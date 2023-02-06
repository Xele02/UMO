using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
using UnityEditor;
#endif
using System.IO;

public class UMOStart : MonoBehaviour
{
#if UNITY_EDITOR
	[MenuItem("UMO/Start Game", validate = true)]
#endif
	static bool StartGameAvaiable()
	{
		return !Application.isPlaying;
	}

#if UNITY_EDITOR
	[MenuItem("UMO/Start Game")]
#endif
	static void StartGameMenu()
	{
        StartGameMenuInternal();
    }

#if UNITY_EDITOR
	[MenuItem("UMO/Start Auto SLive Viewer (Experimental)", validate = true)]
#endif
	static bool StartSLiveAvaiable()
	{
		return !Application.isPlaying;
	}

#if UNITY_EDITOR
	[MenuItem("UMO/Start Auto SLive Viewer (Experimental)")]
#endif
	static void StartSLive()
	{
        RuntimeSettings.CurrentSettings.SLiveViewerRequest = true;
        StartGameMenuInternal();
    }

    static bool StartGameMenuInternal()
    {
        if(!RuntimeSettings.CurrentSettings.IsPathValid())
        {
            return TrySelectDirectory();
        }
        else
        {
#if UNITY_EDITOR
			if(!EditorApplication.isPlaying)
                StartGameEditor();
#endif
			return true;
        }
    }

    static bool TrySelectDirectory()
	{
#if UNITY_EDITOR
		if (EditorUtility.DisplayDialog("Game Data error", "Game data directory ("+RuntimeSettings.CurrentSettings.DataDirectory+") is not setup correctly and no game data was found in the default directories. Please select the directory containing game directories \"android\" and \"db\".", "Select directory", "Cancel"))
        {
            string path = EditorUtility.OpenFolderPanel("Select Game data directory", Application.dataPath, "");
            if(!string.IsNullOrEmpty(path))
            {
                RuntimeSettings.CurrentSettings.DataDirectory = path;
                EditorUtility.SetDirty(RuntimeSettings.CurrentSettings);
                AssetDatabase.SaveAssets();
                return StartGameMenuInternal();
            }
        }
#endif
		return false;
    }

    static void StartGameEditor()
	{
#if UNITY_EDITOR
		if (EditorSceneManager.GetActiveScene().name != "Start")
            EditorSceneManager.OpenScene("Assets/Scenes/Start.unity", OpenSceneMode.Single);
		EditorApplication.isPlaying = true;
#endif
	}

	bool hasSwitched = false;
    bool canStart = false;
    void Start()
    {
        if(!RuntimeSettings.CurrentSettings.IsPathValid())
        {
            if(!TrySelectDirectory())
			{
#if UNITY_EDITOR
				EditorApplication.isPlaying = false;
#endif
				return;
            }
        }
        canStart = true;
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        if(RuntimeSettings.CurrentSettings.SLiveViewerRequest)
        {
            RuntimeSettings.CurrentSettings.SLiveViewerRequest = false;
            RuntimeSettings.CurrentSettings.SLiveViewer = true;
        }
        else
        {
            RuntimeSettings.CurrentSettings.SLiveViewer = false;
        }
		this.StartCoroutineWatched(FileSystemProxy.InitServerFileList());
    }
    
    void Update()
    {
        if(canStart && !hasSwitched && BundleShaderInfo.Instance.IsInitialized && FileSystemProxy.IsInitialized)
        {
            hasSwitched = true;
            SceneManager.LoadScene("UMAssets/Scene/Project/Scenes/Boot");
        }
    }
}
