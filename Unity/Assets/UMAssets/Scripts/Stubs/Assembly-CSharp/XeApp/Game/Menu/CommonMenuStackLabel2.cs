using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CommonMenuStackLabel2 : LayoutLabelScriptBase
	{
		[SerializeField]
		private RawImageEx m_labelImage;
		[SerializeField]
		private RectTransform m_labelImageRect;
		[SerializeField]
		private Vector2 m_labelTexSize;
		[SerializeField]
		private Text m_description;
	}
}
