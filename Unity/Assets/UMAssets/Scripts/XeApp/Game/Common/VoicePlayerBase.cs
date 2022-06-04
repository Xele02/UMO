namespace XeApp.Game.Common
{
	public class VoicePlayerBase : SoundPlayerBase
	{
		// Fields
		private CriAtomSource atomSource; // 0x1C

		// Properties
		public override CriAtomSource source { get; set; }

		// Methods

		// RVA: 0xD33B04 Offset: 0xD33B04 VA: 0xD33B04 Slot: 4
		/*public override CriAtomSource get_source()
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}*/

		// RVA: 0xD33B0C Offset: 0xD33B0C VA: 0xD33B0C Slot: 5
		// public override void set_source(CriAtomSource value) { }

		// RVA: 0xD33B14 Offset: 0xD33B14 VA: 0xD33B14
		// public void .ctor() { }
	}
}
