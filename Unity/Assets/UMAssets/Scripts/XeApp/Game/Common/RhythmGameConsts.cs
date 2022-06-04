namespace XeApp.Game.Common
{
	public class RhythmGameConsts
	{
		public enum NoteResult
		{
			Miss = 0,
			Bad = 1,
			Good = 2,
			Great = 3,
			Perfect = 4,
			Num = 5,
			None = 6,
			Exempt = 7,
			IncludeSystemValueNum = 8
		}

		public enum ResultComboType
		{
			Complete = 0,
			FullCombo = 1,
			PerfectFullCombo = 2,
			Num = 3,
			Illegal = 4,
		}

		public enum BaseNoteType
		{
			Single = 0,
			Long = 1,
			FlickL = 2,
			FlickU = 3,
			FlickR = 4,
			Slide = 5,
			SlideLink = 6,
			WingOpenNoteR = 7,
			WingOpenNoteL = 8,
			WingCloseNoteR = 9,
			WingCloseNoteL = 10,
			Num = 11
		}

		public enum SpecialNoteType
		{
			None = 0,
			Score = 1,
			Fold = 2,
			Attack = 3,
			Heal = 4,
			NormalItem = 5,
			RareItem = 6,
			CenterLiveSkill = 7,
			EventItem = 8,
			Num = 9
		}

		public enum ItemRarity
		{
			Nomral = 0,
			Rare = 1,
			Num = 2,
		}

		public enum NoteJudgeType
		{
			Normal = 0,
			EndedTouch = 1,
			Num = 2,
		}

		public class NoteResultEx
		{
			public NoteResult m_result; // 0x8
			public bool m_excellent; // 0xC

			// // RVA: 0x138B49C Offset: 0x138B49C VA: 0x138B49C
			// public void Init(RhythmGameConsts.NoteResult a_result) { }

			// // RVA: 0x138B4AC Offset: 0x138B4AC VA: 0x138B4AC
			// public void Copy(RhythmGameConsts.NoteResultEx dest) { }

			// // RVA: 0x138B4F8 Offset: 0x138B4F8 VA: 0x138B4F8
			// public void .ctor() { }
		}

		public class NoteResultParam_Excellent
		{
			public float m_note_judge_rate; // 0x8
			public float m_score_rate; // 0xC

			// RVA: 0x138B500 Offset: 0x138B500 VA: 0x138B500
			// public void .ctor() { }
		}

		public class NoteParam_CenterLiveSkill
		{
			public float m_assign_rate; // 0x8
			public int m_assign_index; // 0xC

			// RVA: 0x138B47C Offset: 0x138B47C VA: 0x138B47C
			//public void .ctor() { }
		}

		public class NoteParam_EventItem
		{
			public bool m_enable; // 0x8
			public int m_index; // 0xC

			// RVA: 0x138B48C Offset: 0x138B48C VA: 0x138B48C
			//public void .ctor() { }
		}



		private static int s_lineNum; // 0x0
		public const int LineWideNum = 6;
		public const int LineNumMax = 6;

		// // Properties
		// public static int LineNum { get; set; }

		// // Methods

		// // RVA: 0x138B168 Offset: 0x138B168 VA: 0x138B168
		// public static int get_LineNum() { }

		// // RVA: 0x138B1F4 Offset: 0x138B1F4 VA: 0x138B1F4
		// private static void set_LineNum(int value) { }

		// // RVA: 0x138B284 Offset: 0x138B284 VA: 0x138B284
		// public static void SetWide(bool on) { }

		// // RVA: 0x138B334 Offset: 0x138B334 VA: 0x138B334
		// public static bool IsWideLine() { }

		// // RVA: 0x138B3BC Offset: 0x138B3BC VA: 0x138B3BC
		// public static bool IsWideLine(int lineNo) { }

		// // RVA: 0x138B3D0 Offset: 0x138B3D0 VA: 0x138B3D0
		// public static bool IsWingLine(int lineNo) { }

		// // RVA: 0x138B3E4 Offset: 0x138B3E4 VA: 0x138B3E4
		// public static bool IsLeftLine(int lineNo) { }

		// // RVA: 0x138B40C Offset: 0x138B40C VA: 0x138B40C
		// public void .ctor() { }

		// // RVA: 0x138B414 Offset: 0x138B414 VA: 0x138B414
		// private static void .cctor() { }

	}
}
