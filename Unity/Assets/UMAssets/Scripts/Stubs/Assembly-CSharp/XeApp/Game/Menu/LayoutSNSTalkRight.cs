using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSTalkRight : LayoutSNSBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text[] m_talk;
		[SerializeField]
		private Text[] m_name;
		[SerializeField]
		private RawImageEx[] m_image;
	}
}
