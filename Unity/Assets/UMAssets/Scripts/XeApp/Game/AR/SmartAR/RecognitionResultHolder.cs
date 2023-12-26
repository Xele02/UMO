
using System;

namespace smartar
{
    public class RecognitionResultHolder
    {
        public IntPtr self_; // 0x8

        // RVA: 0x20C2238 Offset: 0x20C2238 VA: 0x20C2238
        public RecognitionResultHolder(IntPtr self)
        {
            self_ = self;
        }

        // RVA: 0x20C2258 Offset: 0x20C2258 VA: 0x20C2258 Slot: 1
        ~RecognitionResultHolder()
        {
            self_ = IntPtr.Zero;
        }

        // // RVA: 0x20C22FC Offset: 0x20C22FC VA: 0x20C22FC
        // public void Release() { }

        // // RVA: 0x20C2350 Offset: 0x20C2350 VA: 0x20C2350
        // public int GetNumResults() { }

        // // RVA: 0x20C2450 Offset: 0x20C2450 VA: 0x20C2450
        // public int GetResults(RecognitionResult[] results) { }

        // // RVA: 0x20C25CC Offset: 0x20C25CC VA: 0x20C25CC
        // public int GetResult(Target target, out RecognitionResult result) { }

        // // RVA: 0x20C2358 Offset: 0x20C2358 VA: 0x20C2358
        // private static extern int sarSmartar_SarRecognitionResultHolder_sarGetNumResults(IntPtr self) { }

        // // RVA: 0x20C24C8 Offset: 0x20C24C8 VA: 0x20C24C8
        // private static extern int sarSmartar_SarRecognitionResultHolder_sarGetResults(IntPtr self, IntPtr results, int maxResults) { }

        // // RVA: 0x20C2608 Offset: 0x20C2608 VA: 0x20C2608
        // private static extern int sarSmartar_SarRecognitionResultHolder_sarGetResult(IntPtr self, IntPtr target, out RecognitionResult result) { }
    }
}