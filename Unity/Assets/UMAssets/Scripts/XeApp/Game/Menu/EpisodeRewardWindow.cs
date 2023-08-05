using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class EpisodeRewardWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x14
		private List<LGMEPLIJLNB> m_list; // 0x18
		private List<EpisodeRewardItem> m_scrollItemList = new List<EpisodeRewardItem>(); // 0x1C
		private const int ICON_START_MARGIN = 20;
		private const int ScrollItemMax = 12;

		public bool IsInitialized { get; private set; } // 0x20

		// RVA: 0xF02F7C Offset: 0xF02F7C VA: 0xF02F7C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0xF02F94 Offset: 0xF02F94 VA: 0xF02F94
		public void ResetScrollPosition()
		{
			m_scrollRect.content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		//// RVA: 0xF03078 Offset: 0xF03078 VA: 0xF03078
		public void Enter(int episodeId)
		{
			m_list = LGMEPLIJLNB.FKDIMODKKJD_GetEpisodeRewards(episodeId);
			for(int i = 0; i < 12; i++)
			{
				if(i < m_list.Count)
				{
					m_scrollItemList[i].gameObject.SetActive(true);
					m_scrollItemList[i].SetItem(m_list[i], i == m_list.Count - 1);
				}
				else
				{
					m_scrollItemList[i].gameObject.SetActive(false);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB5CC Offset: 0x6DB5CC VA: 0x6DB5CC
		//// RVA: 0xF02E48 Offset: 0xF02E48 VA: 0xF02E48
		public IEnumerator CreateItemIcon()
		{
			AssetBundleLoadLayoutOperationBase layout; // 0x18
			int i; // 0x1C

			//0xF034B0
			LayoutUGUIRuntime runtime = null;
			IsInitialized = false;
			m_scrollItemList.Clear();
			layout = AssetBundleManager.LoadLayoutAsync("ly/052.xab", "EpisodeRewardItem");
			yield return layout;
			yield return Co.R(layout.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0xF033B8
				runtime = obj.GetComponent<LayoutUGUIRuntime>();
				m_scrollItemList.Add(runtime.GetComponent<EpisodeRewardItem>());
			}));
			AssetBundleManager.UnloadAssetBundle("ly/052.xab", false);
			for(i = 0; i < 11; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_scrollItemList.Add(r.GetComponent<EpisodeRewardItem>());
			}
			for(i = 0; i < m_scrollItemList.Count; i++)
			{
				while (!m_scrollItemList[i].IsLoaded())
					yield return null;
				m_scrollItemList[i].transform.SetParent(m_scrollRect.content.GetChild(0), false);
			}
			IsInitialized = true;
		}
	}
}
