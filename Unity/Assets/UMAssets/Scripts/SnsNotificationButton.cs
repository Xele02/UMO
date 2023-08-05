using XeApp.Game.Common;
using XeSys.Gfx;

public class SnsNotificationButton : ActionButton
{
	// RVA: 0xE0004C Offset: 0xE0004C VA: 0xE0004C Slot: 5
	public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
	{
		return base.InitializeFromLayout(layout, uvMan);
	}

	//// RVA: 0xE00054 Offset: 0xE00054 VA: 0xE00054
	public bool IsSelect()
	{
		return m_isPointerDown;
	}
}
