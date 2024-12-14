using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	[Serializable]
	internal class ViewFrameAnimationData : ISerializationCallbackReceiver
	{
		[SerializeField]
		public FrameData[] m_FrameDataList; // 0x8
		[SerializeField]
		public LabelData[] m_LabelList; // 0xC
		[SerializeField]
		private TimeMap m_AnimTimeMap; // 0x10
		[SerializeField]
		private uint m_AnimFlag; // 0x14
		[SerializeField]
		private string m_Id = ""; // 0x18
		[SerializeField]
		private int m_FrameNum; // 0x1C
		private Dictionary<string, int> m_LabelIndex = new Dictionary<string, int>(); // 0x20

		public FrameData[] F { get { return m_FrameDataList; } } //0x1EEBECC
		public int FrameDataCount { get { return m_FrameDataList != null ? m_FrameDataList.Length : 0; } } //0x1EEBCE4
		// public bool IsPosAnim { get; set; } 0x1EEBED4 0x1EEBEE0
		// public bool IsMoveAnim { get; set; } 0x1EEBEF8 0x1EEBF04
		// public bool IsMoveBezierX { get; set; } 0x1EEBF1C 0x1EEBF28
		// public bool IsMoveBezierY { get; set; } 0x1EEBF40 0x1EEBF4C
		// public bool IsSizeAnim { get; set; } 0x1EEBF64 0x1EEBF70
		// public bool IsScaleAnim { get; set; } 0x1EEBF88 0x1EEBF94
		// public bool IsRotAnim { get; set; } 0x1EEBFAC 0x1EEBFB8
		// public bool IsColorAnim { get; set; } 0x1EEBFD0 0x1EEBFDC
		// public bool IsAlphaAnim { get; set; } 0x1EEBFF4 0x1EEC000
		// public bool IsCenterAnim { get; set; } 0x1EEC018 0x1EEC024
		// public bool IsUseTimeMap { get; } 0x1EEA408
		public TimeMap AnimTimeMap { get { return m_AnimTimeMap; } } //0x1EE9694
		public int FrameNum { get { return m_FrameNum; } private set { m_FrameNum = value; } } //0x1EE960C 0x1EEC03C
		// public string ID { get; set; } 0x1EE9638 0x1EE9668

		// // RVA: 0x1EEBDE4 Offset: 0x1EEBDE4 VA: 0x1EEBDE4 Slot: 5
		public void OnAfterDeserialize()
		{
			for(int i = 0; i < m_LabelList.Length; i++)
			{
				m_LabelIndex.Add(m_LabelList[i].Id, i);
			}
		}

		// // RVA: 0x1EEBEC8 Offset: 0x1EEBEC8 VA: 0x1EEBEC8 Slot: 4
		public void OnBeforeSerialize()
		{
			return;
		}

		// // RVA: 0x1EE974C Offset: 0x1EE974C VA: 0x1EE974C
		// public bool IsAnim(ViewFrameAnimationData.AnimKind kind) { }

		// // RVA: 0x1EE9768 Offset: 0x1EE9768 VA: 0x1EE9768
		// public void SetAnim(ViewFrameAnimationData.AnimKind kind, bool on) { }

		// // RVA: 0x1EE9C5C Offset: 0x1EE9C5C VA: 0x1EE9C5C
		// public void InitAnimTimeMap(int count) { }

		// // RVA: 0x1EE9D30 Offset: 0x1EE9D30 VA: 0x1EE9D30
		// public void SetTimeMapData(int index, int start, int end, TimeMapData.TimeMapType tmType, int strength, int count) { }

		// // RVA: 0x1EE9DF0 Offset: 0x1EE9DF0 VA: 0x1EE9DF0
		// public void SetCustomTimeMapElm(int tmIndex, int elmIndex, float point, float next, float prev) { }

		// // RVA: 0x1EE9A8C Offset: 0x1EE9A8C VA: 0x1EE9A8C
		// public void .ctor(int frameNum) { }

		// // RVA: 0x1EE9B7C Offset: 0x1EE9B7C VA: 0x1EE9B7C
		// public void Initialize(FrameData[] data, Dictionary<int, string> labelList, float frameSec) { }

		// // RVA: 0x1EEC044 Offset: 0x1EEC044 VA: 0x1EEC044
		// private void SetLabelList(Dictionary<int, string> labelList, float frameSec) { }

		// // RVA: 0x1EE9EB4 Offset: 0x1EE9EB4 VA: 0x1EE9EB4
		public float SearchLabelFrame(string label)
		{
			if(m_LabelIndex.ContainsKey(label))
			{
				return m_LabelList[m_LabelIndex[label]].FrameIdx;
			}
			return -1;
		}

		// // RVA: 0x1EE9FD4 Offset: 0x1EE9FD4 VA: 0x1EE9FD4
		public float SearchLabelTime(string label)
		{
			if(m_LabelIndex.ContainsKey(label))
			{
				return m_LabelList[m_LabelIndex[label]].Time;
			}
			else
			{
				return -1;
			}
		}

		// // RVA: 0x1EEA0D4 Offset: 0x1EEA0D4 VA: 0x1EEA0D4
		public bool SearchLabelTimePair(string label, float frameSec, out float start, out float end)
		{
			start = -1.0f;
			end = -1.0f;
			if(m_LabelIndex.ContainsKey(label))
			{
				int idx = m_LabelIndex[label];
				start = m_LabelList[idx].Time;
				if(idx < m_LabelList.Length - 1)
					end = m_LabelList[idx + 1].FrameIdx - 1;
				else
					end = m_FrameNum;
				if(end >= 0)
					end = end * frameSec;
				return true;
			}
			return false;
		}

		// // RVA: 0x1EEA27C Offset: 0x1EEA27C VA: 0x1EEA27C
		// public bool SearchLabelTimeInversePair(string label, float frameSec, out float start, out float end) { }

		// // RVA: 0x1EEA554 Offset: 0x1EEA554 VA: 0x1EEA554
		public void SetPrevNextFrameData(float count, ref int prev, ref int next, out float rate)
		{
			prev = -1;
			next = -1;
			if(m_FrameDataList != null)
			{
				for(int i = 0; i < m_FrameDataList.Length; i++)
				{
					if(m_FrameDataList[i].Time <= count)
					{
						prev = i;
						next = i+1;
						if(i >= m_FrameDataList.Length - 1)
							next = -1;
					}
				}
			}
			if(prev < 0 || next < 0)
			{
				rate = 0.0f;
			}
			else
			{
				rate = (count - m_FrameDataList[prev].Time) / (m_FrameDataList[next].Time - m_FrameDataList[prev].Time);
				if((m_FrameDataList[next].FrameIdx - m_FrameDataList[prev].FrameIdx < 2) && (rate < 1.0f))
				{
					//rate = 0.0f;
					// UMO :
					// when frameIdx is 1 frame, looks like we want a immediate swap, not a lerp. But there is a precision bug...
					// Shouldn't force to 0 when almost near 1. Trying with only a round for now.
					rate = Mathf.Round(rate);
				}
			}
		}

		// // RVA: 0x1EEBCF8 Offset: 0x1EEBCF8 VA: 0x1EEBCF8
		public int SearchFrameAction(float oldTime, float time)
		{
			if(m_FrameDataList == null || m_FrameDataList.Length < 1)
				return -1;
			for(int i = 0; i < m_FrameDataList.Length; i++)
			{
				if(oldTime <= m_FrameDataList[i].Time)
				{
					if(m_FrameDataList[i].Time <= time) // ??
					{
						return i;
					}
				}
			}
			return -1;
		}

		// // RVA: 0x1EEA7CC Offset: 0x1EEA7CC VA: 0x1EEA7CC
		public bool GetAnimTransform(ViewTransformData vt, int Base, int Target, float rate, ref bool isUpdateSRT)
		{
			if(Base < 0)
			{
				return false;
			}
			if(Target < 0 || rate == 0.0f)
			{
				if((m_AnimFlag & 1) != 0)
				{
					vt.m.Pos = m_FrameDataList[Base].TransFormData.m.Pos;
					isUpdateSRT = true;
				}
				if((m_AnimFlag & 2) != 0)
				{
					vt.m.Move = m_FrameDataList[Base].TransFormData.m.Move;
					isUpdateSRT = true;
				}
				if((m_AnimFlag & 16) != 0)
				{
					vt.m.Size = m_FrameDataList[Base].TransFormData.m.Size;
					isUpdateSRT = true;
				}
				if((m_AnimFlag & 32) != 0)
				{
					vt.m.Scale = m_FrameDataList[Base].TransFormData.m.Scale;
					isUpdateSRT = true;
				}
				if((m_AnimFlag & 64) != 0)
				{
					vt.m.Rot = m_FrameDataList[Base].TransFormData.m.Rot;
					isUpdateSRT = true;
				}
				if((m_AnimFlag & 0x180) == 0x180) // 128 & 256
				{
					vt.m.Color = m_FrameDataList[Base].TransFormData.m.Color;
					isUpdateSRT = true;
				}
				else if((m_AnimFlag & 128) == 0)
				{
					if((m_AnimFlag & 256) != 0)
					{
						vt.m.Color = new Color(vt.m.Color.r,
												vt.m.Color.g,
												vt.m.Color.b,
												m_FrameDataList[Base].TransFormData.m.Color.a);
					}
				}
				else
				{
					vt.m.Color = new Color(m_FrameDataList[Base].TransFormData.m.Color.r,
												m_FrameDataList[Base].TransFormData.m.Color.g,
												m_FrameDataList[Base].TransFormData.m.Color.b,
												vt.m.Color.a);
				}
				if((m_AnimFlag & 512) != 0)
					vt.m.Center = m_FrameDataList[Base].TransFormData.m.Center;
				return true;
			}
			if((m_AnimFlag & 1) != 0)
			{
				vt.m.Pos = Vector2.Lerp(m_FrameDataList[Base].TransFormData.m.Pos, m_FrameDataList[Target].TransFormData.m.Pos, rate);
				isUpdateSRT = true;
			}
			if((m_AnimFlag & 2) != 0)
			{
				if((m_AnimFlag & 0xc) == 0xc)
				{
					vt.m.Move = Math.CurveBezier3.Evaluate(rate,m_FrameDataList[Base].TransFormData.m.Move,m_FrameDataList[Base].TransFormData.MoveBezierNext, m_FrameDataList[Target].TransFormData.MoveBezierPrev, m_FrameDataList[Target].TransFormData.m.Move);
				}
				else
				{
					if((m_AnimFlag & 4) == 0)
					{
						if((m_AnimFlag & 8) == 0)
						{
							vt.m.Move = Vector2.Lerp(m_FrameDataList[Base].TransFormData.m.Move, m_FrameDataList[Target].TransFormData.m.Move, rate);
						}
						else
						{
							vt.m.Move.x = Mathf.Lerp(m_FrameDataList[Base].TransFormData.m.Move.x, m_FrameDataList[Target].TransFormData.m.Move.x, rate);
							vt.m.Move.y = Math.CurveBezier3.Evaluate(rate, m_FrameDataList[Base].TransFormData.m.Move.y, m_FrameDataList[Base].TransFormData.MoveBezierNextY, m_FrameDataList[Target].TransFormData.MoveBezierPrevY, m_FrameDataList[Target].TransFormData.m.Move.y);
						}
					}
					else
					{
						vt.m.Move.x = Math.CurveBezier3.Evaluate(rate, m_FrameDataList[Base].TransFormData.m.Move.x, m_FrameDataList[Base].TransFormData.MoveBezierNextX, m_FrameDataList[Target].TransFormData.MoveBezierPrevX, m_FrameDataList[Target].TransFormData.m.Move.x);
						vt.m.Move.y = Mathf.Lerp(m_FrameDataList[Base].TransFormData.m.Move.y, m_FrameDataList[Target].TransFormData.m.Move.y, rate);
					}
				}
				isUpdateSRT = true;
			}
			if((m_AnimFlag & 16) != 0)
			{
				vt.m.Size = Vector2.Lerp(m_FrameDataList[Base].TransFormData.m.Size, m_FrameDataList[Target].TransFormData.m.Size, rate);
				isUpdateSRT = true;
			}
			if((m_AnimFlag & 32) != 0)
			{
				vt.m.Scale = m_FrameDataList[Base].TransFormData.m.Scale + (m_FrameDataList[Target].TransFormData.m.Scale - m_FrameDataList[Base].TransFormData.m.Scale) * rate;
				isUpdateSRT = true;
			}
			if((m_AnimFlag & 64) != 0)
			{
				vt.m.Rot = m_FrameDataList[Base].TransFormData.m.Rot + (m_FrameDataList[Target].TransFormData.m.Rot - m_FrameDataList[Base].TransFormData.m.Rot) * rate;
				isUpdateSRT = true;
			}
			if((m_AnimFlag & 0x180) == 0x180)
			{
				vt.m.Color = Color.Lerp(m_FrameDataList[Base].TransFormData.m.Color, m_FrameDataList[Target].TransFormData.m.Color, rate);
				isUpdateSRT = true;
			}
			else if((m_AnimFlag & 0x80) == 0)
			{
				if((m_AnimFlag & 0x100) != 0)
				{
					vt.m.Color = new Color(vt.m.Color.r, vt.m.Color.g, vt.m.Color.b, Mathf.Lerp(m_FrameDataList[Base].TransFormData.m.Color.a, m_FrameDataList[Target].TransFormData.m.Color.a, rate));
				}
			}
			else
			{
				Color col = Color.Lerp(m_FrameDataList[Base].TransFormData.m.Color, m_FrameDataList[Target].TransFormData.m.Color, rate);
				vt.m.Color = new Color(col.r, col.g, col.b, vt.m.Color.a);
			}
			if((m_AnimFlag & 512) != 0)
				vt.m.Center = Vector2.Lerp(m_FrameDataList[Base].TransFormData.m.Center, m_FrameDataList[Target].TransFormData.m.Center, rate);
			return true;
		}
	}
}
