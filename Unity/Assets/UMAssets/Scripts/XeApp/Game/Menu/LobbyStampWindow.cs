using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LobbyStampWindow : LayoutUGUIScriptBase
	{
		public class StampInfo
		{
			public int stampId; // 0x8
			public int serifId; // 0xC
		}

		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x18
		[SerializeField]
		private ActionButton m_stampEditButton; // 0x1C
		[SerializeField]
		private Button m_btnHide; // 0x20
		[SerializeField]
		private Text m_haveNotStampText; // 0x24
		private AbsoluteLayout m_stampWindowAnim; // 0x28
		private List<LobbyStampItem> m_elems = new List<LobbyStampItem>(); // 0x2C
		private List<StampInfo> m_stampInfoList = new List<StampInfo>(); // 0x30
		private bool isSendStampSucess; // 0x34
		private bool isRaidLobby; // 0x35
		private Transform prevParent; // 0x38
		private Transform nextParent; // 0x3C
		public bool IsShow; // 0x40

		public Action onHideClickButton { private get; set; } // 0x14
		public Action OnClickStampEditButton { get; set; } // 0x44
		public Action<int, int> OnClickStamp { get; set; } // 0x48

		//// RVA: 0xD21770 Offset: 0xD21770 VA: 0xD21770
		private void CreateStampDataList()
		{
			m_stampInfoList.Clear();
			IHGHHPPDPEO data = new IHGHHPPDPEO();
			List<IOEKHJBOMDH_DecoStamp.PAFLFMFEOJD> l = data.GMCKCMFKPOB();
			for (int i = 0; i < l.Count; i++)
			{
				if(l[i].IEDNAKOJNDE_IsValid)
				{
					StampInfo stamp = new StampInfo();
					stamp.stampId = l[i].CNOHJPEHHCH_StampId;
					stamp.serifId = l[i].JBOCHIJAMFD_SerifId;
					m_stampInfoList.Add(stamp);
				}
			}
		}

		//// RVA: 0xD0C2F8 Offset: 0xD0C2F8 VA: 0xD0C2F8
		public void StampEditHidden(bool isHidden)
		{
			m_stampEditButton.Hidden = isHidden;
		}

		// RVA: 0xD21A18 Offset: 0xD21A18 VA: 0xD21A18 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_stampWindowAnim = layout.FindViewById("sw_lb_window_stmp_anim") as AbsoluteLayout;
			m_stampEditButton.AddOnClickCallback(() =>
			{
				//0xD22294
				if (m_stampEditButton != null)
					OnClickStampEditButton();
			});
			m_btnHide.onClick.RemoveAllListeners();
			m_btnHide.onClick.AddListener(() =>
			{
				//0xD22348
				if (onHideClickButton != null)
					onHideClickButton();
			});
			m_btnHide.targetGraphic.raycastTarget = false;
			m_haveNotStampText.raycastTarget = false;
			Loaded();
			return true;
		}

		// RVA: 0xD130B0 Offset: 0xD130B0 VA: 0xD130B0
		public void HaveStampListUpdate()
		{
			m_btnHide.targetGraphic.raycastTarget = false;
			isSendStampSucess = true;
			CreateStampDataList();
			m_swapScrollList.SetItemCount(m_stampInfoList.Count);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
			SetNotHaveStampText(m_stampInfoList.Count);
		}

		//// RVA: 0xD21DAC Offset: 0xD21DAC VA: 0xD21DAC
		public void SetParent(Transform prevTrs, Transform nextTrs)
		{
			isRaidLobby = true;
			prevParent = prevTrs;
			nextParent = nextTrs;
		}

		//// RVA: 0xD21DC0 Offset: 0xD21DC0 VA: 0xD21DC0
		public void Show()
		{
			if (isRaidLobby)
				transform.SetParent(nextParent, false);
			MenuScene.Instance.HelpButton.SetDisable();
			m_btnHide.targetGraphic.raycastTarget = true;
			m_stampWindowAnim.StartChildrenAnimGoStop("go_in", "st_in");
			IsShow = true;
		}

		// RVA: 0xD09770 Offset: 0xD09770 VA: 0xD09770
		public void Leave()
		{
			if(isRaidLobby)
			{
				transform.SetParent(prevParent, false);
			}
			MenuScene.Instance.HelpButton.SetEnable();
			m_btnHide.targetGraphic.raycastTarget = false;
			m_stampWindowAnim.StartChildrenAnimGoStop("go_out", "st_out");
			IsShow = false;
		}

		//// RVA: 0xD0999C Offset: 0xD0999C VA: 0xD0999C
		public void Hide()
		{
			if(isRaidLobby)
			{
				transform.SetParent(prevParent, false);
			}
			MenuScene.Instance.HelpButton.SetEnable();
			m_btnHide.targetGraphic.raycastTarget = false;
			m_stampWindowAnim.StartChildrenAnimGoStop("st_wait");
			IsShow = false;
		}

		// RVA: 0xD21F58 Offset: 0xD21F58 VA: 0xD21F58
		public bool IsPlayingChild()
		{
			return m_stampWindowAnim.IsPlayingChildren();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EA454 Offset: 0x6EA454 VA: 0x6EA454
		//// RVA: 0xD0E584 Offset: 0xD0E584 VA: 0xD0E584
		public IEnumerator Co_LoadStampItemContent()
		{
			AssetBundleLoadLayoutOperationBase layout;

			//0xD2265C
			m_elems.Clear();
			GameObject source = null;
			layout = AssetBundleManager.LoadLayoutAsync("ly/203.xab", "root_sel_lobby_stmp_01_layout_root");
			yield return layout;
			yield return Co.R(layout.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0xD22364
				source = obj;
			}));
			AssetBundleManager.UnloadAssetBundle("ly/203.xab", false);
			LayoutUGUIRuntime runtime = source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_swapScrollList.ScrollObjectCount; i++)
			{
				GameObject g = Instantiate(source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_elems.Add(g.GetComponent<LobbyStampItem>());
				m_swapScrollList.AddScrollObject(g.GetComponent<LobbyStampItem>());
			}
			for(int i = 0; i < m_elems.Count; i++)
			{
				int index = i;
				m_elems[i].OnStampClickButton = () =>
				{
					//0xD22374
					OnClickStamp(m_stampInfoList[index].stampId, m_stampInfoList[index].serifId);
				};
			}
			yield return null;
			m_swapScrollList.Apply();
			m_swapScrollList.SetContentEscapeMode(false);
			m_swapScrollList.SetItemCount(m_stampInfoList.Count);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
			Destroy(source);
			if(m_swapScrollList != null)
			{
				m_swapScrollList.OnUpdateItem.RemoveAllListeners();
				m_swapScrollList.OnUpdateItem.AddListener(Co_UpdateList);
			}
			SetNotHaveStampText(m_stampInfoList.Count);
			Leave();
		}

		//// RVA: 0xD21C98 Offset: 0xD21C98 VA: 0xD21C98
		private void SetNotHaveStampText(int stampCount)
		{
			if(stampCount > 0)
			{
				m_haveNotStampText.text = "";
			}
			else
			{
				m_haveNotStampText.text = MessageManager.Instance.GetMessage("menu", "stamp_have_not_text");
			}
		}

		//// RVA: 0xD21FA4 Offset: 0xD21FA4 VA: 0xD21FA4
		private void Co_UpdateList(int index, SwapScrollListContent content)
		{
			LobbyStampItem l = content as LobbyStampItem;
			if(l != null)
			{
				l.OnStampClickButton = () =>
				{
					//0xD22504
					OnClickStamp(m_stampInfoList[index].stampId, m_stampInfoList[index].serifId);
				};
				l.CopyData(m_stampInfoList[index].stampId, m_stampInfoList[index].serifId);
			}
		}
	}
}
