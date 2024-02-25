using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using CriWare;
using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutIntimacyInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_numExpNow; // 0x14
		[SerializeField]
		private NumberBase m_numExpNext; // 0x18
		[SerializeField]
		private NumberBase m_numLevel; // 0x1C
		[SerializeField]
		private NumberBase[] m_numPoint; // 0x20
		[SerializeField]
		private NumberBase m_numBonus; // 0x24
		private AbsoluteLayout m_layoutRoot; // 0x28
		private AbsoluteLayout m_layoutPoint; // 0x2C
		private AbsoluteLayout m_layoutPointAnim; // 0x30
		private AbsoluteLayout[] m_layoutPointAnimTbl; // 0x34
		private AbsoluteLayout m_layoutExpDigit; // 0x38
		private AbsoluteLayout m_layoutLevel; // 0x3C
		private AbsoluteLayout m_layoutLevelMax; // 0x40
		private AbsoluteLayout m_layoutGauge; // 0x44
		private JJOELIOGMKK_DivaIntimacyInfo m_viewData; // 0x48
		private CriAtomExPlayback m_countUpSEPlayback; // 0x4C
		private bool m_isShown; // 0x50

		// RVA: 0x1D5201C Offset: 0x1D5201C VA: 0x1D5201C
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop();
		}

		// // RVA: 0x1D52034 Offset: 0x1D52034 VA: 0x1D52034
		public void Setup(JJOELIOGMKK_DivaIntimacyInfo viewData, bool isHome)
		{
			m_viewData = viewData;
			m_layoutRoot.StartChildrenAnimGoStop(isHome ? "home" : "present");
			m_layoutLevelMax.StartChildrenAnimGoStop(viewData.HBODCMLFDOB.PFIILLOIDIL ? "01" : "00");
			m_numLevel.SetNumber(m_viewData.HEKJGCMNJAB_CurrentLevel, 0);
			if(m_viewData.HBODCMLFDOB.PFIILLOIDIL)
			{
				SetExp(0, 0);
				UpdateGaugePosition(1);
			}
			else
			{
				SetExp(m_viewData.KPEAGFJHNDP_CurrentLevelExp, m_viewData.KOKCFJDMJLI);
				UpdateGaugePosition(m_viewData.KPEAGFJHNDP_CurrentLevelExp * 1.0f / m_viewData.KOKCFJDMJLI);
			}
		}

		// // RVA: 0x1D5246C Offset: 0x1D5246C VA: 0x1D5246C
		public void TryEnter()
		{
			if (m_isShown)
				return;
			Enter();
		}

		// // RVA: 0x1D5253C Offset: 0x1D5253C VA: 0x1D5253C
		public void TryLeave()
		{
			if (!m_isShown)
				return;
			Leave();
		}

		// // RVA: 0x1D5247C Offset: 0x1D5247C VA: 0x1D5247C
		public void Enter()
		{
			m_isShown = true;
			m_layoutLevel.StartChildrenAnimGoStop("go_in", "st_in");
			transform.SetAsLastSibling();
		}

		// // RVA: 0x1D5254C Offset: 0x1D5254C VA: 0x1D5254C
		public void Leave()
		{
			m_isShown = false;
			m_layoutLevel.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1D525E0 Offset: 0x1D525E0 VA: 0x1D525E0
		// public void Show() { }

		// // RVA: 0x1D52664 Offset: 0x1D52664 VA: 0x1D52664
		public void Hide()
		{
			m_isShown = false;
			m_layoutRoot.StartAllAnimGoStop("st_wait");
		}

		// // RVA: 0x1D526E8 Offset: 0x1D526E8 VA: 0x1D526E8
		public void StartPointUp(Action callback)
		{
			this.StartCoroutineWatched(Co_StartPointUp(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E762C Offset: 0x6E762C VA: 0x6E762C
		// // RVA: 0x1D5270C Offset: 0x1D5270C VA: 0x1D5270C
		private IEnumerator Co_StartPointUp(Action callback)
		{
			List<Coroutine> coutupCoroutines; // 0x18
			int i; // 0x1C

			//0x1D54508
			if(m_viewData.HBODCMLFDOB.HOMOKJEKKNK_Bonus < 1)
			{
				m_layoutPoint.StartChildrenAnimGoStop("01");
				m_layoutPointAnim = m_layoutPointAnimTbl[0];
			}
			else
			{
				m_layoutPoint.StartChildrenAnimGoStop("02");
				m_layoutPointAnim = m_layoutPointAnimTbl[1];
			}
			coutupCoroutines = new List<Coroutine>();
			yield return Co.R(Co_CountPoint(coutupCoroutines, m_viewData.HBODCMLFDOB.ODHAIDDEFJL_GetExp, m_viewData.HBODCMLFDOB.HOMOKJEKKNK_Bonus));
			for(i = 0; i < coutupCoroutines.Count; i++)
			{
				yield return coutupCoroutines[i];
			}
			m_layoutPoint.StartChildrenAnimGoStop("go_out", "st_out");
			if (callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E76A4 Offset: 0x6E76A4 VA: 0x6E76A4
		// // RVA: 0x1D527D4 Offset: 0x1D527D4 VA: 0x1D527D4
		private IEnumerator Co_CountPoint(List<Coroutine> coutupCoroutines, int point, int bonus)
		{
			int i;

			//0x1D53724
			SetUpPoint(point);
			m_numBonus.SetNumber(bonus, 0);
			m_layoutPointAnim.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_009);
			while (m_layoutPointAnim.IsPlayingChildren())
				yield return null;
			if (bonus > 0)
			{
				yield return Co.R(Co_CountBonus(coutupCoroutines, point, bonus));
			}
			m_layoutPointAnim.StartChildrenAnimGoStop("go_out", "st_out");
			for(i = 0; i < 30; i++)
			{ 
				yield return null;
			}
			if (!m_viewData.HBODCMLFDOB.EDPNAEOKGNM)
			{
				coutupCoroutines.Add(this.StartCoroutineWatched(Co_ExpGaugeAnim((bool isLevelUp) =>
				{
					//0x1D534D4
					return;
				})));
			}
			while (m_layoutPointAnim.IsPlayingChildren())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E771C Offset: 0x6E771C VA: 0x6E771C
		// // RVA: 0x1D528CC Offset: 0x1D528CC VA: 0x1D528CC
		private IEnumerator Co_CountBonus(List<Coroutine> coutupCoroutines, int point, int bonus)
		{
			//0x1D534DC
			coutupCoroutines.Add(this.StartCoroutineWatched(Co_CountUpAnim(point, bonus)));
			m_layoutPointAnim.StartChildrenAnimGoStop("go_in_co_up", "st_in_co_up");
			while (m_layoutPointAnim.IsPlayingChildren())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E7794 Offset: 0x6E7794 VA: 0x6E7794
		// // RVA: 0x1D529C0 Offset: 0x1D529C0 VA: 0x1D529C0
		private IEnumerator Co_CountUpAnim(int point, int bonus)
		{
			float currentTime; // 0x1C
			float timeLength; // 0x20
			int lastPoint; // 0x24

			//0x1D53C34
			currentTime = 0;
			lastPoint = (int)(bonus / 100.0f * point + point);
			timeLength = 0.4f;
			do
			{
				currentTime += TimeWrapper.deltaTime;
				if (timeLength <= currentTime)
					break;
				SetUpPoint((int)XeSys.Math.Tween.EasingInOutSine(point, lastPoint, currentTime / timeLength));
				yield return null;
			} while (true);
			SetUpPoint(lastPoint);
		}

		// // RVA: 0x1D523A8 Offset: 0x1D523A8 VA: 0x1D523A8
		private void UpdateGaugePosition(float normalizePos)
		{
			int s = (int)((m_layoutGauge.GetView(0).FrameAnimation.FrameNum + 1) * normalizePos);
			m_layoutGauge.StartChildrenAnimGoStop(s, s);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E780C Offset: 0x6E780C VA: 0x6E780C
		// // RVA: 0x1D52AA0 Offset: 0x1D52AA0 VA: 0x1D52AA0
		private IEnumerator Co_ExpGaugeAnim(Action<bool> callback)
		{
			JJOELIOGMKK_DivaIntimacyInfo.MKGIDHAHAIK result; // 0x18
			int crntMaxExp; // 0x1C
			float endNormExp; // 0x20
			float startValue; // 0x24
			float endValue; // 0x28
			int currentFrameLevel; // 0x2C
			int levelDiff; // 0x30
			float currentTime; // 0x34
			float timeLength; // 0x38

			//0x1D53E90
			result = m_viewData.HBODCMLFDOB;
			int a1 = m_viewData.JCFAPAOLDOI(result.CPDEMMFGKED_Level + 1);
			crntMaxExp = m_viewData.JCFAPAOLDOI(result.KBHJOBKOOGC_NextLevel + 1);
			float f = 1;
			if(!result.EDPNAEOKGNM)
				f = result.BJHAMEJPGAJ_Exp * 1.0f / a1;
			endNormExp = 1;
			if (!result.PFIILLOIDIL)
				endNormExp = result.EOIJEGJDLAN_AfterExp * 1.0f / crntMaxExp;
			startValue = f + result.CPDEMMFGKED_Level;
			if (result.EDPNAEOKGNM)
				startValue = result.CPDEMMFGKED_Level;
			endValue = result.KBHJOBKOOGC_NextLevel;
			if (!result.PFIILLOIDIL)
				endValue = endNormExp + result.KBHJOBKOOGC_NextLevel;
			currentFrameLevel = result.CPDEMMFGKED_Level;
			currentTime = 0;
			levelDiff = result.KBHJOBKOOGC_NextLevel - result.CPDEMMFGKED_Level;
			timeLength = 1.5f;
			PlayCountUpLoopSE();
			do
			{
				int prevLevel = currentFrameLevel;
				currentTime += TimeWrapper.deltaTime;
				float f2 = XeSys.Math.Tween.EasingInOutSine(startValue, endValue, currentTime / timeLength);
				currentFrameLevel = (int)(f2 - (f2 % 1));
				if (result.KBHJOBKOOGC_NextLevel == currentFrameLevel)
					UpdateGaugePosition(result.PFIILLOIDIL ? 1 : (f2 % 1));
				else
					UpdateGaugePosition(f2 % 1);
				int exp = m_viewData.JCFAPAOLDOI(currentFrameLevel + 1);
				SetExp((int)(exp * (f2 % 1)), exp);
				if(prevLevel < currentFrameLevel)
				{
					if (!result.PFIILLOIDIL)
						LevelupProcess(currentFrameLevel);
					else
						LevelMaxProcess(currentFrameLevel);
				}
				if(!result.PFIILLOIDIL && timeLength > currentTime)
				{
					yield return null;
				}
				else
				{
					break;
				}
			} while (true);
			UpdateGaugePosition(endNormExp);
			m_numLevel.SetNumber(result.KBHJOBKOOGC_NextLevel, 0);
			SetExp(result.EOIJEGJDLAN_AfterExp, crntMaxExp);
			m_countUpSEPlayback.Stop();
			if (callback != null)
				callback(levelDiff > 0);
		}

		// // RVA: 0x1D52B68 Offset: 0x1D52B68 VA: 0x1D52B68
		private void LevelupProcess(int level)
		{
			SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_005);
			m_numLevel.SetNumber(level, 0);
		}

		// // RVA: 0x1D52BF8 Offset: 0x1D52BF8 VA: 0x1D52BF8
		private void LevelMaxProcess(int level)
		{
			m_countUpSEPlayback.Stop();
			m_layoutLevelMax.StartChildrenAnimGoStop("01");
			UpdateGaugePosition(1);
			LevelupProcess(level);
		}

		// // RVA: 0x1D52248 Offset: 0x1D52248 VA: 0x1D52248
		// private void SetLevel(int value) { }

		// // RVA: 0x1D52288 Offset: 0x1D52288 VA: 0x1D52288
		private void SetExp(int now, int next)
		{
			if(next < 1)
			{
				m_layoutExpDigit.StartChildrenAnimGoStop("max");
			}
			else
			{
				string l = GetDigitLabel(next);
				m_layoutExpDigit.StartChildrenAnimGoStop(l);
				m_numExpNow.SetNumber(now, 0);
				m_numExpNext.SetNumber(next, 0);
			}
		}

		// // RVA: 0x1D52C9C Offset: 0x1D52C9C VA: 0x1D52C9C
		private string GetDigitLabel(int num)
		{
			if (num == 0)
				num = 1;
			else
				num = (int)Mathf.Log10(num) + 1;
			if (num == 3)
				return "02";
			if (num >= 1 && num < 3)
				return "01";
			return "03";
		}

		// // RVA: 0x1D52D78 Offset: 0x1D52D78 VA: 0x1D52D78
		private void SetUpPoint(int value)
		{
			for(int i = 0; i < m_numPoint.Length; i++)
			{
				m_numPoint[i].SetNumber(value, 0);
			}
		}

		// // RVA: 0x1D52E1C Offset: 0x1D52E1C VA: 0x1D52E1C
		// private void SetUpBonus(int value) { }

		// // RVA: 0x1D52E5C Offset: 0x1D52E5C VA: 0x1D52E5C
		private void PlayCountUpLoopSE()
		{
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_004);
		}

		// // RVA: 0x1D52028 Offset: 0x1D52028 VA: 0x1D52028
		// private void StopCountUpLoopSE() { }

		// RVA: 0x1D52EBC Offset: 0x1D52EBC VA: 0x1D52EBC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_gauge_pos") as AbsoluteLayout;
			m_layoutPoint = layout.FindViewById("swtbl_fs_p_01") as AbsoluteLayout;
			m_layoutExpDigit = layout.FindViewById("swtbl_fs_num") as AbsoluteLayout;
			m_layoutLevel = layout.FindViewById("sw_gauge_fs_anim_01") as AbsoluteLayout;
			m_layoutLevelMax = layout.FindViewById("swtbl_fs_lv_max") as AbsoluteLayout;
			m_layoutGauge = layout.FindViewById("swfrm_fs") as AbsoluteLayout;
			m_layoutPointAnimTbl = new AbsoluteLayout[2];
			m_layoutPointAnimTbl[0] = layout.FindViewById("sw_fs_p_anim_01") as AbsoluteLayout;
			m_layoutPointAnimTbl[1] = layout.FindViewById("sw_fs_p_anim_02") as AbsoluteLayout;
			m_layoutRoot.StartAllAnimGoStop("st_wait");
			Loaded();
			return true;
		}
	}
}
