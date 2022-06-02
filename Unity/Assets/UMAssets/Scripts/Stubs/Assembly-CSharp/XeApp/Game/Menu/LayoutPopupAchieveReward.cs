using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAchieveReward : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx[] m_icons;
		[SerializeField]
		private NumberBase[] m_nums;
		[SerializeField]
		private Text[] m_texts;
		[SerializeField]
		private string[] m_layerNames;
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_clearNum;
		[SerializeField]
		private Text m_scoreNum;
		[SerializeField]
		private Text m_comboNum;
		[SerializeField]
		private RawImageEx[] m_diffImages;
	}
}
