using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupUnlock : MonoBehaviour, IDisposable
	{
		public enum eUnlockType
		{
			None = 0,
			Music = 1,
			Stage = 2,
			Diva = 3,
			DivaNotify = 4,
			DifficultyUnlock = 5,
			MultiDivaMusic = 6,
			Line6Music = 7,
			LiveSkip = 8,
			Max = 9,
		}
 
		public enum eSceneType
		{
			None = 0,
			StorySelect = 1,
			Home = 2,
			DropResult = 3,
			MusicSelect = 4,
			FreeMusicSelect1 = 5,
			FreeMusicSelect2 = 6,
		}

		public class UnlockParam
		{
			public eSceneType sceneType; // 0x8
			public eUnlockType unlockType; // 0xC
			public int id; // 0x10
			public int difficultyBit; // 0x14
			public int difficulty6LineBit; // 0x18
			public bool isLine6; // 0x1C
		}

		public class UnlockInfo
		{
			public List<UnlockParam> paramList; // 0x8

			// public PopupUnlock.UnlockParam param { get; } 0x115D728
		}

		private List<UnlockParam> m_paramList = new List<UnlockParam>(); // 0x14
		private Dictionary<int, List<UnlockParam>> m_paramDic = new Dictionary<int, List<UnlockParam>>(); // 0x18
		private List<IEnumerator> m_updater = new List<IEnumerator>(); // 0x1C
		private UnlockInfo m_unlockInfo = new UnlockInfo(); // 0x20
		private LayoutPopupUnlockController m_controller = new LayoutPopupUnlockController(); // 0x24
		private eUnlockType[] ShowPriorityTbl = new eUnlockType[8] {
			eUnlockType.Music, 
			eUnlockType.MultiDivaMusic, 
			eUnlockType.Line6Music,
			eUnlockType.Stage,
			eUnlockType.Diva,
			eUnlockType.DivaNotify,
			eUnlockType.DifficultyUnlock,
			eUnlockType.LiveSkip
		}; // 0x28

		public int PressButtonLabel { get; private set; } // 0xC
		public bool IsClosed { get; private set; } // 0x10
		// public bool IsDisplay { get; } 0x1159BE8

		// // RVA: 0x11588F8 Offset: 0x11588F8 VA: 0x11588F8
		public static PopupUnlock Create(Transform parent)
		{
			GameObject g = new GameObject("PopupUnlock");
			g.transform.SetParent(parent);
			return g.AddComponent<PopupUnlock>();
		}

		// // RVA: 0x11589E0 Offset: 0x11589E0 VA: 0x11589E0
		public static IEnumerator Show(PopupUnlock.eSceneType type, Action<int> callbackClose, bool autoChangeTransition = false, Action<PopupUnlock> receivePopup = null)
		{
			return Coroutine_ShowUnlock(type,callbackClose,autoChangeTransition,receivePopup);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AC64 Offset: 0x70AC64 VA: 0x70AC64
		// // RVA: 0x11589F8 Offset: 0x11589F8 VA: 0x11589F8
		private static IEnumerator Coroutine_ShowUnlock(PopupUnlock.eSceneType type, Action<int> callbackClose, bool autoChangeTransition, Action<PopupUnlock> receivePopup)
		{
			PopupUnlock unlockPopup;

			//0x115C684
			if(GameManager.Instance.IsTutorial)
			{
				if(callbackClose != null)
					callbackClose(0);
			}
			unlockPopup = Create(null);
			unlockPopup.Setup(type);
			unlockPopup.Show();
			if(receivePopup != null)
			{
				receivePopup(unlockPopup);
			}
			while(!unlockPopup.IsClosed)
				yield return null;
			int a = unlockPopup.PressButtonLabel;
			unlockPopup.Dispose();
			if(callbackClose != null)
				callbackClose(a);
			if(autoChangeTransition)
				ChangeTransition(a);
		}

		// // RVA: 0x1158AF0 Offset: 0x1158AF0 VA: 0x1158AF0
		private static void ChangeTransition(int label)
		{
			if(label != 9)
			{
				if(MenuScene.Instance != null)
				{
					if(label == 46)
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, 0);
					}
					else
					{
						if(label != 45)
							return;
						MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, null, true, 0);
					}
				}
			}
		}

		// // RVA: 0x1158E48 Offset: 0x1158E48 VA: 0x1158E48
		private void SetViewData(PopupUnlock.eSceneType sceneType, List<FAGCLBOACEE> viewData)
		{
			for(int i = 0; i < viewData.Count; i++)
			{
				TodoLogger.Log(0, "SetViewData");
			}
		}

		// // RVA: 0x1159878 Offset: 0x1159878 VA: 0x1159878
		public void ViewInitialize(eSceneType type)
		{
			switch(type)
			{
				case eSceneType.StorySelect:
					TodoLogger.Log(0, "ViewInitialize 1");
					return;
				case eSceneType.Home:
					SetViewData(eSceneType.Home, FAGCLBOACEE.OGGDOPACJOB());
					return;
				case eSceneType.DropResult:
					TodoLogger.Log(0, "ViewInitialize 3");
					return;
				case eSceneType.MusicSelect:
					TodoLogger.Log(0, "ViewInitialize 4");
					return;
				case eSceneType.FreeMusicSelect1:
					TodoLogger.Log(0, "ViewInitialize 5");
					return;
				case eSceneType.FreeMusicSelect2:
					TodoLogger.Log(0, "ViewInitialize 6");
					return;
				default:
					return;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AD1C Offset: 0x70AD1C VA: 0x70AD1C
		// // RVA: 0x1159B20 Offset: 0x1159B20 VA: 0x1159B20
		// public IEnumerator LoadLayout(Action callback) { }

		// // RVA: 0x11597F8 Offset: 0x11597F8 VA: 0x11597F8
		// public void AddParam(PopupUnlock.UnlockParam param) { }

		// // RVA: 0x1159C70 Offset: 0x1159C70 VA: 0x1159C70
		// public bool IsClearStoryMusic(int musicId) { }

		// // RVA: 0x1159D80 Offset: 0x1159D80 VA: 0x1159D80
		public void Clear()
		{
			m_paramList.Clear();
			PressButtonLabel = 0;
		}

		// RVA: 0x1159E00 Offset: 0x1159E00 VA: 0x1159E00 Slot: 4
		public void Dispose()
		{
			Clear();
			m_controller.Dispose();
			Destroy(gameObject);
		}

		// // RVA: 0x1159EBC Offset: 0x1159EBC VA: 0x1159EBC
		public void Setup(eSceneType type)
		{
			ViewInitialize(type);
			m_controller.Parent = gameObject;
			m_controller.Setup();
		}

		// // RVA: 0x1159F24 Offset: 0x1159F24 VA: 0x1159F24
		public void Show()
		{
			if(m_paramList.Count < 1)
				IsClosed = true;
			else
			{
				TodoLogger.Log(0, "Show");
			}
		}

		// // RVA: 0x115A7AC Offset: 0x115A7AC VA: 0x115A7AC
		// public void Update() { }

		// // RVA: 0x115A988 Offset: 0x115A988 VA: 0x115A988
		// private void CheckButtonLabel() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70AD94 Offset: 0x70AD94 VA: 0x70AD94
		// // RVA: 0x115A56C Offset: 0x115A56C VA: 0x115A56C
		// private IEnumerator ShowPopupDefault(PopupUnlock.eUnlockType unlockType, List<PopupUnlock.UnlockParam> param) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70AE0C Offset: 0x70AE0C VA: 0x70AE0C
		// // RVA: 0x115A6EC Offset: 0x115A6EC VA: 0x115A6EC
		// private IEnumerator ShowPopupDiva(PopupUnlock.eUnlockType unlockType, List<PopupUnlock.UnlockParam> param) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70AE84 Offset: 0x70AE84 VA: 0x70AE84
		// // RVA: 0x115A62C Offset: 0x115A62C VA: 0x115A62C
		// private IEnumerator ShowPopupMusic(PopupUnlock.eUnlockType unlockType, List<PopupUnlock.UnlockParam> param) { }

		// // RVA: 0x115AA7C Offset: 0x115AA7C VA: 0x115AA7C
		// private PopupSetting CreatePopupSetting(PopupUnlock.eUnlockType unlockTYpe, List<PopupUnlock.UnlockParam> param) { }

		// // RVA: 0x115BE00 Offset: 0x115BE00 VA: 0x115BE00
		// private ButtonInfo[] GetButtons(PopupUnlock.eSceneType sceneType) { }

		// // RVA: 0x115BFDC Offset: 0x115BFDC VA: 0x115BFDC
		// private void PopupShowCommon(PopupUnlock.eUnlockType unlockType, List<PopupUnlock.UnlockParam> param, Action callback, Action openStartCallback, Func<bool> closeWaitCallback) { }
	}
}
