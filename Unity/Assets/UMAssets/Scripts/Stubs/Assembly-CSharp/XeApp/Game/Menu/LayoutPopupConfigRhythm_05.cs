using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_05 : LayoutPopupConfigBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private NumberBase m_notes;
		[SerializeField]
		private GameObject m_timingPos;
		[SerializeField]
		private RawImageEx m_symbolNumber;
	}
}
