using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GakuyaPresentLimit : MonoBehaviour
	{
		[SerializeField]
		private Text m_presetLimitText; // 0xC
		[SerializeField]
		private Text m_prefixText; // 0x10

		// RVA: 0xB73D7C Offset: 0xB73D7C VA: 0xB73D7C
		private void Awake()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_prefixText.text = bk.GetMessageByLabel("pop_gakuya_present_num_prefix");
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				m_prefixText.horizontalOverflow = HorizontalWrapMode.Overflow;
			}
		}

		// RVA: 0xB73E6C Offset: 0xB73E6C VA: 0xB73E6C
		public void SetPresentLimit(int currentCnt)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_presetLimitText.text = string.Format(bk.GetMessageByLabel("pop_gakuya_present_num_title"), currentCnt);
		}
	}
}
