
using System;
using System.Collections.ObjectModel;
using XeSys;

namespace XeApp.Game.Common
{ 
	public static class DivaTimezoneTalk
	{
		public enum Type
		{
			Morning = 0,
			Noon = 1,
			Evening = 2,
			Night = 3,
			Midnight = 4,
			_Num = 5,
		}

		public const int ArrayNum = 5;
		public static readonly ReadOnlyCollection<int> LoginTalkTimeZone = new ReadOnlyCollection<int>(new int[5]
		{
			5, 11, 16, 19, 23
		}); // 0x0

		// RVA: 0x1C09A5C Offset: 0x1C09A5C VA: 0x1C09A5C
		public static Type GetByUnixTime(long unixTime, out bool isOverDay)
		{
			DateTime date = Utility.GetLocalDateTime(unixTime);
			int hour = date.Hour;
			isOverDay = hour < LoginTalkTimeZone[0];
			if (hour < LoginTalkTimeZone[0])
			{
				hour += 24;
			}
			for(int i = LoginTalkTimeZone.Count - 1; i >= 0; i--)
			{
				if (hour >= LoginTalkTimeZone[i])
					return (Type)i;
			}
			return Type.Midnight;
		}
	}
}
