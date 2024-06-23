using System.Text;
using UnityEngine.UI;

namespace XeApp.Game
{
	public static class TextGeneratorUtility
	{
		// Fields
		private static StringBuilder strBuilder = new StringBuilder(256); // 0x0

		// RVA: 0x1570028 Offset: 0x1570028 VA: 0x1570028
		public static bool SetTextRectangleMessage(Text textComponent, string message, int lineCount/* = 1*/, string Censoringtext/* = JpStringLiterals.StringLiteral_12038*/)
		{
			strBuilder.Clear();
			string str = message;
			UnityEngine.TextGenerationSettings setting = textComponent.GetGenerationSettings(textComponent.rectTransform.sizeDelta);
			int line = 0;
			bool b = false;
			for (int i = 0; i < str.Length; i++)
			{
				strBuilder.Append(str[i]);
				float f = textComponent.cachedTextGenerator.GetPreferredWidth(strBuilder.ToString(), setting);
				if(str[i] == '\n')
					line++;
				if(textComponent.rectTransform.sizeDelta.x - 20 <= f /*/ ??*/)
				{
					line++;
					if(lineCount <= line)
					{
						strBuilder.Remove(strBuilder.Length - 2, 2);
						strBuilder.Append(Censoringtext);
						b = true;
						break;
					}
					strBuilder.Insert(strBuilder.Length - 1, '\n');
				}
			}
			textComponent.text = strBuilder.ToString();
			return b;
		}

		// RVA: 0x1570698 Offset: 0x1570698 VA: 0x1570698
		public static bool SetTextNewLineMessage(Text textComponent, string message)
		{
			strBuilder.Clear();
			UnityEngine.TextGenerationSettings setting = textComponent.GetGenerationSettings(textComponent.rectTransform.sizeDelta);
			bool res = false;
			for(int i = 0; i < message.Length; i++)
			{
				strBuilder.Append(message[i]);
				float w = textComponent.cachedTextGenerator.GetPreferredWidth(strBuilder.ToString(), setting);
				float h = textComponent.cachedTextGenerator.GetPreferredWidth(strBuilder.ToString(), setting);
				if(textComponent.rectTransform.sizeDelta.x <= w / setting.scaleFactor)
				{
					strBuilder.Insert(strBuilder.Length - 1, '\n');
				}
				res |= textComponent.rectTransform.sizeDelta.y <= h / setting.scaleFactor;
			}
			textComponent.text = strBuilder.ToString();
			return res;
		}
	}
}
