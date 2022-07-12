using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeApp.Game.RhythmGame.UI;

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
			// public void Release() { }
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
		// public int enteredValkyrieModeVoiceId { get; private set; } 0xBF25DC 0xBF5F9C
		// public int enterdDivaModeVoiceId { get; private set; } 0xBF5FA0 0xBF6058
		// public int enterdAwakenDivaModeVoiceId { get; private set; } 0xBF605C 0xBF6114
		// public int enterFoldWaveId_50 { get; private set; } 0xBF6118 0xBF61D0
		// public int enterFoldWaveId_100 { get; private set; } 0xBF61D4 0xBF628C
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
			UnityEngine.Debug.LogError("TODO is2DModeSpecialResoucesLoaded");
			return true;
		} private set {} }// 0xBF64F8 0xBF64FC
		public bool is3DModeAllResoucesLoaded { get
		{
			UnityEngine.Debug.LogError("TODO is3DModeAllResoucesLoaded");
			return true;
		} private set {} } //0xBF6500 0xBF66CC
		public bool is2DModeAllResoucesLoaded { get {
			UnityEngine.Debug.LogError("TODO is2DModeAllResoucesLoaded");
			return true;
		} private set {} } //0xBF66D0 0xBF6744

		// // RVA: 0xBF4744 Offset: 0xBF4744 VA: 0xBF4744
		public void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xBF5970 Offset: 0xBF5970 VA: 0xBF5970
		public int GetSpecialDirectionMovieId()
		{
			UnityEngine.Debug.LogError("GetSpecialDirectionMovieId");
			return 0;
		}

		// // RVA: 0xBF5978 Offset: 0xBF5978 VA: 0xBF5978
		public int GetSpecialStageResourceId()
		{
			UnityEngine.Debug.LogError("GetSpecialStageResourceId");
			return 0;
		}

		// // RVA: 0xBF5ADC Offset: 0xBF5ADC VA: 0xBF5ADC
		public MusicVoiceChangerParam TryGetMusicVoiceChangerParam()
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}

		// // RVA: 0xBF62B4 Offset: 0xBF62B4 VA: 0xBF62B4
		// private bool divaResourceIsMusicAllLoaded() { }

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
			UnityEngine.Debug.LogError("TODO LoadSpecialDirectionResource");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7451EC Offset: 0x7451EC VA: 0x7451EC
		// // RVA: 0xBF6BBC Offset: 0xBF6BBC VA: 0xBF6BBC
		// private IEnumerator Co_LoadSpecialDirectionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF6CB4 Offset: 0xBF6CB4 VA: 0xBF6CB4
		// public void LoadARSpecialDirectionResource(int wavId, int divaId, int divaModelId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x745264 Offset: 0x745264 VA: 0x745264
		// // RVA: 0xBF6CEC Offset: 0xBF6CEC VA: 0xBF6CEC
		// private IEnumerator Co_LoadARSpecialDirectionResource(int wavId, int divaId, int divaModelId, int stageDivaNum) { }

		// // RVA: 0xBF6E04 Offset: 0xBF6E04 VA: 0xBF6E04
		// private void LoadStageLightingResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF7234 Offset: 0xBF7234 VA: 0xBF7234
		// private void LoadStageExtensionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF766C Offset: 0xBF766C VA: 0xBF766C
		// private void LoadDivaExtensionResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF7AA4 Offset: 0xBF7AA4 VA: 0xBF7AA4
		// private void LoadDivaCutinResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF7EDC Offset: 0xBF7EDC VA: 0xBF7EDC
		// private void LoadMusicCameraCutinResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF830C Offset: 0xBF830C VA: 0xBF830C
		// private void LoadMusicVoiceChangerResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF8524 Offset: 0xBF8524 VA: 0xBF8524
		// private void LoadSpecialMovieResource(List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF8690 Offset: 0xBF8690 VA: 0xBF8690
		// private void LoadSpecialStageResource(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xBF8874 Offset: 0xBF8874 VA: 0xBF8874
		public void LoadUITextureResouces()
		{
			UnityEngine.Debug.LogError("TODO LoadUITextureResouces");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7452DC Offset: 0x7452DC VA: 0x7452DC
		// // RVA: 0xBF8898 Offset: 0xBF8898 VA: 0xBF8898
		// private IEnumerator LoadingUITextureAllResource() { }

		// [IteratorStateMachineAttribute] // RVA: 0x745354 Offset: 0x745354 VA: 0x745354
		// // RVA: 0xBF8944 Offset: 0xBF8944 VA: 0xBF8944
		// private IEnumerator LoadingUIDivaSkillCutinTextureResource() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7453CC Offset: 0x7453CC VA: 0x7453CC
		// // RVA: 0xBF89F0 Offset: 0xBF89F0 VA: 0xBF89F0
		// private IEnumerator LoadingUIACTIVESkillIconTextureResource() { }

		// [IteratorStateMachineAttribute] // RVA: 0x745444 Offset: 0x745444 VA: 0x745444
		// // RVA: 0xBF8A9C Offset: 0xBF8A9C VA: 0xBF8A9C
		// private IEnumerator LoadSkillEffectTextureCoroutine(int effectType, StringBuilder bundleName, StringBuilder assetName) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7454BC Offset: 0x7454BC VA: 0x7454BC
		// // RVA: 0xBF8B94 Offset: 0xBF8B94 VA: 0xBF8B94
		// private IEnumerator LoadingUIPrefab() { }

		// // RVA: 0xBF8C40 Offset: 0xBF8C40 VA: 0xBF8C40
		// private string GetDivaSkillCutinTextureBundlePath(int divaId, int costumeModelId, int costumeColorId) { }

		// // RVA: 0xBF8CD4 Offset: 0xBF8CD4 VA: 0xBF8CD4
		// private string GetDivaSkillCutinTextureAssetName(StringBuilder bundlePath, bool isMask) { }

		// [IteratorStateMachineAttribute] // RVA: 0x745534 Offset: 0x745534 VA: 0x745534
		// // RVA: 0xBF8E24 Offset: 0xBF8E24 VA: 0xBF8E24
		// private IEnumerator LoadPilotTexture() { }

		// // RVA: 0xBF8ED0 Offset: 0xBF8ED0 VA: 0xBF8ED0
		public void LoadSpecialResourceFor2DMode(int wavId, int stageDivaNum, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			UnityEngine.Debug.LogError("TODO LoadSpecialResourceFor2DMode");
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

		// [CompilerGeneratedAttribute] // RVA: 0x745714 Offset: 0x745714 VA: 0x745714
		// // RVA: 0xBF93A4 Offset: 0xBF93A4 VA: 0xBF93A4
		// private bool <Co_LoadSpecialDirectionResource>b__86_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x745724 Offset: 0x745724 VA: 0x745724
		// // RVA: 0xBF93D0 Offset: 0xBF93D0 VA: 0xBF93D0
		// private bool <Co_LoadARSpecialDirectionResource>b__88_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x745734 Offset: 0x745734 VA: 0x745734
		// // RVA: 0xBF93FC Offset: 0xBF93FC VA: 0xBF93FC
		// private void <LoadingUIPrefab>b__102_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x745744 Offset: 0x745744 VA: 0x745744
		// // RVA: 0xBF9404 Offset: 0xBF9404 VA: 0xBF9404
		// private void <LoadingUIPrefab>b__102_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x745754 Offset: 0x745754 VA: 0x745754
		// // RVA: 0xBF940C Offset: 0xBF940C VA: 0xBF940C
		// private bool <LoadPilotTexture>b__105_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x745764 Offset: 0x745764 VA: 0x745764
		// // RVA: 0xBF9438 Offset: 0xBF9438 VA: 0xBF9438
		// private bool <Co_LoadSpecialDirectionResourceFor2DMode>b__108_0() { }
	}
}
