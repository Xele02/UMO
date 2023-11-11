using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System;
using UnityEditor;

namespace XeApp.Game.Menu
{
	public class LayoutPopupOverlapItem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textPrev; // 0x18
		[SerializeField]
		private Text m_textNext; // 0x1C
		[SerializeField]
		private RawImageEx m_imagePlate; // 0x20
		[SerializeField]
		private RawImageEx m_imagePoster; // 0x24
		[SerializeField]
		private ButtonBase m_button; // 0x28
		private AbsoluteLayout m_layoutType; // 0x2C
		private bool m_isLoadingImage; // 0x30
		public Action OnClickButton; // 0x34

		// // RVA: 0x173AFC4 Offset: 0x173AFC4 VA: 0x173AFC4
		// public bool IsLoading() { }

		// RVA: 0x173B070 Offset: 0x173B070 VA: 0x173B070
		public void SetStatus(GONMPHKGKHI_RewardView.CECMLGBLHHG type, GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo info, bool _isKira = false)
		{
			if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8)
			{
				GONMPHKGKHI_RewardView.GCHFDJMNCAF d = info as GONMPHKGKHI_RewardView.GCHFDJMNCAF;
				SetDecoNum(d.GBALGEMKJKD, d.HMGDINKEPHJ);
				SetDecoImage(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(d.DMJCACIDEBM ? EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft : EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef, d.BCCHOBPJJKE_SceneId));
				return;
			}
			if(info.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4)
			{
				SetSubboardNum(info.LBGGNGCKOJE, info.FICKICOHCAD);
			}
			else if(info.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3)
			{
				SetRarity(info.MPGNHFDGOBO, info.HNNAODKJGPD);
			}
			SetPlateImage(info.BCCHOBPJJKE_SceneId, 2, _isKira);
		}

		// // RVA: 0x173B228 Offset: 0x173B228 VA: 0x173B228
		// public void SetStatusDeco(int typeAndId, int prevNum, int nextNum) { }

		// // RVA: 0x173B254 Offset: 0x173B254 VA: 0x173B254
		private void SetRarity(int prev, int next)
		{
			m_textPrev.text = JpStringLiterals.StringLiteral_13959 + prev.ToString();
			m_textNext.text = JpStringLiterals.StringLiteral_13959 + next.ToString();
		}

		// // RVA: 0x173B360 Offset: 0x173B360 VA: 0x173B360
		private void SetSubboardNum(int prev, int next)
		{
			m_layoutType.StartChildrenAnimGoStop("01");
			m_textPrev.text = prev < 10000 ? prev.ToString() : 9999.ToString() + "+";
			m_textNext.text = next < 10000 ? next.ToString() : 9999.ToString() + "+";
		}

		// // RVA: 0x173B6C0 Offset: 0x173B6C0 VA: 0x173B6C0
		private void SetDecoNum(int prev, int next)
		{
			m_layoutType.StartChildrenAnimGoStop("02");
			m_textPrev.text = prev > 999 ? 999.ToString() : prev.ToString();
			m_textNext.text = next > 999 ? 999.ToString() : next.ToString();
		}

		// // RVA: 0x173B4F4 Offset: 0x173B4F4 VA: 0x173B4F4
		private void SetPlateImage(int id, int rank, bool isKira = false)
		{
			m_isLoadingImage = false;
			if(m_imagePlate != null)
			{
				m_isLoadingImage = true;
				GameManager.Instance.SceneIconCache.Load(id, rank, (IiconTexture texture) =>
				{
					//0x1776188
					if(texture != null)
					{
						texture.Set(m_imagePlate);
						SceneIconTextureCache.ChangeKiraMaterial(m_imagePlate, texture as IconTexture, isKira);
					}
					m_isLoadingImage = false;
				});
			}
		}

		// // RVA: 0x173B7F4 Offset: 0x173B7F4 VA: 0x173B7F4
		public void SetDecoImage(int typeAndId)
		{
			m_isLoadingImage = false;
			if(m_imagePoster != null)
			{
				m_isLoadingImage = true;
				GameManager.Instance.ItemTextureCache.Load(typeAndId, 0, (IiconTexture texture) =>
				{
					//0x173BAA8
					if(texture != null)
					{
						texture.Set(m_imagePoster);
					}
					m_isLoadingImage = false;
				});
			}
		}

		// RVA: 0x173B96C Offset: 0x173B96C VA: 0x173B96C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutType = layout.FindViewById("swtbl_pop_overlap_desk") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x173BB88
				if(OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}
	}
}
