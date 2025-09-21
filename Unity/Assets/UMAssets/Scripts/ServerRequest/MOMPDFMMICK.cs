
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use MOMPDFMMICK_ClaimAchievementPrizesAndSave", true)]
public class MOMPDFMMICK { }
public class MOMPDFMMICK_ClaimAchievementPrizesAndSave : CACGCMBKHDI_Request
{
	public class KMHBJPCCDJJ
	{
		public List<long> COGMPENEPBD_InventoryIds; // 0x8
		public List<GJDFHLBONOL> PJJFEAHIPGL_inventories; // 0xC

		//// RVA: 0x17B9FA4 Offset: 0x17B9FA4 VA: 0x17B9FA4
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			EDOHBJAPLPF_JsonData ids = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
			COGMPENEPBD_InventoryIds = new List<long>(ids.HNBFOAJIIAL_Count);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				COGMPENEPBD_InventoryIds.Add((long)ids[i]);
			}
			EDOHBJAPLPF_JsonData invs = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			PJJFEAHIPGL_inventories = new List<GJDFHLBONOL>(invs.HNBFOAJIIAL_Count);
			for(int i = 0; i < invs.HNBFOAJIIAL_Count; i++)
			{
				GJDFHLBONOL data = new GJDFHLBONOL();
				data.DPKCOKLMFMK(invs[i]);
				PJJFEAHIPGL_inventories.Add(data);
			}
		}
	}

	public class JGCHFAKGAGA
	{
		public List<KMHBJPCCDJJ> CEDLLCCONJP_AchievementPrizes; // 0x8
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Balances; // 0xC
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18
		public int HHGIBAALOHE_DataStatus; // 0x20

		//// RVA: 0x17B974C Offset: 0x17B974C VA: 0x17B974C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BBEPLKNMICJ_Balances))
			{
				EDOHBJAPLPF_JsonData l = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BBEPLKNMICJ_Balances];
				BBEPLKNMICJ_Balances = new List<MCKCJMLOAFP_CurrencyInfo>(l.HNBFOAJIIAL_Count);
				for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
				{
					MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
					data.DPKCOKLMFMK(l[i]);
					BBEPLKNMICJ_Balances.Add(data);
				}
			}
			else
			{
				BBEPLKNMICJ_Balances = null;
			}
			if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CEDLLCCONJP_AchievementPrizes))
			{
				EDOHBJAPLPF_JsonData l = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CEDLLCCONJP_AchievementPrizes];
				CEDLLCCONJP_AchievementPrizes = new List<KMHBJPCCDJJ>(l.HNBFOAJIIAL_Count);
				for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
				{
					KMHBJPCCDJJ data = new KMHBJPCCDJJ();
					data.KHEKNNFCAOI_Init(l[i]);
					CEDLLCCONJP_AchievementPrizes.Add(data);
				}
			}
			BIOGKIEECGN_CreatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BIOGKIEECGN_CreatedAt];
			IFNLEKOILPM_UpdatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IFNLEKOILPM_UpdatedAt];
			HHGIBAALOHE_DataStatus = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
		}
	}

	public long MCKEOKFMLAH_SaveId; // 0x80
	public List<string> EFDFLLPLDKD_Keys; // 0x88
	public List<string> HHIHCJKLJFF_Names; // 0x8C
	public bool KMOBDLBKAAA_Repeatable; // 0x90
	public bool BLOCFLFHCFJ_Keep; // 0x91
	public string AHEFHIMGIBI_PlayerData; // 0x94
	public bool ODMNMFNGBGD; // 0x98
	public List<int> MEGNAIJPBFF_InventoryClosedAt; // 0x9C

	public override bool OIDCBBGLPHL { get { return true; } } //0x17B901C GINMIBJOABO  Slot: 7
	public JGCHFAKGAGA NFEAMMJIMPG_Result { get; private set; } // 0xA0 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0x17B9024 Offset: 0x17B9024 VA: 0x17B9024
	public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE _IDLHJIOMJBK_Data, List<string> _JIMKNDJMCID_Keys, bool GAAFOCCFAJP)
	{
		AHEFHIMGIBI_PlayerData = _IDLHJIOMJBK_Data.PBNINEMAOPB();
		EFDFLLPLDKD_Keys = _JIMKNDJMCID_Keys;
		HHIHCJKLJFF_Names = _IDLHJIOMJBK_Data.KFGDPMNCCFO_NaespaceForSave;
		KMOBDLBKAAA_Repeatable = GAAFOCCFAJP;
		BLOCFLFHCFJ_Keep = _IDLHJIOMJBK_Data.BLOCFLFHCFJ_Keep;
		MCKEOKFMLAH_SaveId = _IDLHJIOMJBK_Data.MCKEOKFMLAH_SaveId;
	}

	//// RVA: 0x17B90C0 Offset: 0x17B90C0 VA: 0x17B90C0
	//public void DOMFHDPMCCO(BBHNACPENDM.EMHDCKMFCGE _IDLHJIOMJBK_Data, List<string> _JIMKNDJMCID_Keys, bool GAAFOCCFAJP, List<int> MEGNAIJPBFF) { }

	//// RVA: 0x17B9184 Offset: 0x17B9184 VA: 0x17B9184
	private bool DEJPNPMHPJD()
	{
		if(MEGNAIJPBFF_InventoryClosedAt != null)
		{
			return MEGNAIJPBFF_InventoryClosedAt.Count > 0;
		}
		return false;
	}

	// RVA: 0x17B9208 Offset: 0x17B9208 VA: 0x17B9208 Slot: 12
	public override void DHLDNIEELHO()
	{
		if(!KMOBDLBKAAA_Repeatable)
		{
			if(DEJPNPMHPJD())
			{
				EBGACDGNCAA_CallContext = SakashoAchievement.ClaimAchievementPrizesAndSaveSetInventoryClosedAt(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Keep, MEGNAIJPBFF_InventoryClosedAt.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
			}
			else
			{
				EBGACDGNCAA_CallContext = SakashoAchievement.ClaimAchievementPrizesAndSave(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Keep, DCKLDDCAJAP, MEOCKCJBDAD);
			}
		}
		else if(DEJPNPMHPJD())
		{
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.ClaimAchievementPrizesAndSaveSetInventoryClosedAt(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Keep, MEGNAIJPBFF_InventoryClosedAt.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
		}
		else
		{
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.ClaimAchievementPrizesAndSave(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Keep, DCKLDDCAJAP, MEOCKCJBDAD);
		}
	}

	// RVA: 0x17B9624 Offset: 0x17B9624 VA: 0x17B9624 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		PJKLMCGEJMK.DALFMJFKCGJ = MCKEOKFMLAH_SaveId;
		NFEAMMJIMPG_Result = new JGCHFAKGAGA();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}

	//// RVA: 0x17B9CB8 Offset: 0x17B9CB8 VA: 0x17B9CB8 Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0x17B9D5C Offset: 0x17B9D5C VA: 0x17B9D5C Slot: 11
	//public override void CBEPCFJOJOI() { }
}
