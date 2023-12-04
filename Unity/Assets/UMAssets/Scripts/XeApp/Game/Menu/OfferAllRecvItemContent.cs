using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvItemContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_itemImage; // 0x20
		[SerializeField]
		private Text m_itemCountText; // 0x24
		[SerializeField]
		private RawImageEx[] m_itemFrame = new RawImageEx[3]; // 0x28
		private RawImageEx m_rareTitle; // 0x2C
		[SerializeField]
		private ActionButton m_ItemDetailsButton; // 0x30
		private AbsoluteLayout rootLayout; // 0x34
		private TexUVList m_texUvList; // 0x38

		// RVA: 0x151FB00 Offset: 0x151FB00 VA: 0x151FB00
		public void Setup(ViewOfferGetItem getItem)
		{
			m_itemCountText.text = string.Format(JpStringLiterals.StringLiteral_14007, getItem.itemNum);
			GameManager.Instance.ItemTextureCache.Load(getItem.itemId, (IiconTexture tex) =>
			{
				//0x1520678
				tex.Set(m_itemImage);
			});
			switch(getItem.itemType)
			{
				case ViewOfferGetItem.ItemType.CONFIRM:
					rootLayout.StartAllAnimGoStop("03");
					m_rareTitle.enabled = true;
					break;
				case ViewOfferGetItem.ItemType.GREATERARE:
					rootLayout.StartAllAnimGoStop("02");
					m_rareTitle.enabled = true;
					break;
				case ViewOfferGetItem.ItemType.RARE:
					rootLayout.StartAllAnimGoStop("02");
					m_rareTitle.enabled = false;
					break;
				case ViewOfferGetItem.ItemType.NOMAL:
					rootLayout.StartAllAnimGoStop("04");
					m_rareTitle.enabled = true;
					break;
				case ViewOfferGetItem.ItemType.NUM:
					rootLayout.StartAllAnimGoStop("01");
					m_rareTitle.enabled = true;
					break;
			}
			int rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(getItem.itemId);
			for(int i = 0; i < m_itemFrame.Length; i++)
			{
				m_itemFrame[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(string.Format("s_v_frm_item_s{0}_{1:d2}", rarity, i + 1)));
			}
			m_ItemDetailsButton.ClearOnClickCallback();
			m_ItemDetailsButton.AddOnClickCallback(() =>
			{
				//0x152076C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(!IsSceneCardItem(getItem.itemId))
				{
					MenuScene.Instance.ShowItemDetail(getItem.itemId, getItem.itemNum, null);
				}
				else
				{
					ShowSceneCardItem(getItem.itemId);
				}
			});
		}

		// // RVA: 0x15200B0 Offset: 0x15200B0 VA: 0x15200B0
		private void ShowSceneCardItem(int itemId)
		{
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(itemId - 40000, null, null, 0, 0, 0, false, 0, 0);
			MenuScene.Instance.ShowSceneStatusPopupWindow(scene, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, SceneStatusParam.PageSave.None, false);
		}

		// // RVA: 0x152024C Offset: 0x152024C VA: 0x152024C
		public bool IsSceneCardItem(int itemId)
		{
			return EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
		}

		// RVA: 0x15202E0 Offset: 0x15202E0 VA: 0x15202E0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			rootLayout = layout.Root;
			List<RawImageEx> imgs = new List<RawImageEx>(GetComponentsInChildren<RawImageEx>(true));
			m_rareTitle = imgs.Where((RawImageEx _) =>
			{
				//0x15205F8
				return _.name == "s_v_icon_pfct (ImageView)";
			}).First();
			m_texUvList = uvMan.GetTexUVList("sel_vfo_pack");
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
