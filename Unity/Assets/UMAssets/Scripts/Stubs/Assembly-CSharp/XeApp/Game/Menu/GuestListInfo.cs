using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GuestListInfo : PlayerListInfo
	{
		public GuestListInfo(short titleIndex, bool isAvailable, EEDKAACNBBG musicData, EAJCBFGKKFA fri)
		{
		}

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
		public bool isKira;
		public int centerSkillRank;
		public int centerSkillRank2;
		public int limitOverCount;
	}
}
