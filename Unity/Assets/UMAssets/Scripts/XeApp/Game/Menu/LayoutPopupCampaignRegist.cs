using System;
using System.Linq;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupCampaignRegist : LayoutUGUIScriptBase
	{
		private Text m_textAppPeriod; // 0x14
		private Text m_textCaution1; // 0x18
		private Text m_textCaution2; // 0x1C
		private Text m_textCaution3; // 0x20
		private Text m_textPlayerId; // 0x24
		private Text m_textContent; // 0x28
		private ActionButton m_buttonIDCopy; // 0x2C
		private OLLAFCBLMIJ m_view; // 0x30
		public Action OnClickButtonIDCopy; // 0x34

		// // RVA: 0x1EBCE64 Offset: 0x1EBCE64 VA: 0x1EBCE64
		public void Setup(int playerId, OLLAFCBLMIJ view)
		{
			m_view = view;
			m_textAppPeriod.text = string.Format(MessageManager.Instance.GetMessage("menu", "campaign_live_3rd_period2"), new object[10]
			{
				view.HGGFIEELABK_Start.Year, view.HGGFIEELABK_Start.Month, view.HGGFIEELABK_Start.Day, view.HGGFIEELABK_Start.Hour, view.HGGFIEELABK_Start.Minute,
				view.KHNIJBEPHPL_End1.Year, view.KHNIJBEPHPL_End1.Month, view.KHNIJBEPHPL_End1.Day, view.KHNIJBEPHPL_End1.Hour, view.KHNIJBEPHPL_End1.Minute
			});
			m_textPlayerId.text = playerId.ToString();
		}

		// RVA: 0x1EBD544 Offset: 0x1EBD544 VA: 0x1EBD544 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textAppPeriod = txts.Where((Text _) =>
			{
				//0x1EBE030
				return _.name == "txt_01 (TextView)";
			}).First();
			m_textCaution1 = txts.Where((Text _) =>
			{
				//0x1EBE0B0
				return _.name == "txt_02 (TextView)";
			}).First();
			m_textCaution2 = txts.Where((Text _) =>
			{
				//0x1EBE130
				return _.name == "txt_03 (TextView)";
			}).First();
			m_textCaution3 = txts.Where((Text _) =>
			{
				//0x1EBE1B0
				return _.name == "txt_06 (TextView)";
			}).First();
			m_textPlayerId = txts.Where((Text _) =>
			{
				//0x1EBE230
				return _.name == "txt_04 (TextView)";
			}).First();
			m_textContent = txts.Where((Text _) =>
			{
				//0x1EBE2B0
				return _.name == "txt_05 (TextView)";
			}).First();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textCaution1.text = bk.GetMessageByLabel("campaign_live_3rd_coution_04");
			m_textCaution2.text = bk.GetMessageByLabel("campaign_live_3rd_coution_05");
			m_textCaution3.text = bk.GetMessageByLabel("campaign_live_3rd_coution_06");
			m_textContent.text = bk.GetMessageByLabel("campaign_live_3rd_content_01");
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_buttonIDCopy = btns.Where((ActionButton _) =>
			{
				//0x1EBE330
				return _.name == "sw_lt_id_btn_all_anim (AbsoluteLayout)";
			}).First();
			m_buttonIDCopy.AddOnClickCallback(() =>
			{
				//0x1EBDFA0
				if(OnClickButtonIDCopy != null)
					OnClickButtonIDCopy();
			});
			Loaded();
			return true;
		}
	}
}
