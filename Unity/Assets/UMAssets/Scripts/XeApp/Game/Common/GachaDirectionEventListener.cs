using mcrs;
using UnityEngine;
using XeSys.uGUI;

namespace XeApp.Game.Common
{
	public class GachaDirectionEventListener : MonoBehaviour
	{
		private static readonly Color s_whiteColor = Color.white; // 0x0
		private static readonly Color s_blackColor = Color.black; // 0x10
		private GachaDirectionEffectFactory m_effectFactory; // 0x10

		private UGUIFader fullscreenFader { get { return GameManager.Instance.fullscreenFader; } } //0x1C18940
		public GachaDirectionObject directionObject { private get; set; } // 0xC

		// RVA: 0x1C189EC Offset: 0x1C189EC VA: 0x1C189EC
		private void Awake()
		{
			m_effectFactory = GetComponent<GachaDirectionEffectFactory>();
		}

		// // RVA: 0x1C18A54 Offset: 0x1C18A54 VA: 0x1C18A54
		public void Ev_WhiteFadeOut(int frame)
		{
			FadeRequest(frame, s_whiteColor, 0, 1);
		}

		// // RVA: 0x1C18BD0 Offset: 0x1C18BD0 VA: 0x1C18BD0
		public void Ev_WhiteFadeIn(int frame)
		{
			if(CanFadeIn())
			{
				FadeRequest(frame, s_whiteColor, 1, 0);
			}
		}

		// // RVA: 0x1C18CF8 Offset: 0x1C18CF8 VA: 0x1C18CF8
		public void Ev_BlackFadeOut(int frame)
		{
			FadeRequest(frame, s_blackColor, 0, 1);
		}

		// // RVA: 0x1C18DC0 Offset: 0x1C18DC0 VA: 0x1C18DC0
		public void Ev_BlackFadeIn(int frame)
		{
			if(CanFadeIn())
			{
				FadeRequest(frame, s_blackColor, 1, 0);
			}
		}

		// // RVA: 0x1C18E90 Offset: 0x1C18E90 VA: 0x1C18E90
		public void Ev_RecentFadeIn(int frame)
		{
			if(CanFadeIn())
			{
				FadeRequest(frame, fullscreenFader.currentColor, 1, 0);
			}
		}

		// // RVA: 0x1C18EF8 Offset: 0x1C18EF8 VA: 0x1C18EF8
		public void Ev_NextCardFadeOut(int frame)
		{
			if(directionObject.isLastCard)
				return;
			Ev_WhiteFadeOut(frame);
		}

		// // RVA: 0x1C18F84 Offset: 0x1C18F84 VA: 0x1C18F84
		public void Ev_OrbChangeFadeOut(int frame)
		{
			if(!directionObject.isOrbChange)
				return;
			Ev_WhiteFadeOut(frame);
		}

		// // RVA: 0x1C19000 Offset: 0x1C19000 VA: 0x1C19000
		public void Ev_GoToResultFadeOut(int frame)
		{
			if(!directionObject.isLastCard)
				return;
			Ev_BlackFadeOut(frame);
		}

		// // RVA: 0x1C19044 Offset: 0x1C19044 VA: 0x1C19044
		public void Ev_NotifyOrbAppear()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_001);
		}

		// // RVA: 0x1C1909C Offset: 0x1C1909C VA: 0x1C1909C
		public void Ev_NotifyOrbFlash()
		{
			directionObject.NotifyOrbFlash();
		}

		// // RVA: 0x1C190EC Offset: 0x1C190EC VA: 0x1C190EC
		public void Ev_NotifyOrbChange()
		{
			directionObject.NotifyOrbChange();
		}

		// // RVA: 0x1C1913C Offset: 0x1C1913C VA: 0x1C1913C
		public void Ev_NotifyOrbDisappear()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_002);
		}

		// // RVA: 0x1C19194 Offset: 0x1C19194 VA: 0x1C19194
		public void Ev_NotifyValkyrieFly(int phase)
		{
			directionObject.NotifyValkyrieFly(phase);
		}

		// // RVA: 0x1C191F8 Offset: 0x1C191F8 VA: 0x1C191F8
		public void Ev_NotifyQuartzChange(int phase)
		{
			directionObject.NotifyQuartzChange(phase);
		}

		// // RVA: 0x1C19400 Offset: 0x1C19400 VA: 0x1C19400
		public void Ev_NotifyQuartzLeave()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_008);
		}

		// // RVA: 0x1C19458 Offset: 0x1C19458 VA: 0x1C19458
		public void Ev_NotifyQuartzBreak()
		{
			directionObject.NotifyQuartzBreak();
		}

		// // RVA: 0x1C19634 Offset: 0x1C19634 VA: 0x1C19634
		public void Ev_NotifyCutinVoice()
		{
			directionObject.NotifyCutinVoice();
		}

		// // RVA: 0x1C19760 Offset: 0x1C19760 VA: 0x1C19760
		public void Ev_NotifyCutinEvolve()
		{
			directionObject.NotifyCutinEvolve();
		}

		// // RVA: 0x1C19804 Offset: 0x1C19804 VA: 0x1C19804
		public void Ev_NotifyQuartzRotateS6()
		{
			directionObject.NotifyQuartzRotateS6();
		}

		// // RVA: 0x1C19884 Offset: 0x1C19884 VA: 0x1C19884
		public void Ev_NotifyLastStarS6()
		{
			directionObject.NotifyLastStarS6();
		}

		// // RVA: 0x1C19904 Offset: 0x1C19904 VA: 0x1C19904
		public void Ev_EffectEmitStart(string name)
		{
			m_effectFactory.EmitStart(name);
		}

		// // RVA: 0x1C19934 Offset: 0x1C19934 VA: 0x1C19934
		public void Ev_EffectEmitStop(string name)
		{
			m_effectFactory.EmitStop(name);
		}

		// // RVA: 0x1C19964 Offset: 0x1C19964 VA: 0x1C19964
		public void Ev_EffectDisable(string name)
		{
			m_effectFactory.Disable(name);
		}

		// // RVA: 0x1C19994 Offset: 0x1C19994 VA: 0x1C19994
		public void Ev_SkipLock()
		{
			directionObject.NotifySkipLock();
		}

		// // RVA: 0x1C199D0 Offset: 0x1C199D0 VA: 0x1C199D0
		public void Ev_SkipUnlock()
		{
			directionObject.NotifySkipUnlock();
		}

		// // RVA: 0x1C18C9C Offset: 0x1C18C9C VA: 0x1C18C9C
		private bool CanFadeIn()
		{
			if(fullscreenFader.currentColor.a <= 0)
			{
				return fullscreenFader.isFading;
			}
			return true;
		}

		// // RVA: 0x1C18B18 Offset: 0x1C18B18 VA: 0x1C18B18
		private void FadeRequest(int frame, Color baseColor, float startAlpha, float endAlpha)
		{
			if(!directionObject.isIgnoreEventFade)
				fullscreenFader.Fade(frame / 60.0f, new Color(baseColor.r, baseColor.g, baseColor.b, startAlpha), new Color(baseColor.r, baseColor.g, baseColor.b, endAlpha));
		}
	}
}
