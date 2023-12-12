
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use OCLHKHAMDHF_Episode", true)]
public class OCLHKHAMDHF { }
public class OCLHKHAMDHF_Episode : KLFDBFMNLBL_ServerSaveBlock
{
	public class MGGPEOCPIEG
	{
		public int HODPFJGODDN_EpIdx; // 0x8
		public int CPNGJMKFCJI; // 0xC
		public JNIKPOIKFAC_Reward KONJMFICNJJ; // 0x10
	}

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

		public int HPLMMKHBKIG_Id { get { return GDIKAELAKBN_IdCrypted ^ FBGGEFFJJHB; } set { GDIKAELAKBN_IdCrypted = value ^ FBGGEFFJJHB; } } //0x1B2D9F4 CABAPDMNCDN 0x1B2E04C BIEKAEDMACK
		public int OGDBKJKIGAJ_CurrentPoint { get {
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
		public bool MCIHDIBHHBI_IsRewardReceived(int OIPCCBHIKIA)
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
			OGDBKJKIGAJ_CurrentPoint = 0;
			EBIIIAELNAA_Step = 0;
			BEBJKJKBOGH_Date = 0;
			for(int i = 0; i < 10; i++)
			{
				BDPOOJDJKAA_SetRewardReceived(i, false);
			}
		}

		//// RVA: 0x1B2E5E0 Offset: 0x1B2E5E0 VA: 0x1B2E5E0
		public bool AGBOGBEOFME(JEHNEEBBDBO_EpisodeInfo OIKJFMGEICL)
		{
			if(OGDBKJKIGAJ_CurrentPoint != OIKJFMGEICL.OGDBKJKIGAJ_CurrentPoint ||
				LHMOAJAIJCO_IsNew != OIKJFMGEICL.LHMOAJAIJCO_IsNew ||
				HPLMMKHBKIG_Id != OIKJFMGEICL.HPLMMKHBKIG_Id ||
				EBIIIAELNAA_Step != OIKJFMGEICL.EBIIIAELNAA_Step ||
				BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
				return false;
			for(int i = 0; i < 10; i++)
			{
				if(MCIHDIBHHBI_IsRewardReceived(i) != OIKJFMGEICL.MCIHDIBHHBI_IsRewardReceived(i))
					return false;
			}
			return true;
		}

		//// RVA: 0x1B2E268 Offset: 0x1B2E268 VA: 0x1B2E268
		public void ODDIHGPONFL(JEHNEEBBDBO_EpisodeInfo GPBJHKLFCEP)
		{
			HPLMMKHBKIG_Id = GPBJHKLFCEP.HPLMMKHBKIG_Id;
			OGDBKJKIGAJ_CurrentPoint = GPBJHKLFCEP.OGDBKJKIGAJ_CurrentPoint;
			EBIIIAELNAA_Step = GPBJHKLFCEP.EBIIIAELNAA_Step;
			LHMOAJAIJCO_IsNew = GPBJHKLFCEP.LHMOAJAIJCO_IsNew;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			for(int i = 0; i < 10; i++)
			{
				BDPOOJDJKAA_SetRewardReceived(i, GPBJHKLFCEP.MCIHDIBHHBI_IsRewardReceived(i));
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
		public bool MOACIBEKLEN(KMOGDEOKHPG_Episode MOLEPBNJAGE, int GNDJCANPLDJ, bool DDGFCOPPBBN = false)
		{
			HMGPODKEFBA_EpisodeInfo ep = MOLEPBNJAGE.BBAJKJPKOHD_EpisodeList.Find((HMGPODKEFBA_EpisodeInfo PKLPKMLGFGK) =>
			{
				//0x1B30D68
				return HPLMMKHBKIG_Id == PKLPKMLGFGK.KELFCMEOPPM;
			});
			if(ep != null)
			{
				FMLIFJBPFNA_Step step = MOLEPBNJAGE.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step PKLPKMLGFGK) =>
				{
					//0x1B30DB8
					return PKLPKMLGFGK.IOFHEGJPHKG_SId == ep.IOFHEGJPHKG_StepId;
				});
				if(step != null)
				{
					int p = OGDBKJKIGAJ_CurrentPoint;
					int s = EBIIIAELNAA_Step;
					List<int> l = new List<int>();
					bool b = true;
					for(int i = 0; i < GNDJCANPLDJ && b; i++)
					{
						while(true)
						{
							p += GNDJCANPLDJ;
							if (p < step.JENFHJDFFAD_Pt[i])
							{
								b = false;
								break;
							}
							l.Add(s);
							GNDJCANPLDJ = p - step.JENFHJDFFAD_Pt[i];
							if(s < step.FGOGPCMHPIN_Count - 1)
							{
								s++;
								p = step.JENFHJDFFAD_Pt[i];
								break;
							}
							p = step.JENFHJDFFAD_Pt[step.FGOGPCMHPIN_Count - 2];
							if(GNDJCANPLDJ < 1)
							{
								b = false;
								break;
							}
						}
					}
					if(!DDGFCOPPBBN)
					{
						OGDBKJKIGAJ_CurrentPoint = p;
						EBIIIAELNAA_Step = s;
						if (l.Count < 1)
							return false;
						if (PHJFOJLMFGK == null)
							PHJFOJLMFGK = l;
						else
						{
							for(int i = 0; i < l.Count; i++)
							{
								PHJFOJLMFGK.Add(l[i]);
							}
						}
						return true;
					}
					else
					{
						return l.Count > 0;
					}
				}
			}
			return false;
		}
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<JEHNEEBBDBO_EpisodeInfo> BBAJKJPKOHD_EpisodeList { get; private set; } // 0x24 LOGMEMCACAC NNNEPHIJAKK HIAFHIDDPEJ
	public override bool DMICHEJIAJL { get { return true; } } // 0x1B304DC NFKFOODCJJB

	// // RVA: 0x1B2C690 Offset: 0x1B2C690 VA: 0x1B2C690
	public int GGKOLJCPNKO(KMOGDEOKHPG_Episode MOLEPBNJAGE)
	{
		int res = 0;
		for(int i = 0; i < MOLEPBNJAGE.BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			if(MOLEPBNJAGE.BBAJKJPKOHD_EpisodeList[i].PPEGAKEIEGM != 0)
			{
				if (MOLEPBNJAGE.BBAJKJPKOHD_EpisodeList[i].FGOGPCMHPIN_Count - 1 <= BBAJKJPKOHD_EpisodeList[i].EBIIIAELNAA_Step)
					res++;
			}
		}
		return res;
	}

	// // RVA: 0x1B2C840 Offset: 0x1B2C840 VA: 0x1B2C840
	public List<MGGPEOCPIEG> POEDIMMMLME(KMOGDEOKHPG_Episode MOLEPBNJAGE, ref bool AJFHCEEKPPA)
	{
		List<MGGPEOCPIEG> res = new List<MGGPEOCPIEG>();
		int cnt = Mathf.Min(BBAJKJPKOHD_EpisodeList.Count, MOLEPBNJAGE.BBAJKJPKOHD_EpisodeList.Count);
		for (int i = 0; i < cnt; i++)
		{
			JEHNEEBBDBO_EpisodeInfo ep = BBAJKJPKOHD_EpisodeList[i];
			HMGPODKEFBA_EpisodeInfo dbEp = MOLEPBNJAGE.BBAJKJPKOHD_EpisodeList[i];
			if(dbEp.PPEGAKEIEGM != 0)
			{
				FMLIFJBPFNA_Step dbStep = MOLEPBNJAGE.KODIKHBMBBJ_Steps[dbEp.IOFHEGJPHKG_StepId - 1];
				if(ep.PHJFOJLMFGK != null)
				{
					for(int j = 0; j < ep.PHJFOJLMFGK.Count; j++)
					{
						MGGPEOCPIEG data = new MGGPEOCPIEG();
						data.HODPFJGODDN_EpIdx = i;
						data.CPNGJMKFCJI = ep.PHJFOJLMFGK[j];
						data.KONJMFICNJJ = MOLEPBNJAGE.LFAAEPAAEMB_Rewards[dbEp.HHJGBJCIFON_Rewards[j]];
						if (data.KONJMFICNJJ.MFKJAOLIPMA_IsVc)
							AJFHCEEKPPA = true;
						res.Add(data);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1B2CCFC Offset: 0x1B2CCFC VA: 0x1B2CCFC
	public void BOAIINJHENE()
	{
		for(int i = 0; i < BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			BBAJKJPKOHD_EpisodeList[i].PHJFOJLMFGK = null;
		}
	}

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
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP] = "";
		for(int i = 0; i < BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			if(BBAJKJPKOHD_EpisodeList[i].BEBJKJKBOGH_Date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				if(BBAJKJPKOHD_EpisodeList[i].PHJFOJLMFGK != null)
				{
					Debug.LogError("pending_rewards is exists!!");
				}
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = BBAJKJPKOHD_EpisodeList[i].HPLMMKHBKIG_Id;
				data2[AFEHLCGHAEE_Strings.JBGEEPFKIGG_val] = BBAJKJPKOHD_EpisodeList[i].OGDBKJKIGAJ_CurrentPoint;
				data2[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = BBAJKJPKOHD_EpisodeList[i].LHMOAJAIJCO_IsNew ? 1 : 0;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = BBAJKJPKOHD_EpisodeList[i].BEBJKJKBOGH_Date;
				data2[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = BBAJKJPKOHD_EpisodeList[i].EBIIIAELNAA_Step;
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int j = 0; j < 10; j++)
				{
					data3.Add(BBAJKJPKOHD_EpisodeList[i].MCIHDIBHHBI_IsRewardReceived(j) ? 1 : 0);
				}
				data2[AFEHLCGHAEE_Strings.CCCHFLGBMAF_recv] = data3;
				data[POFDDFCGEGP + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.PBJKGCLJFOE_episode] = data;
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

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
						info.OGDBKJKIGAJ_CurrentPoint = CJAENOMGPDA_ReadInt(groupData, AFEHLCGHAEE_Strings.JBGEEPFKIGG_val, 0, ref isInvalid);
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
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OCLHKHAMDHF_Episode other = GPBJHKLFCEP as OCLHKHAMDHF_Episode;
		if(BBAJKJPKOHD_EpisodeList.Count != other.BBAJKJPKOHD_EpisodeList.Count)
			return false;
		for(int i = 0; i < BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			if(!BBAJKJPKOHD_EpisodeList[i].AGBOGBEOFME(other.BBAJKJPKOHD_EpisodeList[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1B2E7D0 Offset: 0x1B2E7D0 VA: 0x1B2E7D0 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}

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
