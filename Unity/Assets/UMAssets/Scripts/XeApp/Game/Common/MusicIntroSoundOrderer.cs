namespace XeApp.Game.Common
{
	public class MusicIntroSoundOrderer : EventSoundOrdererBase
	{

		// RVA: 0xAEB510 Offset: 0xAEB510 VA: 0xAEB510 Slot: 6
		public override void InitializeAtomSource()
		{
			atomSource = SoundManager.Instance.sePlayerGame;
		}
	}
}
