using UnityEngine;

namespace XeApp.Game.Common
{
	public class ToggleButton : ActionButton
	{
		[SerializeField]
		private short m_gropId;
		[SerializeField]
		private bool m_isNotRepeat;
		[SerializeField]
		private ToggleButtonGroup m_parent;
	}
}
