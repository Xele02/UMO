using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class CommonMenuTopMiniWindow : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_rootMain;
		[SerializeField]
		private GameObject m_rootText;
		[SerializeField]
		private Text m_textNext;
		[SerializeField]
		private Text m_textPoint;
		[SerializeField]
		private GameObject m_rootItem;
		[SerializeField]
		private RawImageEx m_imageItem;
		[SerializeField]
		private ButtonBase m_button;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private List<Vector2> m_position;
		public bool m_isEnter;
	}
}
