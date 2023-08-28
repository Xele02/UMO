using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ToJShadow : BaseMeshEffect
{
	[SerializeField]
	private Color m_EffectColor = new Color(0, 0, 0, 0.5f); // 0x10
	[SerializeField]
	private Vector2 m_EffectDistance = new Vector2(1, -1); // 0x20
	[SerializeField]
	private bool m_UseGraphicAlpha = true; // 0x28

	//public Color effectColor { get; set; } 0xE071F8 0xE07208
	//public Vector2 effectDistance { get; set; } 0xE072FC 0xE07310
	//public bool useGraphicAlpha { get; set; } 0xE074C0 0xE074C8

	//// RVA: 0xE075A4 Offset: 0xE075A4 VA: 0xE075A4
	protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
	{
		if (verts.Capacity - (2 * verts.Count) < 0)
		{
			verts.Capacity = verts.Count * 2;
		}
		for(; start < end; start++)
		{
			UIVertex v = verts[start];
			verts.Add(v);
			if(m_UseGraphicAlpha)
			{
				v.color.a = color.a;
			}
			v.position.x += x;
			v.position.y += y;
			verts[start] = v;
		}
	}

	//// RVA: 0xE07A78 Offset: 0xE07A78 VA: 0xE07A78
	protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
	{
		if(verts.Capacity - (2 * verts.Count) < 0)
		{
			verts.Capacity = verts.Count * 2;
		}
		ApplyShadowZeroAlloc(verts, color, start, end, x, y);
	}

	// RVA: 0xE07BB0 Offset: 0xE07BB0 VA: 0xE07BB0 Slot: 20
	public override void ModifyMesh(VertexHelper vh)
	{
		if(IsActive())
		{
			List<UIVertex> verts = new List<UIVertex>();
			vh.GetUIVertexStream(verts);
			ApplyShadow(verts, m_EffectColor, 0, verts.Count, m_EffectDistance.x, m_EffectDistance.y);
			Text txt = GetComponent<Text>();
			if(txt != null)
			{
				if(txt.material.shader == Shader.Find("Text Effects/Fancy Text"))
				{
					TodoLogger.LogError(0, "ModifyMesh");
				}
			}
			vh.Clear();
			vh.AddUIVertexTriangleStream(verts);
		}
	}
}
