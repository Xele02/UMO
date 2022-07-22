/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2012 CRI Middleware Co.,Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom for Unity
 * File     : CriAtomAcfInfo.cs
 *
 ****************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class CriAtomAcfInfo
{
	#region Variables
	public static AcfInfo acfInfo = null;
	#endregion
	
	#region InfoBase
	public class InfoBase
	{
		public string name = "dummyCueSheet";
		public int id = 0;
		public string comment = "";
	} /* end of class */
	#endregion
	
	#region AcfInfo
	public class AcfInfo : InfoBase
	{
		public string acfPath = "dummyCueSheet.acf";
		public List<AcbInfo> acbInfoList = new List<AcbInfo>();	//	old version format use (2015-10-15) unsupported.
		private List<AcbInfo> tmpAcbInfoList = new List<AcbInfo>();		
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
		public AcbInfo[] GetAcbInfoList(bool foreceReload,string searchPath)
		{
			if(tmpAcbInfoList.Count == 0 || foreceReload){
				tmpAcbInfoList = new List<AcbInfo>();
				
				//ACBは都度読み込みに修正
				int acbIndex = 0;
				{
					if (UnityEditor.EditorApplication.isPlaying)
					{
						GetAcbInfoListCore(searchPath,ref acbIndex);
					}
				}
			}
			return tmpAcbInfoList.ToArray();
		}
		
		private void GetAcbInfoListCore(string searchPath,ref int acbIndex)
		{
			string[] files = System.IO.Directory.GetFiles(searchPath);
			foreach (string file in files) {
				if (System.IO.Path.GetExtension(file.Replace("\\","/")) == ".acb") {
					
					AcbInfo acbInfo = new AcbInfo(System.IO.Path.GetFileNameWithoutExtension(file),
					                              acbIndex,"",System.IO.Path.GetFileName(file),"","");
					
					/* 指定したACBファイル名(キューシート名)を指定してキュー情報を取得 */
					CriAtomExAcb acb = CriAtomExAcb.LoadAcbFile(null, file.Replace("\\","/"), "");
					
					if(acb != null){
						/* キュー名リストの作成 */ 
						CriAtomEx.CueInfo[] cueInfoList = acb.GetCueInfoList();
						foreach(CriAtomEx.CueInfo cueInfo in cueInfoList){
							CueInfo tmpCueInfo = new CueInfo(cueInfo.name,cueInfo.id,cueInfo.userData);
							
							if(acbInfo.cueInfoList.ContainsKey(cueInfo.id) == false){
								acbInfo.cueInfoList.Add(cueInfo.id,tmpCueInfo);
							} else {
								//	inGame時のサブシーケンスの場合あり
								//Debug.Log("already exists in the dictionay id:" + cueInfo.id.ToString() +"name:" + cueInfo.name);
							}
						}
						
						acb.Dispose();
					}else {
						Debug.Log("GetAcbInfoList LoadAcbFile. acb is null. " + file);
					}
					
					tmpAcbInfoList.Add(acbInfo);
					acbIndex++;
				}
			}
			
			//	directory
			string[] directories = System.IO.Directory.GetDirectories(searchPath);
			foreach (string directory in directories) {
				GetAcbInfoListCore(directory,ref acbIndex);
			}
		}
		#endif
		
	} /* end of class */
	#endregion
	
	#region AcbInfo
	public class AcbInfo : InfoBase
	{
		public string acbPath = "dummyCueSheet.acb";
		public string awbPath = "dummyCueSheet_streamfiles.awb";
		public string atomGuid = "";
		public Dictionary<int, CueInfo> cueInfoList = new Dictionary<int, CueInfo>();
		
		public AcbInfo(string n, int inId, string com, string inAcbPath, string inAwbPath, string _guid)
		{
			this.name = n;
			this.id = inId;
			this.comment = com;
			this.acbPath = inAcbPath;
			this.awbPath = inAwbPath;
			this.atomGuid = _guid;
		}
	} /* end of class */
	#endregion
	
	#region CueInfo
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
	
	
	public static bool GetCueInfo(bool forceReload,string searchPath)
	{		
		/* もしACFInfoが無い場合、acfがあるか検索 */
		if (CriAtomAcfInfo.acfInfo == null || forceReload) {
			
			string[] files = System.IO.Directory.GetFiles(searchPath);
			
			foreach (string file in files) {
				if (System.IO.Path.GetExtension(file.Replace("\\","/")) == ".acf") {
					CriAtomAcfInfo.acfInfo = new AcfInfo(System.IO.Path.GetFileNameWithoutExtension(file),
					                                     0,"",System.IO.Path.GetFileName(file),"","");
					CriAtomAcfInfo.acfInfo.acfFilePath = file;
					break;
				}
			}
			
			if(CriAtomAcfInfo.acfInfo == null){
				Debug.Log("CriAtomAcfInfo.acfInfo is null. \"" + searchPath + "\"");
			}
		}
		
		return (CriAtomAcfInfo.acfInfo != null);
	}
	
	static partial void GetCueInfoInternal();
	
} // end of class

/* end of file */

