using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidApHealWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		private class Content
		{
			public RawImageEx Image; // 0x8
			public NumberBase Num; // 0xC
			public Text Text1; // 0x10
			public Text Text2; // 0x14
			public Text Text3; // 0x18
			public ActionButton Button; // 0x1C
			public ActionButton ItemIcon; // 0x20

			// // RVA: 0x1459E34 Offset: 0x1459E34 VA: 0x1459E34
			// public void PasteStart(Transform parent) { }
		}

		[SerializeField]
		private Text m_infoText; // 0x14
		[SerializeField]
		private Content[] m_contents = new Content[4]; // 0x18
		private Action m_popupCloseEvent; // 0x1C
		private Action<Action, CIOECGOMILE.LIILJGHKIDL> m_onPushPaidButton; // 0x20
		private Action<Action> m_onPushApItemLButton; // 0x24
		private Action<Action> m_onPushApItemSButton; // 0x28

		// RVA: 0x1457CC8 Offset: 0x1457CC8 VA: 0x1457CC8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// RVA: 0x1457CE0 Offset: 0x1457CE0 VA: 0x1457CE0
		public void Initialize(Action<Action, CIOECGOMILE.LIILJGHKIDL> onPushPaidButton, Action<Action> onPushApItemLButton, Action<Action> onPushApItemSButton, Action popupCloseEvent)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popupCloseEvent = popupCloseEvent;
			IFBCGCCJBHI data = new IFBCGCCJBHI();
			data.KHEKNNFCAOI();
			data.FBANBDCOEJL();
			MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), (IiconTexture texture) =>
			{
				//0x145989C
				texture.Set(m_contents[0].Image);
				texture.Set(m_contents[1].Image);
			});
			MenuScene.Instance.ItemTextureCache.Load(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealS), (IiconTexture texture) =>
			{
				//0x1459A94
				texture.Set(m_contents[2].Image);
			});
			MenuScene.Instance.ItemTextureCache.Load(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealL), (IiconTexture texture) =>
			{
				//0x1459BB8
				texture.Set(m_contents[3].Image);
			});
			m_infoText.text = bk.GetMessageByLabel("pop_raid_ap_heal_text");
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			m_contents[0].Text1.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item01_text01"), CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[1]);
			m_contents[0].Text2.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item01_text02"), ev.COEIAHBIFBN(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 0), CIOECGOMILE.LIILJGHKIDL.HLAJMFGDAHP_1));
			m_contents[0].Text3.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item01_text03"), data.FNCPAEFEECO_CurrencyPaid);
			m_contents[1].Text1.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item01_text01"), CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[2]);
			m_contents[1].Text2.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item01_text02"), ev.COEIAHBIFBN(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 0), CIOECGOMILE.LIILJGHKIDL.FPNFLAAECMK_2));
			m_contents[1].Text3.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item01_text03"), data.FNCPAEFEECO_CurrencyPaid);
			m_contents[2].Text1.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item02_text01"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealS)));
			m_contents[2].Text2.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item02_text02"), ev.COEIAHBIFBN(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealS), CIOECGOMILE.LIILJGHKIDL.HLAJMFGDAHP_1));
			int numAp1 = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem, 2, null);
			m_contents[2].Text3.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item02_text03"), numAp1);
			m_contents[3].Text1.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item02_text01"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealL)));
			m_contents[3].Text2.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item02_text02"), ev.COEIAHBIFBN(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealL), CIOECGOMILE.LIILJGHKIDL.FPNFLAAECMK_2));
			int numAp2 = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem, 3, null);
			m_contents[3].Text3.text = string.Format(bk.GetMessageByLabel("pop_raid_ap_heal_item02_text03"), numAp2);
			m_contents[0].Num.SetNumber(CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[1], 0);
			m_contents[1].Num.SetNumber(CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[2], 0);
			m_contents[2].Num.SetNumber(1, 0);
			m_contents[3].Num.SetNumber(1, 0);
			m_onPushPaidButton = onPushPaidButton;
			m_onPushApItemLButton = onPushApItemLButton;
			m_onPushApItemSButton = onPushApItemSButton;
			m_contents[0].Button.AddOnClickCallback(OnPushPaidSButton);
			m_contents[1].Button.AddOnClickCallback(OnPushPaidLButton);
			m_contents[2].Button.AddOnClickCallback(OnPushApItemSButton);
			m_contents[3].Button.AddOnClickCallback(OnPushApItemLButton);
			m_contents[0].ItemIcon.AddOnClickCallback(() =>
			{
				//0x1459CDC
				OnPushItemIcon(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1));
			});
			m_contents[1].ItemIcon.AddOnClickCallback(() =>
			{
				//0x1459D68
				OnPushItemIcon(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1));
			});
			m_contents[2].ItemIcon.AddOnClickCallback(() =>
			{
				//0x1459DF4
				OnPushItemIcon(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealS));
			});
			m_contents[3].ItemIcon.AddOnClickCallback(() =>
			{
				//0x1459E14
				OnPushItemIcon(RaidItemConstants.MakeItemId(RaidItemConstants.Type.ApHealL));
			});
			m_contents[2].Button.Disable = numAp1 < 1;
			m_contents[3].Button.Disable = numAp2 < 1;
		}

		// // RVA: 0x14595A8 Offset: 0x14595A8 VA: 0x14595A8
		private void OnPushPaidSButton()
		{
			if(m_onPushPaidButton != null)
				m_onPushPaidButton(m_popupCloseEvent, CIOECGOMILE.LIILJGHKIDL.HLAJMFGDAHP_1);
		}

		// // RVA: 0x145961C Offset: 0x145961C VA: 0x145961C
		private void OnPushPaidLButton()
		{
			if(m_onPushPaidButton != null)
				m_onPushPaidButton(m_popupCloseEvent, CIOECGOMILE.LIILJGHKIDL.FPNFLAAECMK_2);
		}

		// // RVA: 0x1459690 Offset: 0x1459690 VA: 0x1459690
		private void OnPushApItemLButton()
		{
			if(m_onPushApItemLButton != null)
				m_onPushApItemLButton(m_popupCloseEvent);
		}

		// // RVA: 0x1459700 Offset: 0x1459700 VA: 0x1459700
		private void OnPushApItemSButton()
		{
			if(m_onPushApItemSButton != null)
				m_onPushApItemSButton(m_popupCloseEvent);
		}

		// // RVA: 0x1459770 Offset: 0x1459770 VA: 0x1459770
		private void OnPushItemIcon(int itemId)
		{
			MenuScene.Instance.ShowItemDetail(itemId, 0, null);
		}
	}
}
