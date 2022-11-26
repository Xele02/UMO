using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class MusicNameLabel : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text; // 0x14
		private int m_initialFontSize = -1; // 0x18

		// RVA: 0xF763AC Offset: 0xF763AC VA: 0xF763AC
		public void SetMusicId(int musicNameId)
		{
			if(Database.Instance.musicText == null)
			{
				m_text.text = MessageManager.Instance.GetMessage("master", string.Format("mn_{0:D3}", musicNameId));
			}
			else
			{
				m_text.text = Database.Instance.musicText.Get(musicNameId).musicName;
			}
			RecalcFontSize();
		}

		//// RVA: 0xF77114 Offset: 0xF77114 VA: 0xF77114
		private void RecalcFontSize()
		{
			m_text.fontSize = m_initialFontSize;
			Rect r = m_text.GetComponent<RectTransform>().rect;
			float f = 0;
			int a = 0;
			if(Screen.width * 1.0f / Screen.height >= 1.494949f)
			{
				a = Screen.height;
				f = 792;
			}
			else
			{
				a = Screen.width;
				f = 1184;
			}
			Vector2 v = new Vector2(r.width, r.height);
			v *= a / f;
			TextGenerationSettings setting = m_text.GetGenerationSettings(v);
			float pw = m_text.cachedTextGenerator.GetPreferredWidth(m_text.text, setting);
			float ph = m_text.cachedTextGenerator.GetPreferredHeight(m_text.text, setting);
			m_text.fontSize = System.Math.Min(Mathf.FloorToInt(v.x / pw * m_initialFontSize), m_initialFontSize);
		}

		// RVA: 0xF775D4 Offset: 0xF775D4 VA: 0xF775D4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_initialFontSize = m_text.fontSize;
			Loaded();
			return true;
		}
	}
}
