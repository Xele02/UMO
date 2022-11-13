using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class ValkyrieResource : MonoBehaviour
	{
		public struct IntroOverrideResource
		{
			public AnimationClip idle; // 0x0
			public AnimationClip takeoff; // 0x4

			// // RVA: 0x7FB190 Offset: 0x7FB190 VA: 0x7FB190
			// public void Release() { }
		}
 
		public struct BattleOverrideResource
		{
			public AnimationClip begin; // 0x0
			public AnimationClip gerwalkMain; // 0x4
			public AnimationClip gerwalkDamage; // 0x8
			public AnimationClip tranfsorm; // 0xC
			public AnimationClip battroidMain; // 0x10
			public AnimationClip battroidDamage; // 0x14
			public AnimationClip battroidEnd; // 0x18
			public AnimationClip shootMain; // 0x1C
			public AnimationClip shootBatroidMain; // 0x20

			// // RVA: 0x7FB114 Offset: 0x7FB114 VA: 0x7FB114
			// public void Release() { }
		}

		public struct MenuOverrideResource
		{
			public AnimationClip[] wait; // 0x0
			public AnimationClip[] change; // 0x4

			// // RVA: 0x7FB1FC Offset: 0x7FB1FC VA: 0x7FB1FC
			// public void Release() { }
		}

		public struct UnlockOverrideResource
		{
			public AnimationClip unlock; // 0x0

			// // RVA: 0x7FB260 Offset: 0x7FB260 VA: 0x7FB260
			// public void Release() { }
		}

		public struct AppealOverrideResource
		{
			public AnimationClip appeal; // 0x0

			// // RVA: 0x7FB0AC Offset: 0x7FB0AC VA: 0x7FB0AC
			// public void Release() { }
		}

		private static readonly string[] s_formTypeId = new string[3] { "F", "G", "B" }; // 0x0
		public const int MATERIAL_MAX = 2;
		private Dictionary<int, Material> m_materialAwakeHigh = new Dictionary<int, Material>(); // 0x14
		private Dictionary<int, Material> m_materialAwakeLow = new Dictionary<int, Material>(); // 0x18
		public IntroOverrideResource introOverrideResource; // 0x1C
		public BattleOverrideResource battleOverrideResource; // 0x24
		public MenuOverrideResource menuOverrideResource; // 0x48
		public UnlockOverrideResource unlockOverrideResource; // 0x50
		public AppealOverrideResource appealOverrideResource; // 0x54
		// public static string ParamBundleName { get; } 0xD2B918
		// public static string CommonBundleName { get; } 0xD2B974
		// public static string BundleNameFormat { get; } 0xD2B9D0
		public GameObject prefab { get; private set; } // 0xC
		public RuntimeAnimatorController animatorController { get; private set; } // 0x10
		public Dictionary<int, Material> materialAwakeHigh { get {return m_materialAwakeHigh; } private set { m_materialAwakeHigh = value; } } //0xD2BA3C 0xD2BA44
		// public Dictionary<int, Material> materialAwakeLow { get; private set; } 0xD2BA4C 0xD2BA54
		public bool isLoadedPrefab { get; private set; } // 0x58
		public bool isAllLoaded { get { return isLoadedPrefab; } } //0xD2BA6C

		// // RVA: 0xD2BA74 Offset: 0xD2BA74 VA: 0xD2BA74
		public void OnDestroy()
		{
			TodoLogger.Log(0, "Valkyrie resource OnDestroy");
		}

		// // RVA: 0xD2BBF8 Offset: 0xD2BBF8 VA: 0xD2BBF8
		public void LoadResources(int valkyrieId, int envId, int battleId)
		{
			isLoadedPrefab = false;
			StartCoroutine(Co_LoadResources(valkyrieId, envId, battleId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73C4D0 Offset: 0x73C4D0 VA: 0x73C4D0
		// // RVA: 0xD2BC30 Offset: 0xD2BC30 VA: 0xD2BC30
		private IEnumerator Co_LoadResources(int valkyrieId, int envId, int battleId)
		{
			StringBuilder bundleName; // 0x24
			StringBuilder assetName; // 0x28
			short modelId; // 0x2C
			int subId_Intro; // 0x30
			int subId_Battle; // 0x34
			//int i; // 0x38

			//0xD2C5C0
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[valkyrieId - 1];
			modelId = valkInfo.DAJGPBLEEOB_ModelId;
			subId_Intro = 0;
			subId_Battle = 0;
			bundleName.SetFormat("vl/param_vl.xab", Array.Empty<string>());
			assetName.SetFormat("param_vl_common", Array.Empty<string>());

			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			ParamValkyrieCommon data = operation.GetAsset<ParamValkyrieCommon>(assetName.ToString());
			if(data != null)
			{
				for(int i = 0; i < data.m_table_intro.Count; i++)
				{
					if(data.m_table_intro[i].m_asset_id == envId)
					{
						subId_Intro = data.m_table_intro[i].m_motion_sub_id;
					}
				}
				for (int i = 0; i < data.m_table_battle.Count; i++)
				{
					if (data.m_table_battle[i].m_asset_id == battleId)
					{
						subId_Battle = data.m_table_battle[i].m_motion_sub_id;
					}
				}
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			bundleName.SetFormat("vl/{0:D4}.xab", modelId);
			assetName.SetFormat("val_{0:D4}_prefab", modelId);

			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			prefab = operation.GetAsset<GameObject>(assetName.ToString());
			m_materialAwakeHigh = new Dictionary<int, Material>();
			m_materialAwakeLow = new Dictionary<int, Material>();

			for (int cnt = 0; cnt <= 1; cnt++)
			{
				if (cnt == 0)
					assetName.SetFormat("val_{0:D4}_Awake_H", modelId);
				else
					assetName.SetFormat("val_{0:D4}_{1:D2}_Awake_H", modelId, cnt + 1);

				//operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
				//yield return operation;
				m_materialAwakeHigh[cnt] = operation.GetAsset<Material>(assetName.ToString());

				if (cnt == 0)
					assetName.SetFormat("val_{0:D4}_Awake_L", modelId);
				else
					assetName.SetFormat("val_{0:D4}_{1:D2}_Awake_L", modelId, cnt + 1);
				//operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
				//yield return operation;

				m_materialAwakeLow[cnt] = operation.GetAsset<Material>(assetName.ToString());
			}

			introOverrideResource.idle = GetAnimClip(operation, assetName, "_it_idle", modelId, subId_Intro);
			introOverrideResource.takeoff = GetAnimClip(operation, assetName, "_it_takeoff", modelId, subId_Intro);
			battleOverrideResource.begin = GetAnimClip(operation, assetName, "_bt_G_begin", modelId, subId_Battle);
			battleOverrideResource.gerwalkMain = GetAnimClip(operation, assetName, "_bt_G_main", modelId, subId_Battle);
			battleOverrideResource.gerwalkDamage = GetAnimClip(operation, assetName, "_bt_G_damage", modelId, subId_Battle);
			battleOverrideResource.tranfsorm = GetAnimClip(operation, assetName, "_bt_G_g_to_b", modelId, subId_Battle);
			battleOverrideResource.battroidMain = GetAnimClip(operation, assetName, "_bt_B_main", modelId, subId_Battle);
			battleOverrideResource.battroidDamage = GetAnimClip(operation, assetName, "_bt_B_damage", modelId, subId_Battle);
			battleOverrideResource.battroidEnd = GetAnimClip(operation, assetName, "_bt_B_end", modelId, subId_Battle);
			battleOverrideResource.shootMain = GetAnimClip(operation, assetName, "_bt_G_s_main", modelId, subId_Battle);
			battleOverrideResource.shootBatroidMain = GetAnimClip(operation, assetName, "_bt_B_s_main", modelId, subId_Battle);

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			bundleName.Set("vl/cmn.xab");
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			prefab.GetComponent<EffectFactoryCollector>().RedirectionAll((string name) =>
			{
				//0xD2C3D8
				return operation.GetAsset<GameObject>(name);
			});
			assetName.Set("val_cmn_animator");
			animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			isLoadedPrefab = true;
		}

		// // RVA: 0xD2BD28 Offset: 0xD2BD28 VA: 0xD2BD28
		private AnimationClip GetAnimClip(AssetBundleLoadAllAssetOperationBase a_op, StringBuilder a_sb, string a_str1, int a_model_id, int a_motion_sub_id)
		{
			AnimationClip res = null;
			if (a_motion_sub_id >= 1)
			{
				a_sb.SetFormat("val_{0:D4}_{1:D4}{2}", a_model_id, a_motion_sub_id, a_str1);
				res = a_op.GetAsset<AnimationClip>(a_sb.ToString());
			}
			if(res == null)
			{
				a_sb.SetFormat("val_{0:D4}{1}", a_model_id, a_str1);
				res = a_op.GetAsset<AnimationClip>(a_sb.ToString());
			}
			return res;
		}

		// // RVA: 0xD2BF6C Offset: 0xD2BF6C VA: 0xD2BF6C
		// public void LoadResourcesForMenu(int valkyrieId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73C548 Offset: 0x73C548 VA: 0x73C548
		// // RVA: 0xD2BF9C Offset: 0xD2BF9C VA: 0xD2BF9C
		// private IEnumerator Co_LoadResourcesMenu(int valkyrieId) { }

		// // RVA: 0xD2C064 Offset: 0xD2C064 VA: 0xD2C064
		// public void LoadResourcesForAppeal(int valkyrieId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73C5C0 Offset: 0x73C5C0 VA: 0x73C5C0
		// // RVA: 0xD2C094 Offset: 0xD2C094 VA: 0xD2C094
		// private IEnumerator Co_LoadResourcesForAppeal(int valkyrieId) { }
	}
}
