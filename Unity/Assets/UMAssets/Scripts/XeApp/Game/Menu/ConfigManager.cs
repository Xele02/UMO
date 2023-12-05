using XeSys;
using System;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class ConfigManager : Singleton<ConfigManager>, IDisposable
	{
		public enum eRotationType
		{
			AUTO = 0,
			RIGHT_UP = 1,
			LEFT_UP = 2,
		}

		public enum eParamDefaultType
		{
			MenuVolume = 1,
			RhythmVolume = 2,
			SLiveVolume = 3,
			Timing = 4,
			NotesSpeed = 5,
			Dimmer2D = 6,
			Dimmer3D = 7,
		}

		public const float MAX_VOLUME_VALUE = 20;
		public const int RHYTHM_MIN_VALUE = -75;
		public const int RHYTHM_MAX_VALUE = 75;
		public const int DIMMER_MIN_VALUE = 0;
		public const int DIMMER_MAX_VALUE = 10;
		public const int NOTES_SPEED_MIN_VALUE = 10;
		public const int NOTES_SPEED_MAX_VALUE = 100;
		public const float NOTES_SPEED_BASIC = 10;
		private int m_optionHomeDiva; // 0x18
		private bool m_notesSpeedDiffSelection; // 0x1C
		private int[,] s_QualityValueTbl = new int[2,4] {{0, 1, 2, 3}, {0, 1, 3, 0}}; // 0x20

		public ILDKBCLAFPB.MPHNGGECENI_Option Option { get; private set; } // 0x8
		public ILDKBCLAFPB.JDBOPCADICO_Notification Notification { get; private set; } // 0xC
		public BEJIKEOAJHN_OptionSLive OptionSLive { get; private set; } // 0x10
		public static bool gotoTimingScene { get; set; } // 0x0
		public static Vector2 scrollPosition { get; set; } // 0x4
		public static int selectTab { get; set; } // 0xC
		public int HomeDiva { get; private set; } // 0x14

		// // RVA: 0x1B575B0 Offset: 0x1B575B0 VA: 0x1B575B0
		public void Initialize()
		{
			Option = new ILDKBCLAFPB.MPHNGGECENI_Option();
			Notification = new ILDKBCLAFPB.JDBOPCADICO_Notification();
			OptionSLive = new BEJIKEOAJHN_OptionSLive();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.ODDIHGPONFL_Copy(Option);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ODDIHGPONFL_Copy(Notification);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.ODDIHGPONFL_Copy(OptionSLive);
			SetHomeDivaValue();
		}

		// // RVA: 0x1B57828 Offset: 0x1B57828 VA: 0x1B57828
		private void SetHomeDivaValue()
		{
			HomeDiva = Option.BBIOMNCILMC_HomeDivaId > 0 ? 1 : 0;
			m_optionHomeDiva = Option.BBIOMNCILMC_HomeDivaId > 0 ? 1 : 0;
		}

		// // RVA: 0x1B5788C Offset: 0x1B5788C VA: 0x1B5788C Slot: 4
		public void Dispose()
		{
			return;
		}

		// // RVA: 0x1B57890 Offset: 0x1B57890 VA: 0x1B57890
		private static void SetScreenOrientation(int type)
		{
			if(type == 2)
			{
				Screen.autorotateToLandscapeLeft = false;
				Screen.autorotateToLandscapeRight = false;
				Screen.autorotateToPortrait = false;
				Screen.autorotateToPortraitUpsideDown = false;
				Screen.orientation = ScreenOrientation.LandscapeRight;
			}
			else if(type == 1)
			{
				Screen.autorotateToLandscapeLeft = false;
				Screen.autorotateToLandscapeRight = false;
				Screen.autorotateToPortrait = false;
				Screen.autorotateToPortraitUpsideDown = false;
				Screen.orientation = ScreenOrientation.LandscapeLeft;
			}
			else
			{
				Screen.autorotateToLandscapeLeft = true;
				Screen.autorotateToLandscapeRight = true;
				Screen.autorotateToPortrait = false;
				Screen.autorotateToPortraitUpsideDown = false;
				Screen.orientation = ScreenOrientation.AutoRotation;
			}
		}

		// // RVA: 0x1B57958 Offset: 0x1B57958 VA: 0x1B57958
		public static void SetUserData()
		{
			ILDKBCLAFPB.MPHNGGECENI_Option defaultOption = new ILDKBCLAFPB.MPHNGGECENI_Option();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.ODDIHGPONFL_Copy(defaultOption);
			SetScreenOrientation(defaultOption.CJFAJNMADBA_ScreenRotation);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.MENU_BGM, defaultOption.HOMPENLIHCK_VolBgm, false);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.MENU_SE, defaultOption.BGLLCLEDHKK_VolSe, false);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.MENU_VOICE, defaultOption.CNCIMBGLKOB_VolVoice, false);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_BGM, defaultOption.ICGAOAFIHFD_VolBgmRhythm, false);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_SE, defaultOption.LMDACNNJDOE_VolSeRhythm, false);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_NOTES, defaultOption.IBEINHHMHAC_VolNotesRhythm, false);
			SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_VOICE, defaultOption.FCKEDCKCEFC_VolVoiceRhythm, false);
		}

		// // RVA: 0x1B57C34 Offset: 0x1B57C34 VA: 0x1B57C34
		public float GetNotesSpeed()
		{
			return GetNotesSpeedInner() / 10.0f;
		}

		// // RVA: 0x1B57C54 Offset: 0x1B57C54 VA: 0x1B57C54
		private float GetNotesSpeedInner()
		{
			Difficulty.Type diff = GetNotesSpeedCurrentDiff();
			bool line6 = IsNotesSpeedCurrentLine6Mode();
			switch(diff)
			{
				case Difficulty.Type.Easy:
					return Option.DCHMOFLEFMI_NotesSpeedEasy;
				case Difficulty.Type.Normal:
					return Option.MBOEPFLNDOD_NotesSpeedNormal;
				case Difficulty.Type.Hard:
					return line6 ? Option.LIPAPGABJOA_NotesSpeedHardPlus : Option.MGOOLKHAPAF_NotesSpeedHard;
				case Difficulty.Type.VeryHard:
					return line6 ? Option.JDJBFBPBLDC_NotesSpeedVeryHardPlus : Option.AIKDLBAANLG_NotesSpeedVeryHard;
				case Difficulty.Type.Extreme:
					return line6 ? Option.FJKNAHGFAPP_NotesSpeedExtremePlus : Option.KOKDGGOFPPI_NotesSpeedExtreme;
				default:
					return 30;
			}
		}

		// // RVA: 0x1B57F10 Offset: 0x1B57F10 VA: 0x1B57F10
		// public void SetNotesSpeedValue(float value) { }

		// // RVA: 0x1B57F14 Offset: 0x1B57F14 VA: 0x1B57F14
		private void SetNotesSpeedInner(float value)
		{
			switch(GetNotesSpeedCurrentDiff())
			{
				case Difficulty.Type.Easy:
					Option.DCHMOFLEFMI_NotesSpeedEasy = (int)(value);
					break;
				case Difficulty.Type.Normal:
					Option.MBOEPFLNDOD_NotesSpeedNormal = (int)(value);
					break;
				case Difficulty.Type.Hard:
					if(!IsNotesSpeedCurrentLine6Mode())
						Option.MGOOLKHAPAF_NotesSpeedHard = (int)(value);
					else
						Option.LIPAPGABJOA_NotesSpeedHardPlus = (int)(value);
					break;
				case Difficulty.Type.VeryHard:
					if (!IsNotesSpeedCurrentLine6Mode())
						Option.AIKDLBAANLG_NotesSpeedVeryHard = (int)(value);
					else
						Option.JDJBFBPBLDC_NotesSpeedVeryHardPlus = (int)(value);
					break;
				case Difficulty.Type.Extreme:
					if (!IsNotesSpeedCurrentLine6Mode())
						Option.KOKDGGOFPPI_NotesSpeedExtreme = (int)(value);
					else
						Option.FJKNAHGFAPP_NotesSpeedExtremePlus = (int)(value);
					break;
			}
		}

		// // RVA: 0x1B57D58 Offset: 0x1B57D58 VA: 0x1B57D58
		public Difficulty.Type GetNotesSpeedCurrentDiff()
		{
			if(m_notesSpeedDiffSelection)
			{
				return (Difficulty.Type)Option.LHJHOFNIJJF_NotesSpeedSelectDiff;
			}
			return Database.Instance.gameSetup.musicInfo.difficultyType;
		}

		// // RVA: 0x1B57E34 Offset: 0x1B57E34 VA: 0x1B57E34
		public bool IsNotesSpeedCurrentLine6Mode()
		{
			if(m_notesSpeedDiffSelection)
			{
				return Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode;
			}
			return Database.Instance.gameSetup.musicInfo.IsLine6Mode;
		}

		// // RVA: 0x1B58034 Offset: 0x1B58034 VA: 0x1B58034
		public void SetNotesSpeedDiffSelection(bool canSelect)
		{
			m_notesSpeedDiffSelection = canSelect;
		}

		// // RVA: 0x1B5803C Offset: 0x1B5803C VA: 0x1B5803C
		public void NotesSpeedDiffToLeft()
		{
			Option.LHJHOFNIJJF_NotesSpeedSelectDiff--;
			if(IBJAKJJICBC.KGJJCAKCMLO())
			{
				if(!Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode)
				{
					if(Option.LHJHOFNIJJF_NotesSpeedSelectDiff < 0)
					{
						Option.LHJHOFNIJJF_NotesSpeedSelectDiff = 4;
						Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = true;
						return;
					}
				}
				else if(Option.LHJHOFNIJJF_NotesSpeedSelectDiff < 2)
				{
					Option.LHJHOFNIJJF_NotesSpeedSelectDiff = 4;
					Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = false;
					return;
				}
			}
			else
			{
				Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = false;
				if (Option.LHJHOFNIJJF_NotesSpeedSelectDiff > -1)
					return;
				Option.LHJHOFNIJJF_NotesSpeedSelectDiff = 4;
			}
		}

		// // RVA: 0x1B58198 Offset: 0x1B58198 VA: 0x1B58198
		public void NotesSpeedDiffToRight()
		{
			Option.LHJHOFNIJJF_NotesSpeedSelectDiff++;
			if (IBJAKJJICBC.KGJJCAKCMLO())
			{
				if (!Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode)
				{
					if (Option.LHJHOFNIJJF_NotesSpeedSelectDiff > 4)
					{
						Option.LHJHOFNIJJF_NotesSpeedSelectDiff = 2;
						Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = true;
						return;
					}
				}
				else if (Option.LHJHOFNIJJF_NotesSpeedSelectDiff > 4)
				{
					Option.LHJHOFNIJJF_NotesSpeedSelectDiff = 0;
					Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = false;
					return;
				}
			}
			else
			{
				Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = false;
				if (Option.LHJHOFNIJJF_NotesSpeedSelectDiff < 5)
					return;
				Option.LHJHOFNIJJF_NotesSpeedSelectDiff = 0;
			}
		}

		// // RVA: 0x1B582F0 Offset: 0x1B582F0 VA: 0x1B582F0
		// private void SetNotesSpeedToAll(float value) { }

		// // RVA: 0x1B583D8 Offset: 0x1B583D8 VA: 0x1B583D8
		private void SetNotesSpeedToDefault()
		{
			Option.DCHMOFLEFMI_NotesSpeedEasy = 30;
			Option.MBOEPFLNDOD_NotesSpeedNormal = 40;
			Option.MGOOLKHAPAF_NotesSpeedHard = 60;
			Option.AIKDLBAANLG_NotesSpeedVeryHard = 70;
			Option.KOKDGGOFPPI_NotesSpeedExtreme = 80;
			Option.LIPAPGABJOA_NotesSpeedHardPlus = 70;
			Option.JDJBFBPBLDC_NotesSpeedVeryHardPlus = 70;
			Option.FJKNAHGFAPP_NotesSpeedExtremePlus = 80;
		}

		// // RVA: 0x1B584C4 Offset: 0x1B584C4 VA: 0x1B584C4
		public float NotesSpeedPlus1()
		{
			float val = Mathf.Clamp(GetNotesSpeedInner() + 10, 10, 100);
			SetNotesSpeedInner(val);
			return val / 10.0f;
		}

		// // RVA: 0x1B58594 Offset: 0x1B58594 VA: 0x1B58594
		public float NotesSpeedMinus1()
		{
			float val = Mathf.Clamp(GetNotesSpeedInner() - 10, 10, 100);
			SetNotesSpeedInner(val);
			return val / 10.0f;
		}

		// // RVA: 0x1B58668 Offset: 0x1B58668 VA: 0x1B58668
		public float NotesSpeedPlus()
		{
			float val = Mathf.Clamp(GetNotesSpeedInner() + 1, 10, 100);
			SetNotesSpeedInner(val);
			return val / 10.0f;
		}

		// // RVA: 0x1B5873C Offset: 0x1B5873C VA: 0x1B5873C
		public float NotesSpeedMinus()
		{
			float val = Mathf.Clamp(GetNotesSpeedInner() - 1, 10, 100);
			SetNotesSpeedInner(val);
			return val / 10.0f;
		}

		// // RVA: 0x1B58810 Offset: 0x1B58810 VA: 0x1B58810
		public bool GetNotesSpeedAllApply()
		{
			return Option.LBIKGDHCICB_NotesSpeedAllApply == 1;
		}

		// // RVA: 0x1B5883C Offset: 0x1B5883C VA: 0x1B5883C
		public void SetNotesSpeedAllApply(bool allApply)
		{
			Option.LBIKGDHCICB_NotesSpeedAllApply = allApply ? 1 : 0;
		}

		// // RVA: 0x1B58864 Offset: 0x1B58864 VA: 0x1B58864
		public bool GetNotesSpeedAutoRejected()
		{
			return Option.JJDENMHGOIH_NotesSpeedAutoRejected == 1;
		}

		// // RVA: 0x1B58890 Offset: 0x1B58890 VA: 0x1B58890
		public void SetNotesSpeedAutoRejected(bool reject)
		{
			Option.JJDENMHGOIH_NotesSpeedAutoRejected = reject ? 1 : 0;
		}

		// // RVA: 0x1B588B8 Offset: 0x1B588B8 VA: 0x1B588B8
		public void SetNotesOffsetValue(float value)
		{
			Option.OJAJHIMOIEC_NoteOffset = (int)(value);
		}

		// // RVA: 0x1B588EC Offset: 0x1B588EC VA: 0x1B588EC
		public int NotesPlus()
		{
			Option.OJAJHIMOIEC_NoteOffset = Mathf.Clamp(Option.OJAJHIMOIEC_NoteOffset + 1, -75, 75);
			return Option.OJAJHIMOIEC_NoteOffset;
		}

		// // RVA: 0x1B589C4 Offset: 0x1B589C4 VA: 0x1B589C4
		public int NotesMinus()
		{
			Option.OJAJHIMOIEC_NoteOffset = Mathf.Clamp(Option.OJAJHIMOIEC_NoteOffset - 1, -75, 75);
			return Option.OJAJHIMOIEC_NoteOffset;
		}

		// // RVA: 0x1B58A9C Offset: 0x1B58A9C VA: 0x1B58A9C
		public void SetDimmer2dValue(float value)
		{
			Option.FPFAMFOPJDJ_Dimmer2d = (int)(value);
		}

		// // RVA: 0x1B58AD0 Offset: 0x1B58AD0 VA: 0x1B58AD0
		public int Dimmer2dPlus()
		{
			Option.FPFAMFOPJDJ_Dimmer2d = Mathf.Clamp(Option.FPFAMFOPJDJ_Dimmer2d + 1, 0, 10);
			return Option.FPFAMFOPJDJ_Dimmer2d;
		}

		// // RVA: 0x1B58BA8 Offset: 0x1B58BA8 VA: 0x1B58BA8
		public int Dimmer2dMinus()
		{
			Option.FPFAMFOPJDJ_Dimmer2d = Mathf.Clamp(Option.FPFAMFOPJDJ_Dimmer2d - 1, 0, 10);
			return Option.FPFAMFOPJDJ_Dimmer2d;
		}

		// // RVA: 0x1B58C80 Offset: 0x1B58C80 VA: 0x1B58C80
		public void SetDimmer3dValue(float value)
		{
			Option.OLALFDCEHKJ_Dimmer3d = (int)(value);
		}

		// // RVA: 0x1B58CB4 Offset: 0x1B58CB4 VA: 0x1B58CB4
		public int Dimmer3dPlus()
		{
			Option.OLALFDCEHKJ_Dimmer3d = Mathf.Clamp(Option.OLALFDCEHKJ_Dimmer3d + 1, 0, 10);
			return Option.OLALFDCEHKJ_Dimmer3d;
		}

		// // RVA: 0x1B58D8C Offset: 0x1B58D8C VA: 0x1B58D8C
		public int Dimmer3dMinus()
		{
			Option.OLALFDCEHKJ_Dimmer3d = Mathf.Clamp(Option.OLALFDCEHKJ_Dimmer3d - 1, 0, 10);
			return Option.OLALFDCEHKJ_Dimmer3d;
		}

		// // RVA: 0x1B58E64 Offset: 0x1B58E64 VA: 0x1B58E64
		public void SetSkillCutinValue(int value)
		{
			Option.NAGJLEIPAAC_Cutin = value;
		}

		// // RVA: 0x1B58E8C Offset: 0x1B58E8C VA: 0x1B58E8C
		public void SetEffectCutinValue(int value, bool simulation = false)
		{
			if(simulation)
			{
				OptionSLive.DADIPGPHLDD_EffectCutin = value;
			}
			else
			{
				Option.DADIPGPHLDD_EffectCutin = value;
			}
		}

		// // RVA: 0x1B58EDC Offset: 0x1B58EDC VA: 0x1B58EDC
		public void SetNotesRouteValue(int value)
		{
			Option.NFMEIILKACN_NotesRoute = value;
		}

		// // RVA: 0x1B58F04 Offset: 0x1B58F04 VA: 0x1B58F04
		public void SetExcellentValue(int value)
		{
			Option.EDDMJEMOAGM_IsNotExcellentDisplaySetting = value == 0;
		}

		// // RVA: 0x1B58F38 Offset: 0x1B58F38 VA: 0x1B58F38
		public void SetSlideNoteValue(int value)
		{
			Option.MJHEPGIEDDL_IsSlideNoteEffect = value == 0;
		}

		// // RVA: 0x1B58F6C Offset: 0x1B58F6C VA: 0x1B58F6C
		public void SetNotesTypeValue(int value)
		{
			Option.GMHKLEMBLOF(value, Option.KDNKCOAJGCM_NotesType % 2);
		}

		// // RVA: 0x1B58FE4 Offset: 0x1B58FE4 VA: 0x1B58FE4
		public void SetNotesColorValue(int value)
		{
			Option.GMHKLEMBLOF(Option.KDNKCOAJGCM_NotesType / 2, value);
		}

		// // RVA: 0x1B59054 Offset: 0x1B59054 VA: 0x1B59054
		public void SetQualityValue(int value, bool simulation = false)
		{
			if(!simulation)
			{
				Option.DDHCLNFPNGK_RenderQuality = s_QualityValueTbl[0, value];
			}
			else
			{
				OptionSLive.DDHCLNFPNGK_RenderQuality = s_QualityValueTbl[1, value];
			}
		}

		// // RVA: 0x1B59148 Offset: 0x1B59148 VA: 0x1B59148
		public int GetQualityValue(bool simulation = false)
		{
			if(!simulation)
			{
				if (s_QualityValueTbl.GetLength(1) < 1)
					return 0;
				for(int i = 0; i < s_QualityValueTbl.GetLength(1); i++)
				{
					if (Option.DDHCLNFPNGK_RenderQuality == s_QualityValueTbl[0, i])
						return i;
				}
			}
			else
			{
				if (s_QualityValueTbl.GetLength(1) < 1)
					return 0;
				for (int i = 0; i < s_QualityValueTbl.GetLength(1); i++)
				{
					if (OptionSLive.DDHCLNFPNGK_RenderQuality == s_QualityValueTbl[1, i])
						return i;
				}
			}
			return 0;
		}

		// // RVA: 0x1B592C8 Offset: 0x1B592C8 VA: 0x1B592C8
		public void SetQualityCustomDiva3DValue(int value, bool simulation = false)
		{
			if(simulation)
			{
				OptionSLive.HHMCIGLCBNG_QualityCustomDiva3D = value;
			}
			else
			{
				Option.HHMCIGLCBNG_QualityCustomDiva3D = value;
			}
		}

		// // RVA: 0x1B59318 Offset: 0x1B59318 VA: 0x1B59318
		public void SetQualityCustomOther3DValue(int value, bool simulation = false)
		{
			if (simulation)
			{
				OptionSLive.AHLFOHJMGAI_QualityCustomOther3D = value;
			}
			else
			{
				Option.AHLFOHJMGAI_QualityCustomOther3D = value;
			}
		}

		// // RVA: 0x1B59368 Offset: 0x1B59368 VA: 0x1B59368
		public void SetQualityCustom2DValue(int value)
		{
			Option.FPJHOLMLDGC_QualityCustom2D = value;
		}

		// // RVA: 0x1B59390 Offset: 0x1B59390 VA: 0x1B59390
		public void SetVideoVisibleValue(int value)
		{
			Option.PMGMMMGCEEI_Video = value;
		}

		// // RVA: 0x1B593B8 Offset: 0x1B593B8 VA: 0x1B593B8
		public void SetDivaVisibleValue(bool value)
		{
			Option.CJKKALFPMLA_IsNotDivaModeDivaVisible = value;
		}

		// // RVA: 0x1B593E0 Offset: 0x1B593E0 VA: 0x1B593E0
		public void SetVideoModeValue(int value)
		{
			Option.IHEPCAHBECA_VideoMode = value;
		}

		// // RVA: 0x1B59408 Offset: 0x1B59408 VA: 0x1B59408
		public void SetBackKeyValue(int value)
		{
			Option.OAKOJGPBAJF_BackKey = value;
		}

		// // RVA: 0x1B59430 Offset: 0x1B59430 VA: 0x1B59430
		public void SetValkyrieModeValue(int value)
		{
			Option.CDGKHMEOEMP_ValkyrieMode = value;
		}

		// // RVA: 0x1B59458 Offset: 0x1B59458 VA: 0x1B59458
		public void SetHomeDiva(int value)
		{
			HomeDiva = value;
		}

		// // RVA: 0x1B59460 Offset: 0x1B59460 VA: 0x1B59460
		public void SetDrawKira(int value)
		{
			Option.GACNKPOMOFA_IsDrawKira = value;
		}

		// // RVA: 0x1B59488 Offset: 0x1B59488 VA: 0x1B59488
		public void SetPlateAnimationHome(int value)
		{
			Option.LENJLNLNPEO_IsPlateAnimationHome = value;
		}

		// // RVA: 0x1B594B0 Offset: 0x1B594B0 VA: 0x1B594B0
		public void SetPlateAnimationOther(int value)
		{
			Option.DFLJOKOKLIL_IsPlateAnimationOther = value;
		}

		// // RVA: 0x1B594D8 Offset: 0x1B594D8 VA: 0x1B594D8
		public void SetDivaEffect(int value)
		{
			Option.MDMDEAFFIMB_IsDivaEffect = value;
		}

		// // RVA: 0x1B59500 Offset: 0x1B59500 VA: 0x1B59500
		private float ChangeVolume(SoundManager.CategoryId category, int num, bool simulation = false)
		{
			float val = 0;
			switch (category)
			{
				case SoundManager.CategoryId.MENU_SE:
					val = Mathf.Clamp(Option.BGLLCLEDHKK_VolSe + num, 0, 20);
					break;
				case SoundManager.CategoryId.MENU_VOICE:
					val = Mathf.Clamp(Option.CNCIMBGLKOB_VolVoice + num, 0, 20);
					break;
				case SoundManager.CategoryId.MENU_BGM:
					val = Mathf.Clamp(Option.HOMPENLIHCK_VolBgm + num, 0, 20);
					break;
				case SoundManager.CategoryId.GAME_SE:
					if(!simulation)
						val = Mathf.Clamp(Option.LMDACNNJDOE_VolSeRhythm + num, 0, 20);
					else
						val = Mathf.Clamp(OptionSLive.LMDACNNJDOE_VolSeRhythm + num, 0, 20);
					break;
				case SoundManager.CategoryId.GAME_VOICE:
					if (!simulation)
						val = Mathf.Clamp(Option.FCKEDCKCEFC_VolVoiceRhythm + num, 0, 20);
					else
						val = Mathf.Clamp(OptionSLive.FCKEDCKCEFC_VolVoiceRhythm + num, 0, 20);
					break;
				case SoundManager.CategoryId.GAME_BGM:
					if (!simulation)
						val = Mathf.Clamp(Option.ICGAOAFIHFD_VolBgmRhythm + num, 0, 20);
					else
						val = Mathf.Clamp(OptionSLive.ICGAOAFIHFD_VolBgmRhythm + num, 0, 20);
					break;
				case SoundManager.CategoryId.GAME_NOTES:
					if (!simulation)
						val = Mathf.Clamp(Option.IBEINHHMHAC_VolNotesRhythm + num, 0, 20);
					else
						val = Mathf.Clamp(OptionSLive.IBEINHHMHAC_VolNotesRhythm + num, 0, 20);
					break;
				default:
					val = 0;
					break;
			}
			SetVolume(category, val, simulation);
			return val;
		}

		// // RVA: 0x1B59994 Offset: 0x1B59994 VA: 0x1B59994
		public float VolumePlus(SoundManager.CategoryId category, bool simulation = false)
		{
			return ChangeVolume(category, 1, simulation);
		}

		// // RVA: 0x1B599B4 Offset: 0x1B599B4 VA: 0x1B599B4
		public float VolumeMinus(SoundManager.CategoryId category, bool simulation = false)
		{
			return ChangeVolume(category, -1, simulation);
		}

		// // RVA: 0x1B597E4 Offset: 0x1B597E4 VA: 0x1B597E4
		public void SetVolume(SoundManager.CategoryId category, float value, bool simulation = false)
		{
			switch(category)
			{
				case SoundManager.CategoryId.MENU_SE:
					Option.BGLLCLEDHKK_VolSe = (int)(value);
					break;
				case SoundManager.CategoryId.MENU_VOICE:
					Option.CNCIMBGLKOB_VolVoice = (int)(value);
					break;
				case SoundManager.CategoryId.MENU_BGM:
					Option.HOMPENLIHCK_VolBgm = (int)(value);
					break;
				case SoundManager.CategoryId.GAME_SE:
					if(simulation)
						OptionSLive.LMDACNNJDOE_VolSeRhythm = (int)(value);
					else
						Option.LMDACNNJDOE_VolSeRhythm = (int)(value);
					break;
				case SoundManager.CategoryId.GAME_VOICE:
					if (simulation)
						OptionSLive.FCKEDCKCEFC_VolVoiceRhythm = (int)(value);
					else
						Option.FCKEDCKCEFC_VolVoiceRhythm = (int)(value);
					break;
				case SoundManager.CategoryId.GAME_BGM:
					if (simulation)
						OptionSLive.ICGAOAFIHFD_VolBgmRhythm = (int)(value);
					else
						Option.ICGAOAFIHFD_VolBgmRhythm = (int)(value);
					break;
				case SoundManager.CategoryId.GAME_NOTES:
					if (simulation)
						OptionSLive.IBEINHHMHAC_VolNotesRhythm = (int)(value);
					else
						Option.IBEINHHMHAC_VolNotesRhythm = (int)value;
					break;
				default:
					break;
			}
			SoundManager.Instance.SetCategoryVolumeFromMark(category, (int)(value), false);
		}

		// // RVA: 0x1B599D4 Offset: 0x1B599D4 VA: 0x1B599D4
		public void SetOrientation(int value)
		{
			Option.CJFAJNMADBA_ScreenRotation = value;
		}

		// // RVA: 0x1B599FC Offset: 0x1B599FC VA: 0x1B599FC
		private void SetOrientationInner(int type)
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CJFAJNMADBA_ScreenRotation == type)
				return;
			SetScreenOrientation(type);
		}

		// // RVA: 0x1B59AF8 Offset: 0x1B59AF8 VA: 0x1B59AF8
		public bool IsChangeVideo()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.IHEPCAHBECA_VideoMode != Option.IHEPCAHBECA_VideoMode;
		}

		// // RVA: 0x1B59C08 Offset: 0x1B59C08 VA: 0x1B59C08
		public void UndoVideo()
		{
			Option.IHEPCAHBECA_VideoMode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.IHEPCAHBECA_VideoMode;
		}

		// // RVA: 0x1B59D0C Offset: 0x1B59D0C VA: 0x1B59D0C
		// public bool IsChangeWideScreen() { }

		// // RVA: 0x1B59E1C Offset: 0x1B59E1C VA: 0x1B59E1C
		public bool IsChangeNotification()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive != Notification.ILNIHDCCOEO_EventReceive;
		}

		// // RVA: 0x1B59F2C Offset: 0x1B59F2C VA: 0x1B59F2C
		public bool IsChangeDecoNotification()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.PIPOIELPKBP_DecoReceive != Notification.PIPOIELPKBP_DecoReceive;
		}

		// // RVA: 0x1B5A03C Offset: 0x1B5A03C VA: 0x1B5A03C
		public bool IsChangeAllNotification()
		{
			return ILDKBCLAFPB.JDBOPCADICO_Notification.HMMFJOEBEKJ(Notification, GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification);
		}

		// // RVA: 0x1B5A120 Offset: 0x1B5A120 VA: 0x1B5A120
		public void ApplyNotification()
		{
			GameManager.Instance.StartCoroutineWatched(Co_ApplyNotification(Notification.ILNIHDCCOEO_EventReceive == 1));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x700A84 Offset: 0x700A84 VA: 0x700A84
		// // RVA: 0x1B5A1F0 Offset: 0x1B5A1F0 VA: 0x1B5A1F0
		private IEnumerator Co_ApplyNotification(bool enable)
		{
			//0x1B5D598
			if(GameManager.Instance.transmissionIcon != null)
			{
				GameManager.Instance.transmissionIcon.SetActive(true);
			}
			bool finishWait = true;
			if(!enable)
			{
				NMFABEKNBKJ.HHCJCDFCLOB.MDJNLBOLPNJ_BlockFCM(() =>
				{
					//0x1B5D420
					finishWait = false;
				});
			}
			else
			{
				NMFABEKNBKJ.HHCJCDFCLOB.FCDDHHKAGEP_AcceptFCM(() =>
				{
					//0x1B5D414
					finishWait = false;
				});
			}
			while (finishWait)
				yield return null;
			if (GameManager.Instance.transmissionIcon != null)
			{
				GameManager.Instance.transmissionIcon.SetActive(false);
			}
		}

		// // RVA: 0x1B5A29C Offset: 0x1B5A29C VA: 0x1B5A29C
		public void ApplyDecoNotification()
		{
			if (Notification.PIPOIELPKBP_DecoReceive == 1)
				return;
			EOHDAOAJOHH.HHCJCDFCLOB.NINPDKEKNEG();
		}

		// // RVA: 0x1B5A35C Offset: 0x1B5A35C VA: 0x1B5A35C
		public void ApplyValue(bool isSave = true, Action callback = null)
		{
			if(!isSave)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.ODDIHGPONFL_Copy(Option);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ODDIHGPONFL_Copy(Notification);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.ODDIHGPONFL_Copy(OptionSLive);
				SetHomeDivaValue();
			}
			SetVolume(SoundManager.CategoryId.MENU_BGM, Option.HOMPENLIHCK_VolBgm, false);
			SetVolume(SoundManager.CategoryId.GAME_BGM, Option.ICGAOAFIHFD_VolBgmRhythm, false);
			SetVolume(SoundManager.CategoryId.MENU_SE, Option.BGLLCLEDHKK_VolSe, false);
			SetVolume(SoundManager.CategoryId.GAME_SE, Option.LMDACNNJDOE_VolSeRhythm, false);
			SetVolume(SoundManager.CategoryId.GAME_NOTES, Option.IBEINHHMHAC_VolNotesRhythm, false);
			SetVolume(SoundManager.CategoryId.MENU_VOICE, Option.CNCIMBGLKOB_VolVoice, false);
			SetVolume(SoundManager.CategoryId.GAME_VOICE, Option.FCKEDCKCEFC_VolVoiceRhythm, false);

			Option.CJFAJNMADBA_ScreenRotation = Option.CJFAJNMADBA_ScreenRotation;

			GameManager.Instance.SetLongScreenFrameColor(Option.HLABNEIEJPM_SafeAreaDesign);
			if(isSave)
			{
				bool b = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PKEMELMMEKM_IsDivaHighQuality();
				bool b2 = Option.PKEMELMMEKM_IsDivaHighQuality();
				SetOrientationInner(b2 ? 1 : 0);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.HOMPENLIHCK_VolBgm = Option.HOMPENLIHCK_VolBgm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BGLLCLEDHKK_VolSe = Option.BGLLCLEDHKK_VolSe;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CNCIMBGLKOB_VolVoice = Option.CNCIMBGLKOB_VolVoice;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.ICGAOAFIHFD_VolBgmRhythm = Option.ICGAOAFIHFD_VolBgmRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.LMDACNNJDOE_VolSeRhythm = Option.LMDACNNJDOE_VolSeRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FCKEDCKCEFC_VolVoiceRhythm = Option.FCKEDCKCEFC_VolVoiceRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.IBEINHHMHAC_VolNotesRhythm = Option.IBEINHHMHAC_VolNotesRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.ICGAOAFIHFD_VolBgmRhythm = OptionSLive.ICGAOAFIHFD_VolBgmRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.LMDACNNJDOE_VolSeRhythm = OptionSLive.LMDACNNJDOE_VolSeRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.FCKEDCKCEFC_VolVoiceRhythm = OptionSLive.FCKEDCKCEFC_VolVoiceRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.IBEINHHMHAC_VolNotesRhythm = OptionSLive.IBEINHHMHAC_VolNotesRhythm;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CJFAJNMADBA_ScreenRotation = Option.CJFAJNMADBA_ScreenRotation;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.NFMEIILKACN_NotesRoute = Option.NFMEIILKACN_NotesRoute;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.EDDMJEMOAGM_IsNotExcellentDisplaySetting = Option.EDDMJEMOAGM_IsNotExcellentDisplaySetting;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MJHEPGIEDDL_IsSlideNoteEffect = Option.MJHEPGIEDDL_IsSlideNoteEffect;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType = Option.KDNKCOAJGCM_NotesType;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OJAJHIMOIEC_NoteOffset = Option.OJAJHIMOIEC_NoteOffset;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CDGKHMEOEMP_ValkyrieMode = Option.CDGKHMEOEMP_ValkyrieMode;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FPFAMFOPJDJ_Dimmer2d = Option.FPFAMFOPJDJ_Dimmer2d;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OLALFDCEHKJ_Dimmer3d = Option.OLALFDCEHKJ_Dimmer3d;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.NAGJLEIPAAC_Cutin = Option.NAGJLEIPAAC_Cutin;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DADIPGPHLDD_EffectCutin = Option.DADIPGPHLDD_EffectCutin;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.DADIPGPHLDD_EffectCutin = OptionSLive.DADIPGPHLDD_EffectCutin;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality = Option.DDHCLNFPNGK_RenderQuality;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.DDHCLNFPNGK_RenderQuality = OptionSLive.DDHCLNFPNGK_RenderQuality;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video = Option.PMGMMMGCEEI_Video;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CJKKALFPMLA_IsNotDivaModeDivaVisible = Option.CJKKALFPMLA_IsNotDivaModeDivaVisible;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.IHEPCAHBECA_VideoMode = Option.IHEPCAHBECA_VideoMode;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OAKOJGPBAJF_BackKey = Option.OAKOJGPBAJF_BackKey;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MHACPBAPBFE_BgMode = Option.MHACPBAPBFE_BgMode;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GACNKPOMOFA_IsDrawKira = Option.GACNKPOMOFA_IsDrawKira;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.LENJLNLNPEO_IsPlateAnimationHome = Option.LENJLNLNPEO_IsPlateAnimationHome;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DFLJOKOKLIL_IsPlateAnimationOther = Option.DFLJOKOKLIL_IsPlateAnimationOther;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MDMDEAFFIMB_IsDivaEffect = Option.MDMDEAFFIMB_IsDivaEffect;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KPFAFLBICLA_IsNotBattleEventInfo = Option.KPFAFLBICLA_IsNotBattleEventInfo;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.HLABNEIEJPM_SafeAreaDesign = Option.HLABNEIEJPM_SafeAreaDesign;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.HJPDHDHMOPF_IsNotForceWideScreen = Option.HJPDHDHMOPF_IsNotForceWideScreen;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.HHMCIGLCBNG_QualityCustomDiva3D = Option.HHMCIGLCBNG_QualityCustomDiva3D;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AHLFOHJMGAI_QualityCustomOther3D = Option.AHLFOHJMGAI_QualityCustomOther3D;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FPJHOLMLDGC_QualityCustom2D = Option.FPJHOLMLDGC_QualityCustom2D;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.HHMCIGLCBNG_QualityCustomDiva3D = OptionSLive.HHMCIGLCBNG_QualityCustomDiva3D;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.AHLFOHJMGAI_QualityCustomOther3D = OptionSLive.AHLFOHJMGAI_QualityCustomOther3D;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DCHMOFLEFMI_NotesSpeedEasy = Option.DCHMOFLEFMI_NotesSpeedEasy;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MBOEPFLNDOD_NotesSpeedNormal = Option.MBOEPFLNDOD_NotesSpeedNormal;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MGOOLKHAPAF_NotesSpeedHard = Option.MGOOLKHAPAF_NotesSpeedHard;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AIKDLBAANLG_NotesSpeedVeryHard = Option.AIKDLBAANLG_NotesSpeedVeryHard;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KOKDGGOFPPI_NotesSpeedExtreme = Option.KOKDGGOFPPI_NotesSpeedExtreme;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.LIPAPGABJOA_NotesSpeedHardPlus = Option.LIPAPGABJOA_NotesSpeedHardPlus;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.JDJBFBPBLDC_NotesSpeedVeryHardPlus = Option.JDJBFBPBLDC_NotesSpeedVeryHardPlus;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FJKNAHGFAPP_NotesSpeedExtremePlus = Option.FJKNAHGFAPP_NotesSpeedExtremePlus;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.LHJHOFNIJJF_NotesSpeedSelectDiff = Option.LHJHOFNIJJF_NotesSpeedSelectDiff;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = Option.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.LBIKGDHCICB_NotesSpeedAllApply = Option.LBIKGDHCICB_NotesSpeedAllApply;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.JJDENMHGOIH_NotesSpeedAutoRejected = Option.JJDENMHGOIH_NotesSpeedAutoRejected;
				bool b3 = b != b2;
				if(HomeDiva == m_optionHomeDiva)
				{
					if(b3)
					{
						//LAB_01b5cb0c
						if(MenuScene.Instance != null)
						{
							MenuScene.Instance.divaManager.Release(true);
						}
					}
				}
				else
				{
					int dId = m_optionHomeDiva;
					if (dId != 1)
						dId = 0;
					int hid = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
					FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
					if(diva.EGAFMGDFFCH_HomeDivaCostume.DAJGPBLEEOB_PrismCostumeId ==
						diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId)
					{
						if(diva.JFFLFIMIMOI_HomeColorId != diva.JFFLFIMIMOI_HomeColorId)
							b3 = true;
					}
					else
					{
						//LAB_01b5ca08
						b3 = true;
					}
					if (m_optionHomeDiva == 1)
						dId = diva.AHHJLDLAPAN_DivaId;
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId = dId;
					Option.BBIOMNCILMC_HomeDivaId = dId;
					SetHomeDivaValue();
					if ((hid != diva.AHHJLDLAPAN_DivaId && m_optionHomeDiva != 1) || b3)
					{
						if (MenuScene.Instance != null)
						{
							MenuScene.Instance.divaManager.Release(true);
						}
					}
				}
				bool b4 = false;
				if(IsChangeAllNotification())
				{
					Notification.ODDIHGPONFL_Copy(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification);
					b4 = true;
				}
				if(MenuScene.Instance != null)
				{
					if(MenuScene.Instance.divaManager != null)
					{
						MenuScene.Instance.divaManager.SetEnableDivaEffect(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MDMDEAFFIMB_IsDivaEffect == 0, false);
						MenuScene.Instance.divaManager.SetEnableDivaWind(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MDMDEAFFIMB_IsDivaEffect == 0, false);
					}
				}
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				if(b4)
				{
					MenuScene.Instance.InputDisable();
					MenuScene.Save(() =>
					{
						//0x1B5D42C
						if(callback != null)
							callback();
						MenuScene.Instance.InputEnable();
					}, () =>
					{
						//0x1B5D4E0
						if (callback != null)
							callback();
						MenuScene.Instance.InputEnable();
					});
					return;
				}
			}
			//LAB_01b5d088
			if (callback != null)
				callback();
		}

		// // RVA: 0x1B5D114 Offset: 0x1B5D114 VA: 0x1B5D114
		public float ParamDefault(eParamDefaultType type)
		{
			switch(type)
			{
				case eParamDefaultType.MenuVolume:
					Option.HOMPENLIHCK_VolBgm = 15;
					Option.BGLLCLEDHKK_VolSe = 15;
					Option.CNCIMBGLKOB_VolVoice = 15;
					return 15;
				case eParamDefaultType.RhythmVolume:
					Option.ICGAOAFIHFD_VolBgmRhythm = 15;
					Option.LMDACNNJDOE_VolSeRhythm = 15;
					Option.FCKEDCKCEFC_VolVoiceRhythm = 15;
					Option.IBEINHHMHAC_VolNotesRhythm = 11;
					return 15;
				case eParamDefaultType.SLiveVolume:
					OptionSLive.ICGAOAFIHFD_VolBgmRhythm = 15;
					OptionSLive.LMDACNNJDOE_VolSeRhythm = 15;
					OptionSLive.FCKEDCKCEFC_VolVoiceRhythm = 15;
					OptionSLive.IBEINHHMHAC_VolNotesRhythm = 8;
					return 15;
				case eParamDefaultType.Timing:
					Option.OJAJHIMOIEC_NoteOffset = 0;
					return 0;
				case eParamDefaultType.NotesSpeed:
					SetNotesSpeedToDefault();
					Option.LBIKGDHCICB_NotesSpeedAllApply = 0;
					return GetNotesSpeedInner() / 10;
				case eParamDefaultType.Dimmer2D:
					Option.FPFAMFOPJDJ_Dimmer2d = 4;
					return 4;
				case eParamDefaultType.Dimmer3D:
					Option.OLALFDCEHKJ_Dimmer3d = 10;
					return 10;
			}
			return 0;
		}
	}
}
