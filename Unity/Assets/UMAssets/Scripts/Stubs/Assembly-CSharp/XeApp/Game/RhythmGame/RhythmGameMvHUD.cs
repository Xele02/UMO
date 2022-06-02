using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameMvHUD : MonoBehaviour
	{
		[SerializeField]
		private PrefabInstance[] touchPrefab;
		[SerializeField]
		private PrefabInstance[] touchPrefabWide;
		[SerializeField]
		private GameObject waterMark;
		[SerializeField]
		private GameObject touchMark;
		[SerializeField]
		private GameObject touchMarkWide;
		[SerializeField]
		private GameObject m_userStateObject;
		[SerializeField]
		private GameObject valkyrieTopObject;
		[SerializeField]
		private GameObject m_targetSightPrefab;
		[SerializeField]
		private GameObject pauseButton;
		[SerializeField]
		private RectTransform leftTop;
		[SerializeField]
		private RectTransform RightTop;
		[SerializeField]
		private RectTransform leftBottom;
		[SerializeField]
		private RectTransform top;
		[SerializeField]
		private RectTransform center;
		[SerializeField]
		private RectTransform bottom;
		[SerializeField]
		private RectTransform bottomWide;
	}
}
