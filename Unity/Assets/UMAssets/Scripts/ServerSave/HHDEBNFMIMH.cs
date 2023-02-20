
using System.Collections.Generic;

[System.Obsolete("Use HHDEBNFMIMH_Adventure", true)]
public class HHDEBNFMIMH { }
public class HHDEBNFMIMH_Adventure : KLFDBFMNLBL_ServerSaveBlock
{
	public class JLAPDGALDGC
	{
		public int DPMFCMCDBKL { get; set; } // 0x8 PEGDAIOMDKH BDFDFHFLEKI MBOGFMBGAIG
		public bool CADENLBDAEB { get; set; } // 0xC HMFLCAALEKM KJGFPPLHLAB ILJHLPMDHPO
		public long BEBJKJKBOGH { get; set; } // 0x10 MCIJNMKFMDB DIAPHCJBPFD IHAIKPNEEJE
		//public bool FJODMPGPDDD { get; }

		//// RVA: 0x17574A8 Offset: 0x17574A8 VA: 0x17574A8
		//public void GLHANCMGNDM(long JGNBPFCJLKI) { }

		//// RVA: 0x17574C0 Offset: 0x17574C0 VA: 0x17574C0
		//public bool CGKAEMGLHNK() { }

		//// RVA: 0x17560C0 Offset: 0x17560C0 VA: 0x17560C0
		//public void ODDIHGPONFL(HHDEBNFMIMH.JLAPDGALDGC GPBJHKLFCEP) { }

		//// RVA: 0x1756370 Offset: 0x1756370 VA: 0x1756370
		//public bool AGBOGBEOFME(HHDEBNFMIMH.JLAPDGALDGC OIKJFMGEICL) { }

		//// RVA: 0x17567F4 Offset: 0x17567F4 VA: 0x17567F4
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, HHDEBNFMIMH.JLAPDGALDGC OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	 private const int ECFEMKGFDCE = 2;
	 public static string POFDDFCGEGP = "_"; // 0x0

	 public List<JLAPDGALDGC> JBBHBNAJMJB { get; private set; } // 0x24 COIBHDMEMIP PHPKEFFEFLI OBEIGCKJIPF
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x17550EC Offset: 0x17550EC VA: 0x17550EC
	// public void GFANLIOMMNA(int BPNKGDGBBFG) { }

	// // RVA: 0x175523C Offset: 0x175523C VA: 0x175523C
	// public bool FABEJIHKFGN(int MDLFDNOJAJN) { }

	// // RVA: 0x17552F0 Offset: 0x17552F0 VA: 0x17552F0
	public HHDEBNFMIMH_Adventure()
	{
		JBBHBNAJMJB = new List<JLAPDGALDGC>(500);
		KMBPACJNEOF();
	}

	// // RVA: 0x1755394 Offset: 0x1755394 VA: 0x1755394 Slot: 4
	public override void KMBPACJNEOF()
	{
		JBBHBNAJMJB.Clear();
		for(int i = 0; i < 500; i++)
		{
			JLAPDGALDGC data = new JLAPDGALDGC();
			data.DPMFCMCDBKL = i + 1;
			JBBHBNAJMJB.Add(data);
		}
	}

	// // RVA: 0x175549C Offset: 0x175549C VA: 0x175549C Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1755B78 Offset: 0x1755B78 VA: 0x1755B78 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x1755EF0 Offset: 0x1755EF0 VA: 0x1755EF0 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1756128 Offset: 0x1756128 VA: 0x1756128 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x17563E8 Offset: 0x17563E8 VA: 0x17563E8 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x175742C Offset: 0x175742C VA: 0x175742C Slot: 9
	// public override bool NFKFOODCJJB() { }
}
