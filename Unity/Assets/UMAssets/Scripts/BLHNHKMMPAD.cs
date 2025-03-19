
using System.ComponentModel;
using UnityEngine;
using XeSys;

public class BLHNHKMMPAD
{
	public int FBGGEFFJJHB; // 0x8
	public int[] MJNMPAKBNKB_NoteResultCount = new int[5]; // 0xC
	public int CJAOMKLHFJL_Crypted; // 0x10
	public int CPCKPCJBDEL_Crypted; // 0x14
	public int DMPDIMGFEBL_Crypted; // 0x18
	public int AOFGNAJLLPD_Crypted; // 0x1C
	public int BJHHOBEMBJG_Crypted; // 0x20
	public int LEHJBFPLJPL_Crypted; // 0x24
	public int ENEKCBCOKNM_Crypted; // 0x28
	public int MHGDDPCAGAJ_Crypted; // 0x2C
	public int GIELAFNPOCG_Crypted; // 0x30
	public int GHJIBEMCKLA_Crypted; // 0x34
	public int JKJDDGGNEAB_Crypted; // 0x38
	public int NBOLDNMPJFG_Crypted; // 0x3C
	public int BNPKALPLIJH_Crypted; // 0x40
	public int BCKCCHGMPBG_Crypted; // 0x44
	public int ONHKDPEAJOI_Crypted; // 0x48
	public int EOPEEENMHEN_Crypted; // 0x4C
	public int ADOIPHGJHBC_Crypted; // 0x50
	public long KLAPHOKNEDG_Crypted; // 0x58
	public int KPLDLGGMOMH_Crypted; // 0x60
	public int HIJDFKKMONB_Crypted; // 0x64
	public int LPNGJDDEJJD_Crypted; // 0x68
	public int GFPNAILCPLG_Crypted; // 0x6C

	public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF49C BPGCGEDHBEH 0x19BF4AC ICPMFBIDFFO
	public int AKNELONELJK_Difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF4BC BPPILHGDABB 0x19BF4CC PMMIIHKEGCI
	public int MIKICCLPDJA_L6 { get { return DMPDIMGFEBL_Crypted ^ FBGGEFFJJHB; } set { DMPDIMGFEBL_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF4DC CCFIANIJCJI 0x19BF4EC BFDODBCKDMK
	public int DIPKCALNIII_DivaId { get { return AOFGNAJLLPD_Crypted ^ FBGGEFFJJHB; } set { AOFGNAJLLPD_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF4FC EOGPBFIDAPF 0x19BF50C JDNCGPBAFMB
	public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_Crypted ^ FBGGEFFJJHB; } set { BJHHOBEMBJG_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF51C DIIBIOEMHAI 0x19BF52C JIHEDMEFKAF
	public int AFNIOJHODAG_CsCol { get { return LEHJBFPLJPL_Crypted ^ FBGGEFFJJHB; } set { LEHJBFPLJPL_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF53C OCABHAPHAMH 0x19BF54C DIAIECJEGDG
	public int HEBKEJBDCBH_DivaLevel { get { return ENEKCBCOKNM_Crypted ^ FBGGEFFJJHB; } set { ENEKCBCOKNM_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF55C OMOHEDILHMF 0x19BF56C FCGDHINFKHC
	public int GLILAGLJLEP_Scene { get { return MHGDDPCAGAJ_Crypted ^ FBGGEFFJJHB; } set { MHGDDPCAGAJ_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF57C HGPGPALMELF 0x19BF58C ECHLNFNJFFO
	public int ECOLMPLOPFM_SceneLevel { get { return GIELAFNPOCG_Crypted ^ FBGGEFFJJHB; } set { GIELAFNPOCG_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF59C BFLCGLBAFOE 0x19BF5AC NJGKCLHFDIB
	public int CFCIMKOHLIG_Mlt { get { return GHJIBEMCKLA_Crypted ^ FBGGEFFJJHB; } set { GHJIBEMCKLA_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF5BC AJNACFGNOAA 0x19BF5CC LCGAFCPHDKA
	public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ FBGGEFFJJHB; } set { EOPEEENMHEN_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF5DC BNFNPCNAGAF 0x19BF5EC GEMDEGDPJPK
	public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG_Crypted ^ FBGGEFFJJHB; } set { NBOLDNMPJFG_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF5FC EOJEPLIPOMJ 0x19BF60C AEEMBPAEAAI
	public int OFJHABJNGOD_ExcellentScore { get { return BNPKALPLIJH_Crypted ^ FBGGEFFJJHB; } set { BNPKALPLIJH_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF61C NDBFELIIICL 0x19BF62C BIJLJDDDMLL
	public int NLKEBAOBJCM_MaxCombo { get { return BCKCCHGMPBG_Crypted ^ FBGGEFFJJHB; } set { BCKCCHGMPBG_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF63C AECNKGBNKHH 0x19BF64C ECHLKFHOJFP
	public int LAMCCNAKIOJ_ComboRank { get { return ONHKDPEAJOI_Crypted ^ FBGGEFFJJHB; } set { ONHKDPEAJOI_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF65C IHEENNFAAAJ 0x19BF66C ODPFIDLANCG
	public int BDLNMOIOMHK_TotalStats { get { return JKJDDGGNEAB_Crypted ^ FBGGEFFJJHB; } set { JKJDDGGNEAB_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF67C MKMAKAEDMBG 0x19BF68C GIJPLHEDIKD
	public long BEBJKJKBOGH_Date { get { return KLAPHOKNEDG_Crypted ^ FBGGEFFJJHB; } set { KLAPHOKNEDG_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF69C DIAPHCJBPFD 0x19BF6B4 IHAIKPNEEJE
	public int NHLGACIHDAH_ExcellentCount { get { return ADOIPHGJHBC_Crypted ^ FBGGEFFJJHB; } set { ADOIPHGJHBC_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF6C8 MDCFGFPHGKO 0x19BF6D8 KJOPHNJJCOB
	public int EDJMDDAGCEJ_S1 { get { return KPLDLGGMOMH_Crypted ^ FBGGEFFJJHB; } set { KPLDLGGMOMH_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF6E8 BCMKDNCFOJO 0x19BF6F8 DDIAEKOKDIE
	public int HEFPAIOLBAG_S2 { get { return HIJDFKKMONB_Crypted ^ FBGGEFFJJHB; } set { HIJDFKKMONB_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF708 EAGPNJEBOCP 0x19BF718 LLIGHINHLOL
	public int ENNCJKLIGKE_Luck { get { return LPNGJDDEJJD_Crypted ^ FBGGEFFJJHB; } set { LPNGJDDEJJD_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF728 CIGNNFNAAAN 0x19BF738 DOLNOHODMEI
	public int PALEGNNHIKH_Leaf { get { return GFPNAILCPLG_Crypted ^ FBGGEFFJJHB; } set { GFPNAILCPLG_Crypted = value ^ FBGGEFFJJHB; } } //0x19BF748 MALPONGOPKO 0x19BF758 BHAFNMAEHOH

	// // RVA: 0x19BF768 Offset: 0x19BF768 VA: 0x19BF768 Slot: 4
	public virtual void LHPDDGIJKNB_Reset()
    {
        FBGGEFFJJHB = (int)NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() * 0x1d32 + 13;
        BEBJKJKBOGH_Date = 0;
        OFJHABJNGOD_ExcellentScore = 0;
        NLKEBAOBJCM_MaxCombo = 0;
        LAMCCNAKIOJ_ComboRank = 0;
        IPPNCOHEEOD_ScoreAverage = 0;
        NHLGACIHDAH_ExcellentCount = 0;
        GOIKCKHMBDL_FreeMusicId = 0;
        AKNELONELJK_Difficulty = 0;
        MIKICCLPDJA_L6 = 0;
        DIPKCALNIII_DivaId = 0;
        BEEAIAAJOHD_CostumeId = 0;
        AFNIOJHODAG_CsCol = 0;
        HEBKEJBDCBH_DivaLevel = 0;
        GLILAGLJLEP_Scene = 0;
        ECOLMPLOPFM_SceneLevel = 0;
        CFCIMKOHLIG_Mlt = 0;
        BDLNMOIOMHK_TotalStats = 0;
        KNIFCANOHOC_Score = 0;
        EDJMDDAGCEJ_S1 = 0;
        HEFPAIOLBAG_S2 = 0;
        ENNCJKLIGKE_Luck = 0;
        PALEGNNHIKH_Leaf = 0;
        for(int i = 0; i < MJNMPAKBNKB_NoteResultCount.Length; i++)
        {
            MJNMPAKBNKB_NoteResultCount[i] = 0;
        }
    }

	// // RVA: 0x19BF904 Offset: 0x19BF904 VA: 0x19BF904 Slot: 5
	public virtual bool AGBOGBEOFME(BLHNHKMMPAD OIKJFMGEICL)
	{
		if(GOIKCKHMBDL_FreeMusicId != OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId)
			return false;
		if(AKNELONELJK_Difficulty != OIKJFMGEICL.AKNELONELJK_Difficulty)
			return false;
		if(BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
			return false;
		if(MIKICCLPDJA_L6 != OIKJFMGEICL.MIKICCLPDJA_L6)
			return false;
		if(DIPKCALNIII_DivaId != OIKJFMGEICL.DIPKCALNIII_DivaId)
			return false;
		if(BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId)
			return false;
		if(AFNIOJHODAG_CsCol != OIKJFMGEICL.AFNIOJHODAG_CsCol)
			return false;
		if(HEBKEJBDCBH_DivaLevel != OIKJFMGEICL.HEBKEJBDCBH_DivaLevel)
			return false;
		if(GLILAGLJLEP_Scene != OIKJFMGEICL.GLILAGLJLEP_Scene)
			return false;
		if(ECOLMPLOPFM_SceneLevel != OIKJFMGEICL.ECOLMPLOPFM_SceneLevel)
			return false;
		if(CFCIMKOHLIG_Mlt != OIKJFMGEICL.CFCIMKOHLIG_Mlt)
			return false;
		if(IPPNCOHEEOD_ScoreAverage != OIKJFMGEICL.IPPNCOHEEOD_ScoreAverage)
			return false;
		if(KNIFCANOHOC_Score != OIKJFMGEICL.KNIFCANOHOC_Score)
			return false;
		if(OFJHABJNGOD_ExcellentScore != OIKJFMGEICL.OFJHABJNGOD_ExcellentScore)
			return false;
		if(BDLNMOIOMHK_TotalStats != OIKJFMGEICL.BDLNMOIOMHK_TotalStats)
			return false;
		if(NLKEBAOBJCM_MaxCombo != OIKJFMGEICL.NLKEBAOBJCM_MaxCombo)
			return false;
		if(LAMCCNAKIOJ_ComboRank != OIKJFMGEICL.LAMCCNAKIOJ_ComboRank)
			return false;
		if(NHLGACIHDAH_ExcellentCount != OIKJFMGEICL.NHLGACIHDAH_ExcellentCount)
			return false;
		if(ENNCJKLIGKE_Luck != OIKJFMGEICL.ENNCJKLIGKE_Luck)
			return false;
		if(PALEGNNHIKH_Leaf != OIKJFMGEICL.PALEGNNHIKH_Leaf)
			return false;
		if(EDJMDDAGCEJ_S1 != OIKJFMGEICL.EDJMDDAGCEJ_S1)
			return false;
		if(HEFPAIOLBAG_S2 != OIKJFMGEICL.HEFPAIOLBAG_S2)
			return false;
		for(int i = 0; i < MJNMPAKBNKB_NoteResultCount.Length; i++)
		{
			if(MJNMPAKBNKB_NoteResultCount[i] != OIKJFMGEICL.MJNMPAKBNKB_NoteResultCount[i])
				return false;
		}
		return true;
	}

	// // RVA: 0x19BFEA0 Offset: 0x19BFEA0 VA: 0x19BFEA0 Slot: 6
	public virtual void ODDIHGPONFL(BLHNHKMMPAD OIKJFMGEICL)
	{
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		AKNELONELJK_Difficulty = OIKJFMGEICL.AKNELONELJK_Difficulty;
		MIKICCLPDJA_L6 = OIKJFMGEICL.MIKICCLPDJA_L6;
		DIPKCALNIII_DivaId = OIKJFMGEICL.DIPKCALNIII_DivaId;
		BEEAIAAJOHD_CostumeId = OIKJFMGEICL.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CsCol = OIKJFMGEICL.AFNIOJHODAG_CsCol;
		HEBKEJBDCBH_DivaLevel = OIKJFMGEICL.HEBKEJBDCBH_DivaLevel;
		GLILAGLJLEP_Scene = OIKJFMGEICL.GLILAGLJLEP_Scene;
		ECOLMPLOPFM_SceneLevel = OIKJFMGEICL.ECOLMPLOPFM_SceneLevel;
		IPPNCOHEEOD_ScoreAverage = OIKJFMGEICL.IPPNCOHEEOD_ScoreAverage;
		KNIFCANOHOC_Score = OIKJFMGEICL.KNIFCANOHOC_Score;
		OFJHABJNGOD_ExcellentScore = OIKJFMGEICL.OFJHABJNGOD_ExcellentScore;
		BEBJKJKBOGH_Date = OIKJFMGEICL.BEBJKJKBOGH_Date;
		NLKEBAOBJCM_MaxCombo = OIKJFMGEICL.NLKEBAOBJCM_MaxCombo;
		LAMCCNAKIOJ_ComboRank = OIKJFMGEICL.LAMCCNAKIOJ_ComboRank;
		BDLNMOIOMHK_TotalStats = OIKJFMGEICL.BDLNMOIOMHK_TotalStats;
		NHLGACIHDAH_ExcellentCount = OIKJFMGEICL.NHLGACIHDAH_ExcellentCount;
		ENNCJKLIGKE_Luck = OIKJFMGEICL.ENNCJKLIGKE_Luck;
		PALEGNNHIKH_Leaf = OIKJFMGEICL.PALEGNNHIKH_Leaf;
		EDJMDDAGCEJ_S1 = OIKJFMGEICL.EDJMDDAGCEJ_S1;
		HEFPAIOLBAG_S2 = OIKJFMGEICL.HEFPAIOLBAG_S2;
		for(int i = 0; i < MJNMPAKBNKB_NoteResultCount.Length; i++)
		{
			MJNMPAKBNKB_NoteResultCount[i] = OIKJFMGEICL.MJNMPAKBNKB_NoteResultCount[i];
		}
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
	}

	// // RVA: 0x19C039C Offset: 0x19C039C VA: 0x19C039C
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res["f"] = GOIKCKHMBDL_FreeMusicId;
		res["df"] = AKNELONELJK_Difficulty;
		res["dv"] = DIPKCALNIII_DivaId;
		res["cs"] = BEEAIAAJOHD_CostumeId;
		res["cs_col"] = AFNIOJHODAG_CsCol;
		res["dl"] = HEBKEJBDCBH_DivaLevel;
		res["s"] = GLILAGLJLEP_Scene;
		res["sl"] = ECOLMPLOPFM_SceneLevel;
		res["m"] = CFCIMKOHLIG_Mlt;
		res["av"] = IPPNCOHEEOD_ScoreAverage;
		res["cb"] = NLKEBAOBJCM_MaxCombo;
		res["cr"] = LAMCCNAKIOJ_ComboRank;
		res["to"] = BDLNMOIOMHK_TotalStats;
		res["sc"] = KNIFCANOHOC_Score;
		res["d"] = BEBJKJKBOGH_Date;
		res["ex"] = NHLGACIHDAH_ExcellentCount;
		res["lu"] = ENNCJKLIGKE_Luck;
		res["lf"] = PALEGNNHIKH_Leaf;
		res["s1"] = EDJMDDAGCEJ_S1;
		res["s2"] = HEFPAIOLBAG_S2;
		res["l6"] = MIKICCLPDJA_L6;
		res["se"] = OFJHABJNGOD_ExcellentScore;
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 5; i++)
		{
			data.Add(MJNMPAKBNKB_NoteResultCount[i]);
		}
		res["nr"] = data;
		return res;
	}

	// // RVA: 0x19C0B6C Offset: 0x19C0B6C VA: 0x19C0B6C
	public void IIEMACPEEBJ(OKGLGHCBCJP_Database LKMHPJKIFDN, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool NGJDHLGMHMH)
	{
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("f"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("df"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("dv"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("cs"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("dl"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("s"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("sl"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("m"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("av"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("cb"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("cr"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("to"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("sc"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("d"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("ex"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("lu"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("lf"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("kr"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("s1"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("s2"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("l6"))
			NGJDHLGMHMH = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("se"))
			NGJDHLGMHMH = true;
		LHPDDGIJKNB_Reset();
		GOIKCKHMBDL_FreeMusicId = JsonUtil.GetInt(OBHAFLMHAKG, "f", 0);
		AKNELONELJK_Difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "df", 0);
		DIPKCALNIII_DivaId = JsonUtil.GetInt(OBHAFLMHAKG, "dv", 0);
		BEEAIAAJOHD_CostumeId = JsonUtil.GetInt(OBHAFLMHAKG, "cs", 0);
		AFNIOJHODAG_CsCol = JsonUtil.GetInt(OBHAFLMHAKG, "cs_col", 0);
		HEBKEJBDCBH_DivaLevel = JsonUtil.GetInt(OBHAFLMHAKG, "dl", 0);
		GLILAGLJLEP_Scene = JsonUtil.GetInt(OBHAFLMHAKG, "s", 0);
		ECOLMPLOPFM_SceneLevel = JsonUtil.GetInt(OBHAFLMHAKG, "sl", 0);
		CFCIMKOHLIG_Mlt = JsonUtil.GetInt(OBHAFLMHAKG, "m", 0);
		IPPNCOHEEOD_ScoreAverage = JsonUtil.GetInt(OBHAFLMHAKG, "av", 0);
		NLKEBAOBJCM_MaxCombo = JsonUtil.GetInt(OBHAFLMHAKG, "cb", 0);
		LAMCCNAKIOJ_ComboRank = JsonUtil.GetInt(OBHAFLMHAKG, "cr", 0);
		BDLNMOIOMHK_TotalStats = JsonUtil.GetInt(OBHAFLMHAKG, "to", 0);
		KNIFCANOHOC_Score = JsonUtil.GetInt(OBHAFLMHAKG, "sc", 0);
		BEBJKJKBOGH_Date = JsonUtil.GetLong(OBHAFLMHAKG, "d", 0);
		NHLGACIHDAH_ExcellentCount = JsonUtil.GetInt(OBHAFLMHAKG, "ex", 0);
		ENNCJKLIGKE_Luck = JsonUtil.GetInt(OBHAFLMHAKG, "lu", 0);
		PALEGNNHIKH_Leaf = JsonUtil.GetInt(OBHAFLMHAKG, "lf", 0);
		EDJMDDAGCEJ_S1 = JsonUtil.GetInt(OBHAFLMHAKG, "s1", 0);
		HEFPAIOLBAG_S2 = JsonUtil.GetInt(OBHAFLMHAKG, "s2", 0);
		MIKICCLPDJA_L6 = JsonUtil.GetInt(OBHAFLMHAKG, "l6", 0);
		OFJHABJNGOD_ExcellentScore = JsonUtil.GetInt(OBHAFLMHAKG, "se", 0);
		if(OFJHABJNGOD_ExcellentScore < 0)
		{
			AKNELONELJK_Difficulty = 0;
		}
		if(OFJHABJNGOD_ExcellentScore > 4)
		{
			AKNELONELJK_Difficulty = 4;
		}
		MIKICCLPDJA_L6 = 0;
		if(LKMHPJKIFDN.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(DIPKCALNIII_DivaId))
		{
			if(!LKMHPJKIFDN.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(BEEAIAAJOHD_CostumeId, DIPKCALNIII_DivaId))
			{
				BEEAIAAJOHD_CostumeId = 0;
				AFNIOJHODAG_CsCol = 0;
			}
		}
		else
		{
			DIPKCALNIII_DivaId = 1;
			BEEAIAAJOHD_CostumeId = 0;
			AFNIOJHODAG_CsCol = 0;
		}
		if(!LKMHPJKIFDN.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(GLILAGLJLEP_Scene))
		{
			GLILAGLJLEP_Scene = 0;
			ECOLMPLOPFM_SceneLevel = 0;
			CFCIMKOHLIG_Mlt = 0;
		}
		IPPNCOHEEOD_ScoreAverage = Mathf.Clamp(IPPNCOHEEOD_ScoreAverage, 0, 99999999);
		if(OBHAFLMHAKG.BBAJPINMOEP_Contains("nr"))
		{
			EDOHBJAPLPF_JsonData data = OBHAFLMHAKG["nr"];
			for(int i = 0; i < 5; i++)
			{
				MJNMPAKBNKB_NoteResultCount[i] = (int)data[i];
				MJNMPAKBNKB_NoteResultCount[i] = Mathf.Clamp(MJNMPAKBNKB_NoteResultCount[i], 0, 9999);
			}
		}
		else
		{
			NGJDHLGMHMH = true;
		}
	}
}
