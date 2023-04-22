using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game
{
	public class TextFontReapply : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private List<Text> m_textComponents;

		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			//throw new System.NotImplementedException();
			return true;
		}

		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
