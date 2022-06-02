using XeSys.Gfx;
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusStanding : LayoutUGUIScriptBase
	{
		[Serializable]
		public class LoginBonusPrizeObject
		{
			[SerializeField]
			public RawImageEx iconL;
			[SerializeField]
			public RawImageEx iconS;
			[SerializeField]
			public NumberBase itemNumS;
			[SerializeField]
			public NumberBase itemNumL;
			[SerializeField]
			public NumberBase ucL;
			[SerializeField]
			public NumberBase ucS;
		}

		[SerializeField]
		private NumberBase[] m_day;
		[SerializeField]
		private LoginBonusPrizeObject[] m_prizeObject;
		[SerializeField]
		private ActionButton m_okButton;
	}
}
