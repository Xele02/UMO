using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class MenuFacialBlendAnimMediator : FacialBlendAnimMediatorBase
	{
		// RVA: 0x1113360 Offset: 0x1113360 VA: 0x1113360 Slot: 4
		protected override void OverrideCustomAnimation(DivaResource resource)
		{
			StringBuilder str = new StringBuilder(64);
			overrideController["diva_cmn_menu_idle_face"] = resource.menuMotionOverride.idle.faceBlendClip;
			overrideController["diva_cmn_menu_idle_mouth"] = resource.menuMotionOverride.idle.mouthBlendClip;
			for(int i = 0; i < resource.menuMotionOverride.reactions.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_reaction{0:D2}_face", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.reactions[i].main.faceBlendClip;
				str.SetFormat("diva_cmn_menu_reaction{0:D2}_mouth", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.reactions[i].main.mouthBlendClip;
			}
			for(int i = 0; i < resource.menuMotionOverride.talk.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_talk{0:D2}_face", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].main.faceBlendClip;
			}
			for (int i = 0; i < resource.menuMotionOverride.simpletalk.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_simple_talk{0:D2}_face", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.simpletalk[i].main.faceBlendClip;
				str.SetFormat("diva_cmn_menu_simple_talk{0:D2}_mouth", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.simpletalk[i].main.mouthBlendClip;
			}
			for (int i = 0; i < resource.menuMotionOverride.timezone.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_timezone{0:D2}_face", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.timezone[i].main.faceBlendClip;
				str.SetFormat("diva_cmn_menu_timezone{0:D2}_mouth", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.timezone[i].main.mouthBlendClip;
			}
			overrideController["diva_cmn_result_wait_loop_face"] = resource.resultMotionOverride.wait.faceBlendClip;
			overrideController["diva_cmn_result_wait_loop_mouth"] = resource.resultMotionOverride.wait.mouthBlendClip;
			overrideController["diva_cmn_result_start_face"] = resource.resultMotionOverride.start.faceBlendClip;
			overrideController["diva_cmn_result_start_mouth"] = resource.resultMotionOverride.start.mouthBlendClip;
			overrideController["diva_cmn_result_end_loop_face"] = resource.resultMotionOverride.end.faceBlendClip;
			overrideController["diva_cmn_result_end_loop_mouth"] = resource.resultMotionOverride.end.mouthBlendClip;
			overrideController["diva_cmn_result_win_start_face"] = resource.resultMotionOverride.winStart.faceBlendClip;
			overrideController["diva_cmn_result_win_start_mouth"] = resource.resultMotionOverride.winStart.mouthBlendClip;
			overrideController["diva_cmn_result_win_end_loop_face"] = resource.resultMotionOverride.winEnd.faceBlendClip;
			overrideController["diva_cmn_result_win_end_loop_mouth"] = resource.resultMotionOverride.winEnd.mouthBlendClip;
			overrideController["diva_cmn_result_lose_start_face"] = resource.resultMotionOverride.loseStart.faceBlendClip;
			overrideController["diva_cmn_result_lose_start_mouth"] = resource.resultMotionOverride.loseStart.mouthBlendClip;
			overrideController["diva_cmn_result_lose_end_loop_face"] = resource.resultMotionOverride.loseEnd.faceBlendClip;
			overrideController["diva_cmn_result_lose_end_loop_mouth"] = resource.resultMotionOverride.loseEnd.mouthBlendClip;
			overrideController["diva_cmn_login_idle_face"] = resource.loginMotionOverride.idle.faceBlendClip;
			for (int i = 0; i < resource.loginMotionOverride.reactions.Count; i++)
			{
				str.SetFormat("diva_cmn_login_reaction{0:D2}_begin_face", i + 1);
				overrideController[str.ToString()] = resource.loginMotionOverride.reactions[i].begin.faceBlendClip;
				str.SetFormat("diva_cmn_login_reaction{0:D2}_end_face", i + 1);
				overrideController[str.ToString()] = resource.loginMotionOverride.reactions[i].begin.mouthBlendClip;
			}
			overrideController["diva_cmn_join_start_face"] = resource.unlockMotionOverride.start.faceBlendClip;
			overrideController["diva_cmn_join_start_mouth"] = resource.unlockMotionOverride.start.mouthBlendClip;
			overrideController["diva_cmn_join_loop_face"] = resource.unlockMotionOverride.end.faceBlendClip;
			overrideController["diva_cmn_join_loop_mouth"] = resource.unlockMotionOverride.end.mouthBlendClip;
			overrideController["diva_cmn_costume_start_face"] = resource.unlockCostumeMotionOverride.start.faceBlendClip;
			overrideController["diva_cmn_costume_start_mouth"] = resource.unlockCostumeMotionOverride.start.mouthBlendClip;
			overrideController["diva_cmn_costume_pose_face"] = resource.unlockCostumeMotionOverride.pose.faceBlendClip;
			overrideController["diva_cmn_costume_pose_mouth"] = resource.unlockCostumeMotionOverride.pose.mouthBlendClip;
			overrideController["diva_cmn_costume_loop_face"] = resource.unlockCostumeMotionOverride.end.faceBlendClip;
			overrideController["diva_cmn_costume_loop_mouth"] = resource.unlockCostumeMotionOverride.end.mouthBlendClip;
			for (int i = 0; i < DivaResource.MAX_PRESENT; i++)
			{
				str.SetFormat("diva_cmn_menu_present{0:D2}_face", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.present[i].main.faceBlendClip;
			}
		}
	}
}
