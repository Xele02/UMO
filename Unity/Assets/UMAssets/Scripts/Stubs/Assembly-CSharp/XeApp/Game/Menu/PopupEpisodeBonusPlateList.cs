using UnityEngine.EventSystems;
using System;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusPlateList : UIBehaviour
	{
		[Serializable]
		private struct Setting
		{
			public Vector2 StartPoint;
			public Vector2 Advance;
			public int RowCount;
		}

		[SerializeField]
		private Setting[] settings;
		[SerializeField]
		private RawImageEx m_rawImageSource;
		[SerializeField]
		private Text m_errorText;
	}
}
