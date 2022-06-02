using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoSLive : MonoBehaviour
	{
		[SerializeField]
		private UGUIEnterLeave m_animeControl;
		[SerializeField]
		private List<SetDeckDivaCardControl> m_divas;
		[SerializeField]
		private List<SetDeckDivaCardControl> m_additionDivas;
	}
}
