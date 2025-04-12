using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.UI
{
	[RequireComponent(typeof(RawImage))]
	[ExecuteInEditMode]
	public class ModifierRadarChart : LayoutUGUIScriptBase, IMeshModifier
	{
		public const int DataCountMin = 3;
		[SerializeField]
		[Range(0, 100)]
		private int m_DataCount = DataCountMin; // 0x14
		[SerializeField]
		private float m_DrawSize = 10; // 0x18
		[SerializeField]
		private Vector2[] m_UVList = new Vector2[3] { new Vector2(0.5f, 1), new Vector2(0, 0), new Vector2(1, 0) }; // 0x1C
		[SerializeField]
		private float m_AnimeTime = 0.5f; // 0x20
		private bool m_IsInisialized; // 0x24
		private Canvas m_RootCanvas; // 0x28
		private RectTransform m_RectTransform; // 0x2C
		private RawImage m_Image; // 0x30
		private List<Vector3> m_Vertices; // 0x34
		private List<Vector2> m_UVs; // 0x38
		private List<int> m_Indices; // 0x3C
		private List<float> m_Datas; // 0x40
		private List<float> m_DrawDatas; // 0x44
		private List<FloatMover> m_DataMovers; // 0x48

		private RawImage Image { get { 
			if(m_Image == null)
				m_Image = GetComponent<RawImage>();
			return m_Image;
		 } } //0x191F45C
		private Canvas RootCanvas { get {
			if(m_RootCanvas == null)
				m_RootCanvas = GetComponentInParent<Canvas>();
			return m_RootCanvas;
		} } //0x191F510
		private RectTransform Trans { get {
			if(m_RectTransform == null)
				m_RectTransform = GetComponent<RectTransform>();
			return m_RectTransform;
		} } //0x191F5C4

		// // RVA: 0x191F678 Offset: 0x191F678 VA: 0x191F678
		public void Initialize()
		{
			if(RootCanvas != null)
			{
				Trans.sizeDelta = (RootCanvas.transform as RectTransform).sizeDelta;
				Trans.anchoredPosition = new Vector2(0, 0);
			}
			m_IsInisialized = true;
			m_Vertices = new List<Vector3>();
			m_UVs = new List<Vector2>();
			m_Indices = new List<int>();
			if(m_DataCount < 3)
				m_DataCount = 3;
			m_Datas = new List<float>(m_DataCount);
			m_DrawDatas = new List<float>(m_DataCount);
			m_DataMovers = new List<FloatMover>(m_DataCount);
			for(int i = 0; i < m_DataCount; i++)
			{
				m_Datas.Add(0);
				m_DrawDatas.Add(0);
				m_DataMovers.Add(new FloatMover());
			}
			Image.SetVerticesDirty();
		}

		// RVA: 0x191FA90 Offset: 0x191FA90 VA: 0x191FA90
		private void Awake()
		{
			Initialize();
		}

		// RVA: 0x191FA94 Offset: 0x191FA94 VA: 0x191FA94
		private void Update()
		{
			if(!m_IsInisialized)
				return;
			if(RootCanvas != null)
			{
				if(Trans.anchoredPosition.x != 0 || Trans.anchoredPosition.y != 0)
				{
					Trans.sizeDelta = (RootCanvas.transform as RectTransform).sizeDelta;
					Trans.anchoredPosition = new Vector2(0, 0);
				}
			}
			//LAB_0191fcb8
			bool b = false;
			for(int i = 0; i < m_DataCount; i++)
			{
				if(m_DataMovers[i].IsMoving)
				{
					m_DataMovers[i].Update();
					m_DrawDatas[i] = m_DataMovers[i].Value;
					b = true;
				}
			}
			if(b)
			{
				Image.SetVerticesDirty();
			}
		}

		// RVA: 0x191FE74 Offset: 0x191FE74 VA: 0x191FE74 Slot: 7
		public void ModifyMesh(VertexHelper verts)
		{
			m_Vertices.Clear();
			m_UVs.Clear();
			m_Indices.Clear();
			m_Vertices.Add(Vector3.zero);
			for(int i = 0; i < m_DataCount; i++)
			{
				for(int j = 0; j <= 1; j++)
				{
					int idx = (i + j) % m_DataCount;
					float f2 = idx * 6.283185f / m_DataCount + 1.570796f;
					float f2s = Mathf.Sin(f2);
					float f2c = Mathf.Cos(f2);
					m_Vertices.Add(new Vector3(f2c * m_DrawSize * 0.5f * m_DrawDatas[idx], f2s * m_DrawSize * 0.5f * m_DrawDatas[idx]));
				}
			}
			for(int i = 0; i < m_DataCount; i++)
			{
				m_Indices.Add(0);
				m_Indices.Add(i * 2 + 1);
				m_Indices.Add(i * 2 + 2);
			}
			m_UVs.Add(m_UVList[0]);
			for(int i = 1; i < m_Vertices.Count; i++)
			{
				m_UVs.Add(m_UVList[(i - 1) % 2 + 1]);
			}
			if(Image is RawImageEx)
			{
                Rect r = (Image as RawImageEx).uvRect;
				for(int i = 0; i < m_UVs.Count; i++)
				{
					m_UVs[i] = new Vector2(r.x + m_UVs[i].x * r.width, r.y + m_UVs[i].y * r.height );
				}
            }
			for(int i = 0; i < m_Vertices.Count; i++)
			{
				m_Vertices[i] = new Vector3(Mathf.Round(m_Vertices[i].x), Mathf.Round(m_Vertices[i].y), Mathf.Round(m_Vertices[i].z)); // should be floor to zero
			}
			verts.Clear();
			for(int i = 0; i < m_Vertices.Count; i++)
			{
				verts.AddVert(m_Vertices[i], Image.color, m_UVs[i]);
			}
			for(int i = 0; i < m_DataCount; i++)
			{
				verts.AddTriangle(m_Indices[i * 3], m_Indices[i * 3 + 1], m_Indices[i * 3 + 2]);
			}
		}

		// RVA: 0x1920C04 Offset: 0x1920C04 VA: 0x1920C04 Slot: 6
		public void ModifyMesh(Mesh mesh)
		{
			return;
		}

		// // RVA: 0x1920C08 Offset: 0x1920C08 VA: 0x1920C08
		public void SetDataValue(int dataNo, float value, bool useAnime)
		{
			if(dataNo >= 0 && dataNo <= m_DataCount)
			{
				m_Datas[dataNo] = value;
				if(useAnime)
				{
					m_DrawDatas[dataNo] = value;
					Image.SetVerticesDirty();
				}
				else
				{
					m_DataMovers[dataNo].Start(m_DrawDatas[dataNo], value, m_AnimeTime, FloatMover.MoveType.Sin);
				}
			}
		}

		// RVA: 0x1920DCC Offset: 0x1920DCC VA: 0x1920DCC
		public void SetValues(float[] values, bool useAnime)
		{
			for(int i = 0; i < values.Length; i++)
			{
				SetDataValue(i, values[i], useAnime);
			}
		}

		// RVA: 0x1920E44 Offset: 0x1920E44 VA: 0x1920E44
		public bool IsMoving()
		{
			foreach(var m in m_DataMovers)
			{
				if(m.IsMoving)
					return true;
			}
			return false;
		}
	}
}
