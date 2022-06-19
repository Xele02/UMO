using UnityEngine;
using XeApp.Game.Common;
using System.Text;
using XeSys;
using XeApp.Core;
using System.Collections;

namespace XeApp.Game.RhythmGame
{
	public class RhytmGameParameterResource : MonoBehaviour
	{
		public bool isRequestLoad; // 0xC
		public bool isLoaded; // 0xD
		public ParameterData_ValkyrieAwake m_paramValkyrieAwake; // 0x10
		public ParameterData_ValkyrieChangeExplosion m_paramValkyrieChangeExplosion; // 0x14
		public ParameterData_ValkyrieChangeIntro m_paramIntro; // 0x18
		public ParameterData_ValkyrieChangeBattle m_paramBattle; // 0x1C
		public ParameterData_ValkyrieChangeEnemy m_paramEnemy; // 0x20

		// // RVA: 0x1551C0C Offset: 0x1551C0C VA: 0x1551C0C
		public void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1551C88 Offset: 0x1551C88 VA: 0x1551C88
		public void LoadResource()
		{
			isRequestLoad = true;
			StartCoroutine(Co_LoadResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74640C Offset: 0x74640C VA: 0x74640C
		// // RVA: 0x1551CB8 Offset: 0x1551CB8 VA: 0x1551CB8
		private IEnumerator Co_LoadResource()
		{
    		UnityEngine.Debug.Log("Enter Co_LoadResource");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public RhytmGameParameterResource <>4__this; // 0x10
			// private StringBuilder <t_name_bundle>5__2; // 0x14
			// private StringBuilder <t_name_asset>5__3; // 0x18
			// private AssetBundleLoadAllAssetOperationBase <t_operation>5__4; // 0x1C
			// 0x1551D70
			StringBuilder name_bundle = new StringBuilder();
			StringBuilder name_asset = new StringBuilder();

			name_bundle.Set("vl/param_vl.xab");
			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(name_bundle.ToString());
			yield return operation;

			name_asset.Set("param_vl_awake");
			m_paramValkyrieAwake = new ParameterData_ValkyrieAwake();
			TextAsset text_asset = operation.GetAsset<TextAsset>(name_asset.ToString());
			m_paramValkyrieAwake.Create(text_asset);

			name_asset.Set("param_vl_change_explosion");
			m_paramValkyrieChangeExplosion = new ParameterData_ValkyrieChangeExplosion();
			text_asset = operation.GetAsset<TextAsset>(name_asset.ToString());
			m_paramValkyrieChangeExplosion.Create(text_asset);

			name_asset.Set("param_vl_change_intro");
			m_paramIntro = new ParameterData_ValkyrieChangeIntro();
			text_asset = operation.GetAsset<TextAsset>(name_asset.ToString());
			m_paramIntro.Create(text_asset);

			name_asset.Set("param_vl_change_battle");
			m_paramBattle = new ParameterData_ValkyrieChangeBattle();
			text_asset = operation.GetAsset<TextAsset>(name_asset.ToString());
			m_paramBattle.Create(text_asset);

			name_asset.Set("param_vl_change_enemy");
			m_paramEnemy = new ParameterData_ValkyrieChangeEnemy();
			text_asset = operation.GetAsset<TextAsset>(name_asset.ToString());
			m_paramEnemy.Create(text_asset);

			AssetBundleManager.UnloadAssetBundle(name_bundle.ToString(), false);

			isLoaded = true;
    		UnityEngine.Debug.Log("Exit Co_LoadResource");
		}
	}
}
