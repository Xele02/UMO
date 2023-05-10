
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
		//public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK) { }
	}

	public class JGCHFAKGAGA
	{
		public List<KMHBJPCCDJJ> CEDLLCCONJP; // 0x8
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ; // 0xC
		public long BIOGKIEECGN; // 0x10
		public long IFNLEKOILPM; // 0x18
		public int HHGIBAALOHE; // 0x20

		//// RVA: 0x17B974C Offset: 0x17B974C VA: 0x17B974C
		//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
	}

	public long MCKEOKFMLAH; // 0x80
	public List<string> EFDFLLPLDKD_Keys; // 0x88
	public List<string> HHIHCJKLJFF_Names; // 0x8C
	public bool KMOBDLBKAAA; // 0x90
	public bool BLOCFLFHCFJ_Replace; // 0x91
	public string AHEFHIMGIBI_PlayerData; // 0x94
	public bool ODMNMFNGBGD; // 0x98
	public List<int> MEGNAIJPBFF; // 0x9C

	//public override bool OIDCBBGLPHL { get; } 0x17B901C GINMIBJOABO  Slot: 7
	public JGCHFAKGAGA NFEAMMJIMPG { get; private set; } // 0xA0 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0x17B9024 Offset: 0x17B9024 VA: 0x17B9024
	public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, List<string> JIMKNDJMCID, bool GAAFOCCFAJP)
	{
		AHEFHIMGIBI_PlayerData = IDLHJIOMJBK.PBNINEMAOPB();
		EFDFLLPLDKD_Keys = JIMKNDJMCID;
		HHIHCJKLJFF_Names = IDLHJIOMJBK.KFGDPMNCCFO;
		KMOBDLBKAAA = GAAFOCCFAJP;
		BLOCFLFHCFJ_Replace = IDLHJIOMJBK.BLOCFLFHCFJ;
		MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
	}

	//// RVA: 0x17B90C0 Offset: 0x17B90C0 VA: 0x17B90C0
	//public void DOMFHDPMCCO(BBHNACPENDM.EMHDCKMFCGE IDLHJIOMJBK, List<string> JIMKNDJMCID, bool GAAFOCCFAJP, List<int> MEGNAIJPBFF) { }

	//// RVA: 0x17B9184 Offset: 0x17B9184 VA: 0x17B9184
	//private bool DEJPNPMHPJD() { }

	// RVA: 0x17B9208 Offset: 0x17B9208 VA: 0x17B9208 Slot: 12
	public override void DHLDNIEELHO()
	{
		TodoLogger.Log(0, "MOMPDFMMICK_ClaimAchievementPrizesAndSave DHLDNIEELHO");
	}

	// RVA: 0x17B9624 Offset: 0x17B9624 VA: 0x17B9624 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		TodoLogger.Log(0, "MOMPDFMMICK_ClaimAchievementPrizesAndSave MGFNKDPHFGI");
	}

	//// RVA: 0x17B9CB8 Offset: 0x17B9CB8 VA: 0x17B9CB8 Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0x17B9D5C Offset: 0x17B9D5C VA: 0x17B9D5C Slot: 11
	//public override void CBEPCFJOJOI() { }
}
