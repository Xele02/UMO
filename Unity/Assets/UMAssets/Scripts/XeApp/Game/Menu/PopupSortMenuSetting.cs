
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupSortMenuSetting : PopupSetting
	{
		public PopupSortMenu.SortPlace SortPlace { get; private set; } // 0x34
		public SortItem SortItem { get; private set; } // 0x38
		public AssistItem AssistItem { get; private set; } // 0x3C
		public uint RarityFilter { get; private set; } // 0x40
		public uint AttributeFilter { get; private set; } // 0x44
		public uint SeriaseFilter { get; private set; } // 0x48
		public uint CompatibleFilter { get; private set; } // 0x4C
		public uint CenterSkillFilter { get; private set; } // 0x50
		public uint InteriorFilter { get; private set; } // 0x54
		public bool IsCompatibleDiva { get; private set; } // 0x58
		public int SelectedDivaId { get; set; } // 0x5C
		public int SelectedAttrId { get; set; } // 0x60
		public override string PrefabPath { get { return ""; } } //0x11516D8
		public override string BundleName { get { return "ly/035.xab"; } } //0x1151734
		public override string AssetName { get { return "root_deck_sort_layout_root"; } } //0x1151790
		public override bool IsPreload { get { return true; } } //0x11517EC
		public override bool IsAssetBundle { get { return true; } } //0x11517F4
		public override GameObject Content { get { return m_content; } } //0x11517FC

		//// RVA: 0x1150FC4 Offset: 0x1150FC4 VA: 0x1150FC4
		public void Initialize()
		{
			WindowSize = SizeType.Large;
			Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
		}

		//// RVA: 0x1151114 Offset: 0x1151114 VA: 0x1151114
		public void SetDefault(ILDKBCLAFPB.IJDOCJCLAIL_SortProprty sortProperty, PopupSortMenu.SortPlace place, SortItem sortItem = SortItem.None)
		{
			TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_sort_title");
			SortPlace = place;
			SortItem = sortItem;
			switch(place)
			{
				case PopupSortMenu.SortPlace.Diva:
					SortItem = (SortItem)sortProperty.ONPAMDMIEKM_divaSortItem;
					break;
				case PopupSortMenu.SortPlace.SceneSelect:
					SortItem = (SortItem)sortProperty.LNFFKCDNCPN_sceneSelectSortItem;
					RarityFilter = (uint)sortProperty.FFAKMECDMFC_sceneSelectRarityFilter;
					AttributeFilter = (uint)sortProperty.LMPKAPBCIFD_sceneSelectAttributeFilter;
					SeriaseFilter = (uint)sortProperty.MNNCLIFBAOA_sceneSelectSeriaseFilter;
					CompatibleFilter = (uint)sortProperty.NPFGKBKKCFL_sceneSelectCompatibleFilter;
					IsCompatibleDiva = sortProperty.JACFDEKLDCK_isCompatibleDivaCheck != 0;
					break;
				case PopupSortMenu.SortPlace.Costume:
					SortItem = (SortItem)sortProperty.MDJMAEEONKK_costumeSortItem;
					break;
				case PopupSortMenu.SortPlace.Unit:
					TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_sort_title_unit");
					SortItem = (SortItem)sortProperty.LEAPMNHODPJ_unitWindowDispItem;
					break;
				case PopupSortMenu.SortPlace.SceneList:
					SortItem = (SortItem)sortProperty.GEAECNMDMHH_sceneListSortItem;
					RarityFilter = (uint)sortProperty.HMJNAGNIEJB_sceneListRarityFilter;
					AttributeFilter = (uint)sortProperty.HFGAILIOFAN_sceneListAttributeFilter;
					SeriaseFilter = (uint)sortProperty.AKFPHKLCHAA_sceneListSeriaseFilter;
					CompatibleFilter = (uint)sortProperty.PHCEMKLNJLH_sceneListCompatibleFilter;
					break;
				case PopupSortMenu.SortPlace.AssistList:
					SortItem = (SortItem)sortProperty.NCDOLBOHGFN_sceneAssistSortItem;
					AttributeFilter = (uint)sortProperty.OFFBGLDDBHC_sceneAssistAttributeFilter;
					SeriaseFilter = (uint)sortProperty.POPIEDDJGBA_sceneAssistSeriaseFilter;
					CenterSkillFilter = (uint)sortProperty.GJFPKDOBIPH_sceneAssistCenterSkillFilter;
					break;
				case PopupSortMenu.SortPlace.EpsiodeSelect:
				case PopupSortMenu.SortPlace.VisitList:
					break;
				case PopupSortMenu.SortPlace.DecoShopList:
					TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("pop_deco_shop_sort_title");
					SeriaseFilter = (uint)sortProperty.MOOHKFCHJPO_shopListSeriaseFilter;
					break;
				case PopupSortMenu.SortPlace.DecoInteriorList:
					TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("pop_deco_shop_sort_title");
					SeriaseFilter = (uint)sortProperty.MOOHKFCHJPO_shopListSeriaseFilter;
					InteriorFilter = (uint)sortProperty.PJDCJKHMNNM_interiorListFilter;
					break;
				case PopupSortMenu.SortPlace.FriendList:
					SetFriendSortProprty(sortProperty.IDFGCPNELIA_FriendList);
					break;
				case PopupSortMenu.SortPlace.GuestSelect:
					TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_sort_title_guest_select");
					SetFriendSortProprty(sortProperty.GDMIGCCMEEF_GuestSelect);
					break;
				case PopupSortMenu.SortPlace.SentRequestList:
					SetFriendSortProprty(sortProperty.EJAJGGKHALM_SentRequestList);
					break;
				case PopupSortMenu.SortPlace.PendingList:
					SetFriendSortProprty(sortProperty.DOKBEPGKNJK_PendingList);
					break;
				case PopupSortMenu.SortPlace.LobbyMemberList:
					SetFriendSortProprty(sortProperty.ACCNCHJBDHM_UserList);
					break;
			}
		}

		//// RVA: 0x115161C Offset: 0x115161C VA: 0x115161C
		private void SetFriendSortProprty(ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList friendProperty)
		{
			TodoLogger.Log(0, "SetFriendSortProprty");
		}
	}
}
