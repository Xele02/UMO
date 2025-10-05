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
	private long BMOBAOCHNMO_request_id; // 0x18
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

	public static ILCCJNDFFOB HHCJCDFCLOB { get; set; } // 0x0 LGMPACEDIJF_bgs NKACBOEHELJ_bgs 0x8F3D90 OKPMHKNCNAL_bgs 0x8F3E1C

	// // RVA: 0x8F3EAC Offset: 0x8F3EAC VA: 0x8F3EAC
	public void IJBGPAENLJA_OnAwake()
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
	private string COPGJHJGHJG_TimestampToString(long _KPBJHHHMOJE_Time)
	{
		if(_KPBJHHHMOJE_Time != 0)
		{
			return BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(_KPBJHHHMOJE_Time));
		}
		return "";
	}

	// // RVA: 0x8F44CC Offset: 0x8F44CC VA: 0x8F44CC
	private void FLBFCCIEPNC_InitBaseJson(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, long _JCNNBEEHFLE_RequestId)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MOEDCMHBCHN_client_time] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(time));
		_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BMOBAOCHNMO_request_id] = _JCNNBEEHFLE_RequestId;
		if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BIEPKMIADMM_user_rank] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			MCKCJMLOAFP_CurrencyInfo m = CIOECGOMILE.HHCJCDFCLOB.JBEKNFEGFFI();
			if (m != null)
			{
				_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OCDBDAFJPBG_num_free_crystal] = m.JLNEMPJICEH_free;
				_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.ABFKGMFCAIL_num_paid_crystal] = m.KCKBGALKNMA_paid;
			}
			_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MOPDHAAPNAN_player_name] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
		}
	}

	// // RVA: 0x8F4AB8 Offset: 0x8F4AB8 VA: 0x8F4AB8
	// private void BAHPICOFGFH(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, JBECFDNKPFD MFCGAKOAGFE) { }
	//MFCGAKOAGFE.HGEDPFFCDBG_char_id = HGEDPFFCDBG_char_id
	//MFCGAKOAGFE.MIDCDCFCJJM_char_level = MIDCDCFCJJM_char_level
	//MFCGAKOAGFE.LLHFLCGIMPB_char_cos = LLHFLCGIMPB_char_cos
	//MFCGAKOAGFE.JGJPKLCCOIO_scene_id = JGJPKLCCOIO_scene_id
	//MFCGAKOAGFE.JNPCEKKNEBF_scene_level = JNPCEKKNEBF_scene_level
	//MFCGAKOAGFE.PCMDFNHIEBE_valkyrie_id = PCMDFNHIEBE_valkyrie_id
	//MFCGAKOAGFE.CBOCBLLOMHE_para_total = CBOCBLLOMHE_para_total
	//MFCGAKOAGFE.HBKBKHACHHI_para_soul = HBKBKHACHHI_para_soul
	//MFCGAKOAGFE.GMECIBOJCFF_para_voice = GMECIBOJCFF_para_voice
	//MFCGAKOAGFE.MIMLMJGGNJH_para_charm = MIMLMJGGNJH_para_charm
	//MFCGAKOAGFE.MINAGJOIGOP_para_luck = MINAGJOIGOP_para_luck
	//MFCGAKOAGFE.IPEKDLNEOFI_para_life = IPEKDLNEOFI_para_life
	//MFCGAKOAGFE.BFHPKJEKJNN_para_support = BFHPKJEKJNN_para_support
	//MFCGAKOAGFE.DDBEJNGJIPF_para_foldwave = DDBEJNGJIPF_para_foldwave
	//MFCGAKOAGFE.GELJFCKEBDM_FriendId = guest_player_id
	//MFCGAKOAGFE.ANOPDAGJIKG_FriendSceneId = guest_scene_id
	//MFCGAKOAGFE.JBODHPPGKJO_FriendSceneLevel = guest_scene_level
	//MFCGAKOAGFE.DHNBIFENONF_FriendSceneLuck = guest_scene_luck

	// // RVA: 0x8F509C Offset: 0x8F509C VA: 0x8F509C
	private static void DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType _KAPMOPMDHJE_label, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, bool FOIGCFNFPOB/* = false*/)
	{
		JDDGPJDKHNE.HHCJCDFCLOB.CLHLFPDNFNM((int)_KAPMOPMDHJE_label,_IDLHJIOMJBK_data,FOIGCFNFPOB);
	}

	// // RVA: 0x8F50E4 Offset: 0x8F50E4 VA: 0x8F50E4
	public void JONAMONAHOB_Paid(int _ADPPAIPFHML_num, int _FKIBPHGINAE_af_num, LGDNAJACFHI _MEANCEOIMGE_Summon)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		res[AFEHLCGHAEE_Strings.FKCAECFAFCG_stuff_id] = _MEANCEOIMGE_Summon.LHENLPLKGLP_StuffId;
		if(!_MEANCEOIMGE_Summon.JLGHMCBLENL_IsBeginner)
		{
			if(_MEANCEOIMGE_Summon.GCJMGMBNBCB_BuyLimit < 1)
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
		res[AFEHLCGHAEE_Strings.ADPPAIPFHML_num] = _ADPPAIPFHML_num;
		res[AFEHLCGHAEE_Strings.FKIBPHGINAE_af_num] = _FKIBPHGINAE_af_num;
		res[AFEHLCGHAEE_Strings.JLPEGFAMKPK_amount] = _MEANCEOIMGE_Summon.NPPGKNGIFGK_price;
		if(_MEANCEOIMGE_Summon.BIOHCFLJDCH_BonusItemId == null || _MEANCEOIMGE_Summon.HBHLKLGBKIJ_BonusCount == null)
		{
			res["bonus_vc_info"] = "";
		}
		else
		{
			JBBHNIACMFJ.Length = 0;
			bool b = false;
			for(int i = 0; i < _MEANCEOIMGE_Summon.BIOHCFLJDCH_BonusItemId.Length; i++)
			{
				if(b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(_MEANCEOIMGE_Summon.BIOHCFLJDCH_BonusItemId[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(_MEANCEOIMGE_Summon.HBHLKLGBKIJ_BonusCount[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(EKLNMHFCAOI.DEACAHNLMNI_getItemId(_MEANCEOIMGE_Summon.BIOHCFLJDCH_BonusItemId[i])));
				b = true;
			}
			res["bonus_vc_info"] = JBBHNIACMFJ.ToString();
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.JONAMONAHOB_1_Paid, res, false);
	}

	// // RVA: 0x8F5B88 Offset: 0x8F5B88 VA: 0x8F5B88
	// public void KMEONFIEFHN(int _ADPPAIPFHML_num, int _FKIBPHGINAE_af_num, FHPFLAGNCAF _MEANCEOIMGE_Summon) { }
	// FKCAECFAFCG_stuff_id = 10001
	// CEEHDBKCHNJ_stuff_type = Subscription
	// ADPPAIPFHML_num = _ADPPAIPFHML_num
	// FKIBPHGINAE_af_num = _FKIBPHGINAE_af_num
	// JLPEGFAMKPK_amount = _MEANCEOIMGE_Summon.NPPGKNGIFGK_price
	// bonus_vc_info = ""

	// // RVA: 0x8F602C Offset: 0x8F602C VA: 0x8F602C
	public void PMFGEJJDMCK_Consume(int _PPFNGGCBJKC_id, int _INDDJNMPONH_type, string _FPGMBHJNGIK_FromWhere, int _ADPPAIPFHML_num, int _JLPEGFAMKPK_amount)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		res["id"] = _PPFNGGCBJKC_id;
		res["type"] = _INDDJNMPONH_type;
		res["from_where"] = _FPGMBHJNGIK_FromWhere;
		res["num"] = _ADPPAIPFHML_num;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PMFGEJJDMCK_2_Consume, res, true);
	}

	// // RVA: 0x8F63AC Offset: 0x8F63AC VA: 0x8F63AC
	public void ALABPEPENHH_Tutorial(OAGBCBBHMPF.OGBCFNIKAFI_LoadStep _LGADCGFMLLD_step, long _GCLPIJNJFAE_ElapsedTime)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		long t = time - _GCLPIJNJFAE_ElapsedTime;
		if(_GCLPIJNJFAE_ElapsedTime == 0)
			t = _GCLPIJNJFAE_ElapsedTime;
		NNNAKNFEPCF.Length = 0;
		int h = (int)(t / 3600);
		NNNAKNFEPCF.AppendFormat("{0:00}:", h);
		t = t % 3600;
		int m = (int)(t / 60);
		NNNAKNFEPCF.AppendFormat("{0:00}:", m);
		t = t % 60;
		int s = (int)(t / 60);
		NNNAKNFEPCF.AppendFormat("{0:00}", s);
		res[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = (int)_LGADCGFMLLD_step;
		res[AFEHLCGHAEE_Strings.ADAFEPKKBKP_step_name] = OAGBCBBHMPF.KDIDJBOMHFO_LoadStepNames[(int)_LGADCGFMLLD_step];
		res[AFEHLCGHAEE_Strings.MFOCHEBHHNC_elapse_t] = NNNAKNFEPCF.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ALABPEPENHH_3_Tutorial/*3*/, res, true);
	}

	// // RVA: 0x8F6A44 Offset: 0x8F6A44 VA: 0x8F6A44
	public EDOHBJAPLPF_JsonData LECBAPOGJAG(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina)
	{
		EDOHBJAPLPF_JsonData res = null;
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
		{
			res = new EDOHBJAPLPF_JsonData();
			FLBFCCIEPNC_InitBaseJson(res, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
			res["session_id"] = _MDADLCOCEBN_session_id;
			res["free_music_id"] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
			res["music_id"] = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId).DLAEJOBELBH_MusicId).DLAEJOBELBH_MusicId;
			if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
			{
				res["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty;
			}
			else
			{
				res["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty + 10;
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
            System.Collections.Generic.List<AMCGONHBGGF> dList = OMNOFMEBLAD.OALJNDABDHK.DJPFJGKGOOF_Setting.FDBOPFEOENF_diva;
            for (int i = 0; i < dList.Count; i++)
			{
				if(b)
				{
					JBBHNIACMFJ.Append(',');
				}
				JBBHNIACMFJ.Append(dList[i].DIPKCALNIII_diva_id);
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
				if(dList[i].DIPKCALNIII_diva_id == 0)
					JBBHNIACMFJ.Append(0);
				else
					JBBHNIACMFJ.Append(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(dList[i].DIPKCALNIII_diva_id).HEBKEJBDCBH_diva_lv);
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
				if(dList[i].DIPKCALNIII_diva_id == 0)
					JBBHNIACMFJ.Append(0);
				else
					JBBHNIACMFJ.Append(dList[i].BEEAIAAJOHD_CostumeId);
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
					if(dList[i].DIPKCALNIII_diva_id == 0)
						JBBHNIACMFJ.Append(0);
					else
						JBBHNIACMFJ.Append(dList[i].EBDNICPAFLB_s_slot[j]);
					b = true;
				}
			}
			res["scene_id"] = JBBHNIACMFJ.ToString();
			int cnt = 0;
			for(int i = 0; i < dList.Count; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if((i != 0 || j != 0) && dList[i].DIPKCALNIII_diva_id != 0)
					{
						if(dList[i].EBDNICPAFLB_s_slot[j] != 0)
						{
							if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[dList[i].EBDNICPAFLB_s_slot[j] - 1].KPIIIEGGPIB_LS != 0)
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
					if(dList[i].DIPKCALNIII_diva_id == 0)
						JBBHNIACMFJ.Append(0);
					else
					{
						if(dList[i].EBDNICPAFLB_s_slot[j] == 0)
							JBBHNIACMFJ.Append(0);
						else
							JBBHNIACMFJ.Append(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[dList[i].EBDNICPAFLB_s_slot[j] - 1].ANAJIAENLNB_lv);
					}
					b = true;
				}
			}
			res["scene_level"] = JBBHNIACMFJ.ToString();
			res["valkyrie_id"] = OMNOFMEBLAD.OALJNDABDHK.DJPFJGKGOOF_Setting.FODKKJIDDKN_vf_Id;
			string[] ss = new string[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.HBKBKHACHHI_para_soul.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.ICBJAAPJNEI_Soul.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.APPEPDLOPAA_Soul.ToString()
			};
			res["para_soul"] = string.Concat(ss);
			ss = new string[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.GMECIBOJCFF_para_voice.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.AGNGKDFONAM_Vocal.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.LHBINHCMEDA_Vocal.ToString()
			};
			res["para_voice"] = string.Concat(ss);
			ss = new string[5]
			{
				OMNOFMEBLAD.ENMGODCHGAC_Log.MIMLMJGGNJH_para_charm.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.KAEHAANLPKF_Charm.ToString(),
				":",
				OMNOFMEBLAD.ENMGODCHGAC_Log.BPNAAEDJGPC_Charm.ToString()
			};
			res["para_charm"] = string.Concat(ss);
			res["para_life"] = OMNOFMEBLAD.ENMGODCHGAC_Log.IPEKDLNEOFI_para_life + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.NIBMFONLOME_Life;
			res["para_support"] = OMNOFMEBLAD.ENMGODCHGAC_Log.BFHPKJEKJNN_para_support + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.PLMGHHHFAGL_Support;
			res["para_foldwave"] = OMNOFMEBLAD.ENMGODCHGAC_Log.DDBEJNGJIPF_para_foldwave + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.EKKCKGDGNPM_Fold;
			res["para_total"] = OMNOFMEBLAD.ENMGODCHGAC_Log.CBOCBLLOMHE_para_total + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.GCAOLGILAAI_Total;
			res["para_luck"] = OMNOFMEBLAD.ENMGODCHGAC_Log.MINAGJOIGOP_para_luck + ":" + OMNOFMEBLAD.ENMGODCHGAC_Log.IBFPGFJDLEI_Luck;
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
				res["guest_player_id"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.MLPEHNBNOGD_PlayerId;
				res["guest_scene_id"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId : 0;
				res["guest_scene_level"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().CIEOBFIIPLD_Level : 0;
				res["guest_scene_luck"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_luck : 0;
				res["guest_center_skill_lv"] = OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene() != null ? OMNOFMEBLAD.NHPGGBCKLHC_FriendData.KHGKPKDBMOH_GetAssistScene().DDEDANKHHPN_SkillLevel : 0;
			}
			res["game_event_type"] = OMNOFMEBLAD.MNNHHJBBICA_GameEventType;
			res["open_event_type"] = OMNOFMEBLAD.MFJKNCACBDG_OpenEventType;
			res["remaint_stamina"] = _KALCJMLIAOK_RemainStamina;
			res["use_stamina"] = _CBHACAOCJGP_UseStamina;
			res["notes_speed"] = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DGCDPGPAAII_GetNotesSpeed((Difficulty.Type)OMNOFMEBLAD.AKNELONELJK_difficulty, false);
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
					if(cos.DAJGPBLEEOB_ModelId == 1)
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
				OMNOFMEBLAD.ENMGODCHGAC_Log.LPKBGBLIDCE_ParaSceneSoul,
				OMNOFMEBLAD.ENMGODCHGAC_Log.LCFAJIELMMF_ParaSceneCharm,
				OMNOFMEBLAD.ENMGODCHGAC_Log.OIKJEAEJOME_ParaSceneVocal,
				OMNOFMEBLAD.ENMGODCHGAC_Log.MINAGJOIGOP_para_luck,
				OMNOFMEBLAD.ENMGODCHGAC_Log.JJDKFJACLMD_ParaSceneLife,
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
				JBBHNIACMFJ.AppendFormat("{0},{1},{2}", OMNOFMEBLAD.ENMGODCHGAC_Log.EEKANKOEJIL_ParaDivaSoul[i], OMNOFMEBLAD.ENMGODCHGAC_Log.HNINPGMPGMJ_ParaDivaCharm[i], OMNOFMEBLAD.ENMGODCHGAC_Log.DNGJJFFKOBG_ParaDivaVocal[i]);
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
				JBBHNIACMFJ.AppendFormat("{0},{1},{2}", OMNOFMEBLAD.ENMGODCHGAC_Log.IPPIIBLLDDG_ParaCosSoul[i], OMNOFMEBLAD.ENMGODCHGAC_Log.HHNPILDOHKP_ParaCosCharm[i], OMNOFMEBLAD.ENMGODCHGAC_Log.MHPLFJHDIEP_ParaCosVocal[i]);
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
				JBBHNIACMFJ.AppendFormat("{0},{1},{2}", OMNOFMEBLAD.ENMGODCHGAC_Log.NBCMAGJGHLC_ParaGoDivaSoul[i], OMNOFMEBLAD.ENMGODCHGAC_Log.LBGNJCODPEJ_ParaGoDivaCharm[i], OMNOFMEBLAD.ENMGODCHGAC_Log.EGEKLGIEKLL_ParaGoDivaVocal[i]);
				b = true;
			}
			res["para_godiva"] = JBBHNIACMFJ.ToString();
		}
		return res;

	}

	// // RVA: 0x8FACB0 Offset: 0x8FACB0 VA: 0x8FACB0
	public void FKODKMNGCEH_StageStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina)
	{
		EDOHBJAPLPF_JsonData data = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(data != null)
		{
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FKODKMNGCEH_4_StageStart/*4*/, data, false);
		}
	}

	// // RVA: 0x8FAE00 Offset: 0x8FAE00 VA: 0x8FAE00
	public EDOHBJAPLPF_JsonData MKMJILJPOGC(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id)
	{
		EDOHBJAPLPF_JsonData data = null;
		if(IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId != 0)
		{
			data = new EDOHBJAPLPF_JsonData();
			FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
			data["session_id"] = _MDADLCOCEBN_session_id;
			data["free_music_id"] = IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId;
			KEODKEGFDLD_FreeMusicInfo fData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId);
			EONOEHOKBEB_Music mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fData.DLAEJOBELBH_MusicId);
			data["music_id"] = mdata.DLAEJOBELBH_MusicId;
			if(IJAOGPFKDBP.LIDKENJKLGA_IsLine6 == 0)
			{
				data["difficulty"] = IJAOGPFKDBP.AKNELONELJK_difficulty;
			}
			else
			{
				data["difficulty"] = IJAOGPFKDBP.AKNELONELJK_difficulty + 10;
			}
			data["result"] = IJAOGPFKDBP.HBODCMLFDOB_result;
			data["start_t"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(IJAOGPFKDBP.ICJEDACBMMF_start_t));
			data["continue"] = IJAOGPFKDBP.HGACHHHCHHM_ContinueCount;
			data["score"] = IJAOGPFKDBP.KNIFCANOHOC_score;
			data["high_score"] = IJAOGPFKDBP.JKAMFMNGEBB_high_score;
			data["score_rank"] = IJAOGPFKDBP.GEIONHDKGEB_ScoreRank;
			data["combo_num"] = IJAOGPFKDBP.POGINDBNBAJ_MaxCombo;
			JBBHNIACMFJ.Length = 0;
			data[AFEHLCGHAEE_Strings.BIEPKMIADMM_user_rank] = IJAOGPFKDBP.HPEHMCGPMJM_Level;
			if(IJAOGPFKDBP.FILFPNDEINH_Combo == 0)
			{
				data["full_combo"] = JpStringLiterals.StringLiteral_11163;
			}
			else if(IJAOGPFKDBP.FILFPNDEINH_Combo == 1)
			{
				data["full_combo"] = JpStringLiterals.StringLiteral_11164;
			}
			else
			{
				data["full_combo"] = JpStringLiterals.StringLiteral_11165;
			}
			if(IJAOGPFKDBP.IMIEPNOECFD_ValkyrieMode == 0)
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
			for(int i = 0; i < IJAOGPFKDBP.MNDPPLILCPJ_DropInfoItemId.Count; i++)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(IJAOGPFKDBP.MNDPPLILCPJ_DropInfoItemId[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(IJAOGPFKDBP.JIHECDPAOKB_DropInfoCount[i]);
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
			data["ave_fps"] = IJAOGPFKDBP.LMOBPKIDIHF_ave_fps;
			data["low_fps"] = IJAOGPFKDBP.IPAAOFCGEAB_low_fps;
			data["money"] = IJAOGPFKDBP.HJILBFGFFEM_BaseUnionCredit;
			data["get_char_exp"] = IJAOGPFKDBP.BNJBFKAIICK_GetCharExp;
			data["get_user_exp"] = IJAOGPFKDBP.NMDHKLPAKHB_GetUserExp;
			data["notes"] = IJAOGPFKDBP.OEEOILKOKFM_SerializedNoteResultInfo;
			JBBHNIACMFJ.Length = 0;
			JBBHNIACMFJ.AppendFormat("PERFECT:{0},", IJAOGPFKDBP.LAMMILPNINO_notes[4]);
			JBBHNIACMFJ.AppendFormat("GREAT:{0},", IJAOGPFKDBP.LAMMILPNINO_notes[3]);
			JBBHNIACMFJ.AppendFormat("GOOD:{0},", IJAOGPFKDBP.LAMMILPNINO_notes[2]);
			JBBHNIACMFJ.AppendFormat("BAD:{0},", IJAOGPFKDBP.LAMMILPNINO_notes[1]);
			JBBHNIACMFJ.AppendFormat("MISS:{0},,", IJAOGPFKDBP.LAMMILPNINO_notes[0]);
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
	public void IMJLLLNHICJ_StageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id)
	{
		EDOHBJAPLPF_JsonData data = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if (data != null)
		{
			HighScoreRating rating = new HighScoreRating();
			rating.Init();
			rating.CalcUtaRate(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.LCKMBHDMPIP_RecordMusic, false);
			HighScoreRating rating2 = new HighScoreRating();
			rating2.Init();
			rating2.CalcUtaRateForLog(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.LCKMBHDMPIP_RecordMusic, IJAOGPFKDBP.GOIKCKHMBDL_FreeMusicId, IJAOGPFKDBP.AKNELONELJK_difficulty, IJAOGPFKDBP.KNIFCANOHOC_score);
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
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IMJLLLNHICJ_5_StageEnd/*5*/, data, false);
		}
	}

	// // RVA: 0x8FD4B0 Offset: 0x8FD4B0 VA: 0x8FD4B0
	public void KHMDGNKEFOD_DeckChange(string _CHJGGLFGALP_set_status, int _EIANMIIKPDH_deck_id, bool NMJBGABMEDK/* = false*/, bool _CMEOKJMCEBH_IsGoDiva/* = false*/, int _AHHJLDLAPAN_DivaId/* = 1*/)
	{
		CIFHILOJJFC afterData = null;
		CIFHILOJJFC beforeData = null;
		if (_CMEOKJMCEBH_IsGoDiva)
		{
			afterData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KMBJGAHCBDI_UnitGoDiva.IGKLKPIEEEH(_AHHJLDLAPAN_DivaId);
			beforeData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KMBJGAHCBDI_UnitGoDiva.PKMMBKHODDM_Saved[_AHHJLDLAPAN_DivaId - 1];
		}
		else
		{
			afterData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault();
			beforeData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.DBMOBFCLFOB_Saved;
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
				JBBHNIACMFJ.Append(beforeData.FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot[j]);
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
				JBBHNIACMFJ.Append(afterData.FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot[j]);
				b = true;
			}
		}
		data["af_scene"] = JBBHNIACMFJ.ToString();
		data["set_status"] = _CHJGGLFGALP_set_status;
		data["deck_id"] = _EIANMIIKPDH_deck_id;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.KHMDGNKEFOD_6_DeckChange/*6*/, data, false);
		beforeData.ODDIHGPONFL_Copy(afterData, false);
	}

	// // RVA: 0x8FE158 Offset: 0x8FE158 VA: 0x8FE158
	public void JNBKOAKJDAL_Gacha(int _HHGMPEEGFMA_GachaId, int _HMFFHLPNMPH_count, int _IIGPLLECFND_use_item, int _KJMLLBDLKCG_use_item_num, List<int> _IHBECLGCIJI_GetSceneIds, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP, PFIJNPCEOIL IFFKECJOPIB)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.BDEOMEBFDFF_gacha_id] = _HHGMPEEGFMA_GachaId;
		data[AFEHLCGHAEE_Strings.NENOJMFOAOC_exec_num] = _HMFFHLPNMPH_count;
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < _IHBECLGCIJI_GetSceneIds.Count; i++)
		{
			if (b)
				JBBHNIACMFJ.Append(',');
			JBBHNIACMFJ.Append(_IHBECLGCIJI_GetSceneIds[i]);
			b = true;
		}
		data["get_scene_ids"] = JBBHNIACMFJ.ToString();
		Dictionary<int, int> d = new Dictionary<int, int>();
		List<MMPBPOIFDAF_Scene.PMKOFEIONEG> l3 = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes;
		for(int i = 0; i < _IHBECLGCIJI_GetSceneIds.Count; i++)
		{
			if(!d.ContainsKey(_IHBECLGCIJI_GetSceneIds[i]))
			{
				if(l3[_IHBECLGCIJI_GetSceneIds[i] - 1].BEBJKJKBOGH_date == 0)
				{
					d.Add(_IHBECLGCIJI_GetSceneIds[i], 0);
				}
				else
				{
					d[_IHBECLGCIJI_GetSceneIds[i]] = l3[_IHBECLGCIJI_GetSceneIds[i] - 1].JPIPENJGGDD_NumBoard + 1;
				}
			}
		}
		JBBHNIACMFJ.Length = 0;
		b = false;
		for(int i = 0; i < _IHBECLGCIJI_GetSceneIds.Count; i++)
		{
			if(d[_IHBECLGCIJI_GetSceneIds[i]] != 0)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(_IHBECLGCIJI_GetSceneIds[i]);
				b = true;
			}
			d[_IHBECLGCIJI_GetSceneIds[i]]++;
		}
		data["get_redundant_obj_ids"] = JBBHNIACMFJ.ToString();
		switch(_IIGPLLECFND_use_item)
		{
			case 1:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_10137;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = _KJMLLBDLKCG_use_item_num;
				break;
			case 2:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_10138;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = _KJMLLBDLKCG_use_item_num;
				break;
			case 3:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_11202;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = _KJMLLBDLKCG_use_item_num;
				break;
			case 4:
				data[AFEHLCGHAEE_Strings.IIGPLLECFND_use_item] = JpStringLiterals.StringLiteral_11203;
				data[AFEHLCGHAEE_Strings.KJMLLBDLKCG_use_item_num] = _KJMLLBDLKCG_use_item_num;
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
			data["bf_step_index"] = OMOEKOCNICP.DBNAGGGJDAB_current_step_index;
			data["af_step_index"] = ONNIHHLHLDP.DBNAGGGJDAB_current_step_index;
			data["bf_step_rest"] = OMOEKOCNICP.NMNLJFIDFJE_current_step_rest_count;
			data["af_step_rest"] = ONNIHHLHLDP.NMNLJFIDFJE_current_step_rest_count;
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
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.JNBKOAKJDAL_7_Gacha, data, false);
	}

	// // RVA: 0x8FF43C Offset: 0x8FF43C VA: 0x8FF43C
	public void JNBKOAKJDAL_Gacha(int _HHGMPEEGFMA_GachaId, int _HMFFHLPNMPH_count, int _IIGPLLECFND_use_item, int _KJMLLBDLKCG_use_item_num, List<ANGEDJODMKO> _HBHMAKNGKFK_items, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP, PFIJNPCEOIL IFFKECJOPIB)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < _HBHMAKNGKFK_items.Count; i++)
		{
			l.Add(_HBHMAKNGKFK_items[i].OCNINMIMHGC_item_value);
		}
		JNBKOAKJDAL_Gacha(_HHGMPEEGFMA_GachaId, _HMFFHLPNMPH_count, _IIGPLLECFND_use_item, _KJMLLBDLKCG_use_item_num, l, _LDEGEHAEALK_ServerData, OMOEKOCNICP, ONNIHHLHLDP, IFFKECJOPIB);
	}

	// // RVA: 0x8FF5B8 Offset: 0x8FF5B8 VA: 0x8FF5B8
	public void JNBKOAKJDAL_Gacha(int _HHGMPEEGFMA_GachaId, int _HMFFHLPNMPH_count, int _IIGPLLECFND_use_item, int _KJMLLBDLKCG_use_item_num, List<MFDJIFIIPJD> _HBHMAKNGKFK_items, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP, PFIJNPCEOIL IFFKECJOPIB)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < _HBHMAKNGKFK_items.Count; i++)
		{
			l.Add(_HBHMAKNGKFK_items[i].OCNINMIMHGC_item_value);
		}
		JNBKOAKJDAL_Gacha(_HHGMPEEGFMA_GachaId, _HMFFHLPNMPH_count, _IIGPLLECFND_use_item, _KJMLLBDLKCG_use_item_num, l, _LDEGEHAEALK_ServerData, OMOEKOCNICP, ONNIHHLHLDP, IFFKECJOPIB);
	}

	// // RVA: 0x8FF734 Offset: 0x8FF734 VA: 0x8FF734
	public void NNAPCDMAAJM_Enhance(int _BCCHOBPJJKE_SceneId, int _JPIPENJGGDD_NumBoard, int _MMEIOJKLCKK_bf_main_lv, int _PNMKPKMDOND_af_main_lv, List<int> GFFAJFPIEKD, List<int> GHINHKOOBKI, int _NEMMJLNMEHB_money, List<int> FHHIONFFABP)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1];
		json["scene_id"] = _BCCHOBPJJKE_SceneId;
		if(_JPIPENJGGDD_NumBoard < 1)
		{
			json["rarity"] = dbScene.EKLIPGELKCL_Rarity;
		}
		else
		{
			json["rarity"] = dbScene.EKLIPGELKCL_Rarity + 1;
		}
		json[AFEHLCGHAEE_Strings.MMEIOJKLCKK_bf_main_lv] = _MMEIOJKLCKK_bf_main_lv;
		json[AFEHLCGHAEE_Strings.PNMKPKMDOND_af_main_lv] = _PNMKPKMDOND_af_main_lv;
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
		json[AFEHLCGHAEE_Strings.NEMMJLNMEHB_money] = _NEMMJLNMEHB_money;
		JBBHNIACMFJ.Length = 0;
		b = false;
		for (int i = 0; i < FHHIONFFABP.Count; i++)
		{
			if (FHHIONFFABP[i] != 0)
			{
				if (b)
					JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(IDMPGHMNLHD.HBOECCCMPMJ_StatName[i]);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(FHHIONFFABP[i]);
				b = true;
			}
		}
		json["open_panel_info"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.NNAPCDMAAJM_8_Enhance/*8*/, json, false);
	}

	// // RVA: 0x900300 Offset: 0x900300 VA: 0x900300
	public void JAHALBMOANH_GetItem(int _JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType _LHEIIHKDMPA_route_type, string _NPBEKONLDDI_route_id, int _ADPPAIPFHML_num, int _FBAIDPHDEBA_num_af, int _LIDBKCIMCKE_rarity)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json[AFEHLCGHAEE_Strings.FKCAECFAFCG_stuff_id] = _JJBGOIMEIPF_ItemId;
		json[AFEHLCGHAEE_Strings.CEEHDBKCHNJ_stuff_type] = EKLNMHFCAOI.PNNKOIFOPMK[(int)EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_JJBGOIMEIPF_ItemId)];
		json[AFEHLCGHAEE_Strings.LHEIIHKDMPA_route_type] = OAGBCBBHMPF.CINOEDJHDIE[(int)_LHEIIHKDMPA_route_type];
		json[AFEHLCGHAEE_Strings.NPBEKONLDDI_route_id] = _NPBEKONLDDI_route_id;
		json[AFEHLCGHAEE_Strings.ADPPAIPFHML_num] = _ADPPAIPFHML_num;
		json[AFEHLCGHAEE_Strings.FBAIDPHDEBA_num_af] = _FBAIDPHDEBA_num_af;
		json[AFEHLCGHAEE_Strings.LIDBKCIMCKE_rarity] = _LIDBKCIMCKE_rarity;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.JAHALBMOANH_9_GetItem/*9*/, json, false);
	}

	// // RVA: 0x900900 Offset: 0x900900 VA: 0x900900
	public void OJOLFJGNEMO_MusicDownload(int _OLDAGCNLJOI_progress, int _DLAEJOBELBH_MusicId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
        EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(_DLAEJOBELBH_MusicId);
		json[AFEHLCGHAEE_Strings.OLDAGCNLJOI_progress] = _OLDAGCNLJOI_progress;
		json["music_id"] = _DLAEJOBELBH_MusicId;
		json["music_name"] = Database.Instance.musicText.Get(minfo.KNMGEEFGDNI_Name).musicName;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.OJOLFJGNEMO_10_MusicDownload, json, false);
    }

	// // RVA: 0x900DA8 Offset: 0x900DA8 VA: 0x900DA8
	public void DBIDGHMFLIC_Clothes(int _AHHJLDLAPAN_DivaId, int _IGCLCOMCHHB_BfCos, int _IBKAENIBBIL_AfCos, int _DPJCPEIPAPN_BfColorId, int _EKPGGDOOLFM_AfColorId)
	{
		DBIDGHMFLIC_Clothes(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DBIDGHMFLIC_11_Clothes, _AHHJLDLAPAN_DivaId, _IGCLCOMCHHB_BfCos, _IBKAENIBBIL_AfCos, _DPJCPEIPAPN_BfColorId, _EKPGGDOOLFM_AfColorId);
	}

	// // RVA: 0x9011B4 Offset: 0x9011B4 VA: 0x9011B4
	public void CJCJNKOPIKB_HomeCloths(int _AHHJLDLAPAN_DivaId, int _IGCLCOMCHHB_BfCos, int _IBKAENIBBIL_AfCos, int _DPJCPEIPAPN_BfColorId, int _EKPGGDOOLFM_AfColorId)
	{
		DBIDGHMFLIC_Clothes(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CJCJNKOPIKB_95_HomeCloths/*95*/, _AHHJLDLAPAN_DivaId, _IGCLCOMCHHB_BfCos, _IBKAENIBBIL_AfCos, _DPJCPEIPAPN_BfColorId, _EKPGGDOOLFM_AfColorId);
	}

	// // RVA: 0x900DE0 Offset: 0x900DE0 VA: 0x900DE0
	private void DBIDGHMFLIC_Clothes(OAGBCBBHMPF.KJDNDEDOIOO_LogType _INDDJNMPONH_type, int _AHHJLDLAPAN_DivaId, int _IGCLCOMCHHB_BfCos, int _IBKAENIBBIL_AfCos, int _DPJCPEIPAPN_BfColorId, int _EKPGGDOOLFM_AfColorId) 
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["char_id"] = _AHHJLDLAPAN_DivaId;
		json["bf_cos"] = _IGCLCOMCHHB_BfCos;
		json["af_cos"] = _IBKAENIBBIL_AfCos;
		json["bf_color_id"] = _DPJCPEIPAPN_BfColorId;
		json["af_color_id"] = _EKPGGDOOLFM_AfColorId;
		DEGEPBNNOAF(_INDDJNMPONH_type, json, false);
	}

	// // RVA: 0x9011EC Offset: 0x9011EC VA: 0x9011EC
	public void GCCAFBHKAEG(int _JOMGCCBFKEF_MissionId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[_JOMGCCBFKEF_MissionId - 1];
		json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11216;
		json[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = _JOMGCCBFKEF_MissionId;
		json[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = MessageManager.Instance.GetMessage("master", "qd_dsc_" + _JOMGCCBFKEF_MissionId.ToString("D4"));
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IEEKNBEEMMM_12_Mission, json, false);
	}

	// // RVA: 0x9016DC Offset: 0x9016DC VA: 0x9016DC
	public void MOCDNABNBAO(int _JOMGCCBFKEF_MissionId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[_JOMGCCBFKEF_MissionId - 1];
		if(ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(quest))
		{
			json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11217;
		}
		else
		{
			if (ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL_ValueType)quest.INDDJNMPONH_type))
			{
				json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11218;
			}
			else
			{
				json[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11219;
			}
		}
		json[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = _JOMGCCBFKEF_MissionId;
		json[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = MessageManager.Instance.GetMessage("master", "qn_dsc_" + _JOMGCCBFKEF_MissionId.ToString("D4"));
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IEEKNBEEMMM_12_Mission, json, false);
	}

	// // RVA: 0x901E50 Offset: 0x901E50 VA: 0x901E50
	public void APAJMNOBNLL(IKDICBBFBMI_EventBase _MOHDLLIJELH_cont, int _JOMGCCBFKEF_MissionId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11220;
		AKIIJBEJOEP d = _MOHDLLIJELH_cont.AGLILDLEFDK_Missions[_JOMGCCBFKEF_MissionId - 1];
		data[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId * 1000 + _JOMGCCBFKEF_MissionId;
		data[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = d.FEMMDNIELFC_Desc;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IEEKNBEEMMM_12_Mission, data, false);
	}

	// // RVA: 0x902248 Offset: 0x902248 VA: 0x902248
	public void JHAPELNFEOM(int _APFDNBGMMMM_BingoId, int _JOMGCCBFKEF_MissionId, string _FEMMDNIELFC_Desc)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.KOEAHHAHDNP_mission_type] = JpStringLiterals.StringLiteral_11221;
		data[AFEHLCGHAEE_Strings.LBOIEJKNCGG_mission_id] = _APFDNBGMMMM_BingoId * 1000 + _JOMGCCBFKEF_MissionId;
		data[AFEHLCGHAEE_Strings.DHMKKJNGDEN_mission_name] = _FEMMDNIELFC_Desc;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IEEKNBEEMMM_12_Mission, data, false);
	}

	// // RVA: 0x9025E0 Offset: 0x9025E0 VA: 0x9025E0
	public void EAEHILOBHDA_View(int _DLAEJOBELBH_MusicId, string _NEDBBJDAFBH_MusicName)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["music_id"] = _DLAEJOBELBH_MusicId;
		data["music_name"] = _NEDBBJDAFBH_MusicName;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EAEHILOBHDA_13_View, data, false);
	}

	// // RVA: 0x9028C8 Offset: 0x9028C8 VA: 0x9028C8
	public void AOPBBHMIEPB_Story(int _BMPFHHHCNJC_story_id)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[_BMPFHHHCNJC_story_id - 1];
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
			aa = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GFIPALLLPMF(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NIKCFOALFJC_diva_1st, dbStory.JHPPLIGJFPI);
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
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.AOPBBHMIEPB_14_Story/*14*/, data, false);
	}

	// // RVA: 0x902EF8 Offset: 0x902EF8 VA: 0x902EF8
	public void MNFOJMBPHEN_Friend(int _LJEONGIBHGM_target_user_id, int _JOBJHJCIMDN_target_user_rank, int _ADKIDBJCAJA_action, int _HLJBAHBLBPL_FriendsNum, int _DKHKDNNIPCA_MaxFriendNum)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.LJEONGIBHGM_target_user_id] = _LJEONGIBHGM_target_user_id;
		data[AFEHLCGHAEE_Strings.JOBJHJCIMDN_target_user_rank] = _JOBJHJCIMDN_target_user_rank; 
		switch(_ADKIDBJCAJA_action)
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
		data["friends_num"] = _HLJBAHBLBPL_FriendsNum;
		data["max_friends_num"] = _DKHKDNNIPCA_MaxFriendNum;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.MNFOJMBPHEN_15_Friend, data, false);
	}

	// // RVA: 0x9036DC Offset: 0x9036DC VA: 0x9036DC
	public void EEPIDKPPLJI_Valkyrie(int _AFNCFEMDJNP_BfValkyrie, int _FDMAECAPKDF_AfValkyrie)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["bf_valkyrie"] = _AFNCFEMDJNP_BfValkyrie;
		data["af_valkyrie"] = _FDMAECAPKDF_AfValkyrie;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EEPIDKPPLJI_20_Valkyrie/*20*/, data, false);
	}

	// // RVA: 0x9039C4 Offset: 0x9039C4 VA: 0x9039C4
	public void JOLBIMMKGIP_OpenSns(int _JPNBLCBOCLN_RoomId, int _NAJPNHKHKKA_sns_id, int _HBNIMMAEKHJ_Id, int _JGGKJBCGKCC_use_item_id)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["type"] = 1;
		data["room_id"] = _JPNBLCBOCLN_RoomId;
		data[AFEHLCGHAEE_Strings.NAJPNHKHKKA_sns_id] = _NAJPNHKHKKA_sns_id;
		data["use_item_id"] = _JGGKJBCGKCC_use_item_id;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HGOGFPOCKFA_17_Sns/*17*/, data, false);
	}

	// // RVA: 0x903D7C Offset: 0x903D7C VA: 0x903D7C
	public void HGOGFPOCKFA_Sns(int _JPNBLCBOCLN_RoomId, int _NAJPNHKHKKA_sns_id, int _HBNIMMAEKHJ_Id)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["type"] = 2;
		data["room_id"] = _JPNBLCBOCLN_RoomId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HGOGFPOCKFA_17_Sns/*17*/, data, false);
	}

	// // RVA: 0x904060 Offset: 0x904060 VA: 0x904060
	public void BBDKHAMANCB_Episode(int _GDEJFKCMNAC_EpisodeId, int _FCJLPINNDKN_BfPoint, int _KJDKJGGHHIF_AfPoint, int _LGADCGFMLLD_step, string _DNKNECIGGMO_GetType, int _FEGJGLAHEOI_UseEpiItemId/* = 0*/, int _KNKCLDMLGIH_UseEpiItemNum/* = 0*/)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data[AFEHLCGHAEE_Strings.AIFCAAHMFBD_episod_id] = _GDEJFKCMNAC_EpisodeId;
		data["af_pt"] = _KJDKJGGHHIF_AfPoint;
		data["bf_pt"] = _FCJLPINNDKN_BfPoint;
		data["step"] = _LGADCGFMLLD_step;
		data["get_type"] = _DNKNECIGGMO_GetType;
		data["use_epi_item_id"] = _FEGJGLAHEOI_UseEpiItemId;
		data["use_epi_item_num"] = _KNKCLDMLGIH_UseEpiItemNum;
		if(_FEGJGLAHEOI_UseEpiItemId == 0)
		{
			data["use_item_info"] = "";
		}
		else
		{
			data["use_item_info"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_FEGJGLAHEOI_UseEpiItemId) + ":" + _KNKCLDMLGIH_UseEpiItemNum.ToString();
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.BBDKHAMANCB_18_Episode, data, false);
	}

	// // RVA: 0x904668 Offset: 0x904668 VA: 0x904668
	// public void AMBIOHGPBNH_Review(string _IPBHCLIHAPG_Msg, int _ADPPAIPFHML_num) { }
	// review = IPBHCLIHAPG_Msg
	// num = _ADPPAIPFHML_num

	// // RVA: 0x904950 Offset: 0x904950 VA: 0x904950
	// public void PNMJDKOLGEG_Rankup(int DMOAGOOHEND) { }

	// // RVA: 0x904954 Offset: 0x904954 VA: 0x904954
	public void EBLJKIOEELA_DivaLevelUp(int _AHHJLDLAPAN_DivaId, int _CIEOBFIIPLD_Level, int _LKIFDCEKDCK_exp)
	{
		return;
	}

	// // RVA: 0x904958 Offset: 0x904958 VA: 0x904958
	public void PGHFPIMIOKE_Emblem(int _ICPDDMIBEIL_Bf, int _MKNKJMFILFB_Af)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["bf_emblem"] = _ICPDDMIBEIL_Bf;
		d["af_emblem"] = _MKNKJMFILFB_Af;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PGHFPIMIOKE_23_Emblem, d, false);
	}

	// // RVA: 0x904C40 Offset: 0x904C40 VA: 0x904C40
	public void COBCMOAAAFF_EmblemGet(int _APGKOJKNNGP_EmblemId)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["emblem_id"] = _APGKOJKNNGP_EmblemId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.COBCMOAAAFF_27_EmblemGet, d, false);
	}

	// // RVA: 0x904EDC Offset: 0x904EDC VA: 0x904EDC
	public void CMBKHLDBIEC_Voice(int _DIPKCALNIII_diva_id, string LDBIGOBMFMD_CharaName, int CLKJBCJMILI_VoiceCount)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["char_id"] = _DIPKCALNIII_diva_id;
		d["char_name"] = LDBIGOBMFMD_CharaName;
		d["voice_count"] = CLKJBCJMILI_VoiceCount;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CMBKHLDBIEC_24_Voice, d, false);
	}

	// // RVA: 0x905210 Offset: 0x905210 VA: 0x905210
	public void FLBCPKHGLPE_Energy(int _APJBBOHHFNE_heal, int _MKNKJMFILFB_Af, int MNHBMILFDBG, int _ECEKFEFOFNI_UseItemCount, string _JKJDGDLAIME_Place)
	{
		EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(d, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		d["heal"] = _APJBBOHHFNE_heal;
		d["af"] = _MKNKJMFILFB_Af;
		if(MNHBMILFDBG == 0)
		{
			d["use_item_type"] = JpStringLiterals.StringLiteral_11245;
			d["use_item_count"] = _ECEKFEFOFNI_UseItemCount;
		}
		else
		{
			d["use_item_type"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem, MNHBMILFDBG);
			d["use_item_count"] = _ECEKFEFOFNI_UseItemCount;
		}
		d["buy_place"] = _JKJDGDLAIME_Place;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FLBCPKHGLPE_25_Energy, d, false);
	}

	// // RVA: 0x905750 Offset: 0x905750 VA: 0x905750
	public void MLNHHIIDJAO_1_Anketo(MBLFHJJEHLH_AnketoMgr.CGBKENNCMMC PEPCJDIECJP)
	{
		if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.JPIDBKDPFLM_IsShowAnketoFlag(PEPCJDIECJP.PPFNGGCBJKC_id - 1))
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
			data["enquete_ver"] = PEPCJDIECJP.CEMEIPNMAAD_Version;
			data["enquete_id"] = PEPCJDIECJP.PPFNGGCBJKC_id;
			data["enquete_detail"] = PEPCJDIECJP.ADCMNODJBGJ_title;
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
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.MLNHHIIDJAO_26_Anketo, data, false);
		}
		else
		{
			Debug.Log(JpStringLiterals.StringLiteral_11248);
		}
	}

	// // RVA: 0x905F20 Offset: 0x905F20 VA: 0x905F20
	public void NNFGBBCHLPC(int _PGIIDPEGGPI_EventId, string _HEIPELEDAIK_ranking_type, long _ICPDDMIBEIL_Bf, long _MKNKJMFILFB_Af, long _DOOGFEGEKLG_max, bool _CMIGGBMMBKK_drop)
	{
        return;
    }

	// // RVA: 0x905F24 Offset: 0x905F24 VA: 0x905F24
	public void GIBLHFKIMDA_EventEnd(IKDICBBFBMI_EventBase _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["event_ttl_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
		data["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		data["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.GIBLHFKIMDA_28_EventEnd, data, false);
	}

	// // RVA: 0x906284 Offset: 0x906284 VA: 0x906284
	// public void GBABEMFLPBA_MissionEventChange(string _MDADLCOCEBN_session_id, int _CCHFKKINLHB_BfDiff, int _DAOBEIMNFLH_AfDiff, MHAPMOLCPKM_EventQuest _MOHDLLIJELH_cont) { }
	// session_id = _MDADLCOCEBN_session_id
	// event_id = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId
	// event_name = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName
	// bf_difficulty = _CCHFKKINLHB_BfDiff
	// af_difficulty = _DAOBEIMNFLH_AfDiff

	// // RVA: 0x906660 Offset: 0x906660 VA: 0x906660
	// public void MFIIOABPKAO_MissionEventSelect(string _MDADLCOCEBN_session_id, MHAPMOLCPKM_EventQuest _MOHDLLIJELH_cont) { }
	// session_id = _MDADLCOCEBN_session_id
	// event_id = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId
	// mission_id = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.PPFNGGCBJKC_id
	// difficulty = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.DGMIADAEGAI_TargetDifficultyType
	// lucky = MOHDLLIJELH_cont.FPILJDOPPJC_GetSelectedCardSaveInfo.KIFJKGDBDBH_lucky
	// reset_uc = MOHDLLIJELH_cont.CDKDCKOAEMA()
	// mission_cnt = _MOHDLLIJELH_cont.FPILJDOPPJC_GetSelectedCardSaveInfo.OLDAGCNLJOI_progress
	// mission_clr_cnt = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.JJECMJFDEEP_ClearConditionValue
	// mission_clr_cnt = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.GLDIGCJNOBO_ClearCount
	// use_uc = 0

	// // RVA: 0x906DD8 Offset: 0x906DD8 VA: 0x906DD8
	// public void EPABCLLAJDP_MissionEventReset(string _MDADLCOCEBN_session_id, MHAPMOLCPKM_EventQuest _MOHDLLIJELH_cont, int _PFDFGDPLLCK_UseUc) { }
	// session_id = _MDADLCOCEBN_session_id
	// event_id = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId
	// mission_id = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.PPFNGGCBJKC_id
	// difficulty = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.DGMIADAEGAI_TargetDifficultyType
	// lucky = MOHDLLIJELH_cont.FPILJDOPPJC_GetSelectedCardSaveInfo.KIFJKGDBDBH_lucky
	// mission_cnt = _MOHDLLIJELH_cont.FPILJDOPPJC_GetSelectedCardSaveInfo.OLDAGCNLJOI_progress
	// mission_clr_cnt = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.JJECMJFDEEP_ClearConditionValue
	// mission_clr_cnt = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo.GLDIGCJNOBO_ClearCount
	// use_uc = _PFDFGDPLLCK_UseUc

	// // RVA: 0x907500 Offset: 0x907500 VA: 0x907500
	public void LKOICKMAADB_MissionEventStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina, MHAPMOLCPKM_EventQuest _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(json != null)
		{
            PKADMPNDMGP d = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo();
            OFNLIBDEIFA_EventQuest.AGFEALDEJOL d2 = _MOHDLLIJELH_cont.FPILJDOPPJC_GetSelectedCardSaveInfo();
			json["mission_id"] = d.PPFNGGCBJKC_id;
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty;
			json["lucky"] = d2.KIFJKGDBDBH_lucky;
			json["boost_ratio"] = _MOHDLLIJELH_cont.HADLPHIMBHH_BoostRatio;
			if(GBNDFCEDNMG.NKGDIBMNLNO(d) == 1)
			{
				json["mission_cnt"] = d2.OLDAGCNLJOI_progress;
				json["mission_clr_cnt"] = d.JJECMJFDEEP_ClearConditionValue;
			}
			else
			{
				json["mission_cnt"] = d2.OLDAGCNLJOI_progress;
				json["mission_clr_cnt"] = d.GLDIGCJNOBO_ClearCount;
			}
			json["start_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["start_ranking"] = _MOHDLLIJELH_cont.CDINKAANIAA_Rank[0];
			HADLOAPLCAF(json, OMNOFMEBLAD, _MOHDLLIJELH_cont);
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LKOICKMAADB_42_MissionEventStart, json, false);
        }
	}

	// // RVA: 0x907FA4 Offset: 0x907FA4 VA: 0x907FA4
	public void EEGOAEADLDP_MissionStageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, MHAPMOLCPKM_EventQuest _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if(json != null)
		{
            PKADMPNDMGP d = _MOHDLLIJELH_cont.GAPOCIFPDDO_GetSelectedCardInfo();
            OFNLIBDEIFA_EventQuest.AGFEALDEJOL d2 = _MOHDLLIJELH_cont.FPILJDOPPJC_GetSelectedCardSaveInfo();
            json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["mission_id"] = d.PPFNGGCBJKC_id;
			json["difficulty"] = IJAOGPFKDBP.AKNELONELJK_difficulty;
			json["lucky"] = d2.KIFJKGDBDBH_lucky;
			int mission_clr_cnt = 0;
			if(GBNDFCEDNMG.NKGDIBMNLNO(d) == 1)
			{
				mission_clr_cnt = d.JJECMJFDEEP_ClearConditionValue;
			}
			else
			{
				mission_clr_cnt = d.GLDIGCJNOBO_ClearCount;
			}
			int mission_cnt = 0;
			int get_pt = 0;
			if(IJAOGPFKDBP.HBODCMLFDOB_result == 1)
			{
				if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, d, OMNOFMEBLAD, _MOHDLLIJELH_cont, true))
				{
					if(GBNDFCEDNMG.NKGDIBMNLNO(d) == 1)
					{
						mission_clr_cnt = d.JJECMJFDEEP_ClearConditionValue;
						mission_cnt = OMNOFMEBLAD.KNIFCANOHOC_score + d2.OLDAGCNLJOI_progress;
					}
					else
					{
						mission_clr_cnt = d.GLDIGCJNOBO_ClearCount;
						mission_cnt = 1 + d2.OLDAGCNLJOI_progress;
					}
					if(GBNDFCEDNMG.GLDHKNMLEIG(d, d2, OMNOFMEBLAD))
					{
						if(d2.KIFJKGDBDBH_lucky == 0)
						{
							get_pt = d.EIOFPIHABFC_Pts;
						}
						else
						{
							get_pt = d.EIOFPIHABFC_Pts * _MOHDLLIJELH_cont.BOLHIMADLBN(OMNOFMEBLAD.AKNELONELJK_difficulty);
						}
						get_pt *= _MOHDLLIJELH_cont.HADLPHIMBHH_BoostRatio;
					}
				}
			}
			json["mission_cnt"] = mission_cnt;
			json["mission_clr_cnt"] = mission_clr_cnt;
			json["get_pt"] = get_pt;
			json["end_pt"] = get_pt + _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EEGOAEADLDP_32_MissionStageEnd, json, false);
		}
	}

	// // RVA: 0x9089A4 Offset: 0x9089A4 VA: 0x9089A4
	public void JMAJBHENDPF_EventStageStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina, IKDICBBFBMI_EventBase _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(json != null)
		{
			if(_MOHDLLIJELH_cont.MNDFBBMNJGN_IsUsingTicket)
			{
				json["remaint_stamina"] = _MOHDLLIJELH_cont.AELBIEDNPGB_GetTicketCount(null);
				json["use_stamina"] = _MOHDLLIJELH_cont.EAMODCHMCEL_GetTicketCost(OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
			}
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["start_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["start_ranking"] = _MOHDLLIJELH_cont.CDINKAANIAA_Rank[0];
			json["boost_ratio"] = _MOHDLLIJELH_cont.HADLPHIMBHH_BoostRatio;
			HADLOAPLCAF(json, OMNOFMEBLAD, _MOHDLLIJELH_cont);
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.JMAJBHENDPF_33_EventStageStart, json, false);
		}
	}

	// // RVA: 0x908E44 Offset: 0x908E44 VA: 0x908E44
	public void NJKBAICBOIN_EventStageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, IKDICBBFBMI_EventBase _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if(json != null)
		{
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			if(IJAOGPFKDBP.HBODCMLFDOB_result == 1)
			{
				if(_MOHDLLIJELH_cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
				{
					HJNNLPIGHLM_EventCollection evColl = _MOHDLLIJELH_cont as HJNNLPIGHLM_EventCollection;
					json["get_pt"] = evColl.EELENPNCGLM.PIIEGNPOPJI_GetPoint;
					json["end_pt"] = evColl.EELENPNCGLM.PIIEGNPOPJI_GetPoint + _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
				}
				else if(_MOHDLLIJELH_cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_4_Score)
				{
					json["get_pt"] = OMNOFMEBLAD.KNIFCANOHOC_score;
					json["end_pt"] = OMNOFMEBLAD.KNIFCANOHOC_score;
					if(OMNOFMEBLAD.KNIFCANOHOC_score <= _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint())
					{
						json["get_pt"] = 0;
						json["end_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
					}
				}
				else
				{
					json["get_pt"] = 0;
					json["end_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
				}
			}
			else
			{
				json["get_pt"] = 0;
				json["end_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			}
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.NJKBAICBOIN_34_EventStageEnd, json, false);
		}
	}

	// // RVA: 0x90941C Offset: 0x90941C VA: 0x90941C
	public string MECOCJPMMDO(HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ BIGMHOMLMAG)
	{
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(BIGMHOMLMAG.GOIKCKHMBDL_FreeMusicId);
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(m.DLAEJOBELBH_MusicId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.GOIKCKHMBDL_FreeMusicId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.EHGBICNIBKE_player_id);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.OPFGFINHFCE_name);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.DIPKCALNIII_diva_id);
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
			int lvl = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[BIGMHOMLMAG.GLILAGLJLEP_SceneId - 1].EKLIPGELKCL_Rarity;
			if(BIGMHOMLMAG.CFCIMKOHLIG_Mlt > 0)
				lvl++;
			JBBHNIACMFJ.Append(lvl);
		}
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.BDLNMOIOMHK_total);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.KNIFCANOHOC_score);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.AKNELONELJK_difficulty);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.EHGBICNIBKE_player_id > 9999);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.IPPNCOHEEOD_ScoreAverage);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(BIGMHOMLMAG.BHCIFFILAKJ_Strength);
		return JBBHNIACMFJ.ToString();
	}

	// // RVA: 0x909B38 Offset: 0x909B38 VA: 0x909B38
	public void HHGEPDNBGAI_BattleStageMatch(HAEDCCLHEMN_EventBattle _MOHDLLIJELH_cont, int[] _PAHGOCGBINJ_SearchMin, int[] _BEGOPJOCMAF_SearchMax)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(data, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		data["session_id"] = _MOHDLLIJELH_cont.FEKEBPKINIM_GetSessionId();
		data["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		data["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		data["game_num"] = _MOHDLLIJELH_cont.BEHNMCPFEIE_GetCnt();
		data["consecutive_win"] = _MOHDLLIJELH_cont.HACMNNLAHCO_GetConsecutiveWin();
		data["avg_score"] = _MOHDLLIJELH_cont.CAEIHFHFOKI_GetScoreAverage();
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < 6; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(_PAHGOCGBINJ_SearchMin[i]);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_BEGOPJOCMAF_SearchMax[i]);
			b = true;
		}
		data["search_range"] = JBBHNIACMFJ.ToString();
		for(int i = 0; i < 6; i++)
		{
			HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ d = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals.Find((HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ _GHPLINIACBB_x) =>
			{
				//0x20193C0
				return _GHPLINIACBB_x.BHCIFFILAKJ_Strength == i;
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
		data["selected_class"] = _MOHDLLIJELH_cont.KKMFHMGIIKN_GetCls();
		data["unlocked_class"] = _MOHDLLIJELH_cont.DAHNCPDEBDM_GetEvBltClassUnlocked();
		data["ex_gauge"] = _MOHDLLIJELH_cont.GGBNNMCLDMO_GetExPoint();
		data["ex_gauge_max"] = _MOHDLLIJELH_cont.AMDOCOMNNKN_GetExGaugePoinMax();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HHGEPDNBGAI_37_BattleStageMatch, data, false);
	}

	// // RVA: 0x90A79C Offset: 0x90A79C VA: 0x90A79C
	public void PMHLIBHEBBB_BattleStageStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina, HAEDCCLHEMN_EventBattle _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(json != null)
		{
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["start_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["start_ranking"] = _MOHDLLIJELH_cont.CDINKAANIAA_Rank[0];
			json["enemy_info_id"] = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[_MOHDLLIJELH_cont.DPPODNCOMIA_GetRivalIdx()].BHCIFFILAKJ_Strength + 1;
			json["boost_ratio"] = _MOHDLLIJELH_cont.HADLPHIMBHH_BoostRatio;
			HADLOAPLCAF(json, OMNOFMEBLAD, _MOHDLLIJELH_cont);
			json["is_ex_battle"] = (_MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[_MOHDLLIJELH_cont.DPPODNCOMIA_GetRivalIdx()].BHCIFFILAKJ_Strength > 2) ? 1 : 0;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PMHLIBHEBBB_38_BattleStageStart, json, false);
		}
	}

	// // RVA: 0x90AC64 Offset: 0x90AC64 VA: 0x90AC64
	public void FEIOPIIEIKB_BattleStageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, HAEDCCLHEMN_EventBattle _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if(json != null)
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String);
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			long v1 = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			HAEDCCLHEMN_EventBattle.DJJHCPAKJKJ d = _MOHDLLIJELH_cont.PIPHAKNMIBL_Rivals[_MOHDLLIJELH_cont.DPPODNCOMIA_GetRivalIdx()];
			if(d != null)
			{
				json["enemey_score"] = d.KNIFCANOHOC_score;
				JBBHNIACMFJ.Length = 0;
				JBBHNIACMFJ.AppendFormat("PERFECT:{0},", d.MJNMPAKBNKB_NotesResult[4].ToString());
				JBBHNIACMFJ.AppendFormat("GREAT:{0},", d.MJNMPAKBNKB_NotesResult[3].ToString());
				JBBHNIACMFJ.AppendFormat("GOOD:{0},", d.MJNMPAKBNKB_NotesResult[2].ToString());
				JBBHNIACMFJ.AppendFormat("BAD:{0},", d.MJNMPAKBNKB_NotesResult[1].ToString());
				JBBHNIACMFJ.AppendFormat("MISS:{0},", d.MJNMPAKBNKB_NotesResult[0].ToString());
				json["enemy_notes_judge"] = JBBHNIACMFJ.ToString();
				if(IJAOGPFKDBP.HBODCMLFDOB_result == 1)
				{
					json["battle_result"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.BLAJKMAPEKP_CWin > 0 ? 1 : 0;
					json["battle_pt"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.FPEOGFMKMKJ_Point;
					json["score_pt"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.GBLHPHCAPLG_ScoreBonus;
					json["win_series_bonus"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.APEFEONDBKL_DiffBonus;
					json["get_pt"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.PIIEGNPOPJI_GetPoint;
					v1 += _MOHDLLIJELH_cont.IHDPLPHLCPA.PIIEGNPOPJI_GetPoint;
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
			json["get_ex_gauge"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.MBBPOOFCAKC_GetExGauge;
			json["end_ex_gauge"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.CINCDFAOEOJ_NewExPoint;
			json["appear_ex_rival"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.EGAMOPBCFKG_ExRival ? 1 : 0;
			if(d != null)
			{
				json["ex_battle_music_score"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.OOEKGFAIFPK_ExBattleMusicScore;
				json["ex_battle_music_high_score"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.JCCABPBHJPA_ExHighScore;
				json["ex_battle_win_bonus"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.KOOMDFGADKH_ExBattleWinBonus;
				json["ex_battle_score_total_bf"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.NHNEMDAFPMJ_ExBattleScoreTotalBefore;
				json["ex_battle_score_total_af"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.IGIPKOJJIIA_TotalScore;
				JBBHNIACMFJ.Length = 0;
				JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.IHDPLPHLCPA.HDIEPNLNABL_ExBattleScoreBefore[0]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.IHDPLPHLCPA.HDIEPNLNABL_ExBattleScoreBefore[1]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.IHDPLPHLCPA.HDIEPNLNABL_ExBattleScoreBefore[2]);
				json["ex_battle_score_bf"] = JBBHNIACMFJ.ToString();
				JBBHNIACMFJ.Length = 0;
				JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.IHDPLPHLCPA.OEGDACKEDIB_ExBattleScoreAfter[0]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.IHDPLPHLCPA.OEGDACKEDIB_ExBattleScoreAfter[1]);
				JBBHNIACMFJ.Append(',');
				JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.IHDPLPHLCPA.OEGDACKEDIB_ExBattleScoreAfter[2]);
				json["ex_battle_score_af"] = JBBHNIACMFJ.ToString();
				json["unlocked_class_bf"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.EDJJIBAGFHL_UnlockedClassBefore;
				json["unlocked_class_af"] = _MOHDLLIJELH_cont.IHDPLPHLCPA.GBIGCJIKKPP_UnlockedClassAfter;
			}
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FEIOPIIEIKB_39_BattleStageEnd, json, false);
		}
	}

	// // RVA: 0x90BF58 Offset: 0x90BF58 VA: 0x90BF58
	public void EAGAKGNNINL_Banner(int _OPKCNBFBBKP_BannerId, string _OPFGFINHFCE_name, string HJLDBEJOMIO)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["banner_id"] = _OPKCNBFBBKP_BannerId;
		json["banner_name"] = _OPFGFINHFCE_name;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EAGAKGNNINL_40_Banner, json, false);
	}

	// // RVA: 0x907BF4 Offset: 0x907BF4 VA: 0x907BF4
	private void HADLOAPLCAF(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, IKDICBBFBMI_EventBase _MOHDLLIJELH_cont)
	{
		int v1 = 0;
		int v2 = 0;
		FFHPBEPOMAK_DivaInfo diva = OMNOFMEBLAD.GNLFLDMNBGG_FrienDiva;
		if(diva != null)
		{
			v2 = diva.FGFIBOBAPIA_SceneId;
			v1 = diva.AICGALGPFMO_NumBoard;
		}
		List<IKDICBBFBMI_EventBase.GNPOABJANKO> l = _MOHDLLIJELH_cont.LMDENICBIIB_GetEpisodesBonusList(v2, v1);
		JBBHNIACMFJ.Length = 0;
		bool b1 = false;
		int v3 = 0;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].JKDJCFEBDHC_Enabled)
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
		_IDLHJIOMJBK_data["epi_bonus"] = Mathf.Min(999, v3);
		_IDLHJIOMJBK_data["epi_bonus_info"] = JBBHNIACMFJ.ToString();
	}

	// // RVA: 0x90C240 Offset: 0x90C240 VA: 0x90C240
	public void NJEIHFPKOMG_GameStartLoad(int _HBODCMLFDOB_result, int _EJJNDLJIIIF_ErrorCode, string EFBLONMFDCB)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["result"] = _HBODCMLFDOB_result;
		json["error_code"] = _EJJNDLJIIIF_ErrorCode;
		json["parse_result"] = EFBLONMFDCB;
		json["system_memory_size"] = SystemInfo.systemMemorySize;
		json["graphic_device_name"] = SystemInfo.graphicsDeviceName;
		json["processor_type"] = SystemInfo.processorType;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.NJEIHFPKOMG_36_GameStartLoad/*36*/, json, false);
	}

	// // RVA: 0x90C664 Offset: 0x90C664 VA: 0x90C664
	public void EEOLHMGNJGO_UnlockLimitOver(int _JGJPKLCCOIO_scene_id, int _OBLKLLDGOEJ_BaseRarity, int _MJBODMOLOBC_luck, int _GLCLFMGPMAN_ItemId, int _LJKMKCOAICL_ItemCount, int _PFDFGDPLLCK_UseUc, int _EDKMIKFEEJI_LimitOverLevelBf, int _LCKLPIDPDIE_LimitOverLevelAf)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(_GLCLFMGPMAN_ItemId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(_LJKMKCOAICL_ItemCount);
		json["scene_id"] = _JGJPKLCCOIO_scene_id;
		json["base_rarity"] = _OBLKLLDGOEJ_BaseRarity;
		json["luck"] = _MJBODMOLOBC_luck;
		json["item_info"] = JBBHNIACMFJ.ToString();
		json["money"] = _PFDFGDPLLCK_UseUc;
		json["limit_over_level_bf"] = _EDKMIKFEEJI_LimitOverLevelBf;
		json["limit_over_level_af"] = _LCKLPIDPDIE_LimitOverLevelAf;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EEOLHMGNJGO_41_UnlockLimitOver, json, false);
	}

	// // RVA: 0x90CBA4 Offset: 0x90CBA4 VA: 0x90CBA4
	public void JNHOIANJAOP(KPJHLACKGJF_EventMission _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["session_id"] = _MOHDLLIJELH_cont.FEKEBPKINIM_GetSessionId();
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
        ACBAHDMEFFL_EventMission.BIMNGKEMMJM d = _MOHDLLIJELH_cont.MLLAMHMJFLP();
        if (d == null)
		{
			json["mission_set_id"] = null;
			json["mission_level_1"] = null;
			json["mission_level_2"] = null;
			json["mission_level_3"] = null;
		}
		else
		{
			json["mission_set_id"] = d.PPFNGGCBJKC_id;
			JBBHNIACMFJ.Length = 0;
			JBBHNIACMFJ.Append(d.BGFPMGPHGJJ_Mid1);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(d.JKAEKMMOJMF_Bns1);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.LOLJPCKNLGI(d.BGFPMGPHGJJ_Mid1).JKPDKNPDEBC_EnemyHasSkill);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.LOLJPCKNLGI(d.BGFPMGPHGJJ_Mid1).FEMMDNIELFC_Desc);
			json["mission_level_1"] = JBBHNIACMFJ.ToString();
			JBBHNIACMFJ.Length = 0;
			JBBHNIACMFJ.Append(d.KEEHMNJCONJ_Mid2);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(d.DHDBOPKADII_Bns2);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.LOLJPCKNLGI(d.KEEHMNJCONJ_Mid2).JKPDKNPDEBC_EnemyHasSkill);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.LOLJPCKNLGI(d.KEEHMNJCONJ_Mid2).FEMMDNIELFC_Desc);
			json["mission_level_2"] = null;
			JBBHNIACMFJ.Length = 0;
			JBBHNIACMFJ.Append(d.CFMIPHDGCAG_Mid3);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(d.OPNNCHMFEBH_Bns3);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.LOLJPCKNLGI(d.CFMIPHDGCAG_Mid3).JKPDKNPDEBC_EnemyHasSkill);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.LOLJPCKNLGI(d.CFMIPHDGCAG_Mid3).FEMMDNIELFC_Desc);
			json["mission_level_3"] = null;
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LKOICKMAADB_42_MissionEventStart, json, false);
	}

	// // RVA: 0x90D72C Offset: 0x90D72C VA: 0x90D72C
	public void HPFKEJGCDKN(KPJHLACKGJF_EventMission _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["session_id"] = _MOHDLLIJELH_cont.FEKEBPKINIM_GetSessionId();
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["mission_level"] = _MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() + 1;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.GHJEAPLGKHJ_43_MissionEventSelectLevel, json, false);
	}

	// // RVA: 0x90DADC Offset: 0x90DADC VA: 0x90DADC
	public void FJIGNIDBFMM(KPJHLACKGJF_EventMission _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
        KEODKEGFDLD_FreeMusicInfo mInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(_MOHDLLIJELH_cont.IGBPFGPPJOE());
        json["session_id"] = _MOHDLLIJELH_cont.FEKEBPKINIM_GetSessionId();
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["free_music_id"] = _MOHDLLIJELH_cont.IGBPFGPPJOE();
		json["music_id"] = mInfo.DLAEJOBELBH_MusicId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IGKMGFKKKHI_44_MissionEventSelectMusic, json, false);
	}

	// // RVA: 0x90DFBC Offset: 0x90DFBC VA: 0x90DFBC
	public void NIPOGLOEMCN(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina, KPJHLACKGJF_EventMission _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(json != null)
		{
			EDOHBJAPLPF_JsonData l = new EDOHBJAPLPF_JsonData();
			l.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String);
			ACBAHDMEFFL_EventMission.ONECEEIOJCP a = null;
			if(_MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() == 0)
			{
				a = _MOHDLLIJELH_cont.LOLJPCKNLGI(_MOHDLLIJELH_cont.MLLAMHMJFLP().BGFPMGPHGJJ_Mid1);
			}
			else if(_MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() == 1)
			{
				a = _MOHDLLIJELH_cont.LOLJPCKNLGI(_MOHDLLIJELH_cont.MLLAMHMJFLP().KEEHMNJCONJ_Mid2);
			}
			else if(_MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() == 2)
			{
				a = _MOHDLLIJELH_cont.LOLJPCKNLGI(_MOHDLLIJELH_cont.MLLAMHMJFLP().CFMIPHDGCAG_Mid3);
			}
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty;
			json["boost_ratio"] = _MOHDLLIJELH_cont.HADLPHIMBHH_BoostRatio;
			json["start_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["start_ranking"] = _MOHDLLIJELH_cont.CDINKAANIAA_Rank[0];
			if(a != null)
			{
				json["enemy_c_skill"] = a.MLKFDMFDFCE_enemy_c_skill;
				json["enemy_l_skill"] = a.DKOPDNHDLIA_enemy_l_skill;
			}
			else
			{
				json["enemy_c_skill"] = l;
				json["enemy_l_skill"] = l;
			}
			HADLOAPLCAF(json, OMNOFMEBLAD, _MOHDLLIJELH_cont);
			json["mission_id"] = l;
			json["lucky"] = l;
			json["mission_cnt"] = l;
			json["mission_clr_cnt"] = l;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FCIJOHCNLBB_31_MissionStageStart, json, false);
		}
	}

	// // RVA: 0x90E690 Offset: 0x90E690 VA: 0x90E690
	public void FEMJIFOMOCL(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, KPJHLACKGJF_EventMission _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if(json != null)
		{
			EDOHBJAPLPF_JsonData l = new EDOHBJAPLPF_JsonData();
			l.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String);
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["mission_id"] = l;
			json["difficulty"] = IJAOGPFKDBP.AKNELONELJK_difficulty;
			if(IJAOGPFKDBP.HBODCMLFDOB_result == 1)
			{
				json["base_point"] = 0;
				json["mission_bonus"] = _MOHDLLIJELH_cont.FHPEAPEANAI.PJEFKNPJEBE_MissionBonus;
				json["muisc_bonus"] = _MOHDLLIJELH_cont.FHPEAPEANAI.JKDICBNOGBL_MusicBonus;
				json["get_pt"] = _MOHDLLIJELH_cont.FHPEAPEANAI.JKFCHNEININ_GetPoint;
				if(_MOHDLLIJELH_cont.FHPEAPEANAI.PJEFKNPJEBE_MissionBonus < 101)
				{
					json["mission_result"] = 0;
				}
				else
				{
					json["mission_result"] = 1;
				}
			}
			else
			{
				json["base_point"] = 0;
				json["mission_bonus"] = 100;
				json["muisc_bonus"] = 100;
				json["mission_result"] = 0;
				json["get_pt"] = 0;
			}
			json["end_pt"] = (int)((int)json["get_pt"] + _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint());
			json["mission_cnt"] = l;
			json["mission_clr_cnt"] = l;
			json["lucky"] = l;
			ACBAHDMEFFL_EventMission.ONECEEIOJCP a = null;
			if(_MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() == 0)
			{
				a = _MOHDLLIJELH_cont.LOLJPCKNLGI(_MOHDLLIJELH_cont.MLLAMHMJFLP().BGFPMGPHGJJ_Mid1);
			}
			else if(_MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() == 1)
			{
				a = _MOHDLLIJELH_cont.LOLJPCKNLGI(_MOHDLLIJELH_cont.MLLAMHMJFLP().KEEHMNJCONJ_Mid2);
			}
			else if(_MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() == 2)
			{
				a = _MOHDLLIJELH_cont.LOLJPCKNLGI(_MOHDLLIJELH_cont.MLLAMHMJFLP().CFMIPHDGCAG_Mid3);
			}
			if(a != null)
			{
				json["enemy_c_skill"] = a.MLKFDMFDFCE_enemy_c_skill;
				json["enemy_l_skill"] = a.DKOPDNHDLIA_enemy_l_skill;
			}
			else
			{
				json["enemy_c_skill"] = l;
				json["enemy_l_skill"] = l;
			}
			json["boost_ratio"] = _MOHDLLIJELH_cont.HADLPHIMBHH_BoostRatio;
			json["mission_level"] = _MOHDLLIJELH_cont.BHNEJEDEHJA_SelectedCardIdx() + 1;
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EEGOAEADLDP_32_MissionStageEnd, json, false);
		}
	}

	// // RVA: 0x90F0FC Offset: 0x90F0FC VA: 0x90F0FC
	public void IENGPDCDMBM_MvStageStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _JPLMIPNGKEA_RemainMvTicket, int _AIMGOGFLILF_UseMvTicket)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KEODKEGFDLD_FreeMusicInfo mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		json["session_id"] = _MDADLCOCEBN_session_id;
		json["free_music_id"] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
		json["music_id"] = mData.DLAEJOBELBH_MusicId;
		if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty;
		else
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty + 10;
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
		json["remain_mv_ticket"] = _JPLMIPNGKEA_RemainMvTicket;
		json["use_mv_ticket"] = _AIMGOGFLILF_UseMvTicket;
		json["notes_speed"] = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DGCDPGPAAII_GetNotesSpeed((Difficulty.Type)OMNOFMEBLAD.AKNELONELJK_difficulty, false);
        NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting team = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GHDDPJBBEOC_Prism.GCINIJEMHFK_Get(mData.DLAEJOBELBH_MusicId);
        json["notes_disp"] = team.NLFMKOJHAHJ_nt;
		if(team.MKKGKKHABEK_vm == 0)
		{
			json["valkyrie_mode"] = JpStringLiterals.StringLiteral_11167;
		}
		else
		{
			json["valkyrie_mode"] = JpStringLiterals.StringLiteral_11168;
		}
		if(team.JPBJOGBGKGA_dm == 0)
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11167;
		}
		else
		{
			json["utahime_mode"] = JpStringLiterals.StringLiteral_11171;
		}
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(team.OCAMDLMPBGA_dv == 0 ? 1 : 0);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(team.PGCEGEJOOON_cs == 0 ? 1 : 0);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(team.EPDPAHNLMKH_vf == 0 ? 1 : 0);
		json["mv_setting"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.IENGPDCDMBM_45_MvStageStart/*45*/, json, false);
    }

	// // RVA: 0x910540 Offset: 0x910540 VA: 0x910540
	public void GDHNBIIOKMF_MvStageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KEODKEGFDLD_FreeMusicInfo mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		json["session_id"] = _MDADLCOCEBN_session_id;
		json["free_music_id"] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
		json["music_id"] = mData.DLAEJOBELBH_MusicId;
		if(IJAOGPFKDBP.LIDKENJKLGA_IsLine6 == 0)
		{
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty;
		}
		else
		{
			json["difficulty"] = OMNOFMEBLAD.AKNELONELJK_difficulty + 10;
		}
		json["result"] = IJAOGPFKDBP.HBODCMLFDOB_result;
		json["start_t"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(IJAOGPFKDBP.ICJEDACBMMF_start_t));
		if(IJAOGPFKDBP.IMIEPNOECFD_ValkyrieMode == 0)
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
		json["ave_fps"] = IJAOGPFKDBP.LMOBPKIDIHF_ave_fps;
		json["low_fps"] = IJAOGPFKDBP.IPAAOFCGEAB_low_fps;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.GDHNBIIOKMF_46_MvStageEnd/*46*/, json, false);
	}

	// // RVA: 0x910ECC Offset: 0x910ECC VA: 0x910ECC
	public void GADJDBJLIGC_ViewMovie(int _LKNCHJCLLFN_MusicId, string _OJBLOEBPHIE_MovieName, string _GGPGIALKGFG_MovieUrl)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["music_id"] = _LKNCHJCLLFN_MusicId;
		json["movie_name"] = _OJBLOEBPHIE_MovieName;
		json["movie_url"] = _GGPGIALKGFG_MovieUrl;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.GADJDBJLIGC_47_ViewMovie, json, false);
	}

	// // RVA: 0x911200 Offset: 0x911200 VA: 0x911200
	public void DBNECDJCNOI_ShopBuy(int _DLLJMINACDN_ShopId, string GEGCFOCMEKD_ShopName, int FNNGLNPIKOL_LineupId, int _DJJGPACGEMM_product_id, int IPJBPBDCCPF_ConsumeItemId, int _HABCGPMKBJK_ConsumeItemCount, int _PEKOLGMLJAL_AfterConsumeItemCount, int BGHCIAOANCF_BuyItemId, int _GJNAOBBAPOF_BuyItemCount, int _FFBPGKHIKGD_AfterBuyItemCount, int KMFLNILNPJD_Cnt, int _JPLLMKIDNBM_BuyCountTotal, int HMFDJHEEGNN_buy_limit, long _DECPPKAAHFA_BuyLimitDate, int _NFBLLKHBMEK_SakashoProductId, string _DJPBDDBNMLN_SakashoProductName)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["shop_id"] = _DLLJMINACDN_ShopId;
		json["shop_name"] = GEGCFOCMEKD_ShopName;
		json["lineup_id"] = FNNGLNPIKOL_LineupId;
		json["product_id"] = _DJJGPACGEMM_product_id;
		json["consume_item_id"] = IPJBPBDCCPF_ConsumeItemId;
		json["consume_item_count"] = _HABCGPMKBJK_ConsumeItemCount;
		json["consume_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(IPJBPBDCCPF_ConsumeItemId);
		json["af_consume_item_count"] = _PEKOLGMLJAL_AfterConsumeItemCount;
		json["buy_item_id"] = BGHCIAOANCF_BuyItemId;
		json["buy_item_count"] = _GJNAOBBAPOF_BuyItemCount;
		json["buy_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(BGHCIAOANCF_BuyItemId);
		json["af_buy_item_count"] = _FFBPGKHIKGD_AfterBuyItemCount;
		json["buy_count"] = KMFLNILNPJD_Cnt;
		json["buy_count_total"] = _JPLLMKIDNBM_BuyCountTotal;
		json["buy_limit"] = HMFDJHEEGNN_buy_limit;
		json["sakasho_product_id"] = _NFBLLKHBMEK_SakashoProductId;
		json["sakasho_product_name"] = _DJPBDDBNMLN_SakashoProductName;
		if(_DECPPKAAHFA_BuyLimitDate == 0)
		{
			json["buy_limit_date"] = "3000-01-01 00:00:00";
		}
		else
		{
			json["buy_limit_date"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(_DECPPKAAHFA_BuyLimitDate));
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DBNECDJCNOI_48_ShopBuy, json, false);
	}

	// // RVA: 0x911BA4 Offset: 0x911BA4 VA: 0x911BA4
	public void CBKENDJIBDM_MvChange(string _JKJDGDLAIME_Place, int _LKNCHJCLLFN_MusicId, int _KAAENFOCPLN_BfEnable, int[] _OCJACPIJCBL_BfDivaId, int[] _POEMOGPOGPN_BfCostumeId, int _BBNEDFIJFEN_BfValk, int _GGPDPDMODPL_AfEnable, int[] _KJEHAHAKGDE_AfDivaId, int[] _OKIMFNNDGGP_AfCostumeId, int _FEFHFFGBOEM_AfValk)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["music_id"] = _LKNCHJCLLFN_MusicId;
		json["place"] = _JKJDGDLAIME_Place;
		json["bf_enable"] = _KAAENFOCPLN_BfEnable;
		json["af_enable"] = _GGPDPDMODPL_AfEnable;
		json["bf_diva_id"] = _OCJACPIJCBL_BfDivaId[0];
		json["bf_diva_id2"] = _OCJACPIJCBL_BfDivaId[1];
		json["bf_diva_id3"] = _OCJACPIJCBL_BfDivaId[2];
		json["af_diva_id"] = _KJEHAHAKGDE_AfDivaId[0];
		json["af_diva_id2"] = _KJEHAHAKGDE_AfDivaId[1];
		json["af_diva_id3"] = _KJEHAHAKGDE_AfDivaId[2];
		json["bf_valkyrie_id"] = _BBNEDFIJFEN_BfValk;
		json["af_valkyrie_id"] = _FEFHFFGBOEM_AfValk;
		json["bf_costume_id"] = _POEMOGPOGPN_BfCostumeId[0];
		json["bf_costume_id2"] = _POEMOGPOGPN_BfCostumeId[1];
		json["bf_costume_id3"] = _POEMOGPOGPN_BfCostumeId[2];
		json["af_costume_id"] = _OKIMFNNDGGP_AfCostumeId[0];
		json["af_costume_id2"] = _OKIMFNNDGGP_AfCostumeId[1];
		json["af_costume_id3"] = _OKIMFNNDGGP_AfCostumeId[2];
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CBKENDJIBDM_49_MvChange, json, false);
	}

	// // RVA: 0x91251C Offset: 0x91251C VA: 0x91251C
	public void LIPHGGFEJFJ_EventBoxGacha(int _IMMDGJAOPCD_BoxId, int _HMFFHLPNMPH_count, int _EIILNOEOICO_AfRest, int _COJALPJKKDL_Boxtotal, int _JGGKJBCGKCC_use_item_id, int _KJMLLBDLKCG_use_item_num, int _GDAGHLJDKGK_AfUseItemNum, CHHECNJBMLA_EventBoxGacha _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["count"] = _HMFFHLPNMPH_count;
		json["box_id"] = _IMMDGJAOPCD_BoxId;
		json["af_rest"] = _EIILNOEOICO_AfRest;
		json["box_total"] = _COJALPJKKDL_Boxtotal;
		json["use_item_id"] = _JGGKJBCGKCC_use_item_id;
		json["use_item_num"] = _KJMLLBDLKCG_use_item_num;
		json["af_use_item_num"] = _GDAGHLJDKGK_AfUseItemNum;
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < _MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult.Count; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult[i].KIJAPOFAGPN_ItemId);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult[i].HMFFHLPNMPH_count);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult[i].PPFNGGCBJKC_id);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult[i].CONGLCLANMP_Remain);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult[i].FPFKNDKENIC);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.PNLJHCDHKCP_LotResult[i].AEDMJLGNDHN_IsSp);
		}
		json["lot_result"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LIPHGGFEJFJ_50_EventBoxGacha, json, false);
	}

	// // RVA: 0x912DAC Offset: 0x912DAC VA: 0x912DAC
	public void LCDPEMIFNKJ_RemoveExpiredItem(int _GLCLFMGPMAN_ItemId, int _MBJIFDBEDAC_item_count)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["remove_item_id"] = _GLCLFMGPMAN_ItemId;
		json["remove_item_num"] = _MBJIFDBEDAC_item_count;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LCDPEMIFNKJ_51_RemoveExpiredItem, json, false);
	}

	// // RVA: 0x913094 Offset: 0x913094 VA: 0x913094
	public void ICAHGJMMGLM_ArTitleStart(string _KMDDJIEPNMF_ArSessionId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_session_id"] = _KMDDJIEPNMF_ArSessionId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ICAHGJMMGLM_52_ArTitleStart, json, false);
	}

	// // RVA: 0x913330 Offset: 0x913330 VA: 0x913330
	public void BGJDJBOCLEA_ArSceneStart(string _KMDDJIEPNMF_ArSessionId, int _HBODCMLFDOB_result, string _OHLHAIIBLBI_FailureReason)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_session_id"] = _KMDDJIEPNMF_ArSessionId;
		json["result"] = _HBODCMLFDOB_result;
		json["failure_reason"] = _OHLHAIIBLBI_FailureReason;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.BGJDJBOCLEA_53_ArSceneStart, json, false);
	}

	// // RVA: 0x913664 Offset: 0x913664 VA: 0x913664
	public void ILLBGAFIBDE_ArMarker(string _KMDDJIEPNMF_ArSessionId, int _FJABGCFCPMH_ArMarkerNo, string _INAMDCCEBOH_ArEventId, string _FNOBKBIFBJG_ArMarkerId, bool _NDODFAPMMEB_IsNewMarker)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_marker_no"] = _FJABGCFCPMH_ArMarkerNo;
		json["ar_session_id"] = _KMDDJIEPNMF_ArSessionId;
		json["ar_event_id"] = _INAMDCCEBOH_ArEventId;
		json["ar_marker_id"] = _FNOBKBIFBJG_ArMarkerId;
		json["is_new_marker"] = _NDODFAPMMEB_IsNewMarker;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ILLBGAFIBDE_54_ArMarker, json, false);
	}

	// // RVA: 0x913A60 Offset: 0x913A60 VA: 0x913A60
	public void KIFPDEFNEPB_ArPhoto(string _KMDDJIEPNMF_ArSessionId, int _FJABGCFCPMH_ArMarkerNo, string _INAMDCCEBOH_ArEventId, string _FNOBKBIFBJG_ArMarkerId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_marker_no"] = _FJABGCFCPMH_ArMarkerNo;
		json["ar_session_id"] = _KMDDJIEPNMF_ArSessionId;
		json["ar_event_id"] = _INAMDCCEBOH_ArEventId;
		json["ar_marker_id"] = _FNOBKBIFBJG_ArMarkerId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.KIFPDEFNEPB_55_ArPhoto, json, false);
	}

	// // RVA: 0x913DE0 Offset: 0x913DE0 VA: 0x913DE0
	public void PHLHLIDCNNN_ArShare(string _KMDDJIEPNMF_ArSessionId, int _FJABGCFCPMH_ArMarkerNo, string _INAMDCCEBOH_ArEventId, string _FNOBKBIFBJG_ArMarkerId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["ar_marker_no"] = _FJABGCFCPMH_ArMarkerNo;
		json["ar_session_id"] = _KMDDJIEPNMF_ArSessionId;
		json["ar_event_id"] = _INAMDCCEBOH_ArEventId;
		json["ar_marker_id"] = _FNOBKBIFBJG_ArMarkerId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PHLHLIDCNNN_56_ArShare, json, false);
	}

	// // RVA: 0x914160 Offset: 0x914160 VA: 0x914160
	public void DNNLEIKNHKL_DivaIntimacyExpAdd(int _DIPKCALNIII_diva_id, int _NHCCINMHEAB_Tension, int _GOKMANFHFPC_get_exp, int _HHAMIAPINGE_AfExp, int _MJKGDEOKFNK_BfLv, int _NCMCPNPOLEB_AfLv, string _JKJDGDLAIME_Place, int CMJHOGBIOKM, int ADIFCNPMKJH, int _DMMKFOLEGKO_FavBonus, int _PMJKECBJBGP_TensionBonus)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["diva_id"] = _DIPKCALNIII_diva_id;
		json["tension"] = _NHCCINMHEAB_Tension;
		json["get_exp"] = _GOKMANFHFPC_get_exp;
		json["af_exp"] = _HHAMIAPINGE_AfExp;
		json["bf_lv"] = _MJKGDEOKFNK_BfLv;
		json["af_lv"] = _NCMCPNPOLEB_AfLv;
		json["place"] = _JKJDGDLAIME_Place;
		json["present_item_info"] = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, CMJHOGBIOKM) + ":" + ADIFCNPMKJH;
		json["favorite_bonus"] = _DMMKFOLEGKO_FavBonus;
		json["tension_bonus"] = _PMJKECBJBGP_TensionBonus;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DNNLEIKNHKL_57_DivaIntimacyExpAdd, json, false);
	}

	// // RVA: 0x914720 Offset: 0x914720 VA: 0x914720
	public void CDNFJBAJAMM_PresentCampaignEntry(CANAFALMGLI_EventPresentCampaign _MOHDLLIJELH_cont, int _JBEFLJENKAC_DayId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["day_id"] = _JBEFLJENKAC_DayId;
		json["entry_date"] = _MOHDLLIJELH_cont.JFHOMINJHJK_GetEntryDate();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CDNFJBAJAMM_58_PresentCampaignEntry, json, false);
	}

	// // RVA: 0x914ABC Offset: 0x914ABC VA: 0x914ABC
	public void BLDDKDNOCFA_PresentCampaignResult(CANAFALMGLI_EventPresentCampaign _MOHDLLIJELH_cont, string _EBAMGNMELPO_EntryDate, string _HBODCMLFDOB_result)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["entry_date"] = _EBAMGNMELPO_EntryDate;
		json["result"] = _HBODCMLFDOB_result;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.BLDDKDNOCFA_59_PresentCampaignResult, json, false);
	}

	// // RVA: 0x914E50 Offset: 0x914E50 VA: 0x914E50
	public void DADNPOJNIBL_EventHome(IKDICBBFBMI_EventBase _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DADNPOJNIBL_60_EventHome, json, false);
	}

	// // RVA: 0x91514C Offset: 0x91514C VA: 0x91514C
	public void LIIJEGOIKDP_Adventure(int _FMJECOKINMO_AdventureId, OAGBCBBHMPF.DKAMMIHBINF_AdventureSource _JKJDGDLAIME_Place)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["adventure_id"] = _FMJECOKINMO_AdventureId;
		json["place"] = OAGBCBBHMPF.BHKNBCJGBDG[(int)_JKJDGDLAIME_Place];
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LIIJEGOIKDP_61_Adventure/*61*/, json, false);
	}

	// // RVA: 0x9154B4 Offset: 0x9154B4 VA: 0x9154B4
	public void BKLNHBHDDEJ_VopTransition(string _INDDJNMPONH_type)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["type"] = _INDDJNMPONH_type;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.BKLNHBHDDEJ_63_VopTransition, json, false);
	}

	// // RVA: 0x915750 Offset: 0x915750 VA: 0x915750
	public void DAGHKCKEJPA_VopAppearence(BOPFPIHGJMD.MLBMHDCCGHI_OfferType _ODMEBOKPNAF_Type, int _AAKPLIFKIJK_OperationId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["type"] = (int)_ODMEBOKPNAF_Type;
		json["operation_id"] = _AAKPLIFKIJK_OperationId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DAGHKCKEJPA_64_VopAppearence, json, false);
	}

	// // RVA: 0x915A38 Offset: 0x915A38 VA: 0x915A38
	public void OEGCKACJMPM_VopOrders(BOPFPIHGJMD.MLBMHDCCGHI_OfferType _ODMEBOKPNAF_Type, int _AAKPLIFKIJK_OperationId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(_ODMEBOKPNAF_Type, _AAKPLIFKIJK_OperationId);
        OCMJNBIFJNM_Offer.JPOHOLBBFGP of2 = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(_ODMEBOKPNAF_Type, _AAKPLIFKIJK_OperationId);
        json["session_id"] = of2.BDJMFDKLHPM_s_id;
		json["type"] = (int)_ODMEBOKPNAF_Type;
		json["operation_id"] = _AAKPLIFKIJK_OperationId;
		JBBHNIACMFJ.Length = 0;
		OCMJNBIFJNM_Offer.PMOECIDOLNA of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[of2.OIOECMEEFKJ_VFp - 1];
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
		json["vfp_name"] = of.OPFGFINHFCE_name;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.OEGCKACJMPM_65_VopOrders, json, false);
	}

	// // RVA: 0x9162E0 Offset: 0x9162E0 VA: 0x9162E0
	public void ONPIDKLOPIP_VopResults(BOPFPIHGJMD.MLBMHDCCGHI_OfferType _ODMEBOKPNAF_Type, int _AAKPLIFKIJK_OperationId, int _KMPBAKBKEGH_ResultType)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(_ODMEBOKPNAF_Type, _AAKPLIFKIJK_OperationId);
		json["session_id"] = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(_ODMEBOKPNAF_Type, _AAKPLIFKIJK_OperationId).BDJMFDKLHPM_s_id;
		json["type"] = (int)_ODMEBOKPNAF_Type;
		json["operation_id"] = _AAKPLIFKIJK_OperationId;
		json["result_type"] = _KMPBAKBKEGH_ResultType;
		if(_KMPBAKBKEGH_ResultType == 0)
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
				JBBHNIACMFJ.Append(KDHGBOOECKC.HHCJCDFCLOB.IKENGGJIJJO().BHKKEJJMMDD[i].PPFNGGCBJKC_id);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(KDHGBOOECKC.HHCJCDFCLOB.IKENGGJIJJO().BHKKEJJMMDD[i].BFINGCJHOHI_cnt);
				b = true;
			}
			json["drop_info"] = JBBHNIACMFJ.ToString();
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ONPIDKLOPIP_66_VopResults, json, false);
	}

	// // RVA: 0x916A08 Offset: 0x916A08 VA: 0x916A08
	public void BABLKKLEPGD_CostumeEnhance(int _BEEAIAAJOHD_CostumeId, int _MMEIOJKLCKK_bf_main_lv, int _PNMKPKMDOND_af_main_lv, int _FCJLPINNDKN_BfPoint, int _KJDKJGGHHIF_AfPoint, int _GLCLFMGPMAN_ItemId, int _CLLKANEGGBJ_ItemCount, int _NEMMJLNMEHB_money)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["costume_id"] = _BEEAIAAJOHD_CostumeId;
		json["bf_main_lv"] = _MMEIOJKLCKK_bf_main_lv;
		json["af_main_lv"] = _PNMKPKMDOND_af_main_lv;
		json["bf_pt"] = _FCJLPINNDKN_BfPoint;
		json["af_pt"] = _KJDKJGGHHIF_AfPoint;
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(_GLCLFMGPMAN_ItemId);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(_CLLKANEGGBJ_ItemCount);
		json["item_info"] = JBBHNIACMFJ.ToString();
		json["money"] = _NEMMJLNMEHB_money;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.BABLKKLEPGD_67_CostumeEnhance, json, false);
	}

	// // RVA: 0x916F48 Offset: 0x916F48 VA: 0x916F48
	public void PLEKHHPMELF_HealItemConsume(int _GOIKCKHMBDL_FreeMusicId, int _JGGKJBCGKCC_use_item_id, int _MKNKJMFILFB_Af)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["af"] = _MKNKJMFILFB_Af;
		json["use_item_id"] = _JGGKJBCGKCC_use_item_id;
		json["heal_music_id"] = _GOIKCKHMBDL_FreeMusicId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PLEKHHPMELF_68_HealItemConsume, json, false);
	}

	// // RVA: 0x91727C Offset: 0x91727C VA: 0x91727C
	public void LPKDNOINDPE_SubscriptionUpdate(long _CBJBEGPLJDO_StartedAt, long _LPHAOMAKKNF_ExpiredAt, long _FDAEDIPOONF_GoogleStartedAt, long _PCHNPJFFJJM_GoogleExpiredAt, long _CPFDDHIEODD_AppleStartedAt, long _LCNMPBBDGPJ_AppleExpiredAt, long _BMHKJPHNCIJ_BfStartedAt, long _KMJCPOGCJDG_BfExpiredAt, long _PPKCOLEJLLG_AfStartedAt, long _BGOLKLJBAHD_AfExpiredAt, OAGBCBBHMPF.NALHDBIKFJO _GAFIOALKHIM_BfStatus, OAGBCBBHMPF.NALHDBIKFJO _PMKOEGJAEDN_AfStatus, string _EEMFGMEEBDC_BfPlatform, string _NJFKGJKINAG_AfPlatform, int _IHJMMPHPHEM_ApiCallTime, string _EJJNDLJIIIF_ErrorCode)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["raw_started_at"] = COPGJHJGHJG_TimestampToString(_CBJBEGPLJDO_StartedAt);
		json["raw_expired_at"] = COPGJHJGHJG_TimestampToString(_LPHAOMAKKNF_ExpiredAt);
		json["google_started_at"] = COPGJHJGHJG_TimestampToString(_FDAEDIPOONF_GoogleStartedAt);
		json["google_expired_at"] = COPGJHJGHJG_TimestampToString(_PCHNPJFFJJM_GoogleExpiredAt);
		json["apple_started_at"] = COPGJHJGHJG_TimestampToString(_CPFDDHIEODD_AppleStartedAt);
		json["apple_expired_at"] = COPGJHJGHJG_TimestampToString(_LCNMPBBDGPJ_AppleExpiredAt);
		json["bf_started_at"] = COPGJHJGHJG_TimestampToString(_BMHKJPHNCIJ_BfStartedAt);
		json["af_started_at"] = COPGJHJGHJG_TimestampToString(_PPKCOLEJLLG_AfStartedAt);
		json["bf_expired_at"] = COPGJHJGHJG_TimestampToString(_KMJCPOGCJDG_BfExpiredAt);
		json["af_expired_at"] = COPGJHJGHJG_TimestampToString(_BGOLKLJBAHD_AfExpiredAt);
		json["bf_status"] = (int)_GAFIOALKHIM_BfStatus;
		json["af_status"] = (int)_PMKOEGJAEDN_AfStatus;
		json["bf_platform"] = _EEMFGMEEBDC_BfPlatform;
		json["af_platform"] = _NJFKGJKINAG_AfPlatform;
		json["api_call_time"] = _IHJMMPHPHEM_ApiCallTime;
		json["error_code"] = _EJJNDLJIIIF_ErrorCode;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LPKDNOINDPE_62_SubscriptionUpdate, json, false);
	}

	// // RVA: 0x917AB4 Offset: 0x917AB4 VA: 0x917AB4
	public void FJBCAHAFLNO_VopDivaTouch()
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FJBCAHAFLNO_69_VopDivaTouch, json, false);
	}

	// // RVA: 0x917CD8 Offset: 0x917CD8 VA: 0x917CD8
	public void FDFMKBGPALI_VopFastComplete(BOPFPIHGJMD.MLBMHDCCGHI_OfferType _ODMEBOKPNAF_Type, int _AAKPLIFKIJK_OperationId, int _GLCLFMGPMAN_ItemId, int _CLLKANEGGBJ_ItemCount, int _PJIOJCFCFOK_AfItemNum, int _BIKHKIGMEMA_RestTime)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(_ODMEBOKPNAF_Type, _AAKPLIFKIJK_OperationId);
		json["session_id"] = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(_ODMEBOKPNAF_Type, _AAKPLIFKIJK_OperationId).BDJMFDKLHPM_s_id;
		json["type"] = (int)_ODMEBOKPNAF_Type;
		json["operation_id"] = _AAKPLIFKIJK_OperationId;
		json["use_item_id"] = _GLCLFMGPMAN_ItemId;
		json["use_item_num"] = _CLLKANEGGBJ_ItemCount;
		json["af_item_num"] = _PJIOJCFCFOK_AfItemNum;
		json["rest_time"] = _BIKHKIGMEMA_RestTime;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FDFMKBGPALI_70_VopFastComplete, json, false);
	}

	// // RVA: 0x9181C4 Offset: 0x9181C4 VA: 0x9181C4
	public void PHCLHGPCFNL_LobbySelectGroup(NKOBMDPHNGP_EventRaidLobby _MOHDLLIJELH_cont, int _OIDBPKAKOJA_GroupId, int _MEBHCFJCKFE_LobbyId, string _FMGBPEHHJEA_GroupName, int _CJHEHIMLGGL_Position, int _AHGJCJFOMIP_Capacity, string _AMMJLEOFFDO_JoinInfo)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["lobby_id"] = _MEBHCFJCKFE_LobbyId;
		json["group_id"] = _OIDBPKAKOJA_GroupId;
		json["group_name"] = _FMGBPEHHJEA_GroupName;
		json["position"] = _CJHEHIMLGGL_Position;
		json["capacity"] = _AHGJCJFOMIP_Capacity;
		json["join_info"] = _AMMJLEOFFDO_JoinInfo;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PHCLHGPCFNL_75_LobbySelectGroup, json, false);
	}

	// // RVA: 0x918694 Offset: 0x918694 VA: 0x918694
	// public void NJMBKGKPCKL() { }

	// // RVA: 0x918698 Offset: 0x918698 VA: 0x918698
	// public void PEBDGCDNPDM_LobbyTransition(NKOBMDPHNGP_EventRaidLobby _MOHDLLIJELH_cont, string _INDDJNMPONH_type) { }
	// event_id = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId
	// event_name = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName
	// type = _INDDJNMPONH_type

	// // RVA: 0x9189E0 Offset: 0x9189E0 VA: 0x9189E0
	// public void LHCHBHPHLCP_LobbyVisit() { }

	// // RVA: 0x9189E4 Offset: 0x9189E4 VA: 0x9189E4
	// public void OOBKCHBNAOF() { }

	// // RVA: 0x9189E8 Offset: 0x9189E8 VA: 0x9189E8
	private void HBOONEFDMJL(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ _GJFJLEOGFLD_RaidBoss)
	{
		_IDLHJIOMJBK_data["boss_instance_id"] = _GJFJLEOGFLD_RaidBoss.PPFNGGCBJKC_id;
		_IDLHJIOMJBK_data["boss_unique_key"] = _GJFJLEOGFLD_RaidBoss.MMEBLOIJBKE_UniqueKey;
		_IDLHJIOMJBK_data["boss_hp_max"] = _GJFJLEOGFLD_RaidBoss.PIKKHCGNGNN_HpMax;
		_IDLHJIOMJBK_data["boss_hp"] = _GJFJLEOGFLD_RaidBoss.BCCOMAODPJI_hp;
		_IDLHJIOMJBK_data["boss_lv"] = _GJFJLEOGFLD_RaidBoss.ANAJIAENLNB_lv;
		_IDLHJIOMJBK_data["boss_sp"] = _GJFJLEOGFLD_RaidBoss.IKICLMGFFPB_IsSpecial ? 1 : 0;
		_IDLHJIOMJBK_data["boss_rank"] = _GJFJLEOGFLD_RaidBoss.FJOLNJLLJEJ_rank;
		switch(_GJFJLEOGFLD_RaidBoss.CMCKNKKCNDK_status)
		{
			case NHCDBBBMFFG_BossStatus.HJNNKCMLGFL_0_None:
				_IDLHJIOMJBK_data["boss_status"] = "None";
				break;
			case NHCDBBBMFFG_BossStatus.MBFHILFLPJL_1_Alive:
				_IDLHJIOMJBK_data["boss_status"] = "Alive";
				break;
			case NHCDBBBMFFG_BossStatus.OPNEOJEGDJB_2_Dead:
				_IDLHJIOMJBK_data["boss_status"] = "Dead";
				break;
			case NHCDBBBMFFG_BossStatus.NFDONDKDHPK_3_Escaped:
				_IDLHJIOMJBK_data["boss_status"] = "Escaped";
				break;
		}
		_IDLHJIOMJBK_data["boss_escape_at"] = _GJFJLEOGFLD_RaidBoss.AJCCONCCIMF_EscapeAt;
		_IDLHJIOMJBK_data["boss_encount_player_id"] = _GJFJLEOGFLD_RaidBoss.MLPEHNBNOGD_PlayerId;
		_IDLHJIOMJBK_data["boss_mission_id"] = _GJFJLEOGFLD_RaidBoss.JOMGCCBFKEF_MissionId;
		_IDLHJIOMJBK_data["boss_mission_bonus"] = _GJFJLEOGFLD_RaidBoss.NFOOOBMJINC_MissionBonusNum;
		_IDLHJIOMJBK_data["boss_attack_player_count"] = _GJFJLEOGFLD_RaidBoss.MHABJOMJCFI_AttackPlayerCount;
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 1; i < 5; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(_GJFJLEOGFLD_RaidBoss.DOJHNCMHNEI_GetMyAttackCount((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType)i));
			b = true;
		}
		_IDLHJIOMJBK_data["boss_my_attack_counts"] = JBBHNIACMFJ.ToString();
		JBBHNIACMFJ.Length = 0;
		b = false;
		for(int i = 1; i < 5; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(_GJFJLEOGFLD_RaidBoss.LGKOMGPLKDK_GetOtherAttackCount((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType)i));
			b = true;
		}
		_IDLHJIOMJBK_data["boss_other_attack_counts"] = JBBHNIACMFJ.ToString();
	}

	// // RVA: 0x919268 Offset: 0x919268 VA: 0x919268
	public void LOGBJCFCJND_RaidStageStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina, PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(json != null)
		{
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
			HBOONEFDMJL(json, _MOHDLLIJELH_cont.JIBMOEHKMGB_SelectedBoss);
			JBBHNIACMFJ.Length = 0;
			bool b = false;
			for(int i = 0; i < _MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList.Count; i++)
			{
				if(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList[i].NFAPNIKALBK_Active)
				{
					if(b)
					{
						JBBHNIACMFJ.Append(',');
					}
					JBBHNIACMFJ.Append("1:");
					JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList[i].IFGEJDMMAHE_Info.JPIDIENBGKH_CostumeId);
					JBBHNIACMFJ.Append(':');
					JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeList[i].DJJGNDCMNHF_BonusValue);
					b = true;
				}
			}
			for(int i = 0; i < _MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList.Count; i++)
			{
				if(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList[i].NFAPNIKALBK_Active)
				{
					if(b)
					{
						JBBHNIACMFJ.Append(',');
					}
					JBBHNIACMFJ.Append("2:");
					JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkList[i].IFGEJDMMAHE_Info.GPPEFLKGGGJ_ValkyrieId);
					JBBHNIACMFJ.Append(':');
					JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.KMEDEGMLEBF_UnitBonusValkyrie);
					b = true;
				}
			}
			for(int i = 0; i < _MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList.Count; i++)
			{
				if(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList[i].COHCODJHJFM)
				{
					if(b)
					{
						JBBHNIACMFJ.Append(',');
					}
					JBBHNIACMFJ.Append("3:");
					JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.BBAJKJPKOHD_EpisodeList[i].PPFNGGCBJKC_id);
					JBBHNIACMFJ.Append(':');
					JBBHNIACMFJ.Append(_MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.LHPJLNGEFEL_UnitBonusEpisode);
					b = true;
				}
			}
			json["unit_bonus"] = _MOHDLLIJELH_cont.ANMBIEIFKFF_UnitBonusInfo.HOJAKNJFIFJ_EpisodeBonusPoint;
			json["unit_bonus_info"] = JBBHNIACMFJ.ToString();
			if(_MOHDLLIJELH_cont.CFLEMFADGLG_AttackType == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType.LPNPLGJJCPC_2_Support)
			{
				json["attack_type"] = JpStringLiterals.StringLiteral_11428;
			}
			else if(_MOHDLLIJELH_cont.CFLEMFADGLG_AttackType == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType.OOEHFFBHCIC_3_Full)
			{
				json["attack_type"] = JpStringLiterals.StringLiteral_11429;
			}
			else if(_MOHDLLIJELH_cont.CFLEMFADGLG_AttackType == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType.EKIGHDLEBAH_4_MacrossCanon)
			{
				json["attack_type"] = JpStringLiterals.StringLiteral_11430;
			}
			else
			{
				json["attack_type"] = JpStringLiterals.StringLiteral_11431;
			}
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LOGBJCFCJND_71_RaidStageStart, json, false);
		}
	}

	// // RVA: 0x919FE4 Offset: 0x919FE4 VA: 0x919FE4
	public void FIPDFLHPNDO_RaidStageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if(json != null)
		{
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
			HBOONEFDMJL(json, _MOHDLLIJELH_cont.JIBMOEHKMGB_SelectedBoss);
			json["score_pt"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.JKLNANHPJLO_ScorePoint;
			json["vf_pt"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.CBKFBBNPIGG_ValkyriePoint;
			json["kasho_bonus"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.EAOCJMFLBJI_PointBonus;
			json["unit_bonus"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.FOOCMHPJJAP_DivaBonus;
			json["coop_bonus"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.CLNPBIJBIIJ_SupportBonus;
			json["damage_pt"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.HACIJLMFDAE_TotalPoint;
			json["mc_guage_add"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.IHIJGIHNOAL_CannonGaugeAdd;
			json["mc_guage_af"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.NPPEPJHBPNE_CannonGauge;
			json["boss_mission_result"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.PAACIPCHDDE_MissionCompleted ? 1 : 0;
			json["get_pt"] = _MOHDLLIJELH_cont.PLFBKEPLAAA.HALIDDHLNEG_Damage;
			json["end_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.FIPDFLHPNDO_72_RaidStageEnd, json, false);
		}
	}

	// // RVA: 0x91A6B0 Offset: 0x91A6B0 VA: 0x91A6B0
	public void KCCMKAEPGPE_RaidBossEncounter(PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont, int _JGGKJBCGKCC_use_item_id, int _KJMLLBDLKCG_use_item_num, int _NMANGFCHCFB_AfItemNum)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
        PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ boss = _MOHDLLIJELH_cont.PMIIMELDPAJ_GetMyBoss();
        if (boss != null)
		{
			HBOONEFDMJL(json, boss);
			json["use_item_id"] = _JGGKJBCGKCC_use_item_id;
			json["use_item_num"] = _KJMLLBDLKCG_use_item_num;
			json["af_item_num"] = _NMANGFCHCFB_AfItemNum;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.KCCMKAEPGPE_73_RaidBossEncounter, json, false);
		}
	}

	// // RVA: 0x91ABC4 Offset: 0x91ABC4 VA: 0x91ABC4
	public void ONMOONKHHLO_RaidBossAppearence(PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ _GJFJLEOGFLD_RaidBoss)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
		HBOONEFDMJL(json, _GJFJLEOGFLD_RaidBoss);
		json["can_help"] = _GJFJLEOGFLD_RaidBoss.CAKONDPGDIL_CanRequestHelp ? 1 : 0;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ONMOONKHHLO_92_RaidBossAppearence, json, false);
	}

	// // RVA: 0x91B040 Offset: 0x91B040 VA: 0x91B040
	public void BACAKFPEMAF(PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont, bool _PJJLOFMLOMN_OnlyMyLobby, bool _MCMPOEHAIHP_PrioFriend, List<PKNOKJNLPOE_EventRaid.ECICDAPCMJG> MOCDACANBIG)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
		if(_MOHDLLIJELH_cont.PMIIMELDPAJ_GetMyBoss() != null)
		{
			HBOONEFDMJL(json, _MOHDLLIJELH_cont.PMIIMELDPAJ_GetMyBoss());
		}
		json["only_my_lobby"] = _PJJLOFMLOMN_OnlyMyLobby ? 1 : 0;
		json["prior_friend"] = _MCMPOEHAIHP_PrioFriend ? 1 : 0;
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < MOCDACANBIG.Count; i++)
		{
			if(b)
			{
				JBBHNIACMFJ.Append(',');
			}
			JBBHNIACMFJ.Append(MOCDACANBIG[i].MLPEHNBNOGD_PlayerId);
			JBBHNIACMFJ.Append(':');
			JBBHNIACMFJ.Append(MOCDACANBIG[i].HKAIJKGODHC);
			b = true;
		}
		json["helper"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.KCCMKAEPGPE_73_RaidBossEncounter, json, false);
	}

	// // RVA: 0x91B758 Offset: 0x91B758 VA: 0x91B758
	public void ICDCMLKMEHI_HealAp(int _APJBBOHHFNE_heal, int _MKNKJMFILFB_Af, int _GLCLFMGPMAN_ItemId, int _ECEKFEFOFNI_UseItemCount, string _JKJDGDLAIME_Place)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["heal"] = _APJBBOHHFNE_heal;
		json["af"] = _MKNKJMFILFB_Af;
		json["place"] = _JKJDGDLAIME_Place;
		json["use_item_id"] = _GLCLFMGPMAN_ItemId;
		json["use_item_count"] = _ECEKFEFOFNI_UseItemCount;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ICDCMLKMEHI_77_HealAp, json, false);
	}

	// // RVA: 0x91BB28 Offset: 0x91BB28 VA: 0x91BB28
	public void EEHEMNBJPAP_RaidBossAttack(PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont, JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH_AttackType _CFLEMFADGLG_AttackType, int _AFFGGBLNPFJ_GetPt, int _EENFAGBJHPP_EndPt, SakashoRaidbossEffectData _NKDGDKKEPOO_EffectData, JPPCMHKHAGC_AttackRaidbossAndSave.ODNJNIICCLB HFBEDHKIBJA, string _MDADLCOCEBN_session_id)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
        json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
        json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
        json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
		if(_MOHDLLIJELH_cont.JIBMOEHKMGB_SelectedBoss != null)
            HBOONEFDMJL(json, _MOHDLLIJELH_cont.JIBMOEHKMGB_SelectedBoss);
        json["effect_id"] = _NKDGDKKEPOO_EffectData.EffectId;
        json["effect_num"] = _NKDGDKKEPOO_EffectData.NumberOfTimes;
        json["effect_duration"] = _NKDGDKKEPOO_EffectData.DurationSeconds;
        json["attack_type"] = OAGBCBBHMPF.GNIPLCBMPEG_RaidAttackType[(int)_CFLEMFADGLG_AttackType];
        json["session_id"] = _MDADLCOCEBN_session_id;
        //MOHDLLIJELH_cont.PLFBKEPLAAA;
        json["get_pt"] = _AFFGGBLNPFJ_GetPt;
        json["end_pt"] = _EENFAGBJHPP_EndPt;
		if(HFBEDHKIBJA == null)
            json["last_attack_player_id"] = 0;
		else
            json["last_attack_player_id"] = HFBEDHKIBJA.AKLNMPMLDAJ_RaidBoss.OKIEOLAAJNM_LastAttackPlayerId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.EEHEMNBJPAP_82_RaidBossAttack, json, false);
    }

	// // RVA: 0x91C368 Offset: 0x91C368 VA: 0x91C368
	public void HONFKODFAPA_RaidBossReward(PKNOKJNLPOE_EventRaid _MOHDLLIJELH_cont, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ _GJFJLEOGFLD_RaidBoss, PKNOKJNLPOE_EventRaid.KJJDLBFDGDM _KONJMFICNJJ_RewardsInfo)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
        json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
        json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
        json["lobby_id"] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
		HBOONEFDMJL(json, _GJFJLEOGFLD_RaidBoss);
        json["boss_my_rank"] = _GJFJLEOGFLD_RaidBoss.GCKGHNBHOPH_Rank;
        json["boss_my_total_damage"] = _GJFJLEOGFLD_RaidBoss.AEGFDINOACE_PlayerDamage;
        JBBHNIACMFJ.Length = 0;
        bool b = false;
        for (int i = 0; i < _KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards.Count; i++)
		{
            if (b)
            {
                JBBHNIACMFJ.Append(',');
            }
            JBBHNIACMFJ.Append(_KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards[i].PPFNGGCBJKC_id);
            JBBHNIACMFJ.Append(':');
            JBBHNIACMFJ.Append(_KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards[i].HMFFHLPNMPH_count);
			b = true;
		}
        json["defeat_reward"] = JBBHNIACMFJ.ToString();
        JBBHNIACMFJ.Length = 0;
        b = false;
        for (int i = 0; i < _KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards.Count; i++)
		{
            if (b)
            {
                JBBHNIACMFJ.Append(',');
            }
            JBBHNIACMFJ.Append(_KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards[i].PPFNGGCBJKC_id);
            JBBHNIACMFJ.Append(':');
            JBBHNIACMFJ.Append(_KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards[i].HMFFHLPNMPH_count);
			b = true;
		}
        json["mvp_reward"] = JBBHNIACMFJ.ToString();
        JBBHNIACMFJ.Length = 0;
        b = false;
        for (int i = 0; i < _KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards.Count; i++)
        {
            if (b)
            {
                JBBHNIACMFJ.Append(',');
            }
            JBBHNIACMFJ.Append(_KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards[i].PPFNGGCBJKC_id);
            JBBHNIACMFJ.Append(':');
            JBBHNIACMFJ.Append(_KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards[i].HMFFHLPNMPH_count);
			b = true;
        }
        json["first_reward"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HONFKODFAPA_85_RaidBossReward, json, false);
    }

	// // RVA: 0x91CF90 Offset: 0x91CF90 VA: 0x91CF90
	public void DNJGGCJPIMC_GoDivaEventStageStart(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _KALCJMLIAOK_RemainStamina, int _CBHACAOCJGP_UseStamina, MANPIONIGNO_EventGoDiva _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = LECBAPOGJAG(OMNOFMEBLAD, _MDADLCOCEBN_session_id, _KALCJMLIAOK_RemainStamina, _CBHACAOCJGP_UseStamina);
		if(json != null)
		{
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["fever_time"] = COPGJHJGHJG_TimestampToString(Database.Instance.gameSetup.musicInfo.setupTime);
			JBBHNIACMFJ.Length = 0;
			MANPIONIGNO_EventGoDiva.IBNAEKMCIEO ib = _MOHDLLIJELH_cont.NLPCPFCIDLM(_MOHDLLIJELH_cont.CMCEGEKGEEP.KPEKOOCPKID_BonusId, _MOHDLLIJELH_cont.CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily);
			if(ib != null)
			{
				JBBHNIACMFJ.Append(ib.PPFNGGCBJKC_id);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.CGHNCPEKOCK_IsDaily);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.NOEFINFEMBM);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.PKDAEFIGMLI);
				JBBHNIACMFJ.Append(':');
				JBBHNIACMFJ.Append(ib.DGAELGEJPNA);
			}
			json["start_pt"] = _MOHDLLIJELH_cont.FBGDBGKNKOD_GetCurrentPoint();
			json["bonus_info"] = JBBHNIACMFJ.ToString();
			HADLOAPLCAF(json, OMNOFMEBLAD, _MOHDLLIJELH_cont);
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DNJGGCJPIMC_96_GoDivaEventStageStart, json, false);
		}
	}

	// // RVA: 0x91D638 Offset: 0x91D638 VA: 0x91D638
	public void HPNIJDCPCNC_GoDivaEventStageEnd(CPHJGFLEFNF IJAOGPFKDBP, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, MANPIONIGNO_EventGoDiva _MOHDLLIJELH_cont)
	{
		EDOHBJAPLPF_JsonData json = MKMJILJPOGC(IJAOGPFKDBP, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
		if(json != null)
		{
			json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
			json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
			json["bonus_id"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.KPEKOOCPKID_BonusId;
			json["bonus_ratio0"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.AONOCELOCLL_BonusMusicProbaBefore;
			json["bonus_ratio"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter;
			json["soul_lv"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.MKMIEGPOKGG_Soul.GLFIELJJDCI_Level;
			json["voice_lv"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.EACDINDLGLF_Voice.GLFIELJJDCI_Level;
			json["charm_lv"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.LDLHPACIIAB_Charm.GLFIELJJDCI_Level;
			json["soul_alv"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_Level;
			json["voice_alv"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_Level;
			json["charm_alv"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_Level;
			json["soul_exp"] = Mathf.Max(100, _MOHDLLIJELH_cont.CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusValue) * _MOHDLLIJELH_cont.CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE_point / 100;
			json["voice_exp"] = Mathf.Max(100, _MOHDLLIJELH_cont.CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusValue) * _MOHDLLIJELH_cont.CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE_point / 100;
			json["charm_exp"] = Mathf.Max(100, _MOHDLLIJELH_cont.CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusValue) * _MOHDLLIJELH_cont.CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE_point / 100;
			json["soul_exp_pr"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.MKMIEGPOKGG_Soul.EJOHDINLOAJ_PrevExp;
			json["voice_exp_pr"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.EACDINDLGLF_Voice.EJOHDINLOAJ_PrevExp;
			json["charm_exp_pr"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.LDLHPACIIAB_Charm.EJOHDINLOAJ_PrevExp;
			json["soul_exp_af"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.MKMIEGPOKGG_Soul.LKIFDCEKDCK_exp;
			json["voice_exp_af"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.EACDINDLGLF_Voice.LKIFDCEKDCK_exp;
			json["charm_exp_af"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.LDLHPACIIAB_Charm.LKIFDCEKDCK_exp;
			json["bonus_start"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart;
			json["bonus_end"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd;
			json["bonus_is_daily"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily;
			json["get_pt"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.JKFCHNEININ_GetPoint;
			json["end_pt"] = _MOHDLLIJELH_cont.CMCEGEKGEEP.AHOKAPCGJMA_TotalPoint;
			json["use_liveskip"] = IJAOGPFKDBP.CAOHBKEIGDM_UseLiveSkip;
			DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HPNIJDCPCNC_97_GoDivaEventStageEnd, json, false);
		}
	}

	// // RVA: 0x91E404 Offset: 0x91E404 VA: 0x91E404
	public void HJGEAHELBPE_GoDivaEventUsedFeverItem(MANPIONIGNO_EventGoDiva _MOHDLLIJELH_cont, int _GLCLFMGPMAN_ItemId, int _ECEKFEFOFNI_UseItemCount, int _NLIMHCILPFE_AfCount)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["event_id"] = _MOHDLLIJELH_cont.PGIIDPEGGPI_EventId;
		json["event_name"] = _MOHDLLIJELH_cont.DGCOMDILAKM_EventName;
		json["item_id"] = _GLCLFMGPMAN_ItemId;
		json["use_count"] = _ECEKFEFOFNI_UseItemCount;
		json["af_count"] = _NLIMHCILPFE_AfCount;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HJGEAHELBPE_98_GoDivaEventUsedFeverItem, json, false);
	}

	// // RVA: 0x91E7E4 Offset: 0x91E7E4 VA: 0x91E7E4
	// public void DAHHMMNABFI() { }

	// // RVA: 0x91E7E8 Offset: 0x91E7E8 VA: 0x91E7E8
	// public void NBBGDNAHAGH() { }

	// // RVA: 0x91E7EC Offset: 0x91E7EC VA: 0x91E7EC
	public void FJIPPAPEBID_DecoBuy(int _IPJBPBDCCPF_ConsumeItemId, int _HABCGPMKBJK_ConsumeItemCount, int _PEKOLGMLJAL_AfterConsumeItemCount, int _BGHCIAOANCF_BuyItemId, int _GJNAOBBAPOF_BuyItemCount, int _FFBPGKHIKGD_AfterBuyItemCount, int _KMFLNILNPJD_Cnt, int _JPLLMKIDNBM_BuyCountTotal, int _HMFDJHEEGNN_buy_limit, long _DECPPKAAHFA_BuyLimitDate)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA_table.Find((BKPAPCMJKHE_Shop.DNOENEKHGMI _GHPLINIACBB_x) =>
		{
			//0x201937C
			return _GHPLINIACBB_x.HCCEFDMGPEA == 5;
		});
		json["shop_id"] = dbShop.OPKDAIMPJBH_ShopId;
		json["shop_name"] = dbShop.NEMKDKDIIDK_ShopName;
		json["lineup_id"] = dbShop.EFNMDPKEJIM_LineupId;
		json["product_id"] = 0;
		json["consume_item_id"] = _IPJBPBDCCPF_ConsumeItemId;
		json["consume_item_count"] = _HABCGPMKBJK_ConsumeItemCount;
		json["consume_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_IPJBPBDCCPF_ConsumeItemId);
		json["af_consume_item_count"] = _PEKOLGMLJAL_AfterConsumeItemCount;
		json["buy_item_id"] = _BGHCIAOANCF_BuyItemId;
		json["buy_item_count"] = _GJNAOBBAPOF_BuyItemCount;
		json["buy_item_name"] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_BGHCIAOANCF_BuyItemId);
		json["af_buy_item_count"] = _FFBPGKHIKGD_AfterBuyItemCount;
		json["buy_count"] = _KMFLNILNPJD_Cnt;
		json["buy_count_total"] = _JPLLMKIDNBM_BuyCountTotal;
		json["buy_limit"] = _HMFDJHEEGNN_buy_limit;
		if(_DECPPKAAHFA_BuyLimitDate == 0)
		{
			json["buy_limit_date"] = "3000-01-01 00:00:00";
		}
		else
		{
			json["buy_limit_date"] = BGLHDAKDPMJ_DateToString(Utility.GetLocalDateTime(_DECPPKAAHFA_BuyLimitDate));
		}
		json["sakasho_product_id"] = 0;
		json["sakasho_product_name"] = "";
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.DBNECDJCNOI_48_ShopBuy, json, false);
	}

	// // RVA: 0x91F36C Offset: 0x91F36C VA: 0x91F36C
	public void HEKBPBPLPJL(int _NPMIJMFMEKB_target_player_id, int _BEPIOAIFCEC_op)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["target_user_id"] = _NPMIJMFMEKB_target_player_id;
		if(_BEPIOAIFCEC_op == 1)
		{
			json["action"] = JpStringLiterals.StringLiteral_11476;
		}
		else
		{
			json["action"] = JpStringLiterals.StringLiteral_11477;
		}
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HGNLDJNEGJM_76_BlockList, json, false);
	}

	// // RVA: 0x91F708 Offset: 0x91F708 VA: 0x91F708
	public void CLGHLKLHEAK_DecoTransition(string _INDDJNMPONH_type, int _HHFIMKIKJBC_VisitUserId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["type"] = _INDDJNMPONH_type;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CLGHLKLHEAK_78_DecoTransition, json, false);
	}

	// // RVA: 0x91F9A4 Offset: 0x91F9A4 VA: 0x91F9A4
	public void PFBIHCIFFKM_DecoVisit(int _HHFIMKIKJBC_VisitUserId, bool _MLEHCBKPNGK_IsFriend, bool _FMNNBGOFBPB_IsVisit, int _GLCLFMGPMAN_ItemId/* = 0*/)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["visit_user_id"] = _HHFIMKIKJBC_VisitUserId;
		json["is_friend"] = _MLEHCBKPNGK_IsFriend ? 1 : 2;
		json["is_visit"] = _FMNNBGOFBPB_IsVisit ? 1 : 2;
		json["item"] = _GLCLFMGPMAN_ItemId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.PFBIHCIFFKM_86_DecoVisit, json, false);
	}

	// // RVA: 0x91FD94 Offset: 0x91FD94 VA: 0x91FD94
	public void CEFIPAIKAKN_DecoItemCollection(List<int> _GMFMGJNPNKA_CollectedItem, List<int> GNGFCCBHLPO)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		JBBHNIACMFJ.Length = 0;
		bool b = false;
		for(int i = 0; i < _GMFMGJNPNKA_CollectedItem.Count; i++)
		{
			if(b)
				JBBHNIACMFJ.Append(",");
			JBBHNIACMFJ.Append(_GMFMGJNPNKA_CollectedItem[i]);
			JBBHNIACMFJ.Append(":");
			JBBHNIACMFJ.Append(GNGFCCBHLPO[i]);
			b = true;
		}
		json["collect_item"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CEFIPAIKAKN_87_DecoItemCollection, json, false);
	}

	// // RVA: 0x920200 Offset: 0x920200 VA: 0x920200
	public void JCJCJPCHNEN(int _NPMIJMFMEKB_target_player_id, int _BEPIOAIFCEC_op, int MFOCDHGOODC, bool _MLEHCBKPNGK_IsFriend)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["fan_user_id"] = _NPMIJMFMEKB_target_player_id;
		if(_BEPIOAIFCEC_op == 0)
		{
			json["action"] = JpStringLiterals.StringLiteral_11477;
		}
		else
		{
			json["action"] = JpStringLiterals.StringLiteral_11476;
		}
		json["is_friend"] = _MLEHCBKPNGK_IsFriend;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CIGPIPBPABC_80_FanRegister, json, false);
	}

	// // RVA: 0x920614 Offset: 0x920614 VA: 0x920614
	public void LHCHBHPHLCP_LobbyVisit(int _AOPIMHHPPMG_VisitId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["visit_id"] = _AOPIMHHPPMG_VisitId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.LHCHBHPHLCP_94_LobbyVisit, json, false);
	}

	// // RVA: 0x9208B0 Offset: 0x9208B0 VA: 0x9208B0
	public void MIDMMEHCCFA_DecoItemSet(int _NJHLKOFIDJN_DecoItemId, int _OLCAOJEHGMO_SetArea, bool _GNKGNCLBKLB_IsSet)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["deco_item_id"] = _NJHLKOFIDJN_DecoItemId;
		json["set_area"] = _OLCAOJEHGMO_SetArea;
		json["is_set"] = _GNKGNCLBKLB_IsSet ? 1 : 2;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.MIDMMEHCCFA_90_DecoItemSet, json, false);
	}

	// // RVA: 0x920C1C Offset: 0x920C1C VA: 0x920C1C
	// public void AGFMBNBIHGB(int _NJHLKOFIDJN_DecoItemId, KDKFHGHGFEK DJKKEABCKLH, Vector3 _NDFOAINJPIN_pos) { }

	// // RVA: 0x920C90 Offset: 0x920C90 VA: 0x920C90
	// public void KBKIDKDDOJN(int _NJHLKOFIDJN_DecoItemId, int GOPGOJDEPML) { }

	// // RVA: 0x920D30 Offset: 0x920D30 VA: 0x920D30
	// public void EPINKLEJAGD(int _NJHLKOFIDJN_DecoItemId, KDKFHGHGFEK DJKKEABCKLH, Vector3 _NDFOAINJPIN_pos) { }

	// // RVA: 0x920DA4 Offset: 0x920DA4 VA: 0x920DA4
	// public void INHBHAMMBEH(int _NJHLKOFIDJN_DecoItemId, int GOPGOJDEPML) { }

	// // RVA: 0x920E44 Offset: 0x920E44 VA: 0x920E44
	public void NOMCHDMPFFE_DecoItemLevelUp(int _DDCKAKGKCIB_DecoId, int _CJAGGLPJOMD_BfLevel, int _JPNCPIINMPC_AfLevel)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["deco_id"] = _DDCKAKGKCIB_DecoId;
		json["bf_level"] = _CJAGGLPJOMD_BfLevel;
		json["af_level"] = _JPNCPIINMPC_AfLevel;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.NOMCHDMPFFE_88_DecoItemLevelUp, json, false);
	}

	// // RVA: 0x921178 Offset: 0x921178 VA: 0x921178
	public void CHMEOKEKABD_Chat(IECJNEHIEKO_CreateBbsComment _ADKIDBJCAJA_action)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["thread_type"] = _ADKIDBJCAJA_action.JECLCENDGIH_ThreadType;
		json["thread_group"] = _ADKIDBJCAJA_action.BDJEICCDKHB_ThreadGroup;
		json["room_user_id"] = _ADKIDBJCAJA_action.GFOIDCMEHGL_RoomUserId;
		json["event_id"] = _ADKIDBJCAJA_action.DNJLJMKKDNA_EventId;
		json["lobby_id"] = _ADKIDBJCAJA_action.MEBHCFJCKFE_LobbyId;
		json["thread_id"] = _ADKIDBJCAJA_action.BOINIEAKFPL_ThreadId;
		json["comment_index"] = _ADKIDBJCAJA_action.NFEAMMJIMPG_Result.NPAHGHOHMHN_Idx;
		json["content"] = _ADKIDBJCAJA_action.KOGBMDOONFA_Info.Content;
		json["nickname"] = _ADKIDBJCAJA_action.KOGBMDOONFA_Info.Nickname;
		json["extra"] = _ADKIDBJCAJA_action.KOGBMDOONFA_Info.Extra;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.CHMEOKEKABD_89_Chat, json, false);
	}

	// // RVA: 0x92172C Offset: 0x92172C VA: 0x92172C
	public void ELDCONNMDGN_ValkyrieEnhance(int _FODKKJIDDKN_vf_Id, int _MJKGDEOKFNK_BfLv, int _NCMCPNPOLEB_AfLv, int MPIJPMELIDO, int NHPFGLJJMJJ, int IKBIIBDNNAL, int LHDHBPOLEGB)
	{

		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["vf_id"] = _FODKKJIDDKN_vf_Id;
		json["bf_lv"] = _MJKGDEOKFNK_BfLv;
		json["af_lv"] = _NCMCPNPOLEB_AfLv;
		JBBHNIACMFJ.Length = 0;
		JBBHNIACMFJ.Append(MPIJPMELIDO);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(NHPFGLJJMJJ);
		JBBHNIACMFJ.Append(',');
		JBBHNIACMFJ.Append(IKBIIBDNNAL);
		JBBHNIACMFJ.Append(':');
		JBBHNIACMFJ.Append(LHDHBPOLEGB);
		json["item_info"] = JBBHNIACMFJ.ToString();
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.ELDCONNMDGN_79_ValkyrieEnhance, json, false);
	}

	// // RVA: 0x921C2C Offset: 0x921C2C VA: 0x921C2C
	public void MINOEGPNBIH_McCharge(int _IJIEMJFAJKL_McGaugeAdd, int _GGJLPODCHIO_McGaugeAf, int _JGGKJBCGKCC_use_item_id, int _PJIOJCFCFOK_AfItemNum, string _INDDJNMPONH_type, string _GNOOPLDMLBE_AttackInfo)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["mc_guage_add"] = _IJIEMJFAJKL_McGaugeAdd;
		json["mc_guage_af"] = _GGJLPODCHIO_McGaugeAf;
		json["use_item_id"] = _JGGKJBCGKCC_use_item_id;
		json["af_item_num"] = _PJIOJCFCFOK_AfItemNum;
		json["type"] = _INDDJNMPONH_type;
		json["attack_info"] = _GNOOPLDMLBE_AttackInfo;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.MINOEGPNBIH_81_McCharge, json, false);
	}

	// // RVA: 0x92204C Offset: 0x92204C VA: 0x92204C
	public void OMLMHKGCJPH_DecoStampSave(int _IKPIDCFOFEA_no, string _ADKIDBJCAJA_action, int _FDGBLNFGBPJ_stamp_id, int _HPPHKHBPFMJ_serif_id)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["no"] = _IKPIDCFOFEA_no;
		json["action"] = _ADKIDBJCAJA_action;
		json["stamp_id"] = _FDGBLNFGBPJ_stamp_id;
		json["serif_id"] = _HPPHKHBPFMJ_serif_id;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.OMLMHKGCJPH_91_DecoStampSave, json, false);
	}

	// // RVA: 0x9223CC Offset: 0x9223CC VA: 0x9223CC
	public void HNOKBPNGOEF_DecoSns()
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.HNOKBPNGOEF_93_DecoSns, json, false);
	}

	// // RVA: 0x9225F0 Offset: 0x9225F0 VA: 0x9225F0
	public void BOIIMIEPMLG_DecoLayoutSet(string _INDDJNMPONH_type, int _PPFNGGCBJKC_id, string KIFBPEGOEDL)
	{
		return;
	}

	// // RVA: 0x9225F4 Offset: 0x9225F4 VA: 0x9225F4
	public void NBCACPPAAMC_HomeDivaModify(int _CHCPNKMNDOP_BfDivaId, int _KBMAMKCAIGD_AfDivaId, int _IGCLCOMCHHB_BfCos, int _IBKAENIBBIL_AfCos, int _DPJCPEIPAPN_BfColorId, int _EKPGGDOOLFM_AfColorId)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["bf_diva_id"] = _CHCPNKMNDOP_BfDivaId;
		json["af_diva_id"] = _KBMAMKCAIGD_AfDivaId;
		json["bf_cos"] = _IGCLCOMCHHB_BfCos;
		json["af_cos"] = _IBKAENIBBIL_AfCos;
		json["bf_color_id"] = _DPJCPEIPAPN_BfColorId;
		json["af_color_id"] = _EKPGGDOOLFM_AfColorId;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.NBCACPPAAMC_99_HomeDivaModify/*99*/, json, false);
	}

	// // RVA: 0x922A14 Offset: 0x922A14 VA: 0x922A14
	public void BBIBBNHCPPJ_HomeModify(int _LKFPHAIMKMA_BfViewModel, int _HGBMBIBAEGG_AfViewModel, int _JBOMAOOPGAA_BfWallpaperFlag, int _HPBLCCLGFHH_AfWallpaperFlag, int _AICIPAHGLOE_BfLightFlag, int _FOILMFGFFNH_AfLightFlag, int _DLDODLGIOMC_IllustId, int _CNKFPJCGNFE_SceneId, int _EEJFLMKCCGN_RareUpFlag)
	{
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		FLBFCCIEPNC_InitBaseJson(json, JDDGPJDKHNE.HHCJCDFCLOB.KPKAKIIAFFB_GetNextRequestId());
		json["bf_view_model"] = _LKFPHAIMKMA_BfViewModel;
		json["af_view_model"] = _HGBMBIBAEGG_AfViewModel;
		json["bf_wallpaper_flag"] = _JBOMAOOPGAA_BfWallpaperFlag;
		json["af_wallpaper_flag"] = _HPBLCCLGFHH_AfWallpaperFlag;
		json["bf_light_flag"] = _AICIPAHGLOE_BfLightFlag;
		json["af_light_flag"] = _FOILMFGFFNH_AfLightFlag;
		json["illust_id"] = _DLDODLGIOMC_IllustId;
		json["plate_id"] = _CNKFPJCGNFE_SceneId;
		json["rare_up_flag"] = _EEJFLMKCCGN_RareUpFlag;
		DEGEPBNNOAF(OAGBCBBHMPF.KJDNDEDOIOO_LogType.BBIBBNHCPPJ_100_HomeModify, json, false);
	}
}
