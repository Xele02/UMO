using XeSys.Gfx;
using System;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusConditions : LayoutUGUIScriptBase
	{
		[Serializable]
		public class LoginBonusPrizeObject
		{
			[SerializeField]
			public RawImageEx iconL; // 0x8
			[SerializeField]
			public RawImageEx iconS; // 0xC
			[SerializeField]
			public NumberBase itemNumS; // 0x10
			[SerializeField]
			public NumberBase itemNumL; // 0x14
			[SerializeField]
			public NumberBase ucL; // 0x18
			[SerializeField]
			public NumberBase ucS; // 0x1C
			[SerializeField]
			public NumberBase day; // 0x20

			public AbsoluteLayout iconLayout { get; set; } // 0x24
			public AbsoluteLayout stampAnim { get; set; } // 0x28
			public AbsoluteLayout frameLPlaying { get; set; } // 0x2C
			public AbsoluteLayout frameSPlaying { get; set; } // 0x30
			public bool isLoadingIconL { get; set; } // 0x34
			public bool isLoadingIconS { get; set; } // 0x35
		}

		public enum eIconLayoutType
		{
			Normal = 0,
			Big = 1,
		}

		public enum eNextType
		{
			None = 0,
			Next = 1,
		}

		public enum eStampStatus
		{
			None = 0,
			Play = 1,
			Press = 2,
			Loop = 3,
		}

		public enum eUnitPrice
		{
			Num = 0,
			Uc = 1,
		}

		public enum eIconFrameAnim
		{
			None = 0,
			Wait = 1,
			InToLoop = 2,
			Loop = 3,
			In = 4,
			Out = 5,
		}

		private const int ICON_NUM = 14;
		[SerializeField]
		private LoginBonusPrizeObject[] m_prizeObject = new LoginBonusPrizeObject[14]; // 0x14
		[SerializeField]
		private ActionButton m_okButton; // 0x18
		private EPLAAEHPCDM m_rewardData; // 0x1C
		private ItemPackImageTextureCache m_itemPackTextureCache; // 0x20
		private AbsoluteLayout m_root; // 0x24
		private LayoutUGUIRuntime m_runtime; // 0x28
		private bool m_isOpen; // 0x2C
		private bool m_isClosed; // 0x2D
		private bool m_isSkip; // 0x2E
		private bool m_isPlayStampSe; // 0x2F
		private int m_stampPlayDay; // 0x30
		private List<IEnumerator> m_animationList = new List<IEnumerator>(); // 0x34
		private IEnumerator m_animItemIconL; // 0x38
		private IEnumerator m_animItemIconS; // 0x3C
		private bool m_isCheckItemPack; // 0x40

		// RVA: 0x1D55720 Offset: 0x1D55720 VA: 0x1D55720
		public bool IsReady()
		{
			if(m_runtime != null)
			{
				return m_runtime.IsReady && IsLoaded();
			}
			return false;
		}

		// RVA: 0x1D557F0 Offset: 0x1D557F0 VA: 0x1D557F0
		public void SetButtonCallbackOk(Action callback)
		{
			if(m_okButton != null && callback != null)
			{
				m_okButton.ClearOnClickCallback();
				m_okButton.AddOnClickCallback(() =>
				{
					Method$XeApp.Game.Menu.LayoutLoginBonusConditions.<>c__DisplayClass23_0.<SetButtonCallbackOk>b__0()
				});
			}
		}

		// RVA: 0x1D55968 Offset: 0x1D55968 VA: 0x1D55968
		public bool IsClosed()
		{
			return m_isClosed;
		}

		// RVA: 0x1D55970 Offset: 0x1D55970 VA: 0x1D55970
		public void SetStatus(EPLAAEHPCDM data, IKIIAFKHDFP manager, ItemPackImageTextureCache textureCache)
		{
			m_rewardData = data;
			m_itemPackTextureCache = textureCache;
			int a1 = 0;
			int a2 = 0;
			if(manager.GAOEDFGMHFD != null)
			{
				GMHKBJLIILI g = manager.GAOEDFGMHFD.Find(() =>
				{
					Method$XeApp.Game.Menu.LayoutLoginBonusConditions.<>c__DisplayClass25_0.<SetStatus>b__0()
				});
				if(g != null)
				{
					if (g.HMFFHLPNMPH_Count > 0)
						a1 = g.HMFFHLPNMPH_Count - 1;
				}
			}
			ResetRewardData();
			int idx2 = 0;
			for(int i = 0; i < 10 && i < data.JPILDOGJLDG_LoginBonusPrizes.Count; i++)
			{
				if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items != null)
				{
					if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items.Count > 0)
					{
						m_prizeObject[i].iconLayout.enabled = true;
						if (i < a1)
							SwitchStampAnim(i, 2);
						if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0] == null)
						{
							m_prizeObject[i].iconLayout.enabled = false;
						}
						else
						{
							if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items.Count < 2)
							{
								SetItemIconS(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemFullId);
								SetItemIconL(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemFullId);
								SwitchUnitPrice(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit);
								SetNumItem(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].MBJIFDBEDAC_Cnt);
							}
							else
							{
								SetItemPackIconS(idx2, 1);
								SetItemPackIconL(idx2, 1);
								SwitchUnitPrice(idx2, 0);
								SetNumItem(idx2, 1);
							}
							SwitchDay(idx2, i + 1);
							SwitchItemFrameAnim(i, 0, 1);
							idx2++;
						}
					}
				}
			}
			SwitchDayIconTbl(a2);
			m_stampPlayDay = a1;
			SwitchIcon(m_stampPlayDay + 1, 1);
			SwitchNext(m_stampPlayDay + 1, 1);
		}

		// RVA: 0x1D57C50 Offset: 0x1D57C50 VA: 0x1D57C50
		public bool IsLoading()
		{
			for(int i = 0; i < 10; i++)
			{
				if (m_prizeObject[i].isLoadingIconL)
					return true;
				if (m_prizeObject[i].isLoadingIconS)
					return true;
			}
			return false;
		}

		//// RVA: 0x1D57D30 Offset: 0x1D57D30 VA: 0x1D57D30
		//private bool IsIconLayoutArrayRange(int arrayIndex) { }

		//// RVA: 0x1D57D88 Offset: 0x1D57D88 VA: 0x1D57D88
		//private void SetButtonVisibleEnable(bool enable) { }

		//// RVA: 0x1D57490 Offset: 0x1D57490 VA: 0x1D57490
		//public void SwitchDay(int arrayIndex, int day) { }

		//// RVA: 0x1D578E8 Offset: 0x1D578E8 VA: 0x1D578E8
		//public void SwitchIcon(int arrayIndex, LayoutLoginBonusConditions.eIconLayoutType type) { }

		//// RVA: 0x1D569E0 Offset: 0x1D569E0 VA: 0x1D569E0
		//public void SwitchUnitPrice(int arrayIndex, LayoutLoginBonusConditions.eUnitPrice type) { }

		//// RVA: 0x1D57A9C Offset: 0x1D57A9C VA: 0x1D57A9C
		//public void SwitchNext(int arrayIndex, LayoutLoginBonusConditions.eNextType type) { }

		//// RVA: 0x1D57814 Offset: 0x1D57814 VA: 0x1D57814
		//public void SwitchDayIconTbl(int day) { }

		//// RVA: 0x1D5624C Offset: 0x1D5624C VA: 0x1D5624C
		//public void SwitchStampAnim(int arrayIndex, LayoutLoginBonusConditions.eStampStatus status) { }

		//// RVA: 0x1D56828 Offset: 0x1D56828 VA: 0x1D56828
		//public void SetItemPackIconL(int arrayIndex, ItemPackImageTextureCache.Type type) { }

		//// RVA: 0x1D56670 Offset: 0x1D56670 VA: 0x1D56670
		//public void SetItemPackIconS(int arrayIndex, ItemPackImageTextureCache.Type type) { }

		//// RVA: 0x1D5724C Offset: 0x1D5724C VA: 0x1D5724C
		//public void SetItemIconL(int arrayIndex, int itemId) { }

		//// RVA: 0x1D57008 Offset: 0x1D57008 VA: 0x1D57008
		//public void SetItemIconS(int arrayIndex, int itemId) { }

		//// RVA: 0x1D56B94 Offset: 0x1D56B94 VA: 0x1D56B94
		//public void SetNumItem(int arrayIndex, int num) { }

		//// RVA: 0x1D5761C Offset: 0x1D5761C VA: 0x1D5761C
		//public void SwitchItemFrameAnim(int arrayIndex, LayoutLoginBonusConditions.eIconLayoutType layoutType, LayoutLoginBonusConditions.eIconFrameAnim type) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6EBB0C Offset: 0x6EBB0C VA: 0x6EBB0C
		//// RVA: 0x1D57F54 Offset: 0x1D57F54 VA: 0x1D57F54
		//private IEnumerator WaitItemFrameAnim(LayoutLoginBonusConditions.eIconLayoutType layoutType, int arrayIndex, bool isLoop) { }

		//// RVA: 0x1D57F24 Offset: 0x1D57F24 VA: 0x1D57F24
		//private void SetAnimationIconFrame(LayoutLoginBonusConditions.eIconLayoutType layoutType, int arrayIndex, bool isLoop) { }

		//// RVA: 0x1D5804C Offset: 0x1D5804C VA: 0x1D5804C
		//private void ResetAnimationIconFrame() { }

		//// RVA: 0x1D5805C Offset: 0x1D5805C VA: 0x1D5805C
		//public void Skip() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6EBB84 Offset: 0x6EBB84 VA: 0x6EBB84
		//// RVA: 0x1D581B8 Offset: 0x1D581B8 VA: 0x1D581B8
		//private IEnumerator SkipAnim() { }

		// RVA: 0x1D58264 Offset: 0x1D58264 VA: 0x1D58264
		public void Update()
		{
			if (!IsReady())
				return;
			Skip();
			if(m_animationList.Count > 0)
			{
				if (!m_animationList[0].MoveNext())
					m_animationList.RemoveAt(0);
			}
			if(m_animItemIconL != null)
			{
				if (!m_animItemIconL.MoveNext())
					m_animItemIconL = null;
			}
			if(m_animItemIconS != null)
			{
				if (!m_animItemIconS.MoveNext())
					m_animItemIconS = null;
			}
		}

		// RVA: 0x1D58510 Offset: 0x1D58510 VA: 0x1D58510
		public void Show()
		{
			if (m_root == null)
				return;
			if (m_isOpen)
				return;
			m_isOpen = true;
			m_isClosed = false;
			gameObject.SetActive(true);
			SetButtonVisibleEnable(false);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_animationList.Clear();
			m_animationList.Add(WaitOpenAnim());
		}

		// RVA: 0x1D586F0 Offset: 0x1D586F0 VA: 0x1D586F0
		public void Hide()
		{
			if (!m_isOpen)
				return;
			m_isOpen = false;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animationList.Clear();
			m_animationList.Add(WaitCloseAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EBBFC Offset: 0x6EBBFC VA: 0x6EBBFC
		//// RVA: 0x1D58664 Offset: 0x1D58664 VA: 0x1D58664
		//private IEnumerator WaitOpenAnim() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6EBC74 Offset: 0x6EBC74 VA: 0x6EBC74
		//// RVA: 0x1D587F8 Offset: 0x1D587F8 VA: 0x1D587F8
		//private IEnumerator WaitCloseAnim() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6EBCEC Offset: 0x6EBCEC VA: 0x6EBCEC
		//// RVA: 0x1D57E4C Offset: 0x1D57E4C VA: 0x1D57E4C
		//private IEnumerator WaitStampAnim(int arrayIndex) { }

		//// RVA: 0x1D588E4 Offset: 0x1D588E4 VA: 0x1D588E4
		//private void OpenItemPackPopup(CAEDGOPBDNK data, Action callback) { }

		//// RVA: 0x1D58D8C Offset: 0x1D58D8C VA: 0x1D58D8C
		//public bool IsPlayingAnim() { }

		// RVA: 0x1D58DA4 Offset: 0x1D58DA4 VA: 0x1D58DA4
		public void Reset()
		{
			m_stampPlayDay = 0;
			m_isSkip = false;
			m_isPlayStampSe = false;
			if(m_okButton != null)
			{
				LayoutUGUIUtility.SetImageRaycastTarget(m_okButton.gameObject, true);
			}
			ResetRewardData();
		}

		//// RVA: 0x1D56040 Offset: 0x1D56040 VA: 0x1D56040
		//private void ResetRewardData() { }

		//// RVA: 0x1D58EAC Offset: 0x1D58EAC VA: 0x1D58EAC
		//private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x1D58FFC Offset: 0x1D58FFC VA: 0x1D58FFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_runtime = gameObject.GetComponent<LayoutUGUIRuntime>();
			m_root.StartAllAnimGoStop("st_wait");
			for(int i = 0; i < 10; i++)
			{
				m_prizeObject[i].iconLayout = layout.FindViewByExId(string.Format("swtbl_login_window_02_all_sw_icon_s_02_period_{0}dey", i + 1)) as AbsoluteLayout;
				if(m_prizeObject[i].iconLayout != null)
				{
					m_prizeObject[i].frameLPlaying = m_prizeObject[i].iconLayout.FindViewByExId("swtbl_login_icon_2_sw_next_icon_anim") as AbsoluteLayout;
					m_prizeObject[i].frameSPlaying = m_prizeObject[i].iconLayout.FindViewByExId("sw_icon_s_02_sw_icon_s_ef_loop_2_anim") as AbsoluteLayout;
				}
				m_prizeObject[i].stampAnim = layout.FindViewByExId(string.Format("swtbl_login_window_02_all_sw_icon_s_02_get_{0}dey", i + 1)) as AbsoluteLayout;
			}
			Reset();
			Loaded();
			return true;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6EBD64 Offset: 0x6EBD64 VA: 0x6EBD64
		//// RVA: 0x1D59708 Offset: 0x1D59708 VA: 0x1D59708
		//private void <SkipAnim>b__45_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6EBD74 Offset: 0x6EBD74 VA: 0x6EBD74
		//// RVA: 0x1D59714 Offset: 0x1D59714 VA: 0x1D59714
		//private bool <SkipAnim>b__45_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6EBD84 Offset: 0x6EBD84 VA: 0x6EBD84
		//// RVA: 0x1D59728 Offset: 0x1D59728 VA: 0x1D59728
		//private void <WaitStampAnim>b__51_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6EBD94 Offset: 0x6EBD94 VA: 0x6EBD94
		//// RVA: 0x1D59734 Offset: 0x1D59734 VA: 0x1D59734
		//private bool <WaitStampAnim>b__51_1() { }
	}
}
