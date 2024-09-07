using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupOverlapSingle : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textPrev; // 0x14
		[SerializeField]
		private Text m_textNext; // 0x18
		[SerializeField]
		private Text m_textDesc; // 0x1C
		[SerializeField]
		private Text m_textLimit; // 0x20
		[SerializeField]
		private RawImageEx m_imagePlate; // 0x24
		[SerializeField]
		private RawImageEx m_imagePoster; // 0x28
		[SerializeField]
		private ButtonBase m_button; // 0x2C
		private AbsoluteLayout m_root; // 0x30
		private bool m_isLoadingImage; // 0x34
		public Action OnClickButton; // 0x38

		// // RVA: 0x17762FC Offset: 0x17762FC VA: 0x17762FC
		// public bool IsLoading() { }

		// RVA: 0x17763A8 Offset: 0x17763A8 VA: 0x17763A8
		public void SetStatus(GONMPHKGKHI_RewardView.CECMLGBLHHG type, GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo info, Text titleText, bool _isKira = false)
		{
			if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8)
			{
                GONMPHKGKHI_RewardView.GCHFDJMNCAF a = info as GONMPHKGKHI_RewardView.GCHFDJMNCAF;
                SetStatusDeco(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(a.DMJCACIDEBM ? EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft : EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef, info.BCCHOBPJJKE_SceneId), a.GBALGEMKJKD_PrevBoard, a.HMGDINKEPHJ_NextBoard, titleText);
			}
			else
			{
				if(info.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4)
				{
					SetSubboardNum(info.LBGGNGCKOJE_PrevNumBoard, info.FICKICOHCAD_NextNumBoard);
					m_root.StartChildrenAnimGoStop("02");
				}
				else if(info.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3)
				{
					SetRarity(info.MPGNHFDGOBO_PrevRarity, info.HNNAODKJGPD_NextRarity);
					m_root.StartChildrenAnimGoStop("01");
				}
				SetPlateImage(info.BCCHOBPJJKE_SceneId, 2, _isKira);
			}
		}

		// // RVA: 0x17765AC Offset: 0x17765AC VA: 0x17765AC
		public void SetStatusDeco(int typeAndId, int prevNum, int nextNum, Text titleText)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeAndId);
			string str = "";
            if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef && cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				str = "deco_name_poster";
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure)
			{
				str = "deco_name_figure";
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso)
			{
				str = "deco_name_torso";
			}
			titleText.text = string.Format(bk.GetMessageByLabel("pop_deco_get_title"), bk.GetMessageByLabel(str));
			m_textDesc.text = string.Format(bk.GetMessageByLabel("pop_deco_get_desc"), bk.GetMessageByLabel(str));
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef && cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				m_textLimit.text = string.Format(bk.GetMessageByLabel("pop_deco_get_limit"), bk.GetMessageByLabel(str), EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, 1, null));
			}
			else
			{
				m_textLimit.text = "";
			}
			m_root.StartChildrenAnimGoStop("03");
			SetDecoNum(prevNum, nextNum);
			SetDecoImage(typeAndId);
		}

		// // RVA: 0x1776A78 Offset: 0x1776A78 VA: 0x1776A78
		public void SetRarity(int prev, int next)
		{
			m_textPrev.text = JpStringLiterals.StringLiteral_13959 + prev.ToString();
			m_textNext.text = JpStringLiterals.StringLiteral_13959 + next.ToString();
		}

		// // RVA: 0x1776B84 Offset: 0x1776B84 VA: 0x1776B84
		private void SetSubboardNum(int prev, int next)
		{
			string str = "";
			string str2 = "";
			if(prev < 10000)
				str = prev.ToString();
			else
				str = 9999.ToString() + "+";
			if(next < 10000)
				str2 = next.ToString();
			else
				str2 = 9999.ToString() + "+";
			m_textPrev.text = str;
			m_textNext.text = str2;
		}

		// // RVA: 0x17770E8 Offset: 0x17770E8 VA: 0x17770E8
		// private void SetKiraUpGrade(int prev, int next) { }

		// // RVA: 0x1776EB4 Offset: 0x1776EB4 VA: 0x1776EB4
		private void SetDecoNum(int prev, int next)
		{
			m_textPrev.text = prev > 999 ? 999.ToString() : prev.ToString();
			m_textNext.text = next > 999 ? 999.ToString() : next.ToString();
		}

		// // RVA: 0x1776CE8 Offset: 0x1776CE8 VA: 0x1776CE8
		public void SetPlateImage(int id, int rank, bool isKira)
		{
			m_isLoadingImage = false;
			if(m_imagePlate != null)
			{
				m_isLoadingImage = true;
				GameManager.Instance.SceneIconCache.Load(id, rank, (IiconTexture texture) =>
				{
					//0x177749C
					if(texture != null)
					{
						texture.Set(m_imagePlate);
						SceneIconTextureCache.ChangeKiraMaterial(m_imagePlate, texture as IconTexture, isKira);
					}
					m_isLoadingImage = false;
				});
			}
		}

		// // RVA: 0x1776F70 Offset: 0x1776F70 VA: 0x1776F70
		public void SetDecoImage(int typeAndId)
		{
			m_isLoadingImage = false;
			if(m_imagePoster != null)
			{
				m_isLoadingImage = true;
				GameManager.Instance.ItemTextureCache.Load(typeAndId, 0, (IiconTexture texture) =>
				{
					//0x17773A8
					if(texture != null)
					{
						texture.Set(m_imagePoster);
					}
					m_isLoadingImage = false;
				});
			}
		}

		// RVA: 0x177726C Offset: 0x177726C VA: 0x177726C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewById("swtbl_pop_overlap_s") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x1777488
				if(OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}
	}
}
