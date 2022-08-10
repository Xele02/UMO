
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public class NewMarkIcon
    {
        private const string ShowAnimLabel = "st_wait";
        private const string LoopStartAnimLabel = "lo_go_act";
        private const string LoopEndAnimLabel = "lo_en_act";
        private const string HideAnimLabel = "st_non";
        private const float LoopStartTime = 0.01666667f;
        private const float LoopEndTime = 0.9833334f;
        private AbsoluteLayout m_iconEffectLayout; // 0x8
        private AbsoluteLayout m_iconLayout; // 0xC
        // private LayoutObject m_object; // 0x10

        // public static string ParentObjectName { get; } 0x1515A98

        // RVA: 0x1515AF4 Offset: 0x1515AF4 VA: 0x1515AF4
        // public void .ctor(GameObject parent) { }

        // // RVA: 0x1515E34 Offset: 0x1515E34 VA: 0x1515E34
        // public void Initialize(GameObject parent) { }

        // // RVA: 0x1516250 Offset: 0x1516250 VA: 0x1516250
        // public void SetActive(bool isActive) { }

        // // RVA: 0x1516390 Offset: 0x1516390 VA: 0x1516390
        // public bool IsActive() { }

        // // RVA: 0x1516168 Offset: 0x1516168 VA: 0x1516168
        public void Release()
        {
            TodoLogger.Log(0, "Release NewMarkIcon");
        }

        // // RVA: 0x15163F4 Offset: 0x15163F4 VA: 0x15163F4
        // private void PlayShowAnim() { }

        // // RVA: 0x15162C4 Offset: 0x15162C4 VA: 0x15162C4
        // private void PlayLoopAnim() { }

        // // RVA: 0x15164B0 Offset: 0x15164B0 VA: 0x15164B0
        // private void PlayHideAnim() { }

        // // RVA: 0x151656C Offset: 0x151656C VA: 0x151656C
        // public void OverridePlayTime(int time) { }
    }
}