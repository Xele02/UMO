using System.Collections.Generic;
using System.IO;
using UnityEngine;
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
			public EDOHBJAPLPF_JsonData serverData;
		}

		static AccountData playerAccount;

		public static void SaveAccountServerData()
		{
			if (playerAccount == null)
				return;
			/*EDOHBJAPLPF_JsonData jsonData = new EDOHBJAPLPF_JsonData();
			for (int i = 0; i < playerAccount.serverData.MGJKEJHEBPO_Blocks.Count; i++)
			{
				playerAccount.serverData.MGJKEJHEBPO_Blocks[i].OKJPIBHMKMJ(jsonData, playerAccount.serverData.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
			}*/
			KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
			writer.GALFODHMEOL_PrettyPrint = true;
			playerAccount.serverData.EJCOJCGIBNG_ToJson(writer);
			string saveData = writer.ToString();

			string path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString();
			if(!Directory.Exists(path))
				Directory.CreateDirectory(path);

			path += "/data.json";
			File.WriteAllText(path, saveData);
			UnityEngine.Debug.LogError("saved server data " + path);
		}

		public static void LoadAccountServerData()
		{
			return; // for now for a new profile to config the full unlock profile
			if (playerAccount == null)
				return;
			string path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString() + "/data.json";

			if (File.Exists(path))
			{
				UnityEngine.Debug.LogError("load server data "+path);
				string saveData = File.ReadAllText(path);
				playerAccount.serverData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(saveData);
			}
		}

		public static void InitPlayerAccount(int playerId)
		{
			playerAccount = new AccountData();
			playerAccount.userId = playerId;
			PlayerData p = new PlayerData();
			p.userId = playerAccount.userId;
			playerAccount.playerData = p;
			playerAccount.players.Add(p.userId, p);
			LoadAccountServerData();
		}

		public static int CreateAccount()
		{
			int id = 0;
			do
			{
				id = Random.Range(100000000, 999999999);
			} while (Directory.Exists(Application.persistentDataPath + "/Profiles/" + id.ToString()));

			InitPlayerAccount(id);
			return id;
		}

		public static int SakashoUserTokenCreatePlayer(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoUserTokenCreatePlayer " + json);

			CreateAccount();

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["is_created"] = 1;
			res["player_account_status"] = 0;
			res["player_id"] = playerAccount.userId;
			UnityEngine.Debug.LogError("Created player "+ playerAccount.userId);

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoUserTokenGetPlayerStatus(int callbackId, string json)
        {
            UnityEngine.Debug.Log("SakashoUserTokenGetPlayerStatus "+json);
			//ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoAPICallContext context = ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoUserToken.getPlayerStatus(null, null);

			int playerId = PlayerPrefs.GetInt("cpid", 0);
			if(playerId == 0)
			{
				playerAccount = null;
			}
			else if(playerAccount != null && playerAccount.userId != playerId)
			{
				playerId = 0;
				playerAccount = null;
			}
			if(playerId != 0 && playerAccount == null)
			{
				InitPlayerAccount(playerId);
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			if (playerAccount == null)
			{
				res["is_created"] = 0;
				res["player_account_status"] = 0;
				res["player_id"] = 0;
				UnityEngine.Debug.LogError("No user");
			}
			else
			{
				res["is_created"] = 1;
				res["player_account_status"] = 0;
				res["player_id"] = playerAccount.userId;
				UnityEngine.Debug.LogError("Using user "+ playerAccount.userId);
			}
			// Hack directly send response

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }
    }
}
