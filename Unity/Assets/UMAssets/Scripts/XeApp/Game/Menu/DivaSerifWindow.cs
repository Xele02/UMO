using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaSerifWindow : LayoutUGUIScriptBase
	{
		public enum Type
		{
			Serif = 0,
			MusicRate = 1,
		}

		[SerializeField]
		private Text m_textTitle; // 0x14
		[SerializeField]
		private Text m_textMessage; // 0x18
		[SerializeField]
		private RawImageEx m_imageItemIcon; // 0x1C
		[SerializeField]
		private RawImageEx m_imageMusicrateIcon; // 0x20
		[SerializeField]
		private Text m_textMusicrateGrade; // 0x24
		[SerializeField]
		private Text m_textMusicrateRate; // 0x28
		[SerializeField]
		private Text m_textMusicrateRank; // 0x2C
		[SerializeField]
		private Text m_textMusicrateRankUnit; // 0x30
		[SerializeField]
		private Text m_textNoItem; // 0x34
		[SerializeField]
		private ActionButton m_btnMusicrateDetail; // 0x38
		[SerializeField]
		private ActionButton m_btnChangeWindow; // 0x3C
		private AbsoluteLayout m_layoutRoot; // 0x40
		private AbsoluteLayout m_animChangeWindow; // 0x44
		private AbsoluteLayout m_animItemIcon; // 0x48
		private Coroutine m_coroutine; // 0x4C

		public DivaSerifWindow.Type WindowType { get; set; } // 0x50
		public bool IsOpen { get; private set; } // 0x54

		// RVA: 0x1265500 Offset: 0x1265500 VA: 0x1265500
		private void OnDisable()
		{
			if(m_coroutine != null)
			{
				this.StopCoroutineWatched(m_coroutine);
				m_coroutine = null;
				Hide();
			}
		}

		// RVA: 0x12655EC Offset: 0x12655EC VA: 0x12655EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_cmn_balloon_sw_balloon_home_anim") as AbsoluteLayout;
			m_animChangeWindow = layout.FindViewByExId("sw_cmn_balloon_anim_sw_cmn_balloon_base") as AbsoluteLayout;
			m_animItemIcon = layout.FindViewByExId("sw_cmn_item_onoff_anim_cmn_item") as AbsoluteLayout;
			WindowType = Type.Serif;
			Loaded();
			return true;
		}

		// // RVA: 0x12657C0 Offset: 0x12657C0 VA: 0x12657C0
		public void Enter()
		{
			if(IsOpen)
				return;
			gameObject.SetActive(true);
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			IsOpen = true;
		}

		// // RVA: 0x1265890 Offset: 0x1265890 VA: 0x1265890
		// public void Leave() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CC514 Offset: 0x6CC514 VA: 0x6CC514
		// // RVA: 0x12658F8 Offset: 0x12658F8 VA: 0x12658F8
		// private IEnumerator Co_Leave() { }

		// // RVA: 0x1265538 Offset: 0x1265538 VA: 0x1265538
		public void Hide()
		{
			gameObject.SetActive(false);
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
			IsOpen = false;
		}

		// // RVA: 0x12659A4 Offset: 0x12659A4 VA: 0x12659A4
		// public void Stop() { }

		// // RVA: 0x1265A50 Offset: 0x1265A50 VA: 0x1265A50
		public void SetTitle(string title)
		{
			m_textTitle.text = title;
		}

		// // RVA: 0x1265A8C Offset: 0x1265A8C VA: 0x1265A8C
		public void SetText(string text)
		{
			if(!gameObject.activeSelf)
				Enter();
			m_textMessage.text = text;
		}

		// // RVA: 0x1265B00 Offset: 0x1265B00 VA: 0x1265B00
		// public void ChangeWindow(DivaSerifWindow.Type a_type, bool a_fixed = False) { }

		// // RVA: 0x1265C90 Offset: 0x1265C90 VA: 0x1265C90
		// public void SetMusicRate(int a_musicrate, HighScoreRatingRank.Type a_musicgrade, int a_musicrate_ranking, int a_item) { }

		// // RVA: 0x1266174 Offset: 0x1266174 VA: 0x1266174
		// public ActionButton GetButtonMusicRateDetail() { }

		// // RVA: 0x126617C Offset: 0x126617C VA: 0x126617C
		// public ActionButton GetButtonChangeWindow() { }
	}
}
