using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Tutorial
{
	public class TutorialTextPopup : MonoBehaviour, IPopupContent
	{
		[SerializeField]
		private TutorialCharactor m_charactor;
		[SerializeField]
		private Text m_messageText;

		public Transform Parent => null; //throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public bool IsScrollable()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void Show()
		{
			//throw new System.NotImplementedException();
		}

		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
