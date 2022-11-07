using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;

namespace XeApp.Game.RhythmGame.UI
{
	public abstract class UiReplaceTexture
	{
		protected StringBuilder bundlePath = new StringBuilder(); // 0x8
		protected StringBuilder assetName = new StringBuilder(); // 0xC

		//[IteratorStateMachineAttribute] // RVA: 0x74763C Offset: 0x74763C VA: 0x74763C
		//								// RVA: 0x15683DC Offset: 0x15683DC VA: 0x15683DC
		protected IEnumerator Load(string bundlePath, string assetName, UnityAction<Texture2D> callBack)
		{
			AssetBundleLoadAssetOperation op; // 0x1C

			// 0x1569550
			op = AssetBundleManager.LoadAssetAsync(bundlePath, assetName, typeof(Texture2D));
			yield return op;

			if(callBack != null)
			{
				callBack(op.GetAsset<Texture2D>());
			}

			AssetBundleManager.UnloadAssetBundle(bundlePath, false);
		}

		//// RVA: -1 Offset: -1 Slot: 4
		public abstract void Set(Material material);

		//// RVA: -1 Offset: -1 Slot: 5
		public abstract void OnDestory();
	}
}
