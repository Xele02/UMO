
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;

public static class CMMKCEPBIHI
{
    public enum NOJENDEDECD
    {
        HNGJDMNPMNP = 0,
        KBHGPMNGALJ = 1,
        AJIDOFDBIDL = 2,
        NLAGKLDCBAG = 3,
        GJDKJOHIEFF = 4,
        BMMPEPDFICC = 5,
        CPJOGHCLENG = 6,
        NKPLJNILBFP = 7,
        GGOOOIKELDH = 8,
        OPCNHIMPGCE = 9,
        AEFCOHJBLPO = 10,
    }

	private const int IMNILJDBFDL = 30;
	private const int NPMLACIOKJE = 1;
	private static StatusData GCECPDEOIIN = new StatusData(); // 0x0
	// private static Comparison<GCIJNCFDNON>[] MOGECDOLPPL = new Comparison<GCIJNCFDNON>[3] {
    //     (GCIJNCFDNON HKICMNAACDA, GCIJNCFDNON BNKHBCBJBKI) => {
    //         0x175A31C
    //     },
    //     (GCIJNCFDNON HKICMNAACDA, GCIJNCFDNON BNKHBCBJBKI) => {
    //         0x175A39C
    //     },
    //     (GCIJNCFDNON HKICMNAACDA, GCIJNCFDNON BNKHBCBJBKI) => {
    //         0x175A41C
    //     }
    // }; // 0x4
	// private static Func<StatusData, int>[] HDLKMMHKOKE = new Func<StatusData, int>[3] {
    //     (StatusData IBDJFHFIIHN) => {
    //         0x175A49C
    //     },
    //     (StatusData IBDJFHFIIHN) => {
    //         0x175A4C0
    //     },
    //     (StatusData IBDJFHFIIHN) => {
    //         0x175A4E4
    //     }
    // }; // 0x8
	// private static Action<StatusData, int>[] HOBOLJEFDFF = new Action<StatusData, int>[3] {
    //     (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
    //         0x175A508
    //     },
    //     (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
    //         0x175A54C
    //     },
    //     (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
    //         0x175A54C
    //     }
    // }; // 0xC
	private static int[] OOPMCKOCEFM = new int[10]; // 0x10
	private static float[] LKBGHCIKIOA = new float[5]; // 0x14
	private static int[] HCEPBDBHILM = new int[10] { 100, 100, 100, 90, 100, 100, 90, 90, 90, 90 }; // 0x18
	private static string[] DALGMKEOFLN = new string[8] {"score_gauge_e", "score_gauge_n", "score_gauge_h", "score_gauge_vh", 
        "score_gauge_ex", "score_gauge_h+", "score_gauge_vh+", "score_gauge_ex+"}; // 0x1C
	private static StatusData FLOHCPIIHEH = new StatusData(); // 0x20
	// private static AEKDNMPPOJN OMPNCHBNEPF = new AEKDNMPPOJN(); // 0x24
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
				BALBKJFMDFN.vocal += (int)(JLJGCBOHJID.vocal * NANNGLGOFKH);
				break;
		}
	}

	// // RVA: 0x1087F4C Offset: 0x1087F4C VA: 0x1087F4C
	public static bool OJNOJNEKBKH(int LNGOBGPDBAG, int GMPOGAFIAEF)
    {
        return GMPOGAFIAEF == 4 || GMPOGAFIAEF == LNGOBGPDBAG;
    }

	// // RVA: 0x10868E8 Offset: 0x10868E8 VA: 0x10868E8
	// private static void NJNBELLEGCN(ref CFHDKAFLNEP HBODCMLFDOB, JLKEOGLJNOD MLAFAACKKBG, DFKGGBMFFGB AHEFHIMGIBI, EEDKAACNBBG KKHIDFKKFJE, EAJCBFGKKFA PCEGKKLKFNO, EJKBKMBJMGL KDOLMBEAGCI) { }

	// // RVA: 0x1089E00 Offset: 0x1089E00 VA: 0x1089E00
	// public static void NJNBELLEGCN(ref CFHDKAFLNEP HBODCMLFDOB, int[,] EDAJDLJHBKP, List<List<GCIJNCFDNON>> OPIBAPEGCLA, DFKGGBMFFGB AHEFHIMGIBI, JLKEOGLJNOD MLAFAACKKBG, EEDKAACNBBG KKHIDFKKFJE, EAJCBFGKKFA PCEGKKLKFNO, EJKBKMBJMGL KDOLMBEAGCI) { }

	// // RVA: 0x108BAF0 Offset: 0x108BAF0 VA: 0x108BAF0
	// private static void MHPBLAEDJOC(ref StatusData BALBKJFMDFN, GCIJNCFDNON COIODGJDJEJ, EEDKAACNBBG KKHIDFKKFJE, int ENMAEBJGEKL, int CNLIAMIIJID, JLKEOGLJNOD MLAFAACKKBG) { }

	// // RVA: 0x1089374 Offset: 0x1089374 VA: 0x1089374
	public static int FPJIKEFIJOL(int NCNFMHDKAPN, JLKEOGLJNOD CDCKLJAJBDO)
	{

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
		int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN(score.ANAJIAENLNB_F_pt, PDLCNDBOMAN_IsLine6);
		int b = CBILJEAECKP(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, GMFMMDAKENC_MusicData, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, score.ANAJIAENLNB_F_pt, c, HJJNDDPGIML_Team);
		OOPMCKOCEFM[0] = b;
		OOPMCKOCEFM[4] = MHIKPDIJKJO(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, c, HJJNDDPGIML_Team);
		OOPMCKOCEFM[1] = CHCGGEPAAOE(DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, c, HJJNDDPGIML_Team);
		OOPMCKOCEFM[2] = DONJDICAMJB(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, c, HJJNDDPGIML_Team);
		EDMIONMCICN d = new EDMIONMCICN();
		OOPMCKOCEFM[5] = DBHEBCCLIJG(ref d, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref calcData, c, false, HJJNDDPGIML_Team);
		bool e = false;
		bool g = false;
		bool f = MODGPFEPLIP(ref d, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, out e, out g, HJJNDDPGIML_Team);
		OOPMCKOCEFM[6] = LKGBAIANMLE(b, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		OOPMCKOCEFM[7] = BPPIFIAGLBI(b, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
		OOPMCKOCEFM[3] = AFBHKBGLMHG * b / 1000;
		if (f)
			OOPMCKOCEFM[8] = CBIIKLGPILB(b, GMFMMDAKENC_MusicData, DJLNOAMJECI_Playerdata, AKNELONELJK_Difficulty, score, PDLCNDBOMAN_IsLine6, g ? 1 : 0, HJJNDDPGIML_Team);
		OOPMCKOCEFM[9] = OPKNHONFIOG(b, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		int total = 0;
		for (int i = 0; i < OOPMCKOCEFM.Length; i++)
		{
			total += OOPMCKOCEFM[i];
		}
		OOPMCKOCEFM[6] += NGCOIOANNPA(total, b, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
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
		for(int i = 0; i < 5; i++)
		{
			LKBGHCIKIOA[i] = a.KNIFCANOHOC_RankScore[i] * 1.0f / DNJCAKPKNDP[(int)AKNELONELJK_Difficulty];
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
	private static int CBILJEAECKP(DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, EEDKAACNBBG GMFMMDAKENC_MusicData, Difficulty.Type AKNELONELJK_Difficulty, bool GBNOALJPOBM_IsLine6, int BAKLKJLPLOJ_FPt, int DHIPGHBJLIL, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE();
		CFHDKAFLNEP data2 = new CFHDKAFLNEP();
		data2.OBKGEDCKHHE();
		int a = DBHEBCCLIJG(ref data, DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref data2, DHIPGHBJLIL, true, HEDKFICAPIJ_Team);
		int b = DBHEBCCLIJG(ref data, DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref data2, DHIPGHBJLIL, true, HEDKFICAPIJ_Team);
		int total = 0;
		int i = 0;
		for (i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
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
		int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN(BAKLKJLPLOJ_FPt, GBNOALJPOBM_IsLine6);
		return (a - b) + Mathf.RoundToInt(i * total / 1000.0f);
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
				total += LNMECJDKFDN.KOGBMDOONFA[i, j].KHDDPKHPJID;
			}
		}
		return (total * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108E93C Offset: 0x108E93C VA: 0x108E93C
	private static int DBHEBCCLIJG(ref EDMIONMCICN HBODCMLFDOB, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int DHIPGHBJLIL, bool CCPIGKONMMH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x108DEA8 Offset: 0x108DEA8 VA: 0x108DEA8
	private static int MHIKPDIJKJO(DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP HBODCMLFDOB, int DHIPGHBJLIL, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x1092FB8 Offset: 0x1092FB8 VA: 0x1092FB8
	// private static int FILPDDHMKEJ(GCIJNCFDNON LAPAEBEIAFK, EEDKAACNBBG GMFMMDAKENC, FFHPBEPOMAK JCFNFJJKPAM) { }

	// // RVA: 0x1093268 Offset: 0x1093268 VA: 0x1093268
	// private static int OPGMFCHDEDF(int KPIIIEGGPIB, GCIJNCFDNON COIODGJDJEJ, int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, KLBKPANJCPL POMOLHBFAPM, bool KIFJKGDBDBH, JLKEOGLJNOD HEDKFICAPIJ, FFHPBEPOMAK NENDFGDMJDN) { }

	// // RVA: 0x108F96C Offset: 0x108F96C VA: 0x108F96C
	private static int LKGBAIANMLE(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x1092720 Offset: 0x1092720 VA: 0x1092720
	private static int NGCOIOANNPA(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x10908A8 Offset: 0x10908A8 VA: 0x10908A8
	private static int BPPIFIAGLBI(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x1090E60 Offset: 0x1090E60 VA: 0x1090E60
	private static int CBIIKLGPILB(int KHDDPKHPJID, EEDKAACNBBG GMFMMDAKENC_MusicData, DFKGGBMFFGB DJLNOAMJECI_PlayerData, Difficulty.Type AKNELONELJK_Difficulty, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool GBNOALJPOBM_IsLine6, int BAKLKJLPLOJ, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x10915F0 Offset: 0x10915F0 VA: 0x10915F0
	private static int OPKNHONFIOG(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x1094624 Offset: 0x1094624 VA: 0x1094624
	// private static void HHOKCLBEOHI(LimitOverStatusData CMCKNKKCNDK, GCIJNCFDNON PNLOINMCCKH, EEDKAACNBBG KKHIDFKKFJE) { }

	// // RVA: 0x10939D4 Offset: 0x10939D4 VA: 0x10939D4
	// private static int IGDGGMIMLDN(int NKGHBKFMFCI, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NEJBNCHLMNJ, KLBKPANJCPL POMOLHBFAPM, JLKEOGLJNOD HEDKFICAPIJ) { }

	// // RVA: 0x1093FD0 Offset: 0x1093FD0 VA: 0x1093FD0
	// private static int CPPANAJNEDJ(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, KLBKPANJCPL POMOLHBFAPM, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH) { }

	// // RVA: 0x109435C Offset: 0x109435C VA: 0x109435C
	// private static int MCKHJBNJFJH(int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, KLBKPANJCPL POMOLHBFAPM, bool HGEKDNNJAAC, bool OHLCKPIMMFH) { }

	// // RVA: 0x1093E5C Offset: 0x1093E5C VA: 0x1093E5C
	// private static int MEAHJKCBGFE(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, int JLDDHNFKGHL, KLBKPANJCPL POMOLHBFAPM, bool KIFJKGDBDBH = False) { }

	// // RVA: 0x108EE08 Offset: 0x108EE08 VA: 0x108EE08
	private static bool MODGPFEPLIP(ref EDMIONMCICN HBODCMLFDOB, DFKGGBMFFGB DJLNOAMJECI_PlayerData, EAJCBFGKKFA ALOBLKOHIKD_FriendData, EEDKAACNBBG GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, Difficulty.Type AKNELONELJK_Difficulty, bool GIKLNODJKFK_IsLine6, out bool HGEKDNNJAAC, out bool OHLCKPIMMFH, JLKEOGLJNOD HEDKFICAPIJ_Team)
	{
	}

	// // RVA: 0x10947B0 Offset: 0x10947B0 VA: 0x10947B0
	// private static float BEFDPKNGHPO(float EGIGDODCJOG, int LKCCMBEOLLA, int DCBENCMNOGO, float GKHEOELGCAP, float IHEACEHPHKP, float JDIKNJEJCNN, int NNFBAIJKCCP, float GLDFMGNCOGM, int EDGIJNGLBDE) { }

	// // RVA: 0x1094918 Offset: 0x1094918 VA: 0x1094918
	// private static bool PKLPIDIBHMN(DFKGGBMFFGB DJLNOAMJECI, EEDKAACNBBG GMFMMDAKENC, Difficulty.Type AKNELONELJK, bool GIKLNODJKFK, int EDGIJNGLBDE, float PGEDGKMCFLB, out bool HGEKDNNJAAC, JLKEOGLJNOD HEDKFICAPIJ) { }

	// // RVA: 0x1095364 Offset: 0x1095364 VA: 0x1095364
	// private static int OEEDGPGEPFH(float ALOGOPNMLJI, float EDGBEFKOGMN, float IFMEDLKMHIG, int LGGLNFIKCKF, int CKFNNECHOGG, float PBIFADDFADF, float KOMJMBBPMML, int EDGIJNGLBDE, out int GBMNIAOLBEB) { }

	// // RVA: 0x10956D0 Offset: 0x10956D0 VA: 0x10956D0
	// private static float FDIIFOOLDGM(float EDGBEFKOGMN, float IFMEDLKMHIG, float KOMJMBBPMML, out int GBMNIAOLBEB) { }

	// // RVA: 0x1093648 Offset: 0x1093648 VA: 0x1093648
	// private static int CKNDJNOFFGP(PPGHMBNIAEC KMHPOGKCHHK, int AOGDKBPNGCI, int GBMHFDKCFGB, FFHPBEPOMAK HIDAJBOHJKH) { }

	// // RVA: 0x109477C Offset: 0x109477C VA: 0x109477C
	// private static bool BBIBJKIKBPO(SkillBuffEffect.Type LFAFFMFOFEG) { }
}
