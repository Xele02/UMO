using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupFilterSort : UIBehaviour, IPopupContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
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

		public Transform Parent => null; //throw new System.NotImplementedException();

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
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

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}
	}
}
