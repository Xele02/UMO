using UnityEngine;

namespace XeSys.Gfx
{
	public class Fade : MonoBehaviour
	{
		[SerializeField]
		public int renderQueue;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
