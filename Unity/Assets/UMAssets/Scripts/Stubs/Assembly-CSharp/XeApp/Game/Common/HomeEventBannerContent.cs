using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeEventBannerContent : BannerScrollViewContent
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		protected Text m_textCampaignInfo;
		[SerializeField]
		protected Text m_textCampaignCopy;
	}
}
