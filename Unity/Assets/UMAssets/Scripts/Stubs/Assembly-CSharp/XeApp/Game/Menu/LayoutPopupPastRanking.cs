using XeSys.Gfx;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupPastRanking : LayoutLabelScriptBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private List<ButtonBase> m_n1Buttons;
		[SerializeField]
		private List<RawImageEx> m_n1Images;
		[SerializeField]
		private List<ButtonBase> m_n2Buttons;
		[SerializeField]
		private List<RawImageEx> m_n2Images;
	}
}
