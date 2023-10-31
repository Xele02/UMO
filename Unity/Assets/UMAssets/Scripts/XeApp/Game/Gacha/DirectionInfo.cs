
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Gacha
{
    public class DirectionInfo
    {
        private bool m_isPaid; // 0x8
        private AuraColorType m_auraColor; // 0xC
        // private GachaDirectionOrbTable.ExpectType m_expectLevel; // 0x10
        private int m_divaId; // 0x14
        private List<CardInfo> m_cardInfo; // 0x18

        public bool isPaid { get { return m_isPaid; } } //0x9842F8
        // public AuraColorType auraColor { get; } 0x984300
        // public GachaDirectionOrbTable.ExpectType expectLevel { get; } 0x984308
        public int divaId { get { return m_divaId; } } //0x984310
        public int cardNum { get { return m_cardInfo.Count; } } //0x984318

        // // RVA: 0x984390 Offset: 0x984390 VA: 0x984390
        public CardInfo GetCardInfo(int index)
		{
			return m_cardInfo[index];
		}

        // RVA: 0x984410 Offset: 0x984410 VA: 0x984410
        public DirectionInfo(List<MFDJIFIIPJD> items, bool byPaid, int divaId)
        {
            m_auraColor = 0;
            m_isPaid = byPaid;
            m_divaId = divaId;
            m_cardInfo = new List<CardInfo>(items.Count);
            for(int i = 0; i < items.Count; i++)
            {
                m_cardInfo.Add(new CardInfo(items[i]));
            }
        }

        // RVA: 0x9845A8 Offset: 0x9845A8 VA: 0x9845A8
        public DirectionInfo(int cardCount)
        {
            m_isPaid = RandomUtil.RandomBool();
            m_auraColor = 0;
            m_divaId = 1;
            m_cardInfo = new List<CardInfo>(cardCount);
            for(int i = cardCount - 1; i >= 0; i--)
            {
                m_cardInfo.Add(new CardInfo());
            }
        }

        // // RVA: 0x9846C0 Offset: 0x9846C0 VA: 0x9846C0
        // public void SetupQuartzTable(GachaDirectionQuartzTable table) { }

        // // RVA: 0x984740 Offset: 0x984740 VA: 0x984740
        // public void SetupOrbTable(GachaDirectionOrbTable table) { }

        // // RVA: 0x9847F4 Offset: 0x9847F4 VA: 0x9847F4
        public bool CheckContainsStarNum(int starNum)
        {
            for(int i = 0; i < cardNum; i++)
            {
                if(m_cardInfo[i].starNum >= starNum)
                    return true;
            }
            return false;
        }
    }
}
