using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigButtonLabel : LayoutUGUIScriptBase
	{
		public enum eLabelType
		{
			None = 0,
			High = 1,
			Low = 2,
			Enable = 3,
			Disable = 4,
			Color1 = 5,
			Color3 = 6,
			Max = 7,
		}

		[SerializeField]
		private RawImageEx m_imageFont;
		[SerializeField]
		private eLabelType m_labelType;
	}
}
