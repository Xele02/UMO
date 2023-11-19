
namespace XeApp.Game.Menu
{ 
	public class QuestTopFormQuestListArgs : TransitionArgs
	{
		public CGJKNOCAPII viewData; // 0x8

		// RVA: 0x9D9B70 Offset: 0x9D9B70 VA: 0x9D9B70
		public QuestTopFormQuestListArgs(CGJKNOCAPII viewData)
		{
			this.viewData = viewData;
		}

		//// RVA: 0x9D79F8 Offset: 0x9D79F8 VA: 0x9D79F8
		public bool CanShowHelp()
		{
			if(viewData.COAMJFMEIBF != null && viewData.COAMJFMEIBF is KNKDBNFMAKF_EventSp)
			{
				TodoLogger.LogError(0, "Event Sp");
				//return (viewData.COAMJFMEIBF as KNKDBNFMAKF_EventSp).GEPPAGIEMOK(viewData.BCOKKAALGHC);
			}
			return false;
		}

		//// RVA: 0x9D7AE0 Offset: 0x9D7AE0 VA: 0x9D7AE0
		public int GetHelpId()
		{
			if(viewData.COAMJFMEIBF != null && viewData.COAMJFMEIBF is KNKDBNFMAKF_EventSp)
			{
				TodoLogger.LogError(0, "Event Sp");
				//return (viewData.COAMJFMEIBF as KNKDBNFMAKF_EventSp).EDHFKGEIAHB(viewData.BCOKKAALGHC);
			}
			return 0;
		}
	}
}
