using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class EpisodeReleaseWindow : LayoutUGUIScriptBase
	{
		public class ItemIcon
		{
			public AbsoluteLayout table; // 0x8
			public RawImageEx get_icon; // 0xC
			public RawImageEx image; // 0x10
			public NumberBase num; // 0x14
			public RawImageEx image2; // 0x18
			public NumberBase num2; // 0x1C
			public Transform end_pos; // 0x20
			public AbsoluteLayout line_abs; // 0x24
			public Transform start_pos; // 0x28
			public Transform start_pos2; // 0x2C
			public GameObject line1; // 0x30
			public GameObject line2; // 0x34
			public bool is_next; // 0x38
		}

		public class GaugeLayout
		{
			public AbsoluteLayout under; // 0x8
			public AbsoluteLayout up; // 0xC
			public AbsoluteLayout on; // 0x10
			public AbsoluteLayout over; // 0x14
		}

		private Action mUpdater; // 0x14
		[SerializeField]
		private ActionButton m_plas; // 0x18
		[SerializeField]
		private ActionButton m_minus; // 0x1C
		[SerializeField]
		private ActionButton m_plas_ten; // 0x20
		[SerializeField]
		private ActionButton m_minus_ten; // 0x24
		private int m_item_use_num; // 0x28
		private int m_have_item = 100; // 0x2C
		private int m_use_item_min; // 0x30
		private int m_use_item_max; // 0x34
		private const int ITEM_MAX = 6;
		private int rewardItemNum = 5; // 0x38
		private AbsoluteLayout m_next_gauge; // 0x3C
		private AbsoluteLayout m_item_list_changeNum; // 0x40
		private AbsoluteLayout m_gauge_table; // 0x44
		private GaugeLayout m_unlock_gauge = new GaugeLayout(); // 0x48
		private GaugeLayout m_lock_gauge = new GaugeLayout(); // 0x4C
		[SerializeField]
		private NumberBase m_point_den; // 0x50
		[SerializeField]
		private NumberBase m_point_mol; // 0x54
		[SerializeField]
		private NumberBase m_point_item_num; // 0x58
		[SerializeField]
		private Text m_episode_item; // 0x5C
		[SerializeField]
		private Text m_item_value; // 0x60
		[SerializeField]
		private Text m_caution; // 0x64
		[SerializeField]
		private Text m_episode_item_num; // 0x68
		[SerializeField]
		private Text m_item_name; // 0x6C
		[SerializeField]
		private List<ItemIcon> m_item_icon_list = new List<ItemIcon>(); // 0x70
		[SerializeField]
		private RawImageEx m_episode_item_image; // 0x74
		[SerializeField]
		private RawImageEx m_item_image; // 0x78
		[SerializeField]
		private PopupEpisodeRelease m_pop_window; // 0x7C
		private PIGBBNDPPJC m_data; // 0x80
		private EEDBNJAEKBI item_data; // 0x84
		private List<LGMEPLIJLNB> m_reward_list; // 0x88
		private const int EPISODE_ITEM_NUMBER = 80000;
		private const int LINE_Y_ADJUST = -10;
		private const int LINE_X_ADJUST = -2;
		private int m_item_use_type; // 0x8C
		private int m_next_point; // 0x90
		private bool m_is_line_update; // 0x94
		private RectTransform m_root; // 0x98

		// RVA: 0xEF9588 Offset: 0xEF9588 VA: 0xEF9588 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_next_gauge = layout.FindViewById("sw_sel_ep_progress_02_anim") as AbsoluteLayout;
			m_gauge_table = layout.FindViewById("swtbl_sel_ep_bar_sw_bar_after_anim") as AbsoluteLayout;
			m_lock_gauge.under = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_under") as AbsoluteLayout;
			m_lock_gauge.up = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_up") as AbsoluteLayout;
			m_lock_gauge.on = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_on") as AbsoluteLayout;
			m_lock_gauge.over = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_up_02") as AbsoluteLayout;
			m_unlock_gauge.under = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_up_02") as AbsoluteLayout;
			m_unlock_gauge.up = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_up") as AbsoluteLayout;
			m_unlock_gauge.on = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_on_02") as AbsoluteLayout;
			m_unlock_gauge.over = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_up_02") as AbsoluteLayout;
			m_item_list_changeNum = layout.FindViewByExId("sw_sel_ep_item_pop_swtbl_item_lane") as AbsoluteLayout;
			StringBuilder str = new StringBuilder();
			Transform t1 = transform.Find("sw_sel_ep_item_pop_all (AbsoluteLayout)/sw_sel_ep_item_pop (AbsoluteLayout)/swtbl_item_lane (AbsoluteLayout)");
			for(int i = 1; i < 7; i++)
			{
				str.Clear();
				str.AppendFormat("swtbl_scaling_frm_{0:D2} (AbsoluteLayout)", i);
				Transform t2 = t1.Find(str.ToString());
				ItemIcon image = new ItemIcon();
				image.image = t2.Find("sw_icon_scaling_01 (AbsoluteLayout)/cnm_ep_item_icon_01 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
				image.num = t2.Find("sw_icon_scaling_01 (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
				image.start_pos = t2.Find("sw_icon_scaling_01 (AbsoluteLayout)/item_arrival_pos (AbsoluteLayout)").GetComponent<Transform>();
				image.image2 = t2.Find("sw_icon_scaling_02 (AbsoluteLayout)/cnm_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
				image.num2 = t2.Find("sw_icon_scaling_02 (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
				image.start_pos2 = t2.Find("sw_icon_scaling_02 (AbsoluteLayout)/item_arrival_pos (AbsoluteLayout)").GetComponent<Transform>();
				str.Clear();
				str.AppendFormat("swtbl_get_icon_{0:D2} (AbsoluteLayout)", i);
				t2 = t1.Find(str.ToString());
				image.get_icon = t2.Find("sel_ep_clear_icon (AbsoluteLayout)").GetComponent<RawImageEx>();
				str.Clear();
				str.Clear();
				str.AppendFormat("swtbl_item_lane_swtbl_scaling_frm_{0:D2}", i);
				image.table = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
				image.table = image.table.FindViewByExId("swtbl_scaling_frm_sw_icon_scaling_01") as AbsoluteLayout;
				str.Clear();
				str.AppendFormat("sw_sel_ep_progress_02_anim_sel_ep_arrival_line_{0:D2}", i);
				image.line_abs = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
				GameObject g = new GameObject();
				image.line1 = Instantiate(g);
				image.line1.AddComponent<RawImageEx>();
				image.line1.transform.SetParent(image.start_pos, false);
				image.line2 = Instantiate(g);
				image.line2.AddComponent<RawImageEx>();
				image.line2.transform.SetParent(image.start_pos2, false);
				DestroyImmediate(g);
				str.Clear();
				str.AppendFormat("sw_sel_ep_progress_02_anim (AbsoluteLayout)", Array.Empty<object>());
				t2 = t1.Find(str.ToString());
				Transform[] ts = t2.GetComponentsInChildren<Transform>(true);
				str.Clear();
				str.AppendFormat("sel_ep_arrival_line_{0:D2} (AbsoluteLayout)", i);
				image.end_pos = ts.Where((Transform _) =>
				{
					//0xEFCD10
					return _.name == str.ToString();
				}).First();
				m_item_icon_list.Add(image);
			}
			m_plas.AddOnClickCallback(() =>
			{
				//0xEFCD7C
				TodoLogger.LogNotImplemented("m_plas");
			});
			m_minus.AddOnClickCallback(() =>
			{
				//0xEFCEBC
				TodoLogger.LogNotImplemented("m_minus");
			});
			m_plas_ten.AddOnClickCallback(() =>
			{
				//0xEFCFC4
				TodoLogger.LogNotImplemented("m_plas_ten");
			});
			m_minus_ten.AddOnClickCallback(() =>
			{
				//0xEFD160
				TodoLogger.LogNotImplemented("m_minus_ten");
			});
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0xEFAABC Offset: 0xEFAABC VA: 0xEFAABC
		private void Start()
		{
			return;
		}

		// RVA: 0xEFAAC0 Offset: 0xEFAAC0 VA: 0xEFAAC0
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0xEFAAD4 Offset: 0xEFAAD4 VA: 0xEFAAD4
		private void UpdateLoad()
		{
			if(m_point_den.IsLoaded() && m_point_mol.IsLoaded() && m_point_item_num.IsLoaded())
			{
				Loaded();
				mUpdater = UpdateIdle;
			}
		}

		//// RVA: 0xEFABE0 Offset: 0xEFABE0 VA: 0xEFABE0
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0xEFABE4 Offset: 0xEFABE4 VA: 0xEFABE4
		//private void UpdateItemValue() { }

		//// RVA: 0xEFB1DC Offset: 0xEFB1DC VA: 0xEFB1DC
		//private int RewardIndex() { }

		//// RVA: 0xEFB568 Offset: 0xEFB568 VA: 0xEFB568
		//private int GetAcquiredRewardIndex() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DAF2C Offset: 0x6DAF2C VA: 0x6DAF2C
		//// RVA: 0xEF9284 Offset: 0xEF9284 VA: 0xEF9284
		//public IEnumerator CO_Init(PIGBBNDPPJC data, int item_type) { }

		//// RVA: 0xEFB6A8 Offset: 0xEFB6A8 VA: 0xEFB6A8
		//public void Init(PIGBBNDPPJC data, int item_type) { }

		//// RVA: 0xEFC460 Offset: 0xEFC460 VA: 0xEFC460
		public void Enter()
		{
			m_plas.IsInputOff = false;
			m_minus.IsInputOff = false;
		}

		//// RVA: 0xEFC4B8 Offset: 0xEFC4B8 VA: 0xEFC4B8
		public void OpenEnd()
		{
			GetRoot();
			m_pop_window.SetDisable(m_item_use_num == 0);
		}

		//// RVA: 0xEFC62C Offset: 0xEFC62C VA: 0xEFC62C
		//private void UpdateLine() { }

		//// RVA: 0xEFC1F8 Offset: 0xEFC1F8 VA: 0xEFC1F8
		//private void SetItemImage(int index) { }

		//// RVA: 0xEFC32C Offset: 0xEFC32C VA: 0xEFC32C
		//private void SetEpiItemImage(int index) { }

		//// RVA: 0xEFB31C Offset: 0xEFB31C VA: 0xEFB31C
		//private void SetGauge(int gauge, int up) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DAFA4 Offset: 0x6DAFA4 VA: 0x6DAFA4
		//// RVA: 0xEFC918 Offset: 0xEFC918 VA: 0xEFC918
		//private IEnumerator SetItemGaugeLine(int index, bool is_next, bool isAcquired, bool is_line_skip) { }

		//// RVA: 0xEF82F4 Offset: 0xEF82F4 VA: 0xEF82F4
		//public int GetItemUseCount() { }

		//// RVA: 0xEF82FC Offset: 0xEF82FC VA: 0xEF82FC
		//public int GetItemUseType() { }

		//// RVA: 0xEF8304 Offset: 0xEF8304 VA: 0xEF8304
		//public int GetAddEpisodePoint() { }

		//// RVA: 0xEFC4FC Offset: 0xEFC4FC VA: 0xEFC4FC
		private void GetRoot()
		{
			Transform t = transform;
			while(t != null)
			{
				if (t.GetComponent<Canvas>() != null)
					m_root = t.GetComponent<RectTransform>();
				t = t.parent;
			}
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6DB01C Offset: 0x6DB01C VA: 0x6DB01C
		//// RVA: 0xEFCB08 Offset: 0xEFCB08 VA: 0xEFCB08
		//private void <SetItemImage>b__53_0(IiconTexture icon) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DB02C Offset: 0x6DB02C VA: 0x6DB02C
		//// RVA: 0xEFCC0C Offset: 0xEFCC0C VA: 0xEFCC0C
		//private void <SetEpiItemImage>b__54_0(IiconTexture icon) { }
	}
}
