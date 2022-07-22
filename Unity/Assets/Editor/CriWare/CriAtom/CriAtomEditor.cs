/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2012 CRI Middleware Co.,Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom for Unity Editor
 * File     : CriAtomAcfEditor.cs
 *
 ****************************************************************************/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[CustomEditor(typeof(CriAtom))]
public class CriAtomEditor : Editor
{
	#region Variables
	private CriAtom atom = null;
	#endregion

	#region Functions
	private void OnEnable()
	{
		atom = (CriAtom)base.target;		
	}

	public override void OnInspectorGUI()
	{
		if (atom == null) {
			return;
		}

		Undo.RecordObject(target, null);

		GUI.changed = false;
		{
			atom.acfFile       = EditorGUILayout.TextField("ACF File", atom.acfFile);
			atom.dspBusSetting = EditorGUILayout.TextField("DSP Bus Setting", atom.dspBusSetting);

			for (int i = 0; i < atom.cueSheets.Length; i++) {
				var cueSheet = atom.cueSheets[i];
				EditorGUILayout.BeginHorizontal("Label");
				GUILayout.Label("Cue Sheet");
				//GUILayout.Label("(" + cueSheet.name + ")");
				//cueSheet.name = GUILayout.TextField(cueSheet.name, );
				if (GUILayout.Button("Remove")) {
					atom.RemoveCueSheetInternal(cueSheet.name);
					break;
				}
				EditorGUILayout.EndHorizontal();
				EditorGUI.indentLevel++;
				cueSheet.name = EditorGUILayout.TextField("Name", cueSheet.name);
				cueSheet.acbFile = EditorGUILayout.TextField("ACB File", cueSheet.acbFile);
				cueSheet.awbFile = EditorGUILayout.TextField("AWB File", cueSheet.awbFile);
				EditorGUI.indentLevel--;
			}
			if (GUILayout.Button("Add CueSheet")) {
				atom.AddCueSheetInternal("", "", "", null);
			}

			atom.dontRemoveExistsCueSheet = EditorGUILayout.Toggle("Dont Remove Exists CueSheet", atom.dontRemoveExistsCueSheet);
			atom.dontDestroyOnLoad        = EditorGUILayout.Toggle("Dont Destroy On Load", atom.dontDestroyOnLoad);
		}
		if (GUI.changed) {
			EditorUtility.SetDirty(atom);
		}
	}
	#endregion
} // end of class

/* end of file */
