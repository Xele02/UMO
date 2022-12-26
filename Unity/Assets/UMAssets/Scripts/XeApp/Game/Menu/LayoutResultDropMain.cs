using XeSys.Gfx;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;
using CriWare;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropMain : LayoutUGUIScriptBase
	{
		private enum MainAnimStep
		{
			EVENT_RARE_DROP = 0,
			RARE_DROP = 1,
			NOMAL_DROP = 2,
			RANK_BONUS = 3,
			BONUS_VALUE = 4,
			UC = 5,
			End = 6,
			NoneItem = 7,
		}

		[RangeAttribute(0, 0.5f)] // RVA: 0x67D02C Offset: 0x67D02C VA: 0x67D02C
		public float nextItemMoveSec = 0.1f; // 0x14
		[RangeAttribute(0, 0.5f)] // RVA: 0x67D044 Offset: 0x67D044 VA: 0x67D044
		public float backItemMoveSec = 0.25f; // 0x18
		[SerializeField]
		public float itemBonusCountupSec = 0.5f; // 0x1C
		public Action onFinished; // 0x20
		private static readonly float SCROLL_MARGIN_WIDTH = 20; // 0x0
		// private MOLKENLNCPE viewDrop; // 0x24
		private List<LayoutResultDropItem> itemList; // 0x28
		private AbsoluteLayout layoutRoot; // 0x2C
		private AbsoluteLayout layoutMain; // 0x30
		private Text textRareItemNum; // 0x34
		private Text textNomralItemNum; // 0x38
		private Text textEventRareItemNum; // 0x3C
		private AbsoluteLayout layoutLuckType; // 0x40
		private NumberBase numberLuck; // 0x44
		private AbsoluteLayout layoutScoreRankIcon; // 0x48
		private AbsoluteLayout layoutScoreRankLoop; // 0x4C
		private Text[] textScoreRankBonus; // 0x50
		private AbsoluteLayout layoutUCRoot; // 0x54
		private NumberBase numberTotalUC; // 0x58
		private Text textConvertUC; // 0x5C
		private LayoutUGUIScrollSupport scrollSupporter; // 0x60
		private AbsoluteLayout layoutZeroItem; // 0x64
		private AbsoluteLayout layoutBonus; // 0x68
		private int currentItemIndex; // 0x6C
		private CriAtomExPlayback countUpSEPlayback; // 0x70
		private CriAtomExPlayback countUpBonusSEPlayback; // 0x74
		private bool is_evenRareDrop; // 0x78
		private bool m_is_bonus; // 0x79
		private bool m_is_scoreRank = true; // 0x7A
		private AbsoluteLayout[] layoutRankIcon = new AbsoluteLayout[5]; // 0x7C
		private bool isSkip; // 0x80

		public bool IsSkip { get { return isSkip; } } //0x1D93478

		// RVA: 0x1D93480 Offset: 0x1D93480 VA: 0x1D93480
		private void Start()
		{
			return;
		}

		// RVA: 0x1D93484 Offset: 0x1D93484 VA: 0x1D93484
		private void Update()
		{
			return;
		}

		// RVA: 0x1D93488 Offset: 0x1D93488 VA: 0x1D93488 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_drop_set_anim (AbsoluteLayout)").Find("sw_drop_set (AbsoluteLayout)");
			layoutRoot = layout.FindViewById("sw_drop_set_anim") as AbsoluteLayout;
			layoutMain = layoutRoot.FindViewById("sw_drop_set") as AbsoluteLayout;
			layoutBonus = layout.FindViewById("sw_g_r_drop_txt_no_bns_in_anim") as AbsoluteLayout;
			textRareItemNum = t.Find("sw_txt_raredrop (AbsoluteLayout)/raredrop (TextView)").GetComponent<Text>();
			textNomralItemNum = t.Find("sw_txt_nomaldrop (AbsoluteLayout)/nomaldrop (TextView)").GetComponent<Text>();
			textEventRareItemNum = t.Find("sw_txt_evedrop (AbsoluteLayout)/raredrop (TextView)").GetComponent<Text>();
			layoutLuckType = (layoutMain.FindViewById("sw_txt_raredrop") as AbsoluteLayout).FindViewById("swtbl_luck_num") as AbsoluteLayout;
			numberLuck = t.Find("sw_txt_raredrop (AbsoluteLayout)/swtbl_luck_num (AbsoluteLayout)").Find("swnum_luck (AbsoluteLayout)").GetComponent<NumberBase>();
			layoutScoreRankIcon = layoutMain.FindViewById("swtbl_rank_icon") as AbsoluteLayout;
			layoutScoreRankLoop = layoutMain.FindViewById("sw_txt_rbonus") as AbsoluteLayout;
			textScoreRankBonus = t.Find("sw_txt_rbonus (AbsoluteLayout)").GetComponentsInChildren<Text>(true).Where((Text _) => {
				//0x1D970E0
				return _.name == "rbonus (TextView)";
			}).ToArray();
			scrollSupporter = t.Find("sw_item_area (AbsoluteLayout)/item_area (ScrollView)").GetComponent<LayoutUGUIScrollSupport>();
			layoutZeroItem = layoutMain.FindViewById("sw_nonitem_in_anim") as AbsoluteLayout;
			t.Find("sw_nonitem_in_anim (AbsoluteLayout)/sw_nonitem (AbsoluteLayout)/nonitem (TextView)").GetComponent<Text>().text = "StringLiteral_17777";
			layoutUCRoot = layoutMain.FindViewById("sw_getuc_set") as AbsoluteLayout;
			numberTotalUC = t.Find("sw_getuc_set (AbsoluteLayout)").Find("sw_getuc_anim (AbsoluteLayout)/swnum_uc (AbsoluteLayout)").GetComponent<NumberBase>();
			textConvertUC = t.Find("sw_getuc_set (AbsoluteLayout)").Find("sw_ucitemtxt (AbsoluteLayout)/ucitem (TextView)").GetComponent<Text>();
			layoutRankIcon[0] = layout.FindViewById("sw_rank_score_c") as AbsoluteLayout;
			layoutRankIcon[1] = layout.FindViewById("sw_rank_score_b") as AbsoluteLayout;
			layoutRankIcon[2] = layout.FindViewById("sw_rank_score_a") as AbsoluteLayout;
			layoutRankIcon[3] = layout.FindViewById("sw_rank_score_s") as AbsoluteLayout;
			layoutRankIcon[4] = layout.FindViewById("sw_rank_score_ss") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x1D943BC Offset: 0x1D943BC VA: 0x1D943BC
		// public void Setup(MOLKENLNCPE viewDrop, List<LayoutResultDropItem> itemList) { }

		// // RVA: 0x1D948BC Offset: 0x1D948BC VA: 0x1D948BC
		public void StartBeginAnim()
		{
			TodoLogger.Log(0, "StartBeginAnim");
			if(onFinished != null)
				onFinished();
		}

		// // RVA: 0x1D9496C Offset: 0x1D9496C VA: 0x1D9496C
		public void StartEndAnim(Action endCallback)
		{
			TodoLogger.Log(0, "StartBeginAnim");
			endCallback();
		}

		// // RVA: 0x1D94A38 Offset: 0x1D94A38 VA: 0x1D94A38
		// public void SkipBeginAnim() { }

		// // RVA: 0x1D95714 Offset: 0x1D95714 VA: 0x1D95714
		// public void SkipRecordPlate(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71933C Offset: 0x71933C VA: 0x71933C
		// // RVA: 0x1D948E0 Offset: 0x1D948E0 VA: 0x1D948E0
		// private IEnumerator Co_PlayingRootAnim() { }

		// // RVA: 0x1D95818 Offset: 0x1D95818 VA: 0x1D95818
		// private void StartZeroItemAnim() { }

		// // RVA: 0x1D958EC Offset: 0x1D958EC VA: 0x1D958EC
		// private void StartEventRareItemDropNumAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7193B4 Offset: 0x7193B4 VA: 0x7193B4
		// // RVA: 0x1D95910 Offset: 0x1D95910 VA: 0x1D95910
		// private IEnumerator Co_PlayingEventRareItemDropNumAnim() { }

		// // RVA: 0x1D959BC Offset: 0x1D959BC VA: 0x1D959BC
		// private void StartNextEventRareItemAnim() { }

		// // RVA: 0x1D95D34 Offset: 0x1D95D34 VA: 0x1D95D34
		// private void StartRareItemDropNumAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71942C Offset: 0x71942C VA: 0x71942C
		// // RVA: 0x1D95D58 Offset: 0x1D95D58 VA: 0x1D95D58
		// private IEnumerator Co_PlayingRareItemDropNumAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7194A4 Offset: 0x7194A4 VA: 0x7194A4
		// // RVA: 0x1D94990 Offset: 0x1D94990 VA: 0x1D94990
		// private IEnumerator Co_EndPlayingAnim(Action endCallback) { }

		// // RVA: 0x1D95E24 Offset: 0x1D95E24 VA: 0x1D95E24
		// private void StartNextRareItemAnim() { }

		// // RVA: 0x1D960B4 Offset: 0x1D960B4 VA: 0x1D960B4
		// private void StartNormalItemDropNumAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71951C Offset: 0x71951C VA: 0x71951C
		// // RVA: 0x1D960D8 Offset: 0x1D960D8 VA: 0x1D960D8
		// private IEnumerator Co_PlayingNomralItemDropNumAnim() { }

		// // RVA: 0x1D96184 Offset: 0x1D96184 VA: 0x1D96184
		// private void StartNextNormalItemAnim() { }

		// // RVA: 0x1D962FC Offset: 0x1D962FC VA: 0x1D962FC
		// public void StartNormalItemBonusAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x719594 Offset: 0x719594 VA: 0x719594
		// // RVA: 0x1D96320 Offset: 0x1D96320 VA: 0x1D96320
		// private IEnumerator Co_PlayingNormalItemBonusAnim() { }

		// // RVA: 0x1D963CC Offset: 0x1D963CC VA: 0x1D963CC
		// public void StartUCAnim() { }

		// // RVA: 0x1D955DC Offset: 0x1D955DC VA: 0x1D955DC
		// public void StartScoreLoopAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71960C Offset: 0x71960C VA: 0x71960C
		// // RVA: 0x1D963F8 Offset: 0x1D963F8 VA: 0x1D963F8
		// private IEnumerator Co_PlayingUCAnim() { }

		// // RVA: 0x1D964A4 Offset: 0x1D964A4 VA: 0x1D964A4
		// private void OnChangeUCNumber(int number) { }

		// [IteratorStateMachineAttribute] // RVA: 0x719684 Offset: 0x719684 VA: 0x719684
		// // RVA: 0x1D95C4C Offset: 0x1D95C4C VA: 0x1D95C4C
		// private IEnumerator Co_AutoScrolling(float endNormalizePos, float time, Action actionScrollFinished) { }

		// // RVA: 0x1D94EB8 Offset: 0x1D94EB8 VA: 0x1D94EB8
		// private bool AddItem() { }

		// // RVA: 0x1D951E8 Offset: 0x1D951E8 VA: 0x1D951E8
		// private void EnterMainStep(LayoutResultDropMain.MainAnimStep step) { }

		// // RVA: 0x1D9513C Offset: 0x1D9513C VA: 0x1D9513C
		// public void SetupUCAnimTable() { }

		// // RVA: 0x1D96504 Offset: 0x1D96504 VA: 0x1D96504
		public bool IsOpenPopupRecordPlate()
		{
			TodoLogger.Log(0, "IsOpenPopupRecordPlate");
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7196FC Offset: 0x7196FC VA: 0x7196FC
		// // RVA: 0x1D965B8 Offset: 0x1D965B8 VA: 0x1D965B8
		// private IEnumerator Co_ScrollArea() { }

		// // RVA: 0x1D96664 Offset: 0x1D96664 VA: 0x1D96664
		// private void PlayJingle() { }

		// // RVA: 0x1D96820 Offset: 0x1D96820 VA: 0x1D96820
		// private void PlayCountUpLoopSE() { }

		// // RVA: 0x1D94EA0 Offset: 0x1D94EA0 VA: 0x1D94EA0
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x1D96880 Offset: 0x1D96880 VA: 0x1D96880
		// private void PlayBonusCountUpLoopSE() { }

		// // RVA: 0x1D94EAC Offset: 0x1D94EAC VA: 0x1D94EAC
		// private void StopBonusCountUpLoopSE() { }

		// // RVA: 0x1D968E0 Offset: 0x1D968E0 VA: 0x1D968E0
		// public bool IsDrop() { }

		// // RVA: 0x1D96968 Offset: 0x1D96968 VA: 0x1D96968
		// public bool IsMedalDrop() { }

		// [CompilerGeneratedAttribute] // RVA: 0x719774 Offset: 0x719774 VA: 0x719774
		// // RVA: 0x1D96B64 Offset: 0x1D96B64 VA: 0x1D96B64
		// private bool <Co_PlayingRootAnim>b__42_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x719784 Offset: 0x719784 VA: 0x719784
		// // RVA: 0x1D96B90 Offset: 0x1D96B90 VA: 0x1D96B90
		// private bool <Co_PlayingEventRareItemDropNumAnim>b__45_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x719794 Offset: 0x719794 VA: 0x719794
		// // RVA: 0x1D96BBC Offset: 0x1D96BBC VA: 0x1D96BBC
		// private bool <Co_PlayingRareItemDropNumAnim>b__48_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7197A4 Offset: 0x7197A4 VA: 0x7197A4
		// // RVA: 0x1D96BE8 Offset: 0x1D96BE8 VA: 0x1D96BE8
		// private bool <Co_EndPlayingAnim>b__49_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7197B4 Offset: 0x7197B4 VA: 0x7197B4
		// // RVA: 0x1D96C14 Offset: 0x1D96C14 VA: 0x1D96C14
		// private bool <Co_PlayingNomralItemDropNumAnim>b__52_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7197C4 Offset: 0x7197C4 VA: 0x7197C4
		// // RVA: 0x1D96C40 Offset: 0x1D96C40 VA: 0x1D96C40
		// private bool <Co_PlayingNormalItemBonusAnim>b__55_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7197D4 Offset: 0x7197D4 VA: 0x7197D4
		// // RVA: 0x1D96C6C Offset: 0x1D96C6C VA: 0x1D96C6C
		// private bool <Co_PlayingNormalItemBonusAnim>b__55_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7197E4 Offset: 0x7197E4 VA: 0x7197E4
		// // RVA: 0x1D96D54 Offset: 0x1D96D54 VA: 0x1D96D54
		// private bool <Co_PlayingNormalItemBonusAnim>b__55_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7197F4 Offset: 0x7197F4 VA: 0x7197F4
		// // RVA: 0x1D96D80 Offset: 0x1D96D80 VA: 0x1D96D80
		// private bool <Co_PlayingNormalItemBonusAnim>b__55_4() { }

		// [CompilerGeneratedAttribute] // RVA: 0x719804 Offset: 0x719804 VA: 0x719804
		// // RVA: 0x1D96E68 Offset: 0x1D96E68 VA: 0x1D96E68
		// private bool <Co_PlayingNormalItemBonusAnim>b__55_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x719814 Offset: 0x719814 VA: 0x719814
		// // RVA: 0x1D96F50 Offset: 0x1D96F50 VA: 0x1D96F50
		// private bool <Co_PlayingNormalItemBonusAnim>b__55_6() { }

		// [CompilerGeneratedAttribute] // RVA: 0x719824 Offset: 0x719824 VA: 0x719824
		// // RVA: 0x1D97038 Offset: 0x1D97038 VA: 0x1D97038
		// private bool <Co_PlayingUCAnim>b__58_0() { }
	}
}
