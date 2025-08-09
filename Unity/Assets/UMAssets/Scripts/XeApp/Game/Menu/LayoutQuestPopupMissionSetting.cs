using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutQuestPopupMissionSettingSetting : PopupSetting
	{
		public LayoutQuestPopupMissionSettingWindow.SelectType DefaultSelectButton { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x187C700
		public override string BundleName { get { return "ly/107.xab"; } } //0x187C75C
		public override string AssetName { get { return "PopupMissionSetting"; } } //0x187C7B8
		public override bool IsAssetBundle { get { return true; } } //0x187C814
		public override bool IsPreload { get { return true; } } //0x187C81C
		public override GameObject Content { get { return m_content; } } //0x187C824

		// // RVA: 0x187C82C Offset: 0x187C82C VA: 0x187C82C
		// public void SetContent(GameObject obj) { }
	}

	public class LayoutQuestPopupMissionSetting : UIBehaviour, IPopupContent
	{
		private PopupWindowControl m_control; // 0x10
		private LayoutQuestPopupMissionSettingWindow window; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x187C05C Offset: 0x187C05C VA: 0x187C05C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_control = control;
			window = transform.GetComponent<LayoutQuestPopupMissionSettingWindow>();
			window.Setup((setting as LayoutQuestPopupMissionSettingSetting).DefaultSelectButton);
		}

		// // RVA: 0x187C5D0 Offset: 0x187C5D0 VA: 0x187C5D0
		public bool IsPrevSelectMusic()
		{
			return window.IsPrevSelectMusic();
		}

		// RVA: 0x187C614 Offset: 0x187C614 VA: 0x187C614 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x187C61C Offset: 0x187C61C VA: 0x187C61C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x187C654 Offset: 0x187C654 VA: 0x187C654 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x187C68C Offset: 0x187C68C VA: 0x187C68C Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x187C694 Offset: 0x187C694 VA: 0x187C694 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0x187C698 Offset: 0x187C698 VA: 0x187C698
		// private void OnBeginTextureLoad() { }

		// // RVA: 0x187C6C4 Offset: 0x187C6C4 VA: 0x187C6C4
		// private void OnEndTextureLoad() { }
	}
}
