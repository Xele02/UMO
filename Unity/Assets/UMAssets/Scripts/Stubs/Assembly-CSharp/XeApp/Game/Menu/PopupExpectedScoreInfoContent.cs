using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupExpectedScoreInfoContent : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void Show()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		[SerializeField]
		private Text[] m_textName;
		[SerializeField]
		private Text[] m_textDesc;
		[SerializeField]
		private Text[] m_textCaution;
		[SerializeField]
		private UnitExpectedScore m_scoreGauge;
		[SerializeField]
		private RepeatButton m_buttonScorePlus;
		[SerializeField]
		private RepeatButton m_buttonScoreMinus;
		[SerializeField]
		private RawImageEx m_imageScorePlus;
		[SerializeField]
		private Text m_textGaugeRate;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
