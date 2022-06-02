using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicJecketScrollView : MonoBehaviour
	{
		[SerializeField]
		private UGUISwapScrollList m_scrollList;
		[SerializeField]
		private MusicJacketScrollItem m_prefabContentItem;
		[SerializeField]
		private UGUIButton m_buttonClose;
		[SerializeField]
		private InOutAnime m_animeInOut;
	}
}
