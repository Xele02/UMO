using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaEventInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase[] m_numStatusTotalLvTbl;
		[SerializeField]
		private Text[] m_textStatusExpTbl;
		[SerializeField]
		private ActionButton m_buttonStatusDetail;
		[SerializeField]
		private Text[] m_textInfoTbl;
		[SerializeField]
		private RawImageEx m_imageNextReward;
	}
}
