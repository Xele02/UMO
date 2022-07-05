using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectEventItem : MonoBehaviour
	{
		// [HeaderAttribute] // RVA: 0x6748CC Offset: 0x6748CC VA: 0x6748CC
		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x10
		[SerializeField]
		private RawImageEx m_itemIcon; // 0x14
		[SerializeField]
		private TextMeshProUGUI m_itemNumText; // 0x18

		// // RVA: 0xBDDC5C Offset: 0xBDDC5C VA: 0xBDDC5C
		private void Awake()
		{
			return;
		}

		// // RVA: 0xBDDC60 Offset: 0xBDDC60 VA: 0xBDDC60
		// public void SetEnable(bool isEnable) { }

		// // RVA: 0xBDDCAC Offset: 0xBDDCAC VA: 0xBDDCAC
		// public void SetItemNum(int itemNum) { }

		// // RVA: 0xBDDCF8 Offset: 0xBDDCF8 VA: 0xBDDCF8
		// public void SetTicketIcon(int ticketId) { }

		// // RVA: 0xBDDE08 Offset: 0xBDDE08 VA: 0xBDDE08
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBDDE38 Offset: 0xBDDE38 VA: 0xBDDE38
		// public void Leave() { }

		// // RVA: 0xBDDE68 Offset: 0xBDDE68 VA: 0xBDDE68
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6F59FC Offset: 0x6F59FC VA: 0x6F59FC
		// // RVA: 0xBDDE9C Offset: 0xBDDE9C VA: 0xBDDE9C
		// private void <SetTicketIcon>b__7_0(IiconTexture image) { }
	}
}
