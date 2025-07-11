using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutCampaign : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private Text m_textAppPeriod; // 0x18
		[SerializeField]
		private Text m_textGetPeriod; // 0x1C
		[SerializeField]
		private Text m_textCaution1; // 0x20
		[SerializeField]
		private Text m_textCaution2; // 0x24
		[SerializeField]
		private Text m_textCaution3; // 0x28
		[SerializeField]
		private Text m_textCount; // 0x2C
		[SerializeField]
		private ActionButton m_buttonPrizeList; // 0x30
		[SerializeField]
		private ActionButton m_buttonRegist; // 0x34
		[SerializeField]
		private ActionButton m_buttonEntry; // 0x38
		[SerializeField]
		private ActionButton m_buttonContract; // 0x3C
		private OLLAFCBLMIJ m_view; // 0x40
		public Action OnClickButtonPrizeList; // 0x44
		public Action OnClickButtonRegist; // 0x48
		public Action<ButtonBase> OnClickButtonEntry; // 0x4C
		public Action OnClickButtonContract; // 0x50

		public SwapScrollList List { get { return m_scrollList; } } //0x19D4650

		// // RVA: 0x19D4658 Offset: 0x19D4658 VA: 0x19D4658
		public void Setup(OLLAFCBLMIJ view, bool resetFocus/* = True*/)
		{
			m_view = view;
			m_textAppPeriod.text = string.Format(MessageManager.Instance.GetMessage("menu", "campaign_live_3rd_period"), new object[10]
			{
				view.HGGFIEELABK_Start.Year, view.HGGFIEELABK_Start.Month, view.HGGFIEELABK_Start.Day, view.HGGFIEELABK_Start.Hour, view.HGGFIEELABK_Start.Minute,
				view.KHNIJBEPHPL_End1.Year, view.KHNIJBEPHPL_End1.Month, view.KHNIJBEPHPL_End1.Day, view.KHNIJBEPHPL_End1.Hour, view.KHNIJBEPHPL_End1.Minute
			});
			m_textGetPeriod.text = string.Format(MessageManager.Instance.GetMessage("menu", "campaign_live_3rd_period"), new object[10]
			{
				view.KOHDMPJHOBB.Year, view.KOHDMPJHOBB.Month, view.KOHDMPJHOBB.Day, view.KOHDMPJHOBB.Hour, view.KOHDMPJHOBB.Minute,
				view.IHPPGMJOJIE.Year, view.IHPPGMJOJIE.Month, view.IHPPGMJOJIE.Day, view.IHPPGMJOJIE.Hour, view.IHPPGMJOJIE.Minute
			});
			List<OLLAFCBLMIJ.KAAHBIABMBC> l = view.CKPIHCGOEDP.FindAll((OLLAFCBLMIJ.KAAHBIABMBC x) =>
			{
				//0x19D5E80
				return x.CDMGDFLPPHN_HasStamp;
			});
			m_textCount.text = l.Count.ToString() + "/" + view.CKPIHCGOEDP.Count.ToString();
			m_buttonEntry.Disable = !view.NDAMKMGINBM_CanEntryToday;
			int a = -1;
			if(resetFocus)
			{
				a = 0;
                OLLAFCBLMIJ.KAAHBIABMBC d = m_view.DHNCPKGDEFL();
                if (d != null)
					a = d.ECDKPAIEFFA_DayId - 1;
			}
			SetupList(m_view.CKPIHCGOEDP.Count, a);
		}

		// // RVA: 0x19D556C Offset: 0x19D556C VA: 0x19D556C
		private void SetupList(int count, int focusIndex)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(focusIndex > -1)
			{
				m_scrollList.SetPosition(focusIndex, 0, 0, false);
			}
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x19D573C Offset: 0x19D573C VA: 0x19D573C
		protected void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutCampaignIcon l = content as LayoutCampaignIcon;
			if(l != null)
			{
				l.Setup(m_view.CKPIHCGOEDP[index]);
			}	
		}

		// RVA: 0x19D5A28 Offset: 0x19D5A28 VA: 0x19D5A28 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textCaution1.text = bk.GetMessageByLabel("campaign_live_3rd_coution_01");
			m_textCaution2.text = bk.GetMessageByLabel("campaign_live_3rd_coution_02");
			m_textCaution3.text = bk.GetMessageByLabel("campaign_live_3rd_coution_03");
			m_buttonPrizeList.AddOnClickCallback(() =>
			{
				//0x19D5D58
				if(OnClickButtonPrizeList != null)
					OnClickButtonPrizeList();
			});
			m_buttonRegist.AddOnClickCallback(() =>
			{
				//0x19D5D6C
				if(OnClickButtonRegist != null)
					OnClickButtonRegist();
			});
			m_buttonEntry.AddOnClickCallback(() =>
			{
				//0x19D5D80
				if(OnClickButtonEntry != null)
					OnClickButtonEntry(m_buttonEntry);
			});
			m_buttonContract.AddOnClickCallback(() =>
			{
				//0x19D5DF0
				if(OnClickButtonContract != null)
					OnClickButtonContract();
			});
			Loaded();
			return true;
		}

	}
}
