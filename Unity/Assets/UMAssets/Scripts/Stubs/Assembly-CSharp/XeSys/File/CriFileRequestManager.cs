using UnityEngine;

namespace XeSys.File
{
	internal class CriFileRequestManager : MonoBehaviour
	{
		[SerializeField]
		private bool emulation;
		[SerializeField]
		private float emulationWait;
		[SerializeField]
		private int loadCountLimit;
	}
}
