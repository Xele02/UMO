using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidActSelectArgs : TransitionArgs
	{
		public TransitionUniqueId ReturnTransitionUniqueId { get; private set; } // 0x8
		public EventMusicSelectSceneArgs EventMusicSelectSceneArgs { get; private set; } // 0xC

		// RVA: 0x144B2F4 Offset: 0x144B2F4 VA: 0x144B2F4
		public RaidActSelectArgs(TransitionUniqueId _returnTransitionUniqueId, EventMusicSelectSceneArgs _eventMusicSelectSceneArgs)
		{
			ReturnTransitionUniqueId = _returnTransitionUniqueId;
			EventMusicSelectSceneArgs = _eventMusicSelectSceneArgs;
		}
	}

	public class RaidActSelectBossInfoLayout : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_bossNameText;
		[SerializeField]
		private NumberBase m_joinNum;
		[SerializeField]
		private NumberBase m_assistBonusNum;
		[SerializeField]
		private NumberBase m_bossHpNum;
	}
}
