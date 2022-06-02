using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupVariousInfoButtonLabel : LayoutUGUIScriptBase
	{
		public enum eLabelType
		{
			None = 0,
			Wiki = 1,
			Twitter = 2,
			Byelaw = 3,
			Policy = 4,
			Transaction = 5,
			Settlement = 6,
			CopyRight = 7,
			Credit = 8,
			OfficialSite = 9,
			PortalSite = 10,
			FAQ = 11,
			Num = 12,
		}

		[SerializeField]
		private RawImageEx m_imageFont;
		[SerializeField]
		private eLabelType m_labelType;
	}
}
