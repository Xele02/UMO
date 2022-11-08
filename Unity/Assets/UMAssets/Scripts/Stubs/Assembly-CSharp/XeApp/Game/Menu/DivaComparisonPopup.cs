using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaComparisonPopup : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private DivaComparisonParam[] m_params;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;

		public Transform Parent => throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			throw new System.NotImplementedException();
		}

		public void Hide()
		{
			throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new System.NotImplementedException();
		}

		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			throw new System.NotImplementedException();
		}

		public bool IsReady()
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
	}
}
