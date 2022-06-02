using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckHeadButtons : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_autoSettingButton;
		[SerializeField]
		private UGUIButton m_unitSetButton;
		[SerializeField]
		private UGUIButton m_prismButton;
		[SerializeField]
		private ColorGroup m_prismButtonColor;
		[SerializeField]
		private Image m_prismOnImage;
		[SerializeField]
		private Image m_prismOffImage;
		[SerializeField]
		private Text m_prismOnOffText;
		[SerializeField]
		private List<SpriteAnime> m_prismOnEffectAnimes;
		[SerializeField]
		private Image m_prismLockImage;
		[SerializeField]
		private UGUIButton m_unitButton;
		[SerializeField]
		private UGUIButton m_settingButton;
	}
}
