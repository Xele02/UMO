using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardSelect : LayoutUGUIScriptBase
	{
		public delegate void SelectionChangedCallback(int offset);

		public delegate void ScrollRepeatedCallback(int repeatDelta, int beginIndex, int endIndex);

		[SerializeField]
		private LayoutBingoRewardSelectScroll m_scroll; // 0x14
		[SerializeField]
		private List<BingoRewardContents> contentList = new List<BingoRewardContents>(); // 0x18
		[SerializeField]
		private ActionButton SelectButton; // 0x1C
		[SerializeField]
		private List<BingoRewardSelectButton> m_sideButton; // 0x20
		[SerializeField]
		private Text Desc1Text; // 0x24
		[SerializeField]
		private Text Desc2Text; // 0x28
		[SerializeField]
		private Text Desc3Text; // 0x2C
		[SerializeField]
		private Text RewardCountText; // 0x30
		private static readonly int[] s_orderdBingoIndex = new int[4]
			{ 1, 2, 4, 3 }; // 0x0
		public static readonly int OrderdBingoNum = s_orderdBingoIndex.Length; // 0x4
		private AbsoluteLayout m_layoutRoot; // 0x34
		private AbsoluteLayout m_ribbon; // 0x38
		private AbsoluteLayout m_MultiReward; // 0x3C

		public SelectionChangedCallback onSelectionChanged { private get; set; } // 0x40
		public ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0x44
		public Action<bool> onScrollStarted { private get; set; } // 0x48
		public Action<bool> onScrollUpdated { private get; set; } // 0x4C
		public Action<bool> onScrollEnded { private get; set; } // 0x50
		public Action<int> onClickFlowButton { private get; set; } // 0x54

		// RVA: 0x14C7734 Offset: 0x14C7734 VA: 0x14C7734
		private void Start()
		{
			return;
		}

		// RVA: 0x14C7738 Offset: 0x14C7738 VA: 0x14C7738
		private void Update()
		{
			return;
		}

		// RVA: 0x14C773C Offset: 0x14C773C VA: 0x14C773C
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x14C77C8 Offset: 0x14C77C8 VA: 0x14C77C8
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x14C7854 Offset: 0x14C7854 VA: 0x14C7854
		//public void Show() { }

		//// RVA: 0x14C78D0 Offset: 0x14C78D0 VA: 0x14C78D0
		//public void Hide() { }

		// RVA: 0x14C794C Offset: 0x14C794C VA: 0x14C794C
		public bool RootLayoutIsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		//// RVA: 0x14C7978 Offset: 0x14C7978 VA: 0x14C7978
		//public bool IsLoaded() { }

		// RVA: 0x14C7A68 Offset: 0x14C7A68 VA: 0x14C7A68
		public void LayoutSetting(int current, int max, int _cardMax, Action act)
		{
			SetDescText(_cardMax);
			SetSelectCountText(current, max);
			SetSelectButton(act);
			for(int i = 0; i < m_sideButton.Count; i++)
			{
				m_sideButton[i].onSelectButton = (int offset) =>
				{
					//0x14C968C
					if (onClickFlowButton != null)
						onClickFlowButton(offset);
				};
			}
		}

		// RVA: 0x14C7F84 Offset: 0x14C7F84 VA: 0x14C7F84
		public void ScrollDisable()
		{
			m_scroll.InputDisable();
		}

		// RVA: 0x14C7FB8 Offset: 0x14C7FB8 VA: 0x14C7FB8
		public void ScrollEnable()
		{
			m_scroll.InputEnable();
		}

		// RVA: 0x14C7FEC Offset: 0x14C7FEC VA: 0x14C7FEC
		public void initializeScroll()
		{
			m_scroll.onScrollRepeated = OnScrollRepeated;
			m_scroll.onScrollUpdated = OnScrollUpdated;
			m_scroll.onScrollEnded = OnScrollEnded;
			m_scroll.onScrollStarted = OnScrollStarted;
			m_scroll.onSelectionChanged = OnSelectionChanged;
			if (onScrollRepeated != null)
				onScrollRepeated(0, -2, 1);
		}

		//// RVA: 0x14C7BD8 Offset: 0x14C7BD8 VA: 0x14C7BD8
		private void SetDescText(int _bingoMaxCount)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			Desc1Text.text = bk.GetMessageByLabel("bingo_reward_select_desc1");
			Desc2Text.text = string.Format(bk.GetMessageByLabel("bingo_reward_select_desc2"), _bingoMaxCount);
			Desc3Text.text = bk.GetMessageByLabel("bingo_reward_select_desc3");
		}

		// RVA: 0x14C7DBC Offset: 0x14C7DBC VA: 0x14C7DBC
		public void SetSelectCountText(int current, int max)
		{
			RewardCountText.text = current.ToString() + "/" + max.ToString();
		}

		//// RVA: 0x14C7E84 Offset: 0x14C7E84 VA: 0x14C7E84
		private void SetSelectButton(Action act)
		{
			SelectButton.ClearOnClickCallback();
			SelectButton.AddOnClickCallback(() =>
			{
				//0x14C9700
				act();
			});
		}

		// RVA: 0x14C82A4 Offset: 0x14C82A4 VA: 0x14C82A4
		public void SetSelectButtonDisable()
		{
			SelectButton.Disable = true;
		}

		// RVA: 0x14C82D4 Offset: 0x14C82D4 VA: 0x14C82D4
		public void SetSelectButtonEnable()
		{
			SelectButton.Disable = false;
		}

		//// RVA: 0x14C8304 Offset: 0x14C8304 VA: 0x14C8304
		private void EnableRibbon(bool _isEnable)
		{
			if (m_ribbon != null)
				m_ribbon.StartChildrenAnimGoStop(_isEnable ? "01" : "02");
		}

		// RVA: 0x14C8388 Offset: 0x14C8388 VA: 0x14C8388
		public BingoRewardContents ChangeReward(int order, int bingoId)
		{
			return contentList[s_orderdBingoIndex[order] - 1];
		}

		//// RVA: 0x14C8484 Offset: 0x14C8484 VA: 0x14C8484
		//public void MultiSetting(bool _isMulti) { }

		//// RVA: 0x14C8518 Offset: 0x14C8518 VA: 0x14C8518
		private void OnSelectionChanged(int offset)
		{
			if (onSelectionChanged != null)
				onSelectionChanged(offset);
		}

		//// RVA: 0x14C8260 Offset: 0x14C8260 VA: 0x14C8260
		public void OnScrollRepeated(int repeatDelta, bool isSelectionFlipped)
		{
			if (onScrollRepeated != null)
				onScrollRepeated(repeatDelta, isSelectionFlipped ? -1 : -2, isSelectionFlipped ? 2 : 1);
		}

		//// RVA: 0x14C8DE8 Offset: 0x14C8DE8 VA: 0x14C8DE8
		public void OnScrollStarted(bool isAuto)
		{
			EnableRibbon(false);
			if (onScrollStarted != null)
				onScrollStarted(isAuto);
		}

		//// RVA: 0x14C8E68 Offset: 0x14C8E68 VA: 0x14C8E68
		public void OnScrollUpdated(bool isAuto)
		{
			if (onScrollUpdated != null)
				onScrollUpdated(isAuto);
		}

		//// RVA: 0x14C8EDC Offset: 0x14C8EDC VA: 0x14C8EDC
		public void OnScrollEnded(bool isAuto)
		{
			EnableRibbon(true);
			if (onScrollEnded != null)
				onScrollEnded(isAuto);
		}

		// RVA: 0x14C8F5C Offset: 0x14C8F5C VA: 0x14C8F5C
		public void RequestLeftFlow(int pageOffset, float flowSec, Action onEnd)
		{
			m_scroll.RequestFlow(-pageOffset, flowSec, onEnd);
		}

		// RVA: 0x14C9080 Offset: 0x14C9080 VA: 0x14C9080
		public void RequestRightFlow(int pageOffset, float flowSec, Action onEnd)
		{
			m_scroll.RequestFlow(pageOffset, flowSec, onEnd);
		}

		// RVA: 0x14C90C8 Offset: 0x14C90C8 VA: 0x14C90C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_bingo_sw_sel_bingo_inout_anim") as AbsoluteLayout;
			m_ribbon = layout.FindViewByExId("swtbl_sel_bingo_1ormulti_sw_ribbon_onoff_anim") as AbsoluteLayout;
			m_MultiReward = layout.FindViewByExId("sw_sel_bingo_inout_anim_sw_sdel_bingo_swipe_anim") as AbsoluteLayout;
			for(int i = 0; i < contentList.Count; i++)
			{
				StringBuilder str = new StringBuilder("sw_sdel_bingo_swipe_anim");
				str.Append("_");
				str.Append(contentList[i].name.Replace(" (AbsoluteLayout)", ""));
				contentList[i].initialize(layout.FindViewByExId(str.ToString()) as AbsoluteLayout);
			}
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
