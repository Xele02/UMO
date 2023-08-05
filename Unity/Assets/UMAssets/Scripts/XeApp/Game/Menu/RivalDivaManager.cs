using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RivalDivaManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject divaPrefab; // 0xC
		private DivaResource resource; // 0x10
		private DivaMenuParam divaMenuParam; // 0x14
		private MenuDivaObject divaObject; // 0x18
		private MenuDivaControlBase divaControl; // 0x1C
		private MessageBank messageBank; // 0x20
		private Camera divaCamera; // 0x24

		public bool IsLoading { get; private set; } // 0x28
		//public int DivaId { get; } 0xB647D4

		// RVA: 0xB6488C Offset: 0xB6488C VA: 0xB6488C
		private void Awake()
		{
			resource = gameObject.AddComponent<DivaResource>();
		}

		// RVA: 0xB64914 Offset: 0xB64914 VA: 0xB64914
		private void Start()
		{
			divaCamera = GetComponentInChildren<Camera>(true);
			divaCamera.enabled = false;
			gameObject.SetActive(false);
		}

		// RVA: 0xB649D4 Offset: 0xB649D4 VA: 0xB649D4
		private void Update()
		{
			divaControl.OnUpdate();
		}

		// RVA: 0xB649F0 Offset: 0xB649F0 VA: 0xB649F0
		private void LateUpdate()
		{
			divaControl.OnLateUpdate();
		}

		//// RVA: 0xB64A0C Offset: 0xB64A0C VA: 0xB64A0C
		//public void Load(int divaId, int modelId, int colorId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C7324 Offset: 0x6C7324 VA: 0x6C7324
		//// RVA: 0xB64A44 Offset: 0xB64A44 VA: 0xB64A44
		//private IEnumerator Co_Load(int divaId, int modelId, int colorId) { }

		//// RVA: 0xB64B3C Offset: 0xB64B3C VA: 0xB64B3C
		//public void Release() { }

		//// RVA: 0xB4A400 Offset: 0xB4A400 VA: 0xB4A400
		//public void SetActive(bool active, bool isIdle = True) { }

		//// RVA: 0xB64E94 Offset: 0xB64E94 VA: 0xB64E94
		//public bool isWaitUnlockBoneSpring() { }

		//// RVA: 0xB64F4C Offset: 0xB64F4C VA: 0xB64F4C
		//public void LockBoneSpring() { }

		//// RVA: 0xB4A4F8 Offset: 0xB4A4F8 VA: 0xB4A4F8
		//public void UnlockBoneSpring() { }

		//// RVA: 0xB64DD0 Offset: 0xB64DD0 VA: 0xB64DD0
		//public void OnIdle() { }

		//// RVA: 0xB64F7C Offset: 0xB64F7C VA: 0xB64F7C
		//public void ApplyCameraPos(int divaId, DivaMenuParam.CameraPosType type = 0) { }

		//// RVA: 0xB4A558 Offset: 0xB4A558 VA: 0xB4A558
		//public void SwitchCameraRender(DivaCameraRenderSwitch renderSwitch) { }

		//// RVA: 0xB65134 Offset: 0xB65134 VA: 0xB65134
		//public void RevertCameraRender(DivaCameraRenderSwitch renderSwitch) { }

		//// RVA: 0xB65168 Offset: 0xB65168 VA: 0xB65168
		//public VectorI2 GetCameraPixelSize() { }

		//// RVA: 0xB4A52C Offset: 0xB4A52C VA: 0xB4A52C
		//public void OnBattleResultStart() { }

		//// RVA: 0xB651E0 Offset: 0xB651E0 VA: 0xB651E0
		//public void OnBattleResultAnimStart(bool isWin) { }

		//// RVA: 0xB653A4 Offset: 0xB653A4 VA: 0xB653A4
		//public void RequestBattleResultAnimStart(bool isWin) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C739C Offset: 0x6C739C VA: 0x6C739C
		//// RVA: 0xB653DC Offset: 0xB653DC VA: 0xB653DC
		//private IEnumerator Coroutine_RequestResultAnimStart() { }

		//// RVA: 0xB65488 Offset: 0xB65488 VA: 0xB65488
		//public void ResetBattleResultTransform() { }

		//// RVA: 0xB6553C Offset: 0xB6553C VA: 0xB6553C
		//public void SetEnableDivaEffect(bool a_enable, bool a_save_ginore = False) { }

		//// RVA: 0xB4A340 Offset: 0xB4A340 VA: 0xB4A340
		//public void SetEnableDivaWind(bool a_enable, bool a_save_ginore = False) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6C7414 Offset: 0x6C7414 VA: 0x6C7414
		//// RVA: 0xB65604 Offset: 0xB65604 VA: 0xB65604
		//private bool <Co_Load>b__18_0() { }
	}
}
