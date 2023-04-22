
using UnityEngine;

namespace XeApp.Game.Common
{
	public class PopupSkipTicketUseConfirmSetting : PopupSetting
	{
		public int UseItemId { get; set; } // 0x34
		public int ItemCurrentValue { get; set; } // 0x38
		public int ItemUseMaxValue { get; set; } // 0x3C
		public int ItemHaveMaxValue { get; set; } // 0x40
		public bool IsOneUseForced { get; set; } // 0x44
		public bool IsWeekdayEvent { get; set; } // 0x45
		public bool IsGoDivaEventDailyBonus { get; set; } // 0x46
		public int ConsumeItemId { get; set; } // 0x48
		public int ConsumeItemValue { get; set; } // 0x4C
		public int ConsumeItemMax { get; set; } // 0x50
		public PopupSkipTicketUseConfirm.ConsumeItem ConsumeItem { get; set; } // 0x54
		public override bool IsPreload { get { return true; } } //0x1BB423C
		public override bool IsAssetBundle { get { return true; } } //0x1BB4244
		public override string PrefabPath { get { return ""; } } //0x1BB424C
		public override string BundleName { get { return "ly/216.xab"; } } //0x1BB42A8
		public override string AssetName { get { return "root_skip_pop_01_layout_root"; } } //0x1BB4304
		public override GameObject Content { get { return m_content; } } //0x1BB4360
	}
}
