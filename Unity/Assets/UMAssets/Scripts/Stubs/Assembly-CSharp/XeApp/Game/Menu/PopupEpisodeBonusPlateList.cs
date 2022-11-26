using UnityEngine.EventSystems;
using System;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusPlateList : UIBehaviour, IPopupContent
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[Serializable]
		private struct Setting
		{
			public Vector2 StartPoint;
			public Vector2 Advance;
			public int RowCount;
		}

		[SerializeField]
		private Setting[] settings;
		[SerializeField]
		private RawImageEx m_rawImageSource;
		[SerializeField]
		private Text m_errorText;

		public Transform Parent => throw new NotImplementedException();

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new NotImplementedException();
		}

		public bool IsScrollable()
		{
			throw new NotImplementedException();
		}

		public void Show()
		{
			throw new NotImplementedException();
		}

		public void Hide()
		{
			throw new NotImplementedException();
		}

		public bool IsReady()
		{
			throw new NotImplementedException();
		}

		public void CallOpenEnd()
		{
			throw new NotImplementedException();
		}
	}
}
