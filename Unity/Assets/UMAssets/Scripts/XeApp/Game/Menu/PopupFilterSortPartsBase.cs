using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortPartsBase : LayoutUGUIScriptBase
	{
		public enum Type
		{
			None = 0,
			TitleH1 = 1,
			TitleH2 = 2,
			Sort = 3,
			FilterDiva = 4,
			FilterSeries = 5,
			FilterMainEp = 6,
			FilterGoDivaExp = 7,
		}

		[SerializeField]
		private RectTransform m_rectSizeGuid; // 0x14
		[SerializeField]
		protected PopupFilterSortPartsBase.Type m_type; // 0x18

		// RVA: 0xF94F00 Offset: 0xF94F00 VA: 0xF94F00 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			RectTransform rt = gameObject.GetComponent<RectTransform>();
			rt.sizeDelta = m_rectSizeGuid.sizeDelta;
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			rt.pivot = new Vector2(0, 1);
			rt.anchoredPosition3D = new Vector3(0, 0, 0);
			return true;
		}

		// RVA: 0xF950F0 Offset: 0xF950F0 VA: 0xF950F0 Slot: 6
		public virtual RectTransform GetGuidSize()
		{
			return m_rectSizeGuid;
		}

		// // RVA: 0xF950F8 Offset: 0xF950F8 VA: 0xF950F8
		// public PopupFilterSortPartsBase.Type GetType() { }

		// // RVA: 0xF95100 Offset: 0xF95100 VA: 0xF95100
		protected void SetFilterButton(ToggleButton[] a_btn, uint a_bit)
		{
			a_btn[0].SetOff();
			for(int i = 1; i < a_btn.Length; i++)
			{
				if((a_bit & (1 << (i - 1))) == 0)
				{
					a_btn[i].SetOff();
				}
				else
				{
					a_btn[i].SetOn();
				}
			}
		}

		// // RVA: 0xF953C4 Offset: 0xF953C4 VA: 0xF953C4
		protected uint GetFilterButtonBit(ToggleButton[] buttons)
		{
			uint res = 0;
			for(int i = 1; i < buttons.Length; i++)
			{
				if(buttons[i].IsOn)
					res |= (uint)(1 << (i - 1));
			}
			return res;
		}

		// // RVA: 0xF9521C Offset: 0xF9521C VA: 0xF9521C
		protected void PushFilterButton(int index, ToggleButton[] buttons)
		{
			if(index == 0)
			{
				buttons[0].SetOn();
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

		// // RVA: 0xF95460 Offset: 0xF95460 VA: 0xF95460
		protected void SetFilterButtonSingle(ToggleButton[] a_btn, uint a_bit)
		{
			a_btn[0].SetOff();
			for(int i = 1; i < a_btn.Length; i++)
			{
				if((a_bit & (1 << (i - 1))) == 0)
				{
					a_btn[i].SetOff();
					a_btn[i].IsInputLock = false;
				}
				else
				{
					a_btn[i].SetOn();
					a_btn[i].IsInputLock = true;
				}
			}
		}

		// // RVA: 0xF955E0 Offset: 0xF955E0 VA: 0xF955E0
		protected void PushFilterButtonSingle(int index, ToggleButton[] buttons)
		{
			for(int i = 1; i < buttons.Length; i++)
			{
				if(index == i)
				{
					buttons[i].IsInputLock = true;
				}
				else
				{
					buttons[i].SetOff();
					buttons[i].IsInputLock = false;
				}
			}
		}
	}
}
