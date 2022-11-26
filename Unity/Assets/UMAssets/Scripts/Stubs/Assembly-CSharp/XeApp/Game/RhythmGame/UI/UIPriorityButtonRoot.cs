namespace XeApp.Game.RhythmGame.UI
{
	public class UIPriorityButtonRoot : UIPriority
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		public int buttonModelOffset;
		public int divaButtonOffOffset;
		public int nodesLineOffset;
		public UIPriority.Priority buttonModelPriority;
		public UIPriority.Priority divaButtonOffPriority;
		public UIPriority.Priority nodesLinePriority;
	}
}
