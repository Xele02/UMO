using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CommonMenuStackLabel2 : LayoutLabelScriptBase
	{
		public enum LabelType
		{
			_None = -2,
			_Undefined = -1,
			MusicRate = 0,
			_Num = 1,
		}

		private static readonly string s_labelImageUvFormat = "cmn_back_title_{0:D2}"; // 0x0
		private const int s_labelBgLongLength = 14;
		private static readonly string[] s_groupToDescIdFormat = new string[1] { "header_desc_musicrate{0:D3}" }; // 0x4
		[SerializeField]
		private RawImageEx m_labelImage; // 0x18
		[SerializeField]
		private RectTransform m_labelImageRect; // 0x1C
		[SerializeField]
		private Vector2 m_labelTexSize; // 0x20
		[SerializeField]
		private Text m_description; // 0x28
		private List<Vector2> m_labelImageSizes; // 0x2C
		private List<Rect> m_labelUvRects; // 0x30
		private StringBuilder m_descIdBuilder = new StringBuilder(32); // 0x34
		private LayoutSymbolData m_symbolLabelBg; // 0x38

		// RVA: 0x1B4AE94 Offset: 0x1B4AE94 VA: 0x1B4AE94
		public void SetLabel(LabelType type)
		{
			if(type != LabelType._Undefined)
			{
				m_labelImage.uvRect = m_labelUvRects[(int)type];
				m_labelImageRect.sizeDelta = m_labelImageSizes[(int)type];
			}
		}

		// RVA: 0x1B4AFB4 Offset: 0x1B4AFB4 VA: 0x1B4AFB4
		public void SetDescription(LabelType type, int descId)
		{
			if(descId > -1)
			{
				m_descIdBuilder.SetFormat(s_groupToDescIdFormat[(int)type], descId);
				m_description.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(m_descIdBuilder.ToString());
				m_symbolLabelBg.StartAnim(m_description.text.Length < 14 ? "short" : "long");
			}
		}

		// RVA: 0x1B4C5C8 Offset: 0x1B4C5C8 VA: 0x1B4C5C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			StringBuilder str = new StringBuilder(s_labelImageUvFormat.Length);
			m_labelUvRects = new List<Rect>(1);
			m_labelImageSizes = new List<Vector2>(1);
			str.SetFormat(s_labelImageUvFormat, 26);
			m_labelUvRects.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString())));
			float f = m_labelTexSize.x * m_labelUvRects[0].width;
			float f2 = m_labelTexSize.y * m_labelUvRects[0].height;
			m_labelImageSizes.Add(new Vector2(Mathf.RoundToInt(f), Mathf.RoundToInt(f2)));
			m_description.text = "";
			m_symbolLabelBg = CreateSymbol("label_bg", layout);
			Loaded();
			return true;
		}
	}
}
