using XeApp.Game.Menu;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

public class PopupItemListGrowItemIcon : FlexibleListItemLayout
{
	private void Awake()
	{
		UnityEngine.Debug.LogError("Implement monobehaviour");
	}
	[SerializeField]
	private RawImageEx[] m_iconImages;
	[SerializeField]
	private RawImageEx[] m_frameImages;
	[SerializeField]
	private Text[] m_countTexts;
	[SerializeField]
	private StayButton[] m_stayButtons;
}
