using XeSys;

namespace Mana.Service.Ad
{
    public class ManaAdAPIHelper : SingletonMonoBehaviour<ManaAdAPIHelper>
    {
        // Fields
        private bool _hasSendLaunchEvent; // 0xC
        public static string iOSLounchURL; // 0x0
        public string lastSetLaunchURL; // 0x10
        private bool _sendResumeEventRequest; // 0x14

        // // RVA: 0x17BD040 Offset: 0x17BD040 VA: 0x17BD040
        public void SendLaunchEvent()
        {
            UnityEngine.Debug.LogError("TODO");
        }

        // // RVA: 0x17BD520 Offset: 0x17BD520 VA: 0x17BD520
        // public void SendResumeEvent() { }

        // // RVA: 0x17BD65C Offset: 0x17BD65C VA: 0x17BD65C
        public void TryPendingSendResumeEvent()
        {
            UnityEngine.Debug.LogError("TODO");
        }

        // // RVA: 0x17BD75C Offset: 0x17BD75C VA: 0x17BD75C
        // private void OnApplicationPause(bool pauseStatus) { }

        // // RVA: 0x17BD3A8 Offset: 0x17BD3A8 VA: 0x17BD3A8
        // private void SetLaunchURL() { }

        // // RVA: 0x17BD1E4 Offset: 0x17BD1E4 VA: 0x17BD1E4
        // public string GetReferrer() { }

        // [ConditionalAttribute] // RVA: 0x6AA488 Offset: 0x6AA488 VA: 0x6AA488
        // // RVA: 0x17BD860 Offset: 0x17BD860 VA: 0x17BD860
        // private void ShowDebugMessage(string log, object[] addparams) { }

        // // RVA: 0x17BD870 Offset: 0x17BD870 VA: 0x17BD870
        // public void .ctor() { }

        // // RVA: 0x17BD914 Offset: 0x17BD914 VA: 0x17BD914
        // private static void .cctor() { }
    }
}