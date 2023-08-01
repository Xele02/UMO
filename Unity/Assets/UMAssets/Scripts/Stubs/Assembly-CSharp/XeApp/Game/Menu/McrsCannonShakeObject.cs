using UnityEngine;

namespace XeApp.Game.Menu
{
	public class McrsCannonShakeObject : MonoBehaviour
	{
		public Vector3 Move;
		public Vector3 Rotate;
		public float Speed;
		public float Duration;
		public float Scale;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
