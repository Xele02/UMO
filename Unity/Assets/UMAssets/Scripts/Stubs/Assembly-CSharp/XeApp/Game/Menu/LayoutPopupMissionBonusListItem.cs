using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMissionBonusListItem : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_textDate;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private RawImageEx m_imageLogo;
	}
}
