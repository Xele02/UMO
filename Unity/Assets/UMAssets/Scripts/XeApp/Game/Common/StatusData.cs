namespace XeApp.Game.Common
{
	public class StatusData
	{
		public int life; // 0x8
		public int soul; // 0xC
		public int vocal; // 0x10
		public int charm; // 0x14
		public int sceneBonus; // 0x18
		public int support; // 0x1C
		public int fold; // 0x20
		public int[] spNoteExpected = new int[6]; // 0x24

		public int Total { get { return vocal + soul + charm; } } // 0x1CC9DBC

		// // RVA: 0x1CC9DD4 Offset: 0x1CC9DD4 VA: 0x1CC9DD4
		public void Clear()
		{
			charm = 0;
			sceneBonus = 0;
			support = 0;
			fold = 0;
			life = 0;
			soul = 0;
			vocal = 0;
			for(int i = 0; i < 6; i++)
			{
				spNoteExpected[i] = 0;
			}
		}

		// // RVA: 0x1CC9E44 Offset: 0x1CC9E44 VA: 0x1CC9E44
		public void Copy(StatusData src)
		{
			life = src.life;
			soul = src.soul;
			vocal = src.vocal;
			charm = src.charm;
			sceneBonus = src.sceneBonus;
			support = src.support;
			fold = src.fold;
			for(int i = 0; i < 6; i++)
			{
				spNoteExpected[i] = src.spNoteExpected[i];
			}
		}

		// // RVA: 0x1CC9F98 Offset: 0x1CC9F98 VA: 0x1CC9F98
		public void Add(StatusData add)
		{
			life += add.life;
			soul += add.soul;
			vocal += add.vocal;
			charm += add.charm;
			sceneBonus += add.sceneBonus;
			support += add.support;
			fold += add.fold;
			for(int i = 0; i < 6; i++)
			{
				spNoteExpected[i] += add.spNoteExpected[i];
			}
		}

		// // RVA: 0x1CCA15C Offset: 0x1CCA15C VA: 0x1CCA15C
		// public void Multi(int multi) { }

		// // RVA: 0x1CCA1F0 Offset: 0x1CCA1F0 VA: 0x1CCA1F0
		public void Div(int div)
		{
			life /= div;
			soul /= div;
			vocal /= div;
			charm /= div;
			sceneBonus /= div;
			support /= div;
			fold /= div;
			for(int i = 0; i < spNoteExpected.Length; i++)
			{
				spNoteExpected[i] /= div;
			}
		}
	}
}
