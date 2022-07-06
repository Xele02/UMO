using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Common
{
	public class UGUIObjectPool
	{
		private List<UGUIObject> m_poolList; // 0x8
		private int m_poolSize; // 0xC
		private GameObject m_rootObject; // 0x10
		private bool m_isReady; // 0x14

		public bool IsReady { get { return m_isReady; } } //0x1CD9330

		//// RVA: 0x1CD9338 Offset: 0x1CD9338 VA: 0x1CD9338
		public UGUIObjectPool(GameObject parent, int poolSize)
		{
			m_poolList = new List<UGUIObject>(poolSize);
			m_poolSize = poolSize;
			m_rootObject = parent;
		}

		//// RVA: 0x1CD93D8 Offset: 0x1CD93D8 VA: 0x1CD93D8
		//public void Release() { }

		//// RVA: 0x1CD9528 Offset: 0x1CD9528 VA: 0x1CD9528
		public void Entry(string bundleName, string prefabName, Font font, MonoBehaviour mb)
		{
			mb.StartCoroutine(LoadUGUI(bundleName, prefabName, font));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7400F4 Offset: 0x7400F4 VA: 0x7400F4
		//// RVA: 0x1CD9568 Offset: 0x1CD9568 VA: 0x1CD9568
		private IEnumerator LoadUGUI(string bundleName, string prefabname, Font font)
		{
			AssetBundleLoadUGUIOperationBase operation;
			//0x1CD9868
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, prefabname);
			yield return operation;
			GameObject sourceInstance = null;
			yield return operation.InitializeUGUICoroutine(font, (GameObject instance) =>
			{
				//0x1CD985C
				sourceInstance = instance;
			});
			for(int i = 0; i < m_poolSize; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate<GameObject>(sourceInstance);
				UGUIObject objInfo = new UGUIObject(obj);
				m_poolList.Add(objInfo);
				obj.transform.SetParent(m_rootObject.transform, false);
			}
			Object.DestroyImmediate(sourceInstance);
			yield return null;
			for(int i = 0; i < m_poolList.Count; i++)
			{
				m_poolList[i].instanceObject.gameObject.SetActive(false);
			}
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_isReady = true;
		}

		//// RVA: 0x1CD9660 Offset: 0x1CD9660 VA: 0x1CD9660
		public UGUIObject GetInstance()
		{
			UGUIObject obj = m_poolList[0];
			m_poolList.RemoveAt(0);
			return obj;
		}

		//// RVA: 0x1CD9714 Offset: 0x1CD9714 VA: 0x1CD9714
		//public void Release(UGUIObject uguiObject) { }

	}
}
