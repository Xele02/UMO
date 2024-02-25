using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupGakuyaPresentUse2Contents : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private PopupWindowControl m_popupControl; // 0x14
		[SerializeField]
		private RawImage m_imagePresent; // 0x18
		[SerializeField]
		private Text m_textMessage; // 0x1C
		[SerializeField]
		private Text m_useItemValText; // 0x20
		[SerializeField]
		private Text m_cautionText; // 0x24
		[SerializeField]
		private UGUIButton m_subButton; // 0x28
		[SerializeField]
		private UGUIButton m_addButton; // 0x2C
		private bool m_isLoadingPresentTexture; // 0x30
		private int m_currentUseItemVal; // 0x34
		private int m_haveItemVal; // 0x38
		private int m_maxUseItemVal; // 0x3C
		private const int m_minUseItemVal = 0;
		private int xor; // 0x40

		public int UseItemVal { get { return m_currentUseItemVal ^ xor; } private set { m_currentUseItemVal = xor ^ value; } } //0x17A6B80 0x17A6B90
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17A6BB0 Offset: 0x17A6BB0 VA: 0x17A6BB0
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
			m_subButton.ClearOnClickCallback();
			m_addButton.ClearOnClickCallback();
			m_subButton.AddOnClickCallback(OnClickSubButton);
			m_addButton.AddOnClickCallback(OnClickAddButton);
		}

		// RVA: 0x17A6D30 Offset: 0x17A6D30 VA: 0x17A6D30 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupGakuyaPresentUse2Setting s = setting as PopupGakuyaPresentUse2Setting;
			xor = LPDNKHAIOLH.CEIBAFOCNCA();
			UseItemVal = 0;
			m_popupControl = control;
			Parent = s.m_parent;
			m_useItemValText.text = 0.ToString();
			m_haveItemVal = s.m_haveItemVal;
			m_isLoadingPresentTexture = true;
			m_maxUseItemVal = s.m_maxUseItemVal;
			GameManager.Instance.ItemTextureCache.Load(s.m_divaPresentData.KIJAPOFAGPN_FullItemId, (IiconTexture icon) =>
			{
				//0x17A7528
				icon.Set(m_imagePresent);
				m_isLoadingPresentTexture = false;
			});
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textMessage.text = string.Format(bk.GetMessageByLabel("pop_gakuya_present_ask"), OJEGDIBEBHP.MPKLLGIOBIP_GetDesc2(s.m_divaPresentData.ADJBIEOILPJ_Id));
			m_cautionText.text = bk.GetMessageByLabel("pop_gakuya_present_caution");
			gameObject.SetActive(true);
			ButtonStateUpdate();
		}

		// RVA: 0x17A72DC Offset: 0x17A72DC VA: 0x17A72DC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17A72E4 Offset: 0x17A72E4 VA: 0x17A72E4 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x17A731C Offset: 0x17A731C VA: 0x17A731C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17A7354 Offset: 0x17A7354 VA: 0x17A7354 Slot: 21
		public bool IsReady()
		{
			return !m_isLoadingPresentTexture;
		}

		// RVA: 0x17A7368 Offset: 0x17A7368 VA: 0x17A7368 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0x17A736C Offset: 0x17A736C VA: 0x17A736C
		private void OnClickAddButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(UseItemVal < m_maxUseItemVal)
			{
				UseItemVal++;
				m_useItemValText.text = UseItemVal.ToString();
			}
			ButtonStateUpdate();
		}

		// // RVA: 0x17A744C Offset: 0x17A744C VA: 0x17A744C
		private void OnClickSubButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(UseItemVal > 0)
			{
				UseItemVal--;
				m_useItemValText.text = UseItemVal.ToString();
			}
			ButtonStateUpdate();
		}

		// // RVA: 0x17A7164 Offset: 0x17A7164 VA: 0x17A7164
		private void ButtonStateUpdate()
		{
			m_subButton.Disable = UseItemVal < 1;
			m_addButton.Disable = UseItemVal >= m_haveItemVal || m_maxUseItemVal <= UseItemVal;
			ActionButton btn = m_popupControl.FindButton(PopupButton.ButtonLabel.Ok);
			if(btn != null)
			btn.Disable = UseItemVal < 1;
		}
	}
}
