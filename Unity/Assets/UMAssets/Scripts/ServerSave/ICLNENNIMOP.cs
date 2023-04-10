
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use ICLNENNIMOP_FreeScoreMax", true)]
public class ICLNENNIMOP { }
public class ICLNENNIMOP_FreeScoreMax : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	private const long GMNKHOJAOPC = 1496070000;
	private const long GNBEEACODKK = 1811602800;
	public List<double> AGPLAKAFDEP; // 0x24
	public List<double> HHDIPKALCDG; // 0x28
	private int FBGGEFFJJHB; // 0x2C
	private List<int> NBOLDNMPJFG_FreeMusicHighScore; // 0x30
	private List<int> FONGFOAMHJK; // 0x34

	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0x11EB4DC NFKFOODCJJB

	// // RVA: 0x11E9C2C Offset: 0x11E9C2C VA: 0x11E9C2C
	public int BDCAICINCKK_GetScoreMusic(int GHBPLHBNMBK)
	{
		return NBOLDNMPJFG_FreeMusicHighScore[GHBPLHBNMBK - 1] ^ FBGGEFFJJHB;
	}

	// // RVA: 0x11E9CB4 Offset: 0x11E9CB4 VA: 0x11E9CB4
	public void ECKFCIHPHGJ_SetScoreForMusic(int GHBPLHBNMBK, int KNIFCANOHOC)
	{
		NBOLDNMPJFG_FreeMusicHighScore[GHBPLHBNMBK - 1] = KNIFCANOHOC ^ FBGGEFFJJHB;
		FONGFOAMHJK[GHBPLHBNMBK - 1] = KNIFCANOHOC;
	}

	// // RVA: 0x11E9D78 Offset: 0x11E9D78 VA: 0x11E9D78
	// public double CJFBOEKDKNN(int GHBPLHBNMBK) { }

	// // RVA: 0x11E9DF8 Offset: 0x11E9DF8 VA: 0x11E9DF8
	// public void POIKGADFLHF(int GHBPLHBNMBK, int KNIFCANOHOC, long EOLFJGMAJAB) { }

	// // RVA: 0x11E9F80 Offset: 0x11E9F80 VA: 0x11E9F80
	public void POIKGADFLHF_SetPreciseScoreForMusic(int GHBPLHBNMBK, double HMLEDBJDCAF)
	{
		AGPLAKAFDEP[GHBPLHBNMBK - 1] = HMLEDBJDCAF;
		HHDIPKALCDG[GHBPLHBNMBK - 1] = HMLEDBJDCAF;
		double f = BOAGCEOHJEO.CFLDNJANAPI_Truncate(HMLEDBJDCAF);
		ECKFCIHPHGJ_SetScoreForMusic(GHBPLHBNMBK, (int)f);
	}

	// // RVA: 0x11EA084 Offset: 0x11EA084 VA: 0x11EA084
	public ICLNENNIMOP_FreeScoreMax()
	{
		NBOLDNMPJFG_FreeMusicHighScore = new List<int>(2000);
		FONGFOAMHJK = new List<int>(2000);
		AGPLAKAFDEP = new List<double>(2000);
		HHDIPKALCDG = new List<double>(2000);
		KMBPACJNEOF();
	}

	// // RVA: 0x11EA198 Offset: 0x11EA198 VA: 0x11EA198 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBGGEFFJJHB = (int)Utility.GetCurrentUnixTime() * 0x8d;
		NBOLDNMPJFG_FreeMusicHighScore.Clear();
		FONGFOAMHJK.Clear();
		AGPLAKAFDEP.Clear();
		HHDIPKALCDG.Clear();
		for(int i = 0; i < 2000; i++)
		{
			NBOLDNMPJFG_FreeMusicHighScore.Add(FBGGEFFJJHB);
			FONGFOAMHJK.Add(0);
			AGPLAKAFDEP.Add(0);
			HHDIPKALCDG.Add(0);
		}
	}

	// // RVA: 0x11EA3DC Offset: 0x11EA3DC VA: 0x11EA3DC Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "OKJPIBHMKMJ");
	}

	// // RVA: 0x11EA758 Offset: 0x11EA758 VA: 0x11EA758 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if (block.HNBFOAJIIAL_Count != 2000)
					isInvalid = true;
				int cnt = block.HNBFOAJIIAL_Count;
				if (cnt > 1999)
					cnt = 2000;
				for(int i = 0; i < cnt; i++)
				{
					EDOHBJAPLPF_JsonData b = block[i];
					if(b.MDDJBLEDMBJ_IsInt)
					{
						POIKGADFLHF_SetPreciseScoreForMusic(i + 1, (int)b);
					}
					else if(b.DCPEFFOMOOK_IsLong)
					{
						POIKGADFLHF_SetPreciseScoreForMusic(i + 1, (long)b);
					}
					else if(b.NFPOKKABOHN_IsDouble)
					{
						POIKGADFLHF_SetPreciseScoreForMusic(i + 1, (double)b);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x11EA9DC Offset: 0x11EA9DC VA: 0x11EA9DC Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		ICLNENNIMOP_FreeScoreMax f = GPBJHKLFCEP as ICLNENNIMOP_FreeScoreMax;
		for(int i = 0; i < 2000; i++)
		{
			ECKFCIHPHGJ_SetScoreForMusic(i + 1, f.BDCAICINCKK_GetScoreMusic(i + 1));
			AGPLAKAFDEP[i] = f.AGPLAKAFDEP[i];
			HHDIPKALCDG[i] = f.HHDIPKALCDG[i];
		}
	}

	// // RVA: 0x11EAC28 Offset: 0x11EAC28 VA: 0x11EAC28 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		ICLNENNIMOP_FreeScoreMax other = GPBJHKLFCEP as ICLNENNIMOP_FreeScoreMax;
		double d = 50000000.0;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
			{
				d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("free_score_max_limit_score", 50000000);
			}
		}
		for(int i = 0; i < 2000; i++)
		{
			if(d <= AGPLAKAFDEP[i])
				return true;
			if(d <= other.AGPLAKAFDEP[i])
				return true;
		}
		for(int i = 0; i < 2000; i++)
		{
			if(BDCAICINCKK_GetScoreMusic(i + 1) != other.BDCAICINCKK_GetScoreMusic(i + 1) ||
				AGPLAKAFDEP[i] != other.AGPLAKAFDEP[i])
				return false;
		}
		return true;
	}

	// // RVA: 0x11EB038 Offset: 0x11EB038 VA: 0x11EB038 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}
}
