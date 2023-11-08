
namespace XeApp.Game.Menu
{ 
	public class QuestTopArgs : TransitionArgs
	{
		public int tabType; // 0x8

		// RVA: 0x9D6D6C Offset: 0x9D6D6C VA: 0x9D6D6C
		public QuestTopArgs(PLADCDJLOBE.ENNOBKHBNCG tabType)
		{
			this.tabType = (int)tabType;
		}

		// RVA: 0x9D9B50 Offset: 0x9D9B50 VA: 0x9D9B50
		public QuestTopArgs(int tabType)
		{
			this.tabType = tabType;
		}
	}
}
