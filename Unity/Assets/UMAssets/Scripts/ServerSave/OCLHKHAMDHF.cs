
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use OCLHKHAMDHF_Episode", true)]
public class OCLHKHAMDHF { }
public class OCLHKHAMDHF_Episode : KLFDBFMNLBL_ServerSaveBlock
{
	public class JEHNEEBBDBO_EpisodeInfo
	{
		private int FBGGEFFJJHB; // 0x8
		private int GDIKAELAKBN_IdCrypted; // 0xC
		private int EFLHPLDPEHJ_ValCrypted; // 0x10
		private int BMNPNDCOGOJ_ValCheck; // 0x14
		private int FKEOAJOIILO_StepCheck; // 0x18
		private int EEEHAJPKFLP_StepCrypted; // 0x1C
		private long KLAPHOKNEDG_DateCrypted; // 0x20
		private byte[] GDLLDIJEGCB_RewardReceivedCrypted = new byte[10]; // 0x28
		public List<int> PHJFOJLMFGK; // 0x2C
		public bool LHMOAJAIJCO_IsNew; // 0x30

		public int HPLMMKHBKIG_Id { get { return GDIKAELAKBN_IdCrypted ^ FBGGEFFJJHB; } set { GDIKAELAKBN_IdCrypted = value ^ GDIKAELAKBN_IdCrypted; } } //0x1B2D9F4 CABAPDMNCDN 0x1B2E04C BIEKAEDMACK
		public int OGDBKJKIGAJ_Val { get {
				int res = EFLHPLDPEHJ_ValCrypted ^ FBGGEFFJJHB;
				if (BMNPNDCOGOJ_ValCheck != res)
					return 0;
				return res;
			} set
			{
				EFLHPLDPEHJ_ValCrypted = value ^ FBGGEFFJJHB;
				BMNPNDCOGOJ_ValCheck = value;
			}
		} //0x1B2DA00 KPOKGLEGCON 0x1B2E05C CJKKCALKIKL
		public long BEBJKJKBOGH_Date { get { return KLAPHOKNEDG_DateCrypted ^ FBGGEFFJJHB; } set { KLAPHOKNEDG_DateCrypted = value ^ FBGGEFFJJHB; } } //0x1B2D9DC DIAPHCJBPFD 0x1B2E084 IHAIKPNEEJE
		public int EBIIIAELNAA_Step { get { return EEEHAJPKFLP_StepCrypted ^ FBGGEFFJJHB; } set { EEEHAJPKFLP_StepCrypted = value ^ FBGGEFFJJHB; FKEOAJOIILO_StepCheck = value; } } //0x1B2C830 DNHBBMADHBB 0x1B2E070 KHFOJPIEFKJ

		//// RVA: 0x1B30860 Offset: 0x1B30860 VA: 0x1B30860
		public void BDPOOJDJKAA_SetRewardReceived(int OIPCCBHIKIA_Index, bool LNACKEBEMOB_Value)
		{
			GDLLDIJEGCB_RewardReceivedCrypted[OIPCCBHIKIA_Index] = (byte)(LNACKEBEMOB_Value ? (FBGGEFFJJHB * (OIPCCBHIKIA_Index + 1) & 0xf) ^ 0xf : (FBGGEFFJJHB * (OIPCCBHIKIA_Index + 1) & 0xf));
		}

		//// RVA: 0x1B2DA1C Offset: 0x1B2DA1C VA: 0x1B2DA1C
		public bool MCIHDIBHHBI(int OIPCCBHIKIA)
		{
			return GDLLDIJEGCB_RewardReceivedCrypted[OIPCCBHIKIA] != (FBGGEFFJJHB * (OIPCCBHIKIA + 1) & 0xf);
		}

		//// RVA: 0x1B2D03C Offset: 0x1B2D03C VA: 0x1B2D03C
		public void LHPDDGIJKNB(int PPFNGGCBJKC, int KNEFBLHBDBG)
		{
			LHMOAJAIJCO_IsNew = false;
			PHJFOJLMFGK = null;
			FBGGEFFJJHB = KNEFBLHBDBG;
			HPLMMKHBKIG_Id = PPFNGGCBJKC;
			OGDBKJKIGAJ_Val = 0;
			EBIIIAELNAA_Step = 0;
			BEBJKJKBOGH_Date = 0;
			for(int i = 0; i < 10; i++)
			{
				BDPOOJDJKAA_SetRewardReceived(i, false);
			}
		}

		//// RVA: 0x1B2E5E0 Offset: 0x1B2E5E0 VA: 0x1B2E5E0
		//public bool AGBOGBEOFME(OCLHKHAMDHF.JEHNEEBBDBO OIKJFMGEICL) { }

		//// RVA: 0x1B2E268 Offset: 0x1B2E268 VA: 0x1B2E268
		public void ODDIHGPONFL(JEHNEEBBDBO_EpisodeInfo GPBJHKLFCEP)
		{
			HPLMMKHBKIG_Id = GPBJHKLFCEP.HPLMMKHBKIG_Id;
			OGDBKJKIGAJ_Val = GPBJHKLFCEP.OGDBKJKIGAJ_Val;
			EBIIIAELNAA_Step = GPBJHKLFCEP.EBIIIAELNAA_Step;
			LHMOAJAIJCO_IsNew = GPBJHKLFCEP.LHMOAJAIJCO_IsNew;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			for(int i = 0; i < 10; i++)
			{
				BDPOOJDJKAA_SetRewardReceived(i, GPBJHKLFCEP.MCIHDIBHHBI(i));
			}
		}

		//// RVA: 0x1B2EBDC Offset: 0x1B2EBDC VA: 0x1B2EBDC
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OCLHKHAMDHF.JEHNEEBBDBO OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		//// RVA: 0x1B305C8 Offset: 0x1B305C8 VA: 0x1B305C8
		public FENCAJJBLBH PFAKPFKJJKA()
		{
			if (FBGGEFFJJHB == 0)
				return null;
			if((EFLHPLDPEHJ_ValCrypted ^ FBGGEFFJJHB) != BMNPNDCOGOJ_ValCheck)
			{
				return new FENCAJJBLBH(FENCAJJBLBH.EIAPDOGALDK.AIEOCNLGLEE, 0x16, GDIKAELAKBN_IdCrypted ^ FBGGEFFJJHB, "pd.episode.ep_val");
			}
			if ((EEEHAJPKFLP_StepCrypted ^ FBGGEFFJJHB) != FKEOAJOIILO_StepCheck)
			{
				return new FENCAJJBLBH(FENCAJJBLBH.EIAPDOGALDK.AIEOCNLGLEE, 0x16, GDIKAELAKBN_IdCrypted ^ FBGGEFFJJHB, "pd.episode.ep_step");
			}
			for (int i = 0; i < 8; i++)
			{
				if(GDLLDIJEGCB_RewardReceivedCrypted[i] != (FBGGEFFJJHB * (i + 1) & 0xf))
				{
					if(GDLLDIJEGCB_RewardReceivedCrypted[i] != ((FBGGEFFJJHB * (i + 1) & 0xf) ^ 0xf))
					{
						return new FENCAJJBLBH(FENCAJJBLBH.EIAPDOGALDK.AIEOCNLGLEE, 0x16, GDIKAELAKBN_IdCrypted ^ FBGGEFFJJHB, "pd.episode.reward_received");
					}
				}
			}
			return null;
		}

		//// RVA: 0x1B308D0 Offset: 0x1B308D0 VA: 0x1B308D0
		//public bool MOACIBEKLEN(KMOGDEOKHPG MOLEPBNJAGE, int GNDJCANPLDJ, bool DDGFCOPPBBN = False) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<JEHNEEBBDBO_EpisodeInfo> BBAJKJPKOHD_EpisodeList { get; private set; } // 0x24 LOGMEMCACAC NNNEPHIJAKK HIAFHIDDPEJ
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
		BBAJKJPKOHD_EpisodeList = new List<JEHNEEBBDBO_EpisodeInfo>(500);
		KMBPACJNEOF();
	}

	// // RVA: 0x1B2CE78 Offset: 0x1B2CE78 VA: 0x1B2CE78 Slot: 4
	public override void KMBPACJNEOF()
	{
		long time = Utility.GetCurrentUnixTime();
		int key = (int)(time ^ 0x1476775d);
		BBAJKJPKOHD_EpisodeList.Clear();
		for(int i = 0; i < 500; i++)
		{
			JEHNEEBBDBO_EpisodeInfo data = new JEHNEEBBDBO_EpisodeInfo();
			data.LHPDDGIJKNB(i + 1, key);
			BBAJKJPKOHD_EpisodeList.Add(data);
			key = key * 0x5d3 + 0x6f;
		}
	}

	// // RVA: 0x1B2D098 Offset: 0x1B2D098 VA: 0x1B2D098 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1B2DA80 Offset: 0x1B2DA80 VA: 0x1B2DA80 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData data = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if(!blockMissing)
		{
			if(data == null)
			{
				isInvalid = true;
			}
			else
			{
				List<HMGPODKEFBA_EpisodeInfo> epList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList;
				for(int i = 0; i < epList.Count; i++)
				{
					var key = POFDDFCGEGP + (i + 1);
					if (data.BBAJPINMOEP_Contains(key))
					{
						EDOHBJAPLPF_JsonData groupData = data[key];
						JEHNEEBBDBO_EpisodeInfo info = BBAJKJPKOHD_EpisodeList[i];
						info.HPLMMKHBKIG_Id = CJAENOMGPDA_ReadInt(groupData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i+1, ref isInvalid);
						info.OGDBKJKIGAJ_Val = CJAENOMGPDA_ReadInt(groupData, AFEHLCGHAEE_Strings.JBGEEPFKIGG_val, 0, ref isInvalid);
						info.EBIIIAELNAA_Step = CJAENOMGPDA_ReadInt(groupData, AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						info.LHMOAJAIJCO_IsNew = CJAENOMGPDA_ReadInt(groupData, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
						info.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(groupData, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(groupData, AFEHLCGHAEE_Strings.CCCHFLGBMAF_recv, 0, 10, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x1B30820
							info.BDPOOJDJKAA_SetRewardReceived(OIPCCBHIKIA, JBGEEPFKIGG != 0);
						}, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1B2E098 Offset: 0x1B2E098 VA: 0x1B2E098 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OCLHKHAMDHF_Episode e = GPBJHKLFCEP as OCLHKHAMDHF_Episode;
		for(int i = 0; i < BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			BBAJKJPKOHD_EpisodeList[i].ODDIHGPONFL(e.BBAJKJPKOHD_EpisodeList[i]);
		}
	}

	// // RVA: 0x1B2E398 Offset: 0x1B2E398 VA: 0x1B2E398 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1B2E7D0 Offset: 0x1B2E7D0 VA: 0x1B2E7D0 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1B304DC Offset: 0x1B304DC VA: 0x1B304DC Slot: 9
	// public override bool NFKFOODCJJB() { }

	// // RVA: 0x1B304E4 Offset: 0x1B304E4 VA: 0x1B304E4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		for(int i = 0; i < BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			FENCAJJBLBH val = BBAJKJPKOHD_EpisodeList[i].PFAKPFKJJKA();
			if (val != null)
				return val;
		}
		return null;
	}
}
