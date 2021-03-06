// --
// -- TestCop http://github.com/testcop
// -- License http://github.com/testcop/license
// -- Copyright 2014
// --

using System.IO;
using JetBrains.Application.Settings;
using JetBrains.Application.UI.ActionsRevised.Menu;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi;
using NUnit.Framework;

namespace TestCop.Plugin.Tests.MultipleTestProjectToSingleCodeProjectViaNamespace
{    
    [TestFixture]
    public class ClassToTestFileNavigationTests : CSharpHighlightingWithinSolutionTestBase
    {
        protected override bool HighlightingPredicate(IHighlighting highlighting, IPsiSourceFile sourceFile, IContextBoundSettingsStore settingsStore)
        {
            return highlighting.GetType().Namespace.Contains("TestCop");
        }

        protected override string RelativeTestDataPath
        {
            get { return @"MultipleTestProjectToSingleCodeProject\ClassToTestNavigation"; }
        }

        protected override IExecutableAction GetShortcutAction(TextWriter textwriter)
        {
            IExecutableAction jumpToTestFileAction = JumpToTestFileAction.CreateWith(CreateJetPopMenuShowToWriterAction(textwriter));
            return jumpToTestFileAction;
        }
        protected override string SolutionName
        {
            get { return @"TestApplication.sln"; }
        }
   
        [Test]
        [TestCase(@"<TestApplication>\NG1\ClassWithUnitOnly.cs")]
        [TestCase(@"<TestApplication>\NG1\ClassWithIntegrationOnly.cs")]
        [TestCase(@"<TestApplication>\NG1\ClassWithBoth.cs")]
        [TestCase(@"<TestApplication>\Properties\AssemblyInfo.cs")]

        [TestCase(@"<TestApplication>\NG1\NonNamespaceFolder\ClassDInNonNamespace.cs")]
        public void Test(string testName)
        {            
            ExecuteWithinSettingsTransaction((settingsStore =>
            {
                RunGuarded(
                    () =>
                    {                        
                        SetupTestCopSettings(settingsStore);
                    }
                    
                    );
                DoTestFiles(testName);
            }));
        }

        internal static void SetupTestCopSettings(IContextBoundSettingsStore settingsStore)
        {
            const string altRegEx = "^(.*?)\\.?(Integration)*Tests$";

            ClearRegExSettingsPriorToRun(settingsStore);

            settingsStore.SetValue<TestFileAnalysisSettings, bool>(
                s => s.FindOrphanedProjectFiles, true);

            settingsStore.SetValue<TestFileAnalysisSettings, string>(
                s => s.TestClassSuffix, "Tests,IntegrationTests");

            settingsStore.SetValue<TestFileAnalysisSettings, string>(
                s => s.TestProjectToCodeProjectNameSpaceRegEx, altRegEx);
            settingsStore.SetValue<TestFileAnalysisSettings, string>(
                s => s.TestProjectToCodeProjectNameSpaceRegExReplace, "$1");
        }
    }
}
