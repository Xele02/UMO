using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[InitializeOnLoad]
public class FullscreenPlayMode : MonoBehaviour
{
#if UNITY_EDITOR
	//The size of the toolbar above the game view, excluding the OS border.
	private static int tabHeight = 22;

	bool bEnableFullScreen = false;

	private void CheckPlayModeState()
	{
		bEnableFullScreen = !bEnableFullScreen;
		if (bEnableFullScreen)
		{
			FullScreenGameWindow();
		}
		else
		{
			CloseGameWindow();
		}
	}

	private EditorWindow GetMainGameView()
	{
		EditorApplication.ExecuteMenuItem("Window/General/Game");

		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.FieldInfo M = T.GetField("s_GameViews", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		IEnumerable l = M.GetValue(null) as IEnumerable;
		foreach(var w in l)
		{
			EditorWindow Res_ = w as EditorWindow;
			//if(Res_.name.StartsWith("Game (Stereo)"))
			if(Res_.position.xMin == 0)
				return Res_;
		}
		return null;
	}

	public void FullScreenGameWindow()
	{
		EditorWindow gameView = GetMainGameView();
		if(gameView == null)
		{
			System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
			gameView = ScriptableObject.CreateInstance(T) as EditorWindow;
			gameView.ShowPopup();
		}
		StartCoroutine(MoveWindow(gameView));
	}

	private IEnumerator MoveWindow(EditorWindow gameView)
	{
		while (true)
		{
			yield return null;
			Display[] displays = Display.displays;

			gameView.title = "Game (Stereo)" + gameView.position;
			gameView.name = "Game (Stereo)";
			Rect newPos = new Rect(0, 0, Screen.currentResolution.width, Screen.currentResolution.height);
			//Rect newPos = new Rect(0, 0 - tabHeight, 1920, 1080 + tabHeight);
			Rect Override = RuntimeSettings.CurrentSettings.FullScreenPositionAndSizeOverride;
			if(Override.x != -1) newPos.x = Override.x;
			if(Override.width != -1) newPos.width = Override.width;
			if(Override.y != -1) newPos.y = Override.y;
			if(Override.height != -1) newPos.height = Override.height;
			newPos.y -= tabHeight;
			newPos.height += tabHeight;

			gameView.position = newPos;
			//gameView.minSize = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height + tabHeight);
			//gameView.minSize = newPos.size;
			//gameView.maxSize = gameView.minSize;
			//gameView.position = newPos;
		}
	}

	private void CloseGameWindow()
	{
		EditorWindow gameView = GetMainGameView();
		if(gameView != null)
		{
			gameView.Close();
		}
		StopAllCoroutines();
	}

	public void Update()
	{
		if(Input.GetKeyDown(RuntimeSettings.CurrentSettings.Fullscreen))
		{
			CheckPlayModeState();
		}
	}
#endif
}