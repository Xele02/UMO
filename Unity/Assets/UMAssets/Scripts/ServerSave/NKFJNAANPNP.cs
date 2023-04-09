
using System;
using System.Collections.Generic;
using XeSys;

public class NKFJNAANPNP : KLFDBFMNLBL_ServerSaveBlock
{
	public class IAEPMLKOHOB
	{
		public int MACLMNHOBLH; // 0x8
		public int CNGMGFCGLOK; // 0xC
		public int JECIEFEOBDO; // 0x10
		public int FBGGEFFJJHB; // 0x14
		public int DJJOKAOHAML; // 0x18
		public int DADJGIPLGBK; // 0x1C

		public int INNILPKHEKL { get { return MACLMNHOBLH ^ FBGGEFFJJHB; } set { MACLMNHOBLH = value ^ FBGGEFFJJHB; } } //0xC1642C MHAFKCBKDOK 0xC1643C PCPKGMEGIBL
		public int PGPGPJNBIOH_Uid { get { return CNGMGFCGLOK ^ FBGGEFFJJHB; } set { CNGMGFCGLOK = value ^ FBGGEFFJJHB; } } //0xC12FDC CJEDGLPDJBN 0xC14798 EKJKPIKJLJJ
		public int DOJDOLDDBPP_Hav { get { return DJJOKAOHAML ^ FBGGEFFJJHB; } set { DJJOKAOHAML = value ^ FBGGEFFJJHB; } } //0xC1447C FHJFILKDGGO 0xC147C8 DEEAELHLIEC
		public int DIAPHCJBPFD_Get { get { return JECIEFEOBDO ^ FBGGEFFJJHB; } set { JECIEFEOBDO = value ^ FBGGEFFJJHB; } } //0xC12FCC EIEMCCANNJE 0xC147A8 JLGBEBCNDJN
		public int IOLJPHAOBOH_Use { get { return DADJGIPLGBK ^ FBGGEFFJJHB; } set { DADJGIPLGBK = value ^ FBGGEFFJJHB; } } //0xC1446C EHKEMJJNKKI 0xC147B8 GHMCNDFEFIF
		public int HNKFMAJIFJD { get {
				DateTime date = Utility.GetLocalDateTime(INNILPKHEKL + DIAPHCJBPFD_Get);
				return (int)Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
			} } //0xC12AC0 CEOIBKAGPAG

		//// RVA: 0xC12834 Offset: 0xC12834 VA: 0xC12834
		public bool NIENPFFLMCH(long JHNMKKNEENE)
		{
			return DOJDOLDDBPP_Hav == 1 && JHNMKKNEENE >= DIAPHCJBPFD_Get && HNKFMAJIFJD >= JHNMKKNEENE;
		}

		//// RVA: 0xC1644C Offset: 0xC1644C VA: 0xC1644C
		//public void DNBGDMBCLMI(int KNEFBLHBDBG) { }

		//// RVA: 0xC13F2C Offset: 0xC13F2C VA: 0xC13F2C
		//public void LHPDDGIJKNB(int KNEFBLHBDBG, int JKPPKAHPPKH) { }

		//// RVA: 0xC12FEC Offset: 0xC12FEC VA: 0xC12FEC
		//public void HPFJOBPMNCP(int KNEFBLHBDBG, int PGPGPJNBIOH, long JHNMKKNEENE) { }

		//// RVA: 0xC13348 Offset: 0xC13348 VA: 0xC13348
		//public void PKAINJJBMMH(int KNEFBLHBDBG, long KNCKIJBOODM) { }

		//// RVA: 0xC147D8 Offset: 0xC147D8 VA: 0xC147D8
		public void ODDIHGPONFL(IAEPMLKOHOB GPBJHKLFCEP)
		{
			PGPGPJNBIOH_Uid = GPBJHKLFCEP.PGPGPJNBIOH_Uid;
			DIAPHCJBPFD_Get = GPBJHKLFCEP.DIAPHCJBPFD_Get;
			IOLJPHAOBOH_Use = GPBJHKLFCEP.IOLJPHAOBOH_Use;
			DOJDOLDDBPP_Hav = GPBJHKLFCEP.DOJDOLDDBPP_Hav;
		}

		//// RVA: 0xC14DF0 Offset: 0xC14DF0 VA: 0xC14DF0
		//public bool AGBOGBEOFME(NKFJNAANPNP.IAEPMLKOHOB OIKJFMGEICL) { }

		//// RVA: 0xC15328 Offset: 0xC15328 VA: 0xC15328
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NKFJNAANPNP.IAEPMLKOHOB OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	protected int DALBFCKKGGA = 2; // 0x24
	protected int FIBFMLMHOGN = 9; // 0x28
	protected int KOICDJCMKEC = 0x76a6ff; // 0x2C
	private const int HAKDOMMLLJP = 99999999;
	private List<IAEPMLKOHOB> IDJIDAPJCBE; // 0x30
	private List<IAEPMLKOHOB> NPNNEDINOKC; // 0x34
	private ulong NEJBNCHLMNJ = 1; // 0x38
	private string IHGIDOFLDBD = "pd.limited_tikcet"; // 0x40

	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0xC15D58 NFKFOODCJJB

	// // RVA: 0xC126EC Offset: 0xC126EC VA: 0xC126EC
	public int LDLCGGACHGA(long JHNMKKNEENE)
	{
		int res = 0;
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			res += (IDJIDAPJCBE[i].NIENPFFLMCH(JHNMKKNEENE) && NPNNEDINOKC[i].NIENPFFLMCH(JHNMKKNEENE)) ? 1 : 0;
		}
		return res;
	}

	// // RVA: 0xC12890 Offset: 0xC12890 VA: 0xC12890
	// public int BBHIGOOBGID(long JHNMKKNEENE) { }

	// // RVA: 0xC128B0 Offset: 0xC128B0 VA: 0xC128B0
	// public int JCJKKMECCFI(long JHNMKKNEENE) { }

	// // RVA: 0xC12BD4 Offset: 0xC12BD4 VA: 0xC12BD4
	// public int APIEKGBMBPA(long JHNMKKNEENE, bool DDGFCOPPBBN = False) { }

	// // RVA: 0xC13030 Offset: 0xC13030 VA: 0xC13030
	// public List<int> ALGMLEPBEGA(long JHNMKKNEENE) { }

	// // RVA: 0xC131E8 Offset: 0xC131E8 VA: 0xC131E8
	// public void GKFMCICFEFI(int OIPCCBHIKIA, long KNCKIJBOODM) { }

	// // RVA: 0xC13390 Offset: 0xC13390 VA: 0xC13390
	// public List<NKFJNAANPNP.MOJLCADLMKH> MCPIBDPKBBD(long JHNMKKNEENE) { }

	// // RVA: 0xC13BF0 Offset: 0xC13BF0 VA: 0xC13BF0
	public NKFJNAANPNP()
	{
		IDJIDAPJCBE = new List<IAEPMLKOHOB>(FIBFMLMHOGN);
		NPNNEDINOKC = new List<IAEPMLKOHOB>(FIBFMLMHOGN);
		KMBPACJNEOF();
	}

	// // RVA: 0xC13CF8 Offset: 0xC13CF8 VA: 0xC13CF8 Slot: 4
	public override void KMBPACJNEOF()
	{
		IDJIDAPJCBE.Clear();
		NPNNEDINOKC.Clear();
		int k = (int)Utility.GetCurrentUnixTime() * 0x6f;
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			IAEPMLKOHOB data = new IAEPMLKOHOB();
			data.FBGGEFFJJHB = k;
			data.PGPGPJNBIOH_Uid = 0;
			data.DIAPHCJBPFD_Get = 0;
			data.DOJDOLDDBPP_Hav = 0;
			data.IOLJPHAOBOH_Use = 0;
			data.INNILPKHEKL = KOICDJCMKEC;
			IDJIDAPJCBE.Add(data);
			k *= 0xb;
		}
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			IAEPMLKOHOB data = new IAEPMLKOHOB();
			data.FBGGEFFJJHB = k;
			data.PGPGPJNBIOH_Uid = 0;
			data.DIAPHCJBPFD_Get = 0;
			data.DOJDOLDDBPP_Hav = 0;
			data.IOLJPHAOBOH_Use = 0;
			data.INNILPKHEKL = KOICDJCMKEC;
			NPNNEDINOKC.Add(data);
			k *= 0xb;
		}
	}

	// // RVA: 0xC13F48 Offset: 0xC13F48 VA: 0xC13F48 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "OKJPIBHMKMJ");
	}

	// // RVA: 0xC1448C Offset: 0xC1448C VA: 0xC1448C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, DALBFCKKGGA);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if (block.HNBFOAJIIAL_Count != FIBFMLMHOGN)
					isInvalid = true;
				int cnt = block.HNBFOAJIIAL_Count;
				if (FIBFMLMHOGN < cnt)
					cnt = FIBFMLMHOGN;
				for(int i = 0; i < cnt; i++)
				{
					EDOHBJAPLPF_JsonData b = block[i];
					IAEPMLKOHOB data = IDJIDAPJCBE[i];
					data.PGPGPJNBIOH_Uid = CJAENOMGPDA_ReadInt(b, "uid", 0, ref isInvalid);
					data.DIAPHCJBPFD_Get = CJAENOMGPDA_ReadInt(b, "get", 0, ref isInvalid);
					data.IOLJPHAOBOH_Use = CJAENOMGPDA_ReadInt(b, "use", 0, ref isInvalid);
					data.DOJDOLDDBPP_Hav = CJAENOMGPDA_ReadInt(b, "hav", 0, ref isInvalid);
					NPNNEDINOKC[i].ODDIHGPONFL(data);
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xC148A0 Offset: 0xC148A0 VA: 0xC148A0 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NKFJNAANPNP n = GPBJHKLFCEP as NKFJNAANPNP;
		for(int i = 0; i < IDJIDAPJCBE.Count; i++)
		{
			IDJIDAPJCBE[i].ODDIHGPONFL(n.IDJIDAPJCBE[i]);
			NPNNEDINOKC[i].ODDIHGPONFL(n.NPNNEDINOKC[i]);
		}
	}

	// // RVA: 0xC14B04 Offset: 0xC14B04 VA: 0xC14B04 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "AGBOGBEOFME");
		return true;
	}

	// // RVA: 0xC14F18 Offset: 0xC14F18 VA: 0xC14F18 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}

	// // RVA: 0xC15D60 Offset: 0xC15D60 VA: 0xC15D60
	public void JKGBOCBNIIG(ulong PPFNGGCBJKC, string EBBJPBGHJOL)
	{
		NEJBNCHLMNJ = PPFNGGCBJKC;
		IHGIDOFLDBD = EBBJPBGHJOL;
	}

	// // RVA: 0xC15D74 Offset: 0xC15D74 VA: 0xC15D74 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BF1D0 Offset: 0x6BF1D0 VA: 0x6BF1D0
	// // RVA: 0xC15EE4 Offset: 0xC15EE4 VA: 0xC15EE4
	// private int <GetUsableIndexList>b__11_0(int HKICMNAACDA, int BNKHBCBJBKI) { }
}
