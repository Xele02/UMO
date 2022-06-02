using GooglePlayGames;

namespace GooglePlayGames.BasicApi
{
	public class PlayerProfile : PlayGamesUserProfile
	{
		internal PlayerProfile(string displayName, string playerId, string avatarUrl, bool isFriend) : base(default(string), default(string), default(string))
		{
		}

	}
}
