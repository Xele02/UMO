using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_02 : LayoutPopupConfigBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private GameObject m_notesPos;
		[SerializeField]
		private GameObject m_voicePos;
		[SerializeField]
		private GameObject m_sePos;
		[SerializeField]
		private GameObject m_bgmPos;
	}
}
