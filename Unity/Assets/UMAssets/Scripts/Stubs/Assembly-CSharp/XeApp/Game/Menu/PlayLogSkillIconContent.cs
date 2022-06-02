using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PlayLogSkillIconContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx[] m_LiveSkillIconImages;
		[SerializeField]
		private StayForReleaseButton m_stayForReleseButton;
	}
}
