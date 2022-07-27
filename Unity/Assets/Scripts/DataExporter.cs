using UnityEditor;
using UnityEngine;
using XeApp.Game.Common;
using System.IO;
using System.Collections;
using XeApp.Core;
using XeApp.Game;
using XeSys;

class DataExporter
{
	[MenuItem("UMO/Export Song List", validate = true)]
	static bool ExportSongListAvaiable()
	{
		return Application.isPlaying && IMMAOANGPNK.HHCJCDFCLOB != null && IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized;
	}
	[MenuItem("UMO/Export Song List")]
	static void ExportSongList()
	{
		LPPGENBEECK_musicMaster MusicDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		string fileOutput = "";
		for (int i = 0; i < MusicDb.EPMMNEFADAP_Musics.Count; i++)
		{
			if (MusicDb.EPMMNEFADAP_Musics[i].JNCPEGJGHOG_Cov > 0)
			{
				string Title = Database.Instance.musicText.Get(MusicDb.EPMMNEFADAP_Musics[i].KNMGEEFGDNI_Nam).musicName;
				string Serie = string.Format("{0}", MusicDb.EPMMNEFADAP_Musics[i].AIHCEGFANAM_SerieId);
				if (Serie == "4") Serie = "Macross";
				if (Serie == "3") Serie = "Macross 7";
				if (Serie == "2") Serie = "Macross Frontier";
				if (Serie == "1") Serie = "Macross Delta";
				bool divaSolo = false;
				int numMulti = -1;
				EEDKAACNBBG song = new EEDKAACNBBG();
				song.KHEKNNFCAOI(MusicDb.EPMMNEFADAP_Musics[i].DLAEJOBELBH_Id);

				for (int k = 0; k < 7; k++)
				{
					if ((song.BNCMJNMIDIN & (1 << k)) != 0)
					{
						if (k == 0)
							divaSolo = true;
						else
							numMulti = k + 1;
					}
				}
				fileOutput += "|" + i + "|" + MusicDb.EPMMNEFADAP_Musics[i].KKPAHLMJKIH_WavId + "|" + Title + "|" + Serie + "|" + (divaSolo ? "X" : "") + "|" + (numMulti != -1 ? numMulti.ToString() : "") + "\n";
			}
		}
		File.WriteAllText(Application.dataPath + "../../../Data/SongList.txt", fileOutput);
	}

	[MenuItem("UMO/Export Costume List", validate = true)]
	static bool ExportCostumeListAvaiable()
	{
		return Application.isPlaying && IMMAOANGPNK.HHCJCDFCLOB != null && IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized;
	}
	[MenuItem("UMO/Export Costume List")]
	static void ExportCostumeList()
	{
		LCLCCHLDNHJ_Costume CostumeDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
		string fileOutput = "";
		for (int i = 0; i < CostumeDb.CDENCMNHNGA.Count; i++)
		{
			string cos_name = "";// MessageManager.Instance.GetMessage("master", "ep_nm_" + CostumeDb.CDENCMNHNGA[i].DAJGPBLEEOB_PrismCostumeModelId.ToString("D4"));
			fileOutput += "|" + CostumeDb.CDENCMNHNGA[i].AHHJLDLAPAN_PrismDivaId + "|" + CostumeDb.CDENCMNHNGA[i].DAJGPBLEEOB_PrismCostumeModelId + "|" + CostumeDb.CDENCMNHNGA[i].JPIDIENBGKH_CostumeId + "|" + cos_name + "\n";
		}
		File.WriteAllText(Application.dataPath + "../../../Data/CostumeList.txt", fileOutput);
	}

	[MenuItem("UMO/Export Song Effect Enabler List", validate = true)]
	static bool ExportSongEffectEnablerListAvaiable()
	{
		return Application.isPlaying && IMMAOANGPNK.HHCJCDFCLOB != null && IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized;
	}
	[MenuItem("UMO/Export Song Effect Enabler List")]
	static void ExportSongEffectEnablerList()
	{
		BundleShaderInfo.Instance.StartCoroutine(ExtractEffectList());
	}

	static public IEnumerator ExtractEffectList()
	{
		StreamWriter writer = new StreamWriter(Application.dataPath + "../../../Data/SongEffectlist.csv", false);
		writer.WriteLine("Song;Type;Id;Diva;Costume;Valkyrie;Pilot;Position;Group;AttachToDiva");
		string path = FileSystemProxy.ConvertPath(UnityEngine.Application.persistentDataPath + "/data/android/mc/0001/sc.xab");
		int pos = path.IndexOf("mc/") + 2;
		string[] dirsSong = Directory.GetDirectories(path.Substring(0, pos));
		foreach (var dir in dirsSong)
		{
			Debug.Log(dir);
			DirectoryInfo dirInfo = new DirectoryInfo(dir);
			if (dirInfo.Name == "cmn")
				continue;

			var operation = AssetBundleManager.LoadAssetAsync("mc/" + dirInfo.Name + "/sc.xab", "p_" + dirInfo.Name.Replace("_3", "").Replace("_2", ""), typeof(MusicDirectionParamBase));
			yield return operation;

			MusicDirectionParamBase param = operation.GetAsset<MusicDirectionParamBase>();

			if (param)
			{
				param.WriteEffectList(writer, dirInfo.Name);
			}
			AssetBundleManager.UnloadAssetBundle("mc/" + dirInfo.Name + "/sc.xab", true);
		}
		writer.Close();
		Debug.Log("Done");
	}

}
