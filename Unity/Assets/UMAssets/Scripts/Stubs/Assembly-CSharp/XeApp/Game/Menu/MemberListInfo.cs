using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MemberListInfo : PlayerListInfo
	{
		public MemberListInfo(short titleIndex, bool isAvailable, EAJCBFGKKFA fri)
		{
		}

		public int playerId;
		public int playerRank;
		public long lastLogin;
		public int divaId;
		public int divaModelId;
		public int divaColorId;
		public int sceneId;
		public int episodeId;
		public int sceneRank;
		public int sceneRarity;
		public int sceneLevel;
		public int emblemId;
		public int musicRatio;
		public HighScoreRatingRank.Type scoreRatingRank;
		public GameAttribute.Type sceneAttr;
		public SeriesAttr.Type sceneSeries;
		public int total;
		public string skill;
		public int skillLevel;
		public SkillRank.Type skillRank;
		public int life;
		public int soul;
		public int voice;
		public int charm;
		public int luck;
		public int fold;
		public int support;
		public bool Friend;
		public string comment;
		public string login;
		public int mcannonPower;
		public string mcannonPowerMes;
		public int funCount;
		public string funCountMes;
		public bool isFavorite;
		public bool isKira;
	}
}
