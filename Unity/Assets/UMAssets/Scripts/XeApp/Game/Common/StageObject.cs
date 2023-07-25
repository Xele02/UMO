using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class StageObject : MonoBehaviour
	{
		private Animator animator; // 0x10
		private StageParam _param; // 0x14

		public GameObject rootObject { get; private set; } // 0xC
		public StageParam param { get { return _param; } private set { return; } } //0x1CC89EC 0x1CC89F4
		public StageColorChanger colorChanger { get; private set; } // 0x18

		//// RVA: 0x1CC8A08 Offset: 0x1CC8A08 VA: 0x1CC8A08
		//public void ResetAnimationPreview() { }

		//// RVA: 0x1CC8A0C Offset: 0x1CC8A0C VA: 0x1CC8A0C
		public void Initialize(StageResource resource, int musicNameId)
		{
			Destroy(rootObject);
			rootObject = Instantiate(resource.prefab);
			rootObject.transform.SetParent(transform, false);
			_param = resource.param;
			animator = rootObject.GetComponent<Animator>();
			colorChanger = rootObject.GetComponent<StageColorChanger>();
			if(animator != null)
			{
				if(animator.runtimeAnimatorController != null)
				{
					animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.Manual);
				}
			}
			if(Database.Instance.gameSetup.musicInfo.onStageDivaNum > 2)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality == 1 || GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.JLEJPKOMKEJ_IsAnimatorLowQuality())
				{
					if (animator != null)
					{
						animator.enabled = false;
					}
					SkinnedMeshRenderer[] smrs = rootObject.GetComponentsInChildren<SkinnedMeshRenderer>();
					for(int i = 0; i < smrs.Length; i++)
					{
						smrs[i].enabled = false;
					}
				}
			}
		}

		//// RVA: 0x1CC8E90 Offset: 0x1CC8E90 VA: 0x1CC8E90
		public static void StaticSetupPsylliumColor(StageColorChanger colorChanger, MusicDirectionParamBase musicParam, DivaParam divaParam, List<DivaResource> subDivaResource)
		{
			if(colorChanger != null)
			{
				List<Color> colors = new List<Color>();
				if(musicParam.psylliumOverride)
				{
					colors.Add(musicParam.psylliumColor);
				}
				else
				{
					colors.Add(divaParam.psylliumColor);
					foreach(var r in subDivaResource)
					{
						if(r != null)
						{
							if(r.divaParam != null)
							{
								colors.Add(r.divaParam.psylliumColor);
							}
						}
					}
				}
				colorChanger.SetupPsylliumColor(colors);
			}
		}

		//// RVA: 0x1CC9294 Offset: 0x1CC9294 VA: 0x1CC9294
		public void SetupPsylliumColor(MusicDirectionParamBase musicParam, DivaParam divaParam, List<DivaResource> subDivaResource, int subDivaNum)
		{
			StaticSetupPsylliumColor(colorChanger, musicParam, divaParam, subDivaResource);
		}

		//// RVA: 0x1CC92B0 Offset: 0x1CC92B0 VA: 0x1CC92B0
		public void ChangeAnimationTime(double time)
		{
			if(animator != null && animator.runtimeAnimatorController != null)
			{
				animator.speed = 1;
				if (PlayableExtensions.IsValid<Playable>(animator.playableGraph.GetRootPlayable(0)))
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
			}
		}
	}
}
