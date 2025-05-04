
namespace XeApp.Game.Menu
{
    public class EventLobbyArgs : TransitionArgs
    {
        public int playerId; // 0x8
        public bool IsMyLobby; // 0xC
        public EAJCBFGKKFA_FriendInfo friendData; // 0x10
    }
}