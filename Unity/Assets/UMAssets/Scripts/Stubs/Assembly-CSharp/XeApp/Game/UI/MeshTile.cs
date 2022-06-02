using UnityEngine;

namespace XeApp.Game.UI
{
	public class MeshTile : MonoBehaviour
	{
		public enum Direction
		{
			TopBottom = 0,
			BottomTop = 1,
			RightLeft = 2,
			LeftRight = 3,
		}

		[SerializeField]
		private Material material_;
		[SerializeField]
		private Direction direction_;
		[SerializeField]
		private Rect uvRect;
	}
}
