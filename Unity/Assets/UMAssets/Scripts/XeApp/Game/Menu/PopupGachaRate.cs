using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public enum GachaRateElemType
	{
		Header = 0,
		Rarity = 1,
		Item = 2,
		Message = 3,
		EpDetail = 4,
		EpItem = 5,
		Separator = 6,
		_Num = 7,
	}

	public class PopupGachaRate : UIBehaviour, IPopupContent
	{
		private class ElemData
		{
			public GachaRateInfo info { get; set; } // 0x8
			public GachaRateElemType elemType { get; set; } // 0xC
			public float pos { get; set; } // 0x10
			public float height { get; set; } // 0x14
			public GachaRateElemBase elem { get; set; } // 0x18
			//public float top { get; } 0x17A457C
			//public float bottom { get; } 0x17A4568
			public GachaRateHeaderInfo headerInfo { get { return info as GachaRateHeaderInfo; } } //0x17A4584
			public GachaRateRarityInfo rarityInfo { get { return info as GachaRateRarityInfo; } } //0x17A461C
			public GachaRateItemInfo itemInfo { get { return info as GachaRateItemInfo; } } //0x17A46B4
			public GachaRateMessageInfo messageInfo { get { return info as GachaRateMessageInfo; } } //0x17A474C
			public GachaRateEpDetailInfo epDetailInfo { get { return info as GachaRateEpDetailInfo; } } //0x17A47E4
			public GachaRateEpItemInfo epItemInfo { get { return info as GachaRateEpItemInfo; } } //0x17A487C
			public GachaRateSeparatorInfo separatorInfo { get { return info as GachaRateSeparatorInfo; } } //0x17A4914
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
				if (m_beginElemIndex < begin)
					ReleaseCacheRange(m_beginElemIndex, begin - 1);
				if (end < m_endElemIndex)
					ReleaseCacheRange(end + 1, m_endElemIndex);
				if (m_beginElemIndex > begin)
					LockCacheRange(begin, m_beginElemIndex - 1);
				if (end > m_endElemIndex)
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
			if(m_setting.Mode == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
			{
				RectTransform rt = transform as RectTransform;
				rt.anchoredPosition3D = Vector3.zero;
				rt.sizeDelta = m_baseScale;
				m_layoutWindow.SetActive(true);
				m_scrollTrans = m_layoutWindow.scrollContent;
				m_layoutWindow.SetStatus(m_setting.Data.NECDFDNBHFK);
			}
			else
			{
				m_layoutWindow.SetActive(false);
				m_scrollTrans = transform as RectTransform;
			}
			for(int i = 0; i < m_headerElems.Count; i++)
			{
				m_headerElems[i].transform.SetParent(m_scrollTrans, false);
				HideElem(m_headerElems[i]);
			}
			for (int i = 0; i < m_rarityElems.Count; i++)
			{
				m_rarityElems[i].transform.SetParent(m_scrollTrans, false);
				HideElem(m_rarityElems[i]);
			}
			for (int i = 0; i < m_itemElems.Count; i++)
			{
				m_itemElems[i].transform.SetParent(m_scrollTrans, false);
				m_itemElems[i].SetNameAutoSize(true);
				HideElem(m_itemElems[i]);
			}
			for (int i = 0; i < m_messageElems.Count; i++)
			{
				m_messageElems[i].transform.SetParent(m_scrollTrans, false);
				HideElem(m_messageElems[i]);
			}
			for (int i = 0; i < m_epDetailElems.Count; i++)
			{
				m_epDetailElems[i].transform.SetParent(m_scrollTrans, false);
				HideElem(m_epDetailElems[i]);
			}
			for (int i = 0; i < m_epItemElems.Count; i++)
			{
				m_epItemElems[i].transform.SetParent(m_scrollTrans, false);
				m_epItemElems[i].SetNameAutoSize(true);
				HideElem(m_epItemElems[i]);
			}
			for (int i = 0; i < m_separatorElems.Count; i++)
			{
				m_separatorElems[i].transform.SetParent(m_scrollTrans, false);
				HideElem(m_separatorElems[i]);
			}
			float[] fs = new float[7]
			{
				m_headerElems[0].elemHeight,
				m_itemElems[0].elemHeight,
				m_rarityElems[0].elemHeight,
				m_messageElems[0].elemHeight,
				m_epDetailElems[0].elemHeight,
				m_epItemElems[0].elemHeight,
				m_separatorElems[0].elemHeight,
			};
			m_elemDatas = new List<ElemData>(currentInfoList.Count);
			float f = 0;
			for(int i = 0; i < currentInfoList.Count; i++)
			{
				ElemData data = new ElemData();
				data.info = currentInfoList[i];
				data.elemType = (GachaRateElemType)currentInfoList[i].typeId;
				float h = fs[currentInfoList[i].typeId];
				if(currentInfoList[i] is GachaRateHeaderInfo)
				{
					ApplyForHeader(data);
					h = data.elem.elemHeight;
				}
				else if (currentInfoList[i] is GachaRateMessageInfo)
				{
					ApplyForMessage(data);
					h = data.elem.elemHeight;
				}
				data.pos = f;
				data.height = h;
				m_elemDatas.Add(data);
				f -= h;
			}
			m_scrollTrans.sizeDelta = new Vector2(m_scrollTrans.sizeDelta.x, Mathf.Abs(f));
			m_scrollTrans.anchoredPosition = new Vector2(m_scrollTrans.anchoredPosition.x, scrollPos);
			m_control.StopScrollMovement();
		}

		//// RVA: 0x17A363C Offset: 0x17A363C VA: 0x17A363C
		private void LockCache(ElemData data)
		{
			switch(data.elemType)
			{
				case GachaRateElemType.Header:
					ApplyForHeader(data);
					break;
				case GachaRateElemType.Rarity:
					ApplyForRarity(data);
					break;
				case GachaRateElemType.Item:
					ApplyForItem(data);
					break;
				case GachaRateElemType.Message:
					ApplyForMessage(data);
					break;
				case GachaRateElemType.EpDetail:
					ApplyForEpDetail(data);
					break;
				case GachaRateElemType.EpItem:
					ApplyForEpItem(data);
					break;
				case GachaRateElemType.Separator:
					ApplyForSeparator(data);
					break;
			}
			ShowElem(data.elem, data.pos);
			data.elem.isLocked = true;
		}

		//// RVA: 0x17A3834 Offset: 0x17A3834 VA: 0x17A3834
		private void LockCacheRange(int beginIndex, int endIndex)
		{
			for(int i = beginIndex; i <= endIndex; i++)
			{
				LockCache(m_elemDatas[i]);
			}
		}

		//// RVA: 0x17A44E0 Offset: 0x17A44E0 VA: 0x17A44E0
		private void ReleaseCache(ElemData data)
		{
			HideElem(data.elem);
			data.elem.isLocked = false;
			data.elem = null;
		}

		//// RVA: 0x17A3734 Offset: 0x17A3734 VA: 0x17A3734
		private void ReleaseCacheRange(int beginIndex, int endIndex)
		{
			for(int i = beginIndex; i <= endIndex; i++)
			{
				if (m_elemDatas[i].elem != null)
					ReleaseCache(m_elemDatas[i]);
			}
		}

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
		private void GetVisibleAreaIndex(out int beginIndex, out int endIndex)
		{
			beginIndex = m_elemDatas.Count;
			endIndex = -1;
			for (int i = 0; i < m_elemDatas.Count; i++)
			{
				if (m_elemDatas[i].pos - m_elemDatas[i].height <= -m_scrollTrans.anchoredPosition.y)
				{
					beginIndex = i;
					break;
				}
			}
			for(int i = beginIndex; i < m_elemDatas.Count; i++)
			{
				if (m_elemDatas[i].pos < -m_scrollTrans.anchoredPosition.y - m_scrollAreaSize.y)
					return;
				endIndex = i;
			}
		}

		//// RVA: 0x17A4464 Offset: 0x17A4464 VA: 0x17A4464
		private void ShowElem(GachaRateElemBase elem, float posY)
		{
			elem.rectTrans.anchoredPosition = new Vector2(0, posY);
		}

		//// RVA: 0x17A38D8 Offset: 0x17A38D8 VA: 0x17A38D8
		private void HideElem(GachaRateElemBase elem)
		{
			elem.rectTrans.anchoredPosition = new Vector2(1184, elem.rectTrans.anchoredPosition.y);
		}

		//// RVA: 0x17A3994 Offset: 0x17A3994 VA: 0x17A3994
		private void ApplyForHeader(ElemData data)
		{
			GachaRateHeader elem = (GetFreeElem(m_headerElems));
			GachaRateHeaderInfo headerInfo = data.headerInfo;
			elem.SetHeaderTitle(headerInfo.headerTitle);
			Dictionary<int, string> d = new Dictionary<int, string>();
			if (!string.IsNullOrEmpty(headerInfo.s1Percent))
				d.Add(1, headerInfo.s1Percent);
			if (!string.IsNullOrEmpty(headerInfo.s2Percent))
				d.Add(2, headerInfo.s2Percent);
			if (!string.IsNullOrEmpty(headerInfo.s3Percent))
				d.Add(3, headerInfo.s3Percent);
			if (!string.IsNullOrEmpty(headerInfo.s4Percent))
				d.Add(4, headerInfo.s4Percent);
			if (!string.IsNullOrEmpty(headerInfo.s5Percent))
				d.Add(5, headerInfo.s5Percent);
			if (!string.IsNullOrEmpty(headerInfo.s6Percent))
				d.Add(6, headerInfo.s6Percent);
			int idx = 0;
			for (int i = 6; i > 0; i--)
			{
				string s = "";
				if (d.TryGetValue(i, out s))
				{
					elem.SetPercent(idx, i, s);
					idx++;
				}
			}
			elem.SetStyle(d.Count);
			elem.SetListTitle(headerInfo.listTitle);
			data.elem = elem;
		}

		//// RVA: 0x17A3E80 Offset: 0x17A3E80 VA: 0x17A3E80
		private void ApplyForRarity(ElemData data)
		{
			GachaRateRarity elem = GetFreeElem(m_rarityElems);
			elem.SetPercent(data.rarityInfo.percent);
			elem.SetStarNum(data.rarityInfo.starNum);
			data.elem = elem;
		}

		//// RVA: 0x17A3F84 Offset: 0x17A3F84 VA: 0x17A3F84
		private void ApplyForItem(ElemData data)
		{
			GachaRateItem elem = GetFreeElem(m_itemElems);
			elem.SetAttribute(data.itemInfo.attribute);
			elem.SetName(data.itemInfo.name);
			elem.SetPercent(data.itemInfo.percent);
			elem.SetEnablePickup(data.itemInfo.pickup);
			data.elem = elem;
		}

		//// RVA: 0x17A3D98 Offset: 0x17A3D98 VA: 0x17A3D98
		private void ApplyForMessage(ElemData data)
		{
			GachaRateMessage elem = GetFreeElem(m_messageElems);
			elem.SetMessage(data.messageInfo.message);
			data.elem = elem;
		}

		//// RVA: 0x17A40E0 Offset: 0x17A40E0 VA: 0x17A40E0
		private void ApplyForEpDetail(ElemData data)
		{
			GachaRateEpDetail elem = GetFreeElem(m_epDetailElems);
			GachaRateEpDetailInfo info = data.epDetailInfo;
			elem.SetEpisodeId(info.episodeId);
			elem.SetEpisodeContent(info.episodeContent);
			elem.onClickRewardButton = m_setting.OnClickRewardButton;
			data.elem = elem;
		}

		//// RVA: 0x17A4228 Offset: 0x17A4228 VA: 0x17A4228
		private void ApplyForEpItem(ElemData data)
		{
			GachaRateEpItem elem = GetFreeElem(m_epItemElems);
			GachaRateEpItemInfo info = data.epItemInfo;
			elem.SetAttribute(info.attribute);
			elem.SetName(info.name);
			elem.SetPercent(info.percent);
			elem.SetEnablePickup(info.pickup);
			elem.SetStarNum(info.starNum);
			data.elem = elem;
		}

		//// RVA: 0x17A43C0 Offset: 0x17A43C0 VA: 0x17A43C0
		private void ApplyForSeparator(ElemData data)
		{
			GachaRateSeparator elem = GetFreeElem(m_separatorElems);
			data.elem = elem;
		}

		//// RVA: -1 Offset: -1
		private static T GetFreeElem<T>(List<T> elems) where T : GachaRateElemBase
		{
			for(int i = 0; i < elems.Count; i++)
			{
				if (!elems[i].isLocked)
					return elems[i];
			}
			return null;
		}
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
			return m_setting.Mode != GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8;
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
		public IEnumerator Co_LoadResources()
		{
			//0x17A6534
			if(!m_isLoaded)
			{
				yield return Co.R(Co_LoadLayouts());
				m_isLoaded = true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7033A4 Offset: 0x7033A4 VA: 0x7033A4
		//// RVA: 0x17A4DD0 Offset: 0x17A4DD0 VA: 0x17A4DD0
		private IEnumerator Co_LoadLayouts()
		{
			Font font; // 0x14
			string bundleName; // 0x18
			int bundleLoadCount; // 0x1C

			//0x17A566C
			m_headerElems = new List<GachaRateHeader>(1);
			m_rarityElems = new List<GachaRateRarity>(4);
			m_itemElems = new List<GachaRateItem>(7);
			m_messageElems = new List<GachaRateMessage>(1);
			m_epDetailElems = new List<GachaRateEpDetail>(4);
			m_epItemElems = new List<GachaRateEpItem>(7);
			m_separatorElems = new List<GachaRateSeparator>(3);
			font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/068.xab";
			bundleLoadCount = 0;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateHeader", font, 1, "Header {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A5098
				m_headerElems.Add(instance.GetComponent<GachaRateHeader>());
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateRarity", font, 4, "Rarity {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A5144
				m_rarityElems.Add(instance.GetComponent<GachaRateRarity>());
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateItem", font, 7, "Item {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A51F0
				m_itemElems.Add(instance.GetComponent<GachaRateItem>());
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateMessage", font, 1, "Message {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A529C
				m_messageElems.Add(instance.GetComponent<GachaRateMessage>());
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateEpDetail", font, 4, "EpDetail {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A5348
				m_epDetailElems.Add(instance.GetComponent<GachaRateEpDetail>());
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateEpItem", font, 7, "EpItem {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A53F4
				m_epItemElems.Add(instance.GetComponent<GachaRateEpItem>());
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName, "UI_GachaRateSeparator", font, 3, "Separator {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x17A54A0
				m_separatorElems.Add(instance.GetComponent<GachaRateSeparator>());
			}));
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			yield return Co.R(Co_WaitForLoaded(m_headerElems));
			yield return Co.R(Co_WaitForLoaded(m_rarityElems));
			yield return Co.R(Co_WaitForLoaded(m_itemElems));
			yield return Co.R(Co_WaitForLoaded(m_messageElems));
			yield return Co.R(Co_WaitForLoaded(m_epDetailElems));
			yield return Co.R(Co_WaitForLoaded(m_epItemElems));
			yield return Co.R(Co_WaitForLoaded(m_separatorElems));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70341C Offset: 0x70341C VA: 0x70341C
		//// RVA: 0x17A4E7C Offset: 0x17A4E7C VA: 0x17A4E7C
		protected static IEnumerator Co_LoadListElem(string bundleName, string assetName, Font font, int elemCount, string elemNameFormat, Action<LayoutUGUIRuntime> onLoadedElem)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x17A6050
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x17A5554
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(elemNameFormat, 0);
				onLoadedElem(baseRuntime);
			}));
			for(int i = 1; i < elemCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(elemNameFormat, i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				onLoadedElem(r);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x703494 Offset: 0x703494 VA: 0x703494
		//// RVA: -1 Offset: -1
		private static IEnumerator Co_WaitForLoaded<T>(List<T> elems) where T : GachaRateElemBase
		{
			int i;
			T elem;

			//0x30A609C
			for(i = 0; i < elems.Count; i++)
			{
				elem = elems[i];
				while (!elem.IsLoaded())
					yield return null;
			}
		}
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
	}
}
