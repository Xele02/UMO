using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class ValkyrieModeResource : MonoBehaviour
	{
		public GameObject mainPrefab { get; private set; } // 0xC
		public ValkyrieColorParam paramColor { get; private set; } // 0x10
		public AnimationClip changeCameraBeginAnimClip { get; private set; } // 0x14
		public bool isLoadedMain { get; private set; } // 0x18
		public bool isAllLoaded { get { return isLoadedMain; } } //0xD27000

		// // RVA: 0xD27008 Offset: 0xD27008 VA: 0xD27008
		public void OnDestroy()
		{
			isLoadedMain = false;
			mainPrefab = null;
		}

		// // RVA: 0xD27018 Offset: 0xD27018 VA: 0xD27018
		public void LoadResources(int id, int valkyrie_id)
		{
			isLoadedMain = false;
			this.StartCoroutineWatched(Co_LoadResources(id, valkyrie_id));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73CB00 Offset: 0x73CB00 VA: 0x73CB00
		// // RVA: 0xD27048 Offset: 0xD27048 VA: 0xD27048
		private IEnumerator Co_LoadResources(int id, int valkyrie_id)
		{
			StringBuilder bundleName; // 0x20
			StringBuilder assetName; // 0x24
			GameObject tmpRoot; // 0x28

			//0xD271E4
			bundleName = new StringBuilder();
			assetName = new StringBuilder();

			bundleName.SetFormat("gm/bt/{0:D4}.xab", id);
			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operation);

			assetName.SetFormat("game_bt_{0:D4}_prefab", id);
			mainPrefab = operation.GetAsset<GameObject>(assetName.ToString());

			assetName.SetFormat("game_bt_{0:D4}_color", id);
			paramColor = operation.GetAsset<ValkyrieColorParam>(assetName.ToString());

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			bundleName.Set("gm/bt/cmn.xab");
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operation);

			assetName.SetFormat("val_{0:D4}_bt_cam_start", valkyrie_id);
			changeCameraBeginAnimClip = operation.GetAsset<AnimationClip>(assetName.ToString());

			mainPrefab.GetComponent<EffectFactoryBase>().Redirection((string name) =>
			{
				//0xD27138
				return operation.GetAsset<GameObject>(name);
			});

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			bool fin = false;
			tmpRoot = Instantiate(mainPrefab);
			tmpRoot.layer = LayerMask.NameToLayer("Default");
			WarmupTexturesGenerator.Instance.Create(tmpRoot, () =>
			{
				//0xD271D4
				fin = true;
			});
			while(!fin)
			{
				yield return null;
			}
			Destroy(tmpRoot);
			isLoadedMain = true;
		}
	}
}
