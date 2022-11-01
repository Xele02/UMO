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
		// private AOJGDNFAIJL.AMIECPBIALP m_prismData; // 0x38

		public InOutAnime InOut { get { return m_inOut; } } //0xA73650

		// // RVA: 0xA73658 Offset: 0xA73658 VA: 0xA73658
		private void Awake()
		{
			TodoLogger.Log(0, "SetDeckPrismSettingButtons Awake");
		}

		// // RVA: 0xA739D8 Offset: 0xA739D8 VA: 0xA739D8
		public void UpdateContent(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, SetDeckPrismSettingButtons.ModeType modeType, bool isExistOriginalSetting)
		{
			TodoLogger.Log(0, "SetDeckPrismSettingButtons UpdateContent");
		}

		// // RVA: 0xA73C14 Offset: 0xA73C14 VA: 0xA73C14
		// private void ApplyPrismButton(bool isPrismEnable) { }

		// // RVA: 0xA73C60 Offset: 0xA73C60 VA: 0xA73C60
		// private void ApplyValkyrieModeButton(bool isValkyrieMode) { }

		// // RVA: 0xA73CAC Offset: 0xA73CAC VA: 0xA73CAC
		// private void ApplyNotesButton(bool isNotesOn) { }

		// // RVA: 0xA73CF8 Offset: 0xA73CF8 VA: 0xA73CF8
		// private void ApplyDivaSpModeButton(bool isDivaSpMode) { }

		// // RVA: 0xA73D44 Offset: 0xA73D44 VA: 0xA73D44
		// private void OnClickPrismButtonFunc() { }

		// // RVA: 0xA73E08 Offset: 0xA73E08 VA: 0xA73E08
		// private void OnClickValkyrieModeButtonFunc() { }

		// // RVA: 0xA73ECC Offset: 0xA73ECC VA: 0xA73ECC
		// private void OnClickNotesButtonFunc() { }

		// // RVA: 0xA73F90 Offset: 0xA73F90 VA: 0xA73F90
		// private void OnClickDivaSpModeButtonFunc() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CEC Offset: 0x730CEC VA: 0x730CEC
		// // RVA: 0xA7405C Offset: 0xA7405C VA: 0xA7405C
		// private void <Awake>b__15_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CFC Offset: 0x730CFC VA: 0x730CFC
		// // RVA: 0xA74060 Offset: 0xA74060 VA: 0xA74060
		// private void <Awake>b__15_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730D0C Offset: 0x730D0C VA: 0x730D0C
		// // RVA: 0xA74064 Offset: 0xA74064 VA: 0xA74064
		// private void <Awake>b__15_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730D1C Offset: 0x730D1C VA: 0x730D1C
		// // RVA: 0xA74068 Offset: 0xA74068 VA: 0xA74068
		// private void <Awake>b__15_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730D2C Offset: 0x730D2C VA: 0x730D2C
		// // RVA: 0xA7406C Offset: 0xA7406C VA: 0xA7406C
		// private void <Awake>b__15_4() { }
	}
}
