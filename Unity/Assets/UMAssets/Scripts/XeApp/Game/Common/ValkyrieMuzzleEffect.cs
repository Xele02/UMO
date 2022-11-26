using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieMuzzleEffect : MonoBehaviour
	{
		[SerializeField]
		private Color m_muzzleColor = Color.black; // 0xC

		public List<Renderer> targetRenderer { get; set; } // 0x1C

		// RVA: 0xD27CE4 Offset: 0xD27CE4 VA: 0xD27CE4
		private void Update()
		{
			m_muzzleColor.a = 0;
		}

		// RVA: 0xD27CF0 Offset: 0xD27CF0 VA: 0xD27CF0
		private void LateUpdate()
		{
			for(int i = 0; i < targetRenderer.Count; i++)
			{
				targetRenderer[i].material.SetColor("_MuzzleColor", m_muzzleColor);
			}
		}
	}
}
