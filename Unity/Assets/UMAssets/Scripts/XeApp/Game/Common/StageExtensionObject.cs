using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageExtensionObject : MonoBehaviour
	{
		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private StageExtensionResource resource; // 0x14
		private StageObject stageObject; // 0x18
		private List<Transform> attachNodeList; // 0x1C
		private List<GameObject> prefabInstanceList; // 0x20
		private List<Animator> animatorList = new List<Animator>(); // 0x24
		private List<ParticleSystem> particleList = new List<ParticleSystem>(); // 0x28
		private List<StageColorChanger> colorChangerList = new List<StageColorChanger>(); // 0x2C
		private List<StageExtensionObjectSetupDiva> divaList = new List<StageExtensionObjectSetupDiva>(); // 0x30
		private List<StageExtensionObjectComponentBase> componentList = new List<StageExtensionObjectComponentBase>(); // 0x34
		private StageExtensionWindCtrl windCtrl; // 0x38
		private bool m_pause; // 0x3C
		private ValkyrieShaderController valkyrieShaderController; // 0x40

		private CriManaMovieController moviePlayer { get; set; } // 0x44

		// RVA: 0x139FA60 Offset: 0x139FA60 VA: 0x139FA60
		//public void ResetAnimationPreview() { }

		// RVA: 0x139FA74 Offset: 0x139FA74 VA: 0x139FA74
		public void LateUpdate()
		{
			UnityEngine.Debug.LogError("TODO StageExtensionObject LateUpdate");
		}

		// RVA: 0x139FD44 Offset: 0x139FD44 VA: 0x139FD44
		public void Initialize(StageExtensionResource resource, StageObject stageObject, MusicCameraObject cameraObject, List<GameDivaObject> divaObjectList)
		{
			UnityEngine.Debug.LogError("TODO StageExtensionObject Initialize");
		}

		// RVA: 0x13A1820 Offset: 0x13A1820 VA: 0x13A1820
		public bool AddExtentionSetupWind(List<DivaExtensionObject> a_list)
		{
			UnityEngine.Debug.LogError("TODO StageExtensionObject AddExtentionSetupWind");
			return true;
		}

		//// RVA: 0x13A1C1C Offset: 0x13A1C1C VA: 0x13A1C1C
		//public void UpdateColorByStageLighting(Color fakelitColor, Color lightColorA, Color lightColorB, Color lightColorC) { }

		//// RVA: 0x13A1DC0 Offset: 0x13A1DC0 VA: 0x13A1DC0
		public void SetupPsylliumColor(MusicDirectionParamBase musicParam, DivaParam divaParam, List<DivaResource> subDivaResource)
		{
			UnityEngine.Debug.LogError("TODO StageExtensionObject SetupPsylliumColor");
		}

		//// RVA: 0x13A1EA8 Offset: 0x13A1EA8 VA: 0x13A1EA8
		//public void EnableObject(int id) { }

		//// RVA: 0x13A1F84 Offset: 0x13A1F84 VA: 0x13A1F84
		//public void DisableObject(int id) { }

		//// RVA: 0x13A2060 Offset: 0x13A2060 VA: 0x13A2060
		//public void EventMoviePlay() { }

		//// RVA: 0x13A2114 Offset: 0x13A2114 VA: 0x13A2114
		//public void EventMovieStop() { }

		//// RVA: 0x13A2208 Offset: 0x13A2208 VA: 0x13A2208
		//public void PlayMusicAnimation() { }

		//// RVA: 0x13A284C Offset: 0x13A284C VA: 0x13A284C
		//public void Stop() { }

		//// RVA: 0x13A29D0 Offset: 0x13A29D0 VA: 0x13A29D0
		//public void Pause() { }

		//// RVA: 0x13A2E58 Offset: 0x13A2E58 VA: 0x13A2E58
		//public void Resume() { }

		//// RVA: 0x13A22F0 Offset: 0x13A22F0 VA: 0x13A22F0
		//public void ChangeAnimationTime(double time) { }
	}
}
