using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferSortieLayout : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RectTransform m_ValAnimRect;
		public bool IsSortieEnd;
	}
}
