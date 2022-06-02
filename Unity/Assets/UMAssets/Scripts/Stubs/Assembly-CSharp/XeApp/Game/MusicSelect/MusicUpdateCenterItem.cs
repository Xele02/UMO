using System;
using UnityEngine.Events;

namespace XeApp.Game.MusicSelect
{
	[Serializable]
	public class MusicUpdateCenterItem : UnityEvent<int, MusicScrollCenterItem>
	{
	}
}
