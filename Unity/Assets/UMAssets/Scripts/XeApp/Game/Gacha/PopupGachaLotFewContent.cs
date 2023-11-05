using XeApp.Game.Common;
using XeApp.Game.Menu;

namespace XeApp.Game.Gacha
{
	public class PopupGachaLotFewContent : PopupGachaLotContent
	{
		// RVA: 0x999BF4 Offset: 0x999BF4 VA: 0x999BF4 Slot: 25
		public override void OnInitialize(PopupSetting setting)
		{
			GachaLotFewPopupSetting s = setting as GachaLotFewPopupSetting;
			PopupGachaLotFewRuntime l = m_popupUi as PopupGachaLotFewRuntime;
			l.SetMessageCaution(s.MessageCaution);
			l.SetNeedCurrency(s.NeedCurrency);
		}
	}
}
