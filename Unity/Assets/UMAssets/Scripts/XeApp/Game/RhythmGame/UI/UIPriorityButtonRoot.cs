using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	[ExecuteInEditMode] // RVA: 0x650F58 Offset: 0x650F58 VA: 0x650F58
	public class UIPriorityButtonRoot : UIPriority
	{
		public int buttonModelOffset = 1; // 0x1C
		public int divaButtonOffOffset = 1; // 0x20
		public int nodesLineOffset; // 0x24
		public Priority buttonModelPriority; // 0x28
		public Priority divaButtonOffPriority = Priority.UnderNotes; // 0x2C
		public Priority nodesLinePriority = Priority.UnderNotes; // 0x30

		//// RVA: 0x1567C90 Offset: 0x1567C90 VA: 0x1567C90
		//public void SetValue(ref UIPriority.PrioritySet ps) { }
	}
}
