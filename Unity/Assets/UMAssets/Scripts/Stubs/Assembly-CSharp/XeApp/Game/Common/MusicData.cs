using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicData : MonoBehaviour
	{
		public enum NoteModeType
		{
			None = 0,
			Normal = 1,
			Valkyrie = 2,
			Diva = 3,
			Num = 4,
		}

		public int noteDisplayMillisec;
		public int introFadeMillisec;
		public int valkyrieModeJudgeMillisec;
		public int valkyrieModeStartHUDMillisec;
		public int valkyrieModeStartFadeMillisec;
		public int valkyrieModeStartMillisec;
		public int valkyrieModeLeaveMillisec;
		public int divaModeJudgeMillisec;
		public int divaModeStartMillisec;
		public int rhythmGameResultStartMillisec;
		public int tutorialOneEndGameStartMillisec;
		public int tutorialTwoForceFwaveMaxStartMillisec;
		public int tutorialTwoForceDefeatEnemyStartMillisec;
		public int tutorialTwoModeDescriptionlStartMillisec;
	}
}
