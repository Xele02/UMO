using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using mcrs;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class DegreeSelectLayout : LayoutUGUIScriptBase
	{
		public class DegreeInfo
		{
			public RawImageEx image; // 0x8
			public Text name; // 0xC
			public ActionButton btn; // 0x10
		}

		[SerializeField]
		private Text m_current_window_title; // 0x14
		[SerializeField]
		private Text m_select_window_title; // 0x18
		private AbsoluteLayout m_abs; // 0x1C
		private Transform m_content; // 0x20
		private DegreeInfo m_set_degree = new DegreeInfo(); // 0x24
		private DegreeInfo m_select_degree = new DegreeInfo(); // 0x28
		private ActionButton m_set_btn; // 0x2C
		private NumberBase m_degree_mol; // 0x30
		private DegreeSetPopupSetting m_degree_setting = new DegreeSetPopupSetting(); // 0x34
		private List<IAPDFOPPGND> m_degree_list = new List<IAPDFOPPGND>(); // 0x38
		private List<DegreeSelectDegreeButton> m_button_list = new List<DegreeSelectDegreeButton>(); // 0x3C
		private DegreeSelectNoneBtn m_none_btn; // 0x40
		private const int BUTTON_W = 325;
		private const int BUTTON_H = 90;
		private const int LEFT_SPACE = 10;
		private const int SCROLL_SPACE = 20;
		private int m_set_btn_index; // 0x44
		private int m_select_btn_index; // 0x48
		private int m_start_view_icon_index; // 0x4C
		private float m_old_scroll_pos; // 0x50
		private const int PAGE_LINE = 4;
		private const int PAGE_COLUMN = 2;
		private const int PAGE_MAX_ICON = 8;
		private const int NAME_LIMIT_ROWS = 2;
		private Action m_updater; // 0x54

		// RVA: 0x11E39A0 Offset: 0x11E39A0 VA: 0x11E39A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_sel_degree") as AbsoluteLayout;
			m_content = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_degree_window (AbsoluteLayout)/sc_space (ScrollView)/Content");
			DegreeInfo[] dlist = new DegreeInfo[2]
			{
				m_set_degree, m_select_degree
			};
			string[] slist = new string[2]
			{
				"sw_sel_degree_set (AbsoluteLayout)",
				"sw_sel_degree_select (AbsoluteLayout)"
			};
			for(int i = 0; i < dlist.Length; i++)
			{
				Transform t = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_deg_l (AbsoluteLayout)").Find(slist[i]);
				dlist[i].image = t.Find("cmn_degree_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
				dlist[i].name = t.Find("name_00 (TextView)").GetComponent<Text>();
				dlist[i].btn = t.Find("cmn_btn_b_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			}
			m_degree_mol = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_degree_window (AbsoluteLayout)/swnum_cmn_num_l (AbsoluteLayout)").GetComponent<NumberBase>();
			m_set_btn = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_deg_l (AbsoluteLayout)/sw_sel_degree_select (AbsoluteLayout)/cmn_btn_p_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			this.StartCoroutineWatched(LoadDegreeInfoWindow());
			m_set_degree.btn.AddOnClickCallback(() =>
			{
				//0x11E69AC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OnClickInfoBtn(m_set_btn_index);
			});
			m_select_degree.btn.AddOnClickCallback(() =>
			{
				//0x11E6A14
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OnClickInfoBtn(m_select_btn_index);
			});
			m_set_btn.AddOnClickCallback(() =>
			{
				//0x11E6A7C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				OnClickSetBtn();
			});
			for(int i = 0; i < 24; i++)
			{
				this.StartCoroutineWatched(LoadDegreeButton());
			}
			this.StartCoroutineWatched(LoadDegreeNoneButton());
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x11E4354 Offset: 0x11E4354 VA: 0x11E4354
		private void Start()
		{
			return;
		}

		// RVA: 0x11E4358 Offset: 0x11E4358 VA: 0x11E4358
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x11E436C Offset: 0x11E436C VA: 0x11E436C
		private void UpdateLoad()
		{
			TodoLogger.Log(0, "UpdateLoad");
		}

		//// RVA: 0x11E4590 Offset: 0x11E4590 VA: 0x11E4590
		//private void UpdateIdle() { }

		//// RVA: 0x11E4F28 Offset: 0x11E4F28 VA: 0x11E4F28
		public void Enter()
		{
			TodoLogger.Log(0, "Enter");
		}

		//// RVA: 0x11E4FB4 Offset: 0x11E4FB4 VA: 0x11E4FB4
		public void Leave()
		{
			TodoLogger.Log(0, "Leave");
		}

		//// RVA: 0x11E5040 Offset: 0x11E5040 VA: 0x11E5040
		public void Init(bool allDebug = false)
		{
			TodoLogger.Log(0, "Init");
		}

		//// RVA: 0x11E5AAC Offset: 0x11E5AAC VA: 0x11E5AAC
		//private bool IsNothingEmblem(int emblemId) { }

		//// RVA: 0x11E5ABC Offset: 0x11E5ABC VA: 0x11E5ABC
		public void SetCurrentWindowTitle(string title)
		{
			TodoLogger.Log(0, "SetCurrentWindowTitle");
		}

		//// RVA: 0x11E5AF8 Offset: 0x11E5AF8 VA: 0x11E5AF8
		public void SetSelectWindowTitle(string title)
		{
			TodoLogger.Log(0, "SetSelectWindowTitle");
		}

		//// RVA: 0x11E5470 Offset: 0x11E5470 VA: 0x11E5470
		//private int GetDegreeListIndex(int id) { }

		//// RVA: 0x11E4674 Offset: 0x11E4674 VA: 0x11E4674
		//public void UpdateDegreeBtn() { }

		//// RVA: 0x11E5B34 Offset: 0x11E5B34 VA: 0x11E5B34
		//private void SetActiveBtn(int index, bool active) { }

		//// RVA: 0x11E5C0C Offset: 0x11E5C0C VA: 0x11E5C0C
		//private void SetSelectAnimBtn(int index, bool active) { }

		//// RVA: 0x11E5CE0 Offset: 0x11E5CE0 VA: 0x11E5CE0
		//private void SetIconBtn(int index, bool enable) { }

		//// RVA: 0x11E5558 Offset: 0x11E5558 VA: 0x11E5558
		//private void InitSetDegree(int index) { }

		//// RVA: 0x11E57A0 Offset: 0x11E57A0 VA: 0x11E57A0
		//private void InitSelectDegree(int index) { }

		//// RVA: 0x11E604C Offset: 0x11E604C VA: 0x11E604C
		public bool IsPlaying()
		{
			TodoLogger.Log(0, "IsPlaying");
			return false;
		}

		//// RVA: 0x11E5D8C Offset: 0x11E5D8C VA: 0x11E5D8C
		//public void SetDegreeImage(int degree_no) { }

		//// RVA: 0x11E5EEC Offset: 0x11E5EEC VA: 0x11E5EEC
		//public void SetSelectDegreeImage(int degree_no) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FD384 Offset: 0x6FD384 VA: 0x6FD384
		//// RVA: 0x11E41BC Offset: 0x11E41BC VA: 0x11E41BC
		private IEnumerator LoadDegreeInfoWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x17CDE5C
			operation = AssetBundleManager.LoadLayoutAsync(m_degree_setting.BundleName, m_degree_setting.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.m_font, (GameObject instance) =>
			{
				//0x11E6D64
				m_degree_setting.SetContent(instance);
			}));
			m_degree_setting.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_degree_setting.BundleName);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD3FC Offset: 0x6FD3FC VA: 0x6FD3FC
		//// RVA: 0x11E4244 Offset: 0x11E4244 VA: 0x11E4244
		private IEnumerator LoadDegreeButton()
		{
			TodoLogger.Log(0, "LoadDegreeButton");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD474 Offset: 0x6FD474 VA: 0x6FD474
		//// RVA: 0x11E42CC Offset: 0x11E42CC VA: 0x11E42CC
		private IEnumerator LoadDegreeNoneButton()
		{
			TodoLogger.Log(0, "LoadDegreeNoneButton");
			yield return null;
		}

		//// RVA: 0x11E6078 Offset: 0x11E6078 VA: 0x11E6078
		private void OnClickInfoBtn(int index)
		{
			TodoLogger.LogNotImplemented("OnClickInfoBtn");
		}

		//// RVA: 0x11E64EC Offset: 0x11E64EC VA: 0x11E64EC
		//private void OnClickDegreeBtn(int index) { }

		//// RVA: 0x11E64F4 Offset: 0x11E64F4 VA: 0x11E64F4
		private void OnClickSetBtn()
		{
			TodoLogger.LogNotImplemented("OnClickSetBtn");
		}

		//// RVA: 0x11E678C Offset: 0x11E678C VA: 0x11E678C
		//private void WaitAllBtnAnim() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FD51C Offset: 0x6FD51C VA: 0x6FD51C
		//// RVA: 0x11E6AE0 Offset: 0x11E6AE0 VA: 0x11E6AE0
		//private void <UpdateLoad>b__29_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FD52C Offset: 0x6FD52C VA: 0x6FD52C
		//// RVA: 0x11E6B7C Offset: 0x11E6B7C VA: 0x11E6B7C
		//private void <SetDegreeImage>b__45_0(IiconTexture icon) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FD53C Offset: 0x6FD53C VA: 0x6FD53C
		//// RVA: 0x11E6C70 Offset: 0x11E6C70 VA: 0x11E6C70
		//private void <SetSelectDegreeImage>b__46_0(IiconTexture icon) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FD55C Offset: 0x6FD55C VA: 0x6FD55C
		//// RVA: 0x11E6D98 Offset: 0x11E6D98 VA: 0x11E6D98
		//private void <LoadDegreeButton>b__48_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FD56C Offset: 0x6FD56C VA: 0x6FD56C
		//// RVA: 0x11E6E8C Offset: 0x11E6E8C VA: 0x11E6E8C
		//private void <LoadDegreeNoneButton>b__49_0(GameObject instance) { }
	}
}
