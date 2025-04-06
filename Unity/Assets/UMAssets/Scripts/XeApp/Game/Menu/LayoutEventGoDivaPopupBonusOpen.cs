using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections;
using XeSys;
using XeApp.Game.Menu.EventGoDiva;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaPopupBonusOpen : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_imageJacket; // 0x14
		[SerializeField]
		private Text m_textBonusTargetTitle; // 0x18
		[SerializeField]
		private Text m_textExpBonus; // 0x1C
		[SerializeField]
		private Text m_textExplain; // 0x20
		private AbsoluteLayout m_layoutTitleType; // 0x24
		private AbsoluteLayout m_layoutTitle; // 0x28
		private AbsoluteLayout m_layoutTitle2; // 0x2C
		private AbsoluteLayout[] m_layoutStatusIcons; // 0x30
		private AbsoluteLayout m_layoutMusicAttr; // 0x34
		private bool m_isJacketLoading; // 0x38
		private AbsoluteLayout m_layoutTitleCurrent; // 0x3C

		public bool IsReady { get { return !m_isJacketLoading; } } //0x19938BC

		// RVA: 0x19938D0 Offset: 0x19938D0 VA: 0x19938D0
		public void Setup(IBJAKJJICBC musicData, BBOPDOIIOGM godivaData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_layoutTitleType != null)
			{
				if(godivaData.GEGAEDDGNMA_Bonuses[0].CGHNCPEKOCK)
				{
					m_layoutTitleType.StartChildrenAnimGoStop("02");
					m_layoutTitleCurrent = m_layoutTitle2;
				}
				else
				{
					m_layoutTitleType.StartChildrenAnimGoStop("01");
					m_layoutTitleCurrent = m_layoutTitle;
				}
			}
			else
				m_layoutTitleCurrent = m_layoutTitle;
			if(m_layoutTitleCurrent != null)
			{
				m_layoutTitleCurrent.StartChildrenAnimGoStop("st_wait");
			}
			m_textBonusTargetTitle.text = bk.GetMessageByLabel("pop_godiva_bonus_open_target_status");
			m_textExplain.text = bk.GetMessageByLabel("pop_godiva_bonus_open_explain");
			SetJacket(musicData.JNCPEGJGHOG_JacketId);
			SetAttr((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
			float v1 = godivaData.HODCLEPALGP(0);
			float v2 = godivaData.HODCLEPALGP(1);
			float v3 = godivaData.HODCLEPALGP(2);
			ExpType exp = (v2 > 1 && v1 > 1 && v3 > 1) ? ExpType.Voice : ExpType.Soul;
			if(exp != ExpType.Soul)
				exp = ExpType.All;
			if(v1 <= 1 && (v2 <= 1 || v1 <= 1) && v3 <= 1)
				exp = ExpType.Voice;
			if(v2 <= 1 && (v1 <= 1 && (v2 <= 1 || v1 <= 1) && v3 <= 1))
				exp = ExpType.None;
			if(v2 <= 1 && (v1 <= 1 && (v2 <= 1 || v1 <= 1) && v3 <= 1) && v3 > 1)
				exp = ExpType.Charm;
			SetBonusTargetStatus(exp);
			float v = v1;
			float vv = v2;
			if(v1 > 1 || (v2 > 1 && v1 > 1 && v3 > 1))
				vv = v;
			v = 1;
			if(v2 > 1 || (v1 > 1 || (v2 > 1 && v1 > 1 && v3 > 1)))
				v = vv;
			if(v2 > 1 || (v1 > 1 || (v2 > 1 && v1 > 1 && v3 > 1)) || v3 <= 1)
				v3 = v;
			SetBonusValue(v3);
		}

		// // RVA: 0x1994148 Offset: 0x1994148 VA: 0x1994148
		// public void PlayTitle() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F164C Offset: 0x6F164C VA: 0x6F164C
		// // RVA: 0x199416C Offset: 0x199416C VA: 0x199416C
		private IEnumerator Co_PlayTitle()
		{
			//0x19948E0
			m_layoutTitleCurrent.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			while(m_layoutTitleCurrent.IsPlayingChildren())
				yield return null;
			m_layoutTitleCurrent.StartChildrenAnimLoop("logo_up", "loen_up");
		}

		// // RVA: 0x1993CB0 Offset: 0x1993CB0 VA: 0x1993CB0
		private void SetJacket(int coverId)
		{
			m_isJacketLoading = true;
			GameManager.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture texture) =>
			{
				//0x19947F4
				texture.Set(m_imageJacket);
				m_isJacketLoading = false;
			});
		}

		// // RVA: 0x1993DC8 Offset: 0x1993DC8 VA: 0x1993DC8
		private void SetAttr(GameAttribute.Type attr)
		{
			m_layoutMusicAttr.StartChildrenAnimGoStop(string.Format("{0:D2}", (int)attr));
		}

		// // RVA: 0x1993E80 Offset: 0x1993E80 VA: 0x1993E80
		private void SetBonusTargetStatus(ExpType expType)
		{
			if(expType == ExpType.All)
			{
				for(int i = 0; i < m_layoutStatusIcons.Length; i++)
				{
					m_layoutStatusIcons[i].StartChildrenAnimGoStop("01");
				}
			}
			else
			{
				for(int i = 0; i < m_layoutStatusIcons.Length; i++)
				{
					m_layoutStatusIcons[i].StartChildrenAnimGoStop((int)expType == i ? "01" : "02");
				}
			}
		}

		// // RVA: 0x1994010 Offset: 0x1994010 VA: 0x1994010
		private void SetBonusValue(float bonusValue)
		{
			m_textExpBonus.text = string.Format(MessageManager.Instance.GetMessage("menu", "pop_godiva_bonus_open_bonus_2"), bonusValue);
		}

		// // RVA: 0x1994218 Offset: 0x1994218 VA: 0x1994218
		// public void Reset() { }

		// RVA: 0x199421C Offset: 0x199421C VA: 0x199421C
		public void Show()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
			this.StartCoroutineWatched(Co_PlayTitle());
		}

		// RVA: 0x1994290 Offset: 0x1994290 VA: 0x1994290
		public void Hide()
		{
			return;
		}

		// RVA: 0x1994294 Offset: 0x1994294 VA: 0x1994294 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutTitleType = layout.FindViewByExId("sw_pop_bonus_swtbl_pop_bonus_logo") as AbsoluteLayout;
			m_layoutTitle = layout.FindViewByExId("swtbl_pop_bonus_logo_pop_bonus_logo_anim") as AbsoluteLayout;
			m_layoutTitle2 = layout.FindViewByExId("swtbl_pop_bonus_logo_pop_bonus_logo_anim2") as AbsoluteLayout;
			m_layoutStatusIcons = new AbsoluteLayout[3];
			m_layoutStatusIcons[0] = layout.FindViewById("sw_soul_onoff_anim") as AbsoluteLayout;
			m_layoutStatusIcons[1] = layout.FindViewById("sw_voice_onoff_anim") as AbsoluteLayout;
			m_layoutStatusIcons[2] = layout.FindViewById("sw_charm_onoff_anim") as AbsoluteLayout;
			m_layoutMusicAttr = layout.FindViewById("swtbl_zok") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
