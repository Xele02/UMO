using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaObject : MonoBehaviour
	{
		[SerializeField]
		protected DivaObjectParam ObjParam; // 0xC
		protected int divaId_ = -1; // 0x10
		protected int modelId_ = -1; // 0x14
		protected int colorId_; // 0x18
		protected int positionId_ = 1; // 0x1C
		protected GameObject divaPrefab_; // 0x20
		protected GameObject mikePrefab; // 0x24
		protected GameObject mikeStandPrefab; // 0x28
		protected MikeStandObject mikeStandObject; // 0x2C
		protected Animator animator; // 0x30
		protected AnimatorOverrideController overrideController; // 0x34
		protected ObjectPositionAdjuster adjustScaler; // 0x38
		protected BoneSpringController boneSpringController; // 0x3C
		protected BoneSpringAnimObject m_boneSpringAnim; // 0x40
		protected FacialBlendAnimMediatorBase facialBlendAnimMediator; // 0x44
		protected DivaAwakenAuraSwitcher awakenAuraSwitcher; // 0x48
		protected Transform leftHandAttachNode; // 0x4C
		protected Transform rightHandAttachNode; // 0x50
		private Coroutine m_coroutine_wait_lock; // 0x58
		private bool m_is_wait_lock; // 0x5C
		protected List<Renderer> renderers = new List<Renderer>(); // 0x60
		protected List<Animator> m_list_pause_animator = new List<Animator>(); // 0x64
		protected List<ParticleSystem> m_list_pause_particle = new List<ParticleSystem>(); // 0x68
		protected double musicBodyClipLength = -1; // 0x70
		protected ValkyrieShaderController m_valkyrieShaderControlelr = new ValkyrieShaderController(); // 0x78
		protected List<GameObject> effectObject; // 0x7C
		protected bool effectEnable = true; // 0x80
		protected StageExtensionWindCtrlForMenu windObject; // 0x84
		protected bool windEnable = true; // 0x88

		public int divaId { get { return divaId_; } private set { divaId_ = value; } } //0x1BE9D38 0x1BF2220
		public int modelId { get { return modelId_; } private set { modelId_ = value; } } //0x1BF2228 0x1BF2230
		public int colorId { get { return colorId_; } private set { colorId_ = value; } } //0x1BF2238 0x1BF2240
		public int positionId { get { return positionId_; } private set { positionId_ = value; } } //0x1BEBE10 0x1BF2248
		public GameObject divaPrefab { get { return divaPrefab_; } protected set { divaPrefab_ = value; } } //0x1BED1C4 0x1BF2250
		public bool isWaitUnlockBoneSpring { get; private set; } // 0x54
		//public bool isWaitLockBoneSpring { get; private set; } 0x1BF2268 0x1BF2270
		protected virtual bool useQualitySetting { get { return true; } } //0x1BF2274 
		//protected float Anim_speed { set; } 0x1BF6CA0
		
		//// RVA: 0x1BF227C Offset: 0x1BF227C VA: 0x1BF227C
		public void Initialize(DivaResource resource, int divaId, bool useCommonMike = false)
		{
			InnerInitialize(resource, divaId, useCommonMike, true);
			SetupEffectObject(resource.prefabEffect);
			SetupWind(resource.prefabWind, resource.boneSpringResource);
		}

		//// RVA: 0x1BF25B4 Offset: 0x1BF25B4 VA: 0x1BF25B4
		//public void InitializeSub(DivaResource resource, int divaId, bool useCommonMike = False) { }

		//// RVA: 0x1BF2314 Offset: 0x1BF2314 VA: 0x1BF2314
		private void InnerInitialize(DivaResource resource, int divaId, bool useCommonMike, bool isMain)
		{
			divaId_ = divaId;
			modelId_ = resource.LoadedModelId;
			colorId_ = resource.LoadedColorId;
			positionId_ = resource.positionId;
			InnerInstantiatePrefab(resource, useCommonMike, isMain);
			animator = divaPrefab_.GetComponent<Animator>();
			animator.runtimeAnimatorController = resource.divaAnimatorController;
			overrideController = new AnimatorOverrideController();
			OverrideBasicAnimation(resource);
			if(resource.setupFlags == DivaResource.SetupFlags.Default)
			{
				OverrideCustomAnimation(resource);
			}
			animator.runtimeAnimatorController = overrideController;
			SetupBasicComponents();
			SetupCustomComponents(resource);
			SetupPerformanceChangableObject();
			m_list_pause_animator.Clear();
			m_list_pause_animator.AddRange(divaPrefab_.GetComponentsInChildren<Animator>());
			m_list_pause_particle.Clear();
			animator.Rebind();
		}

		//// RVA: 0x1BF2664 Offset: 0x1BF2664 VA: 0x1BF2664
		private void InnerInstantiatePrefab(DivaResource resource, bool useCommonMike, bool isMain)
		{
			Destroy(divaPrefab_);
			if(mikePrefab != null)
			{
				Destroy(mikePrefab);
				mikePrefab = null;
			}
			if(mikeStandPrefab != null)
			{
				Destroy(mikeStandPrefab);
				mikeStandPrefab = null;
			}
			DestroyEffect();
			DestroyWind();
			GameObject prefab = null;
			if(isMain)
			{
				prefab = resource.divaPrefab;
			}
			else
			{
				prefab = resource.subDivaPrefab;
			}
			divaPrefab_ = Instantiate(prefab);
			divaPrefab_.transform.SetParent(transform, false);
			if(resource.mikeStandPrefab != null)
			{
				mikeStandPrefab = Instantiate(resource.mikeStandPrefab);
				mikeStandPrefab.transform.SetParent(transform, false);
				mikeStandObject = mikeStandPrefab.GetComponent<MikeStandObject>();
				mikeStandObject.Initialize(divaId_, resource.mikeStandAnimatorController, resource.mikeStandAnimationOverrideClip);
			}
			if(resource.mikePrefab != null)
			{
				GameObject mikePrefab_ = resource.mikePrefab;
				if(useCommonMike && resource.mikeCommonPrefab != null)
				{
					mikePrefab_ = resource.mikeCommonPrefab;
				}
				mikePrefab = Instantiate(mikePrefab_);
				mikePrefab.transform.SetParent(transform, false);
				mikePrefab.SetActive(false);
			}
		}

		//// RVA: 0x1BF2B9C Offset: 0x1BF2B9C VA: 0x1BF2B9C
		private void OverrideBasicAnimation(DivaResource resource)
		{
			overrideController.name = "diva_override_controller";
			overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
			for(int i = 0; i < resource.commonFacialResource.Count; i++)
			{
				overrideController["diva_cmn_" + resource.commonFacialResource[i].originalName] = resource.commonFacialResource[i].overrideClip;
			}
			for(int i = 0; i < resource.specialFacialResource.Count; i++)
			{
				overrideController["diva_cmn_" + resource.specialFacialResource[i].originalName] = resource.specialFacialResource[i].overrideClip;
			}
		}

		//// RVA: 0x1BF3CF4 Offset: 0x1BF3CF4 VA: 0x1BF3CF4
		public void OverrideAnimations(List<DivaResource.MotionOverrideClipKeyResource> resource)
		{
			for(int i = 0; i < resource.Count; i++)
			{
				overrideController[resource[i].body.name] = resource[i].body.clip;
			}
			facialBlendAnimMediator.OverrideAnimations(resource);
		}

		//// RVA: 0x1BF3E4C Offset: 0x1BF3E4C VA: 0x1BF3E4C
		public void OverrideAnimations(List<DivaResource.MotionOverrideSingleResource> resource)
		{
			for(int i = 0; i < resource.Count; i++)
			{
				if(resource[i].target == DivaResource.MotionOverrideSingleResource.Target.Body)
				{
					overrideController[resource[i].name] = resource[i].clip;
				}
				else
				{
					facialBlendAnimMediator.OverrideAnimations(resource[i]);
				}
			}
		}

		//// RVA: 0x1BF4048 Offset: 0x1BF4048 VA: 0x1BF4048
		//public void OverrideAnimation(ref DivaResource.MotionOverrideClipKeyResource resource) { }

		//// RVA: 0x1BF40B0 Offset: 0x1BF40B0 VA: 0x1BF40B0 Slot: 5
		protected virtual void OverrideCustomAnimation(DivaResource resource)
		{
			return;
		}

		//// RVA: 0x1BF2E24 Offset: 0x1BF2E24 VA: 0x1BF2E24
		private void SetupBasicComponents()
		{
			boneSpringController = divaPrefab_.GetComponentInChildren<BoneSpringController>();
			DivaMikeAttachSupporter mikeAttach = divaPrefab_.GetComponent<DivaMikeAttachSupporter>();
			if(mikeAttach == null)
			{
				mikeAttach = divaPrefab_.AddComponent<DivaMikeAttachSupporter>();
			}
			mikeAttach.diva = this;
			awakenAuraSwitcher = divaPrefab_.GetComponent<DivaAwakenAuraSwitcher>();
			if(awakenAuraSwitcher == null)
			{
				awakenAuraSwitcher = divaPrefab_.AddComponent<DivaAwakenAuraSwitcher>();
			}
			AwakenAuraOff();
			renderers = new List<Renderer>();
			renderers.AddRange(divaPrefab_.GetComponentsInChildren<Renderer>(true));
			if(mikePrefab != null)
			{
				renderers.AddRange(mikePrefab.GetComponentsInChildren<Renderer>(true));
			}
			if(mikeStandPrefab != null)
			{
				renderers.AddRange(mikeStandPrefab.GetComponentsInChildren<Renderer>(true));
			}
			for(int i = 0; i < renderers.Count; i++)
			{
				SkinnedMeshRenderer sr = renderers[i] as SkinnedMeshRenderer;
				if(sr != null)
				{
					sr.updateWhenOffscreen = true;
				}
				renderers[i].receiveShadows = false;
				renderers[i].lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
				renderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
				renderers[i].reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
			}
			leftHandAttachNode = divaPrefab_.transform.Find("joint_root/hips/spine/spine1/spine2/shoulder_l/arm_l/forearm_l/hand_l/MIKE_L_attach");
			rightHandAttachNode = divaPrefab_.transform.Find("joint_root/hips/spine/spine1/spine2/shoulder_r/arm_r/forearm_r/hand_r/MIKE_R_attach");
			animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		}

		//// RVA: 0x1BF416C Offset: 0x1BF416C VA: 0x1BF416C Slot: 6
		protected virtual void SetupCustomComponents(DivaResource resource)
		{
			return;
		}

		//// RVA: 0x1BF348C Offset: 0x1BF348C VA: 0x1BF348C
		private void SetupPerformanceChangableObject()
		{
			Renderer[] renderers = divaPrefab_.transform.Find("mesh_root").GetComponentsInChildren<Renderer>();
			if(useQualitySetting)
			{
				if(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PKEMELMMEKM_GetDivaQuality())
				{
					TodoLogger.Log(0, "Diva Low quality 3d setyp");
				}
			}
			m_valkyrieShaderControlelr.Initialize(renderers, null);
			BoneSpringController.PerformanceMode boneQualityMode = BoneSpringController.PerformanceMode.High;
			if(useQualitySetting)
			{
				if(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.INPHNKJPJFN())
				{
					boneQualityMode = BoneSpringController.PerformanceMode.Low;
				}
			}
			if(boneSpringController != null)
			{
				boneSpringController.Initialize(boneQualityMode);
			}
		}

		//// RVA: 0x1BF4170 Offset: 0x1BF4170 VA: 0x1BF4170
		protected void SetActiveFoundChildren(Transform t, string targetName, bool active)
		{
			for(int i = 0; i < t.childCount; i++)
			{
				if(t.GetChild(i).name.Contains(targetName))
				{
					t.GetChild(i).gameObject.SetActive(active);
				}
				else
				{
					SetActiveFoundChildren(t.GetChild(i), targetName, active);
				}
			}
		}

		//// RVA: 0x1BF4288 Offset: 0x1BF4288 VA: 0x1BF4288
		public void VisibleRendererComponent(bool enable)
		{
			animator.enabled = enable;
			foreach(var r in renderers)
			{
				r.enabled = enable;
			}
			adjustScaler.enabled = enable;
			SetActiveEffect(enable);
			SetActiveWind(enable);
		}

		//// RVA: 0x1BF466C Offset: 0x1BF466C VA: 0x1BF466C
		//public void ChangeMaterial(DivaResource outerResource, int colorId) { }

		//// RVA: 0x1BF4670 Offset: 0x1BF4670 VA: 0x1BF4670
		public void SetEnableRenderer(bool enable)
		{
			foreach(var r in renderers)
			{
				if(r != null)
				{
					r.enabled = enable;
				}
			}
			SetActiveEffect(enable);
			SetActiveWind(enable);
		}

		//// RVA: 0x1BF4828 Offset: 0x1BF4828 VA: 0x1BF4828
		public void Release()
		{
			animator = null;
			if(facialBlendAnimMediator != null)
			{
				facialBlendAnimMediator.Release();
			}
			if(divaPrefab_ != null)
			{
				Destroy(divaPrefab_);
				divaPrefab_ = null;
			}
			DestroyEffect();
			DestroyWind();
		}

		//// RVA: 0x1BF0150 Offset: 0x1BF0150 VA: 0x1BF0150
		public void SetActiveMikePrefab(bool active)
		{
			if(mikePrefab == null)
				return;
			mikePrefab.SetActive(active);
		}

		//// RVA: 0x1BF497C Offset: 0x1BF497C VA: 0x1BF497C
		public void AdjustHight(float offset)
		{
			if(mikeStandObject != null)
			{
				mikeStandObject.AdjustHight(offset);
			}
		}

		//// RVA: 0x1BF023C Offset: 0x1BF023C VA: 0x1BF023C
		public void AttachMikeToLeftHand()
		{
			if(leftHandAttachNode == null)
				return;
			if(mikePrefab == null)
				return;
			SetActiveMikePrefab(true);
			mikePrefab.transform.SetParent(leftHandAttachNode, false);
		}

		//// RVA: 0x1BF039C Offset: 0x1BF039C VA: 0x1BF039C
		public void AttachMikeToRightHand()
		{
			if(rightHandAttachNode == null)
				return;
			if(mikePrefab == null)
				return;
			SetActiveMikePrefab(true);
			mikePrefab.transform.SetParent(rightHandAttachNode, false);
		}

		//// RVA: 0x1BF04FC Offset: 0x1BF04FC VA: 0x1BF04FC
		public void AttachToMikeStand()
		{
			if(mikeStandObject == null)
				return;
			if(mikePrefab == null)
				return;
			SetActiveMikePrefab(true);
			mikeStandObject.AttachMike(mikePrefab);
		}

		//// RVA: 0x1BEBB98 Offset: 0x1BEBB98 VA: 0x1BEBB98
		public void AttachMikeToObject(Transform a_transform)
		{
			if(mikePrefab == null)
				return;
			SetActiveMikePrefab(true);
			mikePrefab.transform.SetParent(a_transform, false);
		}

		//// RVA: 0x1BF4A38 Offset: 0x1BF4A38 VA: 0x1BF4A38
		public void LockBoneSpring(int a_index = 0)
		{
			if(boneSpringController != null)
			{
				boneSpringController.Lock(a_index);
			}
		}

		//// RVA: 0x1BF4AF4 Offset: 0x1BF4AF4 VA: 0x1BF4AF4
		public void UnlockBoneSpring(bool a_fix = false, int a_index = 0)
		{
			if(!a_fix)
			{
				this.StartCoroutineWatched(WaitUnlockBoneSpring(a_index));
				return;
			}
			if(boneSpringController != null)
			{
				if (!boneSpringController.IsLock(a_index))
					return;
				boneSpringController.Unlock(a_index);
				boneSpringController.RequestInitialize();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7364BC Offset: 0x7364BC VA: 0x7364BC
		//// RVA: 0x1BF4C2C Offset: 0x1BF4C2C VA: 0x1BF4C2C
		protected IEnumerator WaitUnlockBoneSpring(int a_index = 0)
		{
			//0x1BF7B84
			isWaitUnlockBoneSpring = true;
			yield return new WaitForSeconds(0.1f);
			if (boneSpringController != null)
			{
				boneSpringController.Unlock(a_index);
				boneSpringController.RequestInitialize();
			}
			isWaitUnlockBoneSpring = false;
		}

		//// RVA: 0x1BF4CF4 Offset: 0x1BF4CF4 VA: 0x1BF4CF4
		public void WaitLockBoneSpring(int a_index = 0, float a_seconds = 0.05f)
		{
			if (m_coroutine_wait_lock != null)
				this.StopCoroutineWatched(m_coroutine_wait_lock);
			if (!gameObject.activeSelf)
				return;
			m_coroutine_wait_lock = this.StartCoroutineWatched(CoroutineWaitLockBoneSpring(a_index, a_seconds));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x736534 Offset: 0x736534 VA: 0x736534
		//// RVA: 0x1BF4D7C Offset: 0x1BF4D7C VA: 0x1BF4D7C
		public IEnumerator CoroutineWaitLockBoneSpring(int a_index = 0, float a_seconds = 0.1f)
		{
			//0x1BF7988
			if(!m_is_wait_lock)
			{
				m_is_wait_lock = true;
				yield return new WaitForSeconds(a_seconds);
				if(boneSpringController != null)
				{
					boneSpringController.Lock(a_index);
				}
				m_coroutine_wait_lock = null;
				m_is_wait_lock = false;
			}
		}

		//// RVA: 0x1BF4E68 Offset: 0x1BF4E68 VA: 0x1BF4E68
		public void AwakenAuraOn()
		{
			if(awakenAuraSwitcher != null)
			{
				awakenAuraSwitcher.Switch(true);
			}
		}

		//// RVA: 0x1BF40B4 Offset: 0x1BF40B4 VA: 0x1BF40B4
		public void AwakenAuraOff()
		{
			if(awakenAuraSwitcher != null)
			{
				awakenAuraSwitcher.Switch(false);
			}
		}

		//// RVA: 0x1BF4F20 Offset: 0x1BF4F20 VA: 0x1BF4F20
		public void Stop()
		{
			if (animator != null)
				ChangeAnimationTime(0);
		}

		//// RVA: 0x1BF4FDC Offset: 0x1BF4FDC VA: 0x1BF4FDC
		public void Pause()
		{
			if(animator != null)
			{
				animator.speed = 0;
				facialBlendAnimMediator.selfAnimator.speed = 0;
				if(m_boneSpringAnim != null && m_boneSpringAnim.animator != null)
				{
					m_boneSpringAnim.animator.speed = 0;
				}
				if(mikeStandObject != null)
				{
					mikeStandObject.animator.speed = 0;
				}
				foreach(var a in m_list_pause_animator)
				{
					a.speed = 0;
				}
				for(int i = 0; i < m_list_pause_particle.Count; i++)
				{
					if(m_list_pause_particle[i].isPlaying)
					{
						m_list_pause_particle[i].Pause();
					}
				}
				m_valkyrieShaderControlelr.Pause(true);
			}
		}

		//// RVA: 0x1BF5474 Offset: 0x1BF5474 VA: 0x1BF5474
		public void Resume()
		{
			if(animator != null)
			{
				animator.speed = 1;
				facialBlendAnimMediator.selfAnimator.speed = 1;
				if(m_boneSpringAnim != null && m_boneSpringAnim.animator != null)
				{
					m_boneSpringAnim.animator.speed = 1;
				}
				if(mikeStandObject != null)
				{
					mikeStandObject.animator.speed = 1;
				}
				foreach(var a in m_list_pause_animator)
				{
					a.speed = 1;
				}
				for(int i = 0; i < m_list_pause_particle.Count; i++)
				{
					if(m_list_pause_particle[i].isPaused)
					{
						m_list_pause_particle[i].Play();
					}
				}
				m_valkyrieShaderControlelr.Pause(false);
			}
		}

		//// RVA: 0x1BF590C Offset: 0x1BF590C VA: 0x1BF590C Slot: 7
		public virtual void ChangeAnimationTime(double time)
		{
			if (animator != null)
			{
				if (time < 0) time = 0;
				animator.speed = 1;
				if (PlayableExtensions.IsValid<Playable>(animator.playableGraph.GetRootPlayable(0)))
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
				facialBlendAnimMediator.SetTime(time);
				if(m_boneSpringAnim != null)
				{
					if(m_boneSpringAnim.animator != null)
					{
						m_boneSpringAnim.SetTime(time);
					}
				}
				if(mikeStandObject != null)
				{
					mikeStandObject.SetTime(time);
				}
			}

		}

		//// RVA: 0x1BF5C50 Offset: 0x1BF5C50 VA: 0x1BF5C50
		protected void Anim_Play(string stateName, double time = 0)
		{
			animator.Play(stateName, 0);
			facialBlendAnimMediator.selfAnimator.Play(stateName, 0);
			facialBlendAnimMediator.selfAnimator.Play(stateName, 1);
			if(m_boneSpringAnim != null && m_boneSpringAnim.animator != null)
			{
				m_boneSpringAnim.animator.Play(stateName);
			}
			if(mikeStandObject != null)
			{
				mikeStandObject.animator.Play(stateName, 0);
			}
		}

		//// RVA: 0x1BF5ED0 Offset: 0x1BF5ED0 VA: 0x1BF5ED0
		//protected void Anim_CrossFadeInFixedTime(string stateName, float fixedTime = 0) { }

		//// RVA: 0x1BF6188 Offset: 0x1BF6188 VA: 0x1BF6188
		protected void Anim_SetBool(string name, bool value)
		{
			animator.SetBool(name, value);
			facialBlendAnimMediator.selfAnimator.SetBool(name, value);
			if (m_boneSpringAnim != null && m_boneSpringAnim.animator != null)
			{
				m_boneSpringAnim.animator.SetBool(name, value);
			}
			if (mikeStandObject != null)
			{
				mikeStandObject.animator.SetBool(name, value);
			}
		}

		//// RVA: 0x1BF63C8 Offset: 0x1BF63C8 VA: 0x1BF63C8
		protected void Anim_SetInteger(string name, int value)
		{
			animator.SetInteger(name, value);
			facialBlendAnimMediator.selfAnimator.SetInteger(name, value);
			if(m_boneSpringAnim != null && m_boneSpringAnim.animator != null)
			{
				m_boneSpringAnim.animator.SetInteger(name, value);
			}
			if(mikeStandObject != null)
			{
				mikeStandObject.animator.SetInteger(name, value);
			}
		}

		//// RVA: 0x1BF6608 Offset: 0x1BF6608 VA: 0x1BF6608
		protected void Anim_SetTrigger(string name)
		{
			animator.SetTrigger(name);
			facialBlendAnimMediator.selfAnimator.SetTrigger(name);
			if (m_boneSpringAnim != null && m_boneSpringAnim.animator != null)
			{
				m_boneSpringAnim.animator.SetTrigger(name);
			}
			if (mikeStandObject != null)
			{
				mikeStandObject.animator.SetTrigger(name);
			}
		}

		//// RVA: 0x1BF6834 Offset: 0x1BF6834 VA: 0x1BF6834
		//protected void Anim_ResetTrigger(string name) { }

		//// RVA: 0x1BF6A60 Offset: 0x1BF6A60 VA: 0x1BF6A60
		//protected void Anim_SetFloat(string name, float value) { }
		
		//// RVA: 0x1BF6ECC Offset: 0x1BF6ECC VA: 0x1BF6ECC Slot: 8
		protected virtual void SetupEffectObject(List<GameObject> a_effect)
		{
			DestroyEffect();
			if(a_effect != null)
			{
				effectObject = new List<GameObject>();
				for (int i = 0; i < a_effect.Count; i++)
				{
					GameObject effect = Instantiate(a_effect[i]);
					effect.transform.SetParent(transform, false);
					GameObjectFollowingTwoPos a = effect.GetComponent<GameObjectFollowingTwoPos>();
					if(a != null)
					{
						a.Initialize(divaPrefab_.transform);
					}
					GameObjectFollowingAnyPos b = effect.GetComponent<GameObjectFollowingAnyPos>();
					if(b != null)
					{
						b.Initialize(divaPrefab_.transform);
					}
					ParticleSystem[] particles = effect.GetComponentsInChildren<ParticleSystem>();
					if(particles != null)
					{
						m_list_pause_particle.AddRange(particles);
					}
					Animator[] animators = effect.GetComponentsInChildren<Animator>();
					if(animators != null)
					{
						m_list_pause_animator.AddRange(animators);
					}
					effect.SetActive(false);
					effectObject.Add(effect);
				}
			}
		}

		//// RVA: 0x1BF3ACC Offset: 0x1BF3ACC VA: 0x1BF3ACC
		protected void DestroyEffect()
		{
			if(effectObject != null)
			{
				for(int i = 0; i < effectObject.Count; i++)
				{
					Destroy(effectObject[i]);
				}
				effectObject.Clear();
			}
		}

		//// RVA: 0x1BF444C Offset: 0x1BF444C VA: 0x1BF444C
		public void SetActiveEffect(bool a_active)
		{
			if(!effectEnable && a_active)
			{
				return;
			}
			if (effectObject != null)
			{
				for (int i = 0; i < effectObject.Count; i++)
				{
					effectObject[i].SetActive(a_active);
				}
			}
		}

		//// RVA: 0x1BF7314 Offset: 0x1BF7314 VA: 0x1BF7314
		public void SetEnableEffect(bool a_enable, bool a_save_ignore = false)
		{
			if(!a_save_ignore)
			{
				effectEnable = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MDMDEAFFIMB_IsDivaEffect != 1 && a_enable;
			}
			else
			{
				effectEnable = a_enable;
			}
			if(effectEnable)
			{
				if (renderers.Count < 1)
					return;
				SetActiveEffect(renderers[0].enabled);
			}
			else
			{
				SetActiveEffect(false);
			}
		}

		//// RVA: 0x1BF74CC Offset: 0x1BF74CC VA: 0x1BF74CC
		public bool GetEnableEffect()
		{
			return effectEnable;
		}

		//// RVA: 0x1BF74D4 Offset: 0x1BF74D4 VA: 0x1BF74D4 Slot: 9
		protected virtual void SetupWind(GameObject a_prefab_wind, DivaResource.BoneSpringResource a_resource)
		{
			DestroyWind();
			if(a_prefab_wind != null)
			{
				GameObject go = Instantiate(a_prefab_wind);
				go.transform.SetParent(transform, false);
				windObject = go.GetComponent<StageExtensionWindCtrlForMenu>();
				windObject.Initialize(this, a_resource);
			}
		}

		//// RVA: 0x1BF3BFC Offset: 0x1BF3BFC VA: 0x1BF3BFC
		protected void DestroyWind()
		{
			if(windObject != null)
			{
				Destroy(windObject.gameObject);
				windObject = null;
			}
		}

		//// RVA: 0x1BF4550 Offset: 0x1BF4550 VA: 0x1BF4550
		public void SetActiveWind(bool a_active)
		{
			if(!windEnable && a_active)
			{
				return;
			}
			if (windObject == null)
				return;
			if(!a_active)
				windObject.ResetBoneSpringController();
			windObject.gameObject.SetActive(a_active);
		}

		//// RVA: 0x1BF767C Offset: 0x1BF767C VA: 0x1BF767C
		public void SetEnableWind(bool a_enable, bool a_save_ignore = false)
		{
			if (!a_save_ignore)
			{
				windEnable = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MDMDEAFFIMB_IsDivaEffect != 1 && a_enable;
			}
			else
			{
				windEnable = a_enable;
			}
			if(windEnable)
			{
				if (renderers.Count < 1)
					return;
				SetActiveWind(renderers[0].enabled);
			}
			else
			{
				SetActiveWind(false);
			}
		}

		//// RVA: 0x1BF7834 Offset: 0x1BF7834 VA: 0x1BF7834
		public bool GetEnableWind()
		{
			return windEnable;
		}
	}
}
