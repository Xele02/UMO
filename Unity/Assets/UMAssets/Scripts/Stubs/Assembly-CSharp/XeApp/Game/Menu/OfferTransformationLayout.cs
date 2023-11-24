using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferTransformationLayout : LayoutUGUIScriptBase
	{
		private const int TransIconNum = 2;
		private const int TransNum = 3;
		[SerializeField]
		private ActionButton Sortie; // 0x14
		[SerializeField]
		private RawImageEx[] FighterItemIcon; // 0x18
		[SerializeField]
		private RawImageEx[] GarwalkItemIcon; // 0x1C
		[SerializeField]
		private RawImageEx[] BatroidItemIcon; // 0x20
		[SerializeField]
		private Text AttackText; // 0x24
		[SerializeField]
		private Text HitText; // 0x28
		private AbsoluteLayout m_layoutRoot; // 0x2C
		private AbsoluteLayout m_formation; // 0x30
		private AbsoluteLayout m_fighterFontAnim; // 0x34
		private AbsoluteLayout m_garwalkFontAnim; // 0x38
		private AbsoluteLayout m_batroidFontAnim; // 0x3C
		private AbsoluteLayout[] m_fighterUpState = new AbsoluteLayout[2]; // 0x40
		private AbsoluteLayout[] m_garwalkUpState = new AbsoluteLayout[2]; // 0x44
		private AbsoluteLayout[] m_batroidUpState = new AbsoluteLayout[2]; // 0x48
		private AbsoluteLayout m_lowPowerLayout; // 0x4C
		private AbsoluteLayout m_lackPowerAnim; // 0x50
		private bool[] IsLodingList = new bool[6]; // 0x54
		private KDHGBOOECKC.JNHGHDKLDEM m_data; // 0x58
		private HEFCLPGPMLK.AAOPGOGGMID m_info; // 0x5C

		// RVA: 0x1712234 Offset: 0x1712234 VA: 0x1712234
		private void Start()
		{
			return;
		}

		// RVA: 0x1712238 Offset: 0x1712238 VA: 0x1712238
		private void Update()
		{
			return;
		}

		// RVA: 0x171223C Offset: 0x171223C VA: 0x171223C
		public void initialize(KDHGBOOECKC.JNHGHDKLDEM _data, HEFCLPGPMLK.AAOPGOGGMID info, int platoonId)
		{
			m_data = _data;
			m_info = info;
			for(int i = 0; i < IsLodingList.Length; i++)
			{
				IsLodingList[i] = false;
			}
			BOPFPIHGJMD.ADMNKELOLPN a2 = KDHGBOOECKC.HHCJCDFCLOB.KJGAJBOBIHK(info.FGHGMHPNEMG_Category, info.PPFNGGCBJKC);
			SettingText((KDHGBOOECKC.HHCJCDFCLOB.KGLLKKCFDEL(FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter, a2, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0) * KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(platoonId, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0)) / 100, 
						(KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(platoonId, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1) * KDHGBOOECKC.HHCJCDFCLOB.KGLLKKCFDEL(FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter, a2, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1)) / 100);
			bool b = SetRateState(m_data.NNDGIAEFMOG[0].LHMDABPNDDH, m_fighterUpState);
			m_fighterFontAnim.StartChildrenAnimLoop(b ? "lo_" : "st_wait");
			b = SetRateState(m_data.NNDGIAEFMOG[1].LHMDABPNDDH, m_garwalkUpState);
			m_garwalkFontAnim.StartChildrenAnimLoop(b ? "lo_" : "st_wait");
			b = SetRateState(m_data.NNDGIAEFMOG[2].LHMDABPNDDH, m_batroidUpState);
			m_batroidFontAnim.StartChildrenAnimLoop(b ? "lo_" : "st_wait");
			for(int i = 0; i < IsLodingList.Length; i++)
			{
				IsLodingList[i] = true;
			}
			SetItemTexture(FighterItemIcon, m_data.NNDGIAEFMOG[0], (int index) =>
			{
				//0x1713F80
				ChangeIsLoading(index, FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter);
			});
			SetItemTexture(GarwalkItemIcon, m_data.NNDGIAEFMOG[1], (int index) =>
			{
				//0x1713F88
				ChangeIsLoading(index, FKGMGBHBNOC.HPJOCKGKNCC_Form.MOGAKDMDCJB_Gerwalk);
			});
			SetItemTexture(BatroidItemIcon, m_data.NNDGIAEFMOG[2], (int index) =>
			{
				//0x1713F90
				ChangeIsLoading(index, FKGMGBHBNOC.HPJOCKGKNCC_Form.GBLPNIGCPAP_Battroid);
			});
		}

		//// RVA: 0x1713054 Offset: 0x1713054 VA: 0x1713054
		private void ChangeIsLoading(int index, FKGMGBHBNOC.HPJOCKGKNCC_Form _from)
		{
			IsLodingList[index + (int)_from * 2] = false;
		}

		// RVA: 0x17130A8 Offset: 0x17130A8 VA: 0x17130A8
		public void SetSortieCallback(Action act)
		{
			Sortie.ClearOnClickCallback();
			Sortie.AddOnClickCallback(() =>
			{
				//0x1713F98
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				act();
			});
		}

		// RVA: 0x17128E8 Offset: 0x17128E8 VA: 0x17128E8
		public void SettingText(int Attack, int Hit)
		{
			AttackText.text = OfferFormationScene.textColorChenge(m_info.KINFGHHNFCF, Attack);
			HitText.text = OfferFormationScene.textColorChenge(m_info.NONBCCLGBAO, Hit);
		}

		//// RVA: 0x1712A14 Offset: 0x1712A14 VA: 0x1712A14
		private bool SetRateState(BOPFPIHGJMD.MGPIJGMDLOM[] state, AbsoluteLayout[] list)
		{
			bool b = false;
			for(int i = 0; i < 2; i++)
			{
				list[i].enabled = true;
				if(i > 0)
				{
					b = state[i] != BOPFPIHGJMD.MGPIJGMDLOM.HJNNKCMLGFL_3;
				}
				if(state[i] == BOPFPIHGJMD.MGPIJGMDLOM.INIMBLOHIEF_0)
				{
					list[i].StartChildrenAnimGoStop("01");
				}
				else if(state[i] == BOPFPIHGJMD.MGPIJGMDLOM.JIOPJDJBLFK_2)
				{
					list[i].StartChildrenAnimGoStop("03");
				}
				else if (state[i] == BOPFPIHGJMD.MGPIJGMDLOM.FMHLGHDKJBC_1)
				{
					list[i].StartChildrenAnimGoStop("02");
				}
			}
			return b;
		}

		//// RVA: 0x1712CA8 Offset: 0x1712CA8 VA: 0x1712CA8
		private void SetItemTexture(RawImageEx[] images, KDHGBOOECKC.BOBLBPGKIOH state, Action<int> loaded)
		{
			for(int i = 0; i < 2; i++)
			{
				int index = i;
				images[i].enabled = false;
				if(state.LHMDABPNDDH[i] == BOPFPIHGJMD.MGPIJGMDLOM.INIMBLOHIEF_0)
				{
					MenuScene.Instance.InputDisable();
					GameManager.Instance.ItemTextureCache.Load(state.LNADJDFHHAI[i], (IiconTexture image) =>
					{
						//0x1714014
						images[index].enabled = true;
						image.Set(images[index]);
						if(loaded != null)
						{
							loaded(index);
						}
						MenuScene.Instance.InputEnable();
					});
				}
				else
				{
					if(loaded != null)
					{
						loaded(index);
					}
				}
			}
		}

		// RVA: 0x17131C0 Offset: 0x17131C0 VA: 0x17131C0
		public bool IsImageLoading()
		{
			for(int i = 0; i < IsLodingList.Length; i++)
			{
				if (IsLodingList[i])
					return true;
			}
			return false;
		}

		// RVA: 0x1713248 Offset: 0x1713248 VA: 0x1713248
		public void SetTransformation(int _from)
		{
			m_formation.StartChildrenAnimGoStop((_from + 1).ToString("D2"));
		}

		// RVA: 0x17132EC Offset: 0x17132EC VA: 0x17132EC
		public void LowPowerIconEnable(int platoonId, int form)
		{
			if (m_info.JGAMLEMMJCJ < KDHGBOOECKC.HHCJCDFCLOB.NPEFMNPOMMJ(m_info.FGHGMHPNEMG_Category, m_info.PPFNGGCBJKC, platoonId, (FKGMGBHBNOC.HPJOCKGKNCC_Form)form, true))
			{
				m_lowPowerLayout.StartChildrenAnimGoStop("01");
				m_lackPowerAnim.StartChildrenAnimLoop("lo_");
			}
			else
			{
				m_lowPowerLayout.StartChildrenAnimGoStop("02");
			}
		}

		// RVA: 0x1713478 Offset: 0x1713478 VA: 0x1713478
		public void Enter()
		{
			m_layoutRoot.StartAllAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1713504 Offset: 0x1713504 VA: 0x1713504
		public void Leave()
		{
			m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1713590 Offset: 0x1713590 VA: 0x1713590
		//public void Hide() { }

		//// RVA: 0x171360C Offset: 0x171360C VA: 0x171360C
		//public void Show() { }

		//// RVA: 0x1713688 Offset: 0x1713688 VA: 0x1713688
		//public bool IsPlaying() { }

		// RVA: 0x17136B4 Offset: 0x17136B4 VA: 0x17136B4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_form_01_sw_s_v_f_win_01_anim") as AbsoluteLayout;
			m_formation = layout.FindViewByExId("sw_s_v_f_win_01_anim_swtbl_s_v_f_win_01") as AbsoluteLayout;
			m_fighterFontAnim = layout.FindViewByExId("swtbl_s_v_f_win_01_sw_s_v_f_fnt_anim_01") as AbsoluteLayout;
			m_garwalkFontAnim = layout.FindViewByExId("swtbl_s_v_f_win_01_sw_s_v_f_fnt_anim_02") as AbsoluteLayout;
			m_batroidFontAnim = layout.FindViewByExId("swtbl_s_v_f_win_01_sw_s_v_f_fnt_anim_03") as AbsoluteLayout;
			for(int i = 0; i < 2; i++)
			{
				m_fighterUpState[i] = m_fighterFontAnim.FindViewByExId(string.Format("sw_s_v_f_fnt_anim_swtbl_type_up_0{0}", i + 1)) as AbsoluteLayout;
				m_garwalkUpState[i] = m_garwalkFontAnim.FindViewByExId(string.Format("sw_s_v_f_fnt_anim_swtbl_type_up_0{0}", i + 1)) as AbsoluteLayout;
				m_batroidUpState[i] = m_batroidFontAnim.FindViewByExId(string.Format("sw_s_v_f_fnt_anim_swtbl_type_up_0{0}", i + 1)) as AbsoluteLayout;
			}
			m_lowPowerLayout = layout.FindViewByExId("swtbl_s_v_f_win_01_swtbl_pw_low") as AbsoluteLayout;
			m_lackPowerAnim = layout.FindViewByExId("swtbl_pw_low_s_v_fnt_pw_low") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
