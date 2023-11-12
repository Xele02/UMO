using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using mcrs;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMission : LayoutUGUIScriptBase
	{
		public enum LineType
		{
			Horizontal = 0,
			Vertical = 1,
			Diagonal = 2,
			MAX = 3,
		}

		public enum ClearState
		{
			Non = 0,
			NotClear = 1,
			Cleared = 2,
			firstClear = 3,
			AfterClear = 4,
		}

		private const float HASTEN_TIME = 1;
		public const int WaitFrame = 10;
		[SerializeField]
		private RawImageEx[] CompItemList = new RawImageEx[9]; // 0x14
		[SerializeField]
		private NumberBase[] CompItemCountList = new NumberBase[9]; // 0x18
		[SerializeField]
		private Text[] ContentTextList = new Text[9]; // 0x1C
		[SerializeField]
		private Text[] ContentNumTextList = new Text[9]; // 0x20
		[SerializeField]
		private ActionButton[] ContentButtonList = new ActionButton[9]; // 0x24
		[SerializeField]
		private RawImageEx BingoItemImage; // 0x28
		[SerializeField]
		private RawImageEx BingoCostumeImage; // 0x2C
		[SerializeField]
		private RawImageEx DivaIcon; // 0x30
		[SerializeField]
		private ActionButton CompConfButton; // 0x34
		[SerializeField]
		private Text RibbonText; // 0x38
		[SerializeField]
		private NumberBase BingoCount; // 0x3C
		[SerializeField]
		private NumberBase MaxBingoCount; // 0x40
		private AbsoluteLayout m_root; // 0x44
		private AbsoluteLayout[] clearStateList = new AbsoluteLayout[9]; // 0x48
		private AbsoluteLayout[] clearAnimList = new AbsoluteLayout[9]; // 0x4C
		private AbsoluteLayout[] clearContAnimList = new AbsoluteLayout[9]; // 0x50
		private AbsoluteLayout[] bingoCompAnimList = new AbsoluteLayout[9]; // 0x54
		private AbsoluteLayout BingoLightAnim; // 0x58
		private AbsoluteLayout[] LineAnim = new AbsoluteLayout[3]; // 0x5C
		private AbsoluteLayout AnimLineSelect; // 0x60
		private AbsoluteLayout BingoRewardItemState; // 0x64
		private AbsoluteLayout BingoState; // 0x68
		private AbsoluteLayout[] clearAnimChildList = new AbsoluteLayout[9]; // 0x6C
		private AbsoluteLayout BingoAnim; // 0x70
		private AbsoluteLayout BingoCountAnim; // 0x74
		private AbsoluteLayout BingoCountAnim_EF; // 0x78
		private bool m_IsDivaIconSetting; // 0x7C
		private bool m_IsClearIconAnimation; // 0x7D
		private int ClearAnimIndex = -1; // 0x80
		private List<int> ContClearAnimIndexList = new List<int>(); // 0x84
		private int m_bingoRewardItemId; // 0x88
		private int[] CompItemIdList = new int[9]; // 0x8C

		public bool IsDivaIconSetting { get { return m_IsDivaIconSetting; } private set { m_IsDivaIconSetting = value; } } //0x14C1F78 0x14C1F80
		// public bool IsClearIconAnimation { get; private set; } 0x14C1F88 0x14C1F90

		// RVA: 0x14C1F98 Offset: 0x14C1F98 VA: 0x14C1F98
		private void Start()
		{
			return;
		}

		// RVA: 0x14C1F9C Offset: 0x14C1F9C VA: 0x14C1F9C
		private void Update()
		{
			return;
		}

		// // RVA: 0x14C1FA0 Offset: 0x14C1FA0 VA: 0x14C1FA0
		// private LayoutBingoMission.LineType convertLine(DKFJADMCNPI.PBIBFAHJOKC state) { }

		// RVA: 0x14C1FBC Offset: 0x14C1FBC VA: 0x14C1FBC
		public void MissionSetting(int index, int _itemId, int _itemCount, string _missionText, string _numText)
		{
			CompItemIdList[index] = _itemId;
			CompItemList[index].enabled = false;
			GameManager.Instance.ItemTextureCache.Load(ItemTextureCache.MakeItemIconTexturePath(_itemId, 0), (IiconTexture icon) =>
			{
				//0x14C5190
				if(CompItemIdList[index] != _itemId)
					return;
				CompItemList[index].enabled = true;
				icon.Set(CompItemList[index]);
			});
			CompItemCountList[index].SetNumber(_itemCount, 0);
			SetMissionText(index, _missionText, _numText);
		}

		// RVA: 0x14C23B4 Offset: 0x14C23B4 VA: 0x14C23B4
		public void SetDivaIcon(int divaId, int modelId)
		{
			m_IsDivaIconSetting = true;
			GameManager.Instance.DivaIconCache.LoadStandingCostumeIcon(divaId, modelId, (IiconTexture icon) =>
			{
				//0x14C50A8
				icon.Set(DivaIcon);
				m_IsDivaIconSetting = false;
			});
		}

		// RVA: 0x14C24E0 Offset: 0x14C24E0 VA: 0x14C24E0
		public void SetRewardItemIcon(int _itemId, int _rank, Action act)
		{
			m_bingoRewardItemId =_itemId;
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_itemId);
			if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				BingoRewardItemState.StartChildrenAnimGoStop("02");
				BingoItemImage.enabled = false;
				GameManager.Instance.ItemTextureCache.Load(ItemTextureCache.MakeItemIconTexturePath(_itemId, 0), (IiconTexture icon) =>
				{
					//0x14C54F0
					if(m_bingoRewardItemId != _itemId)
						return;
					BingoItemImage.enabled = true;
					icon.Set(BingoItemImage);
					if(act != null)
						act();
				});
			}
			else
			{
				BingoRewardItemState.StartChildrenAnimGoStop("01");
				BingoCostumeImage.enabled = false;
				GameManager.Instance.SceneIconCache.Load(EKLNMHFCAOI.DEACAHNLMNI_getItemId(_itemId), _rank, (IiconTexture scnen) =>
				{
					//0x14C5388
					if(m_bingoRewardItemId !=_itemId)
						return;
					BingoCostumeImage.enabled = true;
					scnen.Set(BingoCostumeImage);
					if(act != null)
						act();
				});
			}
        }

		// RVA: 0x14C28C4 Offset: 0x14C28C4 VA: 0x14C28C4
		public void SetContentButtonCallback(Action<int> callback)
		{
			for(int i = 0; i < 9; i++)
			{
				int index = i;
				ContentButtonList[i].ClearOnClickCallback();
				ContentButtonList[i].AddOnClickCallback(() =>
				{
					//0x14C5658
					callback(index);
				});
			}
		}

		// RVA: 0x14C2AB0 Offset: 0x14C2AB0 VA: 0x14C2AB0
		public void SetCompButtonCallback(Action callback)
		{
			CompConfButton.ClearOnClickCallback();
			CompConfButton.AddOnClickCallback(() =>
			{
				//0x14C56EC
				callback();
			});
		}

		// // RVA: 0x14C22D8 Offset: 0x14C22D8 VA: 0x14C22D8
		public void SetMissionText(int index, string text, string NumText)
		{
			ContentTextList[index].text = text;
			ContentNumTextList[index].text = NumText;
		}

		// RVA: 0x14C2BB8 Offset: 0x14C2BB8 VA: 0x14C2BB8
		public void SetBingoCountText(int currnt, int max)
		{
			BingoCount.SetNumber(currnt, 0);
			MaxBingoCount.SetNumber(max, 0);
		}

		// RVA: 0x14C2C30 Offset: 0x14C2C30 VA: 0x14C2C30
		public void SetRibonText(string text)
		{
			RibbonText.text = text;
		}

		// RVA: 0x14C2C6C Offset: 0x14C2C6C VA: 0x14C2C6C
		public void Enter()
		{
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x14C2CF8 Offset: 0x14C2CF8 VA: 0x14C2CF8
		public void Leave()
		{
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x14C2D84 Offset: 0x14C2D84 VA: 0x14C2D84
		// public void Show() { }

		// // RVA: 0x14C2E00 Offset: 0x14C2E00 VA: 0x14C2E00
		// public void hide() { }

		// RVA: 0x14C2E7C Offset: 0x14C2E7C VA: 0x14C2E7C
		public bool RootIsPlaying()
		{
			return m_root.IsPlayingChildren();
		}

		// // RVA: 0x14C2EA8 Offset: 0x14C2EA8 VA: 0x14C2EA8
		// public void PanelLightAnimStart() { }

		// // RVA: 0x14C2F24 Offset: 0x14C2F24 VA: 0x14C2F24
		public void ClearIconSeting(int index, LayoutBingoMission.ClearState state)
		{
			clearStateList[index].StartChildrenAnimGoStop(((int)state).ToString("D2"));
		}

		// // RVA: 0x14C2FFC Offset: 0x14C2FFC VA: 0x14C2FFC
		public void ClearIconAnimStart(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
			m_IsClearIconAnimation = true;
			clearAnimList[index].StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(CheckAnimEnd(clearAnimChildList[index], clearAnimChildList[index].FrameAnimation.SearchLabelFrame("st_in") - 1.0f / Time.deltaTime));
			ClearAnimIndex = index;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CAA84 Offset: 0x6CAA84 VA: 0x6CAA84
		// // RVA: 0x14C321C Offset: 0x14C321C VA: 0x14C321C
		private IEnumerator CheckAnimEnd(AbsoluteLayout layout, float wait)
		{
			float time;

			//0x14C571C
			yield return null;
			time = layout.FrameAnimation.FrameCount;
			while(wait > time)
			{
				time = layout.FrameAnimation.FrameCount;
				yield return null;
			}
			m_IsClearIconAnimation = false;
		}

		// RVA: 0x14C3308 Offset: 0x14C3308 VA: 0x14C3308
		public void ClearAnimStart(int[] clearPosList, Action AnimEnd)
		{
			this.StartCoroutineWatched(Co_ClearAnim(clearPosList, AnimEnd));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CAAFC Offset: 0x6CAAFC VA: 0x6CAAFC
		// // RVA: 0x14C332C Offset: 0x14C332C VA: 0x14C332C
		private IEnumerator Co_ClearAnim(int[] clearPosList, Action AnimEnd)
		{
			int i;

			//0x14C58F0
			for(i = 0; i < clearPosList.Length; i++)
			{
				if(clearPosList[i] > 0)
				{
					ClearIconSeting(clearPosList[i], ClearState.AfterClear);
					ClearIconAnimContinuityStart(clearPosList[i]);
					yield return Co.R(Co_ClearIconWait());
				}
				else
				{
					ClearIconSeting(clearPosList[i], ClearState.firstClear);
					ClearIconAnimStart(clearPosList[i]);
					//LAB_014c5a94
					while(m_IsClearIconAnimation)
						yield return null;
				}
			}
			while(ClearAnimIsPlaying())
				yield return null;
			while(ClearContAnimIsPlaying())
				yield return null;
			AnimEnd();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CAB74 Offset: 0x6CAB74 VA: 0x6CAB74
		// // RVA: 0x14C340C Offset: 0x14C340C VA: 0x14C340C
		private IEnumerator Co_ClearIconWait()
		{
			int cnt;

			//0x14C5C48
			yield return null;
			for(cnt = 0; cnt <= 9; cnt++)
				yield return null;
		}

		// RVA: 0x14C34A0 Offset: 0x14C34A0 VA: 0x14C34A0
		public void StopClearIcon()
		{
			for(int i = 0; i < clearContAnimList.Length; i++)
			{
				clearContAnimList[i].StopAllAnim();
			}
			for(int i = 0; i < clearAnimList.Length; i++)
			{
				clearAnimList[i].StopAllAnim();
			}
		}

		// RVA: 0x14C35B0 Offset: 0x14C35B0 VA: 0x14C35B0
		public void BingoCompAnimChange(int[] _list)
		{
			for(int i = 0; i < _list.Length; i++)
			{
				bingoCompAnimList[_list[i] - 1].StartChildrenAnimGoStop("02");
			}
		}

		// RVA: 0x14C36B8 Offset: 0x14C36B8 VA: 0x14C36B8
		public void BingoCompAnimReset()
		{
			for(int i = 0; i < bingoCompAnimList.Length; i++)
			{
				bingoCompAnimList[i].StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x14C3794 Offset: 0x14C3794 VA: 0x14C3794
		public void ClearIconAnimContinuityStart(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
			clearContAnimList[index].StartChildrenAnimGoStop("go_in", "st_in");
			ContClearAnimIndexList.Add(index);
		}

		// // RVA: 0x14C38D4 Offset: 0x14C38D4 VA: 0x14C38D4
		public bool ClearContAnimIsPlaying()
		{
			bool res = false;
			for(int i = 0; i < clearContAnimList.Length; i++)
			{
				res |= clearContAnimList[i].IsPlayingChildren();
			}
			return res;
		}

		// // RVA: 0x14C3970 Offset: 0x14C3970 VA: 0x14C3970
		public bool ClearAnimIsPlaying()
		{
			bool res = false;
			for(int i = 0; i < clearAnimList.Length; i++)
			{
				res |= clearAnimList[i].IsPlayingChildren();
			}
			return res;
		}

		// RVA: 0x14C3A0C Offset: 0x14C3A0C VA: 0x14C3A0C
		public void ClearAnimLoopStart()
		{
			if(ClearAnimIndex > -1)
			{
				clearAnimList[ClearAnimIndex].StartChildrenAnimLoop("logo_act_01");
			}
			for(int i = 0; i < ContClearAnimIndexList.Count; i++)
			{
				clearContAnimList[ContClearAnimIndexList[i]].StartChildrenAnimLoop("logo_act_01");
			}
			ClearAnimIndex = -1;
			ContClearAnimIndexList.Clear();
		}

		// RVA: 0x14C3BDC Offset: 0x14C3BDC VA: 0x14C3BDC
		public void LineAnimationStart(int _state)
		{
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_BINGO_001);
			AnimLineSelect.StartChildrenAnimGoStop((_state + 1).ToString("D2"));
			LineAnim[_state / 3].StartChildrenAnimGoStop("go_in", "st_out");
		}

		// RVA: 0x14C3D60 Offset: 0x14C3D60 VA: 0x14C3D60
		public bool LineAnimIsPlaying(int index)
		{
			return LineAnim[index / 3].IsPlayingChildren();
		}

		// RVA: 0x14C3DD8 Offset: 0x14C3DD8 VA: 0x14C3DD8
		public void BingoAnimationStart(int BingoCount)
		{
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_DECO_000);
			BingoCountAnim.StartChildrenAnimGoStop(BingoCount.ToString("D2"));
			BingoCountAnim_EF.StartChildrenAnimGoStop(BingoCount.ToString("D2"));
			BingoAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x14C3F44 Offset: 0x14C3F44 VA: 0x14C3F44
		public bool BingoAnimIsPlaying()
		{
			return BingoAnim.IsPlayingChildren();
		}

		// RVA: 0x14C3F70 Offset: 0x14C3F70 VA: 0x14C3F70
		public void ResetClearIcon()
		{
			for(int i = 0; i < clearStateList.Length; i++)
			{
				clearStateList[i].StartChildrenAnimGoStop(1.ToString("D2"));
			}
		}

		// RVA: 0x14C4074 Offset: 0x14C4074 VA: 0x14C4074
		public void ChangeBingoState(bool _isReleseEpisode)
		{
			BingoState.StartChildrenAnimGoStop(_isReleseEpisode ? "01" : "02");
		}

		// RVA: 0x14C4108 Offset: 0x14C4108 VA: 0x14C4108 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_bingo_sw_bingo_inout_anim") as AbsoluteLayout;
			BingoLightAnim = layout.FindViewByExId("bingo_frm_a_sw_bingo_bord_light_anim") as AbsoluteLayout;
			AnimLineSelect = layout.FindViewByExId("sw_bingo_board_all_swtbl_bingo_line") as AbsoluteLayout;
			BingoState = layout.FindViewByExId("sw_bingo_inout_anim_swtbl_bingo_frm_b") as AbsoluteLayout;
			for(int i = 0; i < LineAnim.Length; i++)
			{
				LineAnim[i] = layout.FindViewByExId("swtbl_bingo_line_line_0" + (i * 3 + 1)) as AbsoluteLayout;
				LineAnim[i].StartAllAnimGoStop("st_out");
			}
			for(int i = 0; i < 9; i++)
			{
				clearStateList[i] = layout.FindViewByExId("bingo_board_swtbl_bingo_clear_" + (i + 1).ToString("D2")) as AbsoluteLayout;
				clearAnimList[i] = clearStateList[i].FindViewById("sw_bingo_clear_1st_anim") as AbsoluteLayout;
				clearContAnimList[i] = clearStateList[i].FindViewById("sw_bingo_clear_2nd_anim") as AbsoluteLayout;
				clearAnimChildList[i] = clearStateList[i].FindViewByExId("sw_bingo_clear_1st_anim_kuro1") as AbsoluteLayout;
			}
			for(int i = 0; i < 9; i++)
			{
				AbsoluteLayout l = layout.FindViewByExId("bingo_board_panel_" + (i + 1).ToString("D2")) as AbsoluteLayout;
				bingoCompAnimList[i] = l.FindViewByExId("bingo_panel_swtbl_bingo_panel_base") as AbsoluteLayout;
			}
			BingoAnim = layout.FindViewByExId("sw_bingo_board_all_sw_bingo_anim") as AbsoluteLayout;
			BingoCountAnim = layout.FindViewByExId("sw_bingo_anim_swtbl_bingo_num") as AbsoluteLayout;
			BingoCountAnim_EF = layout.FindViewByExId("sw_bingo_anim_swtbl_bingo_num_ef") as AbsoluteLayout;
			BingoRewardItemState = layout.FindViewByExId("swtbl_bingo_frm_b_swtbl_bingo_reward") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
