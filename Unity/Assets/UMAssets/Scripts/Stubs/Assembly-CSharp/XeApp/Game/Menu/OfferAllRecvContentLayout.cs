using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvContentLayout : SwapScrollListContent
	{
		[SerializeField]
		private Text m_offerName;
		[SerializeField]
		private Text m_platoonName;
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private RawImageEx[] m_valkyrieIcon;
		[SerializeField]
		private RawImageEx m_seriesIcon;
		[SerializeField]
		private RawImageEx m_seriesLogo;
	}
}
