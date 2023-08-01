using UnityEngine;

namespace XeSys.Gfx
{
	public class Fade : MonoBehaviour
	{
		[SerializeField]
		public int renderQueue;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
