using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GachaRateElemBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RectTransform m_rectTrans; // 0x14
		[SerializeField]
		private float m_elemWidth; // 0x18
		[SerializeField]
		private float m_elemHeight; // 0x1C

		public bool isLocked { get; set; } // 0x20
		public RectTransform rectTrans { get { return m_rectTrans; } } //0xEE43D0
		//public virtual float elemWidth { get; } 0xEE43D8
		public virtual float elemHeight { get { return m_elemHeight; } } //0xEE43E0
	}
}
