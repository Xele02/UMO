using UnityEngine;

public class ScreensRecoder : MonoBehaviour
{
	public KeyCode[] screenCaptureKeys;
	public KeyCode[] keyModifiers;
	public int minimumWidth;
	public int minimumHeight;
	public bool isUseApplicationCapture;
	public string directory;
	public string baseFilename;
	public int framerate;
	public int endFrameno;
	private void Awake()
	{
		UnityEngine.Debug.LogError("Implement Monobehaviour");
	}
}
