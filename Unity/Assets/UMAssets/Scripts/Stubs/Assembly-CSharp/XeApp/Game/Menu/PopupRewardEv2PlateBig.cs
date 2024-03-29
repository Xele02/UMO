using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2PlateBig : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textPlateName;
		[SerializeField]
		private Text[] m_textPointList;
		[SerializeField]
		private Text m_textPointTitle;
		[SerializeField]
		private Text m_textPointPage;
		[SerializeField]
		private Text[] m_textRankingList;
		[SerializeField]
		private Text m_textRankingTitle;
		[SerializeField]
		private Text m_textRankingPage;
		[SerializeField]
		private RawImageEx m_imagePlate;
		[SerializeField]
		private StayButton m_buttonPlate;
		[SerializeField]
		private ActionButton[] m_buttonPoint;
		[SerializeField]
		private ActionButton[] m_buttonRanking;
	}
}
