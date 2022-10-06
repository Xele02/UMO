namespace XeApp.Game.RhythmGame
{
	public class RhythmGameMode
	{
		public enum Type
		{
			None = 0,
			Normal = 1,
			Valkyrie = 2,
			Diva = 3,
			AwakenDiva = 4,
			Num = 5
		}

		public bool isValkyriePlayed; // 0x8
		public bool isDivaPlayed; // 0x9
		public bool isAwakenDivaPlayed; // 0xA
		public bool isAllItemMode; // 0xB
		private Type type_; // 0xC

		public RhythmGameMode.Type type { get { return type_; } set {
				type_ = value;
				if(type_ == Type.AwakenDiva)
				{
					isAwakenDivaPlayed = true;
				}
				else if(type_ == Type.Diva)
				{
					isDivaPlayed = true;
				}
				else if(type_ == Type.Valkyrie)
				{
					isValkyriePlayed = true;
				}
			} } //0x9A91D4 0x9A91DC

		//// RVA: 0x9A9218 Offset: 0x9A9218 VA: 0x9A9218
		public void Reset()
		{
			type_ = Type.Normal;
			isValkyriePlayed = false;
			isDivaPlayed = false;
			isAwakenDivaPlayed = false;
			isAllItemMode = false;
		}

		//// RVA: 0x9A922C Offset: 0x9A922C VA: 0x9A922C
		public bool IsNone()
		{
			return type_ == Type.None;
		}

		//// RVA: 0x9A9240 Offset: 0x9A9240 VA: 0x9A9240
		public bool IsNormal()
		{
			return type_ == Type.Normal;
		}

		//// RVA: 0x9A9250 Offset: 0x9A9250 VA: 0x9A9250
		public bool IsValkyrie()
		{
			return type_ == Type.Valkyrie;
		}

		//// RVA: 0x9A9264 Offset: 0x9A9264 VA: 0x9A9264
		public bool IsDiva()
		{
			return type_ == Type.Diva || type_ == Type.AwakenDiva;
		}
	}
}
