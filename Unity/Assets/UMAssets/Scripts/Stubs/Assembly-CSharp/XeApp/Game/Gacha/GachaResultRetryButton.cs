using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Gacha
{
	public class GachaResultRetryButton : ActionButton
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private NumberBase m_consumeNumber;
		[SerializeField]
		private RawImageEx m_consumeUnitImage;
		[SerializeField]
		private RawImageEx m_currencyIconImage;
	}
}
