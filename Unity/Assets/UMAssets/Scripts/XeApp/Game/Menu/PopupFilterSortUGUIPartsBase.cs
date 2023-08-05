using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public abstract class PopupFilterSortUGUIPartsBase : MonoBehaviour
	{
		public enum Type
		{
			NoControl = 0,
			TitleH1 = 1,
			TitleH2 = 2,
			Sort = 3,
			ToggleButtons = 4,
			ExclusiveToggleButtons = 5,
			RangeSlider = 6,
			FilterSeries = 7,
			FilterMusicAttr = 8,
			FilterGoDivaMusicExp = 9,
			FilterUnitLive = 10,
			FilterComb = 11,
			FilterReward = 12,
			FilterBonus = 13,
			FilterRarity = 14,
			FilterSkill = 15,
			FilterPlate = 16,
			FilterMusicLock = 17,
			FilterMusicBookMark = 18,
			FilterRange = 19,
			FilterMusicSelectSeries = 20,
			FilterMusicSelect = 21,
			FilterShopProduct = 22,
		}
		
		private bool m_waitInitialize = true; // 0xC

		// RVA: -1 Offset: -1 Slot: 4
		public abstract Type MyType { get; }
		public bool IsReady { get { return !m_waitInitialize; } } //0x1C9EC2C

		// // RVA: 0x1C96148 Offset: 0x1C96148 VA: 0x1C96148
		public RectTransform GetGuidSize()
		{
			return GetComponent<RectTransform>();
		}

		// // RVA: 0x1C9EC40 Offset: 0x1C9EC40 VA: 0x1C9EC40
		public void Initialize()
		{
			this.StartCoroutineWatched(Co_Initialize());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x709FF4 Offset: 0x709FF4 VA: 0x709FF4
		// // RVA: 0x1C9EC64 Offset: 0x1C9EC64 VA: 0x1C9EC64
		private IEnumerator Co_Initialize()
		{
			//0x1C9F350
			yield return OnInitialize();
			m_waitInitialize = false;
		}

		// // RVA: -1 Offset: -1 Slot: 5
		protected abstract IEnumerator OnInitialize();

		// // RVA: 0x1C9ED10 Offset: 0x1C9ED10 VA: 0x1C9ED10
		protected static void SetFilterButtonsWithAllButton(UGUIToggleButton[] a_btn, uint a_bit)
		{
			if(a_bit == 0)
				PushFilterButtonsWithAllButton(0, a_btn);
			else
			{
				a_btn[0].SetOff();
				for(int i = 1; i < a_btn.Length; i++)
				{
					if((a_bit & (1 << (i - 1))) != 0)
					{
						a_btn[i].SetOn();
					}
					else
					{
						a_btn[i].SetOff();
					}
				}
			}
		}

		// // RVA: 0x1C9EFD4 Offset: 0x1C9EFD4 VA: 0x1C9EFD4
		// protected static void SetFilterButtons(UGUIToggleButton[] a_btn, uint a_bit) { }

		// // RVA: 0x1C9F07C Offset: 0x1C9F07C VA: 0x1C9F07C
		// protected static void SetFilterButtonsLong(UGUIToggleButton[] a_btn, ulong a_bit) { }

		// // RVA: 0x1C9F154 Offset: 0x1C9F154 VA: 0x1C9F154
		protected static uint GetFilterButtonsBitWithAllButton(UGUIToggleButton[] buttons)
		{
			uint res = 0;
			for(int i = 1; i < buttons.Length; i++)
			{
				if(buttons[i].IsOn)
				{
					res |= (uint)(1 << (i - 1));
				}
			}
			return res;
		}

		// // RVA: 0x1C9F1F0 Offset: 0x1C9F1F0 VA: 0x1C9F1F0
		// protected static uint GetFilterButtonsBit(UGUIToggleButton[] buttons) { }

		// // RVA: 0x1C9F27C Offset: 0x1C9F27C VA: 0x1C9F27C
		// protected static ulong GetFilterButtonsBitLong(UGUIToggleButton[] buttons) { }

		// // RVA: 0x1C9EE2C Offset: 0x1C9EE2C VA: 0x1C9EE2C
		protected static void PushFilterButtonsWithAllButton(int index, UGUIToggleButton[] buttons)
		{
			if(index == 0)
			{
				buttons[0].SetOn();
				if(buttons.Length < 2)
					return;
				for(int i = 1; i < buttons.Length; i++)
				{
					buttons[i].SetOff();
				}
			}
			else
			{
				bool b = true;
				for(int i = 1; i < buttons.Length; i++)
				{
					if(buttons[i].IsOn)
					{
						b = false;
						break;
					}
				}
				if(b)
					buttons[0].SetOn();
				else
					buttons[0].SetOff();
			}
		}
	}
}
