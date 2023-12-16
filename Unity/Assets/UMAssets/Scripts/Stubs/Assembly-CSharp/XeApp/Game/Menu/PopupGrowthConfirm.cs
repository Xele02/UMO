using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGrowthConfirm : UIBehaviour, IPopupContent
	{
		private GrowthAbilityList m_itemList; // 0x10
		private const float SizeSHeight = 96;
		private const float SizeMHeight = 210;
		public const int MsizeThresholdNum = 7;

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17A89C4 Offset: 0x17A89C4 VA: 0x17A89C4
		private void Awake()
		{
			m_itemList = GetComponent<GrowthAbilityList>();
		}

		// RVA: 0x17A8A2C Offset: 0x17A8A2C VA: 0x17A8A2C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, setting.WindowSize == SizeType.Middle ? 210 : 96);
			Parent = setting.m_parent;
		}

		// RVA: 0x17A8B2C Offset: 0x17A8B2C VA: 0x17A8B2C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17A8B34 Offset: 0x17A8B34 VA: 0x17A8B34 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x17A8B6C Offset: 0x17A8B6C VA: 0x17A8B6C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17A8BA4 Offset: 0x17A8BA4 VA: 0x17A8BA4 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x17A8BAC Offset: 0x17A8BAC VA: 0x17A8BAC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x724C34 Offset: 0x724C34 VA: 0x724C34
		// RVA: 0x17A8BB0 Offset: 0x17A8BB0 VA: 0x17A8BB0
		public IEnumerator LoadAppendLayoutCoroutine(int[] statuValue, bool isEpisodeComplete)
		{
			//0x17A8D68
			yield return Co.R(m_itemList.LoadObjectCoroutine(GetValidStatusValue(statuValue)));
			int j = 0;
			for (int i = 0; i < statuValue.Length; i++)
			{
				if(statuValue[i] > 0)
				{
					m_itemList.SetValue(j, i, statuValue[i]);
					j++;
				}
			}
			m_itemList.SetHeader(j, GetEpisodeStatusValue(statuValue) > 0 && isEpisodeComplete);
			for(; j < m_itemList.GetCount(); j++)
			{
				m_itemList.SetOff(j);
			}
		}

		// RVA: 0x17A8C90 Offset: 0x17A8C90 VA: 0x17A8C90
		public static int GetValidStatusValue(int[] statusValue)
		{
			int res = 0;
			for(int i = 0; i < statusValue.Length; i++)
			{
				if (statusValue[i] > 0)
					res++;
			}
			return res;
		}

		//// RVA: 0x17A8CF8 Offset: 0x17A8CF8 VA: 0x17A8CF8
		public static int GetEpisodeStatusValue(int[] statusValue)
		{
			return statusValue[20] + statusValue[18];
		}
	}
}
