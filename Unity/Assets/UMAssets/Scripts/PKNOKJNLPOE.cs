
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public class KAMKMOKMPAN
{
	public enum GGPEAOAOEPH_Step
	{
		HJNNKCMLGFL_0_None = 0,
		LAOEGNLOJHC_1_Start = 1,
		CNLOFIHPBMP_2_Matched = 2,
		OLDDILMKJND_3_GameStart = 3,
		BFIOFNKPOFB_4_Clear = 4,
		OLCLJKOKJCD_5_End = 5,
	}

}

[System.Obsolete("Use PKNOKJNLPOE_EventRaid", true)]
public class PKNOKJNLPOE { }
public class PKNOKJNLPOE_EventRaid : IKDICBBFBMI_EventBase
{
	public enum PGNNLIJLPFO
	{
		FNGAOJCJFJP_0_None = 0,
		AGOIOHHOPFM = 1,
		MOIGPCPOIOO = 2,
		FHCJCJIFKHL = 3,
		PNFCFJLEDEE = 4,
	}

	public class OCBPJEALCPO
	{
		public bool BBIGDCNEFMK; // 0x8
		public NHCDBBBMFFG_BossStatus CMCKNKKCNDK_status; // 0xC
		public int GKHMIECGPJO_HpAfter; // 0x10
		public int OGHIOGDPFJE_MaxHp; // 0x14
		public int FCIBJNKGMOB_Damage; // 0x18
		public int AEIMNLACMFA_Damage; // 0x1C
		public int HMNOKOEJDND_Rank; // 0x20
		public int JKLNANHPJLO_ScorePoint; // 0x24
		public int CBKFBBNPIGG_ValkyriePoint; // 0x28
		public int EAOCJMFLBJI_PointBonus; // 0x2C
		public int FOOCMHPJJAP_DivaBonus; // 0x30
		public int CLNPBIJBIIJ_SupportBonus; // 0x34
		public int HACIJLMFDAE_TotalPoint; // 0x38
		public int HALIDDHLNEG_Damage; // 0x3C
		public bool PAACIPCHDDE_MissionCompleted; // 0x40
		public RhythmGameConsts.ResultComboType LCOHGOIDMDF_ComboRank; // 0x44
		public int ADHMMMEOJMK_FreeMusicId; // 0x48
		public int AKNELONELJK_difficulty; // 0x4C
		public bool GIKLNODJKFK_IsLine6; // 0x50
		public int OIOPCIAGLEK_CannonBaseValue; // 0x54
		public int IHIJGIHNOAL_CannonGaugeAdd; // 0x58
		public int LFOPOHHEODG_ChargeBonus; // 0x5C
		public bool DKKJPLALNFD_Skip; // 0x60

		public int NPPEPJHBPNE_CannonGauge { get { return Mathf.Min(IHIJGIHNOAL_CannonGaugeAdd + OIOPCIAGLEK_CannonBaseValue, 100); } } //0xFE79F0 LIBFGNGACKC_bgs
		public bool FIMNHOIJBLO { get { return CMCKNKKCNDK_status == NHCDBBBMFFG_BossStatus.HJNNKCMLGFL_0_None; } } //0xFE7A80 HDHHANHDMDP_bgs

		// // RVA: 0xFE7A94 Offset: 0xFE7A94 VA: 0xFE7A94
		// public void LHPDDGIJKNB_Reset() { }

		// // RVA: 0xFE7ACC Offset: 0xFE7ACC VA: 0xFE7ACC
		public int HJBBJIOOHAI(int FKMPFOHNPPH, int BJLHPJDKBNE)
		{
            return (int)(((long)BJLHPJDKBNE * FKMPFOHNPPH) / 1000);
        }

		// // RVA: 0xFE7AE8 Offset: 0xFE7AE8 VA: 0xFE7AE8
		public void DEHCKHMIENO(int _FNAEGLFKDBI_div)
		{
            HACIJLMFDAE_TotalPoint = (int)(((long)EAOCJMFLBJI_PointBonus + FOOCMHPJJAP_DivaBonus + CLNPBIJBIIJ_SupportBonus + 100) * (CBKFBBNPIGG_ValkyriePoint + JKLNANHPJLO_ScorePoint) / 100);
            HALIDDHLNEG_Damage = HACIJLMFDAE_TotalPoint / _FNAEGLFKDBI_div;
        }
	}

	public class KJJDLBFDGDM
	{
		public class EGMFNKCKOLB
		{
			public int PPFNGGCBJKC_id; // 0x8
			public int HMFFHLPNMPH_count; // 0xC
		}
		
		public class DPAGNOHCPPH : EGMFNKCKOLB
		{
			public float ADKDHKMPMHP_rate; // 0x10
			public bool POACKFONCAH_IsPickup; // 0x14
		}

		public List<EGMFNKCKOLB> NEAPOLIIELG_MvpRewards = new List<EGMFNKCKOLB>(); // 0x8
		public List<EGMFNKCKOLB> JAGJOLBDBDK_FirstRewards = new List<EGMFNKCKOLB>(); // 0xC
		public List<EGMFNKCKOLB> FGNHJFLBMIE_DefeatRewards = new List<EGMFNKCKOLB>(); // 0x10
		private const int CKIBIEKCKOJ = 16;
	}

	public class AAMIMFNBLKP
	{
		public int ILELGGCCGMJ_UtaGrade; // 0x8
		public int EJGDHAENIDC_BossRank; // 0xC
		public int LCJGEMENAFM_DefeatRewardCount; // 0x10
		public int LBEGGOOHIFM_FirstRewardCount; // 0x14
		public int NOLBNKAJANK_MvpRewardCount; // 0x18
		public int DFCBKNLAFIM_DefeatSpRewardCount; // 0x1C
		public int GEKJGFHKGEP_FirstSpRewardCount; // 0x20
		public int PNHCJNAJPEM_MvpRewardCount; // 0x24
	}

	public enum BKKPEJEABJN
	{
		AOFLHCJEDOA_0 = 0,
		LIFLDNIHBAK_1 = 1,
	}

	public class KMFKFGEDPGJ
	{
		public BKKPEJEABJN INDDJNMPONH_type; // 0x8
		public string LBODHBDOMGK_PlayerName; // 0xC
		public int MLPEHNBNOGD_PlayerId; // 0x10
		public int GBJFCGOBHDO_NewAttackCount; // 0x14
		public int IOMHJCBMADB_AddedCanonPercent; // 0x18

		// public bool DNJGAJPIIPI_IsValid { get; } 0xFE6B50 GALFPKKIGBH_bgs

		// // RVA: 0xFE6B40 Offset: 0xFE6B40 VA: 0xFE6B40
		// public void LHPDDGIJKNB_Reset() { }
	}

	public class MOAICCAOMCP
	{
		public class AAALCKPHGNG
		{
			public CKFGMNAIBNG IFGEJDMMAHE_Info; // 0x8
			public bool NFAPNIKALBK_Active; // 0xC
			private int PEBHLFLDIGC_Crypted; // 0x10

			public int DJJGNDCMNHF_BonusValue { get { return PEBHLFLDIGC_Crypted ^ 0x147bae1; } set { PEBHLFLDIGC_Crypted = value ^ 0x147bae1; } } //0xFE7888 GEPCOAPEAJM_get_BonusValue 0xFE7980 MIFJBBAJAJP_set_BonusValue
		}

		public class LNKNJHEFBCE
		{
			public PNGOLKLFFLH IFGEJDMMAHE_Info; // 0x8
			public bool NFAPNIKALBK_Active; // 0xC
			private int PEBHLFLDIGC_Crypted; // 0x10

			public int DJJGNDCMNHF_BonusValue { get { return PEBHLFLDIGC_Crypted ^ 0x147bae1; } set { PEBHLFLDIGC_Crypted = value ^ 0x147bae1; } } //0xFE79C0 GEPCOAPEAJM_get_BonusValue 0xFE79D4 MIFJBBAJAJP_set_BonusValue
		}

		public class JMMIEPDLLEL
		{
			public GCIJNCFDNON_SceneInfo IFGEJDMMAHE_Info; // 0x8
			public bool NFAPNIKALBK_Active; // 0xC
		}

		public class ELAIDDICLCD
		{
			public int PPFNGGCBJKC_id; // 0x8
			public string OPFGFINHFCE_name; // 0xC
			private int PEBHLFLDIGC_Crypted; // 0x10
			public bool COHCODJHJFM; // 0x14

			public int DJJGNDCMNHF_BonusValue { get { return PEBHLFLDIGC_Crypted ^ 0x147bae1; } set { PEBHLFLDIGC_Crypted = value ^ 0x147bae1; } } //0xFE789C GEPCOAPEAJM_get_BonusValue 0xFE799C MIFJBBAJAJP_set_BonusValue
		}

		public const int CMDHDDPFCIC = 3;
		public const int NEFDMMPNGON = 3;
		public const int PABEAPABKGC = 4;
		public List<AAALCKPHGNG> FABAGMLEKIB_CostumeList = new List<AAALCKPHGNG>(); // 0x8
		public List<LNKNJHEFBCE> CNGNBKNBKGI_ValkList = new List<LNKNJHEFBCE>(); // 0xC
		public List<ELAIDDICLCD> BBAJKJPKOHD_EpisodeList = new List<ELAIDDICLCD>(); // 0x10
		public CIKHPBBNEIM MBPCEBPHOBB = new CIKHPBBNEIM(); // 0x14
		private CEBFFLDKAEC_SecureInt JGAOBPPCFMN = new CEBFFLDKAEC_SecureInt(); // 0x18
		private CEBFFLDKAEC_SecureInt OFKKFNKMGEB = new CEBFFLDKAEC_SecureInt(); // 0x1C
		private CEBFFLDKAEC_SecureInt MNJLHBNAFKA = new CEBFFLDKAEC_SecureInt(); // 0x20
		private CEBFFLDKAEC_SecureInt HDKPOAIAAGP = new CEBFFLDKAEC_SecureInt(); // 0x24

		public int HAAMKDOMDAB_UnitBonusCostume { get { return JGAOBPPCFMN.DNJEJEANJGL_Value; } set { JGAOBPPCFMN.DNJEJEANJGL_Value = value; } } //0xFE6FBC PEINACDLIFF_bgs 0xFE6FE8 HNFEAMAHDIN_bgs
		public int KMEDEGMLEBF_UnitBonusValkyrie { get { return OFKKFNKMGEB.DNJEJEANJGL_Value; } set { OFKKFNKMGEB.DNJEJEANJGL_Value = value; } } //0xFE701C AODNLPBDJDF_bgs 0xFE7048 ANLAFIAAGJB_bgs
		public int LHPJLNGEFEL_UnitBonusEpisode { get { return MNJLHBNAFKA.DNJEJEANJGL_Value; } set { MNJLHBNAFKA.DNJEJEANJGL_Value = value; } } //0xFE707C BHKOMDIMFAF_bgs 0xFE70A8 JKPMLBAMLMH_bgs
		public int HOJAKNJFIFJ_EpisodeBonusPoint { get { return HDKPOAIAAGP.DNJEJEANJGL_Value; } set { HDKPOAIAAGP.DNJEJEANJGL_Value = value; } } //0xFE70DC MNEFIFBALEK_bgs 0xFE7108 IFNCEGFBKMP_bgs
		// public bool BNKABLIKGHL { get; } 0xFE73F0 DOBKDJONDGO_bgs
		public bool NPKCFPMFJOB { get 
		{
			for(int i = 0; i < CNGNBKNBKGI_ValkList.Count; i++)
			{
				if(CNGNBKNBKGI_ValkList[i].NFAPNIKALBK_Active)
                    return true;
            }
			return false;
		} } //0xFE74D4 PLOKLEEGOLO_bgs

		// RVA: 0xFE713C Offset: 0xFE713C VA: 0xFE713C
		public MOAICCAOMCP()
		{
			int v = (int)Utility.GetCurrentUnixTime() ^ 0x4341672;
			int v2 = (int)Utility.GetCurrentUnixTime() ^ 0x1288931;
			JGAOBPPCFMN.LHPDDGIJKNB_Reset(v, v2);
			OFKKFNKMGEB.LHPDDGIJKNB_Reset(v, v2);
			MNJLHBNAFKA.LHPDDGIJKNB_Reset(v, v2);
			HDKPOAIAAGP.LHPDDGIJKNB_Reset(v, v2);
			HAAMKDOMDAB_UnitBonusCostume = 0;
			KMEDEGMLEBF_UnitBonusValkyrie = 0;
			LHPJLNGEFEL_UnitBonusEpisode = 0;
			HOJAKNJFIFJ_EpisodeBonusPoint = 0;
		}

		// // RVA: 0xFE75B8 Offset: 0xFE75B8 VA: 0xFE75B8
		public void BMPJJJHAMID()
		{
            HOJAKNJFIFJ_EpisodeBonusPoint = 0;
            int t = 0;
			for(int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
			{
				if(FABAGMLEKIB_CostumeList[i].NFAPNIKALBK_Active)
				{
                    t = Mathf.Max(t, FABAGMLEKIB_CostumeList[i].DJJGNDCMNHF_BonusValue);
                }
			}
            HOJAKNJFIFJ_EpisodeBonusPoint += t;
			if(NPKCFPMFJOB)
			{
                HOJAKNJFIFJ_EpisodeBonusPoint += KMEDEGMLEBF_UnitBonusValkyrie;
            }
            for (int i = 0; i < BBAJKJPKOHD_EpisodeList.Count; i++)
			{
				if(BBAJKJPKOHD_EpisodeList[i].COHCODJHJFM)
				{
                    HOJAKNJFIFJ_EpisodeBonusPoint += BBAJKJPKOHD_EpisodeList[i].DJJGNDCMNHF_BonusValue;
                }
			}
        }

		// // RVA: 0xFE78B0 Offset: 0xFE78B0 VA: 0xFE78B0
		public void EPPENPBAJPH()
		{
            FABAGMLEKIB_CostumeList.Clear();
            CNGNBKNBKGI_ValkList.Clear();
            BBAJKJPKOHD_EpisodeList.Clear();
        }
	}

	public class FCDIHBGEKOB : IBIGBMDANNM
	{
		public int OFHFGHJEKKL; // 0x48
		public int HIMMCGKKOOL_Rate; // 0x4C

		// public int OMAGKBNHPHK { get; } 0xFE67D4 LCHNGLCHGJI_bgs
		// public int AMLMPPMBBOJ { get; } 0xFE6820 CMKEFNLIAOO_bgs
		// public int HKNHBBBLFDP { get; } 0xFE686C AMNOOLFLOBH_bgs
		// public int BFNFBOOHJCK { get; } 0xFE68B8 BJCKGODILOJ_bgs
		// public int HENMLBOMHBN { get; } 0xFE6904 LNKHHCAIOAF_bgs
		// public int DLHFIMFILEE { get; } 0xFE6970 ENCEBJOGOMP_bgs
		// public int LMJKGGFEFJJ { get; } 0xFE69EC NNGJOAKDEJE_bgs
	}

	public class MJFMOPMOFDJ : FCDIHBGEKOB
	{
		public class CALIFIMGGMD : FCDIHBGEKOB
		{
			public int HALIDDHLNEG_Damage; // 0x50
			public new int FJOLNJLLJEJ_rank; // 0x54
		}

		private const int JFMBNPLPAOB = 5;
		public int PPFNGGCBJKC_id; // 0x50
		public string MMEBLOIJBKE_UniqueKey; // 0x54
		public int BCCOMAODPJI_hp; // 0x58
		public int PIKKHCGNGNN_HpMax; // 0x5C
		public NHCDBBBMFFG_BossStatus CMCKNKKCNDK_status; // 0x60
		public int MHABJOMJCFI_AttackPlayerCount; // 0x64
		public long AJCCONCCIMF_EscapeAt; // 0x68
		public int ANAJIAENLNB_lv; // 0x70
		public int INDDJNMPONH_type; // 0x74
		public int HPPDFBKEJCG_BgId; // 0x78
		public new int FJOLNJLLJEJ_rank; // 0x7C
		public bool IKICLMGFFPB_IsSpecial; // 0x80
		public bool DLMNFENNCJG_HasAttacked; // 0x81
		public bool CAKONDPGDIL_CanRequestHelp; // 0x82
		public bool ICCOOAAJEIN_CanReceiveReward; // 0x83
		private int[] FDAPMJJKNKG_MyAttackCountByType; // 0x84
		private int[] HNEPPPIEJAD_OtherAttackCountByType; // 0x88
		public int OGLLKABGMCP_LastUpdatedPlayerId; // 0x8C
		private CEBFFLDKAEC_SecureInt OMAGOLHJBDB = new CEBFFLDKAEC_SecureInt(); // 0x90
		public string BLFHMNHMDHF_Mission; // 0x94
		public string CJLHLKKNMEE_MissionText; // 0x98
		public int NFOOOBMJINC_MissionBonusNum; // 0x9C
		public int JOMGCCBFKEF_MissionId; // 0xA0
		private List<CALIFIMGGMD> PIGIFFAHFCI = new List<CALIFIMGGMD>(); // 0xA4

		public int CLNPBIJBIIJ_SupportBonus { get { return OMAGOLHJBDB.DNJEJEANJGL_Value; } set { OMAGOLHJBDB.DNJEJEANJGL_Value = value; } } //0xFE6B64 BEGALDANEBB_bgs 0xFE6B90 ODBEDHFDCCE_bgs
		public bool DNJGAJPIIPI_IsValid { get { return PPFNGGCBJKC_id > 0; } } //0xFE6BC4 GALFPKKIGBH_bgs
		public int GCKGHNBHOPH_Rank { get; set; } // 0xA8 MABIMNPOAKL_bgs FODAJFNKMBJ_bgs BPPKEMEMLFN_bgs
		public int AEGFDINOACE_PlayerDamage { get; set; } // 0xAC FHEKPHOCOGA_bgs CCDBHBFKPEB_bgs FKFKCKOCBGA_bgs
		// public bool HIJGICMMECD { get; } 0xFE6D88 GHOEIAKFGIG_bgs
		public int IBGEJLJIAFD { get { return PIGIFFAHFCI.Count; } } //0xFE6E10 CJGBMDBLCII_bgs
		public CALIFIMGGMD BBMPCFEMDDC { get; set; } // 0xB0 AFEMAONMFDD_bgs JINDDLBIHMA_bgs ODAOJCBCLPA_bgs
		public CALIFIMGGMD NBBMHALJCMK_FirstAttackPlayer { get; set; } // 0xB4 OKELJHOGFCO_bgs CHLPJPOIINJ_bgs FGPBGLIAGHF_bgs

		// RVA: 0xFD8330 Offset: 0xFD8330 VA: 0xFD8330
		public MJFMOPMOFDJ()
		{
			OMAGOLHJBDB.LHPDDGIJKNB_Reset((int)Utility.GetCurrentUnixTime() ^ 0x8756217, (int)Utility.GetCurrentUnixTime() ^ 0x3115581);
			CLNPBIJBIIJ_SupportBonus = 0;
		}

		// // RVA: 0xFD6A90 Offset: 0xFD6A90 VA: 0xFD6A90
		public void LHPDDGIJKNB_Reset()
		{
			ANAJIAENLNB_lv = 0;
			INDDJNMPONH_type = 1;
			HPPDFBKEJCG_BgId = 1;
			FJOLNJLLJEJ_rank = 0;
			IKICLMGFFPB_IsSpecial = false;
			DLMNFENNCJG_HasAttacked = false;
			CAKONDPGDIL_CanRequestHelp = false;
			ICCOOAAJEIN_CanReceiveReward = false;
			CMCKNKKCNDK_status = NHCDBBBMFFG_BossStatus.HJNNKCMLGFL_0_None;
			MHABJOMJCFI_AttackPlayerCount = 0;
			AJCCONCCIMF_EscapeAt = 0;
			PPFNGGCBJKC_id = 0;
			MMEBLOIJBKE_UniqueKey = null;
			BCCOMAODPJI_hp = 0;
			PIKKHCGNGNN_HpMax = 0;
			MLPEHNBNOGD_PlayerId = 0;
			PIPOJJGBGLB();
			OMAGOLHJBDB.DNBGDMBCLMI_ChangeKey();
		}

		// // RVA: 0xFE6BD8 Offset: 0xFE6BD8 VA: 0xFE6BD8
		public long OCFJGNPMJBA_GetTime()
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			return AJCCONCCIMF_EscapeAt - t;
		}

		// // RVA: -1 Offset: -1
		public void EMHHJNDOCMB<EffectInfoClass>(List<EffectInfoClass> OEDHCKELBJK) where EffectInfoClass : EBHIMFFJBIJ
		{
			FDAPMJJKNKG_MyAttackCountByType = new int[4];
			HNEPPPIEJAD_OtherAttackCountByType = new int[4];
			long v = 0;
			for(int i= 0; i < OEDHCKELBJK.Count; i++)
			{
				if(OEDHCKELBJK[i].MCJEIDPDMLF_EffectId < 5)
				{
					FDAPMJJKNKG_MyAttackCountByType[OEDHCKELBJK[i].MCJEIDPDMLF_EffectId - 1] = OEDHCKELBJK[i].LHJMEJOJGKL_NumberOfTimes;
				}
				else
				{
					HNEPPPIEJAD_OtherAttackCountByType[OEDHCKELBJK[i].MCJEIDPDMLF_EffectId - 6] = OEDHCKELBJK[i].LHJMEJOJGKL_NumberOfTimes;
					if(OEDHCKELBJK[i].MCJEIDPDMLF_EffectId != 9)
					{
						if(v < OEDHCKELBJK[i].LPJIIDJJKOE_UpdatedAt)
						{
							OGLLKABGMCP_LastUpdatedPlayerId = OEDHCKELBJK[i].NMEGALKLMKH_LastUpdatedPlayerId;
							v = OEDHCKELBJK[i].LPJIIDJJKOE_UpdatedAt;
						}
					}
				}
			}
		}
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x1C79DD0 Offset: 0x1C79DD0 VA: 0x1C79DD0
		// |-PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.EMHHJNDOCMB<EBHIMFFJBIJ>
		// |-PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.EMHHJNDOCMB<MFKPFMCLOIB>
		// |-PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.EMHHJNDOCMB<object>
		// */

		// // RVA: 0xFDCD2C Offset: 0xFDCD2C VA: 0xFDCD2C
		// public static int CKHGLECNCAG(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type) { }

		// // RVA: 0xFDCD30 Offset: 0xFDCD30 VA: 0xFDCD30
		// public static int OHPCPAGKKCF(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type) { }

		// // RVA: 0xFE6CC4 Offset: 0xFE6CC4 VA: 0xFE6CC4
		public int NKIIJMFIIAK_GetTotalAttackCount(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
		{
			return DOJHNCMHNEI_GetMyAttackCount(_INDDJNMPONH_type) + LGKOMGPLKDK_GetOtherAttackCount(_INDDJNMPONH_type);
		}

		// // RVA: 0xFE6CF0 Offset: 0xFE6CF0 VA: 0xFE6CF0
		public int DOJHNCMHNEI_GetMyAttackCount(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
		{
			return FDAPMJJKNKG_MyAttackCountByType[(int)_INDDJNMPONH_type - 1];
		}

		// // RVA: 0xFE6D3C Offset: 0xFE6D3C VA: 0xFE6D3C
		public int LGKOMGPLKDK_GetOtherAttackCount(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
		{
			return HNEPPPIEJAD_OtherAttackCountByType[(int)_INDDJNMPONH_type - 1];
		}

		// // RVA: 0xFE6E88 Offset: 0xFE6E88 VA: 0xFE6E88
		public CALIFIMGGMD PMPMADPEGDE(int _OIPCCBHIKIA_index)
		{
			return PIGIFFAHFCI[_OIPCCBHIKIA_index];
		}

		// // RVA: 0xFE6F08 Offset: 0xFE6F08 VA: 0xFE6F08
		// public PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.CALIFIMGGMD JFODGOKHOEA() { }

		// // RVA: 0xFD98F0 Offset: 0xFD98F0 VA: 0xFD98F0
		internal void PIPOJJGBGLB()
		{
			PIGIFFAHFCI.Clear();
			GCKGHNBHOPH_Rank = 0;
			AEGFDINOACE_PlayerDamage = 0;
			BBMPCFEMDDC = null;
			NBBMHALJCMK_FirstAttackPlayer = null;
		}

		// // RVA: 0xFD9984 Offset: 0xFD9984 VA: 0xFD9984
		internal void IDALEDJHEMF(CALIFIMGGMD _GPNOEFHGOJG_dr)
		{
			PIGIFFAHFCI.Add(_GPNOEFHGOJG_dr);
		}

		// // RVA: 0xFD9A04 Offset: 0xFD9A04 VA: 0xFD9A04
		// internal void PHBGAAHPKPO(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.CALIFIMGGMD _GPNOEFHGOJG_dr) { }

		// // RVA: 0xFD9A0C Offset: 0xFD9A0C VA: 0xFD9A0C
		internal void KGPKFAFHEFP(CALIFIMGGMD _GPNOEFHGOJG_dr)
		{
			BBMPCFEMDDC = _GPNOEFHGOJG_dr;
			GCKGHNBHOPH_Rank = _GPNOEFHGOJG_dr.FJOLNJLLJEJ_rank;
			AEGFDINOACE_PlayerDamage = _GPNOEFHGOJG_dr.HALIDDHLNEG_Damage;
		}
	}

	private enum MALKHIMMLDI_RequestType
	{
		HJNNKCMLGFL_0_None = 0,
		NPGGGMACPLD_1_AttackersIdOnly = 1,
		OOEHFFBHCIC_2_Full = 2, //AttackersWithData
	}

	public class ECICDAPCMJG
	{
		public string LBODHBDOMGK_PlayerName; // 0x8
		public int MLPEHNBNOGD_PlayerId; // 0xC
		public bool HKAIJKGODHC; // 0x10
		public int GFDDPMCEJCI_ClusterId; // 0x14
	}

	public delegate void OGFPKBBOFFH(List<ECICDAPCMJG> GOOOMIHPBPM);

	public enum IEJAFPGDGNP_WinType
	{
		NIHKBNNICFB_Defeat_0 = 0,
		DBPDLIPKFAL_1_First = 1,
		FGPLEPGICPO_Mvp_2 = 2,
	}

	private class GAPINAADMPJ
	{
		public BKOGPDBKFFJ_EventRaid.LDCCKEPPFMG.NEGFCJPAPLC IDLHJIOMJBK_data; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
	}

	private const int GHJHJDIDCFA = 3;
	public const int EGJPAEHGDEL = 40;
	private const int EBPEOLODPNN = 1000;
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xE8
	private BBHNACPENDM_ServerSaveData FPPNANIIODA = new BBHNACPENDM_ServerSaveData(); // 0xEC
	private KAFHAKBBJEI JIMJHIDEHNM_ApCounter; // 0xF0
	private GameAttribute.Type IEDBMNIBDPD_MCannonPlateAttr; // 0xF8
	public int HENFOBHBABA_MCannonPlateAttrBonus; // 0xFC
	public int AKHNDMEHHLF_MCannonPlateSeriesBonus; // 0x100
	private List<KMFKFGEDPGJ> CBPJPNIFJOI = new List<KMFKFGEDPGJ>(8); // 0x10C
	public bool EGOJLOEFMOH_IsUpdateLimitedMusic; // 0x114
	public int BCBCODAKIDN_DescType; // 0x118
	public bool KIBBLLADDPO; // 0x11C
	public MJFMOPMOFDJ MCEJJBANCDA; // 0x120
	public int NENNACLBKJJ; // 0x124
	private MJFMOPMOFDJ PBJBHONLMKF_MyBoss = new MJFMOPMOFDJ(); // 0x128
	private List<MJFMOPMOFDJ> ECPHFLNMECN = new List<MJFMOPMOFDJ>(); // 0x12C
	private HighScoreRating JJGJJALILHC = new HighScoreRating(); // 0x138
	private uint PMBEODGMMBB_y = 0x15ab17a1; // 0x140

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid; } } // DKHCGLCNKCD_bgs  Slot: 4
	public JKIJLMMLNPL GGDBEANLCPC { get; private set; } // 0xF4 KOEMHFFCFBI_bgs MBNLPELOLBJ_bgs PFNPAAKMGJF_bgs
	public OCBPJEALCPO PLFBKEPLAAA { get; private set; } // 0x104 KPJIFMDECLG_bgs NAMEFMANAKG_bgs NPIFONLKBLN_bgs
	public KJJDLBFDGDM KONJMFICNJJ_RewardsInfo { get; private set; } // 0x108 BJFFFIBNLLH_bgs KLDMMPJKHEO_bgs PKGMFMELDEN_bgs
	// public List<PKNOKJNLPOE_EventRaid.KMFKFGEDPGJ> FKLEEMCDKNF { get; }
	public MOAICCAOMCP ANMBIEIFKFF_UnitBonusInfo { get; private set; } // 0x110 BFEMMFOALFE_bgs PDPEPHAMKEB_bgs JNEELMEBJFI_bgs
	// public bool NNNMHHHBIIB { get; }
	// public int CALECMAEBIH { get; }
	// public int HIGDPLMLING { get; }
	// public int OKEGPFAIOCF { get; }
	public JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType CFLEMFADGLG_AttackType { get; private set; } // 0x130 GEJKDKKDHBI_bgs KAHCHHILDEM_bgs MDOJKNFKJGE_bgs
	public MJFMOPMOFDJ JIBMOEHKMGB_SelectedBoss { get; set; } // 0x134 FKHECGJBFAD_bgs KACFOENGHIK_bgs ILADGLDGCLL_bgs
	public int HKMFDIEOKNM { get; private set; } // 0x13C FKCJFJMCNJA_bgs EFKMGOOLCKO_bgs LAGMLHCALKF_bgs
	// public bool NKNJACLMNDG { get; }
	// public bool KLOEKHMPJDJ { get; }
	// public bool CHMMBIEFFHB { get; }
	// public bool JHLLDEFENMP { get; }

	// // RVA: 0x9400AC Offset: 0x9400AC VA: 0x9400AC
	public List<KMFKFGEDPGJ> DIFIHMCHDJF()
	{
		return CBPJPNIFJOI;
	}

	// // RVA: 0x9400C4 Offset: 0x9400C4 VA: 0x9400C4
	public bool NMDNCFGEJGJ()
	{
		return KONJMFICNJJ_RewardsInfo != null;
	}

	// // RVA: 0x9400D4 Offset: 0x9400D4 VA: 0x9400D4 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		return KBACNOCOANM_Ranking;
	}

	// RVA: 0x9400DC Offset: 0x9400DC VA: 0x9400DC
	public PKNOKJNLPOE_EventRaid(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			FPPNANIIODA.KHEKNNFCAOI_Init(0x8000000005);
			IEDBMNIBDPD_MCannonPlateAttr = (GameAttribute.Type) ev.LPJLEHAJADA_GetIntParam("mcannon_plate_attr", 0);
			HENFOBHBABA_MCannonPlateAttrBonus = ev.LPJLEHAJADA_GetIntParam("mcannon_plate_attr_bonus", 50);
			AKHNDMEHHLF_MCannonPlateSeriesBonus = ev.LPJLEHAJADA_GetIntParam("mcannon_plate_series_bonus", 50);
		}
    }

	// // RVA: 0x940304 Offset: 0x940304 VA: 0x940304
	private BKOGPDBKFFJ_EventRaid FJLIDJJAGOM()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			return db as BKOGPDBKFFJ_EventRaid;
		}
		return null;
	}

	// // RVA: 0x940418 Offset: 0x940418 VA: 0x940418
	private JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM KNKJHNJFONJ_GetEvSave()
	{
		return KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
	}

	// // RVA: 0x940430 Offset: 0x940430 VA: 0x940430
	private JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM KNKJHNJFONJ_GetEvSave(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master)
	{
		if(_NDFIEMPPMLF_master != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[_NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0x94055C Offset: 0x94055C VA: 0x94055C Slot: 5
	public override string IFKKBHPMALH()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
		}
        return null;
	}

	// // RVA: 0x9406A4 Offset: 0x9406A4 VA: 0x9406A4
	private void BLNLNMLJIKO()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo m = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.GCINIJEMHFK_Get(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId);
				if(m != null)
				{
					m.EINIOBAIDCP();
				}
			}
		}
    }

	// // RVA: 0x940834 Offset: 0x940834 VA: 0x940834 Slot: 6
	public override string DCODGEOEDPG()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.PJBILOFOCIC;
		}
		return null;
	}

	// // RVA: 0x94097C Offset: 0x94097C VA: 0x94097C Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		return HEACCHAKMFG_GetMusicsList(0);
	}

	// // RVA: 0x940984 Offset: 0x940984 VA: 0x940984
	public List<int> HEACCHAKMFG_GetMusicsList(int _MFMPCHIJINJ_BossType)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			BKOGPDBKFFJ_EventRaid.HAGIHCECBGH h = null;
			if(_MFMPCHIJINJ_BossType != 0)
			{
				h = ev.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType);
			}
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			List<int> l = new List<int>(ev.IJJHFGOIDOK_EventMusic.Count);
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
				{
					if((ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at == 0) || 
						(t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && t <= ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at))
					{
						if(h == null || ev.IJJHFGOIDOK_EventMusic[i].HMHHNHEPAPP_BossId == h.PPFNGGCBJKC_id)
						{
							if(!l.Contains(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId))
								l.Add(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId);
						}
					}
				}
			}
			return l;
		}
		return null;
	}

	// // RVA: 0x940D44 Offset: 0x940D44 VA: 0x940D44
	public int KFBDBBCCPBB(int _MFMPCHIJINJ_BossType)
	{
		List<int> l = HEACCHAKMFG_GetMusicsList(_MFMPCHIJINJ_BossType);
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
	}

	// // RVA: 0x940ED0 Offset: 0x940ED0 VA: 0x940ED0 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int _GHBPLHBNMBK_FreeMusicId)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0 && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at != 0 && 
					t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && 
					t <= ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at && 
					ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
				{
					return ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at;
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(_GHBPLHBNMBK_FreeMusicId);
	}

	// // RVA: 0x9412E0 Offset: 0x9412E0 VA: 0x9412E0 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int _GHBPLHBNMBK_FreeMusicId)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0 && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at != 0 && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at < DPJCPDKALGI_RankingEnd &&
					t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && 
					t <= ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at && 
					ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x941710 Offset: 0x941710 VA: 0x941710 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0x94188C Offset: 0x94188C VA: 0x94188C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].DNBFMLBNAEE_point;
		}
		return 0;
	}

	// // RVA: 0x941AA8 Offset: 0x941AA8 VA: 0x941AA8 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && GPHEKCNDDIK)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("get_rank_cooling_time", 60);
			if(_FBBNPFFEJBN_Force || (t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time))
			{
				//LAB_00941de4
				KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, () =>
				{
					//0xFDE8A0
					CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
					KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					PLOOEECNHFB_IsDone = true;
				}, () =>
				{
					//0xFDEA64
					KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB_IsDone = true;
				}, () =>
				{
					//0xFDEC0C
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				}, () =>
				{
					//0xFDECA4
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				});
				return;
			}
		}
		else
		{
			CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x941F28 Offset: 0x941F28 VA: 0x941F28 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		BKOGPDBKFFJ_EventRaid LKOLAGLKIDA = FJLIDJJAGOM();
		if(LKOLAGLKIDA != null)
		{
            GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(LKOLAGLKIDA.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g == null)
				return false;
			if(_JHNMKKNEENE_Time < LKOLAGLKIDA.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
				return false;
			if(LKOLAGLKIDA.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 < _JHNMKKNEENE_Time)
				return false;
			if(LKOLAGLKIDA.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
			{
				if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0xFDED44
					return LKOLAGLKIDA.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				}) == null)
				{
					Debug.LogError(LKOLAGLKIDA.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api+" not foud to enable event");
					return false;
				}
			}
			return true;
        }
		return false;
	}

	// // RVA: 0x9421F0 Offset: 0x9421F0 VA: 0x9421F0 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_quests;
			if(save.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api || (save.EGBOHDFBAPB_closed_at < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && !RuntimeSettings.CurrentSettings.UnlimitedEvent))
			{
				save.LHPDDGIJKNB_Reset();
				save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
				save.EGBOHDFBAPB_closed_at = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				KOMAHOAEMEK(true);
				BLNLNMLJIKO();
			}
			KOMAHOAEMEK(false);
			JIMJHIDEHNM_ApCounter = new KAFHAKBBJEI();
			JIMJHIDEHNM_ApCounter.NEPIPMPAFIE_CntVal = save.NOKPCBEIJHJ_ApVal;
			JIMJHIDEHNM_ApCounter.DLPEEDCCNMJ_CntSaveTime = save.CKLPPIIKAKD_ApSaveTime;
			JIMJHIDEHNM_ApCounter.DCBENCMNOGO_MaxCount = ev.LPJLEHAJADA_GetIntParam("ap_max", 3);
			JIMJHIDEHNM_ApCounter.FLJGHBLEDDB_UpdateInterval = ev.LPJLEHAJADA_GetIntParam("ap_second", 2400);
			return true;
		}
		return false;
	}

	// // RVA: 0x942614 Offset: 0x942614 VA: 0x942614 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		BKOGPDBKFFJ_EventRaid LKOLAGLKIDA = FJLIDJJAGOM();
		if(LKOLAGLKIDA != null)
		{
			IBNKPMPFLGI_IsRankReward = LKOLAGLKIDA.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				KBACNOCOANM_Ranking = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0xFDEDAC
					return LKOLAGLKIDA.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = LKOLAGLKIDA.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = LKOLAGLKIDA.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = LKOLAGLKIDA.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = LKOLAGLKIDA.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = LKOLAGLKIDA.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = LKOLAGLKIDA.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = LKOLAGLKIDA.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = LKOLAGLKIDA.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = LKOLAGLKIDA.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			NHGPCLGPEHH_TicketType = LKOLAGLKIDA.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = LKOLAGLKIDA.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			HGLAFGHHFKP = LKOLAGLKIDA.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
			GFIBLLLHMPD_StartAdventureId = LKOLAGLKIDA.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = LKOLAGLKIDA.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			PJLNJJIBFBN_HasExtremeDiff = LKOLAGLKIDA.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(LKOLAGLKIDA.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = LKOLAGLKIDA.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[] { ',' });
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = m;
			}
			LHAKGDAGEMM_EpBonusInfos.Clear();
			for(int i = 0; i < LKOLAGLKIDA.LHAKGDAGEMM_EpBonusInfos.Count; i++)
			{
				CEGDBNNIDIG c = new CEGDBNNIDIG();
				c.KELFCMEOPPM_EpisodeId = LKOLAGLKIDA.LHAKGDAGEMM_EpBonusInfos[i].KHPHAAMGMJP_EpId;
				c.MIHNKIHNBBL_BaseBonus = LKOLAGLKIDA.LHAKGDAGEMM_EpBonusInfos[i].OFIAENKCJME_BaseBonus / 100.0f;
				c.MLLPMJFOKEC_GachaIds.AddRange(LKOLAGLKIDA.LHAKGDAGEMM_EpBonusInfos[i].KDNMBOBEGJM_GachaIds);
				LHAKGDAGEMM_EpBonusInfos.Add(c);
			}
			PGDAMNENGDA_EpBonusBySceneRarity.Clear();
			for(int i = 0; i < LKOLAGLKIDA.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
			{
				NJJDBBCHBNP n = new NJJDBBCHBNP();
				n.GJEADBKFAPA = LKOLAGLKIDA.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC_id;
				n.IJKFFIKGLJM_BonusBefore = LKOLAGLKIDA.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
				n.DCBMFNOIENM_BonusAfter = LKOLAGLKIDA.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
				PGDAMNENGDA_EpBonusBySceneRarity.Add(n);
			}
			DHOMAEOEFMJ_EpBonuByScene.Clear();
			for(int i = 0; i < LKOLAGLKIDA.GEGAEDDGNMA_Bonuses.Count; i++)
			{
				MEBJJBHPMEO m = new MEBJJBHPMEO();
				m.PPFNGGCBJKC_id = LKOLAGLKIDA.GEGAEDDGNMA_Bonuses[i].PPFNGGCBJKC_id;
				m.GNFBMCGMCFO_BonusBefore = LKOLAGLKIDA.GEGAEDDGNMA_Bonuses[i].GNFBMCGMCFO_BonusBefore;
				m.BFFGFAMJAIG_BonusAfter = LKOLAGLKIDA.GEGAEDDGNMA_Bonuses[i].BFFGFAMJAIG_BonusAfter;
				m.CNKFPJCGNFE_SceneId = LKOLAGLKIDA.GEGAEDDGNMA_Bonuses[i].CNKFPJCGNFE_SceneId;
				DHOMAEOEFMJ_EpBonuByScene.Add(m);
			}
			GPHEKCNDDIK = true;
		}
	}

	// // RVA: 0x943284 Offset: 0x943284 VA: 0x943284 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			PIMFJALCIGK();
		}
		PLOOEECNHFB_IsDone = true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD31C Offset: 0x6BD31C VA: 0x6BD31C
	// // RVA: 0x9433E8 Offset: 0x9433E8 VA: 0x9433E8 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xFE64DC
		KGBCKPKLKHM_RewardItems.Clear();
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL_GetStringParam("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> l = new List<string>();
				l.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(l, _AOCANKOMKFG_OnError));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD394 Offset: 0x6BD394 VA: 0x6BD394
	// // RVA: 0x94348C Offset: 0x94348C VA: 0x94348C Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xFE61C8
		KGBCKPKLKHM_RewardItems.Clear();
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL_GetStringParam("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> l = new List<string>();
				l.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(l, _AOCANKOMKFG_OnError));
			}
		}
	}

	// // RVA: 0x943530 Offset: 0x943530 VA: 0x943530 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			KIBBLLADDPO = false;
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
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
					if(!save.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2_CanEntry;
						if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
							return;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL == null)
							return;
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
							{
								BELBNINIOIE = true;
								break;
							}
						}
						return;
					}
					if(!save.ABBJBPLHFHA_Spurt)
					{
						if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
							KIBBLLADDPO = true;
							if(MBHDIJJEOFL == null)
								return;
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
							return;
						}
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3_Ranking;
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
									break;
								}
							}
						}
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_5_ChallengePeriod;
					}
				}
				else
				{
					if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
					{
						if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
						{
							if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11_Ended;
							}
							else
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10_Reward2;
							}
						}
						else
						{
							if(!save.HPLMECLKFID_RRcv)
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
							else
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
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
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1_NotStarted;
			}
			return;
		}
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		KIBBLLADDPO = false;
	}

	// // RVA: 0x943B38 Offset: 0x943B38 VA: 0x943B38 Slot: 48
	public override void AMKJFGLEJGE_RequestUpdateEventPoint(int KPIILHGOGJD)
	{
        EECOJKDJIFG LONLNGJAEEK = DAKMIKNKHMF_GetRankingInfoForIndex(KPIILHGOGJD);
		if(LONLNGJAEEK != null)
		{
            BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
			if(ev != null && FBHONHONKGD_MusicSelectDesc != null)
			{
				JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				PJDGDNJNCNM_UpdateStatusImpl(t);
				if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EIFKDKFAHPH_7 && ((1 << (int)NGOFCFJHOMI_Status) & 0x6c) != 0) // 2 3 5 6
				{
					EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _GHPLINIACBB_x) =>
					{
						//0xFDEE14
						return LONLNGJAEEK.OCGFKMHNEOF_name_for_api == _GHPLINIACBB_x.OCGFKMHNEOF_name_for_api;
					});
					if(e != null)
					{
						PKECIDPBEFL.DDBKLMKKCDL p = new PKECIDPBEFL.DDBKLMKKCDL();
						p.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, save.DNBFMLBNAEE_point);
						p.BLJIJENHBPM_Id = e.PPFNGGCBJKC_id;
						p.OBGBAOLONDD_UniqueId = PGIIDPEGGPI_EventId;
						p.NOBCHBHEPNC_Idx = KPIILHGOGJD;
						JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(p);
					}
				}
			}
        }
    }

	// // RVA: 0x943F40 Offset: 0x943F40 VA: 0x943F40 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		if(KBACNOCOANM_Ranking != null)
		{
            BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
            if (ev != null)
			{
                JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM NHLBKJCPLBL = KNKJHNJFONJ_GetEvSave(ev);
                PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(IBNKPMPFLGI_IsRankReward ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2_CanEntry ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3_Ranking ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_5_ChallengePeriod ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting
				)
				{
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, NHLBKJCPLBL.NFIOKIBPJCJ_uptime, NHLBKJCPLBL.DNBFMLBNAEE_point), () =>
					{
                        //0xFDEE68
                        CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                        PLOOEECNHFB_IsDone = true;
                        ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO_BasePoint, NHLBKJCPLBL.DNBFMLBNAEE_point, ev.LPJLEHAJADA_GetIntParam("ranking_point_max", 1000000), KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
                    }, () =>
					{
						//0xFDF0A0
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
                        //0xFDF0C8
                        PLOOEECNHFB_IsDone = true;
                        NPNNPNAIONN_IsError = true;
                    });
                    return;
                }
            }
            return;
        }
        PLOOEECNHFB_IsDone = true;
    }

	// // RVA: 0x944290 Offset: 0x944290 VA: 0x944290 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && IBNKPMPFLGI_IsRankReward)
		{
			KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0xFDF114
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
			}, () =>
			{
				//0xFDF170
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0xFDF1BC
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
			return;
		}
		_IDAEHNGOKAE_OnRankingError();
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x944574 Offset: 0x944574 VA: 0x944574 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		if(!IBNKPMPFLGI_IsRankReward)
		{
			_IDAEHNGOKAE_OnRankingError();
			PLOOEECNHFB_IsDone = false;
		}
		else
		{
			KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0xFDF228
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
			}, () =>
			{
				//0xFDF284
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0xFDF2D0
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
		}
	}

	// // RVA: 0x944770 Offset: 0x944770 VA: 0x944770
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x943398 Offset: 0x943398 VA: 0x943398
	private void PIMFJALCIGK()
	{
		int a = NGIHFKHOJOK_GetRankingMax(true);
		if(a < 1)
			return;
		for(int i = 0; i < a; i++)
		{
			BJEOAOACMGG(i);
		}
	}

	// // RVA: 0x944868 Offset: 0x944868 VA: 0x944868
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
			if(KBACNOCOANM_Ranking != null)
			{
				for(int i = 0; i < KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards.Count; i++)
				{
					MAOCCKFAOPC m = new MAOCCKFAOPC();
					m.JBDGBPAAAEF_HighRank = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].JPHDGGNAKMO_high_rank;
					m.GHANKNIBALB_LowRank = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].FGCAJEAIABA_low_rank;
					m.MJGAMDBOMHD_InventoryMessage = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].IPFEKNMBEBI_inventory_message;
					m.HBHMAKNGKFK_items = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].HBHMAKNGKFK_items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
				}
			}
		}
	}

	// // RVA: 0x944C94 Offset: 0x944C94 VA: 0x944C94 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		BKOGPDBKFFJ_EventRaid NDFIEMPPMLF_master = FJLIDJJAGOM();
		if(NDFIEMPPMLF_master != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				HLFHJIDHJMP = null;
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
				req.EMPNJPMAKBF_Id = KBACNOCOANM_Ranking.PPFNGGCBJKC_id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_from = 0;
				req.PJFKNNNDMIA_to = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xFDF33C
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
						{
							FKKDIDMGLMI_IsDroppedPlayer = true;
						}
						JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
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
					//0xFDF668
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
					{
						JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_point = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
						HLFHJIDHJMP.FJOLNJLLJEJ_rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, () =>
						{
							//0xFDFD3C
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD m = new MFDJIFIIPJD();
								m.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
								HLFHJIDHJMP.HBHMAKNGKFK_items.Add(m);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA_EventEnd(this);
							JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xFE00B8
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA_EventEnd(this);
							JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xFE02A0
							JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xFE042C
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xFE0474
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
						}, 0, -1);
					}
				};
				return;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x944FD0 Offset: 0x944FD0 VA: 0x944FD0
	// public KAMKMOKMPAN.GGPEAOAOEPH_Step BPOCKIHHJKH() { }

	// // RVA: 0x9451E8 Offset: 0x9451E8 VA: 0x9451E8
	public void JMEPDDLGPJF_SetStep(KAMKMOKMPAN.GGPEAOAOEPH_Step _LGADCGFMLLD_step)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.LGADCGFMLLD_step = (int)_LGADCGFMLLD_step;
		}
	}

	// // RVA: 0x945404 Offset: 0x945404 VA: 0x945404 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
			if(GFIBLLLHMPD_StartAdventureId != 0)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2_CanEntry)
				{
					return (save.INLNJOGHLJE_Show & 1) == 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0x9456FC Offset: 0x9456FC VA: 0x9456FC Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if(_JKDJCFEBDHC_Enabled)
		{
			BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
			if(ev != null)
			{
				JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2_CanEntry)
				{
					save.INLNJOGHLJE_Show |= 1;
				}
			}
		}
	}

	// // RVA: 0x94593C Offset: 0x94593C VA: 0x94593C Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD40C Offset: 0x6BD40C VA: 0x6BD40C
	// // RVA: 0x945994 Offset: 0x945994 VA: 0x945994
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		long IBCGNDADAEE_Time; // 0x28
		BKOGPDBKFFJ_EventRaid KEHCNBNPJHB; // 0x30
		JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM AIPLGDHHAJI; // 0x34
		int JEKGKAPLIHO; // 0x38

		//0xFE0678
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		PLFBKEPLAAA = null;
		KONJMFICNJJ_RewardsInfo = null;
		EGOJLOEFMOH_IsUpdateLimitedMusic = false;
		LPFJADHHLHG = false;
		BCBCODAKIDN_DescType = 0;
		KEHCNBNPJHB = FJLIDJJAGOM();
		if(KEHCNBNPJHB != null)
		{
			NPNNPNAIONN_IsError = false;
			PLOOEECNHFB_IsDone = false;
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			MJFKJHJJLMN_GetRanks(0, false);
			while(!PLOOEECNHFB_IsDone)
				yield return null;
			if(!NPNNPNAIONN_IsError)
			{
				AIPLGDHHAJI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
					yield break;
				}
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
				{
					AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
					LPFJADHHLHG = true;
					PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
				}
				CFLEMFADGLG_AttackType = JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType.CCAPCGPIIPF_1_Normal;
				JEKGKAPLIHO = (int)NGOFCFJHOMI_Status;
                int step = AIPLGDHHAJI.LGADCGFMLLD_step;
				if(JEKGKAPLIHO < 6)
				{
					switch(step)
					{
						case 0:
						case 1:
							CMPEJEHCOEI = true;
							AIPLGDHHAJI.LGADCGFMLLD_step = 2;
							AIPLGDHHAJI.IMFBCJOIJKJ_Entry = true;
							if(KIBBLLADDPO)
							{
								AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
								LPFJADHHLHG = true;
							}
							CPOAJKMPPMF_SetSaveFMId(HEACCHAKMFG_GetMusicsList()[0]);
							FGDDBFHGCGP_SetStartAdventureShown(true, 0);
							break;
						case 2:
							BCBCODAKIDN_DescType = JKPDCKDMKBN();
							if(BCBCODAKIDN_DescType != 0)
							{
								CPOAJKMPPMF_SetSaveFMId(HEACCHAKMFG_GetMusicsList()[0]);
								EGOJLOEFMOH_IsUpdateLimitedMusic = true;
							}
							break;
						case 3:
						case 4:
							AIPLGDHHAJI.MHKICPIMFEI_PlayCount++;
							AIPLGDHHAJI.LGADCGFMLLD_step = 2;
							break;
					}
				}
				else
				{
					AIPLGDHHAJI.LGADCGFMLLD_step = 5;
				}
				if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
				{
					if(GFIBLLLHMPD_StartAdventureId > 0)
					{
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(GFIBLLLHMPD_StartAdventureId))
						{
							if(!AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv)
							{
								bool KPIGMCJMFAN = false;
								yield return Co.R(JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(() =>
								{
									//0xFE0634
									KPIGMCJMFAN = true;
								}));
								if(!KPIGMCJMFAN)
								{
									if(JBPPMMMFGCA_HasRewardItems())
									{
										AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv = true;
									}
									//LAB_00fe10c8
								}
								else
								{
									_AOCANKOMKFG_OnError();
									yield break;
								}
							}
						}
					}
				}
				else if(NGOFCFJHOMI_Status >= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive && CAKEOPLJDAF_EndAdventureId > 0)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(CAKEOPLJDAF_EndAdventureId))
					{
						if(!AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(() =>
							{
								//0xFE0648
								KPIGMCJMFAN = true;
							}));
							if(!KPIGMCJMFAN)
							{
								if(JBPPMMMFGCA_HasRewardItems())
								{
									AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv = true;
								}
								//LAB_00fe10c8
							}
							else
							{
								_AOCANKOMKFG_OnError();
								yield break;
							}
						}
					}
				}
				//LAB_00fe10c8
				OIMGJLOLPHK = false;
				if(JEKGKAPLIHO < 6)
				{
					CEBFFLDKAEC_SecureInt a;
					if(KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(HOEKCEJINNA_new_episode_mver, out a))
					{
						bool b = DLHEEOIELBA(a.DNJEJEANJGL_Value);
						if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2_CanEntry)
						{
							if(!b)
							{
								AIPLGDHHAJI.INLNJOGHLJE_Show |= 4;
							}
						}
						else
						{
							if(KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(FOKNMOMNHHD_new_episode_help_pict_id, out a) && b)
							{
								if((AIPLGDHHAJI.INLNJOGHLJE_Show & 4) != 0)
								{
									GFHKFKHBIGM = true;
									OGPMLMDPGJA = a.DNJEJEANJGL_Value;
								}
							}
						}
						OIMGJLOLPHK = b;
					}
				}
				bool BEKAMBBOLBO_Done = false;
				bool CNAIDEAFAAM_Error = false;
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CKJHFFHFPLH_GetFriends(() =>
				{
					//0xFE04C0
					BEKAMBBOLBO_Done = true;
				}, (CACGCMBKHDI_Request _ADKIDBJCAJA_action) =>
				{
					//0xFE04CC
					CNAIDEAFAAM_Error = true;
				}, (CACGCMBKHDI_Request _ADKIDBJCAJA_action) =>
				{
					//0xFE04D8
					CNAIDEAFAAM_Error = true;
				});
				//LAB_00fe143c
				while(!BEKAMBBOLBO_Done && !CNAIDEAFAAM_Error)
					yield return null;
				if(!CNAIDEAFAAM_Error)
				{
					if(!AIPLGDHHAJI.KILJKLIHMAE_SboRcv)
					{
						int a, b;
						if(!PPPEFGFIGMH_GetStartBonusItemIdAndCount(out a, out b))
						{
							AIPLGDHHAJI.KILJKLIHMAE_SboRcv = true;
						}
					}
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xFE04E4
						ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL_EventHome(this);
						PLOOEECNHFB_IsDone = true;
						_BHFHGFKBOHH_OnSuccess();
					}, () =>
					{
						//0xFE05C8
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						_AOCANKOMKFG_OnError();
					}, null);
					yield break;
				}
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
            }
			//break;
			_AOCANKOMKFG_OnError();
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
		}
	}

	// // RVA: 0x945A4C Offset: 0x945A4C VA: 0x945A4C Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x945C68 Offset: 0x945C68 VA: 0x945C68 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM_DetailType _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
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

	// // RVA: 0x945D90 Offset: 0x945D90 VA: 0x945D90 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x945ED4 Offset: 0x945ED4 VA: 0x945ED4 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x946018 Offset: 0x946018 VA: 0x946018 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && BHABCGJCGNO != null && LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != save.OMCAOJJGOGG_Lb)
			{
				save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
				{
					EGOLBAPFHHD_Common.FKLHGOGJOHH enIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId) - 1];
					enIt.BFINGCJHOHI_cnt += BHABCGJCGNO.MBJIFDBEDAC_item_count;
					enIt.BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH_GetItem(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.IGAJCMKNLDL_14_EventLoginBonus, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, enIt.BFINGCJHOHI_cnt, 1);
				}
				return true;
            }
		}
		return false;
	}

	// // RVA: 0x9467BC Offset: 0x9467BC VA: 0x9467BC
	public int JCBDKEPCLKG_GetRaidBossHelpMaxCount()
	{
		return BAEPGOAMBDK("raid_boss_help_max_num", 15);
	}

	// // RVA: 0x946830 Offset: 0x946830 VA: 0x946830
	public void HEOFEABCBCC(out int _GEJGMBBCFEE__max, out int _CCIHMCAPHCB__Min)
	{
		_GEJGMBBCFEE__max = 0;
		_CCIHMCAPHCB__Min = 0;
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			_GEJGMBBCFEE__max = evLobby.DKNNNOIMMFN_GetClusterId();
			int t = BAEPGOAMBDK("raid_zentai_help_range_time", 21600);
			_CCIHMCAPHCB__Min = _GEJGMBBCFEE__max - t;
			if(_GEJGMBBCFEE__max < t)
				_CCIHMCAPHCB__Min = 0;
		}
	}

	// // RVA: 0x946A94 Offset: 0x946A94 VA: 0x946A94 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.MDADLCOCEBN_session_id;
		}
		return "";
	}

	// // RVA: 0x946CBC Offset: 0x946CBC VA: 0x946CBC Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && MNNNLDFNNCD(_JHNMKKNEENE_Time))
		{
			return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.IJJHFGOIDOK_EventMusic[0].MPLGPBNJDJB_FreeMusicId).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
		}
		return null;
	}

	// // RVA: 0x946F98 Offset: 0x946F98 VA: 0x946F98 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.IJJHFGOIDOK_EventMusic[0].MPLGPBNJDJB_FreeMusicId).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
		}
		return 0;
	}

	// // RVA: 0x94720C Offset: 0x94720C VA: 0x94720C
	private void CPOAJKMPPMF_SetSaveFMId(int _GHBPLHBNMBK_FreeMusicId)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.LIEKIBHAPKC_FId = _GHBPLHBNMBK_FreeMusicId;
		}
	}

	// // RVA: 0x947418 Offset: 0x947418 VA: 0x947418
	public int EOAMLLMMCPD_GetSaveFMId()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.LIEKIBHAPKC_FId;
		}
		return 23;
	}

	// // RVA: 0x947624 Offset: 0x947624 VA: 0x947624
	public void EHADIPOAOEA_SelectNextSong()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			List<int> l = HEACCHAKMFG_GetMusicsList();
			if(save.LIEKIBHAPKC_FId > 0 && l.Count > 1)
			{
				l.Remove(save.LIEKIBHAPKC_FId);
			}
			int v = UnityEngine.Random.Range(0, l.Count);
			CPOAJKMPPMF_SetSaveFMId(l[v]);
		}
	}

	// // RVA: 0x947920 Offset: 0x947920 VA: 0x947920
	private int JKPDCKDMKBN()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int a = 0;
			int b = 0;
			IBJAKJJICBC ib = IBJAKJJICBC.MLMMPFACEKI_FindMusicInLists(EOAMLLMMCPD_GetSaveFMId(), 
				IBJAKJJICBC.DHFHJBMKEHN(1, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(2, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(3, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(4, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(5, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(6, t, false),
				ref a, ref b);
			if(ib != null)
			{
				if(ib.LHONOILACFL_IsWeeklyEvent)
				{
					if(ib.BELHFPMBAPJ_WeekPlay < ib.JOJNGDPHOKG_WeeklyMax)
					{
						return 0;
					}
					return 2;
				}
				else
				{
					return 0;
				}
			}
			return 1;
		}
		return 0;
	}

	// // RVA: 0x947C94 Offset: 0x947C94 VA: 0x947C94 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
			if(ev != null)
			{
				JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				save.INLNJOGHLJE_Show &= ~4;
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0x947ECC Offset: 0x947ECC VA: 0x947ECC Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at && 
					t < ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at)
				{
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_description;
				}
			}
		}
		return "";
	}

	// // RVA: 0x9481F0 Offset: 0x9481F0 VA: 0x9481F0
	// public int NMLIONILBMC() { }

	// // RVA: 0x948238 Offset: 0x948238 VA: 0x948238
	public string AGEJGHGEGFF_GetBossName(int _MFMPCHIJINJ_BossType)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType).OPFGFINHFCE_name;
		}
		return "";
	}

	// // RVA: 0x9482D8 Offset: 0x9482D8 VA: 0x9482D8
	public SeriesAttr.Type NNDFMCHDJOH_GetBossSerie(int _MFMPCHIJINJ_BossType)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return (SeriesAttr.Type) ev.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType).CPKMLLNADLJ_Serie;
		}
		return 0;
	}

	// // RVA: 0x948320 Offset: 0x948320 VA: 0x948320
	public bool BMDEELGBBOI(int _MFMPCHIJINJ_BossType)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            return ev.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType).PIPCIMIALOO_sp == 1;
        }
        return false;
    }

	// // RVA: 0x948370 Offset: 0x948370 VA: 0x948370
	public int KNNHGJFJAEN_GetNumBosses()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.GJFJLEOGFLD_RaidBoss.Count;
		}
		return 0;
	}

	// // RVA: 0x948400 Offset: 0x948400 VA: 0x948400
	private static bool MFAFEBNEEHE_IsMyself(int _MLPEHNBNOGD_PlayerId)
	{
		return NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId == _MLPEHNBNOGD_PlayerId;
	}

	// // RVA: 0x9484B0 Offset: 0x9484B0 VA: 0x9484B0
	public string ICCEILFHKEL_GetUtaGradeMoreText()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.EFEGBHACJAL_GetStringParam("uta_grade_more_text", "");
		}
		return "";
	}

	// // RVA: 0x948548 Offset: 0x948548 VA: 0x948548
	public MJFMOPMOFDJ PMIIMELDPAJ_GetMyBoss()
	{
		return PBJBHONLMKF_MyBoss;
	}

	// // RVA: 0x948550 Offset: 0x948550 VA: 0x948550
	public MJFMOPMOFDJ HCFDHLNNDAN(int _OIPCCBHIKIA_index)
	{
		return ECPHFLNMECN[_OIPCCBHIKIA_index];
	}

	// // RVA: 0x9485D0 Offset: 0x9485D0 VA: 0x9485D0
	public int EHJOBALDPBG()
	{
		return ECPHFLNMECN.Count;
	}

	// // RVA: 0x948670 Offset: 0x948670 VA: 0x948670
	private BKOGPDBKFFJ_EventRaid.MNFPNLMPOEB CMMDPDMNNKP(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master, JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
	{
		return _NDFIEMPPMLF_master.NFOECEGILLC_AttacksInfo[(int)_INDDJNMPONH_type - 1];
	}

	// // RVA: 0x948700 Offset: 0x948700 VA: 0x948700
	public int EMJEBMMMDBE_GetPointBonus(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return CMMDPDMNNKP(ev, _INDDJNMPONH_type).KMHIOCCFPEM_PointBonus;
		}
		return 0;
	}

	// // RVA: 0x948748 Offset: 0x948748 VA: 0x948748
	public int AFODCOIFHKO_GetSupportBonus(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return CMMDPDMNNKP(ev, _INDDJNMPONH_type).PIABNPEFLEJ_SupportBonus;
		}
		return 0;
	}

	// // RVA: 0x948790 Offset: 0x948790 VA: 0x948790
	public int MCBGNPBECCI_SupportBonusMax()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.LPJLEHAJADA_GetIntParam("coop_bonus_max", 100);
		}
		return 0;
	}

	// // RVA: 0x948810 Offset: 0x948810 VA: 0x948810
	public bool APGPNCKBADI_GetEncounterStartEndTime(out DateTime _FKPEAGGKNLC_Start, out DateTime _KOMKKBDABJP_end)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev == null || !ev.GNKACELEIAC("encounter_start_time"))
		{
			_FKPEAGGKNLC_Start = new DateTime();
			_KOMKKBDABJP_end = new DateTime();
			return false;
		}
		else
		{
			string s = ev.EFEGBHACJAL_GetStringParam("encounter_start_time", "10:00");
			_FKPEAGGKNLC_Start = DateTime.Parse(s);
			s = ev.EFEGBHACJAL_GetStringParam("encounter_end_time", "23:59");
			_KOMKKBDABJP_end = DateTime.Parse(s);
			return true;
		}
	}

	// // RVA: 0x948984 Offset: 0x948984 VA: 0x948984
	public bool FJBIJAGCGKC_IsEncounterTimeOk()
	{
		DateTime a, b;
		if(APGPNCKBADI_GetEncounterStartEndTime(out a, out b))
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime dt = Utility.GetLocalDateTime(t);
			long t1 = Utility.GetTargetUnixTime(dt.Year, dt.Month, dt.Day, a.Hour, a.Minute, a.Second);
			long t2 = Utility.GetTargetUnixTime(dt.Year, dt.Month, dt.Day, b.Hour, b.Minute, b.Second);
			return t >= t1 && t2 >= t;
		}
		return true;
	}

	// // RVA: 0x948C30 Offset: 0x948C30 VA: 0x948C30
	public int NPICFLFAIJK_GetNumTicket()
	{
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(evLobby != null)
		{
			return evLobby.ONKKHPKHCIA_GetNumTicket();
		}
		return 0;
	}

	// // RVA: 0x948D40 Offset: 0x948D40 VA: 0x948D40
	public bool KBFCALJDLPH()
	{
		if(!PBJBHONLMKF_MyBoss.DNJGAJPIIPI_IsValid && NPICFLFAIJK_GetNumTicket() > 0)
		{
			return FJBIJAGCGKC_IsEncounterTimeOk();
		}
		return false;
	}

	// // RVA: 0x948D94 Offset: 0x948D94 VA: 0x948D94
	private bool IBGMIDDJECI()
	{
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(evLobby != null)
		{
			evLobby.OMNKLDDHNNE();
			return true;
		}
		return false;
	}

	// // RVA: 0x948EAC Offset: 0x948EAC VA: 0x948EAC
	private void KHPCBKAEGBC()
	{
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(evLobby != null)
		{
			evLobby.IMBLLJAEMAI_UseTicket(1);
		}
	}

	// // RVA: 0x948FBC Offset: 0x948FBC VA: 0x948FBC
	public void KECLCFBKMOA_EncounterBoss(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError, DJBHIFLHJLK IILBGCMIEDJ)
	{
		N.a.StartCoroutineWatched(IDNENICNGHO_Coroutine_EncounterBoss(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError, IILBGCMIEDJ));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD4E4 Offset: 0x6BD4E4 VA: 0x6BD4E4
	// // RVA: 0x949024 Offset: 0x949024 VA: 0x949024
	private IEnumerator IDNENICNGHO_Coroutine_EncounterBoss(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError, DJBHIFLHJLK IILBGCMIEDJ)
	{
		//0xFE37E4
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true) == null)
		{
			if(IBGMIDDJECI())
			{
				bool BEKAMBBOLBO_Done = false;
				bool CNAIDEAFAAM_Error = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0xFD6394
					BEKAMBBOLBO_Done = true;
				}, () =>
				{
					//0xFD63A0
					CNAIDEAFAAM_Error = true;
				}, null);
				while(!BEKAMBBOLBO_Done && !CNAIDEAFAAM_Error)
					yield return null;
				if(!CNAIDEAFAAM_Error)
				{
					KDMINIMGGLI_EncounterRaidboss BIHCCEHLAOD = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KDMINIMGGLI_EncounterRaidboss());
					BIHCCEHLAOD.BIHCCEHLAOD.MMEBLOIJBKE_UniqueKey = JLIICBOHICB_GetBossUniqueKey();
					if(IILBGCMIEDJ != null)
						BIHCCEHLAOD.NBFDEFGFLPJ = JGJFFKPFMDB.IOGGLELGHLO;
					PLOOEECNHFB_IsDone = false;
					NPNNPNAIONN_IsError = false;
					BIHCCEHLAOD.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
					{
						//0xFD63AC
						KDMINIMGGLI_EncounterRaidboss r = _HKICMNAACDA_a as KDMINIMGGLI_EncounterRaidboss;
						PBJBHONLMKF_MyBoss.LHPDDGIJKNB_Reset();
						PBJBHONLMKF_MyBoss.MLPEHNBNOGD_PlayerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
						OFAHKDKDGAN(PBJBHONLMKF_MyBoss, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
						NBPANDOEDJH(PBJBHONLMKF_MyBoss, r.NFEAMMJIMPG_Result);
						PBJBHONLMKF_MyBoss.CMCKNKKCNDK_status = NHCDBBBMFFG_BossStatus.MBFHILFLPJL_1_Alive;
						PBJBHONLMKF_MyBoss.DLMNFENNCJG_HasAttacked = false;
						PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = true;
						PBJBHONLMKF_MyBoss.ICCOOAAJEIN_CanReceiveReward = false;
						PBJBHONLMKF_MyBoss.EMHHJNDOCMB(r.NFEAMMJIMPG_Result.MGPCMCNFFIM_Effects);
						FMGJILBBNBJ_UpdateCoopBonus(PBJBHONLMKF_MyBoss);
						KHPCBKAEGBC();
                        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM ev = KNKJHNJFONJ_GetEvSave();
						if(ev != null)
						{
							ev.HBHCCLGECOC_MyBossId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id;
							ev.CPPNJFGEBNM_ResetMyBossAttacksCount();
						}
						IPEIKLJLCJL(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id, PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial);
						HCKEDINDNAP(PBJBHONLMKF_MyBoss);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.KMHJDFJHMEP_35_RaidEncounterBoss);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DCFBLGLFJDO_20_DailyMissionCompleted);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.ADCDEIPMKJI_19_NumEventMission);
						ILCCJNDFFOB.HHCJCDFCLOB.KCCMKAEPGPE_RaidBossEncounter(this, NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD_GetTicketId(), 1, NPICFLFAIJK_GetNumTicket());
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
						{
							//0xFD6B08
							PLOOEECNHFB_IsDone = true;
							_BHFHGFKBOHH_OnSuccess();
						}, () =>
						{
							//0xFD6B54
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							_AOCANKOMKFG_OnError();
						}, null);
                    };
					BIHCCEHLAOD.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
					{
						//0xFD6BB8
						if(!JGJFFKPFMDB.IOGGLELGHLO(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId))
							return;
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.KMHJDFJHMEP_35_RaidEncounterBoss);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DCFBLGLFJDO_20_DailyMissionCompleted);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.ADCDEIPMKJI_19_NumEventMission);
						NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
						if(evLobby != null)
						{
							evLobby.DOCCMMJMJMP();
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0xFD6EE8
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
								if(IILBGCMIEDJ != null)
									IILBGCMIEDJ();
							}, () =>
							{
								//0xFD6F40
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
								_AOCANKOMKFG_OnError();
							}, null);
							return;
						}
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						_AOCANKOMKFG_OnError();
					};
					yield break;
				}
			}
		}
		//LAB_00fe3c7c
		PLOOEECNHFB_IsDone = true;
		NPNNPNAIONN_IsError = true;
		_AOCANKOMKFG_OnError();
	}

	// // RVA: 0x9490F8 Offset: 0x9490F8 VA: 0x9490F8
	private string JLIICBOHICB_GetBossUniqueKey()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			BKOGPDBKFFJ_EventRaid.PIDMOGPJNNA bossLevel = null;
			for(int i = 0; i < ev.BFKJBHMHKAH_BossLevelsInfo.Count; i++)
			{
				bossLevel = ev.BFKJBHMHKAH_BossLevelsInfo[i];
				if(ev.BFKJBHMHKAH_BossLevelsInfo[i].ICLFADEFBIH_UtaGrade > GameManager.Instance.ViewPlayerData.BJGOPOEAAIC_UtaRate)
					break;
			}
			int boss_level_random_p = ev.LPJLEHAJADA_GetIntParam("boss_level_random_+", 2);
			int boss_level_random_m = ev.LPJLEHAJADA_GetIntParam("boss_level_random_-", 2);
			int v = UnityEngine.Random.Range(-boss_level_random_m, boss_level_random_p + 1);
			int s = Mathf.Clamp(v + bossLevel.PPFNGGCBJKC_id, 1, ev.BFKJBHMHKAH_BossLevelsInfo.Count);
			int t = 0;
			for(int i = 0; i < ev.GJFJLEOGFLD_RaidBoss.Count; i++)
			{
				t += ev.GJFJLEOGFLD_RaidBoss[i].AKBHPFBDDOL_Val;
			}
			int v2 = UnityEngine.Random.Range(0, t);
			BKOGPDBKFFJ_EventRaid.HAGIHCECBGH b = null;
			int idx = 0;
			for(int i = 0; i < ev.GJFJLEOGFLD_RaidBoss.Count; i++)
			{
				v2 -= ev.GJFJLEOGFLD_RaidBoss[i].AKBHPFBDDOL_Val;
				if(v2 <= 0)
				{
					idx = i + 1;
					b = ev.GJFJLEOGFLD_RaidBoss[i];
					break;
				}
			}
            BKOGPDBKFFJ_EventRaid.PIDMOGPJNNA d = ev.ODMCAHDEEBK(s);
            StringBuilder str = new StringBuilder(32);
			str.SetFormat("boss_{0}_{1}_{2}{3}", new object[4]
			{
				idx, s, b.PIPCIMIALOO_sp == 1 ? d.OMIEMNDOPKA : d.LLNDMKBBNIJ_ver, b.PIPCIMIALOO_sp == 1 ? "_sp" : ""
			});
			return str.ToString();
		}
		return null;
	}

	// // RVA: 0x9497EC Offset: 0x9497EC VA: 0x9497EC
	public void CFKCMIBJOIA_GetBossLevelRandMinMax(out int LCIIDGAPDCN, out int OGOHJAFOEPG)
	{
		LCIIDGAPDCN = 0;
		OGOHJAFOEPG = 0;
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			LCIIDGAPDCN = ev.LPJLEHAJADA_GetIntParam("boss_level_random_+", 2);
			OGOHJAFOEPG = ev.LPJLEHAJADA_GetIntParam("boss_level_random_-", 2);
		}
    }

	// // RVA: 0x9498A8 Offset: 0x9498A8 VA: 0x9498A8
	public void FGIHOCHKKMD(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NKOBMDPHNGP_EventRaidLobby LLDNJABJNFH = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(LLDNJABJNFH != null)
		{
			if(LLDNJABJNFH.LDEPDKGNAPK())
			{
				IEFFGONGBCD_GetMyRaidBosses((List<NCMFOICNJEB<EBHIMFFJBIJ>> DIDOEKOBNNJ) =>
				{
					//0xFD6FAC
					bool b = false;
					for(int i = 0; i < DIDOEKOBNNJ.Count; i++)
					{
						if(NKGJPJPHLIF.HHCJCDFCLOB.KKMCBNKDDPN(DIDOEKOBNNJ[i].MBEMFKGBIEO_EncounterPlayerId))
						{
							b = true;
							KHPCBKAEGBC();
							break;
						}
					}
					if(!b)
					{
						LLDNJABJNFH.DOCCMMJMJMP();
					}
					PLOOEECNHFB_IsDone = true;
					_BHFHGFKBOHH_OnSuccess();
				}, _MOBEEPPKFLG_OnFail);
				return;
			}
		}
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = true;
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x949CE0 Offset: 0x949CE0 VA: 0x949CE0
	private void OFAHKDKDGAN(FCDIHBGEKOB BCGAOHJKPIG, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		BCGAOHJKPIG.AHEFHIMGIBI_PlayerData = _AHEFHIMGIBI_PlayerData;
		BCGAOHJKPIG.LHMDABPNDDH_state = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(BCGAOHJKPIG.MLPEHNBNOGD_PlayerId) ? IBIGBMDANNM.LJJOIIAEICI_FriendStatus.HEEJBCDDOJJ_1_Friend : IBIGBMDANNM.LJJOIIAEICI_FriendStatus.CCAPCGPIIPF_0_Normal;
		JJGJJALILHC.CalcUtaRate(_AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AEIADFODLMC_HsRating);
		BCGAOHJKPIG.OFHFGHJEKKL = JJGJJALILHC.GetUtaRateTotal();
		BCGAOHJKPIG.HIMMCGKKOOL_Rate = (int) JJGJJALILHC.GetUtaGrade();
	}

	// // RVA: 0x949E80 Offset: 0x949E80 VA: 0x949E80
	private void NBPANDOEDJH(MJFMOPMOFDJ DACHLLPBFPI, LBICPMOLOKD CHCEIJOJDHL)
	{
		DACHLLPBFPI.PPFNGGCBJKC_id = CHCEIJOJDHL.PPFNGGCBJKC_id;
		DACHLLPBFPI.MMEBLOIJBKE_UniqueKey = CHCEIJOJDHL.MMEBLOIJBKE_UniqueKey;
		DACHLLPBFPI.BCCOMAODPJI_hp = CHCEIJOJDHL.BCCOMAODPJI_hp;
		DACHLLPBFPI.PIKKHCGNGNN_HpMax = CHCEIJOJDHL.FFBHEHAIHMA_MaxHp;
		DACHLLPBFPI.MHABJOMJCFI_AttackPlayerCount = CHCEIJOJDHL.MHABJOMJCFI_AttackPlayerCount;
		DACHLLPBFPI.AJCCONCCIMF_EscapeAt = CHCEIJOJDHL.PPLAPJDENND_EscapedAt;
		string[] strs = DACHLLPBFPI.MMEBLOIJBKE_UniqueKey.Split(new char[] { '_' });
		DACHLLPBFPI.INDDJNMPONH_type = int.Parse(strs[1]);
		DACHLLPBFPI.ANAJIAENLNB_lv = int.Parse(strs[2]);
		DACHLLPBFPI.IKICLMGFFPB_IsSpecial = strs.Length > 4;
		DACHLLPBFPI.FJOLNJLLJEJ_rank = FJLIDJJAGOM().ODMCAHDEEBK(DACHLLPBFPI.ANAJIAENLNB_lv).FJOLNJLLJEJ_rank;
		DACHLLPBFPI.HPPDFBKEJCG_BgId = FJLIDJJAGOM().POCOCNENCOE_GetBossInfo(DACHLLPBFPI.INDDJNMPONH_type).PPFNGGCBJKC_id;
	}

	// // RVA: 0x94A118 Offset: 0x94A118 VA: 0x94A118
	private void FMGJILBBNBJ_UpdateCoopBonus(MJFMOPMOFDJ DACHLLPBFPI)
	{
		DACHLLPBFPI.CLNPBIJBIIJ_SupportBonus = 0;
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int a = 0;
			for(int i = 1; i < 5; i++)
			{
				int b = DACHLLPBFPI.NKIIJMFIIAK_GetTotalAttackCount( (JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType) i);
				a += CMMDPDMNNKP(ev, (JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType) i).PIABNPEFLEJ_SupportBonus * b;
			}
			DACHLLPBFPI.CLNPBIJBIIJ_SupportBonus = Mathf.Min(a, ev.LPJLEHAJADA_GetIntParam("coop_bonus_max", 100));
		}
    }

	// // RVA: 0x94A284 Offset: 0x94A284 VA: 0x94A284
	private void HCKEDINDNAP(MJFMOPMOFDJ DACHLLPBFPI)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			int FCBDGLEPGFJ_mid = 1;
			if(!save.LDJPDEHJFOC(DACHLLPBFPI.PPFNGGCBJKC_id, out FCBDGLEPGFJ_mid))
			{
				FCBDGLEPGFJ_mid = BCDFFKCOOFB(DACHLLPBFPI.PPFNGGCBJKC_id, DACHLLPBFPI.IKICLMGFFPB_IsSpecial);
			}
			BKOGPDBKFFJ_EventRaid.NJLOJAKKGFK d = ev.HDMADAHNLDN_Missions.Find((BKOGPDBKFFJ_EventRaid.NJLOJAKKGFK _MABBBOEAPAA_p) =>
			{
				//0xFD7178
				return _MABBBOEAPAA_p.PPFNGGCBJKC_id == FCBDGLEPGFJ_mid;
			});
			if(d != null)
			{
				DACHLLPBFPI.BLFHMNHMDHF_Mission = d.FEMMDNIELFC_Desc;
				DACHLLPBFPI.CJLHLKKNMEE_MissionText = d.FEMMDNIELFC_Desc.Replace(JpStringLiterals.StringLiteral_5812, "");
				DACHLLPBFPI.NFOOOBMJINC_MissionBonusNum = d.ECEKNKIDING(DACHLLPBFPI.IKICLMGFFPB_IsSpecial);
				DACHLLPBFPI.JOMGCCBFKEF_MissionId = d.PPFNGGCBJKC_id;
			}
        }
    }

	// // RVA: 0x94A698 Offset: 0x94A698 VA: 0x94A698
	public void AIMIFGFHBCE_GetMyBoss(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM NHLBKJCPLBL = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
    	if(NHLBKJCPLBL != null)
		{
			EAOJEDAEIJN_GetMyRaidbosses req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new EAOJEDAEIJN_GetMyRaidbosses());
			PLOOEECNHFB_IsDone = false;
			NPNNPNAIONN_IsError = false;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
			{
				//0xFD71C4
				PBJBHONLMKF_MyBoss.LHPDDGIJKNB_Reset();
				KMFKFGEDPGJ d = new KMFKFGEDPGJ();
				d.INDDJNMPONH_type = BKKPEJEABJN.LIFLDNIHBAK_1;
				List<int> l = new List<int>(40);
				ECPHFLNMECN.Clear();
				EAOJEDAEIJN_GetMyRaidbosses r = _HKICMNAACDA_a as EAOJEDAEIJN_GetMyRaidbosses;
				HKMFDIEOKNM = r.NFEAMMJIMPG_Result.DKNENAKHNAP.Count;
				long t = 0;
				for(int i = 0 ; i < r.NFEAMMJIMPG_Result.DKNENAKHNAP.Count; i++)
				{
					MJFMOPMOFDJ m = null;
					if(MFAFEBNEEHE_IsMyself(r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId))
					{
						if(NHLBKJCPLBL.HBHCCLGECOC_MyBossId == r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].PPFNGGCBJKC_id || 
							r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].CMCKNKKCNDK_status == NHCDBBBMFFG_BossStatus.MBFHILFLPJL_1_Alive || 
							r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].ICCOOAAJEIN_CanReceiveReward)
						{
							m = PBJBHONLMKF_MyBoss;
							PBJBHONLMKF_MyBoss.MLPEHNBNOGD_PlayerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
							OFAHKDKDGAN(PBJBHONLMKF_MyBoss, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
							NBPANDOEDJH(PBJBHONLMKF_MyBoss, r.NFEAMMJIMPG_Result.DKNENAKHNAP[i]);
							if(NHLBKJCPLBL.NHGJFJBEIBL_GetNumMissions() < 1 || !NHLBKJCPLBL.MPOLPHDMBKA(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id))
							{
								//LAB_00fd7868
								Debug.LogWarning("StringLiteral_13184");
								IPEIKLJLCJL(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id, PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial);
							}
							if(NHLBKJCPLBL.HBHCCLGECOC_MyBossId == 0)
							{
								NHLBKJCPLBL.HBHCCLGECOC_MyBossId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id;
							}
							PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].CAKONDPGDIL_CanRequestHelp;
							//LAB_00fd79a4
						}
						else
							continue;
					}
					else
					{
						m = new MJFMOPMOFDJ();
						ECPHFLNMECN.Add(m);
						if(!l.Contains(r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId))
						{
							l.Add(r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId);
						}
						m.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId;
						NBPANDOEDJH(m, r.NFEAMMJIMPG_Result.DKNENAKHNAP[i]);
						m.CAKONDPGDIL_CanRequestHelp = false;
						IPEIKLJLCJL(m.PPFNGGCBJKC_id, m.IKICLMGFFPB_IsSpecial);
						if(!NHLBKJCPLBL.OFJNLMIHMDE(r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].PPFNGGCBJKC_id))
						{
							d.GBJFCGOBHDO_NewAttackCount++;
							if(t < r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].OJCCKOICMJK_CreatedAt)
							{
								d.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId;
								t = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].OJCCKOICMJK_CreatedAt;
							}
						}
					}
					//LAB_00fd79a4
					HCKEDINDNAP(m);
					m.CMCKNKKCNDK_status = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].CMCKNKKCNDK_status;
					m.DLMNFENNCJG_HasAttacked = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].DLMNFENNCJG_HasAttacked;
					m.ICCOOAAJEIN_CanReceiveReward = r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].ICCOOAAJEIN_CanReceiveReward;
					m.EMHHJNDOCMB(r.NFEAMMJIMPG_Result.DKNENAKHNAP[i].MGPCMCNFFIM_Effects);
					FMGJILBBNBJ_UpdateCoopBonus(m);
					ILCCJNDFFOB.HHCJCDFCLOB.ONMOONKHHLO_RaidBossAppearence(this, m);
				}
				for(int i = 0; i < NHLBKJCPLBL.HBBNJHLHPDH().Count; i++)
				{
					int JFJFMFNMPPF = NHLBKJCPLBL.HBBNJHLHPDH()[i];
					if(JFJFMFNMPPF != NHLBKJCPLBL.HBHCCLGECOC_MyBossId)
					{
						MJFMOPMOFDJ m = ECPHFLNMECN.Find((MJFMOPMOFDJ BFPPAPMNEHA) =>
						{
							//0xFD8790
							return JFJFMFNMPPF == BFPPAPMNEHA.PPFNGGCBJKC_id;
						});
						if(m == null)
						{
							NHLBKJCPLBL.PJCGNAKDOKH(JFJFMFNMPPF);
						}
					}
				}
				for(int i = 0; i < NHLBKJCPLBL.HEMPBHOBAPE().Count; i++)
				{
					int JFJFMFNMPPF = NHLBKJCPLBL.HEMPBHOBAPE()[i];
					if(JFJFMFNMPPF != NHLBKJCPLBL.HBHCCLGECOC_MyBossId)
					{
						MJFMOPMOFDJ m = ECPHFLNMECN.Find((MJFMOPMOFDJ BFPPAPMNEHA) =>
						{
							//0xFD87C4
							return JFJFMFNMPPF == BFPPAPMNEHA.PPFNGGCBJKC_id;
						});
						if(m == null)
						{
							NHLBKJCPLBL.IDBJMCBHJJJ(JFJFMFNMPPF);
						}
					}
				}
				NHLBKJCPLBL.BADLOIKHGLK();
				ECPHFLNMECN.ForEach((MJFMOPMOFDJ BFPPAPMNEHA) =>
				{
					//0xFD847C
					NHLBKJCPLBL.NBCJGLLLFOH(BFPPAPMNEHA.PPFNGGCBJKC_id);
				});
				if(d.GBJFCGOBHDO_NewAttackCount > 0)
				{
					CBPJPNIFJOI.Add(d);
				}
				if(l.Count < 1)
				{
					KDBBGILHMNL_TryRestoreSavedBoss(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
				}
				else
				{
					NJNCAHLIHNI_GetPlayerData req2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
					req2.FAMHAPONILI_PlayerIds = l;
					req2.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(5);
					req2.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
					{
						//0xFD84C4
						BBHNACPENDM_ServerSaveData sData = new BBHNACPENDM_ServerSaveData();
						sData.EBKCPELHDKN_InitWithBaseAndPublicStatus();
						if(sData.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data))
						{
							for(int i = 0; i < ECPHFLNMECN.Count; i++)
							{
								if(ECPHFLNMECN[i].MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id)
								{
									OFAHKDKDGAN(ECPHFLNMECN[i], sData);
								}
							}
							return true;
						}
						return false;
					};
					req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request BHGCOECCPCO) =>
					{
						//0xFD868C
						KDBBGILHMNL_TryRestoreSavedBoss(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
					};
					req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request MEOKEBAMPLA) =>
					{
						//0xFD86C8
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						_AOCANKOMKFG_OnError();
					};
				}
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
			{
				//0xFD872C
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_AOCANKOMKFG_OnError();
			};
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			_AOCANKOMKFG_OnError();
		}
	}

	// // RVA: 0x94A938 Offset: 0x94A938 VA: 0x94A938
	private void KDBBGILHMNL_TryRestoreSavedBoss(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
		if(save != null && !PBJBHONLMKF_MyBoss.DNJGAJPIIPI_IsValid && save.HBHCCLGECOC_MyBossId != 0)
		{
			PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id = save.HBHCCLGECOC_MyBossId;
			DOECBDLGILJ_GetBosses(PBJBHONLMKF_MyBoss, 0, () =>
			{
				//0xFD8800
				IHMDJENFJIG(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
			}, () =>
			{
				//0xFD8838
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_AOCANKOMKFG_OnError();
			});
		}
		else
		{
			IHMDJENFJIG(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}
    }

	// // RVA: 0x94AE74 Offset: 0x94AE74 VA: 0x94AE74
	private void IHMDJENFJIG(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		if(PBJBHONLMKF_MyBoss.DNJGAJPIIPI_IsValid)
		{
			IHPJMEKNJLP();
			if((PBJBHONLMKF_MyBoss.CMCKNKKCNDK_status == NHCDBBBMFFG_BossStatus.OPNEOJEGDJB_2_Dead || PBJBHONLMKF_MyBoss.CMCKNKKCNDK_status == NHCDBBBMFFG_BossStatus.NFDONDKDHPK_3_Escaped) && 
				!PBJBHONLMKF_MyBoss.ICCOOAAJEIN_CanReceiveReward)
			{
                JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
				if(save != null)
				{
					save.BGOJNJLNLKE();
				}
            }
		}
		CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
		{
			//0xFD88A4
			EGBLOJJIKKJ(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}, () =>
		{
			//0xFD88DC
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_AOCANKOMKFG_OnError();
		}, null);
	}

	// // RVA: 0x94B58C Offset: 0x94B58C VA: 0x94B58C
	private void EGBLOJJIKKJ(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		if(NLEFCEBIGGO_HasMissingPlayersInfo())
		{
			PLOOEECNHFB_IsDone = false;
			NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
			req.FAMHAPONILI_PlayerIds = new List<int>(CBPJPNIFJOI.Count);
			for(int i = 0; i < CBPJPNIFJOI.Count; i++)
			{
				if(string.IsNullOrEmpty(CBPJPNIFJOI[i].LBODHBDOMGK_PlayerName))
				{
					if(!req.FAMHAPONILI_PlayerIds.Contains(CBPJPNIFJOI[i].MLPEHNBNOGD_PlayerId))
					{
						req.FAMHAPONILI_PlayerIds.Add(CBPJPNIFJOI[i].MLPEHNBNOGD_PlayerId);
					}
				}
			}
			req.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(1);
			req.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
			{
				//0xFD8948
				if(FPPNANIIODA.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data))
				{
					for(int i = 0; i < CBPJPNIFJOI.Count; i++)
					{
						if(CBPJPNIFJOI[i].MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id)
						{
							CBPJPNIFJOI[i].LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
						}
					}
					return true;
				}
				return false;
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request BHGCOECCPCO) =>
			{
				//0xFD8B08
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess();
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request MEOKEBAMPLA) =>
			{
				//0xFD8B54
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_AOCANKOMKFG_OnError();
			};
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}
	}

	// // RVA: 0x94BA5C Offset: 0x94BA5C VA: 0x94BA5C
	private bool NLEFCEBIGGO_HasMissingPlayersInfo()
	{
		for(int i = 0; i < CBPJPNIFJOI.Count; i++)
		{
			if(string.IsNullOrEmpty(CBPJPNIFJOI[i].LBODHBDOMGK_PlayerName))
				return true;
		}
		return false;
	}

	// // RVA: 0x94BB48 Offset: 0x94BB48 VA: 0x94BB48
	// public void EPLLCEFGKBH(Action<bool> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x94BC24 Offset: 0x94BC24 VA: 0x94BC24
	// public void GMIPFKHCDCA(Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x94BD00 Offset: 0x94BD00 VA: 0x94BD00
	public void AMBHKLLAJID(Action<int, int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		IEFFGONGBCD_GetMyRaidBosses((List<NCMFOICNJEB<EBHIMFFJBIJ>> DIDOEKOBNNJ) =>
		{
			//0xFD8D04
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave();
			int res = 0;
			for(int i = 0; i < DIDOEKOBNNJ.Count; i++)
			{
				res += save.HBHCCLGECOC_MyBossId != DIDOEKOBNNJ[i].PPFNGGCBJKC_id && !save.OFJNLMIHMDE(DIDOEKOBNNJ[i].PPFNGGCBJKC_id) ? 1 : 0;
			}
			_BHFHGFKBOHH_OnSuccess(DIDOEKOBNNJ.Count, res);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x949A88 Offset: 0x949A88 VA: 0x949A88
	private void IEFFGONGBCD_GetMyRaidBosses(Action<List<NCMFOICNJEB<EBHIMFFJBIJ>>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			EAOJEDAEIJN_GetMyRaidbosses req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new EAOJEDAEIJN_GetMyRaidbosses());
			PLOOEECNHFB_IsDone = false;
			NPNNPNAIONN_IsError = false;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
			{
				//0xFD8EF8
				EAOJEDAEIJN_GetMyRaidbosses r = _HKICMNAACDA_a as EAOJEDAEIJN_GetMyRaidbosses;
				_BHFHGFKBOHH_OnSuccess(r.NFEAMMJIMPG_Result.DKNENAKHNAP);
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
			{
				//0xFD8FDC
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_MOBEEPPKFLG_OnFail();
			};
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail();
		}
    }

	// // RVA: 0x94BDF4 Offset: 0x94BDF4 VA: 0x94BDF4
	// public void ENBNOMKDLFC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x94BE20 Offset: 0x94BE20 VA: 0x94BE20
	public void PDPFNKCIJOP_GetBosses_WithPlayersFullInfo(MJFMOPMOFDJ DACHLLPBFPI, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		DOECBDLGILJ_GetBosses(DACHLLPBFPI, MALKHIMMLDI_RequestType.OOEHFFBHCIC_2_Full, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
	}

	// // RVA: 0x94BE48 Offset: 0x94BE48 VA: 0x94BE48
	public void GKCEHODEPMJ_GetBosses_WithOptionalPlayersNames(bool EKPADKHKCKO, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		DOECBDLGILJ_GetBosses(JIBMOEHKMGB_SelectedBoss, EKPADKHKCKO ? MALKHIMMLDI_RequestType.NPGGGMACPLD_1_AttackersIdOnly : MALKHIMMLDI_RequestType.HJNNKCMLGFL_0_None, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
	}

	// // RVA: 0x94AB1C Offset: 0x94AB1C VA: 0x94AB1C
	private void DOECBDLGILJ_GetBosses(MJFMOPMOFDJ DACHLLPBFPI, MALKHIMMLDI_RequestType _CNDDKMJAIBG_mode, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		JKCDLPOPCGC_GetRaidboss req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JKCDLPOPCGC_GetRaidboss());
		req.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = DACHLLPBFPI.PPFNGGCBJKC_id;
		if(_CNDDKMJAIBG_mode == MALKHIMMLDI_RequestType.OOEHFFBHCIC_2_Full)
		{
			req.BIHCCEHLAOD.KAPGBMNCDDC_PlayerCount = 50;
			req.BIHCCEHLAOD.GACJGEENCKM_Namespaces = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(0x8000000005);
		}
		else
		{
			req.BIHCCEHLAOD.KAPGBMNCDDC_PlayerCount = _CNDDKMJAIBG_mode == MALKHIMMLDI_RequestType.NPGGGMACPLD_1_AttackersIdOnly ? 50 : 0;
			req.BIHCCEHLAOD.GACJGEENCKM_Namespaces = new List<string>();
		}
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
		{
			//0xFD9048
			JKCDLPOPCGC_GetRaidboss r = _HKICMNAACDA_a as JKCDLPOPCGC_GetRaidboss;
			NBPANDOEDJH(DACHLLPBFPI, r.NFEAMMJIMPG_Result.GJFJLEOGFLD_RaidBoss);
			DACHLLPBFPI.CAKONDPGDIL_CanRequestHelp = r.NFEAMMJIMPG_Result.GJFJLEOGFLD_RaidBoss.CAKONDPGDIL_CanRequestHelp;
			DACHLLPBFPI.CMCKNKKCNDK_status = r.NFEAMMJIMPG_Result.GJFJLEOGFLD_RaidBoss.CMCKNKKCNDK_status;
			DACHLLPBFPI.DLMNFENNCJG_HasAttacked = r.NFEAMMJIMPG_Result.GJFJLEOGFLD_RaidBoss.DLMNFENNCJG_HasAttacked;
			DACHLLPBFPI.ICCOOAAJEIN_CanReceiveReward = r.NFEAMMJIMPG_Result.GJFJLEOGFLD_RaidBoss.ICCOOAAJEIN_CanReceiveReward;
			DACHLLPBFPI.EMHHJNDOCMB(r.NFEAMMJIMPG_Result.GJFJLEOGFLD_RaidBoss.MGPCMCNFFIM_Effects);
			FMGJILBBNBJ_UpdateCoopBonus(DACHLLPBFPI);
			DACHLLPBFPI.PIPOJJGBGLB();
			if(_CNDDKMJAIBG_mode == MALKHIMMLDI_RequestType.NPGGGMACPLD_1_AttackersIdOnly)
			{
				int dam = int.MaxValue;
				int b = 0;
				int c = 1;
				for(int i = 0; i < r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers.Count; i++)
				{
					int a = 0;
					if(r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId != DACHLLPBFPI.MLPEHNBNOGD_PlayerId)
					{
						if(r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage < dam)
						{
							dam = r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage;
							b = c;
						}
						a = b;
						c++;
					}
					if(MFAFEBNEEHE_IsMyself(r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId))
					{
						DACHLLPBFPI.GCKGHNBHOPH_Rank = a;
						DACHLLPBFPI.AEGFDINOACE_PlayerDamage = r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage;
						break;
					}
				}
				if(r.NFEAMMJIMPG_Result.COGCGJLFDKG_FirstAttackPlayer != null)
				{
					MJFMOPMOFDJ.CALIFIMGGMD pData = new MJFMOPMOFDJ.CALIFIMGGMD();
					pData.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.COGCGJLFDKG_FirstAttackPlayer.MLPEHNBNOGD_PlayerId;
					DACHLLPBFPI.NBBMHALJCMK_FirstAttackPlayer = pData;
				}
			}
			else if(_CNDDKMJAIBG_mode == MALKHIMMLDI_RequestType.OOEHFFBHCIC_2_Full)
			{
				int pId = 0;
				if(r.NFEAMMJIMPG_Result.COGCGJLFDKG_FirstAttackPlayer != null)
				{
					pId = r.NFEAMMJIMPG_Result.COGCGJLFDKG_FirstAttackPlayer.MLPEHNBNOGD_PlayerId;
				}
				int dam = int.MaxValue;
				int rank = 1;
				int c = 1;
				for(int i = 0; i < r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers.Count; i++)
				{
					if(r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId == DACHLLPBFPI.MLPEHNBNOGD_PlayerId)
					{
						if(MFAFEBNEEHE_IsMyself(r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId))
						{
							DACHLLPBFPI.AEGFDINOACE_PlayerDamage = r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage;
						}
					}
					else
					{
						BBHNACPENDM_ServerSaveData sData = new BBHNACPENDM_ServerSaveData();
						sData.EBKCPELHDKN_InitWithBaseAndPublicStatus();
						if(!sData.IIEMACPEEBJ_Deserialize(r.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG_Result.CFFDADAKJPB_AttackPlayers[i].AHEFHIMGIBI_PlayerData))
						{
							break;
						}
						MJFMOPMOFDJ.CALIFIMGGMD pData = new MJFMOPMOFDJ.CALIFIMGGMD();
						pData.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.COGCGJLFDKG_FirstAttackPlayer.MLPEHNBNOGD_PlayerId;
						OFAHKDKDGAN(pData, sData);
						pData.HALIDDHLNEG_Damage = r.NFEAMMJIMPG_Result.COGCGJLFDKG_FirstAttackPlayer.HALIDDHLNEG_Damage;
						if(pData.HALIDDHLNEG_Damage < dam)
						{
							pData.FJOLNJLLJEJ_rank = rank;
							c = rank;
							dam = pData.HALIDDHLNEG_Damage;
						}
						else
						{
							pData.FJOLNJLLJEJ_rank = c;
						}
						DACHLLPBFPI.IDALEDJHEMF(pData);
						if(pData.MLPEHNBNOGD_PlayerId == pId)
						{
							DACHLLPBFPI.NBBMHALJCMK_FirstAttackPlayer = pData;
						}
						rank++;
						if(MFAFEBNEEHE_IsMyself(pData.MLPEHNBNOGD_PlayerId))
						{
							DACHLLPBFPI.KGPKFAFHEFP(pData);
						}
					}
				}
			}
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
		{
			//0xFD9A64
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_AOCANKOMKFG_OnError();
		};
	}

	// // RVA: 0x94BE74 Offset: 0x94BE74 VA: 0x94BE74
	public bool LMIFOCDCNAI()
	{
		return HEMEDMMBIBH_GetBossHelpCountLeft(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id) > 0 && !KIHAEAEEFJE_IsOverLimitHelp(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id) && PBJBHONLMKF_MyBoss.DNJGAJPIIPI_IsValid && NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() >= GCDHLLHHIHA_GetNextRequestTime(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
	}

	// // RVA: 0x94C404 Offset: 0x94C404 VA: 0x94C404
	public void MCKDAPPELKJ_RequestBossHelp(bool _PJJLOFMLOMN_OnlyMyLobby, bool __MCMPOEHAIHP_PrioFriend, OGFPKBBOFFH _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		if(BAEPGOAMBDK("request_help_ver", 1) < 2)
		{
			N.a.StartCoroutineWatched(BBMJANLENGH_Coroutine_RequestBossHelp(_PJJLOFMLOMN_OnlyMyLobby, __MCMPOEHAIHP_PrioFriend, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError, KLNFKFKNBHC, OEJDHFBAMEO, GKLMHPLFLHJ, CCFPBMOJBNK, OPGIFOEKHPF));
		}
		else
		{
			N.a.StartCoroutineWatched(FMLIOLJNADH_Coroutine_RequestBossHelp_V2(_PJJLOFMLOMN_OnlyMyLobby, __MCMPOEHAIHP_PrioFriend, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError, KLNFKFKNBHC, OEJDHFBAMEO, GKLMHPLFLHJ, CCFPBMOJBNK, OPGIFOEKHPF));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD55C Offset: 0x6BD55C VA: 0x6BD55C
	// // RVA: 0x94C54C Offset: 0x94C54C VA: 0x94C54C
	private IEnumerator FMLIOLJNADH_Coroutine_RequestBossHelp_V2(bool _PJJLOFMLOMN_OnlyMyLobby, bool __MCMPOEHAIHP_PrioFriend, OGFPKBBOFFH _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server; // 0x3C
		string MOONABDCPDD; // 0x40
		string FKGJIBCFJED; // 0x44
		int DOLLGOFIMAE; // 0x48
		int NHODLNIICHK; // 0x4C
		int FCLOLNNNAGL; // 0x50
		int OGBDIKJGKKF; // 0x54
		int DJJAMHHLOPD; // 0x58
		LNGMNNNJBJP_SearchForPlayer LILFADBFJDN; // 0x5C
		LNGMNNNJBJP_SearchForPlayer DPHDPGDCBCE; // 0x60

		//0xFE4EDC
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		StringBuilder str = new StringBuilder(64);
		str.Set("lobby_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		MOONABDCPDD = str.ToString();
		str = new StringBuilder(64);
		str.Set("lobby_cluster_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		FKGJIBCFJED = str.ToString();
		DJJAMHHLOPD = 0;
		DOLLGOFIMAE = 0;
		NHODLNIICHK = 0;
		FCLOLNNNAGL = 0;
		OGBDIKJGKKF = 0;
		KLOJEBGOGPO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, out DJJAMHHLOPD, out OGBDIKJGKKF);
		HEOFEABCBCC(out FCLOLNNNAGL, out NHODLNIICHK);
		int EKADNPHNIHN = 0;
		LILFADBFJDN = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
		if(!_PJJLOFMLOMN_OnlyMyLobby)
		{
			LILFADBFJDN.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo(FKGJIBCFJED, NHODLNIICHK, FCLOLNNNAGL);
			DOLLGOFIMAE = BAEPGOAMBDK("zentai_help_friend_max_num", 5);
		}
		else
		{
			LILFADBFJDN.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo(MOONABDCPDD, OGBDIKJGKKF, DJJAMHHLOPD);
			if(!__MCMPOEHAIHP_PrioFriend)
				DOLLGOFIMAE = BAEPGOAMBDK("lobby_help_friend_max_num2", 2);
			else
				DOLLGOFIMAE = BAEPGOAMBDK("lobby_help_friend_max_num", 7);
		}
		LILFADBFJDN.IPKCADIAAPG_Criteria.OnlyFriends = true;
		LILFADBFJDN.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		LILFADBFJDN.HHIHCJKLJFF_Names = new List<string>();
		LILFADBFJDN.MLPLGFLKKLI_Ipp = DOLLGOFIMAE;
		LILFADBFJDN.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0xFD9AD0
			if(_MLEHCBKPNGK_IsFriend)
				EKADNPHNIHN++;
			return true;
		};
		while(!LILFADBFJDN.PLOOEECNHFB_IsDone)
			yield return null;
		if(!LILFADBFJDN.NPNNPNAIONN_IsError)
		{
			int CAKBAKJCCFM = 0;
			DPHDPGDCBCE = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
			if(!_PJJLOFMLOMN_OnlyMyLobby)
			{
				DPHDPGDCBCE.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo(FKGJIBCFJED, NHODLNIICHK, FCLOLNNNAGL);
			}
			else
			{
				DPHDPGDCBCE.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo(MOONABDCPDD, OGBDIKJGKKF, DJJAMHHLOPD);
			}
			DPHDPGDCBCE.IPKCADIAAPG_Criteria.OnlyFriends = false;
			DPHDPGDCBCE.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			DPHDPGDCBCE.HHIHCJKLJFF_Names = new List<string>();
			DPHDPGDCBCE.MLPLGFLKKLI_Ipp = JCBDKEPCLKG_GetRaidBossHelpMaxCount();
			DPHDPGDCBCE.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
			{
				//0xFD9AEC
				CAKBAKJCCFM++;
				return true;
			};
			while(!DPHDPGDCBCE.PLOOEECNHFB_IsDone)
				yield return null;
			if(!DPHDPGDCBCE.NPNNPNAIONN_IsError)
			{
				if(CAKBAKJCCFM > 0)
				{
					if(EKADNPHNIHN < 0)
					{
						EKADNPHNIHN = 0;
					}
					if(DOLLGOFIMAE < EKADNPHNIHN)
					{
						EKADNPHNIHN = DOLLGOFIMAE;
					}
					ENBPNDFOOCK_RequestRaidbossHelp KCLPLDHANEA = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new ENBPNDFOOCK_RequestRaidbossHelp());
					KCLPLDHANEA.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
					{
						//0xFD62FC
						if(LJJGBICGLLF != SakashoErrorId.RAIDBOSS_ESCAPED)
						{
							return LJJGBICGLLF >= SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED && LJJGBICGLLF < SakashoErrorId.RAIDBOSS_REWARD_ALREADY_RECEIVED;
						}
						return true;
					};
					KCLPLDHANEA.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id;
					KCLPLDHANEA.BIHCCEHLAOD.IHIANEHALAD_FriendPlayerCount = EKADNPHNIHN;
					KCLPLDHANEA.BIHCCEHLAOD.NIKGBLBENGD_OtherPlayerCount = JCBDKEPCLKG_GetRaidBossHelpMaxCount() - EKADNPHNIHN;
					KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(0x8000000005);
					if(!_PJJLOFMLOMN_OnlyMyLobby)
					{
						KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = NHODLNIICHK;
						KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = FCLOLNNNAGL;
						KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = FKGJIBCFJED;
					}
					else
					{
						KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = OGBDIKJGKKF;
						KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = DJJAMHHLOPD;
						KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = MOONABDCPDD;
					}
					KCLPLDHANEA.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
					{
						//0xFD9B00
						ENBPNDFOOCK_RequestRaidbossHelp r = _HKICMNAACDA_a as ENBPNDFOOCK_RequestRaidbossHelp;
						int c = r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players.Count;
						int c2 = r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players.Count;
						List<ECICDAPCMJG> MOCDACANBIG = new List<ECICDAPCMJG>(c + c2);
						List<int> EJIBHPFHDKC = new List<int>(c + c2);
						int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.AHJDJACMFMN_GetPushTimeSlotIndex(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						for(int i = 0; i < r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players.Count; i++)
						{
							if(!FPPNANIIODA.IIEMACPEEBJ_Deserialize(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players[i].AHEFHIMGIBI_PlayerData))
							{
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
								_AOCANKOMKFG_OnError();
								return;
							}
							ECICDAPCMJG e = new ECICDAPCMJG();
							e.HKAIJKGODHC = true;
							e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
							e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players[i].MLPEHNBNOGD_PlayerId;
							e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
							MOCDACANBIG.Add(e);
							if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
							{
								EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
							}
						}
						for(int i = 0; i < r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players.Count; i++)
						{
							if(!FPPNANIIODA.IIEMACPEEBJ_Deserialize(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players[i].AHEFHIMGIBI_PlayerData))
							{
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
								_AOCANKOMKFG_OnError();
								return;
							}
							ECICDAPCMJG e = new ECICDAPCMJG();
							e.HKAIJKGODHC = false;
							e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
							e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players[i].MLPEHNBNOGD_PlayerId;
							e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
							MOCDACANBIG.Add(e);
							if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
							{
								EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
							}
						}
						PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = false;
						MCEJJBANCDA = PBJBHONLMKF_MyBoss;
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.BEKIJHOCDFE_28_RaidRequestBossHelp);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DCFBLGLFJDO_20_DailyMissionCompleted);
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.ADCDEIPMKJI_19_NumEventMission);
						if(EJIBHPFHDKC.Count > 0)
						{
							KIGJMPILEFC_IncRequestCount(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
						}
						JIOEILLGDCG_SetLastRequestTime(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
						ILCCJNDFFOB.HHCJCDFCLOB.BACAKFPEMAF(this, true, __MCMPOEHAIHP_PrioFriend, MOCDACANBIG);
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
						{
							//0xFDAAD8
							PLOOEECNHFB_IsDone = true;
							if(!PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial || EJIBHPFHDKC.Count == 0)
							{
								PLOOEECNHFB_IsDone = true;
								_BHFHGFKBOHH_OnSuccess(MOCDACANBIG);
							}
							else
							{
								LKDGDNOOGND(EJIBHPFHDKC, () =>
								{
									//0xFDB568
									PLOOEECNHFB_IsDone = true;
									_BHFHGFKBOHH_OnSuccess(MOCDACANBIG);
								}, () =>
								{
									//0xFDA8A4
									PLOOEECNHFB_IsDone = true;
									NPNNPNAIONN_IsError = true;
									_AOCANKOMKFG_OnError();
								});
							}
						}, () =>
						{
							//0xFDA908
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							_AOCANKOMKFG_OnError();
						}, null);
						return;
					};
					KCLPLDHANEA.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
					{
						//0xFDA96C
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_ESCAPED)
						{
							OEJDHFBAMEO();
						}
						else if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_HELP_ALREADY_REQUESTED)
						{
							GKLMHPLFLHJ();
						}
						else if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_KILLED)
						{
							CCFPBMOJBNK();
						}
						else if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED)
						{
							OPGIFOEKHPF();
							JDDCHPCBKLM_IncOverLimitHelp(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
						}
						else
						{
							_AOCANKOMKFG_OnError();
						}
					};
					yield break;
				}
				else
				{
					KLNFKFKNBHC();
					yield break;
				}
			}
		}
		PLOOEECNHFB_IsDone = true;
		NPNNPNAIONN_IsError = true;
		_AOCANKOMKFG_OnError();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD5D4 Offset: 0x6BD5D4 VA: 0x6BD5D4
	// // RVA: 0x94C6C4 Offset: 0x94C6C4 VA: 0x94C6C4
	private IEnumerator BBMJANLENGH_Coroutine_RequestBossHelp(bool _PJJLOFMLOMN_OnlyMyLobby, bool __MCMPOEHAIHP_PrioFriend, OGFPKBBOFFH _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		StringBuilder ABMADBCLLHH; // 0x38
		StringBuilder IFCAJOKCFGI; // 0x3C
		int MIEHDOMFBNH; // 0x40
		int LIEFBJJIDOC; // 0x44
		int MICBFIOOCOL; // 0x48
		int KBCCFLDOFFN; // 0x4C
		LNGMNNNJBJP_SearchForPlayer GFCGNLCDNNG; // 0x50

		//0xFE3EB8
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		ABMADBCLLHH = new StringBuilder(64);
		ABMADBCLLHH.Set("lobby_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		IFCAJOKCFGI = new StringBuilder(64);
		IFCAJOKCFGI.Set("lobby_cluster_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		MIEHDOMFBNH = 0;
		LIEFBJJIDOC = 0;
		MICBFIOOCOL = 0;
		KBCCFLDOFFN = 0;
		KLOJEBGOGPO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, out KBCCFLDOFFN, out MICBFIOOCOL);
		HEOFEABCBCC(out LIEFBJJIDOC, out MIEHDOMFBNH);
		GFCGNLCDNNG = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
		if(!_PJJLOFMLOMN_OnlyMyLobby)
		{
			GFCGNLCDNNG.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo(IFCAJOKCFGI.ToString(), MIEHDOMFBNH, LIEFBJJIDOC);
		}
		else
		{
			GFCGNLCDNNG.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo(ABMADBCLLHH.ToString(), MIEHDOMFBNH, LIEFBJJIDOC);
		}
		GFCGNLCDNNG.IPKCADIAAPG_Criteria.OnlyFriends = false;
		GFCGNLCDNNG.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		GFCGNLCDNNG.HHIHCJKLJFF_Names = new List<string>();
		GFCGNLCDNNG.MLPLGFLKKLI_Ipp = JCBDKEPCLKG_GetRaidBossHelpMaxCount();
		int EKADNPHNIHN = 0;
		int GPBOOEHCCNC = 0;
		GFCGNLCDNNG.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0xFDB5E8
			if(_MLEHCBKPNGK_IsFriend)
				EKADNPHNIHN++;
			GPBOOEHCCNC++;
			return true;
		};
		GFCGNLCDNNG.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
		{
			//0xFDB610
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_AOCANKOMKFG_OnError();
		};
		while(!GFCGNLCDNNG.PLOOEECNHFB_IsDone)
			yield return null;
		if(!GFCGNLCDNNG.NPNNPNAIONN_IsError)
		{
			if(GPBOOEHCCNC < 1)
			{
				KLNFKFKNBHC();
			}
			else
			{
				int c = Mathf.Min(EKADNPHNIHN, JCBDKEPCLKG_GetRaidBossHelpMaxCount());
				if(!__MCMPOEHAIHP_PrioFriend)
					c = UnityEngine.Random.Range(0, c + 1);
				ENBPNDFOOCK_RequestRaidbossHelp KCLPLDHANEA = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new ENBPNDFOOCK_RequestRaidbossHelp());
				KCLPLDHANEA.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
				{
					//0xFD631C
					if(LJJGBICGLLF != SakashoErrorId.RAIDBOSS_ESCAPED)
					{
						return LJJGBICGLLF >= SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED && LJJGBICGLLF < SakashoErrorId.RAIDBOSS_REWARD_ALREADY_RECEIVED;
					}
					return true;
				};
				KCLPLDHANEA.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id;
				KCLPLDHANEA.BIHCCEHLAOD.IHIANEHALAD_FriendPlayerCount = c;
				KCLPLDHANEA.BIHCCEHLAOD.NIKGBLBENGD_OtherPlayerCount = JCBDKEPCLKG_GetRaidBossHelpMaxCount() - c;
				KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(0x8000000005);
				if(!_PJJLOFMLOMN_OnlyMyLobby)
				{
					KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = MIEHDOMFBNH;
					KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = LIEFBJJIDOC;
					KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = IFCAJOKCFGI.ToString();
				}
				else
				{
					KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = MICBFIOOCOL;
					KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = KBCCFLDOFFN;
					KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = ABMADBCLLHH.ToString();
				}
				KCLPLDHANEA.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
				{
					//0xFDB674	
					ENBPNDFOOCK_RequestRaidbossHelp r = _HKICMNAACDA_a as ENBPNDFOOCK_RequestRaidbossHelp;
					int c3 = r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players.Count;
					int c2 = r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players.Count;
					List<ECICDAPCMJG> MOCDACANBIG = new List<ECICDAPCMJG>(c3 + c2);
					List<int> EJIBHPFHDKC = new List<int>(c3 + c2);
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.AHJDJACMFMN_GetPushTimeSlotIndex(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
					for(int i = 0; i < r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players.Count; i++)
					{
						if(!FPPNANIIODA.IIEMACPEEBJ_Deserialize(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players[i].AHEFHIMGIBI_PlayerData))
						{
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							_AOCANKOMKFG_OnError();
							return;
						}
						ECICDAPCMJG e = new ECICDAPCMJG();
						e.HKAIJKGODHC = true;
						e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
						e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.LBMEJEDJJFM_friend_help_players[i].MLPEHNBNOGD_PlayerId;
						e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
						MOCDACANBIG.Add(e);
						if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
						{
							EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
						}
					}
					for(int i = 0; i < r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players.Count; i++)
					{
						if(!FPPNANIIODA.IIEMACPEEBJ_Deserialize(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players[i].AHEFHIMGIBI_PlayerData))
						{
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							_AOCANKOMKFG_OnError();
							return;
						}
						ECICDAPCMJG e = new ECICDAPCMJG();
						e.HKAIJKGODHC = false;
						e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
						e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG_Result.ENDAPLAFFAI_other_help_players[i].MLPEHNBNOGD_PlayerId;
						e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
						MOCDACANBIG.Add(e);
						if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
						{
							EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
						}
					}
					PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = false;
					MCEJJBANCDA = PBJBHONLMKF_MyBoss;
					HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.BEKIJHOCDFE_28_RaidRequestBossHelp);
					HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DCFBLGLFJDO_20_DailyMissionCompleted);
					HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.ADCDEIPMKJI_19_NumEventMission);
					ILCCJNDFFOB.HHCJCDFCLOB.BACAKFPEMAF(this, _PJJLOFMLOMN_OnlyMyLobby, __MCMPOEHAIHP_PrioFriend, MOCDACANBIG);
					if(EJIBHPFHDKC.Count > 0)
					{
						KIGJMPILEFC_IncRequestCount(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
					}
					JIOEILLGDCG_SetLastRequestTime(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xFDC650
						PLOOEECNHFB_IsDone = true;
						if(!PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial || EJIBHPFHDKC.Count == 0)
						{
							PLOOEECNHFB_IsDone = true;
							_BHFHGFKBOHH_OnSuccess(MOCDACANBIG);
						}
						else
						{
							LKDGDNOOGND(EJIBHPFHDKC, () =>
							{
								//0xFDC8B8
								PLOOEECNHFB_IsDone = true;
								_BHFHGFKBOHH_OnSuccess(MOCDACANBIG);
							}, () =>
							{
								//0xFDC41C
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
								_AOCANKOMKFG_OnError();
							});
						}
					}, () =>
					{
						//0xFDC480
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						_AOCANKOMKFG_OnError();
					}, null);
					return;
				};
				KCLPLDHANEA.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
				{
					//0xFDC4E4
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
					if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_ESCAPED)
					{
						OEJDHFBAMEO();
					}
					else if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_HELP_ALREADY_REQUESTED)
					{
						GKLMHPLFLHJ();
					}
					else if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_KILLED)
					{
						CCFPBMOJBNK();
					}
					else if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED)
					{
						OPGIFOEKHPF();
						JDDCHPCBKLM_IncOverLimitHelp(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_id);
					}
					else
					{
						_AOCANKOMKFG_OnError();
					}
				};
			}
		}
	}

	// // RVA: 0x94C838 Offset: 0x94C838 VA: 0x94C838
	private void LKDGDNOOGND(List<int> EJIBHPFHDKC, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			if(EJIBHPFHDKC.Count > 0)
			{
				KLABCICOJJN_SendPushNotification req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KLABCICOJJN_SendPushNotification());
				req.DBBNIEHJGHH = KLABCICOJJN_SendPushNotification.FMMLHEIOFBO();
				req.DBBNIEHJGHH.AndroidMessageTitle = ev.EFEGBHACJAL_GetStringParam("push_ex_help_title_text", JpStringLiterals.StringLiteral_13160);
				req.DBBNIEHJGHH.Message = ev.EFEGBHACJAL_GetStringParam("push_ex_help_main_text", JpStringLiterals.StringLiteral_13162);
				req.NBFDEFGFLPJ = (SakashoErrorId FMEMECBIDIB) =>
				{
					//0xFD633C
					return true;
				};
				req.IFMENOJDKBF = EJIBHPFHDKC;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
				{
					//0xFDC938
					_BHFHGFKBOHH_OnSuccess();
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
				{
					//0xFDC964
					_BHFHGFKBOHH_OnSuccess();
				};
				return;
			}
		}
		_BHFHGFKBOHH_OnSuccess();
    }

	// // RVA: 0x94CC78 Offset: 0x94CC78 VA: 0x94CC78
	public int CBDMCDKKFBE_GetNeedAp(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && !ACDLEBPMEIH(JIBMOEHKMGB_SelectedBoss))
		{
			return CMMDPDMNNKP(ev, _INDDJNMPONH_type).JIMJHIDEHNM_ApCounter;
		}
		return 0;
	}

	// // RVA: 0x94D014 Offset: 0x94D014 VA: 0x94D014
	public int CBDMCDKKFBE_GetNeedAp()
	{
		return CBDMCDKKFBE_GetNeedAp(CFLEMFADGLG_AttackType);
	}

	// // RVA: 0x94D01C Offset: 0x94D01C VA: 0x94D01C
	public void FDNIODNLDAI(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _INDDJNMPONH_type)
	{
		CFLEMFADGLG_AttackType = _INDDJNMPONH_type;
	}

	// // RVA: 0x94D024 Offset: 0x94D024 VA: 0x94D024
	public void KMDELKHBDNN(MJFMOPMOFDJ DACHLLPBFPI)
	{
		JIBMOEHKMGB_SelectedBoss = DACHLLPBFPI;
	}

	// // RVA: 0x94D02C Offset: 0x94D02C VA: 0x94D02C
	public void LGJNILBEIKA_AttackBoss(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _CFLEMFADGLG_AttackType, int _HALIDDHLNEG_Damage, bool NFHDKELECKO, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK _AOCANKOMKFG_OnError, string _MDADLCOCEBN_session_id)
	{
		N.a.StartCoroutineWatched(ICBALAJFBND_Coroutine_AttackBoss(_CFLEMFADGLG_AttackType, _HALIDDHLNEG_Damage, NFHDKELECKO, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError, _MDADLCOCEBN_session_id));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD64C Offset: 0x6BD64C VA: 0x6BD64C
	// // RVA: 0x94D0A8 Offset: 0x94D0A8 VA: 0x94D0A8
	private IEnumerator ICBALAJFBND_Coroutine_AttackBoss(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _CFLEMFADGLG_AttackType, int _HALIDDHLNEG_Damage, bool NFHDKELECKO, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK _AOCANKOMKFG_OnError, string _MDADLCOCEBN_session_id)
	{
		//0xFE1850
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM NHLBKJCPLBL = KNKJHNJFONJ_GetEvSave();
		if(NHLBKJCPLBL != null)
		{
			PLOOEECNHFB_IsDone = false;
			NPNNPNAIONN_IsError = false;
			bool JCGDKLJEPKJ = false;
			yield return Co.R(NEADNOHFNJH_Coroutine_DummyBeforeAttackBoss(() =>
			{
				//0xFD6344
				return;
			}, () =>
			{
				//0xFDC998
				JCGDKLJEPKJ = true;
			}));
			if(!JCGDKLJEPKJ)
			{
				long PDNBNOAHMKM = NHLBKJCPLBL.DNBFMLBNAEE_point;
				long LAACDMLCACB = NHLBKJCPLBL.NFIOKIBPJCJ_uptime;
				NHLBKJCPLBL.DNBFMLBNAEE_point += _HALIDDHLNEG_Damage;
				NHLBKJCPLBL.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				List<IKCGAJKCPFN> OFLLNJHBBBC = new List<IKCGAJKCPFN>(NHLBKJCPLBL.NNMPGOAGEOL_quests.Count);
				for(int i = 0; i < NHLBKJCPLBL.NNMPGOAGEOL_quests.Count; i++)
				{
					IKCGAJKCPFN ik = new IKCGAJKCPFN();
					ik.ODDIHGPONFL_Copy(NHLBKJCPLBL.NNMPGOAGEOL_quests[i]);
					OFLLNJHBBBC.Add(ik);
				}
				MCEJJBANCDA = JIBMOEHKMGB_SelectedBoss;
				NENNACLBKJJ = _HALIDDHLNEG_Damage;
				HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.EKKMNHIKGKF_36_RaidAttackType);
				if(_CFLEMFADGLG_AttackType == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType.EKIGHDLEBAH_4_MacrossCanon)
				{
					HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.OOGEAGAJKAG_30_MacrossCanon);
				}
				HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DCFBLGLFJDO_20_DailyMissionCompleted);
				HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.ADCDEIPMKJI_19_NumEventMission);
				CIOECGOMILE.HHCJCDFCLOB.FAMAFKMHFAK((PJKLMCGEJMK _CPHFEPHDJIB_ServerRequester, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string _JCJDPGMKJAJ_PlayerData) =>
				{
					//0xFDC9A4
					JPPCMHKHAGC_AttackRaidbossAndSave req2 = _CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new JPPCMHKHAGC_AttackRaidbossAndSave(NFHDKELECKO));
					req2.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id;
					req2.BIHCCEHLAOD.HALIDDHLNEG_Damage = _HALIDDHLNEG_Damage;
					req2.BIHCCEHLAOD.MHABJOMJCFI_AttackPlayerCount = 0;
					SakashoRaidbossEffectData NKDGDKKEPOO_EffectData = new SakashoRaidbossEffectData();
					NKDGDKKEPOO_EffectData.EffectId = !MFAFEBNEEHE_IsMyself(JIBMOEHKMGB_SelectedBoss.MLPEHNBNOGD_PlayerId) ? (int)_CFLEMFADGLG_AttackType + 5 : (int)_CFLEMFADGLG_AttackType;
					NKDGDKKEPOO_EffectData.NumberOfTimes = 1;
					NKDGDKKEPOO_EffectData.DurationSeconds = 86400;
					req2.BIHCCEHLAOD.NKDGDKKEPOO_EffectData = NKDGDKKEPOO_EffectData;
					req2.BIHCCEHLAOD.HOLACOMBPJH_NamespaceForResponse = new List<string>();
					req2.BIHCCEHLAOD.DOMFHDPMCCO_Init(JEHOEIKANFL, _JCJDPGMKJAJ_PlayerData);
					req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
					{
                        //0xFDCE14
                        JPPCMHKHAGC_AttackRaidbossAndSave r = _HKICMNAACDA_a as JPPCMHKHAGC_AttackRaidbossAndSave;
                        NBPANDOEDJH(JIBMOEHKMGB_SelectedBoss, r.NFEAMMJIMPG_Result.AKLNMPMLDAJ_RaidBoss);
                        JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_status = r.NFEAMMJIMPG_Result.AKLNMPMLDAJ_RaidBoss.CMCKNKKCNDK_status;
                        JIBMOEHKMGB_SelectedBoss.EMHHJNDOCMB(r.NFEAMMJIMPG_Result.AKLNMPMLDAJ_RaidBoss.MGPCMCNFFIM_Effects);
                        FMGJILBBNBJ_UpdateCoopBonus(JIBMOEHKMGB_SelectedBoss);
                        ILCCJNDFFOB.HHCJCDFCLOB.EEHEMNBJPAP_RaidBossAttack(this, _CFLEMFADGLG_AttackType, _HALIDDHLNEG_Damage, (int)NHLBKJCPLBL.DNBFMLBNAEE_point, NKDGDKKEPOO_EffectData,
							r.NFEAMMJIMPG_Result, _MDADLCOCEBN_session_id);
                    };
					req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
					{
                        //0xFDD194
                        NHLBKJCPLBL.DNBFMLBNAEE_point = PDNBNOAHMKM;
                        NHLBKJCPLBL.NFIOKIBPJCJ_uptime = LAACDMLCACB;
                        for (int i = 0; i < NHLBKJCPLBL.NNMPGOAGEOL_quests.Count; i++)
						{
                            NHLBKJCPLBL.NNMPGOAGEOL_quests[i].ODDIHGPONFL_Copy(OFLLNJHBBBC[i]);
                        }
						if(NFHDKELECKO)
						{
							if(JGJFFKPFMDB.PLMJFNPGOCD(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId))
							{
                                JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_status = NHCDBBBMFFG_BossStatus.NFDONDKDHPK_3_Escaped;
                                ILCCJNDFFOB.HHCJCDFCLOB.EEHEMNBJPAP_RaidBossAttack(this, _CFLEMFADGLG_AttackType, _HALIDDHLNEG_Damage, (int)NHLBKJCPLBL.DNBFMLBNAEE_point, NKDGDKKEPOO_EffectData, null, _MDADLCOCEBN_session_id);
                                return;
                            }
						}
                        NPNNPNAIONN_IsError = true;
                    };
					return req2;
				}, () =>
				{
					//0xFDCD38
					PLOOEECNHFB_IsDone = true;
					_BHFHGFKBOHH_OnSuccess();
				}, () =>
				{
					//0xFDCD84
					PLOOEECNHFB_IsDone = true;
					if(!NPNNPNAIONN_IsError)
					{
						_BHFHGFKBOHH_OnSuccess();
					}
					else
					{
						_MOBEEPPKFLG_OnFail();
					}
				});
				yield break;
			}
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		}
		_AOCANKOMKFG_OnError();
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD6C4 Offset: 0x6BD6C4 VA: 0x6BD6C4
	// // RVA: 0x94D1E4 Offset: 0x94D1E4 VA: 0x94D1E4
	private IEnumerator NEADNOHFNJH_Coroutine_DummyBeforeAttackBoss(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0xFE2F1C
		bool DCPKDAGALJO = false;
		do
		{
			bool GMMGNJODPMB = false;
			bool AEJMLBHEKCH = false;
			DPHJPMLCFCK req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DPHJPMLCFCK());
			req.NBFDEFGFLPJ = (SakashoErrorId _PPFNGGCBJKC_id) =>
			{
				//0xFD6348
				return _PPFNGGCBJKC_id == SakashoErrorId.NETWORK_ERROR;
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
			{
				//0xFDD5EC
				DCPKDAGALJO = true;
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request _HKICMNAACDA_a) =>
			{
				//0xFDD600
				if(_HKICMNAACDA_a.CJMFJOMECKI_ErrorId == SakashoErrorId.NETWORK_ERROR)
					GMMGNJODPMB = true;
				else
					AEJMLBHEKCH = true;
			};
			while(!GMMGNJODPMB && !DCPKDAGALJO && !AEJMLBHEKCH)
				yield return null;
			if(GMMGNJODPMB)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				bool LDPKJLNFHNN = false;
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = JpStringLiterals.StringLiteral_11918;
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = bk.GetMessageByLabel("pop_raid_attack_network_error");
				PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
				{
					//0xFDD648
					if(LHFGEOAJAAL == PopupButton.ButtonLabel.Cancel)
						AEJMLBHEKCH = true;
					LDPKJLNFHNN = true;
				}, null, null, null, true, true, false, null, null, null, null, null);
				while(!LDPKJLNFHNN)
					yield return null;
			}
			if(AEJMLBHEKCH)
			{
				_MOBEEPPKFLG_OnFail();
				yield break;
			}
		} while(!DCPKDAGALJO);
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x94D288 Offset: 0x94D288 VA: 0x94D288
	public void GNANMKPFDFE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int BMMPAHHEOJC, string _MDADLCOCEBN_session_id, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		LGJNILBEIKA_AttackBoss(CFLEMFADGLG_AttackType, ADNLNFMJHLM(OMNOFMEBLAD, ACMMDAHKCIF, BMMPAHHEOJC), true, () =>
		{
			//0x952690
			PLFBKEPLAAA.BBIGDCNEFMK = JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_status != NHCDBBBMFFG_BossStatus.NFDONDKDHPK_3_Escaped;
			HPBDHJCICPA(JIBMOEHKMGB_SelectedBoss, true, false, () =>
			{
				//0xFD6358
				return;
			}, () =>
			{
				//0x952844
				PLFBKEPLAAA.CMCKNKKCNDK_status = NHCDBBBMFFG_BossStatus.HJNNKCMLGFL_0_None;
			});
		}, () =>
		{
			//0x95286C
			PLFBKEPLAAA.CMCKNKKCNDK_status = NHCDBBBMFFG_BossStatus.HJNNKCMLGFL_0_None;
		}, _AOCANKOMKFG_OnError, _MDADLCOCEBN_session_id);
	}

	// // RVA: 0x94D38C Offset: 0x94D38C VA: 0x94D38C
	private int ADNLNFMJHLM(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int BMMPAHHEOJC)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        if (ev != null)
        {
            PLFBKEPLAAA = new OCBPJEALCPO();
            PLFBKEPLAAA.FCIBJNKGMOB_Damage = JIBMOEHKMGB_SelectedBoss.BCCOMAODPJI_hp;
            int score_bonus_denomi = ev.LPJLEHAJADA_GetIntParam("score_bonus_denomi", 1000);
            PLFBKEPLAAA.JKLNANHPJLO_ScorePoint = PLFBKEPLAAA.HJBBJIOOHAI(OMNOFMEBLAD.KNIFCANOHOC_score, score_bonus_denomi);
            int valkyrie_attack_denomi = ev.LPJLEHAJADA_GetIntParam("valkyrie_attack_denomi", 1000);
			PLFBKEPLAAA.CBKFBBNPIGG_ValkyriePoint = PLFBKEPLAAA.HJBBJIOOHAI(OMNOFMEBLAD.EHCFOHAABDA_EnemyLeft, valkyrie_attack_denomi);
            PLFBKEPLAAA.EAOCJMFLBJI_PointBonus = CMMDPDMNNKP(ev, CFLEMFADGLG_AttackType).KMHIOCCFPEM_PointBonus;
            int a = OIPALKMEJCA(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id, JIBMOEHKMGB_SelectedBoss.IKICLMGFFPB_IsSpecial, OMNOFMEBLAD);
            PLFBKEPLAAA.PAACIPCHDDE_MissionCompleted = a > 0;
            PLFBKEPLAAA.EAOCJMFLBJI_PointBonus += a;
            PLFBKEPLAAA.FOOCMHPJJAP_DivaBonus = ANMBIEIFKFF_UnitBonusInfo.HOJAKNJFIFJ_EpisodeBonusPoint;
            PLFBKEPLAAA.CLNPBIJBIIJ_SupportBonus = JIBMOEHKMGB_SelectedBoss.CLNPBIJBIIJ_SupportBonus + CMMDPDMNNKP(ev, CFLEMFADGLG_AttackType).PIABNPEFLEJ_SupportBonus;
            PLFBKEPLAAA.CLNPBIJBIIJ_SupportBonus = Mathf.Min(PLFBKEPLAAA.CLNPBIJBIIJ_SupportBonus, ev.LPJLEHAJADA_GetIntParam("coop_bonus_max", 100));
            PLFBKEPLAAA.LCOHGOIDMDF_ComboRank = (RhythmGameConsts.ResultComboType) OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
            PLFBKEPLAAA.DEHCKHMIENO(ev.LPJLEHAJADA_GetIntParam("attack_damage_denomi", 1000));
            PLFBKEPLAAA.DKKJPLALNFD_Skip = Database.Instance.gameSetup.EnableLiveSkip;
            PLFBKEPLAAA.ADHMMMEOJMK_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
            PLFBKEPLAAA.AKNELONELJK_difficulty = OMNOFMEBLAD.AKNELONELJK_difficulty;
            PLFBKEPLAAA.GIKLNODJKFK_IsLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6;
            return PLFBKEPLAAA.HALIDDHLNEG_Damage;
        }
        return 0;
    }

	// // RVA: 0x94DC5C Offset: 0x94DC5C VA: 0x94DC5C
	public void JKBOOMAPOBL(MJFMOPMOFDJ DACHLLPBFPI, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
        HPBDHJCICPA(DACHLLPBFPI, false, false, () =>
        {
            //0xFDD68C
			PLOOEECNHFB_IsDone = false;
			NPNNPNAIONN_IsError = false;
            CIOECGOMILE.HHCJCDFCLOB.LOOCNGEPAMI(() =>
			{
				//0xFDD820
				PLOOEECNHFB_IsDone = true;
                _BHFHGFKBOHH_OnSuccess();
            }, () =>
			{
                //0xFDD86C
                PLOOEECNHFB_IsDone = true;
                NPNNPNAIONN_IsError = true;
                _AOCANKOMKFG_OnError();
            }, DACHLLPBFPI.PPFNGGCBJKC_id);
        }, _AOCANKOMKFG_OnError);
    }

	// // RVA: 0x94DDB0 Offset: 0x94DDB0 VA: 0x94DDB0
	private void HPBDHJCICPA(MJFMOPMOFDJ DACHLLPBFPI, bool MCBICECCNGO, bool KHJPDCEFKMJ, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
        DOECBDLGILJ_GetBosses(DACHLLPBFPI, MALKHIMMLDI_RequestType.NPGGGMACPLD_1_AttackersIdOnly, () =>
        {
            //0xFDD8D8
            BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave();
			if(save != null)
			{
				if(!MCBICECCNGO)
				{
					if(DACHLLPBFPI.PPFNGGCBJKC_id == save.HBHCCLGECOC_MyBossId)
					{
                        IHPJMEKNJLP();
                    }
				}
				else
				{
                    PLFBKEPLAAA.CMCKNKKCNDK_status = DACHLLPBFPI.CMCKNKKCNDK_status;
                    PLFBKEPLAAA.GKHMIECGPJO_HpAfter = DACHLLPBFPI.BCCOMAODPJI_hp;
                    PLFBKEPLAAA.OGHIOGDPFJE_MaxHp = DACHLLPBFPI.PIKKHCGNGNN_HpMax;
                    PLFBKEPLAAA.HMNOKOEJDND_Rank = DACHLLPBFPI.GCKGHNBHOPH_Rank;
                    PLFBKEPLAAA.AEIMNLACMFA_Damage = DACHLLPBFPI.AEGFDINOACE_PlayerDamage;
					if(!KHJPDCEFKMJ)
					{
                        PLFBKEPLAAA.OIOPCIAGLEK_CannonBaseValue = PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge();
                        PLFBKEPLAAA.LFOPOHHEODG_ChargeBonus = save.BJBJHNJJCHL_AtkMcgBonus;
                        PLFBKEPLAAA.IHIJGIHNOAL_CannonGaugeAdd = (PLFBKEPLAAA.LFOPOHHEODG_ChargeBonus + 100) * CMMDPDMNNKP(ev, CFLEMFADGLG_AttackType).BMAHHKLNOGA_CanonBaseChargeValue / 100;
                        save.BJBJHNJJCHL_AtkMcgBonus = 0;
                        HOOENJBGDGM_AddMcGauge(PLFBKEPLAAA.IHIJGIHNOAL_CannonGaugeAdd);
                        StringBuilder str = new StringBuilder();
                        str.Append(PGIIDPEGGPI_EventId);
                        str.Append(':');
                        str.Append(DACHLLPBFPI.ANAJIAENLNB_lv);
                        str.Append(':');
                        str.Append(DACHLLPBFPI.IKICLMGFFPB_IsSpecial);
                        str.Append(':');
                        str.Append(DACHLLPBFPI.PPFNGGCBJKC_id);
                        str.Append(':');
                        str.Append(OAGBCBBHMPF.GNIPLCBMPEG_RaidAttackType[(int)CFLEMFADGLG_AttackType]);
                        ILCCJNDFFOB.HHCJCDFCLOB.MINOEGPNBIH_McCharge(PLFBKEPLAAA.IHIJGIHNOAL_CannonGaugeAdd, PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge(), 0, 0, "StringLiteral_13186", str.ToString());
                    }
                }
                KONJMFICNJJ_RewardsInfo = null;
				if(DACHLLPBFPI.ICCOOAAJEIN_CanReceiveReward)
				{
					if(DACHLLPBFPI.PPFNGGCBJKC_id == save.HBHCCLGECOC_MyBossId)
					{
						if(!MCBICECCNGO)
						{
                            save.BGOJNJLNLKE();
                        }
					}
					else
					{
                        save.PJCGNAKDOKH(DACHLLPBFPI.PPFNGGCBJKC_id);
                    }
                    DKBAOFGBPHO(DACHLLPBFPI);
                }
            }
			if(MCBICECCNGO)
			{
                NKOBMDPHNGP_EventRaidLobby lobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
                if (lobby != null)
                {
                    lobby.EGBFCCFICIF(HBJDIGBFNMP(PLFBKEPLAAA, DACHLLPBFPI, KHJPDCEFKMJ), () =>
                    {
                        //0xFDE2DC
                        EGBLOJJIKKJ(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
                    }, _AOCANKOMKFG_OnError);
                    return;
                }
            }
            EGBLOJJIKKJ(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
        }, _AOCANKOMKFG_OnError);
    }

	// // RVA: 0x94DF34 Offset: 0x94DF34 VA: 0x94DF34
	private NKOBMDPHNGP_EventRaidLobby.PEDPKDBKGIN HBJDIGBFNMP(OCBPJEALCPO LGHNGDCBDKI, MJFMOPMOFDJ BFPPAPMNEHA, bool KHJPDCEFKMJ)
	{
		NKOBMDPHNGP_EventRaidLobby.PEDPKDBKGIN res = new NKOBMDPHNGP_EventRaidLobby.PEDPKDBKGIN();
		if(!KHJPDCEFKMJ)
		{
            res.NANEGCHBEDN_IsFullCombo = LGHNGDCBDKI.LCOHGOIDMDF_ComboRank != RhythmGameConsts.ResultComboType.Complete;
            res.ADHMMMEOJMK_FreeMusicId = LGHNGDCBDKI.ADHMMMEOJMK_FreeMusicId;
            res.AKNELONELJK_difficulty = LGHNGDCBDKI.AKNELONELJK_difficulty;
            res.GIKLNODJKFK_IsLine6 = LGHNGDCBDKI.GIKLNODJKFK_IsLine6;
            res.HALIDDHLNEG_Damage = LGHNGDCBDKI.HALIDDHLNEG_Damage;
        }
		else
		{
            res.HALIDDHLNEG_Damage = LGHNGDCBDKI.HALIDDHLNEG_Damage;
        }
        res.INLLJNOMNGF_CannonAttack = KHJPDCEFKMJ;
        res.IGNJCGMLBDA_Defeat = BFPPAPMNEHA.ICCOOAAJEIN_CanReceiveReward;
        res.MFMPCHIJINJ_BossType = BFPPAPMNEHA.INDDJNMPONH_type;
        res.GJAOLNLFEBD_BossName = AGEJGHGEGFF_GetBossName(BFPPAPMNEHA.INDDJNMPONH_type);
        res.EJGDHAENIDC_BossRank = BFPPAPMNEHA.FJOLNJLLJEJ_rank;
        res.PCPODOMOFDH_BossSerieAttr = (int)NNDFMCHDJOH_GetBossSerie(BFPPAPMNEHA.INDDJNMPONH_type);
        res.JNBDLNBKDCO_BossImage = BFPPAPMNEHA.HPPDFBKEJCG_BgId;
        res.JPOIGNNOHJP_WavId = KFBDBBCCPBB(BFPPAPMNEHA.INDDJNMPONH_type);
        res.IKICLMGFFPB_IsSpecial = BMDEELGBBOI(BFPPAPMNEHA.INDDJNMPONH_type);
		res.AIOGBKCJLHM = this;
        res.DKKJPLALNFD_Skip = LGHNGDCBDKI.DKKJPLALNFD_Skip;
        return res;
    }

	// // RVA: 0x94E18C Offset: 0x94E18C VA: 0x94E18C
	// private uint FBGGEFFJJHB_xor() { }

	// // RVA: 0x94A47C Offset: 0x94A47C VA: 0x94A47C
	private int BCDFFKCOOFB(int KCNAEONFIBP, bool _MPKBLMCNHOM_MissionIsSpecial)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int a = 0;
			for(int i = 0; i < ev.HDMADAHNLDN_Missions.Count; i++)
			{
				a += ev.HDMADAHNLDN_Missions[i].JKMDPGCCAJP(_MPKBLMCNHOM_MissionIsSpecial);
			}
			PMBEODGMMBB_y = (uint)(KCNAEONFIBP ^ 0x15ab17a1);
			for(int i = 14; i > 0; i--)
			{
				PMBEODGMMBB_y ^= PMBEODGMMBB_y << 0xd;
				PMBEODGMMBB_y ^= PMBEODGMMBB_y >> 0x11;
				PMBEODGMMBB_y ^= PMBEODGMMBB_y << 5;
			}
			int b = (int)(PMBEODGMMBB_y & 0x7fffffff) % a;
			for(int i = 0; i < ev.HDMADAHNLDN_Missions.Count; i++)
			{
				b -= ev.HDMADAHNLDN_Missions[i].JKMDPGCCAJP(_MPKBLMCNHOM_MissionIsSpecial);
				if(b < 0)
				{
					return ev.HDMADAHNLDN_Missions[i].PPFNGGCBJKC_id;
				}
			}
		}
		return 1;
    }

	// // RVA: 0x94E1A8 Offset: 0x94E1A8 VA: 0x94E1A8
	private void IPEIKLJLCJL(int KCNAEONFIBP, bool _MPKBLMCNHOM_MissionIsSpecial)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(!save.MPOLPHDMBKA(KCNAEONFIBP))
			{
				save.BEDGDKOCGEE(KCNAEONFIBP, BCDFFKCOOFB(KCNAEONFIBP, _MPKBLMCNHOM_MissionIsSpecial), 0, 0, 0, 0, 0);
			}
        }
    }

	// // RVA: 0x94D978 Offset: 0x94D978 VA: 0x94D978
	private int OIPALKMEJCA(int KCNAEONFIBP, bool _MPKBLMCNHOM_MissionIsSpecial, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        if (ev != null)
        {
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			int FCBDGLEPGFJ_mid = 1;
			if(!save.LDJPDEHJFOC(KCNAEONFIBP, out FCBDGLEPGFJ_mid))
			{
                FCBDGLEPGFJ_mid = BCDFFKCOOFB(KCNAEONFIBP, _MPKBLMCNHOM_MissionIsSpecial);
            }
            BKOGPDBKFFJ_EventRaid.NJLOJAKKGFK d = ev.HDMADAHNLDN_Missions.Find((BKOGPDBKFFJ_EventRaid.NJLOJAKKGFK _MABBBOEAPAA_p) =>
            {
                //0xFDE320
                return _MABBBOEAPAA_p.PPFNGGCBJKC_id == FCBDGLEPGFJ_mid;
            });
			if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, d, OMNOFMEBLAD, this, false))
			{
                return d.ECEKNKIDING(_MPKBLMCNHOM_MissionIsSpecial);
            }
        }
        return 0;
    }

	// // RVA: 0x94E25C Offset: 0x94E25C VA: 0x94E25C
	private int DPJFFBMCAAL_GetRewardGroupId(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master, int _MFMPCHIJINJ_BossType, IEJAFPGDGNP_WinType KDIGPMIABEI)
	{
		if(KDIGPMIABEI == IEJAFPGDGNP_WinType.DBPDLIPKFAL_1_First)
		{
            return _NDFIEMPPMLF_master.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType).FCDNMBBPBKI_RewardFirst;
        }
		else if(KDIGPMIABEI == IEJAFPGDGNP_WinType.NIHKBNNICFB_Defeat_0)
		{
            return _NDFIEMPPMLF_master.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType).NNLAMKCDMEL_RewardDefeat;
        }
		else
		{
            return _NDFIEMPPMLF_master.POCOCNENCOE_GetBossInfo(_MFMPCHIJINJ_BossType).EPMCPGDIBHI_RewardMvp;
        }
	}

	// // RVA: 0x94E2F0 Offset: 0x94E2F0 VA: 0x94E2F0
	private void DKBAOFGBPHO(MJFMOPMOFDJ DACHLLPBFPI)
	{
        KONJMFICNJJ_RewardsInfo = new KJJDLBFDGDM();
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			BKOGPDBKFFJ_EventRaid.PIDMOGPJNNA a = ev.ODMCAHDEEBK(DACHLLPBFPI.ANAJIAENLNB_lv);
            KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards = NLDMEJLFFHD_GetRewards(ev, DPJFFBMCAAL_GetRewardGroupId(ev, DACHLLPBFPI.INDDJNMPONH_type, IEJAFPGDGNP_WinType.NIHKBNNICFB_Defeat_0), DACHLLPBFPI.IKICLMGFFPB_IsSpecial ? a.EHOBDMHPMHB_DefeatSpRewardCount : a.OJLDNEGBFFG_DefeatRewardCount);
            if(DACHLLPBFPI.GCKGHNBHOPH_Rank == 1)
			{
                KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards = NLDMEJLFFHD_GetRewards(ev, DPJFFBMCAAL_GetRewardGroupId(ev, DACHLLPBFPI.INDDJNMPONH_type, IEJAFPGDGNP_WinType.FGPLEPGICPO_Mvp_2), DACHLLPBFPI.IKICLMGFFPB_IsSpecial ? a.CAFDIAFJDKP_MvpSpRewardCount : a.JJELLPDAAEI_MvpRewardCount);
            }
			if(MFAFEBNEEHE_IsMyself(DACHLLPBFPI.NBBMHALJCMK_FirstAttackPlayer.MLPEHNBNOGD_PlayerId))
			{
                KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards = NLDMEJLFFHD_GetRewards(ev, DPJFFBMCAAL_GetRewardGroupId(ev, DACHLLPBFPI.INDDJNMPONH_type, IEJAFPGDGNP_WinType.DBPDLIPKFAL_1_First), DACHLLPBFPI.IKICLMGFFPB_IsSpecial ? a.DIGJFGFKEJC_FirstSpRewardCount : a.DIDNBKKKEDK_FirstRewardCount);
            }
            ILCCJNDFFOB.HHCJCDFCLOB.HONFKODFAPA_RaidBossReward(this, DACHLLPBFPI, KONJMFICNJJ_RewardsInfo);
            StringBuilder str = new StringBuilder();
            str.Append(PGIIDPEGGPI_EventId);
            str.Append(':');
            str.Append(DACHLLPBFPI.ANAJIAENLNB_lv);
            str.Append(':');
            str.Append(DACHLLPBFPI.IKICLMGFFPB_IsSpecial);
            str.Append(':');
            str.Append(DACHLLPBFPI.PPFNGGCBJKC_id);
			JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
            JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.DOENIIJNHNJ_31_RaidBossDefeat, str.ToString());
            for (int i = 0; i < KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards.Count; i++)
			{
                JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards[i].PPFNGGCBJKC_id, KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards[i].HMFFHLPNMPH_count, null, 0);
            }
            JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.HEKCMMMHFMA_32_RaidBossMVP, str.ToString());
            for (int i = 0; i < KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards.Count; i++)
			{
                JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards[i].PPFNGGCBJKC_id, KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards[i].HMFFHLPNMPH_count, null, 0);
            }
            JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.ADJKNFCENEA_33_RaidBossFirst, str.ToString());
            for (int i = 0; i < KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards.Count; i++)
			{
                JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards[i].PPFNGGCBJKC_id, KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards[i].HMFFHLPNMPH_count, null, 0);
            }
            MCEJJBANCDA = DACHLLPBFPI;
            HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.EBCMMPMCHIK_27_RaidAttackType);
			if(DACHLLPBFPI.GCKGHNBHOPH_Rank == 1)
			{
            	HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DMNIOHMDJEI_34_RaidAttackType);
			}
            HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.DCFBLGLFJDO_20_DailyMissionCompleted);
            HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.ADCDEIPMKJI_19_NumEventMission);
        }
    }

	// // RVA: 0x94EC44 Offset: 0x94EC44 VA: 0x94EC44
	private List<KJJDLBFDGDM.EGMFNKCKOLB> NLDMEJLFFHD_GetRewards(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master, int IBPFNNADAKM, int _KPIHBPMOGKL_LotCount)
	{
        BKOGPDBKFFJ_EventRaid.LDCCKEPPFMG d = _NDFIEMPPMLF_master.FNHDKHBNBBN_Rewards.Find((BKOGPDBKFFJ_EventRaid.LDCCKEPPFMG _JGNBPFCJLKI_d) =>
        {
            //0xFDE36C
            return _JGNBPFCJLKI_d.PPFNGGCBJKC_id == IBPFNNADAKM;
        });
        List<KJJDLBFDGDM.EGMFNKCKOLB> l = new List<KJJDLBFDGDM.EGMFNKCKOLB>(d.CMIGGBMMBKK_drop.Length);
        List<GAPINAADMPJ> l2 = new List<GAPINAADMPJ>(d.CMIGGBMMBKK_drop.Length);
        int t = 0;
        for(int i = 0; i < d.CMIGGBMMBKK_drop.Length; i++)
		{
			GAPINAADMPJ g = new GAPINAADMPJ();
            g.IDLHJIOMJBK_data = d.CMIGGBMMBKK_drop[i];
            g.HMFFHLPNMPH_count = 0;
            l2.Add(g);
			KJJDLBFDGDM.EGMFNKCKOLB e = new KJJDLBFDGDM.EGMFNKCKOLB();
            e.PPFNGGCBJKC_id = g.IDLHJIOMJBK_data.AIHOJKFNEEN_itm;
			e.HMFFHLPNMPH_count = 0;
            t += d.CMIGGBMMBKK_drop[i].EHKJFNAABMC_rat;
            l.Add(e);
        }
		for(int i = 0; i < _KPIHBPMOGKL_LotCount; i++)
		{
            int r = UnityEngine.Random.Range(0, t);
            for (int j = 0; j < l2.Count; j++)
			{
				GAPINAADMPJ DGHHMEDBPEE = l2[j];
                r -= DGHHMEDBPEE.IDLHJIOMJBK_data.EHKJFNAABMC_rat;
				if(r <= 0)
				{
					KJJDLBFDGDM.EGMFNKCKOLB e = l.Find((KJJDLBFDGDM.EGMFNKCKOLB IJAOGPFKDBP) =>
					{
                        //0xFDE3AC
                        return IJAOGPFKDBP.PPFNGGCBJKC_id == DGHHMEDBPEE.IDLHJIOMJBK_data.AIHOJKFNEEN_itm;
                    });
                    e.HMFFHLPNMPH_count += DGHHMEDBPEE.IDLHJIOMJBK_data.BFINGCJHOHI_cnt;
                    DGHHMEDBPEE.HMFFHLPNMPH_count++;
					if(DGHHMEDBPEE.HMFFHLPNMPH_count >= DGHHMEDBPEE.IDLHJIOMJBK_data.DOOGFEGEKLG_max && DGHHMEDBPEE.IDLHJIOMJBK_data.DOOGFEGEKLG_max >= 1)
					{
                        t -= DGHHMEDBPEE.IDLHJIOMJBK_data.EHKJFNAABMC_rat;
                        l2.Remove(DGHHMEDBPEE);
                    }
                    break;
                }
            }
        }
        l.RemoveAll((KJJDLBFDGDM.EGMFNKCKOLB _JGOHPDKCJKB_rw) =>
        {
            //0xFD635C
            return _JGOHPDKCJKB_rw.HMFFHLPNMPH_count < 1;
        });
        return l;
    }

	// // RVA: 0x94F478 Offset: 0x94F478 VA: 0x94F478
	public List<KJJDLBFDGDM.DPAGNOHCPPH> CMDOFKLCFEB_GetAllBossRewards(int _MFMPCHIJINJ_BossType, IEJAFPGDGNP_WinType KDIGPMIABEI)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            int IBPFNNADAKM = DPJFFBMCAAL_GetRewardGroupId(ev, _MFMPCHIJINJ_BossType, KDIGPMIABEI);
            BKOGPDBKFFJ_EventRaid.LDCCKEPPFMG d = ev.FNHDKHBNBBN_Rewards.Find((BKOGPDBKFFJ_EventRaid.LDCCKEPPFMG _JGNBPFCJLKI_d) =>
            {
                //0xFDE414
                return _JGNBPFCJLKI_d.PPFNGGCBJKC_id == IBPFNNADAKM;
            });
			int t = 0;
            for (int i = 0; i < d.CMIGGBMMBKK_drop.Length; i++)
			{
                t += d.CMIGGBMMBKK_drop[i].EHKJFNAABMC_rat;
            }
            List<KJJDLBFDGDM.DPAGNOHCPPH> res = new List<KJJDLBFDGDM.DPAGNOHCPPH>();
            for (int i = 0; i < d.CMIGGBMMBKK_drop.Length; i++)
            {
				KJJDLBFDGDM.DPAGNOHCPPH data = new KJJDLBFDGDM.DPAGNOHCPPH();
                data.PPFNGGCBJKC_id = d.CMIGGBMMBKK_drop[i].AIHOJKFNEEN_itm;
                data.HMFFHLPNMPH_count = d.CMIGGBMMBKK_drop[i].BFINGCJHOHI_cnt;
                data.POACKFONCAH_IsPickup = d.CMIGGBMMBKK_drop[i].DCFAPPHINAO_IsPickup == 1;
                data.ADKDHKMPMHP_rate = d.CMIGGBMMBKK_drop[i].EHKJFNAABMC_rat * 100.0f / t;
                res.Add(data);
            }
            return res;
        }
        return null;
	}

	// // RVA: 0x94F7FC Offset: 0x94F7FC VA: 0x94F7FC
	public List<AAMIMFNBLKP> PNHPJDMNEPH()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            List<AAMIMFNBLKP> res = new List<AAMIMFNBLKP>(ev.BFKJBHMHKAH_BossLevelsInfo.Count);
			for(int i = 0; i < ev.BFKJBHMHKAH_BossLevelsInfo.Count; i++)
			{
				AAMIMFNBLKP d = new AAMIMFNBLKP();
                d.ILELGGCCGMJ_UtaGrade = (int)HighScoreRating.GetUtaGrade(ev.BFKJBHMHKAH_BossLevelsInfo[i].ICLFADEFBIH_UtaGrade);
                d.EJGDHAENIDC_BossRank = ev.BFKJBHMHKAH_BossLevelsInfo[i].FJOLNJLLJEJ_rank;
                d.LCJGEMENAFM_DefeatRewardCount = ev.BFKJBHMHKAH_BossLevelsInfo[i].OJLDNEGBFFG_DefeatRewardCount;
                d.LBEGGOOHIFM_FirstRewardCount = ev.BFKJBHMHKAH_BossLevelsInfo[i].DIDNBKKKEDK_FirstRewardCount;
                d.NOLBNKAJANK_MvpRewardCount = ev.BFKJBHMHKAH_BossLevelsInfo[i].CAFDIAFJDKP_MvpSpRewardCount;
                d.DFCBKNLAFIM_DefeatSpRewardCount = ev.BFKJBHMHKAH_BossLevelsInfo[i].EHOBDMHPMHB_DefeatSpRewardCount;
                d.GEKJGFHKGEP_FirstSpRewardCount = ev.BFKJBHMHKAH_BossLevelsInfo[i].DIGJFGFKEJC_FirstSpRewardCount;
                d.PNHCJNAJPEM_MvpRewardCount = ev.BFKJBHMHKAH_BossLevelsInfo[i].JJELLPDAAEI_MvpRewardCount;
                res.Add(d);
            }
			return res;
        }
        return null;
	}

	// // RVA: 0x94FAA8 Offset: 0x94FAA8 VA: 0x94FAA8
	public void HAPDLPAKMLF(out int _GGNOGNOBJLP_CurrentStock, out int _HLANCDFJFIA_CurrentGauge, out bool _ANKEMCJFFIO_IsMax)
	{
		PBOHJPIBILI.GLEPHGKFFLL(out _GGNOGNOBJLP_CurrentStock, out _HLANCDFJFIA_CurrentGauge, out _ANKEMCJFFIO_IsMax);
	}

	// // RVA: 0x94FABC Offset: 0x94FABC VA: 0x94FABC
	public void HOOENJBGDGM_AddMcGauge(int _OEOIHIIIMCK_add)
	{
        PBOHJPIBILI.PGAGKCDGOIN_AddMcGauge(_OEOIHIIIMCK_add);
    }

	// // RVA: 0x94FAC8 Offset: 0x94FAC8 VA: 0x94FAC8
	public bool IOGPHNLODAF_IsMcGaugeMax(bool _DDGFCOPPBBN_test/* = True*/)
	{
        return PBOHJPIBILI.EFOHKCAOFFE_IsMcGaugeMax(_DDGFCOPPBBN_test);
    }

	// // RVA: 0x94B0D4 Offset: 0x94B0D4 VA: 0x94B0D4
	private KMFKFGEDPGJ IHPJMEKNJLP()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
		if(save != null)
		{
			StringBuilder str = new StringBuilder();
			bool b = false;
			int newAttackCount = 0;
			int added_canon = 0;
			for(int i = 1; i < 5; i++)
			{
				int myBossAttackCount = save.KAHKFBKIMBE_GetMyBossAttackCount((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType)i);
				int othersAttackCount = PBJBHONLMKF_MyBoss.LGKOMGPLKDK_GetOtherAttackCount((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType) i);
				if(myBossAttackCount < othersAttackCount )
				{
					if(b)
					{
						str.Append(',');
					}
					str.Append(OAGBCBBHMPF.GNIPLCBMPEG_RaidAttackType[i - 1]);
					str.Append(':');
					str.Append(othersAttackCount - myBossAttackCount);
					str.Append(':');
					int v3 = CMMDPDMNNKP(ev,(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType)i).DHGAILOFNIP_McCannonAdd;
					str.Append(v3);
					str.Append(':');
					str.Append(v3 * (othersAttackCount - myBossAttackCount));
					newAttackCount += othersAttackCount - myBossAttackCount;
					added_canon += v3 * (othersAttackCount - myBossAttackCount);
					save.GNDJFKNNMHD((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType)i, othersAttackCount);
					b = true;
				}
			}
			if(added_canon > 0)
			{
				PBOHJPIBILI.PGAGKCDGOIN_AddMcGauge(added_canon);
				ILCCJNDFFOB.HHCJCDFCLOB.MINOEGPNBIH_McCharge(added_canon, PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge(), 0, 0, "StringLiteral_13166", str.ToString());
				KMFKFGEDPGJ k = new KMFKFGEDPGJ();
				k.MLPEHNBNOGD_PlayerId = PBJBHONLMKF_MyBoss.OGLLKABGMCP_LastUpdatedPlayerId;
				k.GBJFCGOBHDO_NewAttackCount = newAttackCount;
				k.IOMHJCBMADB_AddedCanonPercent = added_canon;
				CBPJPNIFJOI.Add(k);
				return k;
			}
		}
		return null;
    }

	// // RVA: 0x94FAD4 Offset: 0x94FAD4 VA: 0x94FAD4
	public void EMEAEENFOOM()
	{
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM NHLBKJCPLBL = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
		if(NHLBKJCPLBL != null)
		{
            GGDBEANLCPC = new JKIJLMMLNPL();
            GGDBEANLCPC.ACBHJKCJLON_SceneAttr = IEDBMNIBDPD_MCannonPlateAttr;
            GGDBEANLCPC.KOGEKHMBHOI_SceneSerie = NNDFMCHDJOH_GetBossSerie(JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_type);
            GGDBEANLCPC.GCMIDNBBMLA_SceneAttrBonus = HENFOBHBABA_MCannonPlateAttrBonus;
            GGDBEANLCPC.IDDAGCGIAPA_SceneSerieBonus = AKHNDMEHHLF_MCannonPlateSeriesBonus;
            GGDBEANLCPC.DEHCKHMIENO((int _MJMPANIBFED_pid) =>
            {
                //0xFDE454
                return NHLBKJCPLBL.PHBLJOCFNHG(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id, _MJMPANIBFED_pid);
            });
        }
    }

	// // RVA: 0x94FCB4 Offset: 0x94FCB4 VA: 0x94FCB4
	public void JDGCABLBFLH(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, IMCBBOAFION HJBGFEANGMJ, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
        N.a.StartCoroutineWatched(FCCGJKNALLC_Coroutine_AttackMCannon(_BHFHGFKBOHH_OnSuccess, HJBGFEANGMJ, _AOCANKOMKFG_OnError));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD73C Offset: 0x6BD73C VA: 0x6BD73C
	// // RVA: 0x94FD1C Offset: 0x94FD1C VA: 0x94FD1C
	private IEnumerator FCCGJKNALLC_Coroutine_AttackMCannon(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, IMCBBOAFION HJBGFEANGMJ, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		BKOGPDBKFFJ_EventRaid KHGBJCFJGMA; // 0x24
		JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM IHMJKDLLIGA; // 0x28

		//0xFE22B0
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true) == null)
		{
            KHGBJCFJGMA = FJLIDJJAGOM();
			if(KHGBJCFJGMA != null)
			{
                IHMJKDLLIGA = KNKJHNJFONJ_GetEvSave(KHGBJCFJGMA);
				bool AEBPOEJHBID = false;
				GKCEHODEPMJ_GetBosses_WithOptionalPlayersNames(false, () =>
				{
					//0xFDE4CC
					AEBPOEJHBID = true;
                    PLOOEECNHFB_IsDone = false;
                }, _AOCANKOMKFG_OnError);
				while(!AEBPOEJHBID)
					yield return null;
				if(NPNNPNAIONN_IsError)
                    yield break;
				if(JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_status != NHCDBBBMFFG_BossStatus.MBFHILFLPJL_1_Alive)
				{
                    PLOOEECNHFB_IsDone = true;
                    HJBGFEANGMJ();
                    yield break;
                }
				if(IOGPHNLODAF_IsMcGaugeMax(false))
				{
					for(int i = 0; i < GGDBEANLCPC.OPIBAPEGCLA_Scenes.Count; i++)
					{
                        IHMJKDLLIGA.HPNHGLMMMHG(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id, GGDBEANLCPC.OPIBAPEGCLA_Scenes[i].BCCHOBPJJKE_SceneId, true);
                    }
                    int v = UnityEngine.Random.Range(KHGBJCFJGMA.LPJLEHAJADA_GetIntParam("mcannon_damage_random_-", 900), KHGBJCFJGMA.LPJLEHAJADA_GetIntParam("mcannon_damage_random_+", 1100) + 1);
                    GGDBEANLCPC.HALIDDHLNEG_Damage = GGDBEANLCPC.HALIDDHLNEG_Damage * v / 1000;
                    PLFBKEPLAAA = new OCBPJEALCPO();
                    PLFBKEPLAAA.FCIBJNKGMOB_Damage = JIBMOEHKMGB_SelectedBoss.BCCOMAODPJI_hp;
                    PLFBKEPLAAA.HALIDDHLNEG_Damage = GGDBEANLCPC.HALIDDHLNEG_Damage;
                    AEBPOEJHBID = false;
					LGJNILBEIKA_AttackBoss(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType.EKIGHDLEBAH_4_MacrossCanon, PLFBKEPLAAA.HALIDDHLNEG_Damage, true, () =>
					{
                        //0xFDE4FC
                        AEBPOEJHBID = true;
                        PLOOEECNHFB_IsDone = false;
                    }, _AOCANKOMKFG_OnError, _AOCANKOMKFG_OnError, JDDGPJDKHNE.GPLMOKEIOLE());
					while(!AEBPOEJHBID)
						yield return null;
					if(NPNNPNAIONN_IsError)
						yield break;
					if(JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_status == NHCDBBBMFFG_BossStatus.NFDONDKDHPK_3_Escaped)
					{
						for(int i = 0; i < GGDBEANLCPC.OPIBAPEGCLA_Scenes.Count; i++)
						{
							IHMJKDLLIGA.HPNHGLMMMHG(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id, GGDBEANLCPC.OPIBAPEGCLA_Scenes[i].BCCHOBPJJKE_SceneId, false);
						}
                        HOOENJBGDGM_AddMcGauge(100);
                        HJBGFEANGMJ();
                   		yield break;
                    }
					NPNNPNAIONN_IsError = false;
                    FGMOMBKGCNF_UpdateRankingValue(0);
					while(!PLOOEECNHFB_IsDone)
                        yield return null;
					if(!NPNNPNAIONN_IsError)
					{
						NPNNPNAIONN_IsError = false;
						HPBDHJCICPA(JIBMOEHKMGB_SelectedBoss, true, true, () =>
						{
							//0xFDE52C
							if(!NMDNCFGEJGJ())
							{
                                _BHFHGFKBOHH_OnSuccess();
                            }
							else
							{
                                PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = false;
                                CIOECGOMILE.HHCJCDFCLOB.LOOCNGEPAMI(() =>
								{
                                    //0xFDE730
                                    PLOOEECNHFB_IsDone = true;
                                    _BHFHGFKBOHH_OnSuccess();
                                }, () =>
								{
									//0xFDE77C
									PLOOEECNHFB_IsDone = true;
                                    NPNNPNAIONN_IsError = true;
                                    _AOCANKOMKFG_OnError();
                                }, JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id);
                            }
						}, _AOCANKOMKFG_OnError);
                        yield break;
                    }
                    _AOCANKOMKFG_OnError();
                }
				else
				{
					NPNNPNAIONN_IsError = false;
                    PLOOEECNHFB_IsDone = true;
					//_break;
					//LAB_00fe2a44
					_AOCANKOMKFG_OnError();
                }
            }
			else
			{
                PLOOEECNHFB_IsDone = true;
                NPNNPNAIONN_IsError = false;
				//_break;
				//LAB_00fe2a44
				_AOCANKOMKFG_OnError();
            }
        }
		else
		{
            PLOOEECNHFB_IsDone = true;
            NPNNPNAIONN_IsError = true;
            //_break;
            //LAB_00fe2a44
            _AOCANKOMKFG_OnError();
        }
    }

	// // RVA: 0x94FDF0 Offset: 0x94FDF0 VA: 0x94FDF0
	public void JFJDHJNNMON()
	{
		ANMBIEIFKFF_UnitBonusInfo = new MOAICCAOMCP();
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			for(int i = 0; i < ev.HKLGCBKONJG_ValkCosBonusList.Count; i++)
			{
				if(ev.HKLGCBKONJG_ValkCosBonusList[i].INDDJNMPONH_type == (int)BKOGPDBKFFJ_EventRaid.KHPDKADKOCP.GMHNAPBHMMA_BonusType.LMIDAHNABGK_11_Costume2 || ev.HKLGCBKONJG_ValkCosBonusList[i].INDDJNMPONH_type == (int)BKOGPDBKFFJ_EventRaid.KHPDKADKOCP.GMHNAPBHMMA_BonusType.KBHGPMNGALJ_1_Costume)
				{
                    //LAB_0094ff78
                    LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(EKLNMHFCAOI.DEACAHNLMNI_getItemId(ev.HKLGCBKONJG_ValkCosBonusList[i].GLCLFMGPMAN_ItemId));
                    if (cos != null && cos.IPJMPBANBPP_Enabled)
					{
						CKFGMNAIBNG c = new CKFGMNAIBNG();
                        c.KHEKNNFCAOI_Init(cos.AHHJLDLAPAN_DivaId, cos.JPIDIENBGKH_CostumeId, 1, false);
						MOAICCAOMCP.AAALCKPHGNG a = new MOAICCAOMCP.AAALCKPHGNG();
                        a.IFGEJDMMAHE_Info = c;
                        if(ev.HKLGCBKONJG_ValkCosBonusList[i].INDDJNMPONH_type == (int)BKOGPDBKFFJ_EventRaid.KHPDKADKOCP.GMHNAPBHMMA_BonusType.KBHGPMNGALJ_1_Costume)
						{
                            a.DJJGNDCMNHF_BonusValue = ev.LPJLEHAJADA_GetIntParam("unit_bonus_costume", 5);
                        }
						else
						{
							a.DJJGNDCMNHF_BonusValue = ev.LPJLEHAJADA_GetIntParam("unit_bonus_costume2", 10);
						}
                        ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList.Add(a);
                    }
				}
				else if(ev.HKLGCBKONJG_ValkCosBonusList[i].INDDJNMPONH_type == (int)BKOGPDBKFFJ_EventRaid.KHPDKADKOCP.GMHNAPBHMMA_BonusType.PFIOMNHDHCO_2_Valkyrie)
				{
                    int itId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(ev.HKLGCBKONJG_ValkCosBonusList[i].GLCLFMGPMAN_ItemId);
                    JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK_Get(itId);
					if(valk != null && valk.IPJMPBANBPP_Enabled)
					{
						PNGOLKLFFLH p = new PNGOLKLFFLH();
                        p.KHEKNNFCAOI_Init(itId, 0, 0);
						MOAICCAOMCP.LNKNJHEFBCE a = new MOAICCAOMCP.LNKNJHEFBCE();
						a.IFGEJDMMAHE_Info = p;
                        a.DJJGNDCMNHF_BonusValue = ev.LPJLEHAJADA_GetIntParam("unit_bonus_valkyrie", 5);
                        ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList.Add(a);
                    }
                }
			}
			OPJCFOHGPPE();
            ANMBIEIFKFF_UnitBonusInfo.HAAMKDOMDAB_UnitBonusCostume = ev.LPJLEHAJADA_GetIntParam("unit_bonus_costume", 10);
            ANMBIEIFKFF_UnitBonusInfo.KMEDEGMLEBF_UnitBonusValkyrie = ev.LPJLEHAJADA_GetIntParam("unit_bonus_valkyrie", 5);
			ANMBIEIFKFF_UnitBonusInfo.LHPJLNGEFEL_UnitBonusEpisode = ev.LPJLEHAJADA_GetIntParam("unit_bonus_episode", 5);
        }
    }

	// // RVA: 0x9504A4 Offset: 0x9504A4 VA: 0x9504A4
	public void OPJCFOHGPPE()
	{
        ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList.Clear();
        List<GNPOABJANKO> l = LMDENICBIIB_GetEpisodesBonusList(0, 0);
		for(int i = 0 ; i < l.Count; i++)
		{
			MOAICCAOMCP.ELAIDDICLCD e = new MOAICCAOMCP.ELAIDDICLCD();
            e.OPFGFINHFCE_name = PIGBBNDPPJC.EJOJNFDHDHN_GetName(l[i].KELFCMEOPPM_EpisodeId);
            e.PPFNGGCBJKC_id = l[i].KELFCMEOPPM_EpisodeId;
            e.DJJGNDCMNHF_BonusValue = l[i].HEDODOBGPPM_BonusValue;
            e.COHCODJHJFM = l[i].JKDJCFEBDHC_Enabled;
            ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList.Add(e);
        }
    }

	// // RVA: 0x9506D4 Offset: 0x9506D4 VA: 0x9506D4
	public void PAIFGFONEMJ(int CEHNJCIIKDN)
	{
        ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList.Clear();
        List<GNPOABJANKO> l = NFMDGIFKPMM(CEHNJCIIKDN, 0, 0);
        for (int i = 0; i < l.Count; i++)
		{
            MOAICCAOMCP.ELAIDDICLCD m = new MOAICCAOMCP.ELAIDDICLCD();
            m.OPFGFINHFCE_name = PIGBBNDPPJC.EJOJNFDHDHN_GetName(l[i].KELFCMEOPPM_EpisodeId);
            m.PPFNGGCBJKC_id = l[i].KELFCMEOPPM_EpisodeId;
            m.DJJGNDCMNHF_BonusValue = l[i].HEDODOBGPPM_BonusValue;
            m.COHCODJHJFM = l[i].JKDJCFEBDHC_Enabled;
            ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList.Add(m);
        }
    }

	// // RVA: 0x95090C Offset: 0x95090C VA: 0x95090C
	public void CCJKIDIFDKO()
	{
        ANMBIEIFKFF_UnitBonusInfo.EPPENPBAJPH();
    }

	// // RVA: 0x950938 Offset: 0x950938 VA: 0x950938
	public void IMAHHNBOCGG_UpdateUnitBonus()
	{
        IMAHHNBOCGG_UpdateUnitBonus(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH, -1);
    }

	// // RVA: 0x951234 Offset: 0x951234 VA: 0x951234
	public void NDCKGHGLHKN_UpdateUnitBonus(int CEHNJCIIKDN)
	{
		IMAHHNBOCGG_UpdateUnitBonus(GameManager.Instance.ViewPlayerData.JKIJFGGMNAN_GetUnit(CEHNJCIIKDN, false), CEHNJCIIKDN);
	}

	// // RVA: 0x9509FC Offset: 0x9509FC VA: 0x9509FC
	private void IMAHHNBOCGG_UpdateUnitBonus(JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit, int CEHNJCIIKDN/* = -1*/)
	{
        for(int i = 0; i < ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList.Count; i++)
		{
            ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList[i].NFAPNIKALBK_Active = false;
            for (int j = 0; j < _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas.Count; j++)
			{
				if(_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[j] != null)
				{
					if(ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList[i].IFGEJDMMAHE_Info.JPIDIENBGKH_CostumeId == IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_Find(_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[j].AHHJLDLAPAN_DivaId, _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[j].JPIDIENBGKH_CostumeId).JPIDIENBGKH_CostumeId)
					{
						ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList[i].NFAPNIKALBK_Active = true;
                        break;
                    }
				}
			}
        }
        for (int i = 0; i < ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList.Count; i++)
		{
            ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList[i].NFAPNIKALBK_Active = ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList[i].IFGEJDMMAHE_Info.GPPEFLKGGGJ_ValkyrieId == _MLAFAACKKBG_Unit.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId;
		}
		List<GCIJNCFDNON_SceneInfo> l = new List<GCIJNCFDNON_SceneInfo>(9);
        for (int i = 0; i < _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			if(_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i] != null)
			{
				if(_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId > 0)
				{
                    l.Add(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId - 1]);
                }
                for (int j = 0; j < _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if(_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						l.Add(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] - 1]);
					}
				}

            }
		}
		if(CEHNJCIIKDN < 0)
		{
            OPJCFOHGPPE();
        }
		else
		{
            PAIFGFONEMJ(CEHNJCIIKDN);
        }
        ANMBIEIFKFF_UnitBonusInfo.BMPJJJHAMID();
		if(CEHNJCIIKDN > -1)
            ANMBIEIFKFF_UnitBonusInfo.MBPCEBPHOBB.NFEECBNKKHD(this, CEHNJCIIKDN, false);
		else
			ANMBIEIFKFF_UnitBonusInfo.MBPCEBPHOBB.OBKGEDCKHHE_Init(this, false);
    }

	// // RVA: 0x951310 Offset: 0x951310 VA: 0x951310
	public bool DBNGGBFOAPG()
	{
		return JIMJHIDEHNM_ApCounter != null;
	}

	// // RVA: 0x951320 Offset: 0x951320 VA: 0x951320
	public void LHEPBBADNIH()
	{
		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester != null)
		{
            JIMJHIDEHNM_ApCounter.FJDBNGEPKHL_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
        }
	}

	// // RVA: 0x951424 Offset: 0x951424 VA: 0x951424
	public int HGJAGDPPALF_GetApNum()
	{
		return JIMJHIDEHNM_ApCounter.DCLKMNGMIKC_GetCurrentValue();
	}

	// // RVA: 0x951458 Offset: 0x951458 VA: 0x951458
	public long DMNDFBJODBA_GetApLoadTimeLeft()
	{
		return JIMJHIDEHNM_ApCounter.MLLGPBGFLFI_GetRemainingTime();
	}

	// // RVA: 0x95148C Offset: 0x95148C VA: 0x95148C
	public long EIEDIDECECD()
	{
		return JIMJHIDEHNM_ApCounter.LEHHIGOOIJJ();
	}

	// // RVA: 0x9514B8 Offset: 0x9514B8 VA: 0x9514B8
	public void IBMOHKFJDDH_SaveApCounter()
	{
        FNHJDCGHNCF(JIMJHIDEHNM_ApCounter);
    }

	// // RVA: 0x951568 Offset: 0x951568 VA: 0x951568
	public void IBMOHKFJDDH_SaveApCounter(MCGNOFMAPBJ OBFMBNJEOEC)
	{
        FNHJDCGHNCF(OBFMBNJEOEC);
    }

	// // RVA: 0x9514C0 Offset: 0x9514C0 VA: 0x9514C0
	private void FNHJDCGHNCF(MCGNOFMAPBJ OBFMBNJEOEC)
	{
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
		if(save != null)
		{
            save.NOKPCBEIJHJ_ApVal = OBFMBNJEOEC.NEPIPMPAFIE_CntVal;
            save.CKLPPIIKAKD_ApSaveTime = OBFMBNJEOEC.DLPEEDCCNMJ_CntSaveTime;
        }
    }

	// // RVA: 0x95156C Offset: 0x95156C VA: 0x95156C
	public bool MACJBPDFCAI_ConsumeAp(int CHIHFGDIBJM, bool _DDGFCOPPBBN_test/* = True*/)
	{
		return JIMJHIDEHNM_ApCounter.IGFMNMADJPP_Consume(CHIHFGDIBJM, _DDGFCOPPBBN_test);
	}

	// // RVA: 0x9515A8 Offset: 0x9515A8 VA: 0x9515A8
	public bool MGIKKAGFGCF(bool _DDGFCOPPBBN_test/* = True*/, MJFMOPMOFDJ DACHLLPBFPI)
	{
		return MACJBPDFCAI_ConsumeAp(CBDMCDKKFBE_GetNeedAp(CFLEMFADGLG_AttackType), _DDGFCOPPBBN_test);
	}

	// // RVA: 0x9515D4 Offset: 0x9515D4 VA: 0x9515D4
	public void DFNENEFLKPO_IncBossPlayCount()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(!save.MPOLPHDMBKA(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id))
				return;
			save.IPNJMALJDKM_AddPlayCount(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id, 1);
        }
    }

	// // RVA: 0x951664 Offset: 0x951664 VA: 0x951664
	public void BBLIJFBIACE_IncAssistCount()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(!save.MPOLPHDMBKA(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id))
				return;
			save.KCBGMGHNKMB_AddAssistCount(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id, 1);
		}
	}

	// // RVA: 0x9516F4 Offset: 0x9516F4 VA: 0x9516F4
	public bool LIAJFGCJJIM_HasAssist()
	{
		return LIAJFGCJJIM_HasAssist(JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id);
	}

	// // RVA: 0x951724 Offset: 0x951724 VA: 0x951724
	public bool LIAJFGCJJIM_HasAssist(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(!save.MPOLPHDMBKA(KCNAEONFIBP))
				return false;
			return save.IEPDBGCJDEP_GetAssistCount(KCNAEONFIBP) > 0;
		}
        return false;
	}

	// // RVA: 0x9517B0 Offset: 0x9517B0 VA: 0x9517B0
	public void KIGJMPILEFC_IncRequestCount(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(!save.MPOLPHDMBKA(KCNAEONFIBP))
				return;
			save.EEPAJLBMEII_AddRequestCount(KCNAEONFIBP, 1);
        }
    }

	// // RVA: 0x94C198 Offset: 0x94C198 VA: 0x94C198
	public int HEMEDMMBIBH_GetBossHelpCountLeft(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(!save.MPOLPHDMBKA(KCNAEONFIBP))
				return 0;
			return Mathf.Max(0,BAEPGOAMBDK("boss_help_count_max", 3) - save.LNCILHPNOGP_GetRequestCount(KCNAEONFIBP));
		}
        return 0;
	}

	// // RVA: 0x951828 Offset: 0x951828 VA: 0x951828
	public void JIOEILLGDCG_SetLastRequestTime(long IEHACMMICFI, int _KAIMDDPJEON__BossId/* = 0*/)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
    	if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
            if (_KAIMDDPJEON__BossId < 1)
			{
				_KAIMDDPJEON__BossId = JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_id;
			}
			if(save.MPOLPHDMBKA(_KAIMDDPJEON__BossId))
			{
				save.FIBJPHMKGFL_SetLastRequestTime(_KAIMDDPJEON__BossId, IEHACMMICFI);
			}
		}
	}

	// // RVA: 0x94C00C Offset: 0x94C00C VA: 0x94C00C
	public long GCDHLLHHIHA_GetNextRequestTime(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
    	if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(save.MPOLPHDMBKA(KCNAEONFIBP))
			{
				return save.HKCAPAOLNNC_GetLastRequestTime(KCNAEONFIBP) + BAEPGOAMBDK("boss_help_time_max", 600);
			}
		}
		return 0;
	}

	// // RVA: 0x94C2C0 Offset: 0x94C2C0 VA: 0x94C2C0
	public bool KIHAEAEEFJE_IsOverLimitHelp(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
    	if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(save.MPOLPHDMBKA(KCNAEONFIBP))
			{
				return save.GAIGIKOLLFI_IsOverLimitHelp(KCNAEONFIBP);
			}
		}
		return false;
	}

	// // RVA: 0x9518D8 Offset: 0x9518D8 VA: 0x9518D8
	public void JDDCHPCBKLM_IncOverLimitHelp(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			KNKJHNJFONJ_GetEvSave(ev).HCJHKDOANKK_IncOverLimitHelp(KCNAEONFIBP);
		}
    }

	// // RVA: 0x94CDD0 Offset: 0x94CDD0 VA: 0x94CDD0
	public bool ACDLEBPMEIH(MJFMOPMOFDJ OFLJBDDKMII)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
			if(save.MPOLPHDMBKA(OFLJBDDKMII.PPFNGGCBJKC_id))
			{
				int a = ev.LPJLEHAJADA_GetIntParam("raid_boss_ap_out_boss_pattern", 3);
				int c = ev.LPJLEHAJADA_GetIntParam("raid_boss_ap_out_locate_pattern", 3);
				bool isSp = OFLJBDDKMII.MMEBLOIJBKE_UniqueKey.Contains("sp");
				return save.OEENOAGJKJK_GetPlayCount(OFLJBDDKMII.PPFNGGCBJKC_id) < 1 && 
					((isSp && (a >> 1) != 0) || 
					(!isSp && a != 0))
				 && 
					((OFLJBDDKMII.MLPEHNBNOGD_PlayerId == NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId && c != 0) || 
					(OFLJBDDKMII.MLPEHNBNOGD_PlayerId != NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId && (c >> 1) != 0 ));
			}
        }
		return false;
    }

	// // RVA: 0x9519EC Offset: 0x9519EC VA: 0x9519EC
	public int BFPIHPBKEGK_GetApMax()
	{
		return JIMJHIDEHNM_ApCounter.DCBENCMNOGO_MaxCount;
	}

	// // RVA: 0x951A18 Offset: 0x951A18 VA: 0x951A18
	public int COEIAHBIFBN(int _KIJAPOFAGPN_ItemId, CIOECGOMILE.LIILJGHKIDL_RestoreButtonType DCIBKKDLNCI/* = 0*/)
	{
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId);
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
		{
			if(id == 3)
			{
				return ev.LPJLEHAJADA_GetIntParam("apitem_l_heal", 3);
			}
			else if(id == 2)
			{
				return ev.LPJLEHAJADA_GetIntParam("apitem_s_heal", 1);
			}
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
		{
			if(DCIBKKDLNCI == CIOECGOMILE.LIILJGHKIDL_RestoreButtonType.FPNFLAAECMK_2_PaidL)
				return ev.LPJLEHAJADA_GetIntParam("apitem_vc_heal_l", 12);
			else
				return ev.LPJLEHAJADA_GetIntParam("apitem_vc_heal_s", 5);
		}
		return 0;
    }

	// // RVA: 0x951B80 Offset: 0x951B80 VA: 0x951B80
	// public bool DOOGIEBPLDE() { }

	// // RVA: 0x951BB4 Offset: 0x951BB4 VA: 0x951BB4
	// public static bool BPDABBKNFOI(RaidItemConstants.Type _INDDJNMPONH_type) { }

	// // RVA: 0x951CE0 Offset: 0x951CE0 VA: 0x951CE0
	public void FEFCBFNLDEP(MCGNOFMAPBJ OBFMBNJEOEC)
	{
		OBFMBNJEOEC.ODDIHGPONFL_Copy(JIMJHIDEHNM_ApCounter);
	}

	// // RVA: 0x951D14 Offset: 0x951D14 VA: 0x951D14
	public void JIHGDCFBGCK(MCGNOFMAPBJ OBFMBNJEOEC)
	{
		JIMJHIDEHNM_ApCounter.ODDIHGPONFL_Copy(OBFMBNJEOEC);
	}

	// // RVA: 0x951D48 Offset: 0x951D48 VA: 0x951D48
	public void NLHLDMGDAFN(int _KIJAPOFAGPN_ItemId)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
		if(save != null)
		{
			if(EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId) == 3)
			{
				IFBFAOFBNLE(ev, save);
			}
		}
    }

	// // RVA: 0x951EAC Offset: 0x951EAC VA: 0x951EAC
	public void GOPAABMHDOA()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(ev);
		if(save != null)
		{
			IFBFAOFBNLE(ev, save);
			KNFBJBGHGNL(ev);
		}
	}

	// // RVA: 0x951E08 Offset: 0x951E08 VA: 0x951E08
	private void IFBFAOFBNLE(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master, JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM NHLBKJCPLBL)
	{
		NHLBKJCPLBL.BJBJHNJJCHL_AtkMcgBonus = _NDFIEMPPMLF_master.LPJLEHAJADA_GetIntParam("apheal_bonus_mcannon_gauge", 100);
	}

	// // RVA: 0x951EEC Offset: 0x951EEC VA: 0x951EEC
	private void KNFBJBGHGNL(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master)
	{
		NKOBMDPHNGP_EventRaidLobby lobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(lobby != null)
		{
			lobby.KHGKJMODLDE(AMDHBADOKNM(_NDFIEMPPMLF_master));
		}
	}

	// // RVA: 0x95200C Offset: 0x95200C VA: 0x95200C
	private int AMDHBADOKNM(BKOGPDBKFFJ_EventRaid _NDFIEMPPMLF_master)
	{
		return _NDFIEMPPMLF_master.LPJLEHAJADA_GetIntParam("apheal_bonus_fold_radar_count", 1);
	}

	// // RVA: 0x952088 Offset: 0x952088 VA: 0x952088
	public int GDMLCKMCMBG()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return AMDHBADOKNM(ev);
		}
        return 0;
	}

	// // RVA: 0x9520AC Offset: 0x9520AC VA: 0x9520AC
	public bool LDMOBKMEKMD()
	{
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
		if(save != null)
		{
			return save.KILJKLIHMAE_SboRcv;
		}
        return false;
	}

	// // RVA: 0x9520D8 Offset: 0x9520D8 VA: 0x9520D8
	public bool PPPEFGFIGMH_GetStartBonusItemIdAndCount(out int _KIJAPOFAGPN_ItemId, out int _HMFFHLPNMPH_count)
	{
		_KIJAPOFAGPN_ItemId = 0;
		_HMFFHLPNMPH_count = 0;
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			_KIJAPOFAGPN_ItemId = ev.LPJLEHAJADA_GetIntParam("start_bonus_item_id", 360001);
			_HMFFHLPNMPH_count = ev.LPJLEHAJADA_GetIntParam("start_bonus_item_count", 1);
			return _KIJAPOFAGPN_ItemId > 0 && _HMFFHLPNMPH_count > 0;
		}
        return false;
	}

	// // RVA: 0x9521BC Offset: 0x9521BC VA: 0x9521BC
	public void PMAMHBOGPNJ(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM());
		if(save != null)
		{
			NPNNPNAIONN_IsError = false;
			PLOOEECNHFB_IsDone = false;
			save.KILJKLIHMAE_SboRcv = true;
			int itemId, itemCount;
			if(PPPEFGFIGMH_GetStartBonusItemIdAndCount(out itemId, out itemCount))
			{
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.IGAJCMKNLDL_14_EventLoginBonus, PGIIDPEGGPI_EventId.ToString());
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, itemId, itemCount, null, 0);
			}
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xFDE7E8
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess();
			}, () =>
			{
				//0xFDE834
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_MOBEEPPKFLG_OnFail();
			}, null);
		}
		else
		{
			PLOOEECNHFB_IsDone = true;_BHFHGFKBOHH_OnSuccess();
		}
    }

	// // RVA: 0x9524C0 Offset: 0x9524C0 VA: 0x9524C0
	public void KLOJEBGOGPO(int _PPFNGGCBJKC_id, out int _DOOGFEGEKLG_max, out int NNDBJGDFEEM_Min)
	{
		int a = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(_PPFNGGCBJKC_id, 1);
		_DOOGFEGEKLG_max = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(a + 1, -1) - 1;
		NNDBJGDFEEM_Min = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(a, -1);
	}

	// // RVA: 0x952580 Offset: 0x952580 VA: 0x952580 Slot: 80
	public override bool PDDKJENPOBL()
	{
		NKOBMDPHNGP_EventRaidLobby lobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(lobby != null)
		{
			return lobby.MCJFAACGLCB();
		}
		return false;
	}
}
