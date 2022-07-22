/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2012 CRI Middleware Co.,Ltd.
 *
 * Library  : CRI Mana
 * Module   : CRI Mana for Unity Editor
 * File     : CriManaPlayerEditor.cs
 *
 ****************************************************************************/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[CustomEditor(typeof(CriManaPlayer))]
public class CriManaPlayerEditor : Editor
{
	#region Variables
	private CriManaPlayer source = null;
	#endregion

	#region Functions
	private void OnEnable()
	{
		this.source = (CriManaPlayer)base.target;
	}
	
	public override void OnInspectorGUI()
	{
		if (this.source == null) {
			return;
		}

		Undo.RecordObject(target, null);

		GUI.changed = false;
		{
			this.source.moviePath   = EditorGUILayout.TextField("Movie Path", this.source.moviePath);
			this.source.playOnStart = EditorGUILayout.Toggle("Play On Start", this.source.playOnStart);
			this.source.loop        = EditorGUILayout.Toggle("Loop", this.source.loop);
			this.source.volume      = EditorGUILayout.Slider("Volume", this.source.volume, 0.0f, 1.0f);
			
			this.source.movieMaterial	= (Material)EditorGUILayout.ObjectField("Movie Material", this.source.movieMaterial, typeof(Material), false);
			this.source.flipTopBottom = EditorGUILayout.Toggle("Flip Top/Bottom", this.source.flipTopBottom);
			this.source.flipLeftRight = EditorGUILayout.Toggle("Flip Left/Right", this.source.flipLeftRight);
			this.source.additiveMode = EditorGUILayout.Toggle("Additive Mode", this.source.additiveMode);
		}
		if (GUI.changed) {
			EditorUtility.SetDirty(this.source);
		}
	}
	#endregion
} // end of class

/* end of file */
