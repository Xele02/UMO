using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PresentListElem : GeneralListElemBase
	{
		[SerializeField]
		private RawImageEx m_itemIconImage;
		[SerializeField]
		private RawImageEx m_dateLabelImage;
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text m_limitText;
		[SerializeField]
		private Text m_conditionText;
		[SerializeField]
		private Text m_dateText;
		[SerializeField]
		private ScrollListButton m_button;
	}
}
