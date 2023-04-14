using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class TimeMap
	{
		[SerializeField]
		private TimeMapData[] m_DataList; // 0x8

		public TimeMapData[] DataList { get { return m_DataList; } }// 0x1EE4858
		public int DataListCount { get {
			if(m_DataList != null)
				return m_DataList.Length;
			return 0;
		 } } //0x1EE4860

		// RVA: 0x1EE4874 Offset: 0x1EE4874 VA: 0x1EE4874
		public TimeMap(int count)
		{
			m_DataList = new TimeMapData[count];
		}


		// // RVA: 0x1EE48EC Offset: 0x1EE48EC VA: 0x1EE48EC
		// public void SetTimeMapData(int index, int start, int end, TimeMapData.TimeMapType tmType, int strength, int count) { }

		// // RVA: 0x1EE4A88 Offset: 0x1EE4A88 VA: 0x1EE4A88
		// public void CopyTo(TimeMap data) { }

		// // RVA: 0x1EE4C88 Offset: 0x1EE4C88 VA: 0x1EE4C88
		private float GetPlayFrameQuadratic(float time, float start, float end, float strength)
		{
			float f1 = (time - start) / (end - start);
			if(0 <= f1)
			{
				if (1 <= f1)
					f1 = 1;
			}
			else
				f1 = 0;
			float f2 = strength / 100.0f;
			if(f2 >= 0)
			{
				if(f2 >= 0)
				{
					f1 = (1 - f2) * f1 + f2 * (1 - (1 - f1) * (1 - f1));
				}
			}
			else
			{
				f1 = (f2 + 1) * f1 - f1 * f2 * f1;
			}
			return (end - start) * f1 + start;
		}

		// // RVA: 0x1EE4D34 Offset: 0x1EE4D34 VA: 0x1EE4D34
		public float GetPlayFrame(float time, float frameSec)
		{
			float startTime = 0.0f, endTime = 0.0f;
			int i = 0;
			for (; i < m_DataList.Length; i++)
			{
				startTime = m_DataList[i].StartFrame * frameSec;
				if (startTime <= time)
				{
					endTime = m_DataList[i].EndFrame * frameSec;
					if (endTime >= time)
					{
						if (m_DataList[i].TmType == TimeMapData.TimeMapType.CustomElm)
						{
							time = m_DataList[i].GetPlayFrameCustom(time, startTime, endTime);
						}
						else if (m_DataList[i].TmType == TimeMapData.TimeMapType.Quadratic)
						{
							time = GetPlayFrameQuadratic(time, startTime, endTime, m_DataList[i].Strength);
						}
						break;
					}
				}
			}
			return time;
		}
	}
}
