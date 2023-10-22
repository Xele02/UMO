using UnityEngine;

namespace XeApp
{
	public class DecorationBgHitData : MonoBehaviour
	{
		private const int VerTexNum = 9;
		[SerializeField]
		public Vector2[] m_LeftWallInnerOuterLine = new Vector2[2]; // 0xC
		[SerializeField]
		public Vector2[] m_RightWallInnerOuterLine = new Vector2[2]; // 0x10
		[SerializeField]
		public Vector2[] m_LeftFloorInnerOuterLine = new Vector2[2]; // 0x14
		[SerializeField]
		public Vector2[] m_RightFloorInnerOuterLine = new Vector2[2]; // 0x18
		[SerializeField]
		public Vector2[] m_LeftFloorBottomLine = new Vector2[2]; // 0x1C
		[SerializeField]
		public Vector2[] m_RightFloorBottomLine = new Vector2[2]; // 0x20
		[SerializeField]
		public Vector2[] m_LeftBottomSlopeLine = new Vector2[2]; // 0x24
		[SerializeField]
		public Vector2[] m_RightBottomSlopeLine = new Vector2[2]; // 0x28

		// // RVA: 0x1D82BA4 Offset: 0x1D82BA4 VA: 0x1D82BA4
		// public void Setting(MeshFilter meshFilter, DecorationConstants.Attribute.Type attrType) { }

		// // RVA: 0x1D82FCC Offset: 0x1D82FCC VA: 0x1D82FCC
		// public void SettingBottomOffset(MeshFilter meshFilter) { }

		// // RVA: 0x1D8368C Offset: 0x1D8368C VA: 0x1D8368C
		// public void GetLine(out Vector2[] leftFloorInnerOuterLine, out Vector2[] rightFloorInnerOuterLine, out Vector2[] leftFloorBottomLine, out Vector2[] rightFloorBottomLine, out Vector2[] leftWallInnerOuterLine, out Vector2[] rightWallInnerOuterLine) { }
	}
}
