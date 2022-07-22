/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2012 CRI Middleware Co.,Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom for Unity Editor
 * File     : CriAtomListenerEditor.cs
 *
 ****************************************************************************/
using UnityEditor;
using UnityEngine;

public class CriWareEditor : Editor
{
	[MenuItem("CRI/Create CRIWARE Library Initializer", false, 150)]
	public static void CreateCriwareLibraryInitalizer()
	{
		CriWareInitializer[] criWareInitializerList = FindObjectsOfType(typeof(CriWareInitializer)) as CriWareInitializer[];
		if (criWareInitializerList.Length > 0) {
			Debug.LogError("\"CriWareLibraryInitializer\" already exists.");
			
			Selection.activeGameObject = criWareInitializerList[0].gameObject;

		} else { 		
			GameObject go = null;
			go = new GameObject("CriWareLibraryInitializer");
			
			go.AddComponent<CriWareInitializer>();
			
			Selection.activeGameObject = go;
		}
	}	

	[MenuItem("CRI/Create CRIWARE Error Handler", false, 150)]
	public static void CreateCriwareErrorHandler()
	{
		CriWareErrorHandler[] criWareErrorHandlerList = FindObjectsOfType(typeof(CriWareErrorHandler)) as CriWareErrorHandler[];
		if (criWareErrorHandlerList.Length > 0) {
			Debug.LogError("\"CriWareErrorHandler\" already exists.");
			
			Selection.activeGameObject = criWareErrorHandlerList[0].gameObject;
                
		} else { 		
			GameObject go = null;
			go = new GameObject("CriWareErrorHandler");
			
			go.AddComponent<CriWareErrorHandler>();
			
			Selection.activeGameObject = go;
		}
	}	

} // end of class

/* end of file */
