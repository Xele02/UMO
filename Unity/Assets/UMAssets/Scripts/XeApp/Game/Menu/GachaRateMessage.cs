using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GachaRateMessage : GachaRateElemBase
	{
		[SerializeField]
		private Text m_message; // 0x24
		private float preferredHeight; // 0x28

		public override float elemHeight { get { return (base.elemHeight <= preferredHeight) ? preferredHeight : base.elemHeight; } } //0xEE5E9C

		// RVA: 0xEE5DF8 Offset: 0xEE5DF8 VA: 0xEE5DF8
		public void SetMessage(string msg)
		{
			m_message.text = msg;
			preferredHeight = m_message.preferredHeight + m_message.fontSize;
		}

		// RVA: 0xEE5EB8 Offset: 0xEE5EB8 VA: 0xEE5EB8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
