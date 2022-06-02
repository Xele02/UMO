using UnityEngine;

namespace XeApp
{
	public class DecorationBgHitData : MonoBehaviour
	{
		[SerializeField]
		public Vector2[] m_LeftWallInnerOuterLine;
		[SerializeField]
		public Vector2[] m_RightWallInnerOuterLine;
		[SerializeField]
		public Vector2[] m_LeftFloorInnerOuterLine;
		[SerializeField]
		public Vector2[] m_RightFloorInnerOuterLine;
		[SerializeField]
		public Vector2[] m_LeftFloorBottomLine;
		[SerializeField]
		public Vector2[] m_RightFloorBottomLine;
		[SerializeField]
		public Vector2[] m_LeftBottomSlopeLine;
		[SerializeField]
		public Vector2[] m_RightBottomSlopeLine;
	}
}
