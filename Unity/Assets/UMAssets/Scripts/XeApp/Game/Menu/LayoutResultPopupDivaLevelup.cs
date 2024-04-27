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
	public class LayoutResultPopupDivaLevelup : LayoutUGUIScriptBase
	{
		private struct DivaParameterText
		{
			public Text level; // 0x0
			public Text soul; // 0x4
			public Text voice; // 0x8
			public Text charm; // 0xC
			public Text life; // 0x10
			public Text support; // 0x14
			public Text fold; // 0x18
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

		private AbsoluteLayout layoutLevelup; // 0x14
		private AbsoluteLayout layoutEffect; // 0x18
		private AbsoluteLayout layoutLevelValue; // 0x1C
		private ActionButton closeButton; // 0x20
		private RawImageEx imageDiva; // 0x24
		private DivaParameterText beforeParamText; // 0x28
		private DivaParameterText afterParamText; // 0x44
		private DivaParameterLayout afterParamLayout; // 0x60
		private DivaParameterLayout afterIconLayout; // 0x78
		private CriAtomExPlayback countUpSEPlayback; // 0x90
		private FFHPBEPOMAK_DivaInfo beforeDivaData; // 0x94
		private FFHPBEPOMAK_DivaInfo afterDivaData; // 0x98
		private bool isPlayedCountupSE; // 0x9C
		private bool isSkiped; // 0x9D
		private readonly int upParameterFontSize = 24; // 0xA0

		// RVA: 0x1D07B38 Offset: 0x1D07B38 VA: 0x1D07B38
		private void Update()
		{
			if(IsLoaded() && !isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(ResultScene.IsScreenTouch())
					{
						SkipAnim();
						isSkiped = true;
					}
				}
			}
		}

		// RVA: 0x1D080A8 Offset: 0x1D080A8 VA: 0x1D080A8
		private void OnDestroy()
		{
			countUpSEPlayback.Stop();
		}

		// RVA: 0x1D080C0 Offset: 0x1D080C0 VA: 0x1D080C0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutLevelup = layout.FindViewById("sw_lvup_anim") as AbsoluteLayout;
			layoutEffect = layout.FindViewById("sw_pu_ef_anim") as AbsoluteLayout;
			layoutLevelValue = layout.FindViewById("sw_user_lvup_anim") as AbsoluteLayout;
			Transform t = transform.Find("sw_pu_dlvup_set (AbsoluteLayout)");
			imageDiva = t.Find("swtexc_cmn_diva_m03 (ImageView)").GetComponent<RawImageEx>();
			imageDiva.raycastTarget = false;
			beforeParamText.level = t.Find("lv_bef (TextView)").GetComponent<Text>();
			beforeParamText.soul = t.Find("so_bef (TextView)").GetComponent<Text>();
			beforeParamText.voice = t.Find("vo_bef (TextView)").GetComponent<Text>();
			beforeParamText.charm = t.Find("ch_bef (TextView)").GetComponent<Text>();
			beforeParamText.life = t.Find("li_bef (TextView)").GetComponent<Text>();
			beforeParamText.support = t.Find("su_bef (TextView)").GetComponent<Text>();
			beforeParamText.fold = t.Find("fo_bef (TextView)").GetComponent<Text>();
			afterParamText.level = t.Find("sw_user_lvup_anim (AbsoluteLayout)/lv_af (AbsoluteLayout)/lv_af (TextView)").GetComponent<Text>();
			afterParamText.soul = t.Find("sw_soul_up_anim (AbsoluteLayout)/soul_up (AbsoluteLayout)/so_af (TextView)").GetComponent<Text>();
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

		// RVA: 0x1D08E18 Offset: 0x1D08E18 VA: 0x1D08E18
		public void Setup(FFHPBEPOMAK_DivaInfo beforeDivaData, FFHPBEPOMAK_DivaInfo afterDivaData)
		{
			this.beforeDivaData = beforeDivaData;
			this.afterDivaData = afterDivaData;
			StartLoadDivaIcon(beforeDivaData.AHHJLDLAPAN_DivaId);
			beforeParamText.level.text = RichTextUtility.MakeSizeTagString("Lv.", 18) + beforeDivaData.CIEOBFIIPLD_Level.ToString();
			beforeParamText.soul.text = beforeDivaData.JLJGCBOHJID_Status.soul.ToString();
			beforeParamText.voice.text = beforeDivaData.JLJGCBOHJID_Status.vocal.ToString();
			beforeParamText.charm.text = beforeDivaData.JLJGCBOHJID_Status.charm.ToString();
			beforeParamText.life.text = beforeDivaData.JLJGCBOHJID_Status.life.ToString();
			beforeParamText.support.text = beforeDivaData.JLJGCBOHJID_Status.support.ToString();
			beforeParamText.fold.text = beforeDivaData.JLJGCBOHJID_Status.fold.ToString();
			afterParamText.level.text = RichTextUtility.MakeSizeTagString("Lv.", 28) + afterDivaData.CIEOBFIIPLD_Level.ToString();
			afterParamText.soul.text = beforeDivaData.JLJGCBOHJID_Status.soul.ToString();
			afterParamText.voice.text = beforeDivaData.JLJGCBOHJID_Status.vocal.ToString();
			afterParamText.charm.text = beforeDivaData.JLJGCBOHJID_Status.charm.ToString();
			afterParamText.life.text = beforeDivaData.JLJGCBOHJID_Status.life.ToString();
			afterParamText.support.text = beforeDivaData.JLJGCBOHJID_Status.support.ToString();
			afterParamText.fold.text = beforeDivaData.JLJGCBOHJID_Status.fold.ToString();
		}

		// // RVA: 0x1D0966C Offset: 0x1D0966C VA: 0x1D0966C
		private void ChangeAfterParamVisiblity(bool isVisible)
		{
			afterParamText.soul.enabled = isVisible;
			afterParamText.voice.enabled = isVisible;
			afterParamText.charm.enabled = isVisible;
			afterParamText.life.enabled = isVisible;
			afterParamText.support.enabled = isVisible;
			afterParamText.fold.enabled = isVisible;
		}

		// // RVA: 0x1D07C20 Offset: 0x1D07C20 VA: 0x1D07C20
		private void SkipAnim()
		{
			this.StopAllCoroutinesWatched();
			countUpSEPlayback.Stop();
			layoutEffect.StartChildrenAnimLoop("logo_", "loen_");
			layoutLevelup.StartAllAnimLoop("logo_up", "loen_up");
			layoutLevelValue.StartChildrenAnimGoStop("st_in");
			ChangeAfterParamVisiblity(true);
			SkipAfterParam(afterParamText.soul, afterIconLayout.soul, beforeDivaData.JLJGCBOHJID_Status.soul, afterDivaData.JLJGCBOHJID_Status.soul);
			SkipAfterParam(afterParamText.voice, afterIconLayout.voice, beforeDivaData.JLJGCBOHJID_Status.vocal, afterDivaData.JLJGCBOHJID_Status.vocal);
			SkipAfterParam(afterParamText.charm, afterIconLayout.charm, beforeDivaData.JLJGCBOHJID_Status.charm, afterDivaData.JLJGCBOHJID_Status.charm);
			SkipAfterParam(afterParamText.life, afterIconLayout.life, beforeDivaData.JLJGCBOHJID_Status.life, afterDivaData.JLJGCBOHJID_Status.life);
			SkipAfterParam(afterParamText.support, afterIconLayout.support, beforeDivaData.JLJGCBOHJID_Status.support, afterDivaData.JLJGCBOHJID_Status.support);
			SkipAfterParam(afterParamText.fold, afterIconLayout.fold, beforeDivaData.JLJGCBOHJID_Status.fold, afterDivaData.JLJGCBOHJID_Status.fold);
		}

		// RVA: 0x1D09930 Offset: 0x1D09930 VA: 0x1D09930
		public void Show()
		{
			gameObject.SetActive(true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			this.StartCoroutineWatched(Co_MainFlow());
		}

		// RVA: 0x1D09A5C Offset: 0x1D09A5C VA: 0x1D09A5C
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D17C Offset: 0x71D17C VA: 0x71D17C
		// // RVA: 0x1D099D0 Offset: 0x1D099D0 VA: 0x1D099D0
		private IEnumerator Co_MainFlow()
		{
			//0x1D0B048
			yield return this.StartCoroutineWatched(Co_PlayLevelupTitleAnim());
			yield return this.StartCoroutineWatched(Co_PlayLevelValueAnim());
			yield return this.StartCoroutineWatched(Co_CountupParameters());

		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D1F4 Offset: 0x71D1F4 VA: 0x71D1F4
		// // RVA: 0x1D09AB4 Offset: 0x1D09AB4 VA: 0x1D09AB4
		private IEnumerator Co_PlayLevelupTitleAnim()
		{
			//0x1D0B3F4
			layoutLevelup.StartAllAnimGoStop("go_in", "st_in");
			layoutEffect.StartChildrenAnimLoop("logo_", "loen_");
			float end = layoutLevelup.GetView(0).FrameAnimation.SearchLabelFrame("st_in");
			yield return new WaitWhile(() =>
			{
				//0x1D0A044
				return end / layoutLevelup.GetView(0).FrameAnimation.FrameCount < 0.35f;
			});
			layoutLevelup.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D26C Offset: 0x71D26C VA: 0x71D26C
		// // RVA: 0x1D09B60 Offset: 0x1D09B60 VA: 0x1D09B60
		private IEnumerator Co_PlayLevelValueAnim()
		{
			//0x1D0B218
			layoutLevelValue.StartChildrenAnimGoStop("go_in", "st_in");
			yield return new WaitWhile(() =>
			{
				//0x1D09F30
				return layoutLevelValue.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D2E4 Offset: 0x71D2E4 VA: 0x71D2E4
		// // RVA: 0x1D09C0C Offset: 0x1D09C0C VA: 0x1D09C0C
		private IEnumerator Co_CountupParameters()
		{
			Coroutine co_voice; // 0x14
			Coroutine co_charm; // 0x18
			Coroutine co_life; // 0x1C
			Coroutine co_support; // 0x20
			Coroutine co_fold; // 0x24

			//0x1D0A0FC
			ChangeAfterParamVisiblity(true);
			Coroutine co_soul = this.StartCoroutineWatched(SetupAfterParam(afterParamText.soul, null, afterIconLayout.soul, beforeDivaData.JLJGCBOHJID_Status.soul, afterDivaData.JLJGCBOHJID_Status.soul));
			co_voice = this.StartCoroutineWatched(SetupAfterParam(afterParamText.voice, null, afterIconLayout.voice, beforeDivaData.JLJGCBOHJID_Status.vocal, afterDivaData.JLJGCBOHJID_Status.vocal));
			co_charm = this.StartCoroutineWatched(SetupAfterParam(afterParamText.charm, null, afterIconLayout.charm, beforeDivaData.JLJGCBOHJID_Status.charm, afterDivaData.JLJGCBOHJID_Status.charm));
			co_life = this.StartCoroutineWatched(SetupAfterParam(afterParamText.life, null, afterIconLayout.life, beforeDivaData.JLJGCBOHJID_Status.life, afterDivaData.JLJGCBOHJID_Status.life));
			co_support = this.StartCoroutineWatched(SetupAfterParam(afterParamText.support, null, afterIconLayout.support, beforeDivaData.JLJGCBOHJID_Status.support, afterDivaData.JLJGCBOHJID_Status.support));
			co_fold = this.StartCoroutineWatched(SetupAfterParam(afterParamText.fold, null, afterIconLayout.fold, beforeDivaData.JLJGCBOHJID_Status.fold, afterDivaData.JLJGCBOHJID_Status.fold));
			yield return co_soul;
			yield return co_voice;
			yield return co_charm;
			yield return co_life;
			yield return co_support;
			yield return co_fold;
		}

		// // RVA: 0x1D093E8 Offset: 0x1D093E8 VA: 0x1D093E8
		private void StartLoadDivaIcon(int divaId)
		{
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[divaId - 1];
			MenuScene.Instance.DivaIconCache.LoadPortraitIcon(divaId, diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, diva.EKFONBFDAAP_ColorId, (IiconTexture iconTexture) =>
			{
				//0x1D09F5C
				iconTexture.Set(imageDiva);
			});
		}

		// // RVA: 0x1D09CB8 Offset: 0x1D09CB8 VA: 0x1D09CB8
		private IEnumerator SetupAfterParam(Text uguiText, AbsoluteLayout anim, AbsoluteLayout icon, int before, int after)
		{
			uguiText.supportRichText = true;
			if(before < after)
			{
				icon.StartChildrenAnimGoStop("go_in", "st_in");
			}
			return Co_CountupValue(uguiText, icon, before, after);
		}

		// // RVA: 0x1D09758 Offset: 0x1D09758 VA: 0x1D09758
		private void SkipAfterParam(Text uguiText, AbsoluteLayout icon, int before, int after)
		{
			uguiText.supportRichText = true;
			if(after <= before)
				return;
			icon.StartChildrenAnimLoop("logo_on", "loen_on");
			uguiText.text = RichTextUtility.MakeColorTagString(after.ToString(), StatusTextColor.UpColor);
			uguiText.text = RichTextUtility.MakeSizeTagString(uguiText.text, upParameterFontSize);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D35C Offset: 0x71D35C VA: 0x71D35C
		// // RVA: 0x1D09D98 Offset: 0x1D09D98 VA: 0x1D09D98
		private IEnumerator Co_CountupValue(Text text, AbsoluteLayout icon, int before, int after)
		{
			int maxFontSize; // 0x24
			float fs; // 0x28
			float animTime; // 0x2C
			float time; // 0x30

			//0x1D0A6B8
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
			animTime = 0.75f;
			time = 0;
			while(time < animTime)
			{
				time += Time.deltaTime;
				int val = Mathf.RoundToInt(Math.Tween.EasingInOutSine(before, after, time / animTime));
				text.text = RichTextUtility.MakeColorTagString(val.ToString(), StatusTextColor.UpColor);
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
				fs -= Time.deltaTime * 30;
				yield return null;
			}
			text.text = RichTextUtility.MakeColorTagString(after.ToString(), StatusTextColor.UpColor);
			text.text = RichTextUtility.MakeSizeTagString(text.text, upParameterFontSize);
		}

		// // RVA: 0x1D09EAC Offset: 0x1D09EAC VA: 0x1D09EAC
		private void PlayCountUpLoopSE()
		{
			if(isPlayedCountupSE)
				return;
			countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_000);
			isPlayedCountupSE = true;
		}

		// // RVA: 0x1D080B4 Offset: 0x1D080B4 VA: 0x1D080B4
		// private void StopCountUpLoopSE() { }
	}
}
