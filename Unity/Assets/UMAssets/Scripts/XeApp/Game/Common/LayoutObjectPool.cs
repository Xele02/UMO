using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class LayoutObjectPool
	{
		private List<LayoutObject> m_poolList; // 0x8
		private int m_poolSize; // 0xC
		private GameObject m_rootObject; // 0x10
		private bool m_isReady; // 0x14

		public bool IsReady { get { return m_isReady; } } //0x1105A54

		// RVA: 0x1105A5C Offset: 0x1105A5C VA: 0x1105A5C
		public LayoutObjectPool(GameObject parent, int poolSize)
		{
			m_poolList = new List<LayoutObject>(poolSize);
			m_poolSize = poolSize;
			m_rootObject = parent;
		}

		//// RVA: 0x1105AFC Offset: 0x1105AFC VA: 0x1105AFC
		public void Release()
		{
			for(int i = 0; i < m_poolList.Count; i++)
			{
				Object.Destroy(m_poolList[i].Runtime.gameObject);
			}
			m_poolList.Clear();
		}

		//// RVA: 0x1105C4C Offset: 0x1105C4C VA: 0x1105C4C
		public void Entry(string bundleName, string prefabName, Font font, MonoBehaviour mb)
		{
			mb.StartCoroutineWatched(LoadLayout(bundleName, prefabName, font));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73CCF0 Offset: 0x73CCF0 VA: 0x73CCF0
		//// RVA: 0x1105C8C Offset: 0x1105C8C VA: 0x1105C8C
		private IEnumerator LoadLayout(string bundleName, string prefabname, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			GameObject prefab; // 0x28

			//0x1106090
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, prefabname);
			yield return operation;

			prefab = operation.GetAsset<GameObject>();
			Layout layout = null;
			TexUVListManager uvMan = null;
			LayoutUGUIRuntime runtime = prefab.GetComponent<LayoutUGUIRuntime>();

			yield return operation.CreateLayoutCoroutine(runtime, font, (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x1106080
				layout = loadLayout;
				uvMan = loadUvMan;
			});

			GameObject go = UnityEngine.Object.Instantiate(prefab);
			go.GetComponent<LayoutUGUIRuntime>().IsLayoutAutoLoad = false;
			if(font != null)
			{
				Text[] ts = go.GetComponentsInChildren<Text>(true);
				for(int i = 0; i < ts.Length; i++)
				{
					ts[i].font = font;
				}
			}
			for(int i = 0; i < m_poolSize; i++)
			{
				GameObject ins = UnityEngine.Object.Instantiate(go);
				LayoutUGUIRuntime runtimeIns = ins.GetComponent<LayoutUGUIRuntime>();
				runtimeIns.IsLayoutAutoLoad = false;
				runtimeIns.Layout = layout.DeepClone();
				runtimeIns.UvMan = uvMan;
				runtimeIns.LoadLayout();
				m_poolList.Add(new LayoutObject(runtimeIns));
				ins.transform.SetParent(m_rootObject.transform, false);
			}
			UnityEngine.Object.DestroyImmediate(go);
			yield return null;
			for(int i = 0; i < m_poolList.Count; i++)
			{
				m_poolList[i].Runtime.gameObject.SetActive(false);
			}
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_isReady = true;
		}

		//// RVA: 0x1105D84 Offset: 0x1105D84 VA: 0x1105D84
		public LayoutObject GetInstance()
		{
			LayoutObject res = m_poolList[0];
			m_poolList.RemoveAt(0);
			return res;
		}

		//// RVA: 0x1105E38 Offset: 0x1105E38 VA: 0x1105E38
		public void Release(LayoutObject layoutObject)
		{
			if(layoutObject.ParentLayout != null)
			{
				LayoutUGUIUtility.RemoveView(layoutObject.Runtime.transform.parent.gameObject, layoutObject.ParentLayout, layoutObject.Runtime.transform.gameObject);
				layoutObject.ParentLayout = null;
			}
			layoutObject.Runtime.transform.SetParent(m_rootObject.transform, false);
			layoutObject.Runtime.gameObject.SetActive(false);
			m_poolList.Add(layoutObject);
		}
	}
}
