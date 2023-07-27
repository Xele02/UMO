using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Tutorial
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RawImage))]
	public class TutorialHighLight : MonoBehaviour, IMeshModifier
	{
		private List<UIVertex> _vertex = new List<UIVertex>(8); // 0xC
		private RawImage _rawImage; // 0x10
		[SerializeField] // RVA: 0x6626EC Offset: 0x6626EC VA: 0x6626EC
		private Rect _highLightRect; // 0x14

		private RawImage Image { get {
				if (_rawImage == null)
					_rawImage = GetComponent<RawImage>();
				return _rawImage;
			} } //0xE44894
		//public Rect HighLightRect { get; set; } 0xE44948 0xE416B0

		//// RVA: 0xE44958 Offset: 0xE44958 VA: 0xE44958
		private void UpdateVertex()
		{
			Canvas c = GetComponentInParent<Canvas>();
			RectTransform canvasT = c.transform as RectTransform;
			Vector2 canvasSize_ = canvasT.sizeDelta;
			Vector4 v7 = new Vector4(canvasSize_.x, 0, 0, 0);
			Vector2 canvasPivot_ = canvasT.pivot;
			Vector4 v6 = new Vector4(v7.x, v7.y, canvasPivot_.x, 0);
			Vector2 v8 = new Vector2(v6.x * -v6.z, -(canvasSize_.y * canvasPivot_.y));
			Vector3 v11 = new Vector3(v6.y, v6.z, v6.w);
			Vector4 v5 = new Vector4(canvasSize_.x, v11.x, v11.y, v11.z);
			Vector4 v4 = new Vector4(v5.x, v5.y, canvasPivot_.x, v5.w);
			Vector2 v9 = new Vector2(v4.x * v4.z, canvasSize_.y * canvasPivot_.y);
			Vector3 v12 = new Vector3(v4.y, v4.z, v4.w);
			Vector2 topLeft = new Vector2(_highLightRect.x, _highLightRect.yMax);
			Vector2 bottomRight = new Vector2(_highLightRect.xMax, v4.x - _highLightRect.height);
			Vector4 v3 = new Vector4(canvasSize_.x, v12.x, v12.y, v12.z);
			Vector4 v2 = new Vector4(v3.x, v3.y, canvasPivot_.x, v3.w);
			Vector2 v10 = new Vector2(v2.x * v2.z, canvasSize_.y * canvasPivot_.y);
			Vector3 v1 = new Vector3(v10.y, v2.w, 0);
			Rect r2 = new Rect(-v1.x, -v1.y, canvasSize_.x, canvasSize_.y);
			if (v1.x < r2.x)
				topLeft.x = r2.x;
			if (r2.y <= v1.x)
				topLeft.y = r2.y;
			if (r2.xMax <= v1.x)
				bottomRight.x = r2.xMax;
			if (v1.x < r2.yMax)
				bottomRight.y = r2.yMax;
			_vertex.Clear();
			_vertex.Add(new UIVertex() { position = v8 });
			_vertex.Add(new UIVertex() { position = new Vector3(v9.x, v8.y, 0) });
			_vertex.Add(new UIVertex() { position = new Vector3(v8.x, v9.y, 0) });
			_vertex.Add(new UIVertex() { position = v9 });
			_vertex.Add(new UIVertex() { position = new Vector3(topLeft.x, bottomRight.y, 0) });
			_vertex.Add(new UIVertex() { position = new Vector3(bottomRight.x, bottomRight.y, 0) });
			_vertex.Add(new UIVertex() { position = new Vector3(topLeft.x, topLeft.y, 0) });
			_vertex.Add(new UIVertex() { position = new Vector3(bottomRight.x, topLeft.y, 0) });
		}

		// RVA: 0xE45938 Offset: 0xE45938 VA: 0xE45938 Slot: 5
		public void ModifyMesh(VertexHelper verts)
		{
			UpdateVertex();
			verts.Clear();
			for(int i = 0; i < _vertex.Count; i++)
			{
				verts.AddVert(_vertex[i].position, Image.color, new Vector2(0, 0));
			}
			verts.AddTriangle(0, 1, 4);
			verts.AddTriangle(1, 5, 4);
			verts.AddTriangle(1, 3, 5);
			verts.AddTriangle(5, 3, 7);
			verts.AddTriangle(7, 3, 6);
			verts.AddTriangle(6, 3, 2);
			verts.AddTriangle(0, 4, 2);
			verts.AddTriangle(4, 6, 2);
		}

		// RVA: 0xE45CB4 Offset: 0xE45CB4 VA: 0xE45CB4 Slot: 4
		public void ModifyMesh(Mesh mesh)
		{
			return;
		}

		//// RVA: 0xE45CB8 Offset: 0xE45CB8 VA: 0xE45CB8
		//public void SetRect(RectTransform rt) { }
	}
}
