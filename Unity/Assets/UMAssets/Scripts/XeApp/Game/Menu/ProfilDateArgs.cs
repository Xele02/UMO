
namespace XeApp.Game.Menu
{
    public class ProfilDateArgs : TransitionArgs
    {
        public EAJCBFGKKFA_FriendInfo data = null; // 0x8
        public ProfilMenuLayout.InfoType infoType = ProfilMenuLayout.InfoType.PLAYER; // 0xC
        public bool isFavorite = false; // 0x10
        public ProfilMenuLayout.ButtonType btnType = ProfilMenuLayout.ButtonType.None; // 0x14
        public bool isShowMyProfil = false; // 0x18
    }
}
