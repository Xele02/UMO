using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class StageColorChanger : MonoBehaviour
	{
		public List<Material> fakelitMaterials; // 0xC
		public Material lightMaterialA; // 0x10
		public Material lightMaterialB; // 0x14
		public Material lightMaterialC; // 0x18
		public Material psylliumMaterial; // 0x1C
		protected List<Color> fakelitColors; // 0x20
		protected Color defaultColorA; // 0x24
		protected Color defaultColorB; // 0x34
		protected Color defaultColorC; // 0x44
		protected bool m_isPsylliumMulti; // 0x54

		// RVA: 0x139DFEC Offset: 0x139DFEC VA: 0x139DFEC
		private void Awake()
		{
			List<Material> mats = new List<Material>();
			if(fakelitMaterials.Count > 0)
			{
				fakelitColors = new List<Color>(fakelitMaterials.Count);
			}
			for(int i = 0; i < fakelitMaterials.Count; i++)
			{
				if(fakelitMaterials[i] != null)
				{
					Material mat = new Material(fakelitMaterials[i]);
					fakelitMaterials[i] = mat;
					mats.Add(fakelitMaterials[i]);
					fakelitColors.Add(fakelitMaterials[i].GetColor("_Color"));
				}
			}
			if(lightMaterialA != null)
			{
				lightMaterialA = new Material(lightMaterialA);
				mats.Add(lightMaterialA);
				defaultColorA = lightMaterialA.GetColor("_Color");
			}
			if (lightMaterialB != null)
			{
				lightMaterialB = new Material(lightMaterialB);
				mats.Add(lightMaterialB);
				defaultColorB = lightMaterialB.GetColor("_Color");
			}
			if (lightMaterialC != null)
			{
				lightMaterialC = new Material(lightMaterialC);
				mats.Add(lightMaterialC);
				defaultColorC = lightMaterialC.GetColor("_Color");
			}
			if(psylliumMaterial != null)
			{
				psylliumMaterial = new Material(psylliumMaterial);
				mats.Add(psylliumMaterial);
				if(psylliumMaterial.shader.name == "MCRS/Stage/PsylliumMulti" ||
					psylliumMaterial.shader.name == "MCRS/Stage/PsylliumMulti_CullOff" ||
					psylliumMaterial.shader.name == "MCRS/Stage/PsylliumMulti5" ||
					psylliumMaterial.shader.name == "MCRS/Stage/PsylliumMulti5_CullOff")
				{
					m_isPsylliumMulti = true;
				}
			}
			Renderer[] rs = transform.GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				for(int j = 0; j < mats.Count; j++)
				{
					if(rs[i].sharedMaterial.name == mats[j].name)
					{
						rs[i].sharedMaterial = mats[j];
					}
				}
			}
		}

		// RVA: 0x139EB1C Offset: 0x139EB1C VA: 0x139EB1C Slot: 4
		public virtual void SetupPsylliumColor(List<Color> a_list)
		{
			if(psylliumMaterial != null)
			{
				if(!m_isPsylliumMulti)
				{
					Color col = psylliumMaterial.GetColor("_Color");
					psylliumMaterial.SetColor("_Color", Color.Lerp(col, a_list[0], a_list[0].a));
				}
				else
				{
					for(int i = 0; i < 3; i++)
					{
						Color col = psylliumMaterial.GetColor("_Color" + (i+1));
						int idx = i % a_list.Count;
						psylliumMaterial.SetColor("_Color", Color.Lerp(col, a_list[idx], a_list[idx].a));
					}
				}
			}
		}

		// RVA: 0x139EEF4 Offset: 0x139EEF4 VA: 0x139EEF4
		//public void UpdateColorByStageLighting(Color fakelitColor, Color lightColorA, Color lightColorB, Color lightColorC) { }
	}
}
