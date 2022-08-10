using XeSys;
using UnityEngine;
using System.Text;

namespace XeApp.Game.Tutorial
{
	public class BasicTutorialManager : SingletonBehaviour<BasicTutorialManager>
	{
		private GameObject m_blackImageInstance; // 0xC
		private TutorialHighLight m_highLight; // 0x10
		private GameObject m_cursorInstance; // 0x14
		// private TutorialPointer m_pointer; // 0x18
		// private List<ButtonBase> m_buttonList; // 0x1C
		private StringBuilder m_strBuilder; // 0x20
		// private TutorialMessageWindow m_messageWindow; // 0x24
		private int[,] m_charaTextRowColCountTable; // 0x28

		// // RVA: 0xE3D1B0 Offset: 0xE3D1B0 VA: 0xE3D1B0
		// public bool IsLoadedLayout() { }

		// // RVA: 0xE3D23C Offset: 0xE3D23C VA: 0xE3D23C
		// public static void Initialize() { }

		// // RVA: 0xE3D3E8 Offset: 0xE3D3E8 VA: 0xE3D3E8
		// public void PreLoadResource(UnityAction finishCb, bool isAppendLayout = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE360 Offset: 0x6AE360 VA: 0x6AE360
		// // RVA: 0xE3D4CC Offset: 0xE3D4CC VA: 0xE3D4CC
		// public IEnumerator PreDownLoadTextureResource(BasicTutorialMessageId id) { }

		// // RVA: 0xE3D578 Offset: 0xE3D578 VA: 0xE3D578 Slot: 6
		// public virtual void Release() { }

		// // RVA: 0xE3D7CC Offset: 0xE3D7CC VA: 0xE3D7CC
		// public static void SetupFirstTutorialLog() { }

		// // RVA: 0xE3D9B0 Offset: 0xE3D9B0 VA: 0xE3D9B0
		// public static void Log(OAGBCBBHMPF.OGBCFNIKAFI step) { }

		// // RVA: 0xE3DB08 Offset: 0xE3DB08 VA: 0xE3DB08
		public static void TutorialAfterFirstLoginBonus()
		{
			TodoLogger.Log(5, "TutorialAfterFirstLoginBonus");
		}

		// // RVA: 0xE3DD1C Offset: 0xE3DD1C VA: 0xE3DD1C
		// public static void TutorialAfterFirstHome() { }

		// // RVA: 0xE3DF30 Offset: 0xE3DF30 VA: 0xE3DF30
		// public void ShowMessageWindow(BasicTutorialMessageId id, Action endCallBack, AdvMessageBase.TagConvertFunc func) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE3D8 Offset: 0x6AE3D8 VA: 0x6AE3D8
		// // RVA: 0xE3E078 Offset: 0xE3E078 VA: 0xE3E078
		// private IEnumerator ProcMessage(ILLPGHGGKLL.AFBMNDPOALE messData, Action endCallBack, AdvMessageBase.TagConvertFunc func) { }

		// // RVA: 0xE3E170 Offset: 0xE3E170 VA: 0xE3E170
		// public void SetInputLimit(InputLimitButton button, UnityAction onPush, Func<ButtonBase> findButton, TutorialPointer.Direction dir = 1) { }

		// // RVA: 0xE409E4 Offset: 0xE409E4 VA: 0xE409E4
		// private bool ObjectFindFunc(Transform ts, string name, string parentName) { }

		// // RVA: 0xE40AD4 Offset: 0xE40AD4 VA: 0xE40AD4
		// public void ShowCursor(CursorPosition positionType) { }

		// // RVA: 0xE413B4 Offset: 0xE413B4 VA: 0xE413B4
		public void HideCursor()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xE4146C Offset: 0xE4146C VA: 0xE4146C
		// public void ChangeCursorLastSibling() { }

		// // RVA: 0xE3FA90 Offset: 0xE3FA90 VA: 0xE3FA90
		// private void SetCursorPosition(RectTransform target, TutorialPointer.Direction dir) { }

		// // RVA: 0xE40498 Offset: 0xE40498 VA: 0xE40498
		// private void SetRect(LayoutUGUIHitOnly hitOnly, Vector2 offset, Vector2 scale) { }

		// // RVA: 0xE3FF5C Offset: 0xE3FF5C VA: 0xE3FF5C
		// private void SetRect(RectTransform rt, Vector2 offset, Vector2 scale) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE450 Offset: 0x6AE450 VA: 0x6AE450
		// // RVA: 0xE3D40C Offset: 0xE3D40C VA: 0xE3D40C
		// private IEnumerator PreLoadLayoutCoroutine(UnityAction finishCb, bool isAppendLayout = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE4C8 Offset: 0x6AE4C8 VA: 0x6AE4C8
		// // RVA: 0xE4172C Offset: 0xE4172C VA: 0xE4172C
		// private IEnumerator LoadBaseLayoutCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE540 Offset: 0x6AE540 VA: 0x6AE540
		// // RVA: 0xE417D8 Offset: 0xE417D8 VA: 0xE417D8
		// private IEnumerator LoadAppendLayoutCoroutine() { }

		// // RVA: 0xE41884 Offset: 0xE41884 VA: 0xE41884
		// public void UpdateLocalPlayerData() { }

		// // RVA: 0xE419D0 Offset: 0xE419D0 VA: 0xE419D0
		// public void UpdateRecoveryPoint(ILDKBCLAFPB.CDIPJNPICCO rPoint) { }

		// // RVA: 0xE41B10 Offset: 0xE41B10 VA: 0xE41B10
		// public void SaveMusicResult() { }

		// // RVA: 0xE41D24 Offset: 0xE41D24 VA: 0xE41D24
		// public ILDKBCLAFPB.CDIPJNPICCO GetRecoveryPoint() { }

		// // RVA: 0xE41E18 Offset: 0xE41E18 VA: 0xE41E18
		// public JGEOBNENMAH.EDHCNKBMLGI SetupTutorialGame(TutorialGameMode.Type type) { }

		// // RVA: 0xE42544 Offset: 0xE42544 VA: 0xE42544
		// public static bool IsBeginnerMission() { }

		// // RVA: 0xE42630 Offset: 0xE42630 VA: 0xE42630
		public BasicTutorialManager()
		{
			TodoLogger.Log(0, "TODO");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6AE5B8 Offset: 0x6AE5B8 VA: 0x6AE5B8
		// // RVA: 0xE42748 Offset: 0xE42748 VA: 0xE42748
		// private void <LoadAppendLayoutCoroutine>b__29_0(GameObject instance) { }
	}
}
