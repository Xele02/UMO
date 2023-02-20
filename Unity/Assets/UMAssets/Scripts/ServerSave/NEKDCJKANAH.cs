
using System.Collections.Generic;

[System.Obsolete("Use NEKDCJKANAH_StoryRecord", true)]
public class NEKDCJKANAH { }
public class NEKDCJKANAH_StoryRecord : KLFDBFMNLBL_ServerSaveBlock
{
	public class HKDNILFKCFC
	{
		public const int PIHLDCHFFGL = 1;
		public const int CABPJNMPHEJ = 2;
		public const int POBMLOCCLND = 4;
		public const int OIPLHJIPFPD = 8;
		public const int NKBCBKHPLNP = 0;
		public const int BGCLPLAKANE = 1;
		public const int OJPKNLIBPIP = 2;
		public const int AJOHDNLHJBG = 3;
		public const int KOOCNAOFMJC = 4;
		public int BMPFHHHCNJC; // 0x8
		public int EALOBDHOCHP; // 0xC
		public int NDFOAINJPIN; // 0x10
		public int OKJMIFELDMD; // 0x14
		public int EJKHAFIALGK; // 0x18
		public int PDNJGJNGPNJ; // 0x1C
		public int ODEHJGPDFCL; // 0x20
		public int ABFNAEKEGOB; // 0x24
		public bool ICCJMCCJCBG; // 0x28
		public bool HCENOJKNCMK; // 0x29

		//public bool HALOKFOJMLA { get; } 0x1AE98B8 LKOICFDJNDD

		// RVA: 0x1AE6C08 Offset: 0x1AE6C08 VA: 0x1AE6C08
		public HKDNILFKCFC()
		{
			EJKHAFIALGK = 0;
			BMPFHHHCNJC = 0;
			EALOBDHOCHP = 0;
			NDFOAINJPIN = 0;
			OKJMIFELDMD = 0;
		}

		//// RVA: 0x1AE6C34 Offset: 0x1AE6C34 VA: 0x1AE6C34
		//public void LHPDDGIJKNB() { }

		//// RVA: 0x1AE7410 Offset: 0x1AE7410 VA: 0x1AE7410
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x1AE7E38 Offset: 0x1AE7E38 VA: 0x1AE7E38
		//public bool AGBOGBEOFME(NEKDCJKANAH.HKDNILFKCFC OIKJFMGEICL) { }

		//// RVA: 0x1AE7B24 Offset: 0x1AE7B24 VA: 0x1AE7B24
		//public void ODDIHGPONFL(NEKDCJKANAH.HKDNILFKCFC GPBJHKLFCEP) { }

		//// RVA: 0x1AE8420 Offset: 0x1AE8420 VA: 0x1AE8420
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NEKDCJKANAH.HKDNILFKCFC OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0
	private const int FLPFFEIKAKM = 200;
	private const int FLGCFMIACIN = 3;
	private const int KOLKCGMGLMN = 99999;
	private const int GCAHAAADBEH = 45684125;
	private const int GKIDNIKODDK = 52143548;
	private int AKLLPNDJFCN; // 0x24

	// public bool EOHHFADHHBL { get; set; } FPOHKGALENL 0x1AE66D8  HCFHGHNGPJK 0x1AE66F4
	public List<HKDNILFKCFC> MMKAJBFBKNH { get; private set; } // 0x28 JAKKBNNDGOM BLJEKMOEHCM FJAHCOJOEJO
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1AE6720 Offset: 0x1AE6720 VA: 0x1AE6720
	// public int FKJMJELHGGG() { }

	// // RVA: 0x1AE6804 Offset: 0x1AE6804 VA: 0x1AE6804
	// public int ODOKNPHEIFN(int LFLLLOPAKCO, int EALOBDHOCHP) { }

	// // RVA: 0x1AE68FC Offset: 0x1AE68FC VA: 0x1AE68FC
	// public void NDANPOKGFAN() { }

	// // RVA: 0x1AE6A30 Offset: 0x1AE6A30 VA: 0x1AE6A30
	public NEKDCJKANAH_StoryRecord()
	{
		MMKAJBFBKNH = new List<HKDNILFKCFC>(200);
		KMBPACJNEOF();
	}

	// // RVA: 0x1AE6AD4 Offset: 0x1AE6AD4 VA: 0x1AE6AD4 Slot: 4
	public override void KMBPACJNEOF()
	{
		MMKAJBFBKNH.Clear();
		for(int i = 0; i < 200; i++)
		{
			HKDNILFKCFC data = new HKDNILFKCFC();
			data.BMPFHHHCNJC = i + 1;
			MMKAJBFBKNH.Add(data);
		}
	}

	// // RVA: 0x1AE6C4C Offset: 0x1AE6C4C VA: 0x1AE6C4C Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1AE7448 Offset: 0x1AE7448 VA: 0x1AE7448 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x1AE7928 Offset: 0x1AE7928 VA: 0x1AE7928 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1AE7BC4 Offset: 0x1AE7BC4 VA: 0x1AE7BC4 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1AE7F14 Offset: 0x1AE7F14 VA: 0x1AE7F14 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1AE9734 Offset: 0x1AE9734 VA: 0x1AE9734 Slot: 9
	// public override bool NFKFOODCJJB() { }

	// // RVA: 0x1AE6928 Offset: 0x1AE6928 VA: 0x1AE6928
	// public void LOAOLBNFNNP() { }

	// // RVA: 0x1AE973C Offset: 0x1AE973C VA: 0x1AE973C
	// public void GGKLNCHMPFC(int LFLLLOPAKCO) { }
}
