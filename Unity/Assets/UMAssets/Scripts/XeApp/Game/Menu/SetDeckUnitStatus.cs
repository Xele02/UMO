using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitStatus : MonoBehaviour
	{
		public enum CheckStatusButtonState
		{
			Normal = 0,
			Display = 1,
		}

		// Fields
		//[HeaderAttribute] // RVA: 0x684ED4 Offset: 0x684ED4 VA: 0x684ED4
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684ED4 Offset: 0x684ED4 VA: 0x684ED4
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684F44 Offset: 0x684F44 VA: 0x684F44
		private Text m_unitNameText; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684F8C Offset: 0x684F8C VA: 0x684F8C
		private UGUIButton m_nameEditButton; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684FEC Offset: 0x684FEC VA: 0x684FEC
		private SetDeckStatusValueControl m_totalStatus; // 0x18
		//[TooltipAttribute] // RVA: 0x685054 Offset: 0x685054 VA: 0x685054
		[SerializeField]
		private Text m_invalidTotalText; // 0x1C
		//[TooltipAttribute] // RVA: 0x6850B8 Offset: 0x6850B8 VA: 0x6850B8
		[SerializeField]
		private GameObject m_episodeBonusObject; // 0x20
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x685128 Offset: 0x685128 VA: 0x685128
		private Text m_episodeBonusText; // 0x24
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x685190 Offset: 0x685190 VA: 0x685190
		private UGUIButton m_episodeBonusButton; // 0x28
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6851F8 Offset: 0x6851F8 VA: 0x6851F8
		private UGUIButton m_checkStatusButton; // 0x2C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x685258 Offset: 0x685258 VA: 0x685258
		private Image m_checkStatusButtonImage; // 0x30
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6852C0 Offset: 0x6852C0 VA: 0x6852C0
		private Text m_checkStatusButtonTextNormal; // 0x34
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x685338 Offset: 0x685338 VA: 0x685338
		private Text m_checkStatusButtonTextDisplay; // 0x38
		//[TooltipAttribute] // RVA: 0x6853B0 Offset: 0x6853B0 VA: 0x6853B0
		[SerializeField]
		private UGUIButton m_dispTypeButton; // 0x3C
		//[HeaderAttribute] // RVA: 0x68540C Offset: 0x68540C VA: 0x68540C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68540C Offset: 0x68540C VA: 0x68540C
		private Sprite m_checkStatusButtonSpriteNormal; // 0x40
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6854B4 Offset: 0x6854B4 VA: 0x6854B4
		private Sprite m_checkStatusButtonSpriteDisplay; // 0x44
		public Action OnClickNameEditButton; // 0x48
		public Action OnClickEpisodeBonusButton; // 0x4C
		public Action OnClickCheckStatusButton; // 0x50
		public Action OnClickDispTypeButton; // 0x54

		public InOutAnime InOut { get { return m_inOut; } } //0xC39E68

		// RVA: 0xC39E70 Offset: 0xC39E70 VA: 0xC39E70
		private void Awake()
		{
			m_invalidTotalText.text = TextConstant.InvalidText;
			SetCheckStatusButtonState(CheckStatusButtonState.Normal);
			if(m_nameEditButton != null)
			{
				m_nameEditButton.AddOnClickCallback(() =>
				{
					//0xC3A82C
					if (OnClickNameEditButton != null)
						OnClickNameEditButton();
				});
			}
			if(m_episodeBonusButton != null)
			{
				m_episodeBonusButton.AddOnClickCallback(() =>
				{
					//0xC3A840
					if (OnClickEpisodeBonusButton != null)
						OnClickEpisodeBonusButton();
				});
			}
			if(m_checkStatusButton != null)
			{
				m_checkStatusButton.AddOnClickCallback(() =>
				{
					//0xC3A854
					if (OnClickCheckStatusButton != null)
						OnClickCheckStatusButton();
				});
			}
			if(m_dispTypeButton != null)
			{
				m_dispTypeButton.AddOnClickCallback(() =>
				{
					//0xC3A868
					if (OnClickDispTypeButton != null)
						OnClickDispTypeButton();
				});
			}
		}

		//// RVA: 0xC3A344 Offset: 0xC3A344 VA: 0xC3A344
		public void UpdateContent(SetDeckParamCalculator paramCalculator)
		{
			if(paramCalculator.IsEmptyUnit)
			{
				m_invalidTotalText.gameObject.SetActive(true);
				m_totalStatus.gameObject.SetActive(false);
			}
			else
			{
				m_invalidTotalText.gameObject.SetActive(false);
				m_totalStatus.gameObject.SetActive(true);
				m_totalStatus.Set(paramCalculator.BaseStatus.Total, paramCalculator.AddStatus.Total, false, paramCalculator.SkillCalcResult.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.MKADAMIGMPO), paramCalculator.SkillCalcResult.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.MKADAMIGMPO), null, 0);
			}
			if(paramCalculator.IsEnableEpisodeBonus)
			{
				m_episodeBonusObject.SetActive(true);
				m_episodeBonusText.text = paramCalculator.EpisodeBonusPoint.ToString() + "%";
			}
			else
			{
				m_episodeBonusObject.SetActive(false);
			}
		}

		//// RVA: 0xC3A6F8 Offset: 0xC3A6F8 VA: 0xC3A6F8
		public void SetUnitName(string name)
		{
			if(m_unitNameText != null)
			{
				m_unitNameText.text = name;
			}
		}

		//// RVA: 0xC3A7BC Offset: 0xC3A7BC VA: 0xC3A7BC
		public void SetUnitNameEditButtonEnable(bool isEnable)
		{
			m_nameEditButton.Disable = !isEnable;
		}

		//// RVA: 0xC3A7F0 Offset: 0xC3A7F0 VA: 0xC3A7F0
		public void SetCheckStatusButtonEnable(bool isEnable)
		{
			m_checkStatusButton.Disable = !isEnable;
		}

		//// RVA: 0xC3A1C8 Offset: 0xC3A1C8 VA: 0xC3A1C8
		public void SetCheckStatusButtonState(CheckStatusButtonState state)
		{
			if(state == CheckStatusButtonState.Display)
			{
				m_checkStatusButtonImage.sprite = m_checkStatusButtonSpriteDisplay;
				m_checkStatusButtonTextNormal.gameObject.SetActive(false);
				m_checkStatusButtonTextDisplay.gameObject.SetActive(true);
			}
			else if(state == CheckStatusButtonState.Normal)
			{
				m_checkStatusButtonImage.sprite = m_checkStatusButtonSpriteNormal;
				m_checkStatusButtonTextNormal.gameObject.SetActive(true);
				m_checkStatusButtonTextDisplay.gameObject.SetActive(false);
			}
		}
	}
}
