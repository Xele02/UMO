using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class ComboNumber : MonoBehaviour
	{
		[SerializeField]
		private NumericMesh m_comboNumericMesh;
		[SerializeField]
		private NumericMesh m_comboEffNumericMesh;
		[SerializeField]
		private GameObject m_comboRootObject;
		[SerializeField]
		private Animator m_animator;
		[SerializeField]
		private Animator m_effAnimator;
	}
}
