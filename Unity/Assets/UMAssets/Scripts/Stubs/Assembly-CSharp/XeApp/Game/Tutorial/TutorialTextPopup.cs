using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Tutorial
{
	public class TutorialTextPopup : MonoBehaviour
	{
		[SerializeField]
		private TutorialCharactor m_charactor;
		[SerializeField]
		private Text m_messageText;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
