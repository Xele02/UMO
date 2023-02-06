using System;
using System.Collections;
using System.IO;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.RhythmGame.UI
{
    public class UiDivaTexture : UiReplaceTexture
    {
        private Texture2D mainTexture; // 0x10
        private Texture2D maskTexture; // 0x14
        private Texture2D bgTexture; // 0x18

        // [IteratorStateMachineAttribute] // RVA: 0x7477DC Offset: 0x7477DC VA: 0x7477DC
        // // RVA: 0x1567E34 Offset: 0x1567E34 VA: 0x1567E34
        // public IEnumerator Load(Texture2D liveCutBaseTexture, Texture2D liveCutMaskTexture) { }

        // [IteratorStateMachineAttribute] // RVA: 0x747854 Offset: 0x747854 VA: 0x747854
        // // RVA: 0x1567F14 Offset: 0x1567F14 VA: 0x1567F14
        public IEnumerator Load(int divaId, int modelId, int colorId)
		{
			//0x1568538
			bundlePath.Set(DivaIconTextureCache.GetDivaUpIconPath(divaId, modelId, colorId));
			assetName.Set(Path.GetFileNameWithoutExtension(bundlePath.ToString()));
			assetName.Append("_base");
			yield return Co.R(Load(bundlePath.ToString(), assetName.ToString(), (Texture2D tex) =>
			{
				//0x15681AC
				mainTexture = tex;
			}));
			assetName.Replace("_base", "_mask");
			yield return Co.R(Load(bundlePath.ToString(), assetName.ToString(), (Texture2D tex) =>
			{
				//0x15681B4
				maskTexture = tex;
			}));
			bundlePath.SetFormat("gm/if/un.xab", Array.Empty<object>());
			assetName.SetFormat("diva_cutin_bg_01", Array.Empty<object>());
			yield return Co.R(Load(bundlePath.ToString(), assetName.ToString(), (Texture2D tex) =>
			{
				//0x15681BC
				bgTexture = tex;
			}));
		}

		// // RVA: 0x156800C Offset: 0x156800C VA: 0x156800C Slot: 4
		public override void Set(Material material)
		{
			material.SetTexture("_MainTex", mainTexture);
			material.SetTexture("_MaskTex", maskTexture);
			material.SetTexture("_BgTex", bgTexture);
		}

		// // RVA: 0x15680F8 Offset: 0x15680F8 VA: 0x15680F8 Slot: 5
		public override void OnDestory()
		{
			mainTexture = null;
			maskTexture = null;
			bgTexture = null;
		}

        // [CompilerGeneratedAttribute] // RVA: 0x7478CC Offset: 0x7478CC VA: 0x7478CC
        // // RVA: 0x15681A4 Offset: 0x15681A4 VA: 0x15681A4
        // private void <Load>b__3_0(Texture2D tex) { }
    }
}
