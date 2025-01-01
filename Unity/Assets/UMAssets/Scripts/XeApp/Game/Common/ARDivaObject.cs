
using System.Text;
using UnityEngine;
using XeApp.Game.AR;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.Common
{
    public class ARDivaObject : GameDivaObject
    {
        [SerializeField]
        private MenuDivaGazeControl.Data gazeControlData = new MenuDivaGazeControl.Data(); // 0xD0

        // public MenuDivaGazeControl.Data GazeControlData { get; } 0xB0778C
        protected override bool useQualitySetting { get { return false; } } //0xB07794
        public ARDivaMotionId motionId { get; set; } // 0xD4

        // RVA: 0xB077AC Offset: 0xB077AC VA: 0xB077AC Slot: 6
        protected override void SetupCustomComponents(DivaResource resource)
        {
            DivaUnlockEventListener del = divaPrefab.AddComponent<DivaUnlockEventListener>();
            Transform j = divaPrefab.transform.Find("joint_root/hips");
            if(j != null)
            {
                adjustScaler = j.gameObject.GetComponent<ObjectPositionAdjuster>();
                if(adjustScaler == null)
                {
                    adjustScaler = j.gameObject.AddComponent<ObjectPositionAdjuster>();
                }
                adjustScaler.Initialize(ObjParam.GetHipScaleFactor(divaId), true, true, true);
            }
            facialBlendAnimMediator = GetComponentInChildren<ARFacialBlendAnimMediator>();
            facialBlendAnimMediator.Initialize(resource, divaPrefab);
            facialBlendAnimMediator.SetEyeMeshUvRate(ObjParam.GetEyeMeshUvRate(divaId));
            if(motionId == ARDivaMotionId.Talk)
            {
                SetActiveFoundChildren(divaPrefab.transform, "game", false);
            }
            else if(motionId == ARDivaMotionId.Dance)
            {
                SetActiveFoundChildren(divaPrefab.transform, "menu", false);
            }
        }

        // RVA: 0xB07B94 Offset: 0xB07B94 VA: 0xB07B94 Slot: 5
        protected override void OverrideCustomAnimation(DivaResource resource)
        {
            if(motionId == ARDivaMotionId.Talk)
            {
                StringBuilder str = new StringBuilder(64);
                overrideController["diva_cmn_menu_idle_body"] = resource.menuMotionOverride.idle.bodyClip;
                for(int i = 0; i < resource.menuMotionOverride.talk.Count; i++)
                {
                    str.SetFormat("diva_cmn_menu_talk{0:D2}_start_body", i + 1);
                    overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].begin.bodyClip;
                    str.SetFormat("diva_cmn_menu_talk{0:D2}_body", i + 1);
                    overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].main.bodyClip;
                    str.SetFormat("diva_cmn_menu_talk{0:D2}_end_body", i + 1);
                    overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].end.bodyClip;
                }
                overrideController["diva_cmn_join_start_body"] = resource.unlockMotionOverride.start.bodyClip;
                overrideController["diva_cmn_join_loop_body"] = resource.unlockMotionOverride.end.bodyClip;
            }
            else if(motionId == ARDivaMotionId.Dance)
            {
                overrideController["diva_cmn_game_music_body"] = resource.musicMotionOverrideResource.bodyClip;
                musicBodyClipLength = resource.musicMotionOverrideResource.bodyClip.length;
            }
        }

        // RVA: 0xB08030 Offset: 0xB08030 VA: 0xB08030
        public void Idle()
        {
            if(animator != null)
            {
                Anim_Play("idle", 0);
            }
        }

        // RVA: 0xB080F4 Offset: 0xB080F4 VA: 0xB080F4
        public void IdleCrossFade(float time = 0.25f)
        {
            if(animator != null)
            {
                Anim_CrossFadeInFixedTime("idle", time);
            }
        }

        // // RVA: 0xB081AC Offset: 0xB081AC VA: 0xB081AC
        // public void Unlock() { }

        // RVA: 0xB08270 Offset: 0xB08270 VA: 0xB08270
        public void Talk(int type)
        {
            if(animator != null)
            {
                Anim_SetTrigger("menu_toTalk");
                Anim_SetInteger("menu_talkType", type);
                Anim_SetBool("menu_breakTalkLoop", false);
            }
        }

        // RVA: 0xB08374 Offset: 0xB08374 VA: 0xB08374
        public void TalkEnd()
        {
            if(animator != null)
                Anim_SetBool("menu_breakTalkLoop", true);
        }

        // // RVA: 0xB08428 Offset: 0xB08428 VA: 0xB08428
        // public MenuDivaGazeControl StartGazeControl() { }

        // // RVA: 0xB085F8 Offset: 0xB085F8 VA: 0xB085F8
        // public void FinishGazeControl() { }

        // RVA: 0xB086DC Offset: 0xB086DC VA: 0xB086DC
        public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex)
        {
            return animator.GetCurrentAnimatorStateInfo(layerIndex);
        }
    }
}