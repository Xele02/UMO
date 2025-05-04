using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MembersListElemBase : LayoutLabelScriptBase
	{
		// RVA: 0xEC278C Offset: 0xEC278C VA: 0xEC278C
		protected void InvokeSelectItem(int value)
		{
			GetComponent<MembersListContent>().ClickButton.Invoke(value, GetComponent<MembersListContent>());
		}

		// RVA: 0xEC3510 Offset: 0xEC3510 VA: 0xEC3510 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}
	}
}
