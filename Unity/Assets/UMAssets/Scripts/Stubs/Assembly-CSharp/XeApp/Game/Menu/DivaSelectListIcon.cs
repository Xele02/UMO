using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class DivaSelectListIcon : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_divaIconImage;
		[SerializeField]
		private RawImageEx[] m_skillIconImages;
		[SerializeField]
		private RawImageEx[] m_sceneIconImages;
		[SerializeField]
		private RawImageEx m_centerIcon;
		[SerializeField]
		private RawImageEx m_setIcon;
		[SerializeField]
		private StayButton m_stayButton;
		[SerializeField]
		private UnityEvent m_onPushEvent;
		[SerializeField]
		private UnityEvent m_onStayEvent;
	}
}
