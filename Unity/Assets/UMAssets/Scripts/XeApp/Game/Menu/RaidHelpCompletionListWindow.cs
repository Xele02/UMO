using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	internal class RaidHelpCompletionListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text01; // 0x14
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x18
		private bool m_IsInialize; // 0x1C

		public SwapScrollList Scroll { get { return m_scrollList; } } //0x1BCFDF8

		// RVA: 0x1BCFE00 Offset: 0x1BCFE00 VA: 0x1BCFE00 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// RVA: 0x1BCFE18 Offset: 0x1BCFE18 VA: 0x1BCFE18
		public void Initialize(List<PKNOKJNLPOE_EventRaid.ECICDAPCMJG> helperList)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_text01.text = bk.GetMessageByLabel("pop_raid_helprequest_completion_text");
			UpdateContent(helperList);
			m_IsInialize = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x714D64 Offset: 0x714D64 VA: 0x714D64
		// // RVA: 0x1BD0174 Offset: 0x1BD0174 VA: 0x1BD0174
		public IEnumerator LoadScrollObjectCoroutine()
		{
			string assetBundleName; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			RaidHelpCompletionScrollItem scrObject; // 0x20
			int i; // 0x24

			//0x1BD0904
			int poolSize = m_scrollList.ScrollObjectCount;
			assetBundleName = "ly/200.xab";
			operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_sel_music_raid_list_01_layout_root");
			yield return operation;
			GameObject prefab = operation.GetAsset<GameObject>();
			LayoutUGUIRuntime loadLayout_ = prefab.GetComponent<LayoutUGUIRuntime>();
			yield return Co.R(operation.CreateLayoutCoroutine(loadLayout_, GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x1BD0238
				for(i = 0; i < poolSize; i++)
				{
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime l2 = g.GetComponent<LayoutUGUIRuntime>();
					l2.IsLayoutAutoLoad = false;
					l2.Layout = loadLayout.DeepClone();
					l2.UvMan = loadUvMan;
					l2.LoadLayout();
					Text[] txts = g.GetComponentsInChildren<Text>(true);
					for(int j = 0; j < txts.Length; j++)
					{
						GameManager.Instance.GetSystemFont().Apply(txts[j], true);
					}
					m_scrollList.AddScrollObject(g.GetComponent<RaidHelpCompletionScrollItem>());
				}
			}));
			yield return null;
			m_scrollList.Apply();
			AssetBundleManager.UnloadAssetBundle(assetBundleName);
			for(i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				while(!m_scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
			}
			scrObject = m_scrollList.ScrollObjects[0] as RaidHelpCompletionScrollItem;
			while(!scrObject.IsLoaded())
				yield return null;
			m_scrollList.SetContentEscapeMode(true);
		}

		// // RVA: 0x1BCFF20 Offset: 0x1BCFF20 VA: 0x1BCFF20
		public void UpdateContent(List<PKNOKJNLPOE_EventRaid.ECICDAPCMJG> helperList)
		{
			m_scrollList.SetItemCount(helperList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x1BD0570
				RaidHelpCompletionScrollItem c = content as RaidHelpCompletionScrollItem;
				Vector3 pos = content.RectTransform.localPosition;
				float y = pos.y;
				if(index < 0)
				{
					content.RectTransform.localPosition = new Vector3(-320, y, 0);
				}
				else
				{
					int _y = index / m_scrollList.ColumnCount;
					int _x = index % m_scrollList.ColumnCount;
					content.RectTransform.localPosition = new Vector3(m_scrollList.ContentSize.x * _x + m_scrollList.LeftTopPosition.x,
						m_scrollList.ContentSize.y, 0);
					c.UpdateContent(helperList[index]);
				}
			});
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}
	}
}
