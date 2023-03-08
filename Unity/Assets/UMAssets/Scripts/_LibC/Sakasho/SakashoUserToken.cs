using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
	{
		public partial class PlayerData
		{
			public int userId;
		}

		public partial class AccountData
		{
			public int userId = -1;
			public PlayerData playerData;
			public Dictionary<int, PlayerData> players = new Dictionary<int, PlayerData>();
		}

		static AccountData playerAccount;

		public static int SakashoUserTokenGetPlayerStatus(int callbackId, string json)
        {
            UnityEngine.Debug.Log("SakashoUserTokenGetPlayerStatus "+json);
            //ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoAPICallContext context = ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoUserToken.getPlayerStatus(null, null);
    
			if(playerAccount == null)
			{
				// load player Account
				playerAccount = new AccountData();
				playerAccount.userId = 119562781;
				PlayerData p = new PlayerData();
				p.userId = playerAccount.userId;
				playerAccount.playerData = p;
				playerAccount.players.Add(p.userId, p);
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["is_created"] = 1;
			res["player_account_status"] = 0;
			res["player_id"] = playerAccount.userId;
			// Hack directly send response

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }
    }
}
