using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class Debug_UIBunnerAndEpisordController : DebugCheatUIBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Toggle appeal;
	}
}
