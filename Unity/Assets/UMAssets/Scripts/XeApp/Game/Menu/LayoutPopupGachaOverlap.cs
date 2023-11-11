using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using XeSys;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupGachaOverlap : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_plateName; // 0x14
		[SerializeField]
		private Text m_desc; // 0x18
		[SerializeField]
		private RawImageEx m_imagePlate; // 0x1C
		private AbsoluteLayout m_logo; // 0x20
		private AbsoluteLayout m_plate; // 0x24
		private AbsoluteLayout m_newGetPlate; // 0x28
		private AbsoluteLayout m_tbl; // 0x2C
		private GONMPHKGKHI_RewardView.CECMLGBLHHG m_showType; // 0x40
		private GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo m_rareUpInfo; // 0x44
		private List<IEnumerator> m_animList = new List<IEnumerator>(4); // 0x48
		private bool m_isLoadingNewImage; // 0x4C
		private bool m_isLoadingNextImage; // 0x4D

		public bool IsSkip { get; private set; } // 0x30
		public Action OnButtonCallbackClose { get; set; } // 0x34
		public Action<bool> OnButtonCallbackHidden { get; set; } // 0x38
		private bool IsPlateAnimEnd { get; set; } // 0x3C

		//// RVA: 0x172ADE4 Offset: 0x172ADE4 VA: 0x172ADE4
		public void SetStatus(GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo info)
		{
			IsPlateAnimEnd = false;
			m_showType = info.IPMJIODJGBC;
			m_rareUpInfo = info;
			if (info.BCCHOBPJJKE_SceneId == 0)
			{
				SetPlateName("");
				return;
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_showType == GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4)
			{
				SetDesc(bk.GetMessageByLabel("popup_record_plate_002"));
			}
			else
			{
				SetDesc("");
			}
			SetPlateName(RecordPlateUtility.GetPlateName(info.BCCHOBPJJKE_SceneId, m_showType, m_showType != GONMPHKGKHI_RewardView.CECMLGBLHHG.GBIDBHKEPGL/*1*/ && m_showType != GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3/*3*/));
			SetPlateImage(info.BCCHOBPJJKE_SceneId, info.JKGFBFPIMGA < info.HNNAODKJGPD ? 1 : 2);
			SwitchTblShowType(m_showType);
		}

		//// RVA: 0x172B3B8 Offset: 0x172B3B8 VA: 0x172B3B8
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || m_isLoadingNewImage || m_isLoadingNextImage;
		}

		//// RVA: 0x172B320 Offset: 0x172B320 VA: 0x172B320
		public void SwitchTblShowType(GONMPHKGKHI_RewardView.CECMLGBLHHG type)
		{
			m_tbl.StartChildrenAnimGoStop(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.GBIDBHKEPGL/*1*/ ? "02" : "01");
		}

		//// RVA: 0x172B024 Offset: 0x172B024 VA: 0x172B024
		public void SetPlateName(string text)
		{
			if(m_plateName != null)
			{
				m_plateName.text = text;
			}
		}

		//// RVA: 0x172B0E4 Offset: 0x172B0E4 VA: 0x172B0E4
		public void SetDesc(string text)
		{
			if(m_desc != null)
			{
				m_desc.text = text;
			}
		}

		//// RVA: 0x172B1A4 Offset: 0x172B1A4 VA: 0x172B1A4
		public void SetPlateImage(int nowId, int nowRank)
		{
			m_isLoadingNewImage = false;
			m_isLoadingNextImage = false;
			if(m_imagePlate != null)
			{
				m_isLoadingNewImage = true;
				GameManager.Instance.SceneIconCache.Load(nowId, nowRank, (IiconTexture texture) =>
				{
					//0x172C408
					if(texture != null)
					{
						texture.Set(m_imagePlate);
					}
					m_isLoadingNewImage = false;
				});
			}
		}

		// RVA: 0x172B474 Offset: 0x172B474 VA: 0x172B474
		public void Update()
		{
			for(int i = 0; i < m_animList.Count; i++)
			{
				if (m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
					{
						m_animList[i] = null;
					}
				}
			}
			CheckSkip();
		}

		// RVA: 0x172B8E4 Offset: 0x172B8E4 VA: 0x172B8E4
		public void Reset()
		{
			IsPlateAnimEnd = false;
			IsSkip = false;
			m_animList.Clear();
			if(m_logo != null)
			{
				m_logo.StartAllAnimGoStop("st_wait");
			}
			if(m_plate != null)
			{
				m_plate.StartAllAnimGoStop("st_wait");
			}
		}

		//// RVA: 0x172B9B0 Offset: 0x172B9B0 VA: 0x172B9B0
		public void Show()
		{
			return;
		}

		//// RVA: 0x172B9B4 Offset: 0x172B9B4 VA: 0x172B9B4
		public void Hide()
		{
			return;
		}

		//// RVA: 0x172B618 Offset: 0x172B618 VA: 0x172B618
		public void CheckSkip()
		{
			if(!IsSkip && (((int)m_showType | 2) == 3))
			{
				if(InputManager.Instance.touchCount > 0)
				{
					if (!InputManager.Instance.GetCurrentTouchInfo(0).isEnded)
						return;
					m_animList.Clear();
					m_logo.StartAllAnimLoop("logo_up", "loen_up");
					m_newGetPlate.StartAllAnimLoop("logo_act", "loen_act");
					IsPlateAnimEnd = true;
					SetPlateName(RecordPlateUtility.GetPlateName(m_rareUpInfo.BCCHOBPJJKE_SceneId, m_showType, (((int)m_showType | 2) == 3)));
					SetDesc();
					SoundManager.Instance.sePlayerMenu.Stop();
					IsSkip = true;
				}
			}
		}

		//// RVA: 0x172BAFC Offset: 0x172BAFC VA: 0x172BAFC
		public void CallbackOpenEnd()
		{
			if(m_showType == GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3)
			{
				AnimPlayPlateRarityUp();
				AnimPlayLogo();
				SetPlateName(RecordPlateUtility.GetPlateName(m_rareUpInfo.BCCHOBPJJKE_SceneId, m_showType, false));
				SetDesc();
			}
			else if(m_showType == GONMPHKGKHI_RewardView.CECMLGBLHHG.GBIDBHKEPGL)
			{
				AnimPlayPlateNewGet(true);
				m_animList.Add(WaitTextShow());
			}
		}

		//// RVA: 0x172BDC4 Offset: 0x172BDC4 VA: 0x172BDC4
		private void AnimPlayLogo()
		{
			if (IsSkip)
				return;
			m_logo.StartAllAnimGoStop("go_in", "st_in");
			m_animList.Add(WaitLogoAnim());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70B9E4 Offset: 0x70B9E4 VA: 0x70B9E4
		//// RVA: 0x172BEDC Offset: 0x172BEDC VA: 0x172BEDC
		private IEnumerator WaitLogoAnim()
		{
			//0x172C4EC
			while (m_logo.IsPlayingChildren())
				yield return null;
			m_logo.StartAllAnimLoop("logo_up", "loen_up");
		}

		//// RVA: 0x172BD38 Offset: 0x172BD38 VA: 0x172BD38
		private void AnimPlayPlateRarityUp()
		{
			m_plate.StartAllAnimLoop("logo_act", "loen_act");
		}

		//// RVA: 0x172BC28 Offset: 0x172BC28 VA: 0x172BC28
		private void AnimPlayPlateNewGet(bool enable = false)
		{
			AnimPlayPlate(m_newGetPlate, WaitPlateGetAnim(), enable);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
		}

		//// RVA: 0x172C014 Offset: 0x172C014 VA: 0x172C014
		private void AnimPlayPlate(AbsoluteLayout laout, IEnumerator anim, bool enable = false)
		{
			if (laout == null)
				return;
			laout.StartAllAnimGoStop("st_wait");
			if(enable)
			{
				laout.StartAllAnimGoStop("go_in", "st_in");
				m_animList.Add(anim);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BA5C Offset: 0x70BA5C VA: 0x70BA5C
		//// RVA: 0x172BF88 Offset: 0x172BF88 VA: 0x172BF88
		private IEnumerator WaitPlateGetAnim()
		{
			//0x172C684
			while (m_newGetPlate.IsPlayingChildren())
				yield return null;
			m_newGetPlate.StartAllAnimLoop("logo_act", "loen_act");
			IsPlateAnimEnd = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BAD4 Offset: 0x70BAD4 VA: 0x70BAD4
		//// RVA: 0x172BCAC Offset: 0x172BCAC VA: 0x172BCAC
		private IEnumerator WaitTextShow()
		{
			//0x172C824
			while (!IsPlateAnimEnd)
				yield return null;
			IsSkip = true;
			SetPlateName(RecordPlateUtility.GetPlateName(m_rareUpInfo.BCCHOBPJJKE_SceneId, m_showType, ((int)m_showType | 2) != 3));
			SetDesc();
		}

		//// RVA: 0x172B9B8 Offset: 0x172B9B8 VA: 0x172B9B8
		private void SetDesc()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_showType == GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3)
			{
				SetDesc(bk.GetMessageByLabel("popup_record_plate_001"));
				return;
			}
			if(m_showType == GONMPHKGKHI_RewardView.CECMLGBLHHG.GBIDBHKEPGL)
			{
				SetDesc(bk.GetMessageByLabel("popup_record_plate_009"));
				if(OnButtonCallbackHidden != null)
				{
					OnButtonCallbackHidden(false);
				}
			}
		}

		// RVA: 0x172C138 Offset: 0x172C138 VA: 0x172C138 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_logo = layout.FindViewByExId("swtbl_gacha_overlap_sw_gacha_overlap_logo_anim") as AbsoluteLayout;
			m_plate = layout.FindViewByExId("swtbl_gacha_overlap_sw_gacha_overlap_plate_s_anim") as AbsoluteLayout;
			m_newGetPlate = layout.FindViewByExId("swtbl_gacha_overlap_sw_gacha_overlap_plate_get_anim") as AbsoluteLayout;
			m_tbl = layout.FindViewByExId("root_gacha_overlap_swtbl_gacha_overlap") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
