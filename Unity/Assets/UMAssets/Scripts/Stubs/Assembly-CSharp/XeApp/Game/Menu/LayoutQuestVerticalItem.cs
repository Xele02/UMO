using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutQuestVerticalItem : SwapScrollListContent
	{
		[SerializeField]
		private NumberBase m_mol;
		[SerializeField]
		private NumberBase m_den;
		[SerializeField]
		private ActionButton m_buttonChallenge;
		[SerializeField]
		private ActionButton m_buttonReceive;
		[SerializeField]
		private StayButton m_itemDetailsButton;
		[SerializeField]
		private RawImageEx m_icon;
		[SerializeField]
		private Text m_desc1;
		[SerializeField]
		private Text m_desc2;
		[SerializeField]
		private Text m_time;
		[SerializeField]
		private NumberBase m_rewardNum;
	}
}
