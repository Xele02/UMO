using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System;
using XeSys;
using UnityEngine.Localization.SmartFormat;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardContents : SwapScrollListContent
	{
		[SerializeField]
		private Text BingoCountText; // 0x20
		[SerializeField]
		private Text ItemNameText; // 0x24
		[SerializeField]
		private Text ItemCountText; // 0x28
		[SerializeField]
		private RawImageEx ItemIcon; // 0x2C
		[SerializeField]
		private ActionButton m_button; // 0x30
		[SerializeField]
		private RawImageEx Fr03; // 0x34
		[SerializeField]
		private RawImageEx Fr02; // 0x38
		private bool m_isLoadedTexture; // 0x3C
		private TexUVList m_texUvList; // 0x40
		private AbsoluteLayout BingoCountLayout; // 0x44
		private AbsoluteLayout ClearIconLayout; // 0x48

		//public bool IsLoadedTexture { get; private set; } 0x14C6848 0x14C6850

		// RVA: 0x14C6858 Offset: 0x14C6858 VA: 0x14C6858
		private void Start()
		{
			return;
		}

		// RVA: 0x14C685C Offset: 0x14C685C VA: 0x14C685C
		private void Update()
		{
			return;
		}

		// RVA: 0x14C6860 Offset: 0x14C6860 VA: 0x14C6860
		public void SetUp(JJPEIELNEJB.JLHHGLANHGE _itemInfo, Action IconLodedAct, Action<int> OnClickAct)
		{
			SetImage(_itemInfo.GLCLFMGPMAN_ItemFullId, (int idx) =>
			{
				//0x14C7494
				IconLodedAct();
			});
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str;
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_itemInfo.GLCLFMGPMAN_ItemFullId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				str = string.Format(bk.GetMessageByLabel("popup_event_reward_platetitle"), EKLNMHFCAOI.APDHLDGBENB(_itemInfo.GLCLFMGPMAN_ItemFullId), _itemInfo.HAAJGNCFNJM_ItemName);
			}
			else
			{
				str = _itemInfo.HAAJGNCFNJM_ItemName;
			}
			SetText(Smart.Format(bk.GetMessageByLabel("bingo_reward_count_text"), Index + 1), str, _itemInfo.LJKMKCOAICL_ItemCount.ToString() + EKLNMHFCAOI.NDBLEADIDLA(_itemInfo.MJBKGOJBPAD_ItemCat, 0));
			SetSpItem(_itemInfo.MPKBLMCNHOM);
			SetActtionButton(() =>
			{
				//0x14C74C0
				OnClickAct(Index);
			});
		}

		//// RVA: 0x14C7164 Offset: 0x14C7164 VA: 0x14C7164
		public void SetActtionButton(Action act)
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x14C7560
				act();
			});
		}

		//// RVA: 0x14C6E3C Offset: 0x14C6E3C VA: 0x14C6E3C
		public void SetText(string _bingoCount, string _itemName, string _itemCount)
		{
			BingoCountText.text = _bingoCount;
			ItemNameText.text = _itemName;
			ItemCountText.text = _itemCount;
		}

		//// RVA: 0x14C6CC8 Offset: 0x14C6CC8 VA: 0x14C6CC8
		public void SetImage(int itemId, Action<int> LoadedAct)
		{
			m_isLoadedTexture = false;
			GameManager.Instance.ItemTextureCache.Load(ItemTextureCache.MakeItemIconTexturePath(itemId, 0), (IiconTexture icon) =>
			{
				//0x14C758C
				icon.Set(ItemIcon);
				LoadedAct(Index);
			});
		}

		//// RVA: 0x14C6EDC Offset: 0x14C6EDC VA: 0x14C6EDC
		public void SetSpItem(bool IsSP)
		{
			if(IsSP)
			{
				BingoCountLayout.StartChildrenAnimGoStop("02");
				Fr03.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData("pop_reward_ev_frg2_03"));
				Fr02.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData("pop_reward_ev_frg2_02"));
			}
			else
			{
				BingoCountLayout.StartChildrenAnimGoStop("01");
				Fr03.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData("pop_reward_ev_fr_03"));
				Fr02.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData("pop_reward_ev_fr_02"));
			}
		}

		// RVA: 0x14C7274 Offset: 0x14C7274 VA: 0x14C7274
		public void ClearIconEnable(bool IsEnable)
		{
			ClearIconLayout.StartChildrenAnimGoStop(IsEnable ? "01" : "02");
		}

		// RVA: 0x14C7308 Offset: 0x14C7308 VA: 0x14C7308 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList = uvMan.GetTexUVList("pop_bingo_pack");
			BingoCountLayout = layout.FindViewByExId("sw_pop_bingo_rwd_btn_anim_swtbl_bingo_fnt") as AbsoluteLayout;
			ClearIconLayout = layout.FindViewByExId("sw_pop_reward_ev_item_point_sw_get_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
