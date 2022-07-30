using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
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
		public List<BoneSpringController> BoneSpringControllerList { get { return bscList; } } //0x1BEBEDC

		//// RVA: 0x1BEBEE4 Offset: 0x1BEBEE4 VA: 0x1BEBEE4
		//public void ResetAnimationPreview() { }

		//// RVA: 0x1BEBEE8 Offset: 0x1BEBEE8 VA: 0x1BEBEE8
		public void Initialize(DivaExtensionResource resource, DivaObject divaObject, MusicCameraObject cameraObject, List<GameDivaObject> a_diva_list)
		{
			if(resource != null)
			{
				animator = GetComponent<Animator>();
				animator.runtimeAnimatorController = resource.animatorController;
				overrideController = new AnimatorOverrideController();
				overrideController.name = "dr_dv_override_controller";
				overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
				overrideController["dr_dv_cmn_animation"] = resource.clip;
				animator.runtimeAnimatorController = overrideController;
				if(animator != null && animator.runtimeAnimatorController != null)
				{
					animator.playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
				}
				attachNodeList = new List<Transform>(resource.param.attachDataList.Count);
				prefabInstanceList = new List<GameObject>(resource.param.attachDataList.Count);
				animatorList.Clear();
				particleList.Clear();
				bscList.Clear();
				for(int i = 0; i < resource.param.attachDataList.Count; i++)
				{
					Transform t = divaObject.divaPrefab.transform.Find(resource.param.attachDataList[i].path);
					attachNodeList.Add(t);
					if(t == null)
						return;
					GameObject prefab = Instantiate<GameObject>(resource.prefabList[i]);
					prefab.transform.SetParent(t, false);
					prefab.SetActive(resource.param.attachDataList[i].isEnableStart);
					prefabInstanceList.Add(prefab);
					if(prefab.GetComponent<DivaExtensionAdjust>())
					{
						prefab.GetComponent<DivaExtensionAdjust>().Initialize(divaObject.divaId);
					}
					if(prefab.GetComponent<DivaExtensionAdjust2>())
					{
						prefab.GetComponent<DivaExtensionAdjust2>().Initialize(divaObject.divaId);
					}
					if(prefab.GetComponent<DivaExtensionAdjust3>())
					{
						prefab.GetComponent<DivaExtensionAdjust3>().Initialize(a_diva_list);
					}
					if(prefab.GetComponent<DivaExtensionAdjustInterpolate>())
					{
						prefab.GetComponent<DivaExtensionAdjustInterpolate>().Initialize(a_diva_list);
					}
					if(prefab.GetComponent<DivaExtensionChangeAnimationForPositionId>())
					{
						prefab.GetComponent<DivaExtensionChangeAnimationForPositionId>().Initialize(divaObject);
					}
					if(prefab.GetComponentInChildren<BoneSpringController>(true))
					{
						prefab.GetComponentInChildren<BoneSpringController>(true).Initialize(BoneSpringController.PerformanceMode.High);
					}
					if(prefab.GetComponent<GameObjectFollowingTwoPos>())
					{
						prefab.GetComponent<GameObjectFollowingTwoPos>().Initialize(divaObject.divaPrefab.transform);
					}
					if(prefab.GetComponent<GameObjectFollowingAnyPos>())
					{
						prefab.GetComponent<GameObjectFollowingAnyPos>().Initialize(divaObject.divaPrefab.transform);
					}
					if(prefab.GetComponent<DivaExtensionAttachDivaMike>())
					{
						prefab.GetComponent<DivaExtensionAttachDivaMike>().Initialize(divaObject);
					}
					if(prefab.GetComponent<DivaExtensionPositionOffset>())
					{
						prefab.GetComponent<DivaExtensionPositionOffset>().Initialize(divaObject);
					}
					renderers.AddRange(prefab.GetComponentsInChildren<Renderer>());
					animatorList.AddRange(prefab.GetComponentsInChildren<Animator>(true));
					particleList.AddRange(prefab.GetComponentsInChildren<ParticleSystem>(true));
					bscList.AddRange(prefab.GetComponentsInChildren<BoneSpringController>(true));
					MusicCameraFollower[] mcfs = prefab.GetComponentsInChildren<MusicCameraFollower>(true);
					for(int j = 0; j < mcfs.Length; j++)
					{
						mcfs[j].Initialize(cameraObject);
					}
				}
				for(int i = 0; i < animatorList.Count; i++)
				{
					if(animatorList[i] != null && animatorList[i].runtimeAnimatorController != null)
					{
						animatorList[i].playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
					}
				}
			}
		}

		//// RVA: 0x1BED240 Offset: 0x1BED240 VA: 0x1BED240
		public void SetupDefaultMaterialColor(Color mainColor, Color rimColor, float rimPower)
		{
			defaultMainColor = mainColor;
			defaultRimColor = rimColor;
			defaultRimPower = rimPower;
			materials.Clear();
			for(int i = 0; i < renderers.Count; i++)
			{
				if(renderers[i] != null)
				{
					if(renderers[i].material.HasProperty("_Color") && renderers[i].material.HasProperty("_RimColor") &&
						renderers[i].material.HasProperty("_RimLightPower"))
					{
						materials.Add(renderers[i].material);
					}
				}
			}
			ChangeColor(mainColor, rimColor, rimPower);
		}

		//// RVA: 0x1BED8C4 Offset: 0x1BED8C4 VA: 0x1BED8C4
		//public void ChangeMovieMaterialColor(bool isOn) { }

		//// RVA: 0x1BED964 Offset: 0x1BED964 VA: 0x1BED964
		public void UpdateColorByStageLighting(Color mainColor, Color rimColor, float rimPower)
		{
			if(!isMovieMode)
			{
				Color main = Color.Lerp(defaultMainColor, mainColor, mainColor.a);
				main.a = defaultMainColor.a;
				Color rim = Color.Lerp(defaultRimColor, rimColor, rimColor.a);
				rim.a = defaultRimColor.a;
				ChangeColor(main, rim, Mathf.Lerp(defaultRimPower, rimPower, rimColor.a));
			}
		}

		//// RVA: 0x1BED594 Offset: 0x1BED594 VA: 0x1BED594
		private void ChangeColor(Color mainColor, Color rimColor, float rimPower)
		{
			if(materials != null)
			{
				for(int i = 0; i < materials.Count; i++)
				{
					if(materials[i] != null)
					{
						Color col = materials[i].GetColor("_Color");
						mainColor.a = col.a;
						materials[i].SetColor("_Color", mainColor);
						col = materials[i].GetColor("_RimColor");
						rimColor.a = col.a;
						materials[i].SetColor("_RimColor", rimColor);
						materials[i].SetFloat("_RimLightPower", rimPower);
					}
				}
			}
		}

		//// RVA: 0x1BEDADC Offset: 0x1BEDADC VA: 0x1BEDADC
		public void EnableObject(int id)
		{
			if((id - 1) >= prefabInstanceList.Count)
				return;
			prefabInstanceList[id - 1].SetActive(true);
		}

		//// RVA: 0x1BEDBB8 Offset: 0x1BEDBB8 VA: 0x1BEDBB8
		public void DisableObject(int id)
		{
			if((id - 1) >= prefabInstanceList.Count)
				return;
			prefabInstanceList[id - 1].SetActive(false);
		}

		//// RVA: 0x1BEDC94 Offset: 0x1BEDC94 VA: 0x1BEDC94
		public void PlayMusicAnimation()
		{
			if (animator != null)
			{
				ChangeAnimationTime(0);
				animator.Play("Music", 0);
				m_pause = false;
			}
		}

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
		public void ChangeAnimationTime(double time)
		{
			if (animator != null && animator.runtimeAnimatorController != null)
			{
				animator.speed = 1;
				if (animator.playableGraph.IsValid())
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
			}
			for (int i = 0; i < animatorList.Count; i++)
			{
				if (animatorList[i] != null && animatorList[i].runtimeAnimatorController != null)
				{
					animatorList[i].speed = 1;
					if (animatorList[i].playableGraph.IsValid())
					{
						animatorList[i].playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animatorList[i].playableGraph.GetRootPlayable(0))));
					}
				}
			}
		}

		//// RVA: 0x1BEEAA0 Offset: 0x1BEEAA0 VA: 0x1BEEAA0
		public void LateUpdate()
		{
			if(m_pause)
			{
				UnityEngine.Debug.LogError("TODO LateUpdate DivaExtenssionObject when paused");
			}
		}
	}
}
