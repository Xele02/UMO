using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeEventBannerContent : BannerScrollViewContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		protected Text m_textCampaignInfo;
		[SerializeField]
		protected Text m_textCampaignCopy;
	}
}
