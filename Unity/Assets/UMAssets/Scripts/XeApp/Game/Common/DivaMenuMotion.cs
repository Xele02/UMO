namespace XeApp.Game.Common
{
	public class DivaMenuMotion
	{
		public enum Type
		{
			Talk_ST = 1,
			Talk01 = 1,
			Talk02 = 2,
			Talk_ED = 3,
			Touch_ST = 101,
			Touch01 = 101,
			Touch02 = 102,
			Touch03 = 103,
			Touch04 = 104,
			Touch05 = 105,
			Touch_ED = 106,
			Timezone_ST = 201,
			Timezone01 = 201,
			Timezone02 = 202,
			Timezone03 = 203,
			Timezone04 = 204,
			Timezone05 = 205,
			Timezone_ED = 206,
			Present_ST = 301,
			Present_01 = 301,
			Present_ED = 302,
			SimpleTalk_ST = 401,
			SimpleTalk01 = 401,
			SimpleTalk_ED = 402,
		}
		
		public const int TalkOffset = 0;
		public const int TouchReactionOffset = 100;
		public const int TimezoneTalkOffset = 200;
		public const int PresentReactionOffset = 300;
		public const int SimpleTalkOffset = 400;

		//// RVA: 0x1BF0054 Offset: 0x1BF0054 VA: 0x1BF0054
		//public static bool IsTalk(DivaMenuMotion.Type type) { }

		//// RVA: 0x1BF0068 Offset: 0x1BF0068 VA: 0x1BF0068
		//public static bool IsSimpleTalk(DivaMenuMotion.Type type) { }

		//// RVA: 0x1BF0080 Offset: 0x1BF0080 VA: 0x1BF0080
		//public static bool IsTouchReaction(DivaMenuMotion.Type type) { }

		//// RVA: 0x1BF0094 Offset: 0x1BF0094 VA: 0x1BF0094
		public static bool IsTimezoneTalk(Type type)
		{
			return type >= Type.Timezone_ST && type < Type.Timezone_ED;
		}

		//// RVA: 0x1BF00A8 Offset: 0x1BF00A8 VA: 0x1BF00A8
		//public static bool IsPresentReaction(DivaMenuMotion.Type type) { }

		// RVA: 0x1BF00C0 Offset: 0x1BF00C0 VA: 0x1BF00C0
		public static int ToMotionId(Type type)
		{
			if (type < 0)
				return -1;
			if((int)type < 100)
				return (int)type;
			if((int)type < 200)
				return (int)type - 100;
			if ((int)type < 300)
				return (int)type - 200;
			if ((int)type < 400)
				return (int)type - 300;
			return (int)type - 400;
		}
	}
}
