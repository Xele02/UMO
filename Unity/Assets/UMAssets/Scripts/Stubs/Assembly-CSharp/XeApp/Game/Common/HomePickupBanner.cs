using UnityEngine;
using System;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class HomePickupBanner : MonoBehaviour
	{
		[Serializable]
		public class ReplaceInfo
		{
			public string name;
			public Sprite sprite;
		}

		[SerializeField]
		private ReplaceInfo[] m_tableReplace;
		[SerializeField]
		private float m_autoScrollWait;
		[SerializeField]
		private int m_sizeOpen;
		[SerializeField]
		private int m_sizeClose;
		[SerializeField]
		private float m_openAnimTime;
		[SerializeField]
		private float m_closeAnimTime;
		[SerializeField]
		private AnimationCurve m_animOpenClose;
		[SerializeField]
		private float m_changeTime;
		[SerializeField]
		private float m_swipeMinDistance;
		[SerializeField]
		private float m_swipeMaxDistance;
		[SerializeField]
		private ButtonBase m_buttonOpenClose;
		[SerializeField]
		private Image m_imageOpenClose;
		[SerializeField]
		private UGUILoopScrollList m_scrollView;
		[SerializeField]
		private GameObject m_scrollbar;
		[SerializeField]
		private Image m_imageScroll;
		[SerializeField]
		private HomePickupBannerContent m_objBanner;
		[SerializeField]
		private Transform m_rootPageNum;
		[SerializeField]
		private Text m_textPageNum;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
	}
}
