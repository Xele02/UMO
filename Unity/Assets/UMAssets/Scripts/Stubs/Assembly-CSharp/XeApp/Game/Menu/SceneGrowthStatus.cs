using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SceneGrowthStatus : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private RawImageEx m_titleIconImage;
		[SerializeField]
		private Text[] m_statusText;
		[SerializeField]
		private Text[] m_skillLevel;
		[SerializeField]
		private Text[] m_skillDescript;
		[SerializeField]
		private RawImageEx[] m_skillRankImages;
		[SerializeField]
		private RawImageEx[] m_skillInfoImages;
		[SerializeField]
		private Text[] m_commonText;
		[SerializeField]
		private ActionButton[] m_pageChangeButton;
		[SerializeField]
		private ActionButton[] m_skillInfoButtons;
		[SerializeField]
		private SceneGrowthEpisodeGauge m_episodeGauge;
		[SerializeField]
		private SceneGrowthEpisodeStatus m_episodeStatus;
		[SerializeField]
		private ActionButton m_storyButton;
	}
}
