using UnityEngine;
using XeApp.Game.Common;
using System.IO;
using System.Collections;
using XeApp.Core;
using XeApp.Game;
using XeSys;
using System;
using XeApp.Game.Menu;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
using UnityEditor;
#endif

#if false

class DataExporter
{
#if UNITY_EDITOR
	[MenuItem("UMO/Export Song List", validate = true)]
	static bool ExportSongListAvaiable()
	{
		return Application.isPlaying && IMMAOANGPNK.HHCJCDFCLOB != null && IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized;
	}
	[MenuItem("UMO/Export Song List")]
	static void ExportSongList()
	{
		LPPGENBEECK_MusicMaster MusicDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		string fileOutput = "";
		for (int i = 0; i < MusicDb.EPMMNEFADAP_Musics.Count; i++)
		{
			if (MusicDb.EPMMNEFADAP_Musics[i].JNCPEGJGHOG_Cov > 0)
			{
				string Title = Database.Instance.musicText.Get(MusicDb.EPMMNEFADAP_Musics[i].KNMGEEFGDNI_Nam).musicName;
				string Serie = string.Format("{0}", MusicDb.EPMMNEFADAP_Musics[i].AIHCEGFANAM_SerieAttr);
				if (Serie == "4") Serie = "Macross";
				if (Serie == "3") Serie = "Macross 7";
				if (Serie == "2") Serie = "Macross Frontier";
				if (Serie == "1") Serie = "Macross Delta";
				bool divaSolo = false;
				int numMulti = -1;
				EEDKAACNBBG_MusicData song = new EEDKAACNBBG_MusicData();
				song.KHEKNNFCAOI(MusicDb.EPMMNEFADAP_Musics[i].DLAEJOBELBH_Id);

				for (int k = 0; k < 7; k++)
				{
					if ((song.BNCMJNMIDIN_AvaiableDivaModes & (1 << k)) != 0)
					{
						if (k == 0)
							divaSolo = true;
						else
							numMulti = k + 1;
					}
				}
				bool valid = MusicDb.GEAANLPDJBP_FreeMusicDatas.Find((KEODKEGFDLD_FreeMusicInfo data) => {
					return data.DLAEJOBELBH_MusicId == MusicDb.EPMMNEFADAP_Musics[i].DLAEJOBELBH_Id && data.PPEGAKEIEGM_Enabled == 2;
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
		Directory.CreateDirectory(Application.dataPath + "../../../Data/CostumeImg/");
		LCLCCHLDNHJ_Costume CostumeDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
		string fileOutput = "";
		for(int diva = 1; diva <= 10; diva++)
		{
			for (int i = 0; i < CostumeDb.CDENCMNHNGA_Costumes.Count; i++)
			{
				var cosInfo = CostumeDb.CDENCMNHNGA_Costumes[i];
				if (cosInfo.PPEGAKEIEGM_Enabled == 2 && cosInfo.AHHJLDLAPAN_PrismDivaId == diva)
				{
					GameManager.Instance.DivaIconCache.LoadDivaUpIco(cosInfo.AHHJLDLAPAN_PrismDivaId, cosInfo.DAJGPBLEEOB_PrismCostumeModelId, 0, (IiconTexture texture) =>
					{
						//0x169C1D8
						Material mat = new Material(Shader.Find("MCRS/SplitTextureRGB16A8"));
						mat.SetTexture("_MainTex", texture.BaseTexture);
						mat.SetTexture("_MaskTex", texture.MaskTexture);
						Texture2D tex = TextureHelper.Copy(texture.BaseTexture, -1, -1, mat);
						File.WriteAllBytes(Application.dataPath + "../../../Data/CostumeImg/" + cosInfo.JPIDIENBGKH_CostumeId + ".png", tex.EncodeToPNG());
					});

					string cos_name = MessageManager.Instance.GetMessage("master", "cos_" + cosInfo.DAJGPBLEEOB_PrismCostumeModelId.ToString("D4"));
					fileOutput += "|[[/images/costumes/"+ cosInfo.JPIDIENBGKH_CostumeId + ".png]]|" + cosInfo.AHHJLDLAPAN_PrismDivaId + "|" + cosInfo.DAJGPBLEEOB_PrismCostumeModelId + "|" + cosInfo.JPIDIENBGKH_CostumeId + "|" + cos_name + "\n";
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
		BundleShaderInfo.Instance.StartCoroutineWatched(ExtractEffectList());
	}

	static public IEnumerator ExtractEffectList()
	{
		LPPGENBEECK_MusicMaster MusicDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;

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
			yield return Co.R(operation);

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

	[MenuItem("UMO/Copy Song setup for bug report", validate = true)]
	static bool CopySongSetupAvaiable()
	{
		return Application.isPlaying && IMMAOANGPNK.HHCJCDFCLOB != null && 
			IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized && 
			SceneManager.GetActiveScene().name.Contains("Rhythm");
	}
	[MenuItem("UMO/Copy Song setup for bug report")]
	static void CopySongSetup()
	{
		string txt = "";
		int songId = Database.Instance.gameSetup.musicInfo.prismMusicId;
		var music = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(songId);
		string Title = music != null ? Database.Instance.musicText.Get(music.KNMGEEFGDNI_Nam).musicName : "";
		txt += "Song : "+songId+" "+Title+"\n";
		txt += "Num diva : "+Database.Instance.gameSetup.musicInfo.onStageDivaNum+"\n";
		for(int i = 0; i < Database.Instance.gameSetup.musicInfo.onStageDivaNum; i++)
		{
			txt += " "+i+" : Diva : "+Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismDivaId + " - Costume : " + 
				Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismCostumeModelId + " - " + Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismCostumeColorId + 
				" Position : "+Database.Instance.gameSetup.teamInfo.danceDivaList[i].positionId+"\n";
		}
		txt += "Valkyrie : "+Database.Instance.gameSetup.teamInfo.prismValkyrieId+"\n";
		txt += "Difficulty : "+Database.Instance.gameSetup.musicInfo.difficultyType+", Line6 : "+Database.Instance.gameSetup.musicInfo.IsLine6Mode;
		GUIUtility.systemCopyBuffer = txt;
	}

	[MenuItem("Assets/UMO/Convert Texture to PNG", true)]
	private static bool CheckConvertTexture()
	{
		return Selection.activeObject is Texture;
	}

	[MenuItem("Assets/UMO/Convert Texture to PNG")]
	private static void ConvertTexture()
	{
		string[] assets = Selection.assetGUIDs;
		for (int i = 0; i < assets.Length; i++)
		{
			string path = AssetDatabase.GUIDToAssetPath(assets[i]);
			Texture2D tex = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
			if (tex)
			{
				string name = path.Replace(".asset", "new.png");
				Texture2D t = TextureHelper.Copy(tex);
				File.WriteAllBytes(name, t.EncodeToPNG());
			}
		}
	}
#endif
}
#endif
