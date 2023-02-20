
using System.Collections.Generic;

[System.Obsolete("Use JGGLDGNKELI_Emblem", true)]
public class JGGLDGNKELI { }
public class JGGLDGNKELI_Emblem : KLFDBFMNLBL_ServerSaveBlock
{
	public class AAHAAJEJNLJ
	{
		public int FBGGEFFJJHB = 0xa93169d; // 0x8

		public int HEJIMPBBFEP { get; set; } // 0xC IBDDDEPKAKK KMPECCNMHAG CNNONBKOMNB
		public int GJOCKDBHEIM { get; set; } // 0x10 EAOGMOMIMED GLEEHIGEGND FKNAHDCMFHE
		public int ABLOIBMGLFD { get { return HEJIMPBBFEP ^ FBGGEFFJJHB; } set { HEJIMPBBFEP = value ^ FBGGEFFJJHB; } } //0xB16DEC PEFEEOLHFGE 0xB16744 LBMNIKJOIIF
		public int FHCAFLCLGAA { get { return GJOCKDBHEIM ^ FBGGEFFJJHB; } set { GJOCKDBHEIM = value ^ FBGGEFFJJHB; } } //0xB16DF8 EMLMAIJNCKP 0xB16754 OKLACIGBMAM
		public long BEBJKJKBOGH { get; set; } // 0x18 MCIJNMKFMDB DIAPHCJBPFD IHAIKPNEEJE
		//public bool FJODMPGPDDD { get; } 0xB173EC CGKAEMGLHNK

		//// RVA: 0xB175CC Offset: 0xB175CC VA: 0xB175CC
		//public void ODDIHGPONFL(JGGLDGNKELI.AAHAAJEJNLJ GPBJHKLFCEP) { }

		//// RVA: 0xB178A0 Offset: 0xB178A0 VA: 0xB178A0
		//public bool AGBOGBEOFME(JGGLDGNKELI.AAHAAJEJNLJ OIKJFMGEICL) { }

		//// RVA: 0xB17D28 Offset: 0xB17D28 VA: 0xB17D28
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, JGGLDGNKELI.AAHAAJEJNLJ OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	 public List<AAHAAJEJNLJ> MDKOHOCONKE { get; private set; } // 0x24 JOMEBEGPPNI GIEDMHKMCEN DJKFGOKGNBF
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0xB16538 Offset: 0xB16538 VA: 0xB16538
	public JGGLDGNKELI_Emblem()
	{
		MDKOHOCONKE = new List<AAHAAJEJNLJ>(999);
		KMBPACJNEOF();
	}

	// // RVA: 0xB165DC Offset: 0xB165DC VA: 0xB165DC Slot: 4
	public override void KMBPACJNEOF()
	{
		MDKOHOCONKE.Clear();
		for(int i = 0; i < 999; i++)
		{
			AAHAAJEJNLJ data = new AAHAAJEJNLJ();
			data.ABLOIBMGLFD = i + 1;
			data.FHCAFLCLGAA = 0;
			data.BEBJKJKBOGH = 0;
			MDKOHOCONKE.Add(data);
		}
	}

	// // RVA: 0xB16774 Offset: 0xB16774 VA: 0xB16774 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0xB16E08 Offset: 0xB16E08 VA: 0xB16E08 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0xB173FC Offset: 0xB173FC VA: 0xB173FC Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xB17658 Offset: 0xB17658 VA: 0xB17658 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xB1791C Offset: 0xB1791C VA: 0xB1791C Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0xB18A1C Offset: 0xB18A1C VA: 0xB18A1C Slot: 9
	// public override bool NFKFOODCJJB() { }
}
