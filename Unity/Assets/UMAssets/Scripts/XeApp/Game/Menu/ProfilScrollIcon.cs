using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ProfilScrollIcon : SwapScrollListContent
	{
		public delegate void onClickIconVal(PNGOLKLFFLH a_data);
		public delegate void onClickIconCos(CKFGMNAIBNG a_data, int color);
		public delegate void onClickIconEmblem(IAPDFOPPGND a_data);

		[SerializeField]
		private RawImageEx m_image_icon; // 0x20
		[SerializeField]
		private ActionButton m_button; // 0x24
		private int m_item_id; // 0x28
		private PNGOLKLFFLH m_view_data_val; // 0x2C
		private CKFGMNAIBNG m_view_data_cos; // 0x30
		private IAPDFOPPGND m_view_data_emblem; // 0x34
		private int m_color; // 0x38
		private onClickIconVal m_cb_click_val; // 0x3C
		private onClickIconCos m_cb_click_cos; // 0x40
		private onClickIconEmblem m_cb_click_emblem; // 0x44

		// RVA: 0x9D1ED4 Offset: 0x9D1ED4 VA: 0x9D1ED4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_button.AddOnClickCallback(CallbackClickButton);
			return true;
		}

		//// RVA: 0x9D1F80 Offset: 0x9D1F80 VA: 0x9D1F80
		public void SetCostumeIcon(CKFGMNAIBNG a_data, int a_color)
		{
			m_item_id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, a_data.JPIDIENBGKH_CostumeId);
			int t_itemId = m_item_id;
			m_color = a_color;
			m_view_data_cos = a_data;
			m_image_icon.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(m_item_id, a_color, (IiconTexture icon) =>
			{
				//0x9D3EE0
				if (m_item_id != t_itemId)
					return;
				icon.Set(m_image_icon);
				m_image_icon.enabled = true;
			});
		}

		//// RVA: 0x9D2174 Offset: 0x9D2174 VA: 0x9D2174
		public void SetVarkiryIcon(PNGOLKLFFLH a_data)
		{
			m_item_id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie, a_data.GPPEFLKGGGJ_ValkyrieId);
			int t_item_id = m_item_id;
			m_view_data_val = a_data;
			m_image_icon.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(m_item_id, (IiconTexture icon) =>
			{
				//0x9D4030
				if (m_item_id != t_item_id)
					return;
				icon.Set(m_image_icon);
				m_image_icon.enabled = true;
			});
		}

		//// RVA: 0x9D2344 Offset: 0x9D2344 VA: 0x9D2344
		public void SetEmblemIcon(IAPDFOPPGND a_data)
		{
			m_item_id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, a_data.MDPKLNFFDBO_EmblemId);
			int t_item_id = m_item_id;
			m_view_data_emblem = a_data;
			m_image_icon.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(t_item_id, (IiconTexture icon) =>
			{
				//0x9D4180
				if (m_item_id != t_item_id)
					return;
				icon.Set(m_image_icon);
				m_image_icon.enabled = true;
			});
		}

		//// RVA: 0x9CD984 Offset: 0x9CD984 VA: 0x9CD984
		public void SetCallbackClickIconVal(onClickIconVal a_cb)
		{
			m_cb_click_val = a_cb;
		}

		//// RVA: 0x9CD968 Offset: 0x9CD968 VA: 0x9CD968
		public void SetCallbackClickIconCos(onClickIconCos a_cb)
		{
			m_cb_click_cos = a_cb;
		}

		//// RVA: 0x9CD9A0 Offset: 0x9CD9A0 VA: 0x9CD9A0
		public void SetCallbackClickIconEmblem(onClickIconEmblem a_cb)
		{
			m_cb_click_emblem = a_cb;
		}

		//// RVA: 0x9D2514 Offset: 0x9D2514 VA: 0x9D2514
		private void CallbackClickButton()
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_item_id);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem)
			{
				if (m_cb_click_emblem != null)
					m_cb_click_emblem(m_view_data_emblem);
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				if (m_cb_click_val != null)
					m_cb_click_val(m_view_data_val);
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				if (m_cb_click_cos != null)
					m_cb_click_cos(m_view_data_cos, m_color);
			}
		}
	}
}
