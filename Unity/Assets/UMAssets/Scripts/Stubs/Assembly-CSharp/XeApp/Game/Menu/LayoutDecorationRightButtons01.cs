using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationRightButtons01 : LayoutUGUIScriptBase
	{
		[Serializable]
		public class EditLayout
		{
			public ActionButton m_button;
			public ActionButton m_maxButton;
		}

		[SerializeField]
		private ActionButton m_takeButton;
		[SerializeField]
		private ActionButton m_mapChangeButton;
		[SerializeField]
		private ActionButton m_mapNameEditButton;
		[SerializeField]
		private Text m_mapNameText;
		[SerializeField]
		private EditLayout m_showEditButton;
		[SerializeField]
		private List<LayoutDecorationRightButtons01.EditLayout> m_edits;
		[SerializeField]
		private ActionButton m_decoButton;
		[SerializeField]
		private NumberBase m_decoNumber;
		[SerializeField]
		private ActionButton m_optionButton;
		[SerializeField]
		private ActionButton m_playerSearchButton;
	}
}
