using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDJacket : LayoutLabelScriptBase
	{
		[SerializeField]
		private RawImageEx m_jacketImage;
		[SerializeField]
		private int m_jacketIndex;
		[SerializeField]
		private string m_frameAttrPreset;
		[SerializeField]
		private List<RawImageEx> m_allImages;
		[SerializeField]
		private MusicSelectCDButton m_cdButton;
	}
}
