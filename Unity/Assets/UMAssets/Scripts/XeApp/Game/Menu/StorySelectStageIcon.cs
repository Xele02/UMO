using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class StorySelectStageIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private bool m_is_large; // 0x11
		[SerializeField]
		private RawImageEx m_jacket; // 0x14
		[SerializeField]
		private ActionButton m_action_btn; // 0x18
		[SerializeField]
		private GameObject m_newPos; // 0x1C
		[SerializeField]
		private RawImageEx[] m_stamp; // 0x20
		[SerializeField]
		private RawImage m_noizeImage; // 0x24
		private AbsoluteLayout m_stage_icon; // 0x28
		private AbsoluteLayout m_base_type; // 0x2C
		private AbsoluteLayout m_icon_tbl; // 0x30
		private AbsoluteLayout m_effect_abs; // 0x34
		private AbsoluteLayout m_iconStatusTbl; // 0x38
		private AbsoluteLayout m_noiseAnim; // 0x3C
		private AbsoluteLayout m_stampAnim; // 0x40
		private TexUVList m_texUvList; // 0x48
		private CompatibleLayoutAnimeParam m_syncEmphasisAnimParam; // 0x4C
		private bool m_isPlayEmphasis; // 0x58

		public LIEJFHMGNIA viewStageData { get; set; } // 0x44

		//// RVA: 0x1A86410 Offset: 0x1A86410 VA: 0x1A86410
		public GameObject GetNewPos()
		{
			return m_newPos;
		}

		//// RVA: 0x1A94FD8 Offset: 0x1A94FD8 VA: 0x1A94FD8
		//public RawImage GetNoizeImage() { }

		// RVA: 0x1A94FE0 Offset: 0x1A94FE0 VA: 0x1A94FE0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(!m_is_large)
			{
				m_stage_icon = layout.FindViewByExId("root_story_musuc_sw_music") as AbsoluteLayout;
				m_iconStatusTbl = layout.FindViewByExId("sw_music_s_anim_swtbl_music_s") as AbsoluteLayout;
			}
			else
			{
				m_stage_icon = layout.FindViewByExId("root_story_musuc_l_sw_music_l") as AbsoluteLayout;
				m_icon_tbl = layout.FindViewByExId("sw_music_l_anim_swtbl_sel_st_icon") as AbsoluteLayout;
				m_effect_abs = layout.FindViewByExId("sw_music_l_anim_sw_music_glow_anim") as AbsoluteLayout;
				m_noiseAnim = layout.FindViewByExId("sw_music_l_anim_sw_music_l_noise_anim") as AbsoluteLayout;
				m_stampAnim = layout.FindViewByExId("sw_music_l_anim_sw_music_l_get_anim") as AbsoluteLayout;
				m_texUvList = uvMan.GetTexUVList("sel_story_pack");
			}
			m_base_type = layout.FindViewByExId("sel_st_music_swtbl_s_s_music_cd_jakt") as AbsoluteLayout;
			m_stage_icon.StartChildrenAnimGoStop("st_non");
			Loaded();
			return true;
		}

		// RVA: 0x1A95464 Offset: 0x1A95464 VA: 0x1A95464
		private void Update()
		{
			if (!m_isPlayEmphasis || m_effect_abs == null)
				return;
			int frame = m_syncEmphasisAnimParam.UpdateFrame(TimeWrapper.deltaTime);
			m_effect_abs.StartChildrenAnimGoStop(frame, frame);
		}

		//// RVA: 0x1A954D4 Offset: 0x1A954D4 VA: 0x1A954D4
		//private bool IsEffect(LIEJFHMGNIA viewData) { }

		//// RVA: 0x1A8AE14 Offset: 0x1A8AE14 VA: 0x1A8AE14
		//public bool IsPlaying() { }

		//// RVA: 0x1A8250C Offset: 0x1A8250C VA: 0x1A8250C
		public void SetStatus()
		{
			m_isPlayEmphasis = false;
			gameObject.SetActive(true);
			SetButtonEnable(false);
			bool enable = false;
			if (!viewStageData.BCGLDMKODLC)
			{
				if (!viewStageData.NDLKPJDHHCN && !viewStageData.DHPNLACAGPG)
					enable = !viewStageData.PGCCOCKGCKO;
			}
			else
				enable = true;
			SetButtonEnable(enable);
			ChangeBaseType(viewStageData.FKDCCLPGKDK_JacketAttr - 1);
			SetTexture();
			ChangeIconType();
			SetWaitAnim(viewStageData);
		}

		//// RVA: 0x1A8FD84 Offset: 0x1A8FD84 VA: 0x1A8FD84
		//public void SetNoiseEnable(bool enable) { }

		//// RVA: 0x1A82DA4 Offset: 0x1A82DA4 VA: 0x1A82DA4
		//public void SetPosition(Vector3 pos) { }

		//// RVA: 0x1A95514 Offset: 0x1A95514 VA: 0x1A95514
		//public void ChangeBaseType(int type) { }

		//// RVA: 0x1A9579C Offset: 0x1A9579C VA: 0x1A9579C
		//public void ChangeIconType() { }

		//// RVA: 0x1A95EC0 Offset: 0x1A95EC0 VA: 0x1A95EC0
		//public void SetStamp(int divaId) { }

		//// RVA: 0x1A8A9FC Offset: 0x1A8A9FC VA: 0x1A8A9FC
		public void SetButtonEnable(bool enable)
		{
			if (m_action_btn != null)
				m_action_btn.enabled = enable;
		}

		//// RVA: 0x1A908E4 Offset: 0x1A908E4 VA: 0x1A908E4
		//public void SetButtonStatus() { }

		//// RVA: 0x1A8261C Offset: 0x1A8261C VA: 0x1A8261C
		//public void SetCallback(Action callback) { }

		//// RVA: 0x1A9554C Offset: 0x1A9554C VA: 0x1A9554C
		//public void SetTexture() { }

		//// RVA: 0x1A863B8 Offset: 0x1A863B8 VA: 0x1A863B8
		public void ButtonEmphasis()
		{
			if (!m_is_large)
				return;
			if(m_effect_abs != null && viewStageData != null)
			{
				if(!viewStageData.PGCCOCKGCKO && !viewStageData.BCGLDMKODLC)
				{
					m_isPlayEmphasis = true;
					m_syncEmphasisAnimParam.Initialize(1, 74);
				}
			}
		}

		//// RVA: 0x1A96214 Offset: 0x1A96214 VA: 0x1A96214
		//public void ButtonDecide() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72D0F4 Offset: 0x72D0F4 VA: 0x72D0F4
		//// RVA: 0x1A962C8 Offset: 0x1A962C8 VA: 0x1A962C8
		//private IEnumerator ButtonDecideWait() { }

		//// RVA: 0x1A95468 Offset: 0x1A95468 VA: 0x1A95468
		//private void UpdateEmphasis() { }

		//// RVA: 0x1A88254 Offset: 0x1A88254 VA: 0x1A88254
		//public void In(StorySelectStageCreater.EffectType effectType) { }

		//// RVA: 0x1A966D4 Offset: 0x1A966D4 VA: 0x1A966D4
		//public void Out() { }

		//// RVA: 0x1A8800C Offset: 0x1A8800C VA: 0x1A8800C
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x1A83B40 Offset: 0x1A83B40 VA: 0x1A83B40
		public void Hide(bool isNone = true)
		{
			if (m_stage_icon != null && isNone)
				m_stage_icon.StartChildrenAnimGoStop("st_non");
			gameObject.SetActive(false);
		}

		//// RVA: 0x1A958A4 Offset: 0x1A958A4 VA: 0x1A958A4
		//private void SetWaitAnim(LIEJFHMGNIA viewData) { }

		//// RVA: 0x1A96374 Offset: 0x1A96374 VA: 0x1A96374
		//private void PlayAnimInner(StorySelectStageCreater.EffectType effectType, LIEJFHMGNIA viewData) { }

		//// RVA: 0x1A83F24 Offset: 0x1A83F24 VA: 0x1A83F24
		//public void NoneIcon() { }

		//// RVA: 0x1A83E60 Offset: 0x1A83E60 VA: 0x1A83E60
		//public void LockIcon() { }

		//// RVA: 0x1A94AEC Offset: 0x1A94AEC VA: 0x1A94AEC
		//public void LockAppearIn() { }

		//// RVA: 0x1A94C18 Offset: 0x1A94C18 VA: 0x1A94C18
		//public void AppearIn() { }

		//// RVA: 0x1A94A00 Offset: 0x1A94A00 VA: 0x1A94A00
		//public void ShrinkingIn() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72D16C Offset: 0x72D16C VA: 0x72D16C
		//// RVA: 0x1A93814 Offset: 0x1A93814 VA: 0x1A93814
		//public IEnumerator StampPressAnim() { }

		//// RVA: 0x1A966F8 Offset: 0x1A966F8 VA: 0x1A966F8
		//private void SetStampDiva() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72D1E4 Offset: 0x72D1E4 VA: 0x72D1E4
		//// RVA: 0x1A96804 Offset: 0x1A96804 VA: 0x1A96804
		//private void <SetTexture>b__35_0(IiconTexture icon) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72D1F4 Offset: 0x72D1F4 VA: 0x72D1F4
		//// RVA: 0x1A968E4 Offset: 0x1A968E4 VA: 0x1A968E4
		//private void <SetTexture>b__35_1(IiconTexture icon) { }
	}
}
