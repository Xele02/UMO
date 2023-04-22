using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	public class SwfView : ViewBase
	{
		private bool m_IsDraw = true; // 0x78
		private float m_viewWidth; // 0x7C
		private float m_viewHeight; // 0x80
		private bool m_IsMask; // 0x84

		public string SwfId { get; set; } // 0x70
		public SwfBase swf { get; set; } // 0x74
		//public bool IsDraw { get; set; } 0x1EDF9C4 0x1EDF9CC
		//public float ViewWidth { get; set; } 0x1EDF9D4 0x1EDF9DC
		//public float ViewHeight { get; set; } 0x1EDF9E4 0x1EDF9EC
		public bool IsMask { get { return m_IsMask; } set { m_IsMask = value; } } //0x1EDF9F4 0x1EDF9FC

		// RVA: 0x1EDFA04 Offset: 0x1EDFA04 VA: 0x1EDFA04
		public SwfView()
		{
			SwfId = null;
			swf = null;
			m_DrawLayer = 0;
		}

		// RVA: 0x1EDFC70 Offset: 0x1EDFC70 VA: 0x1EDFC70 Slot: 8
		//public override void Clear() { }

		// RVA: 0x1EDFC7C Offset: 0x1EDFC7C VA: 0x1EDFC7C
		//public void SetSwfFormSwfId(SwfManager swfMan) { }

		// RVA: 0x1EDFD8C Offset: 0x1EDFD8C VA: 0x1EDFD8C Slot: 7
		public override void Update(Matrix23 parentMat, Color parentCol)
		{
			base.Update(parentMat, parentCol);
		}

		//// RVA: 0x1EDFE80 Offset: 0x1EDFE80 VA: 0x1EDFE80
		//public void ReplaceDirectTex(int hSrcImgId, TexUVList uvList, TexUVData uvData) { }

		//// RVA: 0x1EDFF1C Offset: 0x1EDFF1C VA: 0x1EDFF1C
		//public void SetMaskRect(Rect rect) { }

		//// RVA: 0x1EDFF20 Offset: 0x1EDFF20 VA: 0x1EDFF20
		public void SetMaskFromView(ViewBase view)
		{
			return;
		}

		// RVA: 0x1EDFF24 Offset: 0x1EDFF24 VA: 0x1EDFF24 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			SwfView sview = view as SwfView;
			sview.SwfId = SwfId;
			sview.swf = swf;
			sview.m_DrawLayer = m_DrawLayer;
			sview.m_IsDraw = m_IsDraw;
			sview.m_viewWidth = m_viewWidth;
			sview.m_viewHeight = m_viewHeight;
			sview.m_IsMask = m_IsMask;
		}

		// RVA: 0x1EE0214 Offset: 0x1EE0214 VA: 0x1EE0214 Slot: 11
		public override ViewBase DeepClone()
		{
			SwfView res = new SwfView();
			CopyTo(res);
			return res;
		}

		// RVA: 0x1EE0298 Offset: 0x1EE0298 VA: 0x1EE0298 Slot: 15
		//public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
