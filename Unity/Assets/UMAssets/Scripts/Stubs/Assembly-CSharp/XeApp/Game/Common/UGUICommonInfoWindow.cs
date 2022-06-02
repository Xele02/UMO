using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUICommonInfoWindow : MonoBehaviour
	{
		public enum Direction
		{
			None = 0,
			Left = 1,
			Right = 2,
			Top = 3,
			Bottom = 4,
		}

		[SerializeField]
		private Direction m_direction;
		[SerializeField]
		private RectTransform m_root;
		[SerializeField]
		private Image m_imageTelop;
		[SerializeField]
		private Image m_imageArrow;
		[SerializeField]
		private Image m_imageIcon;
		[SerializeField]
		private Text m_textMessage;
		[SerializeField]
		private InOutAnime m_inOutAnime;
	}
}
