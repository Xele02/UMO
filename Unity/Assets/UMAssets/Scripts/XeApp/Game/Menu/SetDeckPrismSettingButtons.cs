using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckPrismSettingButtons : MonoBehaviour
	{
		public enum ModeType
		{
			Prism = 0,
			SLive = 1,
		}

		// [TooltipAttribute] // RVA: 0x682474 Offset: 0x682474 VA: 0x682474
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x682474 Offset: 0x682474 VA: 0x682474
		private InOutAnime m_inOut; // 0xC
		// [TooltipAttribute] // RVA: 0x6824E4 Offset: 0x6824E4 VA: 0x6824E4
		[SerializeField]
		private GameObject m_prismButtonObject; // 0x10
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x68254C Offset: 0x68254C VA: 0x68254C
		private UGUIToggleButton m_prismButton; // 0x14
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6825A4 Offset: 0x6825A4 VA: 0x6825A4
		private GameObject m_valkyrieModeButtonObject; // 0x18
		// [TooltipAttribute] // RVA: 0x682618 Offset: 0x682618 VA: 0x682618
		[SerializeField]
		private UGUIToggleButton m_valkyrieModeButton; // 0x1C
		// [TooltipAttribute] // RVA: 0x68267C Offset: 0x68267C VA: 0x68267C
		[SerializeField]
		private GameObject m_notesButtonObject; // 0x20
		// [TooltipAttribute] // RVA: 0x6826E8 Offset: 0x6826E8 VA: 0x6826E8
		[SerializeField]
		private UGUIToggleButton m_notesButton; // 0x24
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x682744 Offset: 0x682744 VA: 0x682744
		private GameObject m_divaSpModeButtonObject; // 0x28
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6827B4 Offset: 0x6827B4 VA: 0x6827B4
		private UGUIToggleButton m_divaSpModeButton; // 0x2C
		// [TooltipAttribute] // RVA: 0x682810 Offset: 0x682810 VA: 0x682810
		[SerializeField]
		private UGUIButton m_originalSettingButton; // 0x30
		public Action OnClickOriginalSettingButton; // 0x34
		private AOJGDNFAIJL_PrismData.AMIECPBIALP m_prismData; // 0x38

		public InOutAnime InOut { get { return m_inOut; } } //0xA73650

		// // RVA: 0xA73658 Offset: 0xA73658 VA: 0xA73658
		private void Awake()
		{
			if(m_prismButton != null)
			{
				m_prismButton.AddOnClickCallback(() =>
				{
					//0xA7405C
					OnClickPrismButtonFunc();
				});
			}
			if(m_valkyrieModeButton != null)
			{
				m_valkyrieModeButton.AddOnClickCallback(() =>
				{
					//0xA74060
					OnClickValkyrieModeButtonFunc();
				});
			}
			if(m_notesButton != null)
			{
				m_notesButton.AddOnClickCallback(() =>
				{
					//0xA74064
					OnClickNotesButtonFunc();
				});
			}
			if(m_divaSpModeButton != null)
			{
				m_divaSpModeButton.AddOnClickCallback(() =>
				{
					//0xA74068
					OnClickDivaSpModeButtonFunc();
				});
			}
			if(m_originalSettingButton != null)
			{
				m_originalSettingButton.AddOnClickCallback(() =>
				{
					//0xA7406C
					if (OnClickOriginalSettingButton != null)
						OnClickOriginalSettingButton();
				});
			}
		}

		// // RVA: 0xA739D8 Offset: 0xA739D8 VA: 0xA739D8
		public void UpdateContent(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, SetDeckPrismSettingButtons.ModeType modeType, bool isExistOriginalSetting)
		{
			m_prismData = prismData;
			if(modeType == ModeType.SLive)
			{
				m_prismButtonObject.SetActive(false);
				m_valkyrieModeButtonObject.SetActive(true);
				m_notesButtonObject.SetActive(true);
				m_divaSpModeButtonObject.SetActive(true);
			}
			else
			{
				m_prismButtonObject.SetActive(true);
				m_valkyrieModeButtonObject.SetActive(false);
				m_notesButtonObject.SetActive(false);
				m_divaSpModeButtonObject.SetActive(false);
			}
			modeType = ModeType.Prism;
			ApplyPrismButton(prismData.FBGAKINEIPG);
			ApplyValkyrieModeButton(prismData.OHLCKPIMMFH_ValkyrieMode);
			ApplyNotesButton(m_prismData.DNLCLAOPFPF_ShowNotes);
			ApplyDivaSpModeButton(m_prismData.HGEKDNNJAAC_DivaMode);
			m_originalSettingButton.gameObject.SetActive(isExistOriginalSetting);
		}

		// // RVA: 0xA73C14 Offset: 0xA73C14 VA: 0xA73C14
		private void ApplyPrismButton(bool isPrismEnable)
		{
			if (isPrismEnable)
				m_prismButton.SetOn();
			else
				m_prismButton.SetOff();
		}

		// // RVA: 0xA73C60 Offset: 0xA73C60 VA: 0xA73C60
		private void ApplyValkyrieModeButton(bool isValkyrieMode)
		{
			if (isValkyrieMode)
				m_valkyrieModeButton.SetOn();
			else
				m_valkyrieModeButton.SetOff();
		}

		// // RVA: 0xA73CAC Offset: 0xA73CAC VA: 0xA73CAC
		private void ApplyNotesButton(bool isNotesOn)
		{
			if (isNotesOn)
				m_notesButton.SetOn();
			else
				m_notesButton.SetOff();
		}

		// // RVA: 0xA73CF8 Offset: 0xA73CF8 VA: 0xA73CF8
		private void ApplyDivaSpModeButton(bool isDivaSpMode)
		{
			if (isDivaSpMode)
				m_divaSpModeButton.SetOn();
			else
				m_divaSpModeButton.SetOff();
		}

		// // RVA: 0xA73D44 Offset: 0xA73D44 VA: 0xA73D44
		private void OnClickPrismButtonFunc()
		{
			SoundManager.Instance.sePlayerBoot.Play(3);
			m_prismData.NFMFFMDHBJO(m_prismButton.IsOn);
			m_prismData.LMAAILCIFLF_ApplyInSave();
		}

		// // RVA: 0xA73E08 Offset: 0xA73E08 VA: 0xA73E08
		private void OnClickValkyrieModeButtonFunc()
		{
			SoundManager.Instance.sePlayerBoot.Play(3);
			m_prismData.EOGMEFOFOBJ_SetValkyrieMode(m_valkyrieModeButton.IsOn);
			m_prismData.LMAAILCIFLF_ApplyInSave();
		}

		// // RVA: 0xA73ECC Offset: 0xA73ECC VA: 0xA73ECC
		private void OnClickNotesButtonFunc()
		{
			SoundManager.Instance.sePlayerBoot.Play(3);
			m_prismData.NEJBBHHINLA_SetShowNotes(m_notesButton.IsOn);
			m_prismData.LMAAILCIFLF_ApplyInSave();
		}

		// // RVA: 0xA73F90 Offset: 0xA73F90 VA: 0xA73F90
		private void OnClickDivaSpModeButtonFunc()
		{
			SoundManager.Instance.sePlayerBoot.Play(3);
			m_prismData.FNMFBCGCPGP_SetDivaMode(m_divaSpModeButton.IsOn);
			m_prismData.LMAAILCIFLF_ApplyInSave();
		}
	}
}
