
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Gacha
{
    public enum AuraColorType
    {
        Blue = 0,
        Gold = 1,
    }

    public class CardInfo
    {
        public const int SPANIMID_DEFAULT = -1;
        public const int SPANIMID_STAR_6 = -2;
        private int m_cardId; // 0x8
        private int m_starNum; // 0xC
        private string m_name; // 0x10
        private int m_attrId; // 0x14
        private int m_seriesId; // 0x18
        private bool m_isNew; // 0x1C
        private bool m_hasSpAnim; // 0x1D
        private int m_spAnimId; // 0x20
        private GachaDirectionQuartzTable.PhaseData m_quartzPhaseData; // 0x24
        private bool m_isFeed; // 0x28

        public int cardId { get { return m_cardId; } } //0x9837FC
        public int starNum { get { return m_starNum; } } //0x983804
        public string name { get { return m_name; } } //0x98380C
        public int attrId { get { return m_attrId; } } //0x983814
        public int seriesId { get { return m_seriesId; } } //0x98381C
        public bool isNew { get { return m_isNew; } } //0x983824
        public bool hasSpAnim { get { return m_hasSpAnim; } } //0x98382C
        public int spAnimId { get { return m_spAnimId; } } //0x983834
        // public int quartzPhaseNum { get; } 0x98383C

        // // RVA: 0x983844 Offset: 0x983844 VA: 0x983844
        public GachaDirectionQuartzTable.QuartzType GetQuartzType(int index)
		{
			return m_quartzPhaseData[index];
		}

        // // RVA: 0x983878 Offset: 0x983878 VA: 0x983878
        public GachaDirectionQuartzTable.QuartzType GetLastQuartzType()
		{
			return GetQuartzType(2);
		}

        // RVA: 0x983880 Offset: 0x983880 VA: 0x983880
        public CardInfo(MFDJIFIIPJD item)
        {
            m_cardId = GetCardId(item.JJBGOIMEIPF_ItemFullId);
            m_starNum = GetCardStarNum(item.JJBGOIMEIPF_ItemFullId);
            m_name = GetCardName(item.JJBGOIMEIPF_ItemFullId);
            m_attrId = GetCardAttribute(item.JJBGOIMEIPF_ItemFullId);
            m_seriesId = GetCardSeries(item.JJBGOIMEIPF_ItemFullId);
            m_isNew = item.JPIPENJGGDD_SceneMlt == 0;
            m_isFeed = IsFeed(item.JJBGOIMEIPF_ItemFullId);
            m_spAnimId = -1;
            m_hasSpAnim = m_starNum > 3;
            if(m_hasSpAnim)
            {
                if(m_starNum < 6)
                {
                    if(m_starNum == 5 && !m_isFeed)
                        m_spAnimId = m_cardId;
                }
                else
                    m_spAnimId = -2;
            }
            m_quartzPhaseData = null;
        }

        // RVA: 0x9840FC Offset: 0x9840FC VA: 0x9840FC
        public CardInfo()
        {
            m_cardId = UnityEngine.Random.Range(1, 31);
            m_starNum = UnityEngine.Random.Range(1, 6);
            m_name = MessageManager.Instance.GetMessage("master", string.Format("sn_{0:D4}", m_cardId));
            m_attrId =UnityEngine.Random.Range(1, GameAttribute.ArrayNum + 1);
            m_seriesId = UnityEngine.Random.Range(1, 6);
            m_isNew = RandomUtil.RandomBool();
            m_isFeed = IsFeed(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, m_cardId));
            m_spAnimId = -1;
            m_hasSpAnim = m_starNum > 3;
            if(m_hasSpAnim)
            {
                if(m_starNum < 6)
                {
                    if(m_starNum == 5 && !m_isFeed)
                        m_spAnimId = m_cardId;
                }
                else
                    m_spAnimId = -2;
            }
            m_quartzPhaseData = null;
        }

        // // RVA: 0x9842F0 Offset: 0x9842F0 VA: 0x9842F0
        public void SetupQuartzPhaseData(GachaDirectionQuartzTable.PhaseData phaseData)
        {
            m_quartzPhaseData = phaseData;
        }

        // // RVA: 0x9840A8 Offset: 0x9840A8 VA: 0x9840A8
        // private void SetupSpAnim() { }

        // // RVA: 0x9839E0 Offset: 0x9839E0 VA: 0x9839E0
        private int GetCardId(int app_item_id)
        {
            return EKLNMHFCAOI.DEACAHNLMNI_getItemId(app_item_id);
        }

        // // RVA: 0x983A64 Offset: 0x983A64 VA: 0x983A64
        private int GetCardStarNum(int app_item_id)
        {
            return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[EKLNMHFCAOI.DEACAHNLMNI_getItemId(app_item_id)].EKLIPGELKCL_Rarity;
        }

        // // RVA: 0x983C58 Offset: 0x983C58 VA: 0x983C58
        private int GetCardAttribute(int app_item_id)
        {
            return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[EKLNMHFCAOI.DEACAHNLMNI_getItemId(app_item_id)].FKDCCLPGKDK_Ma;
        }

        // // RVA: 0x983DC8 Offset: 0x983DC8 VA: 0x983DC8
        private int GetCardSeries(int app_item_id)
        {
            return (int)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[EKLNMHFCAOI.DEACAHNLMNI_getItemId(app_item_id)].AIHCEGFANAM_Serie;
        }

        // // RVA: 0x983F38 Offset: 0x983F38 VA: 0x983F38
        private bool IsFeed(int app_item_id)
        {
            return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[EKLNMHFCAOI.DEACAHNLMNI_getItemId(app_item_id)].MCCIFLKCNKO_Feed;
        }

        // // RVA: 0x983BD4 Offset: 0x983BD4 VA: 0x983BD4
        private string GetCardName(int app_item_id)
        {
            return EKLNMHFCAOI.INCKKODFJAP_GetItemName(app_item_id);
        }
    }
}
