using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieDamageEffect : MonoBehaviour
	{
		[SerializeField]
		private Color m_damageColor = Color.black; // 0xC

		public List<Renderer> targetRenderer { get; set; } // 0x1C

		// RVA: 0x1CDF78C Offset: 0x1CDF78C VA: 0x1CDF78C
		private void OnDisable()
		{
			Debug.Log("ValkyrieDamageEffect.OnDisable");
			ApplyColor(Color.black);
		}

		// RVA: 0x1CDF990 Offset: 0x1CDF990 VA: 0x1CDF990
		private void LateUpdate()
		{
			ApplyColor(m_damageColor);
		}

		//// RVA: 0x1CDF848 Offset: 0x1CDF848 VA: 0x1CDF848
		private void ApplyColor(Color color)
		{
			for(int i = 0; i < targetRenderer.Count; i++)
			{
				targetRenderer[i].material.SetColor("_DamageColor", color);
			}
		}
	}
}
