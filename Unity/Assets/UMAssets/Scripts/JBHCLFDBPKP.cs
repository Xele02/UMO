
using System.Collections.Generic;

public class OEJEEHMMPBK
{
	private const int FBGGEFFJJHB = 0x2541a98f;
	public int GKGHEKGGAIF_StepIdxCrypted = FBGGEFFJJHB; // 0x8
	public ABPEPHGCNDA GOKKEPEDLIM_NormalLots; // 0xC
	public ABPEPHGCNDA EFMGKHGMNKA_RareLots; // 0x10

	public int AGBCJMMMLON_StepIdx { get { return GKGHEKGGAIF_StepIdxCrypted ^ FBGGEFFJJHB; } set { GKGHEKGGAIF_StepIdxCrypted = value ^ FBGGEFFJJHB; } } //0x1DCBE80 AOGDFNLPBNO 0x1DCBE94 MPINCEJGHJN

	// RVA: 0x1DCBEA8 Offset: 0x1DCBEA8 VA: 0x1DCBEA8
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK, IKMBBPDBECA KACECFNECON)
	{
		AGBCJMMMLON_StepIdx = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.AGBCJMMMLON_step_index];
		string str = "lot_" + AGBCJMMMLON_StepIdx + "_normal";
		EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HALGELBLEPE_lots];
		if(d.BBAJPINMOEP_Contains(str))
		{
			ABPEPHGCNDA data = new ABPEPHGCNDA();
			data.KHEKNNFCAOI(d[str], KACECFNECON);
			GOKKEPEDLIM_NormalLots = data;
		}
		str = "lot_" + AGBCJMMMLON_StepIdx + "_rare";
		if(d.BBAJPINMOEP_Contains(str))
		{
			ABPEPHGCNDA data = new ABPEPHGCNDA();
			data.KHEKNNFCAOI(d[str], KACECFNECON);
			data.EKLIPGELKCL_IsRare = true;
			EFMGKHGMNKA_RareLots = data;
		}
	}
}

public class JBHCLFDBPKP
{
	public string OPFGFINHFCE_Name; // 0x8
	public string OriginalName;
	public IKMBBPDBECA KACECFNECON_Desc; // 0xC
	public List<OEJEEHMMPBK> BMFEGOMNECF_Steps; // 0x10

	// RVA: 0x1420D2C Offset: 0x1420D2C VA: 0x1420D2C
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK, bool ENDFGMBBBEE)
	{
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		OriginalName = (string)IDLHJIOMJBK["original_name"];
		if(IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] != null)
		{
			KACECFNECON_Desc = IKMBBPDBECA.HEGEKFMJNCC((string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description]);
		}
		if(ENDFGMBBBEE)
		{
			EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BMFEGOMNECF_steps];
			BMFEGOMNECF_Steps = new List<OEJEEHMMPBK>(d.HNBFOAJIIAL_Count);
			for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
			{
				OEJEEHMMPBK data = new OEJEEHMMPBK();
				data.KHEKNNFCAOI(d[i], KACECFNECON_Desc);
				BMFEGOMNECF_Steps.Add(data);
			}
		}
	}
}
