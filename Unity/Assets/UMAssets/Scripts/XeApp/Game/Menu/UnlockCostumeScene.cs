using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class UnlockCostumeScene : TransitionRoot
	{
		private class CameraController
		{
			public Camera camera; // 0x8
			public Animator animator; // 0xC
			public Transform pos; // 0x10
			public ObjectPositionAdjuster adjuster; // 0x14
			public FlexibleCameraChanger flexible_changer; // 0x18
			public RenderTexture rendererTexture; // 0x1C
		}

		private class EffectController
		{
			public GameObject obj; // 0x8
			public Animator animator; // 0xC

			//// RVA: 0x1258358 Offset: 0x1258358 VA: 0x1258358
			//public void Init() { }
		}

		public class CostumeData
		{
			public int id = -1; // 0x8
			public int color_id; // 0xC
		}

		[SerializeField]
		private ScriptableObject m_CameraParam; // 0x48
		private int m_diva_id = 1; // 0x4C
		private CostumeData m_after_costume; // 0x50
		private CostumeData m_before_costume; // 0x54
		private bool m_model_loaded; // 0x58
		private bool m_camera_anim_loaded; // 0x59
		private bool m_voice_loaded; // 0x5A
		private MenuDivaManager m_divaManager; // 0x5C
		private CameraController m_befor_camera = new CameraController(); // 0x60
		private CameraController m_after_camera = new CameraController(); // 0x64
		private RawImage m_RT_image; // 0x68
		private Material m_RT_material; // 0x6C
		private UnlockCostumeInfo m_info_layout; // 0x70
		private UnlockCostumeLogo m_logo_layout; // 0x74
		private UnlockCostumeLogo m_logo_color_layout; // 0x78
		private EffectController m_eff_front; // 0x7C
		private EffectController m_eff_back; // 0x80
		private EffectController m_eff_borderline; // 0x84
		private float m_borderline_eff_param; // 0x88
		private float m_final_camera_move_sec; // 0x8C
		private Vector3 m_final_camera_pos; // 0x90
		private Vector3 m_final_camera_lookat; // 0x9C
		private Vector3 m_final_camera_pos_scale = Vector3.zero; // 0xA8
		private Vector3 m_final_camera_lookat_scale = Vector3.zero; // 0xB4
		private List<Vector3> m_final_camera_offset; // 0xC0
		private List<float> m_camera_adjust_scale; // 0xC4
		private Vector3 m_befor_origin_pos = new Vector3(1000, 1000, 0); // 0xC8
		private Vector3 m_camera_anim_last_pos = Vector3.zero; // 0xD4
		private Vector3 m_camera_anim_last_lookat = Vector3.zero; // 0xE0
		private List<MenuDivaObject> m_diva_list = new List<MenuDivaObject>(); // 0xEC
		private float m_eff_borderline_speed; // 0xF0
		private bool IsEffectLoaded; // 0xF4
		private const float RendererTextureBlendMin3dPos = -5;
		private const float RendererTextureBlendMax3dPos = 5;

		private FFHPBEPOMAK_DivaInfo currentViewDivaData { get { return GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[m_diva_id - 1]; } set { return; } } //0x1256964 0x1256A4C
		private LayoutLogoCutin layoutUnlockCutin { get { return UnlockFadeManager.Instance.GetEffect(); } set { return; } } //0x1256A50 0x1256AEC

		// // RVA: 0x1256AF0 Offset: 0x1256AF0 VA: 0x1256AF0
		private void InitializeFinishCameraDataCoroutine()
		{
			CostumeCameraParameter param = m_CameraParam as CostumeCameraParameter; 
			m_borderline_eff_param = param.m_borderline_eff_param;
			m_camera_adjust_scale = param.m_camera_adjust_scale;
			m_final_camera_move_sec = param.m_final_camera_move_sec;
			m_final_camera_pos = param.m_final_camera_pos;
			m_final_camera_lookat = param.m_final_camera_lookat;
			m_final_camera_offset = param.m_final_camera_offset;
		}

		// RVA: 0x1256C34 Offset: 0x1256C34 VA: 0x1256C34 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			GameManager.Instance.SetFPS(60);
			m_divaManager = MenuScene.Instance.divaManager;
			Vector2 v = SystemManager.BaseScreenSize;
			if(SystemManager.isLongScreenDevice)
			{
				v.x = GameManager.Instance.AppResolutionWidth;
				v.y = v.x / (SystemManager.BaseScreenSize.x / SystemManager.BaseScreenSize.y);
			}
			m_befor_camera.camera = transform.Find("BeforPos/BeforObject/BeforCamera").GetComponent<Camera>();
			m_befor_camera.pos = transform.Find("BeforPos");
			m_befor_camera.animator = transform.Find("BeforPos/BeforObject").GetComponent<Animator>();
			m_befor_camera.adjuster = m_befor_camera.animator.GetComponent<ObjectPositionAdjuster>();
			m_befor_camera.flexible_changer = m_befor_camera.camera.GetComponent<FlexibleCameraChanger>();
			m_befor_camera.animator.speed = 0;
			m_befor_camera.rendererTexture = m_befor_camera.camera.targetTexture;
			if(SystemManager.isLongScreenDevice)
			{
				m_befor_camera.rendererTexture = new RenderTexture((int)v.x, (int)v.y, m_befor_camera.camera.targetTexture.depth);
			}
			m_befor_camera.camera.targetTexture = m_befor_camera.rendererTexture;
			m_after_camera.camera = transform.Find("AfterPos/AfterObject/AfterCamera").GetComponent<Camera>();
			m_after_camera.pos = transform.Find("AfterPos");
			m_after_camera.animator = transform.Find("AfterPos/AfterObject").GetComponent<Animator>();
			m_after_camera.adjuster = m_after_camera.animator.GetComponent<ObjectPositionAdjuster>();
			m_after_camera.flexible_changer = m_after_camera.camera.GetComponent<FlexibleCameraChanger>();
			m_after_camera.animator.speed = 0;
			m_after_camera.rendererTexture = m_after_camera.camera.targetTexture;
			if(SystemManager.isLongScreenDevice)
			{
				m_after_camera.rendererTexture = new RenderTexture((int)v.x, (int)v.y, m_after_camera.camera.targetTexture.depth);
			}
			m_after_camera.camera.targetTexture = m_after_camera.rendererTexture;
			m_RT_material = transform.Find("RT_DivaRenderer").GetComponent<RawImage>().material;
			m_RT_image = transform.Find("RT_DivaRenderer").GetComponent<RawImage>();
			if(SystemManager.isLongScreenDevice)
			{
				m_RT_material.SetTexture("_BeforeTex", m_befor_camera.rendererTexture);
				m_RT_material.SetTexture("_AfterTex", m_after_camera.rendererTexture);
			}
			m_logo_layout = transform.Find("root_ul_cos_logo_layout_root").GetComponent<UnlockCostumeLogo>();
			m_logo_color_layout = transform.Find("root_ul_cos_logo_02_layout_root").GetComponent<UnlockCostumeLogo>();
			m_info_layout = transform.Find("root_ul_cos_layout_root").GetComponent<UnlockCostumeInfo>();
			m_befor_camera.flexible_changer.enabled = false;
			if(!SystemManager.isLongScreenDevice)
				m_after_camera.flexible_changer.enabled = true;
			else
			{
				m_after_camera.flexible_changer.enabled = false;
				m_after_camera.camera.rect = new Rect(0, 0, 1, 1);
				m_befor_camera.camera.rect = new Rect(0, 0, 1, 1);
			}
			InitializeFinishCameraDataCoroutine();
			IsReady = true;
		}

		// RVA: 0x1257A18 Offset: 0x1257A18 VA: 0x1257A18 Slot: 16
		protected override void OnPreSetCanvas()
		{
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
			if(SystemManager.isLongScreenDevice || SystemManager.CanWideScreenMenu)
			{
				m_befor_camera.flexible_changer.enabled = false;
				m_after_camera.flexible_changer.enabled = false;
				m_after_camera.camera.rect = new Rect(0, 0, 1, 1);
				m_befor_camera.camera.rect = new Rect(0, 0, 1, 1);
			}
			else
			{
				m_befor_camera.flexible_changer.enabled = false;
				m_after_camera.flexible_changer.enabled = true;
			}
		}

		// RVA: 0x1257D48 Offset: 0x1257D48 VA: 0x1257D48 Slot: 18
		protected override void OnPostSetCanvas()
		{
			if(Args != null && Args is UnlockCostumeArgs)
			{
				UnlockCostumeArgs arg = Args as UnlockCostumeArgs;
				m_diva_id = arg.diva_id;
				m_after_costume = arg.after_costume_data;
				if(arg.before_costume_data == null)
				{
					m_before_costume = new CostumeData();
					m_before_costume.id = currentViewDivaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
					m_before_costume.color_id = currentViewDivaData.EKFONBFDAAP_ColorId;

				}
				else
					m_before_costume = arg.before_costume_data;
			}
			this.StartCoroutineWatched(Co_MainFlow());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x731414 Offset: 0x731414 VA: 0x731414
		// // RVA: 0x1257EF4 Offset: 0x1257EF4 VA: 0x1257EF4
		private IEnumerator Co_MainFlow()
		{
			//0x125C678
			if(!IsEffectLoaded)
			{
				yield return this.StartCoroutineWatched(Co_LoadUnlockCostumeResource());
			}
			yield return this.StartCoroutineWatched(Co_LoadDivaResource());
			Initialize();
			while(!m_info_layout.IsResourceLoaded())
				yield return null;
			m_info_layout.GetBtn().IsInputOff = true;
			yield return this.StartCoroutineWatched(Co_LoadingResource());
			yield return Resources.UnloadUnusedAssets();
			yield return this.StartCoroutineWatched(Co_PlayingLayoutUnlockCutin());
			yield return this.StartCoroutineWatched(Co_WaitingStartAnimStart());
			yield return this.StartCoroutineWatched(Co_WaitingPoseAnimStart());
			yield return this.StartCoroutineWatched(Co_WaitingLoopAnimStart());
			yield return this.StartCoroutineWatched(Co_WaitingLoopAnimEnd());
			yield return this.StartCoroutineWatched(Co_MovingCamera());
			yield return this.StartCoroutineWatched(Co_OpenPopupGetDecoCostumeTorso());
			m_info_layout.GetBtn().IsInputOff = false;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73148C Offset: 0x73148C VA: 0x73148C
		// // RVA: 0x1257FA0 Offset: 0x1257FA0 VA: 0x1257FA0
		private IEnumerator Co_LoadUnlockCostumeResource()
		{
			string BundleName; // 0x14
			string AssetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x125BB4C
			m_camera_anim_loaded = false;
			BundleName = "mn/gt/cs.xab";
			AssetName = "menu_costume_get_cam_animator";
			operation = AssetBundleManager.LoadAllAssetAsync(BundleName);
			yield return operation;
			m_befor_camera.animator.runtimeAnimatorController = operation.GetAsset<RuntimeAnimatorController>(AssetName);
			m_after_camera.animator.runtimeAnimatorController = operation.GetAsset<RuntimeAnimatorController>(AssetName);
			m_eff_front = new EffectController();
			InstantiateParticlePrefab(operation, "get_cs_front_root", false, ref m_eff_front);
			m_eff_back = new EffectController();
			InstantiateParticlePrefab(operation, "get_cs_back_root", false, ref m_eff_back);
			m_eff_borderline = new EffectController();
			InstantiateParticlePrefab(operation, "get_cs_diva_particle", true, ref m_eff_borderline);
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			IsEffectLoaded = true;
			m_camera_anim_loaded = true;
		}

		// // RVA: 0x125804C Offset: 0x125804C VA: 0x125804C
		private void InstantiateParticlePrefab(AssetBundleLoadAllAssetOperationBase operation, string assetName, bool isOriginInstantiate, ref UnlockCostumeScene.EffectController effController)
		{
			effController.obj = operation.GetAsset<GameObject>(assetName);
			if(isOriginInstantiate)
			{
				effController.obj = Instantiate(effController.obj, Vector3.zero, effController.obj.transform.rotation);
			}
			else
			{
				effController.obj = Instantiate(effController.obj);
			}
			effController.animator = effController.obj.transform.GetComponentInChildren<Animator>();
			effController.obj.transform.SetParent(m_divaManager.transform, false);

		}

		// [IteratorStateMachineAttribute] // RVA: 0x731504 Offset: 0x731504 VA: 0x731504
		// // RVA: 0x12583B0 Offset: 0x12583B0 VA: 0x12583B0
		private IEnumerator Co_LoadDivaResource()
		{
			int afterCostumeModelId; // 0x18
			int afterCostumeColorId; // 0x1C

			//0x125B304
			afterCostumeModelId = m_after_costume.id;
			afterCostumeColorId = m_after_costume.color_id;
			m_voice_loaded = false;
			m_model_loaded = false;
			m_divaManager.Release(true);
			m_divaManager.Load(m_diva_id, m_before_costume.id, m_before_costume.color_id, DivaResource.MenuFacialType.Home, true);
			yield return new WaitWhile(() =>
			{
				//0x125B244
				return m_divaManager.IsLoading;
			});
			m_divaManager.LoadSub(afterCostumeModelId, afterCostumeColorId, 0);
			yield return new WaitWhile(() =>
			{
				//0x125B284
				return m_divaManager.IsLoading;
			});
			bool is_voice_loaded = false;
			SoundManager.Instance.voDiva.RequestChangeCueSheet(m_diva_id, () =>
			{
				//0x125B2C4
				is_voice_loaded = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x125B2D0
				return is_voice_loaded;
			});
			m_diva_list.Clear();
			m_diva_list.Add(m_divaManager.transform.Find("DivaMenuPrefab(Clone)").GetComponent<MenuDivaObject>());
			m_diva_list.Add(m_divaManager.transform.Find("SubDivaMenuObject").GetComponent<MenuDivaObject>());
			for(int i = 0; i < m_diva_list.Count; i++)
			{
				m_diva_list[i].SetEnableEffect(false, false);
				m_diva_list[i].SetEnableWind(false, false);
				m_diva_list[i].gameObject.SetActive(false);
				m_diva_list[i].SetAnimationSpeed(0);
			}
			m_voice_loaded = true;
			m_model_loaded = true;
		}

		// // RVA: 0x125845C Offset: 0x125845C VA: 0x125845C
		private void Initialize()
		{
			GameManager.Instance.SetFPS(60);
			m_divaManager.transform.Find("DivaCamera").GetComponent<Camera>().enabled = false;
			m_befor_camera.pos.SetParent(m_divaManager.transform, false);
			m_befor_camera.animator.enabled = false;
			m_befor_camera.camera.enabled = true;
			m_after_camera.pos.SetParent(m_divaManager.transform, false);
			m_after_camera.animator.enabled = false;
			m_after_camera.camera.enabled = false;
			m_after_camera.camera.targetTexture = m_after_camera.rendererTexture;
			m_after_camera.camera.clearFlags = CameraClearFlags.SolidColor;
			m_after_camera.flexible_changer.enabled = false;
			m_after_camera.camera.fieldOfView = m_befor_camera.camera.fieldOfView;
			m_info_layout.Wait();
			m_info_layout.Init(m_diva_id, m_after_costume.id, m_after_costume.color_id);
			m_info_layout.GetBtn().ClearOnClickCallback();
			m_info_layout.GetBtn().AddOnClickCallback(() =>
			{
				//0x125AE8C
				OnClickOkBtn();
			});
			m_logo_layout.SetVisible(false);
			m_logo_color_layout.SetVisible(false);
			if(m_after_costume.color_id != 0)
				m_logo_layout = m_logo_color_layout;
			m_logo_layout.SetVisible(true);
			m_logo_layout.Wait();
			m_eff_front.obj.transform.SetParent(m_divaManager.transform, false);
			m_eff_back.obj.transform.SetParent(m_divaManager.transform, false);
			m_eff_borderline.obj.transform.SetParent(m_divaManager.transform, false);
			m_eff_front.animator.enabled = false;
			m_eff_front.obj.SetActive(false);
			m_RT_image.enabled = false;
			InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73157C Offset: 0x73157C VA: 0x73157C
		// // RVA: 0x1258CB8 Offset: 0x1258CB8 VA: 0x1258CB8
		private IEnumerator Co_LoadingResource()
		{
			//0x125BF44
			yield return new WaitUntil(() =>
			{
				//0x125AE90
				return m_model_loaded;
			});
			yield return new WaitUntil(() =>
			{
				//0x125AE98
				return m_camera_anim_loaded;
			});
			yield return new WaitUntil(() =>
			{
				//0x125AEA0
				return m_voice_loaded;
			});
			yield return new WaitUntil(() =>
			{
				//0x125AEA8
				return layoutUnlockCutin.IsEntered();
			});
			layoutUnlockCutin.Leave();
			m_RT_image.enabled = true;
			m_diva_list[0].gameObject.SetActive(true);
			m_diva_list[0].Idle("");
			m_befor_camera.adjuster.Initialize(m_camera_adjust_scale[m_diva_id - 1], true,true, true);
			m_after_camera.adjuster.Initialize(m_camera_adjust_scale[m_diva_id - 1], true,true, true);
			m_final_camera_pos_scale = m_final_camera_pos + m_final_camera_offset[m_diva_id - 1];
			m_final_camera_lookat_scale = m_final_camera_lookat + m_final_camera_offset[m_diva_id - 1];
			PrepareAnimation();
			yield return null;
			m_divaManager.SetPosition(m_befor_origin_pos);
		}

		// // RVA: 0x1258D64 Offset: 0x1258D64 VA: 0x1258D64
		private void PrepareAnimation()
		{
			for(int i = 0; i < m_diva_list.Count; i++)
			{
				m_diva_list[i].gameObject.SetActive(true);
				m_diva_list[i].PlayUnlockCostumeAnim();
				m_diva_list[i].LockBoneSpring(0);
				m_diva_list[i].SetAnimationSpeed(0);
			}
			m_befor_camera.camera.enabled = true;
			m_befor_camera.animator.enabled = true;
			m_befor_camera.adjuster.enabled = true;
			m_befor_camera.camera.transform.localRotation = new Quaternion(0, 180, 0, 0);
			m_befor_camera.pos.localPosition = m_befor_origin_pos;
			m_befor_camera.animator.speed = 0;
			m_after_camera.camera.enabled = true;
			m_after_camera.animator.enabled = true;
			m_after_camera.adjuster.enabled = true;
			m_after_camera.camera.transform.localRotation = new Quaternion(0, 180, 0, 0);
			m_after_camera.animator.speed = 0;
			m_eff_borderline.obj.SetActive(true);
			m_eff_borderline.animator.enabled = true;
			m_eff_back.obj.SetActive(true);
			m_eff_back.animator.enabled = true;
			m_eff_back.animator.Play("get_cs_start_back", 0);
			SetBorderline(0);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7315F4 Offset: 0x7315F4 VA: 0x7315F4
		// // RVA: 0x1259640 Offset: 0x1259640 VA: 0x1259640
		private IEnumerator Co_PlayingLayoutUnlockCutin()
		{
			//0x125DA54
			yield return new WaitWhile(() =>
			{
				//0x125AED8
				return layoutUnlockCutin.IsPlaying();
			});
			StartCostumeChange();
		}

		// // RVA: 0x12596EC Offset: 0x12596EC VA: 0x12596EC
		private void StartCostumeChange()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_001);
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Costume, 0);
			for(int i = 0; i < m_diva_list.Count; i++)
			{
				m_diva_list[i].SetAnimationSpeed(1);
			}
			m_befor_camera.animator.speed = 1;
			m_after_camera.animator.speed = 1;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73166C Offset: 0x73166C VA: 0x73166C
		// // RVA: 0x12598D8 Offset: 0x12598D8 VA: 0x12598D8
		private IEnumerator Co_WaitingStartAnimStart()
		{
			//0x125E7C4
			yield return new WaitUntil(() =>
			{
				//0x125AF08
				return m_diva_list[0].IsMatchUnlockCostumeAnimStep(MenuDivaObject.eUnlockCostumeAnimStep.Start);
			});
			m_divaManager.SetPosition(m_befor_origin_pos);
			SoundManager.Instance.sePlayerBoot.Stop();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7316E4 Offset: 0x7316E4 VA: 0x7316E4
		// // RVA: 0x1259984 Offset: 0x1259984 VA: 0x1259984
		private IEnumerator Co_WaitingPoseAnimStart()
		{
			//0x125E418
			yield return new WaitUntil(() =>
			{
				//0x125AFA8
				SetBorderline(m_diva_list[0].GetNormalizedTime());
				return m_diva_list[0].IsMatchUnlockCostumeAnimStep(MenuDivaObject.eUnlockCostumeAnimStep.Pose);
			});
			SetBorderlineThretholdValue(1);
			m_eff_front.animator.enabled = true;
			m_eff_front.obj.SetActive(true);
			m_eff_back.animator.Play("get_cs_back", 0);
			m_eff_borderline.animator.Play("get_cs_particle_scale", 0);
			SwitchToNormalCamera();
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Costume, 1);
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_003);
			m_eff_borderline.obj.transform.AddLocalPositionY(m_eff_borderline_speed);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73175C Offset: 0x73175C VA: 0x73175C
		// // RVA: 0x1259A30 Offset: 0x1259A30 VA: 0x1259A30
		private IEnumerator Co_WaitingLoopAnimStart()
		{
			//0x125E28C
			yield return new WaitUntil(() =>
			{
				//0x125B0A4
				m_eff_borderline.obj.transform.AddLocalPositionY(m_eff_borderline_speed);
				return m_diva_list[0].IsMatchUnlockCostumeAnimStep(MenuDivaObject.eUnlockCostumeAnimStep.Loop);
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7317D4 Offset: 0x7317D4 VA: 0x7317D4
		// // RVA: 0x1259ADC Offset: 0x1259ADC VA: 0x1259ADC
		private IEnumerator Co_WaitingLoopAnimEnd()
		{
			//0x125DBFC
			yield return new WaitWhile(() =>
			{
				//0x125B184
				return m_diva_list[0].GetNormalizedTime() < 1;
			});
			m_info_layout.Enter();
			m_logo_layout.Enter();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_menu.SE_UNLOCK_003);
			m_diva_list[1].SetEnableEffect(true, false);
			m_befor_camera.animator.enabled = false;
			m_befor_camera.adjuster.enabled = false;
			m_after_camera.animator.enabled = false;
			m_after_camera.adjuster.enabled = false;
			m_eff_borderline.animator.enabled = false;
			m_eff_borderline.obj.SetActive(false);
			m_camera_anim_last_pos = m_after_camera.animator.transform.localPosition;
			m_camera_anim_last_lookat = Vector3.zero;
			float dist = Vector2.Distance(m_camera_anim_last_pos, m_camera_anim_last_lookat);
			m_camera_anim_last_lookat.y = m_after_camera.animator.transform.localPosition.y + dist * Mathf.Tan(m_after_camera.animator.transform.localEulerAngles.x * 0.01745329f);
			m_after_camera.camera.transform.LookAt(m_camera_anim_last_lookat);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73184C Offset: 0x73184C VA: 0x73184C
		// // RVA: 0x1259B88 Offset: 0x1259B88 VA: 0x1259B88
		private IEnumerator Co_MovingCamera()
		{
			float time;

			//0x125CC8C
			time = 0;
			while(time <= m_final_camera_move_sec)
			{
				time += Time.deltaTime;
				float f = Mathf.Clamp01(time / m_final_camera_move_sec);
				m_after_camera.animator.transform.localPosition = Vector3.Lerp(m_camera_anim_last_pos, m_final_camera_pos_scale, f);
				m_after_camera.camera.transform.LookAt(Vector3.Lerp(m_camera_anim_last_lookat, m_final_camera_lookat_scale, f));
				yield return null;
			}
			m_after_camera.animator.transform.localPosition = m_final_camera_pos_scale;
			m_after_camera.camera.transform.LookAt(m_final_camera_lookat_scale);
			if(m_after_costume.color_id == 0)
				yield return Co.R(Co_OnShowTutorialWindow());
			else
				yield return Co.R(Co_OnShowCostumeUpgradeTutorialWindow());
			if(IsHaveDiva())
				yield break;
			bool isWait = true;
			NotHaveDivaWindow(currentViewDivaData.AHHJLDLAPAN_DivaId, () =>
			{
				//0x125B2E0
				isWait = false;
			});
			while(isWait)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7318C4 Offset: 0x7318C4 VA: 0x7318C4
		// // RVA: 0x1259C34 Offset: 0x1259C34 VA: 0x1259C34
		private IEnumerator Co_OpenPopupGetDecoCostumeTorso()
		{
			//0x125D5D4
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(m_diva_id, m_after_costume.id);
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.JAHFLLONDCN(cos.JPIDIENBGKH_CostumeId, m_after_costume.color_id) && 
				HNDLICBDEMI.AFGKIJMPNNN_IsDecoEnabled() &&
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture))
			{
				MenuScene.Instance.InputDisable();
				yield return Co.R(MenuScene.Instance.ShowGetDecoItemWindow(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso, cos.JPIDIENBGKH_CostumeId)));
				MenuScene.Instance.InputEnable();
			}
        }

		// // RVA: 0x1259CE0 Offset: 0x1259CE0 VA: 0x1259CE0
		private bool IsHaveDiva()
		{
			if(currentViewDivaData.IPJMPBANBPP_Enabled)
			{
				return currentViewDivaData.FJODMPGPDDD_DivaHave;
			}
			return false;
		}

		// // RVA: 0x1259D44 Offset: 0x1259D44 VA: 0x1259D44
		private void NotHaveDivaWindow(int divaId, Action endCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GDLAPBKCBFP_IsHomeDivaWindow = false;
            TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, bk.GetMessageByLabel(divaId == 9 ? "unlock_costume_not_have_basara" : "unlock_costume_not_have_diva"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			s.IsCaption = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x125B2EC
				if(endCallBack != null)
					endCallBack();
			}, null, null, null);
        }

		// // RVA: 0x125A0A4 Offset: 0x125A0A4 VA: 0x125A0A4
		public void OnClickOkBtn()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_eff_front.obj.transform.SetParent(transform, false);
			m_eff_back.obj.transform.SetParent(transform, false);
			m_eff_borderline.obj.transform.SetParent(transform, false);
			m_divaManager.SetActive(false, true);
			m_divaManager.SetPosition(Vector3.zero);
			UnlockFadeManager.Release();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			MenuScene.Instance.Return(true);
		}

		// // RVA: 0x125A42C Offset: 0x125A42C VA: 0x125A42C
		private void OnBackButton()
		{
			OnClickOkBtn();
		}

		// // RVA: 0x125A430 Offset: 0x125A430 VA: 0x125A430
		private void SwitchToNormalCamera()
		{
			m_befor_camera.camera.enabled = false;
			m_RT_image.enabled = false;
			m_after_camera.camera.targetTexture = null;
			m_after_camera.camera.clearFlags = CameraClearFlags.Nothing;
			m_after_camera.flexible_changer.enabled = true;
			if(SystemManager.isLongScreenDevice)
			{
				m_after_camera.flexible_changer.IsEnableFlexibleFov = true;
			}
			m_after_camera.flexible_changer.Initialize();
			if(!SystemManager.isLongScreenDevice)
				return;
			m_after_camera.flexible_changer.IsEnableFlexibleFov = false;
			m_after_camera.camera.fieldOfView = Mathf.CeilToInt(m_after_camera.flexible_changer.GetDefaultFov(0) * MenuScene.GetLongScreenScale());
		}

		// // RVA: 0x12593C8 Offset: 0x12593C8 VA: 0x12593C8
		private void SetBorderline(float time)
		{
			Vector2 s = transform.parent.GetComponent<RectTransform>().sizeDelta;
			Vector3 v = new Vector3(0, m_borderline_eff_param * (792.0f / s.y) * (time - 0.5f), 0);
			m_eff_borderline_speed = v.y - m_eff_borderline.obj.transform.localPosition.y;
			m_eff_borderline.obj.transform.localPosition = v;
			SetBorderlineThretholdValue((Mathf.Clamp(v.y, -5, 5) + 5) / 10.0f);
		}

		// // RVA: 0x125A7D0 Offset: 0x125A7D0 VA: 0x125A7D0
		private void SetBorderlineThretholdValue(float value)
		{
			m_RT_material.SetFloat("_Threthold", value);
		}

		// RVA: 0x125A854 Offset: 0x125A854 VA: 0x125A854 Slot: 14
		protected override void OnDestoryScene()
		{
			GameManager.Instance.SetFPS(30);
			m_divaManager.Release(true);
			m_divaManager.ReleaseSub();
			m_divaManager.transform.Find("DivaCamera").GetComponent<Camera>().enabled = true;
			m_befor_camera.pos.SetParent(transform, false);
			m_befor_camera.camera.enabled = false;
			m_after_camera.pos.SetParent(transform, false);
			m_after_camera.camera.enabled = false;
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73193C Offset: 0x73193C VA: 0x73193C
		// // RVA: 0x125AB5C Offset: 0x125AB5C VA: 0x125AB5C
		private IEnumerator Co_OnShowTutorialWindow()
		{
			//0x125D410
			yield return this.StartCoroutineWatched(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCodition));
		}

		// // RVA: 0x125AC08 Offset: 0x125AC08 VA: 0x125AC08
		private bool CheckTutorialCodition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition33;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7319B4 Offset: 0x7319B4 VA: 0x7319B4
		// // RVA: 0x125AC18 Offset: 0x125AC18 VA: 0x125AC18
		private IEnumerator Co_OnShowCostumeUpgradeTutorialWindow()
		{
			//0x125D24C
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCoditionCostumeUpgrade));
		}

		// // RVA: 0x125ACC4 Offset: 0x125ACC4 VA: 0x125ACC4
		private bool CheckTutorialCoditionCostumeUpgrade(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition64;
		}
	}
}
