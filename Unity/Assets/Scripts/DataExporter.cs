using UnityEditor;
using UnityEngine;
using XeApp.Game.Common;
using System.IO;
using System.Collections;
using XeApp.Core;
using XeApp.Game;
using XeSys;
using System;

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
				bool valid = MusicDb.GEAANLPDJBP_FreeMusicDatas.Find((KEODKEGFDLD data) => {
					return data.DLAEJOBELBH_Id == MusicDb.EPMMNEFADAP_Musics[i].DLAEJOBELBH_Id && data.PPEGAKEIEGM == 2;
				}) != null;
				fileOutput += "|" + i + "|" + MusicDb.EPMMNEFADAP_Musics[i].KKPAHLMJKIH_WavId + "|" + Title + "|" + Serie + "|" + (divaSolo ? "X" : "") + "|" + (numMulti != -1 ? numMulti.ToString() : "") + "|" + (valid ? "X" : "") + "\n";
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
		for(int diva = 1; diva <= 10; diva++)
		{
			for (int i = 0; i < CostumeDb.CDENCMNHNGA.Count; i++)
			{
				if(CostumeDb.CDENCMNHNGA[i].PPEGAKEIEGM == 2 && CostumeDb.CDENCMNHNGA[i].AHHJLDLAPAN_PrismDivaId == diva)
				{
					string cos_name = MessageManager.Instance.GetMessage("master", "cos_" + CostumeDb.CDENCMNHNGA[i].DAJGPBLEEOB_PrismCostumeModelId.ToString("D4"));
					fileOutput += "|" + CostumeDb.CDENCMNHNGA[i].AHHJLDLAPAN_PrismDivaId + "|" + CostumeDb.CDENCMNHNGA[i].DAJGPBLEEOB_PrismCostumeModelId + "|" + CostumeDb.CDENCMNHNGA[i].JPIDIENBGKH_CostumeId + "|" + cos_name + "\n";
				}
			}
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
		LPPGENBEECK_musicMaster MusicDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;

		StreamWriter writer = new StreamWriter(Application.dataPath + "../../../Data/SongEffectlist.txt", false);
		string path = FileSystemProxy.ConvertPath(UnityEngine.Application.persistentDataPath + "/data/android/mc/0001/sc.xab");
		int pos = path.IndexOf("mc/") + 2;
		string[] dirsSong = Directory.GetDirectories(path.Substring(0, pos));
		foreach (var dir in dirsSong)
		{
			Debug.Log(dir);
			DirectoryInfo dirInfo = new DirectoryInfo(dir);
			if (dirInfo.Name == "cmn")
				continue;

			string songId = dirInfo.Name.Replace("_3", "").Replace("_2", "").Replace("_5", "");

			var music = MusicDb.EPMMNEFADAP_Musics.Find((EONOEHOKBEB_Music data) =>
			{
				return data.KKPAHLMJKIH_WavId == Int32.Parse(songId);
			});
			string Title = music != null ? Database.Instance.musicText.Get(music.KNMGEEFGDNI_Nam).musicName : "";
			if (dirInfo.Name.Contains("_3"))
				Title += " (3 divas)";
			if (dirInfo.Name.Contains("_2"))
				Title += " (2 divas)";
			if (dirInfo.Name.Contains("_5"))
				Title += " (5 divas)";

			if (Title != "")
				writer.WriteLine("# "+Title);
			writer.WriteLine("|Song|Type|Id|Diva|Costume|Valkyrie|Pilot|Position|Group|AttachToDiva|");
			writer.WriteLine("|---|---|---|---|---|---|---|---|---|---|");

			var operation = AssetBundleManager.LoadAssetAsync("mc/" + dirInfo.Name + "/sc.xab", "p_" + songId, typeof(MusicDirectionParamBase));
			yield return operation;

			MusicDirectionParamBase param = operation.GetAsset<MusicDirectionParamBase>();

			if (param)
			{
				param.WriteEffectList(writer, "|"+dirInfo.Name);
			}
			AssetBundleManager.UnloadAssetBundle("mc/" + dirInfo.Name + "/sc.xab", true);
		}
		writer.Close();
		Debug.Log("Done");
	}

}
