
using UnityEngine;

namespace XeApp.Game.Menu
{ 
	public class ItemPeriodComfirmListHeader : IFlexibleListItem
	{
		public Vector2 Top { get; set; } // 0x8
		public float Height { get; set; } // 0x10
		public int ResourceType { get; set; } // 0x14
		public FlexibleListItemLayout Layout { get; set; } // 0x18
	}
}
