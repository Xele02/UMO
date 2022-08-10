using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

namespace XeSys.Gfx
{
	public class Layout
	{
		private enum ViewType
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
		}

		private const string AbsoluteLayoutTag = "AL";
		private const string ImageViewTag = "IV";
		private const string ImageButtonTag = "IB";
		private const string TextViewTag = "TV";
		private const string ScrollTextTag = "ST";
		private const string EditTextTag = "ET";
		private const string ScrollViewTag = "SV";
		private const string SwfTag = "Swf";
		private const string ModelViewTag = "MoV";
		private const string AutoScrollViewTag = "ASV";
		private const string MaskViewTag = "MV";
		private static Dictionary<string, Layout.ViewType> TagToViewTypeDic = new Dictionary<string, Layout.ViewType>() {
			{ AbsoluteLayoutTag, Layout.ViewType.AbsoluteLayout },
			{ ImageViewTag, Layout.ViewType.ImageView},
			{ ImageButtonTag, Layout.ViewType.ImageButton },
			{ TextViewTag, Layout.ViewType.TextView },
			{ ScrollTextTag, Layout.ViewType.ScrollText}, 
			{ EditTextTag, Layout.ViewType.EditText },
			{ SwfTag, Layout.ViewType.Swf },
			{ ScrollViewTag, Layout.ViewType.ScrollView },
			{ ModelViewTag, Layout.ViewType.ModelView },
			{ AutoScrollViewTag, Layout.ViewType.AutoScrollView },
			{ MaskViewTag, Layout.ViewType.MaskView }
		}; // 0x0
		private const string idAtt = "id";
		private const string exidAtt = "ei";
		private const string animIdAtt = "ai";
		private const string heightAtt = "lh";
		private const string widthAtt = "lw";
		private const string xAtt = "lx";
		private const string yAtt = "ly";
		private const string centerXAtt = "cx";
		private const string centerYAtt = "cy";
		private const string scaleTypeAtt = "sT";
		private const string srcAtt = "sc";
		private const string backgroundAtt = "bg";
		private const string alignHAtt = "aH";
		private const string alignVAtt = "aV";
		private const string colorAtt = "co";
		private const string FlipXAtt = "fX";
		private const string FlipYAtt = "fY";
		private const string LabelAtt = "lb";
		private const string textAtt = "tt";
		private const string textColorAtt = "tC";
		private const string textSizeAtt = "tS";
		private const string gravityAtt = "gv";
		private const string lineSpacingAtt = "lS";
		private const string hintAtt = "ht";
		private const string hintColorAtt = "tCH";
		private const string textLength = "mL";
		private const string lineNum = "mLs";
		private const string linesAtt = "ls";
		private const string barBaseScrAtt = "bBS";
		private const string barScrAtt = "bS";
		private const string scaleXAtt = "sX";
		private const string scaleYAtt = "sY";
		private const string rotAtt = "rt";
		private const string blendTypeAtt = "bT";
		private const string scrollDirAtt = "sD";
		private const string matrixAtt = "mtx";
		private const string transformPointAtt = "tP";
		private const string baseXAtt = "bX";
		private const string baseYAtt = "bY";
		private const string isApplyColorAtt = "iAC";
		private static int lineSpaceBase = 100; // 0x4
		private static string[] AlignHStrTbl = new string[4] { "l", "c", "r", "f" }; // 0x8
		private static Dictionary<string, ViewBase.EAlignH> AlignHStrToValDic = new Dictionary<string, ViewBase.EAlignH>() {
			{"l", ViewBase.EAlignH.left},
			{"c", ViewBase.EAlignH.center},
			{"r", ViewBase.EAlignH.right},
			{"f", ViewBase.EAlignH.fit}
		}; // 0xC
		private static string[] AlignVStrTbl = new string[4] { "t", "c", "b", "f" }; // 0x10
		private static Dictionary<string, ViewBase.EAlignV> AlignVStrToValDic = new Dictionary<string, ViewBase.EAlignV>() {
			{"t",ViewBase.EAlignV.top},
			{"c",ViewBase.EAlignV.center},
			{"b",ViewBase.EAlignV.bottom},
			{"f",ViewBase.EAlignV.fit}
		}; // 0x14
		private static string[] gravityVStrTbl = new string[3] { "t", "m", "b" }; // 0x18
		private static Dictionary<string, ViewBase.EAlignV> gravityVStrToValDic = new Dictionary<string, ViewBase.EAlignV>() {
			{"t",ViewBase.EAlignV.top},
			{"m",ViewBase.EAlignV.center},
			{"b",ViewBase.EAlignV.bottom}
		}; // 0x1C
		private static string TateScrollStr = "tate"; // 0x20
		private Matrix23 m_baseMat = new Matrix23(0, 0, 0, 0, 0, 0); // 0x10
		private AbsoluteLayout m_Root = new AbsoluteLayout(); // 0x28
		private bool m_ForceAnimChildren; // 0x2C
		private Dictionary<string, string> m_TmpAttDic = new Dictionary<string, string>(20); // 0x30

		public FontInfo fontInfo { get; set; } // 0x8
		public bool isLoaded { get; private set; } // 0xC
		public bool isSubLayout { get; private set; } // 0xD
		public AbsoluteLayout Root { get { return m_Root; } } //0x2049F8C
		// private Dictionary<string, string> TmpAttDic { get; }

		// RVA: 0x2049F94 Offset: 0x2049F94 VA: 0x2049F94
		public Layout() : this(false)
		{

		}

		// RVA: 0x2049F9C Offset: 0x2049F9C VA: 0x2049F9C
		public Layout(bool subLayout)
		{
			isSubLayout = subLayout;
			isLoaded = false;
		}

		// // RVA: 0x204A0A8 Offset: 0x204A0A8 VA: 0x204A0A8
		// public void .ctor(Layout.eCashClear type) { }

		// // RVA: 0x204A0B0 Offset: 0x204A0B0 VA: 0x204A0B0
		// public void Clear() { }

		// // RVA: 0x204A0E4 Offset: 0x204A0E4 VA: 0x204A0E4
		public void LoadFromBytes(byte[] bytes)
		{
			ReadXmlStringReader(Encoding.ASCII.GetString(bytes));
		}

		// // RVA: 0x204A3AC Offset: 0x204A3AC VA: 0x204A3AC
		public void LoadFromString(string layoutText)
		{
			TodoLogger.Log(0, "Layout LoadFromString");
		}

		// // RVA: 0x204A3B0 Offset: 0x204A3B0 VA: 0x204A3B0
		// private void ReadXmlString(string text) { }

		// // RVA: 0x204B03C Offset: 0x204B03C VA: 0x204B03C
		// public void ReadXmlElement(XmlElement root) { }

		// // RVA: 0x204B0DC Offset: 0x204B0DC VA: 0x204B0DC
		public void SettingTexture(TexUVListManager texManager)
		{
			m_Root.SettingTexture(texManager);
		}

		// // RVA: 0x204B118 Offset: 0x204B118 VA: 0x204B118
		// public void SettingSwf(SwfManager swfMan) { }

		// // RVA: 0x204B148 Offset: 0x204B148 VA: 0x204B148
		public void SettingAnimation(LayoutAnimation anim)
		{
			m_Root.SettingAnimation(anim);
		}

		// // RVA: 0x204B178 Offset: 0x204B178 VA: 0x204B178
		// public static ViewBase.EAlignH GetAlignH(string str) { }

		// // RVA: 0x204B24C Offset: 0x204B24C VA: 0x204B24C
		// public static ViewBase.EAlignV GetAlignV(string str) { }

		// // RVA: 0x204B320 Offset: 0x204B320 VA: 0x204B320
		// private void ReadCommon(ViewBase view, XmlElement elm) { }

		// // RVA: 0x204A630 Offset: 0x204A630 VA: 0x204A630
		// private void ReadAbsoluteLayout(AbsoluteLayout abs, XmlElement elm) { }

		// // RVA: 0x204C134 Offset: 0x204C134 VA: 0x204C134
		// private void ReadImageView(ImageView imgview, XmlElement elm) { }

		// // RVA: 0x204C3CC Offset: 0x204C3CC VA: 0x204C3CC
		// private void ReadImageButton(ImageButton imgbuton, XmlElement elm) { }

		// // RVA: 0x204C664 Offset: 0x204C664 VA: 0x204C664
		// private void ReadTextView(TextView textView, XmlElement elm) { }

		// // RVA: 0x204CD20 Offset: 0x204CD20 VA: 0x204CD20
		// private void ReadScrollTextView(ScrollText scrollText, XmlElement elm) { }

		// // RVA: 0x204CE9C Offset: 0x204CE9C VA: 0x204CE9C
		// private void ReadEditTextView(EditTextView edittextView, XmlElement elm) { }

		// // RVA: 0x204CFE8 Offset: 0x204CFE8 VA: 0x204CFE8
		// private void ReadSwfView(SwfView swfView, XmlElement elm) { }

		// // RVA: 0x204D4BC Offset: 0x204D4BC VA: 0x204D4BC
		// private void ReadScrollView(ScrollView scrollView, XmlElement elm) { }

		// // RVA: 0x204D754 Offset: 0x204D754 VA: 0x204D754
		// private void ReadModelView(ModelView modelview, XmlElement elm) { }

		// // RVA: 0x204D758 Offset: 0x204D758 VA: 0x204D758
		// private void ReadMaskView(MaskView maskview, XmlElement elm) { }

		// // RVA: 0x204DA34 Offset: 0x204DA34 VA: 0x204DA34
		// private Dictionary<string, string> get_TmpAttDic() { }

		// // RVA: 0x204DA3C Offset: 0x204DA3C VA: 0x204DA3C
		private void AddXmlAttributeDic(XmlReader reader, Dictionary<string, string> dic)
		{
			dic.Clear();
			while(true)
			{
				if(!reader.MoveToNextAttribute())
					break;
				dic.Add(reader.Name, reader.Value);
			}
		}

		// // RVA: 0x204A138 Offset: 0x204A138 VA: 0x204A138
		private void ReadXmlStringReader(string text)
		{
			StringReader sr = new StringReader(text);
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreComments = true;
			settings.IgnoreWhitespace = true;
			settings.IgnoreProcessingInstructions = true;

			XmlReader reader = XmlReader.Create(sr, settings);
			while(true)
			{
				if(!reader.Read())
					break;
				if(reader.NodeType == XmlNodeType.Element)
				{
					if(reader.Name == AbsoluteLayoutTag)
					{
						ReadAbsoluteLayoutReader(m_Root, reader);
					}
				}
			}
			m_Root.UpdateAll(m_baseMat, Color.white);
		}

		// // RVA: 0x204DBB4 Offset: 0x204DBB4 VA: 0x204DBB4
		// private void ReadCommonAtt(ViewBase view, Dictionary<string, string> dic) { }

		// // RVA: 0x204E888 Offset: 0x204E888 VA: 0x204E888
		private void ReadAbsoluteLayoutAtt(AbsoluteLayout abs, Dictionary<string, string> dic)
		{
			TodoLogger.Log(0, "TODO");
			/*ReadCommonAtt(abs, dic);
			if(dic.ContainsKey(colorAtt))
			{
				abs.SetColorFromString(dic[colorAtt]);
			}
			else
			{
				abs.SetColor(1, 1, 1, 1);
			}*/
		}

		// // RVA: 0x204EB28 Offset: 0x204EB28 VA: 0x204EB28
		// private void ReadImageViewAtt(ImageView imgview, Dictionary<string, string> dic) { }

		// // RVA: 0x204EDF8 Offset: 0x204EDF8 VA: 0x204EDF8
		// private void ReadImageButtonAtt(ImageButton imgbuton, Dictionary<string, string> dic) { }

		// // RVA: 0x204F0C8 Offset: 0x204F0C8 VA: 0x204F0C8
		// private void ReadTextViewAtt(TextView textView, Dictionary<string, string> dic) { }

		// // RVA: 0x204F6A4 Offset: 0x204F6A4 VA: 0x204F6A4
		// private void ReadScrollTextViewAtt(ScrollText scrollText, Dictionary<string, string> dic) { }

		// // RVA: 0x204F810 Offset: 0x204F810 VA: 0x204F810
		// private void ReadEditTextViewAtt(EditTextView edittextView, Dictionary<string, string> dic) { }

		// // RVA: 0x204F94C Offset: 0x204F94C VA: 0x204F94C
		// private void ReadSwfViewAtt(SwfView swfView, Dictionary<string, string> dic) { }

		// // RVA: 0x204FE0C Offset: 0x204FE0C VA: 0x204FE0C
		// private void ReadScrollViewAtt(ScrollView scrollView, Dictionary<string, string> dic) { }

		// // RVA: 0x205004C Offset: 0x205004C VA: 0x205004C
		// private void ReadMaskViewAtt(MaskView maskview, Dictionary<string, string> dic) { }

		// // RVA: 0x205035C Offset: 0x205035C VA: 0x205035C
		private void ReadChildrenView(AbsoluteLayout abs, XmlReader reader)
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x204DB44 Offset: 0x204DB44 VA: 0x204DB44
		private void ReadAbsoluteLayoutReader(AbsoluteLayout abs, XmlReader reader)
		{
			AddXmlAttributeDic(reader, m_TmpAttDic);
			ReadAbsoluteLayoutAtt(abs, m_TmpAttDic);
			if(reader.IsEmptyElement)
				return;
			ReadChildrenView(abs, reader);
		}

		// // RVA: 0x20508C8 Offset: 0x20508C8 VA: 0x20508C8
		// private void ReadImageViewReader(ImageView imgview, XmlReader reader) { }

		// // RVA: 0x20508F8 Offset: 0x20508F8 VA: 0x20508F8
		// private void ReadImageButtonReader(ImageButton imgbuton, XmlReader reader) { }

		// // RVA: 0x2050928 Offset: 0x2050928 VA: 0x2050928
		// private void ReadTextViewReader(TextView textView, XmlReader reader) { }

		// // RVA: 0x2050958 Offset: 0x2050958 VA: 0x2050958
		// private void ReadScrollTextViewReader(ScrollText scrollText, XmlReader reader) { }

		// // RVA: 0x2050988 Offset: 0x2050988 VA: 0x2050988
		// private void ReadEditTextViewReader(EditTextView edittextView, XmlReader reader) { }

		// // RVA: 0x20509B8 Offset: 0x20509B8 VA: 0x20509B8
		// private void ReadSwfViewReader(SwfView swfView, XmlReader reader) { }

		// // RVA: 0x20509E8 Offset: 0x20509E8 VA: 0x20509E8
		// private void ReadScrollViewReader(ScrollView scrollView, XmlReader reader) { }

		// // RVA: 0x2050A18 Offset: 0x2050A18 VA: 0x2050A18
		// private void ReadModelViewReader(ModelView modelview, XmlReader reader) { }

		// // RVA: 0x2050A48 Offset: 0x2050A48 VA: 0x2050A48
		// private void ReadMaskViewReader(MaskView maskview, XmlReader reader) { }

		// // RVA: 0x2050ABC Offset: 0x2050ABC VA: 0x2050ABC
		// public void SetDrawLayer(int layer) { }

		// // RVA: 0x2050AF8 Offset: 0x2050AF8 VA: 0x2050AF8
		// public void SetForceAnimChildren(bool force) { }

		// // RVA: 0x2050B00 Offset: 0x2050B00 VA: 0x2050B00
		public ViewBase FindViewById(string id)
		{
			return m_Root.FindViewById(id);
		}

		// // RVA: 0x2050B30 Offset: 0x2050B30 VA: 0x2050B30
		public ViewBase FindViewByExId(string exid)
		{
			return m_Root.FindViewByExId(exid);
		}

		// // RVA: 0x2050B60 Offset: 0x2050B60 VA: 0x2050B60
		// public void UpdateAll() { }

		// // RVA: 0x2050B9C Offset: 0x2050B9C VA: 0x2050B9C
		public void UpdateAll(Color color)
		{
			m_Root.UpdateAll(m_baseMat, color);
		}

		// // RVA: 0x2050C30 Offset: 0x2050C30 VA: 0x2050C30
		public void UpdateAllAnimation(float dt)
		{
			m_Root.UpdateAllAnimation(dt, m_ForceAnimChildren);
		}

		// // RVA: 0x2050C70 Offset: 0x2050C70 VA: 0x2050C70
		// public bool IsPlayingAll() { }

		// [ObsoleteAttribute] // RVA: 0x692424 Offset: 0x692424 VA: 0x692424
		// // RVA: 0x2050C9C Offset: 0x2050C9C VA: 0x2050C9C
		// public bool CheckAnimation() { }

		// // RVA: 0x2050CA0 Offset: 0x2050CA0 VA: 0x2050CA0
		// public void InitAllAnimation() { }

		// // RVA: 0x2050CC8 Offset: 0x2050CC8 VA: 0x2050CC8
		// public void StartAllAnimation(float time) { }

		// // RVA: 0x2050CF8 Offset: 0x2050CF8 VA: 0x2050CF8
		// public void SetAllAnimationFromLayout(Layout layout) { }

		// // RVA: 0x2050D28 Offset: 0x2050D28 VA: 0x2050D28
		// public void SetAllInterpolationType(ViewAnimation.InterpolationType type) { }

		// // RVA: 0x2050D58 Offset: 0x2050D58 VA: 0x2050D58
		// public void StartAllAnim() { }

		// // RVA: 0x2050D84 Offset: 0x2050D84 VA: 0x2050D84
		// public void StartAllAnimGoStop(int start, int end) { }

		// // RVA: 0x2050DC8 Offset: 0x2050DC8 VA: 0x2050DC8
		public void StartAllAnimGoStop(string startLabel, string endLabel)
		{
			m_Root.StartAllAnimGoStop(startLabel, endLabel);
		}

		// // RVA: 0x2050E0C Offset: 0x2050E0C VA: 0x2050E0C
		public void StartAllAnimGoStop(string startLabel)
		{
			m_Root.StartAllAnimGoStop(startLabel);
		}

		// // RVA: 0x2050E40 Offset: 0x2050E40 VA: 0x2050E40
		// public void StartAllAnimLoop(int start, int end) { }

		// // RVA: 0x2050E84 Offset: 0x2050E84 VA: 0x2050E84
		// public void StartAllAnimLoop(string startLabel, string endLabel) { }

		// // RVA: 0x2050EC8 Offset: 0x2050EC8 VA: 0x2050EC8
		public void StartAllAnimLoop(string startLabel)
		{
			m_Root.StartAllAnimLoop(startLabel);
		}

		// // RVA: 0x2050EFC Offset: 0x2050EFC VA: 0x2050EFC
		// public void StartAllAnimDefault() { }

		// // RVA: 0x2050F94 Offset: 0x2050F94 VA: 0x2050F94
		public void StartAllAnimDecoLoop()
		{
			StartAllAnimLoop(ViewBase.ANIMLABEL_LOOP);
		}

		// // RVA: 0x205102C Offset: 0x205102C VA: 0x205102C
		// public void StartAllAnimDecoOnce() { }

		// // RVA: 0x20510C4 Offset: 0x20510C4 VA: 0x20510C4
		// public void StartAllAnimIn() { }

		// // RVA: 0x2051168 Offset: 0x2051168 VA: 0x2051168
		// public void StartAllAnimOut() { }

		// // RVA: 0x2051204 Offset: 0x2051204 VA: 0x2051204
		// public void TextFadeIn() { }

		// // RVA: 0x205122C Offset: 0x205122C VA: 0x205122C
		// public void TextFadeIn(float time, Color col) { }

		// // RVA: 0x2051284 Offset: 0x2051284 VA: 0x2051284
		// public void TextFadeOut() { }

		// // RVA: 0x20512AC Offset: 0x20512AC VA: 0x20512AC
		// public void TextFadeOut(float time, Color col) { }

		// // RVA: 0x2051304 Offset: 0x2051304 VA: 0x2051304
		public void CopyTo(Layout layout)
		{
			layout.fontInfo = fontInfo;
			layout.m_ForceAnimChildren = m_ForceAnimChildren;
			m_Root.CopyTo(layout.m_Root);
		}

		// // RVA: 0x2051394 Offset: 0x2051394 VA: 0x2051394
		public Layout DeepClone()
		{
			Layout layout = new Layout(false);
			CopyTo(layout);
			return layout;
		}

		// // RVA: 0x2051410 Offset: 0x2051410 VA: 0x2051410
		// public void StartGameObject() { }

		// // RVA: 0x2051444 Offset: 0x2051444 VA: 0x2051444
		// public void RemoveGameObject() { }

		// // RVA: 0x2051478 Offset: 0x2051478 VA: 0x2051478
		// public ScriptableLayout Export() { }

		// // RVA: 0x2051500 Offset: 0x2051500 VA: 0x2051500
		public void Import(ScriptableLayout scriptable)
		{
			scriptable.Deserialize(this);
		}
	}
}
