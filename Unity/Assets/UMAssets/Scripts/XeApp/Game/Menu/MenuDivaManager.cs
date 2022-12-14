using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MenuDivaManager : MonoBehaviour
	{
		public interface ControlDelegater
		{
			//// RVA: -1 Offset: -1 Slot: 0
			//public abstract void BeginControl(MenuDivaManager divaManager, MenuDivaObject divaObject);

			//// RVA: -1 Offset: -1 Slot: 1
			//public abstract void EndControl();
		}
		[SerializeField]
		private GameObject divaPrefab; // 0xC
		private DivaResource resource; // 0x10
		private DivaMenuParam divaMenuParam; // 0x14
		private MenuDivaObject divaObject; // 0x18
		private MenuDivaVoiceTable voiceTable; // 0x1C
		private MenuDivaVoiceTableCos voiceTableCos; // 0x20
		private MenuDivaControlBase divaControl; // 0x24
		private MessageBank messageBank; // 0x28
		private Vector3 position = new Vector3(0, 0, 0); // 0x2C
		private const float CameraDistance = 30;
		private string fullName = string.Empty; // 0x38
		private MenuDivaObject divaSubObject; // 0x3C
		private bool m_isChangingDivaCameraRot; // 0x40
		private Camera divaCamera; // 0x44

		public bool IsLoading { get; private set; } // 0x48
		//public MenuDivaVoiceTable VoiceTable { get; } 0xECA3B4
		//public MenuDivaVoiceTableCos VoiceTableCos { get; } 0xECA3BC
		//public IList<int> ReactionWeights { get; } 0xECA3C4
		public int DivaId { get { return divaObject != null ? divaObject.divaId : -1; } } //0xECA3F0
		public int ModelId { get { return divaObject != null ? divaObject.modelId : -1; } } //0xECA4A8
		public int ColorId { get { return divaObject != null ? divaObject.colorId : -1; } } //0xECA560
		//public Vector3 CurrentDivaCameraRot { get; }0xECA618
		//public MenuDivaControlBase DBG_DivaControl { get; }0xECBF4C

		// RVA: 0xECA66C Offset: 0xECA66C VA: 0xECA66C
		private void Awake()
		{
			resource = GameManager.Instance.divaResource;
		}

		// RVA: 0xECA710 Offset: 0xECA710 VA: 0xECA710
		private void Start()
		{
			divaCamera = transform.GetComponentInChildren<Camera>(true);
			if (MenuScene.Instance != null)
				MenuScene.Instance.divaManager = this;
		}

		// RVA: 0xECA870 Offset: 0xECA870 VA: 0xECA870
		private void Update()
		{
			if(divaControl != null)
				divaControl.OnUpdate();
		}

		// RVA: 0xECA88C Offset: 0xECA88C VA: 0xECA88C
		private void LateUpdate()
		{
			if(divaControl != null)
				divaControl.OnLateUpdate();
		}

		// RVA: 0xECA8A8 Offset: 0xECA8A8 VA: 0xECA8A8
		private void OnDestroy()
		{
			Release(false);
		}

		//// RVA: 0xECA8B0 Offset: 0xECA8B0 VA: 0xECA8B0
		//public void Load(int divaId, int modelId, int colorId, DivaResource.MenuFacialType facialType, bool defaultVisible = True) { }

		//// RVA: 0xEB9C30 Offset: 0xEB9C30 VA: 0xEB9C30
		//public void Load(DFKGGBMFFGB playerData, DivaResource.MenuFacialType facialType, bool defaultVisible = True) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C6F94 Offset: 0x6C6F94 VA: 0x6C6F94
		//// RVA: 0xECA8F8 Offset: 0xECA8F8 VA: 0xECA8F8
		//private IEnumerator Coroutine_Load(int divaId, int modelId, int colorId, DivaResource.MenuFacialType facialType, bool defaultVisible = True) { }

		//// RVA: 0xEB9BA8 Offset: 0xEB9BA8 VA: 0xEB9BA8
		public void Release(bool isModelChange)
		{
			messageBank = null;
			if(isModelChange)
			{
				TodoLogger.Log(0, "Menudivamanager reenable release when diva is loaded");
				//resource.ReleaseBasicResource();
			}
			if (!resource.isLoadedMenuAnimationResource)
				return;
			resource.ReleaseMenuResource();
		}

		//// RVA: 0xECAA24 Offset: 0xECAA24 VA: 0xECAA24
		//public void Load(DivaResource outerResource, int divaId, int modelId, int colorId, bool defaultVisible = True) { }

		//// RVA: 0xECAE44 Offset: 0xECAE44 VA: 0xECAE44
		//public void ChangeCostumeTexture(List<Material> mtlList, int colorId) { }

		//// RVA: 0xECAE80 Offset: 0xECAE80 VA: 0xECAE80
		//public void IdleCrossFade(string stateName = "") { }

		//// RVA: 0xECAEB4 Offset: 0xECAEB4 VA: 0xECAEB4
		//public void SetBodyCrossFade(string stateName, float duration = 0,07) { }

		//// RVA: 0xECAEF0 Offset: 0xECAEF0 VA: 0xECAEF0
		//public void PlayFacialBlendAnimator(string stateName, int layerIndex) { }

		//// RVA: 0xECAF2C Offset: 0xECAF2C VA: 0xECAF2C
		//public bool IsCurrentBodyState(int hash) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C700C Offset: 0x6C700C VA: 0x6C700C
		//// RVA: 0xECAF60 Offset: 0xECAF60 VA: 0xECAF60
		//public IEnumerator Co_WaitTransition() { }

		//// RVA: 0xEB3CD8 Offset: 0xEB3CD8 VA: 0xEB3CD8
		public void SetActive(bool active, bool isIdle = true)
		{
			if(divaObject != null)
			{
				divaObject.VisibleRendererComponent(active);
				if (!active || !isIdle)
					return;
				OnIdle("");
			}
		}

		//// RVA: 0xECB00C Offset: 0xECB00C VA: 0xECB00C
		//public void SetEnableDivaEffect(bool a_enable, bool a_save_ignore = False) { }

		//// RVA: 0xECB0D0 Offset: 0xECB0D0 VA: 0xECB0D0
		//public bool GetEnableDivaEffect() { }

		//// RVA: 0xECB0FC Offset: 0xECB0FC VA: 0xECB0FC
		//public void SetEnableDivaWind(bool a_enable, bool a_save_ignore = False) { }

		//// RVA: 0xECB1C0 Offset: 0xECB1C0 VA: 0xECB1C0
		//public bool GetEnableDivaWind() { }

		//// RVA: 0xECB1EC Offset: 0xECB1EC VA: 0xECB1EC
		//public void SetEnableRenderer(bool visible) { }

		//// RVA: 0xECB2A8 Offset: 0xECB2A8 VA: 0xECB2A8
		//public void SetPosition(Vector3 position) { }

		//// RVA: 0xECB408 Offset: 0xECB408 VA: 0xECB408
		//public bool isWaitUnlockBoneSpring() { }

		//// RVA: 0xECB4C0 Offset: 0xECB4C0 VA: 0xECB4C0
		public void LockBoneSpring()
		{
			divaObject.LockBoneSpring(0);
		}

		//// RVA: 0xECB4F0 Offset: 0xECB4F0 VA: 0xECB4F0
		public void UnlockBoneSpring()
		{
			divaObject.UnlockBoneSpring(false, 0);
		}

		//// RVA: 0xEB9EF0 Offset: 0xEB9EF0 VA: 0xEB9EF0
		public void OnIdle(string stateName = "")
		{
			if(divaObject != null)
			{
				DivaTransformReset();
				divaObject.Idle(stateName);
			}
		}

		//// RVA: 0xECB524 Offset: 0xECB524 VA: 0xECB524
		public void DivaTransformReset()
		{
			transform.position = position;
			transform.rotation = Quaternion.identity;
		}

		//// RVA: 0xECB630 Offset: 0xECB630 VA: 0xECB630
		//public void OverrideAnimations(List<DivaResource.MotionOverrideClipKeyResource> resource) { }

		//// RVA: 0xECB6EC Offset: 0xECB6EC VA: 0xECB6EC
		//public void OverrideAnimations(List<DivaResource.MotionOverrideSingleResource> resource) { }

		//// RVA: 0xECB7A8 Offset: 0xECB7A8 VA: 0xECB7A8
		public void SetAnimParamInteger(string paramName, int value)
		{
			if(divaObject != null)
			{
				divaObject.SetAnimInteger(paramName, value);
			}
		}

		//// RVA: 0xEB470C Offset: 0xEB470C VA: 0xEB470C
		//public string GetMessageByLabel(string label) { }

		//// RVA: 0xECB868 Offset: 0xECB868 VA: 0xECB868
		//public string GetMessageByIndex(int index) { }

		//// RVA: 0xEB4454 Offset: 0xEB4454 VA: 0xEB4454
		//public string GetFullName() { }

		//// RVA: 0xECB89C Offset: 0xECB89C VA: 0xECB89C
		//public void SetCameraRot(Vector3 rotation) { }

		//// RVA: 0xECB90C Offset: 0xECB90C VA: 0xECB90C
		//public void ChangeCameraRot(Vector3 rotation, float duration) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C7084 Offset: 0x6C7084 VA: 0x6C7084
		//// RVA: 0xECBA4C Offset: 0xECBA4C VA: 0xECBA4C
		//private IEnumerator Co_ChangeCameraRot(Vector3 rotation, float duration) { }

		//// RVA: 0xECBB44 Offset: 0xECBB44 VA: 0xECBB44
		//public bool IsChangingCameraRot() { }

		//// RVA: 0xECAC40 Offset: 0xECAC40 VA: 0xECAC40
		//public void ApplyCameraPos(int divaId, DivaMenuParam.CameraPosType type = 0) { }

		//// RVA: 0xECBB4C Offset: 0xECBB4C VA: 0xECBB4C
		//public void SwitchCameraRender(DivaCameraRenderSwitch renderSwitch) { }

		//// RVA: 0xECBB88 Offset: 0xECBB88 VA: 0xECBB88
		//public void SetCameraFov(float fov) { }

		//// RVA: 0xECBBBC Offset: 0xECBBBC VA: 0xECBBBC
		//public VectorI2 GetCameraPixelSize() { }

		//// RVA: 0xECBC34 Offset: 0xECBC34 VA: 0xECBC34
		//public void RevertCameraRender(DivaCameraRenderSwitch renderSwitch) { }

		//// RVA: 0xECBC68 Offset: 0xECBC68 VA: 0xECBC68
		//public void LoadSub(int modelId, int colorId, int divaId = 0) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C70FC Offset: 0x6C70FC VA: 0x6C70FC
		//// RVA: 0xECBCA0 Offset: 0xECBCA0 VA: 0xECBCA0
		//private IEnumerator Coroutine_LoadSub(int modelId, int colorId, int divaId) { }

		//// RVA: 0xECBD98 Offset: 0xECBD98 VA: 0xECBD98
		//public void ReleaseSub() { }

		//// RVA: 0xEB536C Offset: 0xEB536C VA: 0xEB536C
		//public void BeginControl(MenuDivaControlBase control) { }

		//// RVA: 0xEB50F4 Offset: 0xEB50F4 VA: 0xEB50F4
		//public void EndControl(MenuDivaControlBase control) { }

		//// RVA: 0xECBEA8 Offset: 0xECBEA8 VA: 0xECBEA8
		//public bool Compare(int divaId, int modelId, int colorId) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6C7174 Offset: 0x6C7174 VA: 0x6C7174
		//// RVA: 0xECC008 Offset: 0xECC008 VA: 0xECC008
		//private bool <Coroutine_LoadSub>b__76_0() { }
	}
}
