using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class DivaFriendIconDecorationBehaviour : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_degreeIconImage;
		[SerializeField]
		private RawImageEx m_friendIconImage;
		[SerializeField]
		private RawImageEx m_fanIconImage;
		[SerializeField]
		private NumberBase m_degreeNumber;
		[SerializeField]
		private List<RawImageEx> m_numberImages;
	}
}
