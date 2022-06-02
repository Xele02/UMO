using UnityEngine;

namespace XeSys.Net
{
	public class UrlRequestManager : MonoBehaviour
	{
		public enum TestMode
		{
			None = 0,
			Fail = 1,
			TimeOut = 2,
		}

		[SerializeField]
		private int retryCount;
		[SerializeField]
		private float timeOut;
		[SerializeField]
		private int requestListSize;
		[SerializeField]
		private float execWait;
		[SerializeField]
		private int listCount;
		[SerializeField]
		private bool emulation;
		[SerializeField]
		private float emulationWait;
		[SerializeField]
		private TestMode testMode;
	}
}
