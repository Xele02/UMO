using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class DecoSetListContent : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text productName;
	}
}
