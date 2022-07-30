using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;
using System.Collections;
using XeApp.Game.Menu;
using System;
using System.Text;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaResource : MonoBehaviour
	{
		public enum MenuFacialType
		{
			Home,
			Costume,
			Result
		}

		public struct FacialOverrideResouece
		{
			public string originalName; // 0x0
			public AnimationClip overrideClip; // 0x4
		}

		public struct MotionOverrideClipKeyResource
		{
			public struct Pair
			{
				public string name; // 0x0
				public AnimationClip clip; // 0x4
			}

			public Pair body; // 0x0
			public Pair face; // 0x8
			public Pair mouth; // 0x10

			// RVA: 0x1C09618 Offset: 0x1C09618 VA: 0x1C09618
			//public static DivaResource.MotionOverrideClipKeyResource Set(string keyFormat, string replaceClipName, int id, AssetBundleLoadAllAssetOperationBase op, StringBuilder strBuilder) { }
		}
		
		public struct MotionOverrideSingleResource
		{
			public enum Target
			{
				Body,
				Face,
				Mouth
			}

			public string name; // 0x0
			public AnimationClip clip; // 0x4
			public Target target; // 0x8

			// RVA: 0x7FF4E4 Offset: 0x7FF4E4 VA: 0x7FF4E4
			public MotionOverrideSingleResource(string name, AnimationClip clip, DivaResource.MotionOverrideSingleResource.Target target)
			{
				this.name = name;
				this.clip = clip;
				this.target = target;
			}
		}

		public struct MotionOverrideResource
		{
			public AnimationClip bodyClip; // 0x0
			public AnimationClip faceBlendClip; // 0x4
			public AnimationClip mouthBlendClip; // 0x8
		}

		public struct MenuMotionOverrideResource
		{
			public struct Reaction
			{
				public MotionOverrideResource main; // 0x0
			}
			
			public struct Talk
			{
				public MotionOverrideResource begin; // 0x0
				public MotionOverrideResource main; // 0xC
				public MotionOverrideResource end; // 0x18
			}
 
			public struct Timezone
			{
				public MotionOverrideResource main; // 0x0
			}

			public MotionOverrideResource idle; // 0x0
			public List<Reaction> reactions; // 0xC
			public List<Talk> talk; // 0x10
			public List<Timezone> timezone; // 0x14
			public List<Reaction> present; // 0x18
			public List<Reaction> simpletalk; // 0x1C
		}

		public struct ResultMotionOverrideResource
		{
			public MotionOverrideResource wait; // 0x0
			public MotionOverrideResource start; // 0xC
			public MotionOverrideResource end; // 0x18
			public MotionOverrideResource winStart; // 0x24
			public MotionOverrideResource winEnd; // 0x30
			public MotionOverrideResource loseStart; // 0x3C
			public MotionOverrideResource loseEnd; // 0x48
		}

		public struct LoginMotionOverrideResource
		{
			public struct Reaction
			{
				public MotionOverrideResource begin; // 0x0
				public MotionOverrideResource end; // 0xC
			}

			public MotionOverrideResource idle; // 0x0
			public List<Reaction> reactions; // 0xC
		}

		public struct UnlockMotionOverrideResource
		{
			public MotionOverrideResource wait; // 0x0
			public MotionOverrideResource start; // 0xC
			public MotionOverrideResource end; // 0x18
		}

		public struct UnlockCostumeMotionOverrideResource
		{
			public DivaResource.MotionOverrideResource pose; // 0x0
			public DivaResource.MotionOverrideResource start; // 0xC
			public DivaResource.MotionOverrideResource end; // 0x18
		}

		public struct BoneSpringSuppressResource
		{
			public Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam> presets; // 0x0
		}

		public struct BoneSpringResource
		{
			public BoneSpringSuppressResource suppress; // 0x0
		}

		public enum SetupFlags
		{
			Default = 0,
			Manual = 1
		}
		
		private static string[] divaCommonFacialAnimName = new string[18]
			{
				"face_exp_normal",
				"face_exp_joy",
				"face_exp_laugh",
				"face_exp_smile",
				"face_eye_close",
				"mouth_exp_normal",
				"mouth_exp_joy",
				"mouth_exp_laugh",
				"mouth_exp_smile",
				"mouth_exp_sorrow",
				"mouth_lip_A",
				"mouth_lip_I",
				"mouth_lip_U",
				"mouth_lip_E",
				"mouth_lip_O",
				"mouth_lip_N",
				"mouth_lip_bigA",
				"mouth_lip_bigO"
			}; // 0x0
		public static readonly int MAX_REACTION = 5; // 0x4
		public static readonly int MAX_TALK = 2; // 0x8
		public static readonly int MAX_PRESENT = 1; // 0xC
		public static readonly int MAX_SIMPLE_TALK = 1; // 0x10
		public DivaParam divaParam; // 0xC
		public GameObject divaPrefab; // 0x10
		public GameObject mikePrefab; // 0x14
		public GameObject mikeStandPrefab; // 0x18
		public GameObject mikeCommonPrefab; // 0x1C
		public List<GameObject> prefabEffect; // 0x20
		public GameObject prefabWind; // 0x24
		public RuntimeAnimatorController divaAnimatorController; // 0x28
		public RuntimeAnimatorController facialAnimatorController; // 0x2C
		public RuntimeAnimatorController mikeStandAnimatorController; // 0x30
		public DivaMenuParam divaMenuParam; // 0x34
		public MotionOverrideResource musicMotionOverrideResource; // 0x38
		public MenuDivaVoiceTable menuVoiceTable; // 0x44
		public MenuDivaVoiceTableCos menuVoiceTableCos; // 0x48
		public MenuMotionOverrideResource menuMotionOverride; // 0x4C
		public ResultMotionOverrideResource resultMotionOverride; // 0x6C
		public LoginMotionOverrideResource loginMotionOverride; // 0xC0
		public UnlockMotionOverrideResource unlockMotionOverride; // 0xD0
		public UnlockCostumeMotionOverrideResource unlockCostumeMotionOverride; // 0xF4
		public List<FacialOverrideResouece> commonFacialResource = new List<FacialOverrideResouece>(); // 0x118
		public List<FacialOverrideResouece> specialFacialResource = new List<FacialOverrideResouece>(); // 0x11C
		public AnimationClip mikeStandAnimationOverrideClip; // 0x120
		public BoneSpringResource boneSpringResource; // 0x124
		public SetupFlags setupFlags; // 0x128
		public GameObject subDivaPrefab; // 0x12C
		public List<GameObject> subPrefabEffect; // 0x130
		public GameObject subPrefabWind; // 0x134
		public BoneSpringResource subBoneSpringResource; // 0x138
		protected int m_loadedDivaId = -1; // 0x140
		protected int m_loadedModelId = -1; // 0x144
		protected int m_loadedColorId = -1; // 0x148
		private bool isLoadedSimpleResource; // 0x156

		protected static string[] DivaCommonFacialAnimNames { get { return divaCommonFacialAnimName; } } // get_DivaCommonFacialAnimNames 0x1BF7F5C
		public bool IsSetupAuto { get { return setupFlags == 0; } } // get_IsSetupAuto 0x1BF2E10
		public bool isLoadedFacialNameDatabase { get { return true; } set {} } // get_isLoadedFacialNameDatabase 0x1BF87D8 // set_isLoadedFacialNameDatabase 0x1BF8580 
		public bool isLoadedBasicResource { get; set; }  // 0x13C
		public int LoadedDivaId { get { return m_loadedDivaId; } } // get_LoadedDivaId 0x1BF87E8 
		public int LoadedModelId { get { return m_loadedModelId; } } // get_LoadedModelId 0x1BF264C
		public int LoadedColorId { get { return m_loadedColorId; } } // get_LoadedColorId 0x1BF2654
		public bool isLoadedMusicAnimationResource { get; set; }  // 0x14C
		public bool isLoadedARMusicAnimationResource { get; set; } // 0x14D
		public int positionId { get; set; } // 0x150
		public bool isLoadedMusicFacialResource { get; set; } // 0x154
		public bool isMusicAllLoaded { get { return isLoadedBasicResource && isLoadedMusicFacialResource && isLoadedMusicAnimationResource; } set {} } // get_isMusicAllLoaded 0x1BF9814 set_isMusicAllLoaded 0x1BF9840 
		public bool isLoadedMenuAnimationResource { get; set; } // 0x155
		public bool isMenuAllLoaded { get { return isLoadedBasicResource && isLoadedMenuAnimationResource; } set {} } // get_isMenuAllLoaded 0x1BF9E54 set_isMenuAllLoaded 0x1BF9E74  
		public bool IsSimpleLoaded { get { return isLoadedBasicResource && isLoadedSimpleResource; } } // get_IsSimpleLoaded 0x1BF9F84 
		public bool isLoadedSubCostumeResource { get; set; } // 0x157
		public bool isLoadedRivalResultAnimationResource { get; set; } // 0x158
		public bool isRivalResultAllLoaded { get { return isLoadedBasicResource && isLoadedRivalResultAnimationResource; } set {} } //  get_isRivalResultAllLoaded 0x1BFA218 set_isRivalResultAllLoaded 0x1BFA238
		public bool isLoadedARAnimationResource { get; set; } // 0x159
		public bool isARAllLoaded { get { return isLoadedBasicResource && isLoadedARAnimationResource; } set {} } //  get_isARAllLoaded 0x1BFA598 set_isARAllLoaded 0x1BFA5B8 

		// // RVA: 0x1BF7FE8 Offset: 0x1BF7FE8 VA: 0x1BF7FE8
		public void OnDestroy()
		{
			ReleaseAll();
		}

		// // RVA: 0x1BF7FEC Offset: 0x1BF7FEC VA: 0x1BF7FEC
		public void ReleaseAll()
		{
			ReleaseBasicResource();
			ReleaseMenuResource();
			ReleaseMusicResource();
			ReleaseSubCostumeResource();
			isLoadedSimpleResource = false;
			isLoadedARAnimationResource = false;
		}

		// // RVA: 0x1BF8024 Offset: 0x1BF8024 VA: 0x1BF8024
		public void ReleaseBasicResource()
		{
			divaParam = null;
			divaPrefab = null;
			divaAnimatorController = null;
			facialAnimatorController = null;
			isLoadedBasicResource = false;
			boneSpringResource.suppress.presets.Clear();
			prefabEffect.Clear();
			prefabEffect = null;
			prefabWind = null;
		}

		// // RVA: 0x1BF82D8 Offset: 0x1BF82D8 VA: 0x1BF82D8
		public void ReleaseMusicResource()
		{
			musicMotionOverrideResource.bodyClip = null;
			musicMotionOverrideResource.faceBlendClip = null;
			musicMotionOverrideResource.mouthBlendClip = null;
			//for(int i = 0; i < commonFacialResource.Count; i++)
			//	commonFacialResource[i].overrideClip = null;
			commonFacialResource.Clear();
			//for(int i = 0; i < specialFacialResource.Count; i++)
			//	specialFacialResource[i].overrideClip = null;
			specialFacialResource.Clear();
			mikeStandAnimationOverrideClip = null;
			isLoadedMusicFacialResource = false;
			mikeStandPrefab = null;
			mikeCommonPrefab = null;
		}

		// // RVA: 0x1BF80BC Offset: 0x1BF80BC VA: 0x1BF80BC
		public void ReleaseMenuResource()
		{
			//menuMotionOverride
			menuVoiceTable = null;
			menuVoiceTableCos = null;
			//for(int i = 0; i < commonFacialResource.Count; i++)
			//	commonFacialResource[i].overrideClip = null;
			commonFacialResource.Clear();
			//for(int i = 0; i < specialFacialResource.Count; i++)
			//	specialFacialResource[i].overrideClip = null;
			specialFacialResource.Clear();
			//resultMotionOverride
			//loginMotionOverride
			//unlockMotionOverride
			isLoadedMenuAnimationResource = false;
		}

		// // RVA: 0x1BF84DC Offset: 0x1BF84DC VA: 0x1BF84DC
		public void ReleaseSubCostumeResource()
		{
			subPrefabEffect.Clear();
			isLoadedSubCostumeResource = false;
			subDivaPrefab = null;
			subPrefabEffect = null;
			subPrefabWind = null;
			//subBoneSpringResource
		}

		// // RVA: 0x1BF85B4 Offset: 0x1BF85B4 VA: 0x1BF85B4
		// public void ReleaseRivalResultResource() { }

		// // RVA: 0x1BF8568 Offset: 0x1BF8568 VA: 0x1BF8568
		// public void RelaseARResource() { }

		// // RVA: 0x1BF8574 Offset: 0x1BF8574 VA: 0x1BF8574
		// public void ReleaseSimpleResource() { }

		// // RVA: 0x1BF87F0 Offset: 0x1BF87F0 VA: 0x1BF87F0
		public void LoadBasicResource(int divaId, int modelId, int colorId)
		{
			if(isLoadedBasicResource)
			{
				if(m_loadedDivaId == divaId && m_loadedModelId == modelId && m_loadedColorId == colorId)
				{
					return;
				}
				ReleaseBasicResource();
			}
			m_loadedDivaId = divaId;
			m_loadedModelId = modelId;
			m_loadedColorId = colorId;
			if(isLoadedBasicResource)
				return;
			StartCoroutine(Co_LoadBasicResource(divaId, modelId, colorId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73666C Offset: 0x73666C VA: 0x73666C
		// // RVA: 0x1BF88A8 Offset: 0x1BF88A8 VA: 0x1BF88A8
		private IEnumerator Co_LoadBasicResource(int divaId, int modelId, int colorId)
		{
    		UnityEngine.Debug.Log("Enter Co_LoadBasicResource");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public DivaResource <>4__this; // 0x10
			// public int divaId; // 0x14
			// public int modelId; // 0x18
			// private DivaResource.<>c__DisplayClass76_0 <>8__1; // 0x1C
			// public int colorId; // 0x20
			// private DivaResource.<>c__DisplayClass76_1 <>8__2; // 0x24
			// private StringBuilder <bundleName>5__2; // 0x28
			// private StringBuilder <assetName>5__3; // 0x2C
			// private AssetBundleLoadAllAssetOperationBase <operation>5__4; // 0x30
			// private LCLCCHLDNHJ.ILODJKFJJDO <cosMaster>5__5; // 0x34
			// 0x1BFDE5C
			
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			AssetBundleLoadAllAssetOperationBase operation = null;
			
			IMMAOANGPNK a = IMMAOANGPNK.HHCJCDFCLOB;
			OKGLGHCBCJP_Database o = a.NKEBMCIMJND_Database;
			LCLCCHLDNHJ_Costume l = o.MFPNGNMFEAL_Costume;
			LCLCCHLDNHJ_Costume.ILODJKFJJDO cos_master = l.NLIBHNJNJAN(divaId, modelId);
			bundleName.SetFormat("dv/ca/cmn.xab", "");
			
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			divaAnimatorController = operation.GetAsset<RuntimeAnimatorController>("diva_cmn_animator");
			facialAnimatorController = operation.GetAsset<RuntimeAnimatorController>("med_cmn_animator");
			divaMenuParam = operation.GetAsset<DivaMenuParam>("menu_diva_param");
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			assetName.SetFormat("diva_{0:D3}_param", divaId);
			divaParam = operation.GetAsset<DivaParam>(assetName.ToString());
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}.xab", divaId, modelId);
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			assetName.SetFormat("diva_{0:D3}_cos_{1:D3}_prefab", divaId, modelId);
			divaPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			assetName.SetFormat("diva_{0:D3}_cos_{1:D3}_mike_prefab", divaId, modelId);
			mikePrefab = operation.GetAsset<GameObject>(assetName.ToString());
			
			List<Material> matList = new List<Material>(16);
			if(cos_master.GLEEPAFMPLO)
			{
				operation.ForEach(mat => {
					if(mat is Material)
					{
						matList.Add(mat as Material);
					}
				});
			}
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			if(cos_master.GLEEPAFMPLO)
			{
				bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}_{2:D2}.xab", divaId, modelId, colorId);
				operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
				yield return operation;
				
				List<Texture> texList = new List<Texture>();
				
				operation.ForEach(tex => {
					if(tex is Texture)
					{
						texList.Add(tex as Texture);
					}
				});
				
				SetCostumeColorTexture(matList, texList);
				XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);	
			}
			
			yield return Co_LoadComponent(divaId, modelId, (pe, pw) => {prefabEffect = pe; prefabWind = pw;});
			
			yield return Co_LoadBoneSpringSuppress(divaId, modelId, (p) => {boneSpringResource.suppress.presets = p;});
			
			isLoadedBasicResource = true;
    		UnityEngine.Debug.Log("Exit Co_LoadBasicResource");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7366E4 Offset: 0x7366E4 VA: 0x7366E4
		// // RVA: 0x1BF89A0 Offset: 0x1BF89A0 VA: 0x1BF89A0
		protected IEnumerator Co_LoadBoneSpringSuppress(int divaId, int modelId, Action<Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam>> a_func)
		{
    		UnityEngine.Debug.Log("Enter Co_LoadBoneSpringSuppress");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public int divaId; // 0x10
			// public int modelId; // 0x14
			// public Action<Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam>> a_func; // 0x18
			// private StringBuilder <bundleName>5__2; // 0x1C
			// private StringBuilder <assetName>5__3; // 0x20
			// private AssetBundleLoadAllAssetOperationBase <operation>5__4; // 0x24
			// private Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam> <t_pressets>5__5; // 0x28
			//0x1BFECBC
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			AssetBundleLoadAllAssetOperationBase operation = null;
			Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam> pressets = new Dictionary<BoneSpringSuppressor.Preset, BoneSpringSuppressParam>();
			
			bundleName.SetFormat("dv/bs/{0:D3}_{1:D3}.xab", divaId, modelId);
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			if(!operation.IsError())
			{
				for(int i = 0; i < (int)BoneSpringSuppressor.Preset._Num; i++)
				{
					assetName.SetFormat("bs_{0:D3}_{1:D3}_suppress_{2}", divaId, modelId, i);
					BoneSpringSuppressParam p = operation.GetAsset<BoneSpringSuppressParam>(assetName.ToString());
					if(p != null)
					{
						pressets.Add((BoneSpringSuppressor.Preset)i, p);
					}
				}
			}
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			a_func(pressets);
    		UnityEngine.Debug.Log("Exit Co_LoadBoneSpringSuppress");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73675C Offset: 0x73675C VA: 0x73675C
		// // RVA: 0x1BF8A80 Offset: 0x1BF8A80 VA: 0x1BF8A80
		protected IEnumerator Co_LoadComponent(int divaId, int modelId, Action<List<GameObject>, GameObject> a_func)
		{
    		UnityEngine.Debug.Log("Enter Co_LoadComponent");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public int divaId; // 0x10
			// public int modelId; // 0x14
			// public Action<List<GameObject>, GameObject> a_func; // 0x18
			// private List<GameObject> <t_list_effect>5__2; // 0x1C
			// private GameObject <t_wind>5__3; // 0x20
			// private StringBuilder <bundleName>5__4; // 0x24
			// private StringBuilder <assetName>5__5; // 0x28
			// private AssetBundleLoadAllAssetOperationBase <operation>5__6; // 0x2C
			//0x1C00ED4
			List<GameObject> list_effect = new List<GameObject>();
			GameObject wind = null;
			IMMAOANGPNK im = IMMAOANGPNK.HHCJCDFCLOB;
			OKGLGHCBCJP_Database o = im.NKEBMCIMJND_Database;
			LCLCCHLDNHJ_Costume l = o.MFPNGNMFEAL_Costume;
			LCLCCHLDNHJ_Costume.ILODJKFJJDO a = l.NLIBHNJNJAN(divaId, modelId);
			int e = a.EGLDFPILJLG;
			if(e == 0)
			{
    			UnityEngine.Debug.LogError("Exit  Error Co_LoadComponent");
				yield break;
			}
			
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			
			bundleName.SetFormat("dv/cs/{0:D3}_{1:D3}.xab", divaId, modelId);
			AssetBundleLoadAllAssetOperationBase operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			for(int i = 0; i < 3; i++)
			{
				assetName.SetFormat("diva_{0:D3}_cos_{1:D3}_sp_effect_{2:D2}", divaId, modelId, i);
				GameObject g = operation.GetAsset<GameObject>(assetName.ToString());
				if(g != null)
				{
					list_effect.Add(g);
				}
			}
				
			assetName.SetFormat("diva_{0:D3}_cos_{1:D3}_wind", divaId, modelId);
			wind = operation.GetAsset<GameObject>(assetName.ToString());
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			bundleName.SetFormat("dv/ca/cmn.xab", "");
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			if(list_effect.Count == 0)
			{
				for(int i = 0; i < 3; i++)
				{
					assetName.SetFormat("diva_cmn_sp_effect_{0:D2}", i);
					GameObject g = operation.GetAsset<GameObject>(assetName.ToString());
					if(g != null)
					{
						list_effect.Add(g);
					}
				}
			}
			
			if(wind == null)
			{
				assetName.SetFormat("diva_cmn_wind", "");
				wind = operation.GetAsset<GameObject>(assetName.ToString());
			}
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			a_func(list_effect, wind);
    		UnityEngine.Debug.Log("Exit Co_LoadComponent");
		}

		// // RVA: 0x1BF8B60 Offset: 0x1BF8B60 VA: 0x1BF8B60
		public void SetCostumeColorTexture(List<Material> matList, List<Texture> texList)
		{
			StringBuilder buildStr = new StringBuilder(64);
			StringBuilder texName = new StringBuilder(64);
			
			for(int i = 0; i < matList.Count; i++)
			{
				Material m = matList[i];
				if(m == null)
					break;
				int idx = m.name.IndexOf("_mat");
				buildStr.Set(m.name);
				buildStr.Length = idx;
				buildStr.Append("_tex");
				texName.Set(buildStr.ToString());
				Texture colTex = null;
				if(m.HasProperty("_AlphaTex"))
				{
					texName.Append("_mask");
					Texture t = texList.Find(o => texName.ToString() == o.name);
					m.SetTexture("_AlphaTex", t);
					
					texName.Set(buildStr.ToString());
					texName.Append("_base");
					colTex = texList.Find(o => texName.ToString() == o.name);
				}
				else
				{
					texName.Append("_col");
					colTex = texList.Find(o => texName.ToString() == o.name);
				}
				m.SetTexture("_MainTex", colTex);
				if(m.HasProperty("_RimLightSampler"))
				{
					texName.Set(buildStr.ToString());
					texName.Append("_sp");
					Texture t = texList.Find(o => texName.ToString() == o.name);
					m.SetTexture("_RimLightSampler", t);
				}
			}
		}

		// [ConditionalAttribute] // RVA: 0x7367D4 Offset: 0x7367D4 VA: 0x7367D4
		// // RVA: 0x1BF92DC Offset: 0x1BF92DC VA: 0x1BF92DC
		// private static void AssertCostumeColorTexture(Texture tex, string texName) { }

		// [CompilerGeneratedAttribute] // RVA: 0x736808 Offset: 0x736808 VA: 0x736808
		// // RVA: 0x1BF9364 Offset: 0x1BF9364 VA: 0x1BF9364
		// public bool get_isLoadedMusicAnimationResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736818 Offset: 0x736818 VA: 0x736818
		// // RVA: 0x1BF858C Offset: 0x1BF858C VA: 0x1BF858C
		// private void set_isLoadedMusicAnimationResource(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x736828 Offset: 0x736828 VA: 0x736828
		// // RVA: 0x1BF936C Offset: 0x1BF936C VA: 0x1BF936C
		// public bool get_isLoadedARMusicAnimationResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736838 Offset: 0x736838 VA: 0x736838
		// // RVA: 0x1BF9374 Offset: 0x1BF9374 VA: 0x1BF9374
		// private void set_isLoadedARMusicAnimationResource(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x736848 Offset: 0x736848 VA: 0x736848
		// // RVA: 0x1BF265C Offset: 0x1BF265C VA: 0x1BF265C
		// public int get_positionId() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736858 Offset: 0x736858 VA: 0x736858
		// // RVA: 0x1BF937C Offset: 0x1BF937C VA: 0x1BF937C
		// private void set_positionId(int value) { }

		// // RVA: 0x1BF9384 Offset: 0x1BF9384 VA: 0x1BF9384
		public void LoadMusicAnimationResource(int wavId, int primeId, int positionId = 1, int divaNum = 1, int divaId = 0)
		{
			this.positionId = positionId;
			if(!isLoadedMusicAnimationResource)
				StartCoroutine(Co_LoadMusicAnimationResource(wavId, primeId, positionId, divaNum, divaId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x736868 Offset: 0x736868 VA: 0x736868
		// // RVA: 0x1BF93D8 Offset: 0x1BF93D8 VA: 0x1BF93D8
		private IEnumerator Co_LoadMusicAnimationResource(int wavId, int primeId, int positionId = 1, int divaNum = 1, int divaId = 0)
		{
    		UnityEngine.Debug.Log("Enter Co_LoadMusicAnimationResource");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public int divaNum; // 0x10
			// public int positionId; // 0x14
			// public int wavId; // 0x18
			// public int primeId; // 0x1C
			// public int divaId; // 0x20
			// public DivaResource <>4__this; // 0x24
			// private StringBuilder <bundleName>5__2; // 0x28
			// private StringBuilder <assetName>5__3; // 0x2C
			// private string <attachPositionId>5__4; // 0x30
			// private string <wavIdString>5__5; // 0x34
			// private AssetBundleLoadAllAssetOperationBase <operation>5__6; // 0x38
			
			//0x1C042A0
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			
			string attachPositionId = "";
			if(divaNum != 1)
				attachPositionId = "_"+positionId;
			
			string wavPath = XeApp.Game.GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/bt{1:D3}.xab", divaNum, primeId, -1, true);
			
			bundleName.SetFormat("mc/{0}/bt{1:D3}.xab", wavPath, primeId);
			AssetBundleLoadAllAssetOperationBase operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			if(divaNum > 1 && divaId == 9)
			{
				attachPositionId = "_"+positionId+"_B";
			}
			assetName.SetFormat("music_{0}_prime_{1:D3}{2}_body", wavPath, primeId, attachPositionId);
			musicMotionOverrideResource.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			
			assetName.SetFormat("music_{0}_prime_{1:D3}{2}_face", wavPath, primeId, attachPositionId);
			musicMotionOverrideResource.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			
			assetName.SetFormat("music_{0}_prime_{1:D3}{2}_mouth", wavPath, primeId, attachPositionId);
			musicMotionOverrideResource.mouthBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			
			assetName.SetFormat("music_{0}_prime_{1:D3}{2}_mike", wavPath, primeId, attachPositionId);
			mikeStandAnimationOverrideClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			if(mikeStandAnimationOverrideClip != null)
			{
				IMMAOANGPNK i = IMMAOANGPNK.HHCJCDFCLOB;
				OKGLGHCBCJP_Database o = i.NKEBMCIMJND_Database;
				HPBPIOPPDCB_Diva h = o.MGFMPKLLGHE_Diva;
				BJPLLEBHAGO b = h.GCINIJEMHFK(divaId);
				int ms = b.IDDHKOEFJFB;
				yield return StartCoroutine(Co_LoadMikeStandResource(ms));
			}
			isLoadedMusicAnimationResource = true;
    		UnityEngine.Debug.Log("Exit Co_LoadMusicAnimationResource");
		}

		// // RVA: 0x1BF9508 Offset: 0x1BF9508 VA: 0x1BF9508
		// public void LoadARMusicAnimationResource(int wavId, int primeId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7368E0 Offset: 0x7368E0 VA: 0x7368E0
		// // RVA: 0x1BF952C Offset: 0x1BF952C VA: 0x1BF952C
		// private IEnumerator Co_LoadARMusicAnimationResource(int wavId, int primeId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736958 Offset: 0x736958 VA: 0x736958
		// // RVA: 0x1BF960C Offset: 0x1BF960C VA: 0x1BF960C
		private IEnumerator Co_LoadMikeStandResource(int primeId)
		{
    		UnityEngine.Debug.Log("Enter Co_LoadMikeStandResource");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public DivaResource <>4__this; // 0x10
			// public int primeId; // 0x14
			// private StringBuilder <bundleName>5__2; // 0x18
			// private StringBuilder <assetName>5__3; // 0x1C
			// private AssetBundleLoadAllAssetOperationBase <operation>5__4; // 0x20
			//0x1C03CDC
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			
			bundleName.SetFormat("dv/mk/bt/cmn.xab", "");
			AssetBundleLoadAllAssetOperationBase operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			assetName.SetFormat("stand_mike_animator", "");
			mikeStandAnimatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			bundleName.SetFormat("dv/mk/bt/{0:D3}.xab", primeId);
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			assetName.SetFormat("stand_mike_prefab", "");
			mikeStandPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			
			assetName.SetFormat("hand_mike_prefab", "");
			mikeCommonPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
    		UnityEngine.Debug.Log("Exit Co_LoadMikeStandResource");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x7369D0 Offset: 0x7369D0 VA: 0x7369D0
		// // RVA: 0x1BF96D4 Offset: 0x1BF96D4 VA: 0x1BF96D4
		// public bool get_isLoadedMusicFacialResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7369E0 Offset: 0x7369E0 VA: 0x7369E0
		// // RVA: 0x1BF859C Offset: 0x1BF859C VA: 0x1BF859C
		// private void set_isLoadedMusicFacialResource(bool value) { }

		// // RVA: 0x1BF96DC Offset: 0x1BF96DC VA: 0x1BF96DC
		public void LoadFacialResource(int divaId, int wavId, int stageDivaNum)
		{
			if(!isLoadedMusicFacialResource)
			{
				StartCoroutine(Co_LoadFacialResource(divaId, wavId, stageDivaNum));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7369F0 Offset: 0x7369F0 VA: 0x7369F0
		// // RVA: 0x1BF971C Offset: 0x1BF971C VA: 0x1BF971C
		private IEnumerator Co_LoadFacialResource(int divaId, int wavId, int stageDivaNum)
		{
    		UnityEngine.Debug.Log("Enter Co_LoadFacialResource");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public int wavId; // 0x10
			// public int stageDivaNum; // 0x14
			// public int divaId; // 0x18
			// public DivaResource <>4__this; // 0x1C
			// private StringBuilder <bundleName>5__2; // 0x20
			// private StringBuilder <assetName>5__3; // 0x24
			// private AssetBundleLoadAllAssetOperationBase <operation>5__4; // 0x28
			// private List<string> <originalFacesName>5__5; // 0x2C
			// private List<int> <overrideFacesId>5__6; // 0x30
			//0x1C02344
			
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			
			string wavPath = XeApp.Game.GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/ft.xab", stageDivaNum, 1, -1, true);
			
			bundleName.SetFormat("mc/{0}/ft.xab", wavPath);
			AssetBundleLoadAllAssetOperationBase operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			assetName.SetFormat("facial_table", "");
			TextAsset facialTableAsset = operation.GetAsset<TextAsset>(assetName.ToString());
			
			List<string> originalFacialNames = new List<string>();
			List<int> overrideFacesId = new List<int>();
			
			XeApp.Game.Common.FacialNameDatabase.CreateFacialOverrideList(facialTableAsset, divaId, ref originalFacialNames, ref overrideFacesId);
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			commonFacialResource.Clear();
			
			for(int i = 0; i < divaCommonFacialAnimName.Length; i++)
			{
				assetName.SetFormat("diva_{0:D3}_{1}", divaId, divaCommonFacialAnimName[i]);
				FacialOverrideResouece resource;
				resource.originalName = divaCommonFacialAnimName[i];
				resource.overrideClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				commonFacialResource.Add(resource);
			}
			
			specialFacialResource.Clear();
			for(int i = 0; i < originalFacialNames.Count; i++)
			{
				if(overrideFacesId[i] > 0)
				{
					string s = XeApp.Game.Common.FacialNameDatabase.ToString(overrideFacesId[i]);
					assetName.SetFormat("diva_{0:D3}_{1}", divaId, s);
					FacialOverrideResouece resource;
					resource.originalName = originalFacialNames[i];
					resource.overrideClip = operation.GetAsset<AnimationClip>(assetName.ToString());
					specialFacialResource.Add(resource);
				}
			}
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			isLoadedMusicFacialResource = true;
    		UnityEngine.Debug.Log("Exit Co_LoadFacialResource");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x736A68 Offset: 0x736A68 VA: 0x736A68
		// // RVA: 0x1BF9844 Offset: 0x1BF9844 VA: 0x1BF9844
		// public bool get_isLoadedMenuAnimationResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736A78 Offset: 0x736A78 VA: 0x736A78
		// // RVA: 0x1BF85A4 Offset: 0x1BF85A4 VA: 0x1BF85A4
		// private void set_isLoadedMenuAnimationResource(bool value) { }

		// // RVA: 0x1BF984C Offset: 0x1BF984C VA: 0x1BF984C
		public void LoadMenuResource(int divaId, int modelId, DivaResource.MenuFacialType facialType, ResultScoreRank.Type scoreRank = ResultScoreRank.Type.Illegal)
		{
			if(!isLoadedMenuAnimationResource)
			{
				StartCoroutine(Co_LoadMenuResource(divaId, modelId, facialType, scoreRank));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x736A88 Offset: 0x736A88 VA: 0x736A88
		// // RVA: 0x1BF9894 Offset: 0x1BF9894 VA: 0x1BF9894
		private IEnumerator Co_LoadMenuResource(int divaId, int modelId, DivaResource.MenuFacialType facialType, ResultScoreRank.Type scoreRank)
		{			
    		UnityEngine.Debug.Log("Enter Co_LoadMenuResource");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public DivaResource <>4__this; // 0x10
			// public int divaId; // 0x14
			// public DivaResource.MenuFacialType facialType; // 0x18
			// public int modelId; // 0x1C
			// public ResultScoreRank.Type scoreRank; // 0x20
			//0x1C03944
			
			yield return StartCoroutine(Co_LoadCharacter(divaId));
			//yield return StartCoroutine(Co_LoadFacialClip(divaId, facialType));
			//yield return StartCoroutine(Co_LoadLoginAction(divaId));
			//yield return StartCoroutine(Co_LoadResultAction(divaId, modelId, scoreRank));
			//yield return StartCoroutine(Co_LoadUnlockDivaAction(divaId));
			//yield return StartCoroutine(Co_LoadUnlockCostumeDivaAction(divaId));
			isLoadedMenuAnimationResource = true;
			
			UnityEngine.Debug.LogError("TODO");
    		UnityEngine.Debug.Log("Exit Co_LoadMenuResource");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x736B00 Offset: 0x736B00 VA: 0x736B00
		// // RVA: 0x1BF99A4 Offset: 0x1BF99A4 VA: 0x1BF99A4
		private IEnumerator Co_LoadCharacter(int divaId)
		{			
    		UnityEngine.Debug.Log("Enter Co_LoadCharacter");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public DivaResource <>4__this; // 0x10
			// public int divaId; // 0x14
			// private StringBuilder <bundleName>5__2; // 0x18
			// private StringBuilder <assetName>5__3; // 0x1C
			// private int <personalityId>5__4; // 0x20
			// private AssetBundleLoadAllAssetOperationBase <operation>5__5; // 0x24
			//0x1BFF220
			
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			
			menuMotionOverride.reactions = new List<MenuMotionOverrideResource.Reaction>(MAX_REACTION);
			menuMotionOverride.talk = new List<MenuMotionOverrideResource.Talk>(MAX_TALK);
			menuMotionOverride.timezone = new List<MenuMotionOverrideResource.Timezone>(5);
			menuMotionOverride.present = new List<MenuMotionOverrideResource.Reaction>(MAX_PRESENT);
			menuMotionOverride.simpletalk = new List<MenuMotionOverrideResource.Reaction>(MAX_SIMPLE_TALK);
			
			IMMAOANGPNK im = IMMAOANGPNK.HHCJCDFCLOB;
			OKGLGHCBCJP_Database o = im.NKEBMCIMJND_Database;
			HPBPIOPPDCB_Diva h = o.MGFMPKLLGHE_Diva;
			BJPLLEBHAGO b = h.GCINIJEMHFK(divaId);
			int personalityId = b.FPMGHDKACOF;
			
			bundleName.SetFormat("dv/ty/{0:D3}.xab", personalityId);
			AssetBundleLoadAllAssetOperationBase operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			for(int i = 1; i <= MAX_TALK; i++)
			{
				MenuMotionOverrideResource.Talk talk = new MenuMotionOverrideResource.Talk();
				
				assetName.SetFormat("type_{0:D3}_menu_talk{1:D2}_start_body", personalityId, i);
				talk.begin.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("type_{0:D3}_menu_talk{1:D2}_body", personalityId, i);
				talk.main.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("type_{0:D3}_menu_talk{1:D2}_face", personalityId, i);
				talk.main.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("type_{0:D3}_menu_talk{1:D2}_end_body", personalityId, i);
				talk.end.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				menuMotionOverride.talk.Add(talk);
			}
			for(int i = 1; i <= MAX_PRESENT; i++)
			{
				MenuMotionOverrideResource.Reaction reaction = new MenuMotionOverrideResource.Reaction();
				
				assetName.SetFormat("type_{0:D3}_menu_present{1:D2}_body", personalityId, i);
				reaction.main.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("type_{0:D3}_menu_present{1:D2}_face", personalityId, i);
				reaction.main.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				menuMotionOverride.present.Add(reaction);
			}
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			
			bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
			operation = XeApp.Core.AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			
			assetName.SetFormat("diva_{0:D3}_menu_idle_body", divaId);
			menuMotionOverride.idle.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			assetName.SetFormat("diva_{0:D3}_menu_idle_face", divaId);
			menuMotionOverride.idle.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			assetName.SetFormat("diva_{0:D3}_menu_idle_mouth", divaId);
			menuMotionOverride.idle.mouthBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
			
			for(int i = 1; i <= MAX_REACTION; i++)
			{
				MenuMotionOverrideResource.Reaction reaction = new MenuMotionOverrideResource.Reaction();
				
				assetName.SetFormat("diva_{0:D3}_menu_reaction{1:D2}_body", divaId, i);
				reaction.main.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("diva_{0:D3}_menu_reaction{1:D2}_face", divaId, i);
				reaction.main.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("diva_{0:D3}_menu_reaction{1:D2}_mouth", divaId, i);
				reaction.main.mouthBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				menuMotionOverride.reactions.Add(reaction);
			}
			
			for(int i = 1; i < 6; i++)
			{
				MenuMotionOverrideResource.Timezone timezone = new MenuMotionOverrideResource.Timezone();
				
				assetName.SetFormat("diva_{0:D3}_menu_timezone{1:D2}_body", divaId, i);
				timezone.main.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("diva_{0:D3}_menu_timezone{1:D2}_face", divaId, i);
				timezone.main.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("diva_{0:D3}_menu_timezone{1:D2}_mouth", divaId, i);
				timezone.main.mouthBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				menuMotionOverride.timezone.Add(timezone);
			}
			
			for(int i = 1; i <= MAX_SIMPLE_TALK; i++)
			{
				MenuMotionOverrideResource.Reaction reaction = new MenuMotionOverrideResource.Reaction();
				
				assetName.SetFormat("diva_{0:D3}_menu_simple_talk{1:D2}_body", divaId, i);
				reaction.main.bodyClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("diva_{0:D3}_menu_simple_talk{1:D2}_face", divaId, i);
				reaction.main.faceBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				assetName.SetFormat("diva_{0:D3}_menu_simple_talk{1:D2}_mouth", divaId, i);
				reaction.main.mouthBlendClip = operation.GetAsset<AnimationClip>(assetName.ToString());
				
				menuMotionOverride.simpletalk.Add(reaction);
			}
			
			assetName.SetFormat("diva_{0:D3}_menu_voicetable", divaId);
			menuVoiceTable = operation.GetAsset<MenuDivaVoiceTable>(assetName.ToString());
			menuVoiceTableCos = null;
			
			CIOECGOMILE c = CIOECGOMILE.HHCJCDFCLOB;
			BBHNACPENDM b2 = c.AHEFHIMGIBI_Save;
			MMPBPOIFDAF m = b2.PNLOINMCCKH;
			bool f = m.GOFAPKBNNCL(divaId);
			if(f)
			{
				assetName.SetFormat("diva_{0:D3}_menu_voicetable_cos", divaId);
				menuVoiceTableCos = operation.GetAsset<MenuDivaVoiceTableCos>(assetName.ToString());
			}
			
			XeApp.Core.AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
    		UnityEngine.Debug.Log("Exit Co_LoadCharacter");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x736B78 Offset: 0x736B78 VA: 0x736B78
		// // RVA: 0x1BF9A6C Offset: 0x1BF9A6C VA: 0x1BF9A6C
		// private IEnumerator Co_LoadResultAction(int divaId, int modelId, ResultScoreRank.Type scoreRank) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736BF0 Offset: 0x736BF0 VA: 0x736BF0
		// // RVA: 0x1BF9B64 Offset: 0x1BF9B64 VA: 0x1BF9B64
		// private IEnumerator Co_LoadLoginAction(int divaId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736C68 Offset: 0x736C68 VA: 0x736C68
		// // RVA: 0x1BF9C2C Offset: 0x1BF9C2C VA: 0x1BF9C2C
		// private IEnumerator Co_LoadUnlockDivaAction(int divaId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736CE0 Offset: 0x736CE0 VA: 0x736CE0
		// // RVA: 0x1BF9CD0 Offset: 0x1BF9CD0 VA: 0x1BF9CD0
		// private IEnumerator Co_LoadUnlockCostumeDivaAction(int divaId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736D58 Offset: 0x736D58 VA: 0x736D58
		// // RVA: 0x1BF9D74 Offset: 0x1BF9D74 VA: 0x1BF9D74
		// private IEnumerator Co_LoadFacialClip(int divaId, DivaResource.MenuFacialType facialType) { }

		// // RVA: 0x1BF9E78 Offset: 0x1BF9E78 VA: 0x1BF9E78
		// public void LoadSimpleResource(int divaId, int modelId, DivaResource.MenuFacialType facialType) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736DD0 Offset: 0x736DD0 VA: 0x736DD0
		// // RVA: 0x1BF9EA4 Offset: 0x1BF9EA4 VA: 0x1BF9EA4
		// private IEnumerator Co_LoadSimpleResource(int divaId, int modelId, DivaResource.MenuFacialType facialType) { }

		// [CompilerGeneratedAttribute] // RVA: 0x736E48 Offset: 0x736E48 VA: 0x736E48
		// // RVA: 0x1BF9FA4 Offset: 0x1BF9FA4 VA: 0x1BF9FA4
		// public bool get_isLoadedSubCostumeResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736E58 Offset: 0x736E58 VA: 0x736E58
		// // RVA: 0x1BF85AC Offset: 0x1BF85AC VA: 0x1BF85AC
		// private void set_isLoadedSubCostumeResource(bool value) { }

		// // RVA: 0x1BF9FAC Offset: 0x1BF9FAC VA: 0x1BF9FAC
		// public void LoadSubResource(int modelId, int colorId, int divaId = 0) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736E68 Offset: 0x736E68 VA: 0x736E68
		// // RVA: 0x1BFA004 Offset: 0x1BFA004 VA: 0x1BFA004
		// private IEnumerator Co_LoadSubResource(int divaId, int modelId, int colorId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x736EE0 Offset: 0x736EE0 VA: 0x736EE0
		// // RVA: 0x1BFA0FC Offset: 0x1BFA0FC VA: 0x1BFA0FC
		// public bool get_isLoadedRivalResultAnimationResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736EF0 Offset: 0x736EF0 VA: 0x736EF0
		// // RVA: 0x1BF87D0 Offset: 0x1BF87D0 VA: 0x1BF87D0
		// private void set_isLoadedRivalResultAnimationResource(bool value) { }

		// // RVA: 0x1BFA104 Offset: 0x1BFA104 VA: 0x1BFA104
		// public void LoadRivalResultResource(int divaId, int modelId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736F00 Offset: 0x736F00 VA: 0x736F00
		// // RVA: 0x1BFA138 Offset: 0x1BFA138 VA: 0x1BFA138
		// private IEnumerator Co_LoadRivalResultResource(int divaId, int modelId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x736F78 Offset: 0x736F78 VA: 0x736F78
		// // RVA: 0x1BFA23C Offset: 0x1BFA23C VA: 0x1BFA23C
		// public bool get_isLoadedARAnimationResource() { }

		// [CompilerGeneratedAttribute] // RVA: 0x736F88 Offset: 0x736F88 VA: 0x736F88
		// // RVA: 0x1BF8594 Offset: 0x1BF8594 VA: 0x1BF8594
		// private void set_isLoadedARAnimationResource(bool value) { }

		// // RVA: 0x1BFA244 Offset: 0x1BFA244 VA: 0x1BFA244
		// public void LoadARResource(int divaId, int modelId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x736F98 Offset: 0x736F98 VA: 0x736F98
		// // RVA: 0x1BFA278 Offset: 0x1BFA278 VA: 0x1BFA278
		// private IEnumerator Co_LoadARResource(int divaId, int modelId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x737010 Offset: 0x737010 VA: 0x737010
		// // RVA: 0x1BFA340 Offset: 0x1BFA340 VA: 0x1BFA340
		// private IEnumerator Co_LoadARCharacter(int divaId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x737088 Offset: 0x737088 VA: 0x737088
		// // RVA: 0x1BFA408 Offset: 0x1BFA408 VA: 0x1BFA408
		// private IEnumerator Co_LoadARUnlockDivaAction(int divaId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x737100 Offset: 0x737100 VA: 0x737100
		// // RVA: 0x1BFA4D0 Offset: 0x1BFA4D0 VA: 0x1BFA4D0
		// private IEnumerator Co_LoadARFacialClip(int divaId) { }

		// // RVA: 0x1BFA5BC Offset: 0x1BFA5BC VA: 0x1BFA5BC Slot: 4
		// public virtual void ChangeCostumeTexture() { }
	}
}
