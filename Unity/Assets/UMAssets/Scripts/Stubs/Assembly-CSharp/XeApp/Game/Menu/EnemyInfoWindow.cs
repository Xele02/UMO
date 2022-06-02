using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class EnemyInfoWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_name;
		[SerializeField]
		private Text[] m_sp;
		[SerializeField]
		private Text m_info;
		[SerializeField]
		private RawImageEx m_enemy_image;
	}
}
