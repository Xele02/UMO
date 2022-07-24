using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageColorMulti5Changer : StageColorChanger
	{
		public Texture2D tex_black; // 0x58
		public Texture2D tex2; // 0x5C
		public Texture2D tex3; // 0x60
		public Texture2D tex5_1; // 0x64
		public Texture2D tex5_2; // 0x68

		// RVA: 0x139F434 Offset: 0x139F434 VA: 0x139F434 Slot: 4
		public override void SetupPsylliumColor(List<Color> a_list)
		{
			if(psylliumMaterial == null)
				return;
			if(!m_isPsylliumMulti)
			{
				Color col = psylliumMaterial.GetColor("_Color");
				Color newCol = Color.Lerp(col, a_list[0], a_list[0].a);
				newCol.a = col.a;
				psylliumMaterial.SetColor("_Color", newCol);
			}
			else
			{
				if(a_list.Count < 3)
				{
					psylliumMaterial.SetTexture("_PsylliumMaskTex", tex2);
					psylliumMaterial.SetTexture("_PsylliumMaskTex2", tex_black);
				}
				else if(a_list.Count == 3)
				{
					psylliumMaterial.SetTexture("_PsylliumMaskTex", tex3);
					psylliumMaterial.SetTexture("_PsylliumMaskTex2", tex_black);
				}
				else if(a_list.Count == 5)
				{
					psylliumMaterial.SetTexture("_PsylliumMaskTex", tex5_1);
					psylliumMaterial.SetTexture("_PsylliumMaskTex2", tex5_2);
				}
				for(int i = 0; i < 4; i++)
				{
					string name = "_Color"+(i+1);
					Color col = psylliumMaterial.GetColor(name);
					int idx = i;
					if(i >= a_list.Count)
						idx = 0;
					Color newCol = Color.Lerp(col, a_list[idx], a_list[idx].a);
					newCol.a = col.a;
					psylliumMaterial.SetColor(name, newCol);
				}
			}
		}
	}
}
