using UnityEngine;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollItemLabelGroup : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup[] timeLabel;
		[SerializeField]
		private CanvasGroup[] eventLabel;
		[SerializeField]
		private CanvasGroup[] musicTypeLabel;
		[SerializeField]
		private CanvasGroup[] playBoostLabel;
		[SerializeField]
		private GameObject limitedSLiveLabel;
	}
}
