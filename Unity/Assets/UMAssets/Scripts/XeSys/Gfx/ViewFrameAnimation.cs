using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class ViewFrameAnimation
	{
		private enum AnimAction
		{
			stop = 0,
			loop = 1,
		}

		[SerializeField]
		private ViewFrameAnimationData data; // 0x8
		private ViewFrameAnimation.AnimAction m_Action; // 0xC
		private float m_startTime; // 0x10
		private float m_endTime = -1.0f; // 0x14
		private float m_AnimCount; // 0x18
		private bool m_IsAnimEnd = true; // 0x1C
		private float m_timeScale = 1.0f; // 0x20
		private int m_PrevFrameData = -1; // 0x24
		private int m_NextFrameData = -1; // 0x28
		private float m_FrameDataRate; // 0x2C
		[SerializeField]
		private float m_FrameSec = 0.03333334f; // 0x30
		[SerializeField]
		private float m_BaseX; // 0x34
		[SerializeField]
		private float m_BaseY; // 0x38

		public bool IsAnimEnd { get { return m_IsAnimEnd; } set { m_IsAnimEnd = value; } } //0x1EE7058 0x1EE7010
		public float AnimCount { get { return m_AnimCount; } set { m_AnimCount = value; } } //0x1EE958C 0x1EE9594
		// public float TimeScale { get; set; } 0x1EE5EA4 0x1EE5EF8
		// public float FrameSec { get; set; } 0x1EE959C 0x1EE95A4
		public int FrameCount { get { return Mathf.RoundToInt(m_AnimCount / m_FrameSec); } private set { return; } } //0x1EE95AC 0x1EE95C4
		// public float BaseX { get; set; } 0x1EE95C8 0x1EE95D0
		// public float BaseY { get; set; } 0x1EE95D8 0x1EE95E0
		public int FrameNum { get { return data.FrameNum; } } //0x1EE95E8
		// public string ID { get; set; } 0x1EE9614 0x1EE9640
		// public TimeMap AnimTimeMap { get; } 0x1EE9670
		// public int LabelCount { get; } 0x1EE969C
		public LabelData[] LabelList { get { return data.m_LabelList; } } //0x1EE9700
		// public bool IsPosAnim { get; set; } 0x1EE9724 0x1EE6E7C
		// public bool IsMoveAnim { get; set; } 0x1EE9790 0x1EE97B8
		// public bool IsMoveBezierX { get; set; } 0x1EE97F0 0x1EE9818
		// public bool IsMoveBezierY { get; set; } 0x1EE9850 0x1EE9878
		// public bool IsSizeAnim { get; set; } 0x1EE98B0 0x1EE6EB4
		// public bool IsScaleAnim { get; set; } 0x1EE98D8 0x1EE6EEC
		// public bool IsRotAnim { get; set; } 0x1EE9900 0x1EE6F24
		// public bool IsColAnim { get; set; } 0x1EE9928 0x1EE6F5C
		// public bool IsAlphaAnim { get; set; } 0x1EE9950 0x1EE9978
		// public bool IsCenterAnim { get; set; } 0x1EE99B0 0x1EE6F94
		public FrameData[] F { get { return data.F; } }
		public int FrameDataCount { get { return data.FrameDataCount; } }

		// RVA: 0x1EE99D8 Offset: 0x1EE99D8 VA: 0x1EE99D8
		// public void .ctor(int frameNum) { }

		// RVA: 0x1EE9B34 Offset: 0x1EE9B34 VA: 0x1EE9B34
		// public void Initialize(FrameData[] frameDatas, Dictionary<int, string> labelList) { }

		// // RVA: 0x1EE8984 Offset: 0x1EE8984 VA: 0x1EE8984
		public void InitializeEmptyAnimation(bool force = false)
		{
			if(!force && data != null)
				return;

			data = new ViewFrameAnimationData();
		}

		// // RVA: 0x1EE9C2C Offset: 0x1EE9C2C VA: 0x1EE9C2C
		// public void InitAnimTimeMap(int count) { }

		// // RVA: 0x1EE9CD0 Offset: 0x1EE9CD0 VA: 0x1EE9CD0
		// public void SetTimeMapData(int index, int start, int end, TimeMapData.TimeMapType tmType, int strength, int count) { }

		// // RVA: 0x1EE9D90 Offset: 0x1EE9D90 VA: 0x1EE9D90
		// public void SetCustomTimeMapElm(int tmIndex, int elmIndex, float point, float next, float prev) { }

		// // RVA: 0x1EE9E84 Offset: 0x1EE9E84 VA: 0x1EE9E84
		public float SearchLabelFrame(string label)
		{
			return data.SearchLabelFrame(label);
		}

		// // RVA: 0x1EE8AD0 Offset: 0x1EE8AD0 VA: 0x1EE8AD0
		public void StartAnim()
		{
			m_startTime = 0;
			m_endTime = -1;
			m_AnimCount = 0;
			m_IsAnimEnd = false;
		}

		// // RVA: 0x1EE8B4C Offset: 0x1EE8B4C VA: 0x1EE8B4C
		public void StartAnimGoStop(int start, int end)
		{
			m_Action = AnimAction.stop;
			m_IsAnimEnd = false;
			m_startTime = start * m_FrameSec;
			m_endTime = end * m_FrameSec;
			m_AnimCount = m_startTime;
		}

		// // RVA: 0x1EE9FB8 Offset: 0x1EE9FB8 VA: 0x1EE9FB8
		// public void StartAnimGoStopTime(float start, float end) { }

		// // RVA: 0x1EE8BBC Offset: 0x1EE8BBC VA: 0x1EE8BBC
		public void StartAnimGoStop(string startLabel, string endLabel)
		{
			float startTime = data.SearchLabelTime(startLabel);
			float endTime = data.SearchLabelTime(endLabel);
			if(startTime >= 0)
			{
				if(endTime >= 0)
				{
					m_Action = AnimAction.stop;
					m_startTime = startTime;
					m_endTime = endTime;
					m_AnimCount = startTime;
					m_IsAnimEnd = false;
				}
			}
		}

		// // RVA: 0x1EE8C80 Offset: 0x1EE8C80 VA: 0x1EE8C80
		public void StartAnimGoStop(string startLabel)
		{
			float startTime, endTime;
			if(data.SearchLabelTimePair(startLabel, m_FrameSec, out startTime, out endTime))
			{
				m_Action = AnimAction.stop;
				m_startTime = startTime;
				m_endTime = endTime;
				m_AnimCount = startTime;
				m_IsAnimEnd = false;
			}
		}

		// // RVA: 0x1EE93C0 Offset: 0x1EE93C0 VA: 0x1EE93C0
		// public void StartAnimInverseGoStop(string startLabel) { }

		// // RVA: 0x1EE8D68 Offset: 0x1EE8D68 VA: 0x1EE8D68
		public void StartAnimLoop(int start, int end)
		{
			m_Action = AnimAction.loop;
			m_IsAnimEnd = false;
			m_startTime = start * m_FrameSec;
			m_endTime = end * m_FrameSec;
			m_AnimCount = m_startTime;
		}

		// // RVA: 0x1EE8E14 Offset: 0x1EE8E14 VA: 0x1EE8E14
		public void StartAnimLoop(int current, int start, int end)
		{
			m_Action = AnimAction.loop;
			m_IsAnimEnd = false;
			m_startTime = start * m_FrameSec;
			m_endTime = end * m_FrameSec;
			m_AnimCount = current * m_FrameSec;
		}

		// // RVA: 0x1EE8E94 Offset: 0x1EE8E94 VA: 0x1EE8E94
		public void StartAnimLoop(string startLabel, string endLabel)
		{
			if(data != null)
			{
				float startTime = data.SearchLabelTime(startLabel);
				float endTime = data.SearchLabelTime(endLabel);
				if(startTime >= 0)
				{
					if(endTime >= 0)
					{
						m_Action = AnimAction.loop;
						m_startTime = startTime;
						m_endTime = endTime;
						m_AnimCount = startTime;
						m_IsAnimEnd = false;
					}
				}
			}
		}

		// // RVA: 0x1EE8F48 Offset: 0x1EE8F48 VA: 0x1EE8F48
		public void StartAnimLoop(string startLabel)
		{
			if(data != null)
			{
				float start, end;
				if(data.SearchLabelTimePair(startLabel, m_FrameSec, out start, out end))
				{
					m_Action = AnimAction.loop;
					m_startTime = start;
					m_endTime = end;
					m_AnimCount = start;
					m_IsAnimEnd = false;
				}
			}
		}

		// // RVA: 0x1EE8FE4 Offset: 0x1EE8FE4 VA: 0x1EE8FE4
		public void FinishAnimLoop()
		{
			if (m_Action == AnimAction.loop)
				m_Action = AnimAction.stop;
		}

		// // RVA: 0x1EE71BC Offset: 0x1EE71BC VA: 0x1EE71BC
		public void Update(float dt)
		{
			if(m_IsAnimEnd)
				return;
			float time = m_endTime;
			float elapsed = m_timeScale * dt;
			float animCount = m_AnimCount;
			bool hitEnd = false;
			if(time >= 0)
			{
				hitEnd = false;
				if(m_startTime < time)
				{
					m_AnimCount = animCount + elapsed;
					if(m_AnimCount >= time)
					{
						m_AnimCount = time;
						hitEnd = true;
					}
				}
				else
				{
					m_AnimCount = animCount - elapsed;
					if(m_AnimCount <= time)
					{
						m_AnimCount = time;
						hitEnd = true;
					}
				}
			}
			else
			{
				time = m_AnimCount + elapsed;
				m_AnimCount = time;
			}
			float newTime = 0.0f;
			if(data.AnimTimeMap == null || data.AnimTimeMap.DataList == null || data.AnimTimeMap.DataList.Length < 1)
			{
				newTime = m_AnimCount;
			}
			else
			{
				newTime = data.AnimTimeMap.GetPlayFrame(m_AnimCount, m_FrameSec);
			}
			bool res = ApplyFrameAction(animCount, newTime);
			if(hitEnd && !res)
			{
				if(m_Action == AnimAction.loop)
				{
					m_AnimCount = m_startTime;
				}
				else if(m_Action == AnimAction.stop)
				{
					m_IsAnimEnd = true;
				}
			}
			data.SetPrevNextFrameData(newTime, ref m_PrevFrameData, ref m_NextFrameData, out m_FrameDataRate);
		}

		// // RVA: 0x1EE7364 Offset: 0x1EE7364 VA: 0x1EE7364
		public bool GetAnimTransform(ViewTransformData vt, ref bool isUpdateSRT)
		{
			return data.GetAnimTransform(vt, m_PrevFrameData, m_NextFrameData, m_FrameDataRate, ref isUpdateSRT);
		}

		// // RVA: 0x1EE6A44 Offset: 0x1EE6A44 VA: 0x1EE6A44
		// public void InitInterpolationAnim(ViewTransformData transformdata) { }

		// // RVA: 0x1EE7438 Offset: 0x1EE7438 VA: 0x1EE7438
		// public void StartInterpolationAnim(float time) { }

		// // RVA: 0x1EE75C0 Offset: 0x1EE75C0 VA: 0x1EE75C0
		// public void SetInterpolationTargetPos(float x, float y) { }

		// // RVA: 0x1EE778C Offset: 0x1EE778C VA: 0x1EE778C
		// public void SetInterpolationTargetScale(float x, float y) { }

		// // RVA: 0x1EE7920 Offset: 0x1EE7920 VA: 0x1EE7920
		// public void SetInterpolationTargetRot(float rot) { }

		// // RVA: 0x1EE7A7C Offset: 0x1EE7A7C VA: 0x1EE7A7C
		// public void SetInterpolationTargetColor(Color col) { }

		// // RVA: 0x1EE7C2C Offset: 0x1EE7C2C VA: 0x1EE7C2C
		// public void SetInterpolationTargetColor(float r, float g, float b, float a) { }

		// // RVA: 0x1EE7E20 Offset: 0x1EE7E20 VA: 0x1EE7E20
		// public void SetInterpolationTargetColor(float r, float g, float b) { }

		// // RVA: 0x1EE80BC Offset: 0x1EE80BC VA: 0x1EE80BC
		// public void SetInterpolationTargetColAlpha(float a) { }

		// // RVA: 0x1EE83EC Offset: 0x1EE83EC VA: 0x1EE83EC
		// public void SetInterpolationTargetAnimMove(float x, float y) { }

		// // RVA: 0x1EE8680 Offset: 0x1EE8680 VA: 0x1EE8680
		// public void SetInterpolationTargetTransform(ViewTransformData vt) { }

		// // RVA: 0x1EE87C0 Offset: 0x1EE87C0 VA: 0x1EE87C0
		// public void SetInterpolationTargetLoop(ViewAnimation.LoopType loopType) { }

		// // RVA: 0x1EE8A08 Offset: 0x1EE8A08 VA: 0x1EE8A08
		public void CopyTo(ViewFrameAnimation anim)
		{
			if(data == null)
				TodoLogger.LogError(TodoLogger.Layout, "Copying empty data animation");
			anim.data = data;
			anim.m_timeScale = m_timeScale;
			anim.m_BaseX = m_BaseX;
			anim.m_BaseY = m_BaseY;
		}

		// // RVA: 0x1EEA434 Offset: 0x1EEA434 VA: 0x1EEA434
		private bool ApplyFrameAction(float oldTime, float time)
		{
			int frame = data.SearchFrameAction(oldTime, time);
			if(frame > -1)
			{
				if(data.m_FrameDataList[frame].Action == FrameData.FrameAction.jump)
				{
					m_AnimCount = data.m_FrameDataList[frame].JumpFrame;
					return true;
				}
				else if(data.m_FrameDataList[frame].Action == FrameData.FrameAction.loop)
				{
					m_AnimCount = 0.0f;
					return true;
				}
				else if(data.m_FrameDataList[frame].Action == FrameData.FrameAction.stop)
				{
					m_IsAnimEnd = true;
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
	}
}
