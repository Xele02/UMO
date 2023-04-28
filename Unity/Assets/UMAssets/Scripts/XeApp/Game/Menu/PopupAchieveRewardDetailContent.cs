using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupAchieveRewardDetailContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupAchieveRewardScrollList m_layoutScrollList; // 0x10
		private bool m_isLoading; // 0x14
		private int m_itemCount; // 0x18
		private bool m_isSetup; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x132C1C0 Offset: 0x132C1C0 VA: 0x132C1C0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAchieveRewardDetailSetting s = setting as PopupAchieveRewardDetailSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			m_itemCount = s.clearList.Count + s.comboList.Count + s.scoreList.Count + s.allList.Count;
			if (m_itemCount > 4)
				m_itemCount = 6;
			if(s.Content != null)
			{
				m_layoutScrollList = s.Content.GetComponent<LayoutPopupAchieveRewardScrollList>();
				GameManager.Instance.StartCoroutineWatched(SetupLayout(s));
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x132C600 Offset: 0x132C600 VA: 0x132C600 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x132C608 Offset: 0x132C608 VA: 0x132C608
		public void Update()
		{
			if (m_layoutScrollList != null)
				m_layoutScrollList.UpdateScroll();
		}

		// RVA: 0x132C6BC Offset: 0x132C6BC VA: 0x132C6BC Slot: 19
		public void Show()
		{
			if (m_layoutScrollList != null)
				m_layoutScrollList.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x132C7A0 Offset: 0x132C7A0 VA: 0x132C7A0 Slot: 20
		public void Hide()
		{
			if (m_layoutScrollList != null)
				m_layoutScrollList.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x132C884 Offset: 0x132C884 VA: 0x132C884 Slot: 21
		public bool IsReady()
		{
			return !GameManager.Instance.ItemTextureCache.IsLoading() && m_isSetup;
		}

		// RVA: 0x132C960 Offset: 0x132C960 VA: 0x132C960 Slot: 22
		public void CallOpenEnd()
		{
			if (m_layoutScrollList != null)
				m_layoutScrollList.ResetScrollPosition();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70782C Offset: 0x70782C VA: 0x70782C
		//// RVA: 0x132CA14 Offset: 0x132CA14 VA: 0x132CA14
		private IEnumerator LoadLayoutItem()
		{
			List<LayoutPopupAchieveRewardItem> itemList; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0x132CBF8
			itemList = new List<LayoutPopupAchieveRewardItem>(6);
			operation = AssetBundleManager.LoadLayoutAsync("ly/043.xab", "root_pop_reward_item_list_inf_layout_root");
			yield return operation;
			LayoutUGUIRuntime sourceObject = null;
			yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x132CB78
				sourceObject = instance.GetComponent<LayoutUGUIRuntime>();
			});
			AssetBundleManager.UnloadAssetBundle("ly/043.xab", false);
			for(int i = 0; i < m_itemCount; i++)
			{
				LayoutUGUIRuntime o = Instantiate(sourceObject);
				o.IsLayoutAutoLoad = false;
				o.UvMan = sourceObject.UvMan;
				o.Layout = sourceObject.Layout.DeepClone();
				o.LoadLayout();
				itemList.Add(o.GetComponent<LayoutPopupAchieveRewardItem>());
			}
			yield return null;
			for(int i = 0; i < itemList.Count; i++)
			{
				while(!itemList[i].IsLoaded())
					yield return null;
			}
			Destroy(sourceObject.gameObject);
			sourceObject = null;
			m_layoutScrollList.AddView(itemList);
			m_isLoading = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7078A4 Offset: 0x7078A4 VA: 0x7078A4
		//// RVA: 0x132C558 Offset: 0x132C558 VA: 0x132C558
		private IEnumerator SetupLayout(PopupAchieveRewardDetailSetting setup)
		{
			//0x132D2E4
			m_isLoading = false;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutItem());
			while (!m_isLoading)
				yield return null;
			m_layoutScrollList.Setup(setup.clearList, setup.scoreList, setup.comboList);
			for(int i = 0; i < setup.clearList.Count; i++)
			{
				GameManager.Instance.ItemTextureCache.Load(setup.clearList[i].KIJAPOFAGPN_GlobalItemId, (IiconTexture texture) =>
				{
					//0x132CB64
					return;
				});
			}
			for (int i = 0; i < setup.scoreList.Count; i++)
			{
				GameManager.Instance.ItemTextureCache.Load(setup.scoreList[i].KIJAPOFAGPN_GlobalItemId, (IiconTexture texture) =>
				{
					//0x132CB68
					return;
				});
			}
			for (int i = 0; i < setup.comboList.Count; i++)
			{
				GameManager.Instance.ItemTextureCache.Load(setup.comboList[i].KIJAPOFAGPN_GlobalItemId, (IiconTexture texture) =>
				{
					//0x132CB6C
					return;
				});
			}
			yield return null;
			m_isSetup = true;
		}
	}
}
