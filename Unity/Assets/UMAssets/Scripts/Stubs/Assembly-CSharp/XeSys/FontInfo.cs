using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game;

namespace XeSys
{
	[Serializable]
	public class FontInfo
	{
		public Font font;
		public int size = 1;
		public float lineSpacing = -1;
		public float widgetHeightRatio = 1;

		public void Apply(Text Text, bool Force = true)
		{
			FontInfo defInfo = GameManager.Instance.GetSystemFont(true);
			if(Text.font == null || Text.font == defInfo.font || Force)
			{
				Text.font = font;
				if(lineSpacing != -1)
				{
					Text.lineSpacing = GetLineSpace(Text.lineSpacing);
				}
				if(widgetHeightRatio != 1)
				{
					RectTransform rt = Text.rectTransform;
					if(NeedFixHeight(rt, Text.fontSize))
						Text.verticalOverflow = VerticalWrapMode.Overflow;
				}
				Text.FontTextureChanged();
			}
		}
		public void Apply(TextMesh Text, bool Force = true)
		{
			FontInfo defInfo = GameManager.Instance.GetSystemFont(true);
			if(Text.font == null || Text.font == defInfo.font || Force)
			{
				Text.font = font;
				if(lineSpacing != -1)
				{
					Text.lineSpacing = GetLineSpace(Text.lineSpacing);
				}
				if(widgetHeightRatio != 1)
				{
					RectTransform rt = Text.GetComponent<RectTransform>();
				}
			}
		}

		private bool NeedFixHeight(RectTransform rt, float fontSize)
		{
			if(rt != null)
			{
				float minSize = Mathf.CeilToInt(widgetHeightRatio * fontSize);
				Vector3[] corners = new Vector3[4];
				rt.GetLocalCorners(corners);
				if(Mathf.Abs(corners[0].y - corners[1].y) < minSize)
				{
					return true;
				}
			}
			return false;
		}

		public float GetLineSpace(float lineSpace)
		{
			if(lineSpacing != -1)
				return lineSpace * lineSpacing / 0.6f;
			return lineSpace;
		}

		public Text ReplaceTmpText(TextMeshProUGUI Text)
		{
			if(RuntimeSettings.CurrentSettings.Language == "zh_Hans")
			{
				GameObject go = new GameObject(Text.name);
				Text t = go.AddComponent<Text>();
				GameManager.Instance.GetSystemFont().Apply(t);
				t.color = Text.color;
				t.fontSize = (int)Text.fontSize;
				switch(Text.alignment)
				{
					case TextAlignmentOptions.TopLeft:
						t.alignment = TextAnchor.UpperLeft;
						break;
					case TextAlignmentOptions.Top:
					case TextAlignmentOptions.TopJustified:
						t.alignment = TextAnchor.UpperCenter;
						break;
					case TextAlignmentOptions.TopRight:
						t.alignment = TextAnchor.UpperRight;
						break;
					case TextAlignmentOptions.Left:
						t.alignment = TextAnchor.MiddleLeft;
						break;
					case TextAlignmentOptions.Center:
						t.alignment = TextAnchor.MiddleCenter;
						break;
					case TextAlignmentOptions.Right:
						t.alignment = TextAnchor.MiddleRight;
						break;
					case TextAlignmentOptions.BottomLeft:
						t.alignment = TextAnchor.LowerLeft;
						break;
					case TextAlignmentOptions.Bottom:
					case TextAlignmentOptions.BottomJustified:
						t.alignment = TextAnchor.LowerCenter;
						break;
					case TextAlignmentOptions.BottomRight:
						t.alignment = TextAnchor.LowerRight;
						break;
					default:
						UnityEngine.Debug.LogError("Unkown alignment : "+Text.alignment);
						break;
				}
				t.horizontalOverflow = Text.enableWordWrapping ? HorizontalWrapMode.Wrap : HorizontalWrapMode.Overflow;
				t.verticalOverflow = Text.isTextOverflowing ? VerticalWrapMode.Overflow : VerticalWrapMode.Truncate;
				t.text = Text.text;
				t.transform.SetParent(Text.transform.parent);
				t.transform.SetSiblingIndex(Text.transform.GetSiblingIndex());
				t.rectTransform.sizeDelta = Text.rectTransform.sizeDelta;
				t.rectTransform.anchoredPosition = Text.rectTransform.anchoredPosition;
				t.rectTransform.anchorMax = Text.rectTransform.anchorMax;
				t.rectTransform.anchorMin = Text.rectTransform.anchorMin;
				t.rectTransform.pivot = Text.rectTransform.pivot;
				GameObject.Destroy(Text.gameObject);
				return t;
			}
			return null;
		}

	}
}
