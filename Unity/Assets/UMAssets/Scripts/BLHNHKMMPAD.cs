
using System.ComponentModel;
using UnityEngine;
using XeSys;

public class BLHNHKMMPAD
{
	public int FBGGEFFJJHB_xor; // 0x8
	public int[] MJNMPAKBNKB_NotesResult = new int[5]; // 0xC
	public int CJAOMKLHFJL_Crypted; // 0x10
	public int CPCKPCJBDEL_Crypted; // 0x14
	public int DMPDIMGFEBL_Crypted; // 0x18
	public int AOFGNAJLLPD_DivaIdCrypted; // 0x1C
	public int BJHHOBEMBJG_CostumeIdCrypted; // 0x20
	public int LEHJBFPLJPL_CostumeColorIdCrypted; // 0x24
	public int ENEKCBCOKNM_Crypted; // 0x28
	public int MHGDDPCAGAJ_Crypted; // 0x2C
	public int GIELAFNPOCG_Crypted; // 0x30
	public int GHJIBEMCKLA_Crypted; // 0x34
	public int JKJDDGGNEAB_TotalCrypted; // 0x38
	public int NBOLDNMPJFG_scoreCrypted; // 0x3C
	public int BNPKALPLIJH_Crypted; // 0x40
	public int BCKCCHGMPBG_Crypted; // 0x44
	public int ONHKDPEAJOI_Crypted; // 0x48
	public int EOPEEENMHEN_Crypted; // 0x4C
	public int ADOIPHGJHBC_ExcellentCountCrypted; // 0x50
	public long KLAPHOKNEDG_DateCrypted; // 0x58
	public int KPLDLGGMOMH_Crypted; // 0x60
	public int HIJDFKKMONB_Crypted; // 0x64
	public int LPNGJDDEJJD_Crypted; // 0x68
	public int GFPNAILCPLG_Crypted; // 0x6C

	public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB_xor; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF49C BPGCGEDHBEH 0x19BF4AC ICPMFBIDFFO
	public int AKNELONELJK_difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB_xor; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF4BC BPPILHGDABB 0x19BF4CC PMMIIHKEGCI
	public int MIKICCLPDJA_L6 { get { return DMPDIMGFEBL_Crypted ^ FBGGEFFJJHB_xor; } set { DMPDIMGFEBL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF4DC CCFIANIJCJI 0x19BF4EC BFDODBCKDMK
	public int DIPKCALNIII_DivaId { get { return AOFGNAJLLPD_DivaIdCrypted ^ FBGGEFFJJHB_xor; } set { AOFGNAJLLPD_DivaIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF4FC EOGPBFIDAPF 0x19BF50C JDNCGPBAFMB
	public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { BJHHOBEMBJG_CostumeIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF51C DIIBIOEMHAI 0x19BF52C JIHEDMEFKAF
	public int AFNIOJHODAG_CostumeColorId { get { return LEHJBFPLJPL_CostumeColorIdCrypted ^ FBGGEFFJJHB_xor; } set { LEHJBFPLJPL_CostumeColorIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF53C OCABHAPHAMH 0x19BF54C DIAIECJEGDG
	public int HEBKEJBDCBH_DivaLevel { get { return ENEKCBCOKNM_Crypted ^ FBGGEFFJJHB_xor; } set { ENEKCBCOKNM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF55C OMOHEDILHMF 0x19BF56C FCGDHINFKHC
	public int GLILAGLJLEP_Scene { get { return MHGDDPCAGAJ_Crypted ^ FBGGEFFJJHB_xor; } set { MHGDDPCAGAJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF57C HGPGPALMELF 0x19BF58C ECHLNFNJFFO
	public int ECOLMPLOPFM_SceneLevel { get { return GIELAFNPOCG_Crypted ^ FBGGEFFJJHB_xor; } set { GIELAFNPOCG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF59C BFLCGLBAFOE 0x19BF5AC NJGKCLHFDIB
	public int CFCIMKOHLIG_Mlt { get { return GHJIBEMCKLA_Crypted ^ FBGGEFFJJHB_xor; } set { GHJIBEMCKLA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF5BC AJNACFGNOAA 0x19BF5CC LCGAFCPHDKA
	public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ FBGGEFFJJHB_xor; } set { EOPEEENMHEN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF5DC BNFNPCNAGAF 0x19BF5EC GEMDEGDPJPK
	public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF5FC EOJEPLIPOMJ 0x19BF60C AEEMBPAEAAI
	public int OFJHABJNGOD_ExcellentScore { get { return BNPKALPLIJH_Crypted ^ FBGGEFFJJHB_xor; } set { BNPKALPLIJH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF61C NDBFELIIICL 0x19BF62C BIJLJDDDMLL
	public int NLKEBAOBJCM_combo { get { return BCKCCHGMPBG_Crypted ^ FBGGEFFJJHB_xor; } set { BCKCCHGMPBG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF63C AECNKGBNKHH 0x19BF64C ECHLKFHOJFP
	public int LAMCCNAKIOJ_ComboRank { get { return ONHKDPEAJOI_Crypted ^ FBGGEFFJJHB_xor; } set { ONHKDPEAJOI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF65C IHEENNFAAAJ 0x19BF66C ODPFIDLANCG
	public int BDLNMOIOMHK_Total { get { return JKJDDGGNEAB_TotalCrypted ^ FBGGEFFJJHB_xor; } set { JKJDDGGNEAB_TotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF67C MKMAKAEDMBG 0x19BF68C GIJPLHEDIKD
	public long BEBJKJKBOGH_Date { get { return KLAPHOKNEDG_DateCrypted ^ FBGGEFFJJHB_xor; } set { KLAPHOKNEDG_DateCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF69C DIAPHCJBPFD 0x19BF6B4 IHAIKPNEEJE
	public int NHLGACIHDAH_ExcellentCount { get { return ADOIPHGJHBC_ExcellentCountCrypted ^ FBGGEFFJJHB_xor; } set { ADOIPHGJHBC_ExcellentCountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF6C8 MDCFGFPHGKO 0x19BF6D8 KJOPHNJJCOB
	public int EDJMDDAGCEJ_S1 { get { return KPLDLGGMOMH_Crypted ^ FBGGEFFJJHB_xor; } set { KPLDLGGMOMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF6E8 BCMKDNCFOJO 0x19BF6F8 DDIAEKOKDIE
	public int HEFPAIOLBAG_S2 { get { return HIJDFKKMONB_Crypted ^ FBGGEFFJJHB_xor; } set { HIJDFKKMONB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF708 EAGPNJEBOCP 0x19BF718 LLIGHINHLOL
	public int ENNCJKLIGKE_Luck { get { return LPNGJDDEJJD_Crypted ^ FBGGEFFJJHB_xor; } set { LPNGJDDEJJD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF728 CIGNNFNAAAN 0x19BF738 DOLNOHODMEI
	public int PALEGNNHIKH_Leaf { get { return GFPNAILCPLG_Crypted ^ FBGGEFFJJHB_xor; } set { GFPNAILCPLG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19BF748 MALPONGOPKO 0x19BF758 BHAFNMAEHOH

	// // RVA: 0x19BF768 Offset: 0x19BF768 VA: 0x19BF768 Slot: 4
	public virtual void LHPDDGIJKNB_Reset()
    {
        FBGGEFFJJHB_xor = (int)NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() * 0x1d32 + 13;
        BEBJKJKBOGH_Date = 0;
        OFJHABJNGOD_ExcellentScore = 0;
        NLKEBAOBJCM_combo = 0;
        LAMCCNAKIOJ_ComboRank = 0;
        IPPNCOHEEOD_ScoreAverage = 0;
        NHLGACIHDAH_ExcellentCount = 0;
        GOIKCKHMBDL_FreeMusicId = 0;
        AKNELONELJK_difficulty = 0;
        MIKICCLPDJA_L6 = 0;
        DIPKCALNIII_DivaId = 0;
        BEEAIAAJOHD_CostumeId = 0;
        AFNIOJHODAG_CostumeColorId = 0;
        HEBKEJBDCBH_DivaLevel = 0;
        GLILAGLJLEP_Scene = 0;
        ECOLMPLOPFM_SceneLevel = 0;
        CFCIMKOHLIG_Mlt = 0;
        BDLNMOIOMHK_Total = 0;
        KNIFCANOHOC_score = 0;
        EDJMDDAGCEJ_S1 = 0;
        HEFPAIOLBAG_S2 = 0;
        ENNCJKLIGKE_Luck = 0;
        PALEGNNHIKH_Leaf = 0;
        for(int i = 0; i < MJNMPAKBNKB_NotesResult.Length; i++)
        {
            MJNMPAKBNKB_NotesResult[i] = 0;
        }
    }

	// // RVA: 0x19BF904 Offset: 0x19BF904 VA: 0x19BF904 Slot: 5
	public virtual bool AGBOGBEOFME(BLHNHKMMPAD OIKJFMGEICL)
	{
		if(GOIKCKHMBDL_FreeMusicId != OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId)
			return false;
		if(AKNELONELJK_difficulty != OIKJFMGEICL.AKNELONELJK_difficulty)
			return false;
		if(BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
			return false;
		if(MIKICCLPDJA_L6 != OIKJFMGEICL.MIKICCLPDJA_L6)
			return false;
		if(DIPKCALNIII_DivaId != OIKJFMGEICL.DIPKCALNIII_DivaId)
			return false;
		if(BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId)
			return false;
		if(AFNIOJHODAG_CostumeColorId != OIKJFMGEICL.AFNIOJHODAG_CostumeColorId)
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
		if(KNIFCANOHOC_score != OIKJFMGEICL.KNIFCANOHOC_score)
			return false;
		if(OFJHABJNGOD_ExcellentScore != OIKJFMGEICL.OFJHABJNGOD_ExcellentScore)
			return false;
		if(BDLNMOIOMHK_Total != OIKJFMGEICL.BDLNMOIOMHK_Total)
			return false;
		if(NLKEBAOBJCM_combo != OIKJFMGEICL.NLKEBAOBJCM_combo)
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
		for(int i = 0; i < MJNMPAKBNKB_NotesResult.Length; i++)
		{
			if(MJNMPAKBNKB_NotesResult[i] != OIKJFMGEICL.MJNMPAKBNKB_NotesResult[i])
				return false;
		}
		return true;
	}

	// // RVA: 0x19BFEA0 Offset: 0x19BFEA0 VA: 0x19BFEA0 Slot: 6
	public virtual void ODDIHGPONFL_Copy(BLHNHKMMPAD OIKJFMGEICL)
	{
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		AKNELONELJK_difficulty = OIKJFMGEICL.AKNELONELJK_difficulty;
		MIKICCLPDJA_L6 = OIKJFMGEICL.MIKICCLPDJA_L6;
		DIPKCALNIII_DivaId = OIKJFMGEICL.DIPKCALNIII_DivaId;
		BEEAIAAJOHD_CostumeId = OIKJFMGEICL.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CostumeColorId = OIKJFMGEICL.AFNIOJHODAG_CostumeColorId;
		HEBKEJBDCBH_DivaLevel = OIKJFMGEICL.HEBKEJBDCBH_DivaLevel;
		GLILAGLJLEP_Scene = OIKJFMGEICL.GLILAGLJLEP_Scene;
		ECOLMPLOPFM_SceneLevel = OIKJFMGEICL.ECOLMPLOPFM_SceneLevel;
		IPPNCOHEEOD_ScoreAverage = OIKJFMGEICL.IPPNCOHEEOD_ScoreAverage;
		KNIFCANOHOC_score = OIKJFMGEICL.KNIFCANOHOC_score;
		OFJHABJNGOD_ExcellentScore = OIKJFMGEICL.OFJHABJNGOD_ExcellentScore;
		BEBJKJKBOGH_Date = OIKJFMGEICL.BEBJKJKBOGH_Date;
		NLKEBAOBJCM_combo = OIKJFMGEICL.NLKEBAOBJCM_combo;
		LAMCCNAKIOJ_ComboRank = OIKJFMGEICL.LAMCCNAKIOJ_ComboRank;
		BDLNMOIOMHK_Total = OIKJFMGEICL.BDLNMOIOMHK_Total;
		NHLGACIHDAH_ExcellentCount = OIKJFMGEICL.NHLGACIHDAH_ExcellentCount;
		ENNCJKLIGKE_Luck = OIKJFMGEICL.ENNCJKLIGKE_Luck;
		PALEGNNHIKH_Leaf = OIKJFMGEICL.PALEGNNHIKH_Leaf;
		EDJMDDAGCEJ_S1 = OIKJFMGEICL.EDJMDDAGCEJ_S1;
		HEFPAIOLBAG_S2 = OIKJFMGEICL.HEFPAIOLBAG_S2;
		for(int i = 0; i < MJNMPAKBNKB_NotesResult.Length; i++)
		{
			MJNMPAKBNKB_NotesResult[i] = OIKJFMGEICL.MJNMPAKBNKB_NotesResult[i];
		}
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
		GOIKCKHMBDL_FreeMusicId = OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId;
	}

	// // RVA: 0x19C039C Offset: 0x19C039C VA: 0x19C039C
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res["f"] = GOIKCKHMBDL_FreeMusicId;
		res["df"] = AKNELONELJK_difficulty;
		res["dv"] = DIPKCALNIII_DivaId;
		res["cs"] = BEEAIAAJOHD_CostumeId;
		res["cs_col"] = AFNIOJHODAG_CostumeColorId;
		res["dl"] = HEBKEJBDCBH_DivaLevel;
		res["s"] = GLILAGLJLEP_Scene;
		res["sl"] = ECOLMPLOPFM_SceneLevel;
		res["m"] = CFCIMKOHLIG_Mlt;
		res["av"] = IPPNCOHEEOD_ScoreAverage;
		res["cb"] = NLKEBAOBJCM_combo;
		res["cr"] = LAMCCNAKIOJ_ComboRank;
		res["to"] = BDLNMOIOMHK_Total;
		res["sc"] = KNIFCANOHOC_score;
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
			data.Add(MJNMPAKBNKB_NotesResult[i]);
		}
		res["nr"] = data;
		return res;
	}

	// // RVA: 0x19C0B6C Offset: 0x19C0B6C VA: 0x19C0B6C
	public void IIEMACPEEBJ_Deserialize(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("f"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("df"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("dv"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("cs"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("dl"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("s"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("sl"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("m"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("av"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("cb"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("cr"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("to"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("sc"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("d"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("ex"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("lu"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("lf"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("kr"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("s1"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("s2"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("l6"))
			_NGJDHLGMHMH_IsInvalid = true;
		if(!OBHAFLMHAKG.BBAJPINMOEP_Contains("se"))
			_NGJDHLGMHMH_IsInvalid = true;
		LHPDDGIJKNB_Reset();
		GOIKCKHMBDL_FreeMusicId = JsonUtil.GetInt(OBHAFLMHAKG, "f", 0);
		AKNELONELJK_difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "df", 0);
		DIPKCALNIII_DivaId = JsonUtil.GetInt(OBHAFLMHAKG, "dv", 0);
		BEEAIAAJOHD_CostumeId = JsonUtil.GetInt(OBHAFLMHAKG, "cs", 0);
		AFNIOJHODAG_CostumeColorId = JsonUtil.GetInt(OBHAFLMHAKG, "cs_col", 0);
		HEBKEJBDCBH_DivaLevel = JsonUtil.GetInt(OBHAFLMHAKG, "dl", 0);
		GLILAGLJLEP_Scene = JsonUtil.GetInt(OBHAFLMHAKG, "s", 0);
		ECOLMPLOPFM_SceneLevel = JsonUtil.GetInt(OBHAFLMHAKG, "sl", 0);
		CFCIMKOHLIG_Mlt = JsonUtil.GetInt(OBHAFLMHAKG, "m", 0);
		IPPNCOHEEOD_ScoreAverage = JsonUtil.GetInt(OBHAFLMHAKG, "av", 0);
		NLKEBAOBJCM_combo = JsonUtil.GetInt(OBHAFLMHAKG, "cb", 0);
		LAMCCNAKIOJ_ComboRank = JsonUtil.GetInt(OBHAFLMHAKG, "cr", 0);
		BDLNMOIOMHK_Total = JsonUtil.GetInt(OBHAFLMHAKG, "to", 0);
		KNIFCANOHOC_score = JsonUtil.GetInt(OBHAFLMHAKG, "sc", 0);
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
			AKNELONELJK_difficulty = 0;
		}
		if(OFJHABJNGOD_ExcellentScore > 4)
		{
			AKNELONELJK_difficulty = 4;
		}
		MIKICCLPDJA_L6 = 0;
		if(_LKMHPJKIFDN_md.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(DIPKCALNIII_DivaId))
		{
			if(!_LKMHPJKIFDN_md.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(BEEAIAAJOHD_CostumeId, DIPKCALNIII_DivaId))
			{
				BEEAIAAJOHD_CostumeId = 0;
				AFNIOJHODAG_CostumeColorId = 0;
			}
		}
		else
		{
			DIPKCALNIII_DivaId = 1;
			BEEAIAAJOHD_CostumeId = 0;
			AFNIOJHODAG_CostumeColorId = 0;
		}
		if(!_LKMHPJKIFDN_md.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(GLILAGLJLEP_Scene))
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
				MJNMPAKBNKB_NotesResult[i] = (int)data[i];
				MJNMPAKBNKB_NotesResult[i] = Mathf.Clamp(MJNMPAKBNKB_NotesResult[i], 0, 9999);
			}
		}
		else
		{
			_NGJDHLGMHMH_IsInvalid = true;
		}
	}
}
