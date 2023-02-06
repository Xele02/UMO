
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnitBonusContentSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x11550DC
		public override string BundleName { get { return "ly/208.xab"; } } //0x1155138
		public override string AssetName { get { return "root_pop_ep_raid_layout_root"; } } //0x1155194
		public override bool IsAssetBundle { get { return true; } } //0x11551F0
		public override bool IsPreload { get { return true; } } //0x11551F8
		public override GameObject Content { get { return m_content; } } //0x1155200

		//// RVA: 0x1155208 Offset: 0x1155208 VA: 0x1155208
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x72EBD4 Offset: 0x72EBD4 VA: 0x72EBD4
										// RVA: 0x1155210 Offset: 0x1155210 VA: 0x1155210 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x11552F4
			m_parent = parent;
			if (m_content != null)
				yield break;

			operation = AssetBundleManager.LoadLayoutAsync(BundleName.ToString(), AssetName.ToString());
			yield return Co.R(operation);

			GameObject content = null;

			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11552E8
				content = instance;
			}));

			yield return Co.R(content.GetComponent<UnitBonusWindow>().LoadContents());
			AssetBundleManager.UnloadAssetBundle(BundleName.ToString());
			m_content = content;
			content.transform.SetParent(m_parent, false);
			content.gameObject.SetActive(false);
			operation = null;
		}
	}
}
