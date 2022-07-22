using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;
using XeSys;

namespace XeApp.Game.Common
{
	public class MusicCameraObject : MonoBehaviour
	{
		public float[] CameraScaleFactor = new float[10] { 0.9628f, 1.0391f, 1.0495f, 0.9912f, 0.9109f, 0.98f, 1.0642f, 0.964f, 1, 1 }; // 0xC
		private Animator animator; // 0x10
		public StageObject stageObject; // 0x14
		public GameDivaObject divaObject; // 0x18
		private double musicClipLength = -1; // 0x20
		private double cutinBaseTime = -1; // 0x28
		private double cutinEndTime = -1; // 0x30
		private bool resetCutinBaseTime; // 0x38
		private bool isPlayingCutin; // 0x39
		private List<int> divaIndexList; // 0x3C
		private int targetId = -1; // 0x40
		private int nextTargetId = -1; // 0x44
		private Transform divaHeighOffsetTransform; // 0x48
		private bool m_is_solo = true; // 0x4C
		private bool m_is_adjustXZ; // 0x4D

		// // RVA: 0xAE3590 Offset: 0xAE3590 VA: 0xAE3590
		// public void ResetAnimationPreview() { }

		// // RVA: 0xAE3594 Offset: 0xAE3594 VA: 0xAE3594
		private void Awake()
		{
			return;
		}

		// // RVA: 0xAE3598 Offset: 0xAE3598 VA: 0xAE3598
		public void Initialize(MusicCameraResource resource, List<int> divaIdList, bool isAdjustXZ = false)
		{
			animator = GetComponent<Animator>();
			animator.speed = 0;
			animator.runtimeAnimatorController = resource.animator;
			AnimatorOverrideController overrideCtrl = new AnimatorOverrideController();
			overrideCtrl.runtimeAnimatorController = animator.runtimeAnimatorController;
			overrideCtrl["game_cmn_cam_music"] = resource.clip;
			musicClipLength = resource.clip.length;
			animator.runtimeAnimatorController = overrideCtrl;
			animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.Manual);
			if(resource.m_param != null)
			{
				for(int i = 0; i < CameraScaleFactor.Length; i++)
				{
					if(i < resource.m_param.m_listDivaScale.Count)
					{
						CameraScaleFactor[i] = resource.m_param.m_listDivaScale[i];
					}
				}
			}
			divaHeighOffsetTransform = transform.Find("camera_offset");
			divaHeighOffsetTransform.localPosition = new Vector3(1, -1, 0);
			divaIndexList = divaIdList;
			m_is_adjustXZ = isAdjustXZ;
			m_is_solo = divaIdList.Count == 1;
			DivaHeightOffset(m_is_solo, isAdjustXZ);
			animator.Rebind();
		}

		// // RVA: 0xAE3EB8 Offset: 0xAE3EB8 VA: 0xAE3EB8
		public void OverrideCutinClip(MusicCameraCutinResource resource, int resourceId)
		{
			animator = GetComponent<Animator>();
			animator.speed = 0;
			AnimatorOverrideController overrideCtrl = animator.runtimeAnimatorController as AnimatorOverrideController;
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < resource.cutinClips.Length; i++)
			{
				if(resource.cutinClips[i] != null)
				{
					if(resourceId == 0)
					{
						str.SetFormat("game_cmn_cam_cut_{0:D2}", i + 1);
					}
					else
					{
						str.SetFormat("game_cmn_cam_cut_{0:D2}_{1}", i + 1, resourceId + 1);
					}
					overrideCtrl[str.ToString()] = resource.cutinClips[i];
				}
			}
			animator.Rebind();
		}

		// // RVA: 0xAE4230 Offset: 0xAE4230 VA: 0xAE4230
		private void LateUpdate()
		{
			if(animator != null)
			{
				if(divaHeighOffsetTransform != null)
				{
					DivaHeightOffset(m_is_solo, m_is_adjustXZ);
				}
			}
		}

		// // RVA: 0xAE4320 Offset: 0xAE4320 VA: 0xAE4320
		public void PlayMusicAnimation(double time = 0)
		{
			if(animator != null)
			{
				cutinBaseTime = -1;
				resetCutinBaseTime = false;
				isPlayingCutin = false;
				animator.Play("music", 0, (float)(time / musicClipLength));
			}
		}

		// // RVA: 0xAE442C Offset: 0xAE442C VA: 0xAE442C
		public void PlayCutinAnimation(int cutinId, float fireTime, int resourceId)
		{
			if(animator != null)
			{
				cutinEndTime = -1;
				resetCutinBaseTime = true;
				isPlayingCutin = true;
				cutinBaseTime = fireTime;
				StringBuilder str = new StringBuilder();
				if (resourceId == 0)
					str.SetFormat("cut_{0:D2}", cutinId);
				else
					str.SetFormat("cut_{0:D2}_{1}", cutinId, resourceId + 1);
				animator.Play(str.ToString(), 0);
			}
		}

		// // RVA: 0xAE4610 Offset: 0xAE4610 VA: 0xAE4610
		// public void Stop() { }

		// // RVA: 0xAE4AB4 Offset: 0xAE4AB4 VA: 0xAE4AB4
		// public void Pause() { }

		// // RVA: 0xAE4B6C Offset: 0xAE4B6C VA: 0xAE4B6C
		// public void Resume() { }

		// // RVA: 0xAE46D0 Offset: 0xAE46D0 VA: 0xAE46D0
		public void ChangeAnimationTime(double time)
		{
			if (time < 0)
				time = 0;
			if (animator != null)
			{
				if(resetCutinBaseTime)
				{
					resetCutinBaseTime = false;
					cutinBaseTime = time - cutinBaseTime;
				}
				animator.speed = 1;
				if(!isPlayingCutin)
				{
					if (animator.playableGraph.IsValid())
					{
						animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
					}
				}
				else
				{
					if (animator.playableGraph.IsValid())
					{
						animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0)) - cutinBaseTime));
					}
					cutinBaseTime = 0;
					AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
					if(info.normalizedTime >= 1)
					{
						if(cutinEndTime >= 0)
						{
							if(Mathf.Abs((float)(time - cutinBaseTime - cutinEndTime)) >= 0.01f)
							{
								PlayMusicAnimation(time);
							}
						}
						else
						{
							cutinEndTime = time - cutinBaseTime;
						}
					}
				}
			}
		}

		// // RVA: 0xAE4C24 Offset: 0xAE4C24 VA: 0xAE4C24
		public void AttachCameraBillboard()
		{
			AttachCameraStageBillboard();
			AttachCameraDivaBillboard();
		}

		// // RVA: 0xAE4C40 Offset: 0xAE4C40 VA: 0xAE4C40
		private void AttachCameraStageBillboard()
		{
			UnityEngine.Debug.LogError("TODO MusicCameraObject AttachCameraStageBillboard");
		}

		// // RVA: 0xAE4DC4 Offset: 0xAE4DC4 VA: 0xAE4DC4
		private void AttachCameraDivaBillboard()
		{
			UnityEngine.Debug.LogError("TODO MusicCameraObject AttachCameraDivaBillboard");
		}

		// // RVA: 0xAE4F48 Offset: 0xAE4F48 VA: 0xAE4F48
		public void AttachCameraDvaBillboard(List<GameDivaObject> a_list)
		{
			UnityEngine.Debug.LogError("TODO MusicCameraObject AttachCameraDvaBillboard");
		}

		// // RVA: 0xAE5114 Offset: 0xAE5114 VA: 0xAE5114
		public Transform GetCameraTransform()
		{
			return transform.GetComponentInChildren<Camera>().transform;
		}

		// // RVA: 0xAE3AE4 Offset: 0xAE3AE4 VA: 0xAE3AE4
		private void DivaHeightOffset(bool isSolo = false, bool isAdjustXZ = false)
		{
			ObjectPositionAdjuster adjust = gameObject.GetComponent<ObjectPositionAdjuster>();
			if(adjust == null)
				adjust = gameObject.AddComponent<ObjectPositionAdjuster>();
			targetId = 0;
			nextTargetId = 0;
			float scale = 0;
			if(targetId > divaIndexList.Count || nextTargetId > divaIndexList.Count)
			{
				targetId = 1;
				nextTargetId = -1;
				scale = CameraScaleFactor[divaIndexList[0] - 1];
			}
			else
			{
				if(targetId == -1)
				{
					scale = 1.0f;
					adjust.enableY = false;
					adjust.enableX = false;
					adjust.enableZ = false;
					adjust.scale = scale;
					return;
				}
				if(targetId > 0)
				{
					scale = CameraScaleFactor[divaIndexList[targetId - 1]- 1];
				}
				else
				{
					scale = 1.0f;
				}
			}
			float nextScale = 1.0f;
			if(nextTargetId != -1)
			{
				if(nextTargetId < 1)
				{
					nextScale = 1.0f;
				}
				else
				{
					nextScale = CameraScaleFactor[divaIndexList[nextTargetId - 1] - 1];
				}
				scale = nextScale * divaHeighOffsetTransform.localPosition.y + scale * (1.0f - divaHeighOffsetTransform.localPosition.y);
			}
			adjust.enableY = true;
			adjust.enableX = !isSolo || isAdjustXZ;
			adjust.enableZ = !isSolo || isAdjustXZ;
			adjust.scale = scale;
		}

		// // RVA: 0xAE51D4 Offset: 0xAE51D4 VA: 0xAE51D4
		// public void CameraOffset(AnimationEvent evt) { }
	}
}
