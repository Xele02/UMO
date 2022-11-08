using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGakuyaPresentUseContents : UIBehaviour, IPopupContent
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private RawImage m_imagePresent;
		[SerializeField]
		private Text m_textMessage;

		public Transform Parent => throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			throw new System.NotImplementedException();
		}

		public void Hide()
		{
			throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			throw new System.NotImplementedException();
		}

		public void Show()
		{
			throw new System.NotImplementedException();
		}
	}
}
