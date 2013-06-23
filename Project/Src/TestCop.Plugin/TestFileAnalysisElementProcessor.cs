using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Settings;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Feature.Services.Util;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Caches2;
using JetBrains.ReSharper.Psi.Tree;
using TestCop.Plugin.Extensions;
using TestCop.Plugin.Helper;
using TestCop.Plugin.Highlighting;

namespace TestCop.Plugin
{
    public class TestFileAnalysisElementProcessor : IRecursiveElementProcessor
    {
        private readonly IDaemonProcess _process;
        private readonly IContextBoundSettingsStore _settings;        
        private readonly List<HighlightingInfo> _myHighlightings = new List<HighlightingInfo>();

        public List<HighlightingInfo> Highlightings
        {
            get { return _myHighlightings; }
        }

        public TestFileAnalysisElementProcessor(IDaemonProcess process, IContextBoundSettingsStore settings)
        {
            _process = process;
            _settings = settings;            
        }

        private ISolution Solution { get { return _process.Solution; } }
        private IPsiSourceFile CurrentSourceFile { get { return _process.SourceFile; } }

        private IList<string> TestAttributes
        {
            get
            {
                var testFileAnalysisSettings = _settings.GetKey<TestFileAnalysisSettings>(SettingsOptimization.OptimizeDefault);
                var testingAttributes = testFileAnalysisSettings.TestingAttributes;
                if (testingAttributes.Count == 0)
                {
                    testingAttributes.Add("TestFixture");
                    testingAttributes.Add("TestClass");
                    testingAttributes.Add("TestMethod");
                }
                return testingAttributes;
            }
        }

        private string TestClassSuffix
        {
            get
            {                
                var suffix = Settings.TestClassSuffix;
                if (string.IsNullOrEmpty(suffix))
                {
                    return "Tests";
                }
                return suffix;
            }
        }

        private TestFileAnalysisSettings Settings
        {
            get { return _settings.GetKey<TestFileAnalysisSettings>(SettingsOptimization.OptimizeDefault); }
        }

        private IList<string> BDDPrefixes
        {
            get
            {
                var prefix = Settings.BddPrefixes;               
                return prefix;
            }
        }
              
        public bool InteriorShouldBeProcessed(ITreeNode element)
        {
            return true;
        }

        public void ProcessBeforeInterior(ITreeNode element)
        {
        }

        public void ProcessAfterInterior(ITreeNode element)
        {                                     
            var functionDeclaration = element as ICSharpFunctionDeclaration;
            if (functionDeclaration != null)
            {
                ProcessFunctionDeclaration(functionDeclaration);
            }
            
            var typeDeclaration = element as ICSharpTypeDeclaration;
            if (typeDeclaration != null)
            {
                ProcessTypeDeclaration(typeDeclaration);                           
            }             
        }

      

        private void ProcessTypeDeclaration(ICSharpTypeDeclaration declaration)
        {
            var testingAttributes = FindTestingAttributes(declaration,TestAttributes);                
            if (testingAttributes.Count == 0)
            {                
                /* type is missing attributes - lets check the body */
                if(!CheckMethodsForTestingAttributes(declaration, TestAttributes))return;
            }
            
            //We have a testing attribute so now check some conformance.                       
            CheckElementIsPublicAndCreateWarningIfNot(declaration, testingAttributes);
            if (CheckNamingOfTypeEndsWithTestSuffix(declaration))
            {
                if (CheckNamingOfFileAgainstTypeAndCreateWarningIfNot(declaration))
                {
                    CheckClassnameInFileNameActuallyExistsAndCreateWarningIfNot(declaration);
                }
            }

        }

        static private bool CheckMethodsForTestingAttributes(ICSharpTypeDeclaration declaration, IList<string> testAttributes )
        {
            var sourceFile = declaration.GetSourceFile();
            if (declaration.DeclaredElement == null) return false;
            foreach (var m in declaration.DeclaredElement.Methods.SelectMany(m => m.GetDeclarationsIn(sourceFile)).OfType<IAttributesOwnerDeclaration>())
            {
                if (FindTestingAttributes(m, testAttributes).Any()) return true;                
            }
            return false;
        }

        static IList<IAttribute> FindTestingAttributes(IAttributesOwnerDeclaration element, IList<string> testAttributes)
        {
            var testingAttributes =
                (from a in element.Attributes where testAttributes.Contains(a.Name.QualifiedName) select a).ToList();
            return testingAttributes;
        }

        private void ProcessFunctionDeclaration(ICSharpFunctionDeclaration declaration)
        {
            // Nothing to calculate
            if (declaration.Body == null) return;

            var testingAttributes = FindTestingAttributes(declaration, TestAttributes);                
            if (testingAttributes.Count==0) return;

            CheckElementIsPublicAndCreateWarningIfNot(declaration, testingAttributes);
        }

        public bool ProcessingIsFinished
        {
            get {  return _process.InterruptFlag; }
        }

        private bool CheckNamingOfTypeEndsWithTestSuffix(ICSharpTypeDeclaration declaration)
        {
            if (declaration.IsAbstract) return true;

            var declaredClassName = declaration.DeclaredName;
            if (!declaredClassName.StartsWith(Enumerable.ToArray(BDDPrefixes)))
            {
                if (!declaredClassName.EndsWith(TestClassSuffix))
                {
                    string message = string.Format("Test class names should end with '{0}'.", TestClassSuffix);
                    var testingWarning = new TestClassNameWarning(message, declaration);
                    _myHighlightings.Add(new HighlightingInfo(declaration.GetNameDocumentRange(), testingWarning));
                    return false;

                }
            }
            return true;
        }

        private bool CheckNamingOfFileAgainstTypeAndCreateWarningIfNot(ICSharpTypeDeclaration declaration)
        {
            var declaredClassName = declaration.DeclaredName;
            if (declaredClassName.StartsWith(Enumerable.ToArray(BDDPrefixes))) return false;

            var currentFileName = CurrentSourceFile.GetLocation().NameWithoutExtension;
            var testClassNameFromFileName = currentFileName.Replace(".", "");

            if (testClassNameFromFileName != declaredClassName)
            {
                string message = string.Format("Test classname and filename are not in sync {0}<>{1}.", declaredClassName, testClassNameFromFileName);
                var testingWarning = new TestClassNameWarning(message, declaration);                                
                _myHighlightings.Add(new HighlightingInfo(declaration.GetNameDocumentRange(), testingWarning));
                return false;
            }

            return true;
        }

        private void CheckElementIsPublicAndCreateWarningIfNot(IAccessRightsOwnerDeclaration declaration, IEnumerable<IAttribute> testingAttributes)
        {
            AccessRights accessRights = declaration.GetAccessRights();

            foreach (var attribute in testingAttributes)
            {
                if (accessRights != AccessRights.PUBLIC)
                {                    
                    string message = string.Format("Types with [{0}] must be public.", attribute.Name.QualifiedName);
                    var testingWarning = new ShouldBePublicWarning(message, declaration);
                    _myHighlightings.Add(new HighlightingInfo(declaration.GetNameDocumentRange(), testingWarning));
                    return;
                }
            }
        }

        private void CheckClassnameInFileNameActuallyExistsAndCreateWarningIfNot(ICSharpTypeDeclaration thisDeclaration)
        {
            if (thisDeclaration.IsAbstract) return;
            
            var currentFileName = CurrentSourceFile.GetLocation().NameWithoutExtension;            
            var className = currentFileName.Split(new[] { '.' }, 2)[0].RemoveTrailing(TestClassSuffix);
            
            var declaredElements = ResharperHelper.FindClass(Solution,className);

            var thisProject = thisDeclaration.GetProject();
            var associatedProject = ResharperHelper.FindAssociatedProject(thisProject);
            if (associatedProject == null)
            {
                var highlight = new TestFileNameWarning("Project for this test assembly was not found - check namespace of projects", thisDeclaration);
                _myHighlightings.Add(new HighlightingInfo(thisDeclaration.GetNameDocumentRange(), highlight));
                return;
            }

            var filteredDeclaredElements = new List<IClrDeclaredElement>(declaredElements);
            ResharperHelper.RemoveElementsNotInProject(filteredDeclaredElements, associatedProject);
            
            if (filteredDeclaredElements.Count == 0)
            {
                string message = string.Format("The file name begins with {0} but no matching class exists in associated project", className);

                foreach (var declaredElement in declaredElements)
                {
                    var cls = declaredElement as TypeElement;
                    if (cls != null)
                    {
                         message += string.Format("\nHas it moved to {0}.{1} ?", cls.OwnerNamespaceDeclaration(),cls.GetClrName() );
                    }
                }
                
                var highlight = new TestFileNameWarning(message, thisDeclaration);
                _myHighlightings.Add(new HighlightingInfo(thisDeclaration.GetNameDocumentRange(), highlight));

                return;
            }
            
            if (Settings.CheckTestNamespaces)
            {
                CheckClassNamespaceOfTestMatchesClassUnderTest(thisDeclaration, declaredElements);
            }
        }

        private void CheckClassNamespaceOfTestMatchesClassUnderTest(ICSharpTypeDeclaration thisDeclaration, List<IClrDeclaredElement> declaredElements)
        {            
            var thisProject = thisDeclaration.GetProject();
            var associatedProject = thisProject.GetAssociatedProject();
            if (associatedProject == null) return;
            ResharperHelper.RemoveElementsNotInProject(declaredElements, associatedProject);   

            var thisProjectsDefaultNamespace = thisProject.GetDefaultNamespace();
            if (string.IsNullOrEmpty(thisProjectsDefaultNamespace)) return;

            var associatedProjectsDefaultNameSpace = associatedProject.GetDefaultNamespace();
            if (string.IsNullOrEmpty(associatedProjectsDefaultNameSpace)) return;

            var relativePathNamespaceOfClass =
                thisDeclaration.OwnerNamespaceDeclaration.DeclaredName.RemoveLeading(thisProjectsDefaultNamespace)
                               .RemoveLeading(".");
            var nsToBeFoundShouldBe = associatedProjectsDefaultNameSpace.AppendIfNotNull(".", relativePathNamespaceOfClass);
                       
            //Lookup the namespaces of the declaredElements we've found that possibly match this test             
            IList<string> foundNameSpaces = new List<string>();
            foreach (var declaredTestElement in declaredElements)
            {
                var cls = declaredTestElement as TypeElement;
                if (cls == null) continue;
                var ns = cls.OwnerNamespaceDeclaration();

                if (nsToBeFoundShouldBe == ns)
                {
                    return;//found a match !
                }
                foundNameSpaces.Add(ns);
            }

            foreach (var ns in foundNameSpaces)
            {
                if (ns.StartsWith(associatedProjectsDefaultNameSpace))
                {                    
                    string suggestedNameSpace =
                        thisProjectsDefaultNamespace.AppendIfNotNull(".", ns.Substring(associatedProjectsDefaultNameSpace.Length).TrimStart(new [] {'.'}) );
                    
                    var highlight = new TestFileNameSpaceWarning(thisDeclaration, suggestedNameSpace);
                    _myHighlightings.Add(new HighlightingInfo(thisDeclaration.GetNameDocumentRange(), highlight));                   
                }
            }            
        }         
    }
}