using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class BingoMissionScene : TransitionRoot
	{
		private Color Bingo_FadeIn = new Color(1, 1, 1, 0); // 0x48
		private const float FadeTime = 1;
		private const float WAIT_TIME = 0.5f;
		private const int BGM_ID = 1029;
		private JJPEIELNEJB.JLHHGLANHGE[] ItemList = new JJPEIELNEJB.JLHHGLANHGE[8]; // 0x58
		private LayoutBingoMission m_layout; // 0x5C
		private bool IsInitialize; // 0x60
		private bool IsChangeBingo; // 0x61
		private Action m_updater; // 0x64
		private int bingoId_ = GNGMCIAIKMA.FBGGEFFJJHB; // 0x68
		private JJPEIELNEJB m_view; // 0x6C
		private JJPEIELNEJB.OMMBBPKFLNH m_bingoInfo; // 0x70
		private PupupBingoRewardWindowSetting BingoRewardListPopup; // 0x74

		private int bingoId { get { return bingoId_ ^ GNGMCIAIKMA.FBGGEFFJJHB; } set { bingoId_ = value ^ GNGMCIAIKMA.FBGGEFFJJHB; } } //0x1098204 0x1098270

		// RVA: 0x10982E0 Offset: 0x10982E0 VA: 0x10982E0
		private void Start()
		{
			IsReady = true;
		}

		// RVA: 0x10982EC Offset: 0x10982EC VA: 0x10982EC
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x1098300 Offset: 0x1098300 VA: 0x1098300
		private void updater_Wait()
		{
			return;
		}

		//// RVA: 0x1098304 Offset: 0x1098304 VA: 0x1098304
		private void updaterSetting()
		{
			this.StartCoroutineWatched(MainFlow());
			m_updater = updater_Wait;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA0E4 Offset: 0x6CA0E4 VA: 0x6CA0E4
		//// RVA: 0x1098430 Offset: 0x1098430 VA: 0x1098430
		private IEnumerator Initialize()
		{
			//0x109D500
			IsInitialize = false;
			if(GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				bingoId = GNGMCIAIKMA.HHCJCDFCLOB.MGAHOPFMKHB_GetBingoId();
				GNGMCIAIKMA.HHCJCDFCLOB.FBHHEBDDIMO(bingoId, true);
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(bingoId, null, -1);
			}
			if(m_layout == null)
			{
				yield return Co.R(AssetLoad());
			}
			if(m_view == null || m_view.PMPKHBAJAFA_BingoId != bingoId)
			{
				m_view = new JJPEIELNEJB(bingoId);
			}
			m_bingoInfo = m_view.MEAPAEMIOBB;
			m_bingoInfo.FBANBDCOEJL();
			m_layout.ChangeBingoState(m_bingoInfo.DAKIMDGPHNE_IsReleaseEpisode);
			int divaId = m_bingoInfo.AHHJLDLAPAN_DivaId;
			if (divaId > 0)
				m_layout.SetDivaIcon(divaId, m_bingoInfo.DAJGPBLEEOB_CostumeModelId);
			m_layout.SetRewardItemIcon(m_bingoInfo.LPLDJDCELAN_RewardsId[m_bingoInfo.OLPBIMOPHLM_ReceiveCount].DNJEJEANJGL_Value, 1, null);
			SetBingoText();
			List<JJPEIELNEJB.JLHHGLANHGE> rewardInfo = m_bingoInfo.KONJMFICNJJ_RewardsInfo;
			for(int i = 0; i < ItemList.Length; i++)
			{
				ItemList[i] = new JJPEIELNEJB.JLHHGLANHGE();
				ItemList[i].GLCLFMGPMAN_ItemFullId = rewardInfo[i].GLCLFMGPMAN_ItemFullId;
				ItemList[i].LJKMKCOAICL_ItemCount = rewardInfo[i].LJKMKCOAICL_ItemCount;
			}
			if(BingoRewardListPopup == null)
			{
				BingoRewardListPopup = new PupupBingoRewardWindowSetting();
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			BingoRewardListPopup.WindowSize = SizeType.Large;
			BingoRewardListPopup.TitleText = bk.GetMessageByLabel("bingo_reward_pop_title");
			BingoRewardListPopup.ItemList = m_bingoInfo.KONJMFICNJJ_RewardsInfo.ToArray();
			BingoRewardListPopup.ReceivedBingoCount = m_bingoInfo.OLPBIMOPHLM_ReceiveCount;
			BingoRewardListPopup.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			BingoRewardListPopup.OnClickIcon = (int i) =>
			{
				//0x109C794
				OnclickItemIcon(rewardInfo[i].GLCLFMGPMAN_ItemFullId, 0);
			};
			m_layout.SetCompButtonCallback(() =>
			{
				//0x109C85C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				PopupWindowManager.Show(BingoRewardListPopup, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x109C5E0
					return;
				}, null, null, null);
			});
			m_layout.SetContentButtonCallback((int i) =>
			{
				//0x109CA5C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ShowPopupBingoSelectQuest(i);
			});
			while (m_layout.IsDivaIconSetting)
				yield return null;
			SettingRibbonText(m_bingoInfo.OLPBIMOPHLM_ReceiveCount);
			m_layout.SetBingoCountText(m_bingoInfo.MALACFEDHDE_CurrentCount, m_bingoInfo.AIEFMNBLCKA_MaxCount);
			m_layout.StopClearIcon();
			m_layout.ResetClearIcon();
			List<int> l = GNGMCIAIKMA.HHCJCDFCLOB.OAHPJJCHIPF(bingoId);
			for(int i = 0; i < l.Count; i++)
			{
				m_layout.ClearIconSeting(l[i], LayoutBingoMission.ClearState.Cleared);
			}
			l = GNGMCIAIKMA.HHCJCDFCLOB.NCCCEBGHCOL(bingoId);
			m_layout.BingoCompAnimReset();
			m_layout.BingoCompAnimChange(l.ToArray());
			IsInitialize = true;
		}

		//// RVA: 0x10984DC Offset: 0x10984DC VA: 0x10984DC
		private void SettingRibbonText(int _bingoCount)
		{
			int a1 = GNGMCIAIKMA.HHCJCDFCLOB.MLCGJAJCFDP(bingoId, _bingoCount, 0);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = "";
			if(_bingoCount > 0)
				str = string.Format(bk.GetMessageByLabel("bingo_ribbon_bingo_count_text"), _bingoCount) + "\r\n";
			if (m_bingoInfo.DAKIMDGPHNE_IsReleaseEpisode)
				str += string.Format(bk.GetMessageByLabel("bingo_ribbon_costume_text"), a1);
			else
				str += bk.GetMessageByLabel("bingo_ribbon_item_text");
			m_layout.SetRibonText(str);
		}

		//// RVA: 0x109878C Offset: 0x109878C VA: 0x109878C
		private void ShowPopupBingoSelectQuest(int _index)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			JJPEIELNEJB.CJBKOOCMLEO data = m_bingoInfo.BECEJMHDBBP[_index];
			int itemId = data.GLCLFMGPMAN_ItemId;
			int itemCount = data.LJKMKCOAICL_ItemCount;
			PopupBingoSelectQuestSetting s = new PopupBingoSelectQuestSetting();
			s.TitleText = bk.GetMessageByLabel("bingo_mission_reward_pop_title");
			s.ItemId = itemId;
			s.ItemDetailText = data.LNDAOGHCKJK_ItemDetailText;
			s.QuestText = bk.GetMessageByLabel("bingo_mission_conditions_text") + "\n" + data.JEPGJJJBFLN_ConditionText;
			s.OnClickItemIcon = () =>
			{
				//0x109CADC
				OnclickItemIcon(itemId, itemCount);
			};
			s.WindowSize = SizeType.Middle;
			s.Buttons = SettingButtons(data.BCGLDMKODLC_IsSingle);
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x109CB10
				if (label != PopupButton.ButtonLabel.Challenge)
					return;
				int a2 = m_view.MEAPAEMIOBB.BECEJMHDBBP[_index].DODGLIDGBBC_ConditionValue;
				OnClickChallenge(ILLPDLODANB.HNHNHHCBLDE((ILLPDLODANB.LOEGALDKHPL)m_view.MEAPAEMIOBB.BECEJMHDBBP[_index].GMGGCIJHDJH_ConditionType, a2), a2);
			}, null, null, null);
		}

		//// RVA: 0x1098C14 Offset: 0x1098C14 VA: 0x1098C14
		private ButtonInfo[] SettingButtons(bool IsSingle)
		{
			if(IsSingle)
			{
				return new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			else
			{
				return new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Challenge, Type = PopupButton.ButtonType.Other }
				};
			}
		}

		//// RVA: 0x1098DD8 Offset: 0x1098DD8 VA: 0x1098DD8
		public void OnclickItemIcon(int _itemId, int _itemCount)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				ShowSceneCardItem(_itemId);
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(_itemId, _itemCount, null);
			}
		}

		//// RVA: 0x1098F30 Offset: 0x1098F30 VA: 0x1098F30
		private void ShowSceneCardItem(int _itemId)
		{
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(_itemId - 40000, null, null, 0, 0, 0, false, 0, 0);
			MenuScene.Instance.ShowSceneStatusPopupWindow(scene, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, 0, false);
		}

		//// RVA: 0x10990CC Offset: 0x10990CC VA: 0x10990CC
		private void ShowBingoRewaedPopup(int BingoNum, int ItemId, int ItemCount, Action popEnd)
		{
			PopupGetBingoRewaedSetting s = new PopupGetBingoRewaedSetting();
			s.ItemId = ItemId;
			s.GetItemCount = ItemCount;
			s.BingoCount = BingoNum;
			s.IsCaption = false;
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x109CCF4
				popEnd();
			}, null, null, null, playSeEvent:(PopupWindowControl.SeType type) =>
			{
				//0x109C5E4
				if(type != PopupWindowControl.SeType.WindowOpen)
					return false;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
				return true;
			});
		}

		//// RVA: 0x1099450 Offset: 0x1099450 VA: 0x1099450
		private void ShowGetItemPopup(Action endPopupAct)
		{
			if(m_bingoInfo.CIDBGGOGGPL.Count == 0)
			{
				endPopupAct();
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupBingoMissionRewardWindowSetting s = new PopupBingoMissionRewardWindowSetting();
				for(int i = 0; i < m_bingoInfo.CIDBGGOGGPL.Count; i++)
				{
					GNGMCIAIKMA.JCIFAFBDALP data = new GNGMCIAIKMA.JCIFAFBDALP();
					data.PPFNGGCBJKC_Id = m_bingoInfo.CIDBGGOGGPL[i].GLCLFMGPMAN_ItemFullId;
					data.BFINGCJHOHI_Cnt = m_bingoInfo.CIDBGGOGGPL[i].LJKMKCOAICL_ItemCount;
					s.ItemInfoList.Add(data);
					s.MissionTextList.Add(m_bingoInfo.CIDBGGOGGPL[i].FLGEGLADKHC_MissionText);
				}
				s.TitleText = bk.GetMessageByLabel("bingo_mission_reward_get_pop_title");
				s.WindowSize = SizeType.Middle;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x109CD20
					endPopupAct();
				}, null, null, null);
			}
		}

		//// RVA: 0x10999D0 Offset: 0x10999D0 VA: 0x10999D0
		private void ShowBingoEndPopup(bool IsNextBingo, Action ClosedPopup)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str;
			if(IsNextBingo)
			{
				str = string.Format(bk.GetMessageByLabel("bingo_mission_change__bingo_text"), m_view.MEAPAEMIOBB.MALACFEDHDE_CurrentCount);
			}
			else
			{
				str = bk.GetMessageByLabel("bingo_mission_end_pop_text");
			}
			TextPopupSetting s = new TextPopupSetting();
			s.IsCaption = false;
			s.Text = str;
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x109CD4C
				ClosedPopup();
			}, null, null, null);
		}

		//// RVA: 0x1099D34 Offset: 0x1099D34 VA: 0x1099D34
		private void ShowBingoStartPopup(Action _closePopupAct)
		{
			if(!m_bingoInfo.DAKIMDGPHNE_IsReleaseEpisode)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.IsCaption = false;
				s.WindowSize = SizeType.Small;
				s.Text = string.Format(bk.GetMessageByLabel("bingo_normal_bingo_start_text"), m_bingoInfo.MALACFEDHDE_CurrentCount);
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x109CD78
					_closePopupAct();
				}, null, null, null);
			}
			else
			{
				_closePopupAct();
			}
		}

		//// RVA: 0x109A0A4 Offset: 0x109A0A4 VA: 0x109A0A4
		private void OnClickChallenge(BKANGIKIEML.NODKLJHEAJB sceneType, int conditionId)
		{
			if (MenuScene.Instance == null)
				return;
			switch(sceneType)
			{
				case BKANGIKIEML.NODKLJHEAJB.DOEHLCLBCNN_1:
					MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.DJPFJGKGOOF_2:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PAAIHBHJJMM_3:
					MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.EKHDECEEFFJ_4:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5:
					MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.HBIPNFMLLBF_6:
				case BKANGIKIEML.NODKLJHEAJB.OEFNIAKHGKD_7:
				case BKANGIKIEML.NODKLJHEAJB.MLINGAKKDEP_8:
				case BKANGIKIEML.NODKLJHEAJB.GONENLHJLCJ_9:
				case BKANGIKIEML.NODKLJHEAJB.AGCMIOFBFMG_10:
				case BKANGIKIEML.NODKLJHEAJB.BBAEIHMIFFI_11:
					{
						MusicSelectArgs args = new MusicSelectArgs();
						args.SetSelection((FreeCategoryId.Type)sceneType - 5);
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.OBDLOMGHHED_12:
					{
						long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(5, time, true, false, false, false);
						MusicSelectArgs args = new MusicSelectArgs();
						for(int i = 0; i < l.Count; i++)
						{
							if(l[i].LHONOILACFL_IsWeeklyEvent)
							{
								if(l[i].BELHFPMBAPJ_WeekPlay < l[i].JOJNGDPHOKG)
								{
									if(l[i].GHBPLHBNMBK_FreeMusicId > 0)
									{
										args = new MusicSelectArgs();
										args.SetSelection(l[i].GHBPLHBNMBK_FreeMusicId);
										break;
									}
								}
							}
						}
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				default:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15:
					TransitToFreeMusic(conditionId);
					break;
				case BKANGIKIEML.NODKLJHEAJB.LINKBPIPHAK_17:
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
						{
							long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							for(int i = 1; i <= 6; i++)
							{
								List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(i, time, true, false, false, false);
								List<KEODKEGFDLD_FreeMusicInfo> freeMusicList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.FindAll((KEODKEGFDLD_FreeMusicInfo _) =>
								{
									//0x109CDA4
									return conditionId == _.DLAEJOBELBH_MusicId;
								});
								for(int j = 0; j < freeMusicList.Count; j++)
								{
									IBJAKJJICBC ibj = l.Find((IBJAKJJICBC _) =>
									{
										//0x109CDE8
										return _.GHBPLHBNMBK_FreeMusicId == freeMusicList[j].GHBPLHBNMBK_FreeMusicId;
									});
									if(ibj != null)
									{
										TransitToFreeMusic(ibj.GHBPLHBNMBK_FreeMusicId);
										return;
									}
								}
							}
						}
						TransitToFreeMusic(0);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.ANBJBLLMHMB_18:
					{
						int idx = 0;
						if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
						{
							List<int> l = IBJAKJJICBC.CJHOOLJFGFB();
							l.Sort();
							if(JGEOBNENMAH.HHCJCDFCLOB.NNABDGKFEMK_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0 &&
								JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId > 0)
							{
								l.Insert(0, JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId);
							}
							for(int i = 0; i < l.Count; i++)
							{
								idx = l[i];
								KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[i]);
								if(fminfo.DEPGBBJMFED_CategoryId != 5)
								{
									EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
									if (minfo.FKDCCLPGKDK_Ma == conditionId)
										break;
								}
							}
						}
						TransitToFreeMusic(idx);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.OBBOJKJAHIE_20:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_TEAMEDIT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.ADNIADMMBPM_21:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.GFCAMHABJIC_22:
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_PROFIL, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.ICAPJDDJIEA_23:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_PRESENTLIST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.IJMFEGLNDFI_30:
					{
						OptionMenuScene.OptionMenuArgs args = new OptionMenuScene.OptionMenuArgs();
						args.openSnsLink = true;
						MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.HGOGFPOCKFA_31:
					QuestUtility.ShowSNS();
					break;
				case BKANGIKIEML.NODKLJHEAJB.DFEBFNNJMBM_32:
					MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.KBHGPMNGALJ_33:
					{
						CostumeChangeDivaArgs args = new CostumeChangeDivaArgs();
						args.DivaId = 1;
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_TEAMEDIT_COSTUMESELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.LJILBHPMPOG_34:
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_SHOP, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.NHIOLMNADIO_35:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.OCNIBCBBLAA_36:
					if(KDHGBOOECKC.HHCJCDFCLOB == null)
						MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					else
						MenuScene.Instance.Mount(KDHGBOOECKC.HHCJCDFCLOB.OOFNEPBLPEA(), null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.LEHHJINPFHA_37:
					if(!MOEALEGLGCH.CDOCOLOKCJK())
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_COSTUMEUPGRADE, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.HHFLHPFJMPN_39:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_GAKUYA, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PKHEABDDHKB_40:
					{
						int a;
						bool b;
						HNDLICBDEMI.FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out a, out b);
						if (!b)
						{
							MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						}
						else
						{
							MenuScene.Instance.Mount(TransitionUniqueId.DECO, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						}
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.JDCENDOKKIE_41:
					if (!SettingMenuPanel.IsValkyrieTuneUpUnlock())
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_VALKYRIETUNEUP, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.CLJHDIKFECG_42:
					{
						QuestTopArgs args = new QuestTopArgs(4);
						MenuScene.Instance.Mount(TransitionUniqueId.QUEST, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.KJAFDMGNBPO_43:
					{
						QuestTopArgs args = new QuestTopArgs(1);
						MenuScene.Instance.Mount(TransitionUniqueId.QUEST, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
			}
		}

		//// RVA: 0x109B4E0 Offset: 0x109B4E0 VA: 0x109B4E0
		private void TransitToFreeMusic(int freeMusicId)
		{
			if(freeMusicId < 1)
			{
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
			else
			{
				MusicSelectArgs args = new MusicSelectArgs();
				args.SetSelection(freeMusicId);
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// RVA: 0x109B658 Offset: 0x109B658 VA: 0x109B658 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			this.StartCoroutineWatched(Initialize());
		}

		// RVA: 0x109B688 Offset: 0x109B688 VA: 0x109B688 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsInitialize;
		}

		// RVA: 0x109B690 Offset: 0x109B690 VA: 0x109B690 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0x109B698 Offset: 0x109B698 VA: 0x109B698 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0x109B6A0 Offset: 0x109B6A0 VA: 0x109B6A0 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			transform.SetAsLastSibling();
			m_layout.Enter();
		}

		// RVA: 0x109B704 Offset: 0x109B704 VA: 0x109B704 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
			if(IsBingoMissionHelp())
			{
				this.StartCoroutineWatched(StartHelp());
			}
			else
			{
				m_updater = updaterSetting;
			}
		}

		// RVA: 0x109B930 Offset: 0x109B930 VA: 0x109B930 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
		}

		// RVA: 0x109B938 Offset: 0x109B938 VA: 0x109B938 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(1029, 1);
			return true;
		}

		// RVA: 0x109B998 Offset: 0x109B998 VA: 0x109B998 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_layout.Leave();
			base.OnStartExitAnimation();
		}

		// RVA: 0x109B9D4 Offset: 0x109B9D4 VA: 0x109B9D4 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layout.RootIsPlaying();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA15C Offset: 0x6CA15C VA: 0x6CA15C
		//// RVA: 0x109BA04 Offset: 0x109BA04 VA: 0x109BA04
		private IEnumerator AssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0x109D10C
			bundleName = "ly/152.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_bingo_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x109C494
				instance.transform.SetParent(transform, false);
				m_layout = instance.GetComponent<LayoutBingoMission>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA1D4 Offset: 0x6CA1D4 VA: 0x6CA1D4
		//// RVA: 0x10983A4 Offset: 0x10983A4 VA: 0x10983A4
		private IEnumerator MainFlow()
		{
			List<int> lineList; // 0x1C
			int bingonum; // 0x20
			JKNGJFOBADP inventoryUtil; // 0x24
			bool IsRewardNextPlate; // 0x28
			int i; // 0x2C
			JJPEIELNEJB.JLHHGLANHGE reward; // 0x30
			int _currntBingoNum; // 0x34
			int _getItemID; // 0x38
			int _getItemNum; // 0x3C
			bool IsNextBingo; // 0x40
			bool IsNextBingoEnable; // 0x41
			bool IsGotoQuest; // 0x42
			bool IsGotoBingoSelect; // 0x43

			//0x109E484
			MenuScene.Instance.InputDisable();
			while (m_layout.RootIsPlaying())
				yield return null;
			bool isPopEnd = false;
			if(m_bingoInfo.GKEKBBOFNLB)
			{
				GNGMCIAIKMA.HHCJCDFCLOB.DBEDJLOAILN(bingoId);
				ShowBingoStartPopup(() =>
				{
					//0x109CED8
					isPopEnd = true;
					GNGMCIAIKMA.HHCJCDFCLOB.MNMCNPLIEFM(bingoId, true);
				});
				while (!isPopEnd)
					yield return null;
			}
			yield return Co.R(Co_Wait(0.5f));
			List<int> l = GNGMCIAIKMA.HHCJCDFCLOB.ICNOKENCCJK(bingoId, true, true);
			m_bingoInfo.CIDBGGOGGPL = GNGMCIAIKMA.HHCJCDFCLOB.HNBJHJENFGL(m_bingoInfo, l);
			bool ClearAnimEnd = false;
			m_layout.ClearAnimStart(l.ToArray(), () =>
			{
				//0x109CF90
				ClearAnimEnd = true;
			});
			while (!ClearAnimEnd)
				yield return null;
			yield return null;
			m_layout.ClearAnimLoopStart();
			yield return null;
			isPopEnd = false;
			ShowGetItemPopup(() =>
			{
				//0x109CF9C
				isPopEnd = true;
			});
			while (!isPopEnd)
				yield return null;
			yield return null;
			yield return null;
			m_bingoInfo.FBANBDCOEJL();
			lineList = GNGMCIAIKMA.HHCJCDFCLOB.PFDGKPCCGMG(bingoId, true, true);
			bingonum = m_bingoInfo.OLPBIMOPHLM_ReceiveCount;
			inventoryUtil = CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL;
			inventoryUtil.JCHLONCMPAJ();
			for(i = 0; i < lineList.Count; i++)
			{
				reward = m_bingoInfo.KONJMFICNJJ_RewardsInfo[i + bingonum];
				_currntBingoNum = reward.PPFNGGCBJKC;
				_getItemID = reward.GLCLFMGPMAN_ItemFullId;
				_getItemNum = reward.LJKMKCOAICL_ItemCount;
				GNGMCIAIKMA.HHCJCDFCLOB.CPIICACGNBH(inventoryUtil, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, reward.GLCLFMGPMAN_ItemFullId, reward.LJKMKCOAICL_ItemCount, bingoId);
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_getItemID) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					GameManager.Instance.ResetViewPlayerData();
				}
				m_layout.LineAnimationStart(lineList[i]);
				yield return null;
				while(m_layout.LineAnimIsPlaying(lineList[i]))
					yield return null;
				m_layout.BingoCompAnimChange(GNGMCIAIKMA.HHCJCDFCLOB.EOPMDFOCAKJ(lineList[i]));
				m_layout.BingoAnimationStart(_currntBingoNum);
				yield return null;
				while (m_layout.BingoAnimIsPlaying())
					yield return null;
				SettingRibbonText(bingonum + i + 1);
				if(bingonum + i + 1 < 8)
				{
					bool IsIconLoaded = false;
					m_layout.SetRewardItemIcon(m_bingoInfo.LPLDJDCELAN_RewardsId[bingonum + i + 1].DNJEJEANJGL_Value, 1, () =>
					{
						//0x109CFE0
						IsIconLoaded = true;
					});
					while (!IsIconLoaded)
						yield return null;
				}
				isPopEnd = false;
				ShowBingoRewaedPopup(_currntBingoNum, _getItemID, _getItemNum, () =>
				{
					//0x109CFA8
					isPopEnd = true;
				});
				while (!isPopEnd)
					yield return null;
				if (ChackScenePlate(reward.GLCLFMGPMAN_ItemFullId))
				{
					RecordPlateUtility.CheckPlateId(reward);
					yield return Co.R(SceneCardCheck());
					RecordPlateUtility.Clear();
					inventoryUtil.JCHLONCMPAJ();
				}
				reward = null;
			}
			bool IsSaveing = true;
			m_bingoInfo.FBANBDCOEJL();
			BingoRewardListPopup.ReceivedBingoCount = m_bingoInfo.OLPBIMOPHLM_ReceiveCount;
			IsRewardNextPlate = m_bingoInfo.JOJINPEMEBC;
			if(m_bingoInfo.FHLGEKGBLLN)
			{
				GNGMCIAIKMA.HHCJCDFCLOB.NJJLNPOCKFO(bingoId);
				IsNextBingo = GNGMCIAIKMA.HHCJCDFCLOB.CGOIJPBINCF(bingoId, true) > 0;
				IsNextBingoEnable = GNGMCIAIKMA.HHCJCDFCLOB.DHPLHALIDHH(bingoId);
				GNGMCIAIKMA.HHCJCDFCLOB.KGABKGKGNCA(bingoId, !IsNextBingo);
				QuestUtility.UpdateQuestData();
				GNGMCIAIKMA.HHCJCDFCLOB.FBHHEBDDIMO(bingoId, false);
				BingoSave(() =>
				{
					//0x109CFB4
					IsSaveing = false;
				}, () =>
				{
					//0x109C650
					MenuScene.Instance.InputEnable();
				});
				while (IsSaveing)
					yield return null;
				isPopEnd = false;
				IsGotoQuest = !IsNextBingo || !IsNextBingoEnable;
				IsGotoBingoSelect = IsNextBingo && IsNextBingoEnable && IsRewardNextPlate;
				ShowBingoEndPopup(IsNextBingo, () =>
				{
					//0x109CFC0
					isPopEnd = true;
				});
				while (!isPopEnd)
					yield return null;
				if(!IsGotoQuest)
				{
					if (!IsGotoBingoSelect)
					{
						yield return Co.R(StartChangeBingoCard());
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.QUEST_BINGOSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
				}
				else
				{
					MenuScene.Instance.Mount(TransitionUniqueId.QUEST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
			}
			else
			{
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(bingoId, null, -1);
				SetBingoText();
				l = GNGMCIAIKMA.HHCJCDFCLOB.ICNOKENCCJK(bingoId, true, false);
				if(l.Count > 0)
				{
					yield return Co.R(Initialize());
					updaterSetting();
				}
				else
				{ 
					BingoSave(() =>
					{
						//0x109CFCC
						IsSaveing = false;
					}, () =>
					{
						//0x109C6EC
						MenuScene.Instance.InputEnable();
					});
					while (IsSaveing)
						yield return null;
				}
			}
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x109BAD0 Offset: 0x109BAD0 VA: 0x109BAD0
		public void BingoSave(Action successAct, Action errorAct)
		{
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x109CFEC
				successAct();
			}, () =>
			{
				//0x109D018
				errorAct();
				MenuScene.Instance.GotoTitle();
			}, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA24C Offset: 0x6CA24C VA: 0x6CA24C
		//// RVA: 0x109BC50 Offset: 0x109BC50 VA: 0x109BC50
		private IEnumerator StartChangeBingoCard()
		{
			//0x10A0438
			GameManager.Instance.fullscreenFader.Fade(1, Color.white);
			yield return null;
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			m_layout.ResetClearIcon();
			yield return Co.R(Initialize());
			yield return null;
			yield return null;
			GameManager.Instance.fullscreenFader.Fade(1, Bingo_FadeIn);
			yield return null;
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			updaterSetting();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA2C4 Offset: 0x6CA2C4 VA: 0x6CA2C4
		//// RVA: 0x109BCFC Offset: 0x109BCFC VA: 0x109BCFC
		private IEnumerator Co_Wait(float _waitTime)
		{
			float time; // 0x14
			float count; // 0x18

			//0x109D3CC
			time = _waitTime;
			count = 0;
			while(count < time)
			{
				count += Time.deltaTime;
				yield return null;
			}
		}

		//// RVA: 0x109BDB4 Offset: 0x109BDB4 VA: 0x109BDB4
		private bool ChackScenePlate(int itemId)
		{
			return EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA33C Offset: 0x6CA33C VA: 0x6CA33C
		//// RVA: 0x109BE48 Offset: 0x109BE48 VA: 0x109BE48
		private IEnumerator SceneCardCheck()
		{
			bool prevInput;

			//0x109FFC4
			prevInput = GameManager.Instance.InputEnabled;
			GameManager.Instance.InputEnabled = true;
			bool isOpenRecordPlateInfo = true;
			this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Bingo, () =>
			{
				//0x109D0E0
				isOpenRecordPlateInfo = false;
			}, false));
			yield return new WaitWhile(() =>
			{
				//0x109D0EC
				return isOpenRecordPlateInfo;
			});
			RecordPlateUtility.ClearShowedList();
			GameManager.Instance.InputEnabled = prevInput;
			while(CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FIGHNFKAMGI.Count > 0)
			{
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FIGHNFKAMGI.RemoveAt(0);
			}
		}

		//// RVA: 0x109BEF4 Offset: 0x109BEF4 VA: 0x109BEF4
		private void SetBingoText()
		{
			for(int i = 0; i < 9; i++)
			{
				JJPEIELNEJB.CJBKOOCMLEO data = m_bingoInfo.BECEJMHDBBP[i];
				string numText = "";
				if(data.GMGGCIJHDJH_ConditionType != 14 && data.GMGGCIJHDJH_ConditionType != 23)
				{
					numText = string.Concat(new object[5]
					{
						"(",
						data.GIKJNDFJFPM_MsCnt,
						"/",
						data.MPBADMODLOJ,
						")"
					});
				}
				m_layout.MissionSetting(i, data.GLCLFMGPMAN_ItemId, data.LJKMKCOAICL_ItemCount, data.FEMMDNIELFC_MissionText, numText);
			}
		}

		//// RVA: 0x109B7C0 Offset: 0x109B7C0 VA: 0x109B7C0
		private bool IsBingoMissionHelp()
		{
			return !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsBingoPlay);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA3B4 Offset: 0x6CA3B4 VA: 0x6CA3B4
		//// RVA: 0x109B8A4 Offset: 0x109B8A4 VA: 0x109B8A4
		private IEnumerator StartHelp()
		{
			GameManager.PushBackButtonHandler backButtonDummy;

			//0x10A0890
			backButtonDummy = () =>
			{
				//0x109C788
				return;
			};
			MenuScene.Instance.InputEnable();
			while (m_layout.RootIsPlaying())
				yield return null;
			bool isWait = true;
			yield return Co.R(TutorialManager.ShowTutorial(GNGMCIAIKMA.HHCJCDFCLOB.GEAMLAKKMLI(), null));
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsBingoPlay, true);
			MenuScene.Save(() =>
			{
				//0x109D0FC
				isWait = false;
			}, null);
			while (isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(backButtonDummy);
			MenuScene.Instance.InputEnable();
			m_updater = updaterSetting;
		}
	}
}
