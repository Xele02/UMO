using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicIntroEventListener : MonoBehaviour
	{
		public Action onPlayerCutInStart { private get; set; } // 0xC

		// RVA: 0xAE8ADC Offset: 0xAE8ADC VA: 0xAE8ADC
		public void Ev_PlayerCutInStart()
		{
			if(onPlayerCutInStart != null)
				onPlayerCutInStart();
		}
	}
}
