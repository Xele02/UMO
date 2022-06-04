namespace XeApp.Game.Common
{
	public class StatusData
	{
		// Fields
		public int life; // 0x8
		public int soul; // 0xC
		public int vocal; // 0x10
		public int charm; // 0x14
		public int sceneBonus; // 0x18
		public int support; // 0x1C
		public int fold; // 0x20
		public int[] spNoteExpected; // 0x24

		// Properties
		public int Total { get; }

		// // Methods

		// // RVA: 0x1CC9DBC Offset: 0x1CC9DBC VA: 0x1CC9DBC
		// public int get_Total() { }

		// // RVA: 0x1CC9DD4 Offset: 0x1CC9DD4 VA: 0x1CC9DD4
		// public void Clear() { }

		// // RVA: 0x1CC9E44 Offset: 0x1CC9E44 VA: 0x1CC9E44
		// public void Copy(StatusData src) { }

		// // RVA: 0x1CC9F98 Offset: 0x1CC9F98 VA: 0x1CC9F98
		// public void Add(StatusData add) { }

		// // RVA: 0x1CCA15C Offset: 0x1CCA15C VA: 0x1CCA15C
		// public void Multi(int multi) { }

		// // RVA: 0x1CCA1F0 Offset: 0x1CCA1F0 VA: 0x1CCA1F0
		// public void Div(int div) { }

		// // RVA: 0x1CCA2D8 Offset: 0x1CCA2D8 VA: 0x1CCA2D8
		// public void .ctor() { }
	}
}
