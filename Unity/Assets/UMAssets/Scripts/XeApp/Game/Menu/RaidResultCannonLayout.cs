using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using CriWare;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultCannonLayout : LayoutUGUIScriptBase
	{
		private enum GaugeType
		{
			Non = 0,
			Stock = 1,
			Max = 2,
		}

		public Action onFinished; // 0x14
		public Action onClickButton; // 0x18
		private FLCAECNBMML m_view; // 0x1C
		private Matrix23 m_identity; // 0x20
		private Coroutine m_coroutine; // 0x38
		private AbsoluteLayout m_layoutRoot; // 0x3C
		private AbsoluteLayout m_layoutMain; // 0x40
		private AbsoluteLayout m_layoutStockNum; // 0x44
		private AbsoluteLayout m_layoutMaxGauge; // 0x48
		private LayoutRaidResultCannonGauge m_layoutGauge; // 0x4C
		[SerializeField]
		private Text m_textMaxGauge; // 0x50
		[SerializeField]
		private NumberBase m_addCannonGagueNum; // 0x54
		private CriAtomExPlayback m_countUpSEPlayback; // 0x58
		private bool m_isSkiped; // 0x5C
		private bool m_isLoading; // 0x5D
		private bool m_isChargeBonus; // 0x5E
		private GaugeType m_initGaugeType; // 0x60

		// RVA: 0x1BD9D0C Offset: 0x1BD9D0C VA: 0x1BD9D0C
		private void Start()
		{
			return;
		}

		// RVA: 0x1BD9D10 Offset: 0x1BD9D10 VA: 0x1BD9D10
		private void Update()
		{
			return;
		}

		// RVA: 0x1BD9D14 Offset: 0x1BD9D14 VA: 0x1BD9D14
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1BD9D68 Offset: 0x1BD9D68 VA: 0x1BD9D68 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_r_mcc_bc_sw_g_r_r_mcc_cc_inout_anim") as AbsoluteLayout;
			m_layoutMain = layout.FindViewByExId("sw_g_r_r_mcc_bc_inout_anim_sw_g_r_r_mcc_bc_count_anim") as AbsoluteLayout;
			m_layoutStockNum = layout.FindViewByExId("sw_g_r_r_mcc_bc_count_anim_g_r_r_fnt_mcc_1") as AbsoluteLayout;
			m_layoutMaxGauge = layout.FindViewByExId("sw_g_r_r_mcc_bc_inout_anim_sw_g_r_r_mcc_max_onoff_anim") as AbsoluteLayout;
			m_layoutGauge = GetComponentInChildren<LayoutRaidResultCannonGauge>(true);
			m_layoutGauge.layoutMain = layout.FindViewByExId("sw_g_r_r_mcc_bc_count_anim_sw_g_r_r_bar_mcc_anim") as AbsoluteLayout;
			m_layoutGauge.layoutDiff = layout.FindViewByExId("sw_g_r_r_bar_mcc_anim_deco_bar_mcc_plu_on_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x1BDA100 Offset: 0x1BDA100 VA: 0x1BDA100
		public void Setup(FLCAECNBMML view)
		{
			m_view = view;
			m_layoutGauge.Setup(view.OIOPCIAGLEK_CannonBaseValue, 200);
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "go_in");
			if(view.OIOPCIAGLEK_CannonBaseValue < 100)
			{
				m_layoutMain.StartChildrenAnimGoStop("charge_non");
				m_layoutMaxGauge.StartChildrenAnimGoStop("02");
				m_initGaugeType = GaugeType.Non;
			}
			else if(view.OIOPCIAGLEK_CannonBaseValue < 200)
			{
				m_layoutMain.StartChildrenAnimGoStop("charge_stock1");
				m_layoutStockNum.StartChildrenAnimGoStop("01");
				m_layoutMaxGauge.StartChildrenAnimGoStop("02");
				m_initGaugeType = GaugeType.Stock;
			}
			else
			{
				m_layoutMain.StartChildrenAnimGoStop("chargeen_max_1");
				m_layoutStockNum.StartChildrenAnimGoStop("02");
				m_layoutMaxGauge.StartChildrenAnimGoStop("01");
				m_initGaugeType = GaugeType.Max;
			}
			m_textMaxGauge.text = MessageManager.Instance.GetMessage("menu", "raid_damage_result_gauge_max_text");
			m_isChargeBonus = m_view.LFOPOHHEODG_ChargeBonus > 0;
			m_addCannonGagueNum.SetNumber(m_isChargeBonus ? m_view.IHIJGIHNOAL_CannonGaugeAdd / 2 : m_view.IHIJGIHNOAL_CannonGaugeAdd, 0);
		}

		// // RVA: 0x1BDA488 Offset: 0x1BDA488 VA: 0x1BDA488
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			m_layoutGauge.SkipCountUp();
			if(m_coroutine != null)	
				return;
			StartBeginAnim();
		}

		// // RVA: 0x1BDA4E8 Offset: 0x1BDA4E8 VA: 0x1BDA4E8
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EDA4 Offset: 0x71EDA4 VA: 0x71EDA4
		// // RVA: 0x1BDA510 Offset: 0x1BDA510 VA: 0x1BDA510
		private IEnumerator Co_BeginAnim()
		{
			//0x1BDACF8
			yield return Co.R(Co_EnterGauge());
			if(m_isChargeBonus)
			{
				if(!m_isSkiped)
				{
					yield return new WaitForSeconds(0.5f);
				}
				yield return Co.R(Co_ChageBonus());
			}
			//LAB_01bdae34
			if(!m_isSkiped)
			{
				yield return new WaitForSeconds(0.5f);
			}
			yield return Co.R(Co_StartCountUp());
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EE1C Offset: 0x71EE1C VA: 0x71EE1C
		// // RVA: 0x1BDA5BC Offset: 0x1BDA5BC VA: 0x1BDA5BC
		private IEnumerator Co_EnterGauge()
		{
			//0x1BDB2D0
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EE94 Offset: 0x71EE94 VA: 0x71EE94
		// // RVA: 0x1BDA668 Offset: 0x1BDA668 VA: 0x1BDA668
		private IEnumerator Co_ChageBonus()
		{
			AbsoluteLayout layout;

			//0x1BDAF90
			layout = m_layoutMain;
			string startLabel;
			switch(m_initGaugeType)
			{
				case GaugeType.Non:
					startLabel = "charge_bonus_01";
					m_layoutMain.StartChildrenAnimGoStop(startLabel, "chargeen_bonus_01");
					break;
				case GaugeType.Stock:
					startLabel = "charge_bonus_02";
					m_layoutMain.StartChildrenAnimGoStop(startLabel, "chargeen_bonus_02");
					break;
				case GaugeType.Max:
					startLabel = "charge_bonus_03";
					m_layoutMain.StartChildrenAnimGoStop(startLabel, "chargeen_bonus_03");
					break;
				default:
					startLabel = "go_in";
					m_layoutMain.StartChildrenAnimGoStop(startLabel, "st_in");
					break;
			}
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitLabel(m_layoutMain, startLabel, true));
			m_addCannonGagueNum.SetNumber(m_view.IHIJGIHNOAL_CannonGaugeAdd, 0);
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EF0C Offset: 0x71EF0C VA: 0x71EF0C
		// // RVA: 0x1BDA714 Offset: 0x1BDA714 VA: 0x1BDA714
		private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip/* = True*/)
		{
			//0x1BDBA18
			while(!m_isSkiped || !enableSkip)
			{
				if(layout.GetView(0).FrameAnimation.FrameCount >= layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
					break;
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EF84 Offset: 0x71EF84 VA: 0x71EF84
		// // RVA: 0x1BDA80C Offset: 0x1BDA80C VA: 0x1BDA80C
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x1BDB814
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EFFC Offset: 0x71EFFC VA: 0x71EFFC
		// // RVA: 0x1BDA8EC Offset: 0x1BDA8EC VA: 0x1BDA8EC
		private IEnumerator Co_StartCountUp()
		{
			//0x1BDB4A0
			AbsoluteLayout layout = m_layoutMain;
			m_layoutGauge.OnCountUpEvent = (int value) =>
			{
				//0x1BDAA88
				return;
			};
			m_layoutGauge.OnStockCountUpEvent = () =>
			{
				//0x1BDAA94
				if(!m_isChargeBonus)
					layout.StartChildrenAnimGoStop("charge_1", "chargeen_1");
				else
					layout.StartChildrenAnimGoStop("charge_2", "chargeen_2");
			};
			m_layoutGauge.OnCountMaxEvent = () =>
			{
				//0x1BDAB5C
				if(!m_isChargeBonus)
				{
					layout.StartChildrenAnimGoStop("charge_max_1", "chargeen_max_1");
				}
				else
				{
					layout.StartChildrenAnimGoStop("charge_max_2", "chargeen_max_2");
				}
				m_layoutStockNum.StartChildrenAnimGoStop("02");
				m_layoutMaxGauge.StartChildrenAnimGoStop("01");
			};
			yield return Co.R(m_layoutGauge.StartCountUp(m_view.IHIJGIHNOAL_CannonGaugeAdd, null));
		}

		// // RVA: 0x1BDA998 Offset: 0x1BDA998 VA: 0x1BDA998
		// private void PlayCountUpLoopSE() { }

		// // RVA: 0x1BDA9F8 Offset: 0x1BDA9F8 VA: 0x1BDA9F8
		// private void StopCountUpLoopSE() { }
	}
}
