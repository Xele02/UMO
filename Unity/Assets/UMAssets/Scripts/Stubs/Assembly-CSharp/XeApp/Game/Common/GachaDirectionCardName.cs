using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionCardName : MonoBehaviour
	{
		[SerializeField]
		private Renderer m_renderer;
		[SerializeField]
		private TextMesh m_textMesh;
		[SerializeField]
		private int m_shortTextLength;
		[SerializeField]
		private int m_shortFontSize;
		[SerializeField]
		private int m_longTextLength;
		[SerializeField]
		private int m_longFontSize;
		[SerializeField]
		private Color m_fontColorHoshi;
		[SerializeField]
		private Color m_fontColorAi;
		[SerializeField]
		private Color m_fontColorInochi;
		[SerializeField]
		private Color m_fontColorZen;
	}
}
