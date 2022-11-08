using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common.uGUI
{
	public class FontUpdater : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private Text[] m_textComponents;

		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
			return true;
		}

		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
