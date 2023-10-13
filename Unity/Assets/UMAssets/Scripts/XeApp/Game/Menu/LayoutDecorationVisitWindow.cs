using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	internal class LayoutDecorationVisitWindow : LayoutUGUIScriptBase
	{
		public enum VisitTabType
		{
			Friend = 0,
			Fan = 1,
			Other = 2,
			Num = 3,
		}

		[Serializable]
		private struct TabLayoutData
		{
			public ButtonBase m_button; // 0x0
			public AbsoluteLayout m_select; // 0x4
			public Action<int> m_callBack; // 0x8
		}

		public const string AssetName = "root_deco_window_02_layout_root";
		[SerializeField]
		private TabLayoutData[] m_tabList = new TabLayoutData[3]; // 0x14
		[SerializeField]
		private Text m_windowText; // 0x18
		[SerializeField]
		private Text m_memberNumText; // 0x1C
		[SerializeField]
		private Text m_giftText; // 0x20
		[SerializeField]
		private Text m_giftNumText; // 0x24
		[SerializeField]
		private ActionButton m_allGiftButton; // 0x28
		[SerializeField]
		private RawImageEx m_allGiftButtonFont; // 0x2C
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x30
		private AbsoluteLayout m_base; // 0x34
		private AbsoluteLayout m_memberNumTable; // 0x38
		private AbsoluteLayout m_windowTextTable; // 0x3C
		private List<LayoutDecoraionVisitList> m_visitList = new List<LayoutDecoraionVisitList>(); // 0x40
		private List<EAJCBFGKKFA_FriendInfo> m_friendPlayerData = new List<EAJCBFGKKFA_FriendInfo>(); // 0x48
		public Action OnClickAllGiftButtonCallback; // 0x4C
		public DecorationConstants.VisitButtonCallback OnClickVisitButton; // 0x50
		public Action<EAJCBFGKKFA_FriendInfo> OnClickGiftButton; // 0x54
		public Action<EAJCBFGKKFA_FriendInfo> OnClickDivaIcon; // 0x58
		public Action<VisitTabType> TabCallback; // 0x5C
		private HNKMEOKCNBI m_netDecoVisitControl = new HNKMEOKCNBI(); // 0x60

		public bool IsLoadedList { get; private set; } // 0x44

		// RVA: 0x18BEEEC Offset: 0x18BEEEC VA: 0x18BEEEC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_sel_que_window_02_anim") as AbsoluteLayout;
			m_memberNumTable = layout.FindViewById("swtbl_sle_deco_window") as AbsoluteLayout;
			m_windowTextTable = layout.FindViewById("swtbl_sel_deco_wind") as AbsoluteLayout;
			m_allGiftButtonFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("deco_fnt_09"));
			for(int i = 0; i < m_tabList.Length; i++)
			{
				m_tabList[i].m_select = layout.FindViewById(string.Format("swtbl_sel_deco_tab_{0:D2}", i + 1)) as AbsoluteLayout;
			}
			m_allGiftButton.AddOnClickCallback(() =>
			{
				//0x18C09DC
				OnClickAllGiftButtonCallback();
			});
			this.StartCoroutineWatched(Co_LoadVisitList());
			return base.InitializeFromLayout(layout, uvMan);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D6E14 Offset: 0x6D6E14 VA: 0x6D6E14
		//// RVA: 0x18BF330 Offset: 0x18BF330 VA: 0x18BF330
		private IEnumerator Co_LoadVisitList()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x18C0B40
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, "root_deco_window_02_list_layout_root");
			yield return op;
			GameObject source = null;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x18C0A10
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
				LayoutDecoraionVisitList l = g.GetComponent<LayoutDecoraionVisitList>();
				l.SettingCallback(VisitButtonCallback, GiftButtonCallback, DivaIconCallback);
				m_swapScrollList.AddScrollObject(l);
			}
			yield return null;
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
			m_swapScrollList.Apply();
			Destroy(source);
			if(m_swapScrollList != null)
			{
				m_swapScrollList.OnUpdateItem.RemoveAllListeners();
				m_swapScrollList.OnUpdateItem.AddListener(Co_UpdateList);
			}
			Loaded();
			IsLoadedList = true;
		}

		//// RVA: 0x18BF3DC Offset: 0x18BF3DC VA: 0x18BF3DC
		private void VisitButtonCallback(EAJCBFGKKFA_FriendInfo player, IiconTexture texture, MusicRatioTextureCache.MusicRatioTexture musicRatioTexture)
		{
			OnClickVisitButton(player, texture, musicRatioTexture);
		}

		//// RVA: 0x18BF42C Offset: 0x18BF42C VA: 0x18BF42C
		private void GiftButtonCallback(EAJCBFGKKFA_FriendInfo player)
		{
			OnClickGiftButton(player);
		}

		//// RVA: 0x18BF4AC Offset: 0x18BF4AC VA: 0x18BF4AC
		private void DivaIconCallback(EAJCBFGKKFA_FriendInfo player)
		{
			OnClickDivaIcon(player);
		}

		// RVA: 0x18BF52C Offset: 0x18BF52C VA: 0x18BF52C
		public void Enter()
		{
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x18BF5B8 Offset: 0x18BF5B8 VA: 0x18BF5B8
		public void SettingMember(int memberNum, int memberMax)
		{
			m_memberNumText.text = memberNum.ToString() + "/" + memberMax.ToString();
		}

		// RVA: 0x18BF680 Offset: 0x18BF680 VA: 0x18BF680
		public void SettingMember(int memberMax)
		{
			if (memberMax > 0)
				m_memberNumText.text = memberMax.ToString();
			else
				m_memberNumText.text = "";
		}

		//// RVA: 0x18BF75C Offset: 0x18BF75C VA: 0x18BF75C
		public void SettingGiftNum(int giftNum, int giftMax)
		{
			m_giftText.text = MessageManager.Instance.GetMessage("menu", "deco_visit_gift");
			m_giftNumText.text = giftNum.ToString() + "/" + giftMax.ToString();
		}

		// RVA: 0x18BF8A8 Offset: 0x18BF8A8 VA: 0x18BF8A8
		public void SettingTab()
		{
			for(int i = 0; i < 3; i++)
			{
				int type = i;
				m_tabList[i].m_button.ClearOnClickCallback();
				m_tabList[i].m_button.AddOnClickCallback(() =>
				{
					//0x18C0A18
					ChangeTab((VisitTabType)type);
					if(TabCallback != null)
					{
						TabCallback((VisitTabType)type);
					}
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
		}

		// RVA: 0x18BFA8C Offset: 0x18BFA8C VA: 0x18BFA8C
		public void ChangeTab(VisitTabType type)
		{
			for(int i = 0; i < m_tabList.Length; i++)
			{
				m_tabList[i].m_select.StartChildrenAnimGoStop((int)type == i ? 1 : 0, (int)type == i ? 1 : 0);
			}
			m_windowText.text = "";
			UpdateScrollList(0);
		}

		// RVA: 0x18BFC7C Offset: 0x18BFC7C VA: 0x18BFC7C
		public void Leave()
		{
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x18BFD08 Offset: 0x18BFD08 VA: 0x18BFD08
		public void Hide()
		{
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x18BFD88 Offset: 0x18BFD88 VA: 0x18BFD88
		public bool IsPlayingEnd()
		{
			return !m_base.IsPlayingChildren();
		}

		//// RVA: 0x18BFDB8 Offset: 0x18BFDB8 VA: 0x18BFDB8
		public void UpdateList(List<EAJCBFGKKFA_FriendInfo> friendPlayerData, VisitTabType type, int count)
		{
			m_friendPlayerData = friendPlayerData;
			UpdateWindowText(type, count);
			UpdateScrollList(count);
		}

		// RVA: 0x18BFF24 Offset: 0x18BFF24 VA: 0x18BFF24
		public void Initilize()
		{
			m_windowText.text = "";
			foreach(var it in m_swapScrollList.ScrollObjects)
			{
				LayoutDecoraionVisitList s = (it as LayoutDecoraionVisitList);
				s.Initilize();
			}
		}

		// RVA: 0x18C0160 Offset: 0x18C0160 VA: 0x18C0160
		public void Release()
		{
			foreach (var it in m_swapScrollList.ScrollObjects)
			{
				LayoutDecoraionVisitList s = (it as LayoutDecoraionVisitList);
				s.Release();
			}
		}

		//// RVA: 0x18BFDE8 Offset: 0x18BFDE8 VA: 0x18BFDE8
		private void UpdateWindowText(VisitTabType type, int count)
		{
			if (count != 0)
				return;
			if(type == VisitTabType.Fan)
			{
				m_windowText.text = MessageManager.Instance.GetMessage("menu", "deco_visit_no_fun");
			}
			else if(type == VisitTabType.Friend)
			{
				m_windowText.text = MessageManager.Instance.GetMessage("menu", "deco_visit_no_friend");
			}
		}

		//// RVA: 0x18BFBC0 Offset: 0x18BFBC0 VA: 0x18BFBC0
		private void UpdateScrollList(int count)
		{
			m_swapScrollList.Apply();
			m_swapScrollList.SetItemCount(count);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
			CheckButton_AllGift();
		}

		//// RVA: 0x18C04C0 Offset: 0x18C04C0 VA: 0x18C04C0
		public void UpdateScrollList()
		{
			m_swapScrollList.VisibleRegionUpdate();
			CheckButton_AllGift();
		}

		//// RVA: 0x18C04F8 Offset: 0x18C04F8 VA: 0x18C04F8
		private void Co_UpdateList(int index, SwapScrollListContent content)
		{
			LayoutDecoraionVisitList l = content as LayoutDecoraionVisitList;
			if(l != null)
			{
				IFICNCAHIGI f = m_friendPlayerData[index].PCEGKKLKFNO as IFICNCAHIGI;
				l.SetSetting(m_friendPlayerData[index], f != null, f != null ? f.AGDBNNEAIIC_FanNum : 0);
			}
		}

		//// RVA: 0x18C06CC Offset: 0x18C06CC VA: 0x18C06CC
		public void IconAnimUpdate(int frame)
		{
			if(m_swapScrollList != null)
			{
				for(int i = 0; i < m_swapScrollList.ScrollObjects.Count; i++)
				{
					(m_swapScrollList.ScrollObjects[i] as LayoutDecoraionVisitList).IconAnimUpdate(frame);
				}
			}
		}

		//// RVA: 0x18C0364 Offset: 0x18C0364 VA: 0x18C0364
		private void CheckButton_AllGift()
		{
			if (m_netDecoVisitControl.OIONBFLLDIB_GetPresentCountLeftToSend() < 1)
				m_allGiftButton.Disable = true;
			else
			{
				bool b = true;
				for(int i = 0; i < m_friendPlayerData.Count; i++)
				{
					if(!m_netDecoVisitControl.MHGJGAPLMFO(m_friendPlayerData[i].MLPEHNBNOGD_Id))
					{
						b = false;
						break;
					}
				}
				m_allGiftButton.Disable = b;
			}
		}
	}
}
