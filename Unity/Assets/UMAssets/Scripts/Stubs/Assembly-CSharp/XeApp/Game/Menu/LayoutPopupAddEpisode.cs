using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAddEpisode : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text[] m_episodeDesc;
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private Text m_homeBgName;
		[SerializeField]
		private Text[] m_rewardName;
		[SerializeField]
		private Text[] m_desc;
		[SerializeField]
		private RawImageEx[] m_image;
		[SerializeField]
		private RawImageEx m_episodeImage;
		[SerializeField]
		private RawImageEx m_episodeBgImage;
	}
}
