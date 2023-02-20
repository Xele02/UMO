
using System.Collections.Generic;

[System.Obsolete("Use KDLBHAKPLPH_ArMarker", true)]
public class KDLBHAKPLPH { }
public class KDLBHAKPLPH_ArMarker : KLFDBFMNLBL_ServerSaveBlock
{
	public class KGFJLMLOFED
	{
		public int HIEKBDMHKLP { get; set; } // 0x8 MICLNMBOAJD FEDEEOKEBBH AJEOEBDGIEJ
		public long BEBJKJKBOGH { get; set; } // 0x10 MCIJNMKFMDB DIAPHCJBPFD IHAIKPNEEJE
		//public bool FJODMPGPDDD { get; }

		//// RVA: 0xE7D51C Offset: 0xE7D51C VA: 0xE7D51C
		//public void GLHANCMGNDM(long JGNBPFCJLKI) { }

		//// RVA: 0xE7D534 Offset: 0xE7D534 VA: 0xE7D534
		//public bool CGKAEMGLHNK() { }

		//// RVA: 0xE7C4C4 Offset: 0xE7C4C4 VA: 0xE7C4C4
		//public void ODDIHGPONFL(KDLBHAKPLPH.KGFJLMLOFED GPBJHKLFCEP) { }

		//// RVA: 0xE7C788 Offset: 0xE7C788 VA: 0xE7C788
		//public bool AGBOGBEOFME(KDLBHAKPLPH.KGFJLMLOFED OIKJFMGEICL) { }

		//// RVA: 0xE7CBEC Offset: 0xE7CBEC VA: 0xE7CBEC
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, KDLBHAKPLPH.KGFJLMLOFED OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	 private const int ECFEMKGFDCE = 2;
	 private const int KDNHEMPAGIE = 100;
	 public static string POFDDFCGEGP = "_"; // 0x0

	 public List<KGFJLMLOFED> DNKNFFPLGNM { get; private set; } // 0x24 MJGPHKECNEO KGHIIDAKJOI
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0xE7B884 Offset: 0xE7B884 VA: 0xE7B884
	public KDLBHAKPLPH_ArMarker()
	{
		DNKNFFPLGNM = new List<KGFJLMLOFED>(100);
		KMBPACJNEOF();
	}

	// // RVA: 0xE7B928 Offset: 0xE7B928 VA: 0xE7B928 Slot: 4
	public override void KMBPACJNEOF()
	{
		DNKNFFPLGNM.Clear();
		for(int i = 0; i < 100; i++)
		{
			KGFJLMLOFED data = new KGFJLMLOFED();
			data.HIEKBDMHKLP = i + 1;
			data.BEBJKJKBOGH = 0;
			DNKNFFPLGNM.Add(data);
		}
	}

	// // RVA: 0xE7BA60 Offset: 0xE7BA60 VA: 0xE7BA60 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0xE7C078 Offset: 0xE7C078 VA: 0xE7C078 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0xE7C2F4 Offset: 0xE7C2F4 VA: 0xE7C2F4 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xE7C510 Offset: 0xE7C510 VA: 0xE7C510 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xE7C7E0 Offset: 0xE7C7E0 VA: 0xE7C7E0 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0xE7D4A0 Offset: 0xE7D4A0 VA: 0xE7D4A0 Slot: 9
	// public override bool NFKFOODCJJB() { }
}
