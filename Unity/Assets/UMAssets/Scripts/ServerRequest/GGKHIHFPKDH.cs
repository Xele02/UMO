
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use GGKHIHFPKDH_SavePlayerData", true)]
public class GGKHIHFPKDH { }
public class GGKHIHFPKDH_SavePlayerData : CACGCMBKHDI_Request, CJIKLGPIPBA
{
	public class HCEPENBDPDP
	{
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ; // 0x8
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18
		public int HHGIBAALOHE_DataStatus; // 0x20

		// RVA: 0xAA2E64 Offset: 0xAA2E64 VA: 0xAA2E64
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances))
			{
				EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
				BBEPLKNMICJ = new List<MCKCJMLOAFP_CurrencyInfo>(b.HNBFOAJIIAL_Count);
				for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
				{
					MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
					data.DPKCOKLMFMK(b[i]);
					BBEPLKNMICJ.Add(data);
				}
			}
			else
			{
				BBEPLKNMICJ = null;
			}
			BIOGKIEECGN_CreatedAt = (long)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_UpdatedAt = (long)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
			HHGIBAALOHE_DataStatus = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
		}
	}

	public long MCKEOKFMLAH; // 0x80
	public List<string> HHIHCJKLJFF_Names; // 0x88
	public string AHEFHIMGIBI_PlayerData; // 0x8C
	public bool CHDDDCCHJJH_Replace; // 0x90
	public List<long> AMOMNBEAHBF_InventoryIds; // 0x94

	//public override bool OIDCBBGLPHL { get; }
	public HCEPENBDPDP NFEAMMJIMPG { get; set; } // 0x98 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0xAA2A74 Offset: 0xAA2A74 VA: 0xAA2A74 Slot: 7
	//public override bool GINMIBJOABO() { }

	//// RVA: 0xAA2A7C Offset: 0xAA2A7C VA: 0xAA2A7C
	//public void DOMFHDPMCCO(BBHNACPENDM.EMHDCKMFCGE IDLHJIOMJBK, List<long> AMOMNBEAHBF) { }

	//// RVA: 0xAA2B1C Offset: 0xAA2B1C VA: 0xAA2B1C
	public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, string JCJDPGMKJAJ, List<long> AMOMNBEAHBF)
	{
		AHEFHIMGIBI_PlayerData = JCJDPGMKJAJ;
		CHDDDCCHJJH_Replace = !IDLHJIOMJBK.BLOCFLFHCFJ;
		AMOMNBEAHBF_InventoryIds = AMOMNBEAHBF;
		HHIHCJKLJFF_Names = IDLHJIOMJBK.KFGDPMNCCFO;
		MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
	}

	//// RVA: 0xAA2BAC Offset: 0xAA2BAC VA: 0xAA2BAC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerData.SavePlayerData(HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, CHDDDCCHJJH_Replace, AMOMNBEAHBF_InventoryIds == null ? null : AMOMNBEAHBF_InventoryIds.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xAA2D3C Offset: 0xAA2D3C VA: 0xAA2D3C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new HCEPENBDPDP();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}

	//// RVA: 0xAA31EC Offset: 0xAA31EC VA: 0xAA31EC Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0xAA3290 Offset: 0xAA3290 VA: 0xAA3290 Slot: 11
	//public override void CBEPCFJOJOI() { }

	//// RVA: 0xAA344C Offset: 0xAA344C VA: 0xAA344C Slot: 17
	//public List<string> KPIDBPEKMFD() { }

	//// RVA: 0xAA3454 Offset: 0xAA3454 VA: 0xAA3454 Slot: 18
	//public long DPKGNBIAFDO() { }

	//// RVA: 0xAA3478 Offset: 0xAA3478 VA: 0xAA3478 Slot: 19
	//public int JNFCOPCBHAP() { }
}
