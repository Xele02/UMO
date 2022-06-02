using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ScrollListButton : ActionButton
	{
		[SerializeField]
		private bool root_parent;
		[SerializeField]
		private string parent_root_name;
		[SerializeField]
		private string btn_root_name;
	}
}
