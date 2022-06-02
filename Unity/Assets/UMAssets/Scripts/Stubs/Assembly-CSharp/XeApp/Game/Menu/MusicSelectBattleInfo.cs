using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleInfo : LayoutLabelScriptBase
	{
		[SerializeField]
		private MusicSelectPlayButton m_playButton;
		[SerializeField]
		private RawImageEx m_dropItemIcon;
		[SerializeField]
		private Text m_selfPlayerTitle;
		[SerializeField]
		private Text m_rivalPlayerTitle;
		[SerializeField]
		private RawImageEx m_selfDivaIcon;
		[SerializeField]
		private RawImageEx m_rivalDivaIcon;
		[SerializeField]
		private RawImageEx m_selfSceneIcon;
		[SerializeField]
		private RawImageEx m_rivalSceneIcon;
		[SerializeField]
		private RawImageEx m_rivalRankIcon;
		[SerializeField]
		private NumberBase m_rivalScore;
	}
}
