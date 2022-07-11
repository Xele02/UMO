
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public class IconTexture : IiconTexture
    {
        public Material Material { get; set; } // 0x8
        public Texture2D BaseTexture { get; set; } // 0xC
        public Texture2D MaskTexture { get; set; } // 0x10
        public ulong CreateCount { get; set; } // 0x18

        // // RVA: 0x13DB7E8 Offset: 0x13DB7E8 VA: 0x13DB7E8 Slot: 15
        // public virtual void Release() { }

        // // RVA: 0x13DB938 Offset: 0x13DB938 VA: 0x13DB938 Slot: 16
        public virtual void Set(RawImageEx image)
        {
            if(Material == null)
                return;
            if(image == null)
                return;
            image.material = Material;
            image.texture = BaseTexture;
            image.material.SetTexture("_MainTex", BaseTexture);
            image.material.SetTexture("_MaskTex", MaskTexture);
        }

        // // RVA: 0x13DBB50 Offset: 0x13DBB50 VA: 0x13DBB50 Slot: 17
        public virtual void Set(RawImage image)
        {
            if(Material == null)
                return;
            if(image == null)
                return;
            image.material = Material;
            image.texture = BaseTexture;
            image.material.SetTexture("_MainTex", BaseTexture);
            image.material.SetTexture("_MaskTex", MaskTexture);
        }
    }
}