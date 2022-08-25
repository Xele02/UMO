
using System.Collections.Generic;

public class KMOGDEOKHPG {}
public class KMOGDEOKHPG_Episode : DIHHCBACKGG
{
	public List<HMGPODKEFBA_EpisodeInfo> BBAJKJPKOHD_EpisodeList { get; private set; } = new List<HMGPODKEFBA_EpisodeInfo>(500); // 0x20 LOGMEMCACAC NNNEPHIJAKK HIAFHIDDPEJ
	public List<FMLIFJBPFNA_Step> KODIKHBMBBJ_Steps { get; private set; } = new List<FMLIFJBPFNA_Step>(4); // 0x24 CAPCHAEJOGJ HKIODMBDNKN EIMDIFHLBKK
	public List<JNIKPOIKFAC_Reward> LFAAEPAAEMB_Rewards { get; private set; } = new List<JNIKPOIKFAC_Reward>(1000); // 0x28 LGPNBHKGMEA CBMPDJKIIOF EFCJGLJJBNA

	// // RVA: 0x111E600 Offset: 0x111E600 VA: 0x111E600
	// public HMGPODKEFBA KIJAHKCDLAF(int PPFNGGCBJKC) { }

	// // RVA: 0x111E6C8 Offset: 0x111E6C8 VA: 0x111E6C8
	// public int NNFJBBFBIEN(int JPIDIENBGKH) { }

	// // RVA: 0x111E9EC Offset: 0x111E9EC VA: 0x111E9EC
	public int HFAMPKLFFEJ_FindEpisodeForReward(int GPPEFLKGGGJ)
	{
		int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie, GPPEFLKGGGJ);
		for (int i = 0; i < LFAAEPAAEMB_Rewards.Count; i++)
		{
			if(LFAAEPAAEMB_Rewards[i].KIJAPOFAGPN_Item == itemId)
			{
				for(int j = 0; j < BBAJKJPKOHD_EpisodeList.Count; j++)
				{
					if(BBAJKJPKOHD_EpisodeList[j].PPEGAKEIEGM == 2)
					{
						int idx = BBAJKJPKOHD_EpisodeList[j].HHJGBJCIFON_Rewards.FindIndex((short GHPLINIACBB) =>
						{
							//0x11203F4
							return LFAAEPAAEMB_Rewards[i].EIHOBHDKCDB_RewardId == GHPLINIACBB;
						});
						if (idx > -1)
							return BBAJKJPKOHD_EpisodeList[j].KELFCMEOPPM;
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
        JIKKNHIAEKG = "";
        LMHMIIKCGPE = 25;
    }

	// // RVA: 0x111EE78 Offset: 0x111EE78 VA: 0x111EE78 Slot: 8
	protected override void KMBPACJNEOF()
    {
		BBAJKJPKOHD_EpisodeList.Clear();
		KODIKHBMBBJ_Steps.Clear();
		LFAAEPAAEMB_Rewards.Clear();
	}

	// // RVA: 0x111EF48 Offset: 0x111EF48 VA: 0x111EF48 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		MHNEAKBPPDA parser = MHNEAKBPPDA.HEGEKFMJNCC(DBBGALAPFGC);
		LEPDBLAKJCF_LoadStep(parser);
		JOMKCAPLPEE(parser);
		IHJNKFOJPKM_LoadReward(parser);
		return true;
    }

	// // RVA: 0x111F948 Offset: 0x111F948 VA: 0x111F948 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
    {
        TodoLogger.Log(0, "IIEMACPEEBJ");
        return true;
    }

	// // RVA: 0x111F234 Offset: 0x111F234 VA: 0x111F234
	private bool JOMKCAPLPEE(MHNEAKBPPDA GFPPHFEEHGM)
	{
		GEAAFPCHGFA[] array = GFPPHFEEHGM.LCLJDEHGMCO;
		for(int i = 0; i < array.Length; i++)
		{
			HMGPODKEFBA_EpisodeInfo data = new HMGPODKEFBA_EpisodeInfo();
			data.KELFCMEOPPM = (short)array[i].PPFNGGCBJKC;
			data.IOFHEGJPHKG = (short)array[i].BDJMFDKLHPM;
			data.PPEGAKEIEGM = (sbyte)JKAECBCNHAN(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			data.EILKGEADKGH = (short)array[i].FPOMEEJFBIG;
			for(int j = 0; j < array[i].JGOHPDKCJKB.Length; j++)
			{
				data.HHJGBJCIFON_Rewards.Add((short)array[i].JGOHPDKCJKB[j]);
			}
			FMLIFJBPFNA_Step f = KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step HKICMNAACDA) =>
			{
				//0x112040C
				return HKICMNAACDA.IOFHEGJPHKG_SId == data.IOFHEGJPHKG;
			});
			if (f == null)
				data.FGOGPCMHPIN = 0;
			else
				data.FGOGPCMHPIN = f.FGOGPCMHPIN_Count;
			BBAJKJPKOHD_EpisodeList.Add(data);
		}
		return true;
	}

	// // RVA: 0x111FDE8 Offset: 0x111FDE8 VA: 0x111FDE8
	// private bool JOMKCAPLPEE(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0x111EF90 Offset: 0x111EF90 VA: 0x111EF90
	private bool LEPDBLAKJCF_LoadStep(MHNEAKBPPDA GFPPHFEEHGM)
	{
		INBANFOPJLF[] array = GFPPHFEEHGM.ECPDOFEOIPA;
		for(int i = 0; i < array.Length; i++)
		{
			FMLIFJBPFNA_Step data = new FMLIFJBPFNA_Step();
			data.IOFHEGJPHKG_SId = (short)array[i].BDJMFDKLHPM;
			for(int j = 0; j < array[i].FOILNHKHHDF.Length; j++)
			{
				data.JENFHJDFFAD_Pt.Add(array[i].FOILNHKHHDF[j]);
			}
			data.FGOGPCMHPIN_Count = (sbyte)data.JENFHJDFFAD_Pt.Count;
			KODIKHBMBBJ_Steps.Add(data);
		}
		return true;
	}

	// // RVA: 0x111F95C Offset: 0x111F95C VA: 0x111F95C
	// private bool LEPDBLAKJCF(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0x111F740 Offset: 0x111F740 VA: 0x111F740
	private bool IHJNKFOJPKM_LoadReward(MHNEAKBPPDA GFPPHFEEHGM)
	{
		INMFBOOGCLB[] array = GFPPHFEEHGM.APHNKNGKKFC;
		for(int i = 0; i < array.Length; i++)
		{
			JNIKPOIKFAC_Reward data = new JNIKPOIKFAC_Reward();
			data.EIHOBHDKCDB_RewardId = (short)array[i].FCEJJEPFIPH;
			data.KIJAPOFAGPN_Item = (int)array[i].AIHOJKFNEEN;
			data.JDLJPNMLFID_Count = (int)array[i].BFINGCJHOHI;
			data.MFKJAOLIPMA_IsVc = array[i].GPDEFAHJCBM != 0;
			LFAAEPAAEMB_Rewards.Add(data);
		}
		return true;
	}

	// // RVA: 0x111FDF0 Offset: 0x111FDF0 VA: 0x111FDF0
	// private bool IHJNKFOJPKM(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0x11201C0 Offset: 0x11201C0 VA: 0x11201C0 Slot: 11
	public override uint CAOGDCBPBAN()
    {
        TodoLogger.Log(0, "CAOGDCBPBAN");
        return 0;
    }
}

public class HMGPODKEFBA_EpisodeInfo
{
	public short KELFCMEOPPM; // 0x8
	public short IOFHEGJPHKG; // 0xA
	public short EILKGEADKGH; // 0xC
	public sbyte PPEGAKEIEGM; // 0xE
	public sbyte FGOGPCMHPIN; // 0xF
	public List<short> HHJGBJCIFON_Rewards = new List<short>(10); // 0x10

	public bool IPJMPBANBPP { get; } //0x15F4CC4

	// // RVA: 0x15F4B5C Offset: 0x15F4B5C VA: 0x15F4B5C
	// public int JCFLMEICEII(int OIPCCBHIKIA) { }

	// // RVA: 0x15F4BDC Offset: 0x15F4BDC VA: 0x15F4BDC
	// public uint CAOGDCBPBAN() { }
}

public class FMLIFJBPFNA { }
public class FMLIFJBPFNA_Step
{
	public short IOFHEGJPHKG_SId; // 0x8
	public sbyte FGOGPCMHPIN_Count; // 0xA
	public List<int> JENFHJDFFAD_Pt = new List<int>(10); // 0xC

	// // RVA: 0x119E674 Offset: 0x119E674 VA: 0x119E674
	// public uint CAOGDCBPBAN() { }
}

public class JNIKPOIKFAC { }
public class JNIKPOIKFAC_Reward
{
	public short EIHOBHDKCDB_RewardId; // 0x8
	public bool MFKJAOLIPMA_IsVc; // 0xA
	public int JDLJPNMLFID_Count; // 0xC
	public int KIJAPOFAGPN_Item; // 0x10

	// // RVA: 0x1B8FCFC Offset: 0x1B8FCFC VA: 0x1B8FCFC
	// public uint CAOGDCBPBAN() { }
}
