using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XeSys.Gfx
{
	public class ScrollView : AbsoluteLayout
	{
		protected Matrix23 m_DispMtx = new Matrix23(); // 0x84
		protected Vector2 m_ScrollPos = new Vector2(); // 0x9C
		protected Rect m_ContentSize = new Rect(); // 0xA4
		private const int OldTouchSaveNum = 5;
		protected ScrollBar m_ScrollBarV = new ScrollBar(); // 0xB4
		protected ScrollBar m_ScrollBarH = new ScrollBar(); // 0xB8
		private float m_OldTouchX; // 0xBC
		private float m_OldTouchY; // 0xC0
		private float m_BaseTouchX; // 0xC4
		private float m_BaseTouchY; // 0xC8
		private float m_MoveAsobi = 5.0f; // 0xCC
		protected bool m_IsScroll; // 0xD0
		protected bool m_IsTouch; // 0xD1
		protected bool m_IsTouchSimple; // 0xD2
		protected bool m_IsMaskUpdate; // 0xD3
		private float[] m_OldTouchXList = new float[5]; // 0xD4
		private float[] m_OldTouchYList = new float[5]; // 0xD8
		private const float InertialStopVal = 0.01f;
		private const float InertialDecRate = 0.99f;
		private float m_inertiaV; // 0xDC
		private float m_inertiaH; // 0xE0
		private static StringBuilder s_strWork = new StringBuilder(64); // 0x0
		protected GameObject prefab1; // 0xE4
		protected GameObject obj; // 0xE8
		protected RectTransform rt; // 0xEC
		protected Canvas canv; // 0xF0

		//public Matrix23 dispMtx { get; } 0x1F12334
		//public float ScrollPosX { get; set; } 0x1F1234C 0x1F12354
		//public float ScrollPosY { get; set; } 0x1F1235C 0x1F12364
		//public Rect ContentSize { get; set; } 0x1F1236C 0x1F1237C
		//public float ContentWidth { get; set; } 0x1F08888 0x1F08894
		//public float ContentHeight { get; set; } 0x1F08860 0x1F0886C
		//public bool IsMaskUpdate { get; set; } 0x1F1238C 0x1F12394
		public ScrollBar ScrollBarV { get { return m_ScrollBarV;} } //0x1EFE9F0 
		public ScrollBar ScrollBarH { get { return m_ScrollBarH; } } //0x1EFEE0C
		//public bool IsTouch { get; } 0x1F1239C
		public bool IsTouchSimple { get { return m_IsTouchSimple; } set { m_IsTouchSimple = value; } } //0x1F123A4 0x1F123AC

		// RVA: 0x1F123B4 Offset: 0x1F123B4 VA: 0x1F123B4
		//public void StopInertia() { }

		// RVA: 0x1F123C4 Offset: 0x1F123C4 VA: 0x1F123C4 Slot: 16
		public override void AddView(ViewBase child)
		{
			base.AddView(child);
			SetViewMask(this, child);
		}

		//// RVA: 0x1F123F4 Offset: 0x1F123F4 VA: 0x1F123F4
		//public void AddViewInContentsX(ViewBase child) { }

		//// RVA: 0x1F12460 Offset: 0x1F12460 VA: 0x1F12460
		//public void AddViewInContentsY(ViewBase child) { }

		//// RVA: 0x1F124CC Offset: 0x1F124CC VA: 0x1F124CC
		//public void RemoveViewFromContents(ViewBase child) { }

		//// RVA: 0x1F124F8 Offset: 0x1F124F8 VA: 0x1F124F8 Slot: 23
		//protected virtual void CalcContentMemberPosition() { }

		//// RVA: 0x1F129C4 Offset: 0x1F129C4 VA: 0x1F129C4 Slot: 18
		//public override void InsertView(int index, ViewBase child) { }

		// RVA: 0x1F129F4 Offset: 0x1F129F4 VA: 0x1F129F4 Slot: 19
		public override void SettingTexture(TexUVListManager texManager)
		{
			TexUVList uvList;
			TexUVData tex = texManager.GetTextureData(m_ScrollBarV.BarImageName, out uvList);
			if(uvList != null && tex != null)
			{
				m_ScrollBarV.BarTex = uvList;
				m_ScrollBarV.BarUVData = tex;
				GetScrollBarHName(m_ScrollBarV.BarImageName);
				TexUVList uvList2;
				TexUVData tex2 = texManager.GetTextureData(GetScrollBarHName(m_ScrollBarV.BarImageName), out uvList2);
				if(tex2 != null)
				{
					tex = tex2;
					uvList = uvList2;
					m_ScrollBarH.BarImageName = GetScrollBarHName(m_ScrollBarV.BarImageName);
				}
				m_ScrollBarH.BarTex = uvList;
				m_ScrollBarH.BarUVData = tex;
				tex = texManager.GetTextureData(m_ScrollBarV.ImageName, out uvList);
				m_ScrollBarV.SetTexture(uvList, tex);
				m_ScrollBarV.Width = tex.width * uvList.width;
				tex2 = texManager.GetTextureData(GetScrollBarHName(m_ScrollBarV.ImageName), out uvList2);
				if (tex2 != null)
				{
					tex = tex2;
					uvList = uvList2;
					m_ScrollBarH.ImageName = GetScrollBarHName(m_ScrollBarV.ImageName);
				}
				m_ScrollBarH.SetTexture(uvList, tex);
				m_ScrollBarH.Height = tex.height * uvList.height;
			}
			base.SettingTexture(texManager);
		}

		//// RVA: 0x1F12ED0 Offset: 0x1F12ED0 VA: 0x1F12ED0
		private static string GetScrollBarHName(string nameV)
		{
			s_strWork.Clear();
			s_strWork.Append(nameV.Substring(0, nameV.Length - 3));
			s_strWork.Append("_w");
			s_strWork.Append(nameV.Substring(nameV.Length - 3));
			return s_strWork.ToString();
		}

		//// RVA: 0x1F13110 Offset: 0x1F13110 VA: 0x1F13110
		//public static string GetScrollBarAccessoryName(string nameV) { }

		//// RVA: 0x1EFEE14 Offset: 0x1EFEE14 VA: 0x1EFEE14
		//public string GetScrollBarAccessoryName() { }

		// RVA: 0x1F132C8 Offset: 0x1F132C8 VA: 0x1F132C8 Slot: 7
		public override void Update(Matrix23 parentMat, Color parentCol)
		{
			if(enabled)
			{
				m_inertiaV *= 0.99f;
				m_inertiaH *= 0.99f;
				if(Mathf.Abs(m_inertiaV) <= 0.01f)
					m_inertiaV = 0;
				if (Mathf.Abs(m_inertiaH) <= 0.01f)
					m_inertiaH = 0;
				m_ScrollPos.x += m_inertiaH;
				m_ScrollPos.y += m_inertiaV;
				if (m_ScrollPos.x < 0)
					m_ScrollPos.x = 0;
				if (m_ScrollPos.y < 0)
					m_ScrollPos.y = 0;
				if(m_ContentSize.width <= m_ScrollPos.x + Width)
				{
					m_ScrollPos.x = m_ContentSize.width - Width;
					if ((m_ContentSize.width - Width) < 0)
						m_ScrollPos.x = 0;
				}
				if (m_ContentSize.height <= m_ScrollPos.y + Height)
				{
					m_ScrollPos.y = m_ContentSize.height - Height;
					if ((m_ContentSize.height - Height) < 0)
						m_ScrollPos.y = 0;
				}
				m_DispMtx.Identity();
				m_DispMtx.TransRotScale(m_transformData.m.Pos, Rot, m_transformData.m.Scale);
				m_DispMtx = m_DispMtx * parentMat;
				m_Color = Col;
				m_CurrentColor = Col;
				m_CurrentColor *= parentCol;
				m_ScrollBarV.IsHorizon = false;
				m_ScrollBarV.Height = Height;
				m_ScrollBarV.X = X + (Width - m_ScrollBarV.Width);
				m_ScrollBarV.Y = Y;
				m_ScrollBarV.ContentSize = Height;
				m_ScrollBarV.ValueMin = 0;
				m_ScrollBarV.ValueMax = m_ContentSize.height;
				m_ScrollBarV.Value = m_ScrollPos.y;
				m_ScrollBarH.IsHorizon = true;
				m_ScrollBarH.Width = Width;
				m_ScrollBarH.X = X;
				m_ScrollBarH.Y = Y + (Height - m_ScrollBarH.Height);
				m_ScrollBarH.ContentSize = Width;
				m_ScrollBarH.ValueMin = 0;
				m_ScrollBarH.ValueMax = m_ContentSize.width;
				m_ScrollBarH.Value = m_ScrollPos.x;
				m_ScrollBarH.enabled = Width < m_ContentSize.width;
				m_ScrollBarV.enabled = Height < m_ContentSize.height;
				m_ScrollBarV.Update(parentMat, parentCol);
				m_ScrollBarH.Update(parentMat, parentCol);
				if(rt != null)
				{
					Rect r = PostRenderManager.MakeScreenRect(m_DispMtx._02, m_DispMtx._12, Width * m_DispMtx._00, Height * m_DispMtx._11);
					rt.anchoredPosition = new Vector2(r.x, -r.y);
					rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, r.width);
					rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, r.height);
				}
				if(m_IsMaskUpdate)
				{
					SetViewMask();
				}
			}
		}

		//// RVA: 0x1F13D2C Offset: 0x1F13D2C VA: 0x1F13D2C Slot: 21
		//public override void SetDrawLayer(int layer) { }

		//// RVA: 0x1F13D90 Offset: 0x1F13D90 VA: 0x1F13D90
		//public void SetTouchData(float x, float y) { }

		//// RVA: 0x1F13E4C Offset: 0x1F13E4C VA: 0x1F13E4C
		//public void SetTouchMoveData(float x, float y) { }

		//// RVA: 0x1F141F0 Offset: 0x1F141F0 VA: 0x1F141F0
		//public void SetTouchEndData(float x, float y) { }

		//// RVA: 0x1F13DA4 Offset: 0x1F13DA4 VA: 0x1F13DA4
		//public void ResetOldTouchXY(float x, float y) { }

		//// RVA: 0x1F14088 Offset: 0x1F14088 VA: 0x1F14088
		//public void PushOldTouchXY(float x, float y) { }

		//// RVA: 0x1F1429C Offset: 0x1F1429C VA: 0x1F1429C Slot: 22
		//public override void SetViewMaskEx(ViewBase maskView, ViewBase view) { }

		// RVA: 0x1F14348 Offset: 0x1F14348 VA: 0x1F14348 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			ScrollView sview = view as ScrollView;
			sview.m_DispMtx = m_DispMtx;
			sview.m_ScrollPos = m_ScrollPos;
			sview.m_ContentSize = m_ContentSize;
			m_ScrollBarV.CopyTo(sview.m_ScrollBarV);
			m_ScrollBarH.CopyTo(sview.m_ScrollBarH);
		}

		// RVA: 0x1F14584 Offset: 0x1F14584 VA: 0x1F14584 Slot: 11
		public override ViewBase DeepClone()
		{
			ScrollView res = new ScrollView();
			CopyTo(res);
			return res;
		}

		//// RVA: 0x1F147B8 Offset: 0x1F147B8 VA: 0x1F147B8
		//public GameObject GetMask() { }

		//// RVA: 0x1F147C0 Offset: 0x1F147C0 VA: 0x1F147C0 Slot: 12
		//public override void StartGameObject() { }

		//// RVA: 0x1F14A7C Offset: 0x1F14A7C VA: 0x1F14A7C Slot: 13
		//public override void RemoveGameObject() { }

		//// RVA: 0x1F14B54 Offset: 0x1F14B54 VA: 0x1F14B54 Slot: 14
		//public override void SetActiveGameObject(bool flag) { }

		//// RVA: 0x1F14C20 Offset: 0x1F14C20 VA: 0x1F14C20
		public void AddChildGameObject(GameObject child)
		{
			child.transform.SetParent(obj.transform, false);
		}

		//// RVA: 0x1F14C9C Offset: 0x1F14C9C VA: 0x1F14C9C Slot: 15
		//public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
