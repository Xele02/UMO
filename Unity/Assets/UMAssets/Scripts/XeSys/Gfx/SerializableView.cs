using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	[Serializable]
	public class SerializableView
	{
		public enum ViewType
		{
			AbsoluteLayout = 0,
			ImageView = 1,
			ImageButton = 2,
			TextView = 3,
			ScrollText = 4,
			EditText = 5,
			Swf = 6,
			ScrollView = 7,
			ModelView = 8,
			AutoScrollView = 9,
			MaskView = 10,
			ScrollBar = 11,
		}

		public int index;
		public ViewType viewType;
		public ViewBase.EAnimType animType;
		public ViewFrameAnimation viewFrameAnim;
		public int parentIndex;
		public string id;
		public string exId;
		public string animId;
		public ViewTransformData transformData;
		public ViewBase.EAlignH alignH;
		public ViewBase.EAlignV alignV;
		public ViewBase.EBlendType blendType;
		public string label;
		public int tag;
		public Color color;
		public Color currentColor;
		public bool enabled;
		public bool isOutScreenUpdate;
		public bool isTouchCheck;
		public int drawLayer;
		public List<int> exInteger;
		public List<float> exFloat;
		public List<string> exString;
	}
}
