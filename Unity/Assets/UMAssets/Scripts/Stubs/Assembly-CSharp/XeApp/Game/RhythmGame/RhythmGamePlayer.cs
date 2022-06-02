using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game;
using XeSys.uGUI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGamePlayer : MonoBehaviour
	{
		[SerializeField]
		private GameDivaObject gameDivaObject;
		[SerializeField]
		public GameDivaObject[] subDivaObject;
		[SerializeField]
		private RhythmGamePerformer gamePerformer;
		[SerializeField]
		private RhythmGameUIController uiController;
		[SerializeField]
		private RhythmGameScene scene;
		[SerializeField]
		private RNoteOwner rNoteOwner;
		public int noteOffsetMillisec;
		public int currentRawMusicMillisec;
		public int continueCount;
		[SerializeField]
		private CRIAtomMemoryPoolInfo memPoolInfo;
		[SerializeField]
		private MusicCameraObject musicCameraObject;
		[SerializeField]
		private StageObject stageObject;
		[SerializeField]
		private GameValkyrieObject valkyrieObject;
		[SerializeField]
		private MusicIntroObject musicIntroObject;
		[SerializeField]
		private ValkyrieModeObject valkyrieModeObject;
		[SerializeField]
		private DivaModeObject divaModeObject;
		[SerializeField]
		private LowModeBackgroundObject lowModeBackgroundObject;
		[SerializeField]
		private Camera mode3dCamera;
		[SerializeField]
		private Camera mode2dCamera;
		[SerializeField]
		private GameObject objectRoot3dLayer;
		[SerializeField]
		private GameObject objectRoot2dLayer;
		[SerializeField]
		private UGUIFader uguiFader;
		[SerializeField]
		private MeshRenderer dimmer3dMesh;
	}
}
