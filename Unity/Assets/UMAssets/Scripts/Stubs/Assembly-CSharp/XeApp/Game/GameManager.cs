using UnityEngine;
using XeSys;
using XeSys.uGUI;
using XeApp.Game.RhythmGame;
using XeApp.Game.Common;

namespace XeApp.Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private FontManager fontManagerPrefab;
		[SerializeField]
		private UGUILetterBoxController letterboxPrefab;
		[SerializeField]
		private UGUIFader faderPrefab;
		[SerializeField]
		private GameObject popupPrefab;
		[SerializeField]
		private GameObject transmissionIconPrefab;
		[SerializeField]
		private GameObject downloadBarPrefab;
		[SerializeField]
		private GameObject progressBarPrefab;
		[SerializeField]
		private GameObject nowloadingPrefab;
		[SerializeField]
		private GameObject touchEffectPrefab;
		[SerializeField]
		private Camera systemCanvasCamera;
		[SerializeField]
		private GameObject cbtWindowPrefab;
		[SerializeField]
		private DebugCheatMenu debugCheatMenuPrefab;
		[SerializeField]
		private DebugNetworkPause debugNetworkPausePrefab;
		[SerializeField]
		private NotesSpeedSetting notesSpeedSetting;
		[SerializeField]
		private GameObject longScreenFramePrefab;
		[SerializeField]
		private EnableOnGUIObjects m_enableOnGUIObjects;
		public float ResolutionWidth;
		public float ResolutionHeight;
		public float AppResolutionWidth;
		public float AppResolutionHeight;
		public CriAtom criAtom;
		public string ar_session_id;
		public GameObject transmissionIcon;
		public DivaResource[] subDivaResource;
	}
}
