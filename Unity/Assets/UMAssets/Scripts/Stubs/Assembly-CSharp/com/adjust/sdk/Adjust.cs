using UnityEngine;

namespace com.adjust.sdk
{
	public class Adjust : MonoBehaviour
	{
		public bool startManually;
		public bool eventBuffering;
		public bool sendInBackground;
		public bool launchDeferredDeeplink;
		public string appToken;
		public AdjustLogLevel logLevel;
		public AdjustEnvironment environment;
	}
}
