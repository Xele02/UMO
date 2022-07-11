using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class FlexibleListItemLayout : LayoutUGUIScriptBase
	{
		private RectTransform _rectTransform; // 0x14

		public RectTransform RectTransform { get {
			if(_rectTransform == null)
			{
				_rectTransform = GetComponent<RectTransform>();
			}
			return _rectTransform;
		} }//0xBA0B14
	}
}
