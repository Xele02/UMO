using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SetDeckGaugePopup : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private PopupWindowControl m_popupControl; // 0x14
		//[TooltipAttribute] // RVA: 0x6811EC Offset: 0x6811EC VA: 0x6811EC
		[SerializeField]
		private Text[] m_nameText; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x681244 Offset: 0x681244 VA: 0x681244
		private Text[] m_descText; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6812A0 Offset: 0x6812A0 VA: 0x6812A0
		private Text[] m_cautionText; // 0x20
		[SerializeField]
		private SetDeckExpectedScoreGauge m_scoreGauge; // 0x24

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xA6DBF8 Offset: 0xA6DBF8 VA: 0xA6DBF8
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0xA6DC80 Offset: 0xA6DC80 VA: 0xA6DC80 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			SetDeckGaugePopupSetting s = setting as SetDeckGaugePopupSetting;
			m_popupControl = control;
			Parent = setting.m_parent;
			int[] score = new int[10];
			float[] rank = new float[5];
			for(int i = 0; i < 10; i++)
			{
				score[i] = CMMKCEPBIHI.NDNOLJACLLC_GetScore((CMMKCEPBIHI.NOJENDEDECD_ScoreType)i);
			}
			for (int i = 0; i < rank.Length; i++)
			{
				rank[i] = CMMKCEPBIHI.GPCKPNJGANO_GetRank((ResultScoreRank.Type)i);
			}
			m_scoreGauge.Set(CMMKCEPBIHI.KHCOOPDAGOE_ScoreRank, CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio, rank, score);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < 10; i++)
			{
				m_nameText[i].text = bk.GetMessageByLabel(string.Format("pop_score_detail_item_name_{0:00}", i + 1));
				m_descText[i].text = bk.GetMessageByLabel(string.Format("pop_score_detail_item_desc_{0:00}", i + 1));
			}
			m_cautionText[0].text = bk.GetMessageByLabel("pop_score_detail_caution_01");
			m_cautionText[1].text = bk.GetMessageByLabel("pop_score_detail_caution_02");
			PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			gameObject.SetActive(true);
		}

		// RVA: 0xA6E2E0 Offset: 0xA6E2E0 VA: 0xA6E2E0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xA6E2E8 Offset: 0xA6E2E8 VA: 0xA6E2E8 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xA6E320 Offset: 0xA6E320 VA: 0xA6E320 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xA6E358 Offset: 0xA6E358 VA: 0xA6E358 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xA6E360 Offset: 0xA6E360 VA: 0xA6E360 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
