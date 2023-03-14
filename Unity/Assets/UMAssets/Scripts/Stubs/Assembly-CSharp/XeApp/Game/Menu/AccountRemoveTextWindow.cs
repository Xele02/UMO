using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class AccountRemoveTextWindow : MonoBehaviour
	{
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text contentText;
		[SerializeField]
		private Image backGroundImage;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
