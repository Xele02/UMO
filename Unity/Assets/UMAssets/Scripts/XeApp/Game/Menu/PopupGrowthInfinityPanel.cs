using UnityEngine.EventSystems;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupGrowthInfinityPanel : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		[SerializeField] // RVA: 0x67D48C Offset: 0x67D48C VA: 0x67D48C
		private ActionButton[] m_buttons; // 0x10
		[SerializeField] // RVA: 0x67D49C Offset: 0x67D49C VA: 0x67D49C
		private Text[] m_texts; // 0x14
		private short m_value; // 0x18
		private short m_maxUnlockCount; // 0x1A
		private MNDAMOGGJBJ.MNDGNJLBANB m_reason; // 0x1C
		private short m_episodeUnit; // 0x20
		private short m_stockCount; // 0x22
		private TextPopupSetting m_textPopupSetting = new TextPopupSetting(); // 0x24

		public Transform Parent { get; private set; } // 0xC
		public short Value { get { return m_value; } private set {
			if(m_value != value)
			{
				m_value = value;
				ApplyUnlockCountText(value);
			}
		} } //0x17A9058 0x17A90F4

		// RVA: 0x17A90FC Offset: 0x17A90FC VA: 0x17A90FC Slot: 24
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}

		// RVA: 0x17A9104 Offset: 0x17A9104 VA: 0x17A9104
		private void Awake()
		{
			m_buttons[0].AddOnClickCallback(OnPushMinus);
			m_buttons[1].AddOnClickCallback(OnPushPlus);
			m_textPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
		}

		// RVA: 0x17A9324 Offset: 0x17A9324 VA: 0x17A9324 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupSceneGrowthInfinityPanelSetting s = setting as PopupSceneGrowthInfinityPanelSetting;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			Parent = setting.m_parent;
			m_texts[0].text = string.Format(bk.GetMessageByLabel("growth_popup_text13"), s.StockCount);
			m_texts[1].text = string.Format(bk.GetMessageByLabel("growth_popup_text14"), 1200);
			m_maxUnlockCount = s.UnlockCount;
			m_episodeUnit = s.EpisodeUnit;
			m_stockCount = s.StockCount;
			m_reason = s.Reason;
			Value = (short)Mathf.Min(m_maxUnlockCount, m_stockCount);
		}

		// RVA: 0x17A96C0 Offset: 0x17A96C0 VA: 0x17A96C0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17A96C8 Offset: 0x17A96C8 VA: 0x17A96C8 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x17A9700 Offset: 0x17A9700 VA: 0x17A9700 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17A9738 Offset: 0x17A9738 VA: 0x17A9738 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x17A9740 Offset: 0x17A9740 VA: 0x17A9740
		private void OnPushMinus()
		{
			short newValue = (short)(m_value - 1);
			mcrs.cs_se_boot cueId = mcrs.cs_se_boot.SE_BTN_005;
			if(newValue < 1)
				newValue = 1;
			else
				cueId = mcrs.cs_se_boot.SE_BTN_003;
			SoundManager.Instance.sePlayerBoot.Play((int)cueId);
			Value = newValue;
		}

		// RVA: 0x17A97D8 Offset: 0x17A97D8 VA: 0x17A97D8
		private void OnPushPlus()
		{
			short newValue = (short)(m_value + 1);
			if(newValue * m_episodeUnit < 1201)
			{
				if(m_maxUnlockCount < newValue)
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("growth_popup_title_text06");
					if(m_reason == MNDAMOGGJBJ.MNDGNJLBANB.EDBCFDJBFID_LackUC)
					{
						m_textPopupSetting.Text = bk.GetMessageByLabel("growth_popup_text17");
					}
					else if((int)m_reason == 3)
					{
						m_textPopupSetting.Text = bk.GetMessageByLabel("growth_popup_text18");
					}
					else if(m_reason == MNDAMOGGJBJ.MNDGNJLBANB.LNMPDFICAOM_LackItem)
					{
						m_textPopupSetting.Text = bk.GetMessageByLabel("growth_popup_text16");
					}
					PopupWindowManager.Show(m_textPopupSetting, null, null, null, null);
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				}
				else
				{
					if(m_stockCount <= newValue)
					{
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_005);
						newValue = m_stockCount;
					}
					else
					{
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					}
				}
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_textPopupSetting.TitleText = bk.GetMessageByLabel("growth_popup_title_text06");
				m_textPopupSetting.Text = bk.GetMessageByLabel("growth_popup_text15");
				PopupWindowManager.Show(m_textPopupSetting, null, null, null, null);
				newValue--;
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			}
			Value = newValue;
		}

		// RVA: 0x17A9070 Offset: 0x17A9070 VA: 0x17A9070
		private void ApplyUnlockCountText(int value)
		{
			m_texts[2].text = value.ToString();
		}

		// RVA: 0x17A9C10 Offset: 0x17A9C10 VA: 0x17A9C10 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
