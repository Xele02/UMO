using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	internal enum StatusPopupType
	{
		Diva = 0,
		Scene = 1,
	}
	internal struct StatusPopupState
	{
		public StatusPopupType type; // 0x0
		public int id; // 0x4
		public bool isCloseOnly; // 0x8
		public bool isGoDiva; // 0x9
		public int divaSlotNumber; // 0xC
	}

	public class StatusWindowControl
	{
		private Dictionary<int, List<StatusPopupState>> m_popStateDict = new Dictionary<int, List<StatusPopupState>>(); // 0x8
		private int m_historyPosition; // 0xC
		public DivaStatePopupSetting m_divaStatePopup; // 0x10
		public SceneStatePopupSetting m_sceneStatePopup; // 0x14

		// [IteratorStateMachineAttribute] // RVA: 0x7354B4 Offset: 0x7354B4 VA: 0x7354B4
		// RVA: 0x12E147C Offset: 0x12E147C VA: 0x12E147C
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			//0x12E33B4
			m_divaStatePopup = new DivaStatePopupSetting();
			m_divaStatePopup.SetParent(parent.transform);
			yield return null;
			m_divaStatePopup.WindowSize = Common.SizeType.Large;
			m_sceneStatePopup = new SceneStatePopupSetting();
			m_sceneStatePopup.SetParent(parent.transform);
			yield return null;
			m_sceneStatePopup.WindowSize = Common.SizeType.Large;
			if (action != null)
				action();
		}

		// // RVA: 0x12E155C Offset: 0x12E155C VA: 0x12E155C
		public void ResetHistory()
		{
			foreach(var k in m_popStateDict)
			{
				k.Value.Clear();
			}
		}

		// // RVA: 0x12E1708 Offset: 0x12E1708 VA: 0x12E1708
		public void ShowDivaStatusPopupWindow(FFHPBEPOMAK_DivaInfo diva, DFKGGBMFFGB_PlayerInfo playerData, EAJCBFGKKFA_FriendInfo friendData, EEDKAACNBBG_MusicData musicData, bool isMoment, TransitionList.Type transitionName = TransitionList.Type.UNDEFINED, Action callBack = null, bool isFriend = false, bool isChangeScene = true, bool isCloseOnly = false, int divaSlotNumber = -1, bool isGoDiva = false)
		{
			if(!isGoDiva)
			{
				divaSlotNumber = -1;
				JLKEOGLJNOD_TeamInfo team = playerData.DPLBHAIKPGL_GetTeam(false);
				for(int i = 0; i < team.BCJEAJPLGMB_MainDivas.Count; i++)
				{
					if(team.BCJEAJPLGMB_MainDivas[i] != null)
					{
						if(team.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId == diva.AHHJLDLAPAN_DivaId)
						{
							divaSlotNumber = i;
							break;
						}
					}
				}
				if(divaSlotNumber == -1)
				{
					for(int i = 0; i < team.CMOPCCAJAAO_AddDivas.Count; i++)
					{
						if(team.CMOPCCAJAAO_AddDivas[i] != null)
						{
							if(team.CMOPCCAJAAO_AddDivas[i].AHHJLDLAPAN_DivaId == diva.AHHJLDLAPAN_DivaId)
							{
								divaSlotNumber = i + team.BCJEAJPLGMB_MainDivas.Count;
								break;
							}
						}
					}
				}
			}
			//LAB_012e1b30
			if(!isFriend && !isCloseOnly)
			{
				m_divaStatePopup.Buttons = new ButtonInfo[3]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.GrowthConfirm, Type = PopupButton.ButtonType.Growth},
					new ButtonInfo() { Label = PopupButton.ButtonLabel.CostumeSelect, Type = PopupButton.ButtonType.Costume}
				};
			}
			else
			{
				m_divaStatePopup.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_divaStatePopup.TitleText = bk.GetMessageByLabel("popup_text_08");
			m_divaStatePopup.Diva = diva;
			m_divaStatePopup.DivaSlotIndex = divaSlotNumber;
			m_divaStatePopup.PlayerData = playerData;
			m_divaStatePopup.FriendData = friendData;
			m_divaStatePopup.MusicData = musicData;
			m_divaStatePopup.IsOpenAnimeMoment = isMoment;
			m_divaStatePopup.IsFriend = isFriend;
			m_divaStatePopup.IsChangeScene = isChangeScene;
			m_divaStatePopup.IsGoDiva = isGoDiva;
			List<StatusPopupState> popupStateList = null;
			if(transitionName != TransitionList.Type.UNDEFINED)
			{
				if(!m_popStateDict.TryGetValue((int)transitionName, out popupStateList))
				{
					popupStateList = new List<StatusPopupState>(8);
					m_popStateDict[(int)transitionName] = popupStateList;
				}
				popupStateList.Add(new StatusPopupState()
				{
					type = StatusPopupType.Diva,
					id = diva.AHHJLDLAPAN_DivaId,
					isCloseOnly = isCloseOnly,
					isGoDiva = isGoDiva,
					divaSlotNumber = divaSlotNumber
				});
			}
			int counter = 0;
			PopupWindowManager.Show(m_divaStatePopup, (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
			{
				//0x12E2E6C
				if(label == PopupButton.ButtonType.Costume)
				{
					CostumeChangeDivaArgs arg = new CostumeChangeDivaArgs();
					arg.DivaId = diva.AHHJLDLAPAN_DivaId;
					arg.is_godiva = isGoDiva;
					MenuScene.Instance.Call(TransitionList.Type.COSTUME_SELECT, arg, true);
				}
				else if(label == PopupButton.ButtonType.Growth)
				{
					GrowthConfArgs arg = new GrowthConfArgs();
					arg.DivaId = diva.AHHJLDLAPAN_DivaId;
					TodoLogger.LogNotImplemented("ShowDivaStatusPopupWindow");
					//MenuScene.Instance.Call(TransitionList.Type.DIVA_GROWTH_CONF, arg, true);
				}
				else
				{
					if(callBack != null)
						callBack();
					popupStateList.RemoveAt(popupStateList.Count - 1);
				}
			}, null, null, null, true, true, false, () =>
			{
				//0x12E30A0
				bool a = counter != 0;
				if(!a)
					counter = 1;
				return a;
			});
        }

		// // RVA: 0x12E21FC Offset: 0x12E21FC VA: 0x12E21FC
		public void ShowSceneStatusPopupWindow(GCIJNCFDNON_SceneInfo scene, DFKGGBMFFGB_PlayerInfo playerData, bool isMoment, TransitionList.Type transitionName = TransitionList.Type.UNDEFINED, Action callBack = null, bool isFriend = false, bool isReward = false, SceneStatusParam.PageSave pageSave = SceneStatusParam.PageSave.Player, bool isDisableZoom = false)
		{
			if(isFriend || isReward)
			{
				m_sceneStatePopup.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			else
			{
				if(scene.KELFCMEOPPM_EpisodeId < 1)
				{
					m_sceneStatePopup.Buttons = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.SkillRelease, Type = PopupButton.ButtonType.Ability }
					};
				}
				else
				{
					m_sceneStatePopup.Buttons = new ButtonInfo[3]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Episode, Type = PopupButton.ButtonType.Episode },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.SkillRelease, Type = PopupButton.ButtonType.Ability }
					};
				}
			}
			List<StatusPopupState> popupStateList = null;
			if(transitionName != TransitionList.Type.UNDEFINED)
			{
				if(!m_popStateDict.TryGetValue((int)transitionName, out popupStateList))
				{
					popupStateList = new List<StatusPopupState>(8);
					m_popStateDict[(int)transitionName] = popupStateList;
				}
				popupStateList.Add(new StatusPopupState() {
					type = StatusPopupType.Scene,
					id = scene.BCCHOBPJJKE_SceneId,
					isCloseOnly = false,
					isGoDiva = false
				});
			}
			m_sceneStatePopup.Scene = scene;
			m_sceneStatePopup.PlayerData = playerData;
			m_sceneStatePopup.IsOpenAnimeMoment = isMoment;
			m_sceneStatePopup.IsFriend = isFriend;
			m_sceneStatePopup.PageSave = pageSave;
			m_sceneStatePopup.IsDisableZoom = isDisableZoom;
			m_sceneStatePopup.TitleText = GameMessageManager.GetSceneCardName(scene);
			int counter = 0;
			PopupWindowManager.Show(m_sceneStatePopup, (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
			{
				//0x12E30C0
				if(type == PopupButton.ButtonLabel.Episode)
				{
					PopupWindowManager.Close(control, null);
					PIGBBNDPPJC p = new PIGBBNDPPJC();
					p.KHEKNNFCAOI(scene.KELFCMEOPPM_EpisodeId);
					EpisodeDetailArgs arg = new EpisodeDetailArgs();
					arg.data = p;
					//MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT_EPISODEDETAIL, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					TodoLogger.LogNotImplemented("ShowSceneStatusPopupWindow");
				}
				else if(type == PopupButton.ButtonLabel.SkillRelease)
				{
					PopupWindowManager.Close(control, null);
					SceneGrowthSceneArgs arg = new SceneGrowthSceneArgs(scene, false);
					//MenuScene.Instance.Call(TransitionList.Type.SCENE_GROWTH, arg, true);
					TodoLogger.LogNotImplemented("ShowSceneStatusPopupWindow");
					return;
				}
				else
				{
					if(callBack != null)
						callBack();
				}
				if(popupStateList != null)
					popupStateList.RemoveAt(popupStateList.Count - 1);
			}, null, null, null, true, true, false, () =>
			{
				//0x12E3390
				bool b = counter != 0;
				if(!b)
					counter = 1;
				return b;
			});
		}

		// // RVA: 0x12E2978 Offset: 0x12E2978 VA: 0x12E2978
		public void TryShowPopupWindow(DFKGGBMFFGB_PlayerInfo viewPlayerData, EEDKAACNBBG_MusicData musicData, bool isMoment, TransitionList.Type transitionName, Action closeCallBack)
		{
			List<StatusPopupState> l;
			if(m_popStateDict.TryGetValue((int)transitionName, out l))
			{
				int c = l.Count;
				for (int i = c; i > 0; i--)
				{
					StatusPopupState s = l[0];
					l.RemoveAt(0);
					if (s.type == StatusPopupType.Diva)
					{
						FFHPBEPOMAK_DivaInfo diva;
						bool b;
						if (!s.isGoDiva)
						{
							diva = viewPlayerData.NBIGLBMHEDC[s.id - 1];
							b = false;
						}
						else
						{
							int idx;
							List<FFHPBEPOMAK_DivaInfo> dl;
							if(s.divaSlotNumber < viewPlayerData.DPLBHAIKPGL_GetTeam(true).BCJEAJPLGMB_MainDivas.Count)
							{
								dl = viewPlayerData.DPLBHAIKPGL_GetTeam(true).BCJEAJPLGMB_MainDivas;
								idx = s.divaSlotNumber;
							}
							else
							{
								dl = viewPlayerData.DPLBHAIKPGL_GetTeam(true).CMOPCCAJAAO_AddDivas;
								idx = s.divaSlotNumber = viewPlayerData.DPLBHAIKPGL_GetTeam(true).BCJEAJPLGMB_MainDivas.Count;
							}
							diva = dl[idx];
							b = true;
						}
						ShowDivaStatusPopupWindow(diva, viewPlayerData, null, musicData, isMoment, transitionName, closeCallBack, false, true, s.isCloseOnly, s.divaSlotNumber, b);
					}
					else
					{
						ShowSceneStatusPopupWindow(viewPlayerData.OPIBAPEGCLA_Scenes[s.id], viewPlayerData, isMoment, transitionName, closeCallBack, false, false, SceneStatusParam.PageSave.Player, false);
					}
				}
			}
		}
	}
}
