using UnityEngine;

namespace XeApp.Game.Common
{
	public class UGUIToggleObjectSwapButton : UGUIToggleButton
	{
		[SerializeField]
		private GameObject m_checkObj;
		[SerializeField]
		private GameObject m_nonCheckObj;
		[SerializeField]
		private Color m_normalColor;
		[SerializeField]
		private Color m_disableColor;
		[SerializeField]
		private ColorGroup m_colorGroup;
	}
}
