using UnityEngine;

namespace XeApp
{
	public class DecorationBgData : MonoBehaviour
	{
		[SerializeField]
		public DecorationBgBase.BgMeshData m_floorMesh = new DecorationBgBase.BgMeshData(); // 0xC
		[SerializeField]
		public DecorationBgBase.BgMeshData m_wallLMesh = new DecorationBgBase.BgMeshData(); // 0x10
		[SerializeField]
		public DecorationBgBase.BgMeshData m_wallRMesh = new DecorationBgBase.BgMeshData(); // 0x14
		[SerializeField]
		public Vector2[] m_LeftBoundaryLine = new Vector2[2]; // 0x18
		[SerializeField]
		public Vector2[] m_RightBoundaryLine = new Vector2[2]; // 0x1C
		[SerializeField]
		public Vector2[] m_WallCenterBoundaryLine = new Vector2[2]; // 0x20
		[SerializeField]
		public Vector2[] m_LeftSideLine = new Vector2[2]; // 0x24
		[SerializeField]
		public Vector2[] m_RightSideLine = new Vector2[2]; // 0x28
		[SerializeField]
		public Vector2[] m_LeftFloorBottomLine = new Vector2[2]; // 0x2C
		[SerializeField]
		public Vector2[] m_RightFloorBottomLine = new Vector2[2]; // 0x30
		[SerializeField]
		public Vector2[] m_LeftFloorSideLine = new Vector2[2]; // 0x34
		[SerializeField]
		public Vector2[] m_RightFloorSideLine = new Vector2[2]; // 0x38
		[SerializeField]
		public Vector2[] m_TopLeftLine = new Vector2[2]; // 0x3C
		[SerializeField]
		public Vector2[] m_TopRightLine = new Vector2[2]; // 0x40
		[SerializeField]
		public Vector2[] m_FloorCenterBoundaryLine = new Vector2[2]; // 0x44
		[SerializeField]
		public Vector2[] m_LeftWallInnerOuterLine = new Vector2[2]; // 0x48
		[SerializeField]
		public Vector2[] m_RightWallInnerOuterLine = new Vector2[2]; // 0x4C
		[SerializeField]
		public Vector2[] m_LeftFloorInnerOuterLine = new Vector2[2]; // 0x50
		[SerializeField]
		public Vector2[] m_RightFloorInnerOuterLine = new Vector2[2]; // 0x54
		public const int DecorationBgWallVertexNum = 4;
		public const int DecorationBgFloorVertexNum = 12;
		private Rect m_rect; // 0x58
		private Rect m_floorRect; // 0x68

		//// RVA: 0x1D7FE6C Offset: 0x1D7FE6C VA: 0x1D7FE6C
		//public void Setting(MeshFilter meshFilter) { }

		//// RVA: 0x1D814BC Offset: 0x1D814BC VA: 0x1D814BC
		//public void SettingInnerOuterBoundaryLine(float floorInnerRate, float wallInnerRate) { }

		//// RVA: 0x1D81CE0 Offset: 0x1D81CE0 VA: 0x1D81CE0
		//public void SettingInnerOuterBoundaryLine(Vector2[] leftFloor, Vector2[] rightFloor, Vector2[] leftFloorBottomFloor, Vector2[] rightFloorBottomFloor, Vector2[] leftWall, Vector2[] rightWall) { }

		//// RVA: 0x1D81D10 Offset: 0x1D81D10 VA: 0x1D81D10
		//public Rect GetRect() { }

		//// RVA: 0x1D81ED4 Offset: 0x1D81ED4 VA: 0x1D81ED4
		//public Rect GetFloorRect() { }

		//// RVA: 0x1D82098 Offset: 0x1D82098 VA: 0x1D82098
		public void GetInnerLine(DecorationConstants.Attribute.Type type, DecorationConstants.Attribute.AreaType areaType, out Vector2[] checkLeftInnerLine, out Vector2[] checkRightInnerLine)
		{
			if (areaType == DecorationConstants.Attribute.AreaType.All)
				areaType = DecorationConstants.Attribute.AreaType.Inner;
			bool isArea = DecorationConstants.Attribute.CheckArea(areaType, DecorationConstants.Attribute.AreaType.Inner);
			bool isAttr = DecorationConstants.Attribute.CheckAttribute(type, DecorationConstants.Attribute.Type.Floor);
			if(isAttr && !isArea)
			{
				checkLeftInnerLine = m_LeftFloorInnerOuterLine;
				checkRightInnerLine = m_RightFloorInnerOuterLine;
			}
			else if(!isArea)
			{
				checkLeftInnerLine = m_LeftWallInnerOuterLine;
				checkRightInnerLine = m_RightWallInnerOuterLine;
			}
			else
			{
				checkLeftInnerLine = m_LeftBoundaryLine;
				checkRightInnerLine = m_RightBoundaryLine;
			}
		}

		//// RVA: 0x1D82138 Offset: 0x1D82138 VA: 0x1D82138
		public void GetOuterLine(DecorationConstants.Attribute.Type type, DecorationConstants.Attribute.AreaType areaType, out Vector2[] checkLeftOuterLine, out Vector2[] checkRightOuterLine)
		{
			if (areaType == DecorationConstants.Attribute.AreaType.All)
				areaType = DecorationConstants.Attribute.AreaType.Outer;
			bool isArea = DecorationConstants.Attribute.CheckArea(areaType, DecorationConstants.Attribute.AreaType.Inner);
			bool isAttr = DecorationConstants.Attribute.CheckAttribute(type, DecorationConstants.Attribute.Type.Floor);
			if (isAttr)
			{
				if (!isArea)
				{
					checkLeftOuterLine = m_LeftFloorBottomLine;
					checkRightOuterLine = m_RightFloorBottomLine;
				}
				else
				{
					checkLeftOuterLine = m_LeftFloorInnerOuterLine;
					checkRightOuterLine = m_RightFloorInnerOuterLine;
				}
			}
			else if (!isArea)
			{
				checkLeftOuterLine = m_TopLeftLine;
				checkRightOuterLine = m_TopRightLine;
			}
			else
			{
				checkLeftOuterLine = m_LeftWallInnerOuterLine;
				checkRightOuterLine = m_RightWallInnerOuterLine;
			}
		}

		//// RVA: 0x1D821E8 Offset: 0x1D821E8 VA: 0x1D821E8
		public void GetSideLine(DecorationConstants.Attribute.Type type, out Vector2[] centerLine, out Vector2[] leftSideLine, out Vector2[] rightSideLine)
		{
			if(type != DecorationConstants.Attribute.Type.BgBoth)
			{
				if(DecorationConstants.Attribute.CheckAttribute(type, DecorationConstants.Attribute.Type.Floor))
				{
					centerLine = m_FloorCenterBoundaryLine;
					leftSideLine = m_LeftFloorSideLine;
					rightSideLine = m_RightFloorSideLine;
				}
				else
				{
					centerLine = m_WallCenterBoundaryLine;
					leftSideLine = m_LeftSideLine;
					rightSideLine = m_RightSideLine;
				}
			}
			else
			{
				centerLine = m_WallCenterBoundaryLine;
				leftSideLine = m_LeftSideLine;
				rightSideLine = m_RightSideLine;
				centerLine[1] = m_LeftFloorSideLine[0];
				leftSideLine[1] = m_LeftFloorSideLine[0];
				rightSideLine[1] = m_RightFloorSideLine[0];
			}
		}

		//// RVA: 0x1D823C0 Offset: 0x1D823C0 VA: 0x1D823C0
		//public bool CheckArea(DecorationItemBase item, Vector2 position) { }
	}
}
