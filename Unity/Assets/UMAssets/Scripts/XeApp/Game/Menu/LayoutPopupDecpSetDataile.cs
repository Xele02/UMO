using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using XeSys;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDecpSetDataile : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textDescription; // 0x14
		[SerializeField]
		private Text m_textCaution; // 0x18
		private AbsoluteLayout m_layoutCaution; // 0x1C
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x20
		private List<DecoSetListContent> m_elems = new List<DecoSetListContent>(); // 0x24
		private List<string> m_decoSetItemList = new List<string>(); // 0x28
		private bool m_scrollInitialized; // 0x2C

		// // RVA: 0x171CF18 Offset: 0x171CF18 VA: 0x171CF18
		// public bool IsLoading() { }

		// // RVA: 0x171CF50 Offset: 0x171CF50 VA: 0x171CF50
		// public void SetList(int decoSetItemId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70F02C Offset: 0x70F02C VA: 0x70F02C
		// RVA: 0x171D548 Offset: 0x171D548 VA: 0x171D548
		public IEnumerator Co_LoadScrollItemContent()
		{
			AssetBundleLoadLayoutOperationBase layout;

			//0x171D958
			m_elems.Clear();
			GameObject source = null;
			layout = AssetBundleManager.LoadLayoutAsync("ly/106.xab", "root_pop_c_txt_layout_root");
			yield return layout;
			yield return Co.R(layout.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0x1788480
				source = obj;
			}));
			AssetBundleManager.UnloadAssetBundle("ly/106.xab", false);
			LayoutUGUIRuntime runtime = source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_swapScrollList.ScrollObjectCount; i++)
			{
				GameObject g = Instantiate(source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				DecoSetListContent s = g.GetComponent<DecoSetListContent>();
				m_elems.Add(s);
				m_swapScrollList.AddScrollObject(s);
			}
			yield return null;
			m_swapScrollList.Apply();
			m_swapScrollList.SetContentEscapeMode(false);
			m_swapScrollList.SetItemCount(m_decoSetItemList.Count);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
			Destroy(source);
			if(m_swapScrollList != null)
			{
				m_swapScrollList.OnUpdateItem.RemoveAllListeners();
				m_swapScrollList.OnUpdateItem.AddListener(Co_UpdateList);
			}
			m_scrollInitialized = true;
		}

		// // RVA: 0x171D5F4 Offset: 0x171D5F4 VA: 0x171D5F4
		private void Co_UpdateList(int index, SwapScrollListContent content)
		{
			DecoSetListContent c = content as DecoSetListContent;
			if(c != null)
			{
				c.SetText(m_decoSetItemList[index]);
			}
		}

		// RVA: 0x171D728 Offset: 0x171D728 VA: 0x171D728 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textDescription.text = bk.GetMessageByLabel("popup_deco_set_item_detaile_list");
			m_textCaution.text = bk.GetMessageByLabel("popup_deco_set_item_detaile_caution");
			Loaded();
			return true;
		}
	}
}
