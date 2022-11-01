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
		private readonly int[] baseTriangle = new int[6] { 0, 2, 1, 1, 2, 3 }; // 0x40
		private float value_ = 0.5f; // 0x44

		//public Rect UvRect { get; set; } 0x191C4E0 0x191C4F0
		//public Material Material { get; set; } 0x191CA54 0x191CA5C
		//public MeshTile.Direction Type { get; set; } 0x191CB1C 0x191CB24
		public float Value { get { return value_; } set { value_ = value; UpdateMesh(); } } //0x191CB38 0x191CB40

		//// RVA: 0x191CB5C Offset: 0x191CB5C VA: 0x191CB5C
		public void Initialize()
		{
			filter_ = GetComponent<MeshFilter>();
			renderer_ = GetComponent<MeshRenderer>();
			rectTransform_ = GetComponent<RectTransform>();
			vertices_ = new List<Vector3>(192);
			uvs_ = new List<Vector2>(192);
			mesh_ = new Mesh();filter_.mesh = mesh_;
			renderer_.material = material_;
			UpdateMesh();
		}

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
				vertices_[i] = new Vector3(vertices_[i].x - width * rectTransform_.pivot.x, vertices_[i].y - height * rectTransform_.pivot.y, vertices_[i].z);
			}
			mesh_.SetVertices(vertices_);
			mesh_.SetUVs(0, uvs_);
			mesh_.SetTriangles(indices, 0);
		}

		//// RVA: 0x191CD10 Offset: 0x191CD10 VA: 0x191CD10
		private void UpdateVertexTopBottom(float width, float height, float range)
		{
			float f = value_ * height / range;
			int fi = Mathf.FloorToInt(f);
			int cnt = 0;
			for (int i = 0; i < fi; i++)
			{
				vertices_.Add(new Vector3(0, i * range, 0));
				vertices_.Add(new Vector3(width, i * range, 0));
				vertices_.Add(new Vector3(0, i * range + range, 0));
				vertices_.Add(new Vector3(width, i * range + range, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + i * 4);
				}
				cnt = i;
			}
			f = f - fi;
			if (f >= 0)
			{
				vertices_.Add(new Vector3(0, cnt * range, 0));
				vertices_.Add(new Vector3(width, cnt * range, 0));
				vertices_.Add(new Vector3(0, cnt * range + f * range, 0));
				vertices_.Add(new Vector3(width, cnt * range + f * range, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + cnt * 4);
				}
			}
		}

		//// RVA: 0x191D68C Offset: 0x191D68C VA: 0x191D68C
		private void UpdateVertexBottomTop(float width, float height, float range)
		{
			float f = value_ * height / range;
			int fi = Mathf.FloorToInt(f);
			int cnt = 0;
			for (int i = 0; i < fi; i++)
			{
				vertices_.Add(new Vector3(0, (height - range) - i * range, 0));
				vertices_.Add(new Vector3(width, (height - range) - i * range, 0));
				vertices_.Add(new Vector3(0, height - i * range, 0));
				vertices_.Add(new Vector3(width, height - i * range, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + i * 4);
				}
				cnt = i;
			}
			f = f - fi;
			if (f >= 0)
			{
				vertices_.Add(new Vector3(0, (height - cnt * range) - f * range, 0));
				vertices_.Add(new Vector3(width, (height - cnt * range) - f * range, 0));
				vertices_.Add(new Vector3(0, (height - cnt * range), 0));
				vertices_.Add(new Vector3(width, (height - cnt * range), 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + cnt * 4);
				}
			}
		}

		//// RVA: 0x191E014 Offset: 0x191E014 VA: 0x191E014
		private void UpdateVertexRightLeft(float width, float height, float range)
		{
			float f = value_ * width / range;
			int fi = Mathf.FloorToInt(f);
			int cnt = 0;
			for(int i = 0; i < fi; i++)
			{
				vertices_.Add(new Vector3(i * range, 0, 0));
				vertices_.Add(new Vector3(i * range + range, 0, 0));
				vertices_.Add(new Vector3(i * range, height, 0));
				vertices_.Add(new Vector3(i * range + range, height, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height));
				for(int j = 0; j  < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + i * 4);
				}
				cnt = i;
			}
			f = f - fi;
			if(f >= 0)
			{
				vertices_.Add(new Vector3(cnt * range, 0, 0));
				vertices_.Add(new Vector3(cnt * range + f * range, 0, 0));
				vertices_.Add(new Vector3(cnt * range, height, 0));
				vertices_.Add(new Vector3(cnt * range + f * range, height, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + cnt * 4);
				}
			}
		}

		//// RVA: 0x191E9C4 Offset: 0x191E9C4 VA: 0x191E9C4
		private void UpdateVertexLeftRight(float width, float height, float range)
		{
			float f = value_ * width / range;
			int fi = Mathf.FloorToInt(f);
			int cnt = 0;
			for (int i = 0; i < fi; i++)
			{
				vertices_.Add(new Vector3((width - range) - i * range, 0, 0));
				vertices_.Add(new Vector3(width - i * range, 0, 0));
				vertices_.Add(new Vector3((width - range) - i * range, height, 0));
				vertices_.Add(new Vector3(width - i * range, height, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + i * 4);
				}
				cnt = i;
			}
			f = f - fi;
			if (f >= 0)
			{
				vertices_.Add(new Vector3(width - cnt * range - f * range, 0, 0));
				vertices_.Add(new Vector3(width - cnt * range, 0, 0));
				vertices_.Add(new Vector3(width - cnt * range - f * range, height, 0));
				vertices_.Add(new Vector3(width - cnt * range, height, 0));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y));
				uvs_.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
				uvs_.Add(new Vector2(uvRect.x + f * uvRect.width, uvRect.y + uvRect.height));
				for (int j = 0; j < baseTriangle.Length; j++)
				{
					indices.Add(baseTriangle[j] + cnt * 4);
				}
			}
		}
	}
}
