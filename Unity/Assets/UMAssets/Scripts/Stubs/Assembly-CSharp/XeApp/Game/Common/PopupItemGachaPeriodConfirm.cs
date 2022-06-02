using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemGachaPeriodConfirm : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_imageIcon;
		[SerializeField]
		private ActionButton m_buttonIcon;
		[SerializeField]
		private ActionButton m_buttonDetail;
		[SerializeField]
		private NumberBase m_numberCost;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text[] m_textCount;
		[SerializeField]
		private Text m_textCaution;
		[SerializeField]
		private Text m_textPeriod;
	}
}
