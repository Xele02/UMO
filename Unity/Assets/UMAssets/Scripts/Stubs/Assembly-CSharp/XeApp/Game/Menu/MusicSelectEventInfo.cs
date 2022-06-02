using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectEventInfo : LayoutLabelScriptBase
	{
		[SerializeField]
		private NumberBase m_curTicketCount;
		[SerializeField]
		private Text m_curTicketLabelText;
		[SerializeField]
		private Text m_curValueLabelText;
		[SerializeField]
		private Text m_curValueText;
		[SerializeField]
		private Text m_curValueUnitText;
		[SerializeField]
		private Text m_bpValueLabelText;
		[SerializeField]
		private Text m_bpValueText;
		[SerializeField]
		private Text m_bpValueUnitText;
		[SerializeField]
		private Text[] m_rankLabelText;
		[SerializeField]
		private Text[] m_rankOrderText;
		[SerializeField]
		private Text[] m_rankOrderUnitText;
		[SerializeField]
		private Text m_nextLabelText;
		[SerializeField]
		private Text m_nextValueText;
		[SerializeField]
		private Text m_nextValueUnitText;
		[SerializeField]
		private Text m_rewardLabelText;
		[SerializeField]
		private Text m_rewardEndText;
		[SerializeField]
		private RawImageEx m_rewardIconImage;
		[SerializeField]
		private RawImageEx m_eventTicketImage;
	}
}
