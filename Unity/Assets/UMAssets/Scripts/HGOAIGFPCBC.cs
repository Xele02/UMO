
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class HGOAIGFPCBC
{
	public BadgeConstant.ID BEEIIJJKDBH_BadgeId; // 0x8
	public string BHANMJKCCBC_BadgeText; // 0xC
	public int PKNLMLDKCLM_AchievedCount; // 0x10
	
	// RVA: 0x1751ED4 Offset: 0x1751ED4 VA: 0x1751ED4
	public HGOAIGFPCBC()
	{
		return;
	}

	//// RVA: 0x1751EDC Offset: 0x1751EDC VA: 0x1751EDC
	public void FBANBDCOEJL(LayoutQuestTab.eTabType INDDJNMPONH, bool APEPILNOJHL)
	{
		if (APEPILNOJHL)
			QuestUtility.UpdateQuestData(INDDJNMPONH);
		FBANBDCOEJL(QuestUtility.GetAchievedCount(INDDJNMPONH));
	}

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
		PKNLMLDKCLM_AchievedCount = HMFFHLPNMPH;
		if(HMFFHLPNMPH < 1)
		{
			BEEIIJJKDBH_BadgeId = 0;
			BHANMJKCCBC_BadgeText = "";
		}
		else
		{
			BEEIIJJKDBH_BadgeId = BadgeConstant.ID.Label;
			BHANMJKCCBC_BadgeText = QuestUtility.GetAchievedCountText(HMFFHLPNMPH);
		}
	}
}
