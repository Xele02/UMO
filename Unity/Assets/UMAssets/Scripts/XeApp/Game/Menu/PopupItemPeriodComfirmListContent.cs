using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class PopupItemPeriodComfirmListContent : LayoutUGUIScriptBase, IPopupContent
	{
		public enum ScrollItemType
		{
			Header = 1,
			Item = 2,
		}

		[SerializeField]
		private ScrollRect m_scrollRect; // 0x14
		private PopupItemPeriodComfirmListSetting setup; // 0x1C
		private PopupWindowControl control; // 0x20
		private LayoutPopupOverlapSingle layoutSingle; // 0x24
		private FlexibleItemScrollView fxScrollView; // 0x28
		private List<IFlexibleListItem> m_list = new List<IFlexibleListItem>(); // 0x2C

		public Transform Parent { get; private set; } // 0x18

		// RVA: 0x17ACFEC Offset: 0x17ACFEC VA: 0x17ACFEC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}

		// RVA: 0x17AD004 Offset: 0x17AD004 VA: 0x17AD004 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupItemPeriodComfirmListSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			control.StartCoroutineWatched(LoadAssetBundlePrefab());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x703C1C Offset: 0x703C1C VA: 0x703C1C
		//// RVA: 0x17AD1E8 Offset: 0x17AD1E8 VA: 0x17AD1E8
		public IEnumerator LoadAssetBundlePrefab()
		{
			Font systemFont; // 0x18
			FlexibleItemScrollView scrollView; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x17AE068
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(setup.BundleName);
			scrollView = new FlexibleItemScrollView();
			scrollView.Initialize(m_scrollRect);
			GameObject header = null;
			GameObject item = null;
			operation = AssetBundleManager.LoadLayoutAsync(setup.BundleName, "root_pop_rerity_rimit_01_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x17ADE30
				header = instance;
			}));
			scrollView.AddLayoutCache(1, header.GetComponent<LayoutUGUIRuntime>(), 2);
			AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
			Destroy(header);
			operation = AssetBundleManager.LoadLayoutAsync(setup.BundleName, "root_pop_rerity_rimit_02_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x17ADE38
				item = instance;
			}));
			scrollView.AddLayoutCache(2, item.GetComponent<LayoutUGUIRuntime>(), 8);
			AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
			Destroy(item);
			yield return null;
			MakeScrollItem(setup.List);
			fxScrollView = scrollView;
			AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
			gameObject.SetActive(true);
		}

		//// RVA: 0x17AD294 Offset: 0x17AD294 VA: 0x17AD294
		private void MakeScrollItem(List<NKFJNAANPNP.MOJLCADLMKH> list)
		{
			m_list.Clear();
			ItemPeriodComfirmListHeader h = new ItemPeriodComfirmListHeader();
			h.Top = new Vector2(140, -9);
			h.Height = 34;
			h.ResourceType = 1;
			m_list.Add(h);
			int a = 43;
			for(int i = 0; i < list.Count; i++)
			{
				ItemPeriodComfirmListItem item = new ItemPeriodComfirmListItem();
				item.Top = new Vector2(140, -(a + 18));
				item.Height = 44;
				item.ResourceType = 2;
				item.Period = list[i].HNKFMAJIFJD_ExpireAt;
				item.Num = list[i].HMFFHLPNMPH_Remaining;
				m_list.Add(item);
				a += 18 + 26;
			}
		}

		// RVA: 0x17AD674 Offset: 0x17AD674 VA: 0x17AD674
		private void UpdateContent(IFlexibleListItem item)
		{
			if (item.Layout != null)
			{
				if (item is ItemPeriodComfirmListHeader)
				{
					PopupItemPeriodComfirmHeader p = item.Layout.GetComponent<PopupItemPeriodComfirmHeader>();
					if(p != null)
					{
						p.Setup(setup.TypeItemId);
					}
				}
				if (item is ItemPeriodComfirmListItem)
				{
					PopupItemPeriodComfirmElem p = item.Layout.GetComponent<PopupItemPeriodComfirmElem>();
					if (p != null)
					{
						ItemPeriodComfirmListItem it = item as ItemPeriodComfirmListItem;
						p.Setup(it.Period, setup.TypeItemId, it.Num);
					}
				}
			}
		}

		// RVA: 0x17ADA6C Offset: 0x17ADA6C VA: 0x17ADA6C Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17ADA74 Offset: 0x17ADA74 VA: 0x17ADA74
		public void Update()
		{
			return;
		}

		// RVA: 0x17ADA78 Offset: 0x17ADA78 VA: 0x17ADA78 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
			this.StartCoroutineWatched(Co_Show());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x703C94 Offset: 0x703C94 VA: 0x703C94
		// RVA: 0x17ADACC Offset: 0x17ADACC VA: 0x17ADACC
		private IEnumerator Co_Show()
		{
			//0x17ADE44
			yield return null;
			if(fxScrollView != null)
			{
				fxScrollView.UpdateItemListener += UpdateContent;
				fxScrollView.SetupListItem(m_list);
				fxScrollView.SetlistTop(0);
				fxScrollView.SetZeroVelocity();
				fxScrollView.VisibleRangeUpdate();
			}
		}

		// RVA: 0x17ADB78 Offset: 0x17ADB78 VA: 0x17ADB78 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
			fxScrollView.AllFree();
			fxScrollView.UpdateItemListener -= UpdateContent;
			fxScrollView.Release();
		}

		// RVA: 0x17ADC90 Offset: 0x17ADC90 VA: 0x17ADC90 Slot: 10
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && (layoutSingle != null || fxScrollView != null);
		}

		// RVA: 0x17ADD98 Offset: 0x17ADD98 VA: 0x17ADD98 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
