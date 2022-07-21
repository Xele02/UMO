using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class GameFacialBlendAnimMediator : FacialBlendAnimMediatorBase
	{

		// RVA: 0xF7427C Offset: 0xF7427C VA: 0xF7427C Slot: 4
		protected override void OverrideCustomAnimation(DivaResource resource)
		{
			overrideController["diva_cmn_game_music_face"] = resource.musicMotionOverrideResource.faceBlendClip;
			overrideController["diva_cmn_game_music_mouth"] = resource.musicMotionOverrideResource.mouthBlendClip;
			musicFaceClipLength = resource.musicMotionOverrideResource.faceBlendClip.length;
			musicMouthClipLength = resource.musicMotionOverrideResource.mouthBlendClip.length;
		}

		// RVA: 0xF743CC Offset: 0xF743CC VA: 0xF743CC
		public void OverrideCutinClip(DivaCutinResource resource)
		{
			AnimatorOverrideController overrideCtrl = selfAnimator.runtimeAnimatorController as AnimatorOverrideController;
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < resource.cutinFaceClips.Length; i++)
			{
				if (resource.cutinFaceClips[i] != null)
				{
					str.SetFormat("diva_cmn_game_cut_{0:D2}_face", i + 1);
					overrideCtrl[str.ToString()] = resource.cutinFaceClips[i];
				}
			}
			for(int i = 0; i < resource.cutinMouthClips.Length; i++)
			{
				if(resource.cutinMouthClips[i] != null)
				{
					str.SetFormat("diva_cmn_game_cut_{0:D2}_mouth", i + 1);
					overrideCtrl[str.ToString()] = resource.cutinMouthClips[i];
				}
			}
		}
	}
}
