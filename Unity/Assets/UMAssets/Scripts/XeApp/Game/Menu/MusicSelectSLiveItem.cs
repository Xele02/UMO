using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectSLiveItem : LayoutUGUIScriptBase
	{
		[SerializeField] // RVA: 0x673E74 Offset: 0x673E74 VA: 0x673E74
		private RawImageEx imageItem; // 0x14
		[SerializeField] // RVA: 0x673E84 Offset: 0x673E84 VA: 0x673E84
		private Text textItem; // 0x18
		// private AbsoluteLayout layoutRoot; // 0x1C
		// private NumberBase numberCount; // 0x20
		// private bool isShow; // 0x24

		// public Action<int> onClickButton { private get; set; } // 0x28

		// // RVA: 0x167EB70 Offset: 0x167EB70 VA: 0x167EB70
		// public void TryEnter() { }

		// // RVA: 0x167EC14 Offset: 0x167EC14 VA: 0x167EC14
		public void TryLeave()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveItem TryLeave");
		}

		// // RVA: 0x167EB80 Offset: 0x167EB80 VA: 0x167EB80
		public void Enter()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveItem Enter");
		}

		// // RVA: 0x167EC24 Offset: 0x167EC24 VA: 0x167EC24
		// public void Leave() { }

		// // RVA: 0x167ECB8 Offset: 0x167ECB8 VA: 0x167ECB8
		// public void Show() { }

		// // RVA: 0x167ED40 Offset: 0x167ED40 VA: 0x167ED40
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveItem Hide");
		}

		// // RVA: 0x167EDC8 Offset: 0x167EDC8 VA: 0x167EDC8
		// public bool IsPlaying() { }

		// // RVA: 0x167EDF4 Offset: 0x167EDF4 VA: 0x167EDF4
		public void ItemIconHide()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveItem ItemIconHide");
		}

		// // RVA: 0x167EE24 Offset: 0x167EE24 VA: 0x167EE24
		public void SetIcon(IiconTexture image)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveItem SetIcon");
		}

		// // RVA: 0x167EF70 Offset: 0x167EF70 VA: 0x167EF70
		public void SetCount(int count)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveItem SetCount");
		}

		// // RVA: 0x167EFB0 Offset: 0x167EFB0 VA: 0x167EFB0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectSLiveItem");
			return true;
		}
	}
}
