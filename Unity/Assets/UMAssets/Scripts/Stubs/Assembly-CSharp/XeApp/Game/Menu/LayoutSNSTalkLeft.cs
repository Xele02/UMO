using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSTalkLeft : LayoutSNSBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Text[] m_talk;
		[SerializeField]
		private Text[] m_name;
		[SerializeField]
		private RawImageEx[] m_image;
	}
}
