using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GakuyaCostumeListContent : SwapScrollListContent
	{
		[SerializeField]
		private UGUIButton m_button;
		[SerializeField]
		private Image m_backNormal;
		[SerializeField]
		private Image m_backDressing;
		[SerializeField]
		private RawImage m_imageCostume;
		[SerializeField]
		private List<Image> m_lvStars;
		[SerializeField]
		private List<Image> m_lvStarBases;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Image m_checkIcon;
		[SerializeField]
		private Image m_newIcon;
		[SerializeField]
		private Image m_tryingFrame;
		[SerializeField]
		private Image m_colorChangeIcon;
		[SerializeField]
		private Image m_lockIcon;
		[SerializeField]
		private ColorGroup m_contentColorGroup;
		[SerializeField]
		private Color m_colorNormal;
		[SerializeField]
		private Color m_colorLock;
	}
}
