using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Intentions.Extensibility.Menu;
using JetBrains.ReSharper.Psi;
using JetBrains.TextControl;
using JetBrains.Util;
using TestCop.Highlighting;

namespace TestCop.QuickFixActions
{

    //http://hadihariri.com/tag/resharper/page/3/
    //http://code.google.com/p/agentsmithplugin/source/browse/branches/R%237.0/src/AgentSmith/SpellCheck/ReplaceWordWithBulbItem.cs?spec=svn316&r=316
    [QuickFix]
    public class MakeItPublicBulbItem : BulbActionBase, IQuickFix
    {
        private readonly ShouldBePublicWarning _highlight;

        public MakeItPublicBulbItem(ShouldBePublicWarning highlight)
        {
            _highlight = highlight;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            _highlight.Declaration.SetAccessRights(AccessRights.PUBLIC);
            return null;
        }

        public override string Text
        {
            get { return String.Format("Make public"); }
        }

        public void CreateBulbItems(BulbMenu menu, Severity severity)
        {
            menu.ArrangeQuickFix(this,Severity.ERROR);;
        }

        public bool IsAvailable(IUserDataHolder cache)
        {
            return _highlight.IsValid();
        }
    }
}
