
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class CostumeInfoPopupSetting : PopupSetting
	{
		public FFHPBEPOMAK_DivaInfo beforeData { get; set; } // 0x34
		public FFHPBEPOMAK_DivaInfo afterData { get; set; } // 0x38
		public CostumeInfoWindow costumeInfoWindow { get; set; } // 0x3C
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/root_sel_costume_pop_layout_root"; } } //0x162E250
		public override string BundleName { get { return "ly/044.xab"; } } //0x162E2AC
		public override string AssetName { get { return "root_sel_costume_pop_layout_root"; } } //0x162E308
		public override bool IsAssetBundle { get { return true; } } //0x162E364
		public override bool IsPreload { get { return true; } } //0x162E36C
		public override GameObject Content { get { return m_content; } } //0x162E374

		// RVA: 0x162E37C Offset: 0x162E37C VA: 0x162E37C
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
