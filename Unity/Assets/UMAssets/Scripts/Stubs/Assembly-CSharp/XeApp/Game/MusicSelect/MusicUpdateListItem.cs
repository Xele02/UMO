using System;
using UnityEngine.Events;

namespace XeApp.Game.MusicSelect
{
	[Serializable]
	public class MusicUpdateListItem : UnityEvent<int, MusicScrollItem>
	{
	}
}
