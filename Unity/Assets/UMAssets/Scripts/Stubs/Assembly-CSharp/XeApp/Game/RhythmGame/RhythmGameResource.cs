using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameResource : MonoBehaviour
	{
		public MusicData musicData;
		public DivaResource divaResource;
		public List<DivaResource> subDivaResource;
		public MusicCameraResource cameraResource;
		public StageResource stageResources;
		public ValkyrieResource valkyrieResource;
		public MusicIntroResource musicIntroResource;
		public ValkyrieModeResource valkyrieModeResource;
		public DivaModeResource divaModeResource;
		public LowModeBackgroundResource lowModeBackgroundResource;
		public RhytmGameParameterResource paramResource;
		public List<DivaExtensionResource> divaExtensionResource;
		public List<DivaCutinResource> divaCutinResource;
		public List<MusicCameraCutinResource> musicCameraCutinResource;
		public List<StageLightingResource> stageLightingResource;
		public List<StageExtensionResource> stageExtensionResource;
		public MusicVoiceChangerResource musicVoiceChangerResource;
		public MusicStageChangerResource musicStageChangerResource;
		public MusicBoneSpringResource[] musicBoneSpringResource;
		public int specialDirectionMovieId_;
		public GameObject uiPrefab;
		public GameObject enemySkillPrefab;
		public GameObject faildUiPrefab;
		public GameObject completeUiPrefab;
	}
}
