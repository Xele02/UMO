
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class HGOAIGFPCBC
{
	public BadgeConstant.ID BEEIIJJKDBH_BadgeConstantId; // 0x8
	public string BHANMJKCCBC_BadgeText; // 0xC
	public int PKNLMLDKCLM_AchievedQuestCount; // 0x10
	
	// RVA: 0x1751ED4 Offset: 0x1751ED4 VA: 0x1751ED4
	public HGOAIGFPCBC()
	{
		return;
	}

	//// RVA: 0x1751EDC Offset: 0x1751EDC VA: 0x1751EDC
	public void FBANBDCOEJL(LayoutQuestTab.eTabType _INDDJNMPONH_type, bool APEPILNOJHL)
	{
		if (APEPILNOJHL)
			QuestUtility.UpdateQuestData(_INDDJNMPONH_type);
		FBANBDCOEJL(QuestUtility.GetAchievedCount(_INDDJNMPONH_type));
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
	public void FBANBDCOEJL(int _HMFFHLPNMPH_count)
	{
		PKNLMLDKCLM_AchievedQuestCount = _HMFFHLPNMPH_count;
		if(_HMFFHLPNMPH_count < 1)
		{
			BEEIIJJKDBH_BadgeConstantId = 0;
			BHANMJKCCBC_BadgeText = "";
		}
		else
		{
			BEEIIJJKDBH_BadgeConstantId = BadgeConstant.ID.Label;
			BHANMJKCCBC_BadgeText = QuestUtility.GetAchievedCountText(_HMFFHLPNMPH_count);
		}
	}
}
