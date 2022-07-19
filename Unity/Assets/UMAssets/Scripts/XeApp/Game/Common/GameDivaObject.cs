using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.RhythmGame;

namespace XeApp.Game.Common
{
	public class GameDivaObject : DivaObject
	{
		public class FrameSkipChecker
		{
			public float m_sec_now = -1; // 0x8
			public float m_sec_prev = -1; // 0xC
			public float m_sec_threshold = 1.0f; // 0x10
			public int m_skip_frame_max = 3; // 0x14
			public int m_skip_frame; // 0x18
			public bool m_skip; // 0x1C
			public bool m_init; // 0x1D


			// RVA: 0xE98F38 Offset: 0xE98F38 VA: 0xE98F38
			//public void Reset() { }

			// RVA: 0xE97C44 Offset: 0xE97C44 VA: 0xE97C44
			//public void UpdateSec(float a_now) { }
		}

		private ShadowProjector rightFootShadow; // 0x8C
		private ShadowProjector leftFootShadow; // 0x90
		private ShadowProjector bodyShadow; // 0x94
		private Color defaultMainColor; // 0x98
		private Color defaultRimColor = new Color(0, 0, 0, 1); // 0xA8
		private float defaultRimPower; // 0xB8
		private Color defaultShadowColor; // 0xBC
		private bool isMovieMode; // 0xCC
		private Dictionary<string, List<Material>> m_list_material; // 0xD0
		protected double cutinBaseTime = -1; // 0xD8
		protected bool resetCutinBaseTime; // 0xE0
		protected bool isPlayingCutin; // 0xE1
		private GameDivaObject.FrameSkipChecker m_checker_frameskip = new FrameSkipChecker(); // 0xE4

		protected override bool useQualitySetting { get { return true; } } //0xE95FF4  Slot: 4

		//// RVA: 0xE95FFC Offset: 0xE95FFC VA: 0xE95FFC Slot: 6
		protected override void SetupCustomComponents(DivaResource resource)
		{
			Transform t = divaPrefab.transform.Find("joint_root/hips");
			if(t != null)
			{
				adjustScaler = t.gameObject.GetComponent<ObjectPositionAdjuster>();
				if (adjustScaler == null)
					adjustScaler = t.gameObject.AddComponent<ObjectPositionAdjuster>();
				adjustScaler.Initialize(ObjParam.GetHipScaleFactor(divaId), true, true, true);
			}
			facialBlendAnimMediator = GetComponentInChildren<GameFacialBlendAnimMediator>();
			facialBlendAnimMediator.Initialize(resource, divaPrefab);
			facialBlendAnimMediator.SetEyeMeshUvRate(ObjParam.GetEyeMeshUvRate(divaId));
			rightFootShadow = transform.Find("RightFootShadow").GetComponent<ShadowProjector>();
			t = divaPrefab.transform.Find("joint_root/hips/upleg_r/leg_r/foot_r");
			if (t != null)
				rightFootShadow.SetupTarget(t);
			leftFootShadow = transform.Find("LeftFootShadow").GetComponent<ShadowProjector>();
			t = divaPrefab.transform.Find("joint_root/hips/upleg_l/leg_l/foot_l");
			if (t != null)
				leftFootShadow.SetupTarget(t);
			bodyShadow = transform.Find("BodyShadow").GetComponent<ShadowProjector>();
			t = divaPrefab.transform.Find("joint_root/hips/spine");
			if (t != null)
				bodyShadow.SetupTarget(t);
			if(!GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.PKEMELMMEKM_GetDivaQuality())
			{
				rightFootShadow.gameObject.SetActive(false);
				leftFootShadow.gameObject.SetActive(false);
				bodyShadow.gameObject.SetActive(false);
			}
			SetActiveFoundChildren(divaPrefab.transform, "menu", false);
			animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.Manual);
			facialBlendAnimMediator.selfAnimator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.Manual);
		}

		//// RVA: 0xE96914 Offset: 0xE96914 VA: 0xE96914 Slot: 5
		protected override void OverrideCustomAnimation(DivaResource resource)
		{
			overrideController["diva_cmn_game_music_body"] = resource.musicMotionOverrideResource.bodyClip;
			musicBodyClipLength = resource.musicMotionOverrideResource.bodyClip.length;
		}

		//// RVA: 0xE969D8 Offset: 0xE969D8 VA: 0xE969D8
		//public void OverrideCutinClip(DivaCutinResource resource) { }

		//// RVA: 0xE96DB0 Offset: 0xE96DB0 VA: 0xE96DB0
		public void SetupBoneSpring(RhythmGameResource a_resource, int index = 0)
		{
			if(a_resource != null)
			{
				if(boneSpringController != null)
				{
					BoneSpringAnimObject bsao = transform.GetComponentInChildren<BoneSpringAnimObject>(true);
					if(bsao != null)
					{
						if(a_resource.musicBoneSpringResource[index].clip != null)
						{
							bsao.gameObject.SetActive(true);
							m_boneSpringAnim = bsao;
							m_boneSpringAnim.Initialize(a_resource, divaPrefab, index, divaId);
							m_boneSpringAnim.animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.Manual);
						}
						else
						{
							bsao.gameObject.SetActive(false);
						}
					}
				}
			}
		}

		//// RVA: 0xE970BC Offset: 0xE970BC VA: 0xE970BC
		//public void SetEnableBoneSpringAnime(bool a_enable) { }

		//// RVA: 0xE97198 Offset: 0xE97198 VA: 0xE97198
		//private void ChangeVisibilityCallback(bool isVisible) { }

		//// RVA: 0xE972E8 Offset: 0xE972E8 VA: 0xE972E8
		//public void PlayMusicAnimation(double time = 0) { }

		//// RVA: 0xE976E8 Offset: 0xE976E8 VA: 0xE976E8
		//public void PlayCutinAnimation(int cutinId, bool isBody, bool isFace, bool isMouth, bool isMike, float fireTime) { }

		//// RVA: 0xE97A28 Offset: 0xE97A28 VA: 0xE97A28 Slot: 7
		//public override void ChangeAnimationTime(double time) { }

		//// RVA: 0xE97D40 Offset: 0xE97D40 VA: 0xE97D40
		public void SetupDefaultMaterialColor(Color mainColor, Color rimColor, float rimPower, Color shadowColor)
		{
			defaultMainColor = mainColor;
			defaultRimColor = rimColor;
			defaultShadowColor = shadowColor;
			defaultRimPower = rimPower;
			m_list_material = new Dictionary<string, List<Material>>();
			m_list_material["_Color"] = new List<Material>();
			m_list_material["_RimColor"] = new List<Material>();
			m_list_material["_RimLightPower"] = new List<Material>();
			for(int i = 0; i < renderers.Count; i++)
			{
				if(renderers[i] != null)
				{
					if(!renderers[i].material.shader.name.Contains("Additive"))
					{
						if (renderers[i].material.HasProperty("_Color"))
						{
							m_list_material["_Color"].Add(renderers[i].material);
						}
						if (renderers[i].material.HasProperty("_RimColor"))
						{
							m_list_material["_RimColor"].Add(renderers[i].material);
						}
						if (renderers[i].material.HasProperty("_RimLightPower"))
						{
							m_list_material["_RimLightPower"].Add(renderers[i].material);
						}
					}
				}
			}
			ChangeColor(mainColor, rimColor, rimPower, shadowColor);
		}

		//// RVA: 0xE98B40 Offset: 0xE98B40 VA: 0xE98B40
		//public void ChangeMovieMaterialColor(bool isOn) { }

		//// RVA: 0xE98C20 Offset: 0xE98C20 VA: 0xE98C20
		//public void UpdateColorByStageLighting(Color mainColor, Color rimColor, float rimPower, Color shadowColor) { }

		//// RVA: 0xE98474 Offset: 0xE98474 VA: 0xE98474
		private void ChangeColor(Color mainColor, Color rimColor, float rimPower, Color shadowColor)
		{
			if(!m_valkyrieShaderControlelr.IsEnable() && m_list_material != null)
			{
				for(int i = 0; i < m_list_material["_Color"].Count; i++)
				{
					m_list_material["_Color"][i].SetColor("_Color", mainColor);
				}
				for (int i = 0; i < m_list_material["_RimColor"].Count; i++)
				{
					m_list_material["_RimColor"][i].SetColor("_RimColor", rimColor);
				}
				for (int i = 0; i < m_list_material["_RimLightPower"].Count; i++)
				{
					m_list_material["_RimLightPower"][i].SetFloat("_RimLightPower", rimPower);
				}
			}
			if(bodyShadow != null)
			{
				bodyShadow.SetColor(shadowColor);
			}
			if(leftFootShadow != null)
			{
				leftFootShadow.SetColor(shadowColor);
			}
			if (rightFootShadow != null)
			{
				rightFootShadow.SetColor(shadowColor);
			}
		}

		//// RVA: 0xE98E04 Offset: 0xE98E04 VA: 0xE98E04 Slot: 8
		protected override void SetupEffectObject(List<GameObject> a_effect)
		{
			UnityEngine.Debug.LogError("TODO SetupEffectObject");
		}

		//// RVA: 0xE98E30 Offset: 0xE98E30 VA: 0xE98E30 Slot: 9
		protected override void SetupWind(GameObject a_wind, DivaResource.BoneSpringResource a_resource)
		{
			UnityEngine.Debug.LogError("TODO SetupWind");
		}
	}
}
