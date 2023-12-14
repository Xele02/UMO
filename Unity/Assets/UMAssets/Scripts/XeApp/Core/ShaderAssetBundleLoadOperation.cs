
using System.Collections;
using UnityEngine;

namespace XeApp.Core
{ 
	public class ShaderAssetBundleLoadOperation : UnionAssetBundleLoadOperation
	{
		// RVA: 0x1D74D4C Offset: 0x1D74D4C VA: 0x1D74D4C
		public ShaderAssetBundleLoadOperation(string bundleName)
			: base(bundleName)
		{

		}

		//[IteratorStateMachineAttribute] // RVA: 0x748200 Offset: 0x748200 VA: 0x748200
		// RVA: 0x1D74D8C Offset: 0x1D74D8C VA: 0x1D74D8C Slot: 10
		public virtual IEnumerator PreLoadShader(string[] assetName)
		{
			int count; // 0x18
			int loadCount; // 0x1C
			AssetBundleRequest op; // 0x20

			//0x1D74E58
			count = assetName.Length;
			loadCount = 0;
			for(int i = 0; i < count; i++)
			{
				op = m_loadedAssetBundle.m_AssetBundle.LoadAssetAsync(assetName[i], typeof(ShaderVariantCollection));
				yield return op;
				ShaderVariantCollection s = op.asset as ShaderVariantCollection;
				if(s != null)
				{
					if (!s.isWarmedUp)
						s.WarmUp();
				}
				op = null;
				loadCount++;
			}
		}
	}
}
