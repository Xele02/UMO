using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemGachaPeriodConfirm : LayoutUGUIScriptBase, IPopupContent
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
		private RawImageEx m_imageIcon;
		[SerializeField]
		private ActionButton m_buttonIcon;
		[SerializeField]
		private ActionButton m_buttonDetail;
		[SerializeField]
		private NumberBase m_numberCost;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text[] m_textCount;
		[SerializeField]
		private Text m_textCaution;
		[SerializeField]
		private Text m_textPeriod;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
