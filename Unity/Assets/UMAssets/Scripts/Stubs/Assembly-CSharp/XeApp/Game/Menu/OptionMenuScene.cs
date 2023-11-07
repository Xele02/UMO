namespace XeApp.Game.Menu
{
	public class OptionMenuScene : TransitionRoot
	{
		public class OptionMenuArgs : TransitionArgs
		{
			public bool openConfig; // 0x8
			public bool openSnsLink; // 0x9
		}

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
	}
}
