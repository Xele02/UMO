using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class FriendListInfo : PlayerListInfo
	{
		public FriendListInfo(short titleIndex, bool isAvailable, EAJCBFGKKFA fri)
		{
		}

		public int playerId;
		public int playerRank;
		public long lastLogin;
		public long requestDate;
		public int divaId;
		public int divaModelId;
		public int divaColorId;
		public int sceneId;
		public int sceneRank;
		public int sceneRarity;
		public int sceneLevel;
		public int emblemId;
		public GameAttribute.Type sceneAttr;
		public SeriesAttr.Type sceneSeries;
		public int total;
		public string skill;
		public int skillLevel;
		public SkillRank.Type skillRank;
		public HighScoreRatingRank.Type scoreRatingRank;
		public int life;
		public int soul;
		public int voice;
		public int charm;
		public int luck;
		public int fold;
		public int support;
		public int musicRatio;
		public string login;
		public string request;
		public string comment;
		public bool isKira;
	}
}
