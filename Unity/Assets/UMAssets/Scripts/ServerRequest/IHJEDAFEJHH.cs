
using System.Collections.Generic;
using UnityEngine;

public class GODKIBIPNLG
{
	public string LJNAKDMILMC; // 0x8
	public List<GJDFHLBONOL> PJJFEAHIPGL; // 0xC
}

public class JAMDHMMODCG
{
	public string OPFGFINHFCE_Name; // 0x8
	public string KLMPFGOCBHC_Description; // 0xC
	public List<GODKIBIPNLG> PJJFEAHIPGL_Inventory; // 0x10
	public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Balances; // 0x14
	public IAPIDHGIEED LKHAAGIJEPG_PlayerStatus; // 0x18
	public static string[] OBHNPDJPJCC = new string[18]
	{
		"lot_1_normal",
		"lot_1_rare",
		"lot_2_normal",
		"lot_2_rare",
		"lot_3_normal",
		"lot_3_rare",
		"lot_4_normal",
		"lot_4_rare",
		"lot_5_normal",
		"lot_5_rare",
		"lot_6_normal",
		"lot_6_rare",
		"lot_7_normal",
		"lot_7_rare",
		"lot_8_normal",
		"lot_8_rare",
		"lot_9_normal",
		"lot_9_rare"
	}; // 0x0

	//// RVA: 0x1415014 Offset: 0x1415014 VA: 0x1415014
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_Description = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		PJJFEAHIPGL_Inventory = new List<GODKIBIPNLG>();
		EDOHBJAPLPF_JsonData inv = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
		for(int i = 0; i < OBHNPDJPJCC.Length; i++)
		{
			if(inv.BBAJPINMOEP_Contains(OBHNPDJPJCC[i]))
			{
				GODKIBIPNLG data = new GODKIBIPNLG();
				data.LJNAKDMILMC = OBHNPDJPJCC[i];
				data.PJJFEAHIPGL = new List<GJDFHLBONOL>();
				EDOHBJAPLPF_JsonData d = inv[OBHNPDJPJCC[i]];
				for(int j = 0; j < d.HNBFOAJIIAL_Count; j++)
				{
					GJDFHLBONOL data2 = new GJDFHLBONOL();
					data2.DPKCOKLMFMK(d[j]);
					data.PJJFEAHIPGL.Add(data2);
				}
				PJJFEAHIPGL_Inventory.Add(data);
			}
		}
		EDOHBJAPLPF_JsonData balances = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
		BBEPLKNMICJ_Balances = new List<MCKCJMLOAFP_CurrencyInfo>(balances.HNBFOAJIIAL_Count);
		for(int i = 0; i < balances.HNBFOAJIIAL_Count; i++)
		{
			MCKCJMLOAFP_CurrencyInfo m = new MCKCJMLOAFP_CurrencyInfo();
			m.DPKCOKLMFMK(balances[i]);
			BBEPLKNMICJ_Balances.Add(m);
		}
		LKHAAGIJEPG_PlayerStatus = new IAPIDHGIEED();
		LKHAAGIJEPG_PlayerStatus.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status]);
	}
}

[System.Obsolete("Use IHJEDAFEJHH_StepUpLotPurchase", true)]
public class IHJEDAFEJHH { }
public class IHJEDAFEJHH_StepUpLotPurchase : CACGCMBKHDI_Request
{
	public string MMEBLOIJBKE_Key; // 0x7C
	public string NNEGBDKOAHN_Hash; // 0x80
	public int APHNELOFGAK; // 0x84
	public int LGEKLPJFJEI; // 0x88

	public JAMDHMMODCG NFEAMMJIMPG { get; set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null; } } //0x11FC7B4 HGPAELCGELL

	// RVA: 0x11FC600 Offset: 0x11FC600 VA: 0x11FC600 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoStepUpLot.Purchase(MMEBLOIJBKE_Key, NNEGBDKOAHN_Hash, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x11FC6F8 Offset: 0x11FC6F8 VA: 0x11FC6F8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	//// RVA: 0x11FC7C4 Offset: 0x11FC7C4 VA: 0x11FC7C4
	private void DIAMDBHBKBH()
	{
		JAMDHMMODCG data = new JAMDHMMODCG();
		data.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG = data;
	}
}

