using System;
using System.Collections;
using UnityEngine;

namespace XeApp.Core
{	
	public abstract class AssetBundleLoadUGUIOperationBase : AssetBundleLoadAssetOperationFull
	{
		// RVA: 0xE117BC Offset: 0xE117BC VA: 0xE117BC
		public AssetBundleLoadUGUIOperationBase(string bundleName, string prefabName) : base(bundleName, prefabName, typeof(GameObject))
		{
			return;
		}

		// RVA: -1 Offset: -1 Slot: 11
		public abstract IEnumerator InitializeUGUICoroutine(Font font, Action<GameObject> finish);
	}
}
