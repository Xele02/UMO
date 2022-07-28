using UnityEngine;
using UnityEngine.SceneManagement;

public class UMOStart : MonoBehaviour
{
    bool hasSwitched = false;
    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		StartCoroutine(FileSystemProxy.InitServerFileList());
    }
    
    void Update()
    {
        if(!hasSwitched && BundleShaderInfo.Instance.IsInitialized && FileSystemProxy.IsInitialized)
        {
            hasSwitched = true;
            SceneManager.LoadScene("UMAssets/Scene/Project/Scenes/Boot");
        }
    }
}
