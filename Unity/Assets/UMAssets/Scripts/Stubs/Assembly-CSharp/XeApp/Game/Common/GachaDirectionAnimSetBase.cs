using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionAnimSetBase : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animator;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
