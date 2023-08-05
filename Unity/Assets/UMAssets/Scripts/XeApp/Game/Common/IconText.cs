using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace XeApp.Game.Common
{
	[ExecuteInEditMode] // RVA: 0x64EE34 Offset: 0x64EE34 VA: 0x64EE34
	//[AddComponentMenu] // RVA: 0x64EE34 Offset: 0x64EE34 VA: 0x64EE34
	public class IconText : Text
	{
		public class LineInfo
		{
			private List<RawImage> m_imageList = new List<RawImage>(); // 0x8
			private int m_stringLenght; // 0xC
			private int m_width; // 0x10

			//public int Length { get; } 0x10FEB68
			//public List<RawImage> ImageList { get; } 0x10FEB70

			// RVA: 0x10FDC98 Offset: 0x10FDC98 VA: 0x10FDC98
			public LineInfo(List<RawImage> imageList, int width)
			{
				m_imageList.AddRange(imageList);
				m_width = width;
			}

			// RVA: 0x10FE99C Offset: 0x10FE99C VA: 0x10FE99C
			public void AdjustHorizontalAlignmentIcon(float width, float alignment)
			{
				for(int i = 0; i < m_imageList.Count; i++)
				{
					m_imageList[i].GetComponent<RectTransform>().anchoredPosition += new Vector2(width * alignment - m_width * alignment, 0);
				}
			}
		}

		public IconTextSetting m_setting; // 0x7C
		public float m_iconScale; // 0x80
		public bool IsTextAlpha; // 0x84
		[SerializeField] // RVA: 0x688570 Offset: 0x688570 VA: 0x688570
		[HideInInspector] // RVA: 0x688570 Offset: 0x688570 VA: 0x688570
		private List<RawImage> m_imageObjectList = new List<RawImage>(); // 0x88
		private Stack<RawImage> m_imageCacheStack = new Stack<RawImage>(); // 0x8C
		private List<LineInfo> m_lineObjectList = new List<LineInfo>(); // 0x90
		private List<RawImage> m_lineImageTmpList = new List<RawImage>(); // 0x94
		private Regex m_tagRegex = new Regex("<img=\\d+>"); // 0x98
		private string m_space = JpStringLiterals.StringLiteral_12037; // 0x9C
		private char m_tagStart = '<'; // 0xA0
		private char m_tagEnd = '>'; // 0xA2
		private string[] m_tags = new string[1] { "img" }; // 0xA4
		private bool m_dirtyUpdateText; // 0xA8
		private StringBuilder m_lineString = new StringBuilder(); // 0xAC
		private StringBuilder m_texModify = new StringBuilder(); // 0xB0
		private string m_prevString = ""; // 0xB4

		public override string text { get { return ReplaceTagToSpace(base.text); } set { base.text = value; } } //0x10FC030 0x10FC1A8
		public override float preferredWidth { get
			{
				return cachedTextGeneratorForLayout.GetPreferredWidth(text, GetGenerationSettings(Vector2.zero)) / pixelsPerUnit;
			}
		} //0x10FE168
		public override float preferredHeight { get
			{
				return cachedTextGeneratorForLayout.GetPreferredHeight(text, GetGenerationSettings(new Vector2(rectTransform.rect.width, 0))) / pixelsPerUnit;
			}
		} //0x10FE2D8

		// RVA: 0x10FC1B0 Offset: 0x10FC1B0 VA: 0x10FC1B0 Slot: 4
		protected override void Awake()
		{
			base.Awake();
		}

		// RVA: 0x10FC1B8 Offset: 0x10FC1B8 VA: 0x10FC1B8
		//private void DestoryIconObject() { }

		//// RVA: 0x10FC054 Offset: 0x10FC054 VA: 0x10FC054
		private string ReplaceTagToSpace(string text)
		{
			int a = Mathf.Max(1, Mathf.CeilToInt(m_iconScale));
			m_texModify.Clear();
			for(int i = 0; i < a; i++)
			{
				m_texModify.Append(m_space);
			}
			return m_tagRegex.Replace(text, m_texModify.ToString());
		}

		[ContextMenu("Update")] // RVA: 0x73CFA8 Offset: 0x73CFA8 VA: 0x73CFA8
		//// RVA: 0x10FC3D0 Offset: 0x10FC3D0 VA: 0x10FC3D0
		public void UpdateIcon()
		{
			for(int i = 0; i < m_imageObjectList.Count; i++)
			{
				if(m_imageObjectList[i] != null)
				{
					m_imageCacheStack.Push(m_imageObjectList[i]);
					m_imageObjectList[i].gameObject.SetActive(false);
				}
			}
			m_imageObjectList.Clear();
			Parse(base.text);
		}

		//// RVA: 0x10FCF4C Offset: 0x10FCF4C VA: 0x10FCF4C
		private void UpdateIconAlpha()
		{
			for(int i = 0; i < m_imageObjectList.Count; i++)
			{
				if(m_imageObjectList[i] != null)
				{
					Color c = m_imageObjectList[i].color;
					m_imageObjectList[i].color = new Color(1, 1, 1, c.a);
				}
			}
		}

		// RVA: 0x10FD120 Offset: 0x10FD120 VA: 0x10FD120
		public void Update()
		{
			if (!m_dirtyUpdateText)
				return;
			UpdateIcon();
			m_dirtyUpdateText = false;
		}

		// RVA: 0x10FD14C Offset: 0x10FD14C VA: 0x10FD14C
		private void LateUpdate()
		{
			if (IsTextAlpha)
				UpdateIconAlpha();
		}

		//// RVA: 0x10FC600 Offset: 0x10FC600 VA: 0x10FC600
		private void Parse(string text)
		{
			Vector2 textAnchorPivot = GetTextAnchorPivot(alignment);
			m_lineObjectList.Clear();
			m_lineString.Clear();
			m_lineImageTmpList.Clear();
			TextGenerationSettings setting = GetGenerationSettings(Vector2.zero);
			int tagStart = -1;
			bool inTag = false;
			int lineCount = 0;
			for(int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if(c == m_tagStart)
				{
					inTag = true;
					tagStart = i;
				}
				else if(c == m_tagEnd)
				{
					int a = Mathf.Max(1, Mathf.CeilToInt(m_iconScale));
					string t = text.Substring(tagStart + 1, i - 1 - tagStart);
					string[] word = t.Split(new char[] { '=' });
					string t3 = Array.Find(m_tags, (string tagName) =>
					{
						//0x10FEB18
						return word[0] == tagName;
					});
					float w = GetPreferredWidth(m_lineString.ToString());
					if(t3 == "img")
					{
						int val = 0;
						if (int.TryParse(word[1], out val))
						{
							RawImage icon = CreateIcon(val, Mathf.RoundToInt(w), lineCount);
							m_lineImageTmpList.Add(icon);
							m_imageObjectList.Add(icon);
						}
					}
					for(int j = 0; j < a; j++)
					{
						m_lineString.Append(JpStringLiterals.StringLiteral_12037);
					}
					inTag = false;
				}
				else if(inTag)
				{
					inTag = true;
				}
				else
				{
					m_lineString.Append(c);
					inTag = false;
				}
				if(c == '\n')
				{
					m_lineObjectList.Add(new LineInfo(m_lineImageTmpList, Mathf.RoundToInt(GetPreferredWidth(m_lineString.ToString()))));
					m_lineImageTmpList.Clear();
					m_lineString.Clear();
					lineCount++;
				}
			}
			m_lineObjectList.Add(new LineInfo(m_lineImageTmpList, Mathf.RoundToInt(GetPreferredWidth(m_lineString.ToString()))));
			m_lineObjectList.ForEach((LineInfo info) =>
			{
				//0x10FE8E8
				info.AdjustHorizontalAlignmentIcon(rectTransform.rect.width, textAnchorPivot.x);
			});
			m_lineObjectList.Clear();
			AdjustVerticalAlignmentIcon(m_imageObjectList, 1 - textAnchorPivot.y, GetTextHeight(text), rectTransform.rect.height);
		}

		//// RVA: 0x10FD16C Offset: 0x10FD16C VA: 0x10FD16C
		private float GetPreferredWidth(string text)
		{
			return cachedTextGeneratorForLayout.GetPreferredWidth(text, GetGenerationSettings(rectTransform.sizeDelta)) / pixelsPerUnit;
		}

		//// RVA: 0x10FDD60 Offset: 0x10FDD60 VA: 0x10FDD60
		private float GetTextHeight(string text)
		{
			return cachedTextGeneratorForLayout.GetPreferredHeight(text, GetGenerationSettings(rectTransform.sizeDelta)) / pixelsPerUnit;
		}

		//// RVA: 0x10FDFEC Offset: 0x10FDFEC VA: 0x10FDFEC
		private float GetFontScale()
		{
			return fontSize / font.fontSize;
		}

		//// RVA: 0x10FD288 Offset: 0x10FD288 VA: 0x10FD288
		private RawImage CreateIcon(int uvIndex, int xPosition, int returnCount)
		{
			IconTextSetting.UvRect r = IconTextSetting.SimpleRect;
			if(m_setting != null && m_setting.m_rects != null && m_setting.m_rects.Length > 0 && uvIndex < m_setting.m_rects.Length)
			{
				r = m_setting.m_rects[uvIndex];
			}
			RawImage im;
			if (m_imageCacheStack.Count == 0)
			{
				GameObject go = new GameObject(m_texModify.ToString());
				go.transform.localPosition = Vector3.zero;
				im = go.AddComponent<RawImage>();
				im.gameObject.layer = gameObject.layer;
			}
			else
			{
				im = m_imageCacheStack.Pop();
				im.name = m_texModify.ToString();
				im.gameObject.SetActive(true);
			}
			im.texture = m_setting.m_iconTexture;
			im.material = m_setting.m_material;
			im.uvRect = r.m_uv;
			Vector2 size = new Vector2(fontSize, fontSize);
			float scale = m_iconScale;
			float c = (m_iconScale - 1) * fontSize * 0.5f;
			if (r.m_isIgnoreScale)
			{
				size.x = r.m_uv.width * im.material.mainTexture.width;
				size.y = r.m_uv.height * im.material.mainTexture.height;
				scale = 1;
				c = size.y / 2 - fontSize / 2;
			}
			RectTransform rt = im.GetComponent<RectTransform>();
			rt.sizeDelta = size;
			rt.pivot = new Vector2(0, 1);
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			rt.SetParent(gameObject.transform);
			rt.localScale = new Vector2(scale, scale);
			rt.localRotation = Quaternion.identity;
			rt.anchoredPosition3D = new Vector3(xPosition, lineSpacing * GetFontScale() * font.lineHeight * returnCount - (r.m_yTopMargin + m_setting.m_iconTopMargin + c), 0);
			return im;
		}

		//// RVA: 0x10FDE7C Offset: 0x10FDE7C VA: 0x10FDE7C
		private void AdjustVerticalAlignmentIcon(List<RawImage> list, float alignment, float textHeight, float areaHeight)
		{
			for(int i = 0; i < list.Count; i++)
			{
				RectTransform rt = list[i].GetComponent<RectTransform>();
				rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, alignment * textHeight - alignment * areaHeight + rt.anchoredPosition.y);
			}
		}

		// RVA: 0x10FE0FC Offset: 0x10FE0FC VA: 0x10FE0FC Slot: 44
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			base.OnPopulateMesh(toFill);
			if(m_prevString != base.text)
			{
				m_prevString = base.text;
				m_dirtyUpdateText = true;
			}
		}

		// RVA: 0x10FE44C Offset: 0x10FE44C VA: 0x10FE44C Slot: 7
		protected override void OnDisable()
		{
			base.OnDisable();
			for(int i = 0; i < m_imageObjectList.Count; i++)
			{
				m_imageObjectList[i].gameObject.SetActive(false);
			}
		}

		// RVA: 0x10FE558 Offset: 0x10FE558 VA: 0x10FE558 Slot: 5
		protected override void OnEnable()
		{
			base.OnEnable();
			for (int i = 0; i < m_imageObjectList.Count; i++)
			{
				m_imageObjectList[i].gameObject.SetActive(true);
			}
		}
	}
}
