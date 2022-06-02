using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class AccountAgreeWindow : MonoBehaviour
	{
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text agreeText;
		[SerializeField]
		private Text agreeButtonText;
		[SerializeField]
		private Text accountRemoveButtonText;
		[SerializeField]
		private Text cancelButtonText;
		[SerializeField]
		private Text consentButtonText;
		[SerializeField]
		private UGUIToggleButton agreeToggleButton;
		[SerializeField]
		private UGUIButton accountRemoveButton;
		[SerializeField]
		private UGUIButton cancelButton;
		[SerializeField]
		private UGUIButton consentButton;
		[SerializeField]
		private Image backGroundImage;
	}
}
