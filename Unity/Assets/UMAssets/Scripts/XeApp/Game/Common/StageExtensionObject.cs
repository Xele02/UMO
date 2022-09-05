using System.Collections.Generic;
using CriWare;
using UnityEngine;
using UnityEngine.Playables;

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
			if(moviePlayer != null)
			{
				// Nothing, was printing frame info ?
			}
			if(m_pause)
			{
				for(int i = 0; i < particleList.Count; i++)
				{
					if(particleList[i].gameObject.activeInHierarchy)
					{
						particleList[i].Pause();
					}
				}
			}
		}

		// RVA: 0x139FD44 Offset: 0x139FD44 VA: 0x139FD44
		public void Initialize(StageExtensionResource resource, StageObject stageObject, MusicCameraObject cameraObject, List<GameDivaObject> divaObjectList)
		{
			this.resource = resource;
			this.stageObject = stageObject;
			if(resource == null)
			{
				colorChangerList.Clear();
				animatorList.Clear();
				particleList.Clear();
				divaList.Clear();
			}
			else
			{
				animator = GetComponent<Animator>();
				animator.runtimeAnimatorController = resource.animatorController;
				overrideController = new AnimatorOverrideController();
				overrideController.name = "dr_st_override_controller";
				overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
				overrideController["dr_st_cmn_animation"] = resource.clip;
				animator.runtimeAnimatorController = overrideController;
				if(animator != null)
				{
					if(animator.runtimeAnimatorController != null)
					{
						animator.playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
					}
				}
				attachNodeList = new List<Transform>(resource.param.attachDataList.Count);
				prefabInstanceList = new List<GameObject>(resource.param.attachDataList.Count);
				List<Renderer> renderers = new List<Renderer>();
				componentList.Clear();
				colorChangerList.Clear();
				animatorList.Clear();
				particleList.Clear();
				divaList.Clear();
				windCtrl = null;
				for(int i = 0; i < resource.param.attachDataList.Count; i++)
				{
					attachNodeList.Add(stageObject.rootObject.transform.Find(resource.param.attachDataList[i].path));
					if(attachNodeList[i] == null)
					{
						return;
					}
					GameObject instance = Instantiate(resource.prefabList[i]);
					instance.transform.SetParent(attachNodeList[i], false);
					instance.SetActive(resource.param.attachDataList[i].isEnableStart);
					prefabInstanceList.Add(instance);
					colorChangerList.Add(instance.GetComponent<StageColorChanger>());
					animatorList.AddRange(instance.GetComponentsInChildren<Animator>(true));
					particleList.AddRange(instance.GetComponentsInChildren<ParticleSystem>(true));
					renderers.AddRange(instance.GetComponentsInChildren<Renderer>(true));
					DivaExtensionAdjust adjust = instance.GetComponent<DivaExtensionAdjust>();
					if(adjust != null)
					{
						adjust.Initialize(divaObjectList[0].divaId);
					}
					DivaExtensionAdjust2 adjust2 = instance.GetComponent<DivaExtensionAdjust2>();
					if(adjust2 != null)
					{
						adjust2.Initialize(divaObjectList[0].divaId);
					}
					DivaExtensionAdjust3 adjust3 = instance.GetComponent<DivaExtensionAdjust3>();
					if (adjust3 != null)
					{
						adjust3.Initialize(divaObjectList);
					}
					windCtrl = instance.GetComponent<StageExtensionWindCtrl>();
					if(windCtrl != null)
					{
						windCtrl.Initialize(divaObjectList);
					}
					StageExtensionObjectSetupDiva sesd = instance.GetComponent<StageExtensionObjectSetupDiva>();
					if(sesd != null)
					{
						sesd.SetupDivaObject();
						divaList.Add(sesd);
					}
					if(resource.movieMaterial != null)
					{
						BundleShaderInfo.Instance.FixMaterialShaderMat(resource.movieMaterial);
						Renderer[] selfRenderers = instance.GetComponentsInChildren<Renderer>();
						for(int j = 0; j < selfRenderers.Length; j++)
						{
							if(selfRenderers[j].sharedMaterial.name.CompareTo("cri_movie") == 0 || selfRenderers[j].sharedMaterial.name.CompareTo("cri_movie_add") == 0)
							{
								selfRenderers[j].sharedMaterial = resource.movieMaterial;
							}
						}
					}
					MusicCameraFollower[] camFollowers = instance.GetComponentsInChildren<MusicCameraFollower>(true);
					for(int j = 0; j < camFollowers.Length; j++)
					{
						camFollowers[j].Initialize(cameraObject);
					}
					componentList.AddRange(instance.GetComponentsInChildren<StageExtensionObjectComponentBase>(true));
				}
				if(valkyrieShaderController == null)
				{
					valkyrieShaderController = gameObject.AddComponent<ValkyrieShaderController>();
				}
				valkyrieShaderController.Initialize(renderers.ToArray(), null);
				for(int i = 0; i < animatorList.Count; i++)
				{
					if(animatorList[i] != null && animatorList[i].runtimeAnimatorController != null)
					{
						animatorList[i].playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
					}
				}
				if (resource.moviePlayer != null)
					moviePlayer = resource.moviePlayer;
			}
		}

		// RVA: 0x13A1820 Offset: 0x13A1820 VA: 0x13A1820
		public bool AddExtentionSetupWind(List<DivaExtensionObject> a_list)
		{
			if(windCtrl != null)
			{
				foreach(var deo in a_list)
				{
					windCtrl.AddExtensionBSC(deo.BoneSpringControllerList);
				}
				return true;
			}
			return false;
		}

		//// RVA: 0x13A1C1C Offset: 0x13A1C1C VA: 0x13A1C1C
		public void UpdateColorByStageLighting(Color fakelitColor, Color lightColorA, Color lightColorB, Color lightColorC)
		{
			for(int i = 0; i < colorChangerList.Count; i++)
			{
				if(colorChangerList[i] != null)
				{
					colorChangerList[i].UpdateColorByStageLighting(fakelitColor, lightColorA, lightColorB, lightColorC);
				}
			}
		}

		//// RVA: 0x13A1DC0 Offset: 0x13A1DC0 VA: 0x13A1DC0
		public void SetupPsylliumColor(MusicDirectionParamBase musicParam, DivaParam divaParam, List<DivaResource> subDivaResource)
		{
			for(int i = 0; i < colorChangerList.Count; i++)
			{
				StageObject.StaticSetupPsylliumColor(colorChangerList[i], musicParam, divaParam, subDivaResource);
			}
		}

		//// RVA: 0x13A1EA8 Offset: 0x13A1EA8 VA: 0x13A1EA8
		public void EnableObject(int id)
		{
			if (prefabInstanceList.Count <= id - 1)
				return;
			prefabInstanceList[id - 1].SetActive(true);
		}

		//// RVA: 0x13A1F84 Offset: 0x13A1F84 VA: 0x13A1F84
		public void DisableObject(int id)
		{
			if (prefabInstanceList.Count <= id - 1)
				return;
			prefabInstanceList[id - 1].SetActive(false);
		}

		//// RVA: 0x13A2060 Offset: 0x13A2060 VA: 0x13A2060
		public void EventMoviePlay()
		{
			if(moviePlayer != null)
				moviePlayer.Play();
		}

		//// RVA: 0x13A2114 Offset: 0x13A2114 VA: 0x13A2114
		public void EventMovieStop()
		{
			if(moviePlayer != null)
			{
				moviePlayer.Stop();
				moviePlayer.player.Prepare();
			}
		}

		//// RVA: 0x13A2208 Offset: 0x13A2208 VA: 0x13A2208
		public void PlayMusicAnimation()
		{
			if (animator != null)
			{
				ChangeAnimationTime(0);
				animator.Play("Music", 0);
				m_pause = false;
			}
		}

		//// RVA: 0x13A284C Offset: 0x13A284C VA: 0x13A284C
		//public void Stop() { }

		//// RVA: 0x13A29D0 Offset: 0x13A29D0 VA: 0x13A29D0
		//public void Pause() { }

		//// RVA: 0x13A2E58 Offset: 0x13A2E58 VA: 0x13A2E58
		//public void Resume() { }

		//// RVA: 0x13A22F0 Offset: 0x13A22F0 VA: 0x13A22F0
		public void ChangeAnimationTime(double time)
		{
			if (animator != null && animator.runtimeAnimatorController != null)
			{
				animator.speed = 1;
				if (PlayableExtensions.IsValid<Playable>(animator.playableGraph.GetRootPlayable(0)))
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
			}
			for(int i = 0; i < animatorList.Count; i++)
			{
				if(animatorList[i] != null && animatorList[i].runtimeAnimatorController != null)
				{
					animatorList[i].speed = 1;
					if (PlayableExtensions.IsValid<Playable>(animatorList[i].playableGraph.GetRootPlayable(0)))
					{
						animatorList[i].playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animatorList[i].playableGraph.GetRootPlayable(0))));
					}
				}
			}
		}
	}
}
