using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpCollectPopup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_restTimeText;
		[SerializeField]
		private Text m_lvText;
		[SerializeField]
		private Text m_nextLvText;
		[SerializeField]
		private Text m_collectTimeText;
		[SerializeField]
		private Text m_collectNextTimeText;
		[SerializeField]
		private Text m_collectItemText;
		[SerializeField]
		private Text m_collectNextItemText;
		[SerializeField]
		private Text m_lvUpRestItemNumText;
		[SerializeField]
		private RawImageEx m_itemImage;
	}
}
