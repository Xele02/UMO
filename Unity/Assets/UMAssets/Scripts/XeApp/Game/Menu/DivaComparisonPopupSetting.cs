
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaComparisonPopupSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x17D6B68
		public override string BundleName { get { return "ly/014.xab"; } } //0x17D6BC4
		public override string AssetName { get { return "DivaComparisonPopup"; } } //0x17D6C20
		public override bool IsAssetBundle { get { return true; } } //0x17D6C7C
		public override bool IsPreload { get { return true; } } //0x17D6C84
		public override GameObject Content { get { return m_content; } } //0x17D6C8C
		public DFKGGBMFFGB PlayerData { get; set; } // 0x34
		public FFHPBEPOMAK AfterDiva { get; set; } // 0x38
		public FFHPBEPOMAK BeforeDiva { get; set; } // 0x3C
		public EEDKAACNBBG MusicData { get; set; } // 0x40
		public bool IsCenterDiva { get; set; } // 0x44
		public DisplayType DisplayType { get; set; } // 0x48
		public int TeamId { get; set; } // 0x4C

		//// RVA: 0x17D6CDC Offset: 0x17D6CDC VA: 0x17D6CDC
		public void SetContent(GameObject content)
		{
			m_content = content;
		}
	}
}
