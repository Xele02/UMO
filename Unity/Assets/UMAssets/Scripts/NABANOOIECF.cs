
public class NABANOOIECF
{
	private const int FBGGEFFJJHB_xor = 0x2541a98f;
	public int EHOIENNDEDH_IdCrypted = FBGGEFFJJHB_xor; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public string KLMPFGOCBHC_description; // 0x10

	public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x17BEE78 DEMEPMAEJOO 0x17BEE8C HIGKAIDMOKN

	// RVA: 0x17BEEA0 Offset: 0x17BEEA0 VA: 0x17BEEA0
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
	}
}
