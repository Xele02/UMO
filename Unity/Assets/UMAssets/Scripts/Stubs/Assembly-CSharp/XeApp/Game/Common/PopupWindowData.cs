using UnityEngine;

namespace XeApp.Game.Common
{
	public class PopupWindowData : ScriptableObject
	{
		public enum ContentTextType
		{
			RhythmGame_RetryConfirmation = 0,
			RhythmGame_RetryReconfirmation = 1,
		}

		public enum ButtonTextType
		{
			NO = 0,
			Continue = 1,
			Retire = 2,
		}

		[SerializeField]
		public ContentTextType contentMessage;
		[SerializeField]
		public ButtonTextType[] buttonMessage;
	}
}
