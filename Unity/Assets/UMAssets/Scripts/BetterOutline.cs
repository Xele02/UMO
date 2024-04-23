
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Looks like a evolved version of https://github.com/sakope/BetterOutline/blob/master/BetterOutline.cs
[AddComponentMenu("UI/Better Outline")] // RVA: 0x637178 Offset: 0x637178 VA: 0x637178
[RequireComponent(typeof(Text))] // RVA: 0x637178 Offset: 0x637178 VA: 0x637178
public class BetterOutline : Shadow
{
	// RVA: 0x18F0898 Offset: 0x18F0898 VA: 0x18F0898 Slot: 20
	public override void ModifyMesh(VertexHelper vh)
	{
		if(IsActive())
		{
			List<UIVertex> verts = new List<UIVertex>();
			vh.GetUIVertexStream(verts);
			int start;
			int end = 0;
			for(int i = -1; i < 2; i++)
			{
				for(int j = -1; j < 2; j++)
				{
					if(i != 0 && j != 0)
					{
						start = end;
						end = verts.Count;
						ApplyShadowZeroAlloc(verts, effectColor, start, end, effectDistance.x * i * 0.707f, effectDistance.y * j * 0.707f);
					}
				}
			}
			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc(verts, effectColor, start, end, -effectDistance.x, 0);
			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc(verts, effectColor, start, end, effectDistance.x, 0);
			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc(verts, effectColor, start, end, 0, -effectDistance.y);
			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc(verts, effectColor, start, end, 0, effectDistance.y);
			if(GetComponent<Text>().material.shader == Shader.Find("Text Effects/Fancy Text"))
			{
				TodoLogger.LogError(TodoLogger.Shader, "Todo better outline");
			}
            vh.Clear();
            vh.AddUIVertexTriangleStream(verts);
		}
	}
}
