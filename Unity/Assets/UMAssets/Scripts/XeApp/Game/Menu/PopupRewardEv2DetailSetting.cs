
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupRewardEv2DetailSetting : PopupSetting
    {
        public GCIJNCFDNON_SceneInfo[] Scene { get; set; } // 0x34
        public DFKGGBMFFGB_PlayerInfo PlayerData { get; set; } // 0x38
        public bool IsFriend { get; set; } // 0x3C
        public bool IsDisableZoom { get; set; } // 0x3D
        public SceneStatusParam.PageSave PageSave { get; set; } // 0x40
        public override string PrefabPath { get { return ""; } } //0x1621F24
        public override string BundleName { get { return "ly/053.xab"; } } //0x1621F80
        public override string AssetName { get { return "PopupRewardEv2Detail"; } } //0x1621FDC
        public override bool IsAssetBundle { get { return true; } } //0x1622038
        public override bool IsPreload { get { return true; } } //0x1622040
        public override GameObject Content { get { return m_content; } } //0x1622048

        // // RVA: 0x1622050 Offset: 0x1622050 VA: 0x1622050
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x70D704 Offset: 0x70D704 VA: 0x70D704
        // RVA: 0x1622058 Offset: 0x1622058 VA: 0x1622058 Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            //0x16221B4
            for(int i = 0; i < Scene.Length; i++)
            {
                GameManager.Instance.SceneIconCache.Load(Scene[i].BCCHOBPJJKE_SceneId, Scene[i].CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
                {
                    //0x16221AC
                    return;
                });
            }
            yield return Co.R(base.LoadAssetBundlePrefab(parent));

        }

        // [DebuggerHiddenAttribute] // RVA: 0x70D77C Offset: 0x70D77C VA: 0x70D77C
        // [CompilerGeneratedAttribute] // RVA: 0x70D77C Offset: 0x70D77C VA: 0x70D77C
        // // RVA: 0x1622128 Offset: 0x1622128 VA: 0x1622128
        // private IEnumerator <>n__0(Transform parent) { }
    }
}