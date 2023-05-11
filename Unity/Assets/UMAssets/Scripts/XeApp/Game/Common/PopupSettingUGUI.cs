
using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Common
{
	public abstract class PopupSettingUGUI : PopupSetting
	{

		//[IteratorStateMachineAttribute] // RVA: 0x73F23C Offset: 0x73F23C VA: 0x73F23C
		//								// RVA: 0x1BB295C Offset: 0x1BB295C VA: 0x1BB295C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			AssetBundleLoadUGUIOperationBase operation;

			//0x1BB2A34
			m_parent = parent;
			if(m_content == null)
			{
				operation = AssetBundleManager.LoadUGUIAsync(BundleName, AssetName);
				yield return operation;
				yield return Co.R(operation.InitializeUGUICoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1BB2A28
					m_content = instance;
				}));
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				m_content.transform.SetParent(m_parent, false);
				m_content.gameObject.SetActive(false);
				operation = null;
			}
		}
	}
}
