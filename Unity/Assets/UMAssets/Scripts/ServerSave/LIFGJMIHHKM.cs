
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LIFGJMIHHKM_LimitedItem", true)]
public class LIFGJMIHHKM { }
public class LIFGJMIHHKM_LimitedItem : KLFDBFMNLBL_ServerSaveBlock
{
	public class DOPNDKHMMGI
	{
		public class EFHFKNHFNID
		{
			public int LHKBIALMLCP; // 0x8
			public int CNGMGFCGLOK; // 0xC
			public int JECIEFEOBDO; // 0x10
			public int FBGGEFFJJHB; // 0x14
			public int DJJOKAOHAML; // 0x18
			public int DADJGIPLGBK; // 0x1C

			public int NLMAIPMAHMN { get { return LHKBIALMLCP ^ FBGGEFFJJHB; } set { LHKBIALMLCP = value ^ FBGGEFFJJHB; } } //0x1801E8C AFJLHNHNMKN 0x1801E9C HONPMOAKOGO
			public int PGPGPJNBIOH_Uid { get { return CNGMGFCGLOK ^ FBGGEFFJJHB; } set { CNGMGFCGLOK = value ^ FBGGEFFJJHB; } } //0x17FEB68 CJEDGLPDJBN 0x1800A9C EKJKPIKJLJJ
			public int DOJDOLDDBPP_Hav { get { return DJJOKAOHAML ^ FBGGEFFJJHB; } set { DJJOKAOHAML = value ^ FBGGEFFJJHB; } } //0x1800624 FHJFILKDGGO 0x1800ACC DEEAELHLIEC
			public int DIAPHCJBPFD_Get { get { return JECIEFEOBDO ^ FBGGEFFJJHB; } set { JECIEFEOBDO = value ^ FBGGEFFJJHB; } } //0x17FEB58 EIEMCCANNJE 0x1800AAC JLGBEBCNDJN
			public int IOLJPHAOBOH_Use { get { return DADJGIPLGBK ^ FBGGEFFJJHB; } set { DADJGIPLGBK = value ^ FBGGEFFJJHB; } } //0x1800614 EHKEMJJNKKI 0x1800ABC GHMCNDFEFIF
			//public int HNKFMAJIFJD { get; } 0x17FE608 CEOIBKAGPAG

			//// RVA: 0x17FE280 Offset: 0x17FE280 VA: 0x17FE280
			//public bool NIENPFFLMCH(long JHNMKKNEENE) { }

			//// RVA: 0x1801EAC Offset: 0x1801EAC VA: 0x1801EAC
			//public void DNBGDMBCLMI(int KNEFBLHBDBG) { }

			//// RVA: 0x17FFF90 Offset: 0x17FFF90 VA: 0x17FFF90
			//public void LHPDDGIJKNB(int KNEFBLHBDBG, int JKPPKAHPPKH) { }

			//// RVA: 0x17FEB78 Offset: 0x17FEB78 VA: 0x17FEB78
			//public void HPFJOBPMNCP(int KNEFBLHBDBG, int PGPGPJNBIOH, long JHNMKKNEENE) { }

			//// RVA: 0x17FEFC4 Offset: 0x17FEFC4 VA: 0x17FEFC4
			//public void PKAINJJBMMH(int KNEFBLHBDBG, long KNCKIJBOODM) { }

			//// RVA: 0x1800ADC Offset: 0x1800ADC VA: 0x1800ADC
			public void ODDIHGPONFL(EFHFKNHFNID GPBJHKLFCEP)
			{
				PGPGPJNBIOH_Uid = GPBJHKLFCEP.PGPGPJNBIOH_Uid;
				DIAPHCJBPFD_Get = GPBJHKLFCEP.DIAPHCJBPFD_Get;
				IOLJPHAOBOH_Use = GPBJHKLFCEP.IOLJPHAOBOH_Use;
				DOJDOLDDBPP_Hav = GPBJHKLFCEP.DOJDOLDDBPP_Hav;
			}

			//// RVA: 0x180153C Offset: 0x180153C VA: 0x180153C
			//public bool AGBOGBEOFME(LIFGJMIHHKM.DOPNDKHMMGI.EFHFKNHFNID OIKJFMGEICL) { }

			//// RVA: 0x1801F0C Offset: 0x1801F0C VA: 0x1801F0C
			//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, LIFGJMIHHKM.DOPNDKHMMGI.EFHFKNHFNID OHMCIEMIKCE, bool KFCGIKHEEMB) { }
		}
		public int MAHLPMJFLLJ; // 0x8
		public int NLMAIPMAHMN; // 0xC
		public List<EFHFKNHFNID> PJADHDHKOEJ = new List<EFHFKNHFNID>(); // 0x10
		public List<EFHFKNHFNID> NPNNEDINOKC = new List<EFHFKNHFNID>(); // 0x14

		// RVA: 0x17FFBB8 Offset: 0x17FFBB8 VA: 0x17FFBB8
		public DOPNDKHMMGI(int DOOGFEGEKLG, int JKPPKAHPPKH)
		{
			MAHLPMJFLLJ = DOOGFEGEKLG;
			NLMAIPMAHMN = JKPPKAHPPKH;
		}
	}

	private const int ECFEMKGFDCE = 2;
	public const int HAKDOMMLLJP = 99999999;
	public List<DOPNDKHMMGI> ODHBHOGFNAA = new List<DOPNDKHMMGI>(); // 0x24

	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x17FE0E8 Offset: 0x17FE0E8 VA: 0x17FE0E8
	// public int HPPKOGKNKMH(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x17FE2DC Offset: 0x17FE2DC VA: 0x17FE2DC
	// public int MOAPEHACGDN(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x17FE3AC Offset: 0x17FE3AC VA: 0x17FE3AC
	// public int BLKPKBICPKK(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x17FE71C Offset: 0x17FE71C VA: 0x17FE71C
	// public int CPIICACGNBH(int PPFNGGCBJKC, long JHNMKKNEENE, bool DDGFCOPPBBN = False) { }

	// // RVA: 0x17FEBBC Offset: 0x17FEBBC VA: 0x17FEBBC
	// public List<int> BHNDPHCBCKN(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x17FEE08 Offset: 0x17FEE08 VA: 0x17FEE08
	// public bool LLOAMEOCJEO(int PPFNGGCBJKC, int OIPCCBHIKIA, long KNCKIJBOODM) { }

	// // RVA: 0x17FF00C Offset: 0x17FF00C VA: 0x17FF00C
	// public List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x17FF8F4 Offset: 0x17FF8F4 VA: 0x17FF8F4
	public LIFGJMIHHKM_LimitedItem()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			EGLOKAEIHCB_LimitedItem limitedDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem;
			if(limitedDb.CDENCMNHNGA != null)
			{
				if(limitedDb.CDENCMNHNGA.Count == 0)
				{
					DOPNDKHMMGI data = new DOPNDKHMMGI(9, 0x278d00);
					ODHBHOGFNAA.Add(data);
					return;
				}
				for(int i = 0; i < limitedDb.CDENCMNHNGA.Count; i++)
				{
					DOPNDKHMMGI data = new DOPNDKHMMGI(limitedDb.CDENCMNHNGA[i].DOOGFEGEKLG, limitedDb.CDENCMNHNGA[i].EMIJNAFJFJO * 0x15180);
					ODHBHOGFNAA.Add(data);
				}
			}
		}
	}

	// // RVA: 0x17FFC6C Offset: 0x17FFC6C VA: 0x17FFC6C Slot: 4
	public override void KMBPACJNEOF()
	{
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			DOPNDKHMMGI data = ODHBHOGFNAA[i];
			data.PJADHDHKOEJ.Clear();
			data.NPNNEDINOKC.Clear();
			int k = (int)Utility.GetCurrentUnixTime() * 0x6f;
			for(int j = 0; j < data.MAHLPMJFLLJ; j++)
			{
				DOPNDKHMMGI.EFHFKNHFNID data2 = new DOPNDKHMMGI.EFHFKNHFNID();
				data2.FBGGEFFJJHB = k;
				data2.IOLJPHAOBOH_Use = 0;
				data2.NLMAIPMAHMN = data.NLMAIPMAHMN;
				data2.PGPGPJNBIOH_Uid = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data2.DOJDOLDDBPP_Hav = 0;
				data.PJADHDHKOEJ.Add(data2);
				k *= 0xb;
			}
			for (int j = 0; j < data.MAHLPMJFLLJ; j++)
			{
				DOPNDKHMMGI.EFHFKNHFNID data2 = new DOPNDKHMMGI.EFHFKNHFNID();
				data2.FBGGEFFJJHB = k;
				data2.IOLJPHAOBOH_Use = 0;
				data2.NLMAIPMAHMN = data.NLMAIPMAHMN;
				data2.PGPGPJNBIOH_Uid = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data2.DOJDOLDDBPP_Hav = 0;
				data.NPNNEDINOKC.Add(data2);
				k *= 0xb;
			}
		}
	}

	// // RVA: 0x17FFFAC Offset: 0x17FFFAC VA: 0x17FFFAC Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1800634 Offset: 0x1800634 VA: 0x1800634 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				for(int i = 0; i < ODHBHOGFNAA.Count; i++)
				{
					string str = "_" + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						DOPNDKHMMGI data = ODHBHOGFNAA[i];
						if (b.HNBFOAJIIAL_Count != data.MAHLPMJFLLJ)
							isInvalid = true;
						int cnt = b.HNBFOAJIIAL_Count;
						if (data.MAHLPMJFLLJ < cnt)
							cnt = data.MAHLPMJFLLJ;
						for(int j = 0; j < cnt; j++)
						{
							EDOHBJAPLPF_JsonData b2 = b[j];
							data.PJADHDHKOEJ[j].PGPGPJNBIOH_Uid = CJAENOMGPDA_ReadInt(b2, "uid", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].DIAPHCJBPFD_Get = CJAENOMGPDA_ReadInt(b2, "get", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].IOLJPHAOBOH_Use = CJAENOMGPDA_ReadInt(b2, "use", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].DOJDOLDDBPP_Hav = CJAENOMGPDA_ReadInt(b2, "hav", 0, ref isInvalid);
							data.NPNNEDINOKC[j].ODDIHGPONFL(data.PJADHDHKOEJ[j]);
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1800BA4 Offset: 0x1800BA4 VA: 0x1800BA4 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LIFGJMIHHKM_LimitedItem l = GPBJHKLFCEP as LIFGJMIHHKM_LimitedItem;
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				ODHBHOGFNAA[i].PJADHDHKOEJ[j].ODDIHGPONFL(l.ODHBHOGFNAA[i].PJADHDHKOEJ[j]);
				ODHBHOGFNAA[i].NPNNEDINOKC[j].ODDIHGPONFL(l.ODHBHOGFNAA[i].NPNNEDINOKC[j]);
			}
		}
	}

	// // RVA: 0x1800FD4 Offset: 0x1800FD4 VA: 0x1800FD4 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1801664 Offset: 0x1801664 VA: 0x1801664 Slot: 9
	// public override bool NFKFOODCJJB() { }

	// // RVA: 0x180166C Offset: 0x180166C VA: 0x180166C Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}
}
