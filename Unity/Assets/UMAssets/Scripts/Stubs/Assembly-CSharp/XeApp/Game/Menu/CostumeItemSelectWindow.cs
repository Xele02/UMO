using XeSys.Gfx;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CostumeItemSelectWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		public class ItemPanel
		{
			public Text name;
			public Text info;
			public Text item_num;
			public RawImageEx image;
			public ActionButton btn;
			public ActionButton detail_btn;
		}

		[SerializeField]
		private List<CostumeItemSelectWindow.ItemPanel> m_list;
	}
}
