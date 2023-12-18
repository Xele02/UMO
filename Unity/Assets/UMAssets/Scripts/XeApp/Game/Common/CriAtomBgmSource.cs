
using CriWare;

namespace XeApp.Game.Common
{
    public class CriAtomBgmSource : CriAtomSource
    {
        public override bool enable_audio_synced_timer { get { /*return true*/return !RuntimeSettings.CurrentSettings.DisableCrywareLowLatency; } } // 0xE6C960 Slot: 8
    }
}
