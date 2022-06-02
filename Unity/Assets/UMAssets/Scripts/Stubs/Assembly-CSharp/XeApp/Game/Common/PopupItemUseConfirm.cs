using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemUseConfirm : LayoutUGUIScriptBase
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
		private Text m_textCaution_1;
		[SerializeField]
		private Text m_textCaution_2;
		[SerializeField]
		private Text m_textCaution_3;
		[SerializeField]
		private Text m_textPeriod;
	}
}
