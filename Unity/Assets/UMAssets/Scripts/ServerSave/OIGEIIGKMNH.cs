
using System.Collections.Generic;

[System.Obsolete("Use OIGEIIGKMNH_Valkyrie", true)]
public class OIGEIIGKMNH { }
public class OIGEIIGKMNH_Valkyrie : KLFDBFMNLBL_ServerSaveBlock
{
	public class HLNPGNNPCGO_ValkyrieInfo
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private const sbyte CNECJGKECHK_True = 31;
		private const sbyte JFOFMKBJBBE_False = 56;
		private int BBOLHCKJFCA_IdCrypted; // 0x18
		private sbyte ACKPOCNHOOP_NewCrypted; // 0x1C
		private long KLAPHOKNEDG_DateCrypted; // 0x20
		private int NFCALENBIBL_FPtCrypted; // 0x28
		private sbyte DLFOHMJLHHP_DvfNewCrypted; // 0x2C

		public int FODKKJIDDKN_Id { get { return BBOLHCKJFCA_IdCrypted ^ FBGGEFFJJHB; } set { BBOLHCKJFCA_IdCrypted = value ^ FBGGEFFJJHB; } } //0x1DE4548 LCHMMCPCFDD 0x1DE3D34 DHMLIEPNLCG
		public bool CADENLBDAEB_New { get { return ACKPOCNHOOP_NewCrypted == CNECJGKECHK_True; } set { ACKPOCNHOOP_NewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1DE4558 KJGFPPLHLAB 0x1DE4964 ILJHLPMDHPO
		public long BEBJKJKBOGH_Date { get { return KLAPHOKNEDG_DateCrypted ^ BBEGLBMOBOF; } set { KLAPHOKNEDG_DateCrypted = value ^ BBEGLBMOBOF; } } //0x1DE4534 DIAPHCJBPFD 0x1DE4994 IHAIKPNEEJE
		public int CIEOBFIIPLD_FPt { get { return NFCALENBIBL_FPtCrypted ^ FBGGEFFJJHB; } set { NFCALENBIBL_FPtCrypted = value ^ FBGGEFFJJHB; } } //0x1DE3724 OGKGFGMKPKB 0x1DE377C JOOMBHHPHBD
		public bool FJKIELICMAH_DvfNew { get { return DLFOHMJLHHP_DvfNewCrypted == CNECJGKECHK_True; } set { DLFOHMJLHHP_DvfNewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; }  } //0x1DE456C BIHLHDNGPJP 0x1DE49B4 BCKLGGPBOIK
		public bool FJODMPGPDDD { get { return BEBJKJKBOGH_Date != 0; } } //0x1DE363C CGKAEMGLHNK

		// RVA: 0x1DE3C2C Offset: 0x1DE3C2C VA: 0x1DE3C2C
		public HLNPGNNPCGO_ValkyrieInfo()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
			FODKKJIDDKN_Id = 0;
			CADENLBDAEB_New = false;
			BEBJKJKBOGH_Date = 0;
			CIEOBFIIPLD_FPt = 0;
			FJKIELICMAH_DvfNew = true;
		}

		//// RVA: 0x1DE4BB4 Offset: 0x1DE4BB4 VA: 0x1DE4BB4
		public void ODDIHGPONFL(HLNPGNNPCGO_ValkyrieInfo GPBJHKLFCEP)
		{
			FODKKJIDDKN_Id = GPBJHKLFCEP.FODKKJIDDKN_Id;
			CADENLBDAEB_New = GPBJHKLFCEP.CADENLBDAEB_New;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			CIEOBFIIPLD_FPt = GPBJHKLFCEP.CIEOBFIIPLD_FPt;
			FJKIELICMAH_DvfNew = GPBJHKLFCEP.FJKIELICMAH_DvfNew;
		}

		//// RVA: 0x1DE4EF8 Offset: 0x1DE4EF8 VA: 0x1DE4EF8
		//public bool AGBOGBEOFME(HLNPGNNPCGO OIKJFMGEICL) { }

		//// RVA: 0x1DE53F4 Offset: 0x1DE53F4 VA: 0x1DE53F4
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OIGEIIGKMNH.HLNPGNNPCGO OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<HLNPGNNPCGO_ValkyrieInfo> CNGNBKNBKGI_ValkList { get; private set; } // 0x24 HPMHJMMCOKA PGNBHFIAMPP BDMGCKFBDMI
	//public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1DE34C8 Offset: 0x1DE34C8 VA: 0x1DE34C8
	// public int IJHGOONDKLI(JPIANKEOOMB PEOALFEGNDH) { }

	// // RVA: 0x1DE3658 Offset: 0x1DE3658 VA: 0x1DE3658
	public HLNPGNNPCGO_ValkyrieInfo JMJOPCDNHKK(int FODKKJIDDKN)
	{
		if (FODKKJIDDKN > 100)
			return null;
		return CNGNBKNBKGI_ValkList[FODKKJIDDKN - 1];
	}

	// // RVA: 0x1DE36E4 Offset: 0x1DE36E4 VA: 0x1DE36E4
	public int OEMMJCLJMGB_GetFPt(int FODKKJIDDKN)
	{
		if(JMJOPCDNHKK(FODKKJIDDKN) != null)
		{
			if(JMJOPCDNHKK(FODKKJIDDKN).BEBJKJKBOGH_Date != 0)
				return JMJOPCDNHKK(FODKKJIDDKN).CIEOBFIIPLD_FPt;
		}
		return 0;
	}

	// // RVA: 0x1DE3734 Offset: 0x1DE3734 VA: 0x1DE3734
	// public bool KBBNHBBGDEC(int FODKKJIDDKN, int CIEOBFIIPLD) { }

	// // RVA: 0x1DE378C Offset: 0x1DE378C VA: 0x1DE378C
	// public int HEGDAMANPMF(JPIANKEOOMB PEOALFEGNDH, int NDKJCDGHPLD, int MIHAHCEANII) { }

	// // RVA: 0x1DE397C Offset: 0x1DE397C VA: 0x1DE397C
	// public int NBFPEPBFEHI(int PPFNGGCBJKC, JPIANKEOOMB PEOALFEGNDH) { }

	// // RVA: 0x1DE3A98 Offset: 0x1DE3A98 VA: 0x1DE3A98
	public OIGEIIGKMNH_Valkyrie()
	{
		CNGNBKNBKGI_ValkList = new List<HLNPGNNPCGO_ValkyrieInfo>(100);
		KMBPACJNEOF();
	}

	// // RVA: 0x1DE3B3C Offset: 0x1DE3B3C VA: 0x1DE3B3C Slot: 4
	public override void KMBPACJNEOF()
	{
		CNGNBKNBKGI_ValkList.Clear();
		for(int i = 0; i < 100; i++)
		{
			HLNPGNNPCGO_ValkyrieInfo data = new HLNPGNNPCGO_ValkyrieInfo();
			data.FODKKJIDDKN_Id = i + 1;
			CNGNBKNBKGI_ValkList.Add(data);
		}
	}

	// // RVA: 0x1DE3D44 Offset: 0x1DE3D44 VA: 0x1DE3D44 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1DE4580 Offset: 0x1DE4580 VA: 0x1DE4580 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData data = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if(!blockMissing)
		{
			if(data == null)
			{
				isInvalid = true;
			}
			else
			{
				List<JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo> valkList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList;
				for(int i = 0; i < valkList.Count; i++)
				{
					string key = POFDDFCGEGP + (i + 1);
					if (OILEIIEIBHP.BBAJPINMOEP_Contains(key))
					{
						EDOHBJAPLPF_JsonData info = OILEIIEIBHP[key];
						CNGNBKNBKGI_ValkList[i].FODKKJIDDKN_Id = i + 1;
						CNGNBKNBKGI_ValkList[i].CADENLBDAEB_New = CJAENOMGPDA_ReadInt(info, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new/*new*/, 0, ref isInvalid) != 0;
						CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(info, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date/*date*/, 0, ref isInvalid);
						CNGNBKNBKGI_ValkList[i].CIEOBFIIPLD_FPt = CJAENOMGPDA_ReadInt(info, AFEHLCGHAEE_Strings.OOKGKIONGJF_f_pt/*f_pt*/, 0, ref isInvalid);
						CNGNBKNBKGI_ValkList[i].FJKIELICMAH_DvfNew = CJAENOMGPDA_ReadInt(info, AFEHLCGHAEE_Strings.HMJPPJNLBCM_dvf_new/*dvf_new*/, 1, ref isInvalid) != 0;
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1DE49E4 Offset: 0x1DE49E4 VA: 0x1DE49E4 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OIGEIIGKMNH_Valkyrie v = GPBJHKLFCEP as OIGEIIGKMNH_Valkyrie;
		for(int i = 0; i < CNGNBKNBKGI_ValkList.Count; i++)
		{
			CNGNBKNBKGI_ValkList[i].ODDIHGPONFL(v.CNGNBKNBKGI_ValkList[i]);
		}
	}

	// // RVA: 0x1DE4CB0 Offset: 0x1DE4CB0 VA: 0x1DE4CB0 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1DE4FE8 Offset: 0x1DE4FE8 VA: 0x1DE4FE8 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1DE68D0 Offset: 0x1DE68D0 VA: 0x1DE68D0 Slot: 9
	// public override bool NFKFOODCJJB() { }
}
