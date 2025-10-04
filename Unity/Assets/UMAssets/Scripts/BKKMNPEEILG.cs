
using UnityEngine;
using XeApp.Game.Common;

public class BKKMNPEEILG
{
	public static bool GJMOEKIEKEI; // 0x0
	public FFHPBEPOMAK_DivaInfo FDBOPFEOENF_diva; // 0x8
	public GCIJNCFDNON_SceneInfo AFBMEMCHJCL_MainScene; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public int EOPEEENMHEN_Crypted; // 0x14
	public int JKJDDGGNEAB_TotalCrypted; // 0x18
	public long BEBJKJKBOGH_date; // 0x20
	public int NBOLDNMPJFG_scoreCrypted; // 0x28
	public int EFPOCKLJDIE_Crypted; // 0x2C
	public int AKNELONELJK_difficulty; // 0x30
	public int[] PGPBALKFBNK_Notes; // 0x34
	public int NKLHOLHLEEI_ExcellentCount; // 0x38
	public int BHCIFFILAKJ_Strength; // 0x3C
	public int NLKEBAOBJCM_combo; // 0x40
	public int JEEEFDOGELK_ComboRank; // 0x44
	public int CPBFAMJEODF_c_skill; // 0x48
	public int MGHPJNNDCIG_l_skill; // 0x4C
	public bool JCOJKAHFADL_Is6Line; // 0x50
	public bool JIBFGLODGHN_EnableLiveSkip; // 0x51
	public int BBHFIIKMFJE_IdxCrypted; // 0x54

	public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ 0x7414887f; } set { EOPEEENMHEN_Crypted = value ^ 0x7414887f; } } //0xC8750C BNFNPCNAGAF_get_ScoreAverage 0xC87520 GEMDEGDPJPK_set_ScoreAverage
	public int BDLNMOIOMHK_total { get { return JKJDDGGNEAB_TotalCrypted ^ 0x693d0821; } set { JKJDDGGNEAB_TotalCrypted = value ^ 0x693d0821; } } //0xC87534 MKMAKAEDMBG_get_total 0xC87548 GIJPLHEDIKD_set_total
	public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ 0x731b1935; } set { NBOLDNMPJFG_scoreCrypted = value ^ 0x731b1935; } } //0xC8755C EOJEPLIPOMJ_get_score 0xC87570 AEEMBPAEAAI_set_score
	public int EACPIDGGPPO_ExcellentScore { get { return EFPOCKLJDIE_Crypted ^ 0x731b1935; } set { EFPOCKLJDIE_Crypted = value ^ 0x731b1935; } } //0xC87584 HBEKIAGHOCA_bgs 0xC87598 EOMBKKAIFEI_bgs
	public int OIPCCBHIKIA_index { get { return BBHFIIKMFJE_IdxCrypted ^ 0x5a35a835; } set { BBHFIIKMFJE_IdxCrypted = value ^ 0x5a35a835; } } //0xC875AC HFCGOHDOHAP_bgs 0xC875C0 FOGFPKNLADC_bgs

	//// RVA: 0xC875D4 Offset: 0xC875D4 VA: 0xC875D4
	public void KHEKNNFCAOI_Init(HAEDCCLHEMN_EventBattle _MOHDLLIJELH_cont, int ODHFJJCJHDD)
	{
		JIBFGLODGHN_EnableLiveSkip = false;
		OIPCCBHIKIA_index = ODHFJJCJHDD;
		if(_MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD] == null)
		{
			FDBOPFEOENF_diva = new FFHPBEPOMAK_DivaInfo();
			FDBOPFEOENF_diva.KHEKNNFCAOI_Init(1, 1, 0, 0, null, null, false);
			FDBOPFEOENF_diva.OPFGFINHFCE_name = JpStringLiterals.StringLiteral_9635;
			IPPNCOHEEOD_ScoreAverage = 12345;
			AKNELONELJK_difficulty = 0;
			BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			PGPBALKFBNK_Notes = new int[5];
		}
		else
		{
			if(_MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].GLILAGLJLEP_SceneId == 0)
			{
				AFBMEMCHJCL_MainScene = null;
			}
			else
			{
				AFBMEMCHJCL_MainScene = new GCIJNCFDNON_SceneInfo();
				AFBMEMCHJCL_MainScene.KHEKNNFCAOI_Init(_MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].GLILAGLJLEP_SceneId, null, null, _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].CFCIMKOHLIG_Mlt, 0, _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].ENNCJKLIGKE_Luck, false, 0, _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].PALEGNNHIKH_Leaf);
				AFBMEMCHJCL_MainScene.CIEOBFIIPLD_Level = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].ECOLMPLOPFM_SceneLevel;
			}
			FDBOPFEOENF_diva = new FFHPBEPOMAK_DivaInfo();
			FDBOPFEOENF_diva.KHEKNNFCAOI_Init(_MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].DIPKCALNIII_diva_id, _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].HEBKEJBDCBH_diva_lv, _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].BEEAIAAJOHD_CostumeId, _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].AFNIOJHODAG_CostumeColorId, AFBMEMCHJCL_MainScene, null, false);
			FDBOPFEOENF_diva.OPFGFINHFCE_name = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].OPFGFINHFCE_name;
			BEBJKJKBOGH_date = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].BEBJKJKBOGH_date;
			IPPNCOHEEOD_ScoreAverage = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].IPPNCOHEEOD_ScoreAverage;
			KNIFCANOHOC_score = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].KNIFCANOHOC_score;
			EACPIDGGPPO_ExcellentScore = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].OFJHABJNGOD_ExcellentScore;
			BHCIFFILAKJ_Strength = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].BHCIFFILAKJ_Strength;
			AKNELONELJK_difficulty = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].AKNELONELJK_difficulty;
			PGPBALKFBNK_Notes = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].MJNMPAKBNKB_NotesResult;
			NKLHOLHLEEI_ExcellentCount = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].NHLGACIHDAH_ExcellentCount;
			NLKEBAOBJCM_combo = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].NLKEBAOBJCM_combo;
			JEEEFDOGELK_ComboRank = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].LAMCCNAKIOJ_ComboRank;
			BDLNMOIOMHK_total = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].BDLNMOIOMHK_total;
			CPBFAMJEODF_c_skill = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].CPBFAMJEODF_c_skill;
			MGHPJNNDCIG_l_skill = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].MGHPJNNDCIG_l_skill;
			JCOJKAHFADL_Is6Line = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[ODHFJJCJHDD].MIKICCLPDJA_L6 == 1;
		}
	}

	//// RVA: 0xC87A78 Offset: 0xC87A78 VA: 0xC87A78
	public void GOCAPCKLAPI(HAEDCCLHEMN_EventBattle _MOHDLLIJELH_cont, int _GHBPLHBNMBK_FreeMusicId)
	{
        BMIODFJCGAJ_EventBattlePlayer ebp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
		int v = -1;
		for(int i = 0; i < ebp.AILDCKKOLJG_Results.Count; i++)
		{
			if(ebp.AILDCKKOLJG_Results[i].GOIKCKHMBDL_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				if(ebp.AILDCKKOLJG_Results[i].BEBJKJKBOGH_date > -1)
				{
					ebp.AILDCKKOLJG_Results[i].BEBJKJKBOGH_date = -1;
					v = i;
				}
			}
		}
		if(ebp.EGPMLMCCOLH < ebp.AILDCKKOLJG_Results.Count)
		{
			if(ebp.AILDCKKOLJG_Results[ebp.EGPMLMCCOLH].GOIKCKHMBDL_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				v = ebp.EGPMLMCCOLH;
			}
		}
		AMCGONHBGGF d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0];
		if(d.EBDNICPAFLB_s_slot[0] == 0)
		{
			AFBMEMCHJCL_MainScene = null;
		}
		else
		{
			AFBMEMCHJCL_MainScene = new GCIJNCFDNON_SceneInfo();
			MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[d.EBDNICPAFLB_s_slot[0] - 1];
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[d.EBDNICPAFLB_s_slot[0] - 1];
			AFBMEMCHJCL_MainScene.KHEKNNFCAOI_Init(d.EBDNICPAFLB_s_slot[0], null, null, saveScene.JPIPENJGGDD_NumBoard, 0, dbScene.AGOEDLNOHND(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, saveScene.EMOJHJGHJLN_Sb, saveScene.JPIPENJGGDD_NumBoard, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed)), false, 0, saveScene.DMNIMMGGJJJ_Leaf);
			AFBMEMCHJCL_MainScene.CIEOBFIIPLD_Level = saveScene.ANAJIAENLNB_lv;
		}
		FDBOPFEOENF_diva = new FFHPBEPOMAK_DivaInfo();
		FDBOPFEOENF_diva.KHEKNNFCAOI_Init(d.DIPKCALNIII_diva_id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(d.DIPKCALNIII_diva_id).HEBKEJBDCBH_diva_lv, d.BEEAIAAJOHD_CostumeId, d.AFNIOJHODAG_CostumeColorId, AFBMEMCHJCL_MainScene, null, false);
		OPFGFINHFCE_name = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
		if(v < 0)
		{
			Debug.LogError("not found result data");
			AKNELONELJK_difficulty = 0;
			IPPNCOHEEOD_ScoreAverage = 0;
			PGPBALKFBNK_Notes = new int[5];
			JCOJKAHFADL_Is6Line = false;
			JIBFGLODGHN_EnableLiveSkip = false;
		}
		else
		{
			IPPNCOHEEOD_ScoreAverage = ebp.AILDCKKOLJG_Results[v].IPPNCOHEEOD_ScoreAverage;
			AKNELONELJK_difficulty = ebp.AILDCKKOLJG_Results[v].AKNELONELJK_difficulty;
			KNIFCANOHOC_score = ebp.AILDCKKOLJG_Results[v].KNIFCANOHOC_score;
			EACPIDGGPPO_ExcellentScore = ebp.AILDCKKOLJG_Results[v].OFJHABJNGOD_ExcellentScore;
			PGPBALKFBNK_Notes = ebp.AILDCKKOLJG_Results[v].MJNMPAKBNKB_NotesResult;
			NLKEBAOBJCM_combo = ebp.AILDCKKOLJG_Results[v].NLKEBAOBJCM_combo;
			JEEEFDOGELK_ComboRank = ebp.AILDCKKOLJG_Results[v].LAMCCNAKIOJ_ComboRank;
			BDLNMOIOMHK_total = ebp.AILDCKKOLJG_Results[v].BDLNMOIOMHK_total;
			NKLHOLHLEEI_ExcellentCount = ebp.AILDCKKOLJG_Results[v].NHLGACIHDAH_ExcellentCount;
			JCOJKAHFADL_Is6Line = ebp.AILDCKKOLJG_Results[v].MIKICCLPDJA_L6 == 1;
			JIBFGLODGHN_EnableLiveSkip = Database.Instance.gameSetup.EnableLiveSkip;
		}
    }

	//// RVA: 0xC8883C Offset: 0xC8883C VA: 0xC8883C
	public bool GAOGOMKKJON()
	{
		return BHCIFFILAKJ_Strength > 2;
	}

	//// RVA: 0xC88850 Offset: 0xC88850 VA: 0xC88850
	public void HNLMOCGGIGH()
	{
        AMCGONHBGGF diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0];
		if(diva.EBDNICPAFLB_s_slot[0] == 0)
		{
			AFBMEMCHJCL_MainScene = null;
		}
		else
		{
			AFBMEMCHJCL_MainScene = new GCIJNCFDNON_SceneInfo();
			AFBMEMCHJCL_MainScene.KHEKNNFCAOI_Init(diva.EBDNICPAFLB_s_slot[0], null, null, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[diva.EBDNICPAFLB_s_slot[0] - 1].JPIPENJGGDD_NumBoard, 0, 0, false, 0, 0);
			AFBMEMCHJCL_MainScene.CIEOBFIIPLD_Level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[diva.EBDNICPAFLB_s_slot[0] - 1].ANAJIAENLNB_lv;
		}
		FDBOPFEOENF_diva = new FFHPBEPOMAK_DivaInfo();
		FDBOPFEOENF_diva.KHEKNNFCAOI_Init(diva.DIPKCALNIII_diva_id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(diva.DIPKCALNIII_diva_id).HEBKEJBDCBH_diva_lv, diva.BEEAIAAJOHD_CostumeId, diva.AFNIOJHODAG_CostumeColorId, AFBMEMCHJCL_MainScene, null, false);
		OPFGFINHFCE_name = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
		BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		KNIFCANOHOC_score = 123;
		EACPIDGGPPO_ExcellentScore = 12;
		BDLNMOIOMHK_total = 1234;
		IPPNCOHEEOD_ScoreAverage = 123;
		AKNELONELJK_difficulty = 0;
		PGPBALKFBNK_Notes = new int[5] { 1, 2, 3, 4, 5 };
		NKLHOLHLEEI_ExcellentCount = 1;
		JCOJKAHFADL_Is6Line = false;
		JIBFGLODGHN_EnableLiveSkip = false;
    }

	//// RVA: 0xC88F6C Offset: 0xC88F6C VA: 0xC88F6C
	public void BPHKMLGBBAF()
	{
		FDBOPFEOENF_diva = new FFHPBEPOMAK_DivaInfo();
		FDBOPFEOENF_diva.KHEKNNFCAOI_Init(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 20), 0, 0, null, null, false);
		KNIFCANOHOC_score = 123;
		EACPIDGGPPO_ExcellentScore = 12;
		BDLNMOIOMHK_total = 1234;
		IPPNCOHEEOD_ScoreAverage = UnityEngine.Random.Range(1000,100000);
		AKNELONELJK_difficulty = 0;
		PGPBALKFBNK_Notes = new int[5] { 1, 2, 3, 4, 5 };
		NKLHOLHLEEI_ExcellentCount = 1;
		JCOJKAHFADL_Is6Line = false;
		JIBFGLODGHN_EnableLiveSkip = false;
	}
}
