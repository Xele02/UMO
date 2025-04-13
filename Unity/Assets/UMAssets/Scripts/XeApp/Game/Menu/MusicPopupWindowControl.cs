using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public class MusicPopupWindowControl
	{
		public enum CallType
		{
			MusicSelect = 0,
			StorySelect = 1,
		}
		private MusicInfoPopupSetting m_musicInfoPopupSetting; // 0x8
		private EnemyInfoPopupSetting m_enemyInfoPopupSetting; // 0xC
		private PopupDivaSkillLevelSetting m_divaSkillLevelPopupSetting; // 0x10
		private PopupTabSetting m_tabSetting; // 0x14
		private PopupTabContents m_tabContents; // 0x18
		private static readonly Dictionary<int, PopupTabContents.ContentsData> m_contensDataDic = new Dictionary<int, PopupTabContents.ContentsData>(); // 0x0
		private static readonly List<PopupTabButton.ButtonLabel>[] m_contentLabel = new List<PopupTabButton.ButtonLabel>[2]
			{
				new List<PopupTabButton.ButtonLabel>() { PopupTabButton.ButtonLabel.MusicInformation, PopupTabButton.ButtonLabel.DivaLevelOfSkill },
				new List<PopupTabButton.ButtonLabel>() { PopupTabButton.ButtonLabel.MusicInformation, PopupTabButton.ButtonLabel.EnemyInformation }
			}; // 0x4
		private static readonly List<ButtonInfo>[] m_popupButton = new List<ButtonInfo>[2]
		{
			new List<ButtonInfo>()
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
			}, new List<ButtonInfo>()
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}
		}; // 0x8

		// // RVA: 0x104BB44 Offset: 0x104BB44 VA: 0x104BB44
		public void Initialize(Transform parent)
		{
			m_musicInfoPopupSetting = new MusicInfoPopupSetting();
			m_enemyInfoPopupSetting = new EnemyInfoPopupSetting();
			m_divaSkillLevelPopupSetting = new PopupDivaSkillLevelSetting();
			m_musicInfoPopupSetting.SetParent(parent);
			m_enemyInfoPopupSetting.SetParent(parent);
			m_divaSkillLevelPopupSetting.SetParent(parent);
			m_contensDataDic.Add(6, new PopupTabContents.ContentsData(6, m_musicInfoPopupSetting, "popup_music_select_00"));
			m_contensDataDic.Add(7, new PopupTabContents.ContentsData(7, m_enemyInfoPopupSetting, "popup_music_select_07"));
			m_contensDataDic.Add(8, new PopupTabContents.ContentsData(8, m_divaSkillLevelPopupSetting, "popup_music_select_06"));
		}

		// // RVA: 0x104BE40 Offset: 0x104BE40 VA: 0x104BE40
		public void Release()
		{
			UnityEngine.Object.Destroy(m_musicInfoPopupSetting.Content);
			UnityEngine.Object.Destroy(m_enemyInfoPopupSetting.Content);
			UnityEngine.Object.Destroy(m_divaSkillLevelPopupSetting.Content);
			m_musicInfoPopupSetting.SetContent(null);
			m_enemyInfoPopupSetting.SetContent(null);
			m_divaSkillLevelPopupSetting.SetContent(null);
			m_contensDataDic.Clear();
		}

		// // RVA: 0x104C020 Offset: 0x104C020 VA: 0x104C020
		public void Show(MonoBehaviour mb, CallType type, int musicId, EJKBKMBJMGL_EnemyData enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callBack, bool isSLive = false)
		{
			mb.StartCoroutineWatched(ShowCoroutine(mb, type, musicId, enemyData, callBack, isSLive));
		}

		// // RVA: 0x104C198 Offset: 0x104C198 VA: 0x104C198
		public void ShowEnemyInfo(MonoBehaviour mb, CallType type, EJKBKMBJMGL_EnemyData enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			mb.StartCoroutineWatched(ShowEnemyInfoCoroutine(mb, type, enemyData, callback));
		}

		// // RVA: 0x104C2D4 Offset: 0x104C2D4 VA: 0x104C2D4
		private MusicTextDatabase.TextInfo GetMusicTextInfo(int musicId)
		{
			return Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId).KNMGEEFGDNI_Nam);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C91B4 Offset: 0x6C91B4 VA: 0x6C91B4
		// // RVA: 0x104C070 Offset: 0x104C070 VA: 0x104C070
		private IEnumerator ShowCoroutine(MonoBehaviour mb, CallType type, int musicId, EJKBKMBJMGL_EnemyData enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callBack, bool isSLive)
		{
			bool isLoading; // 0x2D
			UGUIFader fader; // 0x30

			//0x104D470
			isLoading = false;
			fader = GameManager.Instance.fullscreenFader;
			if(m_tabSetting == null || !m_tabSetting.ISLoaded())
			{
				m_tabSetting = PopupWindowManager.CreateTabContents((PopupTabContents tabContents) =>
				{
					//0x104CD10
					m_tabContents = tabContents;
				});
				m_tabSetting.SetParent(m_musicInfoPopupSetting.m_parent);
				isLoading = true;
			}
			if(!m_musicInfoPopupSetting.ISLoaded())
			{
				mb.StartCoroutineWatched(m_musicInfoPopupSetting.LoadAssetBundlePrefab(m_musicInfoPopupSetting.m_parent));
			}
			if(!m_enemyInfoPopupSetting.ISLoaded())
			{
				mb.StartCoroutineWatched(m_enemyInfoPopupSetting.LoadAssetBundlePrefab(m_enemyInfoPopupSetting.m_parent));
			}
			if(!m_divaSkillLevelPopupSetting.ISLoaded())
			{
				mb.StartCoroutineWatched(m_divaSkillLevelPopupSetting.LoadAssetBundlePrefab(m_divaSkillLevelPopupSetting.m_parent));
			}
			if(isLoading)
			{
				fader.Fade(0, new Color(0, 0, 0, 0.5f));
				GameManager.Instance.NowLoading.Show();
			}
			while (!m_musicInfoPopupSetting.ISLoaded())
				yield return null;
			while (!m_enemyInfoPopupSetting.ISLoaded())
				yield return null;
			while (!m_divaSkillLevelPopupSetting.ISLoaded())
				yield return null;
			while (!m_tabSetting.ISLoaded())
				yield return null;
			if(isLoading)
			{
				fader.Fade(0, 0);
				GameManager.Instance.NowLoading.Hide();
			}
			MusicTextDatabase.TextInfo musicInfo = GetMusicTextInfo(musicId);
			m_musicInfoPopupSetting.musicId = musicId;
			m_musicInfoPopupSetting.flameDisplay = type == CallType.StorySelect;
			m_musicInfoPopupSetting.isValidMusicUrl = musicInfo.isEnableBuyURL;
			m_musicInfoPopupSetting.onClickMusicButton = () =>
			{
				//0x104CD38
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				mb.StartCoroutineWatched(OnBuyMusicCoroutine(musicId, musicInfo));
			};
			m_enemyInfoPopupSetting.enemyData = enemyData;
			m_divaSkillLevelPopupSetting.selectMusicId = musicId;
			m_tabContents.ClearContents();
			for(int i = 0; i < m_contentLabel[(int)type].Count; i++)
			{
				m_tabContents.AddContents(m_contensDataDic[(int)m_contentLabel[(int)type][i]]);
			}
			m_tabContents.SelectIndex = (int)m_contentLabel[(int)type][0];
			m_tabSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_music_select_00");
			m_tabSetting.WindowSize = SizeType.Middle;
			m_tabSetting.DefaultTab = m_contentLabel[(int)type][0];
			m_tabSetting.Buttons = m_popupButton[(int)type].ToArray();
			m_tabSetting.Tabs = m_contentLabel[(int)type].ToArray();
			PopupWindowControl ctrl = PopupWindowManager.Show(m_tabSetting, callBack, (IPopupContent content, PopupTabButton.ButtonLabel blabel) =>
			  {
				  //0x104CB90
				  (content as PopupTabContents).ChangeContents((int)blabel);
			  }, null, null);
			if (!isSLive)
				yield break;
			ctrl.m_tabButtonUguiRuntime.gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C922C Offset: 0x6C922C VA: 0x6C922C
		// // RVA: 0x104C1E4 Offset: 0x104C1E4 VA: 0x104C1E4
		private IEnumerator ShowEnemyInfoCoroutine(MonoBehaviour mb, CallType type, EJKBKMBJMGL_EnemyData enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callBack)
		{
			//0x104E354
			MenuScene.Instance.InputDisable();
			if(!m_enemyInfoPopupSetting.ISLoaded())
			{
				mb.StartCoroutineWatched(m_enemyInfoPopupSetting.LoadAssetBundlePrefab(m_enemyInfoPopupSetting.m_parent));
			}
			while (!m_enemyInfoPopupSetting.ISLoaded())
				yield return null;
			m_enemyInfoPopupSetting.enemyData = enemyData;
			m_enemyInfoPopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", m_contensDataDic[7].popupTitleLabel);
			m_enemyInfoPopupSetting.WindowSize = GetEnemyPopupWindowSize(enemyData);
			m_enemyInfoPopupSetting.Buttons = m_popupButton[(int)type].ToArray();
			MenuScene.Instance.InputEnable();
			PopupWindowManager.Show(m_enemyInfoPopupSetting, callBack, null, null, null);
		}

		// // RVA: 0x104C468 Offset: 0x104C468 VA: 0x104C468
		private SizeType GetEnemyPopupWindowSize(EJKBKMBJMGL_EnemyData enemyData)
		{
			if(enemyData.CDEFLIHHNAB_HasSkills)
			{
				if(enemyData.LMJFFFOEPLE_LiveSkillId > 0)
				{
					if (enemyData.PDHCABLLJPB_CenterSkillId > 0)
						return SizeType.Large;
				}
			}
			return SizeType.Middle;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C92A4 Offset: 0x6C92A4 VA: 0x6C92A4
		// // RVA: 0x104C4F4 Offset: 0x104C4F4 VA: 0x104C4F4
		private IEnumerator OnBuyMusicCoroutine(int musicId, MusicTextDatabase.TextInfo musicInfo)
		{
			//0x104CE08
			TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetMessage("menu", "popup_buy_music_msg_android"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			s.IsCaption = false;
			bool isClosed = false;
			bool openUrl = false;
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x104CDE8
				if (type == PopupButton.ButtonType.Positive)
					openUrl = true;
			}, null, null, null, endCallBaack: () =>
			{
				//0x104CDF8
				isClosed = true;
			}, buttonSeEvent: OtherUtility.PopupWindowOpenUrlButtonSe);
			while (!isClosed)
				yield return null;
			if(openUrl)
			{
				ILCCJNDFFOB.HHCJCDFCLOB.EAEHILOBHDA(musicId, musicInfo.musicName);
				PopupWindowManager.SetInputState(false);
				OtherUtility.OpenURL(musicInfo.buyURL, () =>
				{
					//0x104CC88
					PopupWindowManager.SetInputState(true);
				}, 0.5f);
			}
		}
	}
}
