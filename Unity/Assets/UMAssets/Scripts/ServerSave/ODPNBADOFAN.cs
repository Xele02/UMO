
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use ODPNBADOFAN_Quest", true)]
public class ODPNBADOFAN { }
public class ODPNBADOFAN_Quest : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0
	private const int MKINOABMBGM = 20;
	private const int FOBFLHIIJOM = 1700;
	public long FANICHGKOML_init_date; // 0x28

	public List<NFPHOINMHKN_QuestInfo> BEGCHDHHEKC_DailyQuests { get; private set; } // 0x30 FGGBICBDOEN DEBOJOHHPPB CFINEIEEJGN
	public List<NFPHOINMHKN_QuestInfo> GPMKFMFEKLN_NormalQuests { get; private set; } // 0x34 LKPJIEOOENM HDOHKBOJCDK CDNIDJPOHDJ
	public override bool DMICHEJIAJL { get { return false; } } // 0x1B3C0BC NFKFOODCJJB

	// // RVA: 0x1B39620 Offset: 0x1B39620 VA: 0x1B39620
	public long DFFFCPCHBBE_EndDate()
	{
		DateTime d = Utility.GetLocalDateTime(FANICHGKOML_init_date);
		return Utility.GetTargetUnixTime(d.Year, d.Month, d.Day, 23, 59, 59);
	}

	// // RVA: 0x1B39724 Offset: 0x1B39724 VA: 0x1B39724
	public int KJJJNMHNMCG(DHOJHGODBAB_Quest MHGPMMIDKMM)
	{
		int res = 0;
		for(int i = 0; i < MHGPMMIDKMM.GPMKFMFEKLN_NormalQuests.Count; i++)
		{
			if(MHGPMMIDKMM.GPMKFMFEKLN_NormalQuests[i].INDDJNMPONH_type != 0)
			{
				if(GPMKFMFEKLN_NormalQuests[i].EALOBDHOCHP_stat == 3)
					res++;
			}
		}
		return res;
	}

	// // RVA: 0x1B39890 Offset: 0x1B39890 VA: 0x1B39890
	public ODPNBADOFAN_Quest()
	{
		BEGCHDHHEKC_DailyQuests = new List<NFPHOINMHKN_QuestInfo>(20);
		GPMKFMFEKLN_NormalQuests = new List<NFPHOINMHKN_QuestInfo>(1700);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1B39950 Offset: 0x1B39950 VA: 0x1B39950 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		FANICHGKOML_init_date = 0;
		BEGCHDHHEKC_DailyQuests.Clear();
		GPMKFMFEKLN_NormalQuests.Clear();
		int k = (int)Utility.GetCurrentUnixTime() * 0xbd005;
		for(int i = 0; i < 20; i++)
		{
			NFPHOINMHKN_QuestInfo data = new NFPHOINMHKN_QuestInfo();
			data.FBGGEFFJJHB_xor = k;
			data.PPFNGGCBJKC_id = i + 1;
			data.EALOBDHOCHP_stat = 0;
			data.BEBJKJKBOGH_date = 0;
			k *= 0xd;
			data.CADENLBDAEB_IsNew = true;
			BEGCHDHHEKC_DailyQuests.Add(data);
		}
		for(int i = 0; i < 1700; i++)
		{
			NFPHOINMHKN_QuestInfo data = new NFPHOINMHKN_QuestInfo();
			data.FBGGEFFJJHB_xor = k;
			data.PPFNGGCBJKC_id = i + 1;
			data.EALOBDHOCHP_stat = 0;
			data.BEBJKJKBOGH_date = 0;
			k *= 0xb;
			data.CADENLBDAEB_IsNew = true;
			GPMKFMFEKLN_NormalQuests.Add(data);
		}
	}

	// // RVA: 0x1B39C80 Offset: 0x1B39C80 VA: 0x1B39C80 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[POFDDFCGEGP_Underscore] = "";
			for(int i = 0; i < BEGCHDHHEKC_DailyQuests.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = BEGCHDHHEKC_DailyQuests[i].PPFNGGCBJKC_id;
				data3[AFEHLCGHAEE_Strings.EALOBDHOCHP_stat] = BEGCHDHHEKC_DailyQuests[i].EALOBDHOCHP_stat;
				data3[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = BEGCHDHHEKC_DailyQuests[i].BEBJKJKBOGH_date;
				data3[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = BEGCHDHHEKC_DailyQuests[i].CADENLBDAEB_IsNew ? 1 : 0;
				data2[POFDDFCGEGP_Underscore + (i + 1)] = data3;
			}
			data[AFEHLCGHAEE_Strings.EJFAEKPGKNJ_daily] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[POFDDFCGEGP_Underscore] = "";
			for (int i = 0; i < GPMKFMFEKLN_NormalQuests.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = GPMKFMFEKLN_NormalQuests[i].PPFNGGCBJKC_id;
				data3[AFEHLCGHAEE_Strings.EALOBDHOCHP_stat] = GPMKFMFEKLN_NormalQuests[i].EALOBDHOCHP_stat;
				data3[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = GPMKFMFEKLN_NormalQuests[i].BEBJKJKBOGH_date;
				data3[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = GPMKFMFEKLN_NormalQuests[i].CADENLBDAEB_IsNew ? 1 : 0;
				data2[POFDDFCGEGP_Underscore + (i + 1)] = data3;
			}
			data[AFEHLCGHAEE_Strings.EGDEGGMPIGA_normal] = data2;
		}
		data[AFEHLCGHAEE_Strings.FANICHGKOML_init_date] = FANICHGKOML_init_date;
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1B3A84C Offset: 0x1B3A84C VA: 0x1B3A84C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			OILEIIEIBHP = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		}
		bool isInvalid = true;
		if (OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
		{
			if ((int)OILEIIEIBHP[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] == 2)
				isInvalid = false;
		}
		FANICHGKOML_init_date = DKMPHAPBDLH_ReadLong(OILEIIEIBHP, AFEHLCGHAEE_Strings.FANICHGKOML_init_date, 0, ref isInvalid);
		DHOJHGODBAB_Quest questDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest;
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EJFAEKPGKNJ_daily))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.EJFAEKPGKNJ_daily];
			for(int i = 0; i < questDb.BEGCHDHHEKC_DailyQuests.Count; i++)
			{
				string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
				if(b.BBAJPINMOEP_Contains(str))
				{
					EDOHBJAPLPF_JsonData b2 = b[str];
					NFPHOINMHKN_QuestInfo data = BEGCHDHHEKC_DailyQuests[i];
					data.PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, i + 1, ref isInvalid);
					data.EALOBDHOCHP_stat = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
					data.BEBJKJKBOGH_date = DKMPHAPBDLH_ReadLong(b2, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
					data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 1, ref isInvalid) != 0;
				}
			}
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains("normal"))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP["normal"];
			for (int i = 0; i < questDb.GPMKFMFEKLN_NormalQuests.Count; i++)
			{
				string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
				if (b.BBAJPINMOEP_Contains(str))
				{
					EDOHBJAPLPF_JsonData b2 = b[str];
					NFPHOINMHKN_QuestInfo data = GPMKFMFEKLN_NormalQuests[i];
					data.PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, i + 1, ref isInvalid);
					data.EALOBDHOCHP_stat = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
					data.BEBJKJKBOGH_date = DKMPHAPBDLH_ReadLong(b2, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
					data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 1, ref isInvalid) != 0;
				}
			}
		}
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x1B3B480 Offset: 0x1B3B480 VA: 0x1B3B480 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		ODPNBADOFAN_Quest q = GPBJHKLFCEP as ODPNBADOFAN_Quest;
		for(int i = 0; i < GPMKFMFEKLN_NormalQuests.Count; i++)
		{
			GPMKFMFEKLN_NormalQuests[i].ODDIHGPONFL_Copy(q.GPMKFMFEKLN_NormalQuests[i]);
		}
		for(int i = 0; i < BEGCHDHHEKC_DailyQuests.Count; i++)
		{
			BEGCHDHHEKC_DailyQuests[i].ODDIHGPONFL_Copy(q.BEGCHDHHEKC_DailyQuests[i]);
		}
		FANICHGKOML_init_date = q.FANICHGKOML_init_date;
	}

	// // RVA: 0x1B3B74C Offset: 0x1B3B74C VA: 0x1B3B74C Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		ODPNBADOFAN_Quest other = GPBJHKLFCEP as ODPNBADOFAN_Quest;
		if(GPMKFMFEKLN_NormalQuests.Count != other.GPMKFMFEKLN_NormalQuests.Count ||
			BEGCHDHHEKC_DailyQuests.Count != other.BEGCHDHHEKC_DailyQuests.Count)
			return false;
		for(int i = 0; i < GPMKFMFEKLN_NormalQuests.Count; i++)
		{
			if(!GPMKFMFEKLN_NormalQuests[i].AGBOGBEOFME(other.GPMKFMFEKLN_NormalQuests[i]))
				return false;
		}
		for(int i = 0; i < BEGCHDHHEKC_DailyQuests.Count; i++)
		{
			if(!BEGCHDHHEKC_DailyQuests[i].AGBOGBEOFME(other.BEGCHDHHEKC_DailyQuests[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1B3BAE4 Offset: 0x1B3BAE4 VA: 0x1B3BAE4 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}

[System.Obsolete("Use NFPHOINMHKN_QuestInfo", true)]
public class NFPHOINMHKN { }
public class NFPHOINMHKN_QuestInfo
{
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0
	public bool CADENLBDAEB_IsNew; // 0x8
	public int EHOIENNDEDH_IdCrypted; // 0xC
	public int INNAAKJONMJ_StatCrypted; // 0x10
	public int FBGGEFFJJHB_xor; // 0x14
	public int EOONNJAMAMJ_StatCrypted2; // 0x18
	public int BJMDLOCLCEN_Crypted; // 0x1C
	public long BEBJKJKBOGH_date; // 0x20

	public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF3DF0 DEMEPMAEJOO 0x1AF3E00 HIGKAIDMOKN
	public int EALOBDHOCHP_stat { get { return INNAAKJONMJ_StatCrypted ^ FBGGEFFJJHB_xor; } set { INNAAKJONMJ_StatCrypted = value ^ FBGGEFFJJHB_xor; EOONNJAMAMJ_StatCrypted2 = value ^ FBGGEFFJJHB_xor; } } //0x1AF3E10 KLDFNIEJBFE 0x1AF3E1C GJLLJFLGMCN
	public int JIOMCDGKIAF { get { return BJMDLOCLCEN_Crypted ^ FBGGEFFJJHB_xor; } set { BJMDLOCLCEN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF3E30 DJHPCCHENCM 0x1AF3E40 CJEGJOKIJPO

	//// RVA: 0x1AF3E50 Offset: 0x1AF3E50 VA: 0x1AF3E50
	public bool AGBOGBEOFME(NFPHOINMHKN_QuestInfo OIKJFMGEICL)
	{
		if(CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew ||
			PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
			EALOBDHOCHP_stat != OIKJFMGEICL.EALOBDHOCHP_stat ||
			BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date)
			return false;
		return true;
	}

	//// RVA: 0x1AF3F70 Offset: 0x1AF3F70 VA: 0x1AF3F70
	public void ODDIHGPONFL_Copy(NFPHOINMHKN_QuestInfo GPBJHKLFCEP)
	{
		PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
		EALOBDHOCHP_stat = GPBJHKLFCEP.EALOBDHOCHP_stat;
		BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
		CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
	}

	//// RVA: 0x1AF4028 Offset: 0x1AF4028 VA: 0x1AF4028
	//public bool CHFOOMPEABN() { }

	//// RVA: 0x1AF4058 Offset: 0x1AF4058 VA: 0x1AF4058
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, NFPHOINMHKN _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

	//// RVA: 0x1AF5158 Offset: 0x1AF5158 VA: 0x1AF5158
	//public static int OKJENADDBMC(List<NFPHOINMHKN> NNDGIAEFMOG) { }

	//// RVA: 0x1AF5238 Offset: 0x1AF5238 VA: 0x1AF5238
	public static int JGJAEKFMEPM(List<NFPHOINMHKN_QuestInfo> NNDGIAEFMOG, DHOJHGODBAB_Quest MHGPMMIDKMM)
	{
		int res = 0;
		for(int i = 0; i < MHGPMMIDKMM.GPMKFMFEKLN_NormalQuests.Count; i++)
		{
			if(!MHGPMMIDKMM.GPMKFMFEKLN_NormalQuests[i].OAPCHMHAJID)
			{
				if(!ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(MHGPMMIDKMM.GPMKFMFEKLN_NormalQuests[i]))
				{
					if (NNDGIAEFMOG[i].EALOBDHOCHP_stat > 1)
						res++;
				}
			}
		}
		return res;
	}
}
