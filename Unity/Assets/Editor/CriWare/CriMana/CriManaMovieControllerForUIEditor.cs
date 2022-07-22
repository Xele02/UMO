/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co.,Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CriManaMovieControllerForUI))]
public class CriManaMovieControllerForUIEditor : Editor
{
	private CriManaMovieControllerForUI source = null;
	
	private void OnEnable()
	{
		source = (CriManaMovieControllerForUI)base.target;
	}
	
	public override void OnInspectorGUI()
	{
		if (this.source == null) {
			return;
		}

		Undo.RecordObject(target, null);

		GUI.changed = false;
		{
			EditorGUILayout.PrefixLabel("Startup Parameter");
			++EditorGUI.indentLevel;
			{
				source.moviePath    = EditorGUILayout.TextField("Movie Path", source.moviePath);
				source.playOnStart  = EditorGUILayout.Toggle("Play On Start", source.playOnStart);
				source.loop         = EditorGUILayout.Toggle("Loop", source.loop);
			}
			--EditorGUI.indentLevel;
			
			source.additiveMode    = EditorGUILayout.Toggle("Additive Mode", source.additiveMode);
			source.material        = (Material)EditorGUILayout.ObjectField("Material", source.material, typeof(Material), true);
			
			EditorGUILayout.PrefixLabel("Renderer Control");
			++EditorGUI.indentLevel;
			{
				source.target              = (UnityEngine.UI.Graphic)EditorGUILayout.ObjectField("Target", source.target, typeof(UnityEngine.UI.Graphic), true);
				source.useOriginalMaterial = EditorGUILayout.Toggle("Use Original Material", source.useOriginalMaterial);
			}
			--EditorGUI.indentLevel;
		}
		if (GUI.changed) {
			EditorUtility.SetDirty(this.source);
		}
	}
}
