using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MvModeWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		private class PrismButtonSet
		{
			public ActionButton button;
			public RawImageEx image;
		}

		[Serializable]
		private class PrismCharaSet
		{
			public MvModeWindow.PrismButtonSet chara;
			public MvModeWindow.PrismButtonSet costume;
		}

		[SerializeField]
		private PrismCharaSet[] m_charaSet;
		[SerializeField]
		private PrismButtonSet m_valkyrieSet;
		[SerializeField]
		private ToggleButton[] m_toggleButtons;
		[SerializeField]
		private ToggleButtonGroup m_prizmEnableToggleButtonGroup;
		[SerializeField]
		private ToggleButtonGroup m_notesVisibleToggleButtonGroup;
		[SerializeField]
		private Text[] m_toggleButtonLabels;
		[SerializeField]
		private Text[] m_cautionText;
		[SerializeField]
		private RawImageEx m_jecketImage;
		[SerializeField]
		private Material m_defaultMat;
		[SerializeField]
		private Texture m_baseTexture;
		[SerializeField]
		private Texture m_maskTexture;
	}
}
