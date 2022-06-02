using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class TipsContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_titleTexts;
		[SerializeField]
		private Text[] m_contentTexts;
		[SerializeField]
		private RawImageEx m_image;
		[SerializeField]
		private string m_layerName;
	}
}
