using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneGrowthPanelBase : LayoutUGUIScriptBase
	{
		private Canvas _canvas; // 0x14
		private GraphicRaycaster _rayCaster; // 0x18
		private RectTransform _rectTransform; // 0x1C
		private LayoutUGUIRuntime _layoutRuntime; // 0x20
		private int _rayCasterBlockCount; // 0x24

		public RectTransform RectTransform { get { return _rectTransform; } } //0x10DCD84

		// RVA: 0x10DCD8C Offset: 0x10DCD8C VA: 0x10DCD8C
		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			if(_canvas == null)
			{
				_canvas = gameObject.AddComponent<Canvas>();
			}
			_rayCaster = GetComponent<GraphicRaycaster>();
			if(_rayCaster)
			{
				_rayCaster = gameObject.AddComponent<GraphicRaycaster>();
			}
			_layoutRuntime = GetComponent<LayoutUGUIRuntime>();
			_rectTransform = GetComponent<RectTransform>();
		}

		// RVA: 0x10DAE98 Offset: 0x10DAE98 VA: 0x10DAE98 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			_canvas.enabled = true;
			return true;
		}

		//// RVA: 0x10DCF50 Offset: 0x10DCF50 VA: 0x10DCF50
		public void SetActive(bool isActive)
		{
			SetActiveRaycaster(isActive);
			_layoutRuntime.enabled = isActive;
			if(!isActive)
			{
				_rectTransform.anchoredPosition = new Vector2(0, 200);
			}
		}

		//// RVA: 0x10DD074 Offset: 0x10DD074 VA: 0x10DD074
		public void SetEnableRaycaster(bool isEnable)
		{
			SetActiveRaycaster(isEnable);
		}

		//// RVA: 0x10DCFE4 Offset: 0x10DCFE4 VA: 0x10DCFE4
		private void SetActiveRaycaster(bool isEnable)
		{
			if(isEnable)
			{
				_rayCasterBlockCount--;
				if (_rayCasterBlockCount > 0)
					return;
				_rayCaster.enabled = true;
			}
			else
			{
				if(_rayCasterBlockCount == 0)
				{
					_rayCaster.enabled = false;
				}
				_rayCasterBlockCount++;
			}
		}
	}
}
