using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class HelpSelectWindow : LayoutUGUIScriptBase
	{
		private Action m_updater; // 0x14
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x18
		[SerializeField]
		private Transform m_content; // 0x1C
		private const int BTN_MAX = 6;
		private List<PopupHelpBtn> m_btn_list = new List<PopupHelpBtn>(); // 0x20
		private int m_uniqueId; // 0x24
		private bool m_is_wiki = true; // 0x28
		//[CompilerGeneratedAttribute] // RVA: 0x66FD80 Offset: 0x66FD80 VA: 0x66FD80
		public Action<VeiwOptionHelpCategoryData, int, bool> PushButtonHandler; // 0x2C
		private VeiwOptionHelpCategoryData m_help_data = new VeiwOptionHelpCategoryData(); // 0x30

		// RVA: 0x955CF8 Offset: 0x955CF8 VA: 0x955CF8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}

		// RVA: 0x955D10 Offset: 0x955D10 VA: 0x955D10
		private void Start()
		{
			return;
		}

		// RVA: 0x955D14 Offset: 0x955D14 VA: 0x955D14
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x955D28 Offset: 0x955D28 VA: 0x955D28
		//private void UpdateScroll() { }

		//// RVA: 0x955D2C Offset: 0x955D2C VA: 0x955D2C
		private void UpdateBtn(int index, PopupHelpBtn content)
		{
			content.GetBtn().ClearOnClickCallback();
			List<VeiwOptionHelpContentData> list = m_is_wiki ? m_help_data.wikis : m_help_data.helps;
			content.SetName(list[index].contentName);
			content.GetBtn().AddOnClickCallback(() =>
			{
				//0x9565C4
				OnPushButton(m_help_data, index, m_is_wiki);
			});
		}

		//// RVA: 0x955F48 Offset: 0x955F48 VA: 0x955F48
		public void Init(int uniqueId, bool is_wiki)
		{
			m_is_wiki = is_wiki;
			m_uniqueId = uniqueId;
			m_help_data.Init(uniqueId);
			List<VeiwOptionHelpContentData> list = m_is_wiki ? m_help_data.wikis : m_help_data.helps;
			for(int i = 0; i < m_btn_list.Count; i++)
			{
				m_btn_list[i].SetIcon(m_is_wiki ? PopupHelpBtn.ICON_TYPE.WIKI : PopupHelpBtn.ICON_TYPE.HELP);
			}
			m_scrollList.SetItemCount(list.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x9564C0
				UpdateBtn(index, content as PopupHelpBtn);
			});
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x956230 Offset: 0x956230 VA: 0x956230
		public void TabChange()
		{
			m_scrollList.GetComponent<ScrollRect>().enabled = true;
		}

		//// RVA: 0x95580C Offset: 0x95580C VA: 0x95580C
		public void BtnLoad(MonoBehaviour mb)
		{
			if (IsBtnLoad())
				return;
			for(int i = 0; i < 6; i++)
			{
				mb.StartCoroutineWatched(LoadListItemPrefabCoroutine(i));
			}
		}

		//// RVA: 0x955864 Offset: 0x955864 VA: 0x955864
		public bool IsBtnLoad()
		{
			return m_btn_list.Count == 6;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E1F6C Offset: 0x6E1F6C VA: 0x6E1F6C
		//// RVA: 0x9562CC Offset: 0x9562CC VA: 0x9562CC
		private IEnumerator LoadListItemPrefabCoroutine(int index)
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x9567F0
			LayoutUGUIRuntime runtime = null;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/091.xab", "PopupHelpBtn");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x956628
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
				instance.transform.SetParent(m_content, false);
				m_btn_list.Add(instance.GetComponent<PopupHelpBtn>());
				m_scrollList.AddScrollObject(instance.GetComponent<PopupHelpBtn>());
			}));
			AssetBundleManager.UnloadAssetBundle("ly/091.xab", false);
		}

		//// RVA: 0x956378 Offset: 0x956378 VA: 0x956378
		private void OnPushButton(VeiwOptionHelpCategoryData data, int index, bool isWiki)
		{
			if(PushButtonHandler != null)
			{
				PushButtonHandler(data, index, isWiki);
			}
		}
	}
}
