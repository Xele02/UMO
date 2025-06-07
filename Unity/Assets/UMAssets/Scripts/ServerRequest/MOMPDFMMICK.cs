
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use MOMPDFMMICK_ClaimAchievementPrizesAndSave", true)]
public class MOMPDFMMICK { }
public class MOMPDFMMICK_ClaimAchievementPrizesAndSave : CACGCMBKHDI_Request
{
	public class KMHBJPCCDJJ
	{
		public List<long> COGMPENEPBD; // 0x8
		public List<GJDFHLBONOL> PJJFEAHIPGL; // 0xC

		//// RVA: 0x17B9FA4 Offset: 0x17B9FA4 VA: 0x17B9FA4
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData ids = IDLHJIOMJBK[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
			COGMPENEPBD = new List<long>(ids.HNBFOAJIIAL_Count);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				COGMPENEPBD.Add((long)ids[i]);
			}
			EDOHBJAPLPF_JsonData invs = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			PJJFEAHIPGL = new List<GJDFHLBONOL>(invs.HNBFOAJIIAL_Count);
			for(int i = 0; i < invs.HNBFOAJIIAL_Count; i++)
			{
				GJDFHLBONOL data = new GJDFHLBONOL();
				data.DPKCOKLMFMK(invs[i]);
				PJJFEAHIPGL.Add(data);
			}
		}
	}

	public class JGCHFAKGAGA
	{
		public List<KMHBJPCCDJJ> CEDLLCCONJP; // 0x8
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ; // 0xC
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18
		public int HHGIBAALOHE_DataStatus; // 0x20

		//// RVA: 0x17B974C Offset: 0x17B974C VA: 0x17B974C
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances))
			{
				EDOHBJAPLPF_JsonData l = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
				BBEPLKNMICJ = new List<MCKCJMLOAFP_CurrencyInfo>(l.HNBFOAJIIAL_Count);
				for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
				{
					MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
					data.DPKCOKLMFMK(l[i]);
					BBEPLKNMICJ.Add(data);
				}
			}
			else
			{
				BBEPLKNMICJ = null;
			}
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes))
			{
				EDOHBJAPLPF_JsonData l = IDLHJIOMJBK[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes];
				CEDLLCCONJP = new List<KMHBJPCCDJJ>(l.HNBFOAJIIAL_Count);
				for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
				{
					KMHBJPCCDJJ data = new KMHBJPCCDJJ();
					data.KHEKNNFCAOI(l[i]);
					CEDLLCCONJP.Add(data);
				}
			}
			BIOGKIEECGN_CreatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
			HHGIBAALOHE_DataStatus = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
		}
	}

	public long MCKEOKFMLAH; // 0x80
	public List<string> EFDFLLPLDKD_Keys; // 0x88
	public List<string> HHIHCJKLJFF_Names; // 0x8C
	public bool KMOBDLBKAAA; // 0x90
	public bool BLOCFLFHCFJ_Replace; // 0x91
	public string AHEFHIMGIBI_PlayerData; // 0x94
	public bool ODMNMFNGBGD; // 0x98
	public List<int> MEGNAIJPBFF; // 0x9C

	public override bool OIDCBBGLPHL { get { return true; } } //0x17B901C GINMIBJOABO  Slot: 7
	public JGCHFAKGAGA NFEAMMJIMPG { get; private set; } // 0xA0 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0x17B9024 Offset: 0x17B9024 VA: 0x17B9024
	public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, List<string> JIMKNDJMCID, bool GAAFOCCFAJP)
	{
		AHEFHIMGIBI_PlayerData = IDLHJIOMJBK.PBNINEMAOPB();
		EFDFLLPLDKD_Keys = JIMKNDJMCID;
		HHIHCJKLJFF_Names = IDLHJIOMJBK.KFGDPMNCCFO_NaespaceForSave;
		KMOBDLBKAAA = GAAFOCCFAJP;
		BLOCFLFHCFJ_Replace = IDLHJIOMJBK.BLOCFLFHCFJ_Keep;
		MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
	}

	//// RVA: 0x17B90C0 Offset: 0x17B90C0 VA: 0x17B90C0
	//public void DOMFHDPMCCO(BBHNACPENDM.EMHDCKMFCGE IDLHJIOMJBK, List<string> JIMKNDJMCID, bool GAAFOCCFAJP, List<int> MEGNAIJPBFF) { }

	//// RVA: 0x17B9184 Offset: 0x17B9184 VA: 0x17B9184
	private bool DEJPNPMHPJD()
	{
		if(MEGNAIJPBFF != null)
		{
			return MEGNAIJPBFF.Count > 0;
		}
		return false;
	}

	// RVA: 0x17B9208 Offset: 0x17B9208 VA: 0x17B9208 Slot: 12
	public override void DHLDNIEELHO()
	{
		if(!KMOBDLBKAAA)
		{
			if(DEJPNPMHPJD())
			{
				EBGACDGNCAA_CallContext = SakashoAchievement.ClaimAchievementPrizesAndSaveSetInventoryClosedAt(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Replace, MEGNAIJPBFF.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
			}
			else
			{
				EBGACDGNCAA_CallContext = SakashoAchievement.ClaimAchievementPrizesAndSave(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Replace, DCKLDDCAJAP, MEOCKCJBDAD);
			}
		}
		else if(DEJPNPMHPJD())
		{
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.ClaimAchievementPrizesAndSaveSetInventoryClosedAt(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Replace, MEGNAIJPBFF.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
		}
		else
		{
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.ClaimAchievementPrizesAndSave(EFDFLLPLDKD_Keys.ToArray(), HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, ODMNMFNGBGD, !BLOCFLFHCFJ_Replace, DCKLDDCAJAP, MEOCKCJBDAD);
		}
	}

	// RVA: 0x17B9624 Offset: 0x17B9624 VA: 0x17B9624 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		PJKLMCGEJMK.DALFMJFKCGJ = MCKEOKFMLAH;
		NFEAMMJIMPG = new JGCHFAKGAGA();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}

	//// RVA: 0x17B9CB8 Offset: 0x17B9CB8 VA: 0x17B9CB8 Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0x17B9D5C Offset: 0x17B9D5C VA: 0x17B9D5C Slot: 11
	//public override void CBEPCFJOJOI() { }
}
