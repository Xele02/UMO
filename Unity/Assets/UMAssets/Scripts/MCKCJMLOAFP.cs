
[System.Obsolete("Use MCKCJMLOAFP_CurrencyInfo", true)]
public class MCKCJMLOAFP { }
public class MCKCJMLOAFP_CurrencyInfo
{
	public int PPFNGGCBJKC_Id; // 0x8
	public string OPFGFINHFCE_Name; // 0xC
	public string KLMPFGOCBHC_Description; // 0x10
	public int JLNEMPJICEH_NumFreeCrystal; // 0x14
	public int KCKBGALKNMA_NumPaidCrystal; // 0x18
	public int BDLNMOIOMHK_Total; // 0x1C

	// RVA: 0x130D5D8 Offset: 0x130D5D8 VA: 0x130D5D8
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EDOHBJAPLPF_JsonData id = null;
		if (IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id))
		{
			id = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
		}
		else
		{
			if(!IDLHJIOMJBK.BBAJPINMOEP_Contains("client_virtual_currency_id"))
			{
				;
			}
			else
			{
				id = IDLHJIOMJBK["client_virtual_currency_id"];
			}
		}
		if(id != null)
		{
			PPFNGGCBJKC_Id = (int)id;
		}
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_Description = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		JLNEMPJICEH_NumFreeCrystal = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.JLNEMPJICEH_free];
		KCKBGALKNMA_NumPaidCrystal = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KCKBGALKNMA_paid];
		BDLNMOIOMHK_Total = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BDLNMOIOMHK_total];
	}
}
