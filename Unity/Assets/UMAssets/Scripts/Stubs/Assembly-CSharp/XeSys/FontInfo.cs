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
			}
		}

		public float GetLineSpace(float lineSpace)
		{
			if(lineSpacing != -1)
				return lineSpace * lineSpacing / 0.6f;
			return lineSpace;
		}

	}
}
