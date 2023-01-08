using UnityEngine;

namespace XeApp.Game.Adv
{
	public class AdvMessageBase : MonoBehaviour
	{
		public delegate string TagConvertFunc(string tag);
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
