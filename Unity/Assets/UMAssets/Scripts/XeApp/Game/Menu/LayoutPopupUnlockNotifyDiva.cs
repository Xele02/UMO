using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockNotifyDiva : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_divaName; // 0x14
		[SerializeField]
		private Text m_desc; // 0x18
		[SerializeField]
		private RawImageEx m_divaImage; // 0x1C
		private AbsoluteLayout m_logo; // 0x20
		private AbsoluteLayout m_LogoChenge; // 0x24
		private AbsoluteLayout m_divaLogoAnim; // 0x28
		private AbsoluteLayout m_basaraLogoAnim; // 0x2C
		private IEnumerator m_animation; // 0x30
		private bool m_isLoadingDivaImage; // 0x34
		private bool m_IsBasara; // 0x35

		// RVA: 0x1791F24 Offset: 0x1791F24 VA: 0x1791F24
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
			{
				//0x1792ABC
				return info.param.id == _.AHHJLDLAPAN_DivaId;
			});
			int divaId = 0;
			if(diva != null)
			{
				SetDivaName(diva.OPFGFINHFCE_Name);
				SetDivaImage(diva.AHHJLDLAPAN_DivaId);
				divaId = diva.AHHJLDLAPAN_DivaId;
				if(divaId == 9)
				{
					m_LogoChenge.StartAllAnimGoStop("02");
					m_logo = m_basaraLogoAnim;
				}
				else
				{
					m_LogoChenge.StartAllAnimGoStop("01");
					m_logo = m_divaLogoAnim;
				}
			}
			SetDesc(divaId);
		}

		// RVA: 0x1792474 Offset: 0x1792474 VA: 0x1792474
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || m_isLoadingDivaImage;
		}

		// // RVA: 0x17921F8 Offset: 0x17921F8 VA: 0x17921F8
		public void SetDivaImage(int id)
		{
			m_isLoadingDivaImage = true;
			GameManager.Instance.DivaIconCache.LoadStoryIcon(id, 1, (IiconTexture texture) =>
			{
				//0x17929DC
				if(texture != null)
				{
					texture.Set(m_divaImage);
				}
				m_isLoadingDivaImage = false;
			});
		}

		// // RVA: 0x1792134 Offset: 0x1792134 VA: 0x1792134
		public void SetDivaName(string text)
		{
			if(m_divaName != null)
				m_divaName.text = text;
		}

		// // RVA: 0x1792320 Offset: 0x1792320 VA: 0x1792320
		public void SetDesc(int divaId)
		{
			if(m_desc != null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_desc.text = bk.GetMessageByLabel(divaId == 9 ? "popup_unlock_basara_desc_001" : "popup_unlock_diva_desc_001");
			}
		}

		// RVA: 0x1792530 Offset: 0x1792530 VA: 0x1792530
		public void Update()
		{
			if(m_animation != null)
			{
				if(!m_animation.MoveNext())
					m_animation = null;
			}
		}

		// RVA: 0x179260C Offset: 0x179260C VA: 0x179260C
		public void Reset()
		{
			return;
		}

		// RVA: 0x1792610 Offset: 0x1792610 VA: 0x1792610
		public void Show()
		{
			m_animation = null;
			gameObject.SetActive(true);
		}

		// RVA: 0x1792650 Offset: 0x1792650 VA: 0x1792650
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1792688 Offset: 0x1792688 VA: 0x1792688
		public void TitleAnimPlay()
		{
			m_logo.StartAllAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_animation = TitleAnimWait();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x704C0C Offset: 0x704C0C VA: 0x704C0C
		// // RVA: 0x1792760 Offset: 0x1792760 VA: 0x1792760
		private IEnumerator TitleAnimWait()
		{
			//0x1792B30
			while(m_logo.IsPlayingChildren())
				yield return null;
			m_logo.StartAllAnimLoop("logo_up", "loen_up");
		}

		// RVA: 0x179280C Offset: 0x179280C VA: 0x179280C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_LogoChenge = layout.FindViewByExId("sw_pop_diva_join_pop_diva_join_logo_anim") as AbsoluteLayout;
			m_divaLogoAnim = layout.FindViewByExId("swtbl_pop_diva_join_logo_pop_diva_join_logo_anim") as AbsoluteLayout;
			m_basaraLogoAnim = layout.FindViewByExId("swtbl_pop_diva_join_logo_pop_diva_join_logo_anim2") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
