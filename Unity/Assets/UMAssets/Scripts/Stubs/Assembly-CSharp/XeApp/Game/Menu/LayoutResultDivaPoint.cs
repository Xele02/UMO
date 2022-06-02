using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutResultDivaPoint : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase[] m_total_point;
		[SerializeField]
		private NumberBase m_diff_point;
		[SerializeField]
		private NumberBase m_score_point;
		[SerializeField]
		private NumberBase m_score_magnification;
		[SerializeField]
		private Text m_music_name;
		[SerializeField]
		private RawImageEx m_music_cd_image;
	}
}
