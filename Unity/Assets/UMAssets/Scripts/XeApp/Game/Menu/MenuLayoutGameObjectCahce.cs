using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MenuLayoutGameObjectCahce : MonoBehaviour
	{
		private IndexableDictionary<string, LayoutObjectPool> m_layoutInstancePool = new IndexableDictionary<string, LayoutObjectPool>(); // 0xC
		private IndexableDictionary<string, UGUIObjectPool> m_uguiInstancePool = new IndexableDictionary<string, UGUIObjectPool>(); // 0x10
		private IndexableDictionary<string, string> m_dependencyBundleMap = new IndexableDictionary<string, string>(); // 0x14
		private GameObject m_rootObject; // 0x18

		//// RVA: 0xB2C270 Offset: 0xB2C270 VA: 0xB2C270
		private void Awake()
		{
			m_rootObject = new GameObject("MenuLayoutGameObjectCache");
			m_rootObject.transform.SetParent(transform, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6100 Offset: 0x6C6100 VA: 0x6C6100
		//// RVA: 0xB2C348 Offset: 0xB2C348 VA: 0xB2C348
		//public IEnumerator Create(string bundleName, string assetName, string depBundleName, int count, UnityAction action) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C6178 Offset: 0x6C6178 VA: 0x6C6178
		//// RVA: 0xB2C474 Offset: 0xB2C474 VA: 0xB2C474
		public IEnumerator CreateUGUI(string bundleName, string assetName, string depBundleName, int count, UnityAction action)
		{
			UGUIObjectPool pool;
			//0xB2D2D8
			if(!string.IsNullOrEmpty(depBundleName))
			{
				yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(depBundleName));
				m_dependencyBundleMap.Add(assetName, depBundleName);
			}
			pool = new UGUIObjectPool(m_rootObject, count);
			pool.Entry(bundleName, assetName, GameManager.Instance.GetSystemFont(), this);
			m_uguiInstancePool.Add(assetName, pool);
			while(!pool.IsReady)
			{
				yield return null;
			}
			if (action != null)
				action();
		}

		//// RVA: 0xB2C5A0 Offset: 0xB2C5A0 VA: 0xB2C5A0
		public void ReleaseAll()
		{
			for(int i = 0; i < m_layoutInstancePool.Count; i++)
			{
				m_layoutInstancePool[i].Release();
			}
			for(int i = 0; i < m_uguiInstancePool.Count; i++)
			{
				m_uguiInstancePool[i].Release();
			}
			for(int i = 0; i < m_dependencyBundleMap.Count; i++)
			{
				AssetBundleManager.UnloadAssetBundle(m_dependencyBundleMap[i], false);
			}
			m_dependencyBundleMap.Clear();
			m_layoutInstancePool.Clear();
			m_uguiInstancePool.Clear();
		}

		//// RVA: 0xB2C838 Offset: 0xB2C838 VA: 0xB2C838
		public bool IsLoadedObject(string assetName)
		{
			if (m_layoutInstancePool.ContainsKey(assetName))
				return true;
			if (m_uguiInstancePool.ContainsKey(assetName))
				return true;
			return false;
		}

		//// RVA: 0xB2C8F8 Offset: 0xB2C8F8 VA: 0xB2C8F8
		//public void Release(string assetName) { }

		//// RVA: 0xB2CBF4 Offset: 0xB2CBF4 VA: 0xB2CBF4
		//public LayoutObject GetInstance(string assetName) { }

		//// RVA: 0xB2CC94 Offset: 0xB2CC94 VA: 0xB2CC94
		public UGUIObject GetUGUIInstance(string assetName)
		{
			return m_uguiInstancePool[assetName].GetInstance();
		}

		//// RVA: 0xB2CD34 Offset: 0xB2CD34 VA: 0xB2CD34
		//public void ReturnInstance(string assetName, LayoutObject layObj) { }

		//// RVA: 0xB2CDDC Offset: 0xB2CDDC VA: 0xB2CDDC
		public void ReturnUGUIInstance(string assetName, UGUIObject uguiObject)
		{
			m_uguiInstancePool[assetName].Release(uguiObject);
		}
	}
}
