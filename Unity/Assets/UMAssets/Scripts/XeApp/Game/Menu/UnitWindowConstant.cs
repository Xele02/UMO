
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public static class UnitWindowConstant // TypeDefIndex: 16497
	{
		public enum OperationMode
		{
			Edit = 0,
			Check = 0,
			Detail = 1,
			Max = 2,
		}

		public enum DispMode
		{
			Unit = 0,
			SkillDetails = 1,
		}

		public static readonly Dictionary<int, DisplayType> SortItemToDisplayType = new Dictionary<int, DisplayType>()
		{
			{ 0, DisplayType.Total }, { 1, DisplayType.Soul}, {2, DisplayType.Vocal}, { 3, DisplayType.Charm}, { 4, DisplayType.Get}, { 5, DisplayType.Level},
			{ 6, DisplayType.Level}, { 7, DisplayType.Life}, {8, DisplayType.Luck}, { 9, DisplayType.Support}, { 10, DisplayType.Fold}, { 20, DisplayType.ActiveSkill},
			{ 21, DisplayType.LiveSkill}, { 22, DisplayType.EpisodeName}, { 23, DisplayType.SecretBoard}, { 29, DisplayType.LuckyLeaf}, { 38, DisplayType.MusicExp},
			{ 47, DisplayType.NotesExpectation}
		}; // 0x0
		public static readonly string[] m_paletteFrameNameTable = new string[11] {
			"01", "02", "03", "04", "05", "06", "06", "03", "05", "02", "07"
		}; // 0x4
		public static readonly string m_skillCompatibleDiva = "02"; // 0x8
		public const int SkillDescriptionCountLimit = 21;
		public const int StatusTextCount = 3;
		private static List<UILineInfo> m_uiLineInfo = new List<UILineInfo>(4); // 0xC

		//// RVA: 0x1254884 Offset: 0x1254884 VA: 0x1254884
		public static void Validate(ILDKBCLAFPB.IJDOCJCLAIL_SortProprty sortProperty)
		{
			if(!SortItemToDisplayType.ContainsKey(sortProperty.LNFFKCDNCPN_sceneSelectSortItem))
			{
				sortProperty.LNFFKCDNCPN_sceneSelectSortItem = 6;
			}
			if(!SortItemToDisplayType.ContainsKey(sortProperty.GEAECNMDMHH_sceneListSortItem))
			{
				sortProperty.GEAECNMDMHH_sceneListSortItem = 6;
			}
		}

		//// RVA: 0x1252E90 Offset: 0x1252E90 VA: 0x1252E90
		public static bool SetSkillDetails(Text text, string descript, int lineCount = 1)
		{
			text.horizontalOverflow = HorizontalWrapMode.Wrap;
			text.verticalOverflow = VerticalWrapMode.Overflow;
			text.resizeTextForBestFit = false;

			int startIndex = descript.Length;
			Vector2 size = text.rectTransform.sizeDelta;
			TextGenerationSettings settings = text.GetGenerationSettings(size);
			TextGenerator textGen = text.cachedTextGenerator;
			/*for(int i = 20; i > 0; i--)
			{
				//??
			}*/
			text.text = descript;
			/*for(int i = 20; i > 0; i--)
			{
				//??
			}*/
			textGen.Populate(text.text, settings);
			textGen.GetLines(m_uiLineInfo);
			if(lineCount < m_uiLineInfo.Count)
			{
				startIndex = Mathf.Max(0, m_uiLineInfo[lineCount].startCharIdx - 3);
				char[] c = descript.Substring(startIndex).ToCharArray();
				int j = 0;
				for(int i = 0; i < c.Length; i++)
				{
					if(c[i] == '<')
					{
						if(c[i + 1] == '/')
							j++;
						else
							j--;
					}
				}
				if(j > 0)
				{
					c = descript.Substring(0, startIndex).ToCharArray();
					for(int i = c.Length - 1; i >= 0; i--)
					{
						if(c[i] == '<')
						{
							j--;
							startIndex = i;
							if(j == 0)
								break;
						}
					}
				}
				c = descript.Substring(startIndex).ToCharArray();
				for(int i = 0; i < c.Length; i++)
				{
					if(c[i] == '<')
						break;
					if(c[i] == '>')
					{
						startIndex += i + 1;
						break;
					}
				}
			}
			text.text = descript.Substring(0, Mathf.Min(descript.Length, startIndex));
			if(text.text.Length < descript.Length)
			{
				text.text += JpStringLiterals.StringLiteral_12038;
			}
			return text.text.Length < descript.Length;
		}

		//// RVA: 0x12549E0 Offset: 0x12549E0 VA: 0x12549E0
		//public static void SetLiveSkillDetails(Text text, string descript) { }

		//// RVA: 0x124C89C Offset: 0x124C89C VA: 0x124C89C
		public static void SetInvalidText(Text text, TextAnchor anchor = TextAnchor.MiddleCenter)
		{
			text.alignment = anchor;
			text.text = TextConstant.InvalidText;
		}

		//// RVA: 0x1254A50 Offset: 0x1254A50 VA: 0x1254A50
		//public static void SetStatusValue(Text[] texts, int value, int topIndex, bool isSign = False) { }

		//// RVA: 0x124E49C Offset: 0x124E49C VA: 0x124E49C
		//public static void SetButtonLabel(RawImageEx image, TexUVData uvData, TexUVList texUvList) { }

		//// RVA: 0x1254AF8 Offset: 0x1254AF8 VA: 0x1254AF8
		public static void SetLuckText(Text text, int luck)
		{
			text.text = MakeLuckText(luck);
		}

		//// RVA: 0x1254BA8 Offset: 0x1254BA8 VA: 0x1254BA8
		public static string MakeLuckText(int luck)
		{
			return string.Format(luck > 0 ? "+{0}" : "{0}", luck);
		}
	}
}
