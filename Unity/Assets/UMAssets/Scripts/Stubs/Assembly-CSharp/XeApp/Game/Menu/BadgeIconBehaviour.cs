using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class BadgeIconBehaviour : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private Text m_text;
		[SerializeField]
		private RawImageEx m_image;

		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			//throw new System.NotImplementedException();
			return true;
		}

		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
