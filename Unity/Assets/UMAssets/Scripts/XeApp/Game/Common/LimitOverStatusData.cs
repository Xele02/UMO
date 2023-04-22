namespace XeApp.Game.Common
{
	public class LimitOverStatusData
	{
		public int excellentRate; // 0x8
		public int excellentRate_SameMusicAttr; // 0xC
		public int excellentRate_SameSeriesAttr; // 0x10
		public int centerLiveSkillRate; // 0x14
		public int centerLiveSkillRate_SameMusicAttr; // 0x18
		public int centerLiveSkillRate_SameSeriesAttr; // 0x1C
		public int excellentEffect; // 0x20
		public int excellentEffect_SameMusicAttr; // 0x24

		//// RVA: 0x1109B80 Offset: 0x1109B80 VA: 0x1109B80
		public void Clear()
		{
			excellentRate = 0;
			excellentRate_SameMusicAttr = 0;
			excellentRate_SameSeriesAttr = 0;
			centerLiveSkillRate = 0;
			centerLiveSkillRate_SameMusicAttr = 0;
			centerLiveSkillRate_SameSeriesAttr = 0;
		}

		//// RVA: 0x1109B9C Offset: 0x1109B9C VA: 0x1109B9C
		public void Add(LimitOverStatusData data)
		{
			excellentRate += data.excellentRate;
			excellentRate_SameMusicAttr += data.excellentRate_SameMusicAttr;
			excellentRate_SameSeriesAttr += data.excellentRate_SameSeriesAttr;
			centerLiveSkillRate += data.centerLiveSkillRate;
			centerLiveSkillRate_SameMusicAttr += data.centerLiveSkillRate_SameMusicAttr;
			centerLiveSkillRate_SameSeriesAttr += data.centerLiveSkillRate_SameSeriesAttr;
		}

		//// RVA: 0x1109CAC Offset: 0x1109CAC VA: 0x1109CAC
		//public void Copy(LimitOverStatusData data) { }
	}
}
