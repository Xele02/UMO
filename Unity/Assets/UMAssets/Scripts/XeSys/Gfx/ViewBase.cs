using UnityEngine;

namespace XeSys.Gfx
{
	public class ViewBase
	{
		public enum EAnimType
		{
			interpolationAnim = 0,
			frameAnim = 1,
		}

		public enum EAlignH
		{
			left = 0,
			center = 1,
			right = 2,
			fit = 3,
		}

		public enum EAlignV
		{
			top = 0,
			center = 1,
			bottom = 2,
			fit = 3,
		}

		public enum EBlendType
		{
			mul = 0,
			add = 1,
			dec = 2,
		}

		public static string ANIMLABEL_DEFAULT = "st_wait"; // 0x0
		public static string ANIMLABEL_LOOP = "lo_"; // 0x4
		public static string ANIMLABEL_ONCE = "one_"; // 0x8
		public static string ANIMLABEL_IN_START = "go_in"; // 0xC
		public static string ANIMLABEL_IN_END = "st_in"; // 0x10
		public static string ANIMLABEL_OUT_START = "go_out"; // 0x14
		public static string ANIMLABEL_OUT_END = "st_out"; // 0x18
		private ViewBase.EAnimType m_AnimType = EAnimType.frameAnim; // 0x8
		private ViewAnimation m_Animation = new ViewAnimation(); // 0xC
		private ViewFrameAnimation m_FrameAnimation = new ViewFrameAnimation(); // 0x10
		private ViewBase m_Parent; // 0x14
		private string m_ID = ""; // 0x18
		private string m_EXID = ""; // 0x1C
		private string m_AnimID = ""; // 0x20
		protected ViewTransformData m_transformData = new ViewTransformData(); // 0x24
		private ViewBase.EAlignH m_AlignH; // 0x28
		private ViewBase.EAlignV m_AlignV; // 0x2C
		private ViewBase.EBlendType m_BlendType; // 0x30
		private string m_Label = ""; // 0x34
		private int m_tag; // 0x38
		protected Color m_Color = new Color(0, 0, 0, 0); // 0x3C
		protected Color m_CurrentColor = new Color(0, 0, 0, 0); // 0x4C
		private bool m_enabled = true; // 0x5C
		private bool m_isUpdateSRT = true; // 0x5D
		private bool m_IsOutScreenUpdate; // 0x64
		private bool m_IsTouchCheck; // 0x65
		protected int m_DrawLayer; // 0x68
		protected int m_in_scroll_view; // 0x6C

		public ViewBase.EAnimType AnimType { get { return m_AnimType; } set { m_AnimType = value; } } //0x1EE5E60 0x1EE5E68
		// public ViewAnimation viewAnimation { get; } 0x1EE5E70
		public ViewFrameAnimation FrameAnimation { get { return m_FrameAnimation; } } //0x1EE5E78
		// public float TimeScale { get; set; } 0x1EE5E80 0x1EE5EAC
		public Color col { get { return m_Color; } set { m_Color = value; } } //0x1EE5F00 0x1EE5F10
		public Color currentCol { get { return m_CurrentColor; } set { m_CurrentColor = value; } } // 0x1EE5F20 0x1EE5F30
		public virtual bool IsVisible { get { return m_enabled && !m_CurrentColor.IsTransp(); } }  //0x1EE5F40
		public bool IsUpdateSRT { get { return m_isUpdateSRT; } set { m_isUpdateSRT = value; } } //0x1EE5F84 0x1EE5F8C
		public LayoutUGUIRuntime.UguiInfo UguiInfo { get; set; } // 0x60
		public virtual bool enabled { get { return m_enabled; } set { m_enabled = value; } } //0x1EE2690 0x1EE26A0
		public ViewBase Parent { get { return m_Parent; } set { m_Parent = value; } } //0x1EE5FA4 0x1EE5FAC
		public string ID { get { return m_ID; } set { m_ID = value; } } //0x1EE5FB4 0x1EE5FBC
		public string EXID { get { return m_EXID; } set { m_EXID = value; } } //0x1EE5FC4 0x1EE5FCC
		public string AnimID { get { return m_AnimID; } set { m_AnimID = value; } } //0x1EE5FD4 0x1EE5FDC
		public ViewTransformData TransformData { get { return m_transformData; } } //0x1EE5FE4
		public float X { get { return m_transformData.m.Pos.x; } set { m_transformData.m.Pos.x = value; } }// 0x1EE5FEC 0x1EE6018
		public float Y { get { return m_transformData.m.Pos.y; } set { m_transformData.m.Pos.y = value; } } //0x1EE6050 0x1EE607C
		// public float BaseX { get; set; } 0x1EE60B4 0x1EE60E0
		// public float BaseY { get; set; } 0x1EE6118 0x1EE6144
		// public float Left { get; } 0x1EE617C
		// public float Top { get; } 0x1EE61C0
		public float MoveX { get { return m_transformData.m.Move.x; } set { m_transformData.m.Move.x = value; } } //0x1EE6204 0x1EE6230
		public float MoveY { get { return m_transformData.m.Move.y; } set { m_transformData.m.Move.y = value; } } //0x1EE6268 0x1EE6294
		public float Width { get {
				if(0 <= m_transformData.Width)
				{
					return m_transformData.Width;
				}
				else
				{
					if(m_Parent != null)
					{
						return PostRenderManager.renderingRect.width;
					}
					else
					{
						return m_Parent.Width;
					}
				}
			} set {
				m_transformData.Width = value;
			} } //0x1EE3050 0x1EE62D4
		public float Height { get
			{
				if (0 <= m_transformData.Height)
				{
					return m_transformData.Height;
				}
				else
				{
					if (m_Parent != null)
					{
						return PostRenderManager.renderingRect.height;
					}
					else
					{
						return m_Parent.Height;
					}
				}
			} set
			{
				m_transformData.Height = value;
			}
		} //0x1EE630C 0x1EE6420
		public float ScaleX { get { return m_transformData.m.Scale.x; } set { m_transformData.m.Scale.x = value; } } //0x1EE6458 0x1EE6484
		public float ScaleY { get { return m_transformData.m.Scale.y; } set { m_transformData.m.Scale.y = value; } } //0x1EE64BC 0x1EE64E8
		public float Rot { get{ return m_transformData.m.Rot; } set { m_transformData.m.Rot = value; } } //0x1EE6520 0x1EE6544
		public Color Col { get { return m_transformData.m.Color; } set { m_transformData.m.Color = value; } } //0x1EE6574 0x1EE65A4
		public float CenterX { get { return m_transformData.m.Center.x; } set { m_transformData.m.Center.x = value; } } //0x1EE65E4 0x1EE6610
		public float CenterY { get { return m_transformData.m.Center.y; } set { m_transformData.m.Center.y = value; } } //0x1EE6648 0x1EE6674
		public ViewBase.EAlignH AlignH { get { return m_AlignH; } set { m_AlignH = value; } } //0x1EE66AC 0x1EE66B4
		public ViewBase.EAlignV AlignV { get { return m_AlignV; } set { m_AlignV = value; } } //0x1EE66BC 0x1EE66C4
		public ViewBase.EBlendType BlendType { get { return m_BlendType; } set { m_BlendType = value; } } //0x1EE66CC 0x1EE66D4
		public int Tag { get { return m_tag; } set { m_tag = value; } } //0x1EE66DC 0x1EE66E4
		public string Label { get { return m_Label; } set { m_Label = value; } } //0x1EE66EC 0x1EE66F4
		public bool IsOutScreenUpdate { get { return m_IsOutScreenUpdate; } set { m_IsOutScreenUpdate = value; } } //0x1EE66FC 0x1EE6704
		public bool IsTouchCheck { get { return m_IsTouchCheck; } set { m_IsTouchCheck = value; } } //0x1EE670C 0x1EE6714
		public int DrawLayer { get { return m_DrawLayer; } set { m_DrawLayer = value; } } //0x1EE020C 0x1EDFC68
		// public int InScrollView { get; set; } 0x1EE671C 0x1EE6724

		// // RVA: 0x1EE672C Offset: 0x1EE672C VA: 0x1EE672C
		// public bool isNoSize() { }

		// // RVA: 0x1EE6774 Offset: 0x1EE6774 VA: 0x1EE6774
		// public void SetColorFromString(string colStr) { }

		// // RVA: 0x1EE6988 Offset: 0x1EE6988 VA: 0x1EE6988
		// public void SetColor(float r, float g, float b, float a) { }

		// // RVA: 0x1EDFDC4 Offset: 0x1EDFDC4 VA: 0x1EDFDC4 Slot: 7
		public virtual void Update(Matrix23 parentMat, Color parentCol)
		{
			if(enabled)
			{
				m_Color = m_transformData.m.Color;
				m_CurrentColor = parentCol * m_Color;
			}
			if(UguiInfo != null)
			{
				UguiInfo.Update();
			}
		}

		// // RVA: 0x1EE69E8 Offset: 0x1EE69E8 VA: 0x1EE69E8 Slot: 8
		// public virtual void Clear() { }

		// // RVA: 0x1EE69EC Offset: 0x1EE69EC VA: 0x1EE69EC
		// public void InitAnimation() { }

		// // RVA: 0x1EE6C3C Offset: 0x1EE6C3C VA: 0x1EE6C3C
		// public void SetAnimElm(bool isPos, bool isSize, bool isCenter, bool isScale, bool isRot, bool isCol) { }

		// // RVA: 0x1EE6FCC Offset: 0x1EE6FCC VA: 0x1EE6FCC
		// public void StopAnim() { }

		// // RVA: 0x1EE7018 Offset: 0x1EE7018 VA: 0x1EE7018
		public bool IsPlaying()
		{
			if(m_AnimType == 0)
				return m_Animation.IsAnimEnd == false;
			else
				return m_FrameAnimation.IsAnimEnd == false;
		}

		// [ObsoleteAttribute] // RVA: 0x692690 Offset: 0x692690 VA: 0x692690
		// // RVA: 0x1EE7060 Offset: 0x1EE7060 VA: 0x1EE7060
		// public bool IsAnimation() { }

		// // RVA: 0x1EE7064 Offset: 0x1EE7064 VA: 0x1EE7064 Slot: 9
		public virtual bool UpdateAnim(float dt)
		{
			bool isUpdateSRT = false;
			if(m_AnimType == EAnimType.interpolationAnim)
			{
				if(!m_Animation.IsAnimEnd)
				{
					m_Animation.Update(dt);
					m_Animation.GetAnimTransform(m_transformData, ref isUpdateSRT);
				}
			}
			else
			{
				if(!m_FrameAnimation.IsAnimEnd)
				{
					m_FrameAnimation.Update(dt);
					m_FrameAnimation.GetAnimTransform(m_transformData, ref isUpdateSRT);
				}
			}
			if(isUpdateSRT)
			{
				m_isUpdateSRT = true;
			}
			return !m_transformData.m.Color.IsTransp();
		}

		// // RVA: 0x1EE73C4 Offset: 0x1EE73C4 VA: 0x1EE73C4
		// public void StartAnim(float time) { }

		// // RVA: 0x1EE751C Offset: 0x1EE751C VA: 0x1EE751C
		// public void SetAnimTargetPos(float x, float y) { }

		// // RVA: 0x1EE76E8 Offset: 0x1EE76E8 VA: 0x1EE76E8
		// public void SetAnimTargetScale(float x, float y) { }

		// // RVA: 0x1EE78B4 Offset: 0x1EE78B4 VA: 0x1EE78B4
		// public void SetAnimTargetRot(float rot) { }

		// // RVA: 0x1EE79F0 Offset: 0x1EE79F0 VA: 0x1EE79F0
		// public void SetAnimTragetColor(Color col) { }

		// // RVA: 0x1EE7B6C Offset: 0x1EE7B6C VA: 0x1EE7B6C
		// public void SetAnimTargetColor(float r, float g, float b, float a) { }

		// // RVA: 0x1EE7D3C Offset: 0x1EE7D3C VA: 0x1EE7D3C
		// public void SetAnimTargetColor(float r, float g, float b) { }

		// // RVA: 0x1EE7F88 Offset: 0x1EE7F88 VA: 0x1EE7F88
		// public void SetAnimTargetColAlpha(float a) { }

		// // RVA: 0x1EE82E4 Offset: 0x1EE82E4 VA: 0x1EE82E4
		// public void SetAnimMove(float x, float y) { }

		// // RVA: 0x1EE85EC Offset: 0x1EE85EC VA: 0x1EE85EC
		// public void SetTargetTransform(ViewTransformData data) { }

		// // RVA: 0x1EE8758 Offset: 0x1EE8758 VA: 0x1EE8758
		// public void SetLoop(ViewAnimation.LoopType loopType, int loopNum) { }

		// // RVA: 0x1EE8888 Offset: 0x1EE8888 VA: 0x1EE8888
		// public void SetInterpolationType(ViewAnimation.InterpolationType type) { }

		// // RVA: 0x1EE88B0 Offset: 0x1EE88B0 VA: 0x1EE88B0
		// public void SetAnimationFromView(ViewBase view) { }

		// // RVA: 0x1EE88E4 Offset: 0x1EE88E4 VA: 0x1EE88E4
		// public void SetAnimationFromLayout(Layout layout) { }

		// // RVA: 0x1EE8940 Offset: 0x1EE8940 VA: 0x1EE8940
		public void SetFrameAnimation(ViewFrameAnimation anim)
		{
			if(anim != null)
			{
				anim.CopyTo(m_FrameAnimation);
				return;
			}
			m_FrameAnimation.InitializeEmptyAnimation(false);
		}

		// // RVA: 0x1EE8A94 Offset: 0x1EE8A94 VA: 0x1EE8A94
		// public void StartAnim() { }

		// // RVA: 0x1EE8AF0 Offset: 0x1EE8AF0 VA: 0x1EE8AF0
		public void StartAnimGoStop(int start, int end)
		{
			m_FrameAnimation.StartAnimGoStop(start, end);
		}

		// // RVA: 0x1EE8B84 Offset: 0x1EE8B84 VA: 0x1EE8B84
		public void StartAnimGoStop(string startLabel, string endLabel)
		{
			m_FrameAnimation.StartAnimGoStop(startLabel, endLabel);
		}

		// // RVA: 0x1EE8C50 Offset: 0x1EE8C50 VA: 0x1EE8C50
		public void StartAnimGoStop(string label)
		{
			m_FrameAnimation.StartAnimGoStop(label);
		}

		// // RVA: 0x1EE8D08 Offset: 0x1EE8D08 VA: 0x1EE8D08
		// public void StartAnimLoop(int start, int end) { }

		// // RVA: 0x1EE8DA4 Offset: 0x1EE8DA4 VA: 0x1EE8DA4
		public void StartAnimLoop(int current, int start, int end)
		{
			m_FrameAnimation.StartAnimLoop(current, start, end);
		}

		// // RVA: 0x1EE8E5C Offset: 0x1EE8E5C VA: 0x1EE8E5C
		public void StartAnimLoop(string startLabel, string endLabel)
		{
			m_FrameAnimation.StartAnimLoop(startLabel, endLabel);
		}

		// // RVA: 0x1EE8F18 Offset: 0x1EE8F18 VA: 0x1EE8F18
		public void StartAnimLoop(string label)
		{
			m_FrameAnimation.StartAnimLoop(label);
		}

		// // RVA: 0x1EE8FB4 Offset: 0x1EE8FB4 VA: 0x1EE8FB4
		// public void FinishAnimLoop() { }

		// // RVA: 0x1EE8FF8 Offset: 0x1EE8FF8 VA: 0x1EE8FF8
		// public void StartAnimDefault() { }

		// // RVA: 0x1EE9090 Offset: 0x1EE9090 VA: 0x1EE9090
		// public void StartAnimDecoLoop() { }

		// // RVA: 0x1EE9128 Offset: 0x1EE9128 VA: 0x1EE9128
		// public void StartAnimDecoOnce() { }

		// // RVA: 0x1EE91C0 Offset: 0x1EE91C0 VA: 0x1EE91C0
		// public void StartAnimIn() { }

		// // RVA: 0x1EE9264 Offset: 0x1EE9264 VA: 0x1EE9264
		// public void StartAnimOut() { }

		// // RVA: 0x1EE00CC Offset: 0x1EE00CC VA: 0x1EE00CC Slot: 10
		public virtual void CopyTo(ViewBase view)
		{
			m_FrameAnimation.CopyTo(view.m_FrameAnimation);
			m_FrameAnimation.InitializeEmptyAnimation();
			view.m_ID = m_ID;
			view.m_EXID = m_EXID;
			view.m_AnimID = m_AnimID;
			m_transformData.CopyTo(view.m_transformData);
			view.m_AlignH = m_AlignH;
			view.m_AlignV = m_AlignV;
			view.m_BlendType = m_BlendType;
			view.m_tag = m_tag;
			view.m_Color = m_Color;
			view.m_CurrentColor = m_CurrentColor;
			view.m_enabled = m_enabled;
			view.m_Label = m_Label;
			view.m_IsTouchCheck = m_IsTouchCheck;
			view.m_DrawLayer = m_DrawLayer;
		}

		// // RVA: 0x1EE9300 Offset: 0x1EE9300 VA: 0x1EE9300 Slot: 11
		public virtual ViewBase DeepClone()
		{
			ViewBase v = new ViewBase();
			CopyTo(v);
			return v;
		}

		// // RVA: 0x1EE9384 Offset: 0x1EE9384 VA: 0x1EE9384 Slot: 12
		// public virtual void StartGameObject() { }

		// // RVA: 0x1EE9388 Offset: 0x1EE9388 VA: 0x1EE9388 Slot: 13
		// public virtual void RemoveGameObject() { }

		// // RVA: 0x1EE938C Offset: 0x1EE938C VA: 0x1EE938C Slot: 14
		// public virtual void SetActiveGameObject(bool flag) { }

		// // RVA: 0x1EE9390 Offset: 0x1EE9390 VA: 0x1EE9390
		// public void StartAnimInverseGoStop(string Label) { }

		// // RVA: 0x1EE9448 Offset: 0x1EE9448 VA: 0x1EE9448 Slot: 15
		// public virtual void Serialize(List<SerializableView> list, int parent) { }
	}
}
