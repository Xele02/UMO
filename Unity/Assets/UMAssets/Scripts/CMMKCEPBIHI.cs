
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.RhythmGame;

public static class CMMKCEPBIHI
{
    public enum NOJENDEDECD
    {
        HNGJDMNPMNP_BaseScore = 0,
        KBHGPMNGALJ = 1,
        AJIDOFDBIDL = 2,
        NLAGKLDCBAG_Combo = 3,
        GJDKJOHIEFF_PlateScore = 4,
        BMMPEPDFICC_CenterSkillScore = 5,
        CPJOGHCLENG_LiveSkillScore = 6,
        NKPLJNILBFP_ASkillScore = 7,
        GGOOOIKELDH_NotesScore = 8,
        OPCNHIMPGCE_LeafScore = 9,
        AEFCOHJBLPO = 10,
    }

	private const int IMNILJDBFDL = 30;
	private const int NPMLACIOKJE = 1;
	private static StatusData GCECPDEOIIN = new StatusData(); // 0x0
	private static Comparison<GCIJNCFDNON>[] MOGECDOLPPL = new Comparison<GCIJNCFDNON>[3] {
        (GCIJNCFDNON HKICMNAACDA, GCIJNCFDNON BNKHBCBJBKI) => {
            //0x175A31C
			return BNKHBCBJBKI.CMCKNKKCNDK_Status.soul - HKICMNAACDA.CMCKNKKCNDK_Status.soul;
        },
        (GCIJNCFDNON HKICMNAACDA, GCIJNCFDNON BNKHBCBJBKI) => {
            //0x175A39C
			return BNKHBCBJBKI.CMCKNKKCNDK_Status.vocal - HKICMNAACDA.CMCKNKKCNDK_Status.vocal;
        },
        (GCIJNCFDNON HKICMNAACDA, GCIJNCFDNON BNKHBCBJBKI) => {
            //0x175A41C
			return BNKHBCBJBKI.CMCKNKKCNDK_Status.charm - HKICMNAACDA.CMCKNKKCNDK_Status.charm;
        }
    }; // 0x4
	private static Func<StatusData, int>[] HDLKMMHKOKE = new Func<StatusData, int>[3] {
        (StatusData IBDJFHFIIHN) => {
            //0x175A49C
			return IBDJFHFIIHN.soul;
        },
        (StatusData IBDJFHFIIHN) => {
            //0x175A4C0
			return IBDJFHFIIHN.vocal;
        },
        (StatusData IBDJFHFIIHN) => {
            //0x175A4E4
			return IBDJFHFIIHN.charm;
        }
    }; // 0x8
	private static Action<StatusData, int>[] HOBOLJEFDFF = new Action<StatusData, int>[3] {
        (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
            //0x175A508
			IBDJFHFIIHN.soul += OHDPMGMGJBI;
        },
        (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
            //0x175A54C
			IBDJFHFIIHN.vocal += OHDPMGMGJBI;
        },
        (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
            //0x175A590
			IBDJFHFIIHN.charm += OHDPMGMGJBI;
        }
    }; // 0xC
	private static int[] OOPMCKOCEFM = new int[10]; // 0x10
	private static float[] LKBGHCIKIOA = new float[5]; // 0x14
	private static int[] HCEPBDBHILM = new int[10] { 100, 100, 100, 90, 100, 100, 90, 90, 90, 90 }; // 0x18
	private static string[] DALGMKEOFLN = new string[8] {"score_gauge_e", "score_gauge_n", "score_gauge_h", "score_gauge_vh", 
        "score_gauge_ex", "score_gauge_h+", "score_gauge_vh+", "score_gauge_ex+"}; // 0x1C
	private static StatusData FLOHCPIIHEH = new StatusData(); // 0x20
	private static AEKDNMPPOJN OMPNCHBNEPF = new AEKDNMPPOJN(); // 0x24
	private static LimitOverStatusData MEMCOJHNEIP = new LimitOverStatusData(); // 0x28
	private static List<int> AONMBIEIBCD = new List<int>(); // 0x2C
	private static List<int> FOMKBDKKODO = new List<int>(); // 0x30
	private static int AFBHKBGLMHG = 245; // 0x34
	private static List<int> DNJCAKPKNDP = new List<int>(); // 0x38

	public static ResultScoreRank.Type KHCOOPDAGOE_ScoreRank { get; private set; } // 0x3C MHJDBFONNKN CKNLMMGELDF GEENHBHNFIC
	public static float FDLECNKJCGG_GaugeRatio { get; private set; } // 0x40 DCBOMKOHHEP IGEHABMEOHD FOLIPOFKIJA

	// // RVA: 0x1085914 Offset: 0x1085914 VA: 0x1085914
	public static void DIDENKKDJKI(ref AEGLGBOGDHH HBODCMLFDOB, JLKEOGLJNOD MLAFAACKKBG, DFKGGBMFFGB AHEFHIMGIBI, EEDKAACNBBG KKHIDFKKFJE, EAJCBFGKKFA PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		TodoLogger.Log(0, "DIDENKKDJKI");
	}

	// // RVA: 0x1085B98 Offset: 0x1085B98 VA: 0x1085B98
	public static void AECDJDIJJKD(ref EDMIONMCICN HBODCMLFDOB, FFHPBEPOMAK DGCJCAHIAPP, JLKEOGLJNOD MLAFAACKKBG, DFKGGBMFFGB AHEFHIMGIBI, EEDKAACNBBG KKHIDFKKFJE, EAJCBFGKKFA PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		TodoLogger.Log(0, "AECDJDIJJKD");
	}

	// // RVA: 0x1087134 Offset: 0x1087134 VA: 0x1087134
	public static void NIPJMNDBCNF(ref EDMIONMCICN HBODCMLFDOB, JLKEOGLJNOD MLAFAACKKBG_Team, EAJCBFGKKFA PCEGKKLKFNO_FriendData, DFKGGBMFFGB AHEFHIMGIBI_PlayerData, EEDKAACNBBG KKHIDFKKFJE_MusicData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData)
	{
		HPODBOHGGDH data = new HPODBOHGGDH();
		HBODCMLFDOB.JCHLONCMPAJ();
		if(PCEGKKLKFNO_FriendData != null)
		{
			PCEGKKLKFNO_FriendData.KHGKPKDBMOH();
			data.JCHLONCMPAJ();
			if(MLAFAACKKBG_Team != null)
			{
				FFHPBEPOMAK divaInfo = MLAFAACKKBG_Team.BCJEAJPLGMB_MainDivas[0];
				if(divaInfo != null && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					int a = 0;
					if(KKHIDFKKFJE_MusicData == null)
					{
						a = sceneInfo.MEOOLHNNMHL(false, 0, 0);
					}
					else
					{
						a = sceneInfo.MEOOLHNNMHL(false, KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE_MusicData.AIHCEGFANAM_Serie);
					}
					if(a != 0)
					{
						data.EDEDFDDIOKO(a, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SceneSeries);
						AECDJDIJJKD(ref HBODCMLFDOB, PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, PCEGKKLKFNO_FriendData.KHGKPKDBMOH(), PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], KKHIDFKKFJE_MusicData, 0, ref data, -1, MLAFAACKKBG_Team);
					}
				}
			}
			if(PCEGKKLKFNO_FriendData.KHGKPKDBMOH() != null)
			{
				int a = PCEGKKLKFNO_FriendData.KHGKPKDBMOH().MEOOLHNNMHL(false, KKHIDFKKFJE_MusicData == null ? 0 : KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE_MusicData == null ? 0 : KKHIDFKKFJE_MusicData.AIHCEGFANAM_Serie);
				if(a != 0)
				{
					data.EDEDFDDIOKO(a, PCEGKKLKFNO_FriendData.KHGKPKDBMOH().DDEDANKHHPN_SkillLevel, PCEGKKLKFNO_FriendData.KHGKPKDBMOH().AIHCEGFANAM_SceneSeries);
					AECDJDIJJKD(ref HBODCMLFDOB, PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, PCEGKKLKFNO_FriendData.KHGKPKDBMOH(), PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], KKHIDFKKFJE_MusicData, 0, ref data, -1, MLAFAACKKBG_Team);
				}
			}
			if(KKHIDFKKFJE_MusicData != null)
			{
				for(int i = 0; i < PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
				{
					if(i == 0)
					{
						bool isAttrValid = false;
						StatusData st = null;
						StatusData st2 = null;
						if (PCEGKKLKFNO_FriendData.KHGKPKDBMOH() != null)
						{
							st2 = PCEGKKLKFNO_FriendData.KHGKPKDBMOH().CMCKNKKCNDK_Status;
							isAttrValid = KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == PCEGKKLKFNO_FriendData.KHGKPKDBMOH().JGJFIJOCPAG_SceneAttr;
							st = HBODCMLFDOB.BJABFKMIJHB;
						}
						else
						{
							GCIJNCFDNON sceneInfo = PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[i - 1];
							if(sceneInfo != null)
							{
								st2 = sceneInfo.CMCKNKKCNDK_Status;
								isAttrValid = KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == sceneInfo.JGJFIJOCPAG_SceneAttr;
								st = HBODCMLFDOB.OBCPFDNKLMM[i - 1];
							}
						}
						if(isAttrValid &&  st != null)
						{
							st.soul += st2.soul * 30;
							st.vocal += st2.vocal * 30;
							st.charm += st2.charm * 30;
							HBODCMLFDOB.MCBLDOECHEK[i].MKMIEGPOKGG = (st2.soul * 30) / 100;
							HBODCMLFDOB.MCBLDOECHEK[i].EACDINDLGLF = (st2.vocal * 30) / 100;
							HBODCMLFDOB.MCBLDOECHEK[i].LDLHPACIIAB = (st2.charm * 30) / 100;
							if(i == 0)
							{
								HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.MKADAMIGMPO/*7*/;
							}
						}
					}
				}
			}
			if(KDOLMBEAGCI_EnemyData != null && KDOLMBEAGCI_EnemyData.PDHCABLLJPB != 0)
			{
				data.EDEDFDDIOKO(KDOLMBEAGCI_EnemyData.PDHCABLLJPB, 1, 0);
				AECDJDIJJKD(ref HBODCMLFDOB, PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, PCEGKKLKFNO_FriendData.KHGKPKDBMOH(), PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA, ref data, -1, MLAFAACKKBG_Team);
			}
			HBODCMLFDOB.ELFAIDEBLJB.Div(100);
			HBODCMLFDOB.BJABFKMIJHB.Div(100);
			for(int i = 0; i < HBODCMLFDOB.OBCPFDNKLMM.Length; i++)
			{
				HBODCMLFDOB.OBCPFDNKLMM[i].Div(100);
			}
		}
	}

	// // RVA: 0x1087C58 Offset: 0x1087C58 VA: 0x1087C58
	// private static void AECDJDIJJKD(ref EDMIONMCICN HBODCMLFDOB, FFHPBEPOMAK DGCJCAHIAPP, List<GCIJNCFDNON> OPIBAPEGCLA, EEDKAACNBBG KKHIDFKKFJE, JNKEEAOKNCI.MKGJHBAKMBD GJLFANGDGCL, ref HPODBOHGGDH CHMOEPNAJOO, int ABBDKBOIBCG, JLKEOGLJNOD MLAFAACKKBG) { }

	// // RVA: 0x1087F7C Offset: 0x1087F7C VA: 0x1087F7C
	private static void AECDJDIJJKD(ref EDMIONMCICN HBODCMLFDOB, FFHPBEPOMAK DGCJCAHIAPP, GCIJNCFDNON AFBMEMCHJCL, GCIJNCFDNON HAPFNHPFBGD, GCIJNCFDNON JEBHFJEJAKJ, EEDKAACNBBG KKHIDFKKFJE, JNKEEAOKNCI_Skill.MKGJHBAKMBD GJLFANGDGCL, ref HPODBOHGGDH CHMOEPNAJOO, int ABBDKBOIBCG, JLKEOGLJNOD MLAFAACKKBG)
	{
		List<HBDCPGLAPHH> l;
		if(GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
		{
			l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BIOEJKBCIKD;
		}
		else if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA)
		{
			l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.FFCFHFOIKGB;
		}
		else
		{
			l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP;
		}
		HBDCPGLAPHH skill = l[CHMOEPNAJOO.ENMAEBJGEKL - 1];
		for(int i = 0; i < 2; i++)
		{
			KFCIIMBBNCD d = null;
			int skillId = 0;
			if (i == 1)
			{
				if (skill.AKGNPLBDKLN_P2 == 0)
					return;
				skillId = skill.AKGNPLBDKLN_P2;
				d = KDDDDMMMBHE(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.AKGNPLBDKLN_P2, GJLFANGDGCL);
			}
			else if(i == 0)
			{
				if(skill.HEKHODDJHAO_P1 != 0)
				{
					skillId = skill.HEKHODDJHAO_P1;
					d = KDDDDMMMBHE(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.HEKHODDJHAO_P1, GJLFANGDGCL);
				}
			}
			if (d != null)
			{
				SeriesAttr.Type attr = 0;
				if (AFBMEMCHJCL != null && KKHIDFKKFJE != null)
				{
					attr = (SeriesAttr.Type)KKHIDFKKFJE.AIHCEGFANAM_Serie;
					if (attr != CHMOEPNAJOO.AIHCEGFANAM)
						attr = 0;
				}
				if (FNIEADNMMIA((CenterSkillCondition.Type)d.OAFPGJLCNFM_CenterSkillCondition, KKHIDFKKFJE, attr))
				{
					if (FLPKCFDANMK(DGCJCAHIAPP, (CenterSkillTarget.Type)d.GJLFANGDGCL_CenterSkillTarget, ABBDKBOIBCG))
					{
						StatusData st = HBODCMLFDOB.ELFAIDEBLJB;
						if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
							st = HBODCMLFDOB.IMLGBMGIACC;
						KDOFDLIMHJG(ref st, DGCJCAHIAPP.JLJGCBOHJID_Status, GJLFANGDGCL, skillId, CHMOEPNAJOO.CNLIAMIIJID, MLAFAACKKBG);
						if (GJLFANGDGCL != JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
						{
							LBBNJAGGCBB(ref HBODCMLFDOB, st);
							if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA)
							{
								GCECPDEOIIN.Clear();
								KDOFDLIMHJG(ref st, DGCJCAHIAPP.JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA, skillId, CHMOEPNAJOO.CNLIAMIIJID, MLAFAACKKBG);
								MEICPKJFJOA(ref HBODCMLFDOB, st);
							}
						}
					}
					for (int j = 0; j < DGCJCAHIAPP.DJICAKGOGFO_SubSceneIds.Count + 1; j++)
					{
						GCIJNCFDNON a = null;
						if (i == 0)
						{
							a = AFBMEMCHJCL;
						}
						else if (i == 1)
						{
							a = HAPFNHPFBGD;
						}
						else if (i == 2)
						{
							a = JEBHFJEJAKJ;
						}
						if (a != null)
						{
							if (FJHLLHFGICG(a, (CenterSkillTarget.Type)d.GJLFANGDGCL_CenterSkillTarget, ABBDKBOIBCG, i))
							{
								StatusData st = null;
								if (i == 0)
								{
									st = HBODCMLFDOB.BJABFKMIJHB;
									if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
										st = HBODCMLFDOB.AJINBLGCBMM;
									KDOFDLIMHJG(ref st, a.CMCKNKKCNDK_Status, GJLFANGDGCL, skillId, CHMOEPNAJOO.CNLIAMIIJID, MLAFAACKKBG);
								}
								else
								{
									st = HBODCMLFDOB.OBCPFDNKLMM[i - 1];
									if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
										st = HBODCMLFDOB.FEGNMIGJMDM[i - 1];
									KDOFDLIMHJG(ref st, a.CMCKNKKCNDK_Status, GJLFANGDGCL, skillId, CHMOEPNAJOO.CNLIAMIIJID, MLAFAACKKBG);
								}
								if (GJLFANGDGCL != JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
								{
									LBBNJAGGCBB(ref HBODCMLFDOB, st);
									if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA)
									{
										FLOHCPIIHEH.Clear();
									}
									KDOFDLIMHJG(ref FLOHCPIIHEH, DGCJCAHIAPP.JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA, skillId, CHMOEPNAJOO.CNLIAMIIJID, MLAFAACKKBG);
									MEICPKJFJOA(ref HBODCMLFDOB, FLOHCPIIHEH);
								}
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1087F6C Offset: 0x1087F6C VA: 0x1087F6C
	// private static void DALDDNMEMJE(ref EDMIONMCICN HBODCMLFDOB) { }

	// // RVA: 0x10890F4 Offset: 0x10890F4 VA: 0x10890F4
	private static void LBBNJAGGCBB(ref EDMIONMCICN HBODCMLFDOB, StatusData BALBKJFMDFN)
	{
		if (BALBKJFMDFN.soul > 0)
			HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.BICPBLMPBPH;
		if (BALBKJFMDFN.vocal > 0)
			HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.GPCMMGOCPHC;
		if (BALBKJFMDFN.charm > 0)
			HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.LGOHMPBLPKA;
		if (BALBKJFMDFN.life > 0)
			HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.ECHJOKLBHEJ;
		if (BALBKJFMDFN.support > 0)
			HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.AHJNCHAONGN;
		if (BALBKJFMDFN.fold > 0)
			HBODCMLFDOB.LGGLFAECCBK |= MKHCIKICBOI.ONBNGGDFAJK;
	}

	// // RVA: 0x1089190 Offset: 0x1089190 VA: 0x1089190
	private static void MEICPKJFJOA(ref EDMIONMCICN HBODCMLFDOB, StatusData BALBKJFMDFN)
	{
		if (BALBKJFMDFN.soul < 0)
			HBODCMLFDOB.NOEFMBAIAMP |= MKHCIKICBOI.BICPBLMPBPH;
		if (BALBKJFMDFN.vocal < 0)
			HBODCMLFDOB.NOEFMBAIAMP |= MKHCIKICBOI.GPCMMGOCPHC;
		if (BALBKJFMDFN.charm < 0)
			HBODCMLFDOB.NOEFMBAIAMP |= MKHCIKICBOI.LGOHMPBLPKA;
		if (BALBKJFMDFN.life < 0)
			HBODCMLFDOB.NOEFMBAIAMP |= MKHCIKICBOI.ECHJOKLBHEJ;
		if (BALBKJFMDFN.support < 0)
			HBODCMLFDOB.NOEFMBAIAMP |= MKHCIKICBOI.AHJNCHAONGN;
		if (BALBKJFMDFN.fold < 0)
			HBODCMLFDOB.NOEFMBAIAMP |= MKHCIKICBOI.ONBNGGDFAJK;
	}

	// // RVA: 0x108897C Offset: 0x108897C VA: 0x108897C
	private static KFCIIMBBNCD KDDDDMMMBHE(JNKEEAOKNCI_Skill FOFADHAENKC_SkillDb, int BFGNMDGOEID_SkillId, JNKEEAOKNCI_Skill.MKGJHBAKMBD GJLFANGDGCL)
	{
		List<KFCIIMBBNCD> l;
		if(BFGNMDGOEID_SkillId > 0)
		{
			if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
			{
				l = FOFADHAENKC_SkillDb.EBKAAEDMIBI;
			}
			else if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA)
			{
				l = FOFADHAENKC_SkillDb.PHPGICHCBPM;
			}
			else if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.MHKFDBLMOGF)
			{
				l = FOFADHAENKC_SkillDb.PEPLECGHBFA;
			}
			else return null;
			return l[BFGNMDGOEID_SkillId - 1];
		}
		return null;
	}

	// // RVA: 0x1088AC0 Offset: 0x1088AC0 VA: 0x1088AC0
	private static bool FNIEADNMMIA(CenterSkillCondition.Type FKDOMKHHOCD, EEDKAACNBBG KKHIDFKKFJE, SeriesAttr.Type AIHCEGFANAM = 0)
	{
		if (FKDOMKHHOCD == 0)
			return true;
		if (KKHIDFKKFJE == null)
			return false;
		bool res = false;
		switch(FKDOMKHHOCD)
		{
			case CenterSkillCondition.Type.MusicAttr_01:
				return KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == 1;
			case CenterSkillCondition.Type.MusicAttr_02:
				return KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == 2;
			case CenterSkillCondition.Type.MusicAttr_03:
				return KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == 3;
			case CenterSkillCondition.Type.MusicAttr_04:
				return KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == 4;
			case CenterSkillCondition.Type.MusicAttr_05:
				return false;
			case CenterSkillCondition.Type.SeriesAttr_01:
				return KKHIDFKKFJE.AIHCEGFANAM_Serie == 1;
			case CenterSkillCondition.Type.SeriesAttr_02:
				return KKHIDFKKFJE.AIHCEGFANAM_Serie == 2;
			case CenterSkillCondition.Type.SeriesAttr_03:
				return KKHIDFKKFJE.AIHCEGFANAM_Serie == 3;
			case CenterSkillCondition.Type.SeriesAttr_04:
				return KKHIDFKKFJE.AIHCEGFANAM_Serie == 4;
			case CenterSkillCondition.Type.SeriesAttr_05:
				return KKHIDFKKFJE.AIHCEGFANAM_Serie == 5;
			case CenterSkillCondition.Type.SeriesAttr_Scn:
				return KKHIDFKKFJE.AIHCEGFANAM_Serie == (int)AIHCEGFANAM;
		}
		return res;
	}

	// // RVA: 0x1088C18 Offset: 0x1088C18 VA: 0x1088C18
	private static bool FLPKCFDANMK(FFHPBEPOMAK FDBOPFEOENF, CenterSkillTarget.Type GJLFANGDGCL, int ABBDKBOIBCG)
	{
		bool res = false;
		switch(GJLFANGDGCL)
		{
			case CenterSkillTarget.Type.AllTeam:
			case CenterSkillTarget.Type.AllDiva:
				return true;
			default:
				return false;
			case CenterSkillTarget.Type.CenterDiva:
				return ABBDKBOIBCG == 0;
			case CenterSkillTarget.Type.SeriresAttr1:
				return FDBOPFEOENF.AIHCEGFANAM == 1;
			case CenterSkillTarget.Type.SeriresAttr2:
				return FDBOPFEOENF.AIHCEGFANAM == 2;
			case CenterSkillTarget.Type.SeriresAttr3:
				return FDBOPFEOENF.AIHCEGFANAM == 3;
			case CenterSkillTarget.Type.SeriresAttr4:
				return FDBOPFEOENF.AIHCEGFANAM == 4;
		}
		return res;
	}

	// // RVA: 0x108922C Offset: 0x108922C VA: 0x108922C
	private static bool FJHLLHFGICG(GCIJNCFDNON COIODGJDJEJ, CenterSkillTarget.Type GJLFANGDGCL, int ABBDKBOIBCG, int HBMFKPPOPMK)
	{
		bool res = false;
		switch(GJLFANGDGCL)
		{
			case CenterSkillTarget.Type.AllTeam:
			case CenterSkillTarget.Type.AllScene:
				return true;
			default:
				return false;
			case CenterSkillTarget.Type.MainSlotScene:
				return HBMFKPPOPMK == 0;
			case CenterSkillTarget.Type.CenterDiva:
				return ABBDKBOIBCG == 0;
			case CenterSkillTarget.Type.GameAttrYellow:
				return COIODGJDJEJ.JGJFIJOCPAG_SceneAttr == 1;
			case CenterSkillTarget.Type.GameAttrRed:
				return COIODGJDJEJ.JGJFIJOCPAG_SceneAttr == 2;
			case CenterSkillTarget.Type.GameAttrBlue:
				return COIODGJDJEJ.JGJFIJOCPAG_SceneAttr == 3;
			case CenterSkillTarget.Type.SeriresAttr1:
				return (int)COIODGJDJEJ.AIHCEGFANAM_SceneSeries == 1;
			case CenterSkillTarget.Type.SeriresAttr2:
				return (int)COIODGJDJEJ.AIHCEGFANAM_SceneSeries == 2;
			case CenterSkillTarget.Type.SeriresAttr3:
				return (int)COIODGJDJEJ.AIHCEGFANAM_SceneSeries == 3;
			case CenterSkillTarget.Type.SeriresAttr4:
				return (int)COIODGJDJEJ.AIHCEGFANAM_SceneSeries == 4;
		}
		return res;
	}

	// // RVA: 0x1088D0C Offset: 0x1088D0C VA: 0x1088D0C
	private static void KDOFDLIMHJG(ref StatusData BALBKJFMDFN, StatusData JLJGCBOHJID, JNKEEAOKNCI_Skill.MKGJHBAKMBD GJLFANGDGCL, int PGLJHBODOHN, int CIEOBFIIPLD, JLKEOGLJNOD MLAFAACKKBG)
	{
		List<KFCIIMBBNCD> l = null;
		if(GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.KBHGPMNGALJ)
		{
			l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EBKAAEDMIBI;
		}
		else if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA)
		{
			l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PHPGICHCBPM;
		}
		else if (GJLFANGDGCL == JNKEEAOKNCI_Skill.MKGJHBAKMBD.MHKFDBLMOGF)
		{
			l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA;
		}
		KFCIIMBBNCD sk = l[PGLJHBODOHN - 1];
		if(sk != null)
		{
			float f = sk.KCOHMHFBDKF[CIEOBFIIPLD - 1];
			if (sk.BBFKKANELFP == 1)
			{
				FOKHDKJJOFB fo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO(sk.KCOHMHFBDKF[CIEOBFIIPLD - 1]);
				f = fo.NANNGLGOFKH[CIEOBFIIPLD - 1] * FPJIKEFIJOL(fo.FDBOPFEOENF, MLAFAACKKBG) + fo.NNDBJGDFEEM;
			}
			CHJHPJHNCEB(ref BALBKJFMDFN, JLJGCBOHJID, sk.INDDJNMPONH, f);
		}
	}

	// // RVA: 0x10896DC Offset: 0x10896DC VA: 0x10896DC
	private static void CHJHPJHNCEB(ref StatusData BALBKJFMDFN, StatusData JLJGCBOHJID, byte INDDJNMPONH, float NANNGLGOFKH)
	{
		switch(INDDJNMPONH)
		{
			case 1:
				BALBKJFMDFN.life += (int)(JLJGCBOHJID.life * NANNGLGOFKH);
				BALBKJFMDFN.soul += (int)(JLJGCBOHJID.soul * NANNGLGOFKH);
				BALBKJFMDFN.vocal += (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				BALBKJFMDFN.charm += (int)(JLJGCBOHJID.charm * NANNGLGOFKH);
				BALBKJFMDFN.support += (int)(JLJGCBOHJID.support * NANNGLGOFKH);
				BALBKJFMDFN.fold += (int)(JLJGCBOHJID.fold * NANNGLGOFKH);
				break;
			case 2:
				BALBKJFMDFN.life += (int)(JLJGCBOHJID.life * NANNGLGOFKH);
				break;
			case 3:
				BALBKJFMDFN.soul += (int)(JLJGCBOHJID.soul * NANNGLGOFKH);
				BALBKJFMDFN.vocal += (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				BALBKJFMDFN.charm += (int)(JLJGCBOHJID.charm * NANNGLGOFKH);
				break;
			case 4:
				BALBKJFMDFN.soul += (int)(JLJGCBOHJID.soul * NANNGLGOFKH);
				break;
			case 5:
				BALBKJFMDFN.vocal += (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				break;
			case 6:
				BALBKJFMDFN.charm += (int)(JLJGCBOHJID.charm * NANNGLGOFKH);
				break;
			case 7:
				BALBKJFMDFN.soul -= (int)(JLJGCBOHJID.soul * NANNGLGOFKH);
				break;
			case 8:
				BALBKJFMDFN.vocal -= (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				break;
			case 9:
				BALBKJFMDFN.charm -= (int)(JLJGCBOHJID.charm * NANNGLGOFKH);
				break;
			case 10:
				BALBKJFMDFN.soul -= (int)(JLJGCBOHJID.soul * NANNGLGOFKH);
				BALBKJFMDFN.vocal -= (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				break;
			case 11:
				BALBKJFMDFN.soul -= (int)(JLJGCBOHJID.soul * NANNGLGOFKH);
				BALBKJFMDFN.charm -= (int)(JLJGCBOHJID.charm * NANNGLGOFKH);
				break;
			case 12:
				BALBKJFMDFN.vocal -= (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				BALBKJFMDFN.charm -= (int)(JLJGCBOHJID.charm * NANNGLGOFKH);
				break;
			case 13:
				BALBKJFMDFN.fold -= (int)(JLJGCBOHJID.fold * NANNGLGOFKH);
				break;
			case 14:
				BALBKJFMDFN.support += (int)(JLJGCBOHJID.support * NANNGLGOFKH);
				break;
			case 15:
				BALBKJFMDFN.fold += (int)(JLJGCBOHJID.fold * NANNGLGOFKH);
				break;
		}
	}

	// // RVA: 0x1087F4C Offset: 0x1087F4C VA: 0x1087F4C
	public static bool OJNOJNEKBKH(int LNGOBGPDBAG, int GMPOGAFIAEF)
    {
        return GMPOGAFIAEF == 4 || GMPOGAFIAEF == LNGOBGPDBAG;
    }

	// // RVA: 0x10868E8 Offset: 0x10868E8 VA: 0x10868E8
	private static void NJNBELLEGCN(ref CFHDKAFLNEP HBODCMLFDOB, JLKEOGLJNOD MLAFAACKKBG, DFKGGBMFFGB AHEFHIMGIBI, EEDKAACNBBG KKHIDFKKFJE, EAJCBFGKKFA PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		HBODCMLFDOB.JCHLONCMPAJ();
		int[,] data = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.GODGHFDMAHF();
		if(data != null)
		{
			List<List<GCIJNCFDNON>> ll = new List<List<GCIJNCFDNON>>();
			for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
			{
				ll.Add(new List<GCIJNCFDNON>(AHEFHIMGIBI.OPIBAPEGCLA_Scenes.Count));
			}
			bool b = false;
			for(int i = 0; i < AHEFHIMGIBI.OPIBAPEGCLA_Scenes.Count; i++)
			{
				GCIJNCFDNON sceneInfo = AHEFHIMGIBI.OPIBAPEGCLA_Scenes[i];
				int enabled = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA[sceneInfo.BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_En;
				if(enabled == 2)
				{
					if(sceneInfo.CGKAEMGLHNK_IsUnlocked(true) && !sceneInfo.MCCIFLKCNKO_Feed)
					{
						bool isSub = false;
						for(int j = 0; j < MLAFAACKKBG.BCJEAJPLGMB_MainDivas.Count; j++)
						{
							FFHPBEPOMAK divaInfo = MLAFAACKKBG.BCJEAJPLGMB_MainDivas[j];
							if(divaInfo != null)
							{
								if(i == divaInfo.FGFIBOBAPIA_SceneId - 1)
								{
									break;
								}
								for(int k = 0; k < divaInfo.DJICAKGOGFO_SubSceneIds.Count; k++)
								{
									if(divaInfo.DJICAKGOGFO_SubSceneIds[k] - 1 == i)
									{
										isSub = true;
										break;
									}
								}
							}
						}
						if(!isSub)
						{
							ll[sceneInfo.JGJFIJOCPAG_SceneAttr - 1].Add(sceneInfo);
							b = true;
						}
					}
				}
			}
			if(b)
			{
				NJNBELLEGCN(ref HBODCMLFDOB, data, ll, AHEFHIMGIBI, MLAFAACKKBG, KKHIDFKKFJE, PCEGKKLKFNO, KDOLMBEAGCI);
			}
			else
			{
				for(int i = 0; i < data.GetLength(0); i++)
				{
					for(int j = 0; j < data.GetLength(1); j++)
					{
						HBODCMLFDOB.KOGBMDOONFA[i, j].ADKDHKMPMHP_Rate = data[i, j];
					}					
				}
			}
		}
	}

	// // RVA: 0x1089E00 Offset: 0x1089E00 VA: 0x1089E00
	public static void NJNBELLEGCN(ref CFHDKAFLNEP HBODCMLFDOB, int[,] EDAJDLJHBKP, List<List<GCIJNCFDNON>> OPIBAPEGCLA, DFKGGBMFFGB AHEFHIMGIBI, JLKEOGLJNOD MLAFAACKKBG, EEDKAACNBBG KKHIDFKKFJE, EAJCBFGKKFA PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		GCIJNCFDNON sceneInfo = null;
		if(MLAFAACKKBG != null)
		{
			FFHPBEPOMAK divaInfo = MLAFAACKKBG.BCJEAJPLGMB_MainDivas[0];
			if(divaInfo != null)
			{
				if(divaInfo.FGFIBOBAPIA_SceneId != 0)
				{
					sceneInfo = AHEFHIMGIBI.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if(KKHIDFKKFJE == null)
					{
						if(sceneInfo.MEOOLHNNMHL(false, 0, 0) == 0)
							sceneInfo = null;
					}
					else
					{
						if(sceneInfo.MEOOLHNNMHL(false, KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE.AIHCEGFANAM_Serie) == 0)
							sceneInfo = null;
					}
				}
			}
		}
		GCIJNCFDNON sceneInfo2 = null;
		if(PCEGKKLKFNO != null)
		{
			sceneInfo2 = PCEGKKLKFNO.KHGKPKDBMOH();
			if(sceneInfo2 != null)
			{
				if(KKHIDFKKFJE == null)
				{
					if(sceneInfo2.MEOOLHNNMHL(false, 0, 0) == 0)
						sceneInfo2 = null;
				}
				else
				{
					if(sceneInfo2.MEOOLHNNMHL(false, KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE.AIHCEGFANAM_Serie) == 0)
						sceneInfo2 = null;
				}
			}
		}
		CFHDKAFLNEP.OCNHGDCPJDG[,] data = new CFHDKAFLNEP.OCNHGDCPJDG[3, 3];
		StatusData st = new StatusData();
		StatusData st2 = new StatusData();
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			if(OPIBAPEGCLA[i].Count < 1)
			{
				for(int j = 0; j < EDAJDLJHBKP.GetLength(1); j++)
				{
					HBODCMLFDOB.KOGBMDOONFA[i, j].ADKDHKMPMHP_Rate = EDAJDLJHBKP[i, j];
				}
			}
			else
			{
				bool attrMatch = false;
				if(KKHIDFKKFJE != null)
				{
					attrMatch = (KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == i + 1);
				}
				for(int j = 0; j < 3; j++)
				{
					OPIBAPEGCLA[i].Sort(MOGECDOLPPL[j]);
					int val = Mathf.Min(3, OPIBAPEGCLA[i].Count);
					int val2 = EDAJDLJHBKP[i, j];
					if(val  < 1)
					{
						val = 0;
						val--;
						for(int k = val + 1; k < 3; k++)
						{
							data[j, k].PBPOLELIPJI_Id = 0;
							data[j, k].IFFKEMEOFAE_EvolveId = 0;
							data[j, k].ADKDHKMPMHP_Rate = val2;
							data[j, k].OEOIHIIIMCK_Add = 0;
							data[j, k].ALJGIPAGDJI = 0;
							data[j, k].HIPODBKKJFL = 0;
							data[j, k].KHDDPKHPJID = 0;
							data[j, k].LHFPLDHBAAN = false;
							data[j, k].KPNDMALAOKC = false;
							data[j, k].OGHIOHAACIB = false;
						}
					}
					else
					{
						int k = 0;
						for(; k < val; k++)
						{
							GCIJNCFDNON sceneInfo3 = OPIBAPEGCLA[i][k];
							data[j, k].PBPOLELIPJI_Id = sceneInfo3.BCCHOBPJJKE_SceneId;
							data[j, k].IFFKEMEOFAE_EvolveId = sceneInfo3.CGIELKDLHGE_GetEvolveId();
							data[j, k].ADKDHKMPMHP_Rate = val2;
							data[j, k].OGHIOHAACIB = sceneInfo3.MBMFJILMOBP();
							st.Copy(sceneInfo3.CMCKNKKCNDK_Status);
							bool c = attrMatch;
							int e = 0;
							if(sceneInfo != null)
							{
								int a = sceneInfo.MEOOLHNNMHL(false, KKHIDFKKFJE != null ? KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr : 0, KKHIDFKKFJE != null ? KKHIDFKKFJE.AIHCEGFANAM_Serie : 0);
								st2.Clear();
								MHPBLAEDJOC(ref st2, sceneInfo3, KKHIDFKKFJE, a, sceneInfo.DDEDANKHHPN_SkillLevel, MLAFAACKKBG);
								e = HDLKMMHKOKE[j].Invoke(st2);
								c |= e > 0;
							}
							if(sceneInfo2 != null)
							{
								int a = sceneInfo2.MEOOLHNNMHL(false, KKHIDFKKFJE != null ? KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr : 0, KKHIDFKKFJE != null ? KKHIDFKKFJE.AIHCEGFANAM_Serie : 0);
								st2.Clear();
								MHPBLAEDJOC(ref st2, sceneInfo3, KKHIDFKKFJE, a, sceneInfo2.DDEDANKHHPN_SkillLevel, MLAFAACKKBG);
								int d = HDLKMMHKOKE[j].Invoke(st2);
								e += d;
								c |= d > 0;
							}
							bool g = false;
							if(KDOLMBEAGCI != null && KDOLMBEAGCI.PDHCABLLJPB != 0)
							{
								HBDCPGLAPHH h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.FFCFHFOIKGB[KDOLMBEAGCI.PDHCABLLJPB - 1];
								int aa = 0;
								for(int l = 0; l < 2; l++)
								{
									if(l == 1)
									{
										if(h.AKGNPLBDKLN_P2 != 0)
											aa = h.AKGNPLBDKLN_P2;
									}
									else if(l == 0)
									{
										if(h.HEKHODDJHAO_P1 != 0)
											aa = h.HEKHODDJHAO_P1;
									}
									st2.Clear();
									KDOFDLIMHJG(ref st2, sceneInfo3.CMCKNKKCNDK_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD.AIFGINAKBMA, aa, 1, MLAFAACKKBG);
									int d = HDLKMMHKOKE[j].Invoke(st2);
									e += d;
									c |= d > 0;
									g |= d < 0; // ??
								}
							}
							int d_ = HDLKMMHKOKE[j].Invoke(sceneInfo3.CMCKNKKCNDK_Status);
							int bb = attrMatch ? 1 : 0;
							if(attrMatch)
								bb = d_ * 30;
							data[j, k].OEOIHIIIMCK_Add = (((bb + e) / 100 + d_) * val2) / 100;
							data[j, k].KHDDPKHPJID = (d_ * val2) / 100;
							data[j, k].ALJGIPAGDJI = (attrMatch ? ((bb / 100) * val2) / 100 : 0);
							bool cc = false;
							if(c)
							{
								if(data[j, k].OEOIHIIIMCK_Add > 0)
									cc = true;
							}
							data[j, k].LHFPLDHBAAN = cc;
							data[j, k].HIPODBKKJFL = e < 1 ? 0 : ((e / 100) * val2) / 100;
							data[j, k].KPNDMALAOKC = g;
							
						}
						for(; k < 3; k++)
						{
							data[j, k].PBPOLELIPJI_Id = 0;
							data[j, k].IFFKEMEOFAE_EvolveId = 0;
							data[j, k].ADKDHKMPMHP_Rate = val2;
							data[j, k].OEOIHIIIMCK_Add = 0;
							data[j, k].ALJGIPAGDJI = 0;
							data[j, k].HIPODBKKJFL = 0;
							data[j, k].KHDDPKHPJID = 0;
							data[j, k].LHFPLDHBAAN = false;
							data[j, k].KPNDMALAOKC = false;
							data[j, k].OGHIOHAACIB = false;
						}
					}
				}
				int maxAdd = 0;
				for(int j = 0; j < 3; j++)
				{
					int id_j = data[0, j].PBPOLELIPJI_Id;
					for(int k = 0; k < 3; k++)
					{
						int id_k = data[1, k].PBPOLELIPJI_Id;
						for(int l = 0; l < 3; l++)
						{
							int id_l = data[2, l].PBPOLELIPJI_Id;

							if((id_l == 0 || id_l != id_j) && 
								(id_j == 0 || id_j != id_k) && 
								(id_k == 0 || id_k != id_l))
							{
								int v = data[0, j].OEOIHIIIMCK_Add + data[1, j].OEOIHIIIMCK_Add + data[2, j].OEOIHIIIMCK_Add;
								if(maxAdd < v)
								{
									HBODCMLFDOB.KOGBMDOONFA[i, 0] = data[0, j];
									HBODCMLFDOB.KOGBMDOONFA[i, 1] = data[1, k];
									HBODCMLFDOB.KOGBMDOONFA[i, 2] = data[2, l];
									maxAdd = v;
								}
							}
						}
					}
				}
				for(int j = 0; j < 3; j++)
				{
					HOBOLJEFDFF[j].Invoke(HBODCMLFDOB.CMCKNKKCNDK, HBODCMLFDOB.KOGBMDOONFA[i, j].OEOIHIIIMCK_Add);
				}
			}
		}
	}

	// // RVA: 0x108BAF0 Offset: 0x108BAF0 VA: 0x108BAF0
	private static void MHPBLAEDJOC(ref StatusData BALBKJFMDFN, GCIJNCFDNON COIODGJDJEJ, EEDKAACNBBG KKHIDFKKFJE, int ENMAEBJGEKL, int CNLIAMIIJID, JLKEOGLJNOD MLAFAACKKBG)
	{
		HBDCPGLAPHH skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP[ENMAEBJGEKL - 1];
		for(int i = 0; i < 2; i++)
		{
			int skillId = 0;
			KFCIIMBBNCD a = null;
			if (i == 1)
			{
				if (skill.AKGNPLBDKLN_P2 == 0)
					return;
				a = KDDDDMMMBHE(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.AKGNPLBDKLN_P2, JNKEEAOKNCI_Skill.MKGJHBAKMBD.MHKFDBLMOGF);
				skillId = skill.AKGNPLBDKLN_P2;
			}
			else if(i == 0)
			{
				if(skill.HEKHODDJHAO_P1 != 0)
				{
					a = KDDDDMMMBHE(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.HEKHODDJHAO_P1, JNKEEAOKNCI_Skill.MKGJHBAKMBD.MHKFDBLMOGF);
					skillId = skill.HEKHODDJHAO_P1;
				}
			}
			if(a != null)
			{
				if(FNIEADNMMIA((CenterSkillCondition.Type)a.OAFPGJLCNFM_CenterSkillCondition, KKHIDFKKFJE, COIODGJDJEJ.AIHCEGFANAM_SceneSeries))
				{
					if(FJHLLHFGICG(COIODGJDJEJ, (CenterSkillTarget.Type)a.GJLFANGDGCL_CenterSkillTarget, -1, -1))
					{
						KDOFDLIMHJG(ref BALBKJFMDFN, COIODGJDJEJ.CMCKNKKCNDK_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD.MHKFDBLMOGF, skillId, CNLIAMIIJID, MLAFAACKKBG);
					}
				}
			}
		}
	}

	// // RVA: 0x1089374 Offset: 0x1089374 VA: 0x1089374
	public static int FPJIKEFIJOL(int NCNFMHDKAPN, JLKEOGLJNOD CDCKLJAJBDO)
	{
		int total = 0;
		for(int i = 0; i < CDCKLJAJBDO.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK infoDiva = CDCKLJAJBDO.BCJEAJPLGMB_MainDivas[i];
			if(infoDiva != null)
			{
				if(infoDiva.FGFIBOBAPIA_SceneId > 0)
				{
					if((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA[infoDiva.FGFIBOBAPIA_SceneId - 1].AOLIJKMIJJE_Dv & NCNFMHDKAPN) != 0)
						total++;
				}
				for(int j = 0; j < infoDiva.DJICAKGOGFO_SubSceneIds.Count; i++)
				{
					if(infoDiva.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						if((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA[infoDiva.DJICAKGOGFO_SubSceneIds[j] - 1].AOLIJKMIJJE_Dv & NCNFMHDKAPN) != 0)
							total++;
					}
				}
			}
		}
		return total;
	}

	// // RVA: 0x108C0FC Offset: 0x108C0FC VA: 0x108C0FC
	public static int NDNOLJACLLC(NOJENDEDECD HLANCDFJFIA)
	{
		return OOPMCKOCEFM[(int)HLANCDFJFIA];
	}

	// // RVA: 0x108C1C0 Offset: 0x108C1C0 VA: 0x108C1C0
	public static int EPNPGMCGJKB(Difficulty.Type AKNELONELJK_Difficulty, bool NGKGFBLFEGH_IsLine6)
	{
		if(NGKGFBLFEGH_IsLine6)
		{
			return DNJCAKPKNDP[(int)AKNELONELJK_Difficulty + 3];
		}
		else
		{
			return DNJCAKPKNDP[(int)AKNELONELJK_Difficulty];
		}
	}

	// // RVA: 0x108C2EC Offset: 0x108C2EC VA: 0x108C2EC
	public static float GPCKPNJGANO(ResultScoreRank.Type FJOLNJLLJEJ)
	{
		return LKBGHCIKIOA[(int)FJOLNJLLJEJ];
	}

	// // RVA: 0x108C3B0 Offset: 0x108C3B0 VA: 0x108C3B0
	public static void EFCNOOFFMIL(DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, Difficulty.Type AKNELONELJK_Difficulty, bool PDLCNDBOMAN_IsLine6, bool CMEOKJMCEBH_IsGoDivaEvent)
	{
		EFCNOOFFMIL(DJLNOAMJECI_PlayerData, DJLNOAMJECI_PlayerData.DPLBHAIKPGL(CMEOKJMCEBH_IsGoDivaEvent), ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6);
	}

	// // RVA: 0x108C488 Offset: 0x108C488 VA: 0x108C488
	public static void EFCNOOFFMIL(DFKGGBMFFGB DJLNOAMJECI_Playerdata, JLKEOGLJNOD HJJNDDPGIML_Team, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, Difficulty.Type AKNELONELJK_Difficulty, bool PDLCNDBOMAN_IsLine6)
	{
		for (int i = 0; i < OOPMCKOCEFM.Length; i++)
		{
			OOPMCKOCEFM[i] = 0;
		}
		CFHDKAFLNEP calcData = new CFHDKAFLNEP();
		ADDHLABEFKH a = null;
		if (GMFMMDAKENC_MusicData is IBJAKJJICBC)
		{
			a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[(GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId].EMJCHPDJHEI(PDLCNDBOMAN_IsLine6, (int)AKNELONELJK_Difficulty);
		}
		else if (GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO).COGKJBAFBKN[(int)AKNELONELJK_Difficulty];
		}
		int musicId = GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId;
		EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId);
		KLBKPANJCPL_Score score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(musicInfo.KKPAHLMJKIH_WavId, musicInfo.BKJGCEOEPFB_VariationId, (int)AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, true);
		int progress = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(score.ANAJIAENLNB_F_pt, PDLCNDBOMAN_IsLine6);
		int baseScore = CBILJEAECKP_GetBaseScore(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, GMFMMDAKENC_MusicData, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, score.ANAJIAENLNB_F_pt, progress, HJJNDDPGIML_Team);
		//gauge_01_base
		OOPMCKOCEFM[(int)NOJENDEDECD.HNGJDMNPMNP_BaseScore] = baseScore;
		//gauge_05_shien / plate
		OOPMCKOCEFM[(int)NOJENDEDECD.GJDKJOHIEFF_PlateScore] = MHIKPDIJKJO(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, progress, HJJNDDPGIML_Team);
		//gauge_02_isyou
		OOPMCKOCEFM[(int)NOJENDEDECD.KBHGPMNGALJ] = CHCGGEPAAOE(DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, progress, HJJNDDPGIML_Team);
		//gauge_03_zokusei / ?? bonus
		OOPMCKOCEFM[(int)NOJENDEDECD.AJIDOFDBIDL] = DONJDICAMJB(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, progress, HJJNDDPGIML_Team);
		EDMIONMCICN d = new EDMIONMCICN();
		//gauge_04_cskill
		OOPMCKOCEFM[(int)NOJENDEDECD.BMMPEPDFICC_CenterSkillScore] = DBHEBCCLIJG(ref d, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref calcData, progress, false, HJJNDDPGIML_Team);
		bool e = false;
		bool g = false;
		bool f = MODGPFEPLIP(ref d, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, out e, out g, HJJNDDPGIML_Team);
		//gauge_06_lskill
		OOPMCKOCEFM[(int)NOJENDEDECD.CPJOGHCLENG_LiveSkillScore] = LKGBAIANMLE(baseScore, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		//gauge_07_askill
		OOPMCKOCEFM[(int)NOJENDEDECD.NKPLJNILBFP_ASkillScore] = BPPIFIAGLBI(baseScore, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
		//gauge_08_combo
		OOPMCKOCEFM[(int)NOJENDEDECD.NLAGKLDCBAG_Combo] = AFBHKBGLMHG * baseScore / 1000;
		if (f)
		{
			//gauge_09_notes
			OOPMCKOCEFM[(int)NOJENDEDECD.GGOOOIKELDH_NotesScore] = CBIIKLGPILB(baseScore, GMFMMDAKENC_MusicData, DJLNOAMJECI_Playerdata, AKNELONELJK_Difficulty, score, PDLCNDBOMAN_IsLine6, g ? 1 : 0, HJJNDDPGIML_Team);
		}
		//gauge_10_leaf
		OOPMCKOCEFM[(int)NOJENDEDECD.OPCNHIMPGCE_LeafScore] = OPKNHONFIOG(baseScore, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		int total = 0;
		for (int i = 0; i < OOPMCKOCEFM.Length; i++)
		{
			total += OOPMCKOCEFM[i];
		}
		OOPMCKOCEFM[(int)NOJENDEDECD.CPJOGHCLENG_LiveSkillScore] += NGCOIOANNPA(total, baseScore, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
		int total2 = 0;
		for (int i = 0; i < OOPMCKOCEFM.Length; i++)
		{
			OOPMCKOCEFM[i] = OOPMCKOCEFM[i] * HCEPBDBHILM[i] / 100;
			total2 += OOPMCKOCEFM[i];
		}
		KHCOOPDAGOE_ScoreRank = (ResultScoreRank.Type)a.DLPBHJALHCK_GetRank(total2);
		if(DNJCAKPKNDP.Count == 0)
		{
			for(int i = 0; i < DALGMKEOFLN.Length; i++)
			{
				DNJCAKPKNDP.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA(DALGMKEOFLN[i], 200000));
			}
		}
		for(int i = 0; i < 4; i++)
		{
			LKBGHCIKIOA[i + 1] = a.KNIFCANOHOC_RankScore[i] * 1.0f / DNJCAKPKNDP[(int)AKNELONELJK_Difficulty];
		}
		int h = EPNPGMCGJKB(AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6);
		FDLECNKJCGG_GaugeRatio = total2 * 1.0f / h;
	}

	// // RVA: 0x1092B60 Offset: 0x1092B60 VA: 0x1092B60
	public static void BKBMHJBFDOG()
	{
		TodoLogger.Log(0, "BKBMHJBFDOG");
	}

	// // RVA: 0x108D788 Offset: 0x108D788 VA: 0x108D788
	private static int CBILJEAECKP_GetBaseScore(DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, EEDKAACNBBG GMFMMDAKENC_MusicData, Difficulty.Type AKNELONELJK_Difficulty, bool GBNOALJPOBM_IsLine6, int BAKLKJLPLOJ_FPt, int DHIPGHBJLIL_Progress, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE();
		CFHDKAFLNEP data2 = new CFHDKAFLNEP();
		data2.OBKGEDCKHHE();
		int a = DBHEBCCLIJG(ref data, DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref data2, DHIPGHBJLIL_Progress, true, HEDKFICAPIJ_Team);
		int b = DBHEBCCLIJG(ref data, DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref data2, DHIPGHBJLIL_Progress, true, HEDKFICAPIJ_Team);
		int total = 0;
		for (int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if (divaInfo != null)
			{
				StatusData sdata = divaInfo.CMCKNKKCNDK_EquippedStatus;
				total += sdata.soul + sdata.vocal + sdata.charm;
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					StatusData sdata2 = sceneInfo.CMCKNKKCNDK_Status;
					total += sdata2.soul + sdata2.vocal + sdata2.charm;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						StatusData sdata2 = sceneInfo.CMCKNKKCNDK_Status;
						total += sdata2.soul + sdata2.vocal + sdata2.charm;
					}
				}
			}
		}
		if (ALOBLKOHIKD_FriendData != null)
		{
			GCIJNCFDNON data3 = ALOBLKOHIKD_FriendData.KHGKPKDBMOH();
			if (data3 != null)
			{
				StatusData sdata = data3.CMCKNKKCNDK_Status;
				total += sdata.soul + sdata.vocal + sdata.charm;
			}
		}
		int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(BAKLKJLPLOJ_FPt, GBNOALJPOBM_IsLine6);
		return (a - b) + Mathf.RoundToInt(c * total / 1000.0f);
	}

	// // RVA: 0x108E2F8 Offset: 0x108E2F8 VA: 0x108E2F8
	private static int CHCGGEPAAOE(DFKGGBMFFGB AHEFHIMGIBI_PlayerData, EEDKAACNBBG KKHIDFKKFJE_MusicData, EAJCBFGKKFA PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData, int DHIPGHBJLIL, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE();
		int total = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD(ref data, divaInfo, HEDKFICAPIJ_Team, AHEFHIMGIBI_PlayerData, KKHIDFKKFJE_MusicData, PCEGKKLKFNO_FriendData, KDOLMBEAGCI_EnemyData);
				data.IMLOCECFHGK(ref FLOHCPIIHEH);
				total += FLOHCPIIHEH.soul + FLOHCPIIHEH.vocal + FLOHCPIIHEH.charm;
			}
		}
		return (total * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108E584 Offset: 0x108E584 VA: 0x108E584
	private static int DONJDICAMJB(DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int DHIPGHBJLIL, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE();
		int total = 0;
		for (int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if (divaInfo != null)
			{
				AECDJDIJJKD(ref data, divaInfo, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
				for(int j = 0; j < data.MCBLDOECHEK.Length; j++)
				{
					total += data.MCBLDOECHEK[i].PJCKMKEJCEL();
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null)
		{
			NIPJMNDBCNF(ref data, HEDKFICAPIJ_Team, ALOBLKOHIKD_FriendData, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData);
			for (int j = 0; j < data.MCBLDOECHEK.Length; j++)
			{
				total += data.MCBLDOECHEK[0].PJCKMKEJCEL();
			}
		}
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				total += LNMECJDKFDN.KOGBMDOONFA[i, j].ALJGIPAGDJI;
			}
		}
		return (total * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108E93C Offset: 0x108E93C VA: 0x108E93C
	private static int DBHEBCCLIJG(ref EDMIONMCICN HBODCMLFDOB, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int DHIPGHBJLIL, bool CCPIGKONMMH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		HBODCMLFDOB.OBKGEDCKHHE();
		int val = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD(ref HBODCMLFDOB, divaInfo, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
				HBODCMLFDOB.BEDINMCPENB(ref FLOHCPIIHEH);
				int s = 0;
				for(int j = 0; j < HBODCMLFDOB.MCBLDOECHEK.Length; j++)
				{
					s += HBODCMLFDOB.MCBLDOECHEK[j].PJCKMKEJCEL();
				}
				val = (val - s) + FLOHCPIIHEH.Total;
			}
		}
		if(ALOBLKOHIKD_FriendData != null)
		{
			NIPJMNDBCNF(ref HBODCMLFDOB, HEDKFICAPIJ_Team, ALOBLKOHIKD_FriendData, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData);
			StatusData st = HBODCMLFDOB.BJABFKMIJHB;
			val = (st.soul + val + st.vocal + st.charm) - HBODCMLFDOB.MCBLDOECHEK[0].PJCKMKEJCEL();
		}
		if(!CCPIGKONMMH)
		{
			for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					val += LNMECJDKFDN.KOGBMDOONFA[i,j].HIPODBKKJFL;
				}
			}
		}
		return (val * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108DEA8 Offset: 0x108DEA8 VA: 0x108DEA8
	private static int MHIKPDIJKJO(DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP HBODCMLFDOB, int DHIPGHBJLIL, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		HBODCMLFDOB.OBKGEDCKHHE();
		NJNBELLEGCN(ref HBODCMLFDOB, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
		int val = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val += HBODCMLFDOB.KOGBMDOONFA[i, j].KHDDPKHPJID;
			}
		}
		CFHDKAFLNEP data = new CFHDKAFLNEP();
		data.OBKGEDCKHHE();
		NJNBELLEGCN(ref data, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
		int val2 = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val2 += HBODCMLFDOB.KOGBMDOONFA[i, j].HIPODBKKJFL;
			}
		}
		NJNBELLEGCN(ref data, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, null);
		int val3 = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val3 += HBODCMLFDOB.KOGBMDOONFA[i, j].HIPODBKKJFL;
			}
		}
		val3 *= DHIPGHBJLIL;
		return (val2 * DHIPGHBJLIL) / 1000 + (val * DHIPGHBJLIL) / 1000 - val3 / 1000;
	}

	// // RVA: 0x1092FB8 Offset: 0x1092FB8 VA: 0x1092FB8
	private static int FILPDDHMKEJ(GCIJNCFDNON LAPAEBEIAFK, EEDKAACNBBG GMFMMDAKENC, FFHPBEPOMAK JCFNFJJKPAM)
	{
		if(LAPAEBEIAFK != null)
		{
			int skillId = LAPAEBEIAFK.FILPDDHMKEJ(false, GMFMMDAKENC != null ? GMFMMDAKENC.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC != null ? GMFMMDAKENC.AIHCEGFANAM_Serie : 0);
			if(skillId > 0)
			{
				if(LAPAEBEIAFK.DCLLIDMKNGO_IsDivaCompatible(JCFNFJJKPAM.AHHJLDLAPAN_DivaId))
				{
					PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
					if(skillInfo.AANDPLGPDEI() && !skillInfo.HDPIEILADDH(GMFMMDAKENC.DLAEJOBELBH_MusicId))
					{
						return 0;
					}
					if(skillInfo.HCGDJAFINMH() && !skillInfo.OEJNKFONOGJ(GMFMMDAKENC.FKDCCLPGKDK_JacketAttr))
					{
						return 0;
					}
					return skillId;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1093268 Offset: 0x1093268 VA: 0x1093268
	private static int OPGMFCHDEDF(int KPIIIEGGPIB, GCIJNCFDNON COIODGJDJEJ, int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, KLBKPANJCPL_Score POMOLHBFAPM, bool KIFJKGDBDBH, JLKEOGLJNOD HEDKFICAPIJ, FFHPBEPOMAK NENDFGDMJDN)
	{
		if (KPIIIEGGPIB < 1)
			return 0;
		PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[KPIIIEGGPIB - 1];
		int res = 0;
		for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
		{
			int a = CKNDJNOFFGP(skillInfo, i, COIODGJDJEJ.AADFFCIDJCB_LiveSkillLevel, NENDFGDMJDN);
			int b = IGDGGMIMLDN(a, DJLNOAMJECI, GMFMMDAKENC, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.FLJHGGKIOJH_SkillType, POMOLHBFAPM, HEDKFICAPIJ);
			int c = MEAHJKCBGFE(FLKGCONIFEE, KHDDPKHPJID, DJLNOAMJECI, GMFMMDAKENC, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[i, COIODGJDJEJ.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[COIODGJDJEJ.AADFFCIDJCB_LiveSkillLevel - 1], skillInfo.ELEPHBOKIGK_LimitCount[0], POMOLHBFAPM, KIFJKGDBDBH);
			res += c;
		}
		return res;
	}

	// // RVA: 0x108F96C Offset: 0x108F96C VA: 0x108F96C
	private static int LKGBAIANMLE(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		int res = 0;
		for (int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if (i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if (sceneInfo != null)
					{
						int skillId = sceneInfo.FILPDDHMKEJ(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_Serie : 0);
						if (skillId > 0 && sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaInfo.AHHJLDLAPAN_DivaId))
						{
							PPGHMBNIAEC info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
							if (!info.AANDPLGPDEI() || info.HDPIEILADDH(GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
							{
								if (!info.HCGDJAFINMH() || info.OEJNKFONOGJ(GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
								{
									for (int j = 0; j < info.EGLDFPILJLG_SkillBuffEffect.Length; j++)
									{
										int a = CKNDJNOFFGP(info, j, sceneInfo.AADFFCIDJCB_LiveSkillLevel, divaInfo);
										int b = IGDGGMIMLDN(a, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], info.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, HEDKFICAPIJ_Team);
										int c = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[j, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, info.LFGFBMJNBKN_ConfigValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, OOOGNIPJMDE, OHLCKPIMMFH);
										int d = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[j, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, sceneInfo.AADFFCIDJCB_LiveSkillLevel, POMOLHBFAPM_Score, HGEKDNNJAAC, false);
										res += d + c;
									}
								}
							}
						}
					}
				}
				for(int k = 0; k < divaInfo.DJICAKGOGFO_SubSceneIds.Count; k++)
				{
					if(divaInfo.DJICAKGOGFO_SubSceneIds[k] > 0)
					{
						GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[k] - 1];
						if (sceneInfo != null)
						{
							int skillId = sceneInfo.FILPDDHMKEJ(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_Serie : 0);
							if (skillId > 0 && sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaInfo.AHHJLDLAPAN_DivaId))
							{
								PPGHMBNIAEC info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
								if (!info.AANDPLGPDEI() || info.HDPIEILADDH(GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
								{
									if (!info.HCGDJAFINMH() || info.OEJNKFONOGJ(GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
									{
										for (int j = 0; j < info.EGLDFPILJLG_SkillBuffEffect.Length; j++)
										{
											int a = CKNDJNOFFGP(info, j, sceneInfo.AADFFCIDJCB_LiveSkillLevel, divaInfo);
											int b = IGDGGMIMLDN(a, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], info.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, HEDKFICAPIJ_Team);
											int c = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[j, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, info.LFGFBMJNBKN_ConfigValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, OOOGNIPJMDE, OHLCKPIMMFH);
											int d = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[j, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, sceneInfo.AADFFCIDJCB_LiveSkillLevel, POMOLHBFAPM_Score, HGEKDNNJAAC, false);
											res += d + c;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1092720 Offset: 0x1092720 VA: 0x1092720
	private static int NGCOIOANNPA(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		int res = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					res += OPGMFCHDEDF(FILPDDHMKEJ(sceneInfo, GMFMMDAKENC_MusicData, divaInfo), sceneInfo, FLKGCONIFEE, KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, POMOLHBFAPM_Score, false, HEDKFICAPIJ_Team, divaInfo);
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						res += OPGMFCHDEDF(FILPDDHMKEJ(sceneInfo, GMFMMDAKENC_MusicData, divaInfo), sceneInfo, FLKGCONIFEE, KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, POMOLHBFAPM_Score, false, HEDKFICAPIJ_Team, divaInfo);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x10908A8 Offset: 0x10908A8 VA: 0x10908A8
	private static int BPPIFIAGLBI(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		int res = 0;
		FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[0];
		if(divaInfo != null)
		{
			if(divaInfo.FGFIBOBAPIA_SceneId > 0)
			{
				GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
				if (sceneInfo.HGONFBDIBPM_ActiveSkillId < 1)
					return 0;
				CDNKOFIELMK skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[sceneInfo.HGONFBDIBPM_ActiveSkillId - 1];
				for(int i = 0; i < skillInfo.EGLDFPILJLG_BuffEffectType.Length; i++)
				{
					int a = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_BuffEffectType[i], skillInfo.NKGHBKFMFCI_BuffValueByIndexAndLevel[i, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[i, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], SkillTrigger.Type.None, 0, POMOLHBFAPM_Score, false, false, false);
					int b = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_BuffEffectType[i], skillInfo.NKGHBKFMFCI_BuffValueByIndexAndLevel[i, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[i, sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], SkillTrigger.Type.None, 0, POMOLHBFAPM_Score, true, false);
					res += b + a;
				}
			}
		}
		return res;
	}

	// // RVA: 0x1090E60 Offset: 0x1090E60 VA: 0x1090E60
	private static int CBIIKLGPILB(int KHDDPKHPJID, EEDKAACNBBG GMFMMDAKENC_MusicData, DFKGGBMFFGB DJLNOAMJECI_PlayerData, Difficulty.Type AKNELONELJK_Difficulty, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool GBNOALJPOBM_IsLine6, int BAKLKJLPLOJ, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		int res = 0;
		if (GMFMMDAKENC_MusicData != null)
		{
			if(GMFMMDAKENC_MusicData is IBJAKJJICBC)
			{
				KEODKEGFDLD musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
				short[] vals = GBNOALJPOBM_IsLine6 ? musicInfo.DPJDHKIIJIJ_SpNotesByDiff6Line : musicInfo.OCOGIADDNDN_SpNoteByDiff;
				if (vals[(int)AKNELONELJK_Difficulty] < 1)
					res = 0;
				else
				{
					KLJCBKMHKNK k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.BBFNPHGDCOF(vals[(int)AKNELONELJK_Difficulty]);
					EGLJKICMCPG e = k.GCINIJEMHFK(KLJCBKMHKNK.HHMPIIILOLD.CBHCEDGAGHL/*3*/);
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GAHIBKLEDBF((int)AKNELONELJK_Difficulty, GBNOALJPOBM_IsLine6);
					int b = (int)Mathf.Clamp(e.PHGLKBPLFDH_RMax / 100.0f * POMOLHBFAPM_Score.JJBOEMOJPEC, e.MPPANPOOIIB_NMin, e.GKPPCFMBANO_NMax);
					res = 0;
					int c = POMOLHBFAPM_Score.JJBOEMOJPEC;
					if (c < b)
						b = c;
					if(e.JNNKKPNGPAA(SpecialNoteAttribute.Type.HighScore) != 0)
					{
						int numSpNoteExpected = 0;
						for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
						{
							FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
							if(divaInfo != null)
							{
								if(divaInfo.FGFIBOBAPIA_SceneId > 0)
								{
									GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
									numSpNoteExpected += sceneInfo.CMCKNKKCNDK_Status.spNoteExpected[2];
								}
								for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
								{
									if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
									{
										GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
										numSpNoteExpected += sceneInfo.CMCKNKKCNDK_Status.spNoteExpected[2];
									}
								}
							}
						}
						b = Mathf.RoundToInt((numSpNoteExpected / 10 + e.JNNKKPNGPAA(SpecialNoteAttribute.Type.HighScore)) * b);
						res = KHDDPKHPJID / a * b;
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x10915F0 Offset: 0x10915F0 VA: 0x10915F0
	private static int OPKNHONFIOG(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		MEMCOJHNEIP.Clear();
		GCIJNCFDNON s = null;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if(sceneInfo.MKHFCGPJPFI_LimitOverCount > 0)
					{
						OMPNCHBNEPF.KHEKNNFCAOI(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_Luck);
						HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK, sceneInfo, GMFMMDAKENC_MusicData);
						MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK);
					}
					if (i == 0)
						s = sceneInfo;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						if (sceneInfo.MKHFCGPJPFI_LimitOverCount > 0)
						{
							OMPNCHBNEPF.KHEKNNFCAOI(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_Luck);
							HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK, sceneInfo, GMFMMDAKENC_MusicData);
							MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK);
						}
					}
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH() != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH().MKHFCGPJPFI_LimitOverCount > 0)
		{
			GCIJNCFDNON sceneInfo = ALOBLKOHIKD_FriendData.KHGKPKDBMOH();
			OMPNCHBNEPF.KHEKNNFCAOI(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_Luck);
			HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK, sceneInfo, GMFMMDAKENC_MusicData);
			MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK);
		}
		int e = 0;
		if (s != null)
		{
			int skillId = s.FILPDDHMKEJ(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_Serie : 0);
			if(skillId > 0)
			{
				PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
				int rate = (MEMCOJHNEIP.centerLiveSkillRate + MEMCOJHNEIP.centerLiveSkillRate_SameMusicAttr + MEMCOJHNEIP.centerLiveSkillRate_SameSeriesAttr);
				for (int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
				{
					int a = CKNDJNOFFGP(skillInfo, i, s.AADFFCIDJCB_LiveSkillLevel, HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[0]);
					int b = IGDGGMIMLDN(a, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, HEDKFICAPIJ_Team);
					int c = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type) skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type) skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[i, s.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type) skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, OOOGNIPJMDE, OHLCKPIMMFH);
					int g = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[i, s.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, false);
					int d = MEAHJKCBGFE(0, KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[i, s.AADFFCIDJCB_LiveSkillLevel - 1], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], skillInfo.ELEPHBOKIGK_LimitCount[0], POMOLHBFAPM_Score, true);
					e += c * rate / 100 + g * rate / 100 + d * rate / 100;
				}
			}
		}
		return ((KHDDPKHPJID / POMOLHBFAPM_Score.NLKEBAOBJCM_Cb) * ((POMOLHBFAPM_Score.NLKEBAOBJCM_Cb * 90 / 100) * (MEMCOJHNEIP.excellentRate + MEMCOJHNEIP.excellentRate_SameMusicAttr + MEMCOJHNEIP.excellentRate_SameSeriesAttr)) / 100 * 90) / 100 + e;
	}

	// // RVA: 0x1094624 Offset: 0x1094624 VA: 0x1094624
	private static void HHOKCLBEOHI(LimitOverStatusData CMCKNKKCNDK, GCIJNCFDNON PNLOINMCCKH, EEDKAACNBBG KKHIDFKKFJE)
	{
		if((int)PNLOINMCCKH.AIHCEGFANAM_SceneSeries != KKHIDFKKFJE.AIHCEGFANAM_Serie)
		{
			CMCKNKKCNDK.excellentRate_SameSeriesAttr = 0;
			CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr = 0;
		}
		if(KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr != 4 && KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr != PNLOINMCCKH.JGJFIJOCPAG_SceneAttr)
		{
			CMCKNKKCNDK.excellentRate_SameMusicAttr = 0;
			CMCKNKKCNDK.centerLiveSkillRate_SameMusicAttr = 0;
		}
	}

	// // RVA: 0x10939D4 Offset: 0x10939D4 VA: 0x10939D4
	private static int IGDGGMIMLDN(int NKGHBKFMFCI, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NEJBNCHLMNJ, KLBKPANJCPL_Score POMOLHBFAPM, JLKEOGLJNOD HEDKFICAPIJ)
	{
		int IILKAJBHLMJ = 0;
		OKGLGHCBCJP_Database LKMHPJKIFDN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		Func<GCIJNCFDNON, FFHPBEPOMAK, int> f = (GCIJNCFDNON PNLOINMCCKH, FFHPBEPOMAK FDBOPFEOENF) =>
		{
			//0x175A624
			if (PNLOINMCCKH != null)
			{
				int skillId = PNLOINMCCKH.FILPDDHMKEJ(false, GMFMMDAKENC != null ? GMFMMDAKENC.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC != null ? GMFMMDAKENC.AIHCEGFANAM_Serie : 0);
				if(skillId > 0)
				{
					if(PNLOINMCCKH.DCLLIDMKNGO_IsDivaCompatible(FDBOPFEOENF.AHHJLDLAPAN_DivaId))
					{
						PPGHMBNIAEC skillInfo = LKMHPJKIFDN.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
						if(skillInfo.AANDPLGPDEI())
						{
							if (!skillInfo.HDPIEILADDH(GMFMMDAKENC.DLAEJOBELBH_MusicId))
								return 0;
						}
						if(skillInfo.HCGDJAFINMH())
						{
							if (!skillInfo.OEJNKFONOGJ(GMFMMDAKENC.FKDCCLPGKDK_JacketAttr))
								return 0;
						}
						for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
						{
							if(skillInfo.EGLDFPILJLG_SkillBuffEffect[i] == (int)SkillBuffEffect.Type.EffectValueUp &&
								NEJBNCHLMNJ != 0 && NEJBNCHLMNJ == skillInfo.DPGDCJFBFGK_TargetSkillType)
							{
								if(LKMHPJKIFDN.FOFADHAENKC_Skill.JBGPIPLAAIA(skillInfo.POMLAENHCHA_TargetSkillEffectId, (int)MCJEIDPDMLF))
								{
									IILKAJBHLMJ += NKGHBKFMFCI * skillInfo.NKGHBKFMFCI_BuffValueByIndexAndLevel[i, PNLOINMCCKH.AADFFCIDJCB_LiveSkillLevel - 1];
								}
							}
						}
					}
				}
			}
			return IILKAJBHLMJ;
		};
		for (int i = 0; i < HEDKFICAPIJ.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = DJLNOAMJECI.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					f(sceneInfo, divaInfo);
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON sceneInfo = DJLNOAMJECI.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						f(sceneInfo, divaInfo);
					}
				}
			}
		}
		return IILKAJBHLMJ;
	}

	// // RVA: 0x1093FD0 Offset: 0x1093FD0 VA: 0x1093FD0
	private static int CPPANAJNEDJ(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, KLBKPANJCPL_Score POMOLHBFAPM, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH)
	{
		int res = 0;
		if (MCJEIDPDMLF > SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
			return 0;
		if (((1 << ((int)MCJEIDPDMLF & 0xff)) & 0x180202) == 0)
			return 0;
		int v = 0;
		if(FPMFEKIPFPI >= SkillDuration.Type.ValkyrieModeAndNoteResult && FPMFEKIPFPI <= SkillDuration.Type.AwakenDivaModeAndNoteResult)
		{
			if(BAAFOOKFDLL == SkillTrigger.Type.AwakenDivaMode)
			{
				v = POMOLHBFAPM.JJBOEMOJPEC;
				if (!HGEKDNNJAAC)
					return 0;
			}
			else if(BAAFOOKFDLL == SkillTrigger.Type.DivaMode)
			{
				v = POMOLHBFAPM.JJBOEMOJPEC;
				OHLCKPIMMFH = OOOGNIPJMDE;
				if (!OHLCKPIMMFH)
					return 0;
			}
			else if(BAAFOOKFDLL == SkillTrigger.Type.ValkyrieMode)
			{
				v = POMOLHBFAPM.GEIDIHCKDNO;
				if (!OHLCKPIMMFH)
					return 0;
			}
			res = NKGHBKFMFCI * KHDDPKHPJID / 100 * v / POMOLHBFAPM.NLKEBAOBJCM_Cb;
		}
		else
		{
			if (FPMFEKIPFPI != SkillDuration.Type.Time)
				return 0;
			switch(BAAFOOKFDLL)
			{
				case SkillTrigger.Type.Timebomb:
					v = POMOLHBFAPM.MCMIPODICAN_length;
					if (LFGFBMJNBKN * 1000 - v != 0 && v <= LFGFBMJNBKN * 1000)
						return 0;
					res = ((KHDDPKHPJID * NKGHBKFMFCI) / 100) * (PHAGNOHBMCM * 1000 / v);
					break;
				case SkillTrigger.Type.Combo:
					v = POMOLHBFAPM.NLKEBAOBJCM_Cb;
					if (v < LFGFBMJNBKN)
						return 0;
					v = POMOLHBFAPM.MCMIPODICAN_length;
					res = ((KHDDPKHPJID * NKGHBKFMFCI) / 100) * (PHAGNOHBMCM * 1000 / v);
					break;
				case SkillTrigger.Type.EveryTime:
					v = POMOLHBFAPM.MCMIPODICAN_length;
					int b = LFGFBMJNBKN * 1000;
					if (b - v != 0 && v <= b)
						return 0;
					res = ((KHDDPKHPJID * NKGHBKFMFCI) / 100) * (PHAGNOHBMCM * 1000 / v) * v / b;
					break;
				case SkillTrigger.Type.EveryScore:
					break;
			}
		}
		return res;
	}

	// // RVA: 0x109435C Offset: 0x109435C VA: 0x109435C
	private static int MCKHJBNJFJH(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, KLBKPANJCPL_Score POMOLHBFAPM, bool HGEKDNNJAAC, bool OHLCKPIMMFH)
	{
		int skill_combo_bonus_value0 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("skill_combo_bonus_value0", 0);
		if (FPMFEKIPFPI != SkillDuration.Type.Time || MCJEIDPDMLF != SkillBuffEffect.Type.ComboBonus)
			return 0;
		if (BAAFOOKFDLL == SkillTrigger.Type.EveryTime)
			return 0;
		int cb = POMOLHBFAPM.NLKEBAOBJCM_Cb;
		int len = POMOLHBFAPM.MCMIPODICAN_length;
		int a = 0;
		bool b = false;
		if (BAAFOOKFDLL != SkillTrigger.Type.AwakenDivaMode && BAAFOOKFDLL != SkillTrigger.Type.None)
		{
			a = cb / 2;
		}
		else
		{
			if (BAAFOOKFDLL != SkillTrigger.Type.AwakenDivaMode)
			{
				HGEKDNNJAAC = true;
			}
			b = HGEKDNNJAAC;
			a = cb - POMOLHBFAPM.JJBOEMOJPEC;
		}
		int res = 0;
		if(b && skill_combo_bonus_value0 <= cb)
		{
			res = (PHAGNOHBMCM * 1000 / len) * (Mathf.Max(a / cb, 1) * NKGHBKFMFCI) / 100 * KHDDPKHPJID;
		}
		return res;
	}

	// // RVA: 0x1093E5C Offset: 0x1093E5C VA: 0x1093E5C
	private static int MEAHJKCBGFE(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, int JLDDHNFKGHL, KLBKPANJCPL_Score POMOLHBFAPM, bool KIFJKGDBDBH = false)
	{
		int res = 0;
		if (MCJEIDPDMLF < SkillBuffEffect.Type.Num && ((1 << ((int)MCJEIDPDMLF & 0xff)) & 0x180202) != 0 && BAAFOOKFDLL == SkillTrigger.Type.EveryScore)
		{
			int i = FLKGCONIFEE / LFGFBMJNBKN * 10000;
			if (KIFJKGDBDBH)
				i = 1;
			res = 0;
			int a = i;
			if (i > 0)
				a = JLDDHNFKGHL;
			if(a > 0)
			{
				a = -a;
				if (-a <= -i && a != i)
					a = -i;
				res = -(a * NKGHBKFMFCI / 100 * KHDDPKHPJID * PHAGNOHBMCM * 1000 / POMOLHBFAPM.MCMIPODICAN_length);
			}
		}
		return res;
	}

	// // RVA: 0x108EE08 Offset: 0x108EE08 VA: 0x108EE08
	private static bool MODGPFEPLIP(ref EDMIONMCICN HBODCMLFDOB, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, Difficulty.Type AKNELONELJK_Difficulty, bool GIKLNODJKFK_IsLine6, out bool HGEKDNNJAAC, out bool OHLCKPIMMFH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		bool res = false;
		HGEKDNNJAAC = false;
		OHLCKPIMMFH = false;
		int sup = 0;
		int fold = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				fold += divaInfo.JLJGCBOHJID_Status.fold;
				sup += divaInfo.JLJGCBOHJID_Status.support;
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					fold += sceneInfo.CMCKNKKCNDK_Status.fold;
					sup += sceneInfo.CMCKNKKCNDK_Status.support;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						fold += sceneInfo.CMCKNKKCNDK_Status.fold;
						sup += sceneInfo.CMCKNKKCNDK_Status.support;
					}
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH() != null)
		{
			fold += ALOBLKOHIKD_FriendData.KHGKPKDBMOH().CMCKNKKCNDK_Status.fold;
			sup += ALOBLKOHIKD_FriendData.KHGKPKDBMOH().CMCKNKKCNDK_Status.support;
		}
		HBODCMLFDOB.BEDINMCPENB(ref FLOHCPIIHEH);
		int subGoal;
		int goal;
		int max;
		if(GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			DJNPIGEFPMF g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO);
			subGoal = g.HLKHOFPAOMK_SubGoalByDiff[(int)AKNELONELJK_Difficulty];
			goal = g.HLLJIICKNIP_GoalByDiff[(int)AKNELONELJK_Difficulty];
			max = g.FENOHOEIJOE_MaxValueByDiff[(int)AKNELONELJK_Difficulty];
		}
		else
		{
			KEODKEGFDLD m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
			if(!GIKLNODJKFK_IsLine6)
			{
				subGoal = m.HLKHOFPAOMK_SubGoalFreeModeByDiff[(int)AKNELONELJK_Difficulty];
				goal = m.HLLJIICKNIP_GoalFreeModeByDiff[(int)AKNELONELJK_Difficulty];
				max = m.FENOHOEIJOE_MaxValueFreeModeByDiff[(int)AKNELONELJK_Difficulty];
			}
			else
			{
				subGoal = m.MAGILDGLOKD_SubGoalFreeModeL6ByDiff[(int)AKNELONELJK_Difficulty];
				goal = m.JEANDFEBLIG_GoalFreeModeL6ByDiff[(int)AKNELONELJK_Difficulty];
				max = m.KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff[(int)AKNELONELJK_Difficulty];
			}
		}
		int val = 0;
		for(int i = POMOLHBFAPM_Score.KIEHDJFCCNM; i > 0; i--)
		{
			val += Mathf.RoundToInt(
				BEFDPKNGHPO(fold + sup, val, max, 
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.CIFKMCKFMOA_FCoeff4 / 10000.0f, 
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.IHIONKFAAED_FCoeff1 / 100.0f,
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHPJIALEPEE_FCoeff2 / 100.0f,
					subGoal, max, POMOLHBFAPM_Score.KIEHDJFCCNM
				) * (fold + sup));
		}
		if (val < subGoal)
			res = false;
		else
		{
			OHLCKPIMMFH = true;
			res = PKLPIDIBHMN(DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, AKNELONELJK_Difficulty, GIKLNODJKFK_IsLine6, POMOLHBFAPM_Score.GEIDIHCKDNO, (sup + FLOHCPIIHEH.support) / IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.MPAMBMKFCKK_BCoeff2 + 1, out HGEKDNNJAAC, HEDKFICAPIJ_Team);
		}

		return res;
	}

	// // RVA: 0x10947B0 Offset: 0x10947B0 VA: 0x10947B0
	private static float BEFDPKNGHPO(float EGIGDODCJOG, int LKCCMBEOLLA, int DCBENCMNOGO, float GKHEOELGCAP, float IHEACEHPHKP, float JDIKNJEJCNN, int NNFBAIJKCCP, float GLDFMGNCOGM, int EDGIJNGLBDE)
	{
		float f;
		if(EGIGDODCJOG >= 0)
		{
			if(LKCCMBEOLLA < NNFBAIJKCCP)
			{
				f = Mathf.Max((DCBENCMNOGO - LKCCMBEOLLA) / DCBENCMNOGO, GKHEOELGCAP);
			}
			else
			{
				f = Mathf.Max((DCBENCMNOGO - LKCCMBEOLLA) / DCBENCMNOGO, GKHEOELGCAP) * IHEACEHPHKP;
			}
		}
		else
		{
			f = LKCCMBEOLLA / DCBENCMNOGO * JDIKNJEJCNN;
			if (LKCCMBEOLLA < NNFBAIJKCCP)
				f = LKCCMBEOLLA / DCBENCMNOGO;
		}
		return GLDFMGNCOGM / EDGIJNGLBDE * f;
	}

	// // RVA: 0x1094918 Offset: 0x1094918 VA: 0x1094918
	private static bool PKLPIDIBHMN(DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, Difficulty.Type AKNELONELJK, bool GIKLNODJKFK, int EDGIJNGLBDE, float PGEDGKMCFLB, out bool HGEKDNNJAAC, JLKEOGLJNOD HEDKFICAPIJ)
	{
		DJNPIGEFPMF smd = null;
		int goal;
		int subGoal;
		int enemyId;
		if (GMFMMDAKENC is LIEJFHMGNIA)
		{
			DJNPIGEFPMF g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC as LIEJFHMGNIA).KLCIIHKFPPO);
			subGoal = g.HLKHOFPAOMK_SubGoalByDiff[(int)AKNELONELJK];
			goal = g.HLLJIICKNIP_GoalByDiff[(int)AKNELONELJK];
			enemyId = g.LHICAKGHIGF[(int)AKNELONELJK];
			smd = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(g.KLCIIHKFPPO);
		}
		else
		{
			KEODKEGFDLD m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
			if (!GIKLNODJKFK)
			{
				subGoal = m.LJPKLMJPLAC[(int)AKNELONELJK];
				goal = m.MALHPBKPIDE[(int)AKNELONELJK];
				enemyId = m.LHICAKGHIGF[(int)AKNELONELJK];
			}
			else
			{
				subGoal = m.ILCJOOPIILK[(int)AKNELONELJK];
				goal = m.BGILEHEJHHA[(int)AKNELONELJK];
				enemyId = m.PJNFOCDANCE[(int)AKNELONELJK];
			}
		}
		AONMBIEIBCD.Clear();
		AONMBIEIBCD.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.IJDBNKCLGIC_BCoeff3);
		AONMBIEIBCD.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GLMKBFEHPLA_BCoeff4);
		AONMBIEIBCD.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GLMKBFEHPLA_BCoeff4);
		int v = EDGIJNGLBDE + 1 - RhythmGameEnemyStatus.AttackComboCount;
		FOMKBDKKODO.Clear();
		int b = 0;
		for (int i = 0; i < AONMBIEIBCD.Count; i++)
		{
			int a = v / AONMBIEIBCD.Count;
			b += a;
			if (i == 1)
			{
				b = v % AONMBIEIBCD.Count + b;
			}
			FOMKBDKKODO.Add(b);
		}
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[HEDKFICAPIJ.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId - 1];
		int dd = 0;
		int p = 0;
		for(int i = 0; i < v; i++)
		{
			dd += OEEDGPGEPFH(valk.OJHINEMKMOP(0) * PGEDGKMCFLB, valk.PAELLCKLEJP(0) * PGEDGKMCFLB, 
				IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.INONDJKKOKG(enemyId).ADMMEMNGKEN_Avo, i, i + RhythmGameEnemyStatus.AttackComboCount, 1, 1, v, out p);
		}
		HGEKDNNJAAC = goal <= dd;
		return subGoal <= dd;
	}

	// // RVA: 0x1095364 Offset: 0x1095364 VA: 0x1095364
	private static int OEEDGPGEPFH(float ALOGOPNMLJI, float EDGBEFKOGMN, float IFMEDLKMHIG, int LGGLNFIKCKF, int CKFNNECHOGG, float PBIFADDFADF, float KOMJMBBPMML, int EDGIJNGLBDE, out int GBMNIAOLBEB)
	{
		int i = 0;
		for (; i < FOMKBDKKODO.Count; i++)
		{
			if(LGGLNFIKCKF + 1 - RhythmGameEnemyStatus.AttackComboCount < FOMKBDKKODO[i])
				break;
		}
		return (int)(FDIIFOOLDGM(EDGBEFKOGMN, IFMEDLKMHIG, KOMJMBBPMML, out GBMNIAOLBEB) * 
				(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.FHHPNFAECCJ(CKFNNECHOGG) / 100.0f) * 
				(AONMBIEIBCD[i] / EDGIJNGLBDE) * ALOGOPNMLJI * PBIFADDFADF);
	}

	// // RVA: 0x10956D0 Offset: 0x10956D0 VA: 0x10956D0
	private static float FDIIFOOLDGM(float EDGBEFKOGMN, float IFMEDLKMHIG, float KOMJMBBPMML, out int GBMNIAOLBEB)
	{
		int a = (int)((EDGBEFKOGMN * 1.2f - IFMEDLKMHIG) * KOMJMBBPMML);
		GBMNIAOLBEB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.FHFLCJHEEPK(a);
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.IKIGFABDFMB(a) / 100.0f;
	}

	// // RVA: 0x1093648 Offset: 0x1093648 VA: 0x1093648
	private static int CKNDJNOFFGP(PPGHMBNIAEC KMHPOGKCHHK, int AOGDKBPNGCI, int GBMHFDKCFGB, FFHPBEPOMAK HIDAJBOHJKH)
	{
		int v = KMHPOGKCHHK.NKGHBKFMFCI_BuffValueByIndexAndLevel[AOGDKBPNGCI, GBMHFDKCFGB - 1];
		if (KMHPOGKCHHK.EGLDFPILJLG_SkillBuffEffect[(int)AOGDKBPNGCI] != (int)SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
		{
			if(KMHPOGKCHHK.EGLDFPILJLG_SkillBuffEffect[(int)AOGDKBPNGCI] == (int)SkillBuffEffect.Type.ScoreUpPercentage_FoldWave)
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(v).DOOGFEGEKLG;
			}
			return v;
		}
		JJOELIOGMKK j = new JJOELIOGMKK();
		j.KHEKNNFCAOI(HIDAJBOHJKH.AHHJLDLAPAN_DivaId);
		j.HCDGELDHFHB(false);
		EHGAHMIBPIB s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(v);
		return Mathf.Min(j.HEKJGCMNJAB / s.KCOHMHFBDKF[GBMHFDKCFGB - 1] * s.HLMMBNCIIAC[GBMHFDKCFGB - 1], s.DOOGFEGEKLG);
	}

	// // RVA: 0x109477C Offset: 0x109477C VA: 0x109477C
	// private static bool BBIBJKIKBPO(SkillBuffEffect.Type LFAFFMFOFEG) { }
}
