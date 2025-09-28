
using System.Collections.Generic;

[System.Obsolete("Use KMOGDEOKHPG_Episode", true)]
public class KMOGDEOKHPG {}
public class KMOGDEOKHPG_Episode : DIHHCBACKGG_DbSection
{
	public List<HMGPODKEFBA_EpisodeInfo> BBAJKJPKOHD_EpisodeList { get; private set; } = new List<HMGPODKEFBA_EpisodeInfo>(500); // 0x20 LOGMEMCACAC NNNEPHIJAKK HIAFHIDDPEJ
	public List<FMLIFJBPFNA_Step> KODIKHBMBBJ_Steps { get; private set; } = new List<FMLIFJBPFNA_Step>(4); // 0x24 CAPCHAEJOGJ HKIODMBDNKN EIMDIFHLBKK
	public List<JNIKPOIKFAC_Reward> LFAAEPAAEMB_Rewards { get; private set; } = new List<JNIKPOIKFAC_Reward>(1000); // 0x28 LGPNBHKGMEA CBMPDJKIIOF EFCJGLJJBNA

	// // RVA: 0x111E600 Offset: 0x111E600 VA: 0x111E600
	// public HMGPODKEFBA_EpisodeInfo KIJAHKCDLAF(int _PPFNGGCBJKC_id) { }

	// // RVA: 0x111E6C8 Offset: 0x111E6C8 VA: 0x111E6C8
	public int NNFJBBFBIEN(int _JPIDIENBGKH_CostumeId)
	{
		int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume, _JPIDIENBGKH_CostumeId);
		for(int i = 0; i < LFAAEPAAEMB_Rewards.Count; i++)
		{
			if(LFAAEPAAEMB_Rewards[i].KIJAPOFAGPN_ItemId == itemId)
			{
				int IAPEBMMOLMM_rid = LFAAEPAAEMB_Rewards[i].EIHOBHDKCDB_RewardId;
				for(int j = 0; j < BBAJKJPKOHD_EpisodeList.Count; j++)
				{
					if(BBAJKJPKOHD_EpisodeList[j].PPEGAKEIEGM_Enabled == 2)
					{
						int idx = BBAJKJPKOHD_EpisodeList[j].HHJGBJCIFON_Rewards.FindIndex((short _GHPLINIACBB_x) =>
						{
							//0x11203DC
							return IAPEBMMOLMM_rid == _GHPLINIACBB_x;
						});
						if(idx > -1)
						{
							return BBAJKJPKOHD_EpisodeList[j].KELFCMEOPPM_EpisodeId;
						}
					}
				}
				return 0;
			}
		}
		return 0;
	}

	// // RVA: 0x111E9EC Offset: 0x111E9EC VA: 0x111E9EC
	public int HFAMPKLFFEJ_FindEpisodeForReward(int _GPPEFLKGGGJ_ValkyrieId)
	{
		int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie, _GPPEFLKGGGJ_ValkyrieId);
		for (int i = 0; i < LFAAEPAAEMB_Rewards.Count; i++)
		{
			if(LFAAEPAAEMB_Rewards[i].KIJAPOFAGPN_ItemId == itemId)
			{
				for(int j = 0; j < BBAJKJPKOHD_EpisodeList.Count; j++)
				{
					if(BBAJKJPKOHD_EpisodeList[j].PPEGAKEIEGM_Enabled == 2)
					{
						int idx = BBAJKJPKOHD_EpisodeList[j].HHJGBJCIFON_Rewards.FindIndex((short _GHPLINIACBB_x) =>
						{
							//0x11203F4
							return LFAAEPAAEMB_Rewards[i].EIHOBHDKCDB_RewardId == _GHPLINIACBB_x;
						});
						if (idx > -1)
							return BBAJKJPKOHD_EpisodeList[j].KELFCMEOPPM_EpisodeId;
					}
				}
				return 0;
			}
		}
		return 0;
	}

	// // RVA: 0x111ED10 Offset: 0x111ED10 VA: 0x111ED10
	public KMOGDEOKHPG_Episode()
    {
        JIKKNHIAEKG_BlockName = "";
        LMHMIIKCGPE = 25;
    }

	// // RVA: 0x111EE78 Offset: 0x111EE78 VA: 0x111EE78 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		BBAJKJPKOHD_EpisodeList.Clear();
		KODIKHBMBBJ_Steps.Clear();
		LFAAEPAAEMB_Rewards.Clear();
	}

	// // RVA: 0x111EF48 Offset: 0x111EF48 VA: 0x111EF48 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		MHNEAKBPPDA parser = MHNEAKBPPDA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		LEPDBLAKJCF_LoadStep(parser);
		JOMKCAPLPEE(parser);
		IHJNKFOJPKM_LoadReward(parser);
		return true;
    }

	// // RVA: 0x111F948 Offset: 0x111F948 VA: 0x111F948 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
    {
        TodoLogger.LogError(TodoLogger.DbJson, "IIEMACPEEBJ_Deserialize");
        return true;
    }

	// // RVA: 0x111F234 Offset: 0x111F234 VA: 0x111F234
	private bool JOMKCAPLPEE(MHNEAKBPPDA GFPPHFEEHGM)
	{
		GEAAFPCHGFA[] array = GFPPHFEEHGM.LCLJDEHGMCO;
		for(int i = 0; i < array.Length; i++)
		{
			HMGPODKEFBA_EpisodeInfo data = new HMGPODKEFBA_EpisodeInfo();
			data.KELFCMEOPPM_EpisodeId = (short)array[i].PPFNGGCBJKC_id;
			data.IOFHEGJPHKG_StepId = (short)array[i].BDJMFDKLHPM_s_id;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.EILKGEADKGH_Order = (short)array[i].FPOMEEJFBIG_odr;
			for(int j = 0; j < array[i].JGOHPDKCJKB_rw.Length; j++)
			{
				data.HHJGBJCIFON_Rewards.Add((short)array[i].JGOHPDKCJKB_rw[j]);
			}
			FMLIFJBPFNA_Step f = KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _HKICMNAACDA_a) =>
			{
				//0x112040C
				return _HKICMNAACDA_a.IOFHEGJPHKG_StepId == data.IOFHEGJPHKG_StepId;
			});
			if (f == null)
				data.FGOGPCMHPIN_Count = 0;
			else
				data.FGOGPCMHPIN_Count = f.FGOGPCMHPIN_Count;
			BBAJKJPKOHD_EpisodeList.Add(data);
		}
		return true;
	}

	// // RVA: 0x111FDE8 Offset: 0x111FDE8 VA: 0x111FDE8
	// private bool JOMKCAPLPEE(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	// // RVA: 0x111EF90 Offset: 0x111EF90 VA: 0x111EF90
	private bool LEPDBLAKJCF_LoadStep(MHNEAKBPPDA GFPPHFEEHGM)
	{
		INBANFOPJLF[] array = GFPPHFEEHGM.ECPDOFEOIPA;
		for(int i = 0; i < array.Length; i++)
		{
			FMLIFJBPFNA_Step data = new FMLIFJBPFNA_Step();
			data.IOFHEGJPHKG_StepId = (short)array[i].BDJMFDKLHPM_s_id;
			for(int j = 0; j < array[i].FOILNHKHHDF_pt.Length; j++)
			{
				data.JENFHJDFFAD_Pt.Add(array[i].FOILNHKHHDF_pt[j]);
			}
			data.FGOGPCMHPIN_Count = (sbyte)data.JENFHJDFFAD_Pt.Count;
			KODIKHBMBBJ_Steps.Add(data);
		}
		return true;
	}

	// // RVA: 0x111F95C Offset: 0x111F95C VA: 0x111F95C
	// private bool LEPDBLAKJCF_LoadStep(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }
	//KODIKHBMBBJ_Steps = LGADCGFMLLD_step
	//	IOFHEGJPHKG_StepId = BDJMFDKLHPM_s_id
	//	JENFHJDFFAD_Pt = FOILNHKHHDF_pt

	// // RVA: 0x111F740 Offset: 0x111F740 VA: 0x111F740
	private bool IHJNKFOJPKM_LoadReward(MHNEAKBPPDA GFPPHFEEHGM)
	{
		INMFBOOGCLB[] array = GFPPHFEEHGM.APHNKNGKKFC;
		for(int i = 0; i < array.Length; i++)
		{
			JNIKPOIKFAC_Reward data = new JNIKPOIKFAC_Reward();
			data.EIHOBHDKCDB_RewardId = (short)array[i].FCEJJEPFIPH_rwid;
			data.KIJAPOFAGPN_ItemId = (int)array[i].AIHOJKFNEEN_itm;
			data.JDLJPNMLFID_ItemCount = (int)array[i].BFINGCJHOHI_cnt;
			data.MFKJAOLIPMA_IsVc = array[i].GPDEFAHJCBM != 0;
			LFAAEPAAEMB_Rewards.Add(data);
		}
		return true;
	}

	// // RVA: 0x111FDF0 Offset: 0x111FDF0 VA: 0x111FDF0
	// private bool IHJNKFOJPKM_LoadReward(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }
	// = FAENAMBEGMD_reward
	//	EIHOBHDKCDB_RewardId = FCEJJEPFIPH_rwid
	//	KIJAPOFAGPN_ItemId = AIHOJKFNEEN_itm
	//	JDLJPNMLFID_ItemCount = BFINGCJHOHI_cnt
	//	MFKJAOLIPMA_IsVc = vc

	// // RVA: 0x11201C0 Offset: 0x11201C0 VA: 0x11201C0 Slot: 11
	public override uint CAOGDCBPBAN()
    {
        TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KMOGDEOKHPG_Episode.CAOGDCBPBAN");
        return 0;
    }
}

[System.Obsolete("Use HMGPODKEFBA_EpisodeInfo", true)]
public class HMGPODKEFBA { }
public class HMGPODKEFBA_EpisodeInfo
{
	public short KELFCMEOPPM_EpisodeId; // 0x8
	public short IOFHEGJPHKG_StepId; // 0xA
	public short EILKGEADKGH_Order; // 0xC
	public sbyte PPEGAKEIEGM_Enabled; // 0xE
	public sbyte FGOGPCMHPIN_Count; // 0xF
	public List<short> HHJGBJCIFON_Rewards = new List<short>(10); // 0x10

	//public bool IPJMPBANBPP_Enabled { get; } //0x15F4CC4

	// // RVA: 0x15F4B5C Offset: 0x15F4B5C VA: 0x15F4B5C
	// public int JCFLMEICEII(int _OIPCCBHIKIA_index) { }

	// // RVA: 0x15F4BDC Offset: 0x15F4BDC VA: 0x15F4BDC
	// public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use FMLIFJBPFNA_Step", true)]
public class FMLIFJBPFNA { }
public class FMLIFJBPFNA_Step
{
	public short IOFHEGJPHKG_StepId; // 0x8
	public sbyte FGOGPCMHPIN_Count; // 0xA
	public List<int> JENFHJDFFAD_Pt = new List<int>(10); // 0xC

	// // RVA: 0x119E674 Offset: 0x119E674 VA: 0x119E674
	// public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use JNIKPOIKFAC_Reward", true)]
public class JNIKPOIKFAC { }
public class JNIKPOIKFAC_Reward
{
	public short EIHOBHDKCDB_RewardId; // 0x8
	public bool MFKJAOLIPMA_IsVc; // 0xA
	public int JDLJPNMLFID_ItemCount; // 0xC
	public int KIJAPOFAGPN_ItemId; // 0x10

	// // RVA: 0x1B8FCFC Offset: 0x1B8FCFC VA: 0x1B8FCFC
	// public uint CAOGDCBPBAN() { }
}
