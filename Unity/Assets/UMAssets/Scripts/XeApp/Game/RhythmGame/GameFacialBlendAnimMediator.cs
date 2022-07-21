using XeApp.Game.Common;

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
		//public void OverrideCutinClip(DivaCutinResource resource) { }
	}
}
