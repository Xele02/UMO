
using System.Collections.Generic;
using XeSys;

public class OCLHKHAMDHF { }
public class OCLHKHAMDHF_Episode : KLFDBFMNLBL_ServerSaveBlock
{
	public class JEHNEEBBDBO_EpisodeInfo
	{
		private int FBGGEFFJJHB; // 0x8
		private int GDIKAELAKBN; // 0xC
		private int EFLHPLDPEHJ_StepCrypted; // 0x10
		private int BMNPNDCOGOJ_StepCheck; // 0x14
		private int FKEOAJOIILO; // 0x18
		private int EEEHAJPKFLP; // 0x1C
		private long KLAPHOKNEDG; // 0x20
		private byte[] GDLLDIJEGCB = new byte[10]; // 0x28
		public List<int> PHJFOJLMFGK; // 0x2C
		public bool LHMOAJAIJCO; // 0x30

		public int HPLMMKHBKIG { get { return GDIKAELAKBN ^ FBGGEFFJJHB; } set { GDIKAELAKBN = value ^ GDIKAELAKBN; } } //0x1B2D9F4 CABAPDMNCDN 0x1B2E04C BIEKAEDMACK
		public int OGDBKJKIGAJ_Step { get {
				int res = EFLHPLDPEHJ_StepCrypted ^ FBGGEFFJJHB;
				if (BMNPNDCOGOJ_StepCheck != res)
					return 0;
				return res;
			} set
			{
				EFLHPLDPEHJ_StepCrypted = value ^ FBGGEFFJJHB;
				BMNPNDCOGOJ_StepCheck = value;
			}
		} //0x1B2DA00 KPOKGLEGCON 0x1B2E05C CJKKCALKIKL
		public long BEBJKJKBOGH { get { return KLAPHOKNEDG ^ FBGGEFFJJHB; } set { KLAPHOKNEDG = value ^ FBGGEFFJJHB; } } //0x1B2D9DC DIAPHCJBPFD 0x1B2E084 IHAIKPNEEJE
		public int EBIIIAELNAA { get { return EEEHAJPKFLP ^ FBGGEFFJJHB; } set { EEEHAJPKFLP = value ^ FBGGEFFJJHB; FKEOAJOIILO = value; } } //0x1B2C830 DNHBBMADHBB 0x1B2E070 KHFOJPIEFKJ

		//// RVA: 0x1B30860 Offset: 0x1B30860 VA: 0x1B30860
		public void BDPOOJDJKAA(int OIPCCBHIKIA, bool LNACKEBEMOB)
		{
			GDLLDIJEGCB[OIPCCBHIKIA] = (byte)(LNACKEBEMOB ? (FBGGEFFJJHB * (OIPCCBHIKIA + 1) & 0xf) ^ 0xf : (FBGGEFFJJHB * (OIPCCBHIKIA + 1) & 0xf));
		}

		//// RVA: 0x1B2DA1C Offset: 0x1B2DA1C VA: 0x1B2DA1C
		//public bool MCIHDIBHHBI(int OIPCCBHIKIA) { }

		//// RVA: 0x1B2D03C Offset: 0x1B2D03C VA: 0x1B2D03C
		public void LHPDDGIJKNB(int PPFNGGCBJKC, int KNEFBLHBDBG)
		{
			LHMOAJAIJCO = false;
			PHJFOJLMFGK = null;
			FBGGEFFJJHB = KNEFBLHBDBG;
			HPLMMKHBKIG = PPFNGGCBJKC;
			OGDBKJKIGAJ_Step = 0;
			FKEOAJOIILO = 0;
			EBIIIAELNAA = 0;
			BEBJKJKBOGH = 0;
			for(int i = 0; i < 10; i++)
			{
				BDPOOJDJKAA(i, false);
			}
		}

		//// RVA: 0x1B2E5E0 Offset: 0x1B2E5E0 VA: 0x1B2E5E0
		//public bool AGBOGBEOFME(OCLHKHAMDHF.JEHNEEBBDBO OIKJFMGEICL) { }

		//// RVA: 0x1B2E268 Offset: 0x1B2E268 VA: 0x1B2E268
		//public void ODDIHGPONFL(OCLHKHAMDHF.JEHNEEBBDBO GPBJHKLFCEP) { }

		//// RVA: 0x1B2EBDC Offset: 0x1B2EBDC VA: 0x1B2EBDC
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OCLHKHAMDHF.JEHNEEBBDBO OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		//// RVA: 0x1B305C8 Offset: 0x1B305C8 VA: 0x1B305C8
		public FENCAJJBLBH PFAKPFKJJKA()
		{
			if (FBGGEFFJJHB == 0)
				return null;
			if((EFLHPLDPEHJ_StepCrypted ^ FBGGEFFJJHB) != BMNPNDCOGOJ_StepCheck)
			{
				return new FENCAJJBLBH(FENCAJJBLBH.EIAPDOGALDK.AIEOCNLGLEE, 0x16, GDIKAELAKBN ^ FBGGEFFJJHB, "pd.episode.ep_step");
			}
			!!!
		}

		//// RVA: 0x1B308D0 Offset: 0x1B308D0 VA: 0x1B308D0
		//public bool MOACIBEKLEN(KMOGDEOKHPG MOLEPBNJAGE, int GNDJCANPLDJ, bool DDGFCOPPBBN = False) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<JEHNEEBBDBO_EpisodeInfo> BBAJKJPKOHD { get; private set; } // 0x24 LOGMEMCACAC NNNEPHIJAKK HIAFHIDDPEJ
	//public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1B2C690 Offset: 0x1B2C690 VA: 0x1B2C690
	// public int GGKOLJCPNKO(KMOGDEOKHPG MOLEPBNJAGE) { }

	// // RVA: 0x1B2C840 Offset: 0x1B2C840 VA: 0x1B2C840
	// public List<OCLHKHAMDHF.MGGPEOCPIEG> POEDIMMMLME(KMOGDEOKHPG MOLEPBNJAGE, ref bool AJFHCEEKPPA) { }

	// // RVA: 0x1B2CCFC Offset: 0x1B2CCFC VA: 0x1B2CCFC
	// public void BOAIINJHENE() { }

	// // RVA: 0x1B2CDD4 Offset: 0x1B2CDD4 VA: 0x1B2CDD4
	public OCLHKHAMDHF_Episode()
	{
		BBAJKJPKOHD = new List<JEHNEEBBDBO_EpisodeInfo>(500);
		KMBPACJNEOF();
	}

	// // RVA: 0x1B2CE78 Offset: 0x1B2CE78 VA: 0x1B2CE78 Slot: 4
	public override void KMBPACJNEOF()
	{
		long time = Utility.GetCurrentUnixTime();
		int key = (int)(time ^ 0x1476775d);
		BBAJKJPKOHD.Clear();
		for(int i = 0; i < 500; i++)
		{
			JEHNEEBBDBO_EpisodeInfo data = new JEHNEEBBDBO_EpisodeInfo();
			data.LHPDDGIJKNB(i + 1, key);
			BBAJKJPKOHD.Add(data);
			key = key * 0x5d3 + 0x6f;
		}
	}

	// // RVA: 0x1B2D098 Offset: 0x1B2D098 VA: 0x1B2D098 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1B2DA80 Offset: 0x1B2DA80 VA: 0x1B2DA80 Slot: 6
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x1B2E098 Offset: 0x1B2E098 VA: 0x1B2E098 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1B2E398 Offset: 0x1B2E398 VA: 0x1B2E398 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1B2E7D0 Offset: 0x1B2E7D0 VA: 0x1B2E7D0 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1B304DC Offset: 0x1B304DC VA: 0x1B304DC Slot: 9
	// public override bool NFKFOODCJJB() { }

	// // RVA: 0x1B304E4 Offset: 0x1B304E4 VA: 0x1B304E4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		for(int i = 0; i < BBAJKJPKOHD.Count; i++)
		{
			FENCAJJBLBH val = BBAJKJPKOHD[i].PFAKPFKJJKA();
			if (val != null)
				return val;
		}
		return null;
	}
}
