using System.Text;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeSys;

namespace XeApp.Game.AR
{
	public class ARFacialBlendAnimMediator : GameFacialBlendAnimMediator
	{
		public ARDivaMotionId motionId { get; set; } // 0x68

		// RVA: 0xBB8874 Offset: 0xBB8874 VA: 0xBB8874 Slot: 4
		protected override void OverrideCustomAnimation(DivaResource resource)
		{
			if(motionId == ARDivaMotionId.Talk)
			{
				StringBuilder str = new StringBuilder(64);
				overrideController["diva_cmn_menu_idle_face"] = resource.menuMotionOverride.idle.faceBlendClip;
				overrideController["diva_cmn_menu_idle_mouth"] = resource.menuMotionOverride.idle.mouthBlendClip;
				for(int i = 0; i < resource.menuMotionOverride.talk.Count; i++)
				{
					str.SetFormat("diva_cmn_menu_talk{0:D2}_face", i + 1);
					overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].main.faceBlendClip;
				}
				overrideController["diva_cmn_join_start_face"] = resource.unlockMotionOverride.start.faceBlendClip;
				overrideController["diva_cmn_join_start_mouth"] = resource.unlockMotionOverride.start.mouthBlendClip;
				overrideController["diva_cmn_join_loop_face"] = resource.unlockMotionOverride.end.faceBlendClip;
				overrideController["diva_cmn_join_loop_mouth"] = resource.unlockMotionOverride.end.mouthBlendClip;
			}
			else if(motionId == ARDivaMotionId.Dance)
			{
				overrideController["diva_cmn_game_music_face"] = resource.musicMotionOverrideResource.faceBlendClip;
				overrideController["diva_cmn_game_music_mouth"] = resource.musicMotionOverrideResource.mouthBlendClip;
				musicFaceClipLength = resource.musicMotionOverrideResource.faceBlendClip.length;
				musicMouthClipLength = resource.musicMotionOverrideResource.mouthBlendClip.length;
			}
		}
	}
}
