using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ShopListScene : TransitionRoot
	{
		private LayoutShopListWindow m_listShop; // 0x48
		private List<AODFBGCCBPE> m_list; // 0x4C
		private bool m_updateShopList; // 0x50

		// RVA: 0xC3D914 Offset: 0xC3D914 VA: 0xC3D914 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_InitializeLayout());
		}

		// RVA: 0xC3D968 Offset: 0xC3D968 VA: 0xC3D968 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			UpdateShopList();
		}

		// RVA: 0xC3DB2C Offset: 0xC3DB2C VA: 0xC3DB2C Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0xC3DB34 Offset: 0xC3DB34 VA: 0xC3DB34 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && m_updateShopList;
		}

		// RVA: 0xC3DBE0 Offset: 0xC3DBE0 VA: 0xC3DBE0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_listShop.Enter();
		}

		// RVA: 0xC3DC0C Offset: 0xC3DC0C VA: 0xC3DC0C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_listShop.IsPlaying();
		}

		// RVA: 0xC3DC3C Offset: 0xC3DC3C VA: 0xC3DC3C Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_listShop.Leave();
		}

		// RVA: 0xC3DC68 Offset: 0xC3DC68 VA: 0xC3DC68 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_listShop.IsPlaying();
		}

		// RVA: 0xC3DC98 Offset: 0xC3DC98 VA: 0xC3DC98 Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		//// RVA: 0xC3DC9C Offset: 0xC3DC9C VA: 0xC3DC9C
		private void OnShopProduct(AODFBGCCBPE view)
		{
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				view.NBJNKFPEFGC();
				ShopProductScene.ShopProductArgs args = new ShopProductScene.ShopProductArgs();
				args.view = view;
				MenuScene.Instance.Call(TransitionList.Type.SHOP_PRODUCT, args, true);
			}
		}

		//// RVA: 0xC3D944 Offset: 0xC3D944 VA: 0xC3D944
		//private void InitializeLayout() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72682C Offset: 0x72682C VA: 0x72682C
		//// RVA: 0xC3DDF0 Offset: 0xC3DDF0 VA: 0xC3DDF0
		private IEnumerator Co_InitializeLayout()
		{
			//0xC3E290
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//// RVA: 0xC3D988 Offset: 0xC3D988 VA: 0xC3D988
		private void UpdateShopList()
		{
			m_list = AODFBGCCBPE.FKDIMODKKJD(false);
			m_updateShopList = false;
			this.StartCoroutineWatched(AODFBGCCBPE.OMBGMOFMCLD_Coroutine_UpdateViewShopList(m_list, () =>
			{
				//0xC3DF50
				m_updateShopList = true;
			}, () =>
			{
				//0xC3DF5C
				m_updateShopList = true;
				MenuScene.Instance.GotoTitle();
			}));
			m_listShop.SetStatus(m_list, true);
			m_listShop.OnSelectEvent = OnShopProduct;
			m_listShop.Hide();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7268A4 Offset: 0x7268A4 VA: 0x7268A4
		//// RVA: 0xC3DE9C Offset: 0xC3DE9C VA: 0xC3DE9C
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			XeSys.FontInfo systemFont; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			int poolSize; // 0x24

			//0xC3E3B8
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/106.xab");
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString()));
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_window_01_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC3E00C
				instance.transform.SetParent(transform, false);
				m_listShop = instance.GetComponent<LayoutShopListWindow>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			poolSize = m_listShop.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_list_01_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC3E108
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
				m_listShop.List.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = baseRuntime.name.Replace("00", i.ToString("D2"));
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_listShop.List.AddScrollObject(r.GetComponent<SwapScrollListContent>());
			}
			m_listShop.List.Apply();
			m_listShop.List.SetContentEscapeMode(true);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			while (!m_listShop.IsLoaded())
				yield return null;
		}
	}
}
