using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneIconScrollContent : SwapScrollListContent
	{
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
