
using System;
using XeApp.Core;

namespace XeApp.Game.Menu
{
    public class IconTextureLodingInfo
    {
        public AssetBundleLoadAllAssetOperationBase Operation { get; private set; } // 0x8
        public string Path { get; private set; } // 0xC
        public Action<IiconTexture> CallBack { get; set; } // 0x10
        public IconTextureType TextureType { get; set; } // 0x14

        // // RVA: 0x13DC6A0 Offset: 0x13DC6A0 VA: 0x13DC6A0
        public IconTextureLodingInfo(AssetBundleLoadAllAssetOperationBase operation, string path)
        {
            Operation = operation;
            Path = path;
        }
    }
}