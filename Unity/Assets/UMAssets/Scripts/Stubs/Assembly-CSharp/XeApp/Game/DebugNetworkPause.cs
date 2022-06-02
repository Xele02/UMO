using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class DebugNetworkPause : MonoBehaviour
	{
		[SerializeField]
		private Button buttonNext;
		[SerializeField]
		private Button buttonTimeout;
		[SerializeField]
		private Button buttonError;
		[SerializeField]
		private Text actionName;
		[SerializeField]
		private Dropdown dropdownErrorList;
		[SerializeField]
		private InputField inputErrorCode;
		[SerializeField]
		private Toggle toggleDoAction;
		public int selectedErrorId;
		public bool doErrorEmulation;
		public bool isOpened;
		public bool doTimeoutEmulaton;
		public bool emulateDoAction;
	}
}
