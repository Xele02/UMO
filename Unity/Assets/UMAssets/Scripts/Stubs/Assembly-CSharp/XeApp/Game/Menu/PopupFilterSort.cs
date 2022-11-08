using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupFilterSort : UIBehaviour, IPopupContent
	{
		public enum Scene
		{
			None = -1,
			EpisodeSelect = 0,
			EpisodeSelect2 = 1,
			SelectHomeBg = 2,
			DivaSelect = 3,
			GoDivaMusicSelect = 4,
			Max = 5,
		}

		public int ResultSelectDivaId;

		public Transform Parent => throw new System.NotImplementedException();

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
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

		public void Hide()
		{
			throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			throw new System.NotImplementedException();
		}

		public void CallOpenEnd()
		{
			throw new System.NotImplementedException();
		}
	}
}
