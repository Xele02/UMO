using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EpisodeCompWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_point_episode;
		[SerializeField]
		private NumberBase m_point_den;
		[SerializeField]
		private NumberBase m_point_mol;
		[SerializeField]
		private NumberBase m_point_item_num;
		[SerializeField]
		private Text m_episode_info;
		[SerializeField]
		private Text m_next;
		[SerializeField]
		private RawImageEx m_episode_image;
		[SerializeField]
		private RawImageEx m_episode_image2;
		[SerializeField]
		private RawImageEx m_line_image;
		[SerializeField]
		private RawImageEx m_next_image;
		[SerializeField]
		private RawImageEx m_item_image;
		[SerializeField]
		private Transform m_start_point;
		[SerializeField]
		private RectTransform m_end_point;
	}
}
