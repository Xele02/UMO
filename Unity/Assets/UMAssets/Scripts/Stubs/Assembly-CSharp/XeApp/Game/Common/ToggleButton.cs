using UnityEngine;

namespace XeApp.Game.Common
{
	public class ToggleButton : ActionButton
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private short m_gropId;
		[SerializeField]
		private bool m_isNotRepeat;
		[SerializeField]
		private ToggleButtonGroup m_parent;
	}
}
