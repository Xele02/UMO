using System;
using UnityEngine;
public class AndroidUtilsCallback : AndroidJavaProxy
{
	public AndroidUtilsCallback() : base("jp.co.xeen.xeapp.FileLoadCallback") { }
	public Action<byte[]> onFileRead;
	public Action<string> onFileError;

	public void onSuccess(AndroidJavaObject bytesObj) {
		Debug.Log("Unity callbacks: Receive Data ");
		AndroidJavaObject bufferObject = bytesObj.Get<AndroidJavaObject>("Buffer");
		byte[] data = AndroidJNIHelper.ConvertFromJNIArray<byte[]>(bufferObject.GetRawObject());
		Debug.Log("ENTER callback onSuccess: " + data.Length);
		if(onFileRead != null)
			onFileRead(data);
	}
	public void onError(string errorMessage)
	{
		Debug.Log("ENTER callback onError: " + errorMessage);
		if(onFileError != null)
			onFileError(errorMessage);
	}
}

namespace UdonLib
{
	public enum AndroidPermission
	{
		READ_EXTERNAL_STORAGE = 0,
		WRITE_EXTERNAL_STORAGE = 1,
		CAMERA = 2,
	}

	public class AndroidUtils
	{
		private const int VERSION_CODE_K = 19;
		private const int VERSION_CODE_M = 23;
		private const int PERMISSION_GRANTED = 0;
		private const long MEGA_BYTES = 1048576;
		private const long KILO_BYTES = 1024;
		private static int m_apiLevel; // 0x0
		private static int m_targetSdkVersion; // 0x4

		// public static long GetAvailableStorageMB { get; }
		public static long GetAvailableStorageKB { get
		{
#if UNITY_EDITOR
			return 999999999;
#endif
			AndroidJavaObject c = new AndroidJavaObject("android.os.StatFs", new object[1] { Application.temporaryCachePath });
			long l = c.Call<long>("getAvailableBlocksLong", Array.Empty<object>());
			long l2 = c.Call<long>("getBlockSizeLong", Array.Empty<object>());
			return l * l2; //?
		} } //0xE09C54
		public static int ApiLevel { get
		{
			if(m_apiLevel == 0)
			{
				AndroidJavaClass c = new AndroidJavaClass("android.os.Build$VERSION");
				m_apiLevel = c.GetStatic<int>("SDK_INT");
				c.Dispose();
			}
			return m_apiLevel;
		} } // 0xE09E30

		// RVA: 0xE08DEC Offset: 0xE08DEC VA: 0xE08DEC
		public static void PlayShutterSound()
		{
			AndroidJavaClass c = new AndroidJavaClass("jp.co.xeen.xeapp.UdonUtils");
			c.CallStatic("playSystemShutterSound", Array.Empty<object>());
		}

		// // RVA: 0xE08FA0 Offset: 0xE08FA0 VA: 0xE08FA0
		// public static bool OnTwitter(string path, string message) { }

		// // RVA: 0xE0922C Offset: 0xE0922C VA: 0xE0922C
		// public static bool OnLINE(string path, string message) { }

		// RVA: 0xE094B8 Offset: 0xE094B8 VA: 0xE094B8
		public static bool OnShare(string path, string message, string shareTitle)
		{
			//AndroidJavaClass c = new AndroidJavaClass("jp.co.xeen.xeapp.PostSNS");
			//return c.CallStatic<bool>("share", new object[3] { path, message, shareTitle });
			return OnShare2(path, message, shareTitle);
		}

		public static bool OnShareImage(string path, string message, string shareTitle)
		{
			return OnShare2(path, message, shareTitle, "image/jpg");
		}

		// // RVA: 0xE09798 Offset: 0xE09798 VA: 0xE09798
		public static bool OnShare2(string path, string message, string shareTitle, string mimeType = "application/octet-stream") 
		{ 
#if UNITY_ANDROID
			string className = "android.content.Intent";
			using(AndroidJavaClass IntentClass = new AndroidJavaClass(className))
			using(AndroidJavaObject sendIntent = new AndroidJavaObject(className))
			{
				sendIntent.Call<AndroidJavaObject>("setAction", IntentClass.GetStatic<string>("ACTION_SEND"));
				sendIntent.Call<AndroidJavaObject>("setType", mimeType);
				using (AndroidJavaClass versionClazz = new AndroidJavaClass("android.os.Build$VERSION"))
				{
					int apiLevel = versionClazz.GetStatic<int>("SDK_INT");
					using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
					using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						AndroidJavaObject uriObject;
						if(24 <= apiLevel) {
							using(AndroidJavaObject context = currentActivity.Call<AndroidJavaObject> ("getApplicationContext"))
							using(AndroidJavaClass fileProvider = new AndroidJavaClass("androidx.core.content.FileProvider"))
							using(AndroidJavaObject file = new AndroidJavaObject ("java.io.File", path))
							uriObject = fileProvider.CallStatic<AndroidJavaObject>("getUriForFile", context, Application.identifier + ".fileprovider", file);
						}
						else
						{
							using (AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri"))
							uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + path);
						}
						using (sendIntent.Call<AndroidJavaObject>("putExtra", IntentClass.GetStatic<string>("EXTRA_STREAM"), uriObject))
						{ }
						AndroidJavaObject jChooser = IntentClass.CallStatic<AndroidJavaObject>("createChooser", sendIntent, shareTitle);
						currentActivity.Call("startActivity", jChooser);
						uriObject.Dispose();
					}
				}
			}
#endif
			return true;
		}

		public static AndroidUtilsCallback callbacks = new AndroidUtilsCallback();

		public static bool OpenFile(string message, Action<byte[]> onFileRead, Action<string> onFileError, string mimeType = "application/octet-stream")
		{
#if UNITY_ANDROID
			string className = "android.content.Intent";
			using(AndroidJavaClass IntentClass = new AndroidJavaClass(className))
			using(AndroidJavaObject sendIntent = new AndroidJavaObject(className))
			{
				sendIntent.Call<AndroidJavaObject>("setAction", IntentClass.GetStatic<string>("ACTION_GET_CONTENT"));
				sendIntent.Call<AndroidJavaObject>("setType", mimeType);
				sendIntent.Call<AndroidJavaObject>("putExtra", IntentClass.GetStatic<string>("EXTRA_ALLOW_MULTIPLE"), false);
				sendIntent.Call<AndroidJavaObject>("putExtra", IntentClass.GetStatic<string>("EXTRA_LOCAL_ONLY"), true);
				sendIntent.Call<AndroidJavaObject>("putExtra", IntentClass.GetStatic<string>("CATEGORY_OPENABLE"), true);
				using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					callbacks.onFileRead = onFileRead;
					callbacks.onFileError = onFileError;
					currentActivity.Call("setLoadCallbacks", callbacks);
					AndroidJavaObject jChooser = IntentClass.CallStatic<AndroidJavaObject>("createChooser", sendIntent, "");
					currentActivity.Call("startActivityForResult", jChooser, 0);
				}
			}
#endif
			return true;
		}

		// // RVA: 0xE09A78 Offset: 0xE09A78 VA: 0xE09A78
		// public static long get_GetAvailableStorageMB() { }

		// RVA: 0xE0A09C Offset: 0xE0A09C VA: 0xE0A09C
		public static bool CheckSelfPermission(AndroidPermission permission)
		{
			return CheckSelfPermission("android.permission." + permission.ToString());
		}

		// RVA: 0xE0A1A8 Offset: 0xE0A1A8 VA: 0xE0A1A8
		public static bool CheckSelfPermission(string permission)
		{
#if UNITY_EDITOR
			return true;
#endif
			bool result = false;
			if(ApiLevel < 23)
			{
				processActivity((AndroidJavaObject activity) =>
				{
					//0xE0B600
					AndroidJavaObject o = activity.Call<AndroidJavaObject>("getPackageManager");
					int a = o.Call<int>("checkPermission", new object[2] { permission, Application.identifier });
					result = a == 0;
					o.Dispose();
				});
			}
			else
			{
				processActivity((AndroidJavaObject activity) =>
				{
					//0xE0B4E4
					result = activity.Call<int>("checkSelfPermission", new object[1] { permission }) == 0;
				});
			}
			return result;
		}

		// // RVA: 0xE0A340 Offset: 0xE0A340 VA: 0xE0A340
		private static void processActivity(Action<AndroidJavaObject> func)
		{
			AndroidJavaClass c = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject o = c.GetStatic<AndroidJavaObject>("currentActivity");
			func(o);
			o.Dispose();
			c.Dispose();
		}

		// RVA: 0xE0A600 Offset: 0xE0A600 VA: 0xE0A600
		public static bool RedirectSystemSettings()
		{
#if !UNITY_EDITOR			
			AndroidJavaClass c = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject o = c.GetStatic<AndroidJavaObject>("currentActivity");
			string packageName = o.Call<string>("getPackageName", Array.Empty<object>());
			AndroidJavaClass c2 = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject o2 = c2.CallStatic<AndroidJavaObject>("fromParts", new object[3] { "package", packageName, null });
			AndroidJavaObject o3 = new AndroidJavaObject("android.content.Intent", new object[2] { "android.settings.APPLICATION_DETAILS_SETTINGS", o2 });
			o3.Call<AndroidJavaObject>("addCategory", new object[1] { "android.intent.category.DEFAULT" });
			o3.Call<AndroidJavaObject>("setFlags", new object[1] { 0x10000000 });
			o.Call("startActivity", new object[1] { o3 });
			o3.Dispose();
			o2.Dispose();
			c2.Dispose();
			o.Dispose();
			c.Dispose();
#endif
			return true;
		}

		// // RVA: 0xE0B31C Offset: 0xE0B31C VA: 0xE0B31C
		// RVA: 0x1306D94 Offset: 0x1306D94 VA: 0x1306D94
		public static bool CheckCameraHardware()
		{
#if UNITY_EDITOR
			return true;
#endif
			return new AndroidJavaClass("jp.co.xeen.xeapp.UdonUtils").CallStatic<bool>("checkCameraHardware");
		}
	}
}
