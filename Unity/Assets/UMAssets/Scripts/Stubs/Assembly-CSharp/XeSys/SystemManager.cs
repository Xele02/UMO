using UnityEngine;
using XeSys.File;

namespace XeSys
{
	public class SystemManager : MonoBehaviour
	{
		[SerializeField]
		private DebugTextRenderer debugTextRendererPrefab;
		[SerializeField]
		private DebugFPS debugFpsPrefab;
		[SerializeField]
		private InputManager inputManagerPrefab;
		[SerializeField]
		private CriFileRequestManager criFileRequestManagerPrefab;
	}
}
