using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxListItem : LayoutGachaBoxListElemBase
	{
		[SerializeField]
		private Text m_textRemain;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textNum;
		[SerializeField]
		private RawImageEx m_imageItem;
		[SerializeField]
		private RawImageEx m_imageStamp;
		[SerializeField]
		private RawImageEx[] m_imageFrame;
		[SerializeField]
		private ActionButton m_button;
	}
}
