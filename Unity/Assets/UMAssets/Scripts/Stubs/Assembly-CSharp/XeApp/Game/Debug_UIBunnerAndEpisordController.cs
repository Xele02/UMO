using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class Debug_UIBunnerAndEpisordController : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Toggle appeal;
	}
}
