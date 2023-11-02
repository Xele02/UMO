using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGachaRate : UIBehaviour, IPopupContent
	{
		private class ElemData
		{
			public GachaRateInfo info { get; set; } // 0x8
			//public GachaRateElemType elemType { get; set; } // 0xC
			public float pos { get; set; } // 0x10
			public float height { get; set; } // 0x14
			public GachaRateElemBase elem { get; set; } // 0x18
			//public float top { get; } 0x17A457C
			//public float bottom { get; } 0x17A4568
			//public GachaRateHeaderInfo headerInfo { get; } 0x17A4584
			//public GachaRateRarityInfo rarityInfo { get; } 0x17A461C
			//public GachaRateItemInfo itemInfo { get; } 0x17A46B4
			//public GachaRateMessageInfo messageInfo { get; } 0x17A474C
			//public GachaRateEpDetailInfo epDetailInfo { get; } 0x17A47E4
			//public GachaRateEpItemInfo epItemInfo { get; } 0x17A487C
			//public GachaRateSeparatorInfo separatorInfo { get; } 0x17A4914
		}

		private const int s_headerCapacity = 1;
		private const int s_rarityCapacity = 4;
		private const int s_itemCapacity = 7;
		private const int s_messageCapacity = 1;
		private const int s_epDetailCapacity = 4;
		private const int s_epItemCapacity = 7;
		private const int s_separatorCapacity = 3;
		private PopupWindowControl m_control; // 0xC
		private GachaRatePopupSetting m_setting; // 0x10
		private GachaRateListWindow m_layoutWindow; // 0x14
		private Vector2 m_scrollAreaSize; // 0x1C
		private Vector2 m_baseScale; // 0x24
		private bool m_isInitialized; // 0x2C
		private bool m_isLoaded; // 0x2D
		private int m_selectStepIndex = -1; // 0x30
		private List<GachaRateHeader> m_headerElems; // 0x34
		private List<GachaRateRarity> m_rarityElems; // 0x38
		private List<GachaRateItem> m_itemElems; // 0x3C
		private List<GachaRateMessage> m_messageElems; // 0x40
		private List<GachaRateEpDetail> m_epDetailElems; // 0x44
		private List<GachaRateEpItem> m_epItemElems; // 0x48
		private List<GachaRateSeparator> m_separatorElems; // 0x4C
		private List<GachaRateInfo> m_rarityInfoList; // 0x50
		private List<GachaRateInfo> m_episodeInfoList; // 0x54
		private List<ElemData> m_elemDatas; // 0x58
		private int m_beginElemIndex = -1; // 0x5C
		private int m_endElemIndex = -1; // 0x60
		private bool m_enableScrollMonitoring; // 0x64
		private ScrollRect m_scrollRect; // 0x6C
		private RectTransform m_scrollTrans; // 0x70

		public Transform Parent { get; private set; } // 0x18
		private List<GachaRateInfo> currentInfoList { get; set; } // 0x68
		//public RectTransform scrollTrans { get; } 0x17A20AC

		// RVA: 0x17A1F14 Offset: 0x17A1F14 VA: 0x17A1F14
		private void Awake()
		{
			m_baseScale = (transform as RectTransform).sizeDelta;
		}

		// RVA: 0x17A1FC8 Offset: 0x17A1FC8 VA: 0x17A1FC8
		private void Update()
		{
			if (!m_enableScrollMonitoring)
				return;
			UpdateScrollMonitor();
		}

		//// RVA: 0x17A20B4 Offset: 0x17A20B4 VA: 0x17A20B4
		public void UpdateContent(List<GachaRateInfo> infoList)
		{
			ReleaseCacheAll();
			currentInfoList = infoList;
			SetupContent(0);
			VisibleRegionUpdate();
		}

		// RVA: 0x17A3410 Offset: 0x17A3410 VA: 0x17A3410
		public void SwitchToRarityContent()
		{
			UpdateContent(m_rarityInfoList);
		}

		// RVA: 0x17A3418 Offset: 0x17A3418 VA: 0x17A3418
		public void SwitchToEpisodeContent()
		{
			UpdateContent(m_episodeInfoList);
		}

		//// RVA: 0x17A3350 Offset: 0x17A3350 VA: 0x17A3350
		private void VisibleRegionUpdate()
		{
			ReleaseCacheAll();
			GetVisibleAreaIndex(out m_beginElemIndex, out m_endElemIndex);
			for(int i = m_beginElemIndex; i <= m_endElemIndex; i++)
			{
				LockCache(m_elemDatas[i]);
			}
		}

		//// RVA: 0x17A1FD8 Offset: 0x17A1FD8 VA: 0x17A1FD8
		private void UpdateScrollMonitor()
		{
			int begin = 0;
			int end = 0;
			GetVisibleAreaIndex(out begin, out end);
			if(end >= m_beginElemIndex && m_endElemIndex >= begin)
			{
				if (m_beginElemIndex - begin < 0)
					ReleaseCacheRange(m_beginElemIndex, begin - 1);
				if (end - m_endElemIndex < 0)
					ReleaseCacheRange(end + 1, m_endElemIndex);
				if (m_beginElemIndex - begin > 0)
					LockCacheRange(begin, m_beginElemIndex - 1);
				if (end - m_endElemIndex > 0)
					LockCacheRange(m_endElemIndex + 1, end);
			}
			else
			{
				ReleaseCacheRange(m_beginElemIndex, m_endElemIndex);
				LockCacheRange(begin, end);
			}
			m_beginElemIndex = begin;
			m_endElemIndex = end;
		}

		//// RVA: 0x17A2208 Offset: 0x17A2208 VA: 0x17A2208
		private void SetupContent(float scrollPos)
		{
			!!!
		}

		//// RVA: 0x17A363C Offset: 0x17A363C VA: 0x17A363C
		//private void LockCache(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A3834 Offset: 0x17A3834 VA: 0x17A3834
		//private void LockCacheRange(int beginIndex, int endIndex) { }

		//// RVA: 0x17A44E0 Offset: 0x17A44E0 VA: 0x17A44E0
		private void ReleaseCache(ElemData data)
		{
			HideElem(data.elem);
			data.elem.isLocked = false;
			data.elem = null;
		}

		//// RVA: 0x17A3734 Offset: 0x17A3734 VA: 0x17A3734
		//private void ReleaseCacheRange(int beginIndex, int endIndex) { }

		//// RVA: 0x17A20E4 Offset: 0x17A20E4 VA: 0x17A20E4
		private void ReleaseCacheAll()
		{
			for(int i = 0; i < m_elemDatas.Count; i++)
			{
				if (m_elemDatas[i].elem != null)
					ReleaseCache(m_elemDatas[i]);
			}
		}

		//// RVA: 0x17A3420 Offset: 0x17A3420 VA: 0x17A3420
		//private void GetVisibleAreaIndex(out int beginIndex, out int endIndex) { }

		//// RVA: 0x17A4464 Offset: 0x17A4464 VA: 0x17A4464
		//private void ShowElem(GachaRateElemBase elem, float posY) { }

		//// RVA: 0x17A38D8 Offset: 0x17A38D8 VA: 0x17A38D8
		private void HideElem(GachaRateElemBase elem)
		{
			elem.rectTrans.anchoredPosition = new Vector2(1184, elem.rectTrans.anchoredPosition.y);
		}

		//// RVA: 0x17A3994 Offset: 0x17A3994 VA: 0x17A3994
		//private void ApplyForHeader(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A3E80 Offset: 0x17A3E80 VA: 0x17A3E80
		//private void ApplyForRarity(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A3F84 Offset: 0x17A3F84 VA: 0x17A3F84
		//private void ApplyForItem(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A3D98 Offset: 0x17A3D98 VA: 0x17A3D98
		//private void ApplyForMessage(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A40E0 Offset: 0x17A40E0 VA: 0x17A40E0
		//private void ApplyForEpDetail(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A4228 Offset: 0x17A4228 VA: 0x17A4228
		//private void ApplyForEpItem(PopupGachaRate.ElemData data) { }

		//// RVA: 0x17A43C0 Offset: 0x17A43C0 VA: 0x17A43C0
		//private void ApplyForSeparator(PopupGachaRate.ElemData data) { }

		//// RVA: -1 Offset: -1
		//private static T GetFreeElem<T>(List<T> elems) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x2092114 Offset: 0x2092114 VA: 0x2092114
		//|-PopupGachaRate.GetFreeElem<object>
		//|-PopupGachaRate.GetFreeElem<GachaRateEpDetail>
		//|-PopupGachaRate.GetFreeElem<GachaRateEpItem>
		//|-PopupGachaRate.GetFreeElem<GachaRateHeader>
		//|-PopupGachaRate.GetFreeElem<GachaRateItem>
		//|-PopupGachaRate.GetFreeElem<GachaRateMessage>
		//|-PopupGachaRate.GetFreeElem<GachaRateRarity>
		//|-PopupGachaRate.GetFreeElem<GachaRateSeparator>
		//*/

		// RVA: 0x17A49AC Offset: 0x17A49AC VA: 0x17A49AC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_control = control;
			m_setting = setting as GachaRatePopupSetting;
			Parent = setting.m_parent;
			m_scrollAreaSize = size;
			m_rarityInfoList = m_setting.RarityInfoList;
			m_episodeInfoList = m_setting.EpisodeInfoList;
			currentInfoList = m_rarityInfoList;
			if(m_layoutWindow == null)
			{
				m_layoutWindow = transform.GetComponentInChildren<GachaRateListWindow>();
			}
			m_layoutWindow.Initialize();
			m_layoutWindow.OnClickStepButton = (int index) =>
			{
				//0x17A4FC4
				if (m_setting.OnClickStepButton != null)
					m_setting.OnClickStepButton(index);
				UpdateContent(currentInfoList);
			};
			SetupContent(0);
			m_isInitialized = true;
		}

		// RVA: 0x17A4BDC Offset: 0x17A4BDC VA: 0x17A4BDC Slot: 18
		public bool IsScrollable()
		{
			return m_setting.Mode != 8;
		}

		// RVA: 0x17A4C0C Offset: 0x17A4C0C VA: 0x17A4C0C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_enableScrollMonitoring = true;
			m_scrollRect = GetComponentInParent<ScrollRect>();
			VisibleRegionUpdate();
		}

		// RVA: 0x17A4CB4 Offset: 0x17A4CB4 VA: 0x17A4CB4 Slot: 20
		public void Hide()
		{
			ReleaseCacheAll();
			m_enableScrollMonitoring = false;
			gameObject.SetActive(false);
		}

		// RVA: 0x17A4D00 Offset: 0x17A4D00 VA: 0x17A4D00 Slot: 21
		public bool IsReady()
		{
			return m_isInitialized && m_isLoaded;
		}

		// RVA: 0x17A4D20 Offset: 0x17A4D20 VA: 0x17A4D20 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70332C Offset: 0x70332C VA: 0x70332C
		//// RVA: 0x17A4D24 Offset: 0x17A4D24 VA: 0x17A4D24
		//public IEnumerator Co_LoadResources() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7033A4 Offset: 0x7033A4 VA: 0x7033A4
		//// RVA: 0x17A4DD0 Offset: 0x17A4DD0 VA: 0x17A4DD0
		//private IEnumerator Co_LoadLayouts() { }

		//[IteratorStateMachineAttribute] // RVA: 0x70341C Offset: 0x70341C VA: 0x70341C
		//// RVA: 0x17A4E7C Offset: 0x17A4E7C VA: 0x17A4E7C
		//protected static IEnumerator Co_LoadListElem(string bundleName, string assetName, Font font, int elemCount, string elemNameFormat, Action<LayoutUGUIRuntime> onLoadedElem) { }

		//[IteratorStateMachineAttribute] // RVA: 0x703494 Offset: 0x703494 VA: 0x703494
		//// RVA: -1 Offset: -1
		//private static IEnumerator Co_WaitForLoaded<T>(List<T> elems) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1A25324 Offset: 0x1A25324 VA: 0x1A25324
		//|-PopupGachaRate.Co_WaitForLoaded<object>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateEpDetail>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateEpItem>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateHeader>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateItem>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateMessage>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateRarity>
		//|-PopupGachaRate.Co_WaitForLoaded<GachaRateSeparator>
		//*/
		
		//[CompilerGeneratedAttribute] // RVA: 0x70351C Offset: 0x70351C VA: 0x70351C
		//// RVA: 0x17A5098 Offset: 0x17A5098 VA: 0x17A5098
		//private void <Co_LoadLayouts>b__72_0(LayoutUGUIRuntime instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70352C Offset: 0x70352C VA: 0x70352C
		//// RVA: 0x17A5144 Offset: 0x17A5144 VA: 0x17A5144
		//private void <Co_LoadLayouts>b__72_1(LayoutUGUIRuntime instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70353C Offset: 0x70353C VA: 0x70353C
		//// RVA: 0x17A51F0 Offset: 0x17A51F0 VA: 0x17A51F0
		//private void <Co_LoadLayouts>b__72_2(LayoutUGUIRuntime instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70354C Offset: 0x70354C VA: 0x70354C
		//// RVA: 0x17A529C Offset: 0x17A529C VA: 0x17A529C
		//private void <Co_LoadLayouts>b__72_3(LayoutUGUIRuntime instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70355C Offset: 0x70355C VA: 0x70355C
		//// RVA: 0x17A5348 Offset: 0x17A5348 VA: 0x17A5348
		//private void <Co_LoadLayouts>b__72_4(LayoutUGUIRuntime instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70356C Offset: 0x70356C VA: 0x70356C
		//// RVA: 0x17A53F4 Offset: 0x17A53F4 VA: 0x17A53F4
		//private void <Co_LoadLayouts>b__72_5(LayoutUGUIRuntime instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70357C Offset: 0x70357C VA: 0x70357C
		//// RVA: 0x17A54A0 Offset: 0x17A54A0 VA: 0x17A54A0
		//private void <Co_LoadLayouts>b__72_6(LayoutUGUIRuntime instance) { }
	}
}
