using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBannerList : LayoutUGUIScriptBase
	{
		private SelectScrollView m_scrollList; // 0x14
		private LayoutGachaBannerFrame[] m_bannerFrame; // 0x18
		private RawImageEx m_imageTopArrow; // 0x1C
		private RawImageEx m_imageBtmArrow; // 0x20
		private List<LOBDIAABMKG> m_productList; // 0x24
		private LayoutGachaBannerItem m_selectLayout; // 0x28

		public Action<int> OnSelectGacha { private get; set; } // 0x2C
		public Action<bool> OnSwipeScroll { private get; set; } // 0x30

		// RVA: 0x1997CEC Offset: 0x1997CEC VA: 0x1997CEC
		private void OnDestroy()
		{
			if(m_scrollList != null)
			{
				Destroy(m_scrollList.gameObject);
				m_scrollList = null;
			}
			if(m_bannerFrame != null)
			{
				if(m_bannerFrame[0] != null)
				{
					Destroy(m_bannerFrame[0].gameObject);
					m_bannerFrame[0] = null;
				}
				if (m_bannerFrame[1] != null)
				{
					Destroy(m_bannerFrame[1].gameObject);
					m_bannerFrame[1] = null;
				}
				m_bannerFrame = null;
			}
		}

		// RVA: 0x199805C Offset: 0x199805C VA: 0x199805C
		public void Setup(BEPHBEGDFFK view, List<LOBDIAABMKG> productList, int selectIndex)
		{
			m_productList = productList;
			m_scrollList.SetItemCount(productList.Count);
			for(int i = 0; i < m_scrollList.scrollObjects.Count; i++)
			{
				if(i < m_productList.Count)
				{
					m_scrollList.scrollObjects[i].gameObject.SetActive(true);
					LayoutGachaBannerItem it = m_scrollList.scrollObjects[i].gameObject.GetComponent<LayoutGachaBannerItem>();
					it.Setup(m_productList[i], view.CEPJKBFGKEN, view.MFMBCIKGCFC(), view.JHNMKKNEENE_Time);
					it.OnClickButton = (LayoutGachaBannerItem select) =>
					{
						//0x1998B94
						m_scrollList.SetPosition(select, 0.1f);
					};
				}
				else
				{
					m_scrollList.scrollObjects[i].gameObject.SetActive(false);
				}
			}
			if(m_selectLayout == null)
			{
				LOBDIAABMKG p = m_productList[selectIndex];
				LayoutGachaBannerItem s = m_scrollList.scrollObjects.Find((SelectScrollViewContent x) =>
				{
					//0x1998FCC
					LayoutGachaBannerItem c = x as LayoutGachaBannerItem;
					return p.FDEBLMKEMLF_TypeAndSeriesId == (c.GachaProduct != null ? c.GachaProduct.FDEBLMKEMLF_TypeAndSeriesId : 0);
				}) as LayoutGachaBannerItem;
				if (s != null)
				{
					m_selectLayout = s;
					m_selectLayout.SetFocus(true);
					m_imageTopArrow.enabled = selectIndex > 0;
					m_imageBtmArrow.enabled = m_productList.Count - 1 > selectIndex;
				}
				else
					m_selectLayout = null;
			}
			if(m_scrollList.index != selectIndex)
			{
				m_scrollList.OnChangeItem = null;
				m_scrollList.SetPosition(selectIndex, 0);
			}
			m_scrollList.vertical = m_productList.Count > 1;
			m_scrollList.OnChangeItem = (int index) =>
			{
				//0x1998BD0
				int idx = Mathf.Clamp(index, 0, m_productList.Count - 1);
				m_imageTopArrow.enabled = index > 0;
				m_imageBtmArrow.enabled = index < m_productList.Count - 1;
				OnSelectListItem(m_scrollList.scrollObjects[index]);
			};
			m_scrollList.OnSwipe = (bool isSwipe) =>
			{
				//0x1998D7C
				if (OnSwipeScroll != null)
					OnSwipeScroll(isSwipe);
			};
		}

		//// RVA: 0x19987E4 Offset: 0x19987E4 VA: 0x19987E4
		private void OnSelectListItem(SelectScrollViewContent content)
		{
			if (!MenuScene.CheckDatelineAndAssetUpdate())
			{
				LayoutGachaBannerItem it = content as LayoutGachaBannerItem;
				if(it != null)
				{
					if(m_selectLayout != null)
					{
						m_selectLayout.SetFocus(false);
					}
					m_selectLayout = it;
					m_selectLayout.SetFocus(true);
					if (OnSelectGacha != null)
					{ 
						OnSelectGacha(m_productList.FindIndex((LOBDIAABMKG x) =>
						{
							//0x1998DF0
							return m_selectLayout.GachaProduct.FDEBLMKEMLF_TypeAndSeriesId == x.FDEBLMKEMLF_TypeAndSeriesId;
						}));
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DD7C4 Offset: 0x6DD7C4 VA: 0x6DD7C4
		//// RVA: 0x1998A20 Offset: 0x1998A20 VA: 0x1998A20
		private IEnumerator LoadContents(Action callback)
		{
			string assetBundleName; // 0x1C
			AssetBundleLoadAssetOperation op; // 0x20
			AssetBundleLoadLayoutOperationBase layoutOp; // 0x24
			int i; // 0x28

			//0x1999930
			assetBundleName = "ly/155.xab";
			Font font = GameManager.Instance.GetSystemFont();
			op = AssetBundleManager.LoadAssetAsync(assetBundleName, "SelectScrollView", typeof(GameObject));
			yield return op;
			GameObject g = Instantiate(op.GetAsset<GameObject>());
			m_scrollList = g.GetComponent<SelectScrollView>();
			m_scrollList.transform.SetParent(transform.parent);
			m_bannerFrame = new LayoutGachaBannerFrame[2];
			layoutOp = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_bannar_area_btm_grad_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x19990A4
				instance.transform.SetParent(transform.parent, false);
				m_bannerFrame[0] = instance.GetComponent<LayoutGachaBannerFrame>();
			}));
			layoutOp = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_bannar_frame_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1999220
				instance.transform.SetParent(transform.parent, false);
				m_bannerFrame[1] = instance.GetComponent<LayoutGachaBannerFrame>();
				RawImageEx[] imgs = instance.GetComponentsInChildren<RawImageEx>(true);
				List<RawImageEx> l = new List<RawImageEx>(imgs);
				m_imageTopArrow = l.Find((RawImageEx x) =>
				{
					//0x1998ECC
					return x.name == "cmn_arr_r_02_b (ImageView)";
				});
				m_imageBtmArrow = l.Find((RawImageEx x) =>
				{
					//0x1998F4C
					return x.name == "cmn_arr_r_02_t (ImageView)";
				});
			}));
			layoutOp = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_bannar_layout_root");
			yield return layoutOp;
			GameObject prefab = layoutOp.GetAsset<GameObject>();
			int poolSize = 15;
			yield return Co.R(layoutOp.CreateLayoutCoroutine(prefab.GetComponent<LayoutUGUIRuntime>(), font, (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x1999648
				for(int j = 0; j < poolSize; j++)
				{
					GameObject g1 = Instantiate(prefab);
					LayoutUGUIRuntime r = g1.GetComponent<LayoutUGUIRuntime>();
					r.IsLayoutAutoLoad = false;
					r.Layout = loadLayout.DeepClone();
					r.UvMan = loadUvMan;
					r.LoadLayout();
					Text[] txts = g1.GetComponentsInChildren<Text>(true);
					for(int k = 0; k < txts.Length; k++)
					{
						txts[k].font = font;
					}
					m_scrollList.AddScrollObject(g1.GetComponent<LayoutGachaBannerItem>());
				}
			}));
			for(i = 0; i < m_scrollList.scrollObjects.Count; i++)
			{
				LayoutGachaBannerItem it = m_scrollList.scrollObjects[i].GetComponent<LayoutGachaBannerItem>();
				while (!it.IsLoaded())
					yield return null;
			}
			if (callback != null)
				callback();
		}

		// RVA: 0x1998AE8 Offset: 0x1998AE8 VA: 0x1998AE8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(LoadContents(Loaded));
			return true;
		}
	}
}
