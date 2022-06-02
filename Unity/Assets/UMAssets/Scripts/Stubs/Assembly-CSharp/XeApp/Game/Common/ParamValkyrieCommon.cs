using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ParamValkyrieCommon : ScriptableObject
	{
		[Serializable]
		public class InfoTable
		{
			public int m_asset_id;
			public int m_motion_sub_id;
		}

		[SerializeField]
		public List<ParamValkyrieCommon.InfoTable> m_table_intro;
		[SerializeField]
		public List<ParamValkyrieCommon.InfoTable> m_table_battle;
	}
}
