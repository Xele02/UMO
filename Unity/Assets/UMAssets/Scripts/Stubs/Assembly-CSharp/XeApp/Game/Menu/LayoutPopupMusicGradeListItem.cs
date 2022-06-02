using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicGradeListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_text01;
		[SerializeField]
		private Text m_text02;
		[SerializeField]
		private Text m_text03;
		[SerializeField]
		private RawImageEx m_image01;
		[SerializeField]
		private List<RawImageEx> m_imageFrame;
	}
}
