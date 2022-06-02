using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeDecoRoomButton : MonoBehaviour
	{
		[SerializeField]
		private ButtonBase m_button;
		[SerializeField]
		private GameObject m_unlock;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private ColorGroup m_contentColorGroup;
		[SerializeField]
		private Color m_colorNormal;
		[SerializeField]
		private Color m_colorLock;
	}
}
