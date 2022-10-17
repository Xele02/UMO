using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameCheerSoundOrderer
	{
		private class EventBase
		{
			private int m_msec_prev; // 0x8
			private int m_msec_now; // 0xC
			
			//// RVA: 0xDC2B78 Offset: 0xDC2B78 VA: 0xDC2B78
			//public void ResetTime() { }

			//// RVA: 0xDC2B90 Offset: 0xDC2B90 VA: 0xDC2B90
			//public int GetTimeNow() { }

			//// RVA: 0xDC2B98 Offset: 0xDC2B98 VA: 0xDC2B98
			//public int GetTimePrev() { }

			//// RVA: 0xDC2BA0 Offset: 0xDC2BA0 VA: 0xDC2BA0
			//protected bool CheckTime(int a_msec) { }

			//// RVA: 0xDC2BC8 Offset: 0xDC2BC8 VA: 0xDC2BC8
			//protected bool CheckTimeRange(int a_msec_st, int a_msec_ed) { }

			//// RVA: 0xDC23C4 Offset: 0xDC23C4 VA: 0xDC23C4
			//public void Update(int a_msec) { }

			//// RVA: 0xDC2BEC Offset: 0xDC2BEC VA: 0xDC2BEC Slot: 4
			//protected virtual void OnUpdate() { }
		}

		private class EventTrigger : EventBase
		{
			public delegate void delegateOnTrigger(RhythmGameCheerSoundOrderer.EventTrigger a_event);
			public MusicScoreData.InputNoteInfo m_info; // 0x10
			private bool m_on; // 0x14
			private RhythmGameCheerSoundOrderer.EventTrigger.delegateOnTrigger m_delegate; // 0x18

			//// RVA: 0xDC2078 Offset: 0xDC2078 VA: 0xDC2078
			//public void .ctor(MusicScoreData.InputNoteInfo a_info, RhythmGameCheerSoundOrderer.EventTrigger.delegateOnTrigger a_delegate) { }

			//// RVA: 0xDC31E0 Offset: 0xDC31E0 VA: 0xDC31E0 Slot: 4
			//protected override void OnUpdate() { }
		}

		private class EventLoop : EventBase // TypeDefIndex: 18139
		{
			public delegate void DelegateOnActive(bool a_enable, RhythmGameCheerSoundOrderer.EventLoop a_event);

			public MusicScoreData.InputNoteInfo m_st; // 0x10
			public MusicScoreData.InputNoteInfo m_ed; // 0x14
			private bool m_on; // 0x18
			private RhythmGameCheerSoundOrderer.EventLoop.DelegateOnActive m_delegateOnActive; // 0x1C

			//// RVA: 0xDC2034 Offset: 0xDC2034 VA: 0xDC2034
			//public void .ctor(MusicScoreData.InputNoteInfo a_info1, MusicScoreData.InputNoteInfo a_info2, RhythmGameCheerSoundOrderer.EventLoop.DelegateOnActive a_delegate) { }

			//// RVA: 0xDC2BF8 Offset: 0xDC2BF8 VA: 0xDC2BF8 Slot: 4
			//protected override void OnUpdate() { }
		}

		public class AccessorScoreDataInputNote
		{
			private List<MusicScoreData.InputNoteInfo> m_list; // 0x8

			public int current { get; set; } // 0xC

			//// RVA: 0xDC1CC8 Offset: 0xDC1CC8 VA: 0xDC1CC8
			//public void .ctor(List<MusicScoreData.InputNoteInfo> a_list) { }

			//// RVA: 0xDC20A0 Offset: 0xDC20A0 VA: 0xDC20A0
			//public bool IsEnd() { }

			//// RVA: 0xDC1CF0 Offset: 0xDC1CF0 VA: 0xDC1CF0
			//public MusicScoreData.InputNoteInfo GetAdd() { }

			//// RVA: 0xDC1D98 Offset: 0xDC1D98 VA: 0xDC1D98
			//public MusicScoreData.InputNoteInfo SearchLongEnd(MusicScoreData.InputNoteInfo t_input_st, int t_st) { }
		}


		private MusicScoreData m_socre_data; // 0x8
		private List<RhythmGameCheerSoundOrderer.EventLoop> m_list_loop; // 0xC
		private List<RhythmGameCheerSoundOrderer.EventTrigger> m_list_trigger; // 0x10
		private bool m_init; // 0x14
		private const int TRACK_VOLUME = 3;

		// RVA: 0xDC1888 Offset: 0xDC1888 VA: 0xDC1888
		public void OnDestroy()
		{
			TodoLogger.Log(0, "RhythmGameCheerSoundOrderer OnDestroy");
		}

		//// RVA: 0xDC18EC Offset: 0xDC18EC VA: 0xDC18EC
		public void Initialize(MusicScoreData a_score_data)
		{
			TodoLogger.Log(0, "RhythmGameCheerSoundOrderer Initialize");
		}

		//// RVA: 0xDC212C Offset: 0xDC212C VA: 0xDC212C
		public void Update(int a_note_msec)
		{
			TodoLogger.Log(0, "RhythmGameCheerSoundOrderer Update");
		}

		//// RVA: 0xDC23E0 Offset: 0xDC23E0 VA: 0xDC23E0
		//private void OnTrigger(RhythmGameCheerSoundOrderer.EventTrigger a_event) { }

		//// RVA: 0xDC25D8 Offset: 0xDC25D8 VA: 0xDC25D8
		//private void OnLoop(bool a_enable, RhythmGameCheerSoundOrderer.EventLoop a_event) { }

		//// RVA: 0xDC2804 Offset: 0xDC2804 VA: 0xDC2804
		//public void Pause() { }

		//// RVA: 0xDC2864 Offset: 0xDC2864 VA: 0xDC2864
		public void Resume()
		{
			TodoLogger.Log(0, "RhythmGameCheerSoundOrderer Resume");
		}

		//// RVA: 0xDC188C Offset: 0xDC188C VA: 0xDC188C
		public void Stop()
		{
			TodoLogger.Log(0, "RhythmGameCheerSoundOrderer Stop");
		}

		//// RVA: 0xDC28C4 Offset: 0xDC28C4 VA: 0xDC28C4
		//public void Reset() { }
	}
}
