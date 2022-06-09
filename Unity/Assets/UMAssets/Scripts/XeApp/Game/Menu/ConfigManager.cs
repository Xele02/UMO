using XeSys;
using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ConfigManager : Singleton<ConfigManager>, IDisposable
	{
		public const float MAX_VOLUME_VALUE = 20;
		public const int RHYTHM_MIN_VALUE = -75;
		public const int RHYTHM_MAX_VALUE = 75;
		public const int DIMMER_MIN_VALUE = 0;
		public const int DIMMER_MAX_VALUE = 10;
		public const int NOTES_SPEED_MIN_VALUE = 10;
		public const int NOTES_SPEED_MAX_VALUE = 100;
		public const float NOTES_SPEED_BASIC = 10;
		// [CompilerGeneratedAttribute] // RVA: 0x67789C Offset: 0x67789C VA: 0x67789C
		// private ILDKBCLAFPB.MPHNGGECENI <Option>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x6778AC Offset: 0x6778AC VA: 0x6778AC
		// private ILDKBCLAFPB.JDBOPCADICO <Notification>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x6778BC Offset: 0x6778BC VA: 0x6778BC
		// private BEJIKEOAJHN <OptionSLive>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x6778CC Offset: 0x6778CC VA: 0x6778CC
		// private static bool <gotoTimingScene>k__BackingField; // 0x0
		// [CompilerGeneratedAttribute] // RVA: 0x6778DC Offset: 0x6778DC VA: 0x6778DC
		// private static Vector2 <scrollPosition>k__BackingField; // 0x4
		// [CompilerGeneratedAttribute] // RVA: 0x6778EC Offset: 0x6778EC VA: 0x6778EC
		// private static int <selectTab>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x6778FC Offset: 0x6778FC VA: 0x6778FC
		// private int <HomeDiva>k__BackingField; // 0x14
		private int m_optionHomeDiva; // 0x18
		private bool m_notesSpeedDiffSelection; // 0x1C
		private int[,] s_QualityValueTbl; // 0x20

		// Properties
		public ILDKBCLAFPB.MPHNGGECENI Option { get; set; }
		public ILDKBCLAFPB.JDBOPCADICO Notification { get; set; }
		public BEJIKEOAJHN OptionSLive { get; set; }
		public static bool gotoTimingScene { get; set; }
		public static Vector2 scrollPosition { get; set; }
		public static int selectTab { get; set; }
		public int HomeDiva { get; set; }

		// Methods

		// [CompilerGeneratedAttribute] // RVA: 0x7009A4 Offset: 0x7009A4 VA: 0x7009A4
		// // RVA: 0x1B57304 Offset: 0x1B57304 VA: 0x1B57304
		// public ILDKBCLAFPB.MPHNGGECENI get_Option() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7009B4 Offset: 0x7009B4 VA: 0x7009B4
		// // RVA: 0x1B5730C Offset: 0x1B5730C VA: 0x1B5730C
		// private void set_Option(ILDKBCLAFPB.MPHNGGECENI value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7009C4 Offset: 0x7009C4 VA: 0x7009C4
		// // RVA: 0x1B57314 Offset: 0x1B57314 VA: 0x1B57314
		// public ILDKBCLAFPB.JDBOPCADICO get_Notification() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7009D4 Offset: 0x7009D4 VA: 0x7009D4
		// // RVA: 0x1B5731C Offset: 0x1B5731C VA: 0x1B5731C
		// private void set_Notification(ILDKBCLAFPB.JDBOPCADICO value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7009E4 Offset: 0x7009E4 VA: 0x7009E4
		// // RVA: 0x1B57324 Offset: 0x1B57324 VA: 0x1B57324
		// public BEJIKEOAJHN get_OptionSLive() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7009F4 Offset: 0x7009F4 VA: 0x7009F4
		// // RVA: 0x1B5732C Offset: 0x1B5732C VA: 0x1B5732C
		// private void set_OptionSLive(BEJIKEOAJHN value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A04 Offset: 0x700A04 VA: 0x700A04
		// // RVA: 0x1B57334 Offset: 0x1B57334 VA: 0x1B57334
		// public static bool get_gotoTimingScene() { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A14 Offset: 0x700A14 VA: 0x700A14
		// // RVA: 0x1B57398 Offset: 0x1B57398 VA: 0x1B57398
		// public static void set_gotoTimingScene(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A24 Offset: 0x700A24 VA: 0x700A24
		// // RVA: 0x1B573FC Offset: 0x1B573FC VA: 0x1B573FC
		// public static Vector2 get_scrollPosition() { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A34 Offset: 0x700A34 VA: 0x700A34
		// // RVA: 0x1B5746C Offset: 0x1B5746C VA: 0x1B5746C
		// public static void set_scrollPosition(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A44 Offset: 0x700A44 VA: 0x700A44
		// // RVA: 0x1B574D8 Offset: 0x1B574D8 VA: 0x1B574D8
		// public static int get_selectTab() { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A54 Offset: 0x700A54 VA: 0x700A54
		// // RVA: 0x1B5753C Offset: 0x1B5753C VA: 0x1B5753C
		// public static void set_selectTab(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A64 Offset: 0x700A64 VA: 0x700A64
		// // RVA: 0x1B575A0 Offset: 0x1B575A0 VA: 0x1B575A0
		// public int get_HomeDiva() { }

		// [CompilerGeneratedAttribute] // RVA: 0x700A74 Offset: 0x700A74 VA: 0x700A74
		// // RVA: 0x1B575A8 Offset: 0x1B575A8 VA: 0x1B575A8
		// private void set_HomeDiva(int value) { }

		// // RVA: 0x1B575B0 Offset: 0x1B575B0 VA: 0x1B575B0
		// public void Initialize() { }

		// // RVA: 0x1B57828 Offset: 0x1B57828 VA: 0x1B57828
		// private void SetHomeDivaValue() { }

		// // RVA: 0x1B5788C Offset: 0x1B5788C VA: 0x1B5788C Slot: 4
		public void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1B57890 Offset: 0x1B57890 VA: 0x1B57890
		// private static void SetScreenOrientation(int type) { }

		// // RVA: 0x1B57958 Offset: 0x1B57958 VA: 0x1B57958
		public static void SetUserData()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1B57C34 Offset: 0x1B57C34 VA: 0x1B57C34
		// public float GetNotesSpeed() { }

		// // RVA: 0x1B57C54 Offset: 0x1B57C54 VA: 0x1B57C54
		// private float GetNotesSpeedInner() { }

		// // RVA: 0x1B57F10 Offset: 0x1B57F10 VA: 0x1B57F10
		// public void SetNotesSpeedValue(float value) { }

		// // RVA: 0x1B57F14 Offset: 0x1B57F14 VA: 0x1B57F14
		// private void SetNotesSpeedInner(float value) { }

		// // RVA: 0x1B57D58 Offset: 0x1B57D58 VA: 0x1B57D58
		// public Difficulty.Type GetNotesSpeedCurrentDiff() { }

		// // RVA: 0x1B57E34 Offset: 0x1B57E34 VA: 0x1B57E34
		// public bool IsNotesSpeedCurrentLine6Mode() { }

		// // RVA: 0x1B58034 Offset: 0x1B58034 VA: 0x1B58034
		// public void SetNotesSpeedDiffSelection(bool canSelect) { }

		// // RVA: 0x1B5803C Offset: 0x1B5803C VA: 0x1B5803C
		// public void NotesSpeedDiffToLeft() { }

		// // RVA: 0x1B58198 Offset: 0x1B58198 VA: 0x1B58198
		// public void NotesSpeedDiffToRight() { }

		// // RVA: 0x1B582F0 Offset: 0x1B582F0 VA: 0x1B582F0
		// private void SetNotesSpeedToAll(float value) { }

		// // RVA: 0x1B583D8 Offset: 0x1B583D8 VA: 0x1B583D8
		// private void SetNotesSpeedToDefault() { }

		// // RVA: 0x1B584C4 Offset: 0x1B584C4 VA: 0x1B584C4
		// public float NotesSpeedPlus1() { }

		// // RVA: 0x1B58594 Offset: 0x1B58594 VA: 0x1B58594
		// public float NotesSpeedMinus1() { }

		// // RVA: 0x1B58668 Offset: 0x1B58668 VA: 0x1B58668
		// public float NotesSpeedPlus() { }

		// // RVA: 0x1B5873C Offset: 0x1B5873C VA: 0x1B5873C
		// public float NotesSpeedMinus() { }

		// // RVA: 0x1B58810 Offset: 0x1B58810 VA: 0x1B58810
		// public bool GetNotesSpeedAllApply() { }

		// // RVA: 0x1B5883C Offset: 0x1B5883C VA: 0x1B5883C
		// public void SetNotesSpeedAllApply(bool allApply) { }

		// // RVA: 0x1B58864 Offset: 0x1B58864 VA: 0x1B58864
		// public bool GetNotesSpeedAutoRejected() { }

		// // RVA: 0x1B58890 Offset: 0x1B58890 VA: 0x1B58890
		// public void SetNotesSpeedAutoRejected(bool reject) { }

		// // RVA: 0x1B588B8 Offset: 0x1B588B8 VA: 0x1B588B8
		// public void SetNotesOffsetValue(float value) { }

		// // RVA: 0x1B588EC Offset: 0x1B588EC VA: 0x1B588EC
		// public int NotesPlus() { }

		// // RVA: 0x1B589C4 Offset: 0x1B589C4 VA: 0x1B589C4
		// public int NotesMinus() { }

		// // RVA: 0x1B58A9C Offset: 0x1B58A9C VA: 0x1B58A9C
		// public void SetDimmer2dValue(float value) { }

		// // RVA: 0x1B58AD0 Offset: 0x1B58AD0 VA: 0x1B58AD0
		// public int Dimmer2dPlus() { }

		// // RVA: 0x1B58BA8 Offset: 0x1B58BA8 VA: 0x1B58BA8
		// public int Dimmer2dMinus() { }

		// // RVA: 0x1B58C80 Offset: 0x1B58C80 VA: 0x1B58C80
		// public void SetDimmer3dValue(float value) { }

		// // RVA: 0x1B58CB4 Offset: 0x1B58CB4 VA: 0x1B58CB4
		// public int Dimmer3dPlus() { }

		// // RVA: 0x1B58D8C Offset: 0x1B58D8C VA: 0x1B58D8C
		// public int Dimmer3dMinus() { }

		// // RVA: 0x1B58E64 Offset: 0x1B58E64 VA: 0x1B58E64
		// public void SetSkillCutinValue(int value) { }

		// // RVA: 0x1B58E8C Offset: 0x1B58E8C VA: 0x1B58E8C
		// public void SetEffectCutinValue(int value, bool simulation = False) { }

		// // RVA: 0x1B58EDC Offset: 0x1B58EDC VA: 0x1B58EDC
		// public void SetNotesRouteValue(int value) { }

		// // RVA: 0x1B58F04 Offset: 0x1B58F04 VA: 0x1B58F04
		// public void SetExcellentValue(int value) { }

		// // RVA: 0x1B58F38 Offset: 0x1B58F38 VA: 0x1B58F38
		// public void SetSlideNoteValue(int value) { }

		// // RVA: 0x1B58F6C Offset: 0x1B58F6C VA: 0x1B58F6C
		// public void SetNotesTypeValue(int value) { }

		// // RVA: 0x1B58FE4 Offset: 0x1B58FE4 VA: 0x1B58FE4
		// public void SetNotesColorValue(int value) { }

		// // RVA: 0x1B59054 Offset: 0x1B59054 VA: 0x1B59054
		// public void SetQualityValue(int value, bool simulation = False) { }

		// // RVA: 0x1B59148 Offset: 0x1B59148 VA: 0x1B59148
		// public int GetQualityValue(bool simulation = False) { }

		// // RVA: 0x1B592C8 Offset: 0x1B592C8 VA: 0x1B592C8
		// public void SetQualityCustomDiva3DValue(int value, bool simulation = False) { }

		// // RVA: 0x1B59318 Offset: 0x1B59318 VA: 0x1B59318
		// public void SetQualityCustomOther3DValue(int value, bool simulation = False) { }

		// // RVA: 0x1B59368 Offset: 0x1B59368 VA: 0x1B59368
		// public void SetQualityCustom2DValue(int value) { }

		// // RVA: 0x1B59390 Offset: 0x1B59390 VA: 0x1B59390
		// public void SetVideoVisibleValue(int value) { }

		// // RVA: 0x1B593B8 Offset: 0x1B593B8 VA: 0x1B593B8
		// public void SetDivaVisibleValue(bool value) { }

		// // RVA: 0x1B593E0 Offset: 0x1B593E0 VA: 0x1B593E0
		// public void SetVideoModeValue(int value) { }

		// // RVA: 0x1B59408 Offset: 0x1B59408 VA: 0x1B59408
		// public void SetBackKeyValue(int value) { }

		// // RVA: 0x1B59430 Offset: 0x1B59430 VA: 0x1B59430
		// public void SetValkyrieModeValue(int value) { }

		// // RVA: 0x1B59458 Offset: 0x1B59458 VA: 0x1B59458
		// public void SetHomeDiva(int value) { }

		// // RVA: 0x1B59460 Offset: 0x1B59460 VA: 0x1B59460
		// public void SetDrawKira(int value) { }

		// // RVA: 0x1B59488 Offset: 0x1B59488 VA: 0x1B59488
		// public void SetPlateAnimationHome(int value) { }

		// // RVA: 0x1B594B0 Offset: 0x1B594B0 VA: 0x1B594B0
		// public void SetPlateAnimationOther(int value) { }

		// // RVA: 0x1B594D8 Offset: 0x1B594D8 VA: 0x1B594D8
		// public void SetDivaEffect(int value) { }

		// // RVA: 0x1B59500 Offset: 0x1B59500 VA: 0x1B59500
		// private float ChangeVolume(SoundManager.CategoryId category, int num, bool simulation = False) { }

		// // RVA: 0x1B59994 Offset: 0x1B59994 VA: 0x1B59994
		// public float VolumePlus(SoundManager.CategoryId category, bool simulation = False) { }

		// // RVA: 0x1B599B4 Offset: 0x1B599B4 VA: 0x1B599B4
		// public float VolumeMinus(SoundManager.CategoryId category, bool simulation = False) { }

		// // RVA: 0x1B597E4 Offset: 0x1B597E4 VA: 0x1B597E4
		// public void SetVolume(SoundManager.CategoryId category, float value, bool simulation = False) { }

		// // RVA: 0x1B599D4 Offset: 0x1B599D4 VA: 0x1B599D4
		// public void SetOrientation(int value) { }

		// // RVA: 0x1B599FC Offset: 0x1B599FC VA: 0x1B599FC
		// private void SetOrientationInner(int type) { }

		// // RVA: 0x1B59AF8 Offset: 0x1B59AF8 VA: 0x1B59AF8
		// public bool IsChangeVideo() { }

		// // RVA: 0x1B59C08 Offset: 0x1B59C08 VA: 0x1B59C08
		// public void UndoVideo() { }

		// // RVA: 0x1B59D0C Offset: 0x1B59D0C VA: 0x1B59D0C
		// public bool IsChangeWideScreen() { }

		// // RVA: 0x1B59E1C Offset: 0x1B59E1C VA: 0x1B59E1C
		// public bool IsChangeNotification() { }

		// // RVA: 0x1B59F2C Offset: 0x1B59F2C VA: 0x1B59F2C
		// public bool IsChangeDecoNotification() { }

		// // RVA: 0x1B5A03C Offset: 0x1B5A03C VA: 0x1B5A03C
		// public bool IsChangeAllNotification() { }

		// // RVA: 0x1B5A120 Offset: 0x1B5A120 VA: 0x1B5A120
		// public void ApplyNotification() { }

		// [IteratorStateMachineAttribute] // RVA: 0x700A84 Offset: 0x700A84 VA: 0x700A84
		// // RVA: 0x1B5A1F0 Offset: 0x1B5A1F0 VA: 0x1B5A1F0
		// private IEnumerator Co_ApplyNotification(bool enable) { }

		// // RVA: 0x1B5A29C Offset: 0x1B5A29C VA: 0x1B5A29C
		// public void ApplyDecoNotification() { }

		// // RVA: 0x1B5A35C Offset: 0x1B5A35C VA: 0x1B5A35C
		// public void ApplyValue(bool isSave = True, Action callback) { }

		// // RVA: 0x1B5D114 Offset: 0x1B5D114 VA: 0x1B5D114
		// public float ParamDefault(ConfigManager.eParamDefaultType type) { }

		// // RVA: 0x1B5D350 Offset: 0x1B5D350 VA: 0x1B5D350
		// public void .ctor() { }
	}
}
