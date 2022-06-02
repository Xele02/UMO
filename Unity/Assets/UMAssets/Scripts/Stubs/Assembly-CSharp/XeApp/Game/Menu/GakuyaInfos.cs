using UnityEngine;
using System;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GakuyaInfos : MonoBehaviour
	{
		[Serializable]
		private struct SelectButtonHandle
		{
			public UGUIButton m_button;
			public Image m_imageBase;
			public Image m_imageIcon;
			public Text m_text;
		}

		[Serializable]
		private struct SelectButtonVisualInfo
		{
			public Sprite m_baseSprite;
			public Color m_iconColor;
			public Color m_textColor;
		}

		[Serializable]
		private struct DivaVisualInfo
		{
			public Color m_color;
		}

		[SerializeField]
		private Image m_imageDivaNameLabel;
		[SerializeField]
		private Text m_textDivaName;
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl;
		[SerializeField]
		private UGUIButton m_buttonChangeDiva;
		[SerializeField]
		private SelectButtonHandle m_buttonHandleStatus;
		[SerializeField]
		private SelectButtonHandle m_buttonHandleDress;
		[SerializeField]
		private SelectButtonHandle m_buttonHandleGift;
		[SerializeField]
		private SelectButtonHandle m_buttonHandleProfile;
		[SerializeField]
		private GameObject m_giftLockObject;
		[SerializeField]
		private Transform m_transformContent;
		[SerializeField]
		private Transform m_transformEscapeContent;
		[SerializeField]
		private Animator m_animatorContent;
		[SerializeField]
		private GameObject m_contentTapGuard;
		[SerializeField]
		private SelectButtonVisualInfo m_selectButtonVisualInfoNormal;
		[SerializeField]
		private SelectButtonVisualInfo m_selectButtonVisualInfoSelecting;
		[SerializeField]
		private List<GakuyaInfos.DivaVisualInfo> m_divaVisualInfos;
		[SerializeField]
		private ColorGroup m_contentColorGroup;
		[SerializeField]
		private Color m_colorNormal;
		[SerializeField]
		private Color m_colorLock;
	}
}
