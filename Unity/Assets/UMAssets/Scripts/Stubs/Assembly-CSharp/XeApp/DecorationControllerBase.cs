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
			public CanvasScaler scaler;
			public RectTransform transform;
		}

		public DecorationControllerBase(List<DecorationControllerBase.ControlData> setting, DecorationControlArgs args)
		{
		}

	}
}
