using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp
{
	public class DecorationControllerBase
	{ 
		public struct ControlData
		{
			public CanvasScaler scaler; // 0x0
			public RectTransform transform; // 0x4
		}

		public List<ControlData> m_controlDataList = new List<ControlData>(); // 0x8
		public DecorationControlArgs m_args; // 0x10

		public virtual bool Active { protected get; set; } // 0xC

		// RVA: 0x1AD01DC Offset: 0x1AD01DC VA: 0x1AD01DC
		public DecorationControllerBase(List<ControlData> setting, DecorationControlArgs args)
		{
			m_controlDataList = setting;
			m_args = args;
			Active = false;
		}

		//// RVA: 0x1AD02A0 Offset: 0x1AD02A0 VA: 0x1AD02A0 Slot: 6
		public virtual void Update()
		{
			return;
		}
	}
}
