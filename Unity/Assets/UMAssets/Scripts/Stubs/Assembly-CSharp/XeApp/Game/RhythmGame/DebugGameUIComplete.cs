using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class DebugGameUIComplete : MonoBehaviour
	{
		[SerializeField]
		private GameUIComplete m_game_ui;
		[SerializeField]
		private RhythmGameConsts.ResultComboType m_rank;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
