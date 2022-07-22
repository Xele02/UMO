/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2014 CRI Middleware Co.,Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom for Unity Editor
 * File     : CriAtomSourceEditor.cs
 *
 ****************************************************************************/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[CustomEditor(typeof(CriAtomSource))]
public class CriAtomSourceEditor : Editor
{
	#region Variables
	private CriAtomSource source = null;
	private bool showAndroidConfig;
	private GUIStyle style;
	//private bool showPreview = true;
	#endregion

	#region Functions
	private void OnEnable()
	{
		this.source = (CriAtomSource)base.target;
		this.style = new GUIStyle();
	}
	
	public override void OnInspectorGUI()
	{
		if (this.source == null) {
			return;
		}

		Undo.RecordObject(target, null);

		GUI.changed = false;
		{
			EditorGUI.indentLevel++;
			this.source.cueSheet = EditorGUILayout.TextField("Cue Sheet", this.source.cueSheet);
			this.source.cueName = EditorGUILayout.TextField("Cue Name", this.source.cueName);		
			this.source.playOnStart = EditorGUILayout.Toggle("Play On Start", this.source.playOnStart);
			EditorGUILayout.Space();
			this.source.volume = EditorGUILayout.Slider("Volume", this.source.volume, 0.0f, 1.0f);
			this.source.pitch = EditorGUILayout.Slider("Pitch", this.source.pitch, -1200f, 1200);
			this.source.loop = EditorGUILayout.Toggle("Loop", this.source.loop);
			this.source.use3dPositioning = EditorGUILayout.Toggle("3D Positioning", this.source.use3dPositioning);

			this.showAndroidConfig = EditorGUILayout.Foldout(this.showAndroidConfig, "Android Config");
			if (this.showAndroidConfig) {
				EditorGUI.indentLevel++;
				EditorGUILayout.BeginHorizontal();
				style.stretchWidth = true;
				this.source.androidUseLowLatencyVoicePool = EditorGUILayout.Toggle("Low Latency Playback", this.source.androidUseLowLatencyVoicePool);
				EditorGUILayout.EndHorizontal();
				EditorGUI.indentLevel--;
			}

			/*#region preview
			if (this.source.acb != null) {
				this.showPreview = EditorGUILayout.Foldout(this.showPreview, "Preview");
				if (showPreview) {
					EditorGUILayout.BeginHorizontal();
					{
						EditorGUILayout.PrefixLabel("  ");
						if (GUILayout.Button("Play", EditorStyles.miniButtonLeft)) {
							this.source.Play();
						}
						if (GUILayout.Button("Stop", EditorStyles.miniButtonRight)) {
							this.source.Stop();
						}
					}
					EditorGUILayout.EndHorizontal();
				}
			}
			#endregion*/
		}
		if (GUI.changed) {
			EditorUtility.SetDirty(this.source);
		}
	}
	#endregion
} // end of class

/* end of file */
