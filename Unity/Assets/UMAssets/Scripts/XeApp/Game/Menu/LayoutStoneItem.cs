using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutStoneItem : SwapScrollListContent
	{
		private enum LimitType
		{
			None = -1,
			Day = 0,
			Hour = 1,
			Minute = 2,
			Num = 3,
		}

		private static readonly string[] LIMIT_TIME_OBJ_TABLE = new string[3]
		{
			"swnum_limit_day (AbsoluteLayout)",
			"swnum_limit_hour (AbsoluteLayout)",
			"swnum_limit_minute (AbsoluteLayout)",
		}; // 0x0
		private static readonly string[] LIMIT_TIME_LABEL_TABLE = new string[3]
		{
			"day", "hour", "minute"
		}; // 0x4
		private Action m_OnClickBuyButton; // 0x20
		private AbsoluteLayout m_LimitTimeBalloon; // 0x24
		private List<NumberBase> m_LimitTimeNumList = new List<NumberBase>(); // 0x28
		private ActionButton m_detailBtn; // 0x2C
		private Action m_OnClickInfoButton; // 0x30
		private Text m_money; // 0x34
		private bool m_IsSetup; // 0x38
		private bool m_IsDispBalloon; // 0x39
		private long m_CloseTime; // 0x40

		public Action OnClickBuyButton { set { m_OnClickBuyButton = value; } } //0x194A784
		public Action OnClickInfoButton { set { m_OnClickInfoButton = value; } } //0x194A78C

		// RVA: 0x194A794 Offset: 0x194A794 VA: 0x194A794 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_LimitTimeBalloon = layout.FindViewByExId("sw_stone_list_swtbl_limit") as AbsoluteLayout;
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			btns.Where((ActionButton _) =>
			{
				//0x194B78C
				return _.name == "sw_den_btn_buy (AbsoluteLayout)";
			}).First().AddOnClickCallback(() =>
			{
				//0x194B6FC
				if(m_OnClickBuyButton != null)
					m_OnClickBuyButton();
			});
			m_detailBtn = btns.Where((ActionButton _)=>
			{
				//0x194B80C
				return _.name == "sw_den_btn_detail (AbsoluteLayout)";
			}).First();
			NumberBase[] nbs = GetComponentsInChildren<NumberBase>(true);
			m_LimitTimeNumList.Clear();
			for(int i = 0; i < 3; i++)
			{
				m_LimitTimeNumList.Add(nbs.Where((NumberBase _) =>
				{
					//0x194BB0C
					return _.name == LIMIT_TIME_OBJ_TABLE[i];
				}).First());
			}
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_money = txts.Where((Text _) =>
			{
				//0x194B88C
				return _.name == "money (TextView)";
			}).First();
			Loaded();
			return true;
		}

		// // RVA: 0x194ADC0 Offset: 0x194ADC0 VA: 0x194ADC0
		public void Setup(LGDNAJACFHI data)
		{
			this.StartCoroutineWatched(Co_Setup(data));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D7E9C Offset: 0x6D7E9C VA: 0x6D7E9C
		// // RVA: 0x194ADE4 Offset: 0x194ADE4 VA: 0x194ADE4
		private IEnumerator Co_Setup(LGDNAJACFHI data)
		{
			//0x194BD8C
			LayoutUGUIRuntime runtime = GetComponent<LayoutUGUIRuntime>();
			yield return new WaitWhile(() =>
			{
				//0x194BC0C
				return !runtime.IsReady;
			});
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			RawImageEx icon = imgs.Where((RawImageEx _) =>
			{
				//0x194B90C
				return _.name == "cmn_item_10000 (ImageView)";
			}).First();
			GameManager.Instance.DenomIconCache.Load(data.EAHPLCJMPHD, (IiconTexture texture) =>
			{
				//0x194BCA8
				texture.Set(icon);
			});
			Text[] txts = GetComponentsInChildren<Text>(true);
			txts.Where((Text _) =>
			{
				//0x194B98C
				return _.name == "name (TextView)";
			}).First().text = data.OPFGFINHFCE_Name;
			Text t = txts.Where((Text _) =>
			{
				//0x194BA0C
				return _.name == "txt (TextView)";
			}).First();
			t.text = data.KLMPFGOCBHC_Desc;
			t.horizontalOverflow = HorizontalWrapMode.Wrap;
			txts.Where((Text _) =>
			{
				//0x194BA8C
				return _.name == "rest (TextView)";
			}).First().text = data.GCJMGMBNBCB_BuyLimit == 0 ? "" : string.Format(MessageManager.Instance.GetMessage("menu", "denom_item_rest"), data.GCJMGMBNBCB_BuyLimit - data.AJIFADGGAAJ_BoughtQuantity);
			if(!string.IsNullOrEmpty(data.NGIKLCDKAMB_FormatedPrice))
			{
				m_money.text = data.NGIKLCDKAMB_FormatedPrice;
			}
			else
			{
				m_money.text = "";
			}
			m_IsDispBalloon = data.IPKEFHPAMBP;
			if(!m_IsDispBalloon)
			{
				m_LimitTimeBalloon.StartChildrenAnimGoStop("non");
			}
			else
			{
				m_CloseTime = data.EMEKFFHCHMH_CloseAt;
				LimitType type = LimitType.None;
				int time;
				CalcLimitTime(out type, out time);
				m_LimitTimeBalloon.StartChildrenAnimGoStop(LIMIT_TIME_LABEL_TABLE[(int)type]);
			}
			m_detailBtn.ClearOnClickCallback();
			if(data.JKKNIEHJBAP != null && data.JKKNIEHJBAP != "")
			{
				m_detailBtn.Hidden = false;
				m_detailBtn.AddOnClickCallback(() =>
				{
					//0x194BC3C
					if(m_OnClickInfoButton != null)
						m_OnClickInfoButton();
				});
			}
			else
			{
				m_detailBtn.Hidden = true;
			}
			m_IsSetup = true;
		}

		// // RVA: 0x194AEAC Offset: 0x194AEAC VA: 0x194AEAC
		private void CalcLimitTime(out LayoutStoneItem.LimitType type, out int time)
		{
			DateTime date = Utility.GetLocalDateTime(m_CloseTime);
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			DateTime date2 = Utility.GetLocalDateTime(t);
			if(t >= m_CloseTime)
			{
				type = LimitType.Minute;
				time = 0;
			}
			else
			{
				TimeSpan sub = date - date2;
				TimeSpan s = new TimeSpan(0, 1, 0);
				s = sub + s;
				if(s.Days < 1)
				{
					if(s.Hours < 1)
					{
						type = LimitType.Minute;
						time = s.Minutes;
					}
					else
					{
						type = LimitType.Hour;
						time = s.Hours;
					}
				}
				else
				{
					type = LimitType.Day;
					time = s.Days;
				}
			}
		}

		// // RVA: 0x194B184 Offset: 0x194B184 VA: 0x194B184
		private void ApplyLimitTime()
		{
			LimitType type = LimitType.None;
			int time;
			CalcLimitTime(out type, out time);
			m_LimitTimeBalloon.StartChildrenAnimGoStop(LIMIT_TIME_LABEL_TABLE[(int)type]);
			m_LimitTimeNumList[(int)type].SetNumber(time, 0);
		}

		// RVA: 0x194B2FC Offset: 0x194B2FC VA: 0x194B2FC
		public void Update()
		{
			if(m_IsSetup  && m_IsDispBalloon)
				ApplyLimitTime();
		}
	}
}
