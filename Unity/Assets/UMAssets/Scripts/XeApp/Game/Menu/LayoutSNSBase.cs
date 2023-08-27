using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSBase : LayoutUGUIScriptBase
	{
		public bool SePlayEnable { get; set; } // 0x11

		//// RVA: 0x1D1C22C Offset: 0x1D1C22C VA: 0x1D1C22C Slot: 6
		public virtual void SetPosition(float pos_x, float pos_y, float height)
		{
			return;
		}

		//// RVA: 0x1D1C230 Offset: 0x1D1C230 VA: 0x1D1C230 Slot: 7
		public virtual void SetPosition(float pos_x, float pos_y)
		{
			return;
		}

		//// RVA: 0x1D1C234 Offset: 0x1D1C234 VA: 0x1D1C234 Slot: 8
		public virtual void Show()
		{
			return;
		}

		//// RVA: 0x1D1C238 Offset: 0x1D1C238 VA: 0x1D1C238 Slot: 9
		public virtual void Hide()
		{
			return;
		}

		//// RVA: 0x1D1C23C Offset: 0x1D1C23C VA: 0x1D1C23C Slot: 10
		public virtual void In()
		{
			return;
		}

		//// RVA: 0x1D1C240 Offset: 0x1D1C240 VA: 0x1D1C240 Slot: 11
		public virtual void Out()
		{
			return;
		}

		//// RVA: 0x1D1C244 Offset: 0x1D1C244 VA: 0x1D1C244 Slot: 12
		public virtual bool IsPlaying()
		{
			return false;
		}

		//// RVA: 0x1D1C24C Offset: 0x1D1C24C VA: 0x1D1C24C Slot: 13
		public virtual void SetStatus(SNSTalkCreater.ViewTalk talk)
		{
			return;
		}

		//// RVA: 0x1D1C250 Offset: 0x1D1C250 VA: 0x1D1C250 Slot: 14
		public virtual void SetStatus(GAKAAIHLFKI room, Action<int> callback)
		{
			return;
		}
	}
}
