using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupSkipTicketUseConfirm : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }

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
		private StayButton m_itemButton;
		[SerializeField]
		private ActionButton m_minusButton;
		[SerializeField]
		private ActionButton m_plusButton;
		[SerializeField]
		private Text m_itemNameText;
		[SerializeField]
		private Text m_itemValueText;
		[SerializeField]
		private Text[] m_skipTicketTexts;
		[SerializeField]
		private Text[] m_consumeItemTexts;
		[SerializeField]
		private Text m_cautionText;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
