using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicGradeRewardListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textGrade; // 0x18
		[SerializeField]
		private Text m_textName; // 0x1C
		[SerializeField]
		private Text m_textNum; // 0x20
		[SerializeField]
		private RawImageEx m_imageGrade; // 0x24
		[SerializeField]
		private RawImageEx m_imageItem; // 0x28
		[SerializeField]
		private RawImageEx m_imageStamp; // 0x2C
		[SerializeField]
		private RawImageEx[] m_imageFrame; // 0x30
		[SerializeField]
		private ActionButton m_button; // 0x34
		private AbsoluteLayout m_layoutGradeIcon; // 0x38
		private TexUVListManager m_uvMan; // 0x3C
		private int m_itemId; // 0x40
		private int m_itemNum; // 0x44
		public Action<int, int> OnClickButton; // 0x48
		private HighScoreRatingRank.Type m_gradeId; // 0x4C

		//// RVA: 0x1734798 Offset: 0x1734798 VA: 0x1734798
		//public bool IsIconLoaded() { }

		//// RVA: 0x17347E0 Offset: 0x17347E0 VA: 0x17347E0
		public void SetStatus(LayoutMusicRateList.FlexibleListItem_Reward data)
		{
			m_itemId = data.Item.JJBGOIMEIPF_ItemId;
			m_itemNum = data.Item.MBJIFDBEDAC_Cnt;
			m_layoutGradeIcon.StartChildrenAnimGoStop(data.Index == 0 ? "01" : "02");
			m_textGrade.text = data.MusicGradeName;
			SetGradeImage(data.MusicGrade);
			SetItemImage(m_itemId);
			m_imageStamp.enabled = data.Get;
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_itemId);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem)
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_textName, string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_emblemtitle"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(m_itemId)), 1, JpStringLiterals.StringLiteral_12038);
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_textName, string.Format(bk.GetMessageByLabel("popup_event_reward_platetitle"), EKLNMHFCAOI.APDHLDGBENB(m_itemId), EKLNMHFCAOI.INCKKODFJAP_GetItemName(m_itemId)), 1, JpStringLiterals.StringLiteral_12038);
			}
			else
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_textName, EKLNMHFCAOI.INCKKODFJAP_GetItemName(m_itemId), 1, JpStringLiterals.StringLiteral_12038);
			}
			m_textNum.text = m_itemNum.ToString() + EKLNMHFCAOI.NDBLEADIDLA(cat, EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_itemId));
			SetFrameUv(data.Pickup ? "pop_reward_ev_frg2_{0:D2}" : "pop_reward_ev_fr_{0:D2}");
		}

		//// RVA: 0x1734D98 Offset: 0x1734D98 VA: 0x1734D98
		private void SetGradeImage(HighScoreRatingRank.Type gradeId)
		{
			m_gradeId = gradeId;
			m_imageGrade.enabled = false;
			GameManager.Instance.MusicRatioTextureCache.Load(gradeId, (IiconTexture texture) =>
			{
				//0x17354AC
				if(m_gradeId == gradeId)
				{
					MusicRatioTextureCache.MusicRatioTexture t = texture as MusicRatioTextureCache.MusicRatioTexture;
					if(t != null)
					{
						m_imageGrade.enabled = true;
						t.Set(m_imageGrade, m_gradeId);
					}
				}
			});
		}

		//// RVA: 0x1734F48 Offset: 0x1734F48 VA: 0x1734F48
		private void SetItemImage(int itemId)
		{
			m_imageItem.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0x17355FC
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

		//// RVA: 0x17350CC Offset: 0x17350CC VA: 0x17350CC
		private void SetFrameUv(string uvFormat)
		{
			m_imageFrame[0].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(uvFormat, 2)));
			m_imageFrame[1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(uvFormat, 3)));
		}

		// RVA: 0x17352F4 Offset: 0x17352F4 VA: 0x17352F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutGradeIcon = layout.FindViewById("sw_pop_reward_ev_item_pt") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x1735438
				if (OnClickButton != null)
					OnClickButton(m_itemId, m_itemNum);
			});
			Loaded();
			return true;
		}
	}
}
