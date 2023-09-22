using System.Collections.Generic;
using UnityEngine;

namespace XeApp
{
	public class DecorationBgManager : MonoBehaviour
	{
		private enum SnapType
		{
			Top = 0,
			Bottom = 1,
			Thickness = 2,
			Left = 3,
			Right = 4,
			Center = 5,
		}

		public struct AreaData
		{
			public int m_floorId; // 0x0
			public int m_wallLId; // 0x4
			public int m_wallRId; // 0x8

			//// RVA: 0x1D87818 Offset: 0x1D87818 VA: 0x1D87818
			//public static bool op_Equality(DecorationBgManager.AreaData lhs, DecorationBgManager.AreaData rhs) { }

			//// RVA: 0x1D84380 Offset: 0x1D84380 VA: 0x1D84380
			//public static bool op_Inequality(DecorationBgManager.AreaData lhs, DecorationBgManager.AreaData rhs) { }
		}

		private static readonly Vector2 UpRay = new Vector2(0, 10000); // 0x0
		private static readonly Vector2 DownRay = new Vector2(0, -10000); // 0x8
		private static readonly Vector2 RightRay = new Vector2(10000, 0); // 0x10
		private static readonly Vector2 LeftRay = new Vector2(-10000, 0); // 0x18
		private GameObject m_decorationBgPrefab; // 0xC
		private DecorationBgData m_decorationBgData; // 0x10
		private List<GameObject> m_hitGameObject = new List<GameObject>(); // 0x14
		private List<DecorationBgBase> m_decorationBgList = new List<DecorationBgBase>(); // 0x18
		[SerializeField]
		private float m_innerAreaSize = 0.5f; // 0x20
		private AreaData m_areaData; // 0x24
		private AreaData m_initAreaData; // 0x30
		private AreaData m_undoAreaData; // 0x3C

		public bool IsLoded { get; private set; } // 0x1C
		public bool IsLodedTexture { get; private set; } // 0x1D

		// RVA: 0x1D837D8 Offset: 0x1D837D8 VA: 0x1D837D8
		private void Awake()
		{
			return;
		}

		//// RVA: 0x1D837DC Offset: 0x1D837DC VA: 0x1D837DC
		//public void LoadResource() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AAB24 Offset: 0x6AAB24 VA: 0x6AAB24
		//// RVA: 0x1D8380C Offset: 0x1D8380C VA: 0x1D8380C
		//private IEnumerator Co_LoadResource() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AAB9C Offset: 0x6AAB9C VA: 0x6AAB9C
		//// RVA: 0x1D838B8 Offset: 0x1D838B8 VA: 0x1D838B8
		//private IEnumerator Co_LoadBgResource() { }

		//// RVA: 0x1D83964 Offset: 0x1D83964 VA: 0x1D83964
		//private void SettingBgData() { }

		//// RVA: 0x1D83F2C Offset: 0x1D83F2C VA: 0x1D83F2C
		//public void LoadTexutre(DecorationBgManager.AreaData areaData, bool isInit) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AAC14 Offset: 0x6AAC14 VA: 0x6AAC14
		//// RVA: 0x1D83F84 Offset: 0x1D83F84 VA: 0x1D83F84
		//private IEnumerator Co_LoadTexture(DecorationBgManager.AreaData areaData, bool isInit) { }

		//// RVA: 0x1D84074 Offset: 0x1D84074 VA: 0x1D84074
		//public void SetActive(bool isActive) { }

		//// RVA: 0x1D84130 Offset: 0x1D84130 VA: 0x1D84130
		//public Rect GetRect() { }

		//// RVA: 0x1D84160 Offset: 0x1D84160 VA: 0x1D84160
		//public Rect GetFloorRect() { }

		//// RVA: 0x1D84190 Offset: 0x1D84190 VA: 0x1D84190
		//public void GetWallTopLine(out Vector2[] leftLine, out Vector2[] rightLine) { }

		//// RVA: 0x1D841D8 Offset: 0x1D841D8 VA: 0x1D841D8
		//public DecorationBgBase GetFloor() { }

		//// RVA: 0x1D84264 Offset: 0x1D84264 VA: 0x1D84264
		//public int GetId(DecorationConstants.Attribute.Type type) { }

		//// RVA: 0x1D842A0 Offset: 0x1D842A0 VA: 0x1D842A0
		//public void Return() { }

		//// RVA: 0x1D842C8 Offset: 0x1D842C8 VA: 0x1D842C8
		//public void Undo(DecorationConstants.Attribute.Type type) { }

		//// RVA: 0x1D84344 Offset: 0x1D84344 VA: 0x1D84344
		//public bool ExistUndo() { }

		//// RVA: 0x1D843A8 Offset: 0x1D843A8 VA: 0x1D843A8
		public bool CheckAdjustPosition(DecorationItemBase item, ref Vector2 adjustPos)
		{
			bool hasFloor = item.CheckAttribute(DecorationConstants.Attribute.Type.Floor);
			bool hasWall = item.CheckAttribute(DecorationConstants.Attribute.Type.Wall);
			Vector2[] centerLine;
			Vector2[] leftSideLine;
			Vector2[] rightSideLine;
			m_decorationBgData.GetSideLine(item.AttributeType, out centerLine, out leftSideLine, out rightSideLine);
			bool check = VerticalBoundaryLineCheck(item, centerLine, leftSideLine, rightSideLine, ref adjustPos);
			if(hasFloor)
			{
				Vector2[] checkLeftInnerLine;
				Vector2[] checkRightInnerLine;
				Vector2[] checkLeftOuterLine;
				Vector2[] checkRightOuterLine;
				m_decorationBgData.GetInnerLine(DecorationConstants.Attribute.Type.Floor, item.Setting.AreaType, out checkLeftInnerLine, out checkRightInnerLine);
				m_decorationBgData.GetOuterLine(DecorationConstants.Attribute.Type.Floor, item.Setting.AreaType, out checkLeftOuterLine, out checkRightOuterLine);
				check |= FloorHorizonBoundaryLineCheck(item, checkLeftInnerLine, checkRightInnerLine, checkLeftOuterLine, checkRightOuterLine, ref adjustPos);
			}
			if(hasWall)
			{
				Vector2[] checkLeftInnerLine;
				Vector2[] checkRightInnerLine;
				Vector2[] checkLeftOuterLine;
				Vector2[] checkRightOuterLine;
				m_decorationBgData.GetInnerLine(DecorationConstants.Attribute.Type.Wall, item.Setting.AreaType, out checkLeftInnerLine, out checkRightInnerLine);
				m_decorationBgData.GetOuterLine(DecorationConstants.Attribute.Type.Wall, item.Setting.AreaType, out checkLeftOuterLine, out checkRightOuterLine);
				check |= FloorHorizonBoundaryLineCheck(item, checkLeftInnerLine, checkRightInnerLine, checkLeftOuterLine, checkRightOuterLine, ref adjustPos);
			}
			return check;
		}

		//// RVA: 0x1D8533C Offset: 0x1D8533C VA: 0x1D8533C
		//public bool CheckPost(DecorationItemBase item, Vector2 position, DecorationConstants.Attribute.Type hitAttributeType) { }

		//// RVA: 0x1D85440 Offset: 0x1D85440 VA: 0x1D85440
		//public DecorationConstants.Attribute.Type GetAttribute(DecorationItemBase item, Vector2 position) { }

		//// RVA: 0x1D85630 Offset: 0x1D85630 VA: 0x1D85630
		//public void SetEnablePostArea(DecorationConstants.Attribute.Type type) { }

		//// RVA: 0x1D84A5C Offset: 0x1D84A5C VA: 0x1D84A5C
		private bool FloorHorizonBoundaryLineCheck(DecorationItemBase item, Vector2[] checkLeftInnerLine, Vector2[] checkRightInnerLine, Vector2[] checkLeftOuterLine, Vector2[] checkRightOuterLine, ref Vector2 adjustPos)
		{
			bool res = false;
			Vector2 v;
			Vector2 off;
			if (item.Setting.AreaType == DecorationConstants.Attribute.AreaType.Inner)
			{
				off = GetSnapOffset(item, SnapType.Bottom);
				v = new Vector2(adjustPos.x, DownRay.y * -0.5f);
				BoundaryLineCheck(ref res, v, DownRay, off, checkLeftInnerLine, ref adjustPos);
			}
			else
			{
				v = adjustPos + GetRayStartPos(item, SnapType.Bottom);
				BoundaryLineCheck(ref res, v, UpRay, GetSnapOffset(item, SnapType.Bottom), checkLeftOuterLine, ref adjustPos);
				BoundaryLineCheck(ref res, v, UpRay, GetSnapOffset(item, SnapType.Bottom), checkRightOuterLine, ref adjustPos);
				if (item.Setting.AttributeType == DecorationConstants.Attribute.Type.BgBoth)
					return res;
				v = adjustPos + GetRayStartPos(item, SnapType.Thickness);
				BoundaryLineCheck(ref res, v, DownRay, GetSnapOffset(item, SnapType.Thickness), checkLeftInnerLine, ref adjustPos);
				off = GetSnapOffset(item, SnapType.Thickness);
			}
			BoundaryLineCheck(ref res, v, DownRay, off, checkRightInnerLine, ref adjustPos);
			return res;
		}

		//// RVA: 0x1D84EAC Offset: 0x1D84EAC VA: 0x1D84EAC
		//private bool WallHorizonBoundaryLineCheck(DecorationItemBase item, Vector2[] checkLeftInnerLine, Vector2[] checkRightInnerLine, Vector2[] checkLeftOuterLine, Vector2[] checkRightOuterLine, ref Vector2 adjustPos) { }

		//// RVA: 0x1D846CC Offset: 0x1D846CC VA: 0x1D846CC
		private bool VerticalBoundaryLineCheck(DecorationItemBase item, Vector2[] centerLine, Vector2[] leftSizeLine, Vector2[] rightSizeLine, ref Vector2 adjustPos)
		{
			bool isAdjust = false;
			if(item.Setting.IsAutoFlip)
			{
				Vector2 rayStartPos = GetRayStartPos(item, item.Position.x <= 0 ? SnapType.Right : SnapType.Left);
				Vector2 v2 = rayStartPos + adjustPos;
				Vector2 v3 = item.Size;
				Vector2 snapOffset = GetSnapOffset(item, item.Position.x > 0 ? SnapType.Left : SnapType.Right);
				if(item.Position.x <= 0)
				{
					v3.x = -v3.x;
				}
				VerticalBoundaryLineCheck(ref isAdjust, v2, v3, snapOffset, centerLine, ref adjustPos);
			}
			Vector2 rayStartPos2 = GetRayStartPos(item, item.Position.x <= 0 ? SnapType.Left : SnapType.Right);
			rayStartPos2 += adjustPos;
			Vector2 snapOffset2 = GetSnapOffset(item, item.Position.x > 0 ? SnapType.Left : SnapType.Right);
			VerticalBoundaryLineCheck(ref isAdjust, rayStartPos2, item.Position.x > 0 ? LeftRay : RightRay, snapOffset2, item.Position.x <= 0 ? leftSizeLine : rightSizeLine, ref adjustPos);
			return isAdjust;
		}

		//// RVA: 0x1D85BC4 Offset: 0x1D85BC4 VA: 0x1D85BC4
		private void BoundaryLineCheck(ref bool isAdjust, Vector2 itemPosition, Vector2 rayDirection, Vector2 snapOffset, Vector2[] boundaryLine, ref Vector2 adjustPos)
		{
			if (isAdjust)
				return;
			Vector2 v1 = itemPosition + rayDirection;
			Vector2 v2 = v1 - itemPosition;
			Vector2 v3 = boundaryLine[0] - boundaryLine[1];
			Vector2 v4 = boundaryLine[1] - itemPosition;
			Vector2 v5 = boundaryLine[0] - itemPosition;
			Vector2 v6 = itemPosition - boundaryLine[0];
			Vector2 v7 = v1 - boundaryLine[0];
			float f1 = v3.y * v6.y - v3.x * v6.x;
			if(Mathf.Abs(f1) > 0.01f)
			{
				float f2 = v2.y * v5.y - v2.x * v5.x;
				float f3 = v2.y - v4.y - v2.x * v4.x;
				if(f3 * f2 <= 0 && f1 * (v3.y * v7.y - v3.x * v7.x) <= 0)
				{
					v1 = v3 * Mathf.Abs(f3) / (Mathf.Abs(f3) + Mathf.Abs(f2));
					v2 = boundaryLine[1] + v1;
					adjustPos = v2;
					v3 = v2 + snapOffset;
					adjustPos = v3;
					isAdjust = true;
					return;
				}
			}
			isAdjust = false;
		}

		//// RVA: 0x1D860F4 Offset: 0x1D860F4 VA: 0x1D860F4
		private void VerticalBoundaryLineCheck(ref bool isAdjust, Vector2 itemPosition, Vector2 rayDirection, Vector2 snapOffset, Vector2[] boundaryLine, ref Vector2 adjustPos)
		{
			if(!isAdjust)
			{
				Vector2 v = itemPosition + rayDirection;
				isAdjust = false;
				if(0 > (itemPosition.x - boundaryLine[0].x) * (v.x - boundaryLine[0].x))
				{
					Vector2 v2 = itemPosition;
					v2.x -= itemPosition.x - boundaryLine[0].x;
					adjustPos = v2 + snapOffset;
					isAdjust = true;
				}
			}
		}

		//// RVA: 0x1D86048 Offset: 0x1D86048 VA: 0x1D86048
		private Vector2 GetRayStartPos(DecorationItemBase item, SnapType type)
		{
			return -GetSnapOffset(item, type);
		}

		//// RVA: 0x1D85814 Offset: 0x1D85814 VA: 0x1D85814
		private Vector2 GetSnapOffset(DecorationItemBase item, SnapType type)
		{
			Vector2 res = Vector2.zero;
			switch(type)
			{
				case SnapType.Top:
					res.y = -item.HalfHeight - item.Setting.AdjustOffset.y;
					if(item.CheckAttribute(DecorationConstants.Attribute.Type.Wall))
					{
						if(item.Setting.IsAutoFlip)
						{
							res.x = item.HalfWidth;
							if (item.Position.x <= 0)
								res.x = -res.x;
						}
					}
					break;
				case SnapType.Bottom:
					res.y = item.HalfHeight - item.Setting.AdjustOffset.y;
					if(item.CheckAttribute(DecorationConstants.Attribute.Type.Wall))
					{
						if(item.Setting.IsAutoFlip)
						{
							res.x = -item.HalfWidth;
							if (item.Position.x <= 0)
								res.x = -res.x;
						}
					}
					break;
				case SnapType.Thickness:
					res.y = item.HalfHeight - item.Setting.AdjustOffset.y - item.Scale * item.Setting.Thickness;
					break;
				case SnapType.Left:
					res.x = item.HalfWidth + item.Setting.AdjustOffset.x;
					break;
				case SnapType.Right:
					res.x += item.Setting.AdjustOffset.x;
					res.y = res.x - item.Setting.AdjustOffset.y;
					break;
			}
			return res;
		}

		//// RVA: 0x1D8628C Offset: 0x1D8628C VA: 0x1D8628C
		//public void GetCenterLine(DecorationConstants.Attribute.Type type, ref Vector2[] line) { }

		//// RVA: 0x1D866A0 Offset: 0x1D866A0 VA: 0x1D866A0
		//private void GetFloorCenterLine(DecorationConstants.Attribute.AreaType areaType, ref Vector2[] line) { }

		//// RVA: 0x1D864A8 Offset: 0x1D864A8 VA: 0x1D864A8
		//private void GetWallCenterLine(DecorationConstants.Attribute.AreaType areaType, ref Vector2[] line) { }
	}
}
