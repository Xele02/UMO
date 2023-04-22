using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAchieveReward : LayoutUGUIScriptBase
	{
		
		private enum eLayoutArrayIndex
		{
			Clear = 0,
			Score = 4,
			Combo = 8,
			Max = 12,
		}

		private enum eStampStatus
		{
			None = 0,
			Play = 1,
			Press = 2,
			Skip = 3,
		}

		private enum eLayoutType
		{
			None = 0,
			Clear = 1,
			Score = 2,
			Combo = 3,
		}

		public enum eMode
		{
			None = 0,
			MusicSelect = 1,
			Result = 2,
		}


    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx[] m_icons;
		[SerializeField]
		private NumberBase[] m_nums;
		[SerializeField]
		private Text[] m_texts;
		[SerializeField]
		private string[] m_layerNames;
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_clearNum;
		[SerializeField]
		private Text m_scoreNum;
		[SerializeField]
		private Text m_comboNum;
		[SerializeField]
		private RawImageEx[] m_diffImages;
	}
}
