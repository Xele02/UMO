using UnityEngine;

namespace XeSys
{
	public class TimeWrapper
	{
		public static float time { get { return Time.time; } } // 0x23A6590 
		public static float timeSinceLevelLoad { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } //0x23A6598
		public static float deltaTime { get{ return Time.deltaTime; } } // 0x23A65A0
		public static float fixedTime { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } // 0x23A65A8
		public static float fixedDeltaTime { get{ UnityEngine.Debug.LogError("TODO"); return 0; }set{ UnityEngine.Debug.LogError("TODO"); } } // 0x23A65B0 0x23A65B8
		public static float maximumDeltaTime { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } // 0x23A65C0
		public static float smoothDeltaTime { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } // 0x23A65C8
		public static float timeScale { get{ UnityEngine.Debug.LogError("TODO"); return 0; } set{ UnityEngine.Debug.LogError("TODO"); } } // 0x23A65D0 0x23A65D8
		public static int frameCount { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } // 0x23A65E0
		public static int renderedFrameCount { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } // 0x23A65E8
		public static float realtimeSinceStartup { get{ UnityEngine.Debug.LogError("TODO"); return 0; } } // 0x23A65F0
		public static int captureFramerate { get{ UnityEngine.Debug.LogError("TODO"); return 0; } set{ UnityEngine.Debug.LogError("TODO"); } } // 0x23A65F8 0x23A6600
	}
}
