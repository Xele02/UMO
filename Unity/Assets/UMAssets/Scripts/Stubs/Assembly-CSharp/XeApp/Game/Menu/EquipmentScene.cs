using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EquipmentScene : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_centerIconImage;
		[SerializeField]
		private RawImageEx m_divaIconImage;
		[SerializeField]
		private RawImageEx[] m_skillIconImages;
		[SerializeField]
		private RawImageEx[] m_sceneIconImages;
		[SerializeField]
		private StayButton[] m_sceneButtons;
		[SerializeField]
		private Text[] m_episodeNameText;
		[SerializeField]
		private Text m_assistNameText;
		[SerializeField]
		private SelectEquipmentSlotEvent m_onSelectSlotEvent;
		[SerializeField]
		private SelectEquipmentSlotEvent m_onShowSceneStatusEvent;
	}
}
