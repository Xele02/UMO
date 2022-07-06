
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeSettings", menuName = "ScriptableObjects/RuntimeSettings", order = 1)]
class RuntimeSettings : ScriptableObject
{
	public string DataDirectory;
	public string DataWebServerURL;
}
