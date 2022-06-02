using System;
using UnityEngine.UI;
using XeApp.Game;
using UnityEngine;

namespace XeApp.Game.Adv
{
	[Serializable]
	public class MessageWindowInfo
	{
		public Text m_name;
		public AdvMessageBase m_message;
		public ColorTween[] m_windowTween;
		public RectTransform m_messageWindow;
	}
}
