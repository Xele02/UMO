
namespace XeApp.Game.Menu
{
    public class SceneListArgs : TransitionArgs
    {
        private bool m_isFromBiginner; // 0x8
        private int m_questType; // 0xC
        private int m_missionId; // 0x10

        public bool IsFromBiginner { get { return m_isFromBiginner; } set { m_isFromBiginner = value; } } //0x13786EC 0x13786F4
        public int QuestType { get { return m_questType; } set { m_questType = value; } } //0x13786FC 0x1378704
        public int MissionId { get { return m_missionId; } set { m_missionId = value; } }// 0x137870C 0x1378714
    }
}
