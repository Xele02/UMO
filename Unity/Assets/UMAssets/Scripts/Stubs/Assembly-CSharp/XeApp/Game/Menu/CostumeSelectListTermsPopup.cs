using XeSys.Gfx;
using UnityEngine.UI;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class CostumeSelectListTermsPopup : LayoutUGUIScriptBase, IPopupContent
	{
		public enum Type
		{
			CostumeBase = 0,
			CostumeColorChange = 1,
		}

		public class Setting : PopupSetting
		{
			public Type m_type { get; set; } // 0x34
			public int m_diva_id { get; set; } // 0x38
			public int m_costume_model_id { get; set; } // 0x3C
			public int m_costume_color { get; set; } // 0x40
			public string m_text { get; set; } // 0x44
			public override bool IsPreload { get { return false; } } //0x164610C
			public override bool IsAssetBundle { get { return true; } } //0x1646114
			public override string PrefabPath { get { return ""; } } //0x164611C
			public override string BundleName { get { return "ly/044.xab"; } } //0x1646178
			public override string AssetName { get { return "root_sel_terms_window_01_layout_root"; } } //0x16461D4
			public override GameObject Content { get { return m_content; } } //0x1646230
		}
		
		public Text m_text; // 0x14
		public RawImageEx m_image_diva_cos; // 0x18
		public RawImageEx m_image_ul_cos_plate; // 0x1C
		private Setting m_setting; // 0x24
		private int m_diva_id; // 0x28
		private int m_costume_model_id; // 0x2C
		private int m_costume_color; // 0x30

		public Transform Parent { get; private set; } // 0x20

		// RVA: 0x16456A0 Offset: 0x16456A0 VA: 0x16456A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_image_diva_cos = Array.Find(GetComponentsInChildren<RawImageEx>(true), (RawImageEx _) =>
			{
				//0x1645E0C
				return _.name.Contains("swtexf_cmn_diva_cos");
			});
			m_text = Array.Find(GetComponentsInChildren<Text>(true), (Text _) =>
			{
				//0x1645EA4
				return _.name.Contains("release_01");
			});
			Loaded();
			return true;
		}

		// RVA: 0x1645964 Offset: 0x1645964 VA: 0x1645964 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as Setting;
			Parent = setting.m_parent;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			m_text.text = m_setting.m_text;
			int t_diva_id = m_setting.m_diva_id;
			int t_costume_model_id = m_setting.m_costume_model_id;
			int t_costume_color = m_setting.m_costume_color;
			GameManager.Instance.CostumeIconCache.Load(t_diva_id, t_costume_model_id, t_costume_color, (IiconTexture icon) =>
			{
				//0x1645F3C
				if(t_diva_id == m_setting.m_diva_id && t_costume_model_id == m_setting.m_costume_model_id && t_costume_color == m_setting.m_costume_color)
				{
					icon.Set(m_image_diva_cos);
				}
			});
		}

		// RVA: 0x1645D04 Offset: 0x1645D04 VA: 0x1645D04 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1645D0C Offset: 0x1645D0C VA: 0x1645D0C Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1645D44 Offset: 0x1645D44 VA: 0x1645D44 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1645D7C Offset: 0x1645D7C VA: 0x1645D7C Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1645D84 Offset: 0x1645D84 VA: 0x1645D84 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
