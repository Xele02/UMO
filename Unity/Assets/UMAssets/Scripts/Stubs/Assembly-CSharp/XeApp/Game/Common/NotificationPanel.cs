using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class NotificationPanel : UIBehaviour
	{
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text m_titleTextWithBanner;
		[SerializeField]
		private Text m_dateText;
		[SerializeField]
		private Text m_dateTextWithBanner;
		[SerializeField]
		private Image m_newMark;
		[SerializeField]
		private Image m_newMarkWithBanner;
		[SerializeField]
		private RawImage m_bannerImage;
		[SerializeField]
		private GameObject m_normalRoot;
		[SerializeField]
		private GameObject m_bannerRoot;
		[SerializeField]
		private GameObject m_moreRoot;
	}
}
