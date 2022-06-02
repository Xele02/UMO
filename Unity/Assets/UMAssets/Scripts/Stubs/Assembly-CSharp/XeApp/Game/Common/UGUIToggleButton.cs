using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUIToggleButton : ButtonBase
	{
		[Serializable]
		private struct PushDownSetting
		{
			public PushDownSetting(Transform trans, Vector3 offset) : this()
			{
			}

			public Transform m_targetTrans;
			public Vector3 m_offset;
		}

		[SerializeField]
		private short m_gropId;
		[SerializeField]
		private bool m_isNotRepeat;
		[SerializeField]
		private UGUIToggleButtonGroup m_parent;
		[SerializeField]
		private Image m_checkmark;
		[SerializeField]
		private GameObject m_hiddenControlObj;
		[SerializeField]
		private PushDownSetting m_pushDownSetting;
	}
}
