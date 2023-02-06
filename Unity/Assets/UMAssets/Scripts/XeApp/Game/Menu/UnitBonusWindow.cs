using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	internal class UnitBonusWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_descText; // 0x14
		[SerializeField]
		private Text m_bonusPointText; // 0x18
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x1C
		private UnitBonusContent m_contentLayout; // 0x20
		//private PKNOKJNLPOE_EventRaid.MOAICCAOMCP m_unitBonusInfo; // 0x24
		private PopupUnitBonusContent m_content; // 0x28

		// RVA: 0xA4C3BC Offset: 0xA4C3BC VA: 0xA4C3BC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}

		//// RVA: 0xA4C3D4 Offset: 0xA4C3D4 VA: 0xA4C3D4
		//public void Initialize(PopupUnitBonusContent content) { }

		//[IteratorStateMachineAttribute] // RVA: 0x72FDFC Offset: 0x72FDFC VA: 0x72FDFC
		//// RVA: 0xA4C7E0 Offset: 0xA4C7E0 VA: 0xA4C7E0
		public IEnumerator LoadContents()
		{
			string assetBundleName; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0xA4CE28
			assetBundleName = "ly/208.xab";
			operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_pop_ep_raid_contents_layout_root");
			yield return Co.R(operation);

			GameObject prefab = operation.GetAsset<GameObject>();
			LayoutUGUIRuntime runtime = prefab.GetComponent<LayoutUGUIRuntime>();

			yield return Co.R(operation.CreateLayoutCoroutine(runtime, GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0xA4CA40
				GameObject go = Instantiate(prefab);
				LayoutUGUIRuntime run = go.GetComponent<LayoutUGUIRuntime>();
				run.IsLayoutAutoLoad = false;
				run.Layout = loadLayout.DeepClone();
				run.UvMan = loadUvMan;
				run.LoadLayout();
				Text[] ts = go.GetComponentsInChildren<Text>(true);
				for(int i = 0; i < ts.Length; i++)
				{
					ts[i].font = GameManager.Instance.GetSystemFont();
				}
				m_contentLayout = go.GetComponent<UnitBonusContent>();
				m_scrollSupport.BeginAddView();
				m_scrollSupport.AddView(m_contentLayout.gameObject, 0, 0);
				m_scrollSupport.EndAddView();
				m_scrollSupport.ContentSize = new Vector2(m_scrollSupport.RangeSize.x, 572);
			}));
			AssetBundleManager.UnloadAssetBundle(assetBundleName);
			while (!m_contentLayout.IsLoaded())
				yield return null;
		}

	//// RVA: 0xA4C88C Offset: 0xA4C88C VA: 0xA4C88C
	//public bool IsLoadImage() { }

	//[CompilerGeneratedAttribute] // RVA: 0x72FE74 Offset: 0x72FE74 VA: 0x72FE74
	//// RVA: 0xA4C8C8 Offset: 0xA4C8C8 VA: 0xA4C8C8
	//private void <Initialize>b__7_0() { }

	//[CompilerGeneratedAttribute] // RVA: 0x72FE84 Offset: 0x72FE84 VA: 0x72FE84
	//// RVA: 0xA4C980 Offset: 0xA4C980 VA: 0xA4C980
	//private void <Initialize>b__7_1() { }
}
}
