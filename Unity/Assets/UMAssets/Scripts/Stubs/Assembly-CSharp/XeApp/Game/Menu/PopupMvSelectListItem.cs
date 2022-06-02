using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupMvSelectListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private RawImageEx m_iconImage;
		[SerializeField]
		private RawImageEx m_setIcon;
		[SerializeField]
		private RawImageEx m_subImage;
		[SerializeField]
		private Text m_nameText;
		[SerializeField]
		private ActionButton m_button;
	}
}
