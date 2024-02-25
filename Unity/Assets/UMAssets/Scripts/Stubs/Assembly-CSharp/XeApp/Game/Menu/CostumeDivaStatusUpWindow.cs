using System.Collections;
using CriWare;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	internal class CostumeDivaStatusUpWindow : LayoutUGUIScriptBase
	{
		private struct DivaParameterText
		{
			public Text soul; // 0x0
			public Text voice; // 0x4
			public Text charm; // 0x8
			public Text life; // 0xC
			public Text support; // 0x10
			public Text fold; // 0x14
		}

		private struct DivaParameterLayout
		{
			public AbsoluteLayout soul; // 0x0
			public AbsoluteLayout voice; // 0x4
			public AbsoluteLayout charm; // 0x8
			public AbsoluteLayout life; // 0xC
			public AbsoluteLayout support; // 0x10
			public AbsoluteLayout fold; // 0x14
		}

		private AbsoluteLayout layoutStatusUp; // 0x14
		private AbsoluteLayout layoutStatusUpEffect; // 0x18
		private ActionButton closeButton; // 0x1C
		private RawImageEx imageDiva; // 0x20
		private DivaParameterText beforeParamText; // 0x24
		private DivaParameterText afterParamText; // 0x3C
		private DivaParameterLayout afterParamLayout; // 0x54
		private DivaParameterLayout afterIconLayout; // 0x6C
		private CriAtomExPlayback countUpSEPlayback; // 0x84
		private bool isPlayedCountupSE; // 0x88
		private bool isSkiped; // 0x89
		private StatusData m_beforeStatus = new StatusData(); // 0x8C
		private StatusData m_afterStatus = new StatusData(); // 0x90
		private readonly int upParameterFontSize = 24; // 0x94

		// RVA: 0x162A9F4 Offset: 0x162A9F4 VA: 0x162A9F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			layoutStatusUp = layout.FindViewById("sw_st_up_anim") as AbsoluteLayout;
			layoutStatusUpEffect = layoutStatusUp.FindViewById("sw_pu_ef_anim") as AbsoluteLayout;
			Transform t = transform.Find("sw_st_up_diva_set (AbsoluteLayout)").transform;
			imageDiva = t.Find("swtexc_cmn_diva_m03 (ImageView)").GetComponent<RawImageEx>();
			imageDiva.raycastTarget = false;
			beforeParamText.soul = t.Find("so_bef (TextView)").GetComponent<Text>();
			beforeParamText.voice = t.Find("vo_bef (TextView)").GetComponent<Text>();
			beforeParamText.charm = t.Find("ch_bef (TextView)").GetComponent<Text>();
			beforeParamText.life = t.Find("li_bef (TextView)").GetComponent<Text>();
			beforeParamText.support = t.Find("su_bef (TextView)").GetComponent<Text>();
			beforeParamText.fold = t.Find("fo_bef (TextView)").GetComponent<Text>();
			afterParamText.soul = t.Find("sw_soul_up_anim (AbsoluteLayout)/cos_up (AbsoluteLayout)/so_af (TextView)").GetComponent<Text>();
			afterParamText.voice = t.Find("sw_voice_up_anim (AbsoluteLayout)/voice_up (AbsoluteLayout)/vo_af (TextView)").GetComponent<Text>();
			afterParamText.charm = t.Find("sw_charm_up_anim (AbsoluteLayout)/charm_up (AbsoluteLayout)/ch_af (TextView)").GetComponent<Text>();
			afterParamText.life = t.Find("sw_life_up_anim (AbsoluteLayout)/life_up (AbsoluteLayout)/li_af (TextView)").GetComponent<Text>();
			afterParamText.support = t.Find("sw_support_up_anim (AbsoluteLayout)/support_up (AbsoluteLayout)/su_af (TextView)").GetComponent<Text>();
			afterParamText.fold = t.Find("sw_fold_up_anim (AbsoluteLayout)/fold_up (AbsoluteLayout)/fo_af (TextView)").GetComponent<Text>();
			afterParamLayout.soul = layout.FindViewById("sw_soul_up_anim") as AbsoluteLayout;
			afterParamLayout.voice = layout.FindViewById("sw_voice_up_anim") as AbsoluteLayout;
			afterParamLayout.charm = layout.FindViewById("sw_charm_up_anim") as AbsoluteLayout;
			afterParamLayout.life = layout.FindViewById("sw_life_up_anim") as AbsoluteLayout;
			afterParamLayout.support = layout.FindViewById("sw_support_up_anim") as AbsoluteLayout;
			afterParamLayout.fold = layout.FindViewById("sw_fold_up_anim") as AbsoluteLayout;
			afterIconLayout.soul = layout.FindViewById("sw_status_icon_up_anim_soul") as AbsoluteLayout;
			afterIconLayout.voice = layout.FindViewById("sw_status_icon_up_anim_voice") as AbsoluteLayout;
			afterIconLayout.charm = layout.FindViewById("sw_status_icon_up_anim_charm") as AbsoluteLayout;
			afterIconLayout.life = layout.FindViewById("sw_status_icon_up_anim_life") as AbsoluteLayout;
			afterIconLayout.support = layout.FindViewById("sw_status_icon_up_anim_support") as AbsoluteLayout;
			afterIconLayout.fold = layout.FindViewById("sw_status_icon_up_anim_fold") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x162B634 Offset: 0x162B634 VA: 0x162B634
		public void Initialize(LFAFJCNKLML data)
		{
			isPlayedCountupSE = false;
			isSkiped = false;
			StartLoadDivaIcon(data.AHHJLDLAPAN_DivaId);
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[data.AHHJLDLAPAN_DivaId - 1];
			m_afterStatus.Copy(diva.JLJGCBOHJID_Status);
			afterParamText.soul.text = diva.JLJGCBOHJID_Status.soul.ToString();
			afterParamText.voice.text = diva.JLJGCBOHJID_Status.vocal.ToString();
			afterParamText.charm.text = diva.JLJGCBOHJID_Status.charm.ToString();
			afterParamText.life.text = diva.JLJGCBOHJID_Status.life.ToString();
			afterParamText.support.text = diva.JLJGCBOHJID_Status.support.ToString();
			afterParamText.fold.text = diva.JLJGCBOHJID_Status.fold.ToString();
			m_beforeStatus.Copy(m_afterStatus);
			int a1 = data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[0];
			if(a1 > 0 && a1 <= 6)
			{
				switch(a1)
				{
					case 1:
						m_beforeStatus.soul -= data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[1];
						break;
					case 2:
						m_beforeStatus.vocal -= data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[1];
						break;
					case 3:
						m_beforeStatus.charm -= data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[1];
						break;
					case 4:
						m_beforeStatus.life -= data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[1];
						break;
					case 5:
						m_beforeStatus.support -= data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[1];
						break;
					case 6:
						m_beforeStatus.fold -= data.JHLKLPEHHCD_GetCurrentLevelInfo().KJNAHLOODKD_Value[1];
						break;
				}
			}
			beforeParamText.soul.text = m_beforeStatus.soul.ToString();
			beforeParamText.voice.text = m_beforeStatus.vocal.ToString();
			beforeParamText.charm.text = m_beforeStatus.charm.ToString();
			beforeParamText.life.text = m_beforeStatus.life.ToString();
			beforeParamText.support.text = m_beforeStatus.support.ToString();
			beforeParamText.fold.text = m_beforeStatus.fold.ToString();
		}

		// RVA: 0x162C0B8 Offset: 0x162C0B8 VA: 0x162C0B8
		private void Update()
		{
			if(IsLoaded() && !isSkiped)
			{
				if(InputManager.Instance.touchCount > 0)
				{
					if(InputManager.Instance.GetCurrentTouchInfo(0).isEnded)
					{
						SkipAnim();
						isSkiped = true;
					}
				}
			}
		}

		// RVA: 0x162C4E8 Offset: 0x162C4E8 VA: 0x162C4E8
		private void OnDestroy()
		{
			countUpSEPlayback.Stop();
		}

		// // RVA: 0x162C500 Offset: 0x162C500 VA: 0x162C500
		private void ChangeAfterParamVisiblity(bool isVisible)
		{
			afterParamText.soul.enabled = isVisible;
			afterParamText.voice.enabled = isVisible;
			afterParamText.charm.enabled = isVisible;
			afterParamText.life.enabled = isVisible;
			afterParamText.support.enabled = isVisible;
			afterParamText.fold.enabled = isVisible;
		}

		// // RVA: 0x162C210 Offset: 0x162C210 VA: 0x162C210
		private void SkipAnim()
		{
			this.StopAllCoroutinesWatched();
			countUpSEPlayback.Stop();
			layoutStatusUpEffect.StartChildrenAnimLoop("logo_", "loen_");
			layoutStatusUp.StartAllAnimLoop("logo_up", "loen_up");
			ChangeAfterParamVisiblity(true);
			SkipAfterParam(afterParamText.soul, afterIconLayout.soul, m_beforeStatus.soul, m_afterStatus.soul);
			SkipAfterParam(afterParamText.voice, afterIconLayout.voice, m_beforeStatus.vocal, m_afterStatus.vocal);
			SkipAfterParam(afterParamText.charm, afterIconLayout.charm, m_beforeStatus.charm, m_afterStatus.charm);
			SkipAfterParam(afterParamText.life, afterIconLayout.life, m_beforeStatus.life, m_afterStatus.life);
			SkipAfterParam(afterParamText.support, afterIconLayout.support, m_beforeStatus.support, m_afterStatus.support);
			SkipAfterParam(afterParamText.fold, afterIconLayout.fold, m_beforeStatus.fold, m_afterStatus.fold);
		}

		// // RVA: 0x162C7C4 Offset: 0x162C7C4 VA: 0x162C7C4
		public void Show()
		{
			gameObject.SetActive(true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			this.StartCoroutineWatched(Co_MainFlow());
		}

		// // RVA: 0x162C8F0 Offset: 0x162C8F0 VA: 0x162C8F0
		public void Hide()
		{
			gameObject.SetActive(false);
			countUpSEPlayback.Stop();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CDEAC Offset: 0x6CDEAC VA: 0x6CDEAC
		// // RVA: 0x162C864 Offset: 0x162C864 VA: 0x162C864
		private IEnumerator Co_MainFlow()
		{
			//0x162DD7C
			yield return this.StartCoroutineWatched(Co_PlayLevelupTitleAnim());
			yield return this.StartCoroutineWatched(Co_CountupParameters());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CDF24 Offset: 0x6CDF24 VA: 0x6CDF24
		// // RVA: 0x162C958 Offset: 0x162C958 VA: 0x162C958
		private IEnumerator Co_PlayLevelupTitleAnim()
		{
			//0x162DEF8
			layoutStatusUp.StartAllAnimGoStop("go_in", "st_in");
			layoutStatusUpEffect.StartChildrenAnimLoop("logo_", "loen_");
			float end = layoutStatusUp.GetView(0).FrameAnimation.SearchLabelFrame("st_in");
			yield return new WaitWhile(() =>
			{
				//0x162CEDC
				return end / layoutStatusUp.GetView(0).FrameAnimation.FrameCount < 0.35f;
			});
			layoutStatusUp.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CDF9C Offset: 0x6CDF9C VA: 0x6CDF9C
		// // RVA: 0x162CA04 Offset: 0x162CA04 VA: 0x162CA04
		private IEnumerator Co_CountupParameters()
		{
			Coroutine co_voice; // 0x14
			Coroutine co_charm; // 0x18
			Coroutine co_life; // 0x1C
			Coroutine co_support; // 0x20
			Coroutine co_fold; // 0x24

			//0x162CF94
			ChangeAfterParamVisiblity(true);
			Coroutine c = this.StartCoroutineWatched(SetupAfterParam(afterParamText.soul, afterParamLayout.soul, afterIconLayout.soul, m_beforeStatus.soul, m_afterStatus.soul));
			co_voice = this.StartCoroutineWatched(SetupAfterParam(afterParamText.voice, afterParamLayout.voice, afterIconLayout.voice, m_beforeStatus.vocal, m_afterStatus.vocal));
			co_charm = this.StartCoroutineWatched(SetupAfterParam(afterParamText.charm, afterParamLayout.charm, afterIconLayout.charm, m_beforeStatus.charm, m_afterStatus.charm));
			co_life = this.StartCoroutineWatched(SetupAfterParam(afterParamText.life, afterParamLayout.life, afterIconLayout.life, m_beforeStatus.life, m_afterStatus.life));
			co_support = this.StartCoroutineWatched(SetupAfterParam(afterParamText.support, afterParamLayout.support, afterIconLayout.support, m_beforeStatus.support, m_afterStatus.support));
			co_fold = this.StartCoroutineWatched(SetupAfterParam(afterParamText.fold, afterParamLayout.fold, afterIconLayout.fold, m_beforeStatus.fold, m_afterStatus.fold));
			yield return c;
			yield return co_voice;
			yield return co_charm;
			yield return co_life;
			yield return co_support;
			yield return co_fold;
		}

		// // RVA: 0x162BE0C Offset: 0x162BE0C VA: 0x162BE0C
		private void StartLoadDivaIcon(int divaId)
		{
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[divaId - 1];
			imageDiva.enabled = false;
			MenuScene.Instance.DivaIconCache.LoadPortraitIcon(divaId, diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, diva.EKFONBFDAAP_ColorId, (IiconTexture iconTexture) =>
			{
				//0x162CDD0
				iconTexture.Set(imageDiva);
				imageDiva.enabled = true;
			});
		}

		// // RVA: 0x162CAB0 Offset: 0x162CAB0 VA: 0x162CAB0
		private IEnumerator SetupAfterParam(Text uguiText, AbsoluteLayout anim, AbsoluteLayout icon, int before, int after)
		{
			uguiText.supportRichText = true;
			if(before < after)
			{
				icon.StartChildrenAnimGoStop("go_in", "st_in");
			}
			else
			{
				icon.StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			return Co_CountupValue(uguiText, icon, before, after);
		}

		// // RVA: 0x162C5EC Offset: 0x162C5EC VA: 0x162C5EC
		private void SkipAfterParam(Text uguiText, AbsoluteLayout icon, int before, int after)
		{
			uguiText.supportRichText = true;
			if(after <= before)
				return;
			icon.StartChildrenAnimLoop("logo_on", "loen_on");
			uguiText.text = RichTextUtility.MakeColorTagString(after.ToString(), StatusTextColor.UpColor);
			uguiText.text = RichTextUtility.MakeSizeTagString(uguiText.text, upParameterFontSize);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE014 Offset: 0x6CE014 VA: 0x6CE014
		// // RVA: 0x162CBAC Offset: 0x162CBAC VA: 0x162CBAC
		private IEnumerator Co_CountupValue(Text text, AbsoluteLayout icon, int before, int after)
		{
			int maxFontSize; // 0x24
			float fs; // 0x28
			float animTime; // 0x2C
			float time; // 0x30

			//0x162D3EC
			if(before == after)
				yield break;
			PlayCountUpLoopSE();
			maxFontSize = 28;
			fs = text.fontSize;
			while(fs < maxFontSize)
			{
				text.text = RichTextUtility.MakeColorTagString(before.ToString(), StatusTextColor.UpColor);
				text.text = RichTextUtility.MakeSizeTagString(text.text, (int)fs);
				fs += Time.deltaTime * 60;
				yield return null;
			}
			//float frame = icon.GetView(0).FrameAnimation.SearchLabelFrame("go_in");
			animTime = 0.75f;
			time = 0;
			while(time < animTime)
			{
				//LAB_0162d674
				time += Time.deltaTime;
				float f = Math.Tween.EasingInOutSine(before, after, time / animTime);
				text.text = RichTextUtility.MakeColorTagString(Mathf.RoundToInt(f).ToString(), StatusTextColor.UpColor);
				text.text = RichTextUtility.MakeSizeTagString(text.text, maxFontSize);
				yield return null;
			}
			icon.StartChildrenAnimLoop("logo_on", "loen_on");
			countUpSEPlayback.Stop();
			fs = maxFontSize;
			while(fs >= upParameterFontSize)
			{
				text.text = RichTextUtility.MakeColorTagString(after.ToString(), StatusTextColor.UpColor);
				text.text = RichTextUtility.MakeSizeTagString(text.text, (int)fs);
				fs += Time.deltaTime * -30;
				yield return null;
			}
			text.text = RichTextUtility.MakeColorTagString(after.ToString(), StatusTextColor.UpColor);
			text.text = RichTextUtility.MakeSizeTagString(text.text, upParameterFontSize);
		}

		// // RVA: 0x162CCC0 Offset: 0x162CCC0 VA: 0x162CCC0
		private void PlayCountUpLoopSE()
		{
			if(isPlayedCountupSE)
				return;
			countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_000);
			isPlayedCountupSE = true;
		}

		// // RVA: 0x162C4F4 Offset: 0x162C4F4 VA: 0x162C4F4
		// private void StopCountUpLoopSE() { }
	}
}
