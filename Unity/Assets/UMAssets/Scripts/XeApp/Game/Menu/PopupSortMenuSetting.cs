
using UnityEngine;
using XeApp.Game.Common;

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
		//public void Initialize() { }

		//// RVA: 0x1151114 Offset: 0x1151114 VA: 0x1151114
		//public void SetDefault(ILDKBCLAFPB.IJDOCJCLAIL sortProperty, PopupSortMenu.SortPlace place, SortItem sortItem = -1) { }

		//// RVA: 0x115161C Offset: 0x115161C VA: 0x115161C
		//private void SetFriendSortProprty(ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH friendProperty) { }
	}
}
