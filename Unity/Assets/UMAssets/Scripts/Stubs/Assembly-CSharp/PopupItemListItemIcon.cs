using XeApp.Game.Menu;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

public class PopupItemListItemIcon : FlexibleListItemLayout
{
	[SerializeField]
	private RawImageEx[] m_itemIconImage;
	[SerializeField]
	private Text[] m_countText;
	[SerializeField]
	private StayButton[] m_stayButton;
}
