using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneIconScrollContent : SwapScrollListContent
	{
		public enum IconFlagBitIndex
		{
			New = 0,
			Unit = 1,
			Set = 2,
			Episode = 3,
			HomeBg = 4,
		}

		public enum SkillIconType
		{
			None = 0,
			Active = 1,
			Live = 2,
		}

		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private StayButton m_sceneIconButton;
		[SerializeField]
		private RawImageEx[] m_unitSetImages;
		[SerializeField]
		private GameObject m_newParentObject;
		[SerializeField]
		private RawImageEx[] m_skillIconImages;
	}
}
