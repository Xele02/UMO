using System.Collections.Generic;
using UnityEngine;

namespace XeApp
{
	public class DecorationZoomController : DecorationControllerBase
	{
		private float m_max = 1; // 0x14
		private float m_min = 1; // 0x18
		private DecorationScrollController m_scrollController; // 0x1C
		private float m_startScaleFactor; // 0x20
		private bool m_isAutoZoomOut; // 0x24
		private float m_autoZoomTimer; // 0x28

		// RVA: 0xBB53E0 Offset: 0xBB53E0 VA: 0xBB53E0
		public DecorationZoomController(List<ControlData> settings, DecorationZoomControllerArgs args) : base(settings, args)
		{
			m_max = args.m_zoomMax;
			m_scrollController = args.m_scrollController;
			m_max = args.m_screenRect.width / args.m_zoomRect.width;
			m_min = m_max;
			SetScale(m_max);
		}

		// RVA: 0xBB56F8 Offset: 0xBB56F8 VA: 0xBB56F8 Slot: 6
		public override void Update()
		{
			return;
		}

		// // RVA: 0xBB56FC Offset: 0xBB56FC VA: 0xBB56FC
		// private void PinchZoom() { }

		// // RVA: 0xBB5BE0 Offset: 0xBB5BE0 VA: 0xBB5BE0
		// private void AutoZoomOutUpdate() { }

		// // RVA: 0xBB5CB4 Offset: 0xBB5CB4 VA: 0xBB5CB4
		public void AutoZoomOut()
		{
			m_autoZoomTimer = 0;
			m_isAutoZoomOut = true;
			foreach(var k in m_controlDataList)
			{
				m_startScaleFactor = k.scaler.scaleFactor;
			}
		}

		// // RVA: 0xBB59D4 Offset: 0xBB59D4 VA: 0xBB59D4
		// private void AddScale(float scaling) { }

		// // RVA: 0xBB54B4 Offset: 0xBB54B4 VA: 0xBB54B4
		private void SetScale(float scale)
		{
			foreach(var c in m_controlDataList)
			{
				c.scaler.scaleFactor = Mathf.Clamp(scale, m_min, m_max);
			}
			m_scrollController.Translate(Vector3.zero);
		}
	}
}
