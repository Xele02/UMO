using UnityEngine;

namespace XeSys.Gfx
{
	public delegate void onTouchBegin(ViewBase v, TouchInfo touchInfo);
	public delegate void onTouchMove(ViewBase v, TouchInfo touchInfo);
	public delegate void onTouchEnd(ViewBase v, TouchInfo touchInfo);

	public class ImageView : ViewBase
	{
		private onTouchBegin m_onTouchBeginDelegate; // 0x70
		private onTouchMove m_onTouchMoveDelegate; // 0x74
		private onTouchEnd m_onTouchEndDelegate; // 0x78
		private string m_ImageName; // 0x7C
		private TexUVList m_Tex; // 0x80
		private TexUVData m_UVData; // 0x84
		protected bool m_IsInitTexture; // 0x88
		private bool m_IsRender = true; // 0x89
		private bool m_IsFlipX; // 0x8A
		private bool m_IsFlipY; // 0x8B
		protected bool m_IsDraw = true; // 0x8C
		private float m_viewWidth; // 0x90
		private float m_viewHeight; // 0x94
		protected bool m_IsMask; // 0x98

		// public onTouchBegin onTouchBeginDelegate { get; set; } 0x20493EC 0x20493F4
		// public onTouchMove onTouchMoveDelegete { get; set; } 0x20493FC 0x2049404
		// public onTouchEnd onTouchEndDelegete { get; set; } 0x204940C 0x2049414
		public string ImageName { get { return m_ImageName; } set { m_ImageName = value; } } //0x203F420 0x204941C
		public TexUVList Tex { get { return m_Tex; } set { m_Tex = value; } } //0x2048BBC 0x2049424
		public TexUVData UVData { get { return m_UVData; } set { m_UVData = value; } } //0x204942C 0x2049434
		public bool IsRender { get { return m_IsRender; } set { m_IsRender = value; } } //0x204943C 0x2049444
		public override bool IsVisible { get { return base.IsVisible && m_IsRender; } } //0x204944C 
		public bool IsFlipX { get { return m_IsFlipX; } set { m_IsFlipX = value; } } //0x2049474 0x204947C
		public bool IsFlipY { get { return m_IsFlipY; } set { m_IsFlipY = value; } } //0x2049484 0x204948C
		public bool IsDraw { get { return m_IsDraw; } set { m_IsDraw = value; } } //0x2049494 0x204949C
		public float ViewWidth { get { return m_viewWidth; } set { m_viewWidth = value; } } //0x20494A4 0x20494AC
		public float ViewHeight { get { return m_viewHeight; } set { m_viewHeight = value; } } //0x20494B4 0x20494BC
		public bool IsMask { get { return m_IsMask; } set { m_IsMask = value; } } //0x20494C4 0x2042CC8

		// // RVA: 0x203F428 Offset: 0x203F428 VA: 0x203F428
		public void SetTexture(TexUVList tex, TexUVData uvdata)
		{
			if(tex != null && uvdata != null)
			{
				if(!m_IsInitTexture)
					m_IsInitTexture = true;
				m_Tex = tex;
				m_UVData = uvdata;
			}
		}

		// // RVA: 0x20494CC Offset: 0x20494CC VA: 0x20494CC
		// public void SetTexture(TexUVList tex, string name) { }

		// // RVA: 0x2048BAC Offset: 0x2048BAC VA: 0x2048BAC Slot: 8
		// public override void Clear() { }

		// // RVA: 0x2049514 Offset: 0x2049514 VA: 0x2049514 Slot: 7
		public override void Update(Matrix23 parentMat, Color parentColor)
		{
			base.Update(parentMat, parentColor);
			if(enabled)
				m_IsDraw = true;
		}

		// // RVA: 0x204958C Offset: 0x204958C VA: 0x204958C
		// public void SetMaskRect(Rect rect) { }

		// // RVA: 0x2042CC4 Offset: 0x2042CC4 VA: 0x2042CC4
		// public void SetMaskFromView(ViewBase view) { }

		// // RVA: 0x2048CE0 Offset: 0x2048CE0 VA: 0x2048CE0 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			ImageView v = view as ImageView;
			v.m_ImageName = m_ImageName;
			v.SetTexture(m_Tex, m_UVData);
			v.m_IsRender = m_IsRender;
			v.m_IsFlipX = m_IsFlipX;
			v.m_IsFlipY = m_IsFlipY;
			v.m_IsDraw = m_IsDraw;
			v.m_viewWidth = m_viewWidth;
			v.m_viewHeight = m_viewHeight;
			v.m_IsMask = m_IsMask;
		}

		// // RVA: 0x2049590 Offset: 0x2049590 VA: 0x2049590 Slot: 11
		public override ViewBase DeepClone()
		{
			ImageView v = new ImageView();
			CopyTo(v);
			return v;
		}

		// // RVA: 0x2049614 Offset: 0x2049614 VA: 0x2049614
		// public void SetMonochrome(bool isMonochrome) { }

		// // RVA: 0x2049618 Offset: 0x2049618 VA: 0x2049618 Slot: 15
		// public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
