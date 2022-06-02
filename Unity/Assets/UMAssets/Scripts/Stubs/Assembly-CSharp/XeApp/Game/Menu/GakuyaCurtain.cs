using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GakuyaCurtain : MonoBehaviour
	{
		[Serializable]
		private struct DivaSettingInfo
		{
			public Color32 m_colorBorder1;
			public Color32 m_colorBorder2;
			public Sprite m_spriteBorder;
			public Sprite m_spriteChara;
			public int m_messageImagePosId;
		}

		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl;
		[SerializeField]
		private List<Image> m_imageBorderGroup1;
		[SerializeField]
		private List<Image> m_imageBorderGroup2;
		[SerializeField]
		private Image m_imageChara;
		[SerializeField]
		private List<Image> m_imageMessageList;
		[SerializeField]
		private List<GakuyaCurtain.DivaSettingInfo> m_divaSettinfInfos;
		[SerializeField]
		private List<Sprite> m_messageSprites;
	}
}
