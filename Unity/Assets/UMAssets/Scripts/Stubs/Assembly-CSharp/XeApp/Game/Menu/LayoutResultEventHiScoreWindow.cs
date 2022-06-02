using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutResultEventHiScoreWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_image_jacket;
		[SerializeField]
		private Text m_text_episode;
		[SerializeField]
		private Text m_text_episode_rate;
		[SerializeField]
		private Text m_text_rank;
		[SerializeField]
		private ActionButton m_btn_ok;
		[SerializeField]
		private NumberBase m_Number01;
		[SerializeField]
		private NumberBase m_Number02;
		[SerializeField]
		private NumberBase m_Number03;
	}
}
