using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using XeSys;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class RaidMvpLayout : LayoutUGUIScriptBase
	{
		public enum LayoutType
		{
			None = 0,
			OnlyMe = 1,
			OnlyOther = 2,
			Normal = 3,
		}

		[SerializeField]
		private Text m_notesText; // 0x14
		[SerializeField]
		private Text m_bossNameText; // 0x18
		[SerializeField]
		private Text m_descText; // 0x1C
		[SerializeField]
		private RawImageEx m_bossImage; // 0x20
		[SerializeField]
		private Text m_playerDamageText; // 0x24
		[SerializeField]
		private Text m_infoText01; // 0x28
		[SerializeField]
		private Text m_infoText02; // 0x2C
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x30
		private AbsoluteLayout m_mainLayout; // 0x34
		private AbsoluteLayout m_bossRankLayout; // 0x38
		private AbsoluteLayout m_rankingViewLayout; // 0x3C
		private bool m_isShow; // 0x40
		public UnityAction<int> PushProfileButtonListner; // 0x44

		// RVA: 0x1BD462C Offset: 0x1BD462C VA: 0x1BD462C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = true;
			m_mainLayout = layout.FindViewByExId("root_list_raid_mvp_sw_sel_list_window_mvp_anim") as AbsoluteLayout;
			m_bossRankLayout = layout.FindViewByExId("sw_sub_wintext_03_sw_raid_boss_rank") as AbsoluteLayout;
			m_rankingViewLayout = layout.FindViewByExId("sw_sel_list_window_mvp_window") as AbsoluteLayout;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_notesText.text = bk.GetMessageByLabel("raid_mvp_notes_text");
			m_descText.text = bk.GetMessageByLabel("raid_mvp_desc_text");
			return true;
		}

		// RVA: 0x1BD29BC Offset: 0x1BD29BC VA: 0x1BD29BC
		public void InitializeDecoration()
		{
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				if((m_scrollList.ScrollObjects[i] as RaidMvpScrollItem) != null)
					(m_scrollList.ScrollObjects[i] as RaidMvpScrollItem).InitializeDecoration();
			}
		}

		// RVA: 0x1BD39C4 Offset: 0x1BD39C4 VA: 0x1BD39C4
		public void SetBossName(string name)
		{
			m_bossNameText.text = name;
		}

		// RVA: 0x1BD3ABC Offset: 0x1BD3ABC VA: 0x1BD3ABC
		public void SetBossImage(int bossType)
		{
			GameManager.Instance.RaidBossTextureCache.LoadForBossIcon(bossType, (IiconTexture icon) =>
			{
				//0x1BD4BE8
				icon.Set(m_bossImage);
			});
		}

		// RVA: 0x1BD3A00 Offset: 0x1BD3A00 VA: 0x1BD3A00
		public void SetBossRank(int rank)
		{
			string str = string.Format("{0:D2}", rank);
			m_bossRankLayout.StartChildrenAnimGoStop(str, str);
		}

		// // RVA: 0x1BD49C0 Offset: 0x1BD49C0 VA: 0x1BD49C0
		// public void SetLayoutType(LayoutType type) { }

		// RVA: 0x1BD3C24 Offset: 0x1BD3C24 VA: 0x1BD3C24
		public void SetPlayerDamage(int damage)
		{
			m_playerDamageText.text = damage.ToString();
		}

		// // RVA: 0x1BD4A40 Offset: 0x1BD4A40 VA: 0x1BD4A40
		// public void Show() { }

		// RVA: 0x1BD2934 Offset: 0x1BD2934 VA: 0x1BD2934
		public void Hide()
		{
			m_isShow = false;
			m_mainLayout.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// RVA: 0x1BD2B74 Offset: 0x1BD2B74 VA: 0x1BD2B74
		public void Enter()
		{
			if(!m_isShow)
			{
				m_mainLayout.StartChildrenAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// RVA: 0x1BD2C98 Offset: 0x1BD2C98 VA: 0x1BD2C98
		public void Leave()
		{
			if(m_isShow)
			{
				m_mainLayout.StartChildrenAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// RVA: 0x1BD2C44 Offset: 0x1BD2C44 VA: 0x1BD2C44
		public bool IsPlaying()
		{
			return m_mainLayout.IsPlayingChildren();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x714564 Offset: 0x714564 VA: 0x714564
		// RVA: 0x1BD44E8 Offset: 0x1BD44E8 VA: 0x1BD44E8
		public IEnumerator LoadScrollObjectCoroutine()
		{
			string assetBundleName; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			RaidMvpScrollItem scrObject; // 0x20
			int i; // 0x24

			//0x1BD563C
			int poolSize = m_scrollList.ScrollObjectCount;
			assetBundleName = "ly/039.xab";
			operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_list_raid_01_layout_root");
			yield return operation;
			GameObject prefab = operation.GetAsset<GameObject>();
			yield return Co.R(operation.CreateLayoutCoroutine(prefab.GetComponent<LayoutUGUIRuntime>(), GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x1BD4CD0
				for(i = 0; i < poolSize; i++)
				{
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime l = g.GetComponent<LayoutUGUIRuntime>();
					l.IsLayoutAutoLoad = false;
					l.Layout = loadLayout.DeepClone();
					l.UvMan = loadUvMan;
					l.LoadLayout();
					Text[] txts = g.GetComponentsInChildren<Text>();
					for(int j = 0; j < txts.Length; j++)
					{
						GameManager.Instance.GetSystemFont().Apply(txts[j]);
					}
					m_scrollList.AddScrollObject(g.GetComponent<RaidMvpScrollItem>());
				}
			}));
			yield return null;
			m_scrollList.Apply();
			AssetBundleManager.UnloadAssetBundle(assetBundleName, false);
			for(i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				while(!m_scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
				(m_scrollList.ScrollObjects[i] as RaidMvpScrollItem).OnClickProfileButton += (int index) =>
				{
					//0x1BD5008
					OnClickProfile(index);
				};
			}
			scrObject = m_scrollList.ScrollObjects[0] as RaidMvpScrollItem;
			while(!scrObject.IsLoaded())
				yield return null;
			m_scrollList.SetContentEscapeMode(true);
		}

		// RVA: 0x1BD3D84 Offset: 0x1BD3D84 VA: 0x1BD3D84
		public void UpdateContent(List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.CALIFIMGGMD> rankingList)
		{
			if(rankingList.Count == 0)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_infoText01.text = bk.GetMessageByLabel("raid_mvp_info_text01");
			}
			else
			{
				m_infoText01.text = "";
			}
			m_scrollList.SetItemCount(rankingList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x1BD5038
				RaidMvpScrollItem c = content as RaidMvpScrollItem;
				float f = content.RectTransform.localPosition.y;
				if(index < 0)
				{
					content.RectTransform.localPosition = new Vector3(-320, f, 0);
				}
				else
				{
					content.RectTransform.localPosition = new Vector3((m_scrollList.ContentSize.x * index % m_scrollList.ColumnCount) + m_scrollList.LeftTopPosition.x, m_scrollList.ContentSize.y, 0);
				}
				c.UpdateContent(index, rankingList[index]);
			});
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x1BD4AF0 Offset: 0x1BD4AF0 VA: 0x1BD4AF0
		public void OnClickProfile(int index)
		{
			if(PushProfileButtonListner != null)
				PushProfileButtonListner(index);
		}

		// // RVA: 0x1BD4B64 Offset: 0x1BD4B64 VA: 0x1BD4B64
		// public void UpdateRegion() { }

		// RVA: 0x1BD2E30 Offset: 0x1BD2E30 VA: 0x1BD2E30
		public void Release()
		{
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				(m_scrollList.ScrollObjects[i] as RaidMvpScrollItem).Release();
			}
		}
	}
}
