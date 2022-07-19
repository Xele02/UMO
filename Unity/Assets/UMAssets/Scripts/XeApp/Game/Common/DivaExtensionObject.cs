using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaExtensionObject : MonoBehaviour
	{
		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private DivaExtensionResource resource; // 0x14
		private DivaObject divaObject; // 0x18
		private List<Transform> attachNodeList; // 0x1C
		private List<GameObject> prefabInstanceList; // 0x20
		private List<Animator> animatorList = new List<Animator>(); // 0x24
		private List<ParticleSystem> particleList = new List<ParticleSystem>(); // 0x28
		private List<BoneSpringController> bscList = new List<BoneSpringController>(); // 0x2C
		private Color defaultMainColor; // 0x30
		private Color defaultRimColor; // 0x40
		private float defaultRimPower = 1; // 0x50
		private List<Renderer> renderers = new List<Renderer>(); // 0x54
		private List<Material> materials = new List<Material>(); // 0x58
		private bool isMovieMode; // 0x5C
		private bool m_pause; // 0x5D
		private Coroutine m_coroutine_bsc_lock; // 0x60
		private bool m_is_bsc_lock; // 0x64

		//public int divaId { get; } 0x1BEBEB8
		//public List<BoneSpringController> BoneSpringControllerList { get; } 0x1BEBEDC

		//// RVA: 0x1BEBEE4 Offset: 0x1BEBEE4 VA: 0x1BEBEE4
		//public void ResetAnimationPreview() { }

		//// RVA: 0x1BEBEE8 Offset: 0x1BEBEE8 VA: 0x1BEBEE8
		public void Initialize(DivaExtensionResource resource, DivaObject divaObject, MusicCameraObject cameraObject, List<GameDivaObject> a_diva_list)
		{
			UnityEngine.Debug.LogError("TODO DivaExtensionObject Initialize");
		}

		//// RVA: 0x1BED240 Offset: 0x1BED240 VA: 0x1BED240
		public void SetupDefaultMaterialColor(Color mainColor, Color rimColor, float rimPower)
		{
			UnityEngine.Debug.LogError("TODO DivaExtensionObject SetupDefaultMaterialColor");
		}

		//// RVA: 0x1BED8C4 Offset: 0x1BED8C4 VA: 0x1BED8C4
		//public void ChangeMovieMaterialColor(bool isOn) { }

		//// RVA: 0x1BED964 Offset: 0x1BED964 VA: 0x1BED964
		//public void UpdateColorByStageLighting(Color mainColor, Color rimColor, float rimPower) { }

		//// RVA: 0x1BED594 Offset: 0x1BED594 VA: 0x1BED594
		//private void ChangeColor(Color mainColor, Color rimColor, float rimPower) { }

		//// RVA: 0x1BEDADC Offset: 0x1BEDADC VA: 0x1BEDADC
		//public void EnableObject(int id) { }

		//// RVA: 0x1BEDBB8 Offset: 0x1BEDBB8 VA: 0x1BEDBB8
		//public void DisableObject(int id) { }

		//// RVA: 0x1BEDC94 Offset: 0x1BEDC94 VA: 0x1BEDC94
		//public void PlayMusicAnimation() { }

		//// RVA: 0x1BEE2D8 Offset: 0x1BEE2D8 VA: 0x1BEE2D8
		//public void Stop() { }

		//// RVA: 0x1BEE38C Offset: 0x1BEE38C VA: 0x1BEE38C
		//public void Pause() { }

		//// RVA: 0x1BEE5EC Offset: 0x1BEE5EC VA: 0x1BEE5EC
		//public void Resume() { }

		//// RVA: 0x1BEE84C Offset: 0x1BEE84C VA: 0x1BEE84C
		//public void LockBoneSpring(int a_index = 0, float a_seconds = 0,05) { }

		//[IteratorStateMachineAttribute] // RVA: 0x737C50 Offset: 0x737C50 VA: 0x737C50
		//// RVA: 0x1BEE8D4 Offset: 0x1BEE8D4 VA: 0x1BEE8D4
		//public IEnumerator CoroutineWaitLockBoneSpring(int a_index = 0, float a_seconds = 0,1) { }

		//// RVA: 0x1BEE9C0 Offset: 0x1BEE9C0 VA: 0x1BEE9C0
		//public void UnlockBoneSpring() { }

		//// RVA: 0x1BEDD7C Offset: 0x1BEDD7C VA: 0x1BEDD7C
		//public void ChangeAnimationTime(double time) { }

		//// RVA: 0x1BEEAA0 Offset: 0x1BEEAA0 VA: 0x1BEEAA0
		public void LateUpdate()
		{
			UnityEngine.Debug.LogError("TODO LateUpdate DivaExtenssionObject");
		}
	}
}
