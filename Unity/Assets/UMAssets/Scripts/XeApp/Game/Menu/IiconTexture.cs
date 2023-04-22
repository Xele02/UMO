
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public interface IiconTexture
    {
        Material Material { get; set; }//  Slot: 0  Slot: 1
        Texture2D BaseTexture { get; set; } // Slot: 2 Slot: 3
        Texture2D MaskTexture { get; set; }//  Slot: 4  Slot: 5
        ulong CreateCount { get; set; } // Slot: 6  Slot: 7

        // // RVA: -1 Offset: -1 Slot: 8
        void Release();

        // // RVA: -1 Offset: -1 Slot: 9
        void Set(RawImageEx image);

        // // RVA: -1 Offset: -1 Slot: 10
        void Set(RawImage image);
    }
}