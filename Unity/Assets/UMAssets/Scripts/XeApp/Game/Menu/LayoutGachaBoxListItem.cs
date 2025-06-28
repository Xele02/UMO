using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxListItem : LayoutGachaBoxListElemBase
	{
		[SerializeField]
		private Text m_textRemain; // 0x20
		[SerializeField]
		private Text m_textName; // 0x24
		[SerializeField]
		private Text m_textNum; // 0x28
		[SerializeField]
		private RawImageEx m_imageItem; // 0x2C
		[SerializeField]
		private RawImageEx m_imageStamp; // 0x30
		[SerializeField]
		private RawImageEx[] m_imageFrame; // 0x34
		[SerializeField]
		private ActionButton m_button; // 0x38
		private HGFPAFPGIKG.CMEDMHFOFAH m_data; // 0x3C
		private TexUVListManager m_uvMan; // 0x40
		private int m_itemId; // 0x44

		protected override ButtonBase selectButton { get { return m_button; } } //0x19A408C
		public HGFPAFPGIKG.CMEDMHFOFAH data { get { return m_data; } } //0x19A4094

		// RVA: 0x19A409C Offset: 0x19A409C VA: 0x19A409C
		public bool IsIconLoaded()
		{
			return m_imageItem.enabled && IsLoaded();
		}

		// RVA: 0x19A40E4 Offset: 0x19A40E4 VA: 0x19A40E4
		public void SetStatus(HGFPAFPGIKG.CMEDMHFOFAH data, bool hidePickup)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data.GLCLFMGPMAN_ItemId);
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(data.GLCLFMGPMAN_ItemId);
            m_data = data;
			m_textRemain.text = data.NNCCGILOOIE + "/" + data.BFGKGMOLAFL_MaxPlate;
			SetItemImage(data.GLCLFMGPMAN_ItemId);
			m_imageStamp.enabled = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(hidePickup)
			{
				m_textName.text = bk.GetMessageByLabel("event_gacha_box_medama_plate_name");
			}
			else
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem)
				{
					TextGeneratorUtility.SetTextRectangleMessage(m_textName, string.Format(bk.GetMessageByLabel("popup_event_reward_emblemtitle"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GLCLFMGPMAN_ItemId)), 1, JpStringLiterals.StringLiteral_12038);
				}
				else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					TextGeneratorUtility.SetTextRectangleMessage(m_textName, string.Format(bk.GetMessageByLabel("popup_event_reward_platetitle"), EKLNMHFCAOI.APDHLDGBENB(data.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GLCLFMGPMAN_ItemId)), 1, JpStringLiterals.StringLiteral_12038);
				}
				else
				{
					TextGeneratorUtility.SetTextRectangleMessage(m_textName, EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GLCLFMGPMAN_ItemId), 1, JpStringLiterals.StringLiteral_12038);
				}
			}
			m_textNum.text = data.LJKMKCOAICL.ToString() + EKLNMHFCAOI.NDBLEADIDLA(cat, id);
			SetFrameUv(data.JOPPFEHKNFO_IsPickup ? "pop_reward_ev_frg2_{0:D2}" : "pop_reward_ev_fr_{0:D2}");
		}

		// // RVA: 0x19A4618 Offset: 0x19A4618 VA: 0x19A4618
		private void SetItemImage(int itemId)
		{
			m_itemId = itemId;
			m_imageItem.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0x19A4A0C
				if(m_imageItem != null)
				{
					if(m_itemId == itemId)
					{
						m_imageItem.enabled = true;
						icon.Set(m_imageItem);
					}
				}
			});
		}

		// // RVA: 0x19A47C8 Offset: 0x19A47C8 VA: 0x19A47C8
		private void SetFrameUv(string uvFormat)
		{
			m_imageFrame[0].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(uvFormat, 2)));
			m_imageFrame[1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(uvFormat, 3)));
		}

		// RVA: 0x19A49E8 Offset: 0x19A49E8 VA: 0x19A49E8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			Loaded();
			return true;
		}
	}
}
