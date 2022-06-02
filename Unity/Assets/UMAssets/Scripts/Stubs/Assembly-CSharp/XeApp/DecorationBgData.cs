using UnityEngine;

namespace XeApp
{
	public class DecorationBgData : MonoBehaviour
	{
		[SerializeField]
		public DecorationBgBase.BgMeshData m_floorMesh;
		[SerializeField]
		public DecorationBgBase.BgMeshData m_wallLMesh;
		[SerializeField]
		public DecorationBgBase.BgMeshData m_wallRMesh;
		[SerializeField]
		public Vector2[] m_LeftBoundaryLine;
		[SerializeField]
		public Vector2[] m_RightBoundaryLine;
		[SerializeField]
		public Vector2[] m_WallCenterBoundaryLine;
		[SerializeField]
		public Vector2[] m_LeftSideLine;
		[SerializeField]
		public Vector2[] m_RightSideLine;
		[SerializeField]
		public Vector2[] m_LeftFloorBottomLine;
		[SerializeField]
		public Vector2[] m_RightFloorBottomLine;
		[SerializeField]
		public Vector2[] m_LeftFloorSideLine;
		[SerializeField]
		public Vector2[] m_RightFloorSideLine;
		[SerializeField]
		public Vector2[] m_TopLeftLine;
		[SerializeField]
		public Vector2[] m_TopRightLine;
		[SerializeField]
		public Vector2[] m_FloorCenterBoundaryLine;
		[SerializeField]
		public Vector2[] m_LeftWallInnerOuterLine;
		[SerializeField]
		public Vector2[] m_RightWallInnerOuterLine;
		[SerializeField]
		public Vector2[] m_LeftFloorInnerOuterLine;
		[SerializeField]
		public Vector2[] m_RightFloorInnerOuterLine;
	}
}
