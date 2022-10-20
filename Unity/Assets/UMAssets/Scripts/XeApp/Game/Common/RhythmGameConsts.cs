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
			public void Init(NoteResult a_result)
			{
				m_excellent = false;
				m_result = a_result;
			}

			// // RVA: 0x138B4AC Offset: 0x138B4AC VA: 0x138B4AC
			// public void Copy(RhythmGameConsts.NoteResultEx dest) { }
		}

		public class NoteResultParam_Excellent
		{
			public float m_note_judge_rate; // 0x8
			public float m_score_rate = 1.0f; // 0xC
		}

		public class NoteParam_CenterLiveSkill
		{
			public float m_assign_rate; // 0x8
			public int m_assign_index = -1; // 0xC
		}

		public class NoteParam_EventItem
		{
			public bool m_enable; // 0x8
			public int m_index = -1; // 0xC
		}

		private static int s_lineNum = 4; // 0x0
		public const int LineWideNum = 6;
		public const int LineNumMax = 6;

		public static int LineNum { get { return s_lineNum; } private set { s_lineNum = value; } } //0x138B168 0x138B1F4

		// // RVA: 0x138B284 Offset: 0x138B284 VA: 0x138B284
		public static void SetWide(bool on)
		{
			if(on)
			{
				LineNum = 6;
			}
			else
			{
				LineNum = 4;
			}
		}

		// // RVA: 0x138B334 Offset: 0x138B334 VA: 0x138B334
		public static bool IsWideLine()
		{
			return LineNum > 4;
		}

		// // RVA: 0x138B3BC Offset: 0x138B3BC VA: 0x138B3BC
		public static bool IsWideLine(int lineNo)
		{
			return lineNo > 4;
		}

		// // RVA: 0x138B3D0 Offset: 0x138B3D0 VA: 0x138B3D0
		public static bool IsWingLine(int lineNo)
		{
			return lineNo > 5;
		}

		// // RVA: 0x138B3E4 Offset: 0x138B3E4 VA: 0x138B3E4
		public static bool IsLeftLine(int lineNo)
		{
			if (lineNo < 4)
				return !(lineNo > 1);
			return !((lineNo & 1) != 0);
		}

	}
}
