
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class CostumeSelectDivaResrouce : DivaResource
	{
		private StringBuilder bundleName = new StringBuilder(64); // 0x15C
		private StringBuilder assetName = new StringBuilder(64); // 0x160
		private StringBuilder strBuilder = new StringBuilder(64); // 0x164
		public List<List<Material>> materialList = new List<List<Material>>(); // 0x168
		public List<MotionOverrideSingleResource> overrideClipList = new List<MotionOverrideSingleResource>(); // 0x16C

		//// RVA: 0xE6898C Offset: 0xE6898C VA: 0xE6898C
		public void Initialize(int divaId)
		{
			m_loadedDivaId = divaId;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73617C Offset: 0x73617C VA: 0x73617C
		//								// RVA: 0xE68994 Offset: 0xE68994 VA: 0xE68994
		public IEnumerator Co_LoadBasicResource()
		{
			int loadCount; // 0x14
			AssetBundleLoadAssetOperation op; // 0x18

			//0xE694C0
			ReleaseBasic();
			loadCount = 0;
			bundleName.SetFormat("dv/ca/cmn.xab", System.Array.Empty<object>());

			op = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "diva_cmn_animator", typeof(RuntimeAnimatorController));
			yield return Co.R(op);
			divaAnimatorController = op.GetAsset<RuntimeAnimatorController>();
			loadCount++;

			op = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "med_cmn_animator", typeof(RuntimeAnimatorController));
			yield return Co.R(op);
			facialAnimatorController = op.GetAsset<RuntimeAnimatorController>();
			loadCount++;

			op = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "menu_diva_param", typeof(DivaMenuParam));
			yield return Co.R(op);
			divaMenuParam = op.GetAsset<DivaMenuParam>();
			loadCount++;

			op = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "diva_cmn_menu_talk_mouth", typeof(AnimationClip));
			yield return Co.R(op);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_start_mouth", op.GetAsset<AnimationClip>(), MotionOverrideSingleResource.Target.Mouth));
			loadCount++;

			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			loadCount = 0;

			bundleName.SetFormat("dv/ca/{0:D3}.xab", m_loadedDivaId);

			assetName.SetFormat("diva_{0:D3}_param", m_loadedDivaId);
			op = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(DivaParam));
			yield return Co.R(op);
			divaParam = op.GetAsset<DivaParam>();
			loadCount++;

			for (int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
		}

		//// RVA: 0xE68A40 Offset: 0xE68A40 VA: 0xE68A40
		private void ReleaseBasic()
		{
			divaAnimatorController = null;
			facialAnimatorController = null;
			divaMenuParam = null;
			divaParam = null;
			overrideClipList.Clear();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7361F4 Offset: 0x7361F4 VA: 0x7361F4
		//								// RVA: 0xE68ACC Offset: 0xE68ACC VA: 0xE68ACC
		public IEnumerator Co_LoadFacialClip(DivaResource.MenuFacialType type)
		{
			AssetBundleLoadAllAssetOperationBase operation;
			List<string> originalFacesName;
			List<int> overrideFacesId;

			//0xE6ADAC
			ReleaseFacial();
			if(commonFacialResource == null)
				commonFacialResource = new List<FacialOverrideResouece>();
			if(specialFacialResource == null)
				specialFacialResource = new List<FacialOverrideResouece>();
			if(type < MenuFacialType.Result)
			{
				bundleName.SetFormat("mn/ft.xab", Array.Empty<object>());
			}
			else
			{
				bundleName.SetFormat("re/ft.xab", Array.Empty<object>());
			}
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("facial_table", Array.Empty<object>());
			TextAsset facialTableAsset = operation.GetAsset<TextAsset>(assetName.ToString());
			originalFacesName = new List<string>();
			overrideFacesId = new List<int>();
			FacialNameDatabase.CreateFacialOverrideList(facialTableAsset, m_loadedDivaId, ref originalFacesName, ref overrideFacesId);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			bundleName.SetFormat("dv/ca/{0:D3}.xab", m_loadedDivaId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			for(int i = 0; i < DivaCommonFacialAnimNames.Length; i++)
			{
				assetName.SetFormat("diva_{0:D3}_{1}", m_loadedDivaId, DivaCommonFacialAnimNames[i]);
				commonFacialResource.Add(new FacialOverrideResouece() { originalName = DivaCommonFacialAnimNames[i], overrideClip = operation.GetAsset<AnimationClip>(assetName.ToString()) });
			}
			specialFacialResource = new List<FacialOverrideResouece>();
			for(int i = 0; i < originalFacesName.Count; i++)
			{
				if(overrideFacesId[i] > 0)
				{
					assetName.SetFormat("diva_{0:D3}_{1}", m_loadedDivaId, FacialNameDatabase.ToString(overrideFacesId[i]));
					specialFacialResource.Add(new FacialOverrideResouece() { originalName = originalFacesName[i], overrideClip = operation.GetAsset<AnimationClip>(assetName.ToString()) });
				}
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		//// RVA: 0xE68B94 Offset: 0xE68B94 VA: 0xE68B94
		private void ReleaseFacial()
		{
			if(commonFacialResource != null)
			{
				for(int i = 0; i < commonFacialResource.Count; i++)
				{
					commonFacialResource[i].Release();
				}
				commonFacialResource.Clear();
			}
			if (specialFacialResource != null)
			{
				for(int i = 0; i < specialFacialResource.Count; i++)
				{
					specialFacialResource[i].Release();
				}
				specialFacialResource.Clear();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73626C Offset: 0x73626C VA: 0x73626C
		//								// RVA: 0xE68D60 Offset: 0xE68D60 VA: 0xE68D60
		public IEnumerator Co_LoadMotion()
		{
			AssetBundleLoadAllAssetOperationBase operationDiva;

			//0xE6B8B0
			bundleName.SetFormat("dv/ca/{0:D3}.xab", m_loadedDivaId);
			operationDiva = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operationDiva);

			strBuilder.SetFormat("diva_{0:D3}_menu_idle_body", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_idle_body", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Body));

			strBuilder.SetFormat("diva_{0:D3}_menu_idle_face", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_idle_face", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Face));

			strBuilder.SetFormat("diva_{0:D3}_menu_idle_body", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_idle_mouth", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Mouth));

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			bundleName.SetFormat("dv/cl/cs/{0:D3}.xab", m_loadedDivaId);
			operationDiva = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operationDiva);

			strBuilder.SetFormat("diva_{0:D3}_start_body", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_start_body", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Body));

			strBuilder.SetFormat("diva_{0:D3}_start_face", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_start_face", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Face));

			strBuilder.SetFormat("diva_{0:D3}_loop_body", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_loop_body", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Body));

			strBuilder.SetFormat("diva_{0:D3}_loop_face", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_loop_face", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Face));

			strBuilder.SetFormat("diva_{0:D3}_end_body", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_end_body", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Body));

			strBuilder.SetFormat("diva_{0:D3}_end_face", m_loadedDivaId);
			overrideClipList.Add(new MotionOverrideSingleResource("diva_cmn_simple_loop_end_face", operationDiva.GetAsset<AnimationClip>(strBuilder.ToString()), MotionOverrideSingleResource.Target.Face));

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7362E4 Offset: 0x7362E4 VA: 0x7362E4
		//								// RVA: 0xE68E0C Offset: 0xE68E0C VA: 0xE68E0C
		public IEnumerator Co_LoadCostume(int modelId, UnityAction coroutineEnd)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosMaster; // 0x24
			AssetBundleLoadAllAssetOperationBase operation; // 0x28
			int i; // 0x2C

			//0xE69F54
			cosMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(m_loadedDivaId, modelId);
			if(cosMaster.GLEEPAFMPLO_HasTextureBundle)
			{
				for(i = 0; i < 2; i++)
				{
					bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}_{2:D2}.xab", m_loadedDivaId, modelId, i);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(bundleName.ToString());
				}
			}
			bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}.xab", m_loadedDivaId, modelId);
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(bundleName.ToString());
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;

			bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}.xab", m_loadedDivaId, modelId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operation);

			assetName.SetFormat("diva_{0:D3}_cos_{1:D3}_prefab", m_loadedDivaId, modelId);
			divaPrefab = operation.GetAsset<GameObject>(assetName.ToString());

			List<Material> mtlList = new List<Material>();
			if (cosMaster.GLEEPAFMPLO_HasTextureBundle)
			{
				mtlList.Clear();
				operation.ForEach((UnityEngine.Object obj) =>
				{
					//0xE69244
					if(obj is Material)
					{
						mtlList.Add(obj as Material);
					}
				});
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			if (cosMaster.GLEEPAFMPLO_HasTextureBundle)
			{
				for (i = 0; i < 2; i++)
				{
					bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}_{2:D2}.xab", m_loadedDivaId, modelId, i);
					operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
					yield return Co.R(operation);

					List<Texture> list = new List<Texture>();
					operation.ForEach((UnityEngine.Object obj) =>
					{
						//0xE693BC
						if(obj is Texture)
						{
							list.Add(obj as Texture);
						}
					});
					AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

					List<Material> m = new List<Material>();
					for (int j = 0; j < mtlList.Count; j++)
					{
						m.Add(new Material(mtlList[j]));
					}
					SetCostumeColorTexture(m, list);
					materialList.Add(m);
				}
			}
			yield return Co.R(Co_LoadComponent(m_loadedDivaId, modelId, (List<GameObject> a, GameObject b) =>
			{
				//0xE69344
				prefabEffect = a;
				prefabWind = b;
			}));
			yield return Co.R(Co_LoadBoneSpringSuppress(m_loadedDivaId, modelId, (Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam> a) =>
			{
				//0xE6938C
				boneSpringResource.suppress.presets = a;
			}));
			if (coroutineEnd != null)
				coroutineEnd();
		}

		//// RVA: 0xE68EEC Offset: 0xE68EEC VA: 0xE68EEC
		public void ReleaseCostume()
		{
			for(int i = 0; i < materialList.Count; i++)
			{
				for(int j = 0; j < materialList[i].Count; j++)
				{
					materialList[i][j] = null;
				}
			}
			materialList.Clear();
			divaPrefab = null;
			if (prefabEffect != null)
			{
				prefabEffect.Clear();
				prefabEffect = null;
			}
			boneSpringResource.Release();
		}

		//// RVA: 0xE690CC Offset: 0xE690CC VA: 0xE690CC
		public void Release()
		{
			ReleaseBasic();
			ReleaseFacial();
			ReleaseCostume();
		}
	}
}
