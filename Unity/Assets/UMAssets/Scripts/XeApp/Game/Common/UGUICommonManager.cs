using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Common
{
	public class UGUICommonManager
	{
		private const string BundleName = "ly/cmn.xab";

		public bool IsReady { get; private set; } // 0x8

		// [IteratorStateMachineAttribute] // RVA: 0x7404FC Offset: 0x7404FC VA: 0x7404FC
		// RVA: 0x1CD20D0 Offset: 0x1CD20D0 VA: 0x1CD20D0
		public IEnumerator Load()
		{
			//0x1CD2230
			if(IsReady)
				yield break;
			yield return AssetBundleManager.LoadAllAssetAsync(BundleName);
			IsReady = true;
		}

		// // RVA: 0x1CD217C Offset: 0x1CD217C VA: 0x1CD217C
		public void Release()
		{
			if (!IsReady)
				return;
			AssetBundleManager.UnloadAssetBundle("ly/cmn.xab", false);
			IsReady = false;
		}
	}
}
