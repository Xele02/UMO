using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ColorGroup : Graphic
	{
		//[HeaderAttribute] // RVA: 0x6884D0 Offset: 0x6884D0 VA: 0x6884D0
		[SerializeField] // RVA: 0x6884D0 Offset: 0x6884D0 VA: 0x6884D0
		private List<Graphic> m_targets; // 0x48
		private List<Color> m_colorCaches = new List<Color>(); // 0x4C

		// RVA: 0xE65D24 Offset: 0xE65D24 VA: 0xE65D24 Slot: 6
		protected override void Start()
		{
			base.Start();
			raycastTarget = false;
			RegisterDirtyMaterialCallback(this.OnUpdateColor);
			m_colorCaches.Clear();
			for(int i = 0; i < m_targets.Count; i++)
			{
				m_colorCaches.Add(m_targets[i].color);
			}
		}

		// RVA: 0xE65EE8 Offset: 0xE65EE8 VA: 0xE65EE8 Slot: 44
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			base.OnPopulateMesh(vh);
			vh.Clear();
		}

		// RVA: 0xE65F1C Offset: 0xE65F1C VA: 0xE65F1C
		public void OnUpdateColor()
		{
			for(int i = 0; i < m_targets.Count; i++)
			{
				m_targets[i].color = m_colorCaches[i] * color;
			}
		}
	}
}
