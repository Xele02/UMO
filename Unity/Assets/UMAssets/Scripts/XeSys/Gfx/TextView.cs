using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeSys.Gfx
{
	public class TextView : ViewBase
	{
		public enum FadeType
		{
			none = 0,
			fadeIn = 1,
			fadeOut = 2,
		}

		// public static TextAnchor[,] AnchorTbl = new TextAnchor[4, 4] {
		// 	{0, 1, 2, 0},{3, 4, 5, 3},{6, 7, 8, 6},{0, 1, 2, 0}
		// }; // 0x0
		protected GUIStyle m_Style = new GUIStyle(); // 0x70
		private int m_TextSize; // 0x78
		protected ViewBase.EAlignH m_TextAlignH; // 0x7C
		protected ViewBase.EAlignV m_TextAlignV; // 0x80
		protected string m_TextId = ""; // 0x84
		protected string m_Text = ""; // 0x88
		private static float FADE_DEF_TIME = 0.5f; // 0x4
		private static Color FADE_DEF_COLOR = new Color(0, 0, 0, 0); // 0x8
		private TextView.FadeType m_FadeType; // 0x8C
		private float m_FadeTime = FADE_DEF_TIME; // 0x90
		private float m_FadeCount; // 0x94
		private Color m_FadeCol = FADE_DEF_COLOR; // 0x98
		private bool m_WordWrap = true; // 0xA8
		protected bool m_IsMask; // 0xA9
		protected int m_fontSize; // 0xAC
		protected float m_LineSpace = 1.0f; // 0xB0
		protected GUIContent m_ContentWork = new GUIContent(); // 0xB4
		private static GameObject prefab1 = null; // 0x18
		protected GameObject obj; // 0xB8
		protected Text uguiText; // 0xBC
		protected RectTransform rt; // 0xC0
		protected Canvas canv; // 0xC4
		protected bool activate; // 0xC8

		// public GUIStyle guiStyle { get; } 0x1EE2680
		public override bool enabled { get { return base.enabled; } set { base.enabled = value; } }// 0x1EE2688 0x1EE2698
		// public Func<string, string> getTextFromIdDelegate { get; set; } // 0x74
		public int TextSize { get { return m_TextSize; } set { m_TextSize = value; } } //0x1EE26B8 0x1EE26C0
		public ViewBase.EAlignH TextAlignH { get { return m_TextAlignH; } set { m_TextAlignH = value; } } //0x1EE26C8 0x1EE26D0
		public ViewBase.EAlignV TextAlignV { get { return m_TextAlignV; } set { m_TextAlignV = value; } } //0x1EE26D8 0x1EE26E0
		public string TextId { get { return m_TextId; } set {
			m_TextId = value;
			if(LayoutUtil.getTextFromIdDelegate == null)
				Text = "???12";
			else
			{
				Text = LayoutUtil.getTextFromIdDelegate(m_TextId);
			}
		} } //0x1EE26E8 0x1EE26F0
		public virtual string Text { get { return m_Text; } set { m_Text = value; } } //0x1EE2820 0x1EE2828
		public bool WordWrap { get { return m_WordWrap; } set { m_WordWrap = value; } } //0x1EE2830 0x1EE2838
		public bool IsMask { get { return m_IsMask; } set { m_IsMask = value; } } //0x1EE2878 0x1EE2880
		public int FontSize { get { return m_fontSize; } set { m_fontSize = value; } } //0x1EE2888 0x1EE2890
		public float LineSpace { get { return m_LineSpace; } set { m_LineSpace = value; } } //0x1EE2898 0x1EE28A0

		// // RVA: 0x1EE2840 Offset: 0x1EE2840 VA: 0x1EE2840
		// public void FadeParamCopy(TextView.FadeType type, float time, float count, Color col) { }

		// // RVA: 0x1EE28A8 Offset: 0x1EE28A8 VA: 0x1EE28A8
		public void InitFont(FontInfo fontInfo)
		{
			m_Style.font = fontInfo.font;
			m_fontSize = fontInfo.size;
			m_Style.fontSize = 0;
		}

		// // RVA: 0x1EE2920 Offset: 0x1EE2920 VA: 0x1EE2920
		// public void FadeIn() { }

		// // RVA: 0x1EE29D4 Offset: 0x1EE29D4 VA: 0x1EE29D4
		// public void FadeIn(float time, Color col) { }

		// // RVA: 0x1EE2A00 Offset: 0x1EE2A00 VA: 0x1EE2A00
		// public void FadeOut() { }

		// // RVA: 0x1EE2AB4 Offset: 0x1EE2AB4 VA: 0x1EE2AB4
		// public void FadeOut(float time, Color col) { }

		// // RVA: 0x1EE2AE8 Offset: 0x1EE2AE8 VA: 0x1EE2AE8
		// protected void SettingGUI(float fontScale, float fontScaleInv) { }

		// // RVA: 0x1EE2F30 Offset: 0x1EE2F30 VA: 0x1EE2F30
		// public float GetTextHeight() { }

		// // RVA: 0x1EE315C Offset: 0x1EE315C VA: 0x1EE315C
		// public void SetMaskRect(Rect rect) { }

		// // RVA: 0x1EE3160 Offset: 0x1EE3160 VA: 0x1EE3160
		public void SetMaskFromView(ViewBase view)
		{
			return;
		}

		// RVA: 0x1EE3164 Offset: 0x1EE3164 VA: 0x1EE3164 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			TextView v = view as TextView;
			v.m_Style.font = m_Style.font;
			v.m_fontSize = m_fontSize;
			v.m_TextSize = m_TextSize;
			v.m_TextAlignH = m_TextAlignH;
			v.m_TextAlignV = m_TextAlignV;
			v.TextId = m_TextId;
			v.Text = m_Text;
			v.m_FadeCol = m_FadeCol;
			v.m_FadeType = m_FadeType;
			v.m_FadeCount = m_FadeCount;
			v.m_IsMask = m_IsMask;
			v.m_LineSpace = m_LineSpace;
		}

		// RVA: 0x1EE331C Offset: 0x1EE331C VA: 0x1EE331C Slot: 11
		public override ViewBase DeepClone()
		{
			TextView v = new TextView();
			CopyTo(v);
			return v;
		}

		// RVA: 0x1EE34EC Offset: 0x1EE34EC VA: 0x1EE34EC Slot: 12
		// public override void StartGameObject() { }

		// RVA: 0x1EE3864 Offset: 0x1EE3864 VA: 0x1EE3864 Slot: 13
		// public override void RemoveGameObject() { }

		// RVA: 0x1EE393C Offset: 0x1EE393C VA: 0x1EE393C Slot: 14
		// public override void SetActiveGameObject(bool flag) { }

		// // RVA: 0x1EE39FC Offset: 0x1EE39FC VA: 0x1EE39FC
		public GameObject GetTextGameObject()
		{
			return obj;
		}

		// RVA: 0x1EE3A04 Offset: 0x1EE3A04 VA: 0x1EE3A04 Slot: 15
		// public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
