using XeSys.Gfx;

namespace XeApp.Game.Tutorial
{
	public class TutorialPointer : LayoutUGUIScriptBase
	{
		public enum Direction
		{
			Normal = 1,
			UP = 2,
			Down = 3,
		}
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
	}
}
