using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvItemLayout : FlexibleListItemLayout
	{
		private RawImageEx m_ItemImage; // 0x18
		private RawImageEx m_GetIconImage; // 0x1C
		private RawImageEx[] m_goldFrame; // 0x20
		private StayButton m_button; // 0x24
		private Text m_ItemNameText; // 0x28
		private Text m_ItemCountText; // 0x2C
		private Text m_RequiredPointText; // 0x30
		private Rect[] m_uvData; // 0x34
		private int m_iconId; // 0x38

		// RVA: 0x1A741DC Offset: 0x1A741DC VA: 0x1A741DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime r = GetComponent<LayoutUGUIRuntime>();
			RawImageEx[] imgs = r.GetComponentsInChildren<RawImageEx>();
			m_ItemImage = imgs.Where((RawImageEx _) =>
			{
				//0x1A74EC8
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			m_GetIconImage = imgs.Where((RawImageEx _) =>
			{
				//0x1A74F48
				return _.name == "pop_reward_ev_get (ImageView)";
			}).First();
			m_goldFrame = imgs.Where((RawImageEx _) =>
			{
				//0x1A74FC8
				return _.name.Contains("pop_reward_ev_fr_0");
			}).ToArray();
			Text[] txts = r.GetComponentsInChildren<Text>();
			m_ItemNameText = txts.Where((Text _) =>
			{
				//0x1A75060
				return _.name == "item_name (TextView)";
			}).First();
			m_ItemCountText = txts.Where((Text _) =>
			{
				//0x1A750E0
				return _.name == "item_num (TextView)";
			}).First();
			m_RequiredPointText = txts.Where((Text _) =>
			{
				//0x1A75160
				return _.name == "required_pt (TextView)";
			}).FirstOrDefault();
			m_ItemNameText.resizeTextForBestFit = true;
			m_ItemNameText.resizeTextMaxSize = 22;
			m_ItemNameText.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_ItemNameText.verticalOverflow = VerticalWrapMode.Truncate;
			m_button = r.GetComponentInChildren<StayButton>();
			string[] strs = new string[4]
			{
				"pop_reward_ev_fr_02", "pop_reward_ev_fr_03", 
				"pop_reward_ev_frg2_02", "pop_reward_ev_frg2_03"
			};
			m_uvData = new Rect[4];
			for(int i = 0; i < strs.Length; i++)
			{
				m_uvData[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(strs[i]));
			}
			Loaded();
			return true;
		}

		// RVA: 0x1A68DB0 Offset: 0x1A68DB0 VA: 0x1A68DB0
		public void SetItemData(MFDJIFIIPJD info, bool isGet, bool isGoldFrame)
		{
			m_iconId = info.JJBGOIMEIPF_ItemId;
			int iconId = m_iconId;
			m_ItemImage.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(m_iconId, (IiconTexture texture) =>
			{
				//0x1A751E0
				if(m_iconId != iconId)
					return;
				texture.Set(m_ItemImage);
				m_ItemImage.enabled = true;
			});
			if(info.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_ItemNameText, string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_platetitle"), EKLNMHFCAOI.APDHLDGBENB(info.JJBGOIMEIPF_ItemId), EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId)), 1, JpStringLiterals.StringLiteral_12038);
			}
			else if(info.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem)
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_ItemNameText, string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_emblemtitle"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId)), 1, JpStringLiterals.StringLiteral_12038);
			}
			else if(info.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_ItemNameText, string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_sns_itemtitle"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId)), 1, JpStringLiterals.StringLiteral_12038);
			}
			else
			{
				TextGeneratorUtility.SetTextRectangleMessage(m_ItemNameText, EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId), 1, JpStringLiterals.StringLiteral_12038);
			}
			string str = EKLNMHFCAOI.NDBLEADIDLA(info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId);
			string str2 = "";
			if(!string.IsNullOrEmpty(str))
			{
				str2 = info.MBJIFDBEDAC_Cnt.ToString() + str;
			}
			m_ItemCountText.text = str2;
			m_GetIconImage.enabled = isGet;
			SetFrame(isGoldFrame ? 1 : 0);
		}

		// RVA: 0x1A69450 Offset: 0x1A69450 VA: 0x1A69450
		public void SetRequiredPoint(int point)
		{
			if(m_RequiredPointText != null)
			{
				m_RequiredPointText.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_needpoint_unit"), point);
			}
		}

		// RVA: 0x1A695A4 Offset: 0x1A695A4 VA: 0x1A695A4
		public void SetButtonEvent(Action action)
		{
			m_button.ClearOnClickCallback();
			m_button.ClearOnStayCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x1A75330
				action();
			});
			m_button.AddOnStayCallback(() =>
			{
				//0x1A7535C
				action();
			});
		}

		// // RVA: 0x1A74D2C Offset: 0x1A74D2C VA: 0x1A74D2C
		private void SetFrame(int kind)
		{
			for(int i = 0; i < m_goldFrame.Length; i++)
			{
				m_goldFrame[i].uvRect = m_uvData[kind * m_goldFrame.Length + i];
			}
		}
	}
}
