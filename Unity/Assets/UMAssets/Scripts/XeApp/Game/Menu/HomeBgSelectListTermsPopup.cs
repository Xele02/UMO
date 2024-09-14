using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeBgSelectListTermsPopup : MonoBehaviour, IPopupContent
	{
		public class Setting : PopupSetting
		{
			public int m_bg_id { get; set; } // 0x34
			public string m_text { get; set; } // 0x38
			public override bool IsPreload { get { return false; } } //0x95C970
			public override bool IsAssetBundle { get { return true; } } //0x95C978
			public override string PrefabPath { get { return ""; } } //0x95C980
			public override string BundleName { get { return "ly/226.xab"; } } //0x95C9DC
			public override string AssetName { get { return "SelectBgListTermPopup"; } } //0x95CA38
			public override GameObject Content { get { return m_content; } } //0x95CA94
		}

		public Text m_text; // 0xC
		public RawImageEx m_image; // 0x10
		private Setting m_setting; // 0x18
		private int m_diva_id; // 0x1C
		private int m_costume_model_id; // 0x20
		private int m_costume_color; // 0x24
		private bool isReady; // 0x28

		public Transform Parent { get; private set; }

		// RVA: 0x95C49C Offset: 0x95C49C VA: 0x95C49C Slot: 4
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			isReady = false;
			m_setting = setting as Setting;
			Parent = setting.m_parent;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			m_text.text = m_setting.m_text;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_image);
			int bg_id = CGFNKMNBNBN.ELKDCEEPLKB(m_setting.m_bg_id).KEFGPJBKAOD_BgId;
			MenuScene.Instance.HomeBgIconTextureCache.Load(bg_id, (IiconTexture texture) =>
			{
				//0x95C890
				texture.Set(m_image);
			});
		}

		// RVA: 0x95C804 Offset: 0x95C804 VA: 0x95C804 Slot: 5
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x95C80C Offset: 0x95C80C VA: 0x95C80C Slot: 6
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x95C844 Offset: 0x95C844 VA: 0x95C844 Slot: 7
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x95C87C Offset: 0x95C87C VA: 0x95C87C Slot: 8
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x95C884 Offset: 0x95C884 VA: 0x95C884 Slot: 9
		public void CallOpenEnd()
		{
			return;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6E54F4 Offset: 0x6E54F4 VA: 0x6E54F4
		// // RVA: 0x95C890 Offset: 0x95C890 VA: 0x95C890
		// private void <Initialize>b__11_0(IiconTexture texture) { }
	}
}
