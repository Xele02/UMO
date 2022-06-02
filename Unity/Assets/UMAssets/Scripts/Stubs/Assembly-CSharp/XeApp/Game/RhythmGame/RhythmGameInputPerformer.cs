using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameInputPerformer : RhythmGamePerformer
	{
		[SerializeField]
		private GameObject rectParent;
		[SerializeField]
		private GameObject rectParentW;
		public RectTransform touchSkillRect;
		[SerializeField]
		private List<Vector2> touchRectScreenPos;
	}
}
