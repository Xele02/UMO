using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using XeSys;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationEnergyChargePopup : LayoutUGUIScriptBase
	{
		public static readonly string AssetName; // 0x0
		[SerializeField]
		private Text m_textMain; // 0x14
		[SerializeField]
		private Text m_textAttention; // 0x18
		[SerializeField]
		private NumberBase[] m_chargeNum; // 0x1C
		private AbsoluteLayout m_barTbl; // 0x20
		private AbsoluteLayout m_messageTbl; // 0x24
		private AbsoluteLayout m_changeStockTbl; // 0x28
		private AbsoluteLayout m_chargeBarAnim; // 0x2C
		private AbsoluteLayout m_chargePlusBarAnim; // 0x30
		private AbsoluteLayout m_stockNumAnim; // 0x34
		private AbsoluteLayout m_addNumHideAnim; // 0x38
		private AbsoluteLayout m_loopEffectAnim; // 0x3C
		private AbsoluteLayout m_maxStockNumAnime; // 0x40
		private List<AbsoluteLayout> m_allSymbolLayerList = new List<AbsoluteLayout>(); // 0x44
		private List<AbsoluteLayout> m_addNumHideAnimList = new List<AbsoluteLayout>(); // 0x48
		private static string[,] StartTopLabelTbl = new string[7, 2]
		{
			{ "charge_max_logo", "charge_max_loen" },
			{ "charge_max_1", "chargeen_max_1" },
			{ "charge_01", "chargeen_01" },
			{ "charge_bonus_01", "chargeen_bonus_01" },
			{ "charge_max_logo", "charge_max_loen" },
			{ "charge_max_1", "chargeen_max_1" },
			{ "charge_01", "chargeen_01" }
		}; // 0x4

		// RVA: 0x19EDD40 Offset: 0x19EDD40 VA: 0x19EDD40 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_messageTbl = layout.FindViewById("swtbl_deco_bar_txt") as AbsoluteLayout;
			m_barTbl = layout.FindViewById("swtbl_deco_bar_cannon_all") as AbsoluteLayout;
			m_changeStockTbl = layout.FindViewById("swtbl_bar_mcc_01") as AbsoluteLayout;
			m_chargePlusBarAnim = layout.FindViewById("deco_bar_mcc_plu_on_anim") as AbsoluteLayout;
			m_addNumHideAnim = layout.FindViewByExId("sw_deco_charge_max_rp_01_swnum_g_r_r_num_mcc") as AbsoluteLayout;
			m_stockNumAnim = layout.FindViewByExId("sw_deco_charge_max_01_swtbl_g_r_r_fnt_mcc") as AbsoluteLayout;
			m_chargeBarAnim = layout.FindViewById("sw_g_r_r_bar_mcc_anim") as AbsoluteLayout;
			m_addNumHideAnim = layout.FindViewByExId("sw_deco_charge_max_rp_01_swnum_g_r_r_num_mcc") as AbsoluteLayout;
			m_loopEffectAnim = layout.FindViewByExId("deco_bar_mcc_plu_on_anim_deco_bar_mcc_plu_on_eff") as AbsoluteLayout;
			m_maxStockNumAnime = layout.FindViewByExId("sw_deco_charge_max_rp_01_swtbl_g_r_r_fnt_mcc") as AbsoluteLayout;
			m_addNumHideAnimList.Add(layout.FindViewByExId("sw_deco_bar_charge_bonus_01_swnum_g_r_r_num_mcc") as AbsoluteLayout);
			m_addNumHideAnimList.Add(layout.FindViewByExId("sw_deco_bar_charge_01_swnum_g_r_r_num_mcc") as AbsoluteLayout);
			m_addNumHideAnimList.Add(layout.FindViewByExId("sw_deco_charge_max_01_swnum_g_r_r_num_mcc") as AbsoluteLayout);
			m_addNumHideAnimList.Add(layout.FindViewByExId("sw_deco_charge_max_rp_01_swnum_g_r_r_num_mcc") as AbsoluteLayout);
			AbsoluteLayout l = layout.FindViewByExId("sw_deco_bar_mcc_all_swtbl_deco_bar_cannon_all") as AbsoluteLayout;
			for(int i = 0; i < l.viewCount; i++)
			{
				m_allSymbolLayerList.Add(l[i] as AbsoluteLayout);
			}
			return true;
		}

		// RVA: 0x19EE668 Offset: 0x19EE668 VA: 0x19EE668
		public bool IsLoading()
		{
			return false;
		}

		// RVA: 0x19EE670 Offset: 0x19EE670 VA: 0x19EE670
		public void Set(int currentStock, int currentGauge, int nextGauge, bool isMax, bool isDecoScene)
		{
			int start = currentGauge;
			if(99 < currentGauge)
				start = 0;
			int a = currentStock + ((currentGauge > 99) ? 1 : 0);
			int cnt = Mathf.Clamp(a + 1, 0, 3);
			for(int i = 0; i < m_allSymbolLayerList.Count; i++)
			{
				m_allSymbolLayerList[i].StopAllAnim();
			}
			m_changeStockTbl.StartChildrenAnimGoStop(cnt.ToString("00"));
			m_barTbl.StartChildrenAnimGoStop(cnt.ToString("00"));
			m_messageTbl.StartChildrenAnimGoStop("01");
			if(isMax)
			{
				m_chargeBarAnim.StartChildrenAnimGoStop(100, 100);
				m_addNumHideAnim.StartChildrenAnimGoStop("02");
				m_barTbl.StartChildrenAnimGoStop("04");
				m_maxStockNumAnime.StartChildrenAnimGoStop("02");
				m_messageTbl.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_chargeBarAnim.StartChildrenAnimGoStop(start, start);
				m_addNumHideAnim.StartChildrenAnimGoStop("01");
				m_barTbl.StartChildrenAnimGoStop("01");
			}
			if(!isDecoScene)
			{
				m_messageTbl.StartChildrenAnimGoStop("03");
				for(int i = 0; i < m_addNumHideAnimList.Count; i++)
				{
					m_addNumHideAnimList[i].StartChildrenAnimGoStop("02");
				}
			}
			m_chargePlusBarAnim.StartChildrenAnimGoStop(0, 0);
			SetNumber(a * -100 + (nextGauge - start));
			UpdateText(isMax);
			m_loopEffectAnim.StartChildrenAnimLoop("logo_on", "loen_on");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D6214 Offset: 0x6D6214 VA: 0x6D6214
		// RVA: 0x19EEDA4 Offset: 0x19EEDA4 VA: 0x19EEDA4
		public IEnumerator Co_UpdateGauge(int currentStock, int currentGauge, int nextRawGauge, Action endCb)
		{
			int diff;
			int nextValue;
			int gaugeAnimeAdjust;
			int i;
			bool isEnd;

			//0x19EFB74
			diff = currentStock * -100 - currentGauge + nextRawGauge;
			nextValue = currentStock * -100 + nextRawGauge;
			gaugeAnimeAdjust = currentGauge;
			if(nextValue < 101)
				diff = 0;
			else
			{
				diff = nextValue - 100;
				nextValue = 100;
			}
			for(i = 0; i < m_allSymbolLayerList.Count; i++)
			{
				for(int j = 0; j < StartTopLabelTbl.GetLength(0); j++)
				{
					m_allSymbolLayerList[i].StartChildrenAnimGoStop(StartTopLabelTbl[j, 0], StartTopLabelTbl[j, 1]);
				}
			}
			yield return null;
			for(i = 0; i < m_allSymbolLayerList.Count; i++)
			{
				//LAB_019eff0c
				while(m_allSymbolLayerList[i].IsVisible && m_allSymbolLayerList[i].IsPlayingChildren())
				{
					yield return null;
				}
			}
			while(true)
			{
				currentGauge++;
				if(currentGauge < nextValue)
				{
					m_chargePlusBarAnim.StartChildrenAnimGoStop(currentGauge - gaugeAnimeAdjust, currentGauge - gaugeAnimeAdjust);
				}
				else
				{
					currentGauge = nextValue;
					m_chargePlusBarAnim.StartChildrenAnimGoStop(currentGauge - gaugeAnimeAdjust, currentGauge - gaugeAnimeAdjust);
					gaugeAnimeAdjust = 0;
					isEnd = diff == 0;
					if(currentGauge == 100)
					{
						currentStock++;
						yield return Co.R(Co_StockUp(currentStock));
					}
					//LAB_019f00f8
					if(isEnd)
					{
						if(endCb != null)
							endCb();
						yield break;
					}
					currentGauge = 0;
					nextValue = diff;
					diff -= 100;
					if(diff <= 0)
					{
						diff = 0;
					}
					else
					{
						nextValue = 100;
					}
					m_chargeBarAnim.StartChildrenAnimGoStop(0, 0);
				}
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D628C Offset: 0x6D628C VA: 0x6D628C
		// // RVA: 0x19EEEBC Offset: 0x19EEEBC VA: 0x19EEEBC
		private IEnumerator Co_StockUp(int nextStock)
		{
			int i;

			//0x19EF5F4
			m_barTbl.StartChildrenAnimGoStop(nextStock, nextStock);
			for(i = 0; i < m_allSymbolLayerList.Count; i++)
			{
				for(int j = 0; j < StartTopLabelTbl.GetLength(0); j++)
				{
					m_allSymbolLayerList[i].StartChildrenAnimGoStop(StartTopLabelTbl[j, 0], StartTopLabelTbl[j, 1]);
				}
			}
			yield return null;
			for(i = 0; i < m_allSymbolLayerList.Count; i++)
			{
				while(m_allSymbolLayerList[i].IsVisible && m_allSymbolLayerList[i].IsPlayingChildren())
				{
					yield return null;
				}
			}
			if(nextStock > 1)
			{
				m_stockNumAnim.StartChildrenAnimGoStop(nextStock.ToString("00"));
			}
		}

		// // RVA: 0x19EEC00 Offset: 0x19EEC00 VA: 0x19EEC00
		private void UpdateText(bool isMax)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(isMax)
			{
				m_textMain.text = bk.GetMessageByLabel("pop_deco_sp_item_cannon_text002");
				m_textAttention.text = bk.GetMessageByLabel("pop_deco_sp_item_cannon_text003");	
			}
			else
			{
				m_textMain.text = bk.GetMessageByLabel("pop_deco_sp_item_cannon_text001");
			}
		}

		// // RVA: 0x19EEB5C Offset: 0x19EEB5C VA: 0x19EEB5C
		private void SetNumber(int value)
		{
			for(int i = 0; i < m_chargeNum.Length; i++)
			{
				m_chargeNum[i].SetNumber(value, 0);
			}
		}
	}
}
