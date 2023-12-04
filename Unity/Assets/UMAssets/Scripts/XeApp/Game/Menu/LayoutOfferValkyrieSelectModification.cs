using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutOfferValkyrieSelectModification : LayoutUGUIScriptBase
	{
		private AbsoluteLayout[] SortieList = new AbsoluteLayout[3]; // 0x14
		private AbsoluteLayout[] PlatoonNumIconList = new AbsoluteLayout[3]; // 0x18
		private AbsoluteLayout[] BounsIconList = new AbsoluteLayout[3]; // 0x1C
		private AbsoluteLayout[] IconStateList = new AbsoluteLayout[3]; // 0x20
		private AbsoluteLayout m_layoutRoot; // 0x24

		// RVA: 0x15D6DCC Offset: 0x15D6DCC VA: 0x15D6DCC
		private void Start()
		{
			return;
		}

		// RVA: 0x15D6DD0 Offset: 0x15D6DD0 VA: 0x15D6DD0
		private void Update()
		{
			return;
		}

		//// RVA: 0x15D6DD4 Offset: 0x15D6DD4 VA: 0x15D6DD4
		public void initialize()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			AllHide();
		}

		// RVA: 0x15D6E68 Offset: 0x15D6E68 VA: 0x15D6E68
		public void AllHide()
		{
			for(int i = 0; i < 3; i++)
			{
				sortieIcon(i, false);
				PlatoonIcon(i, false, 0);
				BounsIcon(i, false);
				IconState(i, false, false);
			}
		}

		// RVA: 0x15D7308 Offset: 0x15D7308 VA: 0x15D7308
		public void IconSetting(int idx, bool IsSortie, bool IsBouns, bool IsSetPlatoon, int PlatoonNum = 0)
		{
			sortieIcon(idx, IsSortie);
			PlatoonIcon(idx, IsSetPlatoon, PlatoonNum);
			BounsIcon(idx, IsBouns);
			IconState(idx, IsBouns, IsSetPlatoon);
		}

		//// RVA: 0x15D6ED8 Offset: 0x15D6ED8 VA: 0x15D6ED8
		public void sortieIcon(int idx, bool IsSort)
		{
			SortieList[idx].StartChildrenAnimGoStop(IsSort ? "01" : "02");
		}

		//// RVA: 0x15D6FA8 Offset: 0x15D6FA8 VA: 0x15D6FA8
		public void PlatoonIcon(int idx, bool Isplatoon, int platoonNum)
		{
			PlatoonNumIconList[idx].StartChildrenAnimGoStop(Isplatoon ? platoonNum.ToString("D2") : "06");
		}

		//// RVA: 0x15D70B4 Offset: 0x15D70B4 VA: 0x15D70B4
		public void BounsIcon(int idx, bool IsBouns)
		{
			BounsIconList[idx].StartChildrenAnimGoStop(IsBouns ? "01" : "02");
		}

		//// RVA: 0x15D7184 Offset: 0x15D7184 VA: 0x15D7184
		public void IconState(int idx, bool IsBouns, bool Isplatoon)
		{
			if(IsBouns || !Isplatoon)
			{
				IconStateList[idx].StartChildrenAnimGoStop(IsBouns && !Isplatoon ? "02" : "03");
			}
			else
			{
				IconStateList[idx].StartChildrenAnimGoStop("01");
			}
		}

		// RVA: 0x15D7368 Offset: 0x15D7368 VA: 0x15D7368 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_valkyrie_sw_sel_vfo_valkyrie_anim") as AbsoluteLayout;
			for(int i = 0; i < 3; i++)
			{
				SortieList[i] = layout.FindViewByExId(string.Format("sw_sel_vfo_valkyrie_swtbl_s_v_icon_sortie_0{0}", i + 1)) as AbsoluteLayout;
				IconStateList[i] = layout.FindViewByExId(string.Format("sw_sel_vfo_valkyrie_swtbl_s_v_icon_0{0}", i + 1)) as AbsoluteLayout;
				PlatoonNumIconList[i] = IconStateList[i].FindViewByExId("swtbl_s_v_icon_01_swtbl_s_v_btn_vf_num") as AbsoluteLayout;
				BounsIconList[i] = IconStateList[i].FindViewByExId("swtbl_s_v_icon_01_swtbl_s_v_icon_bonus_01") as AbsoluteLayout;
			}
			return true;
		}
	}
}
