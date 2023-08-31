using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class NoizeTexture : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private Camera m_noizeCamera; // 0xC
		[SerializeField]
		private RenderTexture m_renderTexture; // 0x10
		[SerializeField]
		private RawImage m_image; // 0x14
		private List<RawImage> m_noizeImageList = new List<RawImage>(2); // 0x18

		// RVA: 0x151AE00 Offset: 0x151AE00 VA: 0x151AE00
		public void Start()
		{
			if (m_image == null)
				return;
			m_image.material = new Material(Shader.Find("XeSys/Unlit/Transparent"));
		}

		//// RVA: 0x151AF00 Offset: 0x151AF00 VA: 0x151AF00
		public void SetRegisterImage(RawImage image)
		{
			if (image == null)
				return;
			m_noizeImageList.Add(image);
			image.texture = m_renderTexture;
		}

		// RVA: 0x151AFE8 Offset: 0x151AFE8 VA: 0x151AFE8 Slot: 4
		public void Dispose()
		{
			for(int i = 0; i < m_noizeImageList.Count; i++)
			{
				m_noizeImageList[i].texture = null;
			}
			m_noizeImageList.Clear();
		}
	}
}
