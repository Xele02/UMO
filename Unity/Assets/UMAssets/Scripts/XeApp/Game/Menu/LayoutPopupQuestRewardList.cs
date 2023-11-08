using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using System;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutPopupQuestRewardList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private Text m_textHeader; // 0x18
		[SerializeField]
		private Text m_textCaution; // 0x1C
		[SerializeField]
		private Text m_textDesc; // 0x20
		private AbsoluteLayout m_layoutHeader; // 0x24
		private bool m_isReady; // 0x28
		private string[] s_layoutNameTbl = new string[3]
		{
			"root_sel_que_item_layout_root",
			"root_sel_que_item_layout_root",
			"root_sel_que_items_list2_layout_root"
		}; // 0x2C
		private int[,] s_scrollParam = new int[3, 6]
		{
			{ 5, 8, 110, 112, 35, 10},
			{ 5, 8, 110, 112, 35, 10},
			{ 4, 1, 1184, 112, 20, 10}
		}; // 0x30
		private PopupQuestRewardListSetting.Type m_type = PopupQuestRewardListSetting.Type.Undefined; // 0x34
		private List<MFDJIFIIPJD> m_itemList; // 0x38

		// RVA: 0x1778B04 Offset: 0x1778B04 VA: 0x1778B04
		public void SetStatus(PopupQuestRewardListSetting.Type type, List<MFDJIFIIPJD> itemList, bool isOver = false)
		{
			m_type = type;
			m_itemList = itemList;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(type == PopupQuestRewardListSetting.Type.Confirm)
			{
				m_layoutHeader.StartChildrenAnimGoStop("03");
				m_textHeader.text = bk.GetMessageByLabel("popup_quest_receive_limit_desc");
				m_textCaution.text = bk.GetMessageByLabel("popup_quest_receive_limit_caution");
				m_textDesc.text = "";
			}
			else if(type == PopupQuestRewardListSetting.Type.PresentBox)
			{
				m_layoutHeader.StartChildrenAnimGoStop("02");
				m_textCaution.text = isOver ? bk.GetMessageByLabel("popup_quest_receive_limit_failure_01") : "";
				m_textDesc.text = "";
			}
			else if(type == PopupQuestRewardListSetting.Type.Receive)
			{
				m_layoutHeader.StartChildrenAnimGoStop("01");
				m_textCaution.text = isOver ? bk.GetMessageByLabel("popup_quest_receive_limit_failure_01") : "";
				m_textDesc.text = bk.GetMessageByLabel("popup_quest_receive_vc_caution");
			}
			m_isReady = false;
			GameManager.Instance.StartCoroutineWatched(LoadContents(() =>
			{
				//0x177946C
				m_isReady = true;
			}));
		}

		// RVA: 0x1779008 Offset: 0x1779008 VA: 0x1779008
		public bool IsReady()
		{
			return m_isReady;
		}

		//// RVA: 0x1779010 Offset: 0x1779010 VA: 0x1779010
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutQuestRewardItem c = content as LayoutQuestRewardItem;
			if(c != null)
			{
				c.SetStatus(m_itemList[index]);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70FF64 Offset: 0x70FF64 VA: 0x70FF64
		//// RVA: 0x1778F60 Offset: 0x1778F60 VA: 0x1778F60
		private IEnumerator LoadContents(Action callback)
		{
			string assetBundleName; // 0x1C
			Font font; // 0x20
			int rowCount; // 0x24
			int colCount; // 0x28
			Vector2 contentSize; // 0x2C
			Vector2 leftTopPosition; // 0x34
			int poolSize; // 0x3C
			AssetBundleLoadLayoutOperationBase layoutOp; // 0x40
			int i; // 0x44

			//0x177955C
			assetBundleName = "ly/059.xab";
			font = GameManager.Instance.GetSystemFont();
			rowCount = s_scrollParam[(int)m_type, 0];
			colCount = s_scrollParam[(int)m_type, 1];
			contentSize = new Vector2(s_scrollParam[(int)m_type, 2], s_scrollParam[(int)m_type, 3]);
			leftTopPosition = new Vector2(s_scrollParam[(int)m_type, 4], s_scrollParam[(int)m_type, 5]);
			poolSize = rowCount * colCount;
			layoutOp = AssetBundleManager.LoadLayoutAsync(assetBundleName, s_layoutNameTbl[(int)m_type]);
			yield return layoutOp;
			LayoutUGUIRuntime baseRuntime = null;
			List<SwapScrollListContent> scrollObjects = new List<SwapScrollListContent>();
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1779480
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				scrollObjects.Add(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(assetBundleName, false);
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				scrollObjects.Add(r.GetComponent<SwapScrollListContent>());
			}
			for(i = 0; i < scrollObjects.Count; i++)
			{
				while (!scrollObjects[i].IsLoaded())
					yield return null;
				m_scrollList.AddScrollObject(scrollObjects[i]);
			}
			m_scrollList.Apply(rowCount, colCount, contentSize, leftTopPosition);
			m_scrollList.SetItemCount(m_itemList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			yield return null;
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			if (callback != null)
				callback();
		}

		// RVA: 0x177916C Offset: 0x177916C VA: 0x177916C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutHeader = layout.FindViewById("swtbl_sel_que_get_fnt") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
