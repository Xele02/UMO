using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using mcrs;
using XeApp.Game.Common.View;

namespace XeApp.Game.Menu
{
	public class PopupMusicBookMarkContentLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x673F04 Offset: 0x673F04 VA: 0x673F04
		private UGUIToggleButton[] m_bookMarkCheckBox; // 0xC
		//[HeaderAttribute] // RVA: 0x673F68 Offset: 0x673F68 VA: 0x673F68
		[SerializeField]
		private Text[] m_bookMarkName; // 0x10
		//[HeaderAttribute] // RVA: 0x673FC4 Offset: 0x673FC4 VA: 0x673FC4
		[SerializeField]
		private UGUIButton[] m_changeNameButton; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x674028 Offset: 0x674028 VA: 0x674028
		private UGUIButton[] m_bookMarakButton; // 0x18
		//[HeaderAttribute] // RVA: 0x674090 Offset: 0x674090 VA: 0x674090
		public int m_nameMaxLength = 8; // 0x1C
		public PopupMusicBookMarkMusicListSetting m_bookMarkMusicList = new PopupMusicBookMarkMusicListSetting(); // 0x20
		private InputPopupSetting m_inputPopup = new InputPopupSetting(); // 0x24
		private bool[] m_checkIsBookMark = new bool[3]; // 0x28
		private string[] m_checkBookMarkName = new string[3]; // 0x2C

		public IBJAKJJICBC SelectMusicData { get; set; } // 0x30

		// RVA: 0x1690758 Offset: 0x1690758 VA: 0x1690758
		private void Awake()
		{
			for(int i = 0; i < m_bookMarkCheckBox.Length; i++)
			{
				m_bookMarkCheckBox[i].ClearOnClickCallback();
				m_bookMarkCheckBox[i].AddOnClickCallback(() =>
				{
					//0x16919C8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			for(int i = 0; i < m_changeNameButton.Length; i++)
			{
				m_changeNameButton[i].ClearOnClickCallback();
				int index = i;
				m_changeNameButton[i].AddOnClickCallback(() =>
				{
					//0x1691A20
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PopupBookMarkName(index);
				});
			}
			for(int i = 0; i < m_bookMarakButton.Length; i++)
			{
				m_bookMarakButton[i].ClearOnClickCallback();
				int index = i;
				m_bookMarakButton[i].AddOnClickCallback(() =>
				{
					//0x1691AA0
					PopupMusicBookMarkMusicList(index);
				});
			}
		}

		//// RVA: 0x16903A0 Offset: 0x16903A0 VA: 0x16903A0
		public void Initialize(bool init)
		{
			TodoLogger.Log(0, "Initialize");
		}

		//// RVA: 0x1690C38 Offset: 0x1690C38 VA: 0x1690C38
		public void SetMusicBookMark()
		{
			for(int i = 0; i < m_bookMarkCheckBox.Length; i++)
			{
				ViewBookMarkMusicData.OBHMLEOHEFF_SetBookmark(SelectMusicData.DLAEJOBELBH_MusicId, i, m_bookMarkCheckBox[i].IsOn);
			}
			for(int i = 0; i < m_bookMarkName.Length; i++)
			{
				ViewBookMarkMusicData.GLMEPJIKBLP_SetBookmarkName(i, m_bookMarkName[i].text);
			}
		}

		//// RVA: 0x1690D94 Offset: 0x1690D94 VA: 0x1690D94
		public bool IsChangeBookMark()
		{
			for(int i = 0; i < m_checkIsBookMark.Length; i++)
			{
				if (m_checkIsBookMark[i] != m_bookMarkCheckBox[i].IsOn)
					return true;
			}
			for(int i = 0; i < m_checkBookMarkName.Length; i++)
			{
				if (m_bookMarkName[i].text != m_checkBookMarkName[i])
					return true;
			}
			return false;
		}

		//// RVA: 0x1690F5C Offset: 0x1690F5C VA: 0x1690F5C
		private void PopupMusicBookMarkMusicList(int bookMarkIndex)
		{
			TodoLogger.LogNotImplemented("PopupMusicBookMarkMusicList");
		}

		//// RVA: 0x169124C Offset: 0x169124C VA: 0x169124C
		public void PopupBookMarkName(int bookMarkIndex)
		{
			TodoLogger.LogNotImplemented("PopupBookMarkName");
		}
	}
}
