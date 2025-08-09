using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace XeApp.Game.RhythmGame
{
	public class GameUIIntro : LayoutLabelScriptBase
	{
		[SerializeField]
		private MusicNameLabel m_musicName; // 0x18
		[SerializeField]
		private Text m_sub_text; // 0x1C
		private LayoutSymbolData m_symbolMain; // 0x20
		private LayoutSymbolData m_symbolSub; // 0x24
		private Coroutine m_coWaitEnterEnd; // 0x28

		public Action onAnimationEndCallback { private get; set; } // 0x2C

		// RVA: 0xF76150 Offset: 0xF76150 VA: 0xF76150 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolSub = CreateSymbol("mission", layout);
			gameObject.SetActive(false);
			Loaded();
			return true;
		}

		//// RVA: 0xF76240 Offset: 0xF76240 VA: 0xF76240
		public void Enter(int musicNameId, string a_sub_text = "")
		{
			m_musicName.SetMusicId(musicNameId);
			if(RuntimeSettings.CurrentSettings.Language != "en" && RuntimeSettings.CurrentSettings.Language != "fr" )
			{
				m_sub_text.text = a_sub_text.Replace("\n", "").Replace("\r", "");
			}
			else
			{
				m_sub_text.text = a_sub_text.Replace("\n", " ").Replace("\r", "").Replace("  ", " ");
			}
			gameObject.SetActive(true);
			Play("enter_title", false);
		}

		// RVA: 0xF766A0 Offset: 0xF766A0 VA: 0xF766A0
		public void DoIntro()
		{
			Play("enter", true);
		}

		//// RVA: 0xF76584 Offset: 0xF76584 VA: 0xF76584
		private void Play(string label, bool isInactive)
		{
			if (m_coWaitEnterEnd != null)
				this.StopCoroutineWatched(m_coWaitEnterEnd);
			m_symbolMain.StartAnim(label);
			if(m_sub_text.text != "")
			{
				m_symbolSub.StartAnim(label);
			}
			m_coWaitEnterEnd = this.StartCoroutineWatched(Co_WaitEnterEnd(isInactive));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x746ACC Offset: 0x746ACC VA: 0x746ACC
		//								// RVA: 0xF76708 Offset: 0xF76708 VA: 0xF76708
		private IEnumerator Co_WaitEnterEnd(bool isInactive)
		{
			//0xF767DC
			while (m_symbolMain.IsPlaying())
				yield return null;
			if (onAnimationEndCallback != null)
				onAnimationEndCallback();
			if (isInactive)
				gameObject.SetActive(false);
		}
	}
}
