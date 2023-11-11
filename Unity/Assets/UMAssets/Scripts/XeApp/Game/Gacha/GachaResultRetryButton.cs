using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Menu;

namespace XeApp.Game.Gacha
{
	public class GachaResultRetryButton : ActionButton
	{
		[SerializeField]
		private NumberBase m_consumeNumber; // 0x80
		[SerializeField]
		private RawImageEx m_consumeUnitImage; // 0x84
		[SerializeField]
		private RawImageEx m_currencyIconImage; // 0x88
		private TexUVListManager m_uvMan; // 0x8C
		private Rect m_paidUnitUvRect; // 0x90
		private Rect m_ticketUnitUvRect; // 0xA0

		// RVA: 0x98E648 Offset: 0x98E648 VA: 0x98E648
		public void SetConsume(int count)
		{
			m_consumeNumber.SetNumber(count, 0);
		}

		// RVA: 0x98E688 Offset: 0x98E688 VA: 0x98E688
		public void SetCurrencyType(int itemId)
		{
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
			if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
			{
				if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
				{
					if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
					{
						;
					}
					else
					{
						m_consumeUnitImage.uvRect = m_ticketUnitUvRect;
					}
				}
				else
				{
					m_consumeUnitImage.uvRect = m_paidUnitUvRect;
				}
			}
			else
			{
				if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC && cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
				{
					;
				}
				m_consumeUnitImage.uvRect = m_ticketUnitUvRect;
			}
			if(itemId < 1)
				return;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0x98F9C4
				m_currencyIconImage.enabled = true;
				m_currencyIconImage.uvRect = new Rect(0, 0, 1, 1);
				icon.Set(m_currencyIconImage);
			});
        }

		// RVA: 0x98F86C Offset: 0x98F86C VA: 0x98F86C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_paidUnitUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("gatsha_drop_font_01"));
			m_ticketUnitUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("gatsha_drop_font_02"));
			Loaded();
			return true;
		}
	}
}
