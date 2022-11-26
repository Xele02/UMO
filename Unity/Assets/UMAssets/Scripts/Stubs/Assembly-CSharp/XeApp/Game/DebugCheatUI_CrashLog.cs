namespace XeApp.Game
{
	public class DebugCheatUI_CrashLog : DebugCheatUI_SystemsBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
	}
}
