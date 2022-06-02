using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class AgeingRhythmGame : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_uiRoot;
		[SerializeField]
		private GameObject m_settingRoot;
		[SerializeField]
		private Button m_closeButton;
		[SerializeField]
		private Button m_startButton;
		[SerializeField]
		private InputField m_borderFpsInput;
		[SerializeField]
		private InputField m_borderSecInput;
		[SerializeField]
		private Dropdown m_musicSelectDropdown;
		[SerializeField]
		private Dropdown m_diffSelectDropdown;
		[SerializeField]
		private Dropdown m_divaSelectDropdown;
		[SerializeField]
		private Dropdown m_valkyrieSelectDropdown;
		[SerializeField]
		private Dropdown m_noteResultDropdown;
		[SerializeField]
		private Dropdown m_valkyrieDropdown;
		[SerializeField]
		private Dropdown m_divaDropdown;
		[SerializeField]
		private GameObject m_intervalRoot;
		[SerializeField]
		private Button m_breakButton;
		[SerializeField]
		private Button m_continueButton;
		[SerializeField]
		private Text m_continueLabel;
	}
}
