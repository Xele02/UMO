
namespace XeApp.Game.Menu
{
    public class PopupGetDecoItemSetting : PopupOverlapListSetting
    {
        public int typeAndId { get; set; } // 0x3C
        public int prevNum { get; set; } // 0x40
        public int nextNum { get; set; } // 0x44
    }
}
