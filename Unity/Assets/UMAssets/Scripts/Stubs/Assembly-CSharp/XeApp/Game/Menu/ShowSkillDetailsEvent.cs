using System;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	[Serializable]
	public class ShowSkillDetailsEvent : UnityEvent<string, string>
	{
	}
}
