using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class AccountConfirmWindow : MonoBehaviour
	{
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text contentText;
		[SerializeField]
		private Text okButtonText;
		[SerializeField]
		private Text cancelButtonText;
		[SerializeField]
		private UGUIButton okButton;
		[SerializeField]
		private UGUIButton cancelButton;
		[SerializeField]
		private Image backGroundImage;
	}
}
