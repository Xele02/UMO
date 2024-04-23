using System;

namespace XeSys.Gfx
{
	[Serializable]
	public struct TimeMapData
	{
		public enum TimeMapType
		{
			None = 0,
			Quadratic = 1,
			CustomElm = 2,
		}
		
		public TimeMapType TmType; // 0x0
		public int Strength; // 0x4
		public int StartFrame; // 0x8
		public int EndFrame; // 0xC
		public CustomTimeMapElm[] CustomTimeMapElmList; // 0x10

		//public int ElmCount { get; } 0x802570

		// RVA: 0x802584 Offset: 0x802584 VA: 0x802584
		public TimeMapData(int start, int end, TimeMapType tmType, int strength, int elemNum)
		{
			StartFrame = start;
			Strength = strength;
			EndFrame = end;
			TmType = tmType;
			CustomTimeMapElmList = new CustomTimeMapElm[elemNum];
		}

		//// RVA: 0x8025A8 Offset: 0x8025A8 VA: 0x8025A8
		//public void SetCustomTimeMapElm(int index, float point, float next, float prev) { }

		//// RVA: 0x8025CC Offset: 0x8025CC VA: 0x8025CC
		public float GetPlayFrameCustom(float time, float start, float end)
		{
			float t = 0;
			float r = (time - start) / (end - start);
			if(r >= 0)
			{
				t = r;
				if(t >= 1)
					t = 1;
			}
			int found = -1;
			int foundNext = -1;
			float s = 0;
			float n = 0;
			for(int i = 0; i < CustomTimeMapElmList.Length; i++)
			{
				if(CustomTimeMapElmList[i].Prev <= t && (found == -1 || CustomTimeMapElmList[i].Prev > s))
				{
					found = i;
					s = CustomTimeMapElmList[i].Prev;
				}
				if(CustomTimeMapElmList[i].Prev >= t && (foundNext == -1 || CustomTimeMapElmList[i].Prev <= n))
				{
					foundNext = i;
					n = CustomTimeMapElmList[i].Prev;
				}
			}
			if(found > -1 && foundNext > -1)
			{
				t = XeSys.Math.CurveBezier3.Evaluate(t, CustomTimeMapElmList[found].Point, CustomTimeMapElmList[found].Next, CustomTimeMapElmList[foundNext].Prev, CustomTimeMapElmList[foundNext].Point);
			}
			return (end - start) * t + start;
		}
	}
}
