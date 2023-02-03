
namespace XeApp.Game.Menu
{
    public class HomeBgIconBgTextureCache : IconTextureCache
    {
        public const string TexutreBundleFormat = "mn/hm/bg/bg{0:D4}.xab";

        // RVA: 0x958130 Offset: 0x958130 VA: 0x958130
        public HomeBgIconBgTextureCache() : base(4)
        {
            return;
        }

        // // RVA: 0x95813C Offset: 0x95813C VA: 0x95813C Slot: 5
        public override void Terminated()
		{
			Clear();
		}

        // // RVA: 0x958144 Offset: 0x958144 VA: 0x958144 Slot: 7
        protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
        {
            TodoLogger.Log(0, "CreateIconTexture");
            return null;
        }

        // // RVA: 0x958288 Offset: 0x958288 VA: 0x958288
        // public void Load(int bgId, Action<IiconTexture> callBack) { }
    }
}
