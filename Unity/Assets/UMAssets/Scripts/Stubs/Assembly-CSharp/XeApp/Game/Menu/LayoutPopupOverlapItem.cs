using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupOverlapItem : FlexibleListItemLayout
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_textPrev;
		[SerializeField]
		private Text m_textNext;
		[SerializeField]
		private RawImageEx m_imagePlate;
		[SerializeField]
		private RawImageEx m_imagePoster;
		[SerializeField]
		private ButtonBase m_button;
	}
}
