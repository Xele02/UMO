using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SceneGrowthPanel : SceneGrowthPanelBase
	{
		[SerializeField]
		private RawImageEx m_labelImage;
		[SerializeField]
		private RawImageEx m_episodeIcon;
		[SerializeField]
		private NumberBase m_number;
		[SerializeField]
		private RawImageEx[] m_numberImages;
		[SerializeField]
		private ActionButton m_button;
	}
}
