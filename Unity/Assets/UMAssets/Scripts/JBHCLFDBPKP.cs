
using System.Collections.Generic;

public class OEJEEHMMPBK
{
	private const int FBGGEFFJJHB_xor = 0x2541a98f;
	public int GKGHEKGGAIF_StepIdxCrypted = FBGGEFFJJHB_xor; // 0x8
	public ABPEPHGCNDA GOKKEPEDLIM_NormalLots; // 0xC
	public ABPEPHGCNDA EFMGKHGMNKA_RareLots; // 0x10

	public int AGBCJMMMLON_StepIndex { get { return GKGHEKGGAIF_StepIdxCrypted ^ FBGGEFFJJHB_xor; } set { GKGHEKGGAIF_StepIdxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1DCBE80 AOGDFNLPBNO 0x1DCBE94 MPINCEJGHJN

	// RVA: 0x1DCBEA8 Offset: 0x1DCBEA8 VA: 0x1DCBEA8
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data, IKMBBPDBECA _KACECFNECON_extra)
	{
		AGBCJMMMLON_StepIndex = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.AGBCJMMMLON_StepIndex];
		string str = "lot_" + AGBCJMMMLON_StepIndex + "_normal";
		EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HALGELBLEPE_lots];
		if(d.BBAJPINMOEP_Contains(str))
		{
			ABPEPHGCNDA data = new ABPEPHGCNDA();
			data.KHEKNNFCAOI_Init(d[str], _KACECFNECON_extra);
			GOKKEPEDLIM_NormalLots = data;
		}
		str = "lot_" + AGBCJMMMLON_StepIndex + "_rare";
		if(d.BBAJPINMOEP_Contains(str))
		{
			ABPEPHGCNDA data = new ABPEPHGCNDA();
			data.KHEKNNFCAOI_Init(d[str], _KACECFNECON_extra);
			data.EKLIPGELKCL_Rarity = true;
			EFMGKHGMNKA_RareLots = data;
		}
	}
}

public class JBHCLFDBPKP
{
	public string OPFGFINHFCE_name; // 0x8
	public string OriginalName;
	public IKMBBPDBECA KACECFNECON_extra; // 0xC
	public List<OEJEEHMMPBK> BMFEGOMNECF_Steps; // 0x10

	// RVA: 0x1420D2C Offset: 0x1420D2C VA: 0x1420D2C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data, bool ENDFGMBBBEE)
	{
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		OriginalName = (string)_IDLHJIOMJBK_Data["original_name"];
		if(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] != null)
		{
			KACECFNECON_extra = IKMBBPDBECA.HEGEKFMJNCC((string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description]);
		}
		if(ENDFGMBBBEE)
		{
			EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BMFEGOMNECF_Steps];
			BMFEGOMNECF_Steps = new List<OEJEEHMMPBK>(d.HNBFOAJIIAL_Count);
			for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
			{
				OEJEEHMMPBK data = new OEJEEHMMPBK();
				data.KHEKNNFCAOI_Init(d[i], KACECFNECON_extra);
				BMFEGOMNECF_Steps.Add(data);
			}
		}
	}
}
