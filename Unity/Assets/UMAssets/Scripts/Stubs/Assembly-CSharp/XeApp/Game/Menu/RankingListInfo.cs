using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RankingListInfo : PlayerListInfo
	{
		public RankingListInfo(int index, bool isAvailable, EAJCBFGKKFA friend)
		{
		}

		public int divaId;
		public int divaCostumeId;
		public int divaCostumeColorId;
		public int sceneId;
		public int sceneRank;
		public int emblemId;
		public int musicRatio;
		public HighScoreRatingRank.Type scoreRatingRank;
		public bool isKira;
		public int playerLevel;
		public long score;
		public int rankingOrder;
		public bool isOwner;
	}
}
