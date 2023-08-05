using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PlayRecord_AnimEventSound : MonoBehaviour
	{
		public enum SE
		{
			se_000 = 0,
			se_001 = 1,
			se_002 = 2,
		}

		//// RVA: 0xDE668C Offset: 0xDE668C VA: 0xDE668C
		public void PlaySE(SE a_id)
		{
			if(a_id == SE.se_002)
			{
				SoundManager.Instance.sePlayerMenu.Play("se_playrecord_002");
			}
			else if(a_id == SE.se_001)
			{
				SoundManager.Instance.sePlayerMenu.Play("se_playrecord_001");
			}
			else if(a_id == SE.se_000)
			{
				SoundManager.Instance.sePlayerMenu.Play("se_playrecord_000");
			}
		}
	}
}
