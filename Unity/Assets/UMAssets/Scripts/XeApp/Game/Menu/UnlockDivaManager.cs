using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;
using XeApp.Game.Common;
using mcrs;
using XeApp.Game.Tutorial;
using XeSys;
using UnityEngine.Experimental.Rendering;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class UnlockDivaManager : MonoBehaviour
	{
		private class EffectControll
		{
			public GameObject obj; // 0x8
			public Animator anim; // 0xC

			// // RVA: 0x1263F34 Offset: 0x1263F34 VA: 0x1263F34
			public void Init()
			{
				obj.SetActive(false);
				anim.enabled = false;
			}
		}

		[SerializeField]
		private Vector3 m_camera_pos = new Vector3(0, 12, 30); // 0xC
		[SerializeField]
		private Vector3 m_camera_default_target_pos = new Vector3(0, 12, 0); // 0x18
		[SerializeField]
		private Vector3 m_camera_final_target_pos = new Vector3(-5, 12, 0); // 0x24
		[SerializeField]
		private float DIVA_MOVE_TIME = 0.3f; // 0x30
		[SerializeField]
		private List<float> m_diva_target_pos_y = new List<float>() { 12, 12, 12, 12, 11, 12, 12, 12, 14, 12 }; // 0x34
		private const int BasaraId = 9;
		private MenuDivaManager _menuDivaManager; // 0x38
		private Vector3 _diva_camera_pos; // 0x3C
		private Quaternion _diva_camera_rot; // 0x48
		private Camera _divaCamera; // 0x58
		private UnlockDivaControl _divaControl = new UnlockDivaControl(); // 0x5C
		private UnlockDivaLogo _logo; // 0x60
		private UnlockDivaLogo _logo2; // 0x64
		private UnlockDivaInfo _info; // 0x68
		private EffectControll _frontEffect; // 0x6C
		private EffectControll _basaraEffect; // 0x70
		private EffectControll _backEffect; // 0x74
		private int _divaId; // 0x78
		public UnityAction PushOkButtonHandler; // 0x7C
		private float _time; // 0x80

		public bool IsLoadedLayout { get; private set; } // 0x84
		public bool IsLoaded3dResource { get; private set; } // 0x85
		// public int DivaId { get; } 0x126011C

		// RVA: 0x1260124 Offset: 0x1260124 VA: 0x1260124
		public void StartDirection()
		{
			_logo.Wait();
			_logo2.Wait();
			_info.Init(_divaId);
			_frontEffect.obj.transform.SetParent(_menuDivaManager.transform, false);
			_basaraEffect.obj.transform.SetParent(_menuDivaManager.transform, false);
			_backEffect.obj.transform.SetParent(_menuDivaManager.transform, false);
			_diva_camera_pos = _divaCamera.transform.localPosition;
			_diva_camera_rot = _divaCamera.transform.localRotation;
			_menuDivaManager.BeginControl(_divaControl);
			this.StartCoroutineWatched(DirectionCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x731F4C Offset: 0x731F4C VA: 0x731F4C
		// // RVA: 0x1260404 Offset: 0x1260404 VA: 0x1260404
		private IEnumerator DirectionCoroutine()
		{
			LayoutLogoCutin fadeEffect;

			//0x1261DC0
			while(UnlockFadeManager.Instance == null || !UnlockFadeManager.Instance.IsLoaded())
				yield return null;
			fadeEffect = UnlockFadeManager.Instance.GetEffect();
			while(!fadeEffect.IsEntered())
				yield return null;
			fadeEffect.Leave();
			m_camera_default_target_pos.y = m_diva_target_pos_y[_divaId - 1];
			m_camera_final_target_pos.y = m_diva_target_pos_y[_divaId - 1];
			_divaCamera.transform.LookAt(m_camera_default_target_pos);
			FlexibleFovProcess();
			_menuDivaManager.SetPosition(Vector3.zero);
			yield return null;
			_menuDivaManager.SetActive(true, true);
			while(fadeEffect.IsPlaying())
				yield return null;
			SoundManager.Instance.voGreeting.EntrySheet();
			SoundManager.Instance.voGreeting.Play(_divaId, 0);
			_divaControl.StartAnim();
			GameManager.Instance.SetFPS(60);
			_backEffect.obj.SetActive(true);
			_backEffect.anim.enabled = true;
			_backEffect.anim.Play("get_dv_start_back", 0);
			while(!_divaControl.IsFiredStartTelop() && !_divaControl.IsMatchAnimStep(MenuDivaObject.eUnlockDivaAnimStep.Loop))
				yield return null;
			if(_divaId == 9)
			{
				_basaraEffect.anim.enabled = true;
				_basaraEffect.obj.SetActive(true);
			}
			else
			{
				_frontEffect.anim.enabled = true;
				_frontEffect.obj.SetActive(true);
			}
			_backEffect.anim.Play("get_dv_back", 0);
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_003);
			while(_divaControl.GetNormalizedTime() < 1)
				yield return null;
			if(_divaId == 9)
				_logo2.Enter();
			else
				_logo.Enter();
			_info.Enter();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_003);
			_info.GetBtn().IsInputOff = true;
			while(true)
			{
				_time += Time.deltaTime;
				float f = Mathf.Clamp01(_time / DIVA_MOVE_TIME);
				_divaCamera.transform.localPosition = Vector3.Lerp(m_camera_pos, _diva_camera_pos, f);
				_divaCamera.transform.LookAt(Vector3.Lerp(m_camera_default_target_pos, m_camera_final_target_pos, f));
				if(f >= 1)
					break;
				yield return null;
			}
			_divaCamera.transform.localPosition = _diva_camera_pos;
			_divaCamera.transform.LookAt(m_camera_final_target_pos);
			yield return Co.R(Co_OpenPopupGetDecoCostumeTorso());
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			if(!GameManager.Instance.IsTutorial)
			{
				MenuScene.Instance.InputDisable();
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCodition));
				MenuScene.Instance.InputEnable();
			}
			//LAB_012622d0
			_info.GetBtn().IsInputOff = false;
		}

		// // RVA: 0x12604B0 Offset: 0x12604B0 VA: 0x12604B0
		private bool CheckTutorialCodition(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition34;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x731FC4 Offset: 0x731FC4 VA: 0x731FC4
		// // RVA: 0x1260564 Offset: 0x1260564 VA: 0x1260564
		private IEnumerator Co_OpenPopupGetDecoCostumeTorso()
		{
			//0x126198C
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(_divaId, 1);
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.JAHFLLONDCN(cos.JPIDIENBGKH_CostumeId, 0) && HNDLICBDEMI.AFGKIJMPNNN_IsDecoEnabled() && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture))
			{
				MenuScene.Instance.InputDisable();
				yield return Co.R(MenuScene.Instance.ShowGetDecoItemWindow(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso, cos.JPIDIENBGKH_CostumeId)));
				MenuScene.Instance.InputEnable();
			}
		}

		// RVA: 0x1260610 Offset: 0x1260610 VA: 0x1260610
		public void InitializeLayoutResource()
		{
			this.StartCoroutineWatched(InitializeLayoutResourceCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73203C Offset: 0x73203C VA: 0x73203C
		// // RVA: 0x1260634 Offset: 0x1260634 VA: 0x1260634
		private IEnumerator InitializeLayoutResourceCoroutine()
		{
			int loadCount; // 0x14
			AssetBundleLoadLayoutOperationBase layOp; // 0x18

			//0x1262CE0
			IsLoadedLayout = false;
			loadCount = 0;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/084.xab", "root_ul_chara_logo_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
			{
				//0x1261388
				_logo = inst.GetComponent<UnlockDivaLogo>();
				inst.transform.SetParent(transform, false);
			}));
			loadCount++;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/084.xab", "root_ul_chara_logo_02_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
			{
				//0x1261470
				_logo2 = inst.GetComponent<UnlockDivaLogo>();
				inst.transform.SetParent(transform, false);
			}));
			loadCount++;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/084.xab", "root_ul_chara_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
			{
				//0x1261558
				_info = inst.GetComponent<UnlockDivaInfo>();
				inst.transform.SetParent(transform, false);
			}));
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/084.xab", false);
			}
			_info.GetBtn().AddOnClickCallback(OnPushOkButton);
			IsLoadedLayout = true;
		}

		// RVA: 0x12606E0 Offset: 0x12606E0 VA: 0x12606E0
		public void InitializeResource(int divaId)
		{
			this.StartCoroutineWatched(InitializeResourceCoroutine(divaId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7320B4 Offset: 0x7320B4 VA: 0x7320B4
		// // RVA: 0x1260704 Offset: 0x1260704 VA: 0x1260704
		private IEnumerator InitializeResourceCoroutine(int divaId)
		{
			int loadCount; // 0x18
			AssetBundleLoadAssetOperation op; // 0x1C

			//0x1263324
			IsLoaded3dResource = false;
			_divaId = divaId;
			if(MenuScene.Instance != null)
			{
				_menuDivaManager = MenuScene.Instance.divaManager;
				_divaCamera = MenuScene.Instance.divaManager.transform.Find("DivaCamera").GetComponent<Camera>();
			}
			if(_menuDivaManager == null)
			{
				ResourcesManager.Instance.Load("Menu/Prefab/3dModel/DivaCamera", (FileResultObject fo) =>
				{
					//0x1261640
					_divaCamera = (Instantiate(fo.unityObject) as GameObject).GetComponent<Camera>();
					_divaCamera.clearFlags = CameraClearFlags.Depth;
					_divaCamera.depth = 10;
					if(SystemManager.isLongScreenDevice)
					{
						FlexibleCameraChanger.AddComponent(_divaCamera.gameObject, true, false, 0, 0);
					}
					return true;
				});
				ResourcesManager.Instance.Load("Menu/Prefab/3dModel/MenuDivaManager", (FileResultObject fo) =>
				{
					//0x126181C
					GameObject g = Instantiate(fo.unityObject) as GameObject;
					_divaCamera.transform.SetParent(g.transform, false);
					_menuDivaManager = g.GetComponent<MenuDivaManager>();
					return true;
				});
				while(_menuDivaManager == null || _divaCamera == null)
					yield return null;
			}
			_menuDivaManager.Release(true);
			loadCount = 0;
			_menuDivaManager.Load(divaId, GetDivaDefaultModelId(divaId), 0, DivaResource.MenuFacialType.Home, true);
			_frontEffect = new EffectControll();
			_basaraEffect = new EffectControll();
			_backEffect = new EffectControll();
			op = AssetBundleManager.LoadAssetAsync("mn/gt/dv.xab", "get_dv_front_root", typeof(GameObject));
			yield return op;
			_frontEffect.obj = Instantiate(op.GetAsset<GameObject>());
			_frontEffect.anim = _frontEffect.obj.GetComponentInChildren<Animator>(true);
			_frontEffect.Init();
			loadCount++;
			op = AssetBundleManager.LoadAssetAsync("mn/gt/dv.xab", "get_dv_front_root_basara", typeof(GameObject));
			yield return op;
			_basaraEffect.obj = Instantiate(op.GetAsset<GameObject>());
			_basaraEffect.anim = _basaraEffect.obj.GetComponentInChildren<Animator>(true);
			_basaraEffect.Init();
			loadCount++;
			op = AssetBundleManager.LoadAssetAsync("mn/gt/dv.xab", "get_dv_back_root", typeof(GameObject));
			yield return op;
			_backEffect.obj = Instantiate(op.GetAsset<GameObject>());
			_backEffect.anim = _backEffect.obj.GetComponentInChildren<Animator>(true);
			_backEffect.Init();
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("mn/gt/dv.xab", false);
			}
			while(_menuDivaManager.IsLoading)
				yield return null;
			_menuDivaManager.SetActive(false, true);
			IsLoaded3dResource = true;
		}

		// // RVA: 0x12607CC Offset: 0x12607CC VA: 0x12607CC
		private void OnPushOkButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(PushOkButtonHandler != null)
				PushOkButtonHandler();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
		}

		// // RVA: 0x1260908 Offset: 0x1260908 VA: 0x1260908
		private void OnBackButton()
		{
			OnPushOkButton();
		}

		// RVA: 0x126090C Offset: 0x126090C VA: 0x126090C
		public void OkButtonOff()
		{
			_info.GetBtn().IsInputOff = true;
		}

		// // RVA: 0x1260950 Offset: 0x1260950 VA: 0x1260950
		public void Release(bool isDestroyDivaManager = false)
		{
			_menuDivaManager.EndControl(_divaControl);
			SoundManager.Instance.voGreeting.RequestRemoveCueSheet();
			_info.Release();
			_menuDivaManager.Release(true);
			_divaCamera.transform.localPosition = _diva_camera_pos;
			_divaCamera.transform.localRotation = _diva_camera_rot;
			if(isDestroyDivaManager)
			{
				Destroy(_menuDivaManager.gameObject);
			}
			Destroy(_frontEffect.obj.gameObject);
			Destroy(_basaraEffect.obj.gameObject);
			Destroy(_backEffect.obj.gameObject);
			_frontEffect = null;
			_basaraEffect = null;
			_backEffect = null;
			_menuDivaManager = null;
		}

		// // RVA: 0x1260C70 Offset: 0x1260C70 VA: 0x1260C70
		private int GetDivaDefaultModelId(int divaId)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(divaId, 1).DAJGPBLEEOB_PrismCostumeModelId;
		}

		// // RVA: 0x1260D78 Offset: 0x1260D78 VA: 0x1260D78
		private SystemManager.OverPermissionAspectResult GetOverPermissionAspectResult()
		{
			return SystemManager.Instance.CheckOverPermissionAspectRatio();
		}

		// // RVA: 0x1260E14 Offset: 0x1260E14 VA: 0x1260E14
		// private bool IsPermissionAspect() { }

		// // RVA: 0x1260E34 Offset: 0x1260E34 VA: 0x1260E34
		// private bool IsOverPermissionAspect() { }

		// // RVA: 0x1260E4C Offset: 0x1260E4C VA: 0x1260E4C
		private void FlexibleFovProcess()
		{
			float f;
			if(!SystemManager.isLongScreenDevice)
			{
				SystemManager.OverPermissionAspectResult p = GetOverPermissionAspectResult();
				if(Screen.width * 1.0f / Screen.height < SystemManager.BaseScreenSize.x / SystemManager.BaseScreenSize.y || p != SystemManager.OverPermissionAspectResult.None)
				{
					f = 25;
				}
				else
				{
					f = (SystemManager.BaseScreenSize.x / SystemManager.BaseScreenSize.y) / (Screen.width * 1.0f / Screen.height) * 25;
				}
			}
			else
			{
				f = Mathf.CeilToInt(MenuScene.GetLongScreenScale() * 25);
			}
			_divaCamera.fieldOfView = f;
		}
	}
}
