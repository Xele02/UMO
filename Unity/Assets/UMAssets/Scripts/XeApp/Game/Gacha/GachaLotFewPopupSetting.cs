
namespace XeApp.Game.Gacha
{ 
	public class GachaLotFewPopupSetting : GachaLotPopupSetting
	{
		public string MessageCaution { get; set; } // 0x44
		public string NeedCurrency { get; set; } // 0x48
		public override string AssetName { get { return "PopupGachaLotFew"; } } //0x98E3C8
	}
}
