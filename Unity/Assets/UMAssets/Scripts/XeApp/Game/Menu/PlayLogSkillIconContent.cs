using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PlayLogSkillIconContent : SwapScrollListContent
	{
		[SerializeField] // RVA: 0x6791BC Offset: 0x6791BC VA: 0x6791BC
		private RawImageEx[] m_LiveSkillIconImages; // 0x20
		[SerializeField] // RVA: 0x6791CC Offset: 0x6791CC VA: 0x6791CC
		private StayForReleaseButton m_stayForReleseButton; // 0x24
		private AbsoluteLayout m_skillIconEnableAnim; // 0x28
		private AbsoluteLayout m_skillIconChangeAnim; // 0x2C
		private AbsoluteLayout[] m_activeIconEnableAnim = new AbsoluteLayout[2]; // 0x30
		private UnityEvent m_iconPointerDown = new UnityEvent(); // 0x38
		private UnityEvent m_iconPointerUp = new UnityEvent(); // 0x3C
		private Matrix23 m_identity; // 0x40

		public int SkillId { get; set; } // 0x34
		public UnityEvent IconPointerDown { get { return m_iconPointerDown; } } //0xDE2728
		public UnityEvent IconPointerUp { get { return m_iconPointerUp; } } //0xDE2730

		// RVA: 0xDE2738 Offset: 0xDE2738 VA: 0xDE2738 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_skillIconEnableAnim = layout.FindViewByExId("swtbl_log_skill_icon_sw_playlog_skill_change_anim") as AbsoluteLayout;
			m_skillIconChangeAnim = layout.FindViewByExId("sw_playlog_skill_change_anim_sw_log_skill_icon_01") as AbsoluteLayout;
			m_activeIconEnableAnim[0] = layout.FindViewByExId("sw_playlog_skill_change_anim_sw_log_skill_icon_01") as AbsoluteLayout;
			m_activeIconEnableAnim[1] = layout.FindViewByExId("sw_playlog_skill_change_anim_sw_log_skill_icon_02") as AbsoluteLayout;
			m_stayForReleseButton.ClearOnStayCallback();
			m_stayForReleseButton.AddOnStayCallback(() =>
			{
				//0xDE306C
				this.StartCoroutineWatched(Co_StayButton());
			});
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x706E1C Offset: 0x706E1C VA: 0x706E1C
		//// RVA: 0xDE2B30 Offset: 0xDE2B30 VA: 0xDE2B30
		private IEnumerator Co_StayButton()
		{
			//0xDE3094
			m_iconPointerDown.Invoke();
			yield return null;
			while (!m_stayForReleseButton.isRelease)
				yield return null;
			m_iconPointerUp.Invoke();
			yield return null;
		}

		//// RVA: 0xDE2BDC Offset: 0xDE2BDC VA: 0xDE2BDC
		public void SetSkillIconImage(int index, Rect rect)
		{
			m_LiveSkillIconImages[index].uvRect = rect;
		}

		//// RVA: 0xDE2C6C Offset: 0xDE2C6C VA: 0xDE2C6C
		public void SetActiveIconEnable(int index, bool enable)
		{
			m_activeIconEnableAnim[index].StartAllAnimGoStop(enable ? "01" : "02");
			AnimationUpdate(m_activeIconEnableAnim[index]);
		}

		//// RVA: 0xDE2E54 Offset: 0xDE2E54 VA: 0xDE2E54
		public void SetCrossFade(bool isCrossFade)
		{
			if(isCrossFade)
			{
				m_skillIconChangeAnim.StartSiblingAnimLoop("logo_act", "loen_act");
			}
			else
			{
				m_skillIconChangeAnim.StartSiblingAnimLoop("st_wait");
			}
			AnimationUpdate(m_skillIconChangeAnim);
		}

		//// RVA: 0xDE2F18 Offset: 0xDE2F18 VA: 0xDE2F18
		public void SetIconEnable(bool enable)
		{
			m_skillIconEnableAnim.StartSiblingAnimGoStop(enable ? "01" : "02");
			AnimationUpdate(m_skillIconEnableAnim);
		}

		//// RVA: 0xDE2D7C Offset: 0xDE2D7C VA: 0xDE2D7C
		public void AnimationUpdate(AbsoluteLayout layout)
		{
			layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			layout.UpdateAll(m_identity, Color.white);
		}
	}
}
