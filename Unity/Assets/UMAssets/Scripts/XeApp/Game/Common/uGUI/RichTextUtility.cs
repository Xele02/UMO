using System.Text;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Common.uGUI
{
	public class RichTextUtility
	{
		private static readonly StringBuilder sb = new StringBuilder(256); // 0x0

		// RVA: 0xD39370 Offset: 0xD39370 VA: 0xD39370
		public static string MakeColorTagString(string str, string htmlFormatColor)
		{
			sb.SetFormat("<color={0}>{1}</color>", htmlFormatColor, str);
			return sb.ToString();
		}

		//// RVA: 0xD3946C Offset: 0xD3946C VA: 0xD3946C
		public static void ChangeColor(Text uguiText, string htmlFormatColor)
		{
			if (!uguiText.supportRichText)
				return;
			uguiText.text = MakeColorTagString(uguiText.text, htmlFormatColor);
		}

		//// RVA: 0xD39558 Offset: 0xD39558 VA: 0xD39558
		public static string MakeSizeTagString(string str, int size)
		{
			sb.SetFormat("<size={0}>{1}</size>", size, str);
			return str.ToString();
		}

		//// RVA: 0xD39674 Offset: 0xD39674 VA: 0xD39674
		//public static void ChangeSize(Text uguiText, int size) { }
	}
}
