using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class OfferInfoLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_OfferName; // 0x14
		[SerializeField]
		private Text m_EnemyPower; // 0x18
		[SerializeField]
		private Text m_OfferClearTime; // 0x1C
		[SerializeField]
		private Text m_Attack; // 0x20
		[SerializeField]
		private Text m_Hit; // 0x24
		[SerializeField]
		private RawImageEx m_SeriesLog; // 0x28
		private const float CHENGE_TIME = 0.5f;
		private AbsoluteLayout m_layoutRoot; // 0x2C
		private AbsoluteLayout m_offerType; // 0x30
		private AbsoluteLayout m_LackPowerFrame; // 0x34
		private AbsoluteLayout m_LackPowerAnim; // 0x38
		public HEFCLPGPMLK.AAOPGOGGMID ViewOfferInfo; // 0x3C
		private long currntClearTime; // 0x40
		private Coroutine powerChengeCoroutine; // 0x48
		public bool IsLackPower; // 0x4C
		private TexUVList m_texUvList; // 0x50
		private static readonly string[] m_LogoTextureUvNameTable = new string[7]
		{
			"s_v_logo_01", "s_v_logo_02", "s_v_logo_03", "s_v_logo_04", "", "s_v_logo_05", ""
		}; // 0x0

		// RVA: 0x18526F0 Offset: 0x18526F0 VA: 0x18526F0
		private void Start()
		{
			return;
		}

		// RVA: 0x18526F4 Offset: 0x18526F4 VA: 0x18526F4
		private void Update()
		{
			return;
		}

		//// RVA: 0x18526F8 Offset: 0x18526F8 VA: 0x18526F8
		public void SetOfferInfomation(HEFCLPGPMLK.AAOPGOGGMID _view)
		{
			ViewOfferInfo = _view;
			SetRecomValue(_view.KINFGHHNFCF, _view.NONBCCLGBAO);
			SetofferType(ViewOfferInfo.CGKPIIFCCLD_OfferType);
			m_OfferName.text = ViewOfferInfo.IJOLPDKFLPO_OfferName;
			SetenemyDataText((int)ViewOfferInfo.JGAMLEMMJCJ_ClearTime, ViewOfferInfo.JGAMLEMMJCJ_ClearTime);
			ChengeSeriesLogo(ViewOfferInfo.DFMOGBOPLEF_Series);
			currntClearTime = ViewOfferInfo.JGAMLEMMJCJ_ClearTime;
		}

		// RVA: 0x1852E68 Offset: 0x1852E68 VA: 0x1852E68
		public void StartChengeEnemyPower(int vfpId, bool Isinitialize, int vfForm = 0, bool IsCorrent = true)
		{
			if(powerChengeCoroutine != null)
			{
				this.StopCoroutineWatched(powerChengeCoroutine);
				powerChengeCoroutine = null;
			}
			powerChengeCoroutine = this.StartCoroutineWatched(Co_ChengeEnemyPower(vfpId, Isinitialize, vfForm, IsCorrent));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD2BC Offset: 0x6FD2BC VA: 0x6FD2BC
		//// RVA: 0x1852EDC Offset: 0x1852EDC VA: 0x1852EDC
		private IEnumerator Co_ChengeEnemyPower(int vfpId, bool Isinitialize, int vfForm, bool IsCorrent)
		{
			long NextClearTime; // 0x20
			long ChengeTime; // 0x28
			long diffTime; // 0x30
			bool IsMoreEnemyForces; // 0x38

			//0x18539B8
			NextClearTime = KDHGBOOECKC.HHCJCDFCLOB.NPEFMNPOMMJ(ViewOfferInfo.FGHGMHPNEMG_Category, ViewOfferInfo.PPFNGGCBJKC, vfpId, (FKGMGBHBNOC.HPJOCKGKNCC_Form) vfForm, IsCorrent);
			ChengeTime = currntClearTime;
			IsLackPower = ViewOfferInfo.IMPNNOLLMBK < NextClearTime;
			StartLackPowerAnim();
			diffTime = NextClearTime - currntClearTime;
			if(diffTime != 0 && !Isinitialize)
			{
				NextClearTime = NextClearTime * 1000;
				ChengeTime = ChengeTime * 1000;
				IsMoreEnemyForces = NextClearTime < ChengeTime;
				while (true)
				{
					//LAB_01853b70;
					float t = diffTime * 1.0f / (1.0f / Time.deltaTime);
					ChengeTime += (long)(2 * t * 1000);
					if ((!IsMoreEnemyForces && NextClearTime < ChengeTime) || NextClearTime < ChengeTime)
					{
						//LAB_01853c3c
						NextClearTime = NextClearTime / 1000;
						ChengeTime = ChengeTime / 1000;
						break;
					}
					else
					{
						SetenemyDataText((int)ViewOfferInfo.JGAMLEMMJCJ_ClearTime, ChengeTime / 1000);
						yield return null;
					}
				}
			}
			//LAB_01853c74
			SetenemyDataText((int)ViewOfferInfo.JGAMLEMMJCJ_ClearTime, NextClearTime);
			currntClearTime = NextClearTime;
		}

		// RVA: 0x1852FEC Offset: 0x1852FEC VA: 0x1852FEC
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1853078 Offset: 0x1853078 VA: 0x1853078
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1853104 Offset: 0x1853104 VA: 0x1853104
		//public void Hide() { }

		//// RVA: 0x1853180 Offset: 0x1853180 VA: 0x1853180
		//public void Show() { }

		// RVA: 0x18531FC Offset: 0x18531FC VA: 0x18531FC
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlaying();
		}

		//// RVA: 0x1853228 Offset: 0x1853228 VA: 0x1853228
		private void StartLackPowerAnim()
		{
			if (!IsLackPower)
				m_LackPowerFrame.StartChildrenAnimGoStop("02");
			else
			{
				m_LackPowerFrame.StartChildrenAnimGoStop("01");
				m_LackPowerAnim.StartChildrenAnimLoop("lo_");
			}
		}

		//// RVA: 0x18529D8 Offset: 0x18529D8 VA: 0x18529D8
		//private void SetOfferName(string offerName) { }

		//// RVA: 0x1852828 Offset: 0x1852828 VA: 0x1852828
		private void SetRecomValue(int attack, int hit)
		{
			m_Attack.text = attack.ToString();
			m_Hit.text = hit.ToString();
		}

		//// RVA: 0x1852A14 Offset: 0x1852A14 VA: 0x1852A14
		private void SetenemyDataText(int enemyPower, long clearTime)
		{
			int h, m, s;
			OfferSelectScene.GetMiddleTime(enemyPower, out h, out m, out s, true);
			m_EnemyPower.text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
			OfferSelectScene.GetMiddleTime((int)clearTime, out h, out m, out s, true);
			m_OfferClearTime.text = colorChange(string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s), enemyPower, clearTime);
		}

		//// RVA: 0x1853300 Offset: 0x1853300 VA: 0x1853300
		private string colorChange(string label, int enemyPower, long clearTime)
		{
			if(clearTime >= enemyPower)
			{
				if (enemyPower >= clearTime)
					return label;
				return "<color=#FFF000>" + label + "</color>";
			}
			return "<color=#00D2FF>" + label + "</color>";
		}

		//// RVA: 0x18528C0 Offset: 0x18528C0 VA: 0x18528C0
		private void SetofferType(BOPFPIHGJMD.ADMNKELOLPN offerType)
		{
			switch (offerType)
			{
				case BOPFPIHGJMD.ADMNKELOLPN.CCAPCGPIIPF_1:
					m_offerType.StartChildrenAnimGoStop("01");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.NBHIECDDJHH_2:
					m_offerType.StartChildrenAnimGoStop("04");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.HFPIACELNLL_3:
					m_offerType.StartChildrenAnimGoStop("02");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.HIIPBAMPCEM_4:
					m_offerType.StartChildrenAnimGoStop("03");
					break;
				default:
					return;
			}
		}

		//// RVA: 0x1852C24 Offset: 0x1852C24 VA: 0x1852C24
		private void ChengeSeriesLogo(BOPFPIHGJMD.LGEIPIHHNPH seriesIcon)
		{
			if(seriesIcon > BOPFPIHGJMD.LGEIPIHHNPH.HJNNKCMLGFL_0 && seriesIcon <= BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
			{
				if (m_LogoTextureUvNameTable[(int)seriesIcon - 1] == null)
					m_SeriesLog.enabled = false;
				else
				{
					m_SeriesLog.enabled = true;
					m_SeriesLog.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(m_LogoTextureUvNameTable[(int)seriesIcon - 1]));
				}
			}
		}

		// RVA: 0x18533B4 Offset: 0x18533B4 VA: 0x18533B4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList = uvMan.GetTexUVList("sel_vfo_info_pack");
			m_layoutRoot = layout.FindViewByExId("root_s_v_info_sw_s_v_info_anim") as AbsoluteLayout;
			m_offerType = layout.FindViewByExId("sw_s_v_info_swtbl_s_v_frm_type") as AbsoluteLayout;
			m_LackPowerFrame = layout.FindViewByExId("sw_s_v_info_swtbl_s_v_frm_ef_01") as AbsoluteLayout;
			m_LackPowerAnim = layout.FindViewByExId("swtbl_s_v_frm_ef_01_sw_s_v_frm_ef_01_lo") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
