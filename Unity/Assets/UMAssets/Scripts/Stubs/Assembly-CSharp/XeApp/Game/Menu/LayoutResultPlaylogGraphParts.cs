using XeSys.Gfx;
using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogGraphParts : LayoutUGUIScriptBase
	{
		[Serializable]
		public class PartsData
		{
			[Serializable]
			public class ModeParts
			{
				public GameObject icon;
				public GameObject line;
			}

			public ModeParts[] mode_parts;
			public GameObject division_line;
			public GameObject skill_icon;
		}

		public PartsData[] m_PartsData;
	}
}
