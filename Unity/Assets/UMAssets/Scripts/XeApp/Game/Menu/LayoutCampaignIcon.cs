using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutCampaignIcon : SwapScrollListContent
	{
		[SerializeField] // RVA: 0x66A8B0 Offset: 0x66A8B0 VA: 0x66A8B0
		private Text m_textDayTime; // 0x20
		private AbsoluteLayout m_layoutOnOff; // 0x24
		private AbsoluteLayout m_layoutStamp; // 0x28
		private OLLAFCBLMIJ.KAAHBIABMBC m_info; // 0x2C

		public int dayId { get { return m_info != null ? m_info.ECDKPAIEFFA_DayId : -1; } } //0x19D5EA4

		// RVA: 0x19D5880 Offset: 0x19D5880 VA: 0x19D5880
		public void Setup(OLLAFCBLMIJ.KAAHBIABMBC info)
		{
			m_info = info;
			m_textDayTime.text = string.Format("{0}/{1}", info.KLCMKLPIDDJ, info.BAOFEFFADPD);
			m_layoutStamp.StartChildrenAnimGoStop(!info.CDMGDFLPPHN_HasStamp ? "02" : "01");
			m_layoutOnOff.StartChildrenAnimGoStop(!info.CKJPGFCCPIL_IsEnded ? "01" : "02");
		}

		// // RVA: 0x19D5EB8 Offset: 0x19D5EB8 VA: 0x19D5EB8
		public void SetStamp(bool enable)
		{
			m_layoutStamp.StartChildrenAnimGoStop(enable ? "01" : "02");
		}

		// RVA: 0x19D5F50 Offset: 0x19D5F50 VA: 0x19D5F50 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutOnOff = layout.FindViewById("swtbl_lt_get_icon") as AbsoluteLayout;
			m_layoutStamp = layout.FindViewById("swtbl_lt_stamp") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
