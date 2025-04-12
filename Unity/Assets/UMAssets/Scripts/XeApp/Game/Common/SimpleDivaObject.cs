using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class SimpleDivaObject : DivaObject
	{
		protected override bool useQualitySetting { get { return false; } } //0x1392710
		public bool IsInTransition { get { return animator.IsInTransition(0); } } //0x1392718

		// RVA: 0x1392748 Offset: 0x1392748 VA: 0x1392748 Slot: 6
		protected override void SetupCustomComponents(DivaResource resource)
		{
			facialBlendAnimMediator = GetComponentInChildren<SimpleFacialBlendAnimMediator>();
			facialBlendAnimMediator.Initialize(resource, divaPrefab);
			facialBlendAnimMediator.SetEyeMeshUvRate(ObjParam.GetEyeMeshUvRate(divaId));
			if(boneSpringController != null)
			{
				boneSpringController.Lock(0);
			}
			SetActiveFoundChildren(divaPrefab.transform, "game", false);
			Renderer[] rs = divaPrefab.transform.Find("mesh_root").GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				Material[] ms = rs[i].materials;
				for(int j = 0; j < ms.Length; j++)
				{
					if (ms[j].shader.name == "MCRS/Diva/Opaque_Outline_High")
					{
						ms[j].SetFloat("_EdgeThickness", 35);
					}
				}
			}
		}

		// RVA: 0x1392B2C Offset: 0x1392B2C VA: 0x1392B2C Slot: 8
		protected override void SetupEffectObject(List<GameObject> a_effect)
		{
			base.SetupEffectObject(a_effect);
			SetEnableEffect(true, false);
		}

		// RVA: 0x1392B58 Offset: 0x1392B58 VA: 0x1392B58 Slot: 9
		protected override void SetupWind(GameObject a_wind, DivaResource.BoneSpringResource a_resource)
		{
			base.SetupWind(a_wind, a_resource);
			SetEnableWind(false, false);
		}

		//// RVA: 0x1392B84 Offset: 0x1392B84 VA: 0x1392B84
		public void setAdjuster()
		{
			if(adjustScaler == null)
			{
				Transform t = divaPrefab.transform.Find("joint_root/hips");
				if (t != null)
				{
					adjustScaler = t.gameObject.AddComponent<ObjectPositionAdjuster>();
				}
			}
			if(adjustScaler != null)
			{
				adjustScaler.Initialize(ObjParam.GetHipScaleFactor(divaId), true, true, true);
			}
		}

		//// RVA: 0x1392DC4 Offset: 0x1392DC4 VA: 0x1392DC4
		public void Play(string stateName)
		{
			Anim_Play(stateName, 0);
			animator.speed = 1;
			this.StartCoroutineWatched(WaitUnlockBoneSpring(0));
		}

		//// RVA: 0x1392E38 Offset: 0x1392E38 VA: 0x1392E38
		//public void Play(string BodyStateName, string faceStateName, double time) { }

		//// RVA: 0x1392F00 Offset: 0x1392F00 VA: 0x1392F00
		public void PlayFacialAnime(string faceStateName)
		{
			facialBlendAnimMediator.selfAnimator.Play(faceStateName);
		}

		//// RVA: 0x1392F54 Offset: 0x1392F54 VA: 0x1392F54
		public void CrossFadeIdle(string IdleStateName)
		{
			animator.CrossFade(IdleStateName, 0.07f);
			facialBlendAnimMediator.selfAnimator.Play(IdleStateName, 0);
			facialBlendAnimMediator.selfAnimator.Play(IdleStateName, 1);
		}

		//// RVA: 0x1393024 Offset: 0x1393024 VA: 0x1393024
		public void CrossFadeIdle(string IdleStateName, float bodyTime)
		{
			animator.CrossFade(IdleStateName, bodyTime);
			facialBlendAnimMediator.selfAnimator.Play(IdleStateName, 0);
			facialBlendAnimMediator.selfAnimator.Play(IdleStateName, 1);
		}

		//// RVA: 0x13930F4 Offset: 0x13930F4 VA: 0x13930F4
		//public void CrossFadeFixedIdle(string IdleStateName, float bodyTime) { }

		//// RVA: 0x13931C4 Offset: 0x13931C4 VA: 0x13931C4
		public void ReleaseMediator()
		{
			if(facialBlendAnimMediator != null)
			{
				facialBlendAnimMediator.ResetReference();
			}
		}

		//// RVA: 0x1393278 Offset: 0x1393278 VA: 0x1393278
		public int GetBodyHash()
		{
			return animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
		}

		//// RVA: 0x13932F4 Offset: 0x13932F4 VA: 0x13932F4
		//public int GetFaceHash() { }

		//// RVA: 0x1393390 Offset: 0x1393390 VA: 0x1393390
		public int GetMouthHash()
		{
			return facialBlendAnimMediator.selfAnimator.GetCurrentAnimatorStateInfo(1).shortNameHash;
		}

		//// RVA: 0x139342C Offset: 0x139342C VA: 0x139342C
		public new void Anim_SetTrigger(string name)
		{
			base.Anim_SetTrigger(name);
		}

		//// RVA: 0x1393434 Offset: 0x1393434 VA: 0x1393434
		//public void FacialAnim_SetTrigger(string name) { }

		//// RVA: 0x1393488 Offset: 0x1393488 VA: 0x1393488
		//public void Anim_ResetTrigger(string name) { }

		//// RVA: 0x1393490 Offset: 0x1393490 VA: 0x1393490
		//public void FacialAnim_ResetTrigger(string name) { }

		//// RVA: 0x13934E4 Offset: 0x13934E4 VA: 0x13934E4
		public new void Anim_SetInteger(string name, int value)
		{
			base.Anim_SetInteger(name, value);
		}

		//// RVA: 0x13934EC Offset: 0x13934EC VA: 0x13934EC
		public void FacialAnim_SetInteger(string name, int value)
		{
			facialBlendAnimMediator.selfAnimator.SetInteger(name, value);
		}

		//// RVA: 0x1393548 Offset: 0x1393548 VA: 0x1393548
		public new void Anim_SetBool(string name, bool value)
		{
			base.Anim_SetBool(name, value);
		}

		//// RVA: 0x1393550 Offset: 0x1393550 VA: 0x1393550
		//public void FacialAnim_SetBool(string name, bool value) { }
	}
}
