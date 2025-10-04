
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeApp.Game.Common;
using XeSys;

public class OLLEELKFCMM
{
	public enum NDBAPDFEPAF
	{
		HJNNKCMLGFL_0_None = 0,
		OJEGJNOCCEA_1 = 1,
		HNICJFPHCNE_2 = 2,
		CFEBHEEDKFP_3 = 3,
		EBCGBOLPFPE_4 = 4,
	}
}

public class OKMHOFEJPCF
{
	public enum CBOHLHCMGJJ_Steps
	{
		HJNNKCMLGFL_0_None = 0,
		LAOEGNLOJHC_1_Start = 1,
		MAHAPADGBOE = 2,
		GECIHFBADBM = 3,
		CNLOFIHPBMP_4 = 4,
		OLDDILMKJND_5 = 5,
		BFIOFNKPOFB_6 = 6,
		OLCLJKOKJCD_7_End = 7,
	}
}


[System.Obsolete("Use HAEDCCLHEMN_EventBattle", true)]
public class HAEDCCLHEMN { }
public class HAEDCCLHEMN_EventBattle : IKDICBBFBMI_EventBase
{
	public enum LHJDMDJHEEN
	{
		ODGBNGCGKBA = 0,
		LJMCLGJMMNJ = 1,
		JPAPNHAGJKM = 2,
		PEEGCBKNGKN = 3,
		GEJGMBBCFEE_4__max = 4
	}

	public class DJJHCPAKJKJ
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public string MLMKGEJCHMF = ""; // 0xC
		public string OPFGFINHFCE_name; // 0x10
		public int[] MJNMPAKBNKB_NotesResult = new int[5]; // 0x14
		public int DCLLGOECHPA_PidCrypted; // 0x18
		public int BJHHOBEMBJG_CostumeIdCrypted; // 0x1C
		public int LEHJBFPLJPL_CostumeColorIdCrypted; // 0x20
		public int CPCKPCJBDEL_Crypted; // 0x24
		public int DMPDIMGFEBL_Crypted; // 0x28
		public int AOFGNAJLLPD_DivaIdCrypted; // 0x2C
		public int ENEKCBCOKNM_Crypted; // 0x30
		public int HNJHPNPFAAN_EnabledCrypted; // 0x34
		public int CJAOMKLHFJL_Crypted; // 0x38
		public int EHOIENNDEDH_IdCrypted; // 0x3C
		public int KPLDLGGMOMH_Crypted; // 0x40
		public int HIJDFKKMONB_Crypted; // 0x44
		public int MHGDDPCAGAJ_Crypted; // 0x48
		public int GIELAFNPOCG_Crypted; // 0x4C
		public int GHJIBEMCKLA_Crypted; // 0x50
		public int NBOLDNMPJFG_scoreCrypted; // 0x54
		public int BNPKALPLIJH_Crypted; // 0x58
		public long KLAPHOKNEDG_DateCrypted; // 0x60
		public int EOPEEENMHEN_Crypted; // 0x68
		public int EBFFJNGICMJ_Crypted; // 0x6C
		public int BCKCCHGMPBG_Crypted; // 0x70
		public int JKJDDGGNEAB_TotalCrypted; // 0x74
		public int ADOIPHGJHBC_ExcellentCountCrypted; // 0x78
		public int LPNGJDDEJJD_Crypted; // 0x7C
		public int GFPNAILCPLG_Crypted; // 0x80
		public int NBCKDDOCBJE; // 0x84
		public int CHDLCOGBCNK_CSkillCrypted; // 0x88
		public int KNALPNKGKHD_LSkillCrypted; // 0x8C
		public int LAMCCNAKIOJ_ComboRank; // 0x90
		public int NHKHNABCGKL; // 0x94

		public int EHGBICNIBKE_player_id { get { return DCLLGOECHPA_PidCrypted ^ FBGGEFFJJHB_xor; } set { DCLLGOECHPA_PidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B76FFC OMMOMEDOFNO_bgs 0x1B8D354 GKBOGMILGJE_bgs
		public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { BJHHOBEMBJG_CostumeIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF4C DIIBIOEMHAI_get_CostumeId 0x1B8D364 JIHEDMEFKAF_set_CostumeId
		public int AFNIOJHODAG_CostumeColorId { get { return LEHJBFPLJPL_CostumeColorIdCrypted ^ FBGGEFFJJHB_xor; } set { LEHJBFPLJPL_CostumeColorIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF5C OCABHAPHAMH_bgs 0x1B8D374 DIAIECJEGDG_bgs
		public int AKNELONELJK_difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB_xor; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF1C BPPILHGDABB_get_difficulty 0x1B8D384 PMMIIHKEGCI_set_difficulty
		public int MIKICCLPDJA_L6 { get { return DMPDIMGFEBL_Crypted ^ FBGGEFFJJHB_xor; } set { DMPDIMGFEBL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF2C CCFIANIJCJI_bgs 0x1B8D394 BFDODBCKDMK_bgs
		public int DIPKCALNIII_diva_id { get { return AOFGNAJLLPD_DivaIdCrypted ^ FBGGEFFJJHB_xor; } set { AOFGNAJLLPD_DivaIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF3C EOGPBFIDAPF_get_diva_id 0x1B8D3A4 JDNCGPBAFMB_set_diva_id
		public int HEBKEJBDCBH_diva_lv { get { return ENEKCBCOKNM_Crypted ^ FBGGEFFJJHB_xor; } set { ENEKCBCOKNM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF6C OMOHEDILHMF_get_diva_lv 0x1B8D3B4 FCGDHINFKHC_set_diva_lv
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8D3C4 JPCJNLHHIPE_get_en 0x1B8D3D4 JJFJNEJLBDG_set_en
		public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB_xor; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7704C BPGCGEDHBEH_get_FreeMusicId 0x1B8D3E4 ICPMFBIDFFO_set_FreeMusicId
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8D3F4 DEMEPMAEJOO_get_id 0x1B8D404 HIGKAIDMOKN_set_id
		public int EDJMDDAGCEJ_Score1 { get { return KPLDLGGMOMH_Crypted ^ FBGGEFFJJHB_xor; } set { KPLDLGGMOMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7702C BCMKDNCFOJO_get_Score1 0x1B8D414 DDIAEKOKDIE_set_Score1
		public int HEFPAIOLBAG_Score2 { get { return HIJDFKKMONB_Crypted ^ FBGGEFFJJHB_xor; } set { HIJDFKKMONB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7703C EAGPNJEBOCP_get_Score2 0x1B8D424 LLIGHINHLOL_set_Score2
		public int GLILAGLJLEP_SceneId { get { return MHGDDPCAGAJ_Crypted ^ FBGGEFFJJHB_xor; } set { MHGDDPCAGAJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF7C HGPGPALMELF_get_SceneId 0x1B8D434 ECHLNFNJFFO_set_SceneId
		public int ECOLMPLOPFM_SceneLevel { get { return GIELAFNPOCG_Crypted ^ FBGGEFFJJHB_xor; } set { GIELAFNPOCG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF8C BFLCGLBAFOE_get_SceneLevel 0x1B8D444 NJGKCLHFDIB_set_SceneLevel
		public int CFCIMKOHLIG_Mlt { get { return GHJIBEMCKLA_Crypted ^ FBGGEFFJJHB_xor; } set { GHJIBEMCKLA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FF9C AJNACFGNOAA_get_Mlt 0x1B8D454 LCGAFCPHDKA_set_Mlt
		public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7701C EOJEPLIPOMJ_get_score 0x1B8D464 AEEMBPAEAAI_set_score
		public int OFJHABJNGOD_ExcellentScore { get { return BNPKALPLIJH_Crypted ^ FBGGEFFJJHB_xor; } set { BNPKALPLIJH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FFAC NDBFELIIICL_bgs 0x1B8D474 BIJLJDDDMLL_bgs
		public long BEBJKJKBOGH_date { get { return KLAPHOKNEDG_DateCrypted ^ FBGGEFFJJHB_xor; } set { KLAPHOKNEDG_DateCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FFBC DIAPHCJBPFD_get_date 0x1B8D484 IHAIKPNEEJE_set_date
		public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ FBGGEFFJJHB_xor; } set { EOPEEENMHEN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7700C BNFNPCNAGAF_get_ScoreAverage 0x1B8D498 GEMDEGDPJPK_set_ScoreAverage
		public int BHCIFFILAKJ_Strength { get { return EBFFJNGICMJ_Crypted ^ FBGGEFFJJHB_xor; } set { EBFFJNGICMJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7705C GJLJFNOPADH_bgs 0x1B7F5F8 FENGBICDFPD_bgs
		public int NLKEBAOBJCM_combo { get { return BCKCCHGMPBG_Crypted ^ FBGGEFFJJHB_xor; } set { BCKCCHGMPBG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FFD4 AECNKGBNKHH_get_combo 0x1B8D4A8 ECHLKFHOJFP_set_combo
		public int BDLNMOIOMHK_total { get { return JKJDDGGNEAB_TotalCrypted ^ FBGGEFFJJHB_xor; } set { JKJDDGGNEAB_TotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FFE4 MKMAKAEDMBG_get_total 0x1B8D4B8 GIJPLHEDIKD_set_total
		public int NHLGACIHDAH_ExcellentCount { get { return ADOIPHGJHBC_ExcellentCountCrypted ^ FBGGEFFJJHB_xor; } set { ADOIPHGJHBC_ExcellentCountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B7FFF4 MDCFGFPHGKO_bgs 0x1B8D4C8 KJOPHNJJCOB_bgs
		public int ENNCJKLIGKE_Luck { get { return LPNGJDDEJJD_Crypted ^ FBGGEFFJJHB_xor; } set { LPNGJDDEJJD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B80004 CIGNNFNAAAN_get_Luck 0x1B8D4D8 DOLNOHODMEI_set_Luck
		public int PALEGNNHIKH_Leaf { get { return GFPNAILCPLG_Crypted ^ FBGGEFFJJHB_xor; } set { GFPNAILCPLG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1B80014 MALPONGOPKO_get_Leaf 0x1B8D4E8 BHAFNMAEHOH_set_Leaf
		public int CPBFAMJEODF_c_skill { get { return CHDLCOGBCNK_CSkillCrypted ^ FBGGEFFJJHB_xor; } set { CHDLCOGBCNK_CSkillCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8D4F8 GEPFGJBNHNL_get_c_skill 0x1B8D508 MHBECPNIHLA_set_c_skill
		public int MGHPJNNDCIG_l_skill { get { return KNALPNKGKHD_LSkillCrypted ^ FBGGEFFJJHB_xor; } set { KNALPNKGKHD_LSkillCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8D518 GFADFBMKBMD_get_l_skill 0x1B8D528 JECIKFDJMOB_set_l_skill

		// // RVA: 0x1B78F94 Offset: 0x1B78F94 VA: 0x1B78F94
		public void KHEKNNFCAOI_Init(int _BHCIFFILAKJ_Strength, ICFLJACCIKF_EventBattle.FKACPHEKBNF _IDLHJIOMJBK_data)
		{
			FBGGEFFJJHB_xor = (int)Utility.GetCurrentUnixTime() ^ 0x367;
			BEEAIAAJOHD_CostumeId = _IDLHJIOMJBK_data.BEEAIAAJOHD_CostumeId;
			AFNIOJHODAG_CostumeColorId = 0;
			AKNELONELJK_difficulty = _IDLHJIOMJBK_data.AKNELONELJK_difficulty;
			MIKICCLPDJA_L6 = 0;
			DIPKCALNIII_diva_id = _IDLHJIOMJBK_data.DIPKCALNIII_diva_id;
			HEBKEJBDCBH_diva_lv = _IDLHJIOMJBK_data.HEBKEJBDCBH_diva_lv;
			GOIKCKHMBDL_FreeMusicId = _IDLHJIOMJBK_data.GOIKCKHMBDL_FreeMusicId;
			EDJMDDAGCEJ_Score1 = _IDLHJIOMJBK_data.EDJMDDAGCEJ_Score1;
			HEFPAIOLBAG_Score2 = _IDLHJIOMJBK_data.HEFPAIOLBAG_Score2;
			GLILAGLJLEP_SceneId = _IDLHJIOMJBK_data.GLILAGLJLEP_SceneId;
			ECOLMPLOPFM_SceneLevel = _IDLHJIOMJBK_data.ECOLMPLOPFM_SceneLevel;
			CFCIMKOHLIG_Mlt = _IDLHJIOMJBK_data.CFCIMKOHLIG_Mlt;
			PALEGNNHIKH_Leaf = _IDLHJIOMJBK_data.PALEGNNHIKH_Leaf;
			ENNCJKLIGKE_Luck = _IDLHJIOMJBK_data.ENNCJKLIGKE_Luck;
			if(GLILAGLJLEP_SceneId != 0)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[GLILAGLJLEP_SceneId - 1];
				if(scene.PPEGAKEIEGM_Enabled == 2)
				{
					int v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(scene.EKLIPGELKCL_Rarity, CFCIMKOHLIG_Mlt > 0, scene.MCCIFLKCNKO_Feed);
					if(v < ECOLMPLOPFM_SceneLevel)
						ECOLMPLOPFM_SceneLevel = v;
				}
				else
				{
					GLILAGLJLEP_SceneId = 0;
					ECOLMPLOPFM_SceneLevel = 0;
					CFCIMKOHLIG_Mlt = 0;
					ENNCJKLIGKE_Luck = 0;
					PALEGNNHIKH_Leaf = 0;
				}
			}
			if(_BHCIFFILAKJ_Strength < 3)
			{
				CPBFAMJEODF_c_skill = 0;
				MGHPJNNDCIG_l_skill = 0;
			}
			else
			{
				DCAKKIJODME s = new DCAKKIJODME();
				s.KHEKNNFCAOI_Init(false);
                EMGOCNMMPHC em = s.KLMPGMPHNOP(s.AJBHLNMPIPD_GetIdxByMusicId(GOIKCKHMBDL_FreeMusicId));
                CPBFAMJEODF_c_skill = em.EKHAFFFELCO_CSkill;
                MGHPJNNDCIG_l_skill = em.EDHAJJHIKHE_LSkill;
			}
			LAMCCNAKIOJ_ComboRank = 0;
			OPFGFINHFCE_name = _IDLHJIOMJBK_data.OPFGFINHFCE_name;
			BHCIFFILAKJ_Strength = _BHCIFFILAKJ_Strength;
			LAMCCNAKIOJ_ComboRank = 0;
			NLKEBAOBJCM_combo = 0;
			BDLNMOIOMHK_total = 0;
			NHLGACIHDAH_ExcellentCount = 0;
			OFJHABJNGOD_ExcellentScore = 0;
			EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GOIKCKHMBDL_FreeMusicId).DLAEJOBELBH_MusicId);
			KLBKPANJCPL_Score k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m.KKPAHLMJKIH_WavId, m.BKJGCEOEPFB_VariationId, _IDLHJIOMJBK_data.AKNELONELJK_difficulty, false, true);
			if(k != null)
			{
				int v = k.NLKEBAOBJCM_combo - _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[0] - _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[1] - _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[2];
				int v1 = _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[3] * v / 100;
				int v2 = v - v1;
				object[] s = new object[11]
				{
					"<color=yellow>{",
					_IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[0],
					",",
					_IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[1],
					",",
					_IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[2],
					",",
					v1,
					",",
					v2,
					"}</color>"
				};
				Debug.Log(string.Concat(s));
				if(_IDLHJIOMJBK_data.KNIFCANOHOC_score == 0)
				{
					MJNMPAKBNKB_NotesResult[0] = k.NLKEBAOBJCM_combo;
					MJNMPAKBNKB_NotesResult[1] = 0;
					MJNMPAKBNKB_NotesResult[2] = 0;
					MJNMPAKBNKB_NotesResult[3] = 0;
					MJNMPAKBNKB_NotesResult[4] = 0;
				}
				else
				{
					MJNMPAKBNKB_NotesResult[0] = _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[0];
					MJNMPAKBNKB_NotesResult[1] = _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[1];
					MJNMPAKBNKB_NotesResult[2] = _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[2];
					MJNMPAKBNKB_NotesResult[3] = v1;
					MJNMPAKBNKB_NotesResult[4] = v2;
					NLKEBAOBJCM_combo = _IDLHJIOMJBK_data.NLKEBAOBJCM_combo * k.NLKEBAOBJCM_combo / 100;
					if(k.NLKEBAOBJCM_combo == v)
					{
						if(NLKEBAOBJCM_combo != k.NLKEBAOBJCM_combo)
						{
							object[] s2 = new object[7]
							{
								"<color=yellow>warn : combo:",
								NLKEBAOBJCM_combo,
								"(",
								_IDLHJIOMJBK_data.NLKEBAOBJCM_combo,
								"%) != total:",
								k.NLKEBAOBJCM_combo,
								"</color>"
							};
							Debug.Log(string.Concat(s2));
							NLKEBAOBJCM_combo = k.NLKEBAOBJCM_combo;
						}
						//LAB_01b7a5f4
						LAMCCNAKIOJ_ComboRank = v2 == k.NLKEBAOBJCM_combo ? 2 : 1;
					}
					else 
					{
						if(v < NLKEBAOBJCM_combo)
						{
							object[] s2 = new object[5]
							{
								"<color=yellow>warn : combo:",
								NLKEBAOBJCM_combo,
								" > total:",
								v,
								"</color>"
							};
							Debug.Log(string.Concat(s2));
							NLKEBAOBJCM_combo = v;
						}
						if(k.NLKEBAOBJCM_combo == v2 || k.NLKEBAOBJCM_combo == v)
						{
							//LAB_01b7a5f4
							LAMCCNAKIOJ_ComboRank = v2 == k.NLKEBAOBJCM_combo ? 2 : 1;
						}
					}
					int v3 = _IDLHJIOMJBK_data.JCDEDIOAGKE_ExcellentRatio * v2;
					NHLGACIHDAH_ExcellentCount = v3 / 100;
					if(v3 > 99)
					{
						int v4 = NHLGACIHDAH_ExcellentCount * _IDLHJIOMJBK_data.KNIFCANOHOC_score / v2;
						int v5 = v4 * 100 / (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.LPJLEHAJADA_GetIntParam("ex_effect", 0) + 100);
						OFJHABJNGOD_ExcellentScore = v4 - v5 > 0 ? v4 - v5 : 0;
					}
				}
			}
			//LAB_01b7a71c
			BDLNMOIOMHK_total = _IDLHJIOMJBK_data.BDLNMOIOMHK_total;
			KNIFCANOHOC_score = _IDLHJIOMJBK_data.KNIFCANOHOC_score;
			IPPNCOHEEOD_ScoreAverage = _IDLHJIOMJBK_data.IPPNCOHEEOD_ScoreAverage;
			EHGBICNIBKE_player_id = 0;
			BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}

		// // RVA: 0x1B7CD50 Offset: 0x1B7CD50 VA: 0x1B7CD50
		public void KHEKNNFCAOI_Init(int _BHCIFFILAKJ_Strength, BLHNHKMMPAD _IDLHJIOMJBK_data, int _IPPNCOHEEOD_ScoreAverage, string _OPFGFINHFCE_name, int _EHGBICNIBKE_player_id)
		{
			FBGGEFFJJHB_xor = (int)Utility.GetCurrentUnixTime() ^ 0x367;
			BEEAIAAJOHD_CostumeId = _IDLHJIOMJBK_data.BEEAIAAJOHD_CostumeId;
			AFNIOJHODAG_CostumeColorId = _IDLHJIOMJBK_data.AFNIOJHODAG_CostumeColorId;
			AKNELONELJK_difficulty = _IDLHJIOMJBK_data.AKNELONELJK_difficulty;
			MIKICCLPDJA_L6 = _IDLHJIOMJBK_data.MIKICCLPDJA_L6;
			DIPKCALNIII_diva_id = _IDLHJIOMJBK_data.DIPKCALNIII_diva_id;
			HEBKEJBDCBH_diva_lv = _IDLHJIOMJBK_data.HEBKEJBDCBH_diva_lv;
			GOIKCKHMBDL_FreeMusicId = _IDLHJIOMJBK_data.GOIKCKHMBDL_FreeMusicId;
			EDJMDDAGCEJ_Score1 = _IDLHJIOMJBK_data.EDJMDDAGCEJ_Score1;
			HEFPAIOLBAG_Score2 = _IDLHJIOMJBK_data.HEFPAIOLBAG_Score2;
			GLILAGLJLEP_SceneId = _IDLHJIOMJBK_data.GLILAGLJLEP_SceneId;
			ECOLMPLOPFM_SceneLevel = _IDLHJIOMJBK_data.ECOLMPLOPFM_SceneLevel;
			OPFGFINHFCE_name = _OPFGFINHFCE_name;
			CFCIMKOHLIG_Mlt = _IDLHJIOMJBK_data.CFCIMKOHLIG_Mlt;
			for(int i = 0; i < MJNMPAKBNKB_NotesResult.Length; i++)
			{
				MJNMPAKBNKB_NotesResult[i] = _IDLHJIOMJBK_data.MJNMPAKBNKB_NotesResult[i];
			}
			BDLNMOIOMHK_total = _IDLHJIOMJBK_data.BDLNMOIOMHK_total;
			NLKEBAOBJCM_combo = _IDLHJIOMJBK_data.NLKEBAOBJCM_combo;
			KNIFCANOHOC_score = _IDLHJIOMJBK_data.KNIFCANOHOC_score;
			LAMCCNAKIOJ_ComboRank = _IDLHJIOMJBK_data.LAMCCNAKIOJ_ComboRank;
			NHLGACIHDAH_ExcellentCount = _IDLHJIOMJBK_data.NHLGACIHDAH_ExcellentCount;
			OFJHABJNGOD_ExcellentScore = _IDLHJIOMJBK_data.OFJHABJNGOD_ExcellentScore;
			IPPNCOHEEOD_ScoreAverage = _IPPNCOHEEOD_ScoreAverage;
			ENNCJKLIGKE_Luck = _IDLHJIOMJBK_data.ENNCJKLIGKE_Luck;
			PALEGNNHIKH_Leaf = _IDLHJIOMJBK_data.PALEGNNHIKH_Leaf;
			CPBFAMJEODF_c_skill = 0;
			MGHPJNNDCIG_l_skill = 0;
			if(_BHCIFFILAKJ_Strength > 2)
			{
				DCAKKIJODME data = new DCAKKIJODME();
				data.KHEKNNFCAOI_Init(false);
				int v = data.AJBHLNMPIPD_GetIdxByMusicId(GOIKCKHMBDL_FreeMusicId);
				if(v > -1)
				{
					CPBFAMJEODF_c_skill = data.KLMPGMPHNOP(v).EKHAFFFELCO_CSkill;
					MGHPJNNDCIG_l_skill = data.KLMPGMPHNOP(v).EDHAJJHIKHE_LSkill;
				}
			}
			BHCIFFILAKJ_Strength = _BHCIFFILAKJ_Strength;
			EHGBICNIBKE_player_id = _EHGBICNIBKE_player_id;
			BEBJKJKBOGH_date = _IDLHJIOMJBK_data.BEBJKJKBOGH_date;
		}
	}

	public class LCNKFJFICKF
	{
		public int KEHKLOBPEPP_Crypted; // 0x8
		public int ABCKCDLNFNH_Crypted; // 0xC
		public int HKIPKLKCPLO_LastScoreExcellentCrypted; // 0x10
		public int NKBMMDMHKGL_Crypted; // 0x14
		public int OEAPGMPKNFD_Crypted; // 0x18
		public int BFKHCOJGKPJ_Crypted; // 0x1C
		public int KIAOMNBOKJJ_Crypted; // 0x20
		public int ODOPBNCPGAC_Crypted; // 0x24
		public int AICBGODNGHD_Crypted; // 0x28
		public int PBOHMOCPLBG_Crypted; // 0x2C
		public int ICLLEMPGMKL_Crypted; // 0x30
		public int AMJKFJBHOPG_Crypted; // 0x34
		public int AALCBLHNHPN_ScoreResultRankCrypted; // 0x38
		public int KIHLOJGPFII_Crypted; // 0x3C
		public int PAOPCJAOJHF_Crypted; // 0x40
		public int HDDEIDFNPAN_Crypted; // 0x44
		public int GMLHLNKOJMA_Crypted; // 0x48
		public bool INPNFCNLAMA_IsLine6; // 0x4C
		public int GONNMDLFPCG_Crypted; // 0x50
		public int IAJNKIBKJMM_Crypted; // 0x54
		public int KCCPNHPGKMF_Crypted; // 0x58
		public bool EGAMOPBCFKG_ExRival; // 0x5C
		public int JDFLCJMGPHH_Crypted; // 0x60
		public int FBGENHHKLNK_Crypted; // 0x64
		public int EJBJAEHLCHM_Crypted; // 0x68
		public bool DPCFADCFMOA_Win; // 0x6C
		public int KKAJAKPEEMK_Crypted; // 0x70
		public int AGFLDOFHFFP_Crypted; // 0x74
		public int GEOGJLLKONC_Crypted; // 0x78
		public int DHPFMDOOMOH_Crypted; // 0x7C
		public int[] HDIEPNLNABL_ExBattleScoreBefore = new int[3]; // 0x80
		public int[] OEGDACKEDIB_ExBattleScoreAfter = new int[3]; // 0x84
		public int EDJJIBAGFHL_UnlockedClassBefore; // 0x88
		public int GBIGCJIKKPP_UnlockedClassAfter; // 0x8C
		public bool FFHMPNGJCLK_NewRecord; // 0x90
		private int ENOBDCFHELD = 0x8feecf; // 0x94

		public int FPEOGFMKMKJ_Point { get { return KEHKLOBPEPP_Crypted ^ ENOBDCFHELD; } set { KEHKLOBPEPP_Crypted = value ^ ENOBDCFHELD; } } //0x173C3C8 KEAFAPEKPIJ_bgs 0x173C484 MAFPGHEAHAO_bgs
		public int GCAPLLEIAAI_LastScore { get { return ABCKCDLNFNH_Crypted ^ ENOBDCFHELD; } set { ABCKCDLNFNH_Crypted = value ^ ENOBDCFHELD; } } //0x173C70C BKGFGIGDJHB_bgs 0x173C494 DELDFNOMADE_bgs
		public int GPMILOPNBPA_LastScoreExcellent { get { return HKIPKLKCPLO_LastScoreExcellentCrypted ^ ENOBDCFHELD; } set { HKIPKLKCPLO_LastScoreExcellentCrypted = value ^ ENOBDCFHELD; } } //0x173C71C AFMDAPPNMBO_bgs 0x173C4A4 AIEBJIPABLO_bgs
		public int GBLHPHCAPLG_ScoreBonus { get { return NKBMMDMHKGL_Crypted ^ ENOBDCFHELD; } set { NKBMMDMHKGL_Crypted = value ^ ENOBDCFHELD; } } //0x173C72C ILLLOMLHELP_bgs 0x173C4B4 GKIBOMGBNIA_bgs
		public int MACJOPBCEEL { get { return OEAPGMPKNFD_Crypted ^ ENOBDCFHELD; } set { OEAPGMPKNFD_Crypted = value ^ ENOBDCFHELD; } } //0x173C3D8 OCFKEBHGMEG_bgs 0x173C4C4 KCBEKDBDFNI_bgs
		public int BLAJKMAPEKP_CWin { get { return BFKHCOJGKPJ_Crypted ^ ENOBDCFHELD; } set { BFKHCOJGKPJ_Crypted = value ^ ENOBDCFHELD; } } //0x173C73C DCADGLDLIBL_bgs 0x173C4D4 NEMFNAPCJDG_bgs
		public int BOKPPBLPKEF { get { return KIAOMNBOKJJ_Crypted ^ ENOBDCFHELD; } set { KIAOMNBOKJJ_Crypted = value ^ ENOBDCFHELD; } } //0x173C3E8 IHFJAELPEBL_bgs 0x173C4E4 GGHBMDLPKED_bgs
		public int PGNECHOCIAN_CWinMax { get { return ODOPBNCPGAC_Crypted ^ ENOBDCFHELD; } set { ODOPBNCPGAC_Crypted = value ^ ENOBDCFHELD; } } //0x173C74C PIFKCBPGKCN_bgs 0x173C4F4 FPCANJHOJIA_bgs
		public int PKNBEDPHODG_Twin { get { return AICBGODNGHD_Crypted ^ ENOBDCFHELD; } set { AICBGODNGHD_Crypted = value ^ ENOBDCFHELD; } } //0x173C75C PDCPOCNKIME_bgs 0x173C504 BKGMNGFGBGG_bgs
		public int ANOCILKJGOJ_EpisodeCnt { get { return PBOHMOCPLBG_Crypted ^ ENOBDCFHELD; } set { PBOHMOCPLBG_Crypted = value ^ ENOBDCFHELD; } } //0x173C76C FDCOKHBMMOH_bgs 0x173C514 KCHINFILMEL_bgs
		public int ODCLHPGHDHA_EpisodeBonus { get { return ICLLEMPGMKL_Crypted ^ ENOBDCFHELD; } set { ICLLEMPGMKL_Crypted = value ^ ENOBDCFHELD; } } //0x173C3F8 MPEGELCJCPK_bgs 0x173C524 BJLLCJAMGBJ_bgs
		public int PIIEGNPOPJI_GetPoint { get { return AMJKFJBHOPG_Crypted ^ ENOBDCFHELD; } set { AMJKFJBHOPG_Crypted = value ^ ENOBDCFHELD; } } //0x173C408 CLBOPFHGOJJ_bgs 0x173C534 LHGDMPPHENK_bgs
		public int JIMGIIBCABI_ScoreResultRank { get { return AALCBLHNHPN_ScoreResultRankCrypted ^ ENOBDCFHELD; } set { AALCBLHNHPN_ScoreResultRankCrypted = value ^ ENOBDCFHELD; } } //0x173C77C FKEENNGDKEE_bgs 0x173C544 BGLCBKCJOIP_bgs
		public int FCLGIPFPIPH_DashBonus { get { return KIHLOJGPFII_Crypted ^ ENOBDCFHELD; } set { KIHLOJGPFII_Crypted = value ^ ENOBDCFHELD; } } //0x173C78C GHFOOLBCDBM_bgs 0x173C554 EFACKLMPIOD_bgs
		public int EIMCIBOANHE_CurrentClass { get { return PAOPCJAOJHF_Crypted ^ ENOBDCFHELD; } set { PAOPCJAOJHF_Crypted = value ^ ENOBDCFHELD; } } //0x173C79C BOOLAMLCMBL_bgs 0x173C564 FOMEIMMFONE_bgs
		public int KOOMDFGADKH_ExBattleWinBonus { get { return HDDEIDFNPAN_Crypted ^ ENOBDCFHELD; } set { HDDEIDFNPAN_Crypted = value ^ ENOBDCFHELD; } } //0x173C7AC GLBAJMEFCHO_bgs 0x173C574 PMPDDKEIIDM_bgs
		public int LBLOIOMNEIH_Difficulty { get { return GMLHLNKOJMA_Crypted ^ ENOBDCFHELD; } set { GMLHLNKOJMA_Crypted = value ^ ENOBDCFHELD; } } //0x173C7BC BDHAEDEOEKI_bgs 0x173C584 FBMAJDABGEK_bgs
		public int APEFEONDBKL_DiffBonus { get { return GONNMDLFPCG_Crypted ^ ENOBDCFHELD; } set { GONNMDLFPCG_Crypted = value ^ ENOBDCFHELD; } } //0x173C7CC PJIMPNDIPOB_bgs 0x173C594 PEAADOHOJBO_bgs
		public int ONLIMGFHGBH_ExPt { get { return IAJNKIBKJMM_Crypted ^ ENOBDCFHELD; } set { IAJNKIBKJMM_Crypted = value ^ ENOBDCFHELD; } } //0x173C7DC LGNPDBHEBGD_bgs 0x173C5A4 LOFANILEPKG_bgs
		public int CINCDFAOEOJ_NewExPoint { get { return KCCPNHPGKMF_Crypted ^ ENOBDCFHELD; } set { KCCPNHPGKMF_Crypted = value ^ ENOBDCFHELD; } } //0x173C7EC AADGHDLFBIM_bgs 0x173C5B4 BAOBLNKIMMA_bgs
		public int OOEKGFAIFPK_ExBattleMusicScore { get { return JDFLCJMGPHH_Crypted ^ ENOBDCFHELD; } set { JDFLCJMGPHH_Crypted = value ^ ENOBDCFHELD; } } //0x173C7FC IDHMFMPKAHN_bgs 0x173C5C4 NJBAFMLBDAC_bgs
		public int PJJEBMHOLFP { get { return FBGENHHKLNK_Crypted ^ ENOBDCFHELD; } set { FBGENHHKLNK_Crypted = value ^ ENOBDCFHELD; } } //0x173C80C HCAAIPOKOOE_bgs 0x173C5D4 KJNGCOPMFKK_bgs
		public int JCCABPBHJPA_ExHighScore { get { return EJBJAEHLCHM_Crypted ^ ENOBDCFHELD; } set { EJBJAEHLCHM_Crypted = value ^ ENOBDCFHELD; } } //0x173C81C DMBLGNDADJJ_bgs 0x173C5E4 MABLLGHJFAI_bgs
		public int MBBPOOFCAKC_GetExGauge { get { return KKAJAKPEEMK_Crypted ^ ENOBDCFHELD; } set { KKAJAKPEEMK_Crypted = value ^ ENOBDCFHELD; } } //0x173C82C KALIHPAMKKK_bgs 0x173C5F4 BHPOOHJKOOE_bgs
		public int NHNEMDAFPMJ_ExBattleScoreTotalBefore { get { return AGFLDOFHFFP_Crypted ^ ENOBDCFHELD; } set { AGFLDOFHFFP_Crypted = value ^ ENOBDCFHELD; } } //0x173C83C DJAEAGDLGPO_bgs 0x173C604 COPNOPBOKCK_bgs
		//ExBattleScoreTotalAfter
		public int IGIPKOJJIIA_TotalScore { get { return GEOGJLLKONC_Crypted ^ ENOBDCFHELD; } set { GEOGJLLKONC_Crypted = value ^ ENOBDCFHELD; } } //0x173C84C NMEEMHPEIFG_bgs 0x173C614 DOJPMEDBMGB_bgs
		// SongIdx
		public int BOLHMCFBGBP_Idx { get { return DHPFMDOOMOH_Crypted ^ ENOBDCFHELD; } set { DHPFMDOOMOH_Crypted = value ^ ENOBDCFHELD; } } //0x173C85C KFHLDAHFMDH_bgs 0x173C624 PENFGGBBGPJ_bgs

		// // RVA: 0x173BB9C Offset: 0x173BB9C VA: 0x173BB9C
		// public string MNNKOKNBJNC() { }

		// // RVA: 0x173C418 Offset: 0x173C418 VA: 0x173C418
		public void KHEKNNFCAOI_Init(int KNEFBLHBDBG)
		{
			ENOBDCFHELD = KNEFBLHBDBG;
			PKNBEDPHODG_Twin = 0;
			ANOCILKJGOJ_EpisodeCnt = 0;
			LBLOIOMNEIH_Difficulty = 0;
			APEFEONDBKL_DiffBonus = 0;
			ONLIMGFHGBH_ExPt = 0;
			CINCDFAOEOJ_NewExPoint = 0;
			OOEKGFAIFPK_ExBattleMusicScore = 0;
			PJJEBMHOLFP = 0;
			JCCABPBHJPA_ExHighScore = 0;
			FPEOGFMKMKJ_Point = 0;
			GCAPLLEIAAI_LastScore = 0;
			GPMILOPNBPA_LastScoreExcellent = 0;
			GBLHPHCAPLG_ScoreBonus = 0;
			MACJOPBCEEL = 0;
			BLAJKMAPEKP_CWin = 0;
			BOKPPBLPKEF = 0;
			PGNECHOCIAN_CWinMax = 0;
			JIMGIIBCABI_ScoreResultRank = 0;
			FCLGIPFPIPH_DashBonus = 0;
			EIMCIBOANHE_CurrentClass = 0;
			KOOMDFGADKH_ExBattleWinBonus = 0;
			MBBPOOFCAKC_GetExGauge = 0;
			NHNEMDAFPMJ_ExBattleScoreTotalBefore = 0;
			IGIPKOJJIIA_TotalScore = 0;
			BOLHMCFBGBP_Idx = 0;
			ODCLHPGHDHA_EpisodeBonus = 0;
			PIIEGNPOPJI_GetPoint = 0;
			EDJJIBAGFHL_UnlockedClassBefore = 0;
			GBIGCJIKKPP_UnlockedClassAfter = 0;
		}

		public LCNKFJFICKF()
		{
			KHEKNNFCAOI_Init((int)Utility.GetCurrentUnixTime() ^ 0x1741147);
		}
	}

	private const int GHJHJDIDCFA = 3;
	private const int PLOKNLNKNCM = 3;
	private List<ICFLJACCIKF_EventBattle.OABJKIKLDKP> NFMDLCBJOIB_SongCacheList = new List<ICFLJACCIKF_EventBattle.OABJKIKLDKP>(); // 0xE8
	private List<int> AGLLAPMBDIG_MusicList = new List<int>(); // 0xEC
	private List<EECOJKDJIFG> KBACNOCOANM_Ranking = new List<EECOJKDJIFG>(); // 0xF0
	public static bool ICOCFENNFOC; // 0x0
	public const int JPKHAKEODKC = 3;
	public const int FHHGMELAAFO = 6;
	public List<DJJHCPAKJKJ> PIPHAKNMIBL_Rivals = new List<DJJHCPAKJKJ>(); // 0xF4
	public List<List<BBHNACPENDM_ServerSaveData>> AHFKCDGNPEC_Players = new List<List<BBHNACPENDM_ServerSaveData>>() {
                                                   new List<BBHNACPENDM_ServerSaveData>(),
                                                   new List<BBHNACPENDM_ServerSaveData>(),
                                                   new List<BBHNACPENDM_ServerSaveData>(),
                                                   new List<BBHNACPENDM_ServerSaveData>(),
                                                   new List<BBHNACPENDM_ServerSaveData>(),
                                                   new List<BBHNACPENDM_ServerSaveData>()
                                               }; // 0xF8
	public OLLEELKFCMM.NDBAPDFEPAF CKEDJHEFJCJ; // 0xFC
	public bool KIBBLLADDPO; // 0x100
	public const int PLBIKMLBCKL = 2;
	public int[] PBIEALDEMLK_ScoreAtStep = new int[2]; // 0x104
	public int DJDNFDBMGPG; // 0x108
	public int JAPGCDAJACB; // 0x10C
	public int HCEGPMFOLPO_RivalIdx; // 0x110
	public bool OHLGODIKBIP; // 0x114
	public const string CLMKGKNNILO_ExRivalHelpId = "ExRivalHelpId";
	private bool PFJCMJJMNLD; // 0x115
	private int JBNCFKOEIMO; // 0x118
	private int IGGBHKEIILA; // 0x11C
	private int[] KCHKNEJIEOO = new int[6]; // 0x120
	private int[] FFNNCDNGKHC = new int[6]; // 0x124
	private int[] HOIMNJEBPFN = new int[6]; // 0x128
	private int[] LFLJAPNKCMA = new int[6]; // 0x12C
	private int[] IHFAJLDMJEL_Min = new int[6]; // 0x130
	private int[] ONBHMHMFKDK_Max = new int[6]; // 0x134
	private int PIKCPACHALH; // 0x138
	private int FLPKHMDMHJG; // 0x13C
	private uint PMBEODGMMBB_y = 0x15ab17a1; // 0x140
	public LCNKFJFICKF CKCPAMDDNPF = new LCNKFJFICKF(); // 0x144
	public LCNKFJFICKF IHDPLPHLCPA = new LCNKFJFICKF(); // 0x148
	public int IDBJPDBLIIG_ScoreResultRank; // 0x14C
	private const int JAJDLKEOPPP = 432781;

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle; } } //0x1B6CA1C DKHCGLCNKCD_bgs  Slot: 4

	// // RVA: 0x1B6CA24 Offset: 0x1B6CA24 VA: 0x1B6CA24 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		if(NGIHFKHOJOK_GetRankingMax(true) <= LHJCOPMMIGO)
			return null;
		return KBACNOCOANM_Ranking[LHJCOPMMIGO];
	}

	// RVA: 0x1B6CACC Offset: 0x1B6CACC VA: 0x1B6CACC
	public HAEDCCLHEMN_EventBattle(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0x1B6CF48 Offset: 0x1B6CF48 VA: 0x1B6CF48 Slot: 5
	public override string IFKKBHPMALH()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
		}
		return null;
	}

	// // RVA: 0x1B6D0D0 Offset: 0x1B6D0D0 VA: 0x1B6D0D0
	private List<ICFLJACCIKF_EventBattle.OABJKIKLDKP> LEAGIGKFMPE_GenerateMusicList()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music != null)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				NFMDLCBJOIB_SongCacheList.Clear();
				for(int i = 0; i < dbSection.IJJHFGOIDOK_EventMusic.Count; i++)
				{
                    KEODKEGFDLD_FreeMusicInfo music = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(dbSection.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId);
                    if (music.PPEGAKEIEGM_Enabled == 2)
					{
						if(dbSection.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
						{
							if((dbSection.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && dbSection.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at == 0) || 
								(t >= dbSection.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && dbSection.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at >= t))
							{
								NFMDLCBJOIB_SongCacheList.Add(dbSection.IJJHFGOIDOK_EventMusic[i]);
							}
						}
					}
				}
				return NFMDLCBJOIB_SongCacheList;
			}
		}
		return null;
	}

	// // RVA: 0x1B6D574 Offset: 0x1B6D574 VA: 0x1B6D574
	public List<ICFLJACCIKF_EventBattle.OABJKIKLDKP> KOBMFPACBMB_GetCachedSongList()
	{
		if(NFMDLCBJOIB_SongCacheList.Count == 0)
		{
			return LEAGIGKFMPE_GenerateMusicList();
		}
		return NFMDLCBJOIB_SongCacheList;
	}

	// // RVA: 0x1B6D600 Offset: 0x1B6D600 VA: 0x1B6D600
	public void BEFJOAGGAJD_ResetSongListCache()
	{
		NFMDLCBJOIB_SongCacheList.Clear();
	}

	// // RVA: 0x1B6D678 Offset: 0x1B6D678 VA: 0x1B6D678
	public List<int> ANFCICBOGFE_GetMusicsListInternal(bool BODDJDJAIGN)
	{
		List<int> res = new List<int>();
		res.Clear();
		if(!BODDJDJAIGN)
		{
			BEFJOAGGAJD_ResetSongListCache();
		}
		List<ICFLJACCIKF_EventBattle.OABJKIKLDKP> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			for(int i = 0; i < l.Count; i++)
			{
				res.Add(l[i].MPLGPBNJDJB_FreeMusicId);
			}
		}
		return res;
	}

	// // RVA: 0x1B6D800 Offset: 0x1B6D800 VA: 0x1B6D800 Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		return ANFCICBOGFE_GetMusicsListInternal(false);
	}

	// // RVA: 0x1B6D808 Offset: 0x1B6D808 VA: 0x1B6D808 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<ICFLJACCIKF_EventBattle.OABJKIKLDKP> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_open_at != 0)
				{
					if(l[i].FDBNFFNFOND_close_at != 0)
					{
						if(t >= l[i].PDBPFJJCADD_open_at)
						{
							if(l[i].FDBNFFNFOND_close_at >= t)
							{
								if(l[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
								{
									return l[i].FDBNFFNFOND_close_at;
								}
							}
						}
					}
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(_GHBPLHBNMBK_FreeMusicId);
	}

	// // RVA: 0x1B6DB38 Offset: 0x1B6DB38 VA: 0x1B6DB38 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<ICFLJACCIKF_EventBattle.OABJKIKLDKP> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_open_at != 0)
				{
					if(l[i].FDBNFFNFOND_close_at != 0)
					{
						if(l[i].FDBNFFNFOND_close_at < DPJCPDKALGI_RankingEnd)
						{
							if(t >= l[i].PDBPFJJCADD_open_at)
							{
								if(l[i].FDBNFFNFOND_close_at >= t)
								{
									if(l[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
									{
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x1B6DE88 Offset: 0x1B6DE88 VA: 0x1B6DE88 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0x1B6E044 Offset: 0x1B6E044 VA: 0x1B6E044 Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0x1B6E1C8 Offset: 0x1B6E1C8 VA: 0x1B6E1C8 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].DNBFMLBNAEE_point;
		}
		return 0;
	}

	// // RVA: 0x1B6E428 Offset: 0x1B6E428 VA: 0x1B6E428 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		EECOJKDJIFG data = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(data != null && GPHEKCNDDIK)
		{
			if(!_FBBNPFFEJBN_Force)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("get_rank_cooling_time", 60);
				if(t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] < get_rank_cooling_time)
				{
					PLOOEECNHFB_IsDone = true;
					return;
				}
			}
			KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(data.OCGFKMHNEOF_name_for_api, () =>
			{
				//0x1B87E14
				CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
				KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0x1B87FD8
				KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0x1B88180
				CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			}, () =>
			{
				//0x1B88218
				CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			});
		}
		else
		{
			CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
			PLOOEECNHFB_IsDone = true;
		}
	}

	// // RVA: 0x1B6E82C Offset: 0x1B6E82C VA: 0x1B6E82C Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			GDIPLANPCEI evData = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(db.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(evData != null)
			{
				if(_JHNMKKNEENE_Time >= dbSection.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && dbSection.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time && dbSection.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
				{
					List<string> PDDFOEDNFBN = new List<string>();
					PDDFOEDNFBN.Clear();
					if(dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api != "")
					{
						PDDFOEDNFBN.Add(dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
					}
					if(dbSection.NGHKJOEDLIP_Settings.OGMGLOFKKPA != "")
					{
						PDDFOEDNFBN.Add(dbSection.NGHKJOEDLIP_Settings.OGMGLOFKKPA);
					}
					for(int _BMBBDIAEOMP_i = 0; _BMBBDIAEOMP_i < PDDFOEDNFBN.Count; _BMBBDIAEOMP_i++)
					{
						if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
						{
							//0x1B882B0
							return PDDFOEDNFBN[_BMBBDIAEOMP_i] == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
						}) == null)
						{
							TodoLogger.LogError(TodoLogger.EventBattle_3, "No ranking for " + PDDFOEDNFBN[_BMBBDIAEOMP_i]);
							return false;
						}
					}
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1B6ED78 Offset: 0x1B6ED78 VA: 0x1B6ED78 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			string str = dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
			if(dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == "")
			{
				str = dbSection.NGHKJOEDLIP_Settings.OGMGLOFKKPA;
			}
			bool b1 = d.MPCAGEPEJJJ_Key != str;
            BMIODFJCGAJ_EventBattlePlayer bp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
            bool b2 = bp.LJNAKDMILMC_key != dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
			bool b3 = d.EGBOHDFBAPB_closed_at < dbSection.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			int idx = 0;
			if(RuntimeSettings.CurrentSettings.UnlimitedEvent)
				b3 = false;
			AGLILDLEFDK_Missions = dbSection.NNMPGOAGEOL_quests;
			CKEDJHEFJCJ = 0;
			OLDFFDMPEBM_Quests = d.NNMPGOAGEOL_quests;
			AGLLAPMBDIG_MusicList = HEACCHAKMFG_GetMusicsList();
			if(b1 || b2 || b3 || (bp.OBGBAOLONDD_UniqueId != dbSection.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId))
			{
				d.LHPDDGIJKNB_Reset();
				d.MPCAGEPEJJJ_Key = string.Copy(dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
				d.EGBOHDFBAPB_closed_at = dbSection.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				d.LGADCGFMLLD_step = 0;
				for(; idx < AGLLAPMBDIG_MusicList.Count; idx++)
				{
					d.FFMHJIJBKEN_music[idx].LHPDDGIJKNB_Reset();
					d.FFMHJIJBKEN_music[idx].GOIKCKHMBDL_FreeMusicId = AGLLAPMBDIG_MusicList[idx];
				}
				KOMAHOAEMEK(true);
				bp.KHEKNNFCAOI_Init(dbSection.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId, dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name);
			}
			KOMAHOAEMEK(false);
			for(int i = 0; i < d.FFMHJIJBKEN_music.Count; i++)
			{
				if(d.FFMHJIJBKEN_music[i].GOIKCKHMBDL_FreeMusicId != 0)
				{
					bool b = false;
					for(int j = 0; j < AGLLAPMBDIG_MusicList.Count; j++)
					{
						if(AGLLAPMBDIG_MusicList[j] == d.FFMHJIJBKEN_music[i].GOIKCKHMBDL_FreeMusicId)
						{
							b = true;
							break;
							//LAB_01b6f3ec
						}
					}
					//LAB_01b6f3ec
					if(!b)
					{
						d.FFMHJIJBKEN_music[i].LHPDDGIJKNB_Reset();
					}
				}
			}
			NCEJOLLKDDF_InitRandList();
			return true;
		}
		return false;
	}

	// // RVA: 0x1B6F59C Offset: 0x1B6F59C VA: 0x1B6F59C Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle CBJNDNICMHE = db as ICFLJACCIKF_EventBattle;
			IBNKPMPFLGI_IsRankReward = CBJNDNICMHE.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				EECOJKDJIFG data = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x1B8836C
					return CBJNDNICMHE.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				KBACNOCOANM_Ranking.Add(data);
				data = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x1B883CC
					return CBJNDNICMHE.NGHKJOEDLIP_Settings.OGMGLOFKKPA == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				KBACNOCOANM_Ranking.Add(data);
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = CBJNDNICMHE.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = CBJNDNICMHE.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = CBJNDNICMHE.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = CBJNDNICMHE.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = CBJNDNICMHE.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = CBJNDNICMHE.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = CBJNDNICMHE.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = CBJNDNICMHE.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = CBJNDNICMHE.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			NHGPCLGPEHH_TicketType = CBJNDNICMHE.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = CBJNDNICMHE.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			HGLAFGHHFKP = CBJNDNICMHE.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
			GFIBLLLHMPD_StartAdventureId = CBJNDNICMHE.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = CBJNDNICMHE.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			PJLNJJIBFBN_HasExtremeDiff = CBJNDNICMHE.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
			//UnityEngine.Debug.LogError(DGCOMDILAKM_EventName+" "+PGIIDPEGGPI_EventId);
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(CBJNDNICMHE.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = CBJNDNICMHE.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[] {','});
				MFDJIFIIPJD d = new MFDJIFIIPJD();
				d.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = d;
			}
			LHAKGDAGEMM_EpBonusInfos.Clear();
			for(int i = 0; i < CBJNDNICMHE.LHAKGDAGEMM_EpBonusInfos.Count; i++)
			{
				CEGDBNNIDIG data = new CEGDBNNIDIG();
				data.KELFCMEOPPM_EpisodeId = CBJNDNICMHE.LHAKGDAGEMM_EpBonusInfos[i].KHPHAAMGMJP_EpId;
				data.MIHNKIHNBBL_BaseBonus = CBJNDNICMHE.LHAKGDAGEMM_EpBonusInfos[i].OFIAENKCJME_BaseBonus / 100.0f;
				data.MLLPMJFOKEC_GachaIds.AddRange(CBJNDNICMHE.LHAKGDAGEMM_EpBonusInfos[i].KDNMBOBEGJM_GachaIds);
				LHAKGDAGEMM_EpBonusInfos.Add(data);
			}
			PGDAMNENGDA_EpBonusBySceneRarity.Clear();
			for(int i = 0; i < CBJNDNICMHE.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
			{
				NJJDBBCHBNP data = new NJJDBBCHBNP();
				data.GJEADBKFAPA = CBJNDNICMHE.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC_id;
				data.IJKFFIKGLJM_BonusBefore = CBJNDNICMHE.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
				data.DCBMFNOIENM_BonusAfter = CBJNDNICMHE.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
				PGDAMNENGDA_EpBonusBySceneRarity.Add(data);
			}
			DHOMAEOEFMJ_EpBonuByScene.Clear();
			for(int i = 0; i < CBJNDNICMHE.GEGAEDDGNMA_Bonuses.Count; i++)
			{
				MEBJJBHPMEO data = new MEBJJBHPMEO();
				data.PPFNGGCBJKC_id = CBJNDNICMHE.GEGAEDDGNMA_Bonuses[i].PPFNGGCBJKC_id;
				data.GNFBMCGMCFO_BonusBefore = CBJNDNICMHE.GEGAEDDGNMA_Bonuses[i].GNFBMCGMCFO_BonusBefore;
				data.BFFGFAMJAIG_BonusAfter = CBJNDNICMHE.GEGAEDDGNMA_Bonuses[i].BFFGFAMJAIG_BonusAfter;
				data.CNKFPJCGNFE_SceneId = CBJNDNICMHE.GEGAEDDGNMA_Bonuses[i].CNKFPJCGNFE_SceneId;
				DHOMAEOEFMJ_EpBonuByScene.Add(data);
			}
			GPHEKCNDDIK = true;
			MBHDIJJEOFL = CBJNDNICMHE.MBHDIJJEOFL;
		}
	}

	// // RVA: 0x1B70384 Offset: 0x1B70384 VA: 0x1B70384 Slot: 41
	public override int DBOLCELMBJG_GetMainRankingIndex()
	{
		return BAEPGOAMBDK("main_ranking_index", 0);
	}

	// // RVA: 0x1B703F8 Offset: 0x1B703F8 VA: 0x1B703F8 Slot: 42
	public override int DEECKJADNMJ(int _LAJNCHHNLBI_n)
	{
		if(BAEPGOAMBDK("main_ranking_index", 0) != 0)
		{
			return _LAJNCHHNLBI_n == 0 ? 1 : 0;
		}
		return _LAJNCHHNLBI_n;
	}

	// // RVA: 0x1B70490 Offset: 0x1B70490 VA: 0x1B70490 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle NDFIEMPPMLF_master = db as ICFLJACCIKF_EventBattle;
			Dictionary<string, int> DBEKEBNDMBH_SaveIdx = new Dictionary<string, int>();
			List<string> strs = new List<string>();
			string str0 = NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
			for(int i = 0; i < NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards.Count; i++)
			{
				for(int j = 0; j < NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
				{
					if(NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
					{
						string s = string.Concat(str0, NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId.ToString());
						strs.Add(s);
						DBEKEBNDMBH_SaveIdx.Add(s, i);
					}
				}
			}
			if(strs.Count == 0)
			{
				PIMFJALCIGK();
				PLOOEECNHFB_IsDone = true;
			}
			else
			{
				JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
				req.KMOBDLBKAAA_Repeatable = true;
				req.MIDAMHNABAJ_Keys = strs;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1B8842C
					JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
					CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					for(int i = 0; i < r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes.Count; i++)
					{
						if(DBEKEBNDMBH_SaveIdx.ContainsKey(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key))
						{
							if(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].OOIJCMLEAJP_is_received)
							{
								d.LCDIGDMGPGO_TRcv[DBEKEBNDMBH_SaveIdx[r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key]] = 1;
							}
						}
					}
					PIMFJALCIGK();
					PLOOEECNHFB_IsDone = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1B888E4
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				};
				return;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBE4C Offset: 0x6BBE4C VA: 0x6BBE4C
	// // RVA: 0x1B70B4C Offset: 0x1B70B4C VA: 0x1B70B4C Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0x1B8D028
		KGBCKPKLKHM_RewardItems.Clear();
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			string k = dbSection.EFEGBHACJAL_GetStringParam("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(k))
			{
				List<string> strs = new List<string>();
				strs.Add(k);
				yield return AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(strs, _AOCANKOMKFG_OnError);
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBEC4 Offset: 0x6BBEC4 VA: 0x6BBEC4
	// // RVA: 0x1B70C14 Offset: 0x1B70C14 VA: 0x1B70C14 Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0x1B8CCF8
		KGBCKPKLKHM_RewardItems.Clear();
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			string k = dbSection.EFEGBHACJAL_GetStringParam("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(k))
			{
				List<string> strs = new List<string>();
				strs.Add(k);
				yield return AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(strs, _AOCANKOMKFG_OnError);
			}
		}
	}

	// // RVA: 0x1B70CDC Offset: 0x1B70CDC VA: 0x1B70CDC Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			KIBBLLADDPO = false;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			if(_JHNMKKNEENE_Time >= dbSection.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
			{
				if(DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 0)
							{
								IBLPKJJNNIG = true;
								break;
							}
						}
					}
					//LAB_01b71048
					if(!d.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
						if(_JHNMKKNEENE_Time < dbSection.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
							return;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL == null)
							return;
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
							{
								BELBNINIOIE = true;
							}
						}
						return;
					}
					if(!d.ABBJBPLHFHA_Spurt)
					{
						if(_JHNMKKNEENE_Time >= dbSection.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
							KIBBLLADDPO = true;
							if(MBHDIJJEOFL != null)
							{
								for(int i = 0; i < MBHDIJJEOFL.Count; i++)
								{
									if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
									{
										BELBNINIOIE = true;
									}
								}
								return;
							}
						}
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
					}
					else
					{
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
								}
							}
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
						}
					}
				}
				else
				{
					if(_JHNMKKNEENE_Time >= dbSection.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
					{
						if(_JHNMKKNEENE_Time >= dbSection.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
						{
							if(_JHNMKKNEENE_Time >= dbSection.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
							}
							else
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
							}
						}
						else
						{
							if(d.HPLMECLKFID_RRcv)
							{
								if(d.CIIBINABMPE_RRcv2)
								{
									NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
									return;
								}
							}
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
						}
					}
					else
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting;
					}
				}
			}
			else
			{
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			}
			return;
		}
		NGOFCFJHOMI_Status = 0;
		KIBBLLADDPO = false;
	}

	// // RVA: 0x1B7135C Offset: 0x1B7135C VA: 0x1B7135C Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_point)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(dbSection.NGHKJOEDLIP_Settings != null)
			{
				CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				d.DNBFMLBNAEE_point += _DNBFMLBNAEE_point;
				d.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			}
		}
	}

	// // RVA: 0x1B716AC Offset: 0x1B716AC VA: 0x1B716AC Slot: 48
	public override void AMKJFGLEJGE_RequestUpdateEventPoint(int KPIILHGOGJD)
	{
		EECOJKDJIFG data = DAKMIKNKHMF_GetRankingInfoForIndex(KPIILHGOGJD);
		if(data != null)
		{
			DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
			if(db != null)
			{
				ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
				if(dbSection.NGHKJOEDLIP_Settings != null)
				{
					CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					long t;
					if(KPIILHGOGJD == 1)
					{
						t = GFNODPDPNMJ_GetSumExHighScore();
						if(t < 1)
						{
							PLOOEECNHFB_IsDone = true;
							return;
						}
					}
					else
					{
						t = 0;
						if(KPIILHGOGJD == 0)
						{
							t = d.DNBFMLBNAEE_point;
						}
					}
					long t1 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					PJDGDNJNCNM_UpdateStatusImpl(t1 + 3);
					if(IBNKPMPFLGI_IsRankReward || (NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EIFKDKFAHPH_7 && 
					/*6c*/(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 || 
							NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 || 
							NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 || 
							NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)))
					{
						EECOJKDJIFG data2 = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _GHPLINIACBB_x) =>
						{
							//0x1B88928
							return data.OCGFKMHNEOF_name_for_api == _GHPLINIACBB_x.OCGFKMHNEOF_name_for_api;
						});
						if(data2 != null)
						{
							PKECIDPBEFL.DDBKLMKKCDL data3 = new PKECIDPBEFL.DDBKLMKKCDL();
							data3.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, d.NFIOKIBPJCJ_uptime, t);
							data3.BLJIJENHBPM_Id = data2.PPFNGGCBJKC_id;
							data3.OBGBAOLONDD_UniqueId = PGIIDPEGGPI_EventId;
							data3.NOBCHBHEPNC_Idx = KPIILHGOGJD;
							JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(data3);
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1B71DB0 Offset: 0x1B71DB0 VA: 0x1B71DB0 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
        EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
        if(e != null)
		{
			DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
            if (db != null)
            {
                ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
				CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				long BCOKFFDAKCL = 0;
				if(LHJCOPMMIGO == 1)
				{
                    long a = GFNODPDPNMJ_GetSumExHighScore();
                    if(a > 0)
					{
                        BCOKFFDAKCL = a;
                    }
					else
					{
						PLOOEECNHFB_IsDone = true;
                        return;
                    }
				}
				else if(LHJCOPMMIGO == 0)
				{
                    BCOKFFDAKCL = d.DNBFMLBNAEE_point;
                }
                PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(IBNKPMPFLGI_IsRankReward || NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting) //0x6cU
				{
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(e.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), LOLAANGCGDO_RankingEnd2, d.NFIOKIBPJCJ_uptime, BCOKFFDAKCL), () =>
					{
                        //0x1B88974
                        CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                        PLOOEECNHFB_IsDone = true;
                        int ranking_point_max = dbSection.LPJLEHAJADA_GetIntParam("ranking_point_max", 1000000);
						if(LHJCOPMMIGO == 1 || LHJCOPMMIGO == 0)
						{
                            ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO_BasePoint, BCOKFFDAKCL, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
                        }
                    }, () =>
					{
                        //0x1B88C50
                        PLOOEECNHFB_IsDone = true;
                    }, () =>
					{
                        //0x1B88C78
                        PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
                    });
                    return;
                }
            }
        }
        //LAB_01b7230c
        PLOOEECNHFB_IsDone = true;
    }

	// // RVA: 0x1B72390 Offset: 0x1B72390 VA: 0x1B72390 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.PFAKPFKJJKA() == null)
			{
				CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				long point = FBGDBGKNKOD_GetCurrentPoint();
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
				JOFBHHHLBBN_Rewards.Clear();
				List<string> l1 = new List<string>(3);
				List<int> l2 = new List<int>(3);
				StringBuilder str = new StringBuilder();
				for(int i = 0; i < dbSection.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					if(point >= dbSection.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point)
					{
						if(!d.BHIAKGKHKGD_IsReceived(i))
						{
							str.Length = 0;
							str.Append(PGIIDPEGGPI_EventId);
							str.Append(':');
							str.Append(i);
							str.Append(':');
							str.Append(dbSection.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point);
							JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
							for(int j = 0; j < dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
							{
								if(dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
								{
									l1.Add(string.Concat(dbSection.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix, dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId.ToString()));
									l2.Add(dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].PJPDOCNJNGJ_IsLimited ? (int)dbSection.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate : -1);
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count, null, 0);
								d.IPNLHCLFIDB_SetRewardReceived(i, true);
							}
							JOFBHHHLBBN_Rewards.Add(i);
						}
					}
				}
				if(l1.Count > 0)
				{
					if(!GIPBIDFJFLL)
					{
						FLONELKGABJ_ClaimAchievementPrizes req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
						req.KMOBDLBKAAA_Repeatable = true;
						req.MIDAMHNABAJ_Keys = l1;
						req.MEGNAIJPBFF_InventoryClosedAt = l2;
						req.NBFDEFGFLPJ = OHJOJKNLHOK;
						req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x1B87AE8
							PLOOEECNHFB_IsDone = true;
							DENHAAGACPD();
						};
						req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x1B87AF4
							if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								DENHAAGACPD();
								PLOOEECNHFB_IsDone = true;
							}
							else
							{
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
							}
						};
						return;
					}
					PMHLJAIGBGK = l1;
					FMEDFGOMNBK = l2;
				}
				DENHAAGACPD();
			}
			else
			{
				NPNNPNAIONN_IsError = true;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1B73318 Offset: 0x1B73318 VA: 0x1B73318 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(IBNKPMPFLGI_IsRankReward)
			{
                EECOJKDJIFG rankInfo = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
                if (rankInfo != null)
				{
					KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(rankInfo.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
					{
						//0x1B88CBC
						PLOOEECNHFB_IsDone = true;
						_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
					}, () =>
					{
						//0x1B88D18
						PLOOEECNHFB_IsDone = true;
						_IDAEHNGOKAE_OnRankingError();
					}, () =>
					{
						//0x1B88D64
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						_JGKOLBLPMPG_OnFail();
					}, false);
					return;
				}
			}
		}
		_IDAEHNGOKAE_OnRankingError();
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: g Offset: 0x1B73654 VA: 0x1B73654 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		if(!IBNKPMPFLGI_IsRankReward)
		{
			_IDAEHNGOKAE_OnRankingError();
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0x1B88DC8
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
			}, () =>
			{
				//0x1B88E24
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0x1B88E70
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
		}
	}

	// // RVA: 0x1B73858 Offset: 0x1B73858 VA: 0x1B73858
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x1B70AFC Offset: 0x1B70AFC VA: 0x1B70AFC
	private void PIMFJALCIGK()
	{
		int v = NGIHFKHOJOK_GetRankingMax(true);
		for(int i = 0; i < v; i++)
		{
			BJEOAOACMGG(i);
		}
	}

	// // RVA: 0x1B73950 Offset: 0x1B73950 VA: 0x1B73950
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		EECOJKDJIFG data = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(data != null)
		{
			DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
			if(db != null)
			{
				ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
				CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PFPJHJJAGAG_Rewards.Clear();
				EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
				for(int i = 0; i < data.AHJNPEAMCCH_rewards.Count; i++)
				{
					MAOCCKFAOPC data2 = new MAOCCKFAOPC();
					data2.JBDGBPAAAEF_HighRank = data.AHJNPEAMCCH_rewards[i].JPHDGGNAKMO_high_rank;
					data2.GHANKNIBALB_LowRank = data.AHJNPEAMCCH_rewards[i].FGCAJEAIABA_low_rank;
					data2.MJGAMDBOMHD_InventoryMessage = data.AHJNPEAMCCH_rewards[i].IPFEKNMBEBI_inventory_message;
					data2.HBHMAKNGKFK_items = data.AHJNPEAMCCH_rewards[i].HBHMAKNGKFK_items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(data2);
				}
				for(int i = 0; i < dbSection.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					IHAEIOAKEMG data3 = new IHAEIOAKEMG();
					for(int j = 0; j < dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
					{
						MFDJIFIIPJD data4 = new MFDJIFIIPJD();
						data4.KHEKNNFCAOI_Init(dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, dbSection.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count);
						data4.JOPPFEHKNFO_Pickup = dbSection.FCIPEDFHFEM_TotalRewards[i].JOPPFEHKNFO_Pickup;
						data3.HBHMAKNGKFK_items.Add(data4);
					}
					data3.HMEOAKCLKJE_IsReceived = d.BHIAKGKHKGD_IsReceived(i);
					data3.FIOIKMOIJGK_Point = dbSection.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point;
					data3.OJELCGDDAOM_MissingPoint = dbSection.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point - (int)d.DNBFMLBNAEE_point;
					if(data3.OJELCGDDAOM_MissingPoint < 0)
						data3.OJELCGDDAOM_MissingPoint = 0;
					PFPJHJJAGAG_Rewards.Add(data3);
				}
			}
		}
	}

	// // RVA: 0x1B72FEC Offset: 0x1B72FEC VA: 0x1B72FEC
	private void DENHAAGACPD()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
			{
				PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = d.BHIAKGKHKGD_IsReceived(i);
				PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = (int)(PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - d.DNBFMLBNAEE_point);
				if(PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint < 1)
					PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = 0;
			}
		}
	}

	// // RVA: 0x1B741B8 Offset: 0x1B741B8 VA: 0x1B741B8 Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
		{
			if(!PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived)
			{
				return PFPJHJJAGAG_Rewards[i];
			}
		}
		return null;
	}

	// // RVA: 0x1B742CC Offset: 0x1B742CC VA: 0x1B742CC Slot: 54
	public override int NGIHFKHOJOK_GetRankingMax(bool DJHLDMOPCOL/* = true*/)
	{
		if(IBNKPMPFLGI_IsRankReward)
		{
			if(DJHLDMOPCOL)
			{
				return KBACNOCOANM_Ranking.Count;
			}
			int res = 0;
			for(int i = 0; i < KBACNOCOANM_Ranking.Count; i++)
			{
				if(KBACNOCOANM_Ranking[i] != null)
					res++;
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x1B743E8 Offset: 0x1B743E8 VA: 0x1B743E8 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle NDFIEMPPMLF_master = db as ICFLJACCIKF_EventBattle;
			if(IBNKPMPFLGI_IsRankReward)
			{
                EECOJKDJIFG LONLNGJAEEK = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
				if(LONLNGJAEEK != null)
				{
					HLFHJIDHJMP = null;
					OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
					req.EMPNJPMAKBF_Id = LONLNGJAEEK.PPFNGGCBJKC_id;
					req.MJGOBEGONON_Type = 0;
					req.NHPCKCOPKAM_from = 0;
					req.PJFKNNNDMIA_to = 0;
					req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
					{
						//0x1B88ED4
						if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
						{
							if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
							{
								FKKDIDMGLMI_IsDroppedPlayer = true;
							}
							CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							d.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
							d.HPLMECLKFID_RRcv = true;
							long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							PJDGDNJNCNM_UpdateStatusImpl(t);
							PLOOEECNHFB_IsDone = true;
						}
						else
						{
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
						}

					};
					req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
					{
						//0x1B89238
						OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
						if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
						{
							CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							d.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
							long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							PJDGDNJNCNM_UpdateStatusImpl(t);
							PLOOEECNHFB_IsDone = true;
						}
						else
						{
							HLFHJIDHJMP = new NHGEHCMPDAI();
							HLFHJIDHJMP.DNBFMLBNAEE_point = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
							HLFHJIDHJMP.FJOLNJLLJEJ_rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
							IMCBBOAFION CMJMGEFNBDK = () =>
							{
								//0x1B898FC
								for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
								{
									MFDJIFIIPJD data = new MFDJIFIIPJD();
									data.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
									HLFHJIDHJMP.HBHMAKNGKFK_items.Add(data);
								}
								ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
								CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
								d.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
								PLOOEECNHFB_IsDone = true;
							};
							DJBHIFLHJLK DMLJLPMBLCH = () =>
							{
								//0x1B89C7C
								HLFHJIDHJMP = null;
								ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
								CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
								d.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
								PLOOEECNHFB_IsDone = true;
							};
							IMCBBOAFION EEIFDMNADPA = () =>
							{
								//0x1B89E6C
								CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
								d.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
								PLOOEECNHFB_IsDone = true;
								HLFHJIDHJMP = null;
							};
							DJBHIFLHJLK NDBKOPGCPHJ = () =>
							{
								//0x1B8A000
								PLOOEECNHFB_IsDone = true;
								HLFHJIDHJMP = null;
							};
							DJBHIFLHJLK GGPPHHEFHEJ = () =>
							{
								//0x1B8A048
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
							};
							KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(LONLNGJAEEK.OCGFKMHNEOF_name_for_api, 
								CMJMGEFNBDK, DMLJLPMBLCH, EEIFDMNADPA, NDBKOPGCPHJ, GGPPHHEFHEJ, 0, -1);
						}
					};
					return;
				}
            }
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1B747C0 Offset: 0x1B747C0 VA: 0x1B747C0 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops;
		}
		return null;
	}

	// // RVA: 0x1B74944 Offset: 0x1B74944 VA: 0x1B74944 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			PJDGDNJNCNM_UpdateStatusImpl(t);
			if(GFIBLLLHMPD_StartAdventureId != 0)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					return (d.INLNJOGHLJE_Show & 1) == 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1B74C80 Offset: 0x1B74C80 VA: 0x1B74C80 Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if(_JKDJCFEBDHC_Enabled)
		{
			DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
			if(db != null)
			{
				ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
				CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					d.INLNJOGHLJE_Show |= 1;
				}
			}
		}
	}

	// // RVA: 0x1B74F00 Offset: 0x1B74F00 VA: 0x1B74F00
	public void MJKEIBCDFJB_SetExRivalTutoShown()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			d.INLNJOGHLJE_Show |= 8;
		}
	}

	// // RVA: 0x1B75168 Offset: 0x1B75168 VA: 0x1B75168
	public bool LDIMNGFBKHL_GetExRivalTutoShown()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return (d.INLNJOGHLJE_Show & 8) != 0;
		}
		return false;
	}

	// // RVA: 0x1B753C4 Offset: 0x1B753C4 VA: 0x1B753C4
	public int GCNAICGAEPF_GetExRivalHelpId()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.LPJLEHAJADA_GetIntParam("ExRivalHelpId", 0);
		}
		return 0;
	}

	// // RVA: 0x1B75548 Offset: 0x1B75548 VA: 0x1B75548
	public OKMHOFEJPCF.CBOHLHCMGJJ_Steps KCHPPLMMDGD_GetStep()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return (OKMHOFEJPCF.CBOHLHCMGJJ_Steps)d.LGADCGFMLLD_step;
		}
		return OKMHOFEJPCF.CBOHLHCMGJJ_Steps.HJNNKCMLGFL_0_None;
	}

	// // RVA: 0x1B757A4 Offset: 0x1B757A4 VA: 0x1B757A4
	public void KLAOIILCHON_SetStep(OKMHOFEJPCF.CBOHLHCMGJJ_Steps _LGADCGFMLLD_step)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			d.LGADCGFMLLD_step = (int)_LGADCGFMLLD_step;
		}
	}

	// // RVA: 0x1B75A04 Offset: 0x1B75A04 VA: 0x1B75A04
	public int HACMNNLAHCO_GetConsecutiveWin()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer.EEAPIKNJNDB_ConsecutiveWin;
		}
		return 0;
	}

	// // RVA: 0x1B75C00 Offset: 0x1B75C00 VA: 0x1B75C00
	public int CAEIHFHFOKI_GetScoreAverage()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer.IPPNCOHEEOD_ScoreAverage;
		}
		return 0;
	}

	// // RVA: 0x1B75DFC Offset: 0x1B75DFC VA: 0x1B75DFC
	public int BEHNMCPFEIE_GetCnt()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer.NCAEFIHINAP_Cnt;
		}
		return 0;
	}

	// // RVA: 0x1B75FF8 Offset: 0x1B75FF8 VA: 0x1B75FF8
	private bool KKCEHCKLDCI_HasEmblem(int _GIDPPGJPOJA_Id)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
				if(db != null)
				{
					ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
					if(_GIDPPGJPOJA_Id > 0)
					{
						if(_GIDPPGJPOJA_Id <= dbSection.PMJLEPGCAOA_ClassDatas.Count)
						{
							ICFLJACCIKF_EventBattle.EIIMIHPLDFJ d = dbSection.PMJLEPGCAOA_ClassDatas[_GIDPPGJPOJA_Id - 1];
							if(d.PLALNIIBLOF_en == 2)
							{
								return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, d.APGKOJKNNGP_EmblemId, null) > 0;
							}
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x1B762D4 Offset: 0x1B762D4 VA: 0x1B762D4
	private bool PLCLKINIGLO_FixBattleClassUnlockForClassIncrease()
	{
		int maxAvailable = CJOBENJJCLD_GetLastAvailableClassId();
		if(maxAvailable > 0)
		{
			int curMaxClass = DAHNCPDEBDM_GetEvBltClassUnlocked();
			if(curMaxClass > 0)
			{
				if(curMaxClass < maxAvailable && KKCEHCKLDCI_HasEmblem(curMaxClass))
				{
					GPBOPPFAEGE_SetEvBltClassUnlocked(curMaxClass + 1);
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x1B76734 Offset: 0x1B76734 VA: 0x1B76734 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBF3C Offset: 0x6BBF3C VA: 0x6BBF3C
	// // RVA: 0x1B7678C Offset: 0x1B7678C VA: 0x1B7678C
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		ICFLJACCIKF_EventBattle KHGBJCFJGMA;
		BBHNACPENDM_ServerSaveData HELEPCKLDDB;
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK AIPLGDHHAJI;

		//0x1B8B044
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			KHGBJCFJGMA = db as ICFLJACCIKF_EventBattle;
			PJDGDNJNCNM_UpdateStatusImpl(t);
			HELEPCKLDDB = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			AIPLGDHHAJI = HELEPCKLDDB.DKJBALDICBG_EventBattle.FBCJICEPLED[KHGBJCFJGMA.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(AIPLGDHHAJI.DNBFMLBNAEE_point != 0)
			{
				MJFKJHJJLMN_GetRanks(0, false);
				//LAB_01b8b4a8
				while(!PLOOEECNHFB_IsDone)
					yield return null;
				if(NPNNPNAIONN_IsError)
				{
					//LAB_01b8b4c0
					if(_AOCANKOMKFG_OnError != null)
						_AOCANKOMKFG_OnError.Invoke();
					yield break;
				}
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					//LAB_01b8b568
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
					yield break;
				}
			}
			if(GFNODPDPNMJ_GetSumExHighScore() > 0)
			{
				MJFKJHJJLMN_GetRanks(1, false);
				while(!PLOOEECNHFB_IsDone)
					yield return null;
				if(NPNNPNAIONN_IsError)
				{
					//LAB_01b8b4c0
					if(_AOCANKOMKFG_OnError != null)
						_AOCANKOMKFG_OnError.Invoke();
					yield break;
				}
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					//LAB_01b8b568
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
					yield break;
				}
			}
			switch(AIPLGDHHAJI.LGADCGFMLLD_step)
			{
				case 0:
				case 1:
					OHLGODIKBIP = false;
					if(NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
					{
						//LAB_01b8b8a0
						//LAB_01b8ba1c
						AIPLGDHHAJI.LGADCGFMLLD_step = 7;
					}
					else
					{
						CMPEJEHCOEI = true;
						AIPLGDHHAJI.LGADCGFMLLD_step = 2;
						AIPLGDHHAJI.IMFBCJOIJKJ_Entry = true;
						if(KIBBLLADDPO)
						{
							AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
							LPFJADHHLHG = true;
						}
						PLCLKINIGLO_FixBattleClassUnlockForClassIncrease();
						FGDDBFHGCGP_SetStartAdventureShown(true, 0);
					}
					break;
				case 2:
					if(NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
					{
						//LAB_01b8b8a0
						//LAB_01b8ba1c
						AIPLGDHHAJI.LGADCGFMLLD_step = 7;
					}
					else
					{
						OHLGODIKBIP = true;
						//LAB_01b8ba00
						//LAB_01b8ba1c
						AIPLGDHHAJI.LGADCGFMLLD_step = 3;
					}
					break;
				case 3:
					if(NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
					{
						//LAB_01b8b8a0
						//LAB_01b8ba1c
						AIPLGDHHAJI.LGADCGFMLLD_step = 7;
					}
					break;
				case 4:
					if(NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
					{
						//LAB_01b8b8a0
						//LAB_01b8ba1c
						AIPLGDHHAJI.LGADCGFMLLD_step = 7;
					}
					else
					{
						if(KIBBLLADDPO)
						{
							AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
							LPFJADHHLHG = true;
						}
						CAOCMDNBBPI(false);
						if(PIPHAKNMIBL_Rivals.Count < 3)
						{
							//LAB_01b8ba00
							//LAB_01b8ba1c
							AIPLGDHHAJI.LGADCGFMLLD_step = 3;
						}
					}
					break;
				case 5:
					if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
					{
						HELEPCKLDDB.HIIJOEHDAIM_EventBattlePlayer.EEAPIKNJNDB_ConsecutiveWin = 0;
						int v = JJOPCKDDAFA_GetRvSt();
						if(v == 3)
						{
							HHFIKFEGNPD_SetExPt(0);
							DKIIPPCBDGM_SetExRv(false);
							NGOLCKJKLEA_SetRvSt(0);
						}
						OHLGODIKBIP = v == 3;
						AIPLGDHHAJI.LGADCGFMLLD_step = 3;
					}
					else
					{
						AIPLGDHHAJI.LGADCGFMLLD_step = 7;
					}
					if(KIBBLLADDPO)
					{
						AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
						LPFJADHHLHG = true;
					}
					break;
			}
			CKEDJHEFJCJ = 0;
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
			{
				if(GFIBLLLHMPD_StartAdventureId > 0)
				{
					if(HELEPCKLDDB.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(GFIBLLLHMPD_StartAdventureId))
					{
						if(!AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(() =>
							{
								//0x1B8A1CC
								KPIGMCJMFAN = true;
							});
							//3
							if(KPIGMCJMFAN)
							{
								//LAB_01b8b4c0
								if(_AOCANKOMKFG_OnError != null)
									_AOCANKOMKFG_OnError.Invoke();
								yield break;
							}
							if(JBPPMMMFGCA_HasRewardItems())
							{
								AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv = true;
							}
							//LAB_01b8b460
							//LAB_01b8bbd4
						}
					}
				}
			}
			else
			{
				if(NGOFCFJHOMI_Status >= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive && CAKEOPLJDAF_EndAdventureId >= 1)
				{
					if(HELEPCKLDDB.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(CAKEOPLJDAF_EndAdventureId))
					{
						if(!AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv)
						{
							bool KPIGMCJMFAN = false;
							KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(() =>
							{
								//0x1B8A1E0
								KPIGMCJMFAN = true;
							});
							//4
							if(KPIGMCJMFAN)
							{
								//LAB_01b8b4c0
								if(_AOCANKOMKFG_OnError != null)
									_AOCANKOMKFG_OnError.Invoke();
								yield break;
							}
							if(JBPPMMMFGCA_HasRewardItems())
							{
								AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv = true;
							}
							//LAB_01b8b460
							//LAB_01b8bbd4
						}
					}
				}
			}
			//LAB_01b8bbd4
			OIMGJLOLPHK = false;
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
			{
				CEBFFLDKAEC_SecureInt val;
				if(KHGBJCFJGMA.OHJFBLFELNK_m_intParam.TryGetValue(HOEKCEJINNA_new_episode_mver, out val))
				{
					bool b = DLHEEOIELBA(val.DNJEJEANJGL_Value);
					if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
					{
						bool b2 = !b;
						b = true;
						if(b2)
						{
							b = false;
							AIPLGDHHAJI.INLNJOGHLJE_Show |= 4;
						}
					}
					else
					{
						if(b && KHGBJCFJGMA.OHJFBLFELNK_m_intParam.TryGetValue(FOKNMOMNHHD_new_episode_help_pict_id, out val))
						{
							b = true;
							if((AIPLGDHHAJI.INLNJOGHLJE_Show & 4) != 0)
							{
								GFHKFKHBIGM = true;
								OGPMLMDPGJA = val.DNJEJEANJGL_Value;
								b = true;
							}
						}
					}
					OIMGJLOLPHK = b;
				}
			}
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x1B8A094
				ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
				if(_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0x1B8A16C
				if(_AOCANKOMKFG_OnError != null)
					_AOCANKOMKFG_OnError();
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			}, null);
			yield break;
		}
		NPNNPNAIONN_IsError = true;
		PLOOEECNHFB_IsDone = true;
		if(_AOCANKOMKFG_OnError != null)
			_AOCANKOMKFG_OnError.Invoke();
	}

	// // RVA: 0x1B7686C Offset: 0x1B7686C VA: 0x1B7686C
	// private string BGDFDNJEPLE() { }

	// // RVA: 0x1B7706C Offset: 0x1B7706C VA: 0x1B7706C
	public void MPPGMNOOGIL_Matching(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(PGJAJKPNGDF_Corotuine_Matching(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBFB4 Offset: 0x6BBFB4 VA: 0x6BBFB4
	// // RVA: 0x1B770C4 Offset: 0x1B770C4 VA: 0x1B770C4
	private IEnumerator PGJAJKPNGDF_Corotuine_Matching(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK NGHLIKFIIGI_SaveData; // 0x24
		BMIODFJCGAJ_EventBattlePlayer MJNPBIBKMKL; // 0x28
		int GAMLNIOPALH_WarmupCount; // 0x2C
		bool OFLNONNDNPA; // 0x30

		//0x1B8A43C
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			NGHLIKFIIGI_SaveData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			MJNPBIBKMKL = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
			AGLLAPMBDIG_MusicList = HEACCHAKMFG_GetMusicsList();
			if(NGHLIKFIIGI_SaveData.LFCCCLPFJMB_LastFId > 0)
			{
				bool found = false;
				for(int i = 0; i < AGLLAPMBDIG_MusicList.Count; i++)
				{
					if(AGLLAPMBDIG_MusicList[i] == NGHLIKFIIGI_SaveData.LFCCCLPFJMB_LastFId)
					{
						found = true;
						break;
					}
				}
				if(!found)
					NGHLIKFIIGI_SaveData.LFCCCLPFJMB_LastFId = 0;
			}
			GAMLNIOPALH_WarmupCount = dbSection.LPJLEHAJADA_GetIntParam("warmup_count", 1);
			Debug.Log(JpStringLiterals.StringLiteral_10930 + MJNPBIBKMKL.NCAEFIHINAP_Cnt + "</color>");
			Debug.Log(JpStringLiterals.StringLiteral_10931 + MJNPBIBKMKL.EEAPIKNJNDB_ConsecutiveWin + "</color>");
			PFJCMJJMNLD = false;
			OFLNONNDNPA = false;
			do
			{
				PIPHAKNMIBL_Rivals.Clear();
				int v = MJNPBIBKMKL.NCAEFIHINAP_Cnt;
				if(PFJCMJJMNLD)
					v = IGGBHKEIILA;
				if(v < GAMLNIOPALH_WarmupCount)
				{
					Debug.Log(JpStringLiterals.StringLiteral_10932);
					EKENFAMJBHJ_WarmupSelection();
				}
				else
				{
					bool BEKAMBBOLBO_Done = false;
					bool CNAIDEAFAAM_Error = false;
					N.a.StartCoroutineWatched(FNCECEHBHBJ_Corotuine_SearchPlayer(() =>
					{
						//0x1B8A40C
						BEKAMBBOLBO_Done = true;
					}, () =>
					{
						//0x1B8A418
						BEKAMBBOLBO_Done = true;
						CNAIDEAFAAM_Error = true;
					}));
					while(!BEKAMBBOLBO_Done)
						yield return null;
					if(CNAIDEAFAAM_Error)
					{
						_AOCANKOMKFG_OnError();
						yield break;
					}
				}
				for(int i = 0; i < PIPHAKNMIBL_Rivals.Count; i++)
				{
					PIPHAKNMIBL_Rivals[i].NHKHNABCGKL = PIPHAKNMIBL_Rivals[i].BHCIFFILAKJ_Strength < 3 ? PIPHAKNMIBL_Rivals.Count + i : i;
				}
				PIPHAKNMIBL_Rivals.Sort((DJJHCPAKJKJ _HKICMNAACDA_a, DJJHCPAKJKJ _BNKHBCBJBKI_b) =>
				{
					//0x1B8A1F4
					if(_HKICMNAACDA_a.BHCIFFILAKJ_Strength < 3)
					{
						if(_BNKHBCBJBKI_b.BHCIFFILAKJ_Strength < 3)
						{
							if(_HKICMNAACDA_a.GOIKCKHMBDL_FreeMusicId == AGLLAPMBDIG_MusicList[0])
							{
								if(_BNKHBCBJBKI_b.GOIKCKHMBDL_FreeMusicId != AGLLAPMBDIG_MusicList[0])
									return -1;
							}
							else if(_BNKHBCBJBKI_b.GOIKCKHMBDL_FreeMusicId == AGLLAPMBDIG_MusicList[0])
								return 1;
							return _HKICMNAACDA_a.NHKHNABCGKL.CompareTo(_BNKHBCBJBKI_b.NHKHNABCGKL);
						}
					}
					return _HKICMNAACDA_a.NHKHNABCGKL.CompareTo(_BNKHBCBJBKI_b.NHKHNABCGKL);
				});
				NGHLIKFIIGI_SaveData.MDADLCOCEBN_session_id = JDDGPJDKHNE.GPLMOKEIOLE();
				ILCCJNDFFOB.HHCJCDFCLOB.HHGEPDNBGAI(this, IHFAJLDMJEL_Min, ONBHMHMFKDK_Max);
			} while(OFLNONNDNPA);
			ICEOIDMFIKJ_CopyRivalsInfoInSave();
			NGHLIKFIIGI_SaveData.LGADCGFMLLD_step = 4;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() => {
				//0x1B8A3AC
				_BHFHGFKBOHH_OnSuccess();
			}, () => {
				//0x1B8A3D8
				_AOCANKOMKFG_OnError();
			}, null);
		}
	}

	// // RVA: 0x1B771A4 Offset: 0x1B771A4 VA: 0x1B771A4
	private void EKENFAMJBHJ_WarmupSelection()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			List<int> l = new List<int>();
			for(int i = 0; i < 3; i++)
			{
				l.Add(i);
			}
			DLPHPGJCAAF_RandomizeList(l);
			int v_secondSong = 0;
			if(d.LFCCCLPFJMB_LastFId != AGLLAPMBDIG_MusicList[0])
			{
				v_secondSong = d.LFCCCLPFJMB_LastFId;
			}
			List<int> l2 = new List<int>();
			for(int i = 0; i < AGLLAPMBDIG_MusicList.Count; i++)
			{
				int v2 = AGLLAPMBDIG_MusicList[0];
				if(AGLLAPMBDIG_MusicList[i] != v2)
					v2 = v_secondSong;
				if(AGLLAPMBDIG_MusicList[i] != AGLLAPMBDIG_MusicList[0] && AGLLAPMBDIG_MusicList[i] != v2)
				{
					l2.Add(AGLLAPMBDIG_MusicList[i]);
				}
			}
			DLPHPGJCAAF_RandomizeList(l2);
			if(v_secondSong == 0)
			{
				v_secondSong = l2[0];
			}
			int v3_thirdSong = 0;
			for(int i = 0; i < l2.Count; i++)
			{
				if(l2[i] != AGLLAPMBDIG_MusicList[0])
				{
					if(l2[i] != v_secondSong)
					{
						v3_thirdSong = l2[i];
						break;
					}
				}
			}
			int v5 = 0;
			if(GKDFMEKOOBF_IsExRival())
			{
				CAOCMDNBBPI(true);
				if(!(PIPHAKNMIBL_Rivals.Count > 0 && PIPHAKNMIBL_Rivals.Count < 4) || !OHLGODIKBIP)
				{
					//LAB_01b7779c
					OHLGODIKBIP = true;
					PIPHAKNMIBL_Rivals.Clear();
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					int v4 = 3;
					v5 = 0;
					for(int i = 0; i < dbSection.GCFOLMHPDBG.Count; i++)
					{
						if(v4 > 5)
						{
							Debug.Log(JpStringLiterals.StringLiteral_10882 + v4 + "</color>");
							break;
						}
						if(dbSection.GCFOLMHPDBG[i].PLALNIIBLOF_en == 2)
						{
							if(t >= dbSection.GCFOLMHPDBG[i].PDBPFJJCADD_open_at && t <= dbSection.GCFOLMHPDBG[i].FDBNFFNFOND_close_at)
							{
								PEKHJKEABMK_SetupWarmupSong(dbSection.IJJHFGOIDOK_EventMusic[dbSection.GCFOLMHPDBG[i].KOJMEPJBOJM_EvMusicId - 1].MPLGPBNJDJB_FreeMusicId, v4);
								v4++;
								v5++;
							}
						}
					}
					OHLGODIKBIP = false;
				}
			}
			//LAB_01b77ab4
			//CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer.NCAEFIHINAP_Cnt
			PEKHJKEABMK_SetupWarmupSong(AGLLAPMBDIG_MusicList[0], l[0]);
			PEKHJKEABMK_SetupWarmupSong(v_secondSong, l[1]);
			PEKHJKEABMK_SetupWarmupSong(v3_thirdSong, l[2]);
			BOPJPPJNEOP_SetRvMc(v5 + 3);
        }
	}

	// // RVA: 0x1B78328 Offset: 0x1B78328 VA: 0x1B78328
	private void PEKHJKEABMK_SetupWarmupSong(int _CEFHDLLAPDH_MusicId, int _EIMAOPIJJAO_Str)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(KKMFHMGIIKN_GetCls() < 1)
				return;
			ICFLJACCIKF_EventBattle.EIIMIHPLDFJ c = dbSection.PMJLEPGCAOA_ClassDatas[KKMFHMGIIKN_GetCls() - 1];
			int min = c.FLOAHHHAOLE_BMin;
			int max = c.COJMPBFFJFI_BMax;
			if(_EIMAOPIJJAO_Str >= 3 && _EIMAOPIJJAO_Str < 6)
			{
				min = c.NGNKKFNDEPD_ExMin;
				max = c.MKOKEGGPFBC_ExMax;
			}
			else if(_EIMAOPIJJAO_Str == 2)
			{
				min = c.JLDNDNNDEEH_SMin;
				max = c.LIIIGJFLAAB_SMax;
			}
			else if(_EIMAOPIJJAO_Str == 1)
			{
				min = c.KPFDEBIEAME_AMin;
				max = c.MCBDCDLKACL_AMax;
			}
			HOIMNJEBPFN[_EIMAOPIJJAO_Str] = (min * 100 / c.AFKHNFBOMKI_sc) - 100;
			LFLJAPNKCMA[_EIMAOPIJJAO_Str] = (max * 100 / c.AFKHNFBOMKI_sc) - 100;
			IHFAJLDMJEL_Min[_EIMAOPIJJAO_Str] = min;
			ONBHMHMFKDK_Max[_EIMAOPIJJAO_Str] = max;
			List<int> l = new List<int>(dbSection.OCPGCHOGHPB_DefaultRivals.Count);
			for(int i = 0; i < dbSection.OCPGCHOGHPB_DefaultRivals.Count; i++)
			{
				if(dbSection.OCPGCHOGHPB_DefaultRivals[i].PLALNIIBLOF_en == 2)
				{
					if(dbSection.OCPGCHOGHPB_DefaultRivals[i].GOIKCKHMBDL_FreeMusicId == _CEFHDLLAPDH_MusicId)
					{
						if(min <= dbSection.OCPGCHOGHPB_DefaultRivals[i].IPPNCOHEEOD_ScoreAverage)
						{
							if(dbSection.OCPGCHOGHPB_DefaultRivals[i].IPPNCOHEEOD_ScoreAverage <= max)
							{
								if(dbSection.OCPGCHOGHPB_DefaultRivals[i].KNIFCANOHOC_score <= max)
								{
									l.Add(i);
								}
							}
						}
					}
				}
			}
			int limit = 0;
			while(l.Count < 1)
			{
				min -= 10000;
				for(int i = 0; i < dbSection.OCPGCHOGHPB_DefaultRivals.Count; i++)
				{
					if(dbSection.OCPGCHOGHPB_DefaultRivals[i].PLALNIIBLOF_en == 2)
					{
						if(dbSection.OCPGCHOGHPB_DefaultRivals[i].GOIKCKHMBDL_FreeMusicId == _CEFHDLLAPDH_MusicId)
						{
							if(min <= dbSection.OCPGCHOGHPB_DefaultRivals[i].IPPNCOHEEOD_ScoreAverage)
							{
								if(dbSection.OCPGCHOGHPB_DefaultRivals[i].IPPNCOHEEOD_ScoreAverage <= max)
								{
									if(dbSection.OCPGCHOGHPB_DefaultRivals[i].KNIFCANOHOC_score <= max)
									{
										if(l.FindIndex((int _PMBEODGMMBB_y) =>
										{
											//0x1B8A424
											return _PMBEODGMMBB_y == i;
										}) < 0)
										{
											l.Add(i);
											break;
										}
									}
								}
							}
						}
					}
				}
				limit++;
				if(limit > 99999)
					break;
			}
			if(l.Count < 1)
				return;
			DLPHPGJCAAF_RandomizeList(l);
			DJJHCPAKJKJ data = new DJJHCPAKJKJ();
			data.KHEKNNFCAOI_Init(_EIMAOPIJJAO_Str, dbSection.OCPGCHOGHPB_DefaultRivals[l[0]]);
			PIPHAKNMIBL_Rivals.Add(data);
		}
	}

	// // RVA: 0x1B7A8C8 Offset: 0x1B7A8C8 VA: 0x1B7A8C8
	private SakashoPlayerCriteria HGCOJMFIGLO_GetSearchCriteriaForScore(int MBMADKJEDLP)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			SakashoPlayerCriteria res = null;
			int cls = KKMFHMGIIKN_GetCls();
			if(cls > 0)
			{
				IHFAJLDMJEL_Min[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].FLOAHHHAOLE_BMin;
				ONBHMHMFKDK_Max[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].COJMPBFFJFI_BMax;
				if(cls >= 3 && cls < 6)
				{
					IHFAJLDMJEL_Min[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].NGNKKFNDEPD_ExMin;
					ONBHMHMFKDK_Max[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].MKOKEGGPFBC_ExMax;
				}
				else if(cls == 2)
				{
					IHFAJLDMJEL_Min[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].JLDNDNNDEEH_SMin;
					ONBHMHMFKDK_Max[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].LIIIGJFLAAB_SMax;
				}
				else if(cls == 1)
				{
					IHFAJLDMJEL_Min[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].KPFDEBIEAME_AMin;
					ONBHMHMFKDK_Max[MBMADKJEDLP] = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1].MCBDCDLKACL_AMax;
				}
				res = SakashoPlayerCriteria.NewCriteriaFromTo(dbSection.EFEGBHACJAL_GetStringParam("search_key", "avg_" + PGIIDPEGGPI_EventId.ToString("D4")), IHFAJLDMJEL_Min[MBMADKJEDLP], ONBHMHMFKDK_Max[MBMADKJEDLP]);
			}
			return res;
		}
		return null;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC02C Offset: 0x6BC02C VA: 0x6BC02C
	// // RVA: 0x1B7AE18 Offset: 0x1B7AE18 VA: 0x1B7AE18
	private IEnumerator FNCECEHBHBJ_Corotuine_SearchPlayer(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		int ICEFNMMOCKG; // 0x1C
		int GGJDKPHBCFC; // 0x20
		LNGMNNNJBJP_SearchForPlayer BPOJOBICBAC; // 0x24

		//0x1B8C128
		Debug.Log(JpStringLiterals.StringLiteral_10933);
		ICEFNMMOCKG = 6;
		GGJDKPHBCFC = 0;
		for(int i = 0; i < 6; i++)
		{
			FLPKHMDMHJG = i;
			AHFKCDGNPEC_Players[GGJDKPHBCFC].Clear();
			BPOJOBICBAC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
			BPOJOBICBAC.IPKCADIAAPG_Criteria = HGCOJMFIGLO_GetSearchCriteriaForScore(GGJDKPHBCFC);
			List<string> l = new List<string>();
			l.Add("event_battle_player");
			l.Add("base");
			BPOJOBICBAC.HHIHCJKLJFF_Names = l;
			BPOJOBICBAC.PINPBOCDKLI_OnPlayerCb = PAAJLCJGJKJ;
			BPOJOBICBAC.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			BPOJOBICBAC.IGNIIEBMFIN_Page = 1;
			BPOJOBICBAC.MLPLGFLKKLI_Ipp = BAEPGOAMBDK("search_player_count_" + GGJDKPHBCFC, 20);
			while(!BPOJOBICBAC.PLOOEECNHFB_IsDone)
				yield return null;
			if(BPOJOBICBAC.NPNNPNAIONN_IsError)
			{
				_AOCANKOMKFG_OnError();
				yield break;
			}
			Debug.Log("<color=cyan>" + BPOJOBICBAC.NFEAMMJIMPG_Result.AIGKNOKPMEJ_Players.Count + JpStringLiterals.StringLiteral_10935);
			BPOJOBICBAC = null;
			GGJDKPHBCFC++;
		}
		OGGAOMMJAIF_GenerateSongs();
		for(int i = 0; i < ICEFNMMOCKG; i++)
		{
			AHFKCDGNPEC_Players[i].Clear();
		}
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x1B7AEF8 Offset: 0x1B7AEF8 VA: 0x1B7AEF8
	private bool PAAJLCJGJKJ(int _BMBBDIAEOMP_i, int _EHGBICNIBKE_player_id, long _IFNLEKOILPM_updated_at, bool DMBJLEIGCCG, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _NMICBJDPLOH_player)
	{
		bool b1 = false;
		bool b2 = true;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            BMIODFJCGAJ_EventBattlePlayer ebpSelf = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
            BBHNACPENDM_ServerSaveData playerData = new BBHNACPENDM_ServerSaveData();
			playerData.PNHOEMIMCGC();
			if(playerData.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _NMICBJDPLOH_player))
			{
				BMIODFJCGAJ_EventBattlePlayer ebp = playerData.LBDOLHGDIEB_Find("event_battle_player") as BMIODFJCGAJ_EventBattlePlayer;
				if(!string.IsNullOrEmpty(ebp.LJNAKDMILMC_key))
				{
					if(ebp.LJNAKDMILMC_key == dbSection.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api)
					{
						if(ebp.NCAEFIHINAP_Cnt != 0)
						{
							int scoreLimit = BAEPGOAMBDK("score_limit_" + FLPKHMDMHJG, 100);
							for(int i = 0; i < ebp.AILDCKKOLJG_Results.Count; i++)
							{
								if(ebp.AILDCKKOLJG_Results[i].GOIKCKHMBDL_FreeMusicId != 0)
								{
									bool ok = false;
									for(int j = 0; j < AGLLAPMBDIG_MusicList.Count; j++)
									{
										if(AGLLAPMBDIG_MusicList[j] == ebp.AILDCKKOLJG_Results[i].GOIKCKHMBDL_FreeMusicId)
										{
											ok = true;
											break;
										}
									}
									if(!ok)
										ebp.AILDCKKOLJG_Results[i].GOIKCKHMBDL_FreeMusicId = 0;
									if((ebpSelf.IPPNCOHEEOD_ScoreAverage * scoreLimit) / 100 + ebpSelf.IPPNCOHEEOD_ScoreAverage <= ebp.AILDCKKOLJG_Results[i].KNIFCANOHOC_score)
									{
										ebp.AILDCKKOLJG_Results[i].GOIKCKHMBDL_FreeMusicId = 0;
									}
								}
							}
							ebp.EHGBICNIBKE_player_id = _EHGBICNIBKE_player_id;
							playerData.ABPOMNOIKDA_PlayerId = _EHGBICNIBKE_player_id;
							Debug.Log(string.Concat(new object[5]
							{
								"<color=yellow>player_id=",
								_EHGBICNIBKE_player_id,
								" avg=",
								ebp.IPPNCOHEEOD_ScoreAverage,
								"</color>"
							}));
							AHFKCDGNPEC_Players[FLPKHMDMHJG].Add(playerData);
							b2 = false;
							b1 = true;
						}
					}
				}
			}
		}
		return b1 | b2;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC0A4 Offset: 0x6BC0A4 VA: 0x6BC0A4
	// // RVA: 0x1B7BB00 Offset: 0x1B7BB00 VA: 0x1B7BB00
	// private IEnumerator CPKHNIJMKGJ_UpdateGhostPlayerName(IMCBBOAFION CIGEAEONICJ, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x1B7BBE0 Offset: 0x1B7BBE0 VA: 0x1B7BBE0
	// private bool COFOKLCBFJJ(int _BMBBDIAEOMP_i, int _EHGBICNIBKE_player_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _NMICBJDPLOH_player) { }

	// // RVA: 0x1B6F50C Offset: 0x1B6F50C VA: 0x1B6F50C
	public void NCEJOLLKDDF_InitRandList()
	{
		PMBEODGMMBB_y = (uint)(Utility.GetCurrentUnixTime() ^ 0x15ab17a1);
	}

	// // RVA: 0x1B7BEF4 Offset: 0x1B7BEF4 VA: 0x1B7BEF4
	// private int HEPEDNJMCFA(int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) { }

	// // RVA: 0x1B7BF28 Offset: 0x1B7BF28 VA: 0x1B7BF28
	// private void DLPHPGJCAAF_RandomizeList(List<BBHNACPENDM_ServerSaveData> NNDGIAEFMOG) { }

	// // RVA: 0x1B77C80 Offset: 0x1B77C80 VA: 0x1B77C80
	private void DLPHPGJCAAF_RandomizeList(List<int> NNDGIAEFMOG)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y << 0xd);
				PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y >> 0x11);
				PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y << 5);
				int otherIdx = (int)(PMBEODGMMBB_y & 0x7fffffff) % NNDGIAEFMOG.Count;
				int tmp = NNDGIAEFMOG[otherIdx];
				NNDGIAEFMOG[otherIdx] = NNDGIAEFMOG[i];
				NNDGIAEFMOG[i] = tmp;
			}
		}
	}

	// // RVA: 0x1B7C080 Offset: 0x1B7C080 VA: 0x1B7C080
	private void HBBILBONLLE_FindRival(int _FPGALECHAOM_Str, int _CEFHDLLAPDH_MusicId)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int v1 = _FPGALECHAOM_Str;
			if(v1 > 2)
				v1 = 3;
			List<BBHNACPENDM_ServerSaveData> l = new List<BBHNACPENDM_ServerSaveData>(AHFKCDGNPEC_Players[_FPGALECHAOM_Str].Count);
			for(int i = 0; i < AHFKCDGNPEC_Players[_FPGALECHAOM_Str].Count; i++)
			{
				l.Add(AHFKCDGNPEC_Players[_FPGALECHAOM_Str][i]);
			}
			int max = HOJNMALLCME_GetClassMaxScore(v1, 0);
			int min = dbSection.LPJLEHAJADA_GetIntParam("match_score_min", 1);
			for(int i = 0; i < l.Count; i++)
			{
                BMIODFJCGAJ_EventBattlePlayer AHFNIOGDCIG = l[i].HIIJOEHDAIM_EventBattlePlayer;
				int v2 = -1;
				for(int j = 0; j < AHFNIOGDCIG.AILDCKKOLJG_Results.Count; j++)
				{
					int v3 = v2;
					if(AHFNIOGDCIG.AILDCKKOLJG_Results[j].GOIKCKHMBDL_FreeMusicId == _CEFHDLLAPDH_MusicId)
					{
						if(AHFNIOGDCIG.AILDCKKOLJG_Results[j].KNIFCANOHOC_score <= max)
						{
							if(AHFNIOGDCIG.AILDCKKOLJG_Results[j].KNIFCANOHOC_score >= min)
							{
								int idxRival = PIPHAKNMIBL_Rivals.FindIndex((DJJHCPAKJKJ _GHPLINIACBB_x) =>
								{
									//0x1B87D1C
									return _GHPLINIACBB_x.EHGBICNIBKE_player_id == AHFNIOGDCIG.EHGBICNIBKE_player_id;
								});
								if(idxRival < 0)
								{
									v3 = j;
									if(v2 > -1)
									{
										v3 = v2;
										if(AHFNIOGDCIG.AILDCKKOLJG_Results[v2].BEBJKJKBOGH_date < AHFNIOGDCIG.AILDCKKOLJG_Results[j].BEBJKJKBOGH_date)
										{
											v3 = j;
										}
									}
								}
							}
						}
					}
					v2 = v3;
				}
				if(v2 > -1)
				{
					DJJHCPAKJKJ data = new DJJHCPAKJKJ();
					data.KHEKNNFCAOI_Init(_FPGALECHAOM_Str, AHFNIOGDCIG.AILDCKKOLJG_Results[v2], AHFNIOGDCIG.IPPNCOHEEOD_ScoreAverage, AHFNIOGDCIG.OPFGFINHFCE_name, l[i].ABPOMNOIKDA_PlayerId);
					PIPHAKNMIBL_Rivals.Add(data);
					return;
				}
            }
			BEOCEIBHDHP_FindDefaultRivals(_CEFHDLLAPDH_MusicId, PIPHAKNMIBL_Rivals.Count + 1, _FPGALECHAOM_Str);
		}
	}

	// // RVA: 0x1B7E80C Offset: 0x1B7E80C VA: 0x1B7E80C
	private void OGGAOMMJAIF_GenerateSongs()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			List<int> l = new List<int>();
			for(int i = 0; i < 3; i++)
			{
				l.Add(i);
			}
			DLPHPGJCAAF_RandomizeList(l);
			List<int> l2 = new List<int>();
			for(int i = 1; i < AGLLAPMBDIG_MusicList.Count; i++)
			{
				l2.Add(AGLLAPMBDIG_MusicList[i]);
			}
			DLPHPGJCAAF_RandomizeList(l2);
			int v1 = 0;
			int v2 = 0;
			if(GKDFMEKOOBF_IsExRival())
			{
				CAOCMDNBBPI(true);
				v2 = PIPHAKNMIBL_Rivals.Count;
				if(!(v2 > 0 && v2 < 4) || !OHLGODIKBIP)
				{
					OHLGODIKBIP = true;
					PIPHAKNMIBL_Rivals.Clear();
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					int v3 = 3;
					v2 = 0;
					for(int i = 0; i < dbSection.GCFOLMHPDBG.Count; i++)
					{
						if(v3 > 5)
						{
							Debug.Log(JpStringLiterals.StringLiteral_10882 + v3 + "</color>" );
							break;
						}
						if(dbSection.GCFOLMHPDBG[i].PLALNIIBLOF_en == 2)
						{
							if(t >= dbSection.GCFOLMHPDBG[i].PDBPFJJCADD_open_at)
							{
								if(t <= dbSection.GCFOLMHPDBG[i].FDBNFFNFOND_close_at)
								{
									HBBILBONLLE_FindRival(v3, dbSection.IJJHFGOIDOK_EventMusic[dbSection.GCFOLMHPDBG[i].KOJMEPJBOJM_EvMusicId - 1].MPLGPBNJDJB_FreeMusicId);
									v3++;
									v2++;
								}
							}
						}
					}
					OHLGODIKBIP = false;
				}
			}
			{
				int i = 0;
				do
				{
					for(; i == 0; i++)
					{
						HBBILBONLLE_FindRival(l[0], AGLLAPMBDIG_MusicList[0]);
					}
					int v5 = v1;
					if(i == 1)
					{
						if(d.LFCCCLPFJMB_LastFId != AGLLAPMBDIG_MusicList[0] && d.LFCCCLPFJMB_LastFId != 0)
						{
							HBBILBONLLE_FindRival(l[1], d.LFCCCLPFJMB_LastFId);
							i++;
							continue;
						}
						HBBILBONLLE_FindRival(l[1], l2[v1]);
						i++;
						v1++;
						continue;
					}
					while(v5 < l2.Count)
					{
						if(d.LFCCCLPFJMB_LastFId != l2[v5])
						{
							HBBILBONLLE_FindRival(l[i], l2[v5]);
							break;
						}
						else
							v5++;
					}
					i++;
				} while(i != 3);
				int disable_event_battle_strength_sort = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("disable_event_battle_strength_sort", 0);
				if(disable_event_battle_strength_sort == 0)
				{
					List<int> l3 = new List<int>();
					if(GKDFMEKOOBF_IsExRival())
					{
						if(PIPHAKNMIBL_Rivals.Count - 3 >= 0)
						{
							for(i = PIPHAKNMIBL_Rivals.Count - 3; i < PIPHAKNMIBL_Rivals.Count; i++)
							{
								l3.Add(i);
							}
							l3.Sort((int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) =>
							{
								//0x1B87B50
								return PIPHAKNMIBL_Rivals[_HKICMNAACDA_a].IPPNCOHEEOD_ScoreAverage.CompareTo(PIPHAKNMIBL_Rivals[_BNKHBCBJBKI_b].IPPNCOHEEOD_ScoreAverage);
							});
							for(i = 0; i < l3.Count; i++)
							{
								PIPHAKNMIBL_Rivals[l3[i]].BHCIFFILAKJ_Strength = i;
							}
						}
					}
				}
				BOPJPPJNEOP_SetRvMc(v2 + 3);
			}
		}
	}

	// // RVA: 0x1B77DFC Offset: 0x1B77DFC VA: 0x1B77DFC
	private void CAOCMDNBBPI(bool BGNCKAIEIGN/* = false*/)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			PIPHAKNMIBL_Rivals.Clear();
			for(int i = 0; i < d.CCKMLNLMLFC_Rivals.Count; i++)
			{
				DJJHCPAKJKJ data = new DJJHCPAKJKJ();
				if(!BGNCKAIEIGN || d.CCKMLNLMLFC_Rivals[i].BHCIFFILAKJ_Strength > 2)
				{
					data.KHEKNNFCAOI_Init(d.CCKMLNLMLFC_Rivals[i].BHCIFFILAKJ_Strength, d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result, d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.IPPNCOHEEOD_ScoreAverage, d.CCKMLNLMLFC_Rivals[i].OPFGFINHFCE_name, d.CCKMLNLMLFC_Rivals[i].PBJLLAOJMAK_PId);
					if(data.GOIKCKHMBDL_FreeMusicId != 0)
					{
						PIPHAKNMIBL_Rivals.Add(data);
					}
				}
			}
		}
	}

	// // RVA: 0x1B7F608 Offset: 0x1B7F608 VA: 0x1B7F608
	private void ICEOIDMFIKJ_CopyRivalsInfoInSave()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			for(int i = 0; i < PIPHAKNMIBL_Rivals.Count; i++)
			{
				d.CCKMLNLMLFC_Rivals[i].LHPDDGIJKNB_Reset();
				d.CCKMLNLMLFC_Rivals[i].OPFGFINHFCE_name = PIPHAKNMIBL_Rivals[i].OPFGFINHFCE_name;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.GOIKCKHMBDL_FreeMusicId = PIPHAKNMIBL_Rivals[i].GOIKCKHMBDL_FreeMusicId;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.AKNELONELJK_difficulty = PIPHAKNMIBL_Rivals[i].AKNELONELJK_difficulty;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.MIKICCLPDJA_L6 = PIPHAKNMIBL_Rivals[i].MIKICCLPDJA_L6;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.DIPKCALNIII_diva_id = PIPHAKNMIBL_Rivals[i].DIPKCALNIII_diva_id;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.BEEAIAAJOHD_CostumeId = PIPHAKNMIBL_Rivals[i].BEEAIAAJOHD_CostumeId;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.AFNIOJHODAG_CostumeColorId = PIPHAKNMIBL_Rivals[i].AFNIOJHODAG_CostumeColorId;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.HEBKEJBDCBH_diva_lv = PIPHAKNMIBL_Rivals[i].HEBKEJBDCBH_diva_lv;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.GLILAGLJLEP_SceneId = PIPHAKNMIBL_Rivals[i].GLILAGLJLEP_SceneId;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.ECOLMPLOPFM_SceneLevel = PIPHAKNMIBL_Rivals[i].ECOLMPLOPFM_SceneLevel;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.CFCIMKOHLIG_Mlt = PIPHAKNMIBL_Rivals[i].CFCIMKOHLIG_Mlt;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.IPPNCOHEEOD_ScoreAverage = PIPHAKNMIBL_Rivals[i].IPPNCOHEEOD_ScoreAverage;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.KNIFCANOHOC_score = PIPHAKNMIBL_Rivals[i].KNIFCANOHOC_score;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.OFJHABJNGOD_ExcellentScore = PIPHAKNMIBL_Rivals[i].OFJHABJNGOD_ExcellentScore;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.EDJMDDAGCEJ_Score1 = PIPHAKNMIBL_Rivals[i].EDJMDDAGCEJ_Score1;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.HEFPAIOLBAG_Score2 = PIPHAKNMIBL_Rivals[i].HEFPAIOLBAG_Score2;
				for(int j = 0; j < PIPHAKNMIBL_Rivals[i].MJNMPAKBNKB_NotesResult.Length; j++)
				{
					d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.MJNMPAKBNKB_NotesResult[j] = PIPHAKNMIBL_Rivals[i].MJNMPAKBNKB_NotesResult[j];
				}
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.BEBJKJKBOGH_date = PIPHAKNMIBL_Rivals[i].BEBJKJKBOGH_date;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.NLKEBAOBJCM_combo = PIPHAKNMIBL_Rivals[i].NLKEBAOBJCM_combo;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.BDLNMOIOMHK_total = PIPHAKNMIBL_Rivals[i].BDLNMOIOMHK_total;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.LAMCCNAKIOJ_ComboRank = PIPHAKNMIBL_Rivals[i].LAMCCNAKIOJ_ComboRank;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.NHLGACIHDAH_ExcellentCount = PIPHAKNMIBL_Rivals[i].NHLGACIHDAH_ExcellentCount;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.ENNCJKLIGKE_Luck = PIPHAKNMIBL_Rivals[i].ENNCJKLIGKE_Luck;
				d.CCKMLNLMLFC_Rivals[i].HBODCMLFDOB_result.PALEGNNHIKH_Leaf = PIPHAKNMIBL_Rivals[i].PALEGNNHIKH_Leaf;
				d.CCKMLNLMLFC_Rivals[i].PBJLLAOJMAK_PId = PIPHAKNMIBL_Rivals[i].EHGBICNIBKE_player_id;
				d.CCKMLNLMLFC_Rivals[i].BHCIFFILAKJ_Strength = PIPHAKNMIBL_Rivals[i].BHCIFFILAKJ_Strength;
			}
		}
	}

	// // RVA: 0x1B7D3BC Offset: 0x1B7D3BC VA: 0x1B7D3BC
	private void BEOCEIBHDHP_FindDefaultRivals(int _CEFHDLLAPDH_MusicId, int _PIMJMPHMCFO_NumRivals, int _FPGALECHAOM_Str)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int cls = KKMFHMGIIKN_GetCls();
			if(cls < 1)
			{
				return;
			}
			ICFLJACCIKF_EventBattle.EIIMIHPLDFJ data = dbSection.PMJLEPGCAOA_ClassDatas[cls - 1];
			int min = data.FLOAHHHAOLE_BMin;
			int max = data.COJMPBFFJFI_BMax;
			if(_FPGALECHAOM_Str >= 3 && _FPGALECHAOM_Str < 6)
			{
				min = data.NGNKKFNDEPD_ExMin;
				max = data.MKOKEGGPFBC_ExMax;
			}
			else if(_FPGALECHAOM_Str == 2)
			{
				min = data.JLDNDNNDEEH_SMin;
				max = data.LIIIGJFLAAB_SMax;
			}
			else if(_FPGALECHAOM_Str == 1)
			{
				min = data.KPFDEBIEAME_AMin;
				max = data.MCBDCDLKACL_AMax;
			}
			Debug.Log(string.Concat(new object[7]
			{
				JpStringLiterals.StringLiteral_10890,
				_CEFHDLLAPDH_MusicId,
				" ",
				HOIMNJEBPFN[_FPGALECHAOM_Str],
				JpStringLiterals.StringLiteral_10891,
				LFLJAPNKCMA[_FPGALECHAOM_Str],
				"</color>"
			}));
			Debug.Log(string.Concat(new object[5]
			{
				JpStringLiterals.StringLiteral_10892,
				min,
				JpStringLiterals.StringLiteral_10891,
				max,
				"</color>"
			}));
			List<int> l = new List<int>(dbSection.OCPGCHOGHPB_DefaultRivals.Count);
			for(int i = 0; i < dbSection.OCPGCHOGHPB_DefaultRivals.Count; i++)
			{
                ICFLJACCIKF_EventBattle.FKACPHEKBNF JGNBPFCJLKI_d = dbSection.OCPGCHOGHPB_DefaultRivals[i];
				if(JGNBPFCJLKI_d.PLALNIIBLOF_en == 2)
				{
					if(JGNBPFCJLKI_d.GOIKCKHMBDL_FreeMusicId == _CEFHDLLAPDH_MusicId)
					{
						if(min <= JGNBPFCJLKI_d.IPPNCOHEEOD_ScoreAverage)
						{
							if(JGNBPFCJLKI_d.IPPNCOHEEOD_ScoreAverage <= max)
							{
								if(JGNBPFCJLKI_d.KNIFCANOHOC_score <= max)
								{
									int idx = PIPHAKNMIBL_Rivals.FindIndex((DJJHCPAKJKJ _GHPLINIACBB_x) =>
									{
										//0x1B87D70
										return _GHPLINIACBB_x.OPFGFINHFCE_name == JGNBPFCJLKI_d.OPFGFINHFCE_name;
									});
									if(idx < 0)
									{
										l.Add(i);
									}
								}
							}
						}
					}
				}
            }
			for(int c = 0; c < 99999 && l.Count < _PIMJMPHMCFO_NumRivals - PIPHAKNMIBL_Rivals.Count; c++)
			{
				min -= 10000;
				for(int _BMBBDIAEOMP_i = 0; _BMBBDIAEOMP_i < dbSection.OCPGCHOGHPB_DefaultRivals.Count; _BMBBDIAEOMP_i++)
				{
					if(dbSection.OCPGCHOGHPB_DefaultRivals[_BMBBDIAEOMP_i].PLALNIIBLOF_en == 2)
					{
						if(dbSection.OCPGCHOGHPB_DefaultRivals[_BMBBDIAEOMP_i].GOIKCKHMBDL_FreeMusicId == _CEFHDLLAPDH_MusicId)
						{
							if(min <= dbSection.OCPGCHOGHPB_DefaultRivals[_BMBBDIAEOMP_i].IPPNCOHEEOD_ScoreAverage)
							{
								if(dbSection.OCPGCHOGHPB_DefaultRivals[_BMBBDIAEOMP_i].IPPNCOHEEOD_ScoreAverage <= max)
								{
									if(dbSection.OCPGCHOGHPB_DefaultRivals[_BMBBDIAEOMP_i].KNIFCANOHOC_score <= max)
									{
										int idx = l.FindIndex((int _PMBEODGMMBB_y) =>
										{
											//0x1B87DBC
											return _BMBBDIAEOMP_i == _PMBEODGMMBB_y;
										});
										if(idx < 0)
										{
											//code_r0x01b7e35c
											l.Add(_BMBBDIAEOMP_i);
											break;
										}
									}
								}
							}
						}
					}
				}
			}
			//LAB_01b7e388
			//LAB_01b7e3a0
			if(l.Count < 1)
			{
				Debug.Log(JpStringLiterals.StringLiteral_10893);
			}
			else
			{
				if(_PIMJMPHMCFO_NumRivals - PIPHAKNMIBL_Rivals.Count < l.Count)
				{
					for(int i = 0; i < l.Count; i++)
					{
						if(dbSection.OCPGCHOGHPB_DefaultRivals[l[i]].IPPNCOHEEOD_ScoreAverage == 0)
						{
							l.RemoveAt(i);
							i--;
						}
					}
				}
				DLPHPGJCAAF_RandomizeList(l);
				for(int i = 0; i < 100 && _PIMJMPHMCFO_NumRivals > PIPHAKNMIBL_Rivals.Count; i++)
				{
					if(i < l.Count)
					{
						DJJHCPAKJKJ data2 = new DJJHCPAKJKJ();
						data2.KHEKNNFCAOI_Init(_FPGALECHAOM_Str, dbSection.OCPGCHOGHPB_DefaultRivals[l[i]]);
						PIPHAKNMIBL_Rivals.Add(data2);
					}
				}
			}
		}
	}

	// // RVA: 0x1B80034 Offset: 0x1B80034 VA: 0x1B80034
	private void JPBPMFAGMEB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            BMIODFJCGAJ_EventBattlePlayer ebp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
			List<BLHNHKMMPAD> results = ebp.AILDCKKOLJG_Results;
			int v1;
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == AGLLAPMBDIG_MusicList[0])
			{
				v1 = 0;
			}
			else
			{
				long t1 = long.MaxValue;
				v1 = -1;
				for(int i = 1; i < ebp.AILDCKKOLJG_Results.Count; i++)
				{
					if(ebp.AILDCKKOLJG_Results[i].BEBJKJKBOGH_date < t1)
					{
						t1 = ebp.AILDCKKOLJG_Results[i].BEBJKJKBOGH_date;
						v1 = i;
					}
				}
				if(v1 < 2)
					v1 = 1;
			}
			ebp.EGPMLMCCOLH = v1;
			results[v1].GOIKCKHMBDL_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
			results[v1].AKNELONELJK_difficulty = OMNOFMEBLAD.AKNELONELJK_difficulty;
			results[v1].MIKICCLPDJA_L6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? 1 : 0;
            AMCGONHBGGF diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0];
			results[v1].DIPKCALNIII_diva_id = diva.DIPKCALNIII_diva_id;
			results[v1].BEEAIAAJOHD_CostumeId = diva.BEEAIAAJOHD_CostumeId;
			results[v1].AFNIOJHODAG_CostumeColorId = diva.AFNIOJHODAG_CostumeColorId;
			results[v1].HEBKEJBDCBH_diva_lv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(results[v1].DIPKCALNIII_diva_id).HEBKEJBDCBH_diva_lv;
			results[v1].GLILAGLJLEP_SceneId = diva.EBDNICPAFLB_s_slot[0];
			if(results[v1].GLILAGLJLEP_SceneId == 0)
			{
				results[v1].ECOLMPLOPFM_SceneLevel = 0;
				results[v1].CFCIMKOHLIG_Mlt = 0;
				results[v1].ENNCJKLIGKE_Luck = 0;
				results[v1].PALEGNNHIKH_Leaf = 0;
			}
			else
			{
                MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[results[v1].GLILAGLJLEP_SceneId - 1];
                results[v1].ECOLMPLOPFM_SceneLevel = scene.ANAJIAENLNB_lv;
				results[v1].CFCIMKOHLIG_Mlt = scene.JPIPENJGGDD_NumBoard;
				results[v1].ENNCJKLIGKE_Luck = scene.MJBODMOLOBC_luck;
				results[v1].PALEGNNHIKH_Leaf = scene.DMNIMMGGJJJ_Leaf;
			}
			for(int i = 0; i < 5; i++)
			{
				results[v1].MJNMPAKBNKB_NotesResult[i] = OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[i];
			}
			results[v1].NHLGACIHDAH_ExcellentCount = OMNOFMEBLAD.FEGLNPOFDJC_ExcellentCount;
			results[v1].OFJHABJNGOD_ExcellentScore = OMNOFMEBLAD.EACPIDGGPPO_ExcellentScore;
			results[v1].KNIFCANOHOC_score = OMNOFMEBLAD.KNIFCANOHOC_score;
			results[v1].EDJMDDAGCEJ_Score1 = OMEAIMCDHOA_GetScoreForStep(0);
			results[v1].HEFPAIOLBAG_Score2 = OMEAIMCDHOA_GetScoreForStep(1);
			results[v1].BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int warmup_count = dbSection.LPJLEHAJADA_GetIntParam("warmup_count", 1);
			int cutoff_score_per = dbSection.LPJLEHAJADA_GetIntParam("cutoff_score_per", 20);
			if((warmup_count >= ebp.NCAEFIHINAP_Cnt + 1) || 
				((ebp.IPPNCOHEEOD_ScoreAverage * cutoff_score_per) / 100 < OMNOFMEBLAD.KNIFCANOHOC_score))
			{
				for(int i = ebp.PEIFEBNCMOM_Hist.Count - 2; i >= 0 ; i--)
				{
					ebp.PEIFEBNCMOM_Hist[i + 1] = ebp.PEIFEBNCMOM_Hist[i];
				}
				ebp.PEIFEBNCMOM_Hist[0] = results[v1].KNIFCANOHOC_score;
			}
			/*if(ebp.PEIFEBNCMOM_Hist.Count < ebp.NCAEFIHINAP_Cnt + 1)
			{
				ebp.PEIFEBNCMOM_Hist.Count
			}*/
			int v2 = 0;
			long v3 = 0;
			for(int i = 0; i < ebp.PEIFEBNCMOM_Hist.Count; i++)
			{
				if(ebp.PEIFEBNCMOM_Hist[i] > -1)
				{
					v2++;
					v3 += ebp.PEIFEBNCMOM_Hist[i];
				}
			}
			results[v1].LAMCCNAKIOJ_ComboRank = OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
			results[v1].NLKEBAOBJCM_combo = OMNOFMEBLAD.NLKEBAOBJCM_combo;
			results[v1].BDLNMOIOMHK_total = OMNOFMEBLAD.HCFGMNPMIHL_GetTotalStats();
			if(ebp.NCAEFIHINAP_Cnt + 1 < warmup_count)
			{
				ebp.IPPNCOHEEOD_ScoreAverage = ebp.PEIFEBNCMOM_Hist[0];
			}
			else
			{
				if(v2 == 0)
				{
					ebp.IPPNCOHEEOD_ScoreAverage = ebp.PEIFEBNCMOM_Hist[0];
					if(ebp.IPPNCOHEEOD_ScoreAverage < 0)
					{
						ebp.IPPNCOHEEOD_ScoreAverage = 0;
					}
				}
				else
				{
					ebp.IPPNCOHEEOD_ScoreAverage = (int)(v3 / v2); // ldivmod
				}
			}
			results[v1].IPPNCOHEEOD_ScoreAverage = ebp.IPPNCOHEEOD_ScoreAverage;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name != ebp.OPFGFINHFCE_name)
			{
				ebp.OPFGFINHFCE_name = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
			}
		}
	}

	// // RVA: 0x1B815C4 Offset: 0x1B815C4 VA: 0x1B815C4
	private void EBNMMCKCPKN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int _FCLGIPFPIPH_DashBonus, int _LCCGDFGGIHI_PlayCount, int _ANOPDAGJIKG_FriendSceneId, int MHADLGMJKGK, bool _IKGLAFOHGDO_TestOnly)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			MDLBECKMBHJ(OMNOFMEBLAD, _FCLGIPFPIPH_DashBonus, _LCCGDFGGIHI_PlayCount, 1, _ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK, _IKGLAFOHGDO_TestOnly);
			if(_IKGLAFOHGDO_TestOnly)
				return;
            BMIODFJCGAJ_EventBattlePlayer ebp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
			ebp.EEAPIKNJNDB_ConsecutiveWin = CKCPAMDDNPF.BLAJKMAPEKP_CWin;
			if(ebp.EEAPIKNJNDB_ConsecutiveWin < 1000)
			{
				if(ebp.EEAPIKNJNDB_ConsecutiveWin < 0)
					ebp.EEAPIKNJNDB_ConsecutiveWin = 0;
			}
			else
			{
				ebp.EEAPIKNJNDB_ConsecutiveWin = 999;
			}
			ebp.KEFMAJJPAKM_CWinMax = CKCPAMDDNPF.PGNECHOCIAN_CWinMax;
			if(ebp.KEFMAJJPAKM_CWinMax < 1000)
			{
				if(ebp.KEFMAJJPAKM_CWinMax < 0)
					ebp.KEFMAJJPAKM_CWinMax = 0;
			}
			else
			{
				ebp.KEFMAJJPAKM_CWinMax = 999;
			}
			ebp.FGEIOMGBGLI_Twin = CKCPAMDDNPF.PKNBEDPHODG_Twin;
			if(ebp.FGEIOMGBGLI_Twin < 10001)
			{
				if(ebp.FGEIOMGBGLI_Twin < 0)
					ebp.FGEIOMGBGLI_Twin = 0;
			}
			else
			{
				ebp.FGEIOMGBGLI_Twin = 10000;
			}
			NBMDAOFPKGK(CKCPAMDDNPF.PIIEGNPOPJI_GetPoint);
			ebp.NCAEFIHINAP_Cnt++;
			if(ebp.NCAEFIHINAP_Cnt > 10000)
			{
				ebp.NCAEFIHINAP_Cnt = 10000;
			}
			d.LGADCGFMLLD_step = 3;
        }
	}

	// // RVA: 0x1B83CA8 Offset: 0x1B83CA8 VA: 0x1B83CA8
	public int NJDPMDCIFBP_GetResultExPoint(int _BHCIFFILAKJ_Strength, bool _DPCFADCFMOA_Win)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(_BHCIFFILAKJ_Strength < 3)
			{
				if(_DPCFADCFMOA_Win)
				{
					if(_BHCIFFILAKJ_Strength == 2)
					{
						return dbSection.LPJLEHAJADA_GetIntParam("win_pnt_s", 50);
					}
					else if(_BHCIFFILAKJ_Strength == 0)
					{
						return dbSection.LPJLEHAJADA_GetIntParam("win_pnt_b", 30);
					}
					else if(_BHCIFFILAKJ_Strength == 1)
					{
						return dbSection.LPJLEHAJADA_GetIntParam("win_pnt_a", 40);
					}
					return 0;
				}
				else
				{
					if(_BHCIFFILAKJ_Strength == 2)
					{
						return dbSection.LPJLEHAJADA_GetIntParam("los_pnt_s", 25);
					}
					else if(_BHCIFFILAKJ_Strength == 0)
					{
						return dbSection.LPJLEHAJADA_GetIntParam("los_pnt_b", 15);
					}
					else if(_BHCIFFILAKJ_Strength == 1)
					{
						return dbSection.LPJLEHAJADA_GetIntParam("los_pnt_a", 20);
					}
					return 0;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1B7CA38 Offset: 0x1B7CA38 VA: 0x1B7CA38
	public int HOJNMALLCME_GetClassMaxScore(int _BHCIFFILAKJ_Strength, int _BGJDHCEOIDB_BattleClass/* = 0*/)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(_BHCIFFILAKJ_Strength > 3)
				return 0;
			int idx = KKMFHMGIIKN_GetCls();
			if(_BGJDHCEOIDB_BattleClass > 0)
				idx = _BGJDHCEOIDB_BattleClass;
			if(_BHCIFFILAKJ_Strength > 3 || _BHCIFFILAKJ_Strength < 0)
				return 0;
			switch(_BHCIFFILAKJ_Strength)
			{
				case 1:
					return dbSection.PMJLEPGCAOA_ClassDatas[idx - 1].MCBDCDLKACL_AMax;
				case 2:
					return dbSection.PMJLEPGCAOA_ClassDatas[idx - 1].LIIIGJFLAAB_SMax;
				case 3:
					return dbSection.PMJLEPGCAOA_ClassDatas[idx - 1].MKOKEGGPFBC_ExMax;
				default:
					return dbSection.PMJLEPGCAOA_ClassDatas[idx - 1].COJMPBFFJFI_BMax;
			}
		}
		return 0;
	}

	// // RVA: 0x1B83ED8 Offset: 0x1B83ED8 VA: 0x1B83ED8
	public int EHEPBMBNFGE_GetDiffBonus(int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(_AKNELONELJK_difficulty > 4)
				return 0;
			if(!_GIKLNODJKFK_IsLine6)
			{
				switch(_AKNELONELJK_difficulty)
				{
					case 0:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_es", 0);
					case 1:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_nm", 25);
					case 2:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_hd", 50);
					case 3:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_vh", 100);
					case 4:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_ex", 200);
					default:
						return 0;
				}
			}
			else
			{
				switch(_AKNELONELJK_difficulty)
				{
					case 0:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_es_l6", 0);
					case 1:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_nm_l6", 25);
					case 2:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_hd_l6", 50);
					case 3:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_vh_l6", 100);
					case 4:
						return dbSection.LPJLEHAJADA_GetIntParam("df_bns_ex_l6", 200);
					default:
						return 0;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1B81C0C Offset: 0x1B81C0C VA: 0x1B81C0C
	public void MDLBECKMBHJ(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int _FCLGIPFPIPH_DashBonus, int _LCCGDFGGIHI_PlayCount, int KAAGPOHNMBD/* = 1*/, int _ANOPDAGJIKG_FriendSceneId/* = 0*/, int MHADLGMJKGK/* = 0*/, bool _IKGLAFOHGDO_TestOnly/* = False*/)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            BMIODFJCGAJ_EventBattlePlayer ebp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer;
			int currentClass = d.BINKCNFPHIP_Cls;
			if(currentClass < 2)
				currentClass = 1;
			int lastClassAvailable = CJOBENJJCLD_GetLastAvailableClassId();
			int currentClassClamped = currentClass;
			if(lastClassAvailable < currentClass)
				currentClassClamped = lastClassAvailable;
            ICFLJACCIKF_EventBattle.EIIMIHPLDFJ d1 = dbSection.PMJLEPGCAOA_ClassDatas[currentClassClamped];
            DJJHCPAKJKJ d2 = PIPHAKNMIBL_Rivals[HCEGPMFOLPO_RivalIdx];
			bool isWin;
			if(OMNOFMEBLAD.KNIFCANOHOC_score < d2.KNIFCANOHOC_score)
			{
				Debug.Log(JpStringLiterals.StringLiteral_10913);
				isWin = false;
			}
			else
			{
				Debug.Log(JpStringLiterals.StringLiteral_10912);
				isWin = true;
			}
			IDBJPDBLIIG_ScoreResultRank = JAPGCDAJACB;
			int v1 = dbSection.LPJLEHAJADA_GetIntParam("score_point_coef", 10000);
			LCNKFJFICKF data;
			if(_IKGLAFOHGDO_TestOnly)
			{
				data = IHDPLPHLCPA;
				IHDPLPHLCPA.KHEKNNFCAOI_Init((int)Utility.GetCurrentUnixTime() ^ 0x3853358);
			}
			else
			{
				data = CKCPAMDDNPF;
				CKCPAMDDNPF.KHEKNNFCAOI_Init((int)Utility.GetCurrentUnixTime() ^ 0x1741147);
			}
			data.NHNEMDAFPMJ_ExBattleScoreTotalBefore = GFNODPDPNMJ_GetSumExHighScore();
			data.OEGDACKEDIB_ExBattleScoreAfter[0] = APAKCLNALIJ_GetExHighScore(0);
			data.HDIEPNLNABL_ExBattleScoreBefore[0] = data.OEGDACKEDIB_ExBattleScoreAfter[0];
			data.OEGDACKEDIB_ExBattleScoreAfter[1] = APAKCLNALIJ_GetExHighScore(1);
			data.HDIEPNLNABL_ExBattleScoreBefore[1] = data.OEGDACKEDIB_ExBattleScoreAfter[1];
			data.OEGDACKEDIB_ExBattleScoreAfter[2] = APAKCLNALIJ_GetExHighScore(2);
			data.HDIEPNLNABL_ExBattleScoreBefore[2] = data.OEGDACKEDIB_ExBattleScoreAfter[2];
			data.EDJJIBAGFHL_UnlockedClassBefore = DAHNCPDEBDM_GetEvBltClassUnlocked();
			data.GBIGCJIKKPP_UnlockedClassAfter = data.EDJJIBAGFHL_UnlockedClassBefore;
			data.DPCFADCFMOA_Win = isWin;
			data.EIMCIBOANHE_CurrentClass = currentClassClamped;
			data.GCAPLLEIAAI_LastScore = OMNOFMEBLAD.KNIFCANOHOC_score;
			data.GPMILOPNBPA_LastScoreExcellent = OMNOFMEBLAD.EACPIDGGPPO_ExcellentScore;
			data.GBLHPHCAPLG_ScoreBonus = data.GCAPLLEIAAI_LastScore / v1;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer.JKAMFMNGEBB_high_score < CKCPAMDDNPF.GCAPLLEIAAI_LastScore)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HIIJOEHDAIM_EventBattlePlayer.JKAMFMNGEBB_high_score = CKCPAMDDNPF.GCAPLLEIAAI_LastScore;
			}
			Debug.Log(string.Concat(new object[5]
			{
				JpStringLiterals.StringLiteral_10915,
				data.GCAPLLEIAAI_LastScore,
				JpStringLiterals.StringLiteral_10916,
				data.GBLHPHCAPLG_ScoreBonus,
				" </color>"
			}));
			data.ANOCILKJGOJ_EpisodeCnt = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(_ANOPDAGJIKG_FriendSceneId).Count;
			data.ODCLHPGHDHA_EpisodeBonus = CEICDKGEONG_GetEquippedEpisodesBonusValue(_ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK);
			data.ODCLHPGHDHA_EpisodeBonus += 100;
			Debug.Log(string.Concat(new object[5]
			{
				JpStringLiterals.StringLiteral_10918,
				data.ANOCILKJGOJ_EpisodeCnt,
				JpStringLiterals.StringLiteral_10916,
				data.ODCLHPGHDHA_EpisodeBonus,
				" </color>"
			}));
			data.JIMGIIBCABI_ScoreResultRank = IDBJPDBLIIG_ScoreResultRank;
			data.FPEOGFMKMKJ_Point = d1.KEJKLJNJJDB(IDBJPDBLIIG_ScoreResultRank);
			data.LBLOIOMNEIH_Difficulty = OMNOFMEBLAD.AKNELONELJK_difficulty;
			data.INPNFCNLAMA_IsLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6;
			data.APEFEONDBKL_DiffBonus = EHEPBMBNFGE_GetDiffBonus(data.LBLOIOMNEIH_Difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
			data.APEFEONDBKL_DiffBonus += 100;
			if(isWin)
			{
				data.BLAJKMAPEKP_CWin = ebp.EEAPIKNJNDB_ConsecutiveWin + KAAGPOHNMBD;
				data.PGNECHOCIAN_CWinMax = ebp.KEFMAJJPAKM_CWinMax;
				if(data.PGNECHOCIAN_CWinMax < data.BLAJKMAPEKP_CWin)
				{
					data.PGNECHOCIAN_CWinMax = data.BLAJKMAPEKP_CWin;
				}
				data.PKNBEDPHODG_Twin = ebp.FGEIOMGBGLI_Twin;
				data.PKNBEDPHODG_Twin += KAAGPOHNMBD;
				int idx = 0;
				for(int i = 0; i < dbSection.AFHHBNBCOKI.Count; i++)
				{
					idx = i;
					if(dbSection.AFHHBNBCOKI[i].EEAPIKNJNDB_ConsecutiveWin > ebp.EEAPIKNJNDB_ConsecutiveWin + KAAGPOHNMBD)
					{
						break;
					}
				}
				data.BOKPPBLPKEF = dbSection.AFHHBNBCOKI[idx].DJJGNDCMNHF_BonusValue;
				int v2 = (data.ODCLHPGHDHA_EpisodeBonus * (data.GBLHPHCAPLG_ScoreBonus + data.FPEOGFMKMKJ_Point) * 10) / 100; // ldivmod
				int score_upper_limit_magn = dbSection.LPJLEHAJADA_GetIntParam("score_upper_limit_magn", 8);
				int v3 = (data.APEFEONDBKL_DiffBonus * v2) / 1000;
				int v4 = data.FPEOGFMKMKJ_Point;
				if(v3 >= data.FPEOGFMKMKJ_Point)
				{
					v4 = v3;
					if(data.FPEOGFMKMKJ_Point * score_upper_limit_magn < v3)
					{
						v4 = data.FPEOGFMKMKJ_Point * score_upper_limit_magn;
					}
				}
				data.FCLGIPFPIPH_DashBonus = _FCLGIPFPIPH_DashBonus;
				data.PIIEGNPOPJI_GetPoint = v4 * _LCCGDFGGIHI_PlayCount * _FCLGIPFPIPH_DashBonus;
				Debug.Log(string.Concat(new object[5]
				{
					JpStringLiterals.StringLiteral_10920,
					ebp.EEAPIKNJNDB_ConsecutiveWin + KAAGPOHNMBD,
					JpStringLiterals.StringLiteral_10916,
					dbSection.AFHHBNBCOKI[idx].DJJGNDCMNHF_BonusValue,
					" </color>"
				}));
				Debug.Log(JpStringLiterals.StringLiteral_10921 + data.PIIEGNPOPJI_GetPoint + " </color>");
			}
			else
			{
				data.BLAJKMAPEKP_CWin = 0;
				data.BOKPPBLPKEF = 100;
				int los_pnt_per = dbSection.LPJLEHAJADA_GetIntParam("los_pnt_per", 50);
				data.FPEOGFMKMKJ_Point = (data.FPEOGFMKMKJ_Point * los_pnt_per) / 100;
				data.FCLGIPFPIPH_DashBonus = _FCLGIPFPIPH_DashBonus;
				data.PIIEGNPOPJI_GetPoint = _LCCGDFGGIHI_PlayCount * _FCLGIPFPIPH_DashBonus * ((data.APEFEONDBKL_DiffBonus * ((data.GBLHPHCAPLG_ScoreBonus + data.FPEOGFMKMKJ_Point) * 10 * data.ODCLHPGHDHA_EpisodeBonus / 100))  / 1000); // ldivmod
				Debug.Log(JpStringLiterals.StringLiteral_10921 + data.PIIEGNPOPJI_GetPoint + " </color>");
			}
			data.ONLIMGFHGBH_ExPt = d.JMGCEEAJNFE_ExPoint;
			data.MBBPOOFCAKC_GetExGauge = _LCCGDFGGIHI_PlayCount * NJDPMDCIFBP_GetResultExPoint(IDBJPDBLIIG_ScoreResultRank, isWin);
			data.BOLHMCFBGBP_Idx = 0;
			if(data.MBBPOOFCAKC_GetExGauge < 1)
			{
				DCAKKIJODME data2 = new DCAKKIJODME();
				data2.KHEKNNFCAOI_Init(false);
				data.BOLHMCFBGBP_Idx = data2.AJBHLNMPIPD_GetIdxByMusicId(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
				data.KOOMDFGADKH_ExBattleWinBonus = 0;
				if(isWin)
				{
					data.KOOMDFGADKH_ExBattleWinBonus = d1.GCPKJPNENJJ_ExBns;
				}
				data.OOEKGFAIFPK_ExBattleMusicScore = ((data.KOOMDFGADKH_ExBattleWinBonus + data.GCAPLLEIAAI_LastScore) * 10) / 10;
				data.JCCABPBHJPA_ExHighScore = APAKCLNALIJ_GetExHighScore(data.BOLHMCFBGBP_Idx);
				data.FFHMPNGJCLK_NewRecord = data.JCCABPBHJPA_ExHighScore < data.OOEKGFAIFPK_ExBattleMusicScore;
				if(data.FFHMPNGJCLK_NewRecord)
				{
					data.JCCABPBHJPA_ExHighScore = data.OOEKGFAIFPK_ExBattleMusicScore;
					data.OEGDACKEDIB_ExBattleScoreAfter[data.BOLHMCFBGBP_Idx] = data.JCCABPBHJPA_ExHighScore;
				}
				int currentClassUnlocked = DAHNCPDEBDM_GetEvBltClassUnlocked();
				if(isWin && currentClassUnlocked > 0)
				{
					int lastClassForScore = CKBOGCKIMNN_GetLastClassForScore(data.OOEKGFAIFPK_ExBattleMusicScore);
					int lastClassUnlock;
					if(currentClassClamped < lastClassForScore)
					{
						lastClassUnlock = lastClassForScore + 1;
						if(lastClassAvailable < lastClassUnlock)
							lastClassUnlock = lastClassAvailable;
					}
					else
					{
						lastClassUnlock = currentClassUnlocked + ((currentClass < lastClassAvailable && currentClassClamped == currentClassUnlocked) ? 1 : 0);
						lastClassForScore = currentClassClamped;
					}
					PMFBBLGPLLJ data3 = new PMFBBLGPLLJ();
					data3.KHEKNNFCAOI_Init();
					if(!data3.KKCEHCKLDCI_HasEmblem(lastClassForScore))
					{
						if(!_IKGLAFOHGDO_TestOnly)
						{
							LGIBGKBHFML_SetClsu0(currentClassUnlocked);
							GPBOPPFAEGE_SetEvBltClassUnlocked(lastClassUnlock);
							data3.EBEKAEJHIJH_UnlockClassRange(1, lastClassForScore);
						}
						data.GBIGCJIKKPP_UnlockedClassAfter = lastClassUnlock;
					}
				}
				if(!_IKGLAFOHGDO_TestOnly)
				{
					d.PCNOCBANFOO_ExResult[data.BOLHMCFBGBP_Idx].JKAMFMNGEBB_high_score = data.JCCABPBHJPA_ExHighScore;
					data2.FNHNJNEJFLF(data.BOLHMCFBGBP_Idx, isWin);
				}
				OHLGODIKBIP = true;
				data.CINCDFAOEOJ_NewExPoint = 0;
				data.EGAMOPBCFKG_ExRival = false;
			}
			else
			{
				data.OOEKGFAIFPK_ExBattleMusicScore = 0;
				data.KOOMDFGADKH_ExBattleWinBonus = 0;
				OHLGODIKBIP = data.ONLIMGFHGBH_ExPt != AMDOCOMNNKN_GetExGaugePoinMax();
				data.EGAMOPBCFKG_ExRival = AMDOCOMNNKN_GetExGaugePoinMax() <= data.MBBPOOFCAKC_GetExGauge + d.JMGCEEAJNFE_ExPoint;
				data.CINCDFAOEOJ_NewExPoint = data.EGAMOPBCFKG_ExRival ? AMDOCOMNNKN_GetExGaugePoinMax() : data.MBBPOOFCAKC_GetExGauge + d.JMGCEEAJNFE_ExPoint;
			}
			if(!_IKGLAFOHGDO_TestOnly)
			{
				d.JMGCEEAJNFE_ExPoint = data.CINCDFAOEOJ_NewExPoint;
				d.NMPBIBEPLDO_ExRival = data.EGAMOPBCFKG_ExRival;
			}
			Debug.Log(string.Concat(JpStringLiterals.StringLiteral_10923, data.CINCDFAOEOJ_NewExPoint, " </color>"));
			if(data.EGAMOPBCFKG_ExRival)
			{
				Debug.Log(JpStringLiterals.StringLiteral_10924);
			}
			if(_IKGLAFOHGDO_TestOnly)
			{
				data.IGIPKOJJIIA_TotalScore = data.OEGDACKEDIB_ExBattleScoreAfter[1] + data.OEGDACKEDIB_ExBattleScoreAfter[0] + data.OEGDACKEDIB_ExBattleScoreAfter[2];
			}
			else
			{
				data.IGIPKOJJIIA_TotalScore = GFNODPDPNMJ_GetSumExHighScore();
			}
        }
	}

	// // RVA: 0x1B843F8 Offset: 0x1B843F8 VA: 0x1B843F8
	private int CKBOGCKIMNN_GetLastClassForScore(int _KNIFCANOHOC_score)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			int res = 1;
			for(int i = 0; i < dbSection.PMJLEPGCAOA_ClassDatas.Count; i++)
			{
				if(dbSection.PMJLEPGCAOA_ClassDatas[i].PLALNIIBLOF_en == 2)
				{
					if(dbSection.PMJLEPGCAOA_ClassDatas[i].AFKHNFBOMKI_sc <= _KNIFCANOHOC_score)
					{
						res = dbSection.PMJLEPGCAOA_ClassDatas[i].PPFNGGCBJKC_id;
					}
				}
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x1B846E4 Offset: 0x1B846E4 VA: 0x1B846E4
	private CCPKHBECNLH_EventBattle.BHIDLKBIJFK DEBLCKNIJMF()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0x1B84184 Offset: 0x1B84184 VA: 0x1B84184
	public int APAKCLNALIJ_GetExHighScore(int LDNMEOLIMAE)
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			if(LDNMEOLIMAE < d.PCNOCBANFOO_ExResult.Count)
			{
				return d.PCNOCBANFOO_ExResult[LDNMEOLIMAE].JKAMFMNGEBB_high_score;
			}
		}
		return 0;
	}

	// // RVA: 0x1B71CAC Offset: 0x1B71CAC VA: 0x1B71CAC
	public int GFNODPDPNMJ_GetSumExHighScore()
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			int res = 0;
			for(int i = 0; i < d.PCNOCBANFOO_ExResult.Count; i++)
			{
				res += d.PCNOCBANFOO_ExResult[i].JKAMFMNGEBB_high_score;
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x1B78EAC Offset: 0x1B78EAC VA: 0x1B78EAC
	public bool BOPJPPJNEOP_SetRvMc(int _HMFFHLPNMPH_count)
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			d.GBFAOCFOIIM_RvMc = _HMFFHLPNMPH_count;
			return true;
		}
		return false;
	}

	// // RVA: 0x1B84928 Offset: 0x1B84928 VA: 0x1B84928
	public int KOELJHLJKDJ_GetRvMc()
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			return d.GBFAOCFOIIM_RvMc;
		}
		return 0;
	}

	// // RVA: 0x1B8494C Offset: 0x1B8494C VA: 0x1B8494C
	public bool NGOLCKJKLEA_SetRvSt(int _BHCIFFILAKJ_Strength)
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			d.MNLJJDJHJPM_RvSt = _BHCIFFILAKJ_Strength;
		}
		return false;
	}

	// // RVA: 0x1B84980 Offset: 0x1B84980 VA: 0x1B84980
	public int JJOPCKDDAFA_GetRvSt()
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
			return d.MNLJJDJHJPM_RvSt;
		return 0;
	}

	// // RVA: 0x1B849A4 Offset: 0x1B849A4 VA: 0x1B849A4
	public void ECFNKBGDJCA(int LDNMEOLIMAE, int IILBFFKOBFI, int _IDBJPDBLIIG_ScoreResultRank)
	{
		DJDNFDBMGPG = LDNMEOLIMAE;
		JAPGCDAJACB = _IDBJPDBLIIG_ScoreResultRank;
		HCEGPMFOLPO_RivalIdx = IILBFFKOBFI;
		NGOLCKJKLEA_SetRvSt(_IDBJPDBLIIG_ScoreResultRank);
	}

	// // RVA: 0x1B849B8 Offset: 0x1B849B8 VA: 0x1B849B8
	public int MDBIEKEFNJG()
	{
		return DJDNFDBMGPG;
	}

	// // RVA: 0x1B849C0 Offset: 0x1B849C0 VA: 0x1B849C0
	public int DPPODNCOMIA_GetRivalIdx()
	{
		return HCEGPMFOLPO_RivalIdx;
	}

	// // RVA: 0x1B849C8 Offset: 0x1B849C8 VA: 0x1B849C8
	// public int IKAAEKACDEK() { }

	// // RVA: 0x1B849D0 Offset: 0x1B849D0 VA: 0x1B849D0
	public int EPEDBNKGNBP_GetRivalDivaId(int FJNLANODAJC)
	{
		return PIPHAKNMIBL_Rivals[FJNLANODAJC].DIPKCALNIII_diva_id;
	}

	// // RVA: 0x1B84A70 Offset: 0x1B84A70 VA: 0x1B84A70
	public int LCAGAFPFHJP_GetCurrentRivalDivaId()
	{
		return EPEDBNKGNBP_GetRivalDivaId(HCEGPMFOLPO_RivalIdx);
	}

	// // RVA: 0x1B84A78 Offset: 0x1B84A78 VA: 0x1B84A78
	// public int BKOAEFNLAJL(int FJNLANODAJC) { }

	// // RVA: 0x1B84B18 Offset: 0x1B84B18 VA: 0x1B84B18
	// public int IHFHHAMDIHL() { }

	// // RVA: 0x1B84B20 Offset: 0x1B84B20 VA: 0x1B84B20
	public bool DKIIPPCBDGM_SetExRv(bool _JKDJCFEBDHC_Enabled)
	{
        CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			d.NMPBIBEPLDO_ExRival = _JKDJCFEBDHC_Enabled;
			return true;
		}
        return false;
	}

	// // RVA: 0x1B77DD8 Offset: 0x1B77DD8 VA: 0x1B77DD8
	public bool GKDFMEKOOBF_IsExRival()
	{
        CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			return d.NMPBIBEPLDO_ExRival;
		}
		return false;
	}

	// // RVA: 0x1B84B54 Offset: 0x1B84B54 VA: 0x1B84B54
	// public bool JAOLLFBOEMF() { }

	// // RVA: 0x1B84B5C Offset: 0x1B84B5C VA: 0x1B84B5C
	public bool HHFIKFEGNPD_SetExPt(int _DNBFMLBNAEE_point)
	{
        CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			d.JMGCEEAJNFE_ExPoint = _DNBFMLBNAEE_point;
			return true;
		}
        return false;
	}

	// // RVA: 0x1B84B90 Offset: 0x1B84B90 VA: 0x1B84B90
	public int GGBNNMCLDMO_GetExPoint()
	{
        CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			return d.JMGCEEAJNFE_ExPoint;
		}
        return -1;
	}

	// // RVA: 0x1B84274 Offset: 0x1B84274 VA: 0x1B84274
	public int AMDOCOMNNKN_GetExGaugePoinMax()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.LPJLEHAJADA_GetIntParam("ex_gauge_point_max", 100);
		}
		return -1;
	}

	// // RVA: 0x1B76330 Offset: 0x1B76330 VA: 0x1B76330
	public int CJOBENJJCLD_GetLastAvailableClassId()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			for(int i = dbSection.PMJLEPGCAOA_ClassDatas.Count - 1; i >= 0; i--)
			{
				if(dbSection.PMJLEPGCAOA_ClassDatas[i].PLALNIIBLOF_en == 2)
				{
					return dbSection.PMJLEPGCAOA_ClassDatas[i].PPFNGGCBJKC_id;
				}
			}
		}
		return -1;
	}

	// // RVA: 0x1B84BB4 Offset: 0x1B84BB4 VA: 0x1B84BB4
	public bool PIKBPBCNIOD()
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null && HHFIKFEGNPD_SetExPt(0))
		{
			if(DKIIPPCBDGM_SetExRv(false))
			{
				if(NOCIPFMIMKL_SetCls(0))
				{
					d.LGADCGFMLLD_step = 3;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1B84C68 Offset: 0x1B84C68 VA: 0x1B84C68
	public bool HGCIBMLAAMI_SetClsAndResetExPoint(int _AIMCAJDBNOI_ClassId)
	{
		if(HHFIKFEGNPD_SetExPt(0) && DKIIPPCBDGM_SetExRv(false))
		{
			return NOCIPFMIMKL_SetCls(_AIMCAJDBNOI_ClassId);
		}
		return false;
	}

	// // RVA: 0x1B84C34 Offset: 0x1B84C34 VA: 0x1B84C34
	public bool NOCIPFMIMKL_SetCls(int _AIMCAJDBNOI_ClassId)
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			d.BINKCNFPHIP_Cls = _AIMCAJDBNOI_ClassId;
			return true;
		}
		return false;
	}

	// // RVA: 0x1B78EE0 Offset: 0x1B78EE0 VA: 0x1B78EE0
	public int KKMFHMGIIKN_GetCls()
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			return d.BINKCNFPHIP_Cls;
		}
		return -1;
	}

	// // RVA: 0x1B76654 Offset: 0x1B76654 VA: 0x1B76654
	public bool GPBOPPFAEGE_SetEvBltClassUnlocked(int _AIMCAJDBNOI_ClassId)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu = _AIMCAJDBNOI_ClassId;
			return true;
		}
		return false;
	}

	// // RVA: 0x1B76580 Offset: 0x1B76580 VA: 0x1B76580
	public int DAHNCPDEBDM_GetEvBltClassUnlocked()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu;
	}

	// // RVA: 0x1B84CB4 Offset: 0x1B84CB4 VA: 0x1B84CB4
	public int KDDELPFLCEB_GetClsu0()
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
			return d.LCPFENLEALH_Clsu0;
		return -1;
	}

	// // RVA: 0x1B84CD8 Offset: 0x1B84CD8 VA: 0x1B84CD8
	public bool LFBCNAAKHCK_ResetClsu0()
	{
		return LGIBGKBHFML_SetClsu0(0);
	}

	// // RVA: 0x1B846B0 Offset: 0x1B846B0 VA: 0x1B846B0
	public bool LGIBGKBHFML_SetClsu0(int _AIMCAJDBNOI_ClassId)
	{
		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = DEBLCKNIJMF();
		if(d != null)
		{
			d.LCPFENLEALH_Clsu0 = _AIMCAJDBNOI_ClassId;
			return true;
		}
		return false;
	}

	// // RVA: 0x1B84CE0 Offset: 0x1B84CE0 VA: 0x1B84CE0
	// public bool EHACHHNFGCO() { }

	// // RVA: 0x1B84D00 Offset: 0x1B84D00 VA: 0x1B84D00
	public int IECGGHJHJGB_GetClassEmblemId(int _AIMCAJDBNOI_ClassId)
	{
		if(_AIMCAJDBNOI_ClassId > 0)
		{
			DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
			if(db != null)
			{
				ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
				return dbSection.PMJLEPGCAOA_ClassDatas[_AIMCAJDBNOI_ClassId - 1].APGKOJKNNGP_EmblemId;
			}
		}
		return -1;
	}

	// // RVA: 0x1B84EC4 Offset: 0x1B84EC4 VA: 0x1B84EC4
	public int HEOGGKBILIA_GetCurrentClassEmblemId()
	{
		int cls = KKMFHMGIIKN_GetCls();
		if(cls > -1)
		{
			return IECGGHJHJGB_GetClassEmblemId(cls);
		}
		return -1;
	}

	// // RVA: 0x1B84EF4 Offset: 0x1B84EF4 VA: 0x1B84EF4
	private void OKPBJFAAOMG(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		int v1 = OMNOFMEBLAD.HCFGMNPMIHL_GetTotalStats();
		int tips_total_percent = BAEPGOAMBDK("tips_total_percent", 95);
		int tips_notes_percent = BAEPGOAMBDK("tips_notes_percent", 1);
		CKEDJHEFJCJ = 0;
		if(CKCPAMDDNPF.BLAJKMAPEKP_CWin == 0)
		{
			for(int i = 0; i < PIPHAKNMIBL_Rivals.Count; i++)
			{
				if(PIPHAKNMIBL_Rivals[i].GOIKCKHMBDL_FreeMusicId == OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId)
				{
					if(v1 < (PIPHAKNMIBL_Rivals[i].BDLNMOIOMHK_total * tips_total_percent) / 100)
					{
						CKEDJHEFJCJ = OLLEELKFCMM.NDBAPDFEPAF.OJEGJNOCCEA_1;
					}
					else
					{
						int v3 = 0;
						int v4 = 0;
						for(int j = 0; j < 5; j++)
						{
							if(j < 3)
							{
								v4 += OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[j];
							}
							v3 += OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[j];
						}
						if(((v3 * tips_notes_percent + 99) / 100) < v4)
						{
							CKEDJHEFJCJ = OLLEELKFCMM.NDBAPDFEPAF.HNICJFPHCNE_2;
						}
						else
						{
							if(OMNOFMEBLAD.AKNELONELJK_difficulty < PIPHAKNMIBL_Rivals[i].AKNELONELJK_difficulty)
							{
								CKEDJHEFJCJ = OLLEELKFCMM.NDBAPDFEPAF.CFEBHEEDKFP_3;
							}
							else
							{
								CKEDJHEFJCJ = OLLEELKFCMM.NDBAPDFEPAF.EBCGBOLPFPE_4;
							}
						}
					}
					return;
				}
			}
		}
	}

	// // RVA: 0x1B8522C Offset: 0x1B8522C VA: 0x1B8522C
	public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int _FCLGIPFPIPH_DashBonus, int _LCCGDFGGIHI_PlayCount, int _ANOPDAGJIKG_FriendSceneId, int MHADLGMJKGK, bool _IKGLAFOHGDO_TestOnly)
	{
		if(_IKGLAFOHGDO_TestOnly)
		{
			EBNMMCKCPKN(OMNOFMEBLAD, _FCLGIPFPIPH_DashBonus, _LCCGDFGGIHI_PlayCount, _ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK, true);
		}
		else
		{
			JPBPMFAGMEB(OMNOFMEBLAD);
			EBNMMCKCPKN(OMNOFMEBLAD, _FCLGIPFPIPH_DashBonus, _LCCGDFGGIHI_PlayCount, _ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK, false);
			OKPBJFAAOMG(OMNOFMEBLAD);
		}
	}

	// // RVA: 0x1B852CC Offset: 0x1B852CC VA: 0x1B852CC
	public void PACJFJGHADK_SetLastFreeMusicId(int _GOIKCKHMBDL_FreeMusicId)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			d.LFCCCLPFJMB_LastFId = _GOIKCKHMBDL_FreeMusicId;
		}
	}

	// // RVA: 0x1B8551C Offset: 0x1B8551C VA: 0x1B8551C
	public int KGIIPFJIAGB_GetPlayCost(int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return dbSection.NGHKJOEDLIP_Settings.GEDKCAODLMM_GetPlayCost(_AKNELONELJK_difficulty, _GIKLNODJKFK_IsLine6);
        }
		return 0;
	}

	// // RVA: 0x1B85774 Offset: 0x1B85774 VA: 0x1B85774 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x1B859D4 Offset: 0x1B859D4 VA: 0x1B859D4 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		string s = null;
		if(_INDDJNMPONH_type == 0)
		{
			s = JOPOPMLFINI_QuestName + "_rule";
		}
		if(string.IsNullOrEmpty(s))
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}
	}

	// // RVA: 0x1B85AFC Offset: 0x1B85AFC VA: 0x1B85AFC Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1B85C7C Offset: 0x1B85C7C VA: 0x1B85C7C Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1B85DFC Offset: 0x1B85DFC VA: 0x1B85DFC Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			if(BHABCGJCGNO != null)
			{
				if(LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
				{
            		CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != d.OMCAOJJGOGG_Lb)
					{
						d.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
                            EGOLBAPFHHD_Common.FKLHGOGJOHH it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
							it.BFINGCJHOHI_cnt += BHABCGJCGNO.MBJIFDBEDAC_item_count;
							it.BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, it.BFINGCJHOHI_cnt, 1);
                        }
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x1B865E4 Offset: 0x1B865E4 VA: 0x1B865E4 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		if(!MNNNLDFNNCD(_JHNMKKNEENE_Time))
			return null;
		return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(AGLLAPMBDIG_MusicList[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
	}

	// // RVA: 0x1B867D8 Offset: 0x1B867D8 VA: 0x1B867D8 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(AGLLAPMBDIG_MusicList[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
	}

	// // RVA: 0x1B86954 Offset: 0x1B86954 VA: 0x1B86954
	public CCPKHBECNLH_EventBattle.AIFGBKMMJGL JIPPHOKGLIH_GetMusicSaveData(int _GOIKCKHMBDL_FreeMusicId, bool HOENAFAJMGI/* = False*/)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			BBHNACPENDM_ServerSaveData data;
			if(HOENAFAJMGI)
			{
				data = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData;
			}
			else
			{
				data = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			}

            CCPKHBECNLH_EventBattle.BHIDLKBIJFK d = data.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            CCPKHBECNLH_EventBattle.AIFGBKMMJGL music = d.FFMHJIJBKEN_music.Find((CCPKHBECNLH_EventBattle.AIFGBKMMJGL _GHPLINIACBB_x) =>
			{
				//0x1B87DD0
				return _GHPLINIACBB_x.GOIKCKHMBDL_FreeMusicId == _GOIKCKHMBDL_FreeMusicId;
			});
			if(music == null)
			{
				music = d.FFMHJIJBKEN_music.Find((CCPKHBECNLH_EventBattle.AIFGBKMMJGL _GHPLINIACBB_x) =>
				{
					return _GHPLINIACBB_x.GOIKCKHMBDL_FreeMusicId == 0;
				});
			}
			return music;
        }
		return null;
	}

	// // RVA: 0x1B86DD0 Offset: 0x1B86DD0 VA: 0x1B86DD0 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].MDADLCOCEBN_session_id;
		}
		return null;
	}

	// // RVA: 0x1B87028 Offset: 0x1B87028 VA: 0x1B87028 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
			if(db != null)
			{
				ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].INLNJOGHLJE_Show &= 0x7ffffffb;
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0x1B872A4 Offset: 0x1B872A4 VA: 0x1B872A4 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		APMGOLOPLFP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJIBDCAIBIO_LuckCoef0;
		FBBDNLAMPMH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AMNBEMCJCHF_LuckCoef1;
	}

	// // RVA: 0x1B873B8 Offset: 0x1B873B8 VA: 0x1B873B8
	public bool IJGLLGDMDKK_SetScoreForStep(int _IOPHIHFOOEP_idx, int _AFKHNFBOMKI_sc)
	{
		if(_IOPHIHFOOEP_idx < 2 && _AFKHNFBOMKI_sc > -1)
		{
			PBIEALDEMLK_ScoreAtStep[_IOPHIHFOOEP_idx] = _AFKHNFBOMKI_sc ^ 0x69a8d;
			return true;
		}
		return false;
	}

	// // RVA: 0x1B81570 Offset: 0x1B81570 VA: 0x1B81570
	public int OMEAIMCDHOA_GetScoreForStep(int _IOPHIHFOOEP_idx)
	{
		return PBIEALDEMLK_ScoreAtStep[_IOPHIHFOOEP_idx] ^ 0x69a8d;
	}

	// // RVA: 0x1B8742C Offset: 0x1B8742C VA: 0x1B8742C
	public bool OMHGENLJFLK_HasWinStepBattle(int _IOPHIHFOOEP_idx, int BGGOCKNNFKO_CurrentTime, int MPHPFKDHCOC_TotalTime)
	{
		int score = OMEAIMCDHOA_GetScoreForStep(_IOPHIHFOOEP_idx);
		int score2 = _IOPHIHFOOEP_idx == 0 ? PIPHAKNMIBL_Rivals[HCEGPMFOLPO_RivalIdx].EDJMDDAGCEJ_Score1 : PIPHAKNMIBL_Rivals[HCEGPMFOLPO_RivalIdx].HEFPAIOLBAG_Score2;
		if(score2 == 0)
		{
			if(BGGOCKNNFKO_CurrentTime >= 1 && MPHPFKDHCOC_TotalTime >= 1)
			{
				score2 = (PIPHAKNMIBL_Rivals[HCEGPMFOLPO_RivalIdx].KNIFCANOHOC_score * BGGOCKNNFKO_CurrentTime) / MPHPFKDHCOC_TotalTime;
			}
			else
			{
				score2 = (PIPHAKNMIBL_Rivals[HCEGPMFOLPO_RivalIdx].KNIFCANOHOC_score * (_IOPHIHFOOEP_idx != 0 ? 8 : 4)) / 10;
			}
		}
		return score2 <= score;
	}

	// // RVA: 0x1B875DC Offset: 0x1B875DC VA: 0x1B875DC Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < dbSection.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= dbSection.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at)
				{
					if(t <= dbSection.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at)
					{
						return dbSection.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_description;
					}
				}
			}
		}
		return "";
	}

	// // RVA: 0x1B87958 Offset: 0x1B87958 VA: 0x1B87958 Slot: 78
	public override long OEGAJJANHGL()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
			return dbSection.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate;
		}
		return 0;
	}
}
