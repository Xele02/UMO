using XeApp.Game;
using UnityEngine.UI;
using UnityEngine;

public class DebugCheatUI_Raid : DebugCheatUIBase
{
	[SerializeField]
	private Text m_apInfoText;
	[SerializeField]
	private Text m_apResultText;
	[SerializeField]
	private Button m_apAllHealButton;
	[SerializeField]
	private Button m_apHealButton;
	[SerializeField]
	private Button m_apConsumeButton;
	[SerializeField]
	private Button m_apAllConsumeButton;
	[SerializeField]
	private Text m_mcgInfoText;
	[SerializeField]
	private Text m_mcgResultText;
	[SerializeField]
	private Button m_mcgHealButton;
	[SerializeField]
	private Button m_mcgConsumeButton;
	[SerializeField]
	private DebugCheatIntInputField m_mcgValueInput;
	[SerializeField]
	private DebugCheatIntInputField m_bossLvInput;
	[SerializeField]
	private DebugCheatIntInputField m_bossTypeInput;
	[SerializeField]
	private DebugCheatIntInputField m_damageInput;
	[SerializeField]
	private DebugCheatIntInputField m_coopBonusInput;
	[SerializeField]
	private DebugCheatIntInputField m_missionInput;
}
