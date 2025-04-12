using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGoDivaLevelupSetting : PopupSetting
	{
		public LayoutResultPopupGoDivaLevelup.InitParam initParam; // 0x34

		public override string PrefabPath { get { return ""; } } //0x17A8878
		public override string BundleName { get { return "ly/225.xab"; } } //0x17A88D4
		public override string AssetName { get { return "root_game_res_event04_dlvup_layout_root"; } } //0x17A8930
		public override bool IsAssetBundle { get { return true; } } //0x17A898C
		public override bool IsPreload { get { return false; } } //0x17A8994
		public override GameObject Content { get { return m_content; } } //0x17A899C

		// // RVA: 0x17A89A4 Offset: 0x17A89A4 VA: 0x17A89A4
		// public void SetContent(GameObject obj) { }
	}

	public class PopupGoDivaLevelupContent : UIBehaviour, IPopupContent
	{
		private LayoutResultPopupGoDivaLevelup layout; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17A83FC Offset: 0x17A83FC VA: 0x17A83FC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupGoDivaLevelupSetting s = setting as PopupGoDivaLevelupSetting;
			Parent = control.transform;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			if(s.Content != null)
			{
				layout = s.Content.GetComponent<LayoutResultPopupGoDivaLevelup>();
				if(layout != null)
				{
					layout.Setup(s.initParam);
				}
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x17A86F4 Offset: 0x17A86F4 VA: 0x17A86F4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17A86FC Offset: 0x17A86FC VA: 0x17A86FC Slot: 19
		public void Show()
		{
			if(layout != null)
				layout.Show();
		}

		// RVA: 0x17A87B0 Offset: 0x17A87B0 VA: 0x17A87B0 Slot: 20
		public void Hide()
		{
			if(layout != null)
				layout.Hide();
		}

		// RVA: 0x17A8864 Offset: 0x17A8864 VA: 0x17A8864 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x17A886C Offset: 0x17A886C VA: 0x17A886C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
