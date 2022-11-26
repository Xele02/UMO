using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SceneComparisonPopup : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private SceneComparisonParam[] m_params;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private RepeatButton m_scorePlusButton;
		[SerializeField]
		private RepeatButton m_scoreMinusButton;
		[SerializeField]
		private UnitExpectedScore[] m_scoreGauges;
		[SerializeField]
		private RawImageEx m_scoreTotalArrowImage;
		[SerializeField]
		private RawImageEx m_scorePlusImage;
		[SerializeField]
		private Text[] m_textGaugeNames;
		[SerializeField]
		private Text m_gaugeRateText;
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
