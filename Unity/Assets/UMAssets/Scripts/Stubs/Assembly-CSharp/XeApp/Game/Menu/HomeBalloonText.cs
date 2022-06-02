using UnityEngine;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeBalloonText : MonoBehaviour
	{
		[Serializable]
		public class ReplaceInfo
		{
			public string name;
			public Sprite type;
			public Sprite text;
		}

		[SerializeField]
		private ReplaceInfo[] m_tableReplace;
		[SerializeField]
		private Text m_textScroll;
		[SerializeField]
		private ButtonBase m_button;
		[SerializeField]
		private Image m_imageType;
		[SerializeField]
		private Image m_imageText;
		[SerializeField]
		private GameObject m_iconOnOff;
		[SerializeField]
		private RawImageEx m_imageIcon;
		[SerializeField]
		private Image m_imageClear;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
	}
}
