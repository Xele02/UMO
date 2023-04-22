using System;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common.uGUI
{
	public class RichtextAlphaOverwriter : LayoutUGUIScriptBase
	{
		private StringBuilder sb = new StringBuilder(8); // 0x14
		private Text targetText; // 0x18
		private Regex regexColorTag; // 0x1C
		private bool isContainColorTag; // 0x20
		private float prevTextAlpha; // 0x24
		private string prevTextString; // 0x28

		// RVA: 0xD397EC Offset: 0xD397EC VA: 0xD397EC
		private void Start()
		{
			regexColorTag = new Regex("(<color=#[0-9a-f]{6})([0-9a-f]{2})?(>)", RegexOptions.IgnoreCase);
			targetText = GetComponent<Text>();
			CheckContainColorTag();
			prevTextAlpha = float.NaN;
			prevTextString = targetText.text;
		}

		// RVA: 0xD39934 Offset: 0xD39934 VA: 0xD39934
		private void LateUpdate()
		{
			if(targetText.supportRichText)
			{
				bool isDiff = targetText.text != prevTextString;
				if(isDiff)
				{
					CheckContainColorTag();
					prevTextString = targetText.text;
				}
				if(isContainColorTag)
				{
					if(!Mathf.Approximately(targetText.color.a, prevTextAlpha) || isDiff)
					{
						OverwriteColorTagAlpha(targetText.color.a);
						prevTextString = targetText.text;
						prevTextAlpha = targetText.color.a;
					}
				}
			}
		}

		// // RVA: 0xD398D0 Offset: 0xD398D0 VA: 0xD398D0
		private void CheckContainColorTag()
		{
			isContainColorTag = regexColorTag.IsMatch(targetText.text);
		}

		// // RVA: 0xD39B64 Offset: 0xD39B64 VA: 0xD39B64
		private void OverwriteColorTagAlpha(float alpha)
		{
			targetText.text = regexColorTag.Replace(targetText.text, "${1}"+ToHexa(alpha)+"${3}");
		}

		// // RVA: 0xD39C58 Offset: 0xD39C58 VA: 0xD39C58
		private string ToHexa(float ZeroToOneValue)
		{
			return Convert.ToString(Mathf.RoundToInt(ZeroToOneValue * 255), 16).PadLeft(2, '0');
		}
	}
}
