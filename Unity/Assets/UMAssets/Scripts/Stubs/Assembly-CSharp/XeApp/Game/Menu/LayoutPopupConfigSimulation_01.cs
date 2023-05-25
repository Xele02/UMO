using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigSimulation_01 : LayoutPopupConfigBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override int GetContentsHeight()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
			return 0;
		}

		public override bool IsShow()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
			return false;
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
