
using System;
using XeApp.Game.Common;

namespace XeApp.Game.Gacha
{ 
	public class GachaLotPopupSetting : PopupSetting
	{
		public string MessageText { get; set; } // 0x34
		public string HoldCurrency { get; set; } // 0x38
		public bool CurrencyIsTicket { get; set; } // 0x3C
		public bool IsTicketPeriod { get; set; } // 0x3D
		public Action<Action> OnClickLegalDescButton { get; set; } // 0x40
		public override string PrefabPath { get { return ""; } } //0x98E484
		public override string BundleName { get { return "ly/069.xab"; } } //0x98E4E0
		public override string AssetName { get { return "PopupGachaLot"; } } //0x98E53C
		public override bool IsAssetBundle { get { return true; } } //0x98E598
		public override bool IsPreload { get { return false; } } //0x98E5A0
	}
}
