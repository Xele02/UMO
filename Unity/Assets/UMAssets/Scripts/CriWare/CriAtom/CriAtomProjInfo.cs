/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CriWare {

/**
 * \deprecated
 * 削除予定の非推奨APIです。
*/
[Obsolete("Class CriAtomAcfInfo is obsolete and will be removed in the future")]
public partial class CriAtomAcfInfo
{
	#region Variables
	public static AcfInfo acfInfo = null;
	#endregion

	#region InfoBase
	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	*/
	[Obsolete("Class CriAtomAcfInfo.InfoBase is obsolete and will be removed in the future")]
	[Serializable]
	public class InfoBase : System.Object
	{
		public string name = "dummyCueSheet";
		public int id = 0;
		public string comment = "";
	} /* end of class */
	#endregion

	#region AcfInfo
	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	*/
	[Obsolete("Class CriAtomAcfInfo.AcfInfo is obsolete and will be removed in the future")]
	[Serializable]
	public class AcfInfo : InfoBase
	{
		public string acfPath = "dummyCueSheet.acf";
		#if UNITY_EDITOR
		[SerializeField]
		private List<AcbInfo> tmpAcbInfoList = new List<AcbInfo>();
		#endif
		public string atomGuid = "";
		public string dspBusSetting = "DspBusSetting_0";
		public List<string> aisacControlNameList = new List<string>();
		public string acfFilePath = "";

		public AcfInfo(string n, int inId, string com, string inAcfPath, string _guid, string _dspBusSetting)
		{
			this.name = n;
			this.id = inId;
			this.comment = com;
			this.acfPath = inAcfPath;
			this.atomGuid = _guid;
			this.dspBusSetting = _dspBusSetting;
		}

#if UNITY_EDITOR
		/**
		* \deprecated
		* 削除予定の非推奨APIです。
		*/
		[Obsolete("Class CriAtomAcfInfo.AcfInfo is obsolete. Its member methods will be unvailable in the future")]
		public AcbInfo[] GetAcbInfoList(bool foreceReload, string searchPath)
		{
			if (tmpAcbInfoList.Count == 0 || foreceReload){
				tmpAcbInfoList = new List<AcbInfo>();

				//ACBは都度読み込みに修正
				int acbIndex = 0;
				{
					if (UnityEditor.EditorApplication.isPlaying){
						GetAcbInfoListCore(searchPath, ref acbIndex);
					}
				}
			}
			return tmpAcbInfoList.ToArray();
		}

		private void GetAcbInfoListCore(string searchPath, ref int acbIndex)
		{
			string[] files = System.IO.Directory.GetFiles(searchPath);
			foreach(string file in files){
				if (System.IO.Path.GetExtension(file.Replace("\\", "/")) == ".acb"){
					AcbInfo acbInfo = new AcbInfo(System.IO.Path.GetFileNameWithoutExtension(file),
												  acbIndex, "", System.IO.Path.GetFileName(file), "", "");
					/* 指定したACBファイル名(キューシート名)を指定してキュー情報を取得 */
					CriAtomExAcb acb = CriAtomExAcb.LoadAcbFile(null, file.Replace("\\", "/"), "");
					if (acb != null){
						/* キュー名リストの作成 */
						CriAtomEx.CueInfo[] cueInfoList = acb.GetCueInfoList();
						foreach(CriAtomEx.CueInfo cueInfo in cueInfoList){
							CueInfo tmpCueInfo = new CueInfo(cueInfo.name, cueInfo.id, cueInfo.userData);
							bool found = false;
							foreach(var key in acbInfo.cueInfoList){
								if (key.id == cueInfo.id){
									found = true;
									break;
								}
							}
							if (found == false){
								acbInfo.cueInfoList.Add(tmpCueInfo);
							} else {
								//  inGame時のサブシーケンスの場合あり
								//Debug.Log("already exists in the dictionay id:" + cueInfo.id.ToString() +"name:" + cueInfo.name);
							}
						}
						acb.Dispose();
					} else {
						Debug.Log("GetAcbInfoList LoadAcbFile. acb is null. " + file);
					}
					tmpAcbInfoList.Add(acbInfo);
					acbIndex++;
				}
			}

			//  directory
			string[] directories = System.IO.Directory.GetDirectories(searchPath);
			foreach(string directory in directories){
				GetAcbInfoListCore(directory, ref acbIndex);
			}
		}
#endif

	} /* end of class */
	#endregion

	#region AcbInfo
	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	*/
	[Obsolete("Class CriAtomAcfInfo.AcbInfo is obsolete and will be removed in the future")]
	[Serializable]
	public class AcbInfo : InfoBase
	{
		public string acbPath = "dummyCueSheet.acb";
		public string awbPath = "dummyCueSheet_streamfiles.awb";
		public string atomGuid = "";
		public List<CueInfo> cueInfoList;

		public AcbInfo(string n, int inId, string com, string inAcbPath, string inAwbPath, string _guid)
		{
			this.name = n;
			this.id = inId;
			this.comment = com;
			this.acbPath = inAcbPath;
			this.awbPath = inAwbPath;
			this.atomGuid = _guid;
			this.cueInfoList = new List<CueInfo>();
		}
	} /* end of class */
	#endregion

	#region CueInfo
	[Obsolete("Class CriAtomAcfInfo.CueInfo is obsolete and will be removed in the future")]
	[Serializable]
	public class CueInfo : InfoBase
	{
		public CueInfo(string n, int inId, string com)
		{
			this.name = n;
			this.id = inId;
			this.comment = com;
		}
	} /* end of class */
	#endregion

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	*/
	[Obsolete("Class CriAtomAcfInfo is obsolete. Its methods will be unvailable in the future")]
	public static bool GetCueInfo(ref AcfInfo acfInfo, bool forceReload, string searchPath)
	{
		/* もしACFInfoが無い場合、acfがあるか検索 */
		if (acfInfo == null || forceReload){
			string[] files = System.IO.Directory.GetFiles(searchPath);
			foreach(string file in files){
				if (System.IO.Path.GetExtension(file.Replace("\\", "/")) == ".acf"){
					acfInfo = new AcfInfo(System.IO.Path.GetFileNameWithoutExtension(file),
														 0, "", System.IO.Path.GetFileName(file), "", "");
					acfInfo.acfFilePath = file;
					break;
				}
			}
			if (acfInfo == null){
				Debug.Log("CriAtomAcfInfo.acfInfo is null. \"" + searchPath + "\"");
			}
		}
		return (acfInfo != null);
	}
} // end of class

} //namespace CriWare
/* end of file */
