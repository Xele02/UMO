using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionCardName : MonoBehaviour
	{
		[SerializeField]
		private Renderer m_renderer; // 0xC
		[SerializeField]
		private TextMesh m_textMesh; // 0x10
		[SerializeField]
		private int m_shortTextLength = 14; // 0x14
		[SerializeField]
		private int m_shortFontSize = 40; // 0x18
		[SerializeField]
		private int m_longTextLength = 17; // 0x1C
		[SerializeField]
		private int m_longFontSize = 32; // 0x20
		[SerializeField]
		private Color m_fontColorHoshi; // 0x24
		[SerializeField]
		private Color m_fontColorAi; // 0x34
		[SerializeField]
		private Color m_fontColorInochi; // 0x44
		[SerializeField]
		private Color m_fontColorZen; // 0x54

		// // RVA: 0x1C16754 Offset: 0x1C16754 VA: 0x1C16754
		// private void Reset() { }

		// RVA: 0x1C167D8 Offset: 0x1C167D8 VA: 0x1C167D8
		public void SetText(string text)
		{
			m_textMesh.text = text;
			RecalcFontSize();
		}

		// // RVA: 0x1C16818 Offset: 0x1C16818 VA: 0x1C16818
		public void RecalcFontSize()
		{
			int len = m_textMesh.text.Length;
			if(m_shortTextLength < len)
			{
				if(len < m_longTextLength)
				{
					m_textMesh.fontSize = Mathf.FloorToInt((len - m_shortTextLength) * 1.0f / (m_longTextLength - m_shortTextLength) * (m_longFontSize - m_shortFontSize) + m_shortFontSize);
				}
				else
				{
					m_textMesh.fontSize = m_longFontSize;
				}
			}
			else
			{
				m_textMesh.fontSize = m_shortFontSize;
			}
		}

		// RVA: 0x1C16974 Offset: 0x1C16974 VA: 0x1C16974
		public void SetFont(XeSys.FontInfo font)
		{
			font.Apply(m_textMesh);
			m_renderer.sharedMaterial = font.font.material;
		}

		// RVA: 0x1C169F0 Offset: 0x1C169F0 VA: 0x1C169F0
		public void SetAttribute(GameAttribute.Type attr)
		{
			switch(attr)
			{
				case GameAttribute.Type.Yellow:
					m_textMesh.color = m_fontColorHoshi;
					break;
				case GameAttribute.Type.Red:
					m_textMesh.color = m_fontColorAi;
					break;
				case GameAttribute.Type.Blue:
					m_textMesh.color = m_fontColorInochi;
					break;
				case GameAttribute.Type.All:
					m_textMesh.color = m_fontColorZen;
					break;
				default:
					break;
			}
		}
	}
}
