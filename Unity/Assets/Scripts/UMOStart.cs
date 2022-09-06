using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class UMOStart : MonoBehaviour
{
	[MenuItem("UMO/Start Game", validate = true)]
	static bool StartGameAvaiable()
	{
		return !Application.isPlaying;
	}

	[MenuItem("UMO/Start Game")]
	static void StartGameMenu()
	{
        StartGameMenuInternal();
    }

	[MenuItem("UMO/Start Auto SLive Viewer (Experimental)", validate = true)]
	static bool StartSLiveAvaiable()
	{
		return !Application.isPlaying;
	}

	[MenuItem("UMO/Start Auto SLive Viewer (Experimental)")]
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
            if(!EditorApplication.isPlaying)
                StartGameEditor();
            return true;
        }
    }

    static bool TrySelectDirectory()
    {
        if(EditorUtility.DisplayDialog("Game Data error", "Game data directory ("+RuntimeSettings.CurrentSettings.DataDirectory+") is not setup correctly and no game data was found in the default directories. Please select the directory containing game directories \"android\" and \"db\".", "Select directory", "Cancel"))
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
        return false;
    }

    static void StartGameEditor()
    {
        if(EditorSceneManager.GetActiveScene().name != "Start")
            EditorSceneManager.OpenScene("Assets/Scenes/Start.unity", OpenSceneMode.Single);
        EditorApplication.isPlaying = true;
    }

    bool hasSwitched = false;
    bool canStart = false;
    void Start()
    {
        if(!RuntimeSettings.CurrentSettings.IsPathValid())
        {
            if(!TrySelectDirectory())
            {
                EditorApplication.isPlaying = false;
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
		StartCoroutine(FileSystemProxy.InitServerFileList());
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
