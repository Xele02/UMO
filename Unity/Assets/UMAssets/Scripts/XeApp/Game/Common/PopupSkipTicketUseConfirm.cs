using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using XeSys;
using mcrs;

namespace XeApp.Game.Common
{
	public class PopupSkipTicketUseConfirm : LayoutUGUIScriptBase, IPopupContent
	{
		public enum ConsumeItem
		{
			Energy = 0,
			LiveTicket = 1,
			Ap = 2,
		}
		
		[SerializeField]
		private RawImageEx m_imageIcon; // 0x14
		[SerializeField]
		private StayButton m_itemButton; // 0x18
		[SerializeField]
		private ActionButton m_minusButton; // 0x1C
		[SerializeField]
		private ActionButton m_plusButton; // 0x20
		[SerializeField]
		private Text m_itemNameText; // 0x24
		[SerializeField]
		private Text m_itemValueText; // 0x28
		[SerializeField]
		private Text[] m_skipTicketTexts; // 0x2C
		[SerializeField]
		private Text[] m_consumeItemTexts; // 0x30
		[SerializeField]
		private Text m_cautionText; // 0x34
		private int m_maxValueInner; // 0x3C
		private int m_currentValueInner; // 0x40
		private int m_haveMaxValue; // 0x44
		private int m_useItemId; // 0x48
		private int m_consumeMaxValue; // 0x4C
		private int m_consumeItemCurrentValue; // 0x50
		private ConsumeItem m_consumeItem; // 0x54
		private int m_consumeItemId; // 0x58
		private int m_xor; // 0x5C

		public Transform Parent { get; private set; } // 0x38
		public int UseTcketCount { get { return m_currentValueInner ^ m_xor; } set { m_currentValueInner = value ^ m_xor; } } //0x1BB2E38 0x1BB2E48
		public int TicketLimitCount { get { return m_maxValueInner ^ m_xor; } set { m_maxValueInner = value ^ m_xor; } } //0x1BB2E58 0x1BB2E68

		// RVA: 0x1BB2E78 Offset: 0x1BB2E78 VA: 0x1BB2E78 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_plusButton.AddOnClickCallback(AddItem);
			m_minusButton.AddOnClickCallback(SubItem);
			m_itemButton.AddOnClickCallback(OpenItemDetails);
			m_itemButton.AddOnStayCallback(OpenItemDetails);
			Loaded();
			return true;
		}

		// RVA: 0x1BB3044 Offset: 0x1BB3044 VA: 0x1BB3044 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			TicketLimitCount = 0;
			UseTcketCount = 0;
			PopupSkipTicketUseConfirmSetting s = setting as PopupSkipTicketUseConfirmSetting;
			Parent = s.m_parent;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize(s.WindowSize, s.IsCaption);
			m_useItemId = s.UseItemId;
			TicketLimitCount = Mathf.Min(CIOECGOMILE.HHCJCDFCLOB.IIMNMNGEPIJ(), s.ItemUseMaxValue);
			m_haveMaxValue = s.ItemHaveMaxValue;
			UseTcketCount = s.ItemCurrentValue;
			m_consumeItemId = s.ConsumeItemId;
			m_consumeItemCurrentValue = s.ConsumeItemValue;
			m_consumeMaxValue = s.ConsumeItemMax;
			m_consumeItem = s.ConsumeItem;
			MenuScene.Instance.ItemTextureCache.Load(m_useItemId, (IiconTexture texture) =>
			{
				//0x1BB4104
				texture.Set(m_imageIcon);
			});
			m_itemNameText.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(m_useItemId);
			if(!s.IsWeekdayEvent)
			{
				if(s.IsOneUseForced)
				{
					m_cautionText.text = MessageManager.Instance.GetMessage("menu", "use_item_description_02");
				}
				else
				{
					m_cautionText.text = string.Format(s.IsGoDivaEventDailyBonus ? MessageManager.Instance.GetMessage("menu", "use_item_description_05") : MessageManager.Instance.GetMessage("menu", "use_item_description_01"), CIOECGOMILE.HHCJCDFCLOB.IIMNMNGEPIJ());
				}
			}
			else
			{
				m_cautionText.text = string.Format(MessageManager.Instance.GetMessage("menu", "use_item_description_04"), CIOECGOMILE.HHCJCDFCLOB.IIMNMNGEPIJ());
			}
			UpdateButtonState();
			UpdateItemValue();
		}

		//// RVA: 0x1BB3E54 Offset: 0x1BB3E54 VA: 0x1BB3E54
		private void AddItem()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(UseTcketCount + 1 <= TicketLimitCount)
				UseTcketCount += 1;
			UpdateButtonState();
			UpdateItemValue();
		}

		//// RVA: 0x1BB3EE4 Offset: 0x1BB3EE4 VA: 0x1BB3EE4
		private void SubItem()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UseTcketCount -= 1;
			if (UseTcketCount < 2)
				UseTcketCount = 1;
			UpdateButtonState();
			UpdateItemValue();
		}

		//// RVA: 0x1BB382C Offset: 0x1BB382C VA: 0x1BB382C
		private void UpdateButtonState()
		{
			if(TicketLimitCount < 2)
			{
				m_minusButton.Disable = false;
				m_plusButton.Disable = false;
				m_minusButton.Hidden = true;
				m_plusButton.Hidden = true;
			}
			else
			{
				m_minusButton.Disable = UseTcketCount < 2;
				m_plusButton.Disable = TicketLimitCount <= UseTcketCount;
				m_minusButton.Hidden = false;
				m_plusButton.Hidden = false;
			}
		}

		//// RVA: 0x1BB3994 Offset: 0x1BB3994 VA: 0x1BB3994
		private void UpdateItemValue()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_skipTicketTexts[0].text = bk.GetMessageByLabel("use_ticket_popup_havecount");
			m_skipTicketTexts[1].text = m_haveMaxValue.ToString();
			m_skipTicketTexts[2].text = (m_haveMaxValue - UseTcketCount).ToString();
			if(m_consumeItem == ConsumeItem.Ap)
			{
				m_consumeItemTexts[0].text = string.Format(bk.GetMessageByLabel("use_ticket_consume_format"), bk.GetMessageByLabel("use_ticket_consume_item_002"));
			}
			else if(m_consumeItem == ConsumeItem.LiveTicket)
			{
				m_consumeItemTexts[0].text = string.Format(bk.GetMessageByLabel("use_ticket_consume_format"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(m_consumeItemId));
			}
			else if(m_consumeItem == ConsumeItem.Energy)
			{
				m_consumeItemTexts[0].text = string.Format(bk.GetMessageByLabel("use_ticket_consume_format"), bk.GetMessageByLabel("use_ticket_consume_item_001"));
			}
			else
			{
				m_consumeItemTexts[0].text = string.Format(bk.GetMessageByLabel("use_ticket_consume_format"), "");
			}
			m_consumeItemTexts[1].text = m_consumeMaxValue.ToString();
			m_consumeItemTexts[2].text = (m_consumeMaxValue - UseTcketCount * m_consumeItemCurrentValue).ToString();
			m_itemValueText.text = UseTcketCount.ToString();
		}

		//// RVA: 0x1BB3F70 Offset: 0x1BB3F70 VA: 0x1BB3F70
		private void OpenItemDetails()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowItemDetail(m_useItemId, 0, null);
		}

		// RVA: 0x1BB4078 Offset: 0x1BB4078 VA: 0x1BB4078 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BB4080 Offset: 0x1BB4080 VA: 0x1BB4080 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1BB40B8 Offset: 0x1BB40B8 VA: 0x1BB40B8 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BB40F0 Offset: 0x1BB40F0 VA: 0x1BB40F0 Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1BB40F8 Offset: 0x1BB40F8 VA: 0x1BB40F8 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
