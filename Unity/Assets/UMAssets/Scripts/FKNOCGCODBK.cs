using System.Collections.Generic;

public class FKNOCGCODBK { }
public class FKNOCGCODBK_Unit : KLFDBFMNLBL_SaveBlock
{
	// private const int ECFEMKGFDCE = 3;
	private List<CIFHILOJJFC> AHBBMJANGHE; // 0x24
	public CIFHILOJJFC DBMOBFCLFOB = new CIFHILOJJFC(); // 0x28

	// public CIFHILOJJFC JKNGLJNEEPO { get; }
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x118F3A8 Offset: 0x118F3A8 VA: 0x118F3A8
	public CIFHILOJJFC GCINIJEMHFK(int PPFNGGCBJKC)
	{
		return AHBBMJANGHE[PPFNGGCBJKC];
	}

	// // RVA: 0x118F428 Offset: 0x118F428 VA: 0x118F428
	// public CIFHILOJJFC FJDDNKGHPHN() { }

	// // RVA: 0x118F4A4 Offset: 0x118F4A4 VA: 0x118F4A4
	public FKNOCGCODBK_Unit()
	{
		AHBBMJANGHE = new List<CIFHILOJJFC>(16);
		KMBPACJNEOF();
	}

	// // RVA: 0x118F56C Offset: 0x118F56C VA: 0x118F56C Slot: 4
	public override void KMBPACJNEOF()
	{
		AHBBMJANGHE.Clear();
		for(int i = 0; i < 16; i++)
		{
			CIFHILOJJFC data = new CIFHILOJJFC();
			data.GIDKKHFHALL = i;
			data.OPFGFINHFCE = CIFHILOJJFC.CBELJGBFLGA;
			AHBBMJANGHE.Add(data);
		}
	}

	// // RVA: 0x118F6B0 Offset: 0x118F6B0 VA: 0x118F6B0 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x118FEC0 Offset: 0x118FEC0 VA: 0x118FEC0 Slot: 6
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x11916EC Offset: 0x11916EC VA: 0x11916EC Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x11918C4 Offset: 0x11918C4 VA: 0x11918C4 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1191B20 Offset: 0x1191B20 VA: 0x1191B20 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1191F34 Offset: 0x1191F34 VA: 0x1191F34 Slot: 9
	// public override bool NFKFOODCJJB() { }
}
