
using UnityEngine;

namespace XeSys.Gfx
{
    public interface IAlphaTexture
    {
        // public abstract Texture alphaTexture { get; set; } //  Slot: 0 Slot: 1
        Color color { get; set; } //  Slot: 2 Slot: 3
        Material material { get; set; } // Slot: 4 Slot: 5
        Material MaterialMul { get; set; } // Slot: 6 Slot: 7
        Material MaterialAdd { get; set; } // Slot: 8 Slot: 9
        // public abstract string TextureName { get; set; } // Slot: 10 Slot: 11
        // public abstract bool raycastTarget { get; set; } // Slot: 12 Slot: 13

        // // RVA: -1 Offset: -1 Slot: 14
        // public abstract bool IsUseAlphaTexture();

        // // RVA: -1 Offset: -1 Slot: 15
        // public abstract void SetTexture(Texture tex);
    }
}