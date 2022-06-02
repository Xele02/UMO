using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferInfoLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_OfferName;
		[SerializeField]
		private Text m_EnemyPower;
		[SerializeField]
		private Text m_OfferClearTime;
		[SerializeField]
		private Text m_Attack;
		[SerializeField]
		private Text m_Hit;
		[SerializeField]
		private RawImageEx m_SeriesLog;
		public bool IsLackPower;
	}
}
