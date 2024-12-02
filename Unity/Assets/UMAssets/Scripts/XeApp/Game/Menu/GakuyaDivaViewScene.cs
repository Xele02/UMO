using mcrs;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GakuyaDivaViewScene : TransitionRoot
	{
		private GakuyaViewReturnButton m_returnButton; // 0x48
		private GakuyaViewReturnButton m_returnButtonL; // 0x4C
		private GakuyaViewReturnButton m_returnButtonR; // 0x50
		private bool m_reverse = true; // 0x54
		private DeviceOrientation m_deviceOrientation = DeviceOrientation.LandscapeLeft; // 0x58
		private bool m_isEntered; // 0x5C
		private bool m_isWaitLeaveCameraAnim; // 0x5D

		// RVA: 0xB708A0 Offset: 0xB708A0 VA: 0xB708A0 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DED24 Offset: 0x6DED24 VA: 0x6DED24
		//// RVA: 0xB708D0 Offset: 0xB708D0 VA: 0xB708D0
		private IEnumerator Co_LoadResource()
		{
			string bundleName; // 0x14
			XeSys.FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x20

			//0xB71890
			bundleName = "ly/081.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			bundleLoadCount = 0;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName, "GakuyaViewReturnButton");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB714B8
				instance.transform.SetParent(transform, false);
				m_returnButton = instance.GetComponentInChildren<GakuyaViewReturnButton>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName, "GakuyaViewReturnButtonL");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB71588
				instance.transform.SetParent(transform, false);
				m_returnButtonL = instance.GetComponentInChildren<GakuyaViewReturnButton>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName, "GakuyaViewReturnButtonR");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB71658
				instance.transform.SetParent(transform, false);
				m_returnButtonR = instance.GetComponentInChildren<GakuyaViewReturnButton>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			IsReady = true;
		}

		// RVA: 0xB7097C Offset: 0xB7097C VA: 0xB7097C Slot: 5
		protected override void Start()
		{
			base.Start();
			return;
		}

		// RVA: 0xB70984 Offset: 0xB70984 VA: 0xB70984
		private void Update()
		{
			if (!m_isEntered)
				return;
			UpdateUI(CheckDeviceOrientation());
		}

		// RVA: 0xB70B24 Offset: 0xB70B24 VA: 0xB70B24 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_deviceOrientation = DeviceOrientation.LandscapeLeft;
			HomeDivaViewCamera.Instance.Create();
			HomeDivaViewCamera.Instance.m_camera.ClearCameraRot();
			HomeDivaViewCamera.Instance.Enter();
			m_returnButton.OnClickReturnButtonCallback = OnClickReturnButton;
			m_returnButtonL.OnClickReturnButtonCallback = OnClickReturnButton;
			m_returnButtonR.OnClickReturnButtonCallback = OnClickReturnButton;
			GameManager.Instance.SetTouchEffectVisible(false);
		}

		// RVA: 0xB70D58 Offset: 0xB70D58 VA: 0xB70D58 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return HomeDivaViewCamera.Instance.IsEntered();
		}

		// RVA: 0xB70D8C Offset: 0xB70D8C VA: 0xB70D8C Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
			m_deviceOrientation = CheckDeviceOrientation();
			if (m_deviceOrientation == DeviceOrientation.Unknown || m_deviceOrientation > DeviceOrientation.LandscapeRight)
				m_deviceOrientation = DeviceOrientation.LandscapeLeft;
			UpdateUI(m_deviceOrientation);
		}

		// RVA: 0xB70DC8 Offset: 0xB70DC8 VA: 0xB70DC8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_returnButton.IsPlaying() && !m_returnButtonL.IsPlaying() && !m_returnButtonR.IsPlaying();
		}

		// RVA: 0xB70E74 Offset: 0xB70E74 VA: 0xB70E74 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
			HomeDivaViewCamera.Instance.InputOn();
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			m_isEntered = true;
		}

		// RVA: 0xB70F8C Offset: 0xB70F8C VA: 0xB70F8C Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_isEntered = false;
			m_returnButton.TryLeave();
			m_returnButtonL.TryLeave();
			m_returnButtonR.TryLeave();
			GameManager.Instance.SetTouchEffectVisible(true);
		}

		// RVA: 0xB710C4 Offset: 0xB710C4 VA: 0xB710C4 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_returnButton.IsPlaying() && !m_returnButtonL.IsPlaying() && !m_returnButtonR.IsPlaying() && !m_isWaitLeaveCameraAnim;
		}

		//// RVA: 0xB709B4 Offset: 0xB709B4 VA: 0xB709B4
		private DeviceOrientation CheckDeviceOrientation()
		{
			if(Screen.orientation == ScreenOrientation.LandscapeRight)
			{
				m_reverse = true;
			}
			else if(Screen.orientation == ScreenOrientation.LandscapeLeft)
			{
				m_reverse = false;
			}
			if(!m_reverse)
			{
				if(Screen.orientation >= ScreenOrientation.Portrait && Screen.orientation <= ScreenOrientation.LandscapeRight)
				{
					m_deviceOrientation = (DeviceOrientation)Screen.orientation;
				}
				return (DeviceOrientation)Screen.orientation;
			}
			else if(Screen.orientation == ScreenOrientation.Portrait)
			{
				m_deviceOrientation = DeviceOrientation.PortraitUpsideDown;
			}
			else if(Screen.orientation == ScreenOrientation.PortraitUpsideDown)
			{
				m_deviceOrientation = DeviceOrientation.Portrait;
			}
			else
			{
				if (Screen.orientation >= ScreenOrientation.Portrait && Screen.orientation <= ScreenOrientation.LandscapeRight)
				{
					m_deviceOrientation = (DeviceOrientation)Screen.orientation;
				}
				return (DeviceOrientation)Screen.orientation;
			}
			return m_deviceOrientation;
		}

		//// RVA: 0xB70A40 Offset: 0xB70A40 VA: 0xB70A40
		private void UpdateUI(DeviceOrientation orientation)
		{
			if(orientation >= DeviceOrientation.LandscapeLeft && orientation <= DeviceOrientation.LandscapeRight)
			{
				m_returnButton.TryEnter();
				m_returnButtonL.TryLeave();
				m_returnButtonR.TryLeave();
			}
			else if(orientation == DeviceOrientation.PortraitUpsideDown)
			{
				m_returnButtonR.TryEnter();
				m_returnButton.TryLeave();
				m_returnButtonL.TryLeave();
			}
			else if(orientation == DeviceOrientation.Portrait)
			{
				m_returnButtonL.TryEnter();
				m_returnButton.TryLeave();
				m_returnButtonR.TryLeave();
			}
		}

		//// RVA: 0xB71184 Offset: 0xB71184 VA: 0xB71184
		private void OnClickReturnButton()
		{
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			HomeDivaViewCamera.Instance.Leave();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
			MenuScene.Instance.Return(true);
			this.StartCoroutineWatched(Co_EixtCameraAnimWait());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DED9C Offset: 0x6DED9C VA: 0x6DED9C
		//// RVA: 0xB71344 Offset: 0xB71344 VA: 0xB71344
		private IEnumerator Co_EixtCameraAnimWait()
		{
			//0xB7172C
			m_isWaitLeaveCameraAnim = true;
			while (!HomeDivaViewCamera.Instance.IsFinished())
				yield return null;
			m_isWaitLeaveCameraAnim = false;
		}

		//// RVA: 0xB713F0 Offset: 0xB713F0 VA: 0xB713F0
		private void OnBackButton()
		{
			if (MenuScene.Instance.GetInputDisableCount() > 0)
				return;
			OnClickReturnButton();
		}
	}
}
