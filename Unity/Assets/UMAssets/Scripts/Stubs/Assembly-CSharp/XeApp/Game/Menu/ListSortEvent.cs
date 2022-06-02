using System;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	[Serializable]
	public class ListSortEvent : UnityEvent<SortItem, ListSortButtonGroup.SortOrder, bool>
	{
	}
}
