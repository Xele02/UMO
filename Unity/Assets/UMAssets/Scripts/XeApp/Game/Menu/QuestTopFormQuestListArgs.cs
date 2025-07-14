
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
			KNKDBNFMAKF_EventSp ev = viewData.COAMJFMEIBF as KNKDBNFMAKF_EventSp;
			if(ev != null)
			{
				return ev.GEPPAGIEMOK_CanShowHelp(viewData.BCOKKAALGHC_Group);
			}
			return false;
		}

		//// RVA: 0x9D7AE0 Offset: 0x9D7AE0 VA: 0x9D7AE0
		public int GetHelpId()
		{
			KNKDBNFMAKF_EventSp ev = viewData.COAMJFMEIBF as KNKDBNFMAKF_EventSp;
			if(ev != null)
			{
				return ev.EDHFKGEIAHB_GetHelpId(viewData.BCOKKAALGHC_Group);
			}
			return 0;
		}
	}
}
