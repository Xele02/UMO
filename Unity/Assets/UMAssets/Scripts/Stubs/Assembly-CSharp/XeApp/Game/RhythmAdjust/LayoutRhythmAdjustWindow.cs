using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.RhythmAdjust
{
	public class LayoutRhythmAdjustWindow : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Slider m_sliderPrefab;
		[SerializeField]
		private GameObject m_sliderParent;
	}
}
