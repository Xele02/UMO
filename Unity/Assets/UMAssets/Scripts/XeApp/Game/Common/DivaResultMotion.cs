
namespace XeApp.Game.Common
{
    public static class DivaResultMotion
    {
        public enum Type
        {
            Low = 0,
            Middle = 1,
            High = 2,
        }

        // // RVA: 0x1C09958 Offset: 0x1C09958 VA: 0x1C09958
        public static bool UseResultSpecial(int divaId, ResultScoreRank.Type scoreRank)
        {
            if(divaId != 9)
            {
                if(scoreRank >= ResultScoreRank.Type.A &&  scoreRank <= ResultScoreRank.Type.S)
                    return false;
                if(((uint)(scoreRank - 2) & 7) == 2)
                    return true;
                return false;
            }
            return true;
        }

        // // RVA: 0x1C099AC Offset: 0x1C099AC VA: 0x1C099AC
        public static string GetResultSpecialStr(ResultScoreRank.Type scoreRank)
        {
            if(scoreRank >= ResultScoreRank.Type.A &&  scoreRank <= ResultScoreRank.Type.SS)
            {
                return new string[3] { "m", "m", "h" }[(int)scoreRank - 2];
            }
            else
            {
                return "l";
            }
        }

        // // RVA: 0x1C09A28 Offset: 0x1C09A28 VA: 0x1C09A28
        // public static int GetResultReactType(ResultScoreRank.Type scoreRank) { }

        // // RVA: 0x1C09A3C Offset: 0x1C09A3C VA: 0x1C09A3C
        public static int GetVoiceId(ResultScoreRank.Type scoreRank)
		{
			if (scoreRank >= ResultScoreRank.Type.A && scoreRank < ResultScoreRank.Type.Num)
				return new int[3] { 1, 1, 2 }[(int)scoreRank - 2];
			return 0;
		}

        // // RVA: 0x1C0998C Offset: 0x1C0998C VA: 0x1C0998C
        // private static DivaResultMotion.Type ToType(ResultScoreRank.Type scoreRank) { }
    }
}
