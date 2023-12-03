using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutValkyrieSelect : LayoutUGUIScriptBase
	{
		public enum Direction
		{
			NONE = -1,
			LEFT = 0,
			RIGHT = 1,
			NUM = 2,
		}
 
		public enum OfferVallyrieSelectButtonState
		{
			ALL = 0,
			SELECTION = 1,
			DETACH = 2,
		}

		private class ValkyrieImageData
		{
			public AbsoluteLayout anim; // 0x8
			public RawImageEx image; // 0xC
			public RawImageEx lock_icon; // 0x10
			public bool is_disp; // 0x14
			public bool is_enable = true; // 0x15
		}

		private AbsoluteLayout m_SetIconAnim; // 0x14
		private AbsoluteLayout m_StateAnim; // 0x18
		private AbsoluteLayout m_NoticeAnim; // 0x1C
		private AbsoluteLayout m_MainValkyrieIcon; // 0x20
		[SerializeField]
		private ActionButton m_ArrowButtonL; // 0x24
		[SerializeField]
		private ActionButton m_ArrowButtonR; // 0x28
		[SerializeField]
		private ActionButton m_SelectButton; // 0x2C
		[SerializeField]
		private ActionButton m_DetachButton; // 0x30
		[SerializeField]
		private Button m_TransformTouchArea; // 0x34
		[SerializeField]
		private RawImageEx m_ArrowImageL; // 0x38
		[SerializeField]
		private RawImageEx m_ArrowImageR; // 0x3C
		[SerializeField]
		private RawImageEx m_PilotImage; // 0x40
		[SerializeField]
		private RawImageEx m_MainValkyrieIconImage; // 0x44
		[SerializeField]
		private RawImageEx[] m_SubValkyrieImageList = new RawImageEx[2]; // 0x48
		[SerializeField]
		private RawImageEx[] m_SubValkyrieLockImageList = new RawImageEx[2]; // 0x4C
		private int m_pilotId; // 0x50
		private int[] m_valkyrieIdList = new int[2]; // 0x54
		private int m_mainValkyrieId; // 0x58
		private ValkyrieImageData[] m_ValkyrieImageData = new ValkyrieImageData[2]; // 0x5C
		[SerializeField]
		private Text m_ValkyrieNameText; // 0x60
		[SerializeField]
		private Text m_PilotNameText; // 0x64
		[SerializeField]
		private Text m_AttackText; // 0x68
		[SerializeField]
		private Text m_HitText; // 0x6C
		[SerializeField]
		private Text m_ChangeAnimNameText; // 0x70
		[SerializeField]
		private Text m_ChangeAnimLevelText; // 0x74
		[SerializeField]
		private Text m_ChangeAnimDescText; // 0x78
		private AbsoluteLayout m_InfoChangeAnim; // 0x7C
		private AbsoluteLayout m_AbilityLayout; // 0x80
		private AbsoluteLayout m_ShowAbilityLayout; // 0x84
		private AbsoluteLayout m_HideAbilityLayout; // 0x88
		private AbsoluteLayout m_SelectButtonLayout; // 0x8C
		private AbsoluteLayout m_SelectBtnCoverLayout; // 0x90
		[SerializeField]
		private Text m_AbilityNameText; // 0x94
		[SerializeField]
		private Text m_AbilityLevelText; // 0x98
		[SerializeField]
		private Text m_AbilityDescriptionText; // 0x9C
		[SerializeField]
		private RawImageEx sel_fnt; // 0xA0
		[SerializeField]
		private RawImageEx m_atkUpArrow; // 0xA4
		[SerializeField]
		private RawImageEx m_hitUpArrow; // 0xA8
		[SerializeField]
		private Text m_NoTextLayout; // 0xAC
		private TexUVList m_valkyrie_pack; // 0xB0

		public bool HasAbility { get { return false; } set { m_HideAbilityLayout.enabled = !value; } } //0x1537050 0x1537058

		// RVA: 0x1537094 Offset: 0x1537094 VA: 0x1537094
		private void Start()
		{
			return;
		}

		// RVA: 0x1537098 Offset: 0x1537098 VA: 0x1537098
		private void Update()
		{
			return;
		}

		// // RVA: 0x153709C Offset: 0x153709C VA: 0x153709C
		public void NoticeAnimEnter()
		{
			m_NoticeAnim.StartChildrenAnimGoStop("go_on", "st_on");
		}

		// // RVA: 0x1537128 Offset: 0x1537128 VA: 0x1537128
		public void NoticeAnimLeave()
		{
			m_NoticeAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x15371B4 Offset: 0x15371B4 VA: 0x15371B4
		public bool NoticeAnimIsPlaying()
		{
			return m_NoticeAnim.IsPlayingChildren();
		}

		// // RVA: 0x15371E0 Offset: 0x15371E0 VA: 0x15371E0
		public void SetButtonCallBack(Action actL, Action actR, Action selection, Action Detach)
		{
			m_ArrowButtonL.AddOnClickCallback(() => {
				//0x1539B10
				actL();
			});
			m_ArrowButtonR.AddOnClickCallback(() => {
				//0x1539B3C
				actR();
			});
			m_SelectButton.AddOnClickCallback(() => {
				//0x1539B68
				selection();
			});
			m_DetachButton.AddOnClickCallback(() => {
				//0x1539B94
				Detach();
			});
		}

		// // RVA: 0x1537424 Offset: 0x1537424 VA: 0x1537424
		public void SetName(string valkyrieName, string pilotName, string AttackText, string HitText)
		{
			m_ValkyrieNameText.text = valkyrieName;
			m_PilotNameText.text = pilotName;
			m_AttackText.text = AttackText;
			m_HitText.text = HitText;
		}

		// // RVA: 0x15374F4 Offset: 0x15374F4 VA: 0x15374F4
		public void SetAbility(string abilityName, string abilityLevel, string description)
		{
			m_AbilityNameText.text = abilityName;
			m_ChangeAnimNameText.text = abilityName;
			m_AbilityLevelText.text = "Lv" + abilityLevel;
			m_ChangeAnimLevelText.text = "Lv" + abilityLevel;
			m_AbilityDescriptionText.text = description;
			m_ChangeAnimDescText.text = description;
		}

		// // RVA: 0x1537674 Offset: 0x1537674 VA: 0x1537674
		public void SetDefaultText(string _NoText)
		{
			m_NoTextLayout.text = _NoText;
		}

		// // RVA: 0x15376B0 Offset: 0x15376B0 VA: 0x15376B0
		public void SetPilotTexture(int pilotId)
		{
			m_PilotImage.enabled = false;
			MenuScene.Instance.InputDisable();
			int m_pilotId = pilotId;
			GameManager.Instance.PilotTextureCache.Load(pilotId, (IiconTexture texture) =>
			{
				//0x1539BC0
				if(m_pilotId == pilotId)
				{
					texture.Set(m_PilotImage);
					m_PilotImage.enabled = true;
				}
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0x15378BC Offset: 0x15378BC VA: 0x15378BC
		public void SetArrowEnable(bool enable)
		{
			m_ArrowButtonL.enabled = enable;
			m_ArrowButtonR.enabled = enable;
			m_ArrowImageL.enabled = enable;
			m_ArrowImageR.enabled = enable;
		}

		// // RVA: 0x1537960 Offset: 0x1537960 VA: 0x1537960
		public void SetSelectBtnDisable(bool IsDisable)
		{
			m_SelectButton.Disable = IsDisable;
		}

		// // RVA: 0x1537994 Offset: 0x1537994 VA: 0x1537994
		public void SelectButtonChangeUV(TransitionList.Type sceneName)
		{
			sel_fnt.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_valkyrie_pack.GetUVData(sceneName == TransitionList.Type.VALKYRIE_SELECT ? "sel_val_sel_fnt" : "sel_val_sel_fnt_02"));
		}

		// // RVA: 0x1537AA0 Offset: 0x1537AA0 VA: 0x1537AA0
		public void SetSelectBtnCoverLayoutDisable(bool IsDisable)
		{
			m_SelectBtnCoverLayout.enabled = !IsDisable;
			m_SelectButtonLayout.enabled = IsDisable;
		}

		// // RVA: 0x1537B0C Offset: 0x1537B0C VA: 0x1537B0C
		public void SetDetachBtnHidden(bool IsHidden)
		{
			m_DetachButton.Hidden = IsHidden;
		}

		// // RVA: 0x1537B40 Offset: 0x1537B40 VA: 0x1537B40
		public void SetDetachBtnDisable(bool IsDisable)
		{
			m_DetachButton.Disable = IsDisable;
		}

		// // RVA: 0x1537B74 Offset: 0x1537B74 VA: 0x1537B74
		public void SetAtkArrowEnable(bool isEnable)
		{
			m_atkUpArrow.enabled = isEnable;
		}

		// // RVA: 0x1537BA8 Offset: 0x1537BA8 VA: 0x1537BA8
		public void SetHitArrowEnable(bool isEnable)
		{
			m_hitUpArrow.enabled = isEnable;
		}

		// // RVA: 0x1537BDC Offset: 0x1537BDC VA: 0x1537BDC
		public void ApplySelectValkyrieImage(List<PNGOLKLFFLH> list, int select)
		{
			int min = select - 1;
			int max = select + 1;
			for(int i = 0; i < 2; i++)
			{
				int index = i;
				ValkyrieImageData data = m_ValkyrieImageData[i];
				int val = 0;
				if(i == 1)
				{
					val = max;
					if(list.Count <= val)
						val = max - list.Count;
				}
				else
				{
					val = select;
					if(i == 0)
					{
						val = min;
						if(min < 0)
						{
							val = min + list.Count;
						}
					}
				}
				int vfId = list[val].GPPEFLKGGGJ_ValkyrieId;
				m_valkyrieIdList[index] = vfId;
				data.image.enabled = false;
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(vfId, 0, (IiconTexture texture) => {
					//0x1539D64
					if(m_valkyrieIdList[index] == vfId)
					{
						texture.Set(data.image);
						data.image.enabled = true;
					}
					MenuScene.Instance.InputEnable();
				});
				data.lock_icon.enabled = !data.is_enable ? false : list[val].FJODMPGPDDD_Unlocked == false;
			}
		}

		// // RVA: 0x153806C Offset: 0x153806C VA: 0x153806C
		public void SetMainValkyrieIcon(int vfId, int from, Action LoadEndAct)
		{
			m_MainValkyrieIcon.StartChildrenAnimGoStop("02");
			m_MainValkyrieIconImage.enabled = false;
			int m_mainValkyrieId = vfId;
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(vfId, from, (IiconTexture texture) =>
			{
				//0x1539F40
				if(m_mainValkyrieId == vfId)
				{
					texture.Set(m_MainValkyrieIconImage);
					m_MainValkyrieIconImage.enabled = true;
					m_MainValkyrieIcon.StartChildrenAnimGoStop("01");
					if (LoadEndAct != null)
						LoadEndAct();
				}
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0x1538288 Offset: 0x1538288 VA: 0x1538288
		public void MainValkyrieIconHide()
		{
			m_MainValkyrieIcon.StartChildrenAnimGoStop("02");
		}

		// // RVA: 0x1538304 Offset: 0x1538304 VA: 0x1538304
		public void ApplySelectValkyrieImage(List<HEFCLPGPMLK.ANKPCIEKPAH> list, int select)
		{
			for (int i = 0; i < 2; i++)
			{
				int index = i;
				ValkyrieImageData data = m_ValkyrieImageData[i];
				int idx;
				if (i == 1)
				{
					idx = select + 1;
					if (list.Count <= idx)
						idx -= list.Count;
				}
				else
				{
					idx = select;
					if (i == 0)
					{
						idx = select - 1;
						if (idx < 0)
							idx += list.Count;
					}
				}
				int vfId = list[idx].LLOBHDMHJIG_Id;
				m_valkyrieIdList[i] = vfId;
				data.image.enabled = false;
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(vfId, 0, (IiconTexture texture) =>
				{
					//0x153A13C
					if(m_valkyrieIdList[index] == vfId)
					{
						texture.Set(data.image);
						data.image.enabled = true;
					}
					MenuScene.Instance.InputEnable();
				});
				data.lock_icon.enabled = false;
			}
		}

		// // RVA: 0x1538700 Offset: 0x1538700 VA: 0x1538700
		public void ValkyrieImageDefault()
		{
			for(int i = 0; i < m_ValkyrieImageData.Length; i++)
			{
				m_ValkyrieImageData[i].anim.StartChildrenAnimGoStop("st_wait");
			}
		}

		// // RVA: 0x15387F0 Offset: 0x15387F0 VA: 0x15387F0
		public bool SubValkyrieEnable(int listCount)
		{
			bool res = false;
			if(listCount < 2)
			{
				for(int i = 0; i < m_ValkyrieImageData.Length; i++)
				{
					m_ValkyrieImageData[i].is_enable = false;
					m_ValkyrieImageData[i].anim.StartChildrenAnimGoStop("st_act_01");
				}
			}
			else
			{
				for(int i = 0; i < m_ValkyrieImageData.Length; i++)
				{
					m_ValkyrieImageData[i].is_enable = true;
				}
				res = true;
			}
			SetArrowEnable(res);
			return res;
		}

		// // RVA: 0x15389D8 Offset: 0x15389D8 VA: 0x15389D8
		public void SetTransformTouchAreaCallback(Action callback)
		{
			m_TransformTouchArea.onClick.AddListener(() => {
				//0x153A318
				callback();
			});
		}

		// // RVA: 0x1538AE0 Offset: 0x1538AE0 VA: 0x1538AE0
		public void SetActiveTransform(bool activeSelf, bool is_active)
		{
			m_TransformTouchArea.enabled = activeSelf ? false : is_active;
		}

		// // RVA: 0x1538B20 Offset: 0x1538B20 VA: 0x1538B20
		public void FadeInValkyrieImage(LayoutValkyrieSelect.Direction dir)
		{
			if(m_ValkyrieImageData[(int)dir].is_disp)
				return;
			if(!m_ValkyrieImageData[(int)dir].is_enable)
				return;
			m_ValkyrieImageData[(int)dir].anim.StartChildrenAnimGoStop("go_act_02", "st_act_02");
			m_ValkyrieImageData[(int)dir].is_disp = true;
		}

		// // RVA: 0x1538C1C Offset: 0x1538C1C VA: 0x1538C1C
		public void FadeOutValkyrieImage(LayoutValkyrieSelect.Direction dir)
		{
			if(!m_ValkyrieImageData[(int)dir].is_disp)
				return;
			m_ValkyrieImageData[(int)dir].anim.StartChildrenAnimGoStop("go_act_01", "st_act_01");
			m_ValkyrieImageData[(int)dir].is_disp = false;
		}

		// // RVA: 0x1538D08 Offset: 0x1538D08 VA: 0x1538D08
		public bool ValkyrieImageIsPlaying()
		{
			for(int i = 0; i < m_ValkyrieImageData.Length; i++)
			{
				if(m_ValkyrieImageData[i].anim.IsPlayingAll())
					return true;
			}
			return false;
		}

		// // RVA: 0x1538DB8 Offset: 0x1538DB8 VA: 0x1538DB8
		public void Enter()
		{
			m_StateAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1538E44 Offset: 0x1538E44 VA: 0x1538E44
		public void Leave()
		{
			m_StateAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1538ED0 Offset: 0x1538ED0 VA: 0x1538ED0
		public void SetIconState(string label)
		{
			m_SetIconAnim.StartChildrenAnimGoStop(label);
		}

		// // RVA: 0x1538F04 Offset: 0x1538F04 VA: 0x1538F04
		public bool IsPlaying()
		{
			return m_StateAnim.IsPlayingChildren();
		}

		// // RVA: 0x1538F30 Offset: 0x1538F30 VA: 0x1538F30
		public void IsValInfoChange(bool isInfoChange = true)
		{
			if (!isInfoChange)
				m_InfoChangeAnim.StartChildrenAnimGoStop("st_wait", "st_wait");
			else
			{
				m_AbilityLayout.enabled = false;
				m_InfoChangeAnim.StartChildrenAnimLoop("lo_");
			}
		}

		// RVA: 0x153901C Offset: 0x153901C VA: 0x153901C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_StateAnim = layout.FindViewByExId("sw_sel_valkyrie_all_sw_sel_valkyrie_anim") as AbsoluteLayout;
			m_NoticeAnim = layout.FindViewByExId("sw_sel_valkyrie_anim_sw_sel_val_notice_anim") as AbsoluteLayout;
			m_SetIconAnim = layout.FindViewByExId("sw_sel_val_window01_swtbl_sel_val_set_icon") as AbsoluteLayout;
			m_ShowAbilityLayout = layout.FindViewByExId("sw_val_ability_sw_val_abilityset") as AbsoluteLayout;
			m_HideAbilityLayout = layout.FindViewByExId("sw_val_ability_sw_val_abilityset_not_bk") as AbsoluteLayout;
			m_SelectBtnCoverLayout = layout.FindViewByExId("sw_cmn_btn_p_anim_c_b_rankmax_fnt") as AbsoluteLayout;
			m_SelectButtonLayout = layout.FindViewByExId("sw_cmn_btn_p_anim_sel_val_sel_fnt") as AbsoluteLayout;
			m_AbilityLayout = layout.FindViewByExId("sw_sel_valkyrie_anim_sw_val_ability") as AbsoluteLayout;
			m_InfoChangeAnim = layout.FindViewByExId("sw_sel_valkyrie_anim_sw_sel_val_window01") as AbsoluteLayout;
			m_InfoChangeAnim.StartChildrenAnimGoStop("st_wait");
			m_MainValkyrieIcon = layout.FindViewByExId("sw_sel_valkyrie_anim_swtbl_cmn_valkyrie_icon01") as AbsoluteLayout;
			m_MainValkyrieIcon.StartChildrenAnimGoStop("02");
			for(int i = 0; i < m_ValkyrieImageData.Length; i++)
			{
				m_ValkyrieImageData[i] = new ValkyrieImageData();
			}
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			List<RawImageEx> imgsList = new List<RawImageEx>(imgs);
			m_ValkyrieImageData[0].image = m_SubValkyrieImageList[0];
			m_ValkyrieImageData[1].image = m_SubValkyrieImageList[1];
			m_ValkyrieImageData[0].lock_icon = m_SubValkyrieLockImageList[0];
			m_ValkyrieImageData[1].lock_icon = m_SubValkyrieLockImageList[1];
			m_valkyrie_pack = uvMan.GetTexUVList("sel_valkyrie_pack");
			m_ValkyrieImageData[0].anim = layout.FindViewByExId("sw_sel_valkyrie_anim_sw_cmn_valkyrie_icon_anim_01") as AbsoluteLayout;
			m_ValkyrieImageData[1].anim = layout.FindViewByExId("sw_sel_valkyrie_anim_sw_cmn_valkyrie_icon_anim_02") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
