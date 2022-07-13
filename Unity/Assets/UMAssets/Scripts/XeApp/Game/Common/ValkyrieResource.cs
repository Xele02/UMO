using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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
		public ValkyrieResource.IntroOverrideResource introOverrideResource; // 0x1C
		public ValkyrieResource.BattleOverrideResource battleOverrideResource; // 0x24
		public ValkyrieResource.MenuOverrideResource menuOverrideResource; // 0x48
		public ValkyrieResource.UnlockOverrideResource unlockOverrideResource; // 0x50
		public ValkyrieResource.AppealOverrideResource appealOverrideResource; // 0x54
		// public static string ParamBundleName { get; } 0xD2B918
		// public static string CommonBundleName { get; } 0xD2B974
		// public static string BundleNameFormat { get; } 0xD2B9D0
		public GameObject prefab { get; private set; } // 0xC
		public RuntimeAnimatorController animatorController { get; private set; } // 0x10
		// public Dictionary<int, Material> materialAwakeHigh { get; private set; } 0xD2BA3C 0xD2BA44
		// public Dictionary<int, Material> materialAwakeLow { get; private set; } 0xD2BA4C 0xD2BA54
		public bool isLoadedPrefab { get; private set; } // 0x58
		public bool isAllLoaded { get { return isLoadedPrefab; } } //0xD2BA6C

		// // RVA: 0xD2BA74 Offset: 0xD2BA74 VA: 0xD2BA74
		// public void OnDestroy() { }

		// // RVA: 0xD2BBF8 Offset: 0xD2BBF8 VA: 0xD2BBF8
		public void LoadResources(int valkyrieId, int envId, int battleId)
		{
			isLoadedPrefab = false;
			StartCoroutine(Co_LoadResources(valkyrieId, envId, battleId));
			UnityEngine.Debug.LogError("TODO LoadResources");
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
			int i; // 0x38

			//0xD2C5C0
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			//IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.
			UnityEngine.Debug.LogError("TODO Valk Co_LoadResources, need load DB valkyrie data");
			isLoadedPrefab = true;
			yield break;
		}

		// // RVA: 0xD2BD28 Offset: 0xD2BD28 VA: 0xD2BD28
		// private AnimationClip GetAnimClip(AssetBundleLoadAllAssetOperationBase a_op, StringBuilder a_sb, string a_str1, int a_model_id, int a_motion_sub_id) { }

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
