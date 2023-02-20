
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use ODPNBADOFAN_Quest", true)]
public class ODPNBADOFAN { }
public class ODPNBADOFAN_Quest : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0
	private const int MKINOABMBGM = 20;
	private const int FOBFLHIIJOM = 1700;
	public long FANICHGKOML; // 0x28

	public List<NFPHOINMHKN> BEGCHDHHEKC { get; private set; } // 0x30 FGGBICBDOEN DEBOJOHHPPB CFINEIEEJGN
	public List<NFPHOINMHKN> GPMKFMFEKLN { get; private set; } // 0x34 LKPJIEOOENM HDOHKBOJCDK CDNIDJPOHDJ
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1B39620 Offset: 0x1B39620 VA: 0x1B39620
	// public long DFFFCPCHBBE() { }

	// // RVA: 0x1B39724 Offset: 0x1B39724 VA: 0x1B39724
	// public int KJJJNMHNMCG(DHOJHGODBAB MHGPMMIDKMM) { }

	// // RVA: 0x1B39890 Offset: 0x1B39890 VA: 0x1B39890
	public ODPNBADOFAN_Quest()
	{
		BEGCHDHHEKC = new List<NFPHOINMHKN>(20);
		GPMKFMFEKLN = new List<NFPHOINMHKN>(1700);
		KMBPACJNEOF();
	}

	// // RVA: 0x1B39950 Offset: 0x1B39950 VA: 0x1B39950 Slot: 4
	public override void KMBPACJNEOF()
	{
		FANICHGKOML = 0;
		BEGCHDHHEKC.Clear();
		GPMKFMFEKLN.Clear();
		int k = (int)Utility.GetCurrentUnixTime() * 0xbd005;
		for(int i = 0; i < 20; i++)
		{
			NFPHOINMHKN data = new NFPHOINMHKN();
			data.FBGGEFFJJHB = k;
			data.PPFNGGCBJKC = i + 1;
			data.EALOBDHOCHP = 0;
			data.BEBJKJKBOGH = 0;
			k *= 0xd;
			data.CADENLBDAEB = true;
			BEGCHDHHEKC.Add(data);
		}
		for(int i = 0; i < 1700; i++)
		{
			NFPHOINMHKN data = new NFPHOINMHKN();
			data.FBGGEFFJJHB = k;
			data.PPFNGGCBJKC = i + 1;
			data.EALOBDHOCHP = 0;
			data.BEBJKJKBOGH = 0;
			k *= 0xb;
			data.CADENLBDAEB = true;
			GPMKFMFEKLN.Clear();
		}
	}

	// // RVA: 0x1B39C80 Offset: 0x1B39C80 VA: 0x1B39C80 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1B3A84C Offset: 0x1B3A84C VA: 0x1B3A84C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x1B3B480 Offset: 0x1B3B480 VA: 0x1B3B480 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1B3B74C Offset: 0x1B3B74C VA: 0x1B3B74C Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1B3BAE4 Offset: 0x1B3BAE4 VA: 0x1B3BAE4 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1B3C0BC Offset: 0x1B3C0BC VA: 0x1B3C0BC Slot: 9
	// public override bool NFKFOODCJJB() { }
}

public class NFPHOINMHKN
{
	public static string POFDDFCGEGP = "_"; // 0x0
	public bool CADENLBDAEB; // 0x8
	public int EHOIENNDEDH; // 0xC
	public int INNAAKJONMJ; // 0x10
	public int FBGGEFFJJHB; // 0x14
	public int EOONNJAMAMJ; // 0x18
	public int BJMDLOCLCEN; // 0x1C
	public long BEBJKJKBOGH; // 0x20

	public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1AF3DF0 DEMEPMAEJOO 0x1AF3E00 HIGKAIDMOKN
	public int EALOBDHOCHP { get { return INNAAKJONMJ ^ FBGGEFFJJHB; } set { INNAAKJONMJ = value ^ FBGGEFFJJHB; EOONNJAMAMJ = value ^ FBGGEFFJJHB; } } //0x1AF3E10 KLDFNIEJBFE 0x1AF3E1C GJLLJFLGMCN
	public int JIOMCDGKIAF { get { return BJMDLOCLCEN ^ FBGGEFFJJHB; } set { BJMDLOCLCEN = value ^ FBGGEFFJJHB; } } //0x1AF3E30 DJHPCCHENCM 0x1AF3E40 CJEGJOKIJPO

	//// RVA: 0x1AF3E50 Offset: 0x1AF3E50 VA: 0x1AF3E50
	//public bool AGBOGBEOFME(NFPHOINMHKN OIKJFMGEICL) { }

	//// RVA: 0x1AF3F70 Offset: 0x1AF3F70 VA: 0x1AF3F70
	//public void ODDIHGPONFL(NFPHOINMHKN GPBJHKLFCEP) { }

	//// RVA: 0x1AF4028 Offset: 0x1AF4028 VA: 0x1AF4028
	//public bool CHFOOMPEABN() { }

	//// RVA: 0x1AF4058 Offset: 0x1AF4058 VA: 0x1AF4058
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NFPHOINMHKN OHMCIEMIKCE, bool EFOEPDLNLJG) { }

	//// RVA: 0x1AF5158 Offset: 0x1AF5158 VA: 0x1AF5158
	//public static int OKJENADDBMC(List<NFPHOINMHKN> NNDGIAEFMOG) { }

	//// RVA: 0x1AF5238 Offset: 0x1AF5238 VA: 0x1AF5238
	//public static int JGJAEKFMEPM(List<NFPHOINMHKN> NNDGIAEFMOG, DHOJHGODBAB MHGPMMIDKMM) { }
}
