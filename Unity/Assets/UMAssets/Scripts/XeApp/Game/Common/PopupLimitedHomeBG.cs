using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupLimitedHomeBG : LayoutUGUIScriptBase, IPopupContent
	{
		public class Setting : PopupSetting
		{
			public int m_bundle_id { get; set; } // 0x34
			public int m_time_zone { get; set; } // 0x38
			public int m_bg_id { get; set; } // 0x3C
			public override bool IsPreload { get { return false; } } //0x1BAE264
			public override bool IsAssetBundle { get { return true; } } //0x1BAE26C
			public override bool IsCaption { get { return false; } } //0x1BAE274
			public override string PrefabPath { get { return ""; } } //0x1BAE27C
			public override string BundleName { get { return "ly/114.xab"; } } //0x1BAE2D8
			public override string AssetName { get { return "PopupLimitedHomeBG"; } } //0x1BAE334
			public override GameObject Content { get { return m_content; } } //0x1BAE390
		}

		[SerializeField]
		private RawImageEx m_image_00; // 0x14
		[SerializeField]
		private Text m_text_00; // 0x18
		[SerializeField]
		private Text m_text_01; // 0x1C
		private Setting m_setting; // 0x24
		private Texture2D m_texture; // 0x28
		private bool m_is_ready; // 0x2C

		public Transform Parent { get; private set; } // 0x20

		// RVA: 0x1BADBEC Offset: 0x1BADBEC VA: 0x1BADBEC Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as Setting;
			Parent = setting.m_parent;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_text_00.text = bk.GetMessageByLabel("popup_home_scene_limited_bg_msg_00");
			m_text_01.text = bk.GetMessageByLabel("popup_home_scene_limited_bg_msg_01");
			m_is_ready = false;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_image_00);
			MenuScene.Instance.HomeBgIconTextureCache.Load(m_setting.m_bg_id, (IiconTexture texture) =>
			{
				//0x1BAE154
				texture.Set(m_image_00);
				m_is_ready = true;
			});
		}

		// RVA: 0x1BAE0C8 Offset: 0x1BAE0C8 VA: 0x1BAE0C8 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BAE0D0 Offset: 0x1BAE0D0 VA: 0x1BAE0D0 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1BAE108 Offset: 0x1BAE108 VA: 0x1BAE108 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BAE140 Offset: 0x1BAE140 VA: 0x1BAE140 Slot: 10
		public bool IsReady()
		{
			return m_is_ready;
		}

		// RVA: 0x1BAE148 Offset: 0x1BAE148 VA: 0x1BAE148 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
