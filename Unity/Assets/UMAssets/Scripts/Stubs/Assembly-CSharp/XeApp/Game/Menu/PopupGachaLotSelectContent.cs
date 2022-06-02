using XeSys.Gfx;
using System;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotSelectContent : LayoutUGUIScriptBase
	{
		[Serializable]
		private class LotInfo
		{
			public Text text;
			public LayoutGachaDrawButton button;
		}

		[SerializeField]
		private Text[] m_textDesc;
		[SerializeField]
		private LotInfo[] m_lotInfo;
	}
}
