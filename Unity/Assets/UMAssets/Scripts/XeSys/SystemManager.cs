using UnityEngine;
using XeSys.File;
using System;
using XeSys.Gfx;
using XeApp;

namespace XeSys
{
	public class SystemManager : MonoBehaviour
	{
		public enum OverPermissionAspectResult
		{
			None = 0,
			HdivV = 1,
			VdivH = 2,
		}

		[SerializeField]
		private DebugTextRenderer debugTextRendererPrefab; // 0xC
		[SerializeField]
		private DebugFPS debugFpsPrefab; // 0x10
		[SerializeField]
		private InputManager inputManagerPrefab; // 0x14
		[SerializeField]
		private CriFileRequestManager criFileRequestManagerPrefab; // 0x18

		private static SystemManager mInstance; // 0x0
		private GameObject mSystemGroupObject; // 0x1C
		private const float permissionHdivVAspectRatio = 1.782778f;
		private const float permissionVdivHAspectRatio = 0.755f;
		public static bool isLongScreenDevice; // 0x64
		public static Vector2 longScreenBaseSize; // 0x68
		public static Vector2 longScreenReferenceResolution; // 0x70
		public static Vector2 longScreenSizeWithSafeArea; // 0x78
		public static Rect rawSafeAreaRect; // 0x80
		public static Rect rawScreenAreaRect; // 0x90
		public static int width_withSafeArea; // 0xAC
		public static int height_withSafeArea; // 0xB0
		public static Rect rawAppScreenRect; // 0xB4
		private const string forceWideScreen_prefs_key = "forceWideScreen";
		private static bool isForceWideScreen; // 0xC4

		public static SystemManager Instance { get { return mInstance; } } // get_Instance 0x239B690
		public static Vector2 NativeScreenSize { get; set; } // 0x4
		public static Vector2 ScreenSize { get; set; } // 0xC
		public static Vector2 ScreenHalfSize { get; set; } // 0x14
		public static float ScreenAspect { get; set; } // 0x1C
		public static Vector2 BaseScreenSize { get; set; } // 0x20
		public static Vector2 BaseScreenHalfSize { get; set; } // 0x28
		public static float BaseAspect { get; set; } // 0x30
		public static Vector2 AdjustScale { get; set; } // 0x34
		public static Vector2 AdjustInvScale { get; set; } // 0x3C
		public static float AdjustScaleValue { get; set; } // 0x44
		public static float AdjustScaleInvValue { get; set; } // 0x48
		public static long gcMinUseMemorySize { get; set; } // 0x50
		public static long gcMaxUseMemorySize { get; set; } // 0x58
		private static float gcCheckTime { get; set; } // 0x60
		private Action DoUpdate { get; set; } // 0x20
		public static Vector2 safeAreaScale { get; set; } // 0xA0
		public static bool CanWideScreenMenu { get; set; } // 0xA8
		public static bool HasSafeArea { get { return rawSafeAreaRect.width > 0; } } // get_HasSafeArea 0x23A50A4 
		public static bool IsForceWideScreen { get { return isForceWideScreen; } } // get_IsForceWideScreen 0x23A5150

		// // RVA: 0x23A51DC Offset: 0x23A51DC VA: 0x23A51DC
		public static void SetForceWideScreen(bool isOn)
		{
			TodoLogger.Log(0, "Fix isForceWideScreen");
			isForceWideScreen = isOn;
			PlayerPrefs.SetInt("forceWideScreen", isOn ? 1 : 0);
			PlayerPrefs.Save();
		}

		// // RVA: 0x23A524C Offset: 0x23A524C VA: 0x23A524C
		public static void Create(GameObject prefab)
		{
			if(mInstance != null)
				return;
			if(prefab == null)
				return;
			//UnityEngine.Debug.unityLogger.logEnabled = false;
			GameObject res = Instantiate(prefab);
			res.name = "SystemManager";
		}

		// // RVA: 0x23A54A0 Offset: 0x23A54A0 VA: 0x23A54A0
		private void Awake()
		{
			DontDestroyOnLoad(this);
			Application.runInBackground = true;
			Application.targetFrameRate = 60;
			mSystemGroupObject = new GameObject("XeSys");
			DontDestroyOnLoad(mSystemGroupObject);
			AddToSystemGroup(GameObject.Find(name));
			ResetGcMemoryProfile();
			mInstance = this;
			DoUpdate = null;

			int sWidth = Screen.width;
			int sHeight = Screen.height;
			if(sWidth < sHeight)
				NativeScreenSize = new Vector2(sHeight, sWidth);
			else
				NativeScreenSize = new Vector2(sWidth, sHeight);
			rawSafeAreaRect = new Rect(Vector2.zero, NativeScreenSize);
			rawScreenAreaRect = XeSafeArea.GetScreenArea();
			BaseScreenSize = new Vector2(1184, 792);

			int forceWS = PlayerPrefs.GetInt("forceWideScreen", 1);
			if(forceWS != 1)
				forceWS = 0;
			
			AddToSystemGroup(InputManager.Create(inputManagerPrefab));
			AddToSystemGroup(CriFileRequestManager.HEGEKFMJNCC(criFileRequestManagerPrefab));
			AddToSystemGroup(DebugTextRenderer.Create(debugTextRendererPrefab));
			AddToSystemGroup(DebugFPS.Create(debugFpsPrefab));
			FileLoader.Create();
			RenderManager.Create("RenderManager");
			ResourcesManager.Instance.Initialize();
		}

		// // RVA: 0x23A5930 Offset: 0x23A5930 VA: 0x23A5930
		private void ResetGcMemoryProfile()
		{
			gcCheckTime = 0;
			gcMinUseMemorySize = 0x540be3ff20000000; // ??
			gcMaxUseMemorySize = 0;
		}

		// // RVA: 0x23A61F8 Offset: 0x23A61F8 VA: 0x23A61F8
		private void Update()
		{
			gcCheckTime += Time.deltaTime;
			if(gcCheckTime >= 3)
			{
				ResetGcMemoryProfile();
			}
			long totalMem = GC.GetTotalMemory(false);
			if(totalMem > gcMaxUseMemorySize)
				gcMaxUseMemorySize = totalMem;
			if(gcMinUseMemorySize == 0 || totalMem < gcMinUseMemorySize)
				gcMinUseMemorySize = totalMem;
			UpdateScreenSize();
			FileLoader.Instance.Update();
			if(DoUpdate != null)
				DoUpdate();
		}

		// // RVA: 0x23A6430 Offset: 0x23A6430 VA: 0x23A6430
		private void OnDestroy()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x23A59C8 Offset: 0x23A59C8 VA: 0x23A59C8
		public void UpdateScreenSize()
		{
			BaseScreenHalfSize = BaseScreenSize * 0.5f;
			BaseAspect = BaseScreenSize.x / BaseScreenSize.y;
			// ? Weird base aspect calc. Round to 2 digit ?
			if(CheckOverPermissionAspectRatio() == OverPermissionAspectResult.None)
			{
				ScreenSize = new Vector2(1184, 792);
			}
			else
			{
				ScreenSize = new Vector2(Screen.width, Screen.height);
			}
			ScreenHalfSize = ScreenSize * 0.5f;
			ScreenAspect = ScreenSize.x / ScreenSize.y;
			// ? Like BaseAspect
			AdjustScale = ScreenSize / BaseScreenSize;
			AdjustInvScale = Vector2.one / AdjustScale;
			if(ScreenAspect < BaseAspect)
			{
				AppEnv.letterBoxDirection = AppEnv.LetterBoxDirection.TopBottom;
				AdjustScaleValue = AdjustScale.y;
			}
			else
			{
				AppEnv.letterBoxDirection = AppEnv.LetterBoxDirection.LeftRight;
				AdjustScaleValue = AdjustScale.x;
			}
			AdjustScaleInvValue = 1.0f / AdjustScaleValue;
			CanWideScreenMenu = false;
			if(CheckOverPermissionAspectRatio() == OverPermissionAspectResult.HdivV)
			{
				if(IsForceWideScreen)
				{
					isLongScreenDevice = true;
					longScreenBaseSize = new Vector2(BaseScreenSize.x, BaseScreenSize.x * 9.0f * 0.0625f);
				}
				else
				{
					longScreenBaseSize = BaseScreenSize;
				}
				CanWideScreenMenu = true;
			}
			else
			{
				longScreenBaseSize = BaseScreenSize;
			}
		}

		// // RVA: 0x239B71C Offset: 0x239B71C VA: 0x239B71C
		public void AddToSystemGroup(GameObject go)
		{
			if(go == null)
				return;
			if(mSystemGroupObject == null)
				return;
			go.transform.SetParent(mSystemGroupObject.transform);
		}

		// // RVA: 0x23A64D0 Offset: 0x23A64D0 VA: 0x23A64D0
		// public static bool IsExistGameObject(string name) { }

		// // RVA: 0x23A6434 Offset: 0x23A6434 VA: 0x23A6434
		public SystemManager.OverPermissionAspectResult CheckOverPermissionAspectRatio()
		{
			if(Screen.width * 1.0f / Screen.height < 1.782778f)
			{
				if(Screen.height * 1.0f / Screen.width < 0.755f)
					return OverPermissionAspectResult.None;
				return OverPermissionAspectResult.VdivH;
			}
			return OverPermissionAspectResult.HdivV;
		}
	}
}
