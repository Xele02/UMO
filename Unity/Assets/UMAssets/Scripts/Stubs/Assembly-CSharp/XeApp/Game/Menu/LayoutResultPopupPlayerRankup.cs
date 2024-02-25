using System.Collections;
using System.Collections.Generic;
using System.Text;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultPopupPlayerRankup : LayoutUGUIScriptBase
	{
		private AbsoluteLayout layoutRoot; // 0x14
		private AbsoluteLayout layoutRankup; // 0x18
		private AbsoluteLayout layoutEffect; // 0x1C
		private Text textBeforeRank; // 0x20
		private Text textAfterRank; // 0x24
		private Text textBeforeStaminaMax; // 0x28
		private Text textAfterStaminaMax; // 0x2C
		private Text textBeforeFriendMax; // 0x30
		private Text textAfterFriendMax; // 0x34
		private Text textStaminaMessage; // 0x38
		private Text textMissionClear; // 0x3C
		private Text textMissionNextStep; // 0x40
		private Text textMissionMusicName; // 0x44
		private Text textMissionNextDesc; // 0x48
		private RawImageEx[] imageRankup; // 0x4C
		private RawImageEx imageJacket; // 0x50
		private AbsoluteLayout layoutMissionStep; // 0x54
		private Rect m_uvStepup; // 0x58
		private PopupPlayerRankupContent popupPlayerRankupContent; // 0x68

		// RVA: 0x1D0C228 Offset: 0x1D0C228 VA: 0x1D0C228 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_pu_rankup_set") as AbsoluteLayout;
			layoutRankup = layoutRoot.FindViewById("sw_rankup_anim") as AbsoluteLayout;
			layoutEffect = layoutRankup.FindViewById("sw_pu_ef_anim") as AbsoluteLayout;
			List<Text> txts = new List<Text>(transform.GetComponentsInChildren<Text>(true));
			textBeforeRank = txts.Find((Text _) =>
			{
				//0x1D0E078
				return _.name == "rank_bef (TextView)";
			});
			textAfterRank = txts.Find((Text _) =>
			{
				//0x1D0E0F8
				return _.name == "rank_af (TextView)";
			});
			textBeforeStaminaMax = txts.Find((Text _) =>
			{
				//0x1D0E178
				return _.name == "en_bef (TextView)";
			});
			textAfterStaminaMax = txts.Find((Text _) =>
			{
				//0x1D0E1F8
				return _.name == "en_af (TextView)";
			});
			textBeforeFriendMax = txts.Find((Text _) =>
			{
				//0x1D0E278
				return _.name == "fr_bef (TextView)";
			});
			textAfterFriendMax = txts.Find((Text _) =>
			{
				//0x1D0E2F8
				return _.name == "fr_af (TextView)";
			});
			textStaminaMessage = txts.Find((Text _) =>
			{
				//0x1D0E378
				return _.name == "recovery (TextView)";
			});
			textMissionClear = txts.Find((Text _) =>
			{
				//0x1D0E3F8
				return _.name == "clear (TextView)";
			});
			textMissionNextStep = txts.Find((Text _) =>
			{
				//0x1D0E478
				return _.name == "step_num (TextView)";
			});
			textMissionMusicName = txts.Find((Text _) =>
			{
				//0x1D0E4F8
				return _.name == "song_name (TextView)";
			});
			textMissionNextDesc = txts.Find((Text _) =>
			{
				//0x1D0E578
				return _.name == "next (TextView)";
			});
			List<RawImageEx> imgs = new List<RawImageEx>(transform.GetComponentsInChildren<RawImageEx>(true));
			imageRankup = imgs.FindAll((RawImageEx _) =>
			{
				//0x1D0E5F8
				return _.name == "g_r_pu_up_rank (ImageView)" || _.name == "g_r_pu_up_lv_mask (MaskView)";
			}).ToArray();
			imageJacket = imgs.Find((RawImageEx _) =>
			{
				//0x1D0E6B8
				return _.name == "swtexc_cmn_cd (ImageView)";
			});
			m_uvStepup = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("g_r_step_up"));
			layoutMissionStep = layout.FindViewById("swtbl_g_r_step_up") as AbsoluteLayout;
			popupPlayerRankupContent = transform.GetComponent<PopupPlayerRankupContent>();
			Loaded();
			return true;
		}

		// RVA: 0x1D0D3E0 Offset: 0x1D0D3E0 VA: 0x1D0D3E0
		public void Setup(PopupPlayerRankupSetting.SettingParam param)
		{
			if(param.nextStep == 0)
			{
				textBeforeRank.text = param.prevPlayerLevel.ToString();
				textAfterRank.text = param.currentPlayerLevel.ToString();
				textBeforeStaminaMax.text = param.prevStaminaMax.ToString();
				if(param.prevStaminaMax < param.currentStaminaMax)
					textAfterStaminaMax.text = param.currentStaminaMax.ToString();
				else
				{
					textAfterStaminaMax.text = RichTextUtility.MakeColorTagString(param.currentStaminaMax.ToString(), StatusTextColor.NormalColor);
				}
				if(param.prevFriendMax < param.currentFriendMax)
				{
					layoutRoot.StartChildrenAnimGoStop("02");
					textBeforeFriendMax.text = param.prevFriendMax.ToString();
					textAfterFriendMax.text = param.currentFriendMax.ToString();
				}
				else
				{
					layoutRoot.StartChildrenAnimGoStop("01");
				}
				textStaminaMessage.supportRichText = true;
				StringBuilder str = new StringBuilder();
				str.SetFormat(JpStringLiterals.StringLiteral_18067, RichTextUtility.MakeColorTagString(param.currentStamina.ToString(), StatusTextColor.UpColor));
				textStaminaMessage.text = str.ToString();
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				for(int i = 0; i < imageRankup.Length; i++)
				{
					imageRankup[i].uvRect = m_uvStepup;
				}
				if(param.nextStep < 1)
				{
					textMissionClear.text = bk.GetMessageByLabel("popup_mission_stepup_allclear");
					layoutMissionStep.StartChildrenAnimGoStop("02");
				}
				else
				{
					imageJacket.enabled = false;
					GameManager.Instance.MusicJacketTextureCache.Load(param.jacketId, (IiconTexture image) =>
					{
						//0x1D0DECC
						imageJacket.enabled = true;
						image.Set(imageJacket);
					});
					textMissionClear.text = string.Format(bk.GetMessageByLabel("popup_mission_stepup_desc"), param.currentStep, param.nextStep);
					textMissionNextStep.text = param.nextStep.ToString();
					textMissionMusicName.text = param.musicName;
					textMissionNextDesc.text = param.missionDesc;
					layoutMissionStep.StartChildrenAnimGoStop("01");
				}
				layoutRoot.StartChildrenAnimGoStop("03");
			}
		}

		// RVA: 0x1D0DC70 Offset: 0x1D0DC70 VA: 0x1D0DC70
		public void Show()
		{
			gameObject.SetActive(true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			layoutRankup.StartAllAnimGoStop("go_in", "st_in");
			layoutEffect.StartChildrenAnimLoop("logo_", "loen_");
			this.StartCoroutineWatched(Co_PlayingRankupAnim());
		}

		// // RVA: 0x1D0DE5C Offset: 0x1D0DE5C VA: 0x1D0DE5C
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D584 Offset: 0x71D584 VA: 0x71D584
		// // RVA: 0x1D0DDD0 Offset: 0x1D0DDD0 VA: 0x1D0DDD0
		private IEnumerator Co_PlayingRankupAnim()
		{
			//0x1D0E73C
			yield return new WaitWhile(() =>
			{
				//0x1D0DFD0
				return layoutRankup.IsPlayingChildren();
			});
			layoutRankup.StartAllAnimLoop("logo_up", "loen_up");
			yield return null;
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition));
			popupPlayerRankupContent.SetInput(true);
		}

		// // RVA: 0x1D0DEB4 Offset: 0x1D0DEB4 VA: 0x1D0DEB4
		private bool CheckTutorialCondition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition7;
		}
	}
}
