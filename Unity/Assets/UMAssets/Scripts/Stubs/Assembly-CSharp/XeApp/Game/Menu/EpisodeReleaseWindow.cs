using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EpisodeReleaseWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_plas;
		[SerializeField]
		private ActionButton m_minus;
		[SerializeField]
		private ActionButton m_plas_ten;
		[SerializeField]
		private ActionButton m_minus_ten;
		[SerializeField]
		private NumberBase m_point_den;
		[SerializeField]
		private NumberBase m_point_mol;
		[SerializeField]
		private NumberBase m_point_item_num;
		[SerializeField]
		private Text m_episode_item;
		[SerializeField]
		private Text m_item_value;
		[SerializeField]
		private Text m_caution;
		[SerializeField]
		private Text m_episode_item_num;
		[SerializeField]
		private Text m_item_name;
		[SerializeField]
		private RawImageEx m_episode_item_image;
		[SerializeField]
		private RawImageEx m_item_image;
		[SerializeField]
		private PopupEpisodeRelease m_pop_window;
	}
}
