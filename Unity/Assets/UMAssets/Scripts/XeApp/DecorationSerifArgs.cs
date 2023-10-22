
namespace XeApp
{
    public class DecorationSerifArgs : DecorationItemArgsBase
    {
        public string m_text; // 0x8
        public DecorationChara m_chara; // 0xC
        public int m_frameId; // 0x10
        public int m_fontSize; // 0x14

        // RVA: 0xBB2E24 Offset: 0xBB2E24 VA: 0xBB2E24
        public DecorationSerifArgs(int frameId, string text, int fontSize, DecorationChara chara)
        {
            m_text = text;
            m_chara = chara;
            m_frameId = frameId;
            m_fontSize = fontSize;
        }
    }
}