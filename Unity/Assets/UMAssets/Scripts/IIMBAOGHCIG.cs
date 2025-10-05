
using XeApp.Game.Common;

public class IIMBAOGHCIG
{
	public enum BEFNGAHBLEN_BadgeType
	{
		HJNNKCMLGFL_0_None = 0,
		JJGHKIBKFFJ_1_Offer = 1,
	}

	public BadgeConstant.ID BEEIIJJKDBH_BadgeConstantId; // 0x8
	public string BHANMJKCCBC_BadgeText; // 0xC

	//// RVA: 0x1204B5C Offset: 0x1204B5C VA: 0x1204B5C
	public void FBANBDCOEJL_Update(bool _CADENLBDAEB_IsNew)
	{
		if(HNNHJGJCFIL() != BEFNGAHBLEN_BadgeType.JJGHKIBKFFJ_1_Offer/*1*/)
		{
			BEEIIJJKDBH_BadgeConstantId = _CADENLBDAEB_IsNew ? BadgeConstant.ID.New : BadgeConstant.ID.None;
			return;
		}
		BEEIIJJKDBH_BadgeConstantId = BadgeConstant.ID.Label;
		BHANMJKCCBC_BadgeText = KDHGBOOECKC.HHCJCDFCLOB.JIDINGHMOJF();
	}

	//// RVA: 0x1204BC0 Offset: 0x1204BC0 VA: 0x1204BC0
	private BEFNGAHBLEN_BadgeType HNNHJGJCFIL()
	{
		if(!KDHGBOOECKC.HHCJCDFCLOB.CCPNBHCKNDC())
		{
			if(!KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk())
			{
				return BEFNGAHBLEN_BadgeType.JJGHKIBKFFJ_1_Offer/*1*/;
			}
			return BEFNGAHBLEN_BadgeType.HJNNKCMLGFL_0_None/*0*/;
		}
		return BEFNGAHBLEN_BadgeType.JJGHKIBKFFJ_1_Offer/*1*/;
	}
}
