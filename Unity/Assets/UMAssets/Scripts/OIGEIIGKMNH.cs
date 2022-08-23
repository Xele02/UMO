
using System.Collections.Generic;

public class OIGEIIGKMNH { }
public class OIGEIIGKMNH_Valkyrie : KLFDBFMNLBL_SaveBlock
{
	public class HLNPGNNPCGO
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private const sbyte CNECJGKECHK_False = 31;
		private const sbyte JFOFMKBJBBE_True = 56;
		private int BBOLHCKJFCA; // 0x18
		private sbyte ACKPOCNHOOP; // 0x1C
		private long KLAPHOKNEDG; // 0x20
		private int NFCALENBIBL; // 0x28
		private sbyte DLFOHMJLHHP; // 0x2C

		public int FODKKJIDDKN { get { return BBOLHCKJFCA ^ FBGGEFFJJHB; } set { BBOLHCKJFCA = value ^ FBGGEFFJJHB; } } //0x1DE4548 LCHMMCPCFDD 0x1DE3D34 DHMLIEPNLCG
		//public bool CADENLBDAEB { get; set; } 0x1DE4558 KJGFPPLHLAB 0x1DE4964 ILJHLPMDHPO
		//public long BEBJKJKBOGH { get; set; } 0x1DE4534 DIAPHCJBPFD 0x1DE4994 IHAIKPNEEJE
		//public int CIEOBFIIPLD { get; set; } 0x1DE3724 OGKGFGMKPKB 0x1DE377C JOOMBHHPHBD
		//public bool FJKIELICMAH { get; set; } 0x1DE456C BIHLHDNGPJP 0x1DE49B4 BCKLGGPBOIK
		//public bool FJODMPGPDDD { get; } 0x1DE363C CGKAEMGLHNK

		// RVA: 0x1DE3C2C Offset: 0x1DE3C2C VA: 0x1DE3C2C
		public HLNPGNNPCGO()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = FBGGEFFJJHB;
			BBOLHCKJFCA = FBGGEFFJJHB;
			ACKPOCNHOOP = JFOFMKBJBBE_True;
			KLAPHOKNEDG = ~FBGGEFFJJHB;
			NFCALENBIBL = FBGGEFFJJHB;
			DLFOHMJLHHP = CNECJGKECHK_False;
		}

		//// RVA: 0x1DE4BB4 Offset: 0x1DE4BB4 VA: 0x1DE4BB4
		//public void ODDIHGPONFL(HLNPGNNPCGO GPBJHKLFCEP) { }

		//// RVA: 0x1DE4EF8 Offset: 0x1DE4EF8 VA: 0x1DE4EF8
		//public bool AGBOGBEOFME(HLNPGNNPCGO OIKJFMGEICL) { }

		//// RVA: 0x1DE53F4 Offset: 0x1DE53F4 VA: 0x1DE53F4
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OIGEIIGKMNH.HLNPGNNPCGO OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<HLNPGNNPCGO> CNGNBKNBKGI { get; private set; } // 0x24 HPMHJMMCOKA PGNBHFIAMPP BDMGCKFBDMI
	//public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1DE34C8 Offset: 0x1DE34C8 VA: 0x1DE34C8
	// public int IJHGOONDKLI(JPIANKEOOMB PEOALFEGNDH) { }

	// // RVA: 0x1DE3658 Offset: 0x1DE3658 VA: 0x1DE3658
	// public OIGEIIGKMNH.HLNPGNNPCGO JMJOPCDNHKK(int FODKKJIDDKN) { }

	// // RVA: 0x1DE36E4 Offset: 0x1DE36E4 VA: 0x1DE36E4
	// public int OEMMJCLJMGB(int FODKKJIDDKN) { }

	// // RVA: 0x1DE3734 Offset: 0x1DE3734 VA: 0x1DE3734
	// public bool KBBNHBBGDEC(int FODKKJIDDKN, int CIEOBFIIPLD) { }

	// // RVA: 0x1DE378C Offset: 0x1DE378C VA: 0x1DE378C
	// public int HEGDAMANPMF(JPIANKEOOMB PEOALFEGNDH, int NDKJCDGHPLD, int MIHAHCEANII) { }

	// // RVA: 0x1DE397C Offset: 0x1DE397C VA: 0x1DE397C
	// public int NBFPEPBFEHI(int PPFNGGCBJKC, JPIANKEOOMB PEOALFEGNDH) { }

	// // RVA: 0x1DE3A98 Offset: 0x1DE3A98 VA: 0x1DE3A98
	public OIGEIIGKMNH_Valkyrie()
	{
		CNGNBKNBKGI = new List<HLNPGNNPCGO>(100);
		KMBPACJNEOF();
	}

	// // RVA: 0x1DE3B3C Offset: 0x1DE3B3C VA: 0x1DE3B3C Slot: 4
	public override void KMBPACJNEOF()
	{
		CNGNBKNBKGI.Clear();
		for(int i = 0; i < 100; i++)
		{
			HLNPGNNPCGO data = new HLNPGNNPCGO();
			data.FODKKJIDDKN = i + 1;
			CNGNBKNBKGI.Add(data);
		}
	}

	// // RVA: 0x1DE3D44 Offset: 0x1DE3D44 VA: 0x1DE3D44 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1DE4580 Offset: 0x1DE4580 VA: 0x1DE4580 Slot: 6
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool b1 = false;
		bool b2 = false;
		EDOHBJAPLPF_JsonData data = KLFDBFMNLBL.LGPBAKLCFHI(OILEIIEIBHP, ref b1, ref b2, 2);
		if(!b1)
		{
			if(data == null)
			{
!!!
			}
			else
			{
				List<JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo> valkList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x1DE49E4 Offset: 0x1DE49E4 VA: 0x1DE49E4 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1DE4CB0 Offset: 0x1DE4CB0 VA: 0x1DE4CB0 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1DE4FE8 Offset: 0x1DE4FE8 VA: 0x1DE4FE8 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1DE68D0 Offset: 0x1DE68D0 VA: 0x1DE68D0 Slot: 9
	// public override bool NFKFOODCJJB() { }
}
