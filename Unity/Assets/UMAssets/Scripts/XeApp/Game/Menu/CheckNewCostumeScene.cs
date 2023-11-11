using System.Collections;
using System.Collections.Generic;
using System.Text;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CheckNewCostumeScene : TransitionRoot
	{
		private int m_diva_id = 1; // 0x48
		private int m_cos_id = 2; // 0x4C
		private bool m_model_loaded; // 0x50
		private SimpleDivaObject m_divaObject; // 0x54
		private DivaResource m_divaResource; // 0x58
		private StringBuilder m_bundleName = new StringBuilder(64); // 0x5C
		private StringBuilder m_assetName = new StringBuilder(64); // 0x60
		private List<DivaResource.MotionOverrideClipKeyResource> overrideClipList = new List<DivaResource.MotionOverrideClipKeyResource>(); // 0x64
		private MenuDivaManager m_menuDiva; // 0x68
		private Camera m_divaCamera = new Camera(); // 0x6C
		private CheckNewCostumeLayout m_layout; // 0x70
		private Vector3 m_final_camera_pos = Vector3.zero; // 0x74
		private Vector3 m_final_camera_lookat = Vector3.zero; // 0x80
		private Vector3 m_final_camera_pos_scale = Vector3.zero; // 0x8C
		private Vector3 m_final_camera_lookat_scale = Vector3.zero; // 0x98
		private List<Vector3> m_final_camera_offset; // 0xA4
		private Vector3 m_camera_anim_last_lookat = Vector3.zero; // 0xA8
		[SerializeField]
		private ScriptableObject m_CameraParam; // 0xB4
		private bool m_IsRady; // 0xB8
		private const float MoveCosTime = 1.2f;
		private GameObject DivaResourceObj; // 0xBC
		private SimpleDivaObject OriginalSimpleDiva; // 0xC0
		private bool m_isSettingEnd; // 0xC4

		// // RVA: 0x10B2AA4 Offset: 0x10B2AA4 VA: 0x10B2AA4
		private void InitializeFinishCameraDataSetting()
		{
			CostumeCameraParameter p = m_CameraParam as CostumeCameraParameter;
			m_final_camera_pos = p.m_final_camera_pos;
			m_final_camera_lookat = p.m_final_camera_lookat;
			m_final_camera_offset = p.m_final_camera_offset;
		}

		// RVA: 0x10B2B94 Offset: 0x10B2B94 VA: 0x10B2B94 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_menuDiva = MenuScene.Instance.divaManager;
			OriginalSimpleDiva = GetComponentInChildren<SimpleDivaObject>(true);
			DivaResourceObj = new GameObject("DivaResourceObject");
			DivaResourceObj.transform.SetParent(transform);
			m_divaResource = DivaResourceObj.AddComponent<DivaResource>();
			m_divaCamera = transform.Find("CheckNewCostumeCamera").GetComponent<Camera>();
			m_layout = transform.Find("root_ul_cos02_layout_root").GetComponent<CheckNewCostumeLayout>();
			InitializeFinishCameraDataSetting();
			if(SystemManager.isLongScreenDevice)
			{
				FlexibleCameraChanger fl = m_divaCamera.GetComponent<FlexibleCameraChanger>();
				fl.Initialize();
				fl.IsEnableFlexibleFov = false;
				m_divaCamera.fieldOfView = Mathf.CeilToInt(fl.GetDefaultFov(0) * MenuScene.GetLongScreenScale());
			}
			IsReady = true;
		}

		// RVA: 0x10B2FB0 Offset: 0x10B2FB0 VA: 0x10B2FB0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
			m_divaObject = Instantiate(OriginalSimpleDiva);
			m_isSettingEnd = false;
			AutoFadeFlag = false;
		}

		// RVA: 0x10B30D8 Offset: 0x10B30D8 VA: 0x10B30D8 Slot: 18
		protected override void OnPostSetCanvas()
		{
			GameManager.Instance.SetFPS(60);
			m_IsRady = false;
			if(Args != null && Args is CheckNewCostumeArgs)
			{
				m_diva_id = (Args as CheckNewCostumeArgs).diva_id;
				m_cos_id = (Args as CheckNewCostumeArgs).cos_id;
			}
			this.StartCoroutineWatched(Co_MainFlow());
		}

		// RVA: 0x10B3284 Offset: 0x10B3284 VA: 0x10B3284 Slot: 21
		protected override void OnOpenScene()
		{
			this.StartCoroutineWatched(Co_FadeWait());
		}

		// RVA: 0x10B3334 Offset: 0x10B3334 VA: 0x10B3334 Slot: 22
		protected override bool IsEndOpenScene()
		{
			base.IsEndOpenScene();
			return m_isSettingEnd;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CBDAC Offset: 0x6CBDAC VA: 0x6CBDAC
		// // RVA: 0x10B32A8 Offset: 0x10B32A8 VA: 0x10B32A8
		private IEnumerator Co_FadeWait()
		{
			int hash;

			//0x10B42FC
			m_isSettingEnd = false;
			CrossFadeIdel("simple_anime_loop_01");
			yield return null;
			hash = Animator.StringToHash("body.sub_simple.simple_anime_loop_01");
			yield return null;
			while(m_divaObject.GetBodyHash() != hash)
				yield return null;
			GameManager.Instance.NowLoading.Hide();
			GameManager.Instance.fullscreenFader.Fade(0.1f, 0);
			yield return null;
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			m_isSettingEnd = true;
		}

		// RVA: 0x10B3370 Offset: 0x10B3370 VA: 0x10B3370 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_IsRady;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CBE24 Offset: 0x6CBE24 VA: 0x6CBE24
		// // RVA: 0x10B31F8 Offset: 0x10B31F8 VA: 0x10B31F8
		private IEnumerator Co_MainFlow()
		{
			//0x10B5548
			yield return Resources.UnloadUnusedAssets();
			yield return Co.R(Co_LoadDivaResource());
			Initialize();
			while(!m_layout.IsResourceLoaded())
				yield return null;
			yield return Co.R(Co_LoadingResource());
			SwitchToNormalCamera();
			m_layout.Show();
			yield return null;
			while(m_layout.IsPlaying())
				yield return null;
			m_divaCamera.transform.localPosition = m_final_camera_pos_scale;
			m_divaCamera.transform.LookAt(m_final_camera_lookat_scale);
			m_IsRady = true;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CBE9C Offset: 0x6CBE9C VA: 0x6CBE9C
		// // RVA: 0x10B3398 Offset: 0x10B3398 VA: 0x10B3398
		private IEnumerator Co_LoadDivaResource()
		{
			int divaId; // 0x14
			int bodyId; // 0x18
			AssetBundleLoadAllAssetOperationBase operationDiva; // 0x1C

			//0x10B4698
			m_model_loaded = false;
			if(m_divaResource != null)
			{
				Release();
				yield return null;
				yield return Resources.UnloadUnusedAssets();
			}
			//LAB_010b4838
			divaId = m_diva_id;
			m_divaResource.LoadBasicResource(divaId, m_cos_id, 0);
			m_divaResource.LoadSimpleResource(divaId, m_cos_id, 0);
			yield return new WaitUntil(() =>
			{
				//0x10B42C0
				return m_divaResource.IsSimpleLoaded;
			});
			m_divaObject.Initialize(m_divaResource, divaId, false);
			m_divaObject.setAdjuster();
			m_divaObject.SetEnableEffect(true, true);
			bodyId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(divaId).IDDHKOEFJFB_BodyId;
			m_bundleName.SetFormat("dv/bt/{0:D3}.xab", bodyId);
			operationDiva = AssetBundleManager.LoadAllAssetAsync(m_bundleName.ToString());
			yield return operationDiva;
			overrideClipList.Add(DivaResource.MotionOverrideClipKeyResource.Set("type_{0:D3}_costume_start_{1}", "diva_cmn_costume_start", bodyId, operationDiva, m_assetName));
			AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
			m_bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
			operationDiva = AssetBundleManager.LoadAllAssetAsync(m_bundleName.ToString());
			yield return operationDiva;
            DivaResource.MotionOverrideClipKeyResource res = DivaResource.MotionOverrideClipKeyResource.Set("diva_{0:D3}_menu_idle_{1}", "diva_cmn_simple_idle", divaId, operationDiva, m_assetName);
			m_assetName.SetFormat("diva_{0:D3}_costume_pose_loop_{1}", divaId, "mouth");
			string s = "diva_cmn_simple_idle" + "_mouth";
			res.mouth.name = s;
			res.mouth.clip = operationDiva.GetAsset<AnimationClip>(m_assetName.ToString());
			overrideClipList.Add(res);
			overrideClipList.Add(DivaResource.MotionOverrideClipKeyResource.Set("diva_{0:D3}_costume_pose_loop_{1}", "diva_cmn_simple_loop_anime01", divaId, operationDiva, m_assetName));
			m_divaObject.OverrideAnimations(overrideClipList);
			AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
			m_model_loaded = true;
        }

		// // RVA: 0x10B3444 Offset: 0x10B3444 VA: 0x10B3444
		public void CrossFadeIdel(string stateName)
		{
			m_divaObject.CrossFadeIdle(stateName, 0.5f);
		}

		// // RVA: 0x10B347C Offset: 0x10B347C VA: 0x10B347C
		private void Initialize()
		{
			m_menuDiva.transform.Find("DivaCamera").GetComponent<Camera>().enabled = false;
			m_divaCamera.transform.SetParent(m_menuDiva.transform, false);
			m_divaObject.transform.SetParent(m_menuDiva.transform, false);
			m_divaCamera.enabled = true;
			m_divaCamera.clearFlags = CameraClearFlags.SolidColor;
			m_divaCamera.transform.localPosition = new Vector3(0, -10, 0);
			m_layout.Init(m_diva_id, m_cos_id, 0);
			m_layout.GetBtn().ClearOnClickCallback();
			m_layout.GetBtn().AddOnClickCallback(() =>
			{
				//0x10B42EC
				OnClickOkBtn();
			});
			InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CBF14 Offset: 0x6CBF14 VA: 0x6CBF14
		// // RVA: 0x10B37E8 Offset: 0x10B37E8 VA: 0x10B37E8
		private IEnumerator Co_LoadingResource()
		{
			int hash;

			//0x10B5128
			yield return new WaitUntil(() =>
			{
				//0x10B42F0
				return m_model_loaded;
			});
			m_final_camera_pos_scale = m_final_camera_pos + m_final_camera_offset[m_diva_id - 1];
			m_final_camera_lookat_scale = m_final_camera_lookat + m_final_camera_offset[m_diva_id - 1];
			m_divaObject.Play("simple_idle");
			m_divaObject.UnlockBoneSpring(true, 0);
			yield return null;
			hash = Animator.StringToHash("body.sub_simple.simple_idle");
			while(m_divaObject.GetBodyHash() != hash)
				yield return null;
			PrepareAnimation();
		}

		// // RVA: 0x10B3894 Offset: 0x10B3894 VA: 0x10B3894
		private void PrepareAnimation()
		{
			m_divaObject.SetEnableRenderer(true);
			m_divaCamera.enabled = true;
			m_divaCamera.transform.localRotation = new Quaternion(0, 180, 0, 0);
		}

		// // RVA: 0x10B3970 Offset: 0x10B3970 VA: 0x10B3970
		// private void AdDivaDetails() { }

		// // RVA: 0x10B39C8 Offset: 0x10B39C8 VA: 0x10B39C8
		public void OnClickOkBtn()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			UnlockFadeManager.Release();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			MenuScene.Instance.Return();
		}

		// // RVA: 0x10B3B7C Offset: 0x10B3B7C VA: 0x10B3B7C
		private void OnBackButton()
		{
			if(MenuScene.Instance.GetInputDisableCount() > 0)
				return;
			OnClickOkBtn();
		}

		// // RVA: 0x10B3C2C Offset: 0x10B3C2C VA: 0x10B3C2C
		private void SwitchToNormalCamera()
		{
			m_divaCamera.targetTexture = null;
			m_divaCamera.clearFlags = CameraClearFlags.Nothing;
		}

		// // RVA: 0x10B3C84 Offset: 0x10B3C84 VA: 0x10B3C84 Slot: 14
		protected override void OnDestoryScene()
		{
			m_menuDiva.transform.Find("DivaCamera").GetComponent<Camera>().enabled = true;
			m_divaCamera.transform.SetParent(transform, false);
			m_divaCamera.transform.SetParent(transform, false);
			m_divaCamera.enabled = false;
			Release();
			Destroy(m_divaObject.gameObject);
			m_divaObject = null;
			GameManager.Instance.SetFPS(30);
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
		}

		// // RVA: 0x10B3F80 Offset: 0x10B3F80 VA: 0x10B3F80
		public void Release()
		{
			for(int i = 0; i < overrideClipList.Count; i++)
			{
				overrideClipList[i].Release();
			}
			overrideClipList.Clear();
			m_divaObject.ReleaseMediator();
			m_divaObject.Release();
			m_divaResource.ReleaseAll();
		}
	}
}
