using CriWare;

namespace XeApp.Game.Common
{
	public class VoicePlayerBase : SoundPlayerBase
	{
		private CriAtomSource atomSource; // 0x1C

		public override CriAtomSource source { get { return atomSource; } set { atomSource = value; } } //0xD33B04 0xD33B0C
	}
}
