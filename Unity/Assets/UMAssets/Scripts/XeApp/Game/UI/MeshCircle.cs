using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.UI
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class MeshCircle : MonoBehaviour
	{
		private MeshRenderer m_renderer; // 0xC
		private MeshFilter m_filter; // 0x10
		private Mesh m_mesh; // 0x14
		private RectTransform m_rectTransform; // 0x18
		[SerializeField] // RVA: 0x68F164 Offset: 0x68F164 VA: 0x68F164
		private int m_width; // 0x1C
		[SerializeField] // RVA: 0x68F174 Offset: 0x68F174 VA: 0x68F174
		private int m_height; // 0x20
		[SerializeField] // RVA: 0x68F184 Offset: 0x68F184 VA: 0x68F184
		private float m_angleOrigin; // 0x24
		[SerializeField] // RVA: 0x68F194 Offset: 0x68F194 VA: 0x68F194
		private float m_angleEnd; // 0x28
		[SerializeField] // RVA: 0x68F1A4 Offset: 0x68F1A4 VA: 0x68F1A4
		private Rect m_uvRect; // 0x2C
		[SerializeField] // RVA: 0x68F1B4 Offset: 0x68F1B4 VA: 0x68F1B4
		private bool m_isInverse; // 0x3C
		[SerializeField] // RVA: 0x68F1C4 Offset: 0x68F1C4 VA: 0x68F1C4
		private bool m_isUseVertexColor; // 0x3D
		[SerializeField] // RVA: 0x68F1D4 Offset: 0x68F1D4 VA: 0x68F1D4
		private Color m_vertexColor = Color.white; // 0x40
		private float m_value; // 0x50
		private Vector3 m_normalizeEndPosition; // 0x54
		private const int MeshDivCount = 18;
		private const int DivisionAngle = 20;
		private List<Vector3> m_vertices = new List<Vector3>(19); // 0x60
		private List<Vector2> m_uvs = new List<Vector2>(19); // 0x64
		private List<Color> m_vertexColors = new List<Color>(19); // 0x68
		private List<int> m_indices = new List<int>(19); // 0x6C

		public Mesh Mesh { get { if(m_mesh == null) m_mesh = new Mesh(); return m_mesh; } } //0x191B4C4
		// public MeshRenderer Renderer { get; } 0x191B588
		public MeshFilter Filter { get { if(m_filter == null) m_filter = GetComponent<MeshFilter>(); return m_filter; } } //0x191B63C 
		// public float AngleOrigin { get; set; } 0x191B6F0 0x191BF90
		// public float AngleEnd { get; set; } 0x191BF98 0x191BFDC
		public float Value { get {
			return m_value;
		} set {
			value = Mathf.Clamp01(value);
			if(m_value == value)
				return;
			m_value = value;
			UpdateMesh();
		} } //0x191BFE4 0x191C028
		// public Rect UvRect { get; set; } 0x191C030 0x191C0A4
		// public bool IsInverse { get; set; } 0x191C0B4 0x191C0D0
		// public bool IsUseVertexColor { get; set; } 0x191C0D8 0x191C0F4
		// public Color VertexColor { get; set; } 0x191C0FC 0x191C170
		// public int Width { get; set; } 0x191C180 0x191C194
		// public int Height { get; set; } 0x191C19C 0x191C1B0

		// // RVA: 0x191C1B8 Offset: 0x191C1B8 VA: 0x191C1B8
		// public Vector3 GetEndVertexNormalizePosition() { }

		// RVA: 0x191C314 Offset: 0x191C314 VA: 0x191C314
		private void Awake()
		{
			Filter.mesh = Mesh;
			Mesh.MarkDynamic();
		}

		// // RVA: 0x191B734 Offset: 0x191B734 VA: 0x191B734
		public void UpdateMesh()
		{
			Mesh.Clear(true);
			m_vertices.Clear();
			m_uvs.Clear();
			m_vertexColors.Clear();
			m_indices.Clear();
			m_vertices.Add(new Vector3(0, 0, 0));
			m_uvs.Add(new Vector2(m_uvRect.x + m_uvRect.width * 0.5f, m_uvRect.y + m_uvRect.height * 0.5f));
			m_vertexColors.Add(m_vertexColor);

			float endAngle = m_angleEnd * m_value;
			int iangle = (int)(endAngle);
			int a = iangle + DivisionAngle;
			int numDivision = a / DivisionAngle;
			if(a > -DivisionAngle)
			{
				for(int i = 0; i < numDivision + 1; i++)
				{
					float curAngle = endAngle / numDivision * i + m_angleOrigin;
					if(m_isInverse)
						curAngle *= -1;
					float c = Mathf.Cos(curAngle * 0.01745329f);
					float s = Mathf.Sin(curAngle * 0.01745329f);
					float f1 = c * 0 - s * -1;
					float f2 = s * 0 + c * -1;
					m_vertices.Add(new Vector3(f1 * m_width / 2, f2 * m_height / 2, 0));
					m_uvs.Add(new Vector2(m_uvRect.x + (f1 + 1) * 0.5f * m_uvRect.width, m_uvRect.y + (f2 + 1) * 0.5f * m_uvRect.height));
					m_vertexColors.Add(m_vertexColor);
				}
			}
			if(!m_isInverse)
			{
				for(int i = 0; i < numDivision; i++)
				{
					m_indices.Add(0);
					m_indices.Add(i + 2);
					m_indices.Add(i + 1);
				}
			}
			else if(a > 19)
			{
				for(int i = 0; i < numDivision; i++)
				{
					m_indices.Add(0);
					m_indices.Add(i + 1);
					m_indices.Add(i + 2);
				}
			}
			Mesh.SetVertices(m_vertices);
			Mesh.SetUVs(0, m_uvs);
			if(m_isUseVertexColor)
			{
				Mesh.SetColors(m_vertexColors);
			}
			Mesh.SetTriangles(m_indices, 0);
		}
	}
}
