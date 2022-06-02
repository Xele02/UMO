using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class ActiveSkillCutin : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer m_renderer;
		[SerializeField]
		private Animator m_animator;
		[SerializeField]
		private GameObject m_textParentObject;
		[SerializeField]
		private Renderer m_skillDescriptionRenderer;
		[SerializeField]
		private TextMesh m_skillNameText;
	}
}
