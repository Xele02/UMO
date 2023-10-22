
namespace XeApp.Game.Menu
{
    public delegate void LoadedCallback(IiconTexture texture, int id, int subId);

    public interface DecorationSelectItemTextureLoaderBase
    {
        // RVA: -1 Offset: -1 Slot: 0
        void Load(int id, int subId, LoadedCallback LoadedCallback);
    }
}