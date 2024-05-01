using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using CriWare;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecoIntimacyInfo : LayoutUGUIScriptBase
	{
		[Serializable]
		private class Variables
		{
			public NumberBase m_numExpNow; // 0x8
			public NumberBase m_numExpNext; // 0xC
			public NumberBase m_numLevel; // 0x10
			public NumberBase[] m_numPoint; // 0x14
			public AbsoluteLayout m_layoutPoint; // 0x18
			public AbsoluteLayout m_layoutPointAnim; // 0x1C
			public AbsoluteLayout[] m_layoutPointAnimTbl; // 0x20
			public AbsoluteLayout m_layoutExpDigit; // 0x24
			public AbsoluteLayout m_layoutLevel; // 0x28
			public AbsoluteLayout m_layoutLevelMax; // 0x2C
			public AbsoluteLayout m_layoutGauge; // 0x30
		}

		[SerializeField]
		private Variables m_left; // 0x14
		[SerializeField]
		private Variables m_right; // 0x18
		[SerializeField]
		private RectTransform m_RightFarthest; // 0x1C
		private float m_RightFarthestRelativePos; // 0x20
		private NumberBase m_numExpNow; // 0x24
		private NumberBase m_numExpNext; // 0x28
		private NumberBase m_numLevel; // 0x2C
		private NumberBase[] m_numPoint; // 0x30
		private AbsoluteLayout m_layoutRoot_; // 0x34
		private AbsoluteLayout m_layoutRoot; // 0x38
		private AbsoluteLayout m_layoutPoint; // 0x3C
		private AbsoluteLayout m_layoutPointAnim; // 0x40
		private AbsoluteLayout[] m_layoutPointAnimTbl; // 0x44
		private AbsoluteLayout m_layoutExpDigit; // 0x48
		private AbsoluteLayout m_layoutLevel; // 0x4C
		private AbsoluteLayout m_layoutLevelMax; // 0x50
		private AbsoluteLayout m_layoutGauge; // 0x54
		private JJOELIOGMKK_DivaIntimacyInfo m_viewData; // 0x58
		private CriAtomExPlayback m_countUpSEPlayback; // 0x5C

		// RVA: 0x19E7F84 Offset: 0x19E7F84 VA: 0x19E7F84
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop();
		}

		// // RVA: 0x19E7F9C Offset: 0x19E7F9C VA: 0x19E7F9C
		public void Setup(JJOELIOGMKK_DivaIntimacyInfo viewData, DecorationChara chara, Camera cam)
		{
			transform.SetParent(chara.GetObject().transform, false);
			transform.localPosition = new Vector3(0, chara.bottomOfs.y * 0, 0);
			m_viewData = viewData;
			if(m_RightFarthestRelativePos == 0)
			{
				m_RightFarthestRelativePos = m_RightFarthest.transform.position.x - transform.position.x + m_RightFarthest.rect.width;
			}
			float f = 1;
			if(chara.decorationController.scrollController.m_controlDataList.Count > 0)
			{
				f = chara.decorationController.scrollController.m_controlDataList[0].scaler.scaleFactor;
			}
			Vector3 v = cam.WorldToViewportPoint(transform.position + new Vector3(0, f * m_RightFarthestRelativePos, 0));
			if(v.x >= 1)
			{
				m_layoutRoot.StartChildrenAnimGoStop("02");
				m_layoutRoot_.StartChildrenAnimGoStop("02");
				Setup(m_left);
			}
			else
			{
				m_layoutRoot.StartChildrenAnimGoStop("01");
				m_layoutRoot_.StartChildrenAnimGoStop("01");
				Setup(m_right);
			}
			m_layoutLevelMax.StartChildrenAnimGoStop(viewData.HBODCMLFDOB.PFIILLOIDIL ? "01" : "02");
			m_numLevel.SetNumber(m_viewData.HEKJGCMNJAB_CurrentLevel, 0);
			if(!m_viewData.HBODCMLFDOB.PFIILLOIDIL)
			{
				SetExp(m_viewData.KPEAGFJHNDP_CurrentLevelExp, m_viewData.KOKCFJDMJLI);
				UpdateGaugePosition(m_viewData.KPEAGFJHNDP_CurrentLevelExp * 1.0f / m_viewData.KOKCFJDMJLI);
			}
			else
			{
				SetExp(0, 0);
				UpdateGaugePosition(1);
			}
		}

		// // RVA: 0x19E8864 Offset: 0x19E8864 VA: 0x19E8864
		public void Enter()
		{
			m_layoutLevel.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x19E88F0 Offset: 0x19E88F0 VA: 0x19E88F0
		public void Leave()
		{
			m_layoutLevel.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x19E897C Offset: 0x19E897C VA: 0x19E897C
		// public void Show() { }

		// // RVA: 0x19E89F8 Offset: 0x19E89F8 VA: 0x19E89F8
		public void Hide()
		{
			m_layoutRoot.StartAllAnimGoStop("st_wait");
		}

		// // RVA: 0x19E8A74 Offset: 0x19E8A74 VA: 0x19E8A74
		public void StartPointUp(Action callback)
		{
			this.StartCoroutineWatched(Co_StartPointUp(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D0E9C Offset: 0x6D0E9C VA: 0x6D0E9C
		// // RVA: 0x19E8A98 Offset: 0x19E8A98 VA: 0x19E8A98
		private IEnumerator Co_StartPointUp(Action callback)
		{
			List<Coroutine> coutupCoroutines; // 0x18
			int i; // 0x1C

			//0x19EACF0
			if(m_viewData.HBODCMLFDOB.HOMOKJEKKNK_Bonus < 1)
			{
				m_layoutPointAnim = m_layoutPointAnimTbl[0];
			}
			coutupCoroutines = new List<Coroutine>();
			yield return Co.R(Co_CountPoint(coutupCoroutines, m_viewData.HBODCMLFDOB.ODHAIDDEFJL_GetExp, m_viewData.HBODCMLFDOB.HOMOKJEKKNK_Bonus));
			for(i = 0; i < coutupCoroutines.Count; i++)
			{
				yield return coutupCoroutines[i];
			}
			if(callback != null)
				callback();
		}

		// // RVA: 0x19E8B60 Offset: 0x19E8B60 VA: 0x19E8B60
		public bool IsLayoutLevelPlayingEnd()
		{
			return !m_layoutLevel.IsPlayingChildren();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D0F14 Offset: 0x6D0F14 VA: 0x6D0F14
		// // RVA: 0x19E8B90 Offset: 0x19E8B90 VA: 0x19E8B90
		private IEnumerator Co_CountPoint(List<Coroutine> coutupCoroutines, int point, int bonus)
		{
			int i; // 0x20

			//0x19E9F3C
			SetUpPoint(point);
			m_layoutPointAnim.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_009);
			while(m_layoutPointAnim.IsPlayingChildren())
				yield return null;
			if(bonus > 0)
			{
				yield return Co.R(Co_CountBonus(coutupCoroutines, point, bonus));
			}
			//LAB_019ea2e4
			m_layoutPointAnim.StartChildrenAnimGoStop("go_out", "st_out");
			yield return null;
			for(i = 0; i < 30; i++)
			{
				yield return null;
			}
			if(!m_viewData.HBODCMLFDOB.EDPNAEOKGNM)
			{
				coutupCoroutines.Add(this.StartCoroutineWatched(Co_ExpGaugeAnim((bool isLevelUp) =>
				{
					//0x19E9CEC
					return;
				})));
			}
			while(m_layoutPointAnim.IsPlayingChildren())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D0F8C Offset: 0x6D0F8C VA: 0x6D0F8C
		// // RVA: 0x19E8C88 Offset: 0x19E8C88 VA: 0x19E8C88
		private IEnumerator Co_CountBonus(List<Coroutine> coutupCoroutines, int point, int bonus)
		{
			//0x19E9CF4
			coutupCoroutines.Add(this.StartCoroutineWatched(Co_CountUpAnim(point, bonus)));
			m_layoutPointAnim.StartChildrenAnimGoStop("go_in_co_up", "st_in_co_up");
			while(m_layoutPointAnim.IsPlayingChildren())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D1004 Offset: 0x6D1004 VA: 0x6D1004
		// // RVA: 0x19E8D7C Offset: 0x19E8D7C VA: 0x19E8D7C
		private IEnumerator Co_CountUpAnim(int point, int bonus)
		{
			float currentTime; // 0x1C
			float timeLength; // 0x20
			int lastPoint; // 0x24

			//0x19EA41C
			currentTime = 0;
			lastPoint = (int)(bonus / 100.0f * point + point);
			timeLength = 0.4f;
			while(true)
			{
				currentTime += Time.deltaTime;
				if(timeLength <= currentTime)
					break;
				SetUpPoint((int)XeSys.Math.Tween.EasingInOutSine(point, lastPoint, currentTime / timeLength));
				yield return null;
			}
			SetUpPoint(lastPoint);
		}

		// // RVA: 0x19E87A0 Offset: 0x19E87A0 VA: 0x19E87A0
		private void UpdateGaugePosition(float normalizePos)
		{
			int pos = (int)((m_layoutGauge.GetView(0).FrameAnimation.FrameNum + 1) * normalizePos);
			m_layoutGauge.StartChildrenAnimGoStop(pos, pos);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D107C Offset: 0x6D107C VA: 0x6D107C
		// // RVA: 0x19E8E5C Offset: 0x19E8E5C VA: 0x19E8E5C
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

			//0x19EA678
			result = m_viewData.HBODCMLFDOB;
			int a1 = m_viewData.JCFAPAOLDOI(result.CPDEMMFGKED_Level + 1);
			crntMaxExp = m_viewData.JCFAPAOLDOI(result.KBHJOBKOOGC_NextLevel + 1);
			float f = 1;
			if(!result.EDPNAEOKGNM)
				f = result.BJHAMEJPGAJ_Exp * 1.0f / a1;
			endNormExp = 1;
			if(!result.PFIILLOIDIL)
				endNormExp = result.EOIJEGJDLAN_AfterExp * 1.0f / crntMaxExp;
			startValue = f + result.CPDEMMFGKED_Level;
			if (result.EDPNAEOKGNM)
				startValue = result.CPDEMMFGKED_Level;
			endValue = result.KBHJOBKOOGC_NextLevel;
			if(!result.PFIILLOIDIL)
				endValue += endNormExp;
			currentFrameLevel = result.CPDEMMFGKED_Level;
			currentTime = 0;
			levelDiff = result.KBHJOBKOOGC_NextLevel - result.CPDEMMFGKED_Level;
			timeLength = 1.5f;
			PlayCountUpLoopSE();
			while(true)
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
				SetExp((int)((f2 % 1) * exp), exp);
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
			}
			UpdateGaugePosition(endNormExp);
			m_numLevel.SetNumber(result.KBHJOBKOOGC_NextLevel, 0);
			SetExp(result.EOIJEGJDLAN_AfterExp, crntMaxExp);
			m_countUpSEPlayback.Stop();
			if(callback != null)
				callback(levelDiff > 0);
		}

		// // RVA: 0x19E8F24 Offset: 0x19E8F24 VA: 0x19E8F24
		private void LevelupProcess(int level)
		{
			SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_005);
			m_numLevel.SetNumber(level, 0);
		}

		// // RVA: 0x19E8FB4 Offset: 0x19E8FB4 VA: 0x19E8FB4
		private void LevelMaxProcess(int level)
		{
			m_countUpSEPlayback.Stop();
			m_layoutLevelMax.StartChildrenAnimGoStop("01");
			UpdateGaugePosition(1);
			LevelupProcess(level);
		}

		// // RVA: 0x19E8640 Offset: 0x19E8640 VA: 0x19E8640
		// private void SetLevel(int value) { }

		// // RVA: 0x19E8680 Offset: 0x19E8680 VA: 0x19E8680
		private void SetExp(int now, int next)
		{
			if(next < 1)
			{
				m_layoutExpDigit.StartChildrenAnimGoStop("max");
			}
			else
			{
				m_layoutExpDigit.StartChildrenAnimGoStop(GetDigitLabel(next));
				m_numExpNow.SetNumber(now, 0);
				m_numExpNext.SetNumber(next, 0);
			}
		}

		// // RVA: 0x19E9058 Offset: 0x19E9058 VA: 0x19E9058
		private string GetDigitLabel(int num)
		{
			int a = 1;
			if(num != 0)
				a = (int)Mathf.Log10(num) + 1;
			if(a == 3)
				return "02";
			if(a > 0 && a < 3)
				return "01";
			return "03";
		}

		// // RVA: 0x19E9134 Offset: 0x19E9134 VA: 0x19E9134
		private void SetUpPoint(int value)
		{
			for(int i = 0; i < m_numPoint.Length; i++)
			{
				m_numPoint[i].SetNumber(value, 0);
			}
		}

		// // RVA: 0x19E91D8 Offset: 0x19E91D8 VA: 0x19E91D8
		// private void SetUpBonus(int value) { }

		// // RVA: 0x19E91DC Offset: 0x19E91DC VA: 0x19E91DC
		private void PlayCountUpLoopSE()
		{
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_004);
		}

		// // RVA: 0x19E7F90 Offset: 0x19E7F90 VA: 0x19E7F90
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x19E8630 Offset: 0x19E8630 VA: 0x19E8630
		// public void SetRightSide() { }

		// // RVA: 0x19E8638 Offset: 0x19E8638 VA: 0x19E8638
		// public void SetLeftSide() { }

		// // RVA: 0x19E923C Offset: 0x19E923C VA: 0x19E923C
		private void Setup(Variables variables)
		{
			m_numExpNow = variables.m_numExpNow;
			m_numExpNext = variables.m_numExpNext;
			m_numLevel = variables.m_numLevel;
			m_numPoint = variables.m_numPoint;
			m_layoutPoint = variables.m_layoutPoint;
			m_layoutPointAnim = variables.m_layoutPointAnim;
			m_layoutPointAnimTbl = variables.m_layoutPointAnimTbl;
			m_layoutExpDigit = variables.m_layoutExpDigit;
			m_layoutLevel = variables.m_layoutLevel;
			m_layoutLevelMax = variables.m_layoutLevelMax;
			m_layoutGauge = variables.m_layoutGauge;
		}

		// RVA: 0x19E9384 Offset: 0x19E9384 VA: 0x19E9384 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_deco_present") as AbsoluteLayout;
			m_layoutRoot_ = layout.FindViewById("swtbl_fs_p_ga_anim") as AbsoluteLayout;
			m_right.m_layoutLevel = layout.FindViewByExId("swtbl_fs_p_ga_anim_sw_fs_p_ga_anim_01") as AbsoluteLayout;
			m_right.m_layoutExpDigit = m_right.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_num") as AbsoluteLayout;
			m_right.m_layoutLevelMax = m_right.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_lv_num_max") as AbsoluteLayout;
			m_right.m_layoutGauge = m_right.m_layoutLevel.FindViewByExId("deco_fs_ga_sw_ga_anim") as AbsoluteLayout;
			m_right.m_layoutPointAnimTbl = new AbsoluteLayout[2];
			m_right.m_layoutPointAnimTbl[0] = layout.FindViewByExId("swtbl_deco_present_sw_fs_p_num_s_anim") as AbsoluteLayout;
			m_left.m_layoutLevel = layout.FindViewByExId("swtbl_fs_p_ga_anim_sw_fs_p_ga_anim_02") as AbsoluteLayout;
			m_left.m_layoutExpDigit = m_left.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_num") as AbsoluteLayout;
			m_left.m_layoutLevelMax = m_left.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_lv_num_max") as AbsoluteLayout;
			m_left.m_layoutGauge = m_left.m_layoutLevel.FindViewByExId("deco_fs_ga_sw_ga_anim") as AbsoluteLayout;
			m_left.m_layoutPointAnimTbl = new AbsoluteLayout[2];
			m_left.m_layoutPointAnimTbl[0] = layout.FindViewByExId("swtbl_deco_present_sw_fs_p_num_s_anim") as AbsoluteLayout;
			m_layoutRoot.StartAllAnimGoStop("st_wait");
			Setup(m_right);
			Loaded();
			return true;
		}
	}
}
