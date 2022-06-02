using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textRank;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text[] m_textRate;
		[SerializeField]
		private RawImageEx m_imageRank;
		[SerializeField]
		private RawImageEx m_imageJacket;
		[SerializeField]
		private RawImageEx m_imageDifficulty;
		[SerializeField]
		private RawImageEx m_imageAttr;
		[SerializeField]
		private List<RawImageEx> m_imageFrame;
		public int m_JacketId;
	}
}
