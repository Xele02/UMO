using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.UI
{
	[ExecuteInEditMode] // RVA: 0x65107C Offset: 0x65107C VA: 0x65107C
	[RequireComponent(typeof(RectTransform))] // RVA: 0x65107C Offset: 0x65107C VA: 0x65107C
	[RequireComponent(typeof(MeshRenderer))] // RVA: 0x65107C Offset: 0x65107C VA: 0x65107C
	[RequireComponent(typeof(MeshFilter))] // RVA: 0x65107C Offset: 0x65107C VA: 0x65107C
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
		private Material material_; // 0xC
		[SerializeField]
		private Direction direction_; // 0x10
		[SerializeField]
		private Rect uvRect; // 0x14
		private MeshRenderer renderer_; // 0x24
		private MeshFilter filter_; // 0x28
		private Mesh mesh_; // 0x2C
		private RectTransform rectTransform_; // 0x30
		private List<Vector3> vertices_; // 0x34
		private List<Vector2> uvs_; // 0x38
		private const int MaxIndicesCount = 192;
		private List<int> indices = new List<int>(192); // 0x3C
		private readonly int[] baseTriangle = new int[Field$< PrivateImplementationDetails > .45B5AE0F399DF3BEADAD423823505C49AB2A03DF]; // 0x40
		private float value_ = 0.5f; // 0x44

		//public Rect UvRect { get; set; } 0x191C4E0 0x191C4F0
		//public Material Material { get; set; } 0x191CA54 0x191CA5C
		//public MeshTile.Direction Type { get; set; } 0x191CB1C 0x191CB24
		public float Value { get { return value_; } set { value_ = value; UpdateMesh(); } } //0x191CB38 0x191CB40

		//// RVA: 0x191CB5C Offset: 0x191CB5C VA: 0x191CB5C
		//public void Initialize() { }

		//// RVA: 0x191C564 Offset: 0x191C564 VA: 0x191C564
		private void UpdateMesh()
		{
			float range = 128;
			if(material_ != null && material_.mainTexture != null)
			{
				if(direction_ < Direction.RightLeft)
				{
					range = uvRect.height * material_.mainTexture.height;
				}
				else
				{
					range = uvRect.width * material_.mainTexture.width;
				}
			}
			mesh_.Clear();
			vertices_.Clear();
			uvs_.Clear();
			indices.Clear();
			float width = rectTransform_.sizeDelta.x;
			float height = rectTransform_.sizeDelta.y;
			if (direction_ == Direction.RightLeft)
			{
				UpdateVertexRightLeft(width, height, range);
			}
			else if(direction_ == Direction.BottomTop)
			{
				UpdateVertexBottomTop(width, height, range);
			}
			else if(direction_ == Direction.TopBottom)
			{
				UpdateVertexTopBottom(width, height, range);
			}
			else
			{
				UpdateVertexLeftRight(width, height, range);
			}
			for(int i = 0; i < vertices_.Count; i++)
			{
				vertices_[i] = vertices_[i]
			}
		}

		//// RVA: 0x191CD10 Offset: 0x191CD10 VA: 0x191CD10
		//private void UpdateVertexTopBottom(float width, float height, float range) { }

		//// RVA: 0x191D68C Offset: 0x191D68C VA: 0x191D68C
		//private void UpdateVertexBottomTop(float width, float height, float range) { }

		//// RVA: 0x191E014 Offset: 0x191E014 VA: 0x191E014
		//private void UpdateVertexRightLeft(float width, float height, float range) { }

		//// RVA: 0x191E9C4 Offset: 0x191E9C4 VA: 0x191E9C4
		//private void UpdateVertexLeftRight(float width, float height, float range) { }
	}
}
