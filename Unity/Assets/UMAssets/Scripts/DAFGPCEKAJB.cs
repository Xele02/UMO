
public class DAFGPCEKAJB
{
	public const int FBGGEFFJJHB_xor = 625060344;
	public long JGHELDIAPMG_Crypted; // 0x8
	public int JMFKPCFMNKN_Crypted; // 0x10

	public long AEIMNLACMFA_Damage { get { return JGHELDIAPMG_Crypted ^ FBGGEFFJJHB_xor; } set { JGHELDIAPMG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1768F88 OBJFDJFEAEO 0x1768F9C IOCKEEIFIJD
	public int FJOLNJLLJEJ_rank { get { return JMFKPCFMNKN_Crypted ^ FBGGEFFJJHB_xor; } set { JMFKPCFMNKN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1768FB8 EAKAGHDPEMI 0x1768FCC GHECCGBGCBI

	// // RVA: 0x1768FE0 Offset: 0x1768FE0 VA: 0x1768FE0
	public void KHEKNNFCAOI_Init()
	{
		PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid)
		{
			AEIMNLACMFA_Damage = ev.FBGDBGKNKOD_GetCurrentPoint();
			FJOLNJLLJEJ_rank = ev.CDINKAANIAA_Rank[0];
		}
	}
}
