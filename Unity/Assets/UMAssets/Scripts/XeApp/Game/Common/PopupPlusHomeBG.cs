using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupPlusHomeBG : LayoutUGUIScriptBase, IPopupContent
	{
		public class Setting : PopupSetting
		{
			public int m_bundle_id { get; set; } // 0x34
			public string m_titleName { get; set; } // 0x38
			public int m_bg_id { get; set; } // 0x3C
			public override bool IsPreload { get { return false; } } //0x1BB1A40
			public override bool IsAssetBundle { get { return true; } } //0x1BB1A48
			public override bool IsCaption { get { return false; } } //0x1BB1A50
			public override string PrefabPath { get { return ""; } } //0x1BB1A58
			public override string BundleName { get { return "ly/114.xab"; } } //0x1BB1AB4
			public override string AssetName { get { return "PopupPlusHomeBG"; } } //0x1BB1B10
			public override GameObject Content { get { return m_content; } } //0x1BB1B6C
		}

		[SerializeField]
		private RawImageEx m_image; // 0x14
		[SerializeField]
		private Text m_titleText; // 0x18
		private Setting m_setting; // 0x20
		private Texture2D m_texture; // 0x24
		private bool m_is_ready; // 0x28

		public Transform Parent { get; private set; } // 0x1C

		// RVA: 0x1BB1580 Offset: 0x1BB1580 VA: 0x1BB1580 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as Setting;
			Parent = setting.m_parent;
			m_titleText.text = m_setting.m_titleName;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			m_is_ready = false;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_image);
			MenuScene.Instance.HomeBgIconTextureCache.Load(m_setting.m_bg_id, (IiconTexture texture) =>
			{
				//0x1BB1938
				texture.Set(m_image);
				m_is_ready = true;
			});
		}

		// RVA: 0x1BB18AC Offset: 0x1BB18AC VA: 0x1BB18AC Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BB18B4 Offset: 0x1BB18B4 VA: 0x1BB18B4 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1BB18EC Offset: 0x1BB18EC VA: 0x1BB18EC Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BB1924 Offset: 0x1BB1924 VA: 0x1BB1924 Slot: 10
		public bool IsReady()
		{
			return m_is_ready;
		}

		// RVA: 0x1BB192C Offset: 0x1BB192C VA: 0x1BB192C Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
