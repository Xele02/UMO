using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationStorageWindow : LayoutUGUIScriptBase
	{
		public const string AssetName = "root_deco_window_03_layout_root";
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x14
		[SerializeField]
		private Text m_titleText; // 0x18
		[SerializeField]
		private Text m_numberText; // 0x1C
		[SerializeField]
		private Text m_nothingText; // 0x20
		private AbsoluteLayout m_nothingTextTable; // 0x24
		private AbsoluteLayout m_windowBase; // 0x28
		public Action<int> DeleteButtonCallback; // 0x2C
		public Action<int> SelectButtonCallback; // 0x30
		public Action<int> SaveButtonCallback; // 0x34
		private bool IsEnter; // 0x38

		public bool IsLoadedList { get; private set; } // 0x39

		// RVA: 0x18BC2E0 Offset: 0x18BC2E0 VA: 0x18BC2E0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			IsEnter = false;
			m_windowBase = layout.FindViewById("sw_sel_deco_window_anim_03") as AbsoluteLayout;
			m_nothingTextTable = layout.FindViewById("swtbl_wintext_01") as AbsoluteLayout;
			IsLoadedList = false;
			this.StartCoroutineWatched(Co_LoadStorageList());
			return base.InitializeFromLayout(layout, uvMan);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D6CBC Offset: 0x6D6CBC VA: 0x6D6CBC
		//// RVA: 0x18BC460 Offset: 0x18BC460 VA: 0x18BC460
		private IEnumerator Co_LoadStorageList()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x18BCCB0
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, "root_deco_window_03_list_layout_root");
			yield return op;
			GameObject source = null;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x18BCCA4
				source = instance;
			}));
			LayoutUGUIRuntime runtime = source.GetComponent<LayoutUGUIRuntime>();
			int cnt = m_swapScrollList.ColumnCount * m_swapScrollList.RowCount;
			for(int i = 0; i < cnt; i++)
			{
				GameObject g = Instantiate(source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_swapScrollList.AddScrollObject(g.GetComponent<LayoutDecorationStorageList>());
			}
			yield return null;
			m_swapScrollList.Apply();
			Destroy(source);
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
			m_swapScrollList.SetItemCount(m_swapScrollList.RowCount);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
			Loaded();
			IsLoadedList = true;
		}

		// RVA: 0x18BC50C Offset: 0x18BC50C VA: 0x18BC50C
		public void Enter(int useStorageNum)
		{
			IsEnter = true;
			m_windowBase.StartChildrenAnimGoStop("go_in", "st_in");
			UseStorageNum(useStorageNum);
			m_titleText.text = MessageManager.Instance.GetMessage("menu", "deco_bast_storage_title");
			m_nothingText.text = "";
			m_nothingTextTable.StartChildrenAnimGoStop(1, 1);
		}

		//// RVA: 0x18BC694 Offset: 0x18BC694 VA: 0x18BC694
		public void UseStorageNum(int useStorageNum)
		{
			m_numberText.text = useStorageNum.ToString() + "/5";
		}

		// RVA: 0x18BC740 Offset: 0x18BC740 VA: 0x18BC740
		public void Leave()
		{
			if (!IsEnter)
				return;
			IsEnter = false;
			m_windowBase.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x18BC7E0 Offset: 0x18BC7E0 VA: 0x18BC7E0
		public bool IsPlayingEnd()
		{
			return !m_windowBase.IsPlayingChildren();
		}

		// RVA: 0x18BC810 Offset: 0x18BC810 VA: 0x18BC810
		public void Hide()
		{
			m_windowBase.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		//// RVA: 0x18BC890 Offset: 0x18BC890 VA: 0x18BC890
		//public void AddObject() { }

		//// RVA: 0x18BC894 Offset: 0x18BC894 VA: 0x18BC894
		public void UpdateButton(LayoutDecorationStorageList.StorageSetting setting)
		{
			(m_swapScrollList.ScrollObjects[setting.m_id] as LayoutDecorationStorageList).SettingStorage(setting);
		}

		// RVA: 0x18BC9F4 Offset: 0x18BC9F4 VA: 0x18BC9F4
		public void SettingList(int id, string name, bool isUse, Action<LayoutDecorationStorageList.StorageSetting> deleteCallback, Action<LayoutDecorationStorageList.StorageSetting> selectCallback, Action<LayoutDecorationStorageList.StorageSetting> saveCallback, Action<LayoutDecorationStorageList.StorageSetting> mapNameEditCallback)
		{
			(m_swapScrollList.ScrollObjects[id] as LayoutDecorationStorageList).Setting(new LayoutDecorationStorageList.StorageSetting() { m_id = id, m_isUse = isUse, m_name = name }, deleteCallback, selectCallback, saveCallback, mapNameEditCallback);
		}

		//// RVA: 0x18BCB74 Offset: 0x18BCB74 VA: 0x18BCB74
		//public bool IsUseList(int id) { }
	}
}
