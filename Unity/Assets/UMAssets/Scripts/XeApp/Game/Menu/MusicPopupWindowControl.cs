using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicPopupWindowControl
	{
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
			TodoLogger.Log(0, "MusicPopupWindowControl Release");
		}

		// // RVA: 0x104C020 Offset: 0x104C020 VA: 0x104C020
		// public void Show(MonoBehaviour mb, MusicPopupWindowControl.CallType type, int musicId, EJKBKMBJMGL enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callBack, bool isSLive = False) { }

		// // RVA: 0x104C198 Offset: 0x104C198 VA: 0x104C198
		// public void ShowEnemyInfo(MonoBehaviour mb, MusicPopupWindowControl.CallType type, EJKBKMBJMGL enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0x104C2D4 Offset: 0x104C2D4 VA: 0x104C2D4
		// private MusicTextDatabase.TextInfo GetMusicTextInfo(int musicId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C91B4 Offset: 0x6C91B4 VA: 0x6C91B4
		// // RVA: 0x104C070 Offset: 0x104C070 VA: 0x104C070
		// private IEnumerator ShowCoroutine(MonoBehaviour mb, MusicPopupWindowControl.CallType type, int musicId, EJKBKMBJMGL enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callBack, bool isSLive) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C922C Offset: 0x6C922C VA: 0x6C922C
		// // RVA: 0x104C1E4 Offset: 0x104C1E4 VA: 0x104C1E4
		// private IEnumerator ShowEnemyInfoCoroutine(MonoBehaviour mb, MusicPopupWindowControl.CallType type, EJKBKMBJMGL enemyData, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callBack) { }

		// // RVA: 0x104C468 Offset: 0x104C468 VA: 0x104C468
		// private SizeType GetEnemyPopupWindowSize(EJKBKMBJMGL enemyData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C92A4 Offset: 0x6C92A4 VA: 0x6C92A4
		// // RVA: 0x104C4F4 Offset: 0x104C4F4 VA: 0x104C4F4
		// private IEnumerator OnBuyMusicCoroutine(int musicId, MusicTextDatabase.TextInfo musicInfo) { }
	}
}
