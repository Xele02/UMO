/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2012 CRI Middleware Co.,Ltd.
 *
 ****************************************************************************/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

[System.Serializable]
public class CriAtomWindowPrefs : ScriptableObject
{
	public string outputAssetsRoot = String.Empty;
	
	static string criAtomWindowPrefsFilePath = "Assets/Editor/CriWare/CriAtom/CriAtomWindowPrefs.asset";
	
	public void Save ()
	{
		//Debug.Log("SavePrefs \"" + criAtomWindowPrefsFilePath + "\"");
		Directory.CreateDirectory (Path.GetDirectoryName(criAtomWindowPrefsFilePath));
		CriAtomWindowPrefs preference = (CriAtomWindowPrefs)AssetDatabase.LoadAssetAtPath (criAtomWindowPrefsFilePath, typeof(CriAtomWindowPrefs));
		if (preference == null) {
			AssetDatabase.CreateAsset (this, criAtomWindowPrefsFilePath);
		} else {
			EditorUtility.SetDirty(this);
		}
		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh ();
		
		//Debug.Log("SavePrefs outputAssetsRoot is " + preference.outputAssetsRoot);
	}
	
	public static CriAtomWindowPrefs Load ()
	{
		//Debug.Log("LoadPrefs \"" + criAtomWindowPrefsFilePath + "\"");
		CriAtomWindowPrefs preference = (CriAtomWindowPrefs)AssetDatabase.LoadAssetAtPath (criAtomWindowPrefsFilePath, typeof(CriAtomWindowPrefs));
		if (preference == null) {
			//Debug.Log("LoadPrefs preference is null.");
			preference = CreateInstance<CriAtomWindowPrefs> ();
			preference.Save ();
		}

		//Debug.Log("LoadPrefs outputAssetsRoot is " + preference.outputAssetsRoot);

		return preference;
	}
}
