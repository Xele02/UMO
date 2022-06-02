using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SceneGrowthEpisodeStatus : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_den;
		[SerializeField]
		private NumberBase m_num;
		[SerializeField]
		private NumberBase m_rewardNum;
		[SerializeField]
		private RawImageEx m_rewordIcon;
		[SerializeField]
		private Text m_episodeName;
		[SerializeField]
		private Text m_nextRewordPoint;
	}
}
