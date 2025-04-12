using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public class ILCCJNDFFOB
{
	// public ILCCJNDFFOB.GOIOAIDCKDD HFGPPPOINDJ; // 0x8
	private const int LBBLKAEDGHE = 10;
	private StringBuilder JBBHNIACMFJ = new StringBuilder(256); // 0xC
	private StringBuilder NNNAKNFEPCF = new StringBuilder(64); // 0x10
	private long BMOBAOCHNMO; // 0x18
	private static string[] LDLBGFMFMDG = new string[6] { "enemy_info_id1", 
                                                            "enemy_info_id2", 
                                                            "enemy_info_id3", 
                                                            "enemy_info_id4",
                                                            "enemy_info_id5",
                                                            "enemy_info_id6"}; // 0x4
	private static string[] JGDKLDDPNAB = new string[6] { "enemy_info_1",
                                                            "enemy_info_2",
                                                            "enemy_info_3",
                                                            "enemy_info_4",
                                                            "enemy_info_5",
                                                            "enemy_info_6"}; // 0x8

	public static ILCCJNDFFOB HHCJCDFCLOB { get; set; } // 0x0 LGMPACEDIJF NKACBOEHELJ 0x8F3D90 OKPMHKNCNAL 0x8F3E1C

	// // RVA: 0x8F3EAC Offset: 0x8F3EAC VA: 0x8F3EAC
	public void IJBGPAENLJA()
    {
        HHCJCDFCLOB = this;
    }

	// // RVA: 0x8F3F2C Offset: 0x8F3F2C VA: 0x8F3F2C
	// private string AOKAECCKGFC(DateTime EBBCCKCMBMC) { }

	// // RVA: 0x8F4100 Offset: 0x8F4100 VA: 0x8F4100
	private string BGLHDAKDPMJ_DateToString(DateTime EBBCCKCMBMC)
	{
		NNNAKNFEPCF.Length = 0;
		NNNAKNFEPCF.AppendFormat("{0:0000}-", EBBCCKCMBMC.Year);
		NNNAKNFEPCF.AppendFormat("{0:00}-", EBBCCKCMBMC.Month);
		NNNAKNFEPCF.AppendFormat("{0:00} ", EBBCCKCMBMC.Day);
		NNNAKNFEPCF.AppendFormat("{0:00}:", EBBCCKCMBMC.Hour);
		NNNAKNFEPCF.AppendFormat("{0:00}:", EBBCCKCMBMC.Minute);
		NNNAKNFEPCF.AppendFormat("{0:00}", EBBCCKCMBMC.Second);
		return NNNAKNFEPCF.ToString();
	}

	// // RVA: 0x8F4400 Offset: 0x8F4400 VA: 0x8F4400
	private string COPGJHJGHJG_TimestampToString(long KPBJHHHMOJE)
	{
		if(KPBJHHHMOJE != 0)
		{
			return BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(KPBJHHHMOJE));
		}
		return "";
	}

	// // RVA: 0x8F44CC Offset: 0x8F44CC VA: 0x8F44CC
	private void FLBFCCIEPNC_InitBaseJson(EDOHBJAPLPF_JsonData IDLHJIOMJBK, long JCNNBEEHFLE_RequestId)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		IDLHJIOMJBK[AFEHLCGHAEE_Strings.MOEDCMHBCHN_client_time] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(time));
		IDLHJIOMJBK[AFEHLCGHAEE_Strings.BMOBAOCHNMO_request_id] = JCNNBEEHFLE_RequestId;
		if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIEPKMIADMM_user_rank] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			MCKCJMLOAFP_CurrencyInfo m = CIOECGOMILE.HHCJCDFCLOB.JBEKNFEGFFI();
			if (m != null)
			{
				IDLHJIOMJBK[AFEHLCGHAEE_Strings.OCDBDAFJPBG_num_free_crystal] = m.JLNEMPJICEH_NumFreeCrystal;
				IDLHJIOMJBK[AFEHLCGHAEE_Strings.ABFKGMFCAIL_num_paid_crystal] = m.KCKBGALKNMA_NumPaidCrystal;
			}
			IDLHJIOMJBK[AFEHLCGHAEE_Strings.MOPDHAAPNAN_player_name] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
		}
	}

	// // RVA: 0x8F4AB8 Offset: 0x8F4AB8 VA: 0x8F4AB8
	// private void BAHPICOFGFH(EDOHBJAPLPF_JsonData IDLHJIOMJBK, JBECFDNKPFD MFCGAKOAGFE) { }

	// // RVA: 0x8F509C Offset: 0x8F509C VA: 0x8F509C
	private static void DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO KAPMOPMDHJE, EDOHBJAPLPF_JsonData IDLHJIOMJBK, bool FOIGCFNFPOB = false)
	{
		JDDGPJDKHNE.HHCJCDFCLOB.CLHLFPDNFNM((int)KAPMOPMDHJE,IDLHJIOMJBK,FOIGCFNFPOB);
	}

	// // RVA: 0x8F50E4 Offset: 0x8F50E4 VA: 0x8F50E4
	public void JONAMONAHOB(int ADPPAIPFHML, int FKIBPHGINAE, LGDNAJACFHI MEANCEOIMGE)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		res[AFEHLCGHAEE_Strings.FKCAECFAFCG_stuff_id] = MEANCEOIMGE.LHENLPLKGLP_StuffId;
		if(!MEANCEOIMGE.JLGHMCBLENL_IsBeginner)
		{
			if(MEANCEOIMGE.GCJMGMBNBCB_BuyLimit < 1)
			{
				res[AFEHLCGHAEE_Strings.CEEHDBKCHNJ_stuff_type] = JpStringLiterals.StringLiteral_11130;
			}
			else
			{
				res[AFEHLCGHAEE_Strings.CEEHDBKCHNJ_stuff_type] = JpStringLiterals.StringLiteral_11129;
			}
		}
		else
		{
			res[AFEHLCGHAEE_Strings.CEEHDBKCHNJ_stuff_type] = JpStringLiterals.StringLiteral_11128;
		}
		res[AFEHLCGHAEE_Strings.ADPPAIPFHML_num] = ADPPAIPFHML;
		res[AFEHLCGHAEE_Strings.FKIBPHGINAE_af_num] = FKIBPHGINAE;
		res[AFEHLCGHAEE_Strings.JLPEGFAMKPK_amount] = MEANCEOIMGE.NPPGKNGIFGK_Price;
		if(MEANCEOIMGE.BIOHCFLJDCH_BonusItemId == null || MEANCEOIMGE.HBHLKLGBKIJ_BonusCount == null)
		{
			res["bonus_vc_info"] = "";
		}
		else
		{
			JBBHNIACMFJ.Length = 0;
			bool b = false;
			for(int i = 0; i < MEANCEOIMGE.BIOHCFLJDCH_BonusItemId.Length; i++)
			{
				if(b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(MEANCEOIMGE.BIOHCFLJDCH_BonusItemId[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(MEANCEOIMGE.HBHLKLGBKIJ_BonusCount[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(EKLNMHFCAOI.DEACAHNLMNI_getItemId(MEANCEOIMGE.BIOHCFLJDCH_BonusItemId[i])));
				b = true;
			}
			res["bonus_vc_info"] = JBBHNIACMFJ.ToString();
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.JONAMONAHOB_1, res, false);
	}

	// // RVA: 0x8F5B88 Offset: 0x8F5B88 VA: 0x8F5B88
	// public void KMEONFIEFHN(int ADPPAIPFHML, int FKIBPHGINAE, FHPFLAGNCAF MEANCEOIMGE) { }

	// // RVA: 0x8F602C Offset: 0x8F602C VA: 0x8F602C
	public void PMFGEJJDMCK(int PPFNGGCBJKC, int INDDJNMPONH, string FPGMBHJNGIK, int ADPPAIPFHML, int JLPEGFAMKPK)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		res["id"] = PPFNGGCBJKC;
		res["type"] = INDDJNMPONH;
		res["from_where"] = FPGMBHJNGIK;
		res["num"] = ADPPAIPFHML;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.PMFGEJJDMCK, res, true);
	}

	// // RVA: 0x8F63AC Offset: 0x8F63AC VA: 0x8F63AC
	public void ALABPEPENHH(OAGBCBBHMPF.OGBCFNIKAFI LGADCGFMLLD, long GCLPIJNJFAE)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		long t = time - GCLPIJNJFAE;
		if(GCLPIJNJFAE == 0)
			t = GCLPIJNJFAE;
		NNNAKNFEPCF.Length = 0;
		int h = (int)(t / 3600);
		NNNAKNFEPCF.AppendFormat("{0:00}:", h);
		t = t % 3600;
		int m = (int)(t / 60);
		NNNAKNFEPCF.AppendFormat("{0:00}:", m);
		t = t % 60;
		int s = (int)(t / 60);
		NNNAKNFEPCF.AppendFormat("{0:00}", s);
		res[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = (int)LGADCGFMLLD;
		res[AFEHLCGHAEE_Strings.ADAFEPKKBKP_step_name] = OAGBCBBHMPF.KDIDJBOMHFO[(int)LGADCGFMLLD];
		res[AFEHLCGHAEE_Strings.MFOCHEBHHNC_elapse_t] = NNNAKNFEPCF.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.ALABPEPENHH/*3*/, res, true);
	}

	// // RVA: 0x8F6A44 Offset: 0x8F6A44 VA: 0x8F6A44
	public EDOHBJAPLPF_JsonData LECBAPOGJAG(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP)
	{
		EDOHBJAPLPF_JsonData res = null;
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
		{
			res = new EDOHBJAPLPF_JsonData();
			FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
			res["session_id"] = MDADLCOCEBN;
			res["free_music_id"] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
			res["music_id"] = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId).DLAEJOBELBH_MusicId).DLAEJOBELBH_Id;
			if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
			{
				res["difficulty"] = OMNOFMEBLAD.AKNELONELJK_Difficulty;
			}
			else
			{
				res["difficulty"] = OMNOFMEBLAD.AKNELONELJK_Difficulty + 10;
			}
			switch(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality)
			{
				case 0:
				res["mode"] = JpStringLiterals.StringLiteral_11136;
				break;
				case 1:
				res["mode"] = JpStringLiterals.StringLiteral_11137;
				break;
				case 2:
				res["mode"] = "2D";
				break;
				case 3:
				res["mode"] = JpStringLiterals.StringLiteral_11139;
				break;
			}
			JBBHNIACMFJ.Length = 0;
			bool b = false;
            System.Collections.Generic.List<AMCGONHBGGF> dList = OMNOFMEBLAD.OALJNDABDHK.DJPFJGKGOOF_ScoreTeam.FDBOPFEOENF_MainDivas;
            for (int i = 0; i < dList.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(dList[i].DIPKCALNIII_Id);
				b = true;
			}
			res["char_id"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < dList.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				if(dList[i].DIPKCALNIII_Id == 0)
					JBBHNIACMFJ.Append(0);
				else
					JBBHNIACMFJ.Append(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(dList[i].DIPKCALNIII_Id).HEBKEJBDCBH_DivaLevel);
				b = true;
			}
			res["char_level"] = JBBHNIACMFJ.ToString();
			b = false;
			for(int i = 0; i < dList.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				if(dList[i].DIPKCALNIII_Id == 0)
					JBBHNIACMFJ.Append(0);
				else
					JBBHNIACMFJ.Append(dList[i].BEEAIAAJOHD_CId);
				b = true;
			}
			res["char_cos"] = JBBHNIACMFJ.ToString();
			b = false;
			for(int i = 0; i < dList.Count; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if(b)
					{
						JBBHNIACMFJ.Append(',');
					}
					if(dList[i].DIPKCALNIII_Id == 0)
						JBBHNIACMFJ.Append(0);
					else
						JBBHNIACMFJ.Append(dList[i].EBDNICPAFLB_SSlot[j]);
					b = true;
				}
			}
			res["scene_id"] = JBBHNIACMFJ.ToString();
			int cnt = 0;
			for(int i = 0; i < dList.Count; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if((i != 0 || j != 0) && dList[i].DIPKCALNIII_Id != 0)
					{
						if(dList[i].EBDNICPAFLB_SSlot[j] != 0)
						{
							if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[dList[i].EBDNICPAFLB_SSlot[j] - 1].KPIIIEGGPIB_LS != 0)
								cnt++;
						}
					}
				}
			}
			res["live_skill_cnt"] = cnt;
			//749
			b = false;
			for(int i = 0; i < dList.Count; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if(b)
					{
						JBBHNIACMFJ.Append(',');
					}
					if(dList[i].DIPKCALNIII_Id == 0)
						JBBHNIACMFJ.Append(0);
					else
					{
						if(dList[i].EBDNICPAFLB_SSlot[j] == 0)
							JBBHNIACMFJ.Append(0);
						else
							JBBHNIACMFJ.Append(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[dList[i].EBDNICPAFLB_SSlot[j] - 1].ANAJIAENLNB_Level);
					}
					b = true;
				}
			}
			res["scene_level"] = JBBHNIACMFJ.ToString();
			res["valkyrie_id"] = OMNOFMEBLAD.OALJNDABDHK.DJPFJGKGOOF_ScoreTeam.FODKKJIDDKN_VfId;
			string[] ss = new string[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.HBKBKHACHHI_Soul.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.ICBJAAPJNEI_Soul.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.APPEPDLOPAA_Soul.ToString()
			};
			res["para_soul"] = string.Concat(ss);
			ss = new string[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.GMECIBOJCFF_Vocal.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.AGNGKDFONAM_Vocal.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.LHBINHCMEDA_Vocal.ToString()
			};
			res["para_voice"] = string.Concat(ss);
			ss = new string[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.MIMLMJGGNJH_Charm.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.KAEHAANLPKF_Charm.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.BPNAAEDJGPC_Charm.ToString()
			};
			res["para_charm"] = string.Concat(ss);
			res["para_life"] = OMNOFMEBLAD.ENMGODCHGAC_Log.IPEKDLNEOFI_Life + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.NIBMFONLOME_Life;
			res["para_support"] = OMNOFMEBLAD.ENMGODCHGAC_Log.BFHPKJEKJNN_Support + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.PLMGHHHFAGL_Support;
			res["para_foldwave"] = OMNOFMEBLAD.ENMGODCHGAC_Log.DDBEJNGJIPF_Fold + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.EKKCKGDGNPM_Fold;
			res["para_total"] = OMNOFMEBLAD.ENMGODCHGAC_Log.CBOCBLLOMHE_Total + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.GCAOLGILAAI_Total;
			res["para_luck"] = OMNOFMEBLAD.ENMGODCHGAC_Log.MINAGJOIGOP_Luck + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.IBFPGFJDLEI_Luck;
			res["center_skill_lv"] = OMNOFMEBLAD.ENMGODCHGAC_Log.IFHMFONMGPE_CenterSkillLvl;
			res["active_skill_lv"] = OMNOFMEBLAD.ENMGODCHGAC_Log.AKNKIOKELEP_ActiveSkillLvl;
			if(OMNOFMEBLAD.NHPGGBCKLHC_FriendData == null)
			{
				res["guest_player_id"] = 0;
				res["guest_scene_id"] = 0;
				res["guest_scene_level"] = 0;
				res["guest_scene_luck"] = 0;
				res["guest_center_skill_lv"] = 0;
			}
			else
			{
				res["guest_player_id"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.MLPEHNBNOGD_Id;
				res["guest_scene_id"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId : 0;
				res["guest_scene_level"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().CIEOBFIIPLD_SceneLevel : 0;
				res["guest_scene_luck"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck : 0;
				res["guest_center_skill_lv"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().DDEDANKHHPN_SkillLevel : 0;
			}
			res["game_event_type"] = OMNOFMEBLAD.MNNHHJBBICA_GameEventType;
			res["open_event_type"] = OMNOFMEBLAD.MFJKNCACBDG_OpenEventType;
			res["remaint_stamina"] = KALCJMLIAOK;
			res["use_stamina"] = CBHACAOCJGP;
			res["notes_speed"] = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DGCDPGPAAII_GetNotesSpeed((Difficulty.Type)OMNOFMEBLAD.AKNELONELJK_Difficulty, false);
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < dList.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(Database.Instance.gameSetup.teamInfo.divaList[i].prismDivaId);
				b = true;
			}
			res["mv_char_id"] = JBBHNIACMFJ.ToString();
			res["mv_enable"] = Database.Instance.gameSetup.teamInfo.isPrismEnable;
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < dList.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(Database.Instance.gameSetup.teamInfo.divaList[i].prismDivaId, Database.Instance.gameSetup.teamInfo.divaList[i].prismCostumeModelId);
				if(cos == null)
				{
					JBBHNIACMFJ.Append(0);
				}
				else
				{
					if(cos.DAJGPBLEEOB_PrismCostumeModelId == 1)
						JBBHNIACMFJ.Append(0);
					else
						JBBHNIACMFJ.Append(cos.JPIDIENBGKH_CostumeId);
				}
				b = true;
			}
			res["mv_char_cos"] = JBBHNIACMFJ.ToString();
			res["mv_valkyrie_id"] = Database.Instance.gameSetup.teamInfo.valkyrieId;
			res["dancer_cnt"] = Database.Instance.gameSetup.musicInfo.onStageDivaNum;
			res["score_gauge"] = OMNOFMEBLAD.ENMGODCHGAC_Log.NDKKNEIDCFF_TotalScoreExpected;
			JBBHNIACMFJ.Length = 0;
			JBBHNIACMFJ.AppendFormat("{0},{1},{2},{3},{4}", new object[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.LPKBGBLIDCE,
				OMNOFMEBLAD.ENMGODCHGAC_Log.LCFAJIELMMF,
				OMNOFMEBLAD.ENMGODCHGAC_Log.OIKJEAEJOME,
				OMNOFMEBLAD.ENMGODCHGAC_Log.MINAGJOIGOP_Luck,
				OMNOFMEBLAD.ENMGODCHGAC_Log.JJDKFJACLMD,
			});
			res["para_scene"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < 3; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.AppendFormat("{0},{1},{2}", OMNOFMEBLAD.ENMGODCHGAC_Log.EEKANKOEJIL[i], OMNOFMEBLAD.ENMGODCHGAC_Log.HNINPGMPGMJ[i], OMNOFMEBLAD.ENMGODCHGAC_Log.DNGJJFFKOBG[i]);
				b = true;
			}
			res["para_diva"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < 3; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.AppendFormat("{0},{1},{2}", OMNOFMEBLAD.ENMGODCHGAC_Log.IPPIIBLLDDG[i], OMNOFMEBLAD.ENMGODCHGAC_Log.HHNPILDOHKP[i], OMNOFMEBLAD.ENMGODCHGAC_Log.MHPLFJHDIEP[i]);
				b = true;
			}
			res["para_cos"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < 3; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.AppendFormat("{0},{1},{2}", OMNOFMEBLAD.ENMGODCHGAC_Log.NBCMAGJGHLC[i], OMNOFMEBLAD.ENMGODCHGAC_Log.LBGNJCODPEJ[i], OMNOFMEBLAD.ENMGODCHGAC_Log.EGEKLGIEKLL[i]);
				b = true;
			}
			res["para_godiva"] = JBBHNIACMFJ.ToString();
		}
		return res;

	}

	// // RVA: 0x8FACB0 Offset: 0x8FACB0 VA: 0x8FACB0
	public void FKODKMNGCEH(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP)
	{
		EDOHBJAPLPF_JsonData data = LECBAPOGJAG(OMNOFMEBLAD, MDADLCOCEBN, KALCJMLIAOK, CBHACAOCJGP);
		if(data != null)
		{
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.FKODKMNGCEH/*4*/, data, false);
		}
	}

	// // RVA: 0x8FAE00 Offset: 0x8FAE00 VA: 0x8FAE00
	public EDOHBJAPLPF_JsonData MKMJILJPOGC(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN)
	{
		EDOHBJAPLPF_JsonData data = null;
		if(IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId != 0)
		{
			data = new EDOHBJAPLPF_JsonData();
			FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
			data["session_id"] = MDADLCOCEBN;
			data["free_music_id"] = IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId;
			KEODKEGFDLD_FreeMusicInfo fData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId);
			EONOEHOKBEB_Music mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fData.DLAEJOBELBH_MusicId);
			data["music_id"] = mdata.DLAEJOBELBH_Id;
			if(IJAOGPFKDBP.LIDKENJKLGA_IsLine6 == 0)
			{
				data["difficulty"] = IJAOGPFKDBP.AKNELONELJK_Difficulty;
			}
			else
			{
				data["difficulty"] = IJAOGPFKDBP.AKNELONELJK_Difficulty + 10;
			}
			data["result"] = IJAOGPFKDBP.HBODCMLFDOB_Result;
			data["start_t"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(IJAOGPFKDBP.ICJEDACBMMF_ServerTime));
			data["continue"] = IJAOGPFKDBP.HGACHHHCHHM_ContinueCount;
			data["score"] = IJAOGPFKDBP.KNIFCANOHOC_Score;
			data["high_score"] = IJAOGPFKDBP.JKAMFMNGEBB_Highscore;
			data["score_rank"] = IJAOGPFKDBP.GEIONHDKGEB_ScoreRank;
			data["combo_num"] = IJAOGPFKDBP.POGINDBNBAJ_MaxCombo;
			JBBHNIACMFJ.Length = 0;
			data[AFEHLCGHAEE_Strings.BIEPKMIADMM_user_rank] = IJAOGPFKDBP.HPEHMCGPMJM_Level;
			if(IJAOGPFKDBP.FILFPNDEINH_ComboRank == 0)
			{
				data["full_combo"] = JpStringLiterals.StringLiteral_11163;
			}
			else if(IJAOGPFKDBP.FILFPNDEINH_ComboRank == 1)
			{
				data["full_combo"] = JpStringLiterals.StringLiteral_11164;
			}
			else
			{
				data["full_combo"] = JpStringLiterals.StringLiteral_11165;
			}
			if(IJAOGPFKDBP.IMIEPNOECFD_HasValkyrieMode == 0)
			{
				data["valkyrie_mode"] = JpStringLiterals.StringLiteral_11167;
			}
			else
			{
				data["valkyrie_mode"] = JpStringLiterals.StringLiteral_11168;
			}
			if(IJAOGPFKDBP.GFODFMFGLJG_HadDivaMode == 0)
			{
				data["utahime_mode"] = JpStringLiterals.StringLiteral_11167;
			}
			else if(IJAOGPFKDBP.GFODFMFGLJG_HadDivaMode == 1)
			{
				data["utahime_mode"] = JpStringLiterals.StringLiteral_11170;
			}
			else
			{
				data["utahime_mode"] = JpStringLiterals.StringLiteral_11171;
			}
			if(IJAOGPFKDBP.MPHFGEPJOGL_NumSkillActive == 0)
			{
				data["active_skill"] = JpStringLiterals.StringLiteral_11173;
			}
			else
			{
				data["active_skill"] = JpStringLiterals.StringLiteral_11174;
			}
			data["active_skill_t"] = string.Format("{0}:{1:00}:{2:000}", 0, IJAOGPFKDBP.HNCDHJDENJO_LastSkillMillisec / 1000, IJAOGPFKDBP.HNCDHJDENJO_LastSkillMillisec % 1000);
			JBBHNIACMFJ.Length = 0;
			bool b = false;
			for(int i = 0; i < IJAOGPFKDBP.MNDPPLILCPJ.Count; i++)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(IJAOGPFKDBP.MNDPPLILCPJ[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(IJAOGPFKDBP.JIHECDPAOKB[i]);
				b = true;
			}
			data["drop_info"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			b = false;
			for(int i = 0; i < OMNOFMEBLAD.HNHCIGMKPDC_DivaIds.Count; i++)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				if (OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] == 0)
					JBBHNIACMFJ.Append(0);
				else
				{
					JBBHNIACMFJ.Append(IJAOGPFKDBP.FMMKKCANOKG_DivaLevels[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] - 1]);
				}
				b = true;
			}
			data["char_level"] = JBBHNIACMFJ.ToString();
			data["ave_fps"] = IJAOGPFKDBP.LMOBPKIDIHF_AverageFps;
			data["low_fps"] = IJAOGPFKDBP.IPAAOFCGEAB_MinFps;
			data["money"] = IJAOGPFKDBP.HJILBFGFFEM_BaseUnionCredit;
			data["get_char_exp"] = IJAOGPFKDBP.BNJBFKAIICK_GetCharExp;
			data["get_user_exp"] = IJAOGPFKDBP.NMDHKLPAKHB_GetUserExp;
			data["notes"] = IJAOGPFKDBP.OEEOILKOKFM_SerializedNoteResultInfo;
			JBBHNIACMFJ.Length = 0;
			JBBHNIACMFJ.AppendFormat("PERFECT:{0},", IJAOGPFKDBP.LAMMILPNINO_NoteResultCount[4]);
			JBBHNIACMFJ.AppendFormat("GREAT:{0},", IJAOGPFKDBP.LAMMILPNINO_NoteResultCount[3]);
			JBBHNIACMFJ.AppendFormat("GOOD:{0},", IJAOGPFKDBP.LAMMILPNINO_NoteResultCount[2]);
			JBBHNIACMFJ.AppendFormat("BAD:{0},", IJAOGPFKDBP.LAMMILPNINO_NoteResultCount[1]);
			JBBHNIACMFJ.AppendFormat("MISS:{0},,", IJAOGPFKDBP.LAMMILPNINO_NoteResultCount[0]);
			data["notes_judge"] = JBBHNIACMFJ.ToString();
			data["excellent_rate"] = Database.Instance.gameSetup.teamInfo.excellentRate;
			data["excellent_score_up"] = Database.Instance.gameSetup.teamInfo.excellentScoreAdd;
			data["excellent_notes"] = IJAOGPFKDBP.NOEAGOJKEAJ_ExcellentCount;
			data["center_live_skill_rate"] = Database.Instance.gameSetup.teamInfo.centerLiveSkillRate;
			data["center_live_skill_notes"] = IJAOGPFKDBP.FCFICFMIHLI_TouchedCenterLiveSkill;
		}
		return data;
	}

	// // RVA: 0x8FC960 Offset: 0x8FC960 VA: 0x8FC960
	public void IMJLLLNHICJ(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN)
	{
		EDOHBJAPLPF_JsonData data = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, MDADLCOCEBN);
		if (data != null)
		{
			HighScoreRating rating = new HighScoreRating();
			rating.Init();
			rating.CalcUtaRate(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.LCKMBHDMPIP_RecordMusic, false);
			HighScoreRating rating2 = new HighScoreRating();
			rating2.Init();
			rating2.CalcUtaRateForLog(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.LCKMBHDMPIP_RecordMusic, IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId, IJAOGPFKDBP.AKNELONELJK_Difficulty, IJAOGPFKDBP.KNIFCANOHOC_Score);
			JBBHNIACMFJ.Length = 0;
			bool b = false;
			for (int i = 0; i < 10; i++)
			{
				int musicId = rating2.hsRatingMusicData[i, 0].FreeMusicId;
				if (b)
					JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(i + 1);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(musicId);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(rating2.hsRatingMusicData[i, 0].Difficulty);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(rating2.hsRatingMusicData[i, 0].RawScore);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(rating2.hsRatingMusicData[i, 0].Score);
				JBBHNIACMFJ.Append(',');
				string str = "up";
				for (int j = 0; j < 10; j++)
				{
					if (rating.hsRatingMusicData[j, 0].FreeMusicId == musicId)
					{
						str = "down";
						if (i <= j)
						{
							str = "same";
							if (i != j)
							{
								str = "up";
								if (i < j)
									str = "up";
							}
						}
						break;
					}
				}
				JBBHNIACMFJ.Append(str);
				b = true;
			}
			data["uta_rate_info"] = JBBHNIACMFJ.ToString();
			data["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.IMJLLLNHICJ/*5*/, data, false);
		}
	}

	// // RVA: 0x8FD4B0 Offset: 0x8FD4B0 VA: 0x8FD4B0
	public void KHMDGNKEFOD(string CHJGGLFGALP, int EIANMIIKPDH, bool NMJBGABMEDK = false, bool CMEOKJMCEBH = false, int AHHJLDLAPAN = 1)
	{
		CIFHILOJJFC afterData = null;
		CIFHILOJJFC beforeData = null;
		if (CMEOKJMCEBH)
		{
			afterData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KMBJGAHCBDI_UnitGoDiva.IGKLKPIEEEH(AHHJLDLAPAN);
			beforeData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KMBJGAHCBDI_UnitGoDiva.PKMMBKHODDM_Saved[AHHJLDLAPAN - 1];
		}
		else
		{
			afterData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault();
			beforeData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.DBMOBFCLFOB_Saved;
		}
		if(!NMJBGABMEDK)
		{
			if(afterData.AGBOGBEOFME(beforeData))
				return;
		}
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < 3; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(beforeData.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j]);
				b = true;
			}
		}
		data["bf_scene"] = JBBHNIACMFJ.ToString();

		JBBHNIACMFJ.Length = 0;
		b = false;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(afterData.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j]);
				b = true;
			}
		}
		data["af_scene"] = JBBHNIACMFJ.ToString();
		data["set_status"] = CHJGGLFGALP;
		data["deck_id"] = EIANMIIKPDH;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.KHMDGNKEFOD/*6*/, data, false);
		beforeData.ODDIHGPONFL_Copy(afterData, false);
	}

	// // RVA: 0x8FE158 Offset: 0x8FE158 VA: 0x8FE158
	public void JNBKOAKJDAL(int HHGMPEEGFMA, int HMFFHLPNMPH, int IIGPLLECFND, int KJMLLBDLKCG, List<int> IHBECLGCIJI, BBHNACPENDM_ServerSaveData LDEGEHAEALK, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP, PFIJNPCEOIL IFFKECJOPIB)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.BDEOMEBFDFF_gacha_id] = HHGMPEEGFMA;
		data[AFEHLCGHAEE_Strings.NENOJMFOAOC_exec_num] = HMFFHLPNMPH;
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < IHBECLGCIJI.Count; i++)
		{
			if (b)
				JBBHNIACMFJ.Append(',');
			JBBHNIACMFJ.Append(IHBECLGCIJI[i]);
			b = true;
		}
		data["get_scene_ids"] = JBBHNIACMFJ.ToString();
		Dictionary<int, int> d = new Dictionary<int, int>();
		List<MMPBPOIFDAF_Scene.PMKOFEIONEG> l3 = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA;
		for(int i = 0; i < IHBECLGCIJI.Count; i++)
		{
			if(!d.ContainsKey(IHBECLGCIJI[i]))
			{
				if(l3[IHBECLGCIJI[i] - 1].BEBJKJKBOGH_Date == 0)
				{
					d.Add(IHBECLGCIJI[i], 0);
				}
				else
				{
					d[IHBECLGCIJI[i]] = l3[IHBECLGCIJI[i] - 1].JPIPENJGGDD_Mlt + 1;
				}
			}
		}
		JBBHNIACMFJ.Length = 0;
		b = false;
		for(int i = 0; i < IHBECLGCIJI.Count; i++)
		{
			if(d[IHBECLGCIJI[i]] != 0)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(IHBECLGCIJI[i]);
				b = true;
			}
			d[IHBECLGCIJI[i]]++;
		}
		data["get_redundant_obj_ids"] = JBBHNIACMFJ.ToString();
		switch(IIGPLLECFND)
		{
			case 1:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_10137;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = KJMLLBDLKCG;
				break;
			case 2:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_10138;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = KJMLLBDLKCG;
				break;
			case 3:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_11202;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = KJMLLBDLKCG;
				break;
			case 4:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_11203;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = KJMLLBDLKCG;
				break;
		}
		if(OMOEKOCNICP == null || ONNIHHLHLDP == null)
		{
			data["bf_step_index"] = 0;
			data["af_step_index"] = 0;
			data["bf_step_rest"] = 0;
			data["af_step_rest"] = 0;
		}
		else
		{
			data["bf_step_index"] = OMOEKOCNICP.DBNAGGGJDAB_CurrentStepIndex;
			data["af_step_index"] = ONNIHHLHLDP.DBNAGGGJDAB_CurrentStepIndex;
			data["bf_step_rest"] = OMOEKOCNICP.NMNLJFIDFJE_CurrentStepRestCount;
			data["af_step_rest"] = ONNIHHLHLDP.NMNLJFIDFJE_CurrentStepRestCount;
		}
		if(IFFKECJOPIB == null)
		{
			data["is_free"] = 0;
		}
		else if(!IFFKECJOPIB.LDBPAJKIPKD_IsNextFree)
		{
			data["is_free"] = 0;
		}
		else
		{
			data["is_free"] = 1;
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.JNBKOAKJDAL_7, data, false);
	}

	// // RVA: 0x8FF43C Offset: 0x8FF43C VA: 0x8FF43C
	public void JNBKOAKJDAL(int HHGMPEEGFMA, int HMFFHLPNMPH, int IIGPLLECFND, int KJMLLBDLKCG, List<ANGEDJODMKO> HBHMAKNGKFK, BBHNACPENDM_ServerSaveData LDEGEHAEALK, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP, PFIJNPCEOIL IFFKECJOPIB)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < HBHMAKNGKFK.Count; i++)
		{
			l.Add(HBHMAKNGKFK[i].OCNINMIMHGC_ItemValue);
		}
		JNBKOAKJDAL(HHGMPEEGFMA, HMFFHLPNMPH, IIGPLLECFND, KJMLLBDLKCG, l, LDEGEHAEALK, OMOEKOCNICP, ONNIHHLHLDP, IFFKECJOPIB);
	}

	// // RVA: 0x8FF5B8 Offset: 0x8FF5B8 VA: 0x8FF5B8
	public void JNBKOAKJDAL(int HHGMPEEGFMA, int HMFFHLPNMPH, int IIGPLLECFND, int KJMLLBDLKCG, List<MFDJIFIIPJD> HBHMAKNGKFK, BBHNACPENDM_ServerSaveData LDEGEHAEALK, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP, PFIJNPCEOIL IFFKECJOPIB)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < HBHMAKNGKFK.Count; i++)
		{
			l.Add(HBHMAKNGKFK[i].OCNINMIMHGC_ItemFullId);
		}
		JNBKOAKJDAL(HHGMPEEGFMA, HMFFHLPNMPH, IIGPLLECFND, KJMLLBDLKCG, l, LDEGEHAEALK, OMOEKOCNICP, ONNIHHLHLDP, IFFKECJOPIB);
	}

	// // RVA: 0x8FF734 Offset: 0x8FF734 VA: 0x8FF734
	public void NNAPCDMAAJM(int BCCHOBPJJKE, int JPIPENJGGDD, int MMEIOJKLCKK, int PNMKPKMDOND, List<int> GFFAJFPIEKD, List<int> GHINHKOOBKI, int NEMMJLNMEHB, List<int> FHHIONFFABP)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1];
		json["scene_id"] = BCCHOBPJJKE;
		if(JPIPENJGGDD < 1)
		{
			json["rarity"] = dbScene.EKLIPGELKCL_Rarity;
		}
		else
		{
			json["rarity"] = dbScene.EKLIPGELKCL_Rarity + 1;
		}
		json[AFEHLCGHAEE_Strings.MMEIOJKLCKK_bf_main_lv] = MMEIOJKLCKK;
		json[AFEHLCGHAEE_Strings.PNMKPKMDOND_af_main_lv] = PNMKPKMDOND;
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < GFFAJFPIEKD.Count; i++)
		{
			if (b)
				JBBHNIACMFJ.Append(',');
			JBBHNIACMFJ.Append(EKLNMHFCAOI.INCKKODFJAP_GetItemName(GFFAJFPIEKD[i]));
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(GFFAJFPIEKD[i]);
			b = true;
		}
		json["item_info"] = JBBHNIACMFJ.ToString();
		json[AFEHLCGHAEE_Strings.NEMMJLNMEHB_money] = NEMMJLNMEHB;
		JBBHNIACMFJ.Length = 0;
		b = false;
		for (int i = 0; i < FHHIONFFABP.Count; i++)
		{
			if (FHHIONFFABP[i] != 0)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(IDMPGHMNLHD.HBOECCCMPMJ[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(FHHIONFFABP[i]);
				b = true;
			}
		}
		json["open_panel_info"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.NNAPCDMAAJM/*8*/, json, false);
	}

	// // RVA: 0x900300 Offset: 0x900300 VA: 0x900300
	public void JAHALBMOANH(int JJBGOIMEIPF, OAGBCBBHMPF.COIIJOEKBDH LHEIIHKDMPA, string NPBEKONLDDI, int ADPPAIPFHML, int FBAIDPHDEBA, int LIDBKCIMCKE)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json[AFEHLCGHAEE_Strings.FKCAECFAFCG_stuff_id] = JJBGOIMEIPF;
		json[AFEHLCGHAEE_Strings.CEEHDBKCHNJ_stuff_type] = EKLNMHFCAOI.PNNKOIFOPMK[(int)EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JJBGOIMEIPF)];
		json[AFEHLCGHAEE_Strings.LHEIIHKDMPA_route_type] = OAGBCBBHMPF.CINOEDJHDIE[(int)LHEIIHKDMPA];
		json[AFEHLCGHAEE_Strings.NPBEKONLDDI_route_id] = NPBEKONLDDI;
		json[AFEHLCGHAEE_Strings.ADPPAIPFHML_num] = ADPPAIPFHML;
		json[AFEHLCGHAEE_Strings.FBAIDPHDEBA_num_af] = FBAIDPHDEBA;
		json[AFEHLCGHAEE_Strings.LIDBKCIMCKE_rarity] = LIDBKCIMCKE;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.JAHALBMOANH/*9*/, json, false);
	}

	// // RVA: 0x900900 Offset: 0x900900 VA: 0x900900
	public void OJOLFJGNEMO(int OLDAGCNLJOI_Progress, int DLAEJOBELBH_Id)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
        EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH_Id);
		json[AFEHLCGHAEE_Strings.OLDAGCNLJOI_Progress] = OLDAGCNLJOI_Progress;
		json["music_id"] = DLAEJOBELBH_Id;
		json["music_name"] = Database.Instance.musicText.Get(minfo.KNMGEEFGDNI_Nam).musicName;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.OJOLFJGNEMO, json, false);
    }

	// // RVA: 0x900DA8 Offset: 0x900DA8 VA: 0x900DA8
	public void DBIDGHMFLIC(int AHHJLDLAPAN, int IGCLCOMCHHB, int IBKAENIBBIL, int DPJCPEIPAPN, int EKPGGDOOLFM)
	{
		DBIDGHMFLIC(OAGBCBBHMPF.KJDNDEDOIOO.DBIDGHMFLIC, AHHJLDLAPAN, IGCLCOMCHHB, IBKAENIBBIL, DPJCPEIPAPN, EKPGGDOOLFM);
	}

	// // RVA: 0x9011B4 Offset: 0x9011B4 VA: 0x9011B4
	public void CJCJNKOPIKB(int AHHJLDLAPAN, int IGCLCOMCHHB, int IBKAENIBBIL, int DPJCPEIPAPN, int EKPGGDOOLFM)
	{
		DBIDGHMFLIC(OAGBCBBHMPF.KJDNDEDOIOO.CJCJNKOPIKB/*95*/, AHHJLDLAPAN, IGCLCOMCHHB, IBKAENIBBIL, DPJCPEIPAPN, EKPGGDOOLFM);
	}

	// // RVA: 0x900DE0 Offset: 0x900DE0 VA: 0x900DE0
	private void DBIDGHMFLIC(OAGBCBBHMPF.KJDNDEDOIOO INDDJNMPONH, int AHHJLDLAPAN, int IGCLCOMCHHB, int IBKAENIBBIL, int DPJCPEIPAPN, int EKPGGDOOLFM) 
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["char_id"] = AHHJLDLAPAN;
		json["bf_cos"] = IGCLCOMCHHB;
		json["af_cos"] = IBKAENIBBIL;
		json["bf_color_id"] = DPJCPEIPAPN;
		json["af_color_id"] = EKPGGDOOLFM;
		DEGEPBNNOAF(INDDJNMPONH, json, false);
	}

	// // RVA: 0x9011EC Offset: 0x9011EC VA: 0x9011EC
	public void GCCAFBHKAEG(int JOMGCCBFKEF)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[JOMGCCBFKEF - 1];
		json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11216;
		json[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = JOMGCCBFKEF;
		json[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = MessageManager.Instance.GetMessage("master", "qd_dsc_" + JOMGCCBFKEF.ToString("D4"));
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.IEEKNBEEMMM_12, json, false);
	}

	// // RVA: 0x9016DC Offset: 0x9016DC VA: 0x9016DC
	public void MOCDNABNBAO(int JOMGCCBFKEF)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[JOMGCCBFKEF - 1];
		if(ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(quest))
		{
			json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11217;
		}
		else
		{
			if (ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)quest.INDDJNMPONH_Type))
			{
				json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11218;
			}
			else
			{
				json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11219;
			}
		}
		json[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = JOMGCCBFKEF;
		json[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = MessageManager.Instance.GetMessage("master", "qn_dsc_" + JOMGCCBFKEF.ToString("D4"));
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.IEEKNBEEMMM_12, json, false);
	}

	// // RVA: 0x901E50 Offset: 0x901E50 VA: 0x901E50
	public void APAJMNOBNLL(IKDICBBFBMI_EventBase MOHDLLIJELH, int JOMGCCBFKEF)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11220;
		AKIIJBEJOEP d = MOHDLLIJELH.AGLILDLEFDK_Missions[JOMGCCBFKEF - 1];
		data[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = MOHDLLIJELH.PGIIDPEGGPI_EventId * 1000 + JOMGCCBFKEF;
		data[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = d.FEMMDNIELFC_Desc;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.IEEKNBEEMMM_12, data, false);
	}

	// // RVA: 0x902248 Offset: 0x902248 VA: 0x902248
	public void JHAPELNFEOM(int APFDNBGMMMM, int JOMGCCBFKEF, string FEMMDNIELFC)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11221;
		data[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = APFDNBGMMMM * 1000 + JOMGCCBFKEF;
		data[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = FEMMDNIELFC;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.IEEKNBEEMMM_12, data, false);
	}

	// // RVA: 0x9025E0 Offset: 0x9025E0 VA: 0x9025E0
	public void EAEHILOBHDA(int DLAEJOBELBH_Id, string NEDBBJDAFBH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["music_id"] = DLAEJOBELBH_Id;
		data["music_name"] = NEDBBJDAFBH;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.EAEHILOBHDA_13, data, false);
	}

	// // RVA: 0x9028C8 Offset: 0x9028C8 VA: 0x9028C8
	public void AOPBBHMIEPB(int BMPFHHHCNJC)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[BMPFHHHCNJC - 1];
		int aa = 0;
		int type = 2;
		if(dbStory.JHPPLIGJFPI < 1)
		{
			if (dbStory.NOCGGJPABMA != 1)
			{
				type = dbStory.NOCGGJPABMA;
				if (dbStory.NOCGGJPABMA == 2)
					aa = 8;
				else
					type = 1;
			}
			else
				aa = 9;
		}
		else
		{
			aa = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GFIPALLLPMF(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NIKCFOALFJC_DivaFirst, dbStory.JHPPLIGJFPI);
		}
		//LAB_00902b6c
		data["type"] = type;
		if(type == 1)
		{
			data["opened_id"] = dbStory.OMMEPCGNHFM_FreeMusicId2;
		}
		else
		{
			data["opened_id"] = aa;
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.AOPBBHMIEPB/*14*/, data, false);
	}

	// // RVA: 0x902EF8 Offset: 0x902EF8 VA: 0x902EF8
	public void MNFOJMBPHEN(int LJEONGIBHGM, int JOBJHJCIMDN, int ADKIDBJCAJA, int HLJBAHBLBPL, int DKHKDNNIPCA)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.LJEONGIBHGM_target_user_id] = LJEONGIBHGM;
		data[AFEHLCGHAEE_Strings.JOBJHJCIMDN_target_user_rank] = JOBJHJCIMDN; 
		switch(ADKIDBJCAJA)
		{
			case 0:
				data[AFEHLCGHAEE_Strings.ADKIDBJCAJA_action] = JpStringLiterals.StringLiteral_11223;
				break;
			case 1:
				data[AFEHLCGHAEE_Strings.ADKIDBJCAJA_action] = JpStringLiterals.StringLiteral_11224;
				break;
			case 2:
				data[AFEHLCGHAEE_Strings.ADKIDBJCAJA_action] = JpStringLiterals.StringLiteral_11225;
				break;
			case 3:
				data[AFEHLCGHAEE_Strings.ADKIDBJCAJA_action] = JpStringLiterals.StringLiteral_11226;
				break;
			case 4:
				data[AFEHLCGHAEE_Strings.ADKIDBJCAJA_action] = JpStringLiterals.StringLiteral_11227;
				break;
		}
		data["friends_num"] = HLJBAHBLBPL;
		data["max_friends_num"] = DKHKDNNIPCA;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.MNFOJMBPHEN_15, data, false);
	}

	// // RVA: 0x9036DC Offset: 0x9036DC VA: 0x9036DC
	public void EEPIDKPPLJI(int AFNCFEMDJNP, int FDMAECAPKDF)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["bf_valkyrie"] = AFNCFEMDJNP;
		data["af_valkyrie"] = FDMAECAPKDF;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.EEPIDKPPLJI_ValkyrieChange/*20*/, data, false);
	}

	// // RVA: 0x9039C4 Offset: 0x9039C4 VA: 0x9039C4
	public void JOLBIMMKGIP(int JPNBLCBOCLN, int NAJPNHKHKKA, int HBNIMMAEKHJ, int JGGKJBCGKCC)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["type"] = 1;
		data["room_id"] = JPNBLCBOCLN;
		data[AFEHLCGHAEE_Strings.NAJPNHKHKKA_sns_id] = NAJPNHKHKKA;
		data["use_item_id"] = JGGKJBCGKCC;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HGOGFPOCKFA/*17*/, data, false);
	}

	// // RVA: 0x903D7C Offset: 0x903D7C VA: 0x903D7C
	public void HGOGFPOCKFA(int JPNBLCBOCLN, int NAJPNHKHKKA, int HBNIMMAEKHJ)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["type"] = 2;
		data["room_id"] = JPNBLCBOCLN;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HGOGFPOCKFA/*17*/, data, false);
	}

	// // RVA: 0x904060 Offset: 0x904060 VA: 0x904060
	public void BBDKHAMANCB(int GDEJFKCMNAC, int FCJLPINNDKN, int KJDKJGGHHIF, int LGADCGFMLLD, string DNKNECIGGMO, int FEGJGLAHEOI = 0, int KNKCLDMLGIH = 0)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.AIFCAAHMFBD_episod_id] = GDEJFKCMNAC;
		data["af_pt"] = KJDKJGGHHIF;
		data["bf_pt"] = FCJLPINNDKN;
		data["step"] = LGADCGFMLLD;
		data["get_type"] = DNKNECIGGMO;
		data["use_epi_item_id"] = FEGJGLAHEOI;
		data["use_epi_item_num"] = KNKCLDMLGIH;
		if(FEGJGLAHEOI == 0)
		{
			data["use_item_info"] = "";
		}
		else
		{
			data["use_item_info"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(FEGJGLAHEOI) + ":" + KNKCLDMLGIH.ToString();
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.BBDKHAMANCB_18, data, false);
	}

	// // RVA: 0x904668 Offset: 0x904668 VA: 0x904668
	// public void AMBIOHGPBNH(string IPBHCLIHAPG, int ADPPAIPFHML) { }

	// // RVA: 0x904950 Offset: 0x904950 VA: 0x904950
	// public void PNMJDKOLGEG(int DMOAGOOHEND) { }

	// // RVA: 0x904954 Offset: 0x904954 VA: 0x904954
	public void EBLJKIOEELA(int AHHJLDLAPAN, int CIEOBFIIPLD, int LKIFDCEKDCK)
	{
		return;
	}

	// // RVA: 0x904958 Offset: 0x904958 VA: 0x904958
	public void PGHFPIMIOKE(int ICPDDMIBEIL, int MKNKJMFILFB)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["bf_emblem"] = ICPDDMIBEIL;
		d["af_emblem"] = MKNKJMFILFB;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.PGHFPIMIOKE, d, false);
	}

	// // RVA: 0x904C40 Offset: 0x904C40 VA: 0x904C40
	public void COBCMOAAAFF(int APGKOJKNNGP)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["emblem_id"] = APGKOJKNNGP;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.COBCMOAAAFF_27, d, false);
	}

	// // RVA: 0x904EDC Offset: 0x904EDC VA: 0x904EDC
	public void CMBKHLDBIEC_SendVoicePlayed(int DIPKCALNIII_CharaId, string LDBIGOBMFMD_CharaName, int CLKJBCJMILI_VoiceCount)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["char_id"] = DIPKCALNIII_CharaId;
		d["char_name"] = LDBIGOBMFMD_CharaName;
		d["voice_count"] = CLKJBCJMILI_VoiceCount;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.CMBKHLDBIEC, d, false);
	}

	// // RVA: 0x905210 Offset: 0x905210 VA: 0x905210
	public void FLBCPKHGLPE(int APJBBOHHFNE, int MKNKJMFILFB, int MNHBMILFDBG, int ECEKFEFOFNI, string JKJDGDLAIME)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["heal"] = APJBBOHHFNE;
		d["af"] = MKNKJMFILFB;
		if(MNHBMILFDBG == 0)
		{
			d["use_item_type"] = JpStringLiterals.StringLiteral_11245;
			d["use_item_count"] = ECEKFEFOFNI;
		}
		else
		{
			d["use_item_type"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem, MNHBMILFDBG);
			d["use_item_count"] = ECEKFEFOFNI;
		}
		d["buy_place"] = JKJDGDLAIME;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.FLBCPKHGLPE_25, d, false);
	}

	// // RVA: 0x905750 Offset: 0x905750 VA: 0x905750
	public void MLNHHIIDJAO_SendAnketoResult(MBLFHJJEHLH_AnketoMgr.CGBKENNCMMC PEPCJDIECJP)
	{
		if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JPIDBKDPFLM_IsShowAnketoFlag(PEPCJDIECJP.PPFNGGCBJKC_Id - 1))
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
			data["enquete_ver"] = PEPCJDIECJP.CEMEIPNMAAD_Version;
			data["enquete_id"] = PEPCJDIECJP.PPFNGGCBJKC_Id;
			data["enquete_detail"] = PEPCJDIECJP.ADCMNODJBGJ_Question;
			JBBHNIACMFJ.Length = 0;
			bool next = false;
			for(int i = 0; i < PEPCJDIECJP.LPKAJMLOAMF_ChoiceText.Length; i++)
			{
				if(PEPCJDIECJP.MHBBJADMHPN_ChoiceSelected[i])
				{
					if(next)
					{
						JBBHNIACMFJ.Append(',');
					}
					next = true;
					JBBHNIACMFJ.Append(PEPCJDIECJP.LPKAJMLOAMF_ChoiceText[i]);
				}
			}
			data["answer_detail"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			next = false;
			for(int i = 0; i < PEPCJDIECJP.MHBBJADMHPN_ChoiceSelected.Length; i++)
			{
				if (PEPCJDIECJP.MHBBJADMHPN_ChoiceSelected[i])
				{
					if (next)
					{
						JBBHNIACMFJ.Append(',');
					}
					next = true;
					JBBHNIACMFJ.Append(i);
				}
			}
			data["answer_id"] = JBBHNIACMFJ.ToString();
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.MLNHHIIDJAO_Anketo, data, false);
		}
		else
		{
			Debug.Log(JpStringLiterals.StringLiteral_11248);
		}
	}

	// // RVA: 0x905F20 Offset: 0x905F20 VA: 0x905F20
	// public void NNFGBBCHLPC(int PGIIDPEGGPI, string HEIPELEDAIK, long ICPDDMIBEIL, long MKNKJMFILFB, long DOOGFEGEKLG, bool CMIGGBMMBKK) { }

	// // RVA: 0x905F24 Offset: 0x905F24 VA: 0x905F24
	public void GIBLHFKIMDA(IKDICBBFBMI_EventBase MOHDLLIJELH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["event_ttl_pt"] = MOHDLLIJELH.FBGDBGKNKOD_GetCurrentPoint();
		data["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
		data["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.GIBLHFKIMDA_28, data, false);
	}

	// // RVA: 0x906284 Offset: 0x906284 VA: 0x906284
	// public void GBABEMFLPBA(string MDADLCOCEBN, int CCHFKKINLHB, int DAOBEIMNFLH, MHAPMOLCPKM MOHDLLIJELH) { }

	// // RVA: 0x906660 Offset: 0x906660 VA: 0x906660
	// public void MFIIOABPKAO(string MDADLCOCEBN, MHAPMOLCPKM MOHDLLIJELH) { }

	// // RVA: 0x906DD8 Offset: 0x906DD8 VA: 0x906DD8
	// public void EPABCLLAJDP(string MDADLCOCEBN, MHAPMOLCPKM MOHDLLIJELH, int PFDFGDPLLCK) { }

	// // RVA: 0x907500 Offset: 0x907500 VA: 0x907500
	// public void LKOICKMAADB(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP, MHAPMOLCPKM MOHDLLIJELH) { }

	// // RVA: 0x907FA4 Offset: 0x907FA4 VA: 0x907FA4
	// public void EEGOAEADLDP(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, MHAPMOLCPKM MOHDLLIJELH) { }

	// // RVA: 0x9089A4 Offset: 0x9089A4 VA: 0x9089A4
	// public void JMAJBHENDPF(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP, IKDICBBFBMI MOHDLLIJELH) { }

	// // RVA: 0x908E44 Offset: 0x908E44 VA: 0x908E44
	// public void NJKBAICBOIN(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, IKDICBBFBMI MOHDLLIJELH) { }

	// // RVA: 0x90941C Offset: 0x90941C VA: 0x90941C
	public string MECOCJPMMDO(HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ BIGMHOMLMAG)
	{
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(BIGMHOMLMAG.GOIKCKHMBDL_FreeMusicId);
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(m.DLAEJOBELBH_MusicId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.GOIKCKHMBDL_FreeMusicId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.EHGBICNIBKE_Pid);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.OPFGFINHFCE_Name);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.DIPKCALNIII_DivaId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.GLILAGLJLEP_SceneId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.ECOLMPLOPFM_SceneLevel);
		JBBHNIACMFJ.Append(':');
		if(BIGMHOMLMAG.GLILAGLJLEP_SceneId < 1)
		{
			JBBHNIACMFJ.Append(0);
		}
		else
		{
			int lvl = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BIGMHOMLMAG.GLILAGLJLEP_SceneId - 1].EKLIPGELKCL_Rarity;
			if(BIGMHOMLMAG.CFCIMKOHLIG_Mlt > 0)
				lvl++;
			JBBHNIACMFJ.Append(lvl);
		}
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.BDLNMOIOMHK_TotalStats);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.KNIFCANOHOC_Score);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.AKNELONELJK_Difficulty);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.EHGBICNIBKE_Pid > 9999);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.IPPNCOHEEOD_ScoreAverage);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.BHCIFFILAKJ_Str);
		return JBBHNIACMFJ.ToString();
	}

	// // RVA: 0x909B38 Offset: 0x909B38 VA: 0x909B38
	public void HHGEPDNBGAI(HAEDCCLHEMN_EventBattle MOHDLLIJELH, int[] PAHGOCGBINJ, int[] BEGOPJOCMAF)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["session_id"] = MOHDLLIJELH.FEKEBPKINIM_GetSessionId();
		data["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
		data["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
		data["game_num"] = MOHDLLIJELH.BEHNMCPFEIE_GetCnt();
		data["consecutive_win"] = MOHDLLIJELH.HACMNNLAHCO_GetConsecutiveWin();
		data["avg_score"] = MOHDLLIJELH.CAEIHFHFOKI_GetScoreAverage();
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < 6; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(PAHGOCGBINJ[i]);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(BEGOPJOCMAF[i]);
			b = true;
		}
		data["search_range"] = JBBHNIACMFJ.ToString();
		for(int i = 0; i < 6; i++)
		{
			HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ d = MOHDLLIJELH.PIPHAKNMIBL_Rivals.Find((HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ GHPLINIACBB) =>
			{
				//0x20193C0
				return GHPLINIACBB.BHCIFFILAKJ_Str == i;
			});
			if(d == null)
			{
				data[LDLBGFMFMDG[i]] = i + 1;
				data[JGDKLDDPNAB[i]] = "";
			}
			else
			{
				data[LDLBGFMFMDG[i]] = i + 1;
				data[JGDKLDDPNAB[i]] = MECOCJPMMDO(d);
			}
		}
		data["selected_class"] = MOHDLLIJELH.KKMFHMGIIKN_GetCls();
		data["unlocked_class"] = MOHDLLIJELH.DAHNCPDEBDM_GetEvBltClassUnlocked();
		data["ex_gauge"] = MOHDLLIJELH.GGBNNMCLDMO_GetExPoint();
		data["ex_gauge_max"] = MOHDLLIJELH.AMDOCOMNNKN_GetExGaugePoinMax();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HHGEPDNBGAI_37, data, false);
	}

	// // RVA: 0x90A79C Offset: 0x90A79C VA: 0x90A79C
	public void PMHLIBHEBBB(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP, HAEDCCLHEMN_EventBattle MOHDLLIJELH)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, MDADLCOCEBN, KALCJMLIAOK, CBHACAOCJGP);
		if(json != null)
		{
			json["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
			json["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
			json["start_pt"] = MOHDLLIJELH.FBGDBGKNKOD_GetCurrentPoint();
			json["start_ranking"] = MOHDLLIJELH.CDINKAANIAA_Rank[0];
			json["enemy_info_id"] = MOHDLLIJELH.PIPHAKNMIBL_Rivals[MOHDLLIJELH.DPPODNCOMIA_GetRivalIdx()].BHCIFFILAKJ_Str + 1;
			json["boost_ratio"] = MOHDLLIJELH.HADLPHIMBHH_BoostRatio;
			HADLOAPLCAF(json, OMNOFMEBLAD, MOHDLLIJELH);
			json["is_ex_battle"] = (MOHDLLIJELH.PIPHAKNMIBL_Rivals[MOHDLLIJELH.DPPODNCOMIA_GetRivalIdx()].BHCIFFILAKJ_Str > 2) ? 1 : 0;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.PMHLIBHEBBB_38, json, false);
		}
	}

	// // RVA: 0x90AC64 Offset: 0x90AC64 VA: 0x90AC64
	public void FEIOPIIEIKB(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, HAEDCCLHEMN_EventBattle MOHDLLIJELH)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, MDADLCOCEBN);
		if(json != null)
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String);
			json["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
			json["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
			long v1 = MOHDLLIJELH.FBGDBGKNKOD_GetCurrentPoint();
			HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ d = MOHDLLIJELH.PIPHAKNMIBL_Rivals[MOHDLLIJELH.DPPODNCOMIA_GetRivalIdx()];
			if(d != null)
			{
				json["enemey_score"] = d.KNIFCANOHOC_Score;
				JBBHNIACMFJ.Length = 0;
				JBBHNIACMFJ.AppendFormat("PERFECT:{0},", d.MJNMPAKBNKB_NotesResult[4].ToString());
				JBBHNIACMFJ.AppendFormat("GREAT:{0},", d.MJNMPAKBNKB_NotesResult[3].ToString());
				JBBHNIACMFJ.AppendFormat("GOOD:{0},", d.MJNMPAKBNKB_NotesResult[2].ToString());
				JBBHNIACMFJ.AppendFormat("BAD:{0},", d.MJNMPAKBNKB_NotesResult[1].ToString());
				JBBHNIACMFJ.AppendFormat("MISS:{0},", d.MJNMPAKBNKB_NotesResult[0].ToString());
				json["enemy_notes_judge"] = JBBHNIACMFJ.ToString();
				if(IJAOGPFKDBP.HBODCMLFDOB_Result == 1)
				{
					json["battle_result"] = MOHDLLIJELH.IHDPLPHLCPA.BLAJKMAPEKP_CWin > 0 ? 1 : 0;
					json["battle_pt"] = MOHDLLIJELH.IHDPLPHLCPA.FPEOGFMKMKJ_Point;
					json["score_pt"] = MOHDLLIJELH.IHDPLPHLCPA.GBLHPHCAPLG_ScoreBonus;
					json["win_series_bonus"] = MOHDLLIJELH.IHDPLPHLCPA.APEFEONDBKL_DiffBonus;
					json["get_pt"] = MOHDLLIJELH.IHDPLPHLCPA.PIIEGNPOPJI_Point;
					v1 += MOHDLLIJELH.IHDPLPHLCPA.PIIEGNPOPJI_Point;
				}
				else
				{
					json["battle_result"] = 0;
					json["battle_pt"] = 0;
					json["score_pt"] = 0;
					json["win_series_bonus"] = 0;
					json["get_pt"] = 0;
				}
			}
			else
			{
				json["get_pt"] = 0;
			}
			json["end_pt"] = v1;
			json["get_ex_gauge"] = MOHDLLIJELH.IHDPLPHLCPA.MBBPOOFCAKC_GetExGauge;
			json["end_ex_gauge"] = MOHDLLIJELH.IHDPLPHLCPA.CINCDFAOEOJ_NewExPoint;
			json["appear_ex_rival"] = MOHDLLIJELH.IHDPLPHLCPA.EGAMOPBCFKG_ExRival ? 1 : 0;
			if(d != null)
			{
				json["ex_battle_music_score"] = MOHDLLIJELH.IHDPLPHLCPA.OOEKGFAIFPK_ExBattleMusicScore;
				json["ex_battle_music_high_score"] = MOHDLLIJELH.IHDPLPHLCPA.JCCABPBHJPA_ExHighScore;
				json["ex_battle_win_bonus"] = MOHDLLIJELH.IHDPLPHLCPA.KOOMDFGADKH_ExBattleWinBonus;
				json["ex_battle_score_total_bf"] = MOHDLLIJELH.IHDPLPHLCPA.NHNEMDAFPMJ_ExBattleScoreTotalBefore;
				json["ex_battle_score_total_af"] = MOHDLLIJELH.IHDPLPHLCPA.IGIPKOJJIIA_ExBattleScoreTotalAfter;
				JBBHNIACMFJ.Length = 0;
				JBBHNIACMFJ.Append(MOHDLLIJELH.IHDPLPHLCPA.HDIEPNLNABL_ExBattleScoreBefore[0]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(MOHDLLIJELH.IHDPLPHLCPA.HDIEPNLNABL_ExBattleScoreBefore[1]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(MOHDLLIJELH.IHDPLPHLCPA.HDIEPNLNABL_ExBattleScoreBefore[2]);
				json["ex_battle_score_bf"] = JBBHNIACMFJ.ToString();
				JBBHNIACMFJ.Length = 0;
				JBBHNIACMFJ.Append(MOHDLLIJELH.IHDPLPHLCPA.OEGDACKEDIB_ExBattleScoreAfter[0]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(MOHDLLIJELH.IHDPLPHLCPA.OEGDACKEDIB_ExBattleScoreAfter[1]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(MOHDLLIJELH.IHDPLPHLCPA.OEGDACKEDIB_ExBattleScoreAfter[2]);
				json["ex_battle_score_af"] = JBBHNIACMFJ.ToString();
				json["unlocked_class_bf"] = MOHDLLIJELH.IHDPLPHLCPA.EDJJIBAGFHL_UnlockedClassBefore;
				json["unlocked_class_af"] = MOHDLLIJELH.IHDPLPHLCPA.GBIGCJIKKPP_UnlockedClassAfter;
			}
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.FEIOPIIEIKB_39, json, false);
		}
	}

	// // RVA: 0x90BF58 Offset: 0x90BF58 VA: 0x90BF58
	public void EAGAKGNNINL(int OPKCNBFBBKP, string OPFGFINHFCE, string HJLDBEJOMIO)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["banner_id"] = OPKCNBFBBKP;
		json["banner_name"] = OPFGFINHFCE;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.EAGAKGNNINL_40, json, false);
	}

	// // RVA: 0x907BF4 Offset: 0x907BF4 VA: 0x907BF4
	private void HADLOAPLCAF(EDOHBJAPLPF_JsonData IDLHJIOMJBK, JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, IKDICBBFBMI_EventBase MOHDLLIJELH)
	{
		int v1 = 0;
		int v2 = 0;
		FFHPBEPOMAK_DivaInfo diva = OMNOFMEBLAD.GNLFLDMNBGG_FrienDiva;
		if(diva != null)
		{
			v2 = diva.FGFIBOBAPIA_SceneId;
			v1 = diva.AICGALGPFMO_NumBoard;
		}
		List<IKDICBBFBMI_EventBase.GNPOABJANKO> l = MOHDLLIJELH.LMDENICBIIB_GetEpisodesBonusList(v2, v1);
		JBBHNIACMFJ.Length = 0;
		bool b1 = false;
		int v3 = 0;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].JKDJCFEBDHC)
			{
				if(b1)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(l[i].KELFCMEOPPM_EpisodeId);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(l[i].HEDODOBGPPM_BonusValue);
				b1 = true;
				v3 += l[i].HEDODOBGPPM_BonusValue;
			}
		}
		IDLHJIOMJBK["epi_bonus"] = Mathf.Min(999, v3);
		IDLHJIOMJBK["epi_bonus_info"] = JBBHNIACMFJ.ToString();
	}

	// // RVA: 0x90C240 Offset: 0x90C240 VA: 0x90C240
	public void NJEIHFPKOMG_SendServerSaveLoadInfo(int HBODCMLFDOB, int EJJNDLJIIIF, string EFBLONMFDCB)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["result"] = HBODCMLFDOB;
		json["error_code"] = EJJNDLJIIIF;
		json["parse_result"] = EFBLONMFDCB;
		json["system_memory_size"] = SystemInfo.systemMemorySize;
		json["graphic_device_name"] = SystemInfo.graphicsDeviceName;
		json["processor_type"] = SystemInfo.processorType;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.NJEIHFPKOMG_ServerSaveLoadInfo/*36*/, json, false);
	}

	// // RVA: 0x90C664 Offset: 0x90C664 VA: 0x90C664
	public void EEOLHMGNJGO(int JGJPKLCCOIO, int OBLKLLDGOEJ, int MJBODMOLOBC, int GLCLFMGPMAN, int LJKMKCOAICL, int PFDFGDPLLCK, int EDKMIKFEEJI, int LCKLPIDPDIE)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(GLCLFMGPMAN);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(LJKMKCOAICL);
		json["scene_id"] = JGJPKLCCOIO;
		json["base_rarity"] = OBLKLLDGOEJ;
		json["luck"] = MJBODMOLOBC;
		json["item_info"] = JBBHNIACMFJ.ToString();
		json["money"] = PFDFGDPLLCK;
		json["limit_over_level_bf"] = EDKMIKFEEJI;
		json["limit_over_level_af"] = LCKLPIDPDIE;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.EEOLHMGNJGO_41, json, false);
	}

	// // RVA: 0x90CBA4 Offset: 0x90CBA4 VA: 0x90CBA4
	// public void JNHOIANJAOP(KPJHLACKGJF MOHDLLIJELH) { }

	// // RVA: 0x90D72C Offset: 0x90D72C VA: 0x90D72C
	// public void HPFKEJGCDKN(KPJHLACKGJF MOHDLLIJELH) { }

	// // RVA: 0x90DADC Offset: 0x90DADC VA: 0x90DADC
	// public void FJIGNIDBFMM(KPJHLACKGJF MOHDLLIJELH) { }

	// // RVA: 0x90DFBC Offset: 0x90DFBC VA: 0x90DFBC
	// public void NIPOGLOEMCN(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP, KPJHLACKGJF MOHDLLIJELH) { }

	// // RVA: 0x90E690 Offset: 0x90E690 VA: 0x90E690
	// public void FEMJIFOMOCL(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, KPJHLACKGJF MOHDLLIJELH) { }

	// // RVA: 0x90F0FC Offset: 0x90F0FC VA: 0x90F0FC
	public void IENGPDCDMBM(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int JPLMIPNGKEA, int AIMGOGFLILF)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KEODKEGFDLD_FreeMusicInfo mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		json["session_id"] = MDADLCOCEBN;
		json["free_music_id"] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
		json["music_id"] = mData.DLAEJOBELBH_MusicId;
		if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_Difficulty;
		else
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_Difficulty + 10;
		switch(GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.DDHCLNFPNGK_RenderQuality)
		{
			case 0:
				json["mode"] = JpStringLiterals.StringLiteral_11136;
			break;
			case 1:
				json["mode"] = JpStringLiterals.StringLiteral_11137;
			break;
			case 2:
				json["mode"] = "2D";
			break;
			case 3:
				json["mode"] = JpStringLiterals.StringLiteral_11139;
			break;
		}
		json["mv_char_id"] = Database.Instance.gameSetup.teamInfo.divaList[0].prismDivaId;
        LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(Database.Instance.gameSetup.teamInfo.divaList[0].prismDivaId, Database.Instance.gameSetup.teamInfo.divaList[0].prismCostumeModelId);
		if(cos == null)
		{
			json["mv_char_cos"] = 0;
		}
		else
		{
			json["mv_char_cos"] = cos.JPIDIENBGKH_CostumeId;
		}
		json["mv_valkyrie_id"] = Database.Instance.gameSetup.teamInfo.valkyrieId;
		json["remain_mv_ticket"] = JPLMIPNGKEA;
		json["use_mv_ticket"] = AIMGOGFLILF;
		json["notes_speed"] = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DGCDPGPAAII_GetNotesSpeed((Difficulty.Type)OMNOFMEBLAD.AKNELONELJK_Difficulty, false);
        NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting team = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GHDDPJBBEOC_Prism.GCINIJEMHFK_GetTeamForSong(mData.DLAEJOBELBH_MusicId);
        json["notes_disp"] = team.NLFMKOJHAHJ_ShowNotes;
		if(team.MKKGKKHABEK_ValkyrieMode == 0)
		{
			json["valkyrie_mode"] = JpStringLiterals.StringLiteral_11167;
		}
		else
		{
			json["valkyrie_mode"] = JpStringLiterals.StringLiteral_11168;
		}
		if(team.JPBJOGBGKGA_DivaMode == 0)
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11167;
		}
		else
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11171;
		}
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(team.OCAMDLMPBGA_SelectedDivaSoloId == 0 ? 1 : 0);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(team.PGCEGEJOOON_SelectedCostumeSoloId == 0 ? 1 : 0);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(team.EPDPAHNLMKH_SelectedValkyrieSoloId == 0 ? 1 : 0);
		json["mv_setting"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.IENGPDCDMBM/*45*/, json, false);
    }

	// // RVA: 0x910540 Offset: 0x910540 VA: 0x910540
	public void GDHNBIIOKMF(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KEODKEGFDLD_FreeMusicInfo mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		json["session_id"] = MDADLCOCEBN;
		json["free_music_id"] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
		json["music_id"] = mData.DLAEJOBELBH_MusicId;
		if(IJAOGPFKDBP.LIDKENJKLGA_IsLine6 == 0)
		{
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_Difficulty;
		}
		else
		{
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_Difficulty + 10;
		}
		json["result"] = IJAOGPFKDBP.HBODCMLFDOB_Result;
		json["start_t"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(IJAOGPFKDBP.ICJEDACBMMF_ServerTime));
		if(IJAOGPFKDBP.IMIEPNOECFD_HasValkyrieMode == 0)
		{
			json["valkyrie_mode"] = JpStringLiterals.StringLiteral_11167;
		}
		else
		{
			json["valkyrie_mode"] = JpStringLiterals.StringLiteral_11168;
		}
		if(IJAOGPFKDBP.GFODFMFGLJG_HadDivaMode == 0)
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11167;
		}
		else if(IJAOGPFKDBP.GFODFMFGLJG_HadDivaMode == 1)
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11170;
		}
		else
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11171;
		}
		json["ave_fps"] = IJAOGPFKDBP.LMOBPKIDIHF_AverageFps;
		json["low_fps"] = IJAOGPFKDBP.IPAAOFCGEAB_MinFps;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.GDHNBIIOKMF/*46*/, json, false);
	}

	// // RVA: 0x910ECC Offset: 0x910ECC VA: 0x910ECC
	public void GADJDBJLIGC(int LKNCHJCLLFN, string OJBLOEBPHIE, string GGPGIALKGFG)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["music_id"] = LKNCHJCLLFN;
		json["movie_name"] = OJBLOEBPHIE;
		json["movie_url"] = GGPGIALKGFG;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.GADJDBJLIGC_47, json, false);
	}

	// // RVA: 0x911200 Offset: 0x911200 VA: 0x911200
	public void DBNECDJCNOI(int DLLJMINACDN_ShopId, string GEGCFOCMEKD_ShopName, int FNNGLNPIKOL_LineupId, int DJJGPACGEMM_ProductId, int IPJBPBDCCPF_ConsumeItemId, int HABCGPMKBJK_ConsumItemCount, int PEKOLGMLJAL_AfterConsumeItemCount, int BGHCIAOANCF_BuyItemId, int GJNAOBBAPOF_BuyItemCount, int FFBPGKHIKGD_AfterBuyItemCount, int KMFLNILNPJD_BuyCount, int JPLLMKIDNBM_BuyCountTotal, int HMFDJHEEGNN_BuyLimit, long DECPPKAAHFA_BuyLimitDate, int NFBLLKHBMEK_SakashoProductId, string DJPBDDBNMLN_SakashoProductName)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["shop_id"] = DLLJMINACDN_ShopId;
		json["shop_name"] = GEGCFOCMEKD_ShopName;
		json["lineup_id"] = FNNGLNPIKOL_LineupId;
		json["product_id"] = DJJGPACGEMM_ProductId;
		json["consume_item_id"] = IPJBPBDCCPF_ConsumeItemId;
		json["consume_item_count"] = HABCGPMKBJK_ConsumItemCount;
		json["consume_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(IPJBPBDCCPF_ConsumeItemId);
		json["af_consume_item_count"] = PEKOLGMLJAL_AfterConsumeItemCount;
		json["buy_item_id"] = BGHCIAOANCF_BuyItemId;
		json["buy_item_count"] = GJNAOBBAPOF_BuyItemCount;
		json["buy_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(BGHCIAOANCF_BuyItemId);
		json["af_buy_item_count"] = FFBPGKHIKGD_AfterBuyItemCount;
		json["buy_count"] = KMFLNILNPJD_BuyCount;
		json["buy_count_total"] = JPLLMKIDNBM_BuyCountTotal;
		json["buy_limit"] = HMFDJHEEGNN_BuyLimit;
		json["sakasho_product_id"] = NFBLLKHBMEK_SakashoProductId;
		json["sakasho_product_name"] = DJPBDDBNMLN_SakashoProductName;
		if(DECPPKAAHFA_BuyLimitDate == 0)
		{
			json["buy_limit_date"] = "3000-01-01 00:00:00";
		}
		else
		{
			json["buy_limit_date"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(DECPPKAAHFA_BuyLimitDate));
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.DBNECDJCNOI_48, json, false);
	}

	// // RVA: 0x911BA4 Offset: 0x911BA4 VA: 0x911BA4
	public void CBKENDJIBDM(string JKJDGDLAIME, int LKNCHJCLLFN, int KAAENFOCPLN, int[] OCJACPIJCBL, int[] POEMOGPOGPN, int BBNEDFIJFEN, int GGPDPDMODPL, int[] KJEHAHAKGDE, int[] OKIMFNNDGGP, int FEFHFFGBOEM)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["music_id"] = LKNCHJCLLFN;
		json["place"] = JKJDGDLAIME;
		json["bf_enable"] = KAAENFOCPLN;
		json["af_enable"] = GGPDPDMODPL;
		json["bf_diva_id"] = OCJACPIJCBL[0];
		json["bf_diva_id2"] = OCJACPIJCBL[1];
		json["bf_diva_id3"] = OCJACPIJCBL[2];
		json["af_diva_id"] = KJEHAHAKGDE[0];
		json["af_diva_id2"] = KJEHAHAKGDE[1];
		json["af_diva_id3"] = KJEHAHAKGDE[2];
		json["bf_valkyrie_id"] = BBNEDFIJFEN;
		json["af_valkyrie_id"] = FEFHFFGBOEM;
		json["bf_costume_id"] = POEMOGPOGPN[0];
		json["bf_costume_id2"] = POEMOGPOGPN[1];
		json["bf_costume_id3"] = POEMOGPOGPN[2];
		json["af_costume_id"] = OKIMFNNDGGP[0];
		json["af_costume_id2"] = OKIMFNNDGGP[1];
		json["af_costume_id3"] = OKIMFNNDGGP[2];
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.CBKENDJIBDM, json, false);
	}

	// // RVA: 0x91251C Offset: 0x91251C VA: 0x91251C
	// public void LIPHGGFEJFJ(int IMMDGJAOPCD, int HMFFHLPNMPH, int EIILNOEOICO, int COJALPJKKDL, int JGGKJBCGKCC, int KJMLLBDLKCG, int GDAGHLJDKGK, CHHECNJBMLA MOHDLLIJELH) { }

	// // RVA: 0x912DAC Offset: 0x912DAC VA: 0x912DAC
	public void LCDPEMIFNKJ(int GLCLFMGPMAN, int MBJIFDBEDAC)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["remove_item_id"] = GLCLFMGPMAN;
		json["remove_item_num"] = MBJIFDBEDAC;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.LCDPEMIFNKJ_51, json, false);
	}

	// // RVA: 0x913094 Offset: 0x913094 VA: 0x913094
	public void ICAHGJMMGLM(string KMDDJIEPNMF)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_session_id"] = KMDDJIEPNMF;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.ICAHGJMMGLM_52, json, false);
	}

	// // RVA: 0x913330 Offset: 0x913330 VA: 0x913330
	public void BGJDJBOCLEA(string KMDDJIEPNMF, int HBODCMLFDOB, string OHLHAIIBLBI)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_session_id"] = KMDDJIEPNMF;
		json["result"] = HBODCMLFDOB;
		json["failure_reason"] = OHLHAIIBLBI;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.BGJDJBOCLEA_53, json, false);
	}

	// // RVA: 0x913664 Offset: 0x913664 VA: 0x913664
	public void ILLBGAFIBDE(string KMDDJIEPNMF, int FJABGCFCPMH, string INAMDCCEBOH, string FNOBKBIFBJG, bool NDODFAPMMEB)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_marker_no"] = FJABGCFCPMH;
		json["ar_session_id"] = KMDDJIEPNMF;
		json["ar_event_id"] = INAMDCCEBOH;
		json["ar_marker_id"] = FNOBKBIFBJG;
		json["is_new_marker"] = NDODFAPMMEB;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.ILLBGAFIBDE_54, json, false);
	}

	// // RVA: 0x913A60 Offset: 0x913A60 VA: 0x913A60
	public void KIFPDEFNEPB(string KMDDJIEPNMF, int FJABGCFCPMH, string INAMDCCEBOH, string FNOBKBIFBJG)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_marker_no"] = FJABGCFCPMH;
		json["ar_session_id"] = KMDDJIEPNMF;
		json["ar_event_id"] = INAMDCCEBOH;
		json["ar_marker_id"] = FNOBKBIFBJG;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.KIFPDEFNEPB_55, json, false);
	}

	// // RVA: 0x913DE0 Offset: 0x913DE0 VA: 0x913DE0
	public void PHLHLIDCNNN(string KMDDJIEPNMF, int FJABGCFCPMH, string INAMDCCEBOH, string FNOBKBIFBJG)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_marker_no"] = FJABGCFCPMH;
		json["ar_session_id"] = KMDDJIEPNMF;
		json["ar_event_id"] = INAMDCCEBOH;
		json["ar_marker_id"] = FNOBKBIFBJG;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.PHLHLIDCNNN_56, json, false);
	}

	// // RVA: 0x914160 Offset: 0x914160 VA: 0x914160
	public void DNNLEIKNHKL(int DIPKCALNIII, int NHCCINMHEAB, int GOKMANFHFPC, int HHAMIAPINGE, int MJKGDEOKFNK, int NCMCPNPOLEB, string JKJDGDLAIME, int CMJHOGBIOKM, int ADIFCNPMKJH, int DMMKFOLEGKO, int PMJKECBJBGP)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["diva_id"] = DIPKCALNIII;
		json["tension"] = NHCCINMHEAB;
		json["get_exp"] = GOKMANFHFPC;
		json["af_exp"] = HHAMIAPINGE;
		json["bf_lv"] = MJKGDEOKFNK;
		json["af_lv"] = NCMCPNPOLEB;
		json["place"] = JKJDGDLAIME;
		json["present_item_info"] = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, CMJHOGBIOKM) + ":" + ADIFCNPMKJH;
		json["favorite_bonus"] = DMMKFOLEGKO;
		json["tension_bonus"] = PMJKECBJBGP;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.DNNLEIKNHKL_57, json, false);
	}

	// // RVA: 0x914720 Offset: 0x914720 VA: 0x914720
	// public void CDNFJBAJAMM(CANAFALMGLI MOHDLLIJELH, int JBEFLJENKAC) { }

	// // RVA: 0x914ABC Offset: 0x914ABC VA: 0x914ABC
	// public void BLDDKDNOCFA(CANAFALMGLI MOHDLLIJELH, string EBAMGNMELPO, string HBODCMLFDOB) { }

	// // RVA: 0x914E50 Offset: 0x914E50 VA: 0x914E50
	public void DADNPOJNIBL(IKDICBBFBMI_EventBase MOHDLLIJELH)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
		json["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.DADNPOJNIBL_60, json, false);
	}

	// // RVA: 0x91514C Offset: 0x91514C VA: 0x91514C
	public void LIIJEGOIKDP(int FMJECOKINMO, OAGBCBBHMPF.DKAMMIHBINF JKJDGDLAIME)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["adventure_id"] = FMJECOKINMO;
		json["place"] = OAGBCBBHMPF.BHKNBCJGBDG[(int)JKJDGDLAIME];
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.LIIJEGOIKDP/*61*/, json, false);
	}

	// // RVA: 0x9154B4 Offset: 0x9154B4 VA: 0x9154B4
	public void BKLNHBHDDEJ(string INDDJNMPONH)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["type"] = INDDJNMPONH;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.BKLNHBHDDEJ_63, json, false);
	}

	// // RVA: 0x915750 Offset: 0x915750 VA: 0x915750
	public void DAGHKCKEJPA(BOPFPIHGJMD.MLBMHDCCGHI ODMEBOKPNAF, int AAKPLIFKIJK)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["type"] = (int)ODMEBOKPNAF;
		json["operation_id"] = AAKPLIFKIJK;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.DAGHKCKEJPA_64, json, false);
	}

	// // RVA: 0x915A38 Offset: 0x915A38 VA: 0x915A38
	public void OEGCKACJMPM(BOPFPIHGJMD.MLBMHDCCGHI ODMEBOKPNAF, int AAKPLIFKIJK)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(ODMEBOKPNAF, AAKPLIFKIJK);
        OCMJNBIFJNM_Offer.JPOHOLBBFGP of2 = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(ODMEBOKPNAF, AAKPLIFKIJK);
        json["session_id"] = of2.BDJMFDKLHPM_SessionId;
		json["type"] = (int)ODMEBOKPNAF;
		json["operation_id"] = AAKPLIFKIJK;
		JBBHNIACMFJ.Length = 0;
		OCMJNBIFJNM_Offer.PMOECIDOLNA of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[of2.OIOECMEEFKJ_VFp - 1];
		bool b = false;
		int cnt = 0;
		for(int i = 0; i < 3; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(of.LBCCCKNANMJ_GetValkyrieId(i));
			if(of.LBCCCKNANMJ_GetValkyrieId(i) != 0)
				cnt++;
			b = true;
		}
		json["use_vf_id"] = JBBHNIACMFJ.ToString();
		json["use_vf_num"] = cnt;
		json["use_vf_form"] = of2.MNCEBKHBBEF_VFform;
		json["vfp_id"] = of2.OIOECMEEFKJ_VFp;
		json["vfp_name"] = of.OPFGFINHFCE_Name;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.OEGCKACJMPM_65, json, false);
	}

	// // RVA: 0x9162E0 Offset: 0x9162E0 VA: 0x9162E0
	public void ONPIDKLOPIP(BOPFPIHGJMD.MLBMHDCCGHI ODMEBOKPNAF, int AAKPLIFKIJK, int KMPBAKBKEGH)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(ODMEBOKPNAF, AAKPLIFKIJK);
		json["session_id"] = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(ODMEBOKPNAF, AAKPLIFKIJK).BDJMFDKLHPM_SessionId;
		json["type"] = (int)ODMEBOKPNAF;
		json["operation_id"] = AAKPLIFKIJK;
		json["result_type"] = KMPBAKBKEGH;
		if(KMPBAKBKEGH == 0)
		{
			json["drop_info"] = "";
		}
		else
		{
			JBBHNIACMFJ.Length = 0;
			bool b = false;
			for(int i = 0; i < KDHGBOOECKC.HHCJCDFCLOB.IKENGGJIJJO().BHKKEJJMMDD.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(KDHGBOOECKC.HHCJCDFCLOB.IKENGGJIJJO().BHKKEJJMMDD[i].PPFNGGCBJKC_Id);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(KDHGBOOECKC.HHCJCDFCLOB.IKENGGJIJJO().BHKKEJJMMDD[i].BFINGCJHOHI_Cnt);
				b = true;
			}
			json["drop_info"] = JBBHNIACMFJ.ToString();
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.ONPIDKLOPIP_66, json, false);
	}

	// // RVA: 0x916A08 Offset: 0x916A08 VA: 0x916A08
	public void BABLKKLEPGD(int BEEAIAAJOHD, int MMEIOJKLCKK, int PNMKPKMDOND, int FCJLPINNDKN, int KJDKJGGHHIF, int GLCLFMGPMAN, int CLLKANEGGBJ, int NEMMJLNMEHB)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["costume_id"] = BEEAIAAJOHD;
		json["bf_main_lv"] = MMEIOJKLCKK;
		json["af_main_lv"] = PNMKPKMDOND;
		json["bf_pt"] = FCJLPINNDKN;
		json["af_pt"] = KJDKJGGHHIF;
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(GLCLFMGPMAN);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(CLLKANEGGBJ);
		json["item_info"] = JBBHNIACMFJ.ToString();
		json["money"] = NEMMJLNMEHB;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.BABLKKLEPGD_67, json, false);
	}

	// // RVA: 0x916F48 Offset: 0x916F48 VA: 0x916F48
	public void PLEKHHPMELF(int GOIKCKHMBDL, int JGGKJBCGKCC, int MKNKJMFILFB)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["af"] = MKNKJMFILFB;
		json["use_item_id"] = JGGKJBCGKCC;
		json["heal_music_id"] = GOIKCKHMBDL;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.PLEKHHPMELF_68, json, false);
	}

	// // RVA: 0x91727C Offset: 0x91727C VA: 0x91727C
	public void LPKDNOINDPE(long CBJBEGPLJDO, long LPHAOMAKKNF, long FDAEDIPOONF, long PCHNPJFFJJM, long CPFDDHIEODD, long LCNMPBBDGPJ, long BMHKJPHNCIJ, long KMJCPOGCJDG, long PPKCOLEJLLG, long BGOLKLJBAHD, OAGBCBBHMPF.NALHDBIKFJO GAFIOALKHIM, OAGBCBBHMPF.NALHDBIKFJO PMKOEGJAEDN, string EEMFGMEEBDC, string NJFKGJKINAG, int IHJMMPHPHEM, string EJJNDLJIIIF)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["raw_started_at"] = COPGJHJGHJG_TimestampToString(CBJBEGPLJDO);
		json["raw_expired_at"] = COPGJHJGHJG_TimestampToString(LPHAOMAKKNF);
		json["google_started_at"] = COPGJHJGHJG_TimestampToString(FDAEDIPOONF);
		json["google_expired_at"] = COPGJHJGHJG_TimestampToString(PCHNPJFFJJM);
		json["apple_started_at"] = COPGJHJGHJG_TimestampToString(CPFDDHIEODD);
		json["apple_expired_at"] = COPGJHJGHJG_TimestampToString(LCNMPBBDGPJ);
		json["bf_started_at"] = COPGJHJGHJG_TimestampToString(BMHKJPHNCIJ);
		json["af_started_at"] = COPGJHJGHJG_TimestampToString(PPKCOLEJLLG);
		json["bf_expired_at"] = COPGJHJGHJG_TimestampToString(KMJCPOGCJDG);
		json["af_expired_at"] = COPGJHJGHJG_TimestampToString(BGOLKLJBAHD);
		json["bf_status"] = (int)GAFIOALKHIM;
		json["af_status"] = (int)PMKOEGJAEDN;
		json["bf_platform"] = EEMFGMEEBDC;
		json["af_platform"] = NJFKGJKINAG;
		json["api_call_time"] = IHJMMPHPHEM;
		json["error_code"] = EJJNDLJIIIF;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.LPKDNOINDPE_62, json, false);
	}

	// // RVA: 0x917AB4 Offset: 0x917AB4 VA: 0x917AB4
	public void FJBCAHAFLNO()
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.FJBCAHAFLNO_69, json, false);
	}

	// // RVA: 0x917CD8 Offset: 0x917CD8 VA: 0x917CD8
	public void FDFMKBGPALI(BOPFPIHGJMD.MLBMHDCCGHI ODMEBOKPNAF, int AAKPLIFKIJK, int GLCLFMGPMAN, int CLLKANEGGBJ, int PJIOJCFCFOK, int BIKHKIGMEMA)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(ODMEBOKPNAF, AAKPLIFKIJK);
		json["session_id"] = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(ODMEBOKPNAF, AAKPLIFKIJK).BDJMFDKLHPM_SessionId;
		json["type"] = (int)ODMEBOKPNAF;
		json["operation_id"] = AAKPLIFKIJK;
		json["use_item_id"] = GLCLFMGPMAN;
		json["use_item_num"] = CLLKANEGGBJ;
		json["af_item_num"] = PJIOJCFCFOK;
		json["rest_time"] = BIKHKIGMEMA;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.FDFMKBGPALI_70, json, false);
	}

	// // RVA: 0x9181C4 Offset: 0x9181C4 VA: 0x9181C4
	// public void PHCLHGPCFNL(NKOBMDPHNGP MOHDLLIJELH, int OIDBPKAKOJA, int MEBHCFJCKFE, string FMGBPEHHJEA, int CJHEHIMLGGL, int AHGJCJFOMIP, string AMMJLEOFFDO) { }

	// // RVA: 0x918694 Offset: 0x918694 VA: 0x918694
	// public void NJMBKGKPCKL() { }

	// // RVA: 0x918698 Offset: 0x918698 VA: 0x918698
	// public void PEBDGCDNPDM(NKOBMDPHNGP MOHDLLIJELH, string INDDJNMPONH) { }

	// // RVA: 0x9189E0 Offset: 0x9189E0 VA: 0x9189E0
	// public void LHCHBHPHLCP() { }

	// // RVA: 0x9189E4 Offset: 0x9189E4 VA: 0x9189E4
	// public void OOBKCHBNAOF() { }

	// // RVA: 0x9189E8 Offset: 0x9189E8 VA: 0x9189E8
	// private void HBOONEFDMJL(EDOHBJAPLPF_JsonData IDLHJIOMJBK, PKNOKJNLPOE.MJFMOPMOFDJ GJFJLEOGFLD) { }

	// // RVA: 0x919268 Offset: 0x919268 VA: 0x919268
	// public void LOGBJCFCJND(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP, PKNOKJNLPOE MOHDLLIJELH) { }

	// // RVA: 0x919FE4 Offset: 0x919FE4 VA: 0x919FE4
	// public void FIPDFLHPNDO(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, PKNOKJNLPOE MOHDLLIJELH) { }

	// // RVA: 0x91A6B0 Offset: 0x91A6B0 VA: 0x91A6B0
	// public void KCCMKAEPGPE(PKNOKJNLPOE MOHDLLIJELH, int JGGKJBCGKCC, int KJMLLBDLKCG, int NMANGFCHCFB) { }

	// // RVA: 0x91ABC4 Offset: 0x91ABC4 VA: 0x91ABC4
	// public void ONMOONKHHLO(PKNOKJNLPOE MOHDLLIJELH, PKNOKJNLPOE.MJFMOPMOFDJ GJFJLEOGFLD) { }

	// // RVA: 0x91B040 Offset: 0x91B040 VA: 0x91B040
	// public void BACAKFPEMAF(PKNOKJNLPOE MOHDLLIJELH, bool PJJLOFMLOMN, bool MCMPOEHAIHP, List<PKNOKJNLPOE.ECICDAPCMJG> MOCDACANBIG) { }

	// // RVA: 0x91B758 Offset: 0x91B758 VA: 0x91B758
	// public void ICDCMLKMEHI(int APJBBOHHFNE, int MKNKJMFILFB, int GLCLFMGPMAN, int ECEKFEFOFNI, string JKJDGDLAIME) { }

	// // RVA: 0x91BB28 Offset: 0x91BB28 VA: 0x91BB28
	// public void EEHEMNBJPAP(PKNOKJNLPOE MOHDLLIJELH, JLOGEHCIBEJ.JJAFLOEBLDH CFLEMFADGLG, int AFFGGBLNPFJ, int EENFAGBJHPP, SakashoRaidbossEffectData NKDGDKKEPOO, JPPCMHKHAGC.ODNJNIICCLB HFBEDHKIBJA, string MDADLCOCEBN) { }

	// // RVA: 0x91C368 Offset: 0x91C368 VA: 0x91C368
	// public void HONFKODFAPA(PKNOKJNLPOE MOHDLLIJELH, PKNOKJNLPOE.MJFMOPMOFDJ GJFJLEOGFLD, PKNOKJNLPOE.KJJDLBFDGDM KONJMFICNJJ) { }

	// // RVA: 0x91CF90 Offset: 0x91CF90 VA: 0x91CF90
	public void DNJGGCJPIMC(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string MDADLCOCEBN, int KALCJMLIAOK, int CBHACAOCJGP, MANPIONIGNO_EventGoDiva MOHDLLIJELH)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, MDADLCOCEBN, KALCJMLIAOK, CBHACAOCJGP);
		if(json != null)
		{
			json["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
			json["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
			json["fever_time"] = COPGJHJGHJG_TimestampToString(Database.Instance.gameSetup.musicInfo.setupTime);
			JBBHNIACMFJ.Length = 0;
			MANPIONIGNO_EventGoDiva.IBNAEKMCIEO ib = MOHDLLIJELH.NLPCPFCIDLM(MOHDLLIJELH.CMCEGEKGEEP.KPEKOOCPKID_BonusId, MOHDLLIJELH.CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily);
			if(ib != null)
			{
				JBBHNIACMFJ.Append(ib.PPFNGGCBJKC);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.CGHNCPEKOCK);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.NOEFINFEMBM);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.PKDAEFIGMLI);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.DGAELGEJPNA);
			}
			json["start_pt"] = MOHDLLIJELH.FBGDBGKNKOD_GetCurrentPoint();
			json["bonus_info"] = JBBHNIACMFJ.ToString();
			HADLOAPLCAF(json, OMNOFMEBLAD, MOHDLLIJELH);
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.DNJGGCJPIMC_96, json, false);
		}
	}

	// // RVA: 0x91D638 Offset: 0x91D638 VA: 0x91D638
	public void HPNIJDCPCNC(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, MANPIONIGNO_EventGoDiva MOHDLLIJELH)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, MDADLCOCEBN);
		if(json != null)
		{
			json["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
			json["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
			json["bonus_id"] = MOHDLLIJELH.CMCEGEKGEEP.KPEKOOCPKID_BonusId;
			json["bonus_ratio0"] = MOHDLLIJELH.CMCEGEKGEEP.AONOCELOCLL_BonusMusicProbaBefore;
			json["bonus_ratio"] = MOHDLLIJELH.CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter;
			json["soul_lv"] = MOHDLLIJELH.CMCEGEKGEEP.MKMIEGPOKGG_Soul.GLFIELJJDCI_Level;
			json["voice_lv"] = MOHDLLIJELH.CMCEGEKGEEP.EACDINDLGLF_Voice.GLFIELJJDCI_Level;
			json["charm_lv"] = MOHDLLIJELH.CMCEGEKGEEP.LDLHPACIIAB_Charm.GLFIELJJDCI_Level;
			json["soul_alv"] = MOHDLLIJELH.CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_AfterLevel;
			json["voice_alv"] = MOHDLLIJELH.CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_AfterLevel;
			json["charm_alv"] = MOHDLLIJELH.CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_AfterLevel;
			json["soul_exp"] = Mathf.Max(100, MOHDLLIJELH.CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp) * MOHDLLIJELH.CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE / 100;
			json["voice_exp"] = Mathf.Max(100, MOHDLLIJELH.CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp) * MOHDLLIJELH.CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE / 100;
			json["charm_exp"] = Mathf.Max(100, MOHDLLIJELH.CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp) * MOHDLLIJELH.CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE / 100;
			json["soul_exp_pr"] = MOHDLLIJELH.CMCEGEKGEEP.MKMIEGPOKGG_Soul.EJOHDINLOAJ_PrevExp;
			json["voice_exp_pr"] = MOHDLLIJELH.CMCEGEKGEEP.EACDINDLGLF_Voice.EJOHDINLOAJ_PrevExp;
			json["charm_exp_pr"] = MOHDLLIJELH.CMCEGEKGEEP.LDLHPACIIAB_Charm.EJOHDINLOAJ_PrevExp;
			json["soul_exp_af"] = MOHDLLIJELH.CMCEGEKGEEP.MKMIEGPOKGG_Soul.LKIFDCEKDCK_NextExp;
			json["voice_exp_af"] = MOHDLLIJELH.CMCEGEKGEEP.EACDINDLGLF_Voice.LKIFDCEKDCK_NextExp;
			json["charm_exp_af"] = MOHDLLIJELH.CMCEGEKGEEP.LDLHPACIIAB_Charm.LKIFDCEKDCK_NextExp;
			json["bonus_start"] = MOHDLLIJELH.CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart;
			json["bonus_end"] = MOHDLLIJELH.CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd;
			json["bonus_is_daily"] = MOHDLLIJELH.CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily;
			json["get_pt"] = MOHDLLIJELH.CMCEGEKGEEP.JKFCHNEININ_GetPoint;
			json["end_pt"] = MOHDLLIJELH.CMCEGEKGEEP.AHOKAPCGJMA_EndPoint;
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HPNIJDCPCNC_97, json, false);
		}
	}

	// // RVA: 0x91E404 Offset: 0x91E404 VA: 0x91E404
	public void HJGEAHELBPE(MANPIONIGNO_EventGoDiva MOHDLLIJELH, int GLCLFMGPMAN, int ECEKFEFOFNI, int NLIMHCILPFE)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = MOHDLLIJELH.PGIIDPEGGPI_EventId;
		json["event_name"] = MOHDLLIJELH.DGCOMDILAKM_EventName;
		json["item_id"] = GLCLFMGPMAN;
		json["use_count"] = ECEKFEFOFNI;
		json["af_count"] = NLIMHCILPFE;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HJGEAHELBPE_98, json, false);
	}

	// // RVA: 0x91E7E4 Offset: 0x91E7E4 VA: 0x91E7E4
	// public void DAHHMMNABFI() { }

	// // RVA: 0x91E7E8 Offset: 0x91E7E8 VA: 0x91E7E8
	// public void NBBGDNAHAGH() { }

	// // RVA: 0x91E7EC Offset: 0x91E7EC VA: 0x91E7EC
	public void FJIPPAPEBID(int IPJBPBDCCPF, int HABCGPMKBJK, int PEKOLGMLJAL, int BGHCIAOANCF, int GJNAOBBAPOF, int FFBPGKHIKGD, int KMFLNILNPJD, int JPLLMKIDNBM, int HMFDJHEEGNN, long DECPPKAAHFA)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA.Find((BKPAPCMJKHE_Shop.DNOENEKHGMI GHPLINIACBB) =>
		{
			//0x201937C
			return GHPLINIACBB.HCCEFDMGPEA == 5;
		});
		json["shop_id"] = dbShop.OPKDAIMPJBH_ShopId;
		json["shop_name"] = dbShop.NEMKDKDIIDK_ShopName;
		json["lineup_id"] = dbShop.EFNMDPKEJIM_LineupId;
		json["product_id"] = 0;
		json["consume_item_id"] = IPJBPBDCCPF;
		json["consume_item_count"] = HABCGPMKBJK;
		json["consume_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(IPJBPBDCCPF);
		json["af_consume_item_count"] = PEKOLGMLJAL;
		json["buy_item_id"] = BGHCIAOANCF;
		json["buy_item_count"] = GJNAOBBAPOF;
		json["buy_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(BGHCIAOANCF);
		json["af_buy_item_count"] = FFBPGKHIKGD;
		json["buy_count"] = KMFLNILNPJD;
		json["buy_count_total"] = JPLLMKIDNBM;
		json["buy_limit"] = HMFDJHEEGNN;
		if(DECPPKAAHFA == 0)
		{
			json["buy_limit_date"] = "3000-01-01 00:00:00";
		}
		else
		{
			json["buy_limit_date"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(DECPPKAAHFA));
		}
		json["sakasho_product_id"] = 0;
		json["sakasho_product_name"] = "";
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.DBNECDJCNOI_48, json, false);
	}

	// // RVA: 0x91F36C Offset: 0x91F36C VA: 0x91F36C
	public void HEKBPBPLPJL(int NPMIJMFMEKB, int BEPIOAIFCEC)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["target_user_id"] = NPMIJMFMEKB;
		if(BEPIOAIFCEC == 1)
		{
			json["action"] = JpStringLiterals.StringLiteral_11476;
		}
		else
		{
			json["action"] = JpStringLiterals.StringLiteral_11477;
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HGNLDJNEGJM_76, json, false);
	}

	// // RVA: 0x91F708 Offset: 0x91F708 VA: 0x91F708
	public void CLGHLKLHEAK(string INDDJNMPONH, int HHFIMKIKJBC)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["type"] = INDDJNMPONH;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.CLGHLKLHEAK, json, false);
	}

	// // RVA: 0x91F9A4 Offset: 0x91F9A4 VA: 0x91F9A4
	public void PFBIHCIFFKM(int HHFIMKIKJBC, bool MLEHCBKPNGK, bool FMNNBGOFBPB, int GLCLFMGPMAN = 0)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["visit_user_id"] = HHFIMKIKJBC;
		json["is_friend"] = MLEHCBKPNGK ? 1 : 2;
		json["is_visit"] = FMNNBGOFBPB ? 1 : 2;
		json["item"] = GLCLFMGPMAN;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.PFBIHCIFFKM_86, json, false);
	}

	// // RVA: 0x91FD94 Offset: 0x91FD94 VA: 0x91FD94
	public void CEFIPAIKAKN(List<int> GMFMGJNPNKA, List<int> GNGFCCBHLPO)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < GMFMGJNPNKA.Count; i++)
		{
			if(b)
				JBBHNIACMFJ.Append(",");
			JBBHNIACMFJ.Append(GMFMGJNPNKA[i]);
			JBBHNIACMFJ.Append(":");
			JBBHNIACMFJ.Append(GNGFCCBHLPO[i]);
			b = true;
		}
		json["collect_item"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.CEFIPAIKAKN_87, json, false);
	}

	// // RVA: 0x920200 Offset: 0x920200 VA: 0x920200
	public void JCJCJPCHNEN(int NPMIJMFMEKB, int BEPIOAIFCEC, int MFOCDHGOODC, bool MLEHCBKPNGK)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["fan_user_id"] = NPMIJMFMEKB;
		if(BEPIOAIFCEC == 0)
		{
			json["action"] = JpStringLiterals.StringLiteral_11477;
		}
		else
		{
			json["action"] = JpStringLiterals.StringLiteral_11476;
		}
		json["is_friend"] = MLEHCBKPNGK;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.CIGPIPBPABC_80, json, false);
	}

	// // RVA: 0x920614 Offset: 0x920614 VA: 0x920614
	// public void LHCHBHPHLCP(int AOPIMHHPPMG) { }

	// // RVA: 0x9208B0 Offset: 0x9208B0 VA: 0x9208B0
	public void MIDMMEHCCFA(int NJHLKOFIDJN, int OLCAOJEHGMO, bool GNKGNCLBKLB)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["deco_item_id"] = NJHLKOFIDJN;
		json["set_area"] = OLCAOJEHGMO;
		json["is_set"] = GNKGNCLBKLB ? 1 : 2;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.MIDMMEHCCFA_90, json, false);
	}

	// // RVA: 0x920C1C Offset: 0x920C1C VA: 0x920C1C
	// public void AGFMBNBIHGB(int NJHLKOFIDJN, KDKFHGHGFEK DJKKEABCKLH, Vector3 NDFOAINJPIN) { }

	// // RVA: 0x920C90 Offset: 0x920C90 VA: 0x920C90
	// public void KBKIDKDDOJN(int NJHLKOFIDJN, int GOPGOJDEPML) { }

	// // RVA: 0x920D30 Offset: 0x920D30 VA: 0x920D30
	// public void EPINKLEJAGD(int NJHLKOFIDJN, KDKFHGHGFEK DJKKEABCKLH, Vector3 NDFOAINJPIN) { }

	// // RVA: 0x920DA4 Offset: 0x920DA4 VA: 0x920DA4
	// public void INHBHAMMBEH(int NJHLKOFIDJN, int GOPGOJDEPML) { }

	// // RVA: 0x920E44 Offset: 0x920E44 VA: 0x920E44
	public void NOMCHDMPFFE(int DDCKAKGKCIB, int CJAGGLPJOMD, int JPNCPIINMPC)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["deco_id"] = DDCKAKGKCIB;
		json["bf_level"] = CJAGGLPJOMD;
		json["af_level"] = JPNCPIINMPC;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.NOMCHDMPFFE_88, json, false);
	}

	// // RVA: 0x921178 Offset: 0x921178 VA: 0x921178
	public void CHMEOKEKABD(IECJNEHIEKO_CreateBbsComment ADKIDBJCAJA)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["thread_type"] = ADKIDBJCAJA.JECLCENDGIH_ThreadType;
		json["thread_group"] = ADKIDBJCAJA.BDJEICCDKHB_ThreadGroup;
		json["room_user_id"] = ADKIDBJCAJA.GFOIDCMEHGL_RoomUserId;
		json["event_id"] = ADKIDBJCAJA.DNJLJMKKDNA_EventId;
		json["lobby_id"] = ADKIDBJCAJA.MEBHCFJCKFE_LobbyId;
		json["thread_id"] = ADKIDBJCAJA.BOINIEAKFPL_ThreadId;
		json["comment_index"] = ADKIDBJCAJA.NFEAMMJIMPG.NPAHGHOHMHN_Idx;
		json["content"] = ADKIDBJCAJA.KOGBMDOONFA_Info.Content;
		json["nickname"] = ADKIDBJCAJA.KOGBMDOONFA_Info.Nickname;
		json["extra"] = ADKIDBJCAJA.KOGBMDOONFA_Info.Extra;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.CHMEOKEKABD_89, json, false);
	}

	// // RVA: 0x92172C Offset: 0x92172C VA: 0x92172C
	public void ELDCONNMDGN(int FODKKJIDDKN, int MJKGDEOKFNK, int NCMCPNPOLEB, int MPIJPMELIDO, int NHPFGLJJMJJ, int IKBIIBDNNAL, int LHDHBPOLEGB)
	{

		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["vf_id"] = FODKKJIDDKN;
		json["bf_lv"] = MJKGDEOKFNK;
		json["af_lv"] = NCMCPNPOLEB;
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(MPIJPMELIDO);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(NHPFGLJJMJJ);
		JBBHNIACMFJ.Append(',');
		JBBHNIACMFJ.Append(IKBIIBDNNAL);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(LHDHBPOLEGB);
		json["item_info"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.ELDCONNMDGN_79, json, false);
	}

	// // RVA: 0x921C2C Offset: 0x921C2C VA: 0x921C2C
	public void MINOEGPNBIH(int IJIEMJFAJKL, int GGJLPODCHIO, int JGGKJBCGKCC, int PJIOJCFCFOK, string INDDJNMPONH, string GNOOPLDMLBE)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["mc_guage_add"] = IJIEMJFAJKL;
		json["mc_guage_af"] = GGJLPODCHIO;
		json["use_item_id"] = JGGKJBCGKCC;
		json["af_item_num"] = PJIOJCFCFOK;
		json["type"] = INDDJNMPONH;
		json["attack_info"] = GNOOPLDMLBE;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.MINOEGPNBIH_81, json, false);
	}

	// // RVA: 0x92204C Offset: 0x92204C VA: 0x92204C
	public void OMLMHKGCJPH(int IKPIDCFOFEA, string ADKIDBJCAJA, int FDGBLNFGBPJ, int HPPHKHBPFMJ)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["no"] = IKPIDCFOFEA;
		json["action"] = ADKIDBJCAJA;
		json["stamp_id"] = FDGBLNFGBPJ;
		json["serif_id"] = HPPHKHBPFMJ;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.OMLMHKGCJPH_91, json, false);
	}

	// // RVA: 0x9223CC Offset: 0x9223CC VA: 0x9223CC
	public void HNOKBPNGOEF()
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.HNOKBPNGOEF_93, json, false);
	}

	// // RVA: 0x9225F0 Offset: 0x9225F0 VA: 0x9225F0
	public void BOIIMIEPMLG(string INDDJNMPONH, int PPFNGGCBJKC, string KIFBPEGOEDL)
	{
		return;
	}

	// // RVA: 0x9225F4 Offset: 0x9225F4 VA: 0x9225F4
	public void NBCACPPAAMC(int CHCPNKMNDOP, int KBMAMKCAIGD, int IGCLCOMCHHB, int IBKAENIBBIL, int DPJCPEIPAPN, int EKPGGDOOLFM)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["bf_diva_id"] = CHCPNKMNDOP;
		json["af_diva_id"] = KBMAMKCAIGD;
		json["bf_cos"] = IGCLCOMCHHB;
		json["af_cos"] = IBKAENIBBIL;
		json["bf_color_id"] = DPJCPEIPAPN;
		json["af_color_id"] = EKPGGDOOLFM;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.NBCACPPAAMC/*99*/, json, false);
	}

	// // RVA: 0x922A14 Offset: 0x922A14 VA: 0x922A14
	public void BBIBBNHCPPJ(int LKFPHAIMKMA, int HGBMBIBAEGG, int JBOMAOOPGAA, int HPBLCCLGFHH, int AICIPAHGLOE, int FOILMFGFFNH, int DLDODLGIOMC, int CNKFPJCGNFE, int EEJFLMKCCGN)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["bf_view_model"] = LKFPHAIMKMA;
		json["af_view_model"] = HGBMBIBAEGG;
		json["bf_wallpaper_flag"] = JBOMAOOPGAA;
		json["af_wallpaper_flag"] = HPBLCCLGFHH;
		json["bf_light_flag"] = AICIPAHGLOE;
		json["af_light_flag"] = FOILMFGFFNH;
		json["illust_id"] = DLDODLGIOMC;
		json["plate_id"] = CNKFPJCGNFE;
		json["rare_up_flag"] = EEJFLMKCCGN;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO.BBIBBNHCPPJ, json, false);
	}
}
