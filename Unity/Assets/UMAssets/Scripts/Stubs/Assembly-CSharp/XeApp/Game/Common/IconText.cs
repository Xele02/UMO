using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class IconText : Text
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		public IconTextSetting m_setting;
		public float m_iconScale;
		public bool IsTextAlpha;
		[SerializeField]
		private List<RawImage> m_imageObjectList;
	}
}
