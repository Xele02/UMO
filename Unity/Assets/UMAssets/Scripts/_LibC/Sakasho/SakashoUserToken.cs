using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
	{
		public partial class PlayerData
		{
			public int userId;
			public bool needUpdateAfter = false;
			public EDOHBJAPLPF_JsonData serverData;
			public UserThreads bbsThreadCache = null;
		}

		public partial class AccountData
		{
			public int userId = -1;
			public PlayerData playerData;
			public Dictionary<int, PlayerData> players = new Dictionary<int, PlayerData>();
		}

		static AccountData playerAccount;

		public static int GetCurrentAccountId()
		{
			if(playerAccount != null)
				return playerAccount.userId;
			return 0;
		}

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
			TodoLogger.Log(TodoLogger.SakashoServer, "saved server data " + path);
		}

		public static void SaveAccountServerData()
		{
			if (playerAccount == null)
				return;

			playerAccount.playerData.bbsThreadCache.Save(playerAccount.playerData.serverData);

			SaveAccountServerData(playerAccount.playerData.serverData, playerAccount.userId, "data.json");
		}

		public static EDOHBJAPLPF_JsonData GetAccountServerData(int playerId)
		{
			EDOHBJAPLPF_JsonData data = null;
			string path = Application.persistentDataPath + "/Profiles/" + playerId.ToString() + "/data.json";

			if (File.Exists(path))
			{
				TodoLogger.Log(TodoLogger.SakashoServer, "load server data " + path + "for" + playerId);
				string saveData = File.ReadAllText(path);
				data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(saveData);
			}
			return data;
		}

		public static void LoadAccountServerData(int playerId)
		{
			if (playerAccount == null)
				return;
			EDOHBJAPLPF_JsonData data = GetAccountServerData(playerId);
			if(data != null)
			{
				playerAccount.players[playerId].serverData = data;
				playerAccount.players[playerId].bbsThreadCache = new UserThreads();
				playerAccount.players[playerId].bbsThreadCache.Load(playerAccount.players[playerId].serverData);
			}
		}

		public static void InitPlayerAccount(int playerId)
		{
			playerAccount = new AccountData();
			playerAccount.userId = playerId;
			InitAccount(playerId);
			playerAccount.playerData = playerAccount.players[playerId];
		}

		public static void InitAccount(int playerId)
		{
			PlayerData p = new PlayerData();
			p.userId = playerId;
			playerAccount.players.Add(p.userId, p);
			LoadAccountServerData(playerId);
			CheckAccountUpdate(playerId);
		}

		public static void CheckAccountUpdate(int accountId)
		{
			PlayerData p = playerAccount.players[accountId];
			if(!IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				p.needUpdateAfter = true;
				return;
			}
			p.needUpdateAfter = false;

			if(p.serverData == null)
			{
				TodoLogger.Log(TodoLogger.SakashoServer, "Create new server data for " + accountId);
				EDOHBJAPLPF_JsonData jsonRes = new EDOHBJAPLPF_JsonData();

				BBHNACPENDM_ServerSaveData newData = new BBHNACPENDM_ServerSaveData();
				newData.KHEKNNFCAOI_Init(0xFFFFFFFFFFFFFF);

				SerializeServerSave(newData, jsonRes);
				p.serverData = jsonRes;
			}

			// Check cheat accounts is full unlocked
			if (p.userId >= 900000000) // unlock all for cheat account
			{
				UnlockAll(p);
			}
			if (p.userId == 999999998)
			{
				EDOHBJAPLPF_JsonData jsonRes = p.serverData;

				// Update friend with assist cards
				BBHNACPENDM_ServerSaveData newData = new BBHNACPENDM_ServerSaveData();
				newData.KHEKNNFCAOI_Init(0xFFFFFFFFFFFFFF);

				Dictionary<string, EDOHBJAPLPF_JsonData> blocks;
				blocks = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject<Dictionary<string, EDOHBJAPLPF_JsonData>>(jsonRes.EJCOJCGIBNG_ToJson());
				newData.IIEMACPEEBJ_Load(blocks.Keys.ToList(), jsonRes);

				(newData.LBDOLHGDIEB_GetBlock("base") as JBMPOAAMGNB_Base).OPFGFINHFCE_PlayerName = "Friend";
				(newData.LBDOLHGDIEB_GetBlock("base") as JBMPOAAMGNB_Base).CMKKFCGBILD_Prof = "Cool friend";
				{
					JNMFKOHFAFB_PublicStatus publicBlock = newData.LBDOLHGDIEB_GetBlock("public_status") as JNMFKOHFAFB_PublicStatus;
					// build sceneList
					List<GCIJNCFDNON_SceneInfo> scenes = new List<GCIJNCFDNON_SceneInfo>();
					for (int i = 0; i < newData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count; i++)
					{
						GCIJNCFDNON_SceneInfo IFGEJDMMAHE = new GCIJNCFDNON_SceneInfo();
						if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i].PPEGAKEIEGM_En == 2)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG scene = newData.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
							IFGEJDMMAHE.KHEKNNFCAOI(scene.PPFNGGCBJKC_Id, scene.PDNIFBEGMHC_Mb, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_Mlt, scene.IELENGDJPHF_Ulk, scene.MJBODMOLOBC_Luck, scene.LHMOAJAIJCO_New, scene.BEBJKJKBOGH_Date, scene.DMNIMMGGJJJ_Leaf);
							scenes.Add(IFGEJDMMAHE);
						}
					}
					scenes.Sort((GCIJNCFDNON_SceneInfo a, GCIJNCFDNON_SceneInfo b) =>
					{
						int res = b.CMCKNKKCNDK_Status.Total - a.CMCKNKKCNDK_Status.Total;
						if (res == 0)
							res = a.BCCHOBPJJKE_SceneId - b.BCCHOBPJJKE_SceneId;
						return res;
					});

					publicBlock.AFBMEMCHJCL_MScene.DOMFHDPMCCO(scenes[0].BCCHOBPJJKE_SceneId, scenes[0].KBOLNIBLIND, scenes[0].ODKMKEHJOCK, scenes[0].MJBODMOLOBC_Luck, scenes[0].JPIPENJGGDD_NumBoard, scenes[0].MKHFCGPJPFI_LimitOverCount);
					for (int i = 0; i < 4; i++)
					{
						for (int j = 0; j < scenes.Count; j++)
						{
							if (scenes[j].JGJFIJOCPAG_SceneAttr == i || i == 0)
							{
								publicBlock.MGMFOJPNDGA_AssistData.JOHLGBDOLNO_DataList[i].DOMFHDPMCCO(scenes[j].BCCHOBPJJKE_SceneId, scenes[j].KBOLNIBLIND, scenes[j].ODKMKEHJOCK, scenes[j].MJBODMOLOBC_Luck, scenes[j].JPIPENJGGDD_NumBoard, scenes[j].MKHFCGPJPFI_LimitOverCount);
								break;
							}
						}
					}
				}

				SerializeServerSave(newData, jsonRes);
			}
		}

		public static int CreateAccount(bool cheatAccount)
		{
			// cheat account : 999999999
			// cheat other account : 999999998 (or 9xxxxxxxx)
			// local account : 100000000 -> 599999999
			// network account : 600000000 -> 899999999
			int id = 0;
			if (cheatAccount)
			{
				id = 999999999;
			}
			else
			{
				do
				{
					id = Random.Range(100000000, 599999999);
				} while (Directory.Exists(Application.persistentDataPath + "/Profiles/" + id.ToString()));
			}

			InitPlayerAccount(id);
			return id;
		}

		public static int SakashoUserTokenCreatePlayer(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData inData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int accountType = (int)inData["accountType"];
			CreateAccount(accountType == 1);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["is_created"] = 1;
			res["player_account_status"] = 0;
			res["player_id"] = playerAccount.userId;
			TodoLogger.Log(TodoLogger.SakashoServer, "Created player " + playerAccount.userId);

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoUserTokenCreatePlayerFromLine(int callbackId, string json)
		{
			return SakashoUserTokenGetPlayerStatus(callbackId, json);
		}
		public static int SakashoUserTokenCreatePlayerFromFacebook(int callbackId, string json)
		{
			return SakashoUserTokenGetPlayerStatus(callbackId, json);
		}
		public static int SakashoUserTokenCreatePlayerFromTwitter(int callbackId, string json)
		{
			return SakashoUserTokenGetPlayerStatus(callbackId, json);
		}

		public static int SakashoUserTokenGetPlayerStatus(int callbackId, string json)
        {
			//ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoAPICallContext context = ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoUserToken.getPlayerStatus(null, null);

			int playerId = UMO_PlayerPrefs.GetInt("cpid", 0);
			if(playerId == 0)
			{
				playerAccount = null;
			}
			else if(playerAccount != null && playerAccount.userId != playerId)
			{
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
				TodoLogger.Log(TodoLogger.SakashoServer, "No user");
			}
			else
			{
				res["is_created"] = 1;
				res["player_account_status"] = 0;
				res["player_id"] = playerAccount.userId;
				TodoLogger.Log(TodoLogger.SakashoServer, "Using user " + playerAccount.userId);
			}
			// Hack directly send response

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }

		public static int SakashoUserTokenClearDeviceLoginDataWithLog(int callbackId, string json)
        {
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			return 0;
		}
    }
}
