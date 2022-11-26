using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckHeadButtons : MonoBehaviour
	{
		public enum Type
		{
			None = 0,
			TeamSelect = 1,
			Prism = 2,
			TeamEdit = 3,
			SLive = 4,
		}

		public enum PrismType
		{
			ON = 0,
			OFF = 1,
			Lock = 2,
		}

		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681304 Offset: 0x681304 VA: 0x681304
		// [HeaderAttribute] // RVA: 0x681304 Offset: 0x681304 VA: 0x681304
		private InOutAnime m_inOut; // 0xC
		// [TooltipAttribute] // RVA: 0x681374 Offset: 0x681374 VA: 0x681374
		[SerializeField]
		private UGUIButton m_autoSettingButton; // 0x10
		// [TooltipAttribute] // RVA: 0x6813CC Offset: 0x6813CC VA: 0x6813CC
		[SerializeField]
		private UGUIButton m_unitSetButton; // 0x14
		// [TooltipAttribute] // RVA: 0x68142C Offset: 0x68142C VA: 0x68142C
		[SerializeField]
		private UGUIButton m_prismButton; // 0x18
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x68148C Offset: 0x68148C VA: 0x68148C
		private ColorGroup m_prismButtonColor; // 0x1C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6814F4 Offset: 0x6814F4 VA: 0x6814F4
		private Image m_prismOnImage; // 0x20
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681560 Offset: 0x681560 VA: 0x681560
		private Image m_prismOffImage; // 0x24
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6815CC Offset: 0x6815CC VA: 0x6815CC
		private Text m_prismOnOffText; // 0x28
		// [TooltipAttribute] // RVA: 0x681640 Offset: 0x681640 VA: 0x681640
		[SerializeField]
		private List<SpriteAnime> m_prismOnEffectAnimes; // 0x2C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681688 Offset: 0x681688 VA: 0x681688
		private Image m_prismLockImage; // 0x30
		// [TooltipAttribute] // RVA: 0x681708 Offset: 0x681708 VA: 0x681708
		[SerializeField]
		private UGUIButton m_unitButton; // 0x34
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681764 Offset: 0x681764 VA: 0x681764
		private UGUIButton m_settingButton; // 0x38
		public Action OnClickAutoSettingButton; // 0x3C
		public Action OnClickUnitSetButton; // 0x40
		public Action OnClickPrismButton; // 0x44
		public Action OnClickUnitButton; // 0x48
		public Action OnClickSettingButton; // 0x4C

		public InOutAnime InOut { get { return m_inOut; } } //0xA6E4A8
		// public UGUIButton AutoSettingButton { get; } 0xA6E4B0

		// // RVA: 0xA6E4B8 Offset: 0xA6E4B8 VA: 0xA6E4B8
		private void Awake()
		{
			if(m_autoSettingButton != null)
			{
				m_autoSettingButton.AddOnClickCallback(() =>
				{
					//0xA6F3CC
					if (OnClickAutoSettingButton != null)
						OnClickAutoSettingButton();
				});
			}
			if(m_unitSetButton != null)
			{
				m_unitSetButton.AddOnClickCallback(() =>
				{
					//0xA6F3E0
					if (OnClickUnitSetButton != null)
						OnClickUnitSetButton();
				});
			}
			if(m_prismButton != null)
			{
				m_prismButton.AddOnClickCallback(() =>
				{
					//0xA6F3F4
					if (OnClickPrismButton != null)
						OnClickPrismButton();
				});
			}
			if(m_unitButton != null)
			{
				m_unitButton.AddOnClickCallback(() =>
				{
					//0xA6F408
					if (OnClickUnitButton != null)
						OnClickUnitButton();
				});
			}
			if(m_settingButton != null)
			{
				m_settingButton.AddOnClickCallback(() =>
				{
					//0xA6F41C
					if (OnClickSettingButton != null)
						OnClickSettingButton();
				});
			}
		}

		// // RVA: 0xA6E838 Offset: 0xA6E838 VA: 0xA6E838
		public void SetType(Type type)
		{
			switch(type)
			{
				case Type.TeamSelect:
					m_autoSettingButton.gameObject.SetActive(true);
					m_autoSettingButton.Disable = false;
					m_unitSetButton.gameObject.SetActive(true);
					m_unitSetButton.Disable = false;
					m_prismButton.gameObject.SetActive(true);
					m_unitButton.gameObject.SetActive(false);
					m_settingButton.gameObject.SetActive(true);
					break;
				case Type.Prism:
					m_autoSettingButton.gameObject.SetActive(true);
					m_autoSettingButton.Disable = true;
					m_unitSetButton.gameObject.SetActive(true);
					m_unitSetButton.Disable = true;
					m_prismButton.gameObject.SetActive(false);
					m_unitButton.gameObject.SetActive(true);
					m_settingButton.gameObject.SetActive(true);
					break;
				case Type.TeamEdit:
					m_autoSettingButton.gameObject.SetActive(true);
					m_autoSettingButton.Disable = false;
					m_unitSetButton.gameObject.SetActive(true);
					m_unitSetButton.Disable = false;
					m_prismButton.gameObject.SetActive(false);
					m_unitButton.gameObject.SetActive(false);
					m_settingButton.gameObject.SetActive(false);
					break;
				case Type.SLive:
					m_autoSettingButton.gameObject.SetActive(false);
					m_unitSetButton.gameObject.SetActive(false);
					m_prismButton.gameObject.SetActive(false);
					m_unitButton.gameObject.SetActive(false);
					m_settingButton.gameObject.SetActive(true);
					break;
			}
		}

		// // RVA: 0xA6EDC4 Offset: 0xA6EDC4 VA: 0xA6EDC4
		// public void SetPrismType(SetDeckHeadButtons.PrismType type) { }
	}
}
