using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeApp.Game.RhythmGame.UI;
using System.Collections;
using System.Text;
using XeApp.Core;
using XeSys;
using System;
using XeApp.Game.Menu;
using System.IO;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameResource : MonoBehaviour
	{
		public class UITextureResource
		{
			public Texture centerCardTexture; // 0x8
			public List<Material> divaSkillCutinMaterials = new List<Material>(); // 0xC
			public Dictionary<int, Material> skillEffectMaterials = new Dictionary<int, Material>(); // 0x10
			public Material activeSkillIconMaterial; // 0x14
			public Material activeSkillEffectMaterial; // 0x18

			// // RVA: 0xBF4EDC Offset: 0xBF4EDC VA: 0xBF4EDC
			public void Release()
			{
				for(int i = 0; i < divaSkillCutinMaterials.Count; i++)
				{
					Destroy(divaSkillCutinMaterials[i]);
				}
				if (activeSkillIconMaterial != null)
					Destroy(activeSkillIconMaterial);
				skillEffectMaterials.Clear();
				divaSkillCutinMaterials.Clear();
				activeSkillIconMaterial = null;
				activeSkillEffectMaterial = null;
				centerCardTexture = null;
			}
		}

		public MusicData musicData; // 0xC
		public DivaResource divaResource; // 0x10
		public List<DivaResource> subDivaResource = new List<DivaResource>(); // 0x14
		public MusicCameraResource cameraResource; // 0x18
		public StageResource stageResources; // 0x1C
		public ValkyrieResource valkyrieResource; // 0x20
		public MusicIntroResource musicIntroResource; // 0x24
		public ValkyrieModeResource valkyrieModeResource; // 0x28
		public DivaModeResource divaModeResource; // 0x2C
		public LowModeBackgroundResource lowModeBackgroundResource; // 0x30
		public RhytmGameParameterResource paramResource; // 0x34
		private bool isSpecialDirectionResourceLoaded_; // 0x38
		public List<DivaExtensionResource> divaExtensionResource = new List<DivaExtensionResource>(); // 0x3C
		public List<DivaCutinResource> divaCutinResource = new List<DivaCutinResource>(); // 0x40
		public List<MusicCameraCutinResource> musicCameraCutinResource = new List<MusicCameraCutinResource>(); // 0x44
		public List<StageLightingResource> stageLightingResource = new List<StageLightingResource>(); // 0x48
		public List<StageExtensionResource> stageExtensionResource = new List<StageExtensionResource>(); // 0x4C
		public MusicVoiceChangerResource musicVoiceChangerResource; // 0x50
		public MusicStageChangerResource musicStageChangerResource; // 0x54
		public MusicBoneSpringResource[] musicBoneSpringResource = new MusicBoneSpringResource[5]; // 0x58
		public int specialDirectionMovieId_ = -1; // 0x5C
		private bool isInitializedSpecialStageResource; // 0x60
		private bool throwedVoiceParamChangerParamException; // 0x61
		public UITextureResource uiTextureResources; // 0x64
		private bool isUITextureResoucesLoaded_; // 0x68
		public UiPilotTexture m_pilotTexture; // 0x6C
		public UiDivaTexture m_divaTexture; // 0x70
		public UiEnemyPilotTexture m_enemyPilotTexture; // 0x74
		public UiEnemyRobotTexture m_enemyRobotTexture; // 0x78
		public GameObject uiPrefab; // 0x7C
		public GameObject enemySkillPrefab; // 0x80
		public GameObject faildUiPrefab; // 0x84
		public GameObject completeUiPrefab; // 0x88

		// public bool isSpecialDirectionResourceLoaded { get; set; } 0xBF50C0 0xBF5968
		public bool isTakeoffDivaVoice { 
			get
			{ //  0xBF5E1C
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if(param == null)
					return false;
				return param.isTakeoffDivaVoice;
			} private set
			{ // 0xBF5EDC
				return;
			} }
		public int takeoffVoiceId { 
			get 
			{  // 0xBF5EE0
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if(param == null)
					return -1;
				return param.takeoffVoiceId;
			} private set
			{ // 0xBF5F98
				return;
			} }
		public int enteredValkyrieModeVoiceId { get
			{
				//0xBF25DC 
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if (param == null)
					return -1;
				return param.enterdValkyrieModeVoiceId;
			}
			private set { return; } } //0xBF5F9C
		public int enterdDivaModeVoiceId { get
			{
				//0xBF5FA0
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if (param == null)
					return -1;
				return param.enterdDivaModeVoiceId;
			}
			private set {
				//0xBF6058
				return;
			}
		}  
		public int enterdAwakenDivaModeVoiceId { get
			{
				//0xBF605C
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if (param == null)
					return -1;
				return param.enterdAwakenDivaModeVoiceId;
			}
			private set
			{
				//0xBF6114
				return;
			}
		}  
		public int enterFoldWaveId_50 { get {
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if (param == null)
					return -1;
				return param.enterdFoldWaveId_50;
			} private set { return; } } //0xBF6118 0xBF61D0
		public int enterFoldWaveId_100 { get
			{
				MusicVoiceChangerParam param = TryGetMusicVoiceChangerParam();
				if (param == null)
					return -1;
				return param.enterdFoldWaveId_100;
			} private set { return; } } //0xBF61D4 0xBF628C
		// public bool isUITextureResoucesLoaded { get; private set; } 0xBF6290 0xBF62B0
		public bool is3DModeMusicDataResoucesLoaded { get { return musicData.isAllLoaded; } private set { } }// 0xBF6490 0xBF64BC
		public bool is2DModeMusicDataResoucesLoaded { get { return musicData.isAllLoaded; } private set { } } //0xBF64C0 0xBF64EC
		public bool is3DModeSpecialResoucesLoaded { get
			{
				if (!isSpecialDirectionResourceLoaded_)
					return false;
				foreach(var d in divaExtensionResource)
				{
					if (d != null && !d.isAllLoaded)
						return false;
				}
				foreach(var d in divaCutinResource)
				{
					if (d != null && !d.isAllLoaded)
						return false;
				}
				foreach (var d in musicCameraCutinResource)
				{
					if (d != null && !d.isAllLoaded)
						return false;
				}
				foreach (var d in stageLightingResource)
				{
					if (d != null && !d.isAllLoaded)
						return false;
				}
				foreach (var d in stageExtensionResource)
				{
					if (d != null && !d.isAllLoaded)
						return false;
				}
				if (musicVoiceChangerResource != null && !musicVoiceChangerResource.isAllLoaded)
					return false;
				return true;
			}
			private set { } } //0xBF64F0 0xBF64F4
		public bool is2DModeSpecialResoucesLoaded { get {
			TodoLogger.Log(0, "is2DModeSpecialResoucesLoaded");
			return true;
		} private set {} }// 0xBF64F8 0xBF64FC
		public bool is3DModeAllResoucesLoaded { get
		{
			bool ok = divaResourceIsMusicAllLoaded() && cameraResource.isAllLoaded && stageResources.isAllLoaded && 
				valkyrieResource.isAllLoaded && musicIntroResource.isAllLoaded && valkyrieModeResource.isAllLoaded && 
				divaModeResource.isAllLoaded && isUITextureResoucesLoaded_ && uiTextureResources != null && 
				paramResource.isLoaded;
			for(int i = 0; i < musicBoneSpringResource.Length; i++)
			{
				ok &= musicBoneSpringResource[i].isAllLoaded;
			}
			return ok;
		} private set {} } //0xBF6500 0xBF66CC
		public bool is2DModeAllResoucesLoaded { get {
			TodoLogger.Log(0, "is2DModeAllResoucesLoaded");
			return true;
		} private set {} } //0xBF66D0 0xBF6744

		// // RVA: 0xBF4744 Offset: 0xBF4744 VA: 0xBF4744
		public void OnDestroy()
		{
			if(divaResource != null)
			{
				divaResource.ReleaseMusicResource();
			}
			foreach(var s in subDivaResource)
			{
				if(s != null)
				{
					s.ReleaseMusicResource();
				}
			}
			if (cameraResource != null)
				cameraResource.OnDestroy();
			if (stageResources != null)
				stageResources.OnDestroy();
			if (valkyrieResource != null)
				valkyrieResource.OnDestroy();
			if (musicIntroResource != null)
				musicIntroResource.OnDestroy();
			if (valkyrieModeResource != null)
				valkyrieModeResource.OnDestroy();
			if (divaModeResource != null)
				divaModeResource.OnDestroy();
			if (uiTextureResources != null)
				uiTextureResources.Release();
			if (m_pilotTexture != null)
				m_pilotTexture.OnDestory();
			if (m_enemyPilotTexture != null)
				m_enemyPilotTexture.OnDestory();
			if (m_enemyRobotTexture != null)
				m_enemyRobotTexture.OnDestory();
			for(int i = 0; i < stageLightingResource.Count; i++)
			{
				if(stageLightingResource[i] != null)
				{
					stageLightingResource[i].OnDestroy();
				}
			}
			if (uiPrefab != null)
				uiPrefab = null;
			if (enemySkillPrefab != null)
				enemySkillPrefab = null;
			for(int i = 0; i < musicBoneSpringResource.Length; i++)
			{
				if (musicBoneSpringResource[i] != null)
					musicBoneSpringResource[i].OnDestroy();
			}
			if (paramResource != null)
				paramResource.OnDestroy();
		}

		// // RVA: 0xBF5970 Offset: 0xBF5970 VA: 0xBF5970
		public int GetSpecialDirectionMovieId()
		{
			return specialDirectionMovieId_;
		}

		// // RVA: 0xBF5978 Offset: 0xBF5978 VA: 0xBF5978
		public int GetSpecialStageResourceId()
		{
			if (isInitializedSpecialStageResource)
			{
				if(musicStageChangerResource != null)
				{
					if(musicStageChangerResource.isAllLoaded)
					{
						if(musicStageChangerResource.param != null)
						{
							return musicStageChangerResource.param.stageResourceId;
						}
						return 0;
					}
					return -1;
				}
				return 0;
			}
			return -1;
		}

		// // RVA: 0xBF5ADC Offset: 0xBF5ADC VA: 0xBF5ADC
		public MusicVoiceChangerParam TryGetMusicVoiceChangerParam()
		{
			if(musicVoiceChangerResource != null)
			{
				if(musicVoiceChangerResource.param != null)
				{
					return musicVoiceChangerResource.param;
				}
				else if (!throwedVoiceParamChangerParamException)
				{
					throw new MusicVoiceChangerParamNotFoundException("wavId=" + musicVoiceChangerResource.wavId + ",assetId=" + musicVoiceChangerResource.assetId);
				}
			}
			return null;
		}

		// // RVA: 0xBF62B4 Offset: 0xBF62B4 VA: 0xBF62B4
		private bool divaResourceIsMusicAllLoaded()
		{
			foreach(var s in subDivaResource)
			{
				if(s != null)
				{
					if(!s.isMusicAllLoaded)
						return false;
				}
			}
			return divaResource.isMusicAllLoaded;
		}

		// // RVA: 0xBF6748 Offset: 0xBF6748 VA: 0xBF6748
		private void Awake()
		{
			musicData = gameObject.AddComponent<MusicData>();
			divaResource = GameManager.Instance.divaResource;
			cameraResource = gameObject.AddComponent<MusicCameraResource>();
			stageResources = gameObject.AddComponent<StageResource>();
			valkyrieResource = gameObject.AddComponent<ValkyrieResource>();
			musicIntroResource = gameObject.AddComponent<MusicIntroResource>();
			valkyrieModeResource = gameObject.AddComponent<ValkyrieModeResource>();
			divaModeResource = gameObject.AddComponent<DivaModeResource>();
			lowModeBackgroundResource = gameObject.AddComponent<LowModeBackgroundResource>();
			for(int i = 0; i < 5; i++)
			{
				musicBoneSpringResource[i] = gameObject.AddComponent<MusicBoneSpringResource>();
			}
			paramResource = gameObject.AddComponent<RhytmGameParameterResource>();
			for(int i = 0; i < 4; i++)
			{
				subDivaResource.Add(GameManager.Instance.subDivaResource[i]);
			}
		}

		// // RVA: 0xBF6B7C Offset: 0xBF6B7C VA: 0xBF6B7C
		public void LoadSpecialDirectionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			isInitializedSpecialStageResource = false;
			specialDirectionMovieId_ = -1;
			StartCoroutine(Co_LoadSpecialDirectionResource(wavId, stageDivaNum, settingList));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7451EC Offset: 0x7451EC VA: 0x7451EC
		// // RVA: 0xBF6BBC Offset: 0xBF6BBC VA: 0xBF6BBC
		private IEnumerator Co_LoadSpecialDirectionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			//0xBF9B1C
			isSpecialDirectionResourceLoaded_ = false;
			yield return new WaitUntil(() =>
			{
				//0xBF93A4
				return musicData.isAllLoaded;
			});
			LoadStageLightingResource(wavId, stageDivaNum, settingList);
			LoadStageExtensionResource(wavId, stageDivaNum, settingList);
			LoadDivaExtensionResource(wavId, stageDivaNum, settingList);
			LoadDivaCutinResource(wavId, stageDivaNum, settingList);
			LoadMusicCameraCutinResource(wavId, stageDivaNum, settingList);
			LoadMusicVoiceChangerResource(wavId, stageDivaNum, settingList);
			LoadSpecialMovieResource(settingList);
			LoadSpecialStageResource(wavId, stageDivaNum, settingList);
			isSpecialDirectionResourceLoaded_ = true;
		}

		// // RVA: 0xBF6CB4 Offset: 0xBF6CB4 VA: 0xBF6CB4
		// public void LoadARSpecialDirectionResource(int wavId, int divaId, int divaModelId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x745264 Offset: 0x745264 VA: 0x745264
		// // RVA: 0xBF6CEC Offset: 0xBF6CEC VA: 0xBF6CEC
		// private IEnumerator Co_LoadARSpecialDirectionResource(int wavId, int divaId, int divaModelId, int stageDivaNum) { }

		// // RVA: 0xBF6E04 Offset: 0xBF6E04 VA: 0xBF6E04
		private void LoadStageLightingResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			if(stageLightingResource != null)
			{
				foreach(var l in stageLightingResource)
				{
					Destroy(l);
				}
				stageLightingResource.Clear();
			}
			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckStageLightingResourceId(settingList);
			foreach(MusicDirectionParamBase.ResourceData resource in resources)
			{
				if (resource.id > 0)
				{
					StageLightingResource comp = gameObject.AddComponent<StageLightingResource>();
					stageLightingResource.Add(comp);
					comp.LoadResouces(wavId, resource.id, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF7234 Offset: 0xBF7234 VA: 0xBF7234
		private void LoadStageExtensionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			if(stageExtensionResource != null)
			{
				foreach(var s in stageExtensionResource)
				{
					Destroy(s);
				}
				stageExtensionResource.Clear();
			}

			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckStageExtensionResourceId(settingList);
			foreach (MusicDirectionParamBase.ResourceData resource in resources)
			{
				if (resource.id > 0)
				{
					StageExtensionResource comp = gameObject.AddComponent<StageExtensionResource>();
					stageExtensionResource.Add(comp);
					comp.LoadResouces(wavId, resource.divaId, resource.id, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF766C Offset: 0xBF766C VA: 0xBF766C
		private void LoadDivaExtensionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			if(divaExtensionResource != null)
			{
				foreach(var der in divaExtensionResource)
				{
					Destroy(der);
				}
			}
			divaExtensionResource.Clear();
			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckDivaExtensionResourceId(settingList);
			foreach (MusicDirectionParamBase.ResourceData resource in resources)
			{
				if (resource.id > 0)
				{
					DivaExtensionResource comp = gameObject.AddComponent<DivaExtensionResource>();
					divaExtensionResource.Add(comp);
					comp.LoadResouces(wavId, resource.id, resource.divaId, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF7AA4 Offset: 0xBF7AA4 VA: 0xBF7AA4
		private void LoadDivaCutinResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			if (divaCutinResource != null)
			{
				foreach (var dcr in divaCutinResource)
				{
					Destroy(dcr);
				}
			}
			divaCutinResource.Clear();
			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckDivaCutinResourceId(settingList);
			foreach (MusicDirectionParamBase.ResourceData resource in resources)
			{
				if (resource.id > 0)
				{
					DivaCutinResource comp = gameObject.AddComponent<DivaCutinResource>();
					divaCutinResource.Add(comp);
					comp.LoadResouces(wavId, resource.id, resource.divaId, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF7EDC Offset: 0xBF7EDC VA: 0xBF7EDC
		private void LoadMusicCameraCutinResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			if (musicCameraCutinResource != null)
			{
				foreach (var dcr in musicCameraCutinResource)
				{
					Destroy(dcr);
				}
			}
			musicCameraCutinResource.Clear();
			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckMusicCameraCutinResourceId(settingList);
			foreach (MusicDirectionParamBase.ResourceData resource in resources)
			{
				if (resource.id > 0)
				{
					MusicCameraCutinResource comp = gameObject.AddComponent<MusicCameraCutinResource>();
					musicCameraCutinResource.Add(comp);
					comp.LoadResouces(wavId, resource.id, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF830C Offset: 0xBF830C VA: 0xBF830C
		private void LoadMusicVoiceChangerResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			Destroy(musicVoiceChangerResource);
			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckMusicVoiceChangerResourceId(settingList);
			if(resources.Count > 0)
			{
				if(resources[0].id > 0)
				{
					musicVoiceChangerResource = gameObject.AddComponent<MusicVoiceChangerResource>();
					musicVoiceChangerResource.LoadResouces(wavId, resources[0].id, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF8524 Offset: 0xBF8524 VA: 0xBF8524
		private void LoadSpecialMovieResource(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			specialDirectionMovieId_ = 0;
			List<MusicDirectionParamBase.ResourceData> res = musicData.musicParam.CheckSpecialMovieResourceId(settingList);
			if(res.Count > 0)
			{
				if(res[0].id < 1)
					return;
				specialDirectionMovieId_ = res[0].id;
			}
		}

		// // RVA: 0xBF8690 Offset: 0xBF8690 VA: 0xBF8690
		private void LoadSpecialStageResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			isInitializedSpecialStageResource = true;
			List<MusicDirectionParamBase.ResourceData> resources = musicData.musicParam.CheckStageChangerResourceId(settingList);
			if(resources.Count > 0)
			{
				if(resources[0].id > 0)
				{
					musicStageChangerResource = gameObject.AddComponent<MusicStageChangerResource>();
					musicStageChangerResource.LoadResouces(wavId, resources[0].id, stageDivaNum);
				}
			}
		}

		// // RVA: 0xBF8874 Offset: 0xBF8874 VA: 0xBF8874
		public void LoadUITextureResouces()
		{
			StartCoroutine(LoadingUITextureAllResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7452DC Offset: 0x7452DC VA: 0x7452DC
		// // RVA: 0xBF8898 Offset: 0xBF8898 VA: 0xBF8898
		private IEnumerator LoadingUITextureAllResource()
		{
			//0xBFD160
			uiTextureResources = new UITextureResource();
			m_pilotTexture = new UiPilotTexture();
			m_enemyPilotTexture = new UiEnemyPilotTexture();
			m_enemyRobotTexture = new UiEnemyRobotTexture();
			isUITextureResoucesLoaded_ = false;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KKBJCJNAGDB_CutInEnabled())
			{
				yield return StartCoroutine(LoadingUIDivaSkillCutinTextureResource());
				yield return StartCoroutine(LoadingUIACTIVESkillIconTextureResource());
			}
			yield return StartCoroutine(LoadingUIPrefab());
			yield return StartCoroutine(LoadPilotTexture());
			isUITextureResoucesLoaded_ = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x745354 Offset: 0x745354 VA: 0x745354
		// // RVA: 0xBF8944 Offset: 0xBF8944 VA: 0xBF8944
		private IEnumerator LoadingUIDivaSkillCutinTextureResource()
		{
			StringBuilder bundleName; // 0x14
			StringBuilder assetName; // 0x18
			GameSetupData.TeamInfo teamInfo; // 0x1C
			int i; // 0x20
			AssetBundleLoadAllAssetOperationBase operation; // 0x24
			int j; // 0x28
			PPGHMBNIAEC masterSkill; // 0x2C
			int k; // 0x30

			//0xBFBA2C
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			uiTextureResources.divaSkillCutinMaterials.Clear();
			uiTextureResources.skillEffectMaterials.Clear();
			teamInfo = Database.Instance.gameSetup.teamInfo;
			for(i = 0; i < 3; i++)
			{
				if(teamInfo.divaList[i].divaId > 0)
				{
					bundleName.Set(GetDivaSkillCutinTextureBundlePath(teamInfo.divaList[i].divaId, teamInfo.divaList[i].costumeModelId, teamInfo.divaList[i].costumeColorId));
					operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
					yield return operation;

					assetName.SetFormat(GetDivaSkillCutinTextureAssetName(bundleName, false), Array.Empty<object>());
					Texture tex = operation.GetAsset<Texture>(assetName.ToString());

					assetName.SetFormat(GetDivaSkillCutinTextureAssetName(bundleName, true), Array.Empty<object>());
					Texture tex2 = operation.GetAsset<Texture>(assetName.ToString());

					AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

					Material mat = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
					mat.SetTexture("_MainTex", tex);
					mat.SetTexture("_MaskTex", tex2);

					uiTextureResources.divaSkillCutinMaterials.Add(mat);

					int[] liveSkills = teamInfo.divaList[i].liveSkillIdList;
					for (j = 0; j < liveSkills.Length; j++)
					{
						if(liveSkills[j] != 0)
						{
							masterSkill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkills[j] - 1];
							for(k = 0; k < masterSkill.EGLDFPILJLG_SkillBuffEffect.Length; k++)
							{
								if(masterSkill.EGLDFPILJLG_SkillBuffEffect[k] != 0)
								{
									yield return LoadSkillEffectTextureCoroutine(masterSkill.EGLDFPILJLG_SkillBuffEffect[k], bundleName, assetName);
								}
							}
						}
					}
				}
				else
				{
					uiTextureResources.divaSkillCutinMaterials.Add(null);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7453CC Offset: 0x7453CC VA: 0x7453CC
		// // RVA: 0xBF89F0 Offset: 0xBF89F0 VA: 0xBF89F0
		private IEnumerator LoadingUIACTIVESkillIconTextureResource()
		{
			StringBuilder bundleName; // 0x14
			StringBuilder assetName; // 0x18
			int mainSceneId; // 0x1C
			int activeSkillId; // 0x20
			AssetBundleLoadAssetOperation operation; // 0x24
			CDNKOFIELMK md; // 0x28
			int i; // 0x2C
			int effectType; // 0x30

			//0xBFAF44
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			uiTextureResources.centerCardTexture = null;
			mainSceneId = Database.Instance.gameSetup.teamInfo.divaList[0].sceneIdList[0];
			if (mainSceneId == 0)
				yield break;
			GCIJNCFDNON d = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[mainSceneId - 1];
			int a = d.CGIELKDLHGE_GetEvolveId();
			if (d.JKGFBFPIMGA_Rarity < 4)
				a = 1;
			activeSkillId = Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId;
			if (activeSkillId < 1)
				yield break;
			bundleName.SetFormat("ct/sc/me/02/{0:D6}_{1:D2}.xab", mainSceneId, a);
			assetName.SetFormat("{0:D6}_{1:D2}", mainSceneId, a);

			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(Texture));
			yield return operation;

			uiTextureResources.centerCardTexture = operation.GetAsset<Texture>();
			uiTextureResources.activeSkillIconMaterial = new Material(Shader.Find("MCRS/RhythmUI/RhythmUIVertexColor"));
			uiTextureResources.activeSkillIconMaterial.SetTexture("_MainTex", uiTextureResources.centerCardTexture);

			int off = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA[mainSceneId - 1].GCLAAGFKPPJ_Aofs;
			uiTextureResources.activeSkillIconMaterial.SetTextureOffset("_MainTex", new Vector2(0, off * 1.0f / uiTextureResources.centerCardTexture.height));

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			md = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[activeSkillId - 1];
			for (i = 0; i < 1; i++)
			{
				effectType = md.EGLDFPILJLG_BuffEffectType[i];
				yield return StartCoroutine(LoadSkillEffectTextureCoroutine(effectType, bundleName, assetName));
				uiTextureResources.activeSkillEffectMaterial = uiTextureResources.skillEffectMaterials[effectType];
			}
			md = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x745444 Offset: 0x745444 VA: 0x745444
		// // RVA: 0xBF8A9C Offset: 0xBF8A9C VA: 0xBF8A9C
		private IEnumerator LoadSkillEffectTextureCoroutine(int effectType, StringBuilder bundleName, StringBuilder assetName)
		{
			AssetBundleLoadAssetOperation bundleOperation; // 0x20
			Texture colorTex; // 0x24

			//0xBFA8CC
			if(!uiTextureResources.skillEffectMaterials.ContainsKey(effectType))
			{
				bundleName.SetFormat("ct/gm/as/{0:D3}.xab", effectType);
				assetName.SetFormat("{0:D3}_base", effectType);
				bundleOperation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(Texture));
				yield return bundleOperation;

				colorTex = bundleOperation.GetAsset<Texture>();

				assetName.SetFormat("{0:D3}_mask", effectType);
				bundleOperation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(Texture));

				Texture maskTex = bundleOperation.GetAsset<Texture>();

				Material mat = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
				mat.SetTexture("_MainTex", colorTex);
				mat.SetTexture("_MaskTex", maskTex);

				uiTextureResources.skillEffectMaterials.Add(effectType, mat);

				for(int i = 0; i < 2; i++)
				{
					AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
				}
				bundleOperation = null;
				colorTex = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7454BC Offset: 0x7454BC VA: 0x7454BC
		// // RVA: 0xBF8B94 Offset: 0xBF8B94 VA: 0xBF8B94
		private IEnumerator LoadingUIPrefab()
		{
			GameSetupData.MusicInfo musicInfo; // 0x14
			StringBuilder bundleName; // 0x18
			StringBuilder assetName; // 0x1C
			ILDKBCLAFPB.MPHNGGECENI_Option option; // 0x20
			Font font; // 0x24
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x28
			AssetBundleLoadAssetOperation operation; // 0x2C

			//0xBFC624
			musicInfo = Database.Instance.gameSetup.musicInfo;
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			option = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options;

			yield return AssetBundleManager.LoadUnionAssetBundle("gm/if/un.xab");
			
			if(option.MIHFCOBBIPJ_GetQuality2d())
			{
				bundleName.Set("gm/if/hi.xab");
				if(musicInfo.IsMvMode)
					assetName.Set("MvUiRoot");
				else
					assetName.Set("UiRoot");
			}
			else
			{
				bundleName.Set("gm/if/lo.xab");
				if(musicInfo.IsMvMode)
					assetName.Set("MvUiRoot");
				else
					assetName.Set("UiRoot_Low");
			}
			
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(GameObject));
			yield return operation;

			uiPrefab = operation.GetAsset<GameObject>();

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation = null;

			if(option.MIHFCOBBIPJ_GetQuality2d())
				bundleName.SetFormat("gm/if/els/{0:D3}/{0:D3}_{1}.xab", 6, "hi");
			else
				bundleName.SetFormat("gm/if/els/{0:D3}/{0:D3}_{1}.xab", 6, "lo");

			assetName.SetFormat("{0:D3}", 6);

			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(GameObject));
			yield return operation;

			enemySkillPrefab = operation.GetAsset<GameObject>();

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation = null;

			bundleName.Set("ly/018.xab");
			font = GameManager.Instance.GetSystemFont();

			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_Failed");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(font,(GameObject instance) => {
				//0xBF93FC
				faildUiPrefab = instance;
			});

			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GameComplete");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(font,(GameObject instance) => {
				//0xBF9404
				completeUiPrefab = instance;
			});

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		// // RVA: 0xBF8C40 Offset: 0xBF8C40 VA: 0xBF8C40
		private string GetDivaSkillCutinTextureBundlePath(int divaId, int costumeModelId, int costumeColorId)
		{
			return DivaIconTextureCache.GetDivaUpIconPath(divaId, costumeModelId, costumeColorId);
		}

		// // RVA: 0xBF8CD4 Offset: 0xBF8CD4 VA: 0xBF8CD4
		private string GetDivaSkillCutinTextureAssetName(StringBuilder bundlePath, bool isMask)
		{
			StringBuilder str = new StringBuilder();
			str.Set(Path.GetFileNameWithoutExtension(bundlePath.ToString()));
			str.Append(isMask ? "_mask" : "_base");
			return str.ToString();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x745534 Offset: 0x745534 VA: 0x745534
		// // RVA: 0xBF8E24 Offset: 0xBF8E24 VA: 0xBF8E24
		private IEnumerator LoadPilotTexture()
		{
			GameSetupData gameSetup; // 0x14
			MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo enemyInfo; // 0x18

			//0xBFA1BC
			gameSetup = Database.Instance.gameSetup;
			enemyInfo = gameSetup.musicInfo.GetEnemyInfo();

			yield return StartCoroutine(m_pilotTexture.Load(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[gameSetup.teamInfo.prismValkyrieId - 1].PFGJJLGLPAC_PilotId));
			yield return StartCoroutine(m_enemyPilotTexture.Load(enemyInfo.EELBHDJJJHH_Plt));
			yield return StartCoroutine(m_enemyRobotTexture.Load(enemyInfo.EAHPLCJMPHD_Pic));
			if (musicVoiceChangerResource == null)
				yield break;
			yield return new WaitUntil(() =>
			{
				//0xBF940C
				return musicVoiceChangerResource.isAllLoaded;
			});
			if (!isTakeoffDivaVoice)
				yield break;
			m_divaTexture = new UiDivaTexture();
			yield return StartCoroutine(m_divaTexture.Load(gameSetup.teamInfo.divaList[0].prismDivaId, gameSetup.teamInfo.divaList[0].prismCostumeModelId, gameSetup.teamInfo.divaList[0].prismCostumeColorId));
		}

		// // RVA: 0xBF8ED0 Offset: 0xBF8ED0 VA: 0xBF8ED0
		public void LoadSpecialResourceFor2DMode(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			TodoLogger.Log(0, "LoadSpecialResourceFor2DMode");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7455AC Offset: 0x7455AC VA: 0x7455AC
		// // RVA: 0xBF8EFC Offset: 0xBF8EFC VA: 0xBF8EFC
		// private IEnumerator Co_LoadSpecialResourceFor2DMode(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// [IteratorStateMachineAttribute] // RVA: 0x745624 Offset: 0x745624 VA: 0x745624
		// // RVA: 0xBF8FF4 Offset: 0xBF8FF4 VA: 0xBF8FF4
		// private IEnumerator Co_LoadSpecialDirectionResourceFor2DMode(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF90EC Offset: 0xBF90EC VA: 0xBF90EC
		// public void LoadAllResourceFor2DMode(int introEnviromentId, int valkyrieModeId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x74569C Offset: 0x74569C VA: 0x74569C
		// // RVA: 0xBF9110 Offset: 0xBF9110 VA: 0xBF9110
		// private IEnumerator Co_LoadAllResourceFor2DMode(int introEnviromentId, int valkyrieModeId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x745724 Offset: 0x745724 VA: 0x745724
		// // RVA: 0xBF93D0 Offset: 0xBF93D0 VA: 0xBF93D0
		// private bool <Co_LoadARSpecialDirectionResource>b__88_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x745734 Offset: 0x745734 VA: 0x745734
		// // RVA: 0xBF93FC Offset: 0xBF93FC VA: 0xBF93FC
		// private void <LoadingUIPrefab>b__102_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x745744 Offset: 0x745744 VA: 0x745744
		// // RVA: 0xBF9404 Offset: 0xBF9404 VA: 0xBF9404
		// private void <LoadingUIPrefab>b__102_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x745764 Offset: 0x745764 VA: 0x745764
		// // RVA: 0xBF9438 Offset: 0xBF9438 VA: 0xBF9438
		// private bool <Co_LoadSpecialDirectionResourceFor2DMode>b__108_0() { }
	}
}

public class MusicVoiceChangerParamNotFoundException : Exception
{
	// RVA: 0x17BE9F0 Offset: 0x17BE9F0 VA: 0x17BE9F0
	public MusicVoiceChangerParamNotFoundException() { }

	// RVA: 0x17BEA74 Offset: 0x17BEA74 VA: 0x17BEA74
	public MusicVoiceChangerParamNotFoundException(string message) : base(message) { }

	// RVA: 0x17BEB00 Offset: 0x17BEB00 VA: 0x17BEB00
	public MusicVoiceChangerParamNotFoundException(string message, Exception inner) : base(message, inner) { }
}
