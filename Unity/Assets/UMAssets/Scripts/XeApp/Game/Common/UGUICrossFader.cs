using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUICrossFader : MonoBehaviour
	{
		[Serializable]
		private class TargetGroup
		{
			[SerializeField]
			//[TooltipAttribute]
			public List<Graphic> m_fadeTargets; // 0x8
		}
		
		//[TooltipAttribute] // RVA: 0x68C490 Offset: 0x68C490 VA: 0x68C490
		[SerializeField]
		private List<TargetGroup> m_targetGroups; // 0xC
		//[TooltipAttribute] // RVA: 0x68C4F4 Offset: 0x68C4F4 VA: 0x68C4F4
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve; // 0x10
		//[TooltipAttribute] // RVA: 0x68C53C Offset: 0x68C53C VA: 0x68C53C
		[SerializeField]
		private float m_animeLengthSec = 2; // 0x14
		private bool m_isEnableCrossFade; // 0x18
		private int m_startGroupNo; // 0x1C
		private int m_endGroupNo; // 0x20
		private int m_currentGroupNo; // 0x24
		private float m_corssFadeTime; // 0x28
		private bool m_isLoop; // 0x2C

		public int GroupCount { get { return m_targetGroups.Count; } } //0x1CD23CC

		// RVA: 0x1CD2444 Offset: 0x1CD2444 VA: 0x1CD2444
		private void Awake()
		{
			StartCrossFade(0, 0, false);
		}

		// RVA: 0x1CD2488 Offset: 0x1CD2488 VA: 0x1CD2488
		private void Update()
		{
			UpdateCrossFade(Time.deltaTime);
		}

		//// RVA: 0x1CD2830 Offset: 0x1CD2830 VA: 0x1CD2830
		public void StartCrossFade(int startGroupNo, int endGroupNo, bool isLoop)
		{
			m_endGroupNo = Mathf.Clamp(endGroupNo, 0, GroupCount - 1);
			m_startGroupNo = Mathf.Clamp(startGroupNo, 0, m_endGroupNo);
			m_currentGroupNo = m_startGroupNo;
			m_corssFadeTime = 0;
			m_isLoop = isLoop;
			m_isEnableCrossFade = startGroupNo != endGroupNo;
			for(int i = 0; i < GroupCount; i++)
			{
				SetGroupAlpha(m_targetGroups[i], m_currentGroupNo == i ? 1 : 0);
			}
		}

		//// RVA: 0x1CD2D24 Offset: 0x1CD2D24 VA: 0x1CD2D24
		public void StartCrossFade()
		{
			StartCrossFade(0, GroupCount - 1, true);
		}

		//// RVA: 0x1CD2468 Offset: 0x1CD2468 VA: 0x1CD2468
		public void Stop(int groupNo)
		{
			StartCrossFade(groupNo, groupNo, false);
		}

		//// RVA: 0x1CD2D54 Offset: 0x1CD2D54 VA: 0x1CD2D54
		//public void ReStart() { }

		//// RVA: 0x1CD24AC Offset: 0x1CD24AC VA: 0x1CD24AC
		private void UpdateCrossFade(float deltaTime)
		{
			if (!m_isEnableCrossFade)
				return;
			int cur = (m_currentGroupNo + 1 - m_startGroupNo) % ((1 - m_startGroupNo) + m_endGroupNo);
			TargetGroup s = m_targetGroups[m_currentGroupNo];
			TargetGroup n = m_targetGroups[cur + m_startGroupNo];
			m_corssFadeTime += deltaTime;
			if(m_corssFadeTime >= m_animeLengthSec)
			{
				SetGroupAlpha(m_targetGroups[m_currentGroupNo], 0);
				m_currentGroupNo = cur + m_startGroupNo;
				int next = (m_currentGroupNo + 1 - m_startGroupNo) % ((1 - m_startGroupNo) + m_endGroupNo);
				next += m_startGroupNo;
				s = m_targetGroups[m_currentGroupNo];
				n = m_targetGroups[next];
				float f = m_corssFadeTime;
				if (m_animeLengthSec <= 0)
				{
					f = 0;
					m_corssFadeTime = f;
				}
				else
				{
					if(m_animeLengthSec <= f)
					{
						do
						{
							f -= m_animeLengthSec;
						} while (m_animeLengthSec <= f);
						m_corssFadeTime = f;
					}
				}
				if(m_startGroupNo == next && !m_isLoop)
				{
					SetGroupAlpha(m_targetGroups[m_currentGroupNo], 1);
					m_isEnableCrossFade = false;
					return;
				}
			}
			float t = 1;
			if (m_animeLengthSec > 0)
				t = m_corssFadeTime / m_animeLengthSec;
			float u = m_animeCurve[0].Evaluate(t * m_animeCurve[0].keys[m_animeCurve[0].length - 1].time);
			SetGroupAlpha(s, 1 - u);
			SetGroupAlpha(n, u);
		}

		//// RVA: 0x1CD29AC Offset: 0x1CD29AC VA: 0x1CD29AC
		private void SetGroupAlpha(TargetGroup targetGroup, float alpha)
		{
			foreach(var t in targetGroup.m_fadeTargets)
			{
				if(alpha <= 0)
				{
					t.gameObject.SetActive(false);
				}
				else
				{
					t.gameObject.SetActive(true);
				}
				t.color = new Color(t.color.r, t.color.g, t.color.b, alpha);
				if(t is ColorGroup)
				{
					(t as ColorGroup).SetMaterialDirty();
				}
			}
		}

		//// RVA: 0x1CD2984 Offset: 0x1CD2984 VA: 0x1CD2984
		//private int CalcNextGroupNo(int currentGroup, int startGroup, int endGroup) { }
	}
}
