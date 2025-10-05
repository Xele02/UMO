
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class NHDJHOPLMDE
{
	private int FBGGEFFJJHB_xor; // 0x8
	private long BBEGLBMOBOF_xorl; // 0x10
	private int IFGMKBKBFJI_ValkyrieIdCrypted; // 0x18
	private int HCFNIMFOOPF_SkillIdCrypted; // 0x1C
	private int FMFMCBKHIMK; // 0x20
	private int NFCALENBIBL_LevelCrypted; // 0x24
	private int ILHCNHLCELO_SkillLevelCrypted; // 0x28
	private int LIELJCECBNF; // 0x2C
	private int ICLBAMBDKNI; // 0x30
	private int AMFILEGKAML; // 0x34
	private int KIDNEIEHOMN_AtkCrypted; // 0x38
	private int CDDLNKAPCFB_HitCrypted; // 0x3C
	private int EOBFILHOOOD; // 0x40
	private NNJFKLBPBNK_SecureString FINCFIGKHPA_Name = new NNJFKLBPBNK_SecureString(); // 0x44
	private NNJFKLBPBNK_SecureString PMKLGDOEFNM_Desc_ = new NNJFKLBPBNK_SecureString(); // 0x48

	public int GPPEFLKGGGJ_ValkyrieId { get { return IFGMKBKBFJI_ValkyrieIdCrypted ^ FBGGEFFJJHB_xor; } set { IFGMKBKBFJI_ValkyrieIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18903D0 PCDKIHHDCHI_bgs 0x18903E0 LANEIFNCIAA_bgs
	public int ENMAEBJGEKL_SkillId { get { return HCFNIMFOOPF_SkillIdCrypted ^ FBGGEFFJJHB_xor; } set { HCFNIMFOOPF_SkillIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18903F0 FHIMMFAEDIP_bgs 0x1890400 CPEAMPGOMCB_bgs
	public int BHGDALFOHBL { get { return FMFMCBKHIMK ^ FBGGEFFJJHB_xor; } set { FMFMCBKHIMK = value ^ FBGGEFFJJHB_xor; } } //0x1890410 BBKOELBDLNH_bgs 0x1890420 FHKMBENCBKA_bgs
	public int CIEOBFIIPLD_Level { get { return NFCALENBIBL_LevelCrypted ^ FBGGEFFJJHB_xor; } set { NFCALENBIBL_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1890430 OGKGFGMKPKB_bgs 0x1890440 JOOMBHHPHBD_bgs
	public int NBLBJCLIDNN_MaxLevel { get { return ILHCNHLCELO_SkillLevelCrypted ^ FBGGEFFJJHB_xor; } set { ILHCNHLCELO_SkillLevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1890450 EKBBCGCNPMH_bgs 0x1890460 OJCHLBPANDN_bgs
	public int MMODCBJCDMA { get { return LIELJCECBNF ^ FBGGEFFJJHB_xor; } set { LIELJCECBNF = value ^ FBGGEFFJJHB_xor; } } //0x1890470 IGCKEGMPEHD_bgs 0x1890480 MNGLKCNIHNO_bgs
	public int KINFGHHNFCF_Atk { get { return KIDNEIEHOMN_AtkCrypted ^ FBGGEFFJJHB_xor; } set { KIDNEIEHOMN_AtkCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1890490 BNLKPIIJCDF_bgs 0x18904A0 PKEDNGJNJNC_bgs
	public int NONBCCLGBAO_hit { get { return CDDLNKAPCFB_HitCrypted ^ FBGGEFFJJHB_xor; } set { CDDLNKAPCFB_HitCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18904B0 AEJBEGKBPCO_get_hit 0x18904C0 JPIBPFANBNG_set_hit
	public int EHMLAAHLNMN_GreatSuccessRatio { get { return EOBFILHOOOD ^ FBGGEFFJJHB_xor; } set { EOBFILHOOOD = value ^ FBGGEFFJJHB_xor; } } //0x18904D0 MGFAGEDCCHM_bgs 0x18904E0 HBNAGHBGHMH_bgs
	public string OPFGFINHFCE_name { get { return FINCFIGKHPA_Name.DNJEJEANJGL_Value; } set { FINCFIGKHPA_Name.DNJEJEANJGL_Value = value; } } //0x18904F0 DKJOHDGOIJE_get_name 0x189051C MJAMIGECMMF_set_name
	// Skill Desc
	public string KLMPFGOCBHC_description { get { return PMKLGDOEFNM_Desc_.DNJEJEANJGL_Value; } set { PMKLGDOEFNM_Desc_.DNJEJEANJGL_Value = value; } } //0x1890550 BGJNIABLBDB_get_description 0x189057C HFBJLALGKOM_set_description
	public EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition CHOFDPDFPDC_ConfigValue { get { return (EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition)(ICLBAMBDKNI ^ FBGGEFFJJHB_xor); } set { ICLBAMBDKNI = (int)value ^ FBGGEFFJJHB_xor; } } //0x18905B0 IBCDKHDLOKG_bgs 0x18905C0 ICHJGBKDCGM_bgs
	public EPIFHEDDJAE.NGEDJNHECKN_AbilityType EICJJFIBCEF { get { return (EPIFHEDDJAE.NGEDJNHECKN_AbilityType)(AMFILEGKAML ^ FBGGEFFJJHB_xor); } set { AMFILEGKAML = (int)value ^ FBGGEFFJJHB_xor; } } //0x18905D0 LLBFBCBNLLA_bgs 0x18905E0 AGEJCMNBHJJ_bgs

	//// RVA: 0x18905F0 Offset: 0x18905F0 VA: 0x18905F0
	public NHDJHOPLMDE(int _LLOBHDMHJIG_Id, int _ANAJIAENLNB_lv/* = 0*/)
	{
		if(_LLOBHDMHJIG_Id > 0)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
				{
					JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK_Get(_LLOBHDMHJIG_Id);
					if (dbInfo != null && dbInfo.PPEGAKEIEGM_Enabled == 2)
					{
						GKFMJAHKEMA_ValSkill.CCPFGNNIBDD info1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(dbInfo.BMIJDLBGFNP_skill);
						if (info1 != null)
						{
							GKFMJAHKEMA_ValSkill.GBDONNIHJHG info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.OOEFAGKHOCE(info1.KFLIHDFDBOA);
							if(info2 != null)
							{
								GPPEFLKGGGJ_ValkyrieId = _LLOBHDMHJIG_Id;
								ENMAEBJGEKL_SkillId = dbInfo.BMIJDLBGFNP_skill;
								BHGDALFOHBL = info1.KFLIHDFDBOA;
								EICJJFIBCEF = (EPIFHEDDJAE.NGEDJNHECKN_AbilityType)info2.CBDFEJIBAMO;
								CHOFDPDFPDC_ConfigValue = (EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition)info2.ODMJFHDIGLP_cnd;
								OPFGFINHFCE_name = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_nm_"+ info2.CBDFEJIBAMO.ToString("D4"));
								KLMPFGOCBHC_description = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_dsc_" + info1.KFLIHDFDBOA.ToString("D4"));
								NBLBJCLIDNN_MaxLevel = info1.DOOGFEGEKLG_max;
								int skill_level_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.LPJLEHAJADA_GetIntParam("skill_level_max", 4);
								if (skill_level_max < NBLBJCLIDNN_MaxLevel)
									NBLBJCLIDNN_MaxLevel = skill_level_max;
								if(_ANAJIAENLNB_lv < 1)
								{
									_ANAJIAENLNB_lv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId);
								}
								CIEOBFIIPLD_Level = NBLBJCLIDNN_MaxLevel;
								if (_ANAJIAENLNB_lv <= NBLBJCLIDNN_MaxLevel)
								{
									CIEOBFIIPLD_Level = _ANAJIAENLNB_lv;
								}
								int val = MMODCBJCDMA;
								if (CIEOBFIIPLD_Level >= 1)
								{
									MMODCBJCDMA = info2.NBMPBLECFJD(CIEOBFIIPLD_Level - 1);
								}
								if(MMODCBJCDMA > 0)
								{
									List<EPIFHEDDJAE.JAOBCBKBKJJ> l = new List<EPIFHEDDJAE.JAOBCBKBKJJ>();
									l.Add((EPIFHEDDJAE.JAOBCBKBKJJ)info2.PFBDNFPPNEJ);
									l.Add((EPIFHEDDJAE.JAOBCBKBKJJ)info2.GAMEFFJONIJ);
									for(int i = 0; i < l.Count; i++)
									{
										if(l[i] == EPIFHEDDJAE.JAOBCBKBKJJ.FIFJJFPHOEM_3_GreatSuccessRatio)
										{
											EHMLAAHLNMN_GreatSuccessRatio = MMODCBJCDMA;
										}
										else if(l[i] == EPIFHEDDJAE.JAOBCBKBKJJ.JIOPJDJBLFK_2_Hit)
										{
											NONBCCLGBAO_hit = MMODCBJCDMA;
										}
										else if(l[i] == EPIFHEDDJAE.JAOBCBKBKJJ.FMHLGHDKJBC_1_Atk)
										{
											KINFGHHNFCF_Atk = MMODCBJCDMA;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	//// RVA: 0x1890C5C Offset: 0x1890C5C VA: 0x1890C5C
	//public void LHPDDGIJKNB_Reset() { }

	//// RVA: 0x1890D3C Offset: 0x1890D3C VA: 0x1890D3C
	//public string DMBDNIEEMCB_GetDesc() { }

	//// RVA: 0x1890D88 Offset: 0x1890D88 VA: 0x1890D88
	public bool LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN_AbilityType CNLDPKNLBND, EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition _OAFPGJLCNFM_cond)
	{
		if (EICJJFIBCEF != CNLDPKNLBND)
			return false;
		if(CNLDPKNLBND == EPIFHEDDJAE.NGEDJNHECKN_AbilityType.FJFMLFPJKNB_2_ValkPosition)
		{
			if(CHOFDPDFPDC_ConfigValue == EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.PPNNBADDNKB_11_NonLeader)
			{
				if(_OAFPGJLCNFM_cond > EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12_Leader)
				{
					return false;
				}
			}
			else if(CHOFDPDFPDC_ConfigValue == EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12_Leader && _OAFPGJLCNFM_cond != EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12_Leader)
			{
				return false;
			}
		}
		else if(CNLDPKNLBND == EPIFHEDDJAE.NGEDJNHECKN_AbilityType.MGJDKBFHDML_1_MusicSelect && CHOFDPDFPDC_ConfigValue != _OAFPGJLCNFM_cond)
		{
			return false;
		}
		return CIEOBFIIPLD_Level > 0;
	}

	//// RVA: 0x1890E18 Offset: 0x1890E18 VA: 0x1890E18
	public bool LAKLFHGMCLI(SeriesAttr.Type _AIHCEGFANAM_SerieAttr)
	{
		bool res = false;
		if(EICJJFIBCEF == EPIFHEDDJAE.NGEDJNHECKN_AbilityType.MGJDKBFHDML_1_MusicSelect/*1*/)
		{
			res = false;
			int v = (int)CHOFDPDFPDC_ConfigValue;
			if ((v - 1) > 4)
				v = 0;
			if (v == (int)_AIHCEGFANAM_SerieAttr && CIEOBFIIPLD_Level > 0)
				res = true;
		}
		return res;
	}
}
