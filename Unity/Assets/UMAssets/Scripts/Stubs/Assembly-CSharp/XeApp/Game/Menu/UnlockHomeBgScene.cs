using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UnlockHomeBgScene : MonoBehaviour
	{
		[SerializeField]
		private UGUIButton okButton;
		[SerializeField]
		private RawImage[] images;
		[SerializeField]
		private Image fadeImg;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
