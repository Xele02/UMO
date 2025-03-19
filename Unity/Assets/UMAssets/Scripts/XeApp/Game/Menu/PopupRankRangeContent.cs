using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using mcrs;
using System.Collections;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRankRangeContent : UIBehaviour, IPopupContent
	{
		[SerializeField]
		private PopupRankRangeRuntime m_popupUi; // 0xC
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x10
		private RankRangePopupSetting m_setting; // 0x14
		private bool m_isInitialized; // 0x1C
		private List<PopupRankRangeElem> m_elems = new List<PopupRankRangeElem>(); // 0x24

		public Transform Parent { get; private set; } // 0x18
		public int currentIndex { get; private set; } // 0x20

		// RVA: 0x1618450 Offset: 0x1618450 VA: 0x1618450
		private void Reset()
		{
			m_popupUi = GetComponent<PopupRankRangeRuntime>();
			m_scrollList = GetComponentInChildren<SwapScrollList>(true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70A56C Offset: 0x70A56C VA: 0x70A56C
		//// RVA: 0x16184D8 Offset: 0x16184D8 VA: 0x16184D8
		public IEnumerator Co_LoadElements(string bundleName)
		{
			XeSys.FontInfo systemFont; // 0x1C
			int poolSize; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int i; // 0x28

			//0x16194A4
			systemFont = GameManager.Instance.GetSystemFont();
			poolSize = m_scrollList.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "PopupRankRangeElem");
			LayoutUGUIRuntime baseRuntime = null;
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x16192E4
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format("RankRangeElem {0:D2}", 0);
				m_scrollList.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
				m_elems.Add(baseRuntime.GetComponent<PopupRankRangeElem>());
			}));
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format("RankRangeElem {0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
				m_elems.Add(r.GetComponent<PopupRankRangeElem>());
			}
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_scrollList.Apply();
			for(i = 0; i < m_elems.Count; i++)
			{
				while (!m_elems[i].IsLoaded())
					yield return null;
			}
		}

		//// RVA: 0x16185A0 Offset: 0x16185A0 VA: 0x16185A0
		private void OnUpdateListItem(int index, PopupRankRangeElem elem)
		{
			elem.elemIndex = index;
			elem.SetLabel(m_setting.itemLabels[index]);
			if(currentIndex == index)
			{
				elem.SetButtonLock(true);
				elem.SetButtonOn();
			}
			else
			{
				elem.SetButtonLock(false);
				elem.SetButtonOff();
			}
		}

		//// RVA: 0x16187D8 Offset: 0x16187D8 VA: 0x16187D8
		private void OnSelectListItem(int value, PopupRankRangeElem elem)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			currentIndex = elem.elemIndex;
			for(int i = 0; i < m_elems.Count; i++)
			{
				if(elem == m_elems[i])
				{
					m_elems[i].SetButtonLock(true);
					m_elems[i].SetButtonOn();
				}
				else
				{
					m_elems[i].SetButtonLock(false);
					m_elems[i].SetButtonOff();
				}
			}
			if(m_setting.onDecideIndex != null)
			{
				m_setting.onDecideIndex(currentIndex);
			}
		}

		// RVA: 0x1618B24 Offset: 0x1618B24 VA: 0x1618B24 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as RankRangePopupSetting;
			Parent = setting.m_parent;
			currentIndex = m_setting.initialLabelIndex;
			m_scrollList.SetItemCount(m_setting.itemLabels.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x16190DC
				OnUpdateListItem(index, content as PopupRankRangeElem);
			});
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener((int value, SwapScrollListContent content) =>
				{
					//0x16191E0
					OnSelectListItem(value, content as PopupRankRangeElem);
				});
			}
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			m_isInitialized = true;
		}

		// RVA: 0x1618FA4 Offset: 0x1618FA4 VA: 0x1618FA4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1618FAC Offset: 0x1618FAC VA: 0x1618FAC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1618FE4 Offset: 0x1618FE4 VA: 0x1618FE4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x161901C Offset: 0x161901C VA: 0x161901C Slot: 21
		public bool IsReady()
		{
			return m_isInitialized;
		}

		// RVA: 0x1619024 Offset: 0x1619024 VA: 0x1619024 Slot: 22
		public void CallOpenEnd()
		{
			m_scrollList.VisibleRegionUpdate();
		}
	}
}
