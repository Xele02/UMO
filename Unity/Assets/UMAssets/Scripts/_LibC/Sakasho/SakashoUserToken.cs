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

		public static void SerializeServerSave(BBHNACPENDM_ServerSaveData serverData, EDOHBJAPLPF_JsonData jsonRes)
		{
			for (int i = 0; i < serverData.MGJKEJHEBPO_Blocks.Count; i++)
			{
				serverData.MGJKEJHEBPO_Blocks[i].OKJPIBHMKMJ(jsonRes, serverData.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
			}
		}

		public static void SaveAccountServerData(EDOHBJAPLPF_JsonData data, int userId, string fileName)
		{
			KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
			writer.GALFODHMEOL_PrettyPrint = true;
			data.EJCOJCGIBNG_ToJson(writer);
			string saveData = writer.ToString();

			string path = Application.persistentDataPath + "/Profiles/" + userId.ToString();
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			path += "/" + fileName;
			File.WriteAllText(path, saveData);
			UnityEngine.Debug.Log("saved server data " + path);
		}

		public static void SaveAccountServerData()
		{
			if (playerAccount == null)
				return;

			SaveAccountServerData(playerAccount.serverData, playerAccount.userId, "data.json");
		}

		public static void LoadAccountServerData()
		{
			if (playerAccount == null)
				return;
			string path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString() + "/data.json";

			if (File.Exists(path))
			{
				UnityEngine.Debug.Log("load server data "+path);
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

			int playerId = UMO_PlayerPrefs.GetInt("cpid", 0);
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
				UnityEngine.Debug.Log("No user");
			}
			else
			{
				res["is_created"] = 1;
				res["player_account_status"] = 0;
				res["player_id"] = playerAccount.userId;
				UnityEngine.Debug.Log("Using user "+ playerAccount.userId);
			}
			// Hack directly send response

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }
    }
}
