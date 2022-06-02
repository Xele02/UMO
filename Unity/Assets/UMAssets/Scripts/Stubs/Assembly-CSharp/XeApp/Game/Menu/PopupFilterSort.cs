using UnityEngine.EventSystems;

namespace XeApp.Game.Menu
{
	public class PopupFilterSort : UIBehaviour
	{
		public enum Scene
		{
			None = -1,
			EpisodeSelect = 0,
			EpisodeSelect2 = 1,
			SelectHomeBg = 2,
			DivaSelect = 3,
			GoDivaMusicSelect = 4,
			Max = 5,
		}

		public int ResultSelectDivaId;
	}
}
