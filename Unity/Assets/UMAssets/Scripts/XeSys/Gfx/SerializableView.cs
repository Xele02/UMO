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

		public int index; // 0x8
		public SerializableView.ViewType viewType; // 0xC
		public ViewBase.EAnimType animType; // 0x10
		public ViewFrameAnimation viewFrameAnim = new ViewFrameAnimation(); // 0x14
		public int parentIndex; // 0x18
		public string id; // 0x1C
		public string exId; // 0x20
		public string animId; // 0x24
		public ViewTransformData transformData = new ViewTransformData(); // 0x28
		public ViewBase.EAlignH alignH; // 0x2C
		public ViewBase.EAlignV alignV; // 0x30
		public ViewBase.EBlendType blendType; // 0x34
		public string label; // 0x38
		public int tag; // 0x3C
		public Color color; // 0x40
		public Color currentColor; // 0x50
		public bool enabled; // 0x60
		public bool isOutScreenUpdate; // 0x61
		public bool isTouchCheck; // 0x62
		public int drawLayer; // 0x64
		public List<int> exInteger = new List<int>(); // 0x68
		public List<float> exFloat = new List<float>(); // 0x6C
		public List<string> exString = new List<string>(); // 0x70
		private const int EX_INT_IDX = 0;
		private const int EX_FLT_IDX = 1;
		private const int EX_STR_IDX = 2;
		private int[] popIndex = new int[3]; // 0x74

		// // RVA: 0x1F14E08 Offset: 0x1F14E08 VA: 0x1F14E08
		// private void AddEx(int i) { }

		// // RVA: 0x1F14E88 Offset: 0x1F14E88 VA: 0x1F14E88
		// public void AddEx(float f) { }

		// // RVA: 0x1F14F08 Offset: 0x1F14F08 VA: 0x1F14F08
		// public void AddEx(bool b) { }

		// // RVA: 0x1F14F88 Offset: 0x1F14F88 VA: 0x1F14F88
		// public void AddEx(string s) { }

		// // RVA: 0x1F15020 Offset: 0x1F15020 VA: 0x1F15020
		// private void SerializeViewBase(List<SerializableView> list, ViewBase view, int parent) { }

		// // RVA: 0x1F153D0 Offset: 0x1F153D0 VA: 0x1F153D0
		// public void Serialize(List<SerializableView> list, AbsoluteLayout view, int parent) { }

		// // RVA: 0x1F15410 Offset: 0x1F15410 VA: 0x1F15410
		// public void SerializeChildren(List<SerializableView> list, AbsoluteLayout view) { }

		// // RVA: 0x1F14D38 Offset: 0x1F14D38 VA: 0x1F14D38
		// public void Serialize(List<SerializableView> list, ScrollView view, int parent) { }

		// // RVA: 0x1F154B4 Offset: 0x1F154B4 VA: 0x1F154B4
		// private void SerializeScrollView(ScrollView view) { }

		// // RVA: 0x1F1557C Offset: 0x1F1557C VA: 0x1F1557C
		private void DeserializeScrollView(ScrollView view)
		{
			view.ScrollBarV.BarImageName = PopEx("");
			view.ScrollBarV.ImageName = PopEx("");
			view.ScrollBarH.BarImageName = PopEx("");
			view.ScrollBarH.ImageName = PopEx("");
			view.IsTouchSimple = PopEx(0) != 0;
		}

		// // RVA: 0x1F1590C Offset: 0x1F1590C VA: 0x1F1590C
		// public void Serialize(List<SerializableView> list, AutoScrollView view, int parent) { }

		// // RVA: 0x1F15B10 Offset: 0x1F15B10 VA: 0x1F15B10
		// public void DeserializeAutoScrollView(AutoScrollView view) { }

		// // RVA: 0x1F15FAC Offset: 0x1F15FAC VA: 0x1F15FAC
		// public void Serialize(List<SerializableView> list, TextView view, int parent) { }

		// // RVA: 0x1F15FE4 Offset: 0x1F15FE4 VA: 0x1F15FE4
		// private void SerializeTextView(TextView view) { }

		// // RVA: 0x1F16154 Offset: 0x1F16154 VA: 0x1F16154
		private void DeserializeTextView(TextView view)
		{
			view.TextSize = PopEx(0);
			view.TextAlignH = (ViewBase.EAlignH)PopEx(0);
			view.TextAlignV = (ViewBase.EAlignV)PopEx(0);
			view.TextId = PopEx("");
			view.Text = PopEx("");
			view.WordWrap = PopEx(false);
			view.IsMask = PopEx(false);
			view.FontSize = PopEx(0);
			view.LineSpace = PopEx(0.0f);
		}

		// // RVA: 0x1F1643C Offset: 0x1F1643C VA: 0x1F1643C
		// public void Serialize(List<SerializableView> list, EditTextView view, int parent) { }

		// // RVA: 0x1F121C4 Offset: 0x1F121C4 VA: 0x1F121C4
		// public void Serialize(List<SerializableView> list, ScrollText view, int parent) { }

		// // RVA: 0x1F1653C Offset: 0x1F1653C VA: 0x1F1653C
		// public void Serialize(List<SerializableView> list, ImageView view, int parent) { }

		// // RVA: 0x1F16574 Offset: 0x1F16574 VA: 0x1F16574
		// private void SerializeImageView(ImageView view) { }

		// // RVA: 0x1F16718 Offset: 0x1F16718 VA: 0x1F16718
		private void DeserializeImageView(ImageView view)
		{
			view.ImageName = PopEx("");
			view.IsRender = PopEx(false);
			view.IsFlipX = PopEx(false);
			view.IsFlipY = PopEx(false);
			view.IsDraw = PopEx(false);
			view.ViewWidth = PopEx(0.0f);
			view.ViewHeight = PopEx(0.0f);
			view.IsMask = PopEx(false);
		}

		// // RVA: 0x1F16A08 Offset: 0x1F16A08 VA: 0x1F16A08
		// public void Serialize(List<SerializableView> list, ImageButton view, int parent) { }

		// // RVA: 0x1F0A994 Offset: 0x1F0A994 VA: 0x1F0A994
		// public void Serialize(List<SerializableView> list, MaskView view, int parent) { }

		// // RVA: 0x1F0CDA4 Offset: 0x1F0CDA4 VA: 0x1F0CDA4
		// public void Serialize(List<SerializableView> list, ModelView view, int parent) { }

		// // RVA: 0x1F1180C Offset: 0x1F1180C VA: 0x1F1180C
		// public void Serialize(List<SerializableView> list, ScrollBar view, int parent) { }

		// // RVA: 0x1F16A40 Offset: 0x1F16A40 VA: 0x1F16A40
		// public void Serialize(List<SerializableView> list, SwfView view, int parent) { }

		// // RVA: 0x1F16A94 Offset: 0x1F16A94 VA: 0x1F16A94
		private void DeserializeViewBase(List<SerializableView> list, ViewBase view)
		{
			view.AnimType = animType;
			viewFrameAnim.CopyTo(view.FrameAnimation);
			view.ID = id;
			view.EXID = exId;
			view.AnimID = animId;
			transformData.CopyTo(view.TransformData);
			view.AlignH = alignH;
			view.AlignV = alignV;
			view.BlendType = blendType;
			view.Label = label;
			view.Tag = tag;
			view.col = color;
			view.currentCol = currentColor;
			view.enabled = enabled;
			view.IsOutScreenUpdate = isOutScreenUpdate;
			view.IsTouchCheck = isTouchCheck;
			view.DrawLayer = drawLayer;
			for(int i = 0; i < popIndex.Length; i++)
			{
				popIndex[i] = 0;
			}
		}

		// // RVA: 0x1F15DC4 Offset: 0x1F15DC4 VA: 0x1F15DC4
		private int PopEx()
		{
			int value = exInteger[popIndex[0]];
			popIndex[0] = popIndex[0] + 1;
			return value;
		}

		// // RVA: 0x1F16438 Offset: 0x1F16438 VA: 0x1F16438
		private int PopEx(int i)
		{
			return PopEx();
		}

		// // RVA: 0x1F15EB8 Offset: 0x1F15EB8 VA: 0x1F15EB8
		public float PopEx(float f)
		{
			float value = exFloat[popIndex[1]];
			popIndex[1] = popIndex[1] + 1;
			return value;
		}

		// // RVA: 0x1F158F4 Offset: 0x1F158F4 VA: 0x1F158F4
		public bool PopEx(bool b)
		{
			return PopEx(0) != 0;
		}

		// // RVA: 0x1F15778 Offset: 0x1F15778 VA: 0x1F15778
		public string PopEx(string s)
		{
			string value = exString[popIndex[2]];
			if(value == " ")
				value = null;

			popIndex[2] = popIndex[2] + 1;
			return value;
		}

		// // RVA: 0x1F11294 Offset: 0x1F11294 VA: 0x1F11294
		public int Deserialize(List<SerializableView> list, Layout layout)
		{
			DeserializeViewBase(list, layout.Root);
			return DeserializeChildren(list, layout.Root, layout);
		}

		// // RVA: 0x1F16E80 Offset: 0x1F16E80 VA: 0x1F16E80
		private int DeserializeChildren(List<SerializableView> list, AbsoluteLayout view, Layout layout)
		{
			int curIndex = index + 1;
			while(true)
			{
				if(list.Count <= (curIndex))
					return curIndex;
				SerializableView item = list[curIndex];
				if(item.parentIndex != index)
					return curIndex;
				ViewBase newView = null;
				switch(item.viewType)
				{
					case ViewType.AbsoluteLayout:
					{
						newView = new AbsoluteLayout();
						item.DeserializeViewBase(null, newView);
						view.AddView(newView);
						view.AddXmlChildView(newView);
						curIndex = item.DeserializeChildren(list, newView as AbsoluteLayout, layout);
					}
					break;
					case ViewType.ImageView:
					{
						newView = new ImageView();
						item.DeserializeViewBase(null, newView);
						item.DeserializeImageView(newView as ImageView);
						view.AddView(newView);
						view.AddXmlChildView(newView);
						curIndex = curIndex + 1;
					}
					break;
					case ViewType.TextView:
					{
						newView = new TextView();
						(newView as TextView).InitFont(layout.fontInfo);
						item.DeserializeViewBase(null, newView);
						item.DeserializeTextView(newView as TextView);
						view.AddView(newView);
						view.AddXmlChildView(newView);
						curIndex = curIndex + 1;
					}
					break;
					case ViewType.MaskView:
					{
						newView = new MaskView();
						item.DeserializeViewBase(null, newView);
						(newView as MaskView).ImageName = item.PopEx("");
						(newView as MaskView).IsFlipX = item.PopEx(false);
						(newView as MaskView).IsFlipY = item.PopEx(false);
						view.AddView(newView);
						view.AddXmlChildView(newView);
						curIndex = item.DeserializeChildren(list, newView as AbsoluteLayout, layout);
					}
					break;
					case ViewType.ScrollView:
					{
						newView = new ScrollView();
						item.DeserializeViewBase(null, newView);
						item.DeserializeScrollView(newView as ScrollView);
						view.AddView(newView);
						view.AddXmlChildView(newView);
						curIndex = item.DeserializeChildren(list, newView as AbsoluteLayout, layout);
					}
					break;
					default:
						TodoLogger.LogError(0, "Implement DeserializeChildren "+item.viewType.ToString());
						return curIndex;
				}
			}
		}
	}
}
