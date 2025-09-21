
[System.Obsolete("Use MCKCJMLOAFP_CurrencyInfo", true)]
public class MCKCJMLOAFP { }
public class MCKCJMLOAFP_CurrencyInfo
{
	public int PPFNGGCBJKC_id; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public string KLMPFGOCBHC_description; // 0x10
	public int JLNEMPJICEH_free; // 0x14
	public int KCKBGALKNMA_paid; // 0x18
	public int BDLNMOIOMHK_Total; // 0x1C

	// RVA: 0x130D5D8 Offset: 0x130D5D8 VA: 0x130D5D8
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		EDOHBJAPLPF_JsonData id = null;
		if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.PPFNGGCBJKC_id))
		{
			id = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		}
		else
		{
			if(!_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("client_virtual_currency_id"))
			{
				;
			}
			else
			{
				id = _IDLHJIOMJBK_Data["client_virtual_currency_id"];
			}
		}
		if(id != null)
		{
			PPFNGGCBJKC_id = (int)id;
		}
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		JLNEMPJICEH_free = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.JLNEMPJICEH_free];
		KCKBGALKNMA_paid = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KCKBGALKNMA_paid];
		BDLNMOIOMHK_Total = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BDLNMOIOMHK_Total];
	}
}
