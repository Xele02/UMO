using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class StorySelectStageCompleteIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_actionBtn; // 0x14
		[SerializeField]
		private GameObject m_newPos; // 0x18
		private AbsoluteLayout m_stageIcon; // 0x1C

		public LIEJFHMGNIA viewStageData { get; set; } // 0x20

		// RVA: 0x12E8238 Offset: 0x12E8238 VA: 0x12E8238 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_stageIcon = layout.FindViewByExId("root_story_comp_sw_comp_anim") as AbsoluteLayout;
			NoneIcon();
			Loaded();
			return true;
		}

		//// RVA: 0x12E8388 Offset: 0x12E8388 VA: 0x12E8388
		public bool IsPlaying()
		{
			return m_stageIcon != null && m_stageIcon.IsPlayingChildren();
		}

		//// RVA: 0x12E83A0 Offset: 0x12E83A0 VA: 0x12E83A0
		public void SetStatus(bool isComplete)
		{
			gameObject.SetActive(true);
			SetButtonEnable(false);
			if (!viewStageData.NDLKPJDHHCN_NotShown)
				SetButtonEnable(true);
			SetWaitAnim(viewStageData, isComplete);
		}

		//// RVA: 0x12E8578 Offset: 0x12E8578 VA: 0x12E8578
		public void SetPosition(Vector3 pos)
		{
			GetComponent<RectTransform>().anchoredPosition = pos;
		}

		//// RVA: 0x12E8428 Offset: 0x12E8428 VA: 0x12E8428
		public void SetButtonEnable(bool enable)
		{
			if (m_actionBtn != null)
				m_actionBtn.enabled = enable;
		}

		//// RVA: 0x12E8660 Offset: 0x12E8660 VA: 0x12E8660
		//public void SetButtonStatus() { }

		//// RVA: 0x12E8668 Offset: 0x12E8668 VA: 0x12E8668
		public void SetCallback(Action callback)
		{
			if (m_actionBtn == null)
				return;
			m_actionBtn.ClearOnClickCallback();
			m_actionBtn.AddOnClickCallback(() =>
			{
				//0x1A81290
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x12E87B0 Offset: 0x12E87B0 VA: 0x12E87B0
		public void In(StorySelectStageCreater.EffectType effectType)
		{
			PlayAnimInner(effectType, viewStageData);
		}

		//// RVA: 0x12E888C Offset: 0x12E888C VA: 0x12E888C
		//public void Out() { }

		//// RVA: 0x12E8890 Offset: 0x12E8890 VA: 0x12E8890
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x12E88C8 Offset: 0x12E88C8 VA: 0x12E88C8
		public void Hide(bool isNone = true)
		{
			if (m_stageIcon != null && isNone)
				m_stageIcon.StartChildrenAnimGoStop("st_non");
			gameObject.SetActive(false);
		}

		//// RVA: 0x12E84E4 Offset: 0x12E84E4 VA: 0x12E84E4
		private void SetWaitAnim(LIEJFHMGNIA viewData, bool isComplete)
		{
			if (viewData == null || m_stageIcon == null)
				return;
			if (!isComplete)
				NoneIcon();
			else
				m_stageIcon.StartChildrenAnimGoStop("st_wait");
		}

		//// RVA: 0x12E87B8 Offset: 0x12E87B8 VA: 0x12E87B8
		private void PlayAnimInner(StorySelectStageCreater.EffectType effectType, LIEJFHMGNIA viewData)
		{
			if(effectType != StorySelectStageCreater.EffectType.APPEAR)
				return;
			if(m_stageIcon == null || viewData == null)
				return;
			m_stageIcon.StartChildrenAnimGoStop("st_wait");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_STORY_000);
		}

		//// RVA: 0x12E8318 Offset: 0x12E8318 VA: 0x12E8318
		public void NoneIcon()
		{
			if (m_stageIcon != null)
				m_stageIcon.StartChildrenAnimGoStop("st_non");
		}
	}
}
