
public class MMNNAPPLHFM
{
	private const int FBGGEFFJJHB = 0x2541a98f;
	public int GKGHEKGGAIF_StepIndexCrypted = FBGGEFFJJHB; // 0x8
	public int HNFFLHBKNFC_CurrencyAmmountCrypted = FBGGEFFJJHB; // 0xC
	public int FBBDIKKJBKJ_MaxCountCrypted = FBGGEFFJJHB; // 0x10
	public IKMBBPDBECA KACECFNECON; // 0x14
	public string KLMPFGOCBHC_Description; // 0x18
	public int JCHIEPIBLPC_NormalCountCrypted = FBGGEFFJJHB; // 0x1C
	public int GNIJJPKCKKO_RareCountCrypted = FBGGEFFJJHB; // 0x20

	public int AGBCJMMMLON_StepIndex { get { return GKGHEKGGAIF_StepIndexCrypted ^ FBGGEFFJJHB; } set { GKGHEKGGAIF_StepIndexCrypted = value ^ FBGGEFFJJHB; } } //0x1967964 AOGDFNLPBNO 0x1967978 MPINCEJGHJN
	public int LCJPKJMMIAP_CurrencyAmmount { get { return HNFFLHBKNFC_CurrencyAmmountCrypted ^ FBGGEFFJJHB; } set { HNFFLHBKNFC_CurrencyAmmountCrypted = value ^ FBGGEFFJJHB; } } //0x196798C FIFCKLADNCP 0x19679A0 FEOGBLAIIOC
	public int FHBJOLPCAPN_MaxCount { get { return FBBDIKKJBKJ_MaxCountCrypted ^ FBGGEFFJJHB; } set { FBBDIKKJBKJ_MaxCountCrypted = value ^ FBGGEFFJJHB; } } //0x19679B4 LDCMGLDHHDH 0x19679C8 CMAELNMMLAI
	public int MFFNDOEPJFO_NormalCount { get { return JCHIEPIBLPC_NormalCountCrypted ^ FBGGEFFJJHB; } set { JCHIEPIBLPC_NormalCountCrypted = value ^ FBGGEFFJJHB; } } //0x19679DC JLMLOOIDLGP 0x19679F0 NHHCGFKNBEF
	public int EKOFPNGPCIP_RareCount { get { return GNIJJPKCKKO_RareCountCrypted ^ FBGGEFFJJHB; } set { GNIJJPKCKKO_RareCountCrypted = value ^ FBGGEFFJJHB; } } //0x1967A04 EDOJECAIPGK 0x1967A18 PDEFJLLLCOI
	//public int HMFFHLPNMPH { get; } 0x1967A2C NJOGDDPICKG

	//// RVA: 0x1967A4C Offset: 0x1967A4C VA: 0x1967A4C
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		AGBCJMMMLON_StepIndex = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.AGBCJMMMLON_step_index];
		LCJPKJMMIAP_CurrencyAmmount = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.LCJPKJMMIAP_virtual_currency_amount];
		FHBJOLPCAPN_MaxCount = -1;
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count))
		{
			if(IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count] != null)
			{
				FHBJOLPCAPN_MaxCount = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count];
			}
		}
		if(IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] != null)
		{
			KACECFNECON = IKMBBPDBECA.HEGEKFMJNCC((string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description]);
			KLMPFGOCBHC_Description = KACECFNECON.KLMPFGOCBHC_Description;
		}
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains("lots"))
		{
			EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HALGELBLEPE_lots];
			string s = "lot_" + AGBCJMMMLON_StepIndex + "_normal";
			if(d.BBAJPINMOEP_Contains(s))
			{
				MFFNDOEPJFO_NormalCount = (int)d[s]["count"];
			}
			s = "lot_" + AGBCJMMMLON_StepIndex + "_rare";
			if(d.BBAJPINMOEP_Contains(s))
			{
				EKOFPNGPCIP_RareCount = (int)d[s]["count"];
			}
		}
	}
}
