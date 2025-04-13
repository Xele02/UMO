using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;
using XeApp.Game;
using UnityEngine;

[System.Obsolete("Use GCIJNCFDNON_SceneInfo", true)]
public class GCIJNCFDNON { }
public class GCIJNCFDNON_SceneInfo
{
	public enum HINAICIJJJC
	{
		HJNNKCMLGFL_0 = 0,
		BPMNCMICDAF = 1,
		JIKCABGFIEG_2 = 2,
		LAHFPKEJLCA_3 = 3,
		LBODGCPCGHA_4 = 4,
	}

	public enum DLAMEBMGKDO
	{
		DJECFFENCND = 0,
		DFAPCDGNNPN = 1,
		OONCLCEAICE = 2,
	}

	public int BCCHOBPJJKE_SceneId; // 0x8
	public byte EKLIPGELKCL_SceneRarity; // 0xC
	public byte JKGFBFPIMGA_Rarity; // 0xD
	public bool JOKJBMJBLBB_Single; // 0xE
	public sbyte JGJFIJOCPAG_SceneAttr; // 0xF
	public SeriesAttr.Type AIHCEGFANAM_SceneSeries; // 0x10
	public SeriesLogoId.Type EMIKBGHIOMN_SerieLogo; // 0x14
	public int HCHBCMGPMNC_CenterSkillId; // 0x18
	public int HGONFBDIBPM_ActiveSkillId; // 0x1C
	public int PLDALOJIFBE_LiveSkillId; // 0x20
	public string OPFGFINHFCE_SceneName; // 0x24
	private string PMKLGDOEFNM_Detail; // 0x28
	public string PFHJFIHGCKP_CenterSkillName1; // 0x2C
	public string EFELCLMJEOL_CenterSkillName2; // 0x30
	public string ILCLGGPHHJO_ActiveSkillName; // 0x34
	public string NDPPEMCHKHA_LiveSkillName1; // 0x38
	public string LNLECENGMKK_LiveSkillName2; // 0x3C
	public string MCKOOLDJEPG_CenterSkillDesc1; // 0x40
	public string GFLEJDKGJDN_CenterSkillDesc2; // 0x44
	public string FKFEJGKILJO_ActiveSkillDesc; // 0x48
	public string AGJBLOKLMED_LiveSkillDesc1; // 0x4C
	public string ODICCEOHOPH_LiveSkillDesc2; // 0x50
	public int DDEDANKHHPN_SkillLevel; // 0x54
	public int PNHJPCPFNFI_ActiveSkillLevel; // 0x58
	public int AADFFCIDJCB_LiveSkillLevel; // 0x5C
	public int DHEFMEGKKDN_CenterSkillRank; // 0x60
	public int FFDCGHDNDFJ_CenterSkillRank2; // 0x64
	public int BEKGEAMJGEN_ActiveSkillRank; // 0x68
	public int OAHMFMJIENM_LiveSkillRank; // 0x6C
	public int ELNJADBILOM_LiveSkillRank2; // 0x70
	public int BJJNCCGPBGN; // 0x74
	public int FAIKFGHEGEM; // 0x78
	public int KELFCMEOPPM_EpisodeId; // 0x7C
	public bool MCCIFLKCNKO_Feed; // 0x80
	public int IGPMJPPAILL_Note; // 0x84
	public int KMFADKEKPOM_Nx; // 0x88
	public int FPDIMAEOMPL_Nx1; // 0x8C
	public byte[] KBOLNIBLIND_Mb; // 0x90
	public byte[] ODKMKEHJOCK_Sb; // 0x94
	public int JPIPENJGGDD_NumBoard; // 0x9C
	public int IELENGDJPHF; // 0xA0
	public int MJBODMOLOBC_Luck; // 0xA4
	public int CIEOBFIIPLD_SceneLevel; // 0xA8
	public int MKHFCGPJPFI_LimitOverCount; // 0xAC
	public int MCOMAOELHOG_IsKira; // 0xB0
	public bool CADENLBDAEB_New; // 0xB4
	public long NPHOIEOPIJO; // 0xB8
	public DMPDJFAGCPN DKFCPBEOBHB_Layout; // 0xC0
	public DMPDJFAGCPN JCNIAPAJAOB; // 0xC4
	public DMPDJFAGCPN IKBBCHGLLKB; // 0xC8
	public List<short> GDHGEECAJGI; // 0xCC
	public int AOLIJKMIJJE_DivaCompatible; // 0xD0
	private int BPJEOPHAJPP; // 0xD4
	private int BENDGHHBHFN; // 0xD8
	public int IJIKIPDKCPP; // 0xDC
	public int ILABPFOMEAG_Va; // 0xE0

	// public string KLMPFGOCBHC { get; }
	public StatusData CMCKNKKCNDK_Status { get; private set; } = new StatusData(); // 0x98 CLCJNFNMNBH CNKGOPKANGF CHJGGLFGALP
	// public bool OGHIOHAACIB { get; }
	// public bool FJODMPGPDDD { get; }
	// public int NCAFLPPKLPK { get; set; }

	// // RVA: 0x16AB3A4 Offset: 0x16AB3A4 VA: 0x16AB3A4
	public string BGJNIABLBDB_GetSceneDetail()
	{
		if(PMKLGDOEFNM_Detail == null)
		{
			PMKLGDOEFNM_Detail = MessageManager.Instance.GetMessage("master", "sn_dsc_" + BCCHOBPJJKE_SceneId.ToString("D4"));
		}
		return PMKLGDOEFNM_Detail;
	}

	// // RVA: 0x16AB494 Offset: 0x16AB494 VA: 0x16AB494
	public bool MBMFJILMOBP_IsKira()
	{
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GACNKPOMOFA_IsDrawKira >= 0 && MCOMAOELHOG_IsKira == 1;
	}

	// // RVA: 0x16AB598 Offset: 0x16AB598 VA: 0x16AB598
	public void LEHDLBJJBNC_SetNotNew()
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1].LHMOAJAIJCO_New = false;
	}

	// // RVA: 0x16AB6C8 Offset: 0x16AB6C8 VA: 0x16AB6C8
	public bool CGKAEMGLHNK_IsUnlocked(bool checkCheat = false)
	{
		/*if(checkCheat && RuntimeSettings.CurrentSettings.ForceCardsUnlock)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
			return k.PPEGAKEIEGM_En == 2;
		}*/
		return NPHOIEOPIJO != 0;
	}

	// // RVA: 0x16AB6D8 Offset: 0x16AB6D8 VA: 0x16AB6D8
	// public bool KMJLJBOLEMC() { }

	// // RVA: 0x16AB6EC Offset: 0x16AB6EC VA: 0x16AB6EC
	public bool JHNNCPCBFDK()
	{
		if ((JKGFBFPIMGA_Rarity & 254) != 4)
			return false;
		return JPIPENJGGDD_NumBoard > 0;
	}

	// // RVA: 0x16AB718 Offset: 0x16AB718 VA: 0x16AB718
	public bool JFDLBEOGGID()
	{
		if((JKGFBFPIMGA_Rarity & 254) == 4 && JPIPENJGGDD_NumBoard > 0)
		{
			if(KELFCMEOPPM_EpisodeId == 0)
			{
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game != null)
					return JPIPENJGGDD_NumBoard < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(JKGFBFPIMGA_Rarity, MCCIFLKCNKO_Feed);
				return false;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x16AB830 Offset: 0x16AB830 VA: 0x16AB830
	public int CGIELKDLHGE_GetEvolveId()
	{
		if (JPIPENJGGDD_NumBoard <= 0 && IJIKIPDKCPP <= 1 && !JOKJBMJBLBB_Single)
			return 1;
		return 2;
	}

	// // RVA: 0x16AB85C Offset: 0x16AB85C VA: 0x16AB85C
	// private void DAIHKOLKKNC(int NANNGLGOFKH) { }

	// // RVA: 0x16AB860 Offset: 0x16AB860 VA: 0x16AB860
	public bool DCLLIDMKNGO_IsDivaCompatible(int AHHJLDLAPAN)
	{
		return (AOLIJKMIJJE_DivaCompatible & (1 << (AHHJLDLAPAN - 1))) != 0;
	}

	// // RVA: 0x16AB880 Offset: 0x16AB880 VA: 0x16AB880
	public int EMPEHJLBIKC(JLKEOGLJNOD_TeamInfo MLAFAACKKBG)
	{
		int r = 0;
		foreach(var d in MLAFAACKKBG.BCJEAJPLGMB_MainDivas)
		{
			if(d != null)
			{
				r |= (1 << (d.AHHJLDLAPAN_DivaId - 1));
			}
		}
		int res = 0;
		for(r = r & AOLIJKMIJJE_DivaCompatible; r > 0; r &= (r - 1))
		{
			res++;
		}
		return res;
	}

	// // RVA: 0x16ABA20 Offset: 0x16ABA20 VA: 0x16ABA20
	private JNKEEAOKNCI_Skill PJNDCOJNILE_GetSkillDb()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill;
		}
		return null;
	}

	// // RVA: 0x16ABAD4 Offset: 0x16ABAD4 VA: 0x16ABAD4
	private HBDCPGLAPHH LGONDBKGPMH(JNKEEAOKNCI_Skill NDFIEMPPMLF, int JBFLEDKDFCO)
	{
		if(NDFIEMPPMLF.COLCPGFABLP_CenterSkills != null)
		{
			if(JBFLEDKDFCO > 0 && JBFLEDKDFCO <= NDFIEMPPMLF.COLCPGFABLP_CenterSkills.Count)
			{
				return NDFIEMPPMLF.COLCPGFABLP_CenterSkills[JBFLEDKDFCO - 1];
			}
		}
		return null;
	}

	// // RVA: 0x16ABBF8 Offset: 0x16ABBF8 VA: 0x16ABBF8
	private KFCIIMBBNCD KDDDDMMMBHE(JNKEEAOKNCI_Skill NDFIEMPPMLF, int MJMPANIBFED)
	{
		if(NDFIEMPPMLF.PEPLECGHBFA_SceneEffectInfo != null)
		{
			if (MJMPANIBFED > 0 && MJMPANIBFED <= NDFIEMPPMLF.PEPLECGHBFA_SceneEffectInfo.Count)
			{
				return NDFIEMPPMLF.PEPLECGHBFA_SceneEffectInfo[MJMPANIBFED - 1];
			}
		}
		return null;
	}

	// // RVA: 0x16ABD1C Offset: 0x16ABD1C VA: 0x16ABD1C
	public SkillSwitchPatternCondition.Type ABIOBCMPEHM_SkillSwitchPatternCondition()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && HCHBCMGPMNC_CenterSkillId > 0)
		{
			return (SkillSwitchPatternCondition.Type)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BNAPNENIMBO[HCHBCMGPMNC_CenterSkillId - 1].CHOFDPDFPDC_SwitchPatternCondition;
		}
		return SkillSwitchPatternCondition.Type.None;
	}

	// // RVA: 0x16ABE4C Offset: 0x16ABE4C VA: 0x16ABE4C
	public bool IFBJBPEBAFH_HasCenterSkillCondSerie(EONOEHOKBEB_Music KKHIDFKKFJE, bool HBPAFCLFCAL = false)
	{
		JNKEEAOKNCI_Skill s = PJNDCOJNILE_GetSkillDb();
		if (s != null)
		{
			int a = MEOOLHNNMHL_GetCenterSkillId(HBPAFCLFCAL, KKHIDFKKFJE == null ? 0 : KKHIDFKKFJE.FKDCCLPGKDK_Ma, KKHIDFKKFJE == null ? 0 : KKHIDFKKFJE.AIHCEGFANAM_SerieAttr);
			HBDCPGLAPHH h = LGONDBKGPMH(s, a);
			if (h != null)
			{
				KFCIIMBBNCD k = KDDDDMMMBHE(s, h.HEKHODDJHAO_P1);
				if (k != null && k.OAFPGJLCNFM_CenterSkillCondition <= (int)CenterSkillCondition.Type.SeriesAttr_Scn && k.OAFPGJLCNFM_CenterSkillCondition >= (int)CenterSkillCondition.Type.SeriesAttr_01)
					return true;
				k = KDDDDMMMBHE(s, h.AKGNPLBDKLN_P2);
				if (k != null && k.OAFPGJLCNFM_CenterSkillCondition <= (int)CenterSkillCondition.Type.SeriesAttr_Scn && k.OAFPGJLCNFM_CenterSkillCondition >= (int)CenterSkillCondition.Type.SeriesAttr_01)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x16AC0D4 Offset: 0x16AC0D4 VA: 0x16AC0D4
	public SeriesAttr.Type COONMFMEDFJ_GetSerieAttr(EONOEHOKBEB_Music EPMMNEFADAP, bool HBPAFCLFCAL = false)
	{
		JNKEEAOKNCI_Skill s = PJNDCOJNILE_GetSkillDb();
		if(s != null)
		{
			int a = MEOOLHNNMHL_GetCenterSkillId(HBPAFCLFCAL, EPMMNEFADAP == null ? 0 : EPMMNEFADAP.FKDCCLPGKDK_Ma, EPMMNEFADAP == null ? 0 : EPMMNEFADAP.AIHCEGFANAM_SerieAttr);
			HBDCPGLAPHH h = LGONDBKGPMH(s, a);
			if (h == null)
				return SeriesAttr.Type.None;
			KFCIIMBBNCD k = KDDDDMMMBHE(s, h.HEKHODDJHAO_P1);
			if (k == null)
				return SeriesAttr.Type.None;
			switch(k.OAFPGJLCNFM_CenterSkillCondition - 6)
			{
				case 0:
					return SeriesAttr.Type.Delta;
				case 1:
					return SeriesAttr.Type.Frontia;
				case 2:
					return SeriesAttr.Type.Seven;
				case 3:
					return SeriesAttr.Type.First;
				case 4:
					return SeriesAttr.Type.Plus;
				case 5:
					if (AIHCEGFANAM_SceneSeries != SeriesAttr.Type.None)
						return AIHCEGFANAM_SceneSeries;
					break;
			}
			k = KDDDDMMMBHE(s, h.AKGNPLBDKLN_P2);
			if (k == null)
				return SeriesAttr.Type.None;
			switch (k.OAFPGJLCNFM_CenterSkillCondition - 6)
			{
				case 0:
					return SeriesAttr.Type.Delta;
				case 1:
					return SeriesAttr.Type.Frontia;
				case 2:
					return SeriesAttr.Type.Seven;
				case 3:
					return SeriesAttr.Type.First;
				case 4:
					return SeriesAttr.Type.Plus;
				case 5:
					return AIHCEGFANAM_SceneSeries;
			}
		}
		return SeriesAttr.Type.None;
	}

	// // RVA: 0x16AC240 Offset: 0x16AC240 VA: 0x16AC240
	public bool JDAEAJNJBGI_IsMatchCenterSkillSerie(int DLAEJOBELBH)
	{
		EONOEHOKBEB_Music music = null;
		if (DLAEJOBELBH > 0)
		{
			music = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH);
		}
		if(music != null && IFBJBPEBAFH_HasCenterSkillCondSerie(music, false))
		{
			if(SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type) music.EMIKBGHIOMN_SerieLogoId) > 0)
			{
				return SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type)music.EMIKBGHIOMN_SerieLogoId) == COONMFMEDFJ_GetSerieAttr(music, false);
			}
		}
		return true;
	}

	// // RVA: 0x16AC3D0 Offset: 0x16AC3D0 VA: 0x16AC3D0
	// public bool JDAEAJNJBGI(int DLAEJOBELBH, bool HBPAFCLFCAL) { }

	// // RVA: 0x16AC564 Offset: 0x16AC564 VA: 0x16AC564
	public bool PKPCDAAHJGP_HasLiveSkillCondMusic()
	{
		if(FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) != 0)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) - 1].CEFHDLLAPDH_MusicIdCond > 0;
		}
		return false;
	}

	// // RVA: 0x16AC870 Offset: 0x16AC870 VA: 0x16AC870
	public bool ADDCCPKEFOC_IsMatchLiveSkillMusic(int DLAEJOBELBH)
	{
		if (FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) != 0)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[FILPDDHMKEJ_GetLiveSkillId(false, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[DLAEJOBELBH - 1].FKDCCLPGKDK_Ma, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[DLAEJOBELBH - 1].AIHCEGFANAM_SerieAttr) - 1].CEFHDLLAPDH_MusicIdCond == DLAEJOBELBH;
		}
		return false;
	}

	// // RVA: 0x16ACB2C Offset: 0x16ACB2C VA: 0x16ACB2C
	public bool FCGHOLNFDDF_HasCenterSkillCondMusicAttr(EONOEHOKBEB_Music EPMMNEFADAP, bool HBPAFCLFCAL = false)
	{
		bool res = false;
		int a = MEOOLHNNMHL_GetCenterSkillId(HBPAFCLFCAL, EPMMNEFADAP == null ? 0 : EPMMNEFADAP.FKDCCLPGKDK_Ma, EPMMNEFADAP == null ? 0 : EPMMNEFADAP.AIHCEGFANAM_SerieAttr);
		if(a != 0)
		{
			JNKEEAOKNCI_Skill j = PJNDCOJNILE_GetSkillDb();
			if(j != null)
			{
				HBDCPGLAPHH h = LGONDBKGPMH(PJNDCOJNILE_GetSkillDb(), a);
				if(h != null)
				{
					KFCIIMBBNCD k = KDDDDMMMBHE(j, h.HEKHODDJHAO_P1);
					if (k != null && k.OAFPGJLCNFM_CenterSkillCondition <= (int)CenterSkillCondition.Type.MusicAttr_05 && k.OAFPGJLCNFM_CenterSkillCondition >= (int)CenterSkillCondition.Type.MusicAttr_01)
						return true;
					k = KDDDDMMMBHE(j, h.AKGNPLBDKLN_P2);
					if (k != null)
						return k.OAFPGJLCNFM_CenterSkillCondition < (int)CenterSkillCondition.Type.MusicAttr_05 && k.OAFPGJLCNFM_CenterSkillCondition >= (int)CenterSkillCondition.Type.MusicAttr_01;
				}
			}
		}
		return res;
	}

	// // RVA: 0x16ACC2C Offset: 0x16ACC2C VA: 0x16ACC2C
	public GameAttribute.Type NNOLHKHJPFJ_GetCenterSkillMusicAttr(EONOEHOKBEB_Music EPMMNEFADAP, bool HBPAFCLFCAL = false)
	{
		int a = MEOOLHNNMHL_GetCenterSkillId(HBPAFCLFCAL, EPMMNEFADAP == null ? 0 : EPMMNEFADAP.FKDCCLPGKDK_Ma, EPMMNEFADAP == null ? 0 : EPMMNEFADAP.AIHCEGFANAM_SerieAttr);
		int b = FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
		if(a != 0 || b != 0)
		{
			JNKEEAOKNCI_Skill j = PJNDCOJNILE_GetSkillDb();
			if (j != null)
			{
				HBDCPGLAPHH h = LGONDBKGPMH(PJNDCOJNILE_GetSkillDb(), a);
				if (h != null)
				{
					KFCIIMBBNCD k = KDDDDMMMBHE(j, h.HEKHODDJHAO_P1);
					if (k != null && k.OAFPGJLCNFM_CenterSkillCondition - 1 < 4 && k.OAFPGJLCNFM_CenterSkillCondition - 1 >= 0)
						return (GameAttribute.Type)k.OAFPGJLCNFM_CenterSkillCondition;
					k = KDDDDMMMBHE(j, h.AKGNPLBDKLN_P2);
					if (k != null && k.OAFPGJLCNFM_CenterSkillCondition - 1 < 4 && k.OAFPGJLCNFM_CenterSkillCondition - 1 >= 0)
						return (GameAttribute.Type)k.OAFPGJLCNFM_CenterSkillCondition;
				}
			}
		}
		return GameAttribute.Type.None;
	}

	// // RVA: 0x16ACD30 Offset: 0x16ACD30 VA: 0x16ACD30
	public bool KAFAAPEBCPD_IsMatchCenterSkillMusicAttr(int DLAEJOBELBH)
	{
		if(DLAEJOBELBH > 0)
		{
			EONOEHOKBEB_Music music = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH);
			if (FCGHOLNFDDF_HasCenterSkillCondMusicAttr(music, false))
			{
				GameAttribute.Type a = 0;
				if (music != null)
					a = (GameAttribute.Type)music.FKDCCLPGKDK_Ma;
				if (a == NNOLHKHJPFJ_GetCenterSkillMusicAttr(music, false))
					return true;
				return false;
			}
		}
		return true;
	}

	// // RVA: 0x16ACE7C Offset: 0x16ACE7C VA: 0x16ACE7C
	public bool KAFAAPEBCPD(int DLAEJOBELBH, bool HBPAFCLFCAL = false)
	{
		if(DLAEJOBELBH > 0)
		{
			EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH);
			if (FCGHOLNFDDF_HasCenterSkillCondMusicAttr(m, HBPAFCLFCAL))
			{
				return (int)NNOLHKHJPFJ_GetCenterSkillMusicAttr(m, false) == (m != null ? m.FKDCCLPGKDK_Ma : 0);
			}
		}
		return true;
	}

	// // RVA: 0x16ACFCC Offset: 0x16ACFCC VA: 0x16ACFCC
	public bool GOEFBDNFNAA_HasLiveSkillCondAttr()
	{
		if(FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) != 0 || FILPDDHMKEJ_GetLiveSkillId(true, 0, 0) != 0)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) - 1].NFIBKOACELP_Attr > 0 ||
				IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[FILPDDHMKEJ_GetLiveSkillId(true, 0, 0) - 1].NFIBKOACELP_Attr > 0;
		}
		return false;
	}

	// // RVA: 0x16AD20C Offset: 0x16AD20C VA: 0x16AD20C
	public GameAttribute.Type EOIGNOLJGDG_GetLiveSkillMusicAttr(int DLAEJOBELBH_musicId, bool GAMJCMKKHBM)
	{
		GameAttribute.Type res = GameAttribute.Type.None;
		if (FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) != 0 || FILPDDHMKEJ_GetLiveSkillId(true, 0, 0) != 0)
		{
			int b = 0, c = 0;
			if(DLAEJOBELBH_musicId > 0)
			{
				b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[DLAEJOBELBH_musicId - 1].FKDCCLPGKDK_Ma;
				c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[DLAEJOBELBH_musicId - 1].AIHCEGFANAM_SerieAttr;
			}
			int a = FILPDDHMKEJ_GetLiveSkillId(GAMJCMKKHBM, b, c);
			PPGHMBNIAEC p = new PPGHMBNIAEC();
			if(a > 0)
			{
				if(a <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills.Count)
				{
					p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[a - 1];
				}
			}
			res = (GameAttribute.Type)p.NFIBKOACELP_Attr;
		}
		return res;
	}

	// // RVA: 0x16AD568 Offset: 0x16AD568 VA: 0x16AD568
	public bool JEDMBJEICBB_IsLiveSkillMatchAttr(int DLAEJOBELBH, bool GAMJCMKKHBM)
	{
		if(DLAEJOBELBH > 0 && GOEFBDNFNAA_HasLiveSkillCondAttr())
		{
			EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH);
			return (int)EOIGNOLJGDG_GetLiveSkillMusicAttr(DLAEJOBELBH, GAMJCMKKHBM) == (m != null ? m.FKDCCLPGKDK_Ma : 0);
		}
		return true;
	}

	// // RVA: 0x16AD724 Offset: 0x16AD724 VA: 0x16AD724
	public void KHEKNNFCAOI(int PPFNGGCBJKC_Id_, byte[] KBOLNIBLIND_Mb_, byte[] ODKMKEHJOCK_Sb_, int JPIPENJGGDD_Mlt_ = 0, int IELENGDJPHF_Ulk_ = 0, int MJBODMOLOBC_Luck_ = 0, bool CADENLBDAEB_New_ = false, long NPHOIEOPIJO_Date_ = 0, int BLHGJPIFKCL_Leaf_ = 0)
	{
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData server = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		MLIBEPGADJH_Scene.KKLDOOJBJMN s = db.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[PPFNGGCBJKC_Id_ - 1];
		MessageBank bank = MessageManager.Instance.GetBank("master");
		BCCHOBPJJKE_SceneId = s.BCCHOBPJJKE_Id;
		KELFCMEOPPM_EpisodeId = s.KELFCMEOPPM_Ep;
		MCCIFLKCNKO_Feed = s.MCCIFLKCNKO_Feed;
		JOKJBMJBLBB_Single = s.FBJDHLGODPP_Sngl;
		JKGFBFPIMGA_Rarity = (byte)s.EKLIPGELKCL_Rarity;
		EKLIPGELKCL_SceneRarity = (byte)((JPIPENJGGDD_Mlt_ > 0 || JOKJBMJBLBB_Single) ? JKGFBFPIMGA_Rarity + 1 : JKGFBFPIMGA_Rarity);
		AIHCEGFANAM_SceneSeries = s.AIHCEGFANAM_Serie;
		EMIKBGHIOMN_SerieLogo = s.EMIKBGHIOMN_SerieLogo;
		JGJFIJOCPAG_SceneAttr = s.FKDCCLPGKDK_Ma;
		if (JPIPENJGGDD_Mlt_ < 1 || !JOKJBMJBLBB_Single)
			HCHBCMGPMNC_CenterSkillId = s.EMAGAIKNHDN_CS;
		else
			HCHBCMGPMNC_CenterSkillId = s.AEIBPIEIBFO_CS2 < 1 ? s.EMAGAIKNHDN_CS : s.AEIBPIEIBFO_CS2;
		if (JPIPENJGGDD_Mlt_ < 1 || !JOKJBMJBLBB_Single)
			HGONFBDIBPM_ActiveSkillId = s.PBEPKDEEBBK_AS;
		else
			HGONFBDIBPM_ActiveSkillId = s.ECKJJCGPOPN_AS2 < 1 ? s.PBEPKDEEBBK_AS : s.ECKJJCGPOPN_AS2;
		if (JPIPENJGGDD_Mlt_ < 1 || !JOKJBMJBLBB_Single)
			PLDALOJIFBE_LiveSkillId = s.KPIIIEGGPIB_LS;
		else
			PLDALOJIFBE_LiveSkillId = s.PJKJFIOKBGJ_LS2 < 1 ? s.KPIIIEGGPIB_LS : s.PJKJFIOKBGJ_LS2;
		AOLIJKMIJJE_DivaCompatible = s.AOLIJKMIJJE_Dv;
		OPFGFINHFCE_SceneName = bank.GetMessageByLabel("sn_"+BCCHOBPJJKE_SceneId.ToString("D4"));
		this.NPHOIEOPIJO = NPHOIEOPIJO_Date_;
		PMKLGDOEFNM_Detail = null;
		this.KBOLNIBLIND_Mb = KBOLNIBLIND_Mb_;
		this.ODKMKEHJOCK_Sb = ODKMKEHJOCK_Sb_;
		this.MJBODMOLOBC_Luck = MJBODMOLOBC_Luck_;
		this.JPIPENJGGDD_NumBoard = JPIPENJGGDD_Mlt_ == 0 ? (JOKJBMJBLBB_Single ? 1 : 0) : JPIPENJGGDD_Mlt_;
		this.CADENLBDAEB_New = CADENLBDAEB_New_;
		this.IELENGDJPHF = IELENGDJPHF_Ulk_ == 0 ? (JOKJBMJBLBB_Single ? 1 : 0) : IELENGDJPHF_Ulk_;
		MKHFCGPJPFI_LimitOverCount = BLHGJPIFKCL_Leaf_;
		MCOMAOELHOG_IsKira = 0;
		JNNHIDMNBFG(OPFGFINHFCE_SceneName, BLHGJPIFKCL_Leaf_);
		CIEOBFIIPLD_SceneLevel = KBOLNIBLIND_Mb_ == null ? 1 : CEDHHAGBIBA.OGPFNHOKONH_GetNumBitActive(KBOLNIBLIND_Mb_) + 1;
		PFHJFIHGCKP_CenterSkillName1 = bank.GetMessageByLabel("c_nm_" + MEOOLHNNMHL_GetCenterSkillId(false, 0, 0).ToString("D4"));
		EFELCLMJEOL_CenterSkillName2 = bank.GetMessageByLabel("c_nm_" + MEOOLHNNMHL_GetCenterSkillId(true, 0, 0).ToString("D4"));
		ILCLGGPHHJO_ActiveSkillName = bank.GetMessageByLabel("a_nm_" + HGONFBDIBPM_ActiveSkillId.ToString("D4"));
		NDPPEMCHKHA_LiveSkillName1 = bank.GetMessageByLabel("l_nm_" + FILPDDHMKEJ_GetLiveSkillId(false, 0, 0).ToString("D4"));
		LNLECENGMKK_LiveSkillName2 = bank.GetMessageByLabel("l_nm_" + FILPDDHMKEJ_GetLiveSkillId(true, 0, 0).ToString("D4"));
		MCKOOLDJEPG_CenterSkillDesc1 = bank.GetMessageByLabel("c_dsc_" + MEOOLHNNMHL_GetCenterSkillId(false, 0, 0).ToString("D4"));
		GFLEJDKGJDN_CenterSkillDesc2 = bank.GetMessageByLabel("c_dsc_" + MEOOLHNNMHL_GetCenterSkillId(true, 0, 0).ToString("D4"));
		FKFEJGKILJO_ActiveSkillDesc = bank.GetMessageByLabel("a_dsc_" + HGONFBDIBPM_ActiveSkillId.ToString("D4"));
		AGJBLOKLMED_LiveSkillDesc1 = bank.GetMessageByLabel("l_dsc_" + FILPDDHMKEJ_GetLiveSkillId(false, 0, 0).ToString("D4"));
		ODICCEOHOPH_LiveSkillDesc2 = bank.GetMessageByLabel("l_dsc_" + FILPDDHMKEJ_GetLiveSkillId(true, 0, 0).ToString("D4"));
		ILABPFOMEAG_Va = s.ILABPFOMEAG_Va;
		DKFCPBEOBHB_Layout = db.JEMMMJEJLNL_Board.FDCDIHIIJJM_GetLayout(s.BJNBBEMBMIK_BoardId);
		JCNIAPAJAOB = db.JEMMMJEJLNL_Board.GPKFGCFHDHH(s.AOPBAOJIOGO_Sb, false);
		IKBBCHGLLKB = db.JEMMMJEJLNL_Board.GPKFGCFHDHH(s.AOPBAOJIOGO_Sb, ILABPFOMEAG_Va > 0);
		HCDGELDHFHB();
		IGPMJPPAILL_Note = s.FIHNJFKBKBD_NoteType;
		KMFADKEKPOM_Nx = s.FLGDCCFAGEL_NotesExpected;
		FPDIMAEOMPL_Nx1 = s.GPAOEGPMBOJ_NoteExpected1;
	}

	// // RVA: 0x16AE31C Offset: 0x16AE31C VA: 0x16AE31C
	public void JNNHIDMNBFG(string IDMLDEJMMED_Name = "", int DMNIMMGGJJJ_Leaf = -1)
	{
		if(IDMLDEJMMED_Name == "")
		{
			IDMLDEJMMED_Name = MessageManager.Instance.GetBank("master").GetMessageByLabel("sn_" + BCCHOBPJJKE_SceneId.ToString("D4"));
		}
		OPFGFINHFCE_SceneName = IDMLDEJMMED_Name;
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			OPFGFINHFCE_SceneName = "["+BCCHOBPJJKE_SceneId+"] "+OPFGFINHFCE_SceneName;
		if (DMNIMMGGJJJ_Leaf < 0)
		{
			DMNIMMGGJJJ_Leaf = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1].DMNIMMGGJJJ_Leaf;
		}
		MKHFCGPJPFI_LimitOverCount = DMNIMMGGJJJ_Leaf;
		MCOMAOELHOG_IsKira = ELKHCOEMNOJ_IsKira();
	}

	// // RVA: 0x16AF944 Offset: 0x16AF944 VA: 0x16AF944
	public int ELKHCOEMNOJ_IsKira()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.ELKHCOEMNOJ(BCCHOBPJJKE_SceneId, MKHFCGPJPFI_LimitOverCount, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver);
	}

	// // RVA: 0x16AE544 Offset: 0x16AE544 VA: 0x16AE544
	public void HCDGELDHFHB()
	{
		CMCKNKKCNDK_Status.Copy(JPCAIAAOOLN(BCCHOBPJJKE_SceneId, KBOLNIBLIND_Mb, ODKMKEHJOCK_Sb, JPIPENJGGDD_NumBoard, IJIKIPDKCPP));
		MLIBEPGADJH_Scene.KKLDOOJBJMN s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		DDEDANKHHPN_SkillLevel = 1;
		PNHJPCPFNFI_ActiveSkillLevel = 1;
		AADFFCIDJCB_LiveSkillLevel = 1;
		ELNJADBILOM_LiveSkillRank2 = 0;
		BJJNCCGPBGN = 0;
		DHEFMEGKKDN_CenterSkillRank = 0;
		FFDCGHDNDFJ_CenterSkillRank2 = 0;
		BEKGEAMJGEN_ActiveSkillRank = 0;
		OAHMFMJIENM_LiveSkillRank = 0;
		int a = MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
		int b = MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
		if (JPIPENJGGDD_NumBoard < 1 && !JOKJBMJBLBB_Single)
		{
			EKLIPGELKCL_SceneRarity = JKGFBFPIMGA_Rarity;
		}
		else
		{
			EKLIPGELKCL_SceneRarity = (byte)(JKGFBFPIMGA_Rarity + 1);
		}
		if(KBOLNIBLIND_Mb == null)
		{
			if(IJIKIPDKCPP == 0)
			{
				CIEOBFIIPLD_SceneLevel = 1;
				if(a != 0)
				{
					DDEDANKHHPN_SkillLevel = s.MGKDKGOACDB_GetSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, null);
					DHEFMEGKKDN_CenterSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[a - 1].JGNHOGKKPDM;
				}
				if(b != 0)
				{
					DDEDANKHHPN_SkillLevel = s.MGKDKGOACDB_GetSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
					FFDCGHDNDFJ_CenterSkillRank2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[b - 1].JGNHOGKKPDM;
				}
				if(HGONFBDIBPM_ActiveSkillId != 0)
				{
					PNHJPCPFNFI_ActiveSkillLevel = s.CMPJFHEFIND_GetActiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
					BEKGEAMJGEN_ActiveSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[HGONFBDIBPM_ActiveSkillId - 1].JGNHOGKKPDM;
				}
				int c = FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
				if(c != 0)
				{
					AADFFCIDJCB_LiveSkillLevel = s.BBGLLMIFPMA_GetLiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
					OAHMFMJIENM_LiveSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[c - 1].JGNHOGKKPDM;
					BJJNCCGPBGN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[c - 1].AOPELJFAMCL_LiveSkillType;
				}
				int d = FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
				if(d != 0)
				{
					AADFFCIDJCB_LiveSkillLevel = s.BBGLLMIFPMA_GetLiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
					ELNJADBILOM_LiveSkillRank2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[d - 1].JGNHOGKKPDM;
					BJJNCCGPBGN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[d - 1].AOPELJFAMCL_LiveSkillType;
				}
			}
			else
			{
				CIEOBFIIPLD_SceneLevel = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(JKGFBFPIMGA_Rarity, IJIKIPDKCPP == 2, MCCIFLKCNKO_Feed) + 1;
				byte[] g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.DNMKPAKOJFA(JKGFBFPIMGA_Rarity, IJIKIPDKCPP == 2, MCCIFLKCNKO_Feed);
				if (a != 0)
				{
					DDEDANKHHPN_SkillLevel = s.MGKDKGOACDB_GetSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, g);
					DHEFMEGKKDN_CenterSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[a - 1].JGNHOGKKPDM;
				}
				if(b != 0)
				{
					DDEDANKHHPN_SkillLevel = s.MGKDKGOACDB_GetSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, g);
					FFDCGHDNDFJ_CenterSkillRank2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[b - 1].JGNHOGKKPDM;
				}
				if(HGONFBDIBPM_ActiveSkillId != 0)
				{
					PNHJPCPFNFI_ActiveSkillLevel = s.CMPJFHEFIND_GetActiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, g);
					BEKGEAMJGEN_ActiveSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[HGONFBDIBPM_ActiveSkillId - 1].JGNHOGKKPDM;
				}
				int c = FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
				if (c != 0)
				{
					AADFFCIDJCB_LiveSkillLevel = s.BBGLLMIFPMA_GetLiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, g);
					OAHMFMJIENM_LiveSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[c - 1].JGNHOGKKPDM;
					BJJNCCGPBGN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[c - 1].AOPELJFAMCL_LiveSkillType;
				}
				int d = FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
				if (d != 0)
				{
					AADFFCIDJCB_LiveSkillLevel = s.BBGLLMIFPMA_GetLiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, g);
					ELNJADBILOM_LiveSkillRank2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[d - 1].JGNHOGKKPDM;
					BJJNCCGPBGN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[d - 1].AOPELJFAMCL_LiveSkillType;
				}
			}
		}
		else
		{
			CIEOBFIIPLD_SceneLevel = CEDHHAGBIBA.OGPFNHOKONH_GetNumBitActive(KBOLNIBLIND_Mb) + 1;
			if (a != 0)
			{
				DDEDANKHHPN_SkillLevel = s.MGKDKGOACDB_GetSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
				DHEFMEGKKDN_CenterSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[a - 1].JGNHOGKKPDM;
			}
			if (b != 0)
			{
				DDEDANKHHPN_SkillLevel = s.MGKDKGOACDB_GetSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
				FFDCGHDNDFJ_CenterSkillRank2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[b - 1].JGNHOGKKPDM;
			}
			if (HGONFBDIBPM_ActiveSkillId != 0)
			{
				PNHJPCPFNFI_ActiveSkillLevel = s.CMPJFHEFIND_GetActiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
				BEKGEAMJGEN_ActiveSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[HGONFBDIBPM_ActiveSkillId - 1].JGNHOGKKPDM;
			}
			int c = FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
			if (c != 0)
			{
				AADFFCIDJCB_LiveSkillLevel = s.BBGLLMIFPMA_GetLiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
				OAHMFMJIENM_LiveSkillRank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[c - 1].JGNHOGKKPDM;
				BJJNCCGPBGN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[c - 1].AOPELJFAMCL_LiveSkillType;
			}
			int d = FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
			if (d != 0)
			{
				AADFFCIDJCB_LiveSkillLevel = s.BBGLLMIFPMA_GetLiveSkillLevel(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
				ELNJADBILOM_LiveSkillRank2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[d - 1].JGNHOGKKPDM;
				BJJNCCGPBGN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[d - 1].AOPELJFAMCL_LiveSkillType;
			}
		}
		int f = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(s.EKLIPGELKCL_Rarity, s.MCCIFLKCNKO_Feed);
		if (IJIKIPDKCPP == 2)
		{
			MJBODMOLOBC_Luck = s.PKNGPIFNIGN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, f, f);
		}
		else
		{
			MJBODMOLOBC_Luck = s.AGOEDLNOHND(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, ODKMKEHJOCK_Sb, JPIPENJGGDD_NumBoard, f);
		}
	}

	// // RVA: 0x16B0658 Offset: 0x16B0658 VA: 0x16B0658
	// public static List<GCIJNCFDNON> CFJMOBKGFNE(int NMOFFGFGFKA) { }

	// // RVA: 0x16AFA64 Offset: 0x16AFA64 VA: 0x16AFA64
	public static StatusData JPCAIAAOOLN(int BCCHOBPJJKE, byte[] KBOLNIBLIND, byte[] ODKMKEHJOCK, int JPIPENJGGDD, int DPCIPDAECEA = 0)
	{
		StatusData res = new StatusData();
		if(BCCHOBPJJKE == 0)
			return res;
		MLIBEPGADJH_Scene.KKLDOOJBJMN d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1];
		if(KBOLNIBLIND == null)
		{
			if(DPCIPDAECEA == 1)
			{
				res.life = d.CGMFEOFCKPA_GetLife(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.DNMKPAKOJFA(d.EKLIPGELKCL_Rarity, false, d.MCCIFLKCNKO_Feed));
				res.soul = d.ONBGNBDIGPF_GetSoul(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.DNMKPAKOJFA(d.EKLIPGELKCL_Rarity, false, d.MCCIFLKCNKO_Feed));
				res.vocal = d.DPDGKOBDBJF_GetVocal(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.DNMKPAKOJFA(d.EKLIPGELKCL_Rarity, false, d.MCCIFLKCNKO_Feed));
				res.charm = d.JEDMOOILJOJ_GetCharm(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.DNMKPAKOJFA(d.EKLIPGELKCL_Rarity, false, d.MCCIFLKCNKO_Feed));
				res.sceneBonus = 0;
				res.support = d.HCFOMFDPGEC_Support;
				res.fold = d.ONDFNOOICLE_Fold;
				res.spNoteExpected[d.FIHNJFKBKBD_NoteType] = d.FLGDCCFAGEL_NotesExpected;
			}
			else if(DPCIPDAECEA == 2)
			{
				res.life = d.JABFJHJFJEO_Life1;
				res.soul = d.EFMJLKIFNJK_Soul1;
				res.vocal = d.EGNCKFNALIA_Vocal1;
				res.charm = d.OIOABIDEJPG_Charm1;
				res.sceneBonus = 0;
				res.support = d.DCICNKHCBJK_Support1;
				res.fold = d.EANBFFCPKOO_Fold1;
				res.spNoteExpected[d.FIHNJFKBKBD_NoteType] = d.GPAOEGPMBOJ_NoteExpected1;
				if (d.ILABPFOMEAG_Va < 1)
					return res;
				KOGHKIODHPA_Board.ADPMJDMFEIK b = new KOGHKIODHPA_Board.ADPMJDMFEIK();
				b.KHEKNNFCAOI_Init(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, d.AOPBAOJIOGO_Sb, 0, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(d.EKLIPGELKCL_Rarity, d.MCCIFLKCNKO_Feed), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(d.EKLIPGELKCL_Rarity, d.MCCIFLKCNKO_Feed), d.ILABPFOMEAG_Va, d.FKDCCLPGKDK_Ma);
				b.OMKKILODDIC_ApplyBoardValues(null, 0);
				res.soul += b.PFGFNIHOOHE_Soul;
				res.vocal += b.HGNGPAFOFNG_Vocal;
				res.charm += b.PLNJOOPGGIG_Charm;
			}
			else
			{
				res.life = d.HFIDCMNFBJG_Life;
				res.soul = d.PFJCOCPKABN_Soul;
				res.vocal = d.JFJDLEMNKFE_Vocal;
				res.charm = d.GDOLPGBLMEA_Charm;
				res.sceneBonus = 0;
				res.support = d.HCFOMFDPGEC_Support;
				res.fold = d.ONDFNOOICLE_Fold;
				res.spNoteExpected[d.FIHNJFKBKBD_NoteType] = d.FLGDCCFAGEL_NotesExpected;
			}
		}
		else
		{
			res.life = d.CGMFEOFCKPA_GetLife(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND);
			res.soul = d.ONBGNBDIGPF_GetSoul(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND);
			res.vocal = d.DPDGKOBDBJF_GetVocal(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND);
			res.charm = d.JEDMOOILJOJ_GetCharm(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND);
			res.sceneBonus = 0;
			res.support = d.HCFOMFDPGEC_Support;
			res.fold = d.ONDFNOOICLE_Fold;
			res.spNoteExpected[d.FIHNJFKBKBD_NoteType] = d.FLGDCCFAGEL_NotesExpected;
			if (ODKMKEHJOCK == null)
				return res;
			if (d.ILABPFOMEAG_Va < 1)
				return res;
			KOGHKIODHPA_Board.ADPMJDMFEIK b = new KOGHKIODHPA_Board.ADPMJDMFEIK();
			b.KHEKNNFCAOI_Init(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, d.AOPBAOJIOGO_Sb, 0, JPIPENJGGDD, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(d.EKLIPGELKCL_Rarity, d.MCCIFLKCNKO_Feed), d.ILABPFOMEAG_Va, d.FKDCCLPGKDK_Ma);
			b.OMKKILODDIC_ApplyBoardValues(ODKMKEHJOCK, 0);
			res.soul += b.PFGFNIHOOHE_Soul;
			res.vocal += b.HGNGPAFOFNG_Vocal;
			res.charm += b.PLNJOOPGGIG_Charm;
		}
		return res;
	}

	// // RVA: 0x16B0B80 Offset: 0x16B0B80 VA: 0x16B0B80
	public AFIFDLOAKGI LDGCIDPEMPG(int OIPCCBHIKIA)
	{
		if(DKFCPBEOBHB_Layout != null)
		{
			if(OIPCCBHIKIA < DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels.Count)
			{
				NLNDLEEJOFD n = DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[OIPCCBHIKIA];
				AFIFDLOAKGI a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.DDGNLCJGFJF(n.JBGEEPFKIGG);
				if(a != null)
				{
					if (a.INDDJNMPONH_StatType != 0)
						return a;
				}
			}
		}
		return null;
	}

	// // RVA: 0x16B0D2C Offset: 0x16B0D2C VA: 0x16B0D2C
	public AFIFDLOAKGI CDDHNNLPOLG(int OIPCCBHIKIA, int ILABPFOMEAG, int JGJFIJOCPAG)
	{
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbscene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbscene.EKLIPGELKCL_Rarity, dbscene.MCCIFLKCNKO_Feed);
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PBINAHNEFIK(dbscene.AOPBAOJIOGO_Sb, OIPCCBHIKIA, JPIPENJGGDD_NumBoard, a, ILABPFOMEAG, JGJFIJOCPAG);
	}

	// // RVA: 0x16B0F68 Offset: 0x16B0F68 VA: 0x16B0F68
	// public short OHOBGKJEPFM(int OIPCCBHIKIA) { }

	// // RVA: 0x16B0FE8 Offset: 0x16B0FE8 VA: 0x16B0FE8
	public HINAICIJJJC FAPMGGOMCOE(int OIPCCBHIKIA)
	{
		int a = 7;
		if(KBOLNIBLIND_Mb != null)
		{
			if((OIPCCBHIKIA >> 3) < KBOLNIBLIND_Mb.Length)
			{
				a = 0;
				if (((1 << (OIPCCBHIKIA & 7)) & KBOLNIBLIND_Mb[OIPCCBHIKIA >> 3]) == 0)
					a = -1;
			}
		}
		MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		AFIFDLOAKGI b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.BHMFCIIGKCB(scene.BJNBBEMBMIK_BoardId, OIPCCBHIKIA);
		if(b != null && b.INDDJNMPONH_StatType != 0)
		{
			if((a & 7) == 7)
			{
				return HINAICIJJJC.BPMNCMICDAF/*1*/;
			}
			return HINAICIJJJC.JIKCABGFIEG_2/*2*/;
		}
		return HINAICIJJJC.HJNNKCMLGFL_0/*0*/;
	}

	// // RVA: 0x16B11F0 Offset: 0x16B11F0 VA: 0x16B11F0
	public HINAICIJJJC OIEHPHINMIO(int OIPCCBHIKIA)
	{
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbscene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbscene.EKLIPGELKCL_Rarity, dbscene.MCCIFLKCNKO_Feed);
		AFIFDLOAKGI b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PBINAHNEFIK(dbscene.AOPBAOJIOGO_Sb, OIPCCBHIKIA, JPIPENJGGDD_NumBoard, a, dbscene.ILABPFOMEAG_Va, dbscene.FKDCCLPGKDK_Ma);
		if(b != null)
		{
			if(b.INDDJNMPONH_StatType != 0)
			{
				if(b.INDDJNMPONH_StatType != 20)
				{
					if(ODKMKEHJOCK_Sb != null)
					{
						if ((ODKMKEHJOCK_Sb[OIPCCBHIKIA >> 3] & (1 << (OIPCCBHIKIA & 7))) != 0)
							return HINAICIJJJC.JIKCABGFIEG_2/*2*/;
					}
					return HINAICIJJJC.BPMNCMICDAF/*1*/;
				}
				return HINAICIJJJC.LAHFPKEJLCA_3/*3*/;
			}
		}
		return 0;
	}

	// // RVA: 0x16B1524 Offset: 0x16B1524 VA: 0x16B1524
	public void EFLDHMMGALP(int OIPCCBHIKIA, HINAICIJJJC LHMDABPNDDH)
	{
		if(FAPMGGOMCOE(OIPCCBHIKIA) != HINAICIJJJC.HJNNKCMLGFL_0 && KBOLNIBLIND_Mb != null)
		{
			if (KBOLNIBLIND_Mb.Length <= (OIPCCBHIKIA >> 3))
				return;
			if(LHMDABPNDDH == HINAICIJJJC.JIKCABGFIEG_2)
			{
				KBOLNIBLIND_Mb[OIPCCBHIKIA >> 3] |= (byte)(1 << (OIPCCBHIKIA & 7));
			}
			else
			{
				KBOLNIBLIND_Mb[OIPCCBHIKIA >> 3] &= (byte)~(1 << (OIPCCBHIKIA & 7));
			}
		}
	}

	// // RVA: 0x16B159C Offset: 0x16B159C VA: 0x16B159C
	public void GIAPABMCNOC(int OIPCCBHIKIA, HINAICIJJJC LHMDABPNDDH)
	{
		if ((OIEHPHINMIO(OIPCCBHIKIA) <= HINAICIJJJC.LBODGCPCGHA_4 && ((1 << (int)OIEHPHINMIO(OIPCCBHIKIA)) & 0x19U) != 0)
			|| ODKMKEHJOCK_Sb == null)
			return;
		if (ODKMKEHJOCK_Sb.Length <= OIPCCBHIKIA >> 3)
			return;
		if (LHMDABPNDDH == HINAICIJJJC.JIKCABGFIEG_2)
		{
			ODKMKEHJOCK_Sb[OIPCCBHIKIA >> 3] |= (byte)(1 << (OIPCCBHIKIA & 7));
		}
		else
		{
			ODKMKEHJOCK_Sb[OIPCCBHIKIA >> 3] &= (byte)~(1 << (OIPCCBHIKIA & 7));
		}
	}

	// // RVA: 0x16B162C Offset: 0x16B162C VA: 0x16B162C
	public bool OEIFKIPOHME(int OIPCCBHIKIA, int HMFFHLPNMPH)
	{
		if (OIEHPHINMIO(OIPCCBHIKIA) != HINAICIJJJC.LAHFPKEJLCA_3)
			return false;
		MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1];
		return scene2.LMLDPHIAOPH(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(scene.EKLIPGELKCL_Rarity, MCCIFLKCNKO_Feed), HMFFHLPNMPH);
	}

	// // RVA: 0x16B18FC Offset: 0x16B18FC VA: 0x16B18FC
	public int KPCLNEADGEM(int OIPCCBHIKIA)
	{
		HINAICIJJJC a = OIEHPHINMIO(OIPCCBHIKIA);
		if (a < HINAICIJJJC.LAHFPKEJLCA_3 || a > HINAICIJJJC.LBODGCPCGHA_4)
			return 0;
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1];
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		int b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed);
		int res = scene.CDOBCKMHAOK_Inf;
		res = (JPIPENJGGDD_NumBoard - b) - res;
		TodoLogger.LogError(TodoLogger.ToCheck, "Check test");
		if (((res >> 0x1f) & 3) == 3)
			return 0;
		return res;
	}

	// // RVA: 0x16B1C44 Offset: 0x16B1C44 VA: 0x16B1C44
	public int MCDPPBBLDKA(int OIPCCBHIKIA)
	{
		if (OIEHPHINMIO(OIPCCBHIKIA) < HINAICIJJJC.LAHFPKEJLCA_3/*3*/ || OIEHPHINMIO(OIPCCBHIKIA) > HINAICIJJJC.LBODGCPCGHA_4/*4*/)
			return 0;
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1].CDOBCKMHAOK_Inf;
	}

	// // RVA: 0x16ABF40 Offset: 0x16ABF40 VA: 0x16ABF40
	public int MEOOLHNNMHL_GetCenterSkillId(bool GAMJCMKKHBM, int DEIHLMHACCH = 0, int LMLNKHMPOIG = 0)
	{
		if (HCHBCMGPMNC_CenterSkillId < 1)
			return 0;
		BMMNKCJOHOM a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BNAPNENIMBO[HCHBCMGPMNC_CenterSkillId - 1];
		bool b = false;
		if (a.CHOFDPDFPDC_SwitchPatternCondition == 2)
			b = (int)AIHCEGFANAM_SceneSeries == LMLNKHMPOIG;
		else
		{
			if(a.CHOFDPDFPDC_SwitchPatternCondition == 1)
			{
				b = JGJFIJOCPAG_SceneAttr == DEIHLMHACCH;
			}
		}
		if(b || GAMJCMKKHBM)
		{
			if (a.KGBMHHFLGEE == 0)
				return a.PNCCGBBHLLP;
			return a.KGBMHHFLGEE;
		}
		else
		{
			return a.PNCCGBBHLLP;
		}
	}

	// // RVA: 0x16B1D98 Offset: 0x16B1D98 VA: 0x16B1D98
	public string IHLINMFMCDN_GetCenterSkillDesc(bool GAMJCMKKHBM = false)
	{
		return IHLINMFMCDN_GetCenterSkillDesc(DDEDANKHHPN_SkillLevel, GAMJCMKKHBM ? GFLEJDKGJDN_CenterSkillDesc2 : MCKOOLDJEPG_CenterSkillDesc1, GAMJCMKKHBM);
	}

	// // RVA: 0x16B1F78 Offset: 0x16B1F78 VA: 0x16B1F78
	public string IHLINMFMCDN_GetCenterSkillDesc(int CNLIAMIIJID, bool GAMJCMKKHBM = false)
	{
		return IHLINMFMCDN_GetCenterSkillDesc(CNLIAMIIJID, GAMJCMKKHBM ? GFLEJDKGJDN_CenterSkillDesc2 : MCKOOLDJEPG_CenterSkillDesc1, GAMJCMKKHBM);
	}

	// // RVA: 0x16B1DEC Offset: 0x16B1DEC VA: 0x16B1DEC
	public string IHLINMFMCDN_GetCenterSkillDesc(int CNLIAMIIJID_Level, string HCAHCFGPJIF_Desc, bool GAMJCMKKHBM = false)
	{
		if (MEOOLHNNMHL_GetCenterSkillId(GAMJCMKKHBM, 0, 0) == 0)
			return HCAHCFGPJIF_Desc;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[MEOOLHNNMHL_GetCenterSkillId(GAMJCMKKHBM, 0, 0) - 1].KMFMGLENCJH_FormatDesc(HCAHCFGPJIF_Desc, CNLIAMIIJID_Level);
	}

	// // RVA: 0x16B1FCC Offset: 0x16B1FCC VA: 0x16B1FCC
	public string PCMEMHPDABG_GetActiveSkillDesc()
	{
		return PCMEMHPDABG_GetActiveSkillDesc(PNHJPCPFNFI_ActiveSkillLevel, FKFEJGKILJO_ActiveSkillDesc);
	}

	// // RVA: 0x16B2130 Offset: 0x16B2130 VA: 0x16B2130
	public string PCMEMHPDABG_GetActiveSkillDesc(int CNLIAMIIJID)
	{
		return PCMEMHPDABG_GetActiveSkillDesc(CNLIAMIIJID, FKFEJGKILJO_ActiveSkillDesc);
	}

	// // RVA: 0x16B1FD8 Offset: 0x16B1FD8 VA: 0x16B1FD8
	public string PCMEMHPDABG_GetActiveSkillDesc(int CNLIAMIIJID, string HCAHCFGPJIF)
	{
		if (HGONFBDIBPM_ActiveSkillId == 0)
			return HCAHCFGPJIF;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[HGONFBDIBPM_ActiveSkillId - 1].KMFMGLENCJH_FormatDesc(HCAHCFGPJIF, CNLIAMIIJID);
	}

	// // RVA: 0x16B2138 Offset: 0x16B2138 VA: 0x16B2138
	public string KDGACEJPGFG_GetLiveSkillDesc(bool GAMJCMKKHBM = false)
	{
		return KDGACEJPGFG_GetLiveSkillDesc(AADFFCIDJCB_LiveSkillLevel, GAMJCMKKHBM);
	}

	// // RVA: 0x16B2318 Offset: 0x16B2318 VA: 0x16B2318
	public string KDGACEJPGFG_GetLiveSkillDesc(int CNLIAMIIJID, bool GAMJCMKKHBM = false)
	{
		return KDGACEJPGFG_GetLiveSkillDesc(CNLIAMIIJID, GAMJCMKKHBM ? ODICCEOHOPH_LiveSkillDesc2 : AGJBLOKLMED_LiveSkillDesc1, GAMJCMKKHBM);
	}

	// // RVA: 0x16B218C Offset: 0x16B218C VA: 0x16B218C
	public string KDGACEJPGFG_GetLiveSkillDesc(int CNLIAMIIJID, string HCAHCFGPJIF, bool GAMJCMKKHBM = false)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[FILPDDHMKEJ_GetLiveSkillId(GAMJCMKKHBM, 0, 0) - 1].KMFMGLENCJH_FormatDesc(HCAHCFGPJIF, CNLIAMIIJID);
	}

	// // RVA: 0x16AC6DC Offset: 0x16AC6DC VA: 0x16AC6DC
	public int FILPDDHMKEJ_GetLiveSkillId(bool GAMJCMKKHBM, int DEIHLMHACCH = 0, int LMLNKHMPOIG = 0)
	{
		if (PLDALOJIFBE_LiveSkillId < 1)
			return 0;
		EDPDCLMMBPL a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.KGKICLDOOKG[PLDALOJIFBE_LiveSkillId - 1];
		bool b = false;
		if(a.CHOFDPDFPDC_SwitchPatternCondition == 2)
		{
			b = (int)AIHCEGFANAM_SceneSeries == LMLNKHMPOIG;
		}
		else
		{
			if (a.CHOFDPDFPDC_SwitchPatternCondition == 1)
				b = JGJFIJOCPAG_SceneAttr == DEIHLMHACCH;
		}
		if(b || GAMJCMKKHBM)
		{
			if (a.KGBMHHFLGEE == 0)
				return a.PNCCGBBHLLP;
			return a.KGBMHHFLGEE;
		}
		else
		{
			return a.PNCCGBBHLLP;
		}
	}

	// // RVA: 0x16B236C Offset: 0x16B236C VA: 0x16B236C
	public SkillSwitchPatternCondition.Type GPLOOJCLNBL_GetLiveSkillSwitchPatternCond()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && 
			PLDALOJIFBE_LiveSkillId > 0)
		{
			return (SkillSwitchPatternCondition.Type)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.KGKICLDOOKG[PLDALOJIFBE_LiveSkillId - 1].CHOFDPDFPDC_SwitchPatternCondition;
		}
		return SkillSwitchPatternCondition.Type.None;
	}

	// // RVA: 0x16B249C Offset: 0x16B249C VA: 0x16B249C
	public bool BLPHPMBFIEI_LiveSkillHasSwitchPatternCond()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && PLDALOJIFBE_LiveSkillId > 0)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.KGKICLDOOKG[PLDALOJIFBE_LiveSkillId - 1].CHOFDPDFPDC_SwitchPatternCondition != 0;
		}
		return false;
	}

	// // RVA: 0x16B25D4 Offset: 0x16B25D4 VA: 0x16B25D4
	public int CGJCEHGFHMA()
	{
		MLIBEPGADJH_Scene.KKLDOOJBJMN k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
		return k.NGGBHLCKJGO(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb, ODKMKEHJOCK_Sb, JPIPENJGGDD_NumBoard, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(k.EKLIPGELKCL_Rarity, k.MCCIFLKCNKO_Feed), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1].CDOBCKMHAOK_Inf);
	}

	// // RVA: 0x16B28E0 Offset: 0x16B28E0 VA: 0x16B28E0
	public int FGMPFHOEPEL_GetNumUnlockedStory()
	{
		if (JKGFBFPIMGA_Rarity < 6)
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1].JGKOJEOLMIL_GetNumUnlockedStory(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, KBOLNIBLIND_Mb);
	}

	// // RVA: 0x16B2A54 Offset: 0x16B2A54 VA: 0x16B2A54
	public static int CGJCEHGFHMA(int BCCHOBPJJKE)
	{
		MLIBEPGADJH_Scene.KKLDOOJBJMN k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1];
		MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1];
		return k.NGGBHLCKJGO(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, saveScene.PDNIFBEGMHC_Mb, saveScene.EMOJHJGHJLN_Sb, saveScene.JPIPENJGGDD_Mlt, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(k.EKLIPGELKCL_Rarity, k.MCCIFLKCNKO_Feed), saveScene.CDOBCKMHAOK_Inf);
	}

	// // RVA: 0x16B2DA4 Offset: 0x16B2DA4 VA: 0x16B2DA4
	public int JLNGOOGHCNA()
	{
		bool b = JPIPENJGGDD_NumBoard == 0;
		int a = JPIPENJGGDD_NumBoard;
		if (JPIPENJGGDD_NumBoard < 1)
		{
			b = IJIKIPDKCPP == 1;
			a = IJIKIPDKCPP - 1;
		}
		// ????
		if (b || a == 0)
			b = false;
		else
			b = true;
		return JLNGOOGHCNA(BCCHOBPJJKE_SceneId, JKGFBFPIMGA_Rarity, b, a);
	}

	// // RVA: 0x16B2DF4 Offset: 0x16B2DF4 VA: 0x16B2DF4
	public static int JLNGOOGHCNA(int BCCHOBPJJKE, int JKGFBFPIMGA, bool OOCNLBJJBKI, int JPIPENJGGDD)
	{
		MLIBEPGADJH_Scene.KKLDOOJBJMN s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1];
		int i = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(s.EKLIPGELKCL_Rarity, s.MCCIFLKCNKO_Feed);
		return s.NGGBHLCKJGO(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.DNMKPAKOJFA(JKGFBFPIMGA, OOCNLBJJBKI, s.MCCIFLKCNKO_Feed),
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.CEKGFNKJDCF(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, Mathf.Min(JPIPENJGGDD, i), (int)s.AOPBAOJIOGO_Sb, s.ILABPFOMEAG_Va, OOCNLBJJBKI ? 1 : 0 + JKGFBFPIMGA, s.MCCIFLKCNKO_Feed),
			JPIPENJGGDD, i, JPIPENJGGDD - i);
	}

	// // RVA: 0x16B31F8 Offset: 0x16B31F8 VA: 0x16B31F8
	public bool KEJMFDLFIEO()
	{
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1];
		if(!scene.OFNNNEMCJNN())
		{
			BENDGHHBHFN = scene.ANAJIAENLNB_Level;
			BPJEOPHAJPP = CGJCEHGFHMA();
			return true;
		}
		return false;
	}

	// // RVA: 0x16B33D8 Offset: 0x16B33D8 VA: 0x16B33D8
	public void OHJIKMCAOLE()
	{
		if(BPJEOPHAJPP < CGJCEHGFHMA())
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE_SceneId - 1];
			if(scene.KELFCMEOPPM_Ep > 0)
			{
				OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo ep = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[scene.KELFCMEOPPM_Ep - 1];
				int a = ep.OGDBKJKIGAJ_CurrentPoint;
				ep.MOACIBEKLEN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode, CGJCEHGFHMA() - BPJEOPHAJPP, false);
				ILCCJNDFFOB.HHCJCDFCLOB.BBDKHAMANCB(scene.KELFCMEOPPM_Ep, a, ep.OGDBKJKIGAJ_CurrentPoint, ep.EBIIIAELNAA_Step, JpStringLiterals.StringLiteral_10443, 0, 0);
			}
		}
		ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.MCBICLJIJMK_42, 2, false);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1].IDBDAPPJOND();
	}

	// // RVA: 0x16B3888 Offset: 0x16B3888 VA: 0x16B3888
	public void EJLGAMEIMEG(MNDAMOGGJBJ KNAELKENHPF, List<int> FHHIONFFABP)
	{
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1];
		List<int> l1 = new List<int>();
		List<int> l2 = new List<int>();
		for(int i = 0; i < KNAELKENHPF.MHGAOHAHFDN.Count; i++)
		{
			if(KNAELKENHPF.MHGAOHAHFDN[i].HMFFHLPNMPH_Cnt > 0)
			{
				l1.Add(KNAELKENHPF.MHGAOHAHFDN[i].PPFNGGCBJKC_Id);
				l2.Add(KNAELKENHPF.MHGAOHAHFDN[i].HMFFHLPNMPH_Cnt);
			}
		}
		ILCCJNDFFOB.HHCJCDFCLOB.NNAPCDMAAJM(BCCHOBPJJKE_SceneId, scene.JPIPENJGGDD_Mlt, BENDGHHBHFN, scene.ANAJIAENLNB_Level, l1, l2, KNAELKENHPF.PGGKBIIJOND, FHHIONFFABP);
	}

	// // RVA: 0x16B3D50 Offset: 0x16B3D50 VA: 0x16B3D50
	public bool ADMDGGOKPND_IsAdditiveMainBoard()
	{
		if (JOKJBMJBLBB_Single)
			return false;
		if (JPIPENJGGDD_NumBoard > 0 && IELENGDJPHF == 0)
			return true;
		return false;
	}

	// // RVA: 0x16B3D80 Offset: 0x16B3D80 VA: 0x16B3D80
	public void GHJOFLBDIOI()
	{
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1];
		if (scene.IELENGDJPHF_Ulk != 0)
			return;
		scene.IELENGDJPHF_Ulk = 1;
		IELENGDJPHF = 1;
	}

	// // RVA: 0x16B3EE4 Offset: 0x16B3EE4 VA: 0x16B3EE4
	public bool NFILJJGGKNG_IsAdditiveSubBoard()
	{
		if (JPIPENJGGDD_NumBoard > 1)
			return IELENGDJPHF < JPIPENJGGDD_NumBoard;
		return false;
	}

	// // RVA: 0x16B3F0C Offset: 0x16B3F0C VA: 0x16B3F0C
	public void JGNBHPJCICN()
	{
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE_SceneId - 1];
		if(scene.JPIPENJGGDD_Mlt > 1)
		{
			if (scene.JPIPENJGGDD_Mlt <= scene.IELENGDJPHF_Ulk)
				return;
			scene.IELENGDJPHF_Ulk = scene.JPIPENJGGDD_Mlt;
			IELENGDJPHF = scene.JPIPENJGGDD_Mlt;
		}
	}

	// // RVA: 0x16B4108 Offset: 0x16B4108 VA: 0x16B4108
	public int MNODFKEOPGK()
	{
		if (JKGFBFPIMGA_Rarity < 4)
			return 0;
		int res = 0;
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA_Rarity, MJBODMOLOBC_Luck);
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM.Count; i++)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[i].EKLIPGELKCL == JKGFBFPIMGA_Rarity)
			{
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[i].GNFJOONKCFH > a)
					return res;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[i].GNFJOONKCFH > MKHFCGPJPFI_LimitOverCount)
					res++;
			}
		}
		return res;
	}
}
