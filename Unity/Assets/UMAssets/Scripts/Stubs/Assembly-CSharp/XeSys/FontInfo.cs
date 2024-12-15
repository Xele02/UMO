using System;
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

		public void Apply(Text Text)
		{
			FontInfo defInfo = GameManager.Instance.GetSystemFont(true);
			if(Text.font == null || Text.font == defInfo.font)
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
		public void Apply(TextMesh Text)
		{
			FontInfo defInfo = GameManager.Instance.GetSystemFont(true);
			if(Text.font == null || Text.font == defInfo.font)
			{
				FontInfo info = GameManager.Instance.GetSystemFont();
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

	}
}
