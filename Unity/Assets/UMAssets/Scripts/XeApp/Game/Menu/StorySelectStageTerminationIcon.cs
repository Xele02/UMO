using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class StorySelectStageTerminationIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_action_btn; // 0x14
		[SerializeField]
		private GameObject m_newPos; // 0x18
		private AbsoluteLayout m_stage_icon; // 0x1C

		public LIEJFHMGNIA viewStageData { get; set; } // 0x20

		// RVA: 0x1A96EB4 Offset: 0x1A96EB4 VA: 0x1A96EB4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_stage_icon = layout.FindViewByExId("root_story_termnal_sw_music_term_anim") as AbsoluteLayout;
			m_stage_icon.StartChildrenAnimGoStop("st_non");
			Loaded();
			return true;
		}

		//// RVA: 0x1A8F0BC Offset: 0x1A8F0BC VA: 0x1A8F0BC
		public bool IsPlaying()
		{
			return m_stage_icon != null && m_stage_icon.IsPlayingChildren();
		}

		//// RVA: 0x1A82784 Offset: 0x1A82784 VA: 0x1A82784
		public void SetStatus()
		{
			gameObject.SetActive(true);
			SetButtonEnable(false);
			if (!viewStageData.NDLKPJDHHCN_NotShown)
				SetButtonEnable(true);
			SetWaitAnim(viewStageData);
		}

		//// RVA: 0x1A82E8C Offset: 0x1A82E8C VA: 0x1A82E8C
		public void SetPosition(Vector3 pos)
		{
			GetComponent<RectTransform>().anchoredPosition = pos;
		}

		//// RVA: 0x1A8ABA8 Offset: 0x1A8ABA8 VA: 0x1A8ABA8
		public void SetButtonEnable(bool enable)
		{
			if (m_action_btn != null)
				m_action_btn.enabled = enable;
		}

		//// RVA: 0x1A9705C Offset: 0x1A9705C VA: 0x1A9705C
		//public void SetButtonStatus() { }

		//// RVA: 0x1A82804 Offset: 0x1A82804 VA: 0x1A82804
		public void SetCallback(Action callback)
		{
			if (m_action_btn == null)
				return;
			m_action_btn.ClearOnClickCallback();
			m_action_btn.AddOnClickCallback(() =>
			{
				//0x1A972EC
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x1A8824C Offset: 0x1A8824C VA: 0x1A8824C
		public void In(StorySelectStageCreater.EffectType effectType)
		{
			PlayAnimInner(effectType, viewStageData);
		}

		//// RVA: 0x1A97174 Offset: 0x1A97174 VA: 0x1A97174
		//public void Out() { }

		//// RVA: 0x1A88044 Offset: 0x1A88044 VA: 0x1A88044
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x1A83DB4 Offset: 0x1A83DB4 VA: 0x1A83DB4
		public void Hide(bool isNone = true)
		{
			if (m_stage_icon != null && isNone)
				m_stage_icon.StartChildrenAnimGoStop("st_non");
			gameObject.SetActive(false);
		}

		//// RVA: 0x1A96FB8 Offset: 0x1A96FB8 VA: 0x1A96FB8
		private void SetWaitAnim(LIEJFHMGNIA viewData)
		{
			if (viewData == null || m_stage_icon == null)
				return;
			if (!viewData.NDLKPJDHHCN_NotShown || viewData.ENEKMHMKNFK)
				m_stage_icon.StartChildrenAnimGoStop("st_wait");
			else
				m_stage_icon.StartChildrenAnimGoStop("st_non");
		}

		//// RVA: 0x1A9706C Offset: 0x1A9706C VA: 0x1A9706C
		private void PlayAnimInner(StorySelectStageCreater.EffectType effectType, LIEJFHMGNIA viewData)
		{
			if (viewData == null || m_stage_icon == null)
				return;
			if(effectType == StorySelectStageCreater.EffectType.UPDATE)
			{
				m_stage_icon.StartChildrenAnimGoStop("go_bot_act_03", "st_bot_act_03");
			}
			else if(effectType == StorySelectStageCreater.EffectType.APPEAR)
			{
				m_stage_icon.StartChildrenAnimGoStop("go_bot_act", "st_bot_act");
			}
			else
				return;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_STORY_000);
		}

		//// RVA: 0x1A97178 Offset: 0x1A97178 VA: 0x1A97178
		//public void NoneIcon() { }

		//// RVA: 0x1A971E8 Offset: 0x1A971E8 VA: 0x1A971E8
		//public void LockIcon() { }

		//// RVA: 0x1A94D78 Offset: 0x1A94D78 VA: 0x1A94D78
		public void LockAppearIn()
		{
			m_stage_icon.StartChildrenAnimGoStop("go_bot_act", "st_bot_act");
		}

		//// RVA: 0x1A97264 Offset: 0x1A97264 VA: 0x1A97264
		//public void AppearIn() { }

		//// RVA: 0x1A94CF8 Offset: 0x1A94CF8 VA: 0x1A94CF8
		public void ShrinkingIn()
		{
			m_stage_icon.StartChildrenAnimGoStop("st_bot_act_02", "go_bot_act_02");
		}
	}
}
