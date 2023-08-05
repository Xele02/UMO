
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class HGOAIGFPCBC
{
	public BadgeConstant.ID BEEIIJJKDBH; // 0x8
	public string BHANMJKCCBC; // 0xC
	public int PKNLMLDKCLM; // 0x10
	
	// RVA: 0x1751ED4 Offset: 0x1751ED4 VA: 0x1751ED4
	public HGOAIGFPCBC()
	{
		return;
	}

	//// RVA: 0x1751EDC Offset: 0x1751EDC VA: 0x1751EDC
	//public void FBANBDCOEJL(LayoutQuestTab.eTabType INDDJNMPONH, bool APEPILNOJHL) { }

	//// RVA: 0x1752070 Offset: 0x1752070 VA: 0x1752070
	public void FBANBDCOEJL(bool APEPILNOJHL)
	{
		if(APEPILNOJHL)
		{
			QuestUtility.UpdateQuestData();
		}
		FBANBDCOEJL(QuestUtility.GetAchievedCount());
	}

	//// RVA: 0x1751FB4 Offset: 0x1751FB4 VA: 0x1751FB4
	public void FBANBDCOEJL(int HMFFHLPNMPH)
	{
		PKNLMLDKCLM = HMFFHLPNMPH;
		if(HMFFHLPNMPH < 1)
		{
			BEEIIJJKDBH = 0;
			BHANMJKCCBC = "";
		}
		else
		{
			BEEIIJJKDBH = BadgeConstant.ID.Label;
			BHANMJKCCBC = QuestUtility.GetAchievedCountText(HMFFHLPNMPH);
		}
	}
}
