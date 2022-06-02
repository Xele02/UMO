using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutGachaDrawButton : ActionButton
	{
		[SerializeField]
		private RawImageEx m_imageCostIcon;
		[SerializeField]
		private RawImageEx m_imageKakuteiInfo;
		[SerializeField]
		private RawImageEx[] m_imageButton;
		[SerializeField]
		private Font m_fontKakutei;
		[SerializeField]
		private Text m_textKakutei;
		[SerializeField]
		private List<Text> m_textLotCost;
		[SerializeField]
		private NumberBase m_numberLotCount;
		[SerializeField]
		private NumberBase m_numberLotCost;
	}
}
