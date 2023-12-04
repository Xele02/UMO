using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutOfferFormation : LayoutUGUIScriptBase
	{
		public enum Arrangement
		{
			LEFT = 0,
			MIDDLE = 1,
			RIGHT = 2,
			MAX = 3,
		}

		public enum offerSubValIcon
		{
			LEFT = 0,
			RIGHT = 1,
			MAX = 2,
		}

		public enum textColor
		{
			Default = 0,
			Red = 1,
			Green = 2,
		}

		[SerializeField]
		private ActionButton DoneBtn; // 0x14
		[SerializeField]
		private ActionButton DissolutionBtn; // 0x18
		[SerializeField]
		private ActionButton LeftButton; // 0x1C
		[SerializeField]
		private ActionButton RightButton; // 0x20
		[SerializeField]
		private ActionButton NameChenge; // 0x24
		[SerializeField]
		private Text PlatoonName; // 0x28
		[SerializeField]
		private Text AttackText; // 0x2C
		[SerializeField]
		private Text AcccuracyText; // 0x30
		[SerializeField]
		private ActionButton[] PlatoonButtons = new ActionButton[5]; // 0x34
		[SerializeField]
		private RawImageEx[] SubValkyrieImageIcons = new RawImageEx[2]; // 0x38
		[SerializeField]
		private RawImageEx[] ValkyrieBanners = new RawImageEx[3]; // 0x3C
		[SerializeField]
		private ActionButton[] ValkyrieBannerBtns = new ActionButton[3]; // 0x40
		[SerializeField]
		private RawImageEx ValkyrieIcon; // 0x44
		private AbsoluteLayout m_layoutRoot; // 0x48
		private AbsoluteLayout[] m_PlatoonNumList = new AbsoluteLayout[5]; // 0x4C
		private AbsoluteLayout[] m_SubValkyrieIconList = new AbsoluteLayout[2]; // 0x50
		private AbsoluteLayout[] m_SortieIconList = new AbsoluteLayout[3]; // 0x54
		private AbsoluteLayout[] m_LockIconList = new AbsoluteLayout[3]; // 0x58
		private AbsoluteLayout[] m_BannerStateList = new AbsoluteLayout[3]; // 0x5C
		private AbsoluteLayout m_sotieIcon; // 0x60
		private AbsoluteLayout m_lackPower; // 0x64
		private AbsoluteLayout m_lackPowerAnim; // 0x68
		private AbsoluteLayout m_BounsIcon; // 0x6C
		private AbsoluteLayout m_valkyrieIconLayout; // 0x70
		private AbsoluteLayout[] m_SotiePlatoonButton = new AbsoluteLayout[5]; // 0x74
		private AbsoluteLayout[] m_AbilityIconList = new AbsoluteLayout[3]; // 0x78
		private AbsoluteLayout[] m_AbilityEffectList01 = new AbsoluteLayout[3]; // 0x7C
		private AbsoluteLayout[] m_AbilityEffectList02 = new AbsoluteLayout[3]; // 0x80

		// RVA: 0x15D0A68 Offset: 0x15D0A68 VA: 0x15D0A68
		private void Start()
		{
			return;
		}

		// RVA: 0x15D0A6C Offset: 0x15D0A6C VA: 0x15D0A6C
		public void initialize(int formationNum)
		{
			platoonNumAnim(formationNum);
			BounsIconHide();
		}

		// RVA: 0x15D0C04 Offset: 0x15D0C04 VA: 0x15D0C04
		private void Update()
		{
			return;
		}

		// RVA: 0x15D0C08 Offset: 0x15D0C08 VA: 0x15D0C08
		public void AllButtonListenersReset()
		{
			DoneBtn.ClearOnClickCallback();
			DissolutionBtn.ClearOnClickCallback();
			LeftButton.ClearOnClickCallback();
			RightButton.ClearOnClickCallback();
			NameChenge.ClearOnClickCallback();
			for(int i = 0; i < ValkyrieBannerBtns.Length; i++)
			{
				ValkyrieBannerBtns[i].ClearOnClickCallback();
			}
			for(int i = 0; i < PlatoonButtons.Length; i++)
			{
				PlatoonButtons[i].ClearOnClickCallback();
			}
		}

		// RVA: 0x15D0DB8 Offset: 0x15D0DB8 VA: 0x15D0DB8
		public void SetDoneButton(Action _done)
		{
			DoneBtn.AddOnClickCallback(() =>
			{
				//0x15D3DF8
				_done();
			});
		}

		// RVA: 0x15D0EA0 Offset: 0x15D0EA0 VA: 0x15D0EA0
		public void SetDissolutionButton(Action _dissolution)
		{
			DissolutionBtn.AddOnClickCallback(() =>
			{
				//0x15D3E24
				_dissolution();
			});
		}

		// RVA: 0x15D0F88 Offset: 0x15D0F88 VA: 0x15D0F88
		public void SetNameChengeButton(Action _namechenge)
		{
			NameChenge.AddOnClickCallback(() =>
			{
				//0x15D3E50
				_namechenge();
			});
		}

		// RVA: 0x15D1070 Offset: 0x15D1070 VA: 0x15D1070
		public void SetArrowButton(Action _left, Action _right)
		{
			LeftButton.AddOnClickCallback(() =>
			{
				//0x15D3E7C
				_left();
			});
			RightButton.AddOnClickCallback(() =>
			{
				//0x15D3EA8
				_right();
			});
		}

		// RVA: 0x15D11D0 Offset: 0x15D11D0 VA: 0x15D11D0
		public void SetPlatoonSelectButton(Action<int> _SelectPlatoon)
		{
			for(int i = 0; i < 5; i++)
			{
				int index = i;
				PlatoonButtons[i].AddOnClickCallback(() =>
				{
					//0x15D3ED4
					_SelectPlatoon(index);
					platoonNumAnim(index);
				});
			}
		}

		// RVA: 0x15D13A4 Offset: 0x15D13A4 VA: 0x15D13A4
		public void SetValkyrieBannerBtns(Action<int> _valkyrieBanner)
		{
			for(int i = 0; i < ValkyrieBannerBtns.Length; i++)
			{
				int index = i;
				ValkyrieBannerBtns[i].AddOnClickCallback(() =>
				{
					//0x15D3FA0
					_valkyrieBanner(index);
				});
			}
		}

		// RVA: 0x15D1578 Offset: 0x15D1578 VA: 0x15D1578
		public void SetPlatoonName(string _platoonName)
		{
			PlatoonName.text = _platoonName;
		}

		// RVA: 0x15D15B4 Offset: 0x15D15B4 VA: 0x15D15B4
		public string GetPlatoonName()
		{
			return PlatoonName.text;
		}

		// RVA: 0x15D15E8 Offset: 0x15D15E8 VA: 0x15D15E8
		public void SetAttackText(string _attackText)
		{
			AttackText.text = _attackText;
		}

		//// RVA: 0x15D1624 Offset: 0x15D1624 VA: 0x15D1624
		public void SetAcccuracyText(string _acccuracyText)
		{
			AcccuracyText.text = _acccuracyText;
		}

		// RVA: 0x15D1660 Offset: 0x15D1660 VA: 0x15D1660
		public void SetValkyrieBanner(int _index, int vfId)
		{
			if (vfId < 1)
				m_BannerStateList[_index].StartChildrenAnimGoStop("01");
			else
			{
				m_BannerStateList[_index].StartChildrenAnimGoStop("02");
				ValkyrieBanners[_index].enabled = false;
				MenuScene.Instance.InputDisable();
				GameManager.Instance.ValkyrieIconCache.Load(vfId, 0, (IiconTexture image) =>
				{
					//0x15D4034
					ValkyrieBanners[_index].enabled = true;
					image.Set(ValkyrieBanners[_index]);
					MenuScene.Instance.InputEnable();
				});
			}
		}

		// RVA: 0x15D1944 Offset: 0x15D1944 VA: 0x15D1944
		public bool BannerImageIsLoding()
		{
			for(int i = 0; i < ValkyrieBanners.Length; i++)
			{
				if (!ValkyrieBanners[i].enabled)
					return true;
			}
			return false;
		}

		// RVA: 0x15D19E4 Offset: 0x15D19E4 VA: 0x15D19E4
		public void SetSubValkyrieIcon(int _index, int IconId)
		{
			if (IconId < 1)
				m_SubValkyrieIconList[_index].StartChildrenAnimGoStop("02");
			else
			{
				m_SubValkyrieIconList[_index].StartChildrenAnimGoStop("01");
				SubValkyrieImageIcons[_index].enabled = false;
				MenuScene.Instance.InputDisable();
				GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(IconId, 0, (IiconTexture image) =>
				{
					//0x15D4224
					SubValkyrieImageIcons[_index].enabled = true;
					image.Set(SubValkyrieImageIcons[_index]);
					MenuScene.Instance.InputEnable();
				});
			}
		}

		// RVA: 0x15D1CC8 Offset: 0x15D1CC8 VA: 0x15D1CC8
		public bool SubValkyrieIconImageIsLoding()
		{
			for(int i = 0; i < SubValkyrieImageIcons.Length; i++)
			{
				if (!SubValkyrieImageIcons[i].enabled)
					return true;
			}
			return false;
		}

		// RVA: 0x15D1D68 Offset: 0x15D1D68 VA: 0x15D1D68
		public void DisplayLockIcon(bool IsLock, int index)
		{
			m_LockIconList[index].StartChildrenAnimGoStop(IsLock ? "01" : "02");
		}

		// RVA: 0x15D1E38 Offset: 0x15D1E38 VA: 0x15D1E38
		public void DisplaySortieIcon(bool IsSortie)
		{
			m_sotieIcon.StartChildrenAnimGoStop(IsSortie ? "01" : "02");
		}

		// RVA: 0x15D1ED0 Offset: 0x15D1ED0 VA: 0x15D1ED0
		public void LackPowerIconDisable(bool IsLackPower)
		{
			if (!IsLackPower)
				m_lackPower.StartChildrenAnimGoStop("02");
			else
			{
				m_lackPower.StartChildrenAnimGoStop("01");
				m_lackPowerAnim.StartChildrenAnimLoop("lo_");
			}
		}

		// RVA: 0x15D1FA8 Offset: 0x15D1FA8 VA: 0x15D1FA8
		public void ButtonDisable(bool isDisable)
		{
			for(int i = 0; i < ValkyrieBannerBtns.Length; i++)
			{
				ValkyrieBannerBtns[i].Disable = isDisable;
			}
			DoneBtn.Disable = isDisable;
			DissolutionBtn.Disable = isDisable;
			NameChenge.Disable = isDisable;
		}

		// RVA: 0x15D20AC Offset: 0x15D20AC VA: 0x15D20AC
		public void PlatoonEnpty(bool isDark)
		{
			DoneBtn.Disable = isDark;
			DissolutionBtn.Disable = isDark;
		}

		// RVA: 0x15D2108 Offset: 0x15D2108 VA: 0x15D2108
		public void SetValkyrieIcon(int vfId, int from, Action LoadEndAct)
		{
			m_valkyrieIconLayout.StartChildrenAnimGoStop("02");
			ValkyrieIcon.enabled = false;
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(vfId, from, (IiconTexture texture) =>
			{
				//0x15D4414
				texture.Set(ValkyrieIcon);
				ValkyrieIcon.enabled = true;
				m_valkyrieIconLayout.StartChildrenAnimGoStop("01");
				if (LoadEndAct != null)
					LoadEndAct();
				MenuScene.Instance.InputEnable();
			});
		}

		// RVA: 0x15D2300 Offset: 0x15D2300 VA: 0x15D2300
		public void ValkyrieIconHide()
		{
			m_valkyrieIconLayout.StartChildrenAnimGoStop("02");
			ValkyrieIcon.enabled = false;
		}

		// RVA: 0x15D23A0 Offset: 0x15D23A0 VA: 0x15D23A0
		public void Enter()
		{
			m_layoutRoot.StartAllAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x15D242C Offset: 0x15D242C VA: 0x15D242C
		public void Leave()
		{
			m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x15D24B8 Offset: 0x15D24B8 VA: 0x15D24B8
		//public void Hide() { }

		//// RVA: 0x15D2534 Offset: 0x15D2534 VA: 0x15D2534
		//public void Show() { }

		//// RVA: 0x15D25B0 Offset: 0x15D25B0 VA: 0x15D25B0
		//private void SubValkyrieIconAllHide() { }

		//// RVA: 0x15D0B88 Offset: 0x15D0B88 VA: 0x15D0B88
		private void BounsIconHide()
		{
			m_BounsIcon.StartChildrenAnimGoStop("02");
		}

		// RVA: 0x15D268C Offset: 0x15D268C VA: 0x15D268C
		public void BounsIconDisable(bool IsBouns)
		{
			m_BounsIcon.StartChildrenAnimGoStop(IsBouns ? "01" : "02");
		}

		// RVA: 0x15D0A88 Offset: 0x15D0A88 VA: 0x15D0A88
		public void platoonNumAnim(int selectPlatoon)
		{
			for(int i = 0; i < m_PlatoonNumList.Length; i++)
			{
				m_PlatoonNumList[i].StartChildrenAnimGoStop(selectPlatoon == i ? "02" : "01");
			}
		}

		// RVA: 0x15D2724 Offset: 0x15D2724 VA: 0x15D2724
		public void SetSotiePlatoonButton(int index, bool IsSotie)
		{
			m_SotiePlatoonButton[index].StartChildrenAnimGoStop(IsSotie ? "02" : "01");
		}

		// RVA: 0x15D27F0 Offset: 0x15D27F0 VA: 0x15D27F0
		public void SettingAbilityAnim(int _valId, int _select)
		{
			NHDJHOPLMDE n = new NHDJHOPLMDE(_valId, 0);
			if(n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.FJFMLFPJKNB_2, _select == 0 ? EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12 : EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.PPNNBADDNKB_11))
			{
				m_AbilityIconList[_select].StartChildrenAnimGoStop("go_abi_in");
				m_AbilityEffectList01[_select].StartChildrenAnimLoop("logo_abi");
				m_AbilityEffectList02[_select].StartChildrenAnimLoop("logo_abi");
			}
			else
			{
				m_AbilityIconList[_select].StartChildrenAnimGoStop("st_abi_out");
				m_AbilityEffectList01[_select].StartChildrenAnimGoStop("st_wait");
				m_AbilityEffectList02[_select].StartChildrenAnimGoStop("st_wait");
			}
		}

		//// RVA: 0x15D2ABC Offset: 0x15D2ABC VA: 0x15D2ABC
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlaying();
		}

		// RVA: 0x15D2AE8 Offset: 0x15D2AE8 VA: 0x15D2AE8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_deck_sw_s_v_deck_anim") as AbsoluteLayout;
			for(int i = 0; i < 5; i++)
			{
				m_PlatoonNumList[i] = layout.FindViewByExId(string.Format("sw_s_v_btn_vf_swtbl_s_v_tab_0{0}", i + 1)) as AbsoluteLayout;
			}
			for(int i = 0; i < 2; i++)
			{
				m_SubValkyrieIconList[i] = layout.FindViewByExId(string.Format("sw_s_v_icon_bonus_swtbl_m_icon02_01_0{0}", i + 1)) as AbsoluteLayout;
			}
			for(int i = 0; i < 3; i++)
			{
				AbsoluteLayout abs = layout.FindViewByExId(string.Format("sw_s_v_window01_s_v_btn_val_anim_0{0}", i + 1)) as AbsoluteLayout;
				m_BannerStateList[i] = abs.FindViewByExId("s_v_btn_val_anim_btn") as AbsoluteLayout;
				m_LockIconList[i] = abs.FindViewByExId("s_v_btn_val_anim_cmn_lock_icon") as AbsoluteLayout;
				m_SortieIconList[i] = abs.FindViewByExId("s_v_btn_val_anim_swtbl_s_v_icon_sortie_01") as AbsoluteLayout;
				m_SortieIconList[i].StartChildrenAnimGoStop("02");
			}
			m_BounsIcon = layout.FindViewByExId("sw_s_v_deck_anim_swtbl_s_v_icon_bonus_01") as AbsoluteLayout;
			m_sotieIcon = layout.FindViewByExId("sw_s_v_deck_anim_swtbl_s_v_icon_sortie_02") as AbsoluteLayout;
			m_lackPower = layout.FindViewByExId("sw_s_v_window01_swtbl_pw_low") as AbsoluteLayout;
			m_lackPowerAnim = layout.FindViewByExId("swtbl_pw_low_s_v_fnt_pw_low") as AbsoluteLayout;
			m_valkyrieIconLayout = layout.FindViewByExId("sw_s_v_deck_anim_swtbl_cmn_valkyrie_icon01") as AbsoluteLayout;
			ValkyrieIconHide();
			for(int i = 0; i < 5; i++)
			{
				m_SotiePlatoonButton[i] = layout.FindViewByExId(string.Format("s_v_btn_vf_base_{0:D2}_swtbl_s_v_btn_vf_base_{0:D2}", i + 1)) as AbsoluteLayout;
			}
			for(int i = 0; i < m_AbilityIconList.Length; i++)
			{
				m_AbilityIconList[i] = layout.FindViewByExId(string.Format("sw_s_v_window01_sw_set_deck_unit_spt_ability_anim_0{0}", i + 1)) as AbsoluteLayout;
			}
			for(int i = 0; i < m_AbilityEffectList01.Length; i++)
			{
				AbsoluteLayout abs = layout.FindViewByExId(string.Format("sw_s_v_window01_s_v_btn_val_anim_0{0}", i + 1)) as AbsoluteLayout; ;
				m_AbilityEffectList01[i] = abs.FindViewByExId("s_v_btn_val_anim_set_deck_unit_spt_ability_ef_1_all_anim") as AbsoluteLayout;
				m_AbilityEffectList02[i] = abs.FindViewByExId("s_v_btn_val_anim_set_deck_unit_spt_ability_ef_2_all_anim") as AbsoluteLayout;
			}
			return true;
		}
	}
}
