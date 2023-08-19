using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupItemDetail : LayoutUGUIScriptBase, IPopupContent
	{
		public class PopupItemDetailSetting : PopupSetting
		{
			public int ItemId { get; set; } // 0x34
			public int SubId { get; set; } // 0x38
			public int Count { get; set; } // 0x3C
			public string OverrideText { get; set; } // 0x40
			public string OverrideName { get; set; } // 0x44
			public bool IsShop { get; set; } // 0x48
			public override bool IsPreload { get { return true; } } //0xAFB298
			public override bool IsAssetBundle { get { return true; } } //0xAFB2A0
			public override string PrefabPath { get { return ""; } } //0xAFB2A8
			public override string BundleName { get { return "ly/061.xab"; } } //0xAFB304
			public override string AssetName { get { return "root_pop_item_detail_layout_root"; } } //0xAFB360
			public override GameObject Content { get { return m_content; } } //0xAFB3BC
		}
		
		[SerializeField]
		private RawImageEx m_itemIconImage; // 0x14
		[SerializeField]
		private Text m_itemNameText; // 0x18
		[SerializeField]
		private Text m_itemDescriptionText; // 0x1C
		[SerializeField]
		private Text m_decoSetCautionText; // 0x20
		private AbsoluteLayout m_layoutRoot; // 0x24
		private AbsoluteLayout m_layoutCautionText; // 0x28

		public Transform Parent { get; private set; } // 0x2C

		// RVA: 0xAFA870 Offset: 0xAFA870 VA: 0xAFA870 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_item_detail") as AbsoluteLayout;
			m_layoutCautionText = layout.FindViewById("swtbl_explanation_txt") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0xAFA9C0 Offset: 0xAFA9C0 VA: 0xAFA9C0 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupItemDetailSetting s = setting as PopupItemDetailSetting;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			Parent = setting.m_parent;
			MenuScene.Instance.ItemTextureCache.Load(s.ItemId, s.SubId, (IiconTexture texture) =>
			{
				//0xAFB180
				texture.Set(m_itemIconImage);
			});
			m_itemNameText.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_itemNameText.verticalOverflow = VerticalWrapMode.Truncate;
			if(string.IsNullOrEmpty(s.OverrideName))
			{
				m_layoutRoot.StartChildrenAnimGoStop("01");
				m_itemNameText.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(s.ItemId);
			}
			else
			{
				if(s.OverrideName.Contains("\n"))
				{
					m_itemNameText.horizontalOverflow = HorizontalWrapMode.Overflow;
					m_itemNameText.verticalOverflow = VerticalWrapMode.Overflow;
					m_layoutRoot.StartChildrenAnimGoStop("02");
				}
				else
				{
					m_layoutRoot.StartChildrenAnimGoStop("01");
				}
				m_itemNameText.text = s.OverrideName;
			}
			if(string.IsNullOrEmpty(s.OverrideText))
			{
				m_itemDescriptionText.text = EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(s.ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(s.ItemId));
			}
			else
			{
				m_itemDescriptionText.text = s.OverrideText;
			}
			if(!s.IsShop)
			{
				m_layoutCautionText.StartChildrenAnimGoStop("01");
			}
			else
			{
				m_decoSetCautionText.text = bk.GetMessageByLabel("deco_set_buy_warn_text");
				m_layoutCautionText.StartChildrenAnimGoStop(EKLNMHFCAOI.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(s.ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(s.ItemId)) == 0 ? "01" : "02");
			}
		}

		// RVA: 0xAFB0F4 Offset: 0xAFB0F4 VA: 0xAFB0F4 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xAFB0FC Offset: 0xAFB0FC VA: 0xAFB0FC Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xAFB134 Offset: 0xAFB134 VA: 0xAFB134 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xAFB16C Offset: 0xAFB16C VA: 0xAFB16C Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xAFB174 Offset: 0xAFB174 VA: 0xAFB174 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
