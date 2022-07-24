using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageColorMultiChanger : StageColorChanger
	{
		public Texture2D tex2; // 0x58
		public Texture2D tex3; // 0x5C

		// RVA: 0x139F964 Offset: 0x139F964 VA: 0x139F964 Slot: 4
		public override void SetupPsylliumColor(List<Color> a_list)
		{
			if(m_isPsylliumMulti)
			{
				if(a_list.Count < 3)
				{
					psylliumMaterial.SetTexture("_PsylliumMaskTex", tex2);
				}
				else
				{
					psylliumMaterial.SetTexture("_PsylliumMaskTex", tex3);
				}
			}
			base.SetupPsylliumColor(a_list);
		}
	}
}
