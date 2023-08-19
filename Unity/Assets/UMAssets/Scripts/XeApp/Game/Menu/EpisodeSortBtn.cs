using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using mcrs;

namespace XeApp.Game.Menu
{
	public class EpisodeSortBtn : LayoutUGUIScriptBase
	{
		public delegate void DelegateChangeSort(SortItem a_item, int a_order);
		public delegate void DelegateChangeOrder(SortItem a_item, int a_order);

		[SerializeField]
		private ActionButton m_btn_01; // 0x14
		[SerializeField]
		private ActionButton m_btn_02; // 0x18
		[SerializeField]
		private RawImageEx m_image_01; // 0x1C
		[SerializeField]
		private RawImageEx m_image_02; // 0x20
		private AbsoluteLayout m_abs; // 0x24
		private TexUVListManager m_uv_man; // 0x28
		public SortItem m_sort = SortItem.None; // 0x2C
		public int m_order; // 0x30
		private bool m_is_save = true; // 0x34
		private static readonly string[] m_uv_order = new string[2] { "cmn_btn_orde_fnt_01", "cmn_btn_orde_fnt_02" }; // 0x0
		private DelegateChangeSort m_delegate_sort; // 0x38
		private DelegateChangeOrder m_delegate_order; // 0x3C
		
		//// RVA: 0xF05D00 Offset: 0xF05D00 VA: 0xF05D00
		public void EnableSave(bool a_is_save)
		{
			m_is_save = a_is_save;
		}

		//// RVA: 0xF05868 Offset: 0xF05868 VA: 0xF05868
		public void SetDelegateChangeSort(DelegateChangeSort a_delegate)
		{
			m_delegate_sort = a_delegate;
		}

		//// RVA: 0xF0584C Offset: 0xF0584C VA: 0xF0584C
		public void SetDelegateChangeOrder(DelegateChangeOrder a_delegate)
		{
			m_delegate_order = a_delegate;
		}

		// RVA: 0xF08248 Offset: 0xF08248 VA: 0xF08248 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uv_man = uvMan;
			m_abs = layout.FindViewById("sw_sel_ep_sort_bth_anim") as AbsoluteLayout;
			m_btn_01.AddOnClickCallback(OnButtonSort);
			m_btn_02.AddOnClickCallback(OnButtonOrder);
			return true;
		}

		// RVA: 0xF083D4 Offset: 0xF083D4 VA: 0xF083D4
		private void Start()
		{
			return;
		}

		// RVA: 0xF083D8 Offset: 0xF083D8 VA: 0xF083D8
		private void Update()
		{
			return;
		}

		// RVA: 0xF083DC Offset: 0xF083DC VA: 0xF083DC
		private void LateUpdate()
		{
			return;
		}

		//// RVA: 0xF06160 Offset: 0xF06160 VA: 0xF06160
		public void Enter()
		{
			ChangeButtonOrder(m_order);
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0xF062B0 Offset: 0xF062B0 VA: 0xF062B0
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xF08544 Offset: 0xF08544 VA: 0xF08544
		//public bool IsPlaying() { }

		//// RVA: 0xF0633C Offset: 0xF0633C VA: 0xF0633C
		//public void Release() { }

		//// RVA: 0xF0854C Offset: 0xF0854C VA: 0xF0854C
		private void OnButtonSort()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.CDOOMPPEINP() ? PopupFilterSort.Scene.EpisodeSelect2 : PopupFilterSort.Scene.EpisodeSelect, (PopupFilterSort content) =>
			{
				//0xF08F3C
				if(m_delegate_sort != null)
				{
					m_sort = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.LHPDCGNKPHD_sortItem;
					m_delegate_sort(m_sort, m_order);
				}
			}, null, m_is_save);
		}

		//// RVA: 0xF08738 Offset: 0xF08738 VA: 0xF08738
		private void OnButtonOrder()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_order = m_order == 0 ? 1 : 0;
			ChangeButtonOrder(m_order);
			if(m_is_save)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.EILKGEADKGH_order = m_order;
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}
			if(m_delegate_order != null)
				m_delegate_order(m_sort, m_order);
		}

		//// RVA: 0xF08DA8 Offset: 0xF08DA8 VA: 0xF08DA8
		//private int ConvertSortItem(SortItem a_item) { }

		//// RVA: 0xF083E0 Offset: 0xF083E0 VA: 0xF083E0
		private void ChangeButtonOrder(int a_order)
		{
			m_image_02.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uv_man.GetUVData(m_uv_order[a_order]));
		}
	}
}
