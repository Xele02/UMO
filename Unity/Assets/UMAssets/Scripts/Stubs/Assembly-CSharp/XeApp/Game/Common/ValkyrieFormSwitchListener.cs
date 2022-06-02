using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieFormSwitchListener : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animator;
		[SerializeField]
		private string m_fighterStateName;
		[SerializeField]
		private string m_gerwalkStateName;
		[SerializeField]
		private string m_battroidStateName;
	}
}
