using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateTab : MonoBehaviour
	{
		[SerializeField]
		public GameAttribute.Type attr;
		[SerializeField]
		private Text[] text;
		[SerializeField]
		private ActionButton button;
	}
}
