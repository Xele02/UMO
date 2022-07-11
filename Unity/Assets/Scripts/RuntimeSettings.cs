
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeSettings", menuName = "ScriptableObjects/RuntimeSettings", order = 1)]
class RuntimeSettings : ScriptableObject
{
	public static bool ForceDivaUnlock = true;
	public static bool ForceCostumeUnlock = true;
	public string DataDirectory;
	public string DataWebServerURL;
}
