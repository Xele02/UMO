using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SubPlatePanel : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private PopupSubPlateContent m_content;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private Text[] m_statusText;
		[SerializeField]
		private RectTransform[] m_statusArrow;
		[SerializeField]
		private SubPlatePlateControl[] m_plateControl;
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve;
	}
}
