using UnityEngine;

namespace XeApp.Game
{
	public class ScaleTween : TweenBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Vector3 m_from;
		[SerializeField]
		private Vector3 m_to;
		[SerializeField]
		private Transform m_target;
	}
}
