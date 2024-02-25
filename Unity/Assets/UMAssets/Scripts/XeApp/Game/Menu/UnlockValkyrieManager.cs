using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieManager : MonoBehaviour
	{
		[SerializeField]
		private ScriptableObject m_CameraParam; // 0xC
		private UnlockValkyrieScene.CameraInfo m_DefaultCameraInfo; // 0x10
		private UnlockValkyrieScene.CameraInfo m_FinishCameraInfo; // 0x14
		private List<UnlockValkyrieScene.CameraInfo> m_FinishCameraInfoList = new List<UnlockValkyrieScene.CameraInfo>(); // 0x18
		private float m_CameraFieldOfView; // 0x1C
		private float m_CameraFarClip; // 0x20
		private float m_CameraNearClip; // 0x24
		private float m_CameraLerpTime; // 0x28
		private UnlockValkyrieObject m_Object; // 0x2C
		private UnlockValkyrieEffect m_Effect; // 0x30
		private UnlockValkyrieInfo m_LayoutInfo; // 0x34
		private UnlockValkyrieLogo m_LayoutLogo; // 0x38
		public UnityAction PushOkButtonHandler; // 0x3C
		private bool _isInitializedLayout; // 0x40
		private bool _isInitialized3dResource; // 0x41
		private bool _isInitializedPilotVoice; // 0x42
		private int _valkyrieId = -1; // 0x44
		private int _seriesAttr; // 0x48
		public bool IsAnimEnd; // 0x4C

		public bool IsInitializedLayout { get { return _isInitializedLayout; } } //0x164DE9C
		public bool IsInitializedValkyrie { get { return _isInitialized3dResource; } } //0x164DEA4
		public bool IsInitializedPilotVoice { get { return _isInitializedPilotVoice; } } //0x164DEAC
		public int SeriesAttr { get { return _seriesAttr; } } //0x164DEB4

		// // RVA: 0x164DEBC Offset: 0x164DEBC VA: 0x164DEBC
		private void InitializeFinishCameraDataCoroutine()
		{
			ValkyrieCameraParameter param = m_CameraParam as ValkyrieCameraParameter;
			m_DefaultCameraInfo = new UnlockValkyrieScene.CameraInfo(param.m_DefaultCameraPosition, param.m_DefaultTargetPosition);
			m_FinishCameraInfo = new UnlockValkyrieScene.CameraInfo(param.m_FinishCameraInfo, param.m_FinishTargetInfo);
			m_CameraFieldOfView = param.m_CameraFieldOfView;
			m_CameraFarClip = param.m_CameraFarClip;
			m_CameraNearClip = param.m_CameraNearClip;
			m_CameraLerpTime = param.m_CameraLerpTime;
			m_FinishCameraInfoList.Clear();
			for(int i = 0; i < param.m_FinishCameraPositionList.Count; i++)
			{
				m_FinishCameraInfoList.Add(new UnlockValkyrieScene.CameraInfo(param.m_FinishCameraPositionList[i], param.m_FinishTargetPositionList[i]));
			}
		}

		// RVA: 0x164E338 Offset: 0x164E338 VA: 0x164E338
		public void InitializeLayout()
		{
			this.StartCoroutineWatched(InitializeLayoutCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73297C Offset: 0x73297C VA: 0x73297C
		// // RVA: 0x164E35C Offset: 0x164E35C VA: 0x164E35C
		private IEnumerator InitializeLayoutCoroutine()
		{
			string bundleName; // 0x14
			int loadCount; // 0x18
			AssetBundleLoadLayoutOperationBase layOp; // 0x1C

			//0x16501B4
			_isInitializedLayout = false;
			bundleName = "ly/086.xab";
			loadCount = 0;
			layOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_ul_val_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
			{
				//0x164EE9C
				m_LayoutInfo = inst.GetComponentInChildren<UnlockValkyrieInfo>(true);
				inst.transform.SetParent(transform, false);
			}));
			loadCount++;
			layOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_ul_val_logo_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
			{
				//0x164EF8C
				m_LayoutLogo = inst.GetComponentInChildren<UnlockValkyrieLogo>(true);
				inst.transform.SetParent(transform, false);
			}));
			loadCount++;
			yield return new WaitWhile(() =>
			{
				//0x164F07C
				if(m_LayoutInfo.IsLoaded())
				{
					return !m_LayoutLogo.IsLoaded();
				}
				return true;
			});
			m_LayoutInfo.OnClickOk = OnPushOkButton;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			InitializeFinishCameraDataCoroutine();
			_isInitializedLayout = true;
		}

		// RVA: 0x164E408 Offset: 0x164E408 VA: 0x164E408
		public void InitializeValkyrie(int valkyrieId, float camDepth = 0)
		{
			_valkyrieId = valkyrieId;
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(_valkyrieId, 0, 0);
			m_LayoutInfo.Setup(p);
			_isInitializedPilotVoice = false;
			_seriesAttr = p.AIHCEGFANAM_Serie;
			SoundManager.Instance.voPilot.RequestChangeCueSheet(p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, () =>
			{
				//0x164F0DC
				_isInitializedPilotVoice = true;
			});
			this.StartCoroutineWatched(Load3dResourceCoroutine(_valkyrieId, camDepth));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7329F4 Offset: 0x7329F4 VA: 0x7329F4
		// // RVA: 0x164E5BC Offset: 0x164E5BC VA: 0x164E5BC
		private IEnumerator Load3dResourceCoroutine(int valkyrieId, float camDepth = 0)
		{
			//0x165072C
			_isInitialized3dResource = false;
			m_Object = GetComponentInChildren<UnlockValkyrieObject>(true);
			ApplyCameraParameter();
			m_Object.LoadResource(valkyrieId);
			m_Effect = GetComponentInChildren<UnlockValkyrieEffect>(true);
			m_Effect.LoadResource();
			yield return new WaitWhile(() =>
			{
				//0x164F0E8
				if(m_Object.IsLoaded())
				{
					return !m_Effect.IsLoaded();
				}
				return true;
			});
			m_Object.Camera.depth = camDepth;
			_isInitialized3dResource = true;
		}

		// RVA: 0x164E6A8 Offset: 0x164E6A8 VA: 0x164E6A8
		public void StartDirection()
		{
			m_LayoutLogo.ResetAnim();
			m_LayoutInfo.ResetAnim();
			this.StartCoroutineWatched(DirectionCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x732A6C Offset: 0x732A6C VA: 0x732A6C
		// // RVA: 0x164E708 Offset: 0x164E708 VA: 0x164E708
		private IEnumerator DirectionCoroutine()
		{
			bool retry;

			//0x164F8BC
			retry = false;
			//LAB_0164ffd0
			while(true)
			{
				retry = false;
				UnlockFadeManager.Instance.GetEffect().Leave();
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x164F460
					return UnlockFadeManager.Instance.GetEffect().IsPlaying();
				});
				GameManager.Instance.SetFPS(60);
				m_Object.Enter();
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_002);
				m_Effect.PlayBackFlash();
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x164F14C
					if(m_Object.GetCurrentForm() != FKGMGBHBNOC.HPJOCKGKNCC_Form.AEFCOHJBLPO_Num && m_Object.GetCurrentForm() > FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter)
					{
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VALKYRIE_000);
						return false;
					}
					return true;
				});
				yield return new WaitWhile(() =>
				{
					//0x164F2DC
					return !m_Object.IsEntered();
				});
				SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Unlock, 0);
				for(int i = 0; i < 2; i++)
				{
					m_Effect.Play((UnlockValkyrieEffect.EffectType)i);
				}
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_004);
				yield return new WaitWhile(() =>
				{
					//0x164F314
					for(int i = 0; i < 2; i++)
					{
						if(m_Effect.IsPlaying((UnlockValkyrieEffect.EffectType) i))
							return true;
					}
					return false;
				});
				m_Object.Finish();
				m_LayoutLogo.Enter();
				m_LayoutInfo.Enter();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_003);
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x164F368
					if(m_Object.IsFinished())
					{
						if(m_LayoutLogo.IsEntered())
						{
							return m_LayoutInfo.IsPlaying();
						}
					}
					return true;
				});
				yield return Co.R(Co_OpenPopupGetDecoVFFigure());
				m_LayoutInfo.SetOperation(true);
				GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
				if(!retry)
					yield break;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x732AE4 Offset: 0x732AE4 VA: 0x732AE4
		// // RVA: 0x164E7B4 Offset: 0x164E7B4 VA: 0x164E7B4
		private IEnumerator Co_OpenPopupGetDecoVFFigure()
		{
			//0x164F510
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.AAACOMKNJJJ(_valkyrieId) && HNDLICBDEMI.AFGKIJMPNNN_IsDecoEnabled() && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture))
			{
				MenuScene.Instance.InputDisable();
				yield return Co.R(MenuScene.Instance.ShowGetDecoItemWindow(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure, _valkyrieId)));
				MenuScene.Instance.InputEnable();
			}
		}

		// // RVA: 0x164E860 Offset: 0x164E860 VA: 0x164E860
		private void OnPushOkButton()
		{
			UnlockFadeManager.Release();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(PushOkButtonHandler != null)
				PushOkButtonHandler();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
		}

		// // RVA: 0x164E9CC Offset: 0x164E9CC VA: 0x164E9CC
		private void OnBackButton()
		{
			OnPushOkButton();
		}

		// // RVA: 0x164E9D0 Offset: 0x164E9D0 VA: 0x164E9D0
		private void ApplyCameraParameter()
		{
			m_Object.DefaultCameraInfo = m_DefaultCameraInfo;
			m_Object.FinishCameraInfo = m_FinishCameraInfo;
			m_Object.FinishCameraInfoList = m_FinishCameraInfoList;
			m_Object.CameraFieldOfView = m_CameraFieldOfView;
			m_Object.CameraFarClip = m_CameraFarClip;
			m_Object.CameraNearClip = m_CameraNearClip;
			m_Object.CameraLerpTime = m_CameraLerpTime;
		}

		// RVA: 0x164EADC Offset: 0x164EADC VA: 0x164EADC
		private void Reset()
		{
			ApplyCameraParameter();
			m_Object.Reset();
			m_Effect.Reset();
			m_LayoutInfo.ResetAnim();
			m_LayoutLogo.ResetAnim();
		}

		// RVA: 0x164ED1C Offset: 0x164ED1C VA: 0x164ED1C
		public void Release()
		{
			m_Object.Release();
			m_Effect.Release();
		}
	}
}
