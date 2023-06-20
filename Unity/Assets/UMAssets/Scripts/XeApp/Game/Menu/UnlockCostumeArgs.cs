
namespace XeApp.Game.Menu
{
	public class UnlockCostumeArgs : TransitionArgs
	{
		public int diva_id; // 0x8
		public UnlockCostumeScene.CostumeData after_costume_data; // 0xC
		public UnlockCostumeScene.CostumeData before_costume_data; // 0x10
	}
}
