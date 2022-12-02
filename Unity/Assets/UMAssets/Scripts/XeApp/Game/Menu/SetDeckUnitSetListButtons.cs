using UnityEngine;
using System;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitSetListButtons : MonoBehaviour
	{
		[Serializable]
		private class UnitButtonElement
		{
			[SerializeField]
			//[TooltipAttribute] // RVA: 0x684C04 Offset: 0x684C04 VA: 0x684C04
			public UGUIButton m_button; // 0x8
			[SerializeField]
			//[TooltipAttribute] // RVA: 0x684C4C Offset: 0x684C4C VA: 0x684C4C
			public Text m_nameText; // 0xC
			[SerializeField]
			//[TooltipAttribute] // RVA: 0x684C94 Offset: 0x684C94 VA: 0x684C94
			public ScrollText m_nameScroll; // 0x10
			//[TooltipAttribute] // RVA: 0x684D08 Offset: 0x684D08 VA: 0x684D08
			[SerializeField]
			public Image m_buttonImage; // 0x14
		}
		
		//[TooltipAttribute] // RVA: 0x684848 Offset: 0x684848 VA: 0x684848
		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684890 Offset: 0x684890 VA: 0x684890
		private Animator m_unitSetButtonsAnimator; // 0x10
		//[TooltipAttribute] // RVA: 0x684900 Offset: 0x684900 VA: 0x684900
		[SerializeField]
		private List<UnitButtonElement> m_unitButtons; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684970 Offset: 0x684970 VA: 0x684970
		private List<UnitButtonElement> m_switchUnitButtonsBefore; // 0x18
		//[TooltipAttribute] // RVA: 0x6849EC Offset: 0x6849EC VA: 0x6849EC
		[SerializeField]
		private List<UnitButtonElement> m_switchUnitButtonsAfter; // 0x1C
		//[TooltipAttribute] // RVA: 0x684A68 Offset: 0x684A68 VA: 0x684A68
		[SerializeField]
		private UGUIButton m_pageButton; // 0x20
		//[TooltipAttribute] // RVA: 0x684AC8 Offset: 0x684AC8 VA: 0x684AC8
		[SerializeField]
		private Text m_pageButtonText; // 0x24
		//[TooltipAttribute] // RVA: 0x684B34 Offset: 0x684B34 VA: 0x684B34
		[SerializeField]
		private Sprite m_unitButtonDefaultSprite; // 0x28
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684B9C Offset: 0x684B9C VA: 0x684B9C
		private Sprite m_unitButtonSelectingSprite; // 0x2C
		public Action<int, JLKEOGLJNOD> OnClickUnitButton; // 0x30
		public Action<int, JLKEOGLJNOD> OnChangeUnit; // 0x34
		public Action OnStartChangePage; // 0x38
		public Action OnEndChangePage; // 0x3C
		private DFKGGBMFFGB m_viewPlayerData; // 0x40
		private bool m_isGoDiva; // 0x44
		private int m_unitCount; // 0x48
		private int m_pageCount; // 0x4C
		private int m_unitIndex; // 0x50
		private int m_pageNo; // 0x54
		private bool m_isPageSwitching; // 0x58
		private Coroutine m_pageSwitchCoroutine; // 0x5C

		//public InOutAnime InOut { get; } 0xC38020
		//public int CurrentIndex { get; } 0xC38028
		//public JLKEOGLJNOD CurrentUnitData { get; } 0xC38030
		//public int UnitCount { get; } 0xC380E0
		//public bool IsPageSwitching { get; } 0xC380E8
		private int UnitButtonCount { get { return m_unitButtons.Count; } } //0xC380F0

		// RVA: 0xC38168 Offset: 0xC38168 VA: 0xC38168
		private void Awake()
		{
			if(m_pageButton != null)
			{
				m_pageButton.AddOnClickCallback(() =>
				{
					//0xC3977C
					OnClickPageButtonFunc();
				});
			}
			for(int i = 0; i < UnitButtonCount; i++)
			{
				int buttonNo = i;
				m_unitButtons[i].m_button.AddOnClickCallback(() =>
				{
					//0xC39794
					OnClickUnitButtonFunc(buttonNo);
				});
			}
		}

		//// RVA: 0xC38388 Offset: 0xC38388 VA: 0xC38388
		//public void UpdateContent(DFKGGBMFFGB viewPlayerData, bool isGoDiva, int selectIndex) { }

		//// RVA: 0xC38970 Offset: 0xC38970 VA: 0xC38970
		//public void UpdateContent(DFKGGBMFFGB viewPlayerData, bool isGoDiva) { }

		//// RVA: 0xC3898C Offset: 0xC3898C VA: 0xC3898C
		//public void ChangeSelect(int selectIndex, Action onEnd) { }

		//// RVA: 0xC38A98 Offset: 0xC38A98 VA: 0xC38A98
		//public void ResetUnitNameScroll() { }

		//// RVA: 0xC38E68 Offset: 0xC38E68 VA: 0xC38E68
		private void OnClickPageButtonFunc()
		{
			TodoLogger.Log(0, "OnClickPageButtonFunc");
		}

		//// RVA: 0xC38A24 Offset: 0xC38A24 VA: 0xC38A24
		//private void SwitchPage(int prevPageNo, int nextPageNo, Action onEnd) { }

		//[IteratorStateMachineAttribute] // RVA: 0x730E84 Offset: 0x730E84 VA: 0x730E84
		//// RVA: 0xC38F3C Offset: 0xC38F3C VA: 0xC38F3C
		//private IEnumerator Co_PageSwitchAnime(int prevPageNo, int nextPageNo, Action onEnd) { }

		//// RVA: 0xC39034 Offset: 0xC39034 VA: 0xC39034
		private void OnClickUnitButtonFunc(int buttonNo)
		{
			TodoLogger.Log(0, "OnClickUnitButtonFunc");
		}

		//// RVA: 0xC3917C Offset: 0xC3917C VA: 0xC3917C
		//private void CallOnChangeUnit() { }

		//// RVA: 0xC38564 Offset: 0xC38564 VA: 0xC38564
		//private void ApplyPageButton(int pageNo, int pageCount) { }

		//// RVA: 0xC3894C Offset: 0xC3894C VA: 0xC3894C
		//private void ApplyUnitButtonSelect(int unitIndex) { }

		//// RVA: 0xC39204 Offset: 0xC39204 VA: 0xC39204
		//private void ApplyUnitButtonSelect(List<SetDeckUnitSetListButtons.UnitButtonElement> buttons, int pageNo, int unitIndex) { }

		//// RVA: 0xC386B0 Offset: 0xC386B0 VA: 0xC386B0
		//private void ApplyUnitButtonStatus(int pageNo) { }

		//// RVA: 0xC39474 Offset: 0xC39474 VA: 0xC39474
		//private void ApplyUnitButtonStatus(List<SetDeckUnitSetListButtons.UnitButtonElement> buttons, int pageNo) { }

		//// RVA: 0xC3911C Offset: 0xC3911C VA: 0xC3911C
		//private int CalcUnitIndex(int buttonNo, int pageNo) { }

		//// RVA: 0xC39728 Offset: 0xC39728 VA: 0xC39728
		//private int CalcButtonNo(int unitIndex) { }

		//// RVA: 0xC38544 Offset: 0xC38544 VA: 0xC38544
		//private int CalcPageNo(int unitIndex) { }

		//// RVA: 0xC3974C Offset: 0xC3974C VA: 0xC3974C
		//private JLKEOGLJNOD GetUnitData(int buttonNo, int pageNo) { }

		//// RVA: 0xC39138 Offset: 0xC39138 VA: 0xC39138
		//private JLKEOGLJNOD GetUnitData(int unitIndex) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x730F0C Offset: 0x730F0C VA: 0x730F0C
		//// RVA: 0xC39780 Offset: 0xC39780 VA: 0xC39780
		//private void <OnClickPageButtonFunc>b__39_0() { }
	}
}
