using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemUseConfirm : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			throw new System.NotImplementedException();
		}

		public void Show()
		{
			throw new System.NotImplementedException();
		}

		public void Hide()
		{
			throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			throw new System.NotImplementedException();
		}

		public void CallOpenEnd()
		{
			throw new System.NotImplementedException();
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
		private Text m_textCaution_1;
		[SerializeField]
		private Text m_textCaution_2;
		[SerializeField]
		private Text m_textCaution_3;
		[SerializeField]
		private Text m_textPeriod;

		public Transform Parent => throw new System.NotImplementedException();
	}
}
