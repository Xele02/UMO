using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class EventStoryList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x14
		private AbsoluteLayout m_rootLayout; // 0x18
		private AbsoluteLayout m_titleLayout; // 0x1C
		//[CompilerGeneratedAttribute] // RVA: 0x66D04C Offset: 0x66D04C VA: 0x66D04C
		public UnityAction<int, SwapScrollListContent> UpdateListListner; // 0x20
		//[CompilerGeneratedAttribute] // RVA: 0x66D05C Offset: 0x66D05C VA: 0x66D05C
		public UnityAction<EventStoryListContent.ButtonLabel, int, EventStoryListContent.ButtonFunc> PushButtonListner; // 0x24

		// RVA: 0xB8FF68 Offset: 0xB8FF68 VA: 0xB8FF68 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(m_swapScrollList != null)
			{
				m_swapScrollList.OnUpdateItem.AddListener(UpdateList);
			}
			m_rootLayout = layout.FindViewByExId("root_sel_event_data_sw_sel_list_window3") as AbsoluteLayout;
			m_titleLayout = layout.FindViewByExId("sw_sel_event_data_win_inout_anim_sw_sel_event_data_title_anim") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DBC64 Offset: 0x6DBC64 VA: 0x6DBC64
		//// RVA: 0xB90194 Offset: 0xB90194 VA: 0xB90194
		public IEnumerator Co_LoadListContent()
		{
			AssetBundleLoadLayoutOperationBase lytOp;

			//0xB90D34
			lytOp = AssetBundleManager.LoadLayoutAsync("ly/117.xab", "root_sel_event_data_content_layout_root");
			yield return lytOp;
			GameObject source = null;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instace) =>
			{
				//0xB90D28
				source = instace;
			}));
			LayoutUGUIRuntime runtime = source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_swapScrollList.ColumnCount * m_swapScrollList.RowCount; i++)
			{
				GameObject g = Instantiate(source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.LoadLayout();
				EventStoryListContent c = g.GetComponent<EventStoryListContent>();
				c.PushButtonListener += OnPushButton;
				m_swapScrollList.AddScrollObject(c);
			}
			yield return null;
			m_swapScrollList.Apply();
			Object.Destroy(source);
			source = null;
			AssetBundleManager.UnloadAssetBundle("ly/117.xab", false);
		}

		//// RVA: 0xB90240 Offset: 0xB90240 VA: 0xB90240
		public void InitializeList(CCAAJNJGNDO storyData, float yPosition)
		{
			for(int i = 0; i < m_swapScrollList.ScrollObjectCount; i++)
			{
				EventStoryListContent c = m_swapScrollList.ScrollObjects[i] as EventStoryListContent;
				c.CreateNewMark();
			}
			m_swapScrollList.SetItemCount(storyData.FFPCLEONGHE.Count);
			m_swapScrollList.SetPosition(0, 0, yPosition, false);
			m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0xB90600 Offset: 0xB90600 VA: 0xB90600
		public void ReleaseList()
		{
			for(int i = 0; i < m_swapScrollList.ScrollObjectCount; i++)
			{
				EventStoryListContent c = m_swapScrollList.ScrollObjects[i] as EventStoryListContent;
				c.DeleteNewMark();
			}
		}

		//// RVA: 0xB90770 Offset: 0xB90770 VA: 0xB90770
		public float GetListPosition()
		{
			if(m_swapScrollList != null)
			{
				return m_swapScrollList.ScrollContent.anchoredPosition.y;
			}
			return 0;
		}

		//// RVA: 0xB90864 Offset: 0xB90864 VA: 0xB90864
		public void ListUpdate()
		{
			if (m_swapScrollList != null)
				m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0xB90918 Offset: 0xB90918 VA: 0xB90918
		public void Hide()
		{
			m_rootLayout.StartChildrenAnimGoStop("st_wait");
			m_titleLayout.StartChildrenAnimGoStop("01", "01");
		}

		//// RVA: 0xB909C8 Offset: 0xB909C8 VA: 0xB909C8
		public void Enter()
		{
			m_rootLayout.StartChildrenAnimGoStop("st_wait", "st_in");
		}

		//// RVA: 0xB90A54 Offset: 0xB90A54 VA: 0xB90A54
		public void Leave()
		{
			m_rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xB90AE0 Offset: 0xB90AE0 VA: 0xB90AE0
		public bool IsPlaying()
		{
			return m_rootLayout.IsPlayingChildren();
		}

		//// RVA: 0xB90B0C Offset: 0xB90B0C VA: 0xB90B0C
		private void UpdateList(int index, SwapScrollListContent content)
		{
			if (UpdateListListner != null)
				UpdateListListner(index, content);
		}

		//// RVA: 0xB90B88 Offset: 0xB90B88 VA: 0xB90B88
		private void OnPushButton(EventStoryListContent.ButtonLabel label, int index, EventStoryListContent.ButtonFunc func)
		{
			if (PushButtonListner != null)
				PushButtonListner(label, index, func);
		}

		//// RVA: 0xB90C18 Offset: 0xB90C18 VA: 0xB90C18
		public void TitleEnter()
		{
			m_titleLayout.StartChildrenAnimGoStop("02", "02");
		}

		//// RVA: 0xB90C98 Offset: 0xB90C98 VA: 0xB90C98
		//public void TitleLeave() { }
	}
}
