
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use GGKHIHFPKDH_SavePlayerData", true)]
public class GGKHIHFPKDH { }
public class GGKHIHFPKDH_SavePlayerData : CACGCMBKHDI_NetBaseAction, CJIKLGPIPBA
{
	public class HCEPENBDPDP
	{
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_balances; // 0x8
		public long BIOGKIEECGN_created_at; // 0x10
		public long IFNLEKOILPM_updated_at; // 0x18
		public int HHGIBAALOHE_DataStatus; // 0x20

		// RVA: 0xAA2E64 Offset: 0xAA2E64 VA: 0xAA2E64
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances))
			{
				EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
				BBEPLKNMICJ_balances = new List<MCKCJMLOAFP_CurrencyInfo>(b.HNBFOAJIIAL_Count);
				for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
				{
					MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
					data.DPKCOKLMFMK(b[i]);
					BBEPLKNMICJ_balances.Add(data);
				}
			}
			else
			{
				BBEPLKNMICJ_balances = null;
			}
			BIOGKIEECGN_created_at = (long)(int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_updated_at = (long)(int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
			HHGIBAALOHE_DataStatus = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
		}
	}

	public long MCKEOKFMLAH_SaveId; // 0x80
	public List<string> HHIHCJKLJFF_Names; // 0x88
	public string AHEFHIMGIBI_PlayerData; // 0x8C
	public bool CHDDDCCHJJH_replace; // 0x90
	public List<long> AMOMNBEAHBF_InventoryIds; // 0x94

	public override bool OIDCBBGLPHL { get { return true; } } // 0xAA2A74 GINMIBJOABO_bgs
	public HCEPENBDPDP NFEAMMJIMPG_Result { get; set; } // 0x98 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	//// RVA: 0xAA2A7C Offset: 0xAA2A7C VA: 0xAA2A7C
	public void DOMFHDPMCCO_Init(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE _IDLHJIOMJBK_data, List<long> _AMOMNBEAHBF_InventoryIds)
	{
		AHEFHIMGIBI_PlayerData = _IDLHJIOMJBK_data.PBNINEMAOPB();
		CHDDDCCHJJH_replace = !_IDLHJIOMJBK_data.BLOCFLFHCFJ_Keep;
		AMOMNBEAHBF_InventoryIds = _AMOMNBEAHBF_InventoryIds;
		HHIHCJKLJFF_Names = _IDLHJIOMJBK_data.KFGDPMNCCFO_NaespaceForSave;
		MCKEOKFMLAH_SaveId = _IDLHJIOMJBK_data.MCKEOKFMLAH_SaveId;
	}

	//// RVA: 0xAA2B1C Offset: 0xAA2B1C VA: 0xAA2B1C
	public void DOMFHDPMCCO_Init(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE _IDLHJIOMJBK_data, string _JCJDPGMKJAJ_PlayerData, List<long> _AMOMNBEAHBF_InventoryIds)
	{
		AHEFHIMGIBI_PlayerData = _JCJDPGMKJAJ_PlayerData;
		CHDDDCCHJJH_replace = !_IDLHJIOMJBK_data.BLOCFLFHCFJ_Keep;
		AMOMNBEAHBF_InventoryIds = _AMOMNBEAHBF_InventoryIds;
		HHIHCJKLJFF_Names = _IDLHJIOMJBK_data.KFGDPMNCCFO_NaespaceForSave;
		MCKEOKFMLAH_SaveId = _IDLHJIOMJBK_data.MCKEOKFMLAH_SaveId;
	}

	//// RVA: 0xAA2BAC Offset: 0xAA2BAC VA: 0xAA2BAC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerData.SavePlayerData(HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, CHDDDCCHJJH_replace, AMOMNBEAHBF_InventoryIds == null ? null : AMOMNBEAHBF_InventoryIds.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xAA2D3C Offset: 0xAA2D3C VA: 0xAA2D3C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new HCEPENBDPDP();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}

	//// RVA: 0xAA31EC Offset: 0xAA31EC VA: 0xAA31EC Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0xAA3290 Offset: 0xAA3290 VA: 0xAA3290 Slot: 11
	//public override void CBEPCFJOJOI() { }

	//// RVA: 0xAA344C Offset: 0xAA344C VA: 0xAA344C Slot: 17
	public List<string> KPIDBPEKMFD_GetNames()
	{
		return HHIHCJKLJFF_Names;
	}

	//// RVA: 0xAA3454 Offset: 0xAA3454 VA: 0xAA3454 Slot: 18
	public long DPKGNBIAFDO_GetUpdatedAt()
	{
		return NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
	}

	//// RVA: 0xAA3478 Offset: 0xAA3478 VA: 0xAA3478 Slot: 19
	public int JNFCOPCBHAP_GetDataStatus()
	{
		return NFEAMMJIMPG_Result.HHGIBAALOHE_DataStatus;
	}
}
