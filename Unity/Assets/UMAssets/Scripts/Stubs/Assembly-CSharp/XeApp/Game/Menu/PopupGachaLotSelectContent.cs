using XeSys.Gfx;
using System;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotSelectContent : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new NotImplementedException();
		}

		public bool IsScrollable()
		{
			throw new NotImplementedException();
		}

		public void Show()
		{
			throw new NotImplementedException();
		}

		public void Hide()
		{
			throw new NotImplementedException();
		}

		public bool IsReady()
		{
			throw new NotImplementedException();
		}

		public void CallOpenEnd()
		{
			throw new NotImplementedException();
		}

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

		public Transform Parent => throw new NotImplementedException();
	}
}
