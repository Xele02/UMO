using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollView : UIBehaviour
	{
		[SerializeField]
		private MusicScrollCenterItem _centerItem;
		[SerializeField]
		private MusicScrollItem[] _overScrollItem;
		[SerializeField]
		private MusicScrollItem[] _underScrollItem;
		[SerializeField]
		private CanvasGroup m_hitRectCanvasGroup;
		public MusicUpdateCenterItem OnUpdateCenter;
		public MusicUpdateListItem OnUpdateListItem;
		public MusicUpdateClipItem OnUpdateClipItem;
		public ScrollStartEvent OnScrollStartEvent;
		public ScrollEndEvent OnScrollEndEvent;
		public float StopT;
		public float ClipSpeed;
	}
}
