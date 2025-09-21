
public class MMNNAPPLHFM
{
	private const int FBGGEFFJJHB_xor = 0x2541a98f;
	public int GKGHEKGGAIF_StepIndexCrypted = FBGGEFFJJHB_xor; // 0x8
	public int HNFFLHBKNFC_CurrencyAmmountCrypted = FBGGEFFJJHB_xor; // 0xC
	public int FBBDIKKJBKJ_MaxCountCrypted = FBGGEFFJJHB_xor; // 0x10
	public IKMBBPDBECA KACECFNECON_extra; // 0x14
	public string KLMPFGOCBHC_description; // 0x18
	public int JCHIEPIBLPC_NormalCountCrypted = FBGGEFFJJHB_xor; // 0x1C
	public int GNIJJPKCKKO_RareCountCrypted = FBGGEFFJJHB_xor; // 0x20

	public int AGBCJMMMLON_StepIndex { get { return GKGHEKGGAIF_StepIndexCrypted ^ FBGGEFFJJHB_xor; } set { GKGHEKGGAIF_StepIndexCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1967964 AOGDFNLPBNO 0x1967978 MPINCEJGHJN
	public int LCJPKJMMIAP_virtual_currency_amount { get { return HNFFLHBKNFC_CurrencyAmmountCrypted ^ FBGGEFFJJHB_xor; } set { HNFFLHBKNFC_CurrencyAmmountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x196798C FIFCKLADNCP 0x19679A0 FEOGBLAIIOC
	public int FHBJOLPCAPN_MaxCount { get { return FBBDIKKJBKJ_MaxCountCrypted ^ FBGGEFFJJHB_xor; } set { FBBDIKKJBKJ_MaxCountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19679B4 LDCMGLDHHDH 0x19679C8 CMAELNMMLAI
	public int MFFNDOEPJFO_NormalCount { get { return JCHIEPIBLPC_NormalCountCrypted ^ FBGGEFFJJHB_xor; } set { JCHIEPIBLPC_NormalCountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19679DC JLMLOOIDLGP 0x19679F0 NHHCGFKNBEF
	public int EKOFPNGPCIP_RareCount { get { return GNIJJPKCKKO_RareCountCrypted ^ FBGGEFFJJHB_xor; } set { GNIJJPKCKKO_RareCountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1967A04 EDOJECAIPGK 0x1967A18 PDEFJLLLCOI
	//public int HMFFHLPNMPH_Count { get; } 0x1967A2C NJOGDDPICKG

	//// RVA: 0x1967A4C Offset: 0x1967A4C VA: 0x1967A4C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		AGBCJMMMLON_StepIndex = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.AGBCJMMMLON_StepIndex];
		LCJPKJMMIAP_virtual_currency_amount = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.LCJPKJMMIAP_virtual_currency_amount];
		FHBJOLPCAPN_MaxCount = -1;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHBJOLPCAPN_MaxCount))
		{
			if(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHBJOLPCAPN_MaxCount] != null)
			{
				FHBJOLPCAPN_MaxCount = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHBJOLPCAPN_MaxCount];
			}
		}
		if(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] != null)
		{
			KACECFNECON_extra = IKMBBPDBECA.HEGEKFMJNCC((string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description]);
			KLMPFGOCBHC_description = KACECFNECON_extra.KLMPFGOCBHC_description;
		}
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("lots"))
		{
			EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HALGELBLEPE_lots];
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
