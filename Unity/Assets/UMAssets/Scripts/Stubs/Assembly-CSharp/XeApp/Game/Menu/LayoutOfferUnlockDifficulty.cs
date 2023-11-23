using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutOfferUnlockDifficulty : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text PopupMessage; // 0x14
		private AbsoluteLayout m_Title; // 0x18
		private AbsoluteLayout m_PreDiff; // 0x1C
		private AbsoluteLayout m_NextDiff; // 0x20

		// RVA: 0x15D5EEC Offset: 0x15D5EEC VA: 0x15D5EEC
		private void Start()
		{
			return;
		}

		// RVA: 0x15D5EF0 Offset: 0x15D5EF0 VA: 0x15D5EF0
		private void Update()
		{
			return;
		}

		// RVA: 0x15D5EF4 Offset: 0x15D5EF4 VA: 0x15D5EF4
		public void Setup(string Msg, int preDiff, int nextDiff)
		{
			PopupMessage.text = Msg;
			m_PreDiff.StartChildrenAnimGoStop(preDiff.ToString("D2"));
			m_NextDiff.StartChildrenAnimGoStop(nextDiff.ToString("D2"));
		}

		// RVA: 0x15D5FFC Offset: 0x15D5FFC VA: 0x15D5FFC
		public void TitleEnter()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_Title.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(TitleLoopAnimStart());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70A1BC Offset: 0x70A1BC VA: 0x70A1BC
		//// RVA: 0x15D60EC Offset: 0x15D60EC VA: 0x15D60EC
		public IEnumerator TitleLoopAnimStart()
		{
			//0x15D6380
			yield return null;
			while (m_Title.IsPlaying())
				yield return null;
			m_Title.StartChildrenAnimLoop("logo_up");
		}

		// RVA: 0x15D6198 Offset: 0x15D6198 VA: 0x15D6198 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_PreDiff = layout.FindViewByExId("sw_pop_vfo_01_swtbl_lv_icon_01") as AbsoluteLayout;
			m_NextDiff = layout.FindViewByExId("sw_pop_vfo_01_swtbl_lv_icon_02") as AbsoluteLayout;
			m_Title = layout.FindViewByExId("sw_pop_vfo_01_sw_pop_vfo_title_01_anim") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
