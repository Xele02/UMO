using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class FacialBlendAnimMediatorBase : MonoBehaviour
	{
		private enum FaceBlendLayer
		{
			eye_close = 0,
			exp_normal = 1,
			exp_joy = 2,
			exp_laugh = 3,
			exp_smile = 4,
			sp1 = 5,
			sp2 = 6,
			sp3 = 7,
			sp4 = 8,
			sp5 = 9,
			sp6 = 10,
			sp7 = 11,
			sp8 = 12,
			sp9 = 13,
			sp10 = 14,
			Num = 15,
		}

		private enum MouthBlendLayer
		{
			lip_A = 0,
			lip_I = 1,
			lip_U = 2,
			lip_E = 3,
			lip_O = 4,
			lip_N = 5,
			lip_bigA = 6,
			lip_bigO = 7,
			exp_normal = 8,
			exp_joy = 9,
			exp_laugh = 10,
			exp_smile = 11,
			sp1 = 12,
			sp2 = 13,
			sp3 = 14,
			sp4 = 15,
			sp5 = 16,
			sp6 = 17,
			sp7 = 18,
			sp8 = 19,
			Num = 20,
		}

		private Transform[] faceBlendTransforms; // 0xC
		private int[] faceBlendLayerIndex; // 0x10
		public static string[] faceBlendLayerName = new string[15] { "face_eye_close", "face_exp_normal", "face_exp_joy", "face_exp_laugh", "face_exp_smile",
				"face_sp1", "face_sp2", "face_sp3", "face_sp4", "face_sp5", "face_sp6", "face_sp7", "face_sp8", "face_sp9", "face_sp10"}; // 0x0
		private Transform[] mouthBlendTransforms; // 0x14
		private int[] mouthBlendLayerIndex; // 0x18
		public static string[] mouthBlendLayerName = new string[20] { "mouth_lip_A", "mouth_lip_I", "mouth_lip_U", "mouth_lip_E", "mouth_lip_O", "mouth_lip_N",
			"mouth_lip_bigA", "mouth_lip_bigO", "mouth_exp_normal", "mouth_exp_joy", "mouth_exp_laugh", "mouth_exp_smile", "mouth_sp1", "mouth_sp2", "mouth_sp3",
			"mouth_sp4", "mouth_sp5", "mouth_sp6", "mouth_sp7", "mouth_sp8"}; // 0x4
		private Transform cheekTransforms; // 0x1C
		public static string cheekLayerName = "face_cheek"; // 0x8
		public Transform eyeLookUTransforms; // 0x20
		public Transform eyeLookVTransforms; // 0x24
		public static readonly string eyeLookULayerName = "face_look_u"; // 0xC
		public static readonly string eyeLookVLayerName = "face_look_v"; // 0x10
		[SerializeField]
		private SkinnedMeshRenderer eyeMeshRenderer; // 0x28
		[SerializeField]
		private SkinnedMeshRenderer cheekMeshRenderer; // 0x2C
		private Animator targetAnimator; // 0x30
		private Animator selfAnimator_; // 0x34
		protected AnimatorOverrideController overrideController; // 0x38
		private bool isSetup; // 0x50
		private Vector2 eyeMeshUvRate = Vector2.one; // 0x54
		private Vector2 m_delayedEyeTexOffset = Vector2.zero; // 0x5C
		private float m_delayedCheekAlpha; // 0x64

		public Animator selfAnimator { get { return selfAnimator_; } private set { selfAnimator_ = value; } } //0x1C10558 0x1C10560
		public double musicFaceClipLength { get; protected set; } // 0x40
		public double musicMouthClipLength { get; protected set; } // 0x48

		// RVA: 0x1C105A0 Offset: 0x1C105A0 VA: 0x1C105A0
		private void Awake()
		{
			musicFaceClipLength = -1;
			musicMouthClipLength = -1;
			faceBlendTransforms = new Transform[15];
			faceBlendLayerIndex = new int[15];
			mouthBlendTransforms = new Transform[20];
			mouthBlendLayerIndex = new int[20];
			for(int i = 0; i < faceBlendLayerName.Length; i++)
			{
				faceBlendTransforms[i] = transform.Find(faceBlendLayerName[i]);
			}
			for(int i = 0; i < mouthBlendLayerName.Length; i++)
			{
				mouthBlendTransforms[i] = transform.Find(mouthBlendLayerName[i]);
			}
			cheekTransforms = transform.Find(cheekLayerName);
			eyeLookUTransforms = transform.Find(eyeLookULayerName);
			eyeLookVTransforms = transform.Find(eyeLookVLayerName);
			selfAnimator_ = GetComponent<Animator>();
		}

		// RVA: 0x1C10ABC Offset: 0x1C10ABC VA: 0x1C10ABC
		private void Start()
		{
			return;
		}

		//// RVA: 0x1C10AC0 Offset: 0x1C10AC0 VA: 0x1C10AC0
		public void Release()
		{
			isSetup = false;
		}

		//// RVA: 0x1C10ACC Offset: 0x1C10ACC VA: 0x1C10ACC
		public void Initialize(DivaResource resource, GameObject divaPrefab)
		{
			for(int i = 0; i < faceBlendLayerName.Length; i++)
			{
				faceBlendTransforms[i].localPosition = new Vector3(0, 0, 0);
			}
			for(int i = 0; i < mouthBlendLayerName.Length; i++)
			{
				mouthBlendTransforms[i].localPosition = new Vector3(0, 0, 0);
			}
			Setup(divaPrefab);
			selfAnimator_.runtimeAnimatorController = resource.facialAnimatorController;
			overrideController = new AnimatorOverrideController();
			overrideController.name = "med_override_controller";
			overrideController.runtimeAnimatorController = selfAnimator_.runtimeAnimatorController;
			if(resource.IsSetupAuto)
			{
				OverrideCustomAnimation(resource);
			}
			selfAnimator_.runtimeAnimatorController = overrideController;
		}

		//// RVA: 0x1C1130C Offset: 0x1C1130C VA: 0x1C1130C
		public void SetEyeMeshUvRate(Vector2 rate)
		{
			eyeMeshUvRate = rate;
		}

		//// RVA: 0x1C11318 Offset: 0x1C11318 VA: 0x1C11318 Slot: 4
		protected virtual void OverrideCustomAnimation(DivaResource resource)
		{
			return;
		}

		//// RVA: 0x1C10E44 Offset: 0x1C10E44 VA: 0x1C10E44
		protected void Setup(GameObject divaPrefab)
		{
			SkinnedMeshRenderer[] smrs = divaPrefab.GetComponentsInChildren<SkinnedMeshRenderer>();
			for(int i = 0; i < smrs.Length; i++)
			{
				if(smrs[i].name == "eye")
				{
					eyeMeshRenderer = smrs[i];
				}
				if(smrs[i].name == "cheek")
				{
					cheekMeshRenderer = smrs[i];
				}
			}
			targetAnimator = divaPrefab.GetComponentInChildren<Animator>();
			for(int i = 0; i < mouthBlendLayerName.Length; i++)
			{
				mouthBlendLayerIndex[i] = targetAnimator.GetLayerIndex(mouthBlendLayerName[i]);
			}
			for(int i = 0; i < faceBlendLayerName.Length; i++)
			{
				faceBlendLayerIndex[i] = targetAnimator.GetLayerIndex(faceBlendLayerName[i]);
			}
			isSetup = true;
		}

		//// RVA: 0x1C1131C Offset: 0x1C1131C VA: 0x1C1131C
		public void ResetReference()
		{
			eyeMeshRenderer = null;
			cheekMeshRenderer = null;
			targetAnimator = null;
			isSetup = false;
		}

		//// RVA: 0x1C11334 Offset: 0x1C11334 VA: 0x1C11334
		public void SetTime(double time)
		{
			selfAnimator_.speed = 1;
			if (PlayableExtensions.IsValid<Playable>(selfAnimator_.playableGraph.GetRootPlayable(0)))
			{
				selfAnimator_.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(selfAnimator_.playableGraph.GetRootPlayable(0))));
			}
		}

		//// RVA: 0x1C1149C Offset: 0x1C1149C VA: 0x1C1149C
		private void LateUpdate()
		{
			if(!isSetup)
				return;
			UpdateFaceBlend();
			UpdateMouthBlend();
			UpdateEyeLook();
			UpdateCheekAlpha();
		}

		//// RVA: 0x1C114D8 Offset: 0x1C114D8 VA: 0x1C114D8
		private void UpdateFaceBlend()
		{
			float val = 0;
			for(int i = 0; i < 15; i++)
			{
				val += faceBlendTransforms[i].localPosition.x;
			}
			if(val <= 0)
				val = 1;
			for(int i = 0; i < 15; i++)
			{
				if(faceBlendLayerIndex[i] > -1)
				{
					targetAnimator.SetLayerWeight(faceBlendLayerIndex[i], faceBlendTransforms[i].localPosition.x / val);
				}
			}
		}

		//// RVA: 0x1C11698 Offset: 0x1C11698 VA: 0x1C11698
		private void UpdateMouthBlend()
		{
			float val = 0;
			for(int i = 0; i < 20; i++)
			{
				val += mouthBlendTransforms[i].localPosition.x;
			}
			if(val == 0)
				val = 1;
			for(int i = 0; i < 20; i++)
			{
				if(mouthBlendLayerIndex[i] > -1)
				{
					targetAnimator.SetLayerWeight(mouthBlendLayerIndex[i], mouthBlendTransforms[i].localPosition.x / val);
				}
			}
		}

		//// RVA: 0x1C11858 Offset: 0x1C11858 VA: 0x1C11858
		private void UpdateEyeLook()
		{
			if(eyeMeshRenderer != null && eyeLookUTransforms != null && eyeLookVTransforms != null)
			{
				eyeMeshRenderer.material.mainTextureOffset = m_delayedEyeTexOffset;
				m_delayedEyeTexOffset = MakeEyeMeshUvOffset();
			}
		}

		//// RVA: 0x1C119EC Offset: 0x1C119EC VA: 0x1C119EC
		private void UpdateCheekAlpha()
		{
			if(cheekMeshRenderer != null && cheekTransforms != null)
			{
				Color col = cheekMeshRenderer.material.color;
				col.a = m_delayedCheekAlpha;
				cheekMeshRenderer.material.color = col;
				m_delayedCheekAlpha = cheekTransforms.localPosition.x;
			}
		}

		//// RVA: 0x1C11BA0 Offset: 0x1C11BA0 VA: 0x1C11BA0
		private Vector2 MakeEyeMeshUvOffset()
		{
			return new Vector2(eyeLookUTransforms.localPosition.x * eyeMeshUvRate.x, 
								eyeLookVTransforms.localPosition.y * eyeMeshUvRate.y);
		}

		//// RVA: 0x1C11C44 Offset: 0x1C11C44 VA: 0x1C11C44
		//public void OverrideAnimation(ref DivaResource.MotionOverrideClipKeyResource resource) { }

		//// RVA: 0x1C11CB8 Offset: 0x1C11CB8 VA: 0x1C11CB8
		public void OverrideAnimations(List<DivaResource.MotionOverrideClipKeyResource> resource)
		{
			for (int i = 0; i < resource.Count; i++)
			{
				overrideController[resource[i].face.name] = resource[i].face.clip;
				overrideController[resource[i].mouth.name] = resource[i].mouth.clip;
			}
		}

		//// RVA: 0x1C11E8C Offset: 0x1C11E8C VA: 0x1C11E8C
		public void OverrideAnimations(DivaResource.MotionOverrideSingleResource resource)
		{
			if (resource.target != DivaResource.MotionOverrideSingleResource.Target.Face && resource.target != DivaResource.MotionOverrideSingleResource.Target.Mouth)
				return;
			overrideController[resource.name] = resource.clip;
		}
	}
}
