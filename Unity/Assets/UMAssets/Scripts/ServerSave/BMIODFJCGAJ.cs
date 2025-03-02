
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use BMIODFJCGAJ_EventBattlePlayer", true)]
public class BMIODFJCGAJ { }
public class BMIODFJCGAJ_EventBattlePlayer : KLFDBFMNLBL_ServerSaveBlock
{
	public const int ECFEMKGFDCE = 2;
	private const int OIEOCBIJLDC = 10;
	public int FBGGEFFJJHB = 0x2ca3b889; // 0x24
	public int EHGBICNIBKE_PlyerId; // 0x28
	public string LJNAKDMILMC_Key = ""; // 0x2C
	public string OPFGFINHFCE_Name = ""; // 0x30
	public int EOPEEENMHEN_Crypted; // 0x34
	public int LDEOJKDPFFI_Crypted; // 0x38
	public int DPOOAOPAAGC_Crypted; // 0x3C
	public int BAHBNDPEMJP_Crypted; // 0x40
	public int PGPDMJICNLO_Crypted; // 0x44
	public int JAFHGKBENFP_Crypted; // 0x48
	public int AOFGNAJLLPD_Crypted; // 0x4C
	public int CJAOMKLHFJL_Crypted; // 0x50
	public int JBFANBKCHMG_Crypted; // 0x54
	private const int BONKNMCOLHA = 6;
	public List<BLHNHKMMPAD> AILDCKKOLJG_Results = new List<BLHNHKMMPAD>(); // 0x58
	public List<int> PEIFEBNCMOM_Hist = new List<int>(); // 0x5C
	public int EGPMLMCCOLH; // 0x60

	public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ FBGGEFFJJHB; } set { EOPEEENMHEN_Crypted = value ^ FBGGEFFJJHB; } } // BNFNPCNAGAF 0x19C80E0 GEMDEGDPJPK 0x19C80F0
	public int OBGBAOLONDD { get { return JAFHGKBENFP_Crypted ^ FBGGEFFJJHB; } set { JAFHGKBENFP_Crypted = value ^ FBGGEFFJJHB; } } // OLHPPFCEIIK 0x19C8100 EIHCOIFCELN 0x19C8110
	public int NCAEFIHINAP_Cnt { get { return LDEOJKDPFFI_Crypted ^ FBGGEFFJJHB; } set { LDEOJKDPFFI_Crypted = value ^ FBGGEFFJJHB; } } // NBKJHKBBPHP 0x19C8120 KLNDBOMAJHF 0x19C8130
	public int EEAPIKNJNDB_ConsecutiveWin { get { return DPOOAOPAAGC_Crypted ^ FBGGEFFJJHB; } set { DPOOAOPAAGC_Crypted = value ^ FBGGEFFJJHB; } } //  KNLJPLHJMHI 0x19C8140  IMHAJFDFGJL 0x19C8150
	public int KEFMAJJPAKM_CWinMax { get { return BAHBNDPEMJP_Crypted ^ FBGGEFFJJHB; } set { BAHBNDPEMJP_Crypted = value ^ FBGGEFFJJHB; } } // JPBMCILHBLO 0x19C8160 PNCBJOMBOEJ 0x19C8170
	public int FGEIOMGBGLI_Twin { get { return PGPDMJICNLO_Crypted ^ FBGGEFFJJHB; } set { PGPDMJICNLO_Crypted = value ^ FBGGEFFJJHB; } } // HOPMOAGHMHO 0x19C8180 IOCOHNGCFKJ 0x19C8190
	public int DIPKCALNIII_Dv { get { return AOFGNAJLLPD_Crypted ^ FBGGEFFJJHB; } set { AOFGNAJLLPD_Crypted = value ^ FBGGEFFJJHB; } } // EOGPBFIDAPF 0x19C81A0 JDNCGPBAFMB 0x19C81B0
	public int GOIKCKHMBDL_F { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB; } } // BPGCGEDHBEH 0x19C81C0 ICPMFBIDFFO 0x19C81D0
	public int JKAMFMNGEBB_Hs { get { return JBFANBKCHMG_Crypted ^ FBGGEFFJJHB; } set { JBFANBKCHMG_Crypted = value ^ FBGGEFFJJHB; } } // EAOCMNMBDEG 0x19C81E0 ILFAFLEFJCF 0x19C81F0
	public override bool DMICHEJIAJL { get { return false; } } // 0x19CA08C NFKFOODCJJB

	// // RVA: 0x19C8200 Offset: 0x19C8200 VA: 0x19C8200
	public void KHEKNNFCAOI_Init(int GPLGIGCNNAD, string LJNAKDMILMC, string OPFGFINHFCE)
	{
		LJNAKDMILMC_Key = LJNAKDMILMC;
		IPPNCOHEEOD_ScoreAverage = 0;
		NCAEFIHINAP_Cnt = 0;
		EEAPIKNJNDB_ConsecutiveWin = 0;
		KEFMAJJPAKM_CWinMax = 0;
		FGEIOMGBGLI_Twin = 0;
		OPFGFINHFCE_Name = string.Copy(OPFGFINHFCE);
		IPPNCOHEEOD_ScoreAverage = 0;
		GOIKCKHMBDL_F = 0;
		DIPKCALNIII_Dv = 0;
		JKAMFMNGEBB_Hs = 0;
		OBGBAOLONDD = GPLGIGCNNAD;
		for(int i = 0; i < 10; i++)
		{
			PEIFEBNCMOM_Hist[i] = -1;
		}
		for(int i = 0; i < AILDCKKOLJG_Results.Count; i++)
		{
			AILDCKKOLJG_Results[i].LHPDDGIJKNB_Reset();
		}
	}

	// // RVA: 0x19C8378 Offset: 0x19C8378 VA: 0x19C8378
	public BMIODFJCGAJ_EventBattlePlayer()
	{
		PEIFEBNCMOM_Hist.Clear();
		for(int i = 0; i < 10; i++)
		{
			PEIFEBNCMOM_Hist.Add(-1);
		}
		AILDCKKOLJG_Results.Clear();
		for(int i = 0; i < 6; i++)
		{
			BLHNHKMMPAD data = new BLHNHKMMPAD();
			data.LHPDDGIJKNB_Reset();
			AILDCKKOLJG_Results.Add(data);
		}
		KMBPACJNEOF();
	}

	// // RVA: 0x19C8580 Offset: 0x19C8580 VA: 0x19C8580 Slot: 4
	public override void KMBPACJNEOF()
	{
		for(int i = 0; i < 6; i++)
		{
			AILDCKKOLJG_Results[i].LHPDDGIJKNB_Reset();
		}
		for(int i = 0; i < 10; i++)
		{
			PEIFEBNCMOM_Hist[i] = -1;
		}
		EGPMLMCCOLH = 0;
	}

	// // RVA: 0x19C8680 Offset: 0x19C8680 VA: 0x19C8680 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = LJNAKDMILMC_Key;
		data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = OPFGFINHFCE_Name;
		data[string.Format("avg_" + OBGBAOLONDD.ToString("D4"), Array.Empty<object>())] = IPPNCOHEEOD_ScoreAverage;
		data["cnt"] = NCAEFIHINAP_Cnt;
		data["cwin"] = EEAPIKNJNDB_ConsecutiveWin;
		data["cwin_max"] = KEFMAJJPAKM_CWinMax;
		data["twin"] = FGEIOMGBGLI_Twin;
		data["f"] = GOIKCKHMBDL_F;
		data["dv"] = DIPKCALNIII_Dv;
		data["hs"] = JKAMFMNGEBB_Hs;
		EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
		data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < AILDCKKOLJG_Results.Count; i++)
		{
			data2.Add(AILDCKKOLJG_Results[i].NOJCMGAFAAC());
		}
		data["results"] = data2;
		EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
		data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 10; i++)
		{
			data3.Add(PEIFEBNCMOM_Hist[i]);
		}
		data["hist"] = data3;
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x19C8DF8 Offset: 0x19C8DF8 VA: 0x19C8DF8 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
			return false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		if(!block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
			isInvalid = true;
		else
		{
			if((int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 2)
				isInvalid = true;
		}
		OKGLGHCBCJP_Database db = null;
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		}
		LJNAKDMILMC_Key = FGCNMLBACGO_ReadString(block, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
		OPFGFINHFCE_Name = FGCNMLBACGO_ReadString(block, AFEHLCGHAEE_Strings.OPFGFINHFCE_name, "", ref isInvalid);
		OBGBAOLONDD = 0;
		for(int i = 3001; i < 4000; i++)
		{
			string str = string.Format("avg_" + i.ToString("D4"), Array.Empty<object>());
			if(block.BBAJPINMOEP_Contains(str))
			{
				OBGBAOLONDD = i;
				IPPNCOHEEOD_ScoreAverage = CJAENOMGPDA_ReadInt(block, str, 0, ref isInvalid);
				break;
			}
		}
		string s = "";
		if(OBGBAOLONDD != 0)
		{
			s = "avg_" + OBGBAOLONDD.ToString("D4");
		}
		IPPNCOHEEOD_ScoreAverage = CJAENOMGPDA_ReadInt(block, s, 0, ref isInvalid);
		NCAEFIHINAP_Cnt = Mathf.Clamp(CJAENOMGPDA_ReadInt(block, "cnt", 0, ref isInvalid), 0, 9999);
		EEAPIKNJNDB_ConsecutiveWin = Mathf.Clamp(CJAENOMGPDA_ReadInt(block, "cwin", 0, ref isInvalid), 0, 999);
		KEFMAJJPAKM_CWinMax = Mathf.Clamp(CJAENOMGPDA_ReadInt(block, "cwin_max", 0, ref isInvalid), 0, 999);
		FGEIOMGBGLI_Twin = Mathf.Clamp(CJAENOMGPDA_ReadInt(block, "twin", 0, ref isInvalid), 0, 999);
		IPPNCOHEEOD_ScoreAverage = Mathf.Clamp(IPPNCOHEEOD_ScoreAverage, 0, 999999999);
		if(block.BBAJPINMOEP_Contains("results"))
		{
			EDOHBJAPLPF_JsonData d = block["results"];
			int cnt = d.HNBFOAJIIAL_Count;
			if(cnt > 0)
			{
				if(cnt >= 7)
				{
					cnt = 6;
					isInvalid = true;
				}
				for(int i = 0; i < cnt; i++)
				{
					AILDCKKOLJG_Results[i].IIEMACPEEBJ(db, d[i], ref isInvalid);
				}
			}
		}
		if(block.BBAJPINMOEP_Contains("hist"))
		{
			EDOHBJAPLPF_JsonData d = block["hist"];
			int cnt = d.HNBFOAJIIAL_Count;
			if(cnt > 0)
			{
				if(cnt >= 11)
				{
					cnt = 10;
					isInvalid = true;
				}
				for(int i = 0; i < cnt; i++)
				{
					PEIFEBNCMOM_Hist[i] = (int)d[i];
				}
			}
		}
		GOIKCKHMBDL_F = Mathf.Clamp(CJAENOMGPDA_ReadInt(block, "f", 0, ref isInvalid), 0, 2000);
		DIPKCALNIII_Dv = Mathf.Clamp(CJAENOMGPDA_ReadInt(block, "dv", 0, ref isInvalid), 1, 10);
		JKAMFMNGEBB_Hs = Mathf.Max(0, CJAENOMGPDA_ReadInt(block, "hs", 0, ref isInvalid));
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x19C979C Offset: 0x19C979C VA: 0x19C979C Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		BMIODFJCGAJ_EventBattlePlayer other = GPBJHKLFCEP as BMIODFJCGAJ_EventBattlePlayer;
		IPPNCOHEEOD_ScoreAverage = other.IPPNCOHEEOD_ScoreAverage;
		NCAEFIHINAP_Cnt = other.NCAEFIHINAP_Cnt;
		EEAPIKNJNDB_ConsecutiveWin = other.EEAPIKNJNDB_ConsecutiveWin;
		KEFMAJJPAKM_CWinMax = other.KEFMAJJPAKM_CWinMax;
		FGEIOMGBGLI_Twin = other.FGEIOMGBGLI_Twin;
		LJNAKDMILMC_Key = other.LJNAKDMILMC_Key;
		OPFGFINHFCE_Name = other.OPFGFINHFCE_Name;
		OBGBAOLONDD = other.OBGBAOLONDD;
		GOIKCKHMBDL_F = other.GOIKCKHMBDL_F;
		DIPKCALNIII_Dv = other.DIPKCALNIII_Dv;
		JKAMFMNGEBB_Hs = other.JKAMFMNGEBB_Hs;
		AILDCKKOLJG_Results.Clear();
		for(int i = 0; i < other.AILDCKKOLJG_Results.Count; i++)
		{
			BLHNHKMMPAD data = new BLHNHKMMPAD();
			data.LHPDDGIJKNB_Reset();
			data.ODDIHGPONFL(other.AILDCKKOLJG_Results[i]);
			AILDCKKOLJG_Results.Add(data);
		}
		for(int i = 0; i < PEIFEBNCMOM_Hist.Count; i++)
		{
			PEIFEBNCMOM_Hist[i] = other.PEIFEBNCMOM_Hist[i];
		}
	}

	// // RVA: 0x19C9C48 Offset: 0x19C9C48 VA: 0x19C9C48 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		BMIODFJCGAJ_EventBattlePlayer other = GPBJHKLFCEP as BMIODFJCGAJ_EventBattlePlayer;
		if(IPPNCOHEEOD_ScoreAverage != other.IPPNCOHEEOD_ScoreAverage)
			return false;
		if(AILDCKKOLJG_Results.Count != other.AILDCKKOLJG_Results.Count)
			return false;
		if(NCAEFIHINAP_Cnt != other.NCAEFIHINAP_Cnt)
			return false;
		if(EEAPIKNJNDB_ConsecutiveWin != other.EEAPIKNJNDB_ConsecutiveWin)
			return false;
		if(KEFMAJJPAKM_CWinMax != other.KEFMAJJPAKM_CWinMax)
			return false;
		if(FGEIOMGBGLI_Twin != other.FGEIOMGBGLI_Twin)
			return false;
		if(OBGBAOLONDD != other.OBGBAOLONDD)
			return false;
		if(GOIKCKHMBDL_F != other.GOIKCKHMBDL_F)
			return false;
		if(DIPKCALNIII_Dv != other.DIPKCALNIII_Dv)
			return false;
		if(JKAMFMNGEBB_Hs != other.JKAMFMNGEBB_Hs)
			return false;
		if(LJNAKDMILMC_Key != other.LJNAKDMILMC_Key)
			return false;
		if(OPFGFINHFCE_Name != other.OPFGFINHFCE_Name)
			return false;
		for(int i = 0; i < AILDCKKOLJG_Results.Count; i++)
		{
			if(!AILDCKKOLJG_Results[i].AGBOGBEOFME(other.AILDCKKOLJG_Results[i]))
				return false;
		}
		for(int i = 0; i < PEIFEBNCMOM_Hist.Count; i++)
		{
			if(PEIFEBNCMOM_Hist[i] != other.PEIFEBNCMOM_Hist[i])
				return false;
		}
		return true;
	}

	// // RVA: 0x19CA088 Offset: 0x19CA088 VA: 0x19CA088 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);
}
