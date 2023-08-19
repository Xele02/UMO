using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GrowthNeedItemIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_iconImage; // 0x14
		[SerializeField]
		private NumberBase m_number; // 0x18
		[SerializeField]
		private Text m_haveText; // 0x1C
		[SerializeField]
		private StayButton m_button; // 0x20
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve; // 0x24
		private AbsoluteLayout m_iconBackColorLayout; // 0x28
		private AbsoluteLayout m_panelColorLayout; // 0x2C
		private Color m_baseColor; // 0x30
		private Color m_lackColor; // 0x40
		private int m_growItemId; // 0x50
		private int m_growItemCount; // 0x54
		private bool m_isLack; // 0x58

		// RVA: 0xE24D5C Offset: 0xE24D5C VA: 0xE24D5C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_iconBackColorLayout = layout.FindViewByExId("sw_btn_item_anim_sw_item_frm_anim") as AbsoluteLayout;
			m_panelColorLayout = layout.FindViewByExId("sw_btn_item_anim_swtbl_cmn_icon_base_4") as AbsoluteLayout;
			m_button.AddOnStayCallback(OnGrowItemDetails);
			m_button.AddOnClickCallback(OnGrowItemDetails);
			m_baseColor = SystemTextColor.GetLackColor();
			m_lackColor = SystemTextColor.GetImportantYellowColor();
			m_haveText.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_haveText.verticalOverflow = VerticalWrapMode.Truncate;
			m_haveText.resizeTextForBestFit = true;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0xE25040 Offset: 0xE25040 VA: 0xE25040
		public void SetIcon(int growthItemId)
		{
			m_growItemId = growthItemId;
			MenuScene.Instance.ItemTextureCache.Load(growthItemId, (IiconTexture texture) =>
			{
				//0xE25578
				texture.Set(m_iconImage);
			});
		}

		//// RVA: 0xE25154 Offset: 0xE25154 VA: 0xE25154
		public void SetNeedCount(int count)
		{
			m_number.SetNumber(count, 0);
		}

		//// RVA: 0xE25194 Offset: 0xE25194 VA: 0xE25194
		public void SetHaveCount(int count, int needCount)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_haveText.text = string.Format(bk.GetMessageByLabel("growth_popup_text01"), count);
			m_isLack = count < needCount;
			m_growItemCount = count;
		}

		//// RVA: 0xE252D8 Offset: 0xE252D8 VA: 0xE252D8
		public void SetLack(bool isLack)
		{
			m_iconBackColorLayout.StartChildrenAnimGoStop(isLack ? "02" : "01");
			m_panelColorLayout.StartChildrenAnimGoStop(isLack ? "02" : "01");
		}

		//// RVA: 0xE25394 Offset: 0xE25394 VA: 0xE25394
		private void OnGrowItemDetails()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowItemDetail(m_growItemId, m_growItemCount, null);
		}

		//// RVA: 0xE254A0 Offset: 0xE254A0 VA: 0xE254A0
		public void UpdateFontColor(float time)
		{
			if(m_isLack)
			{
				float f = m_animeCurve[0].Evaluate(time);
				m_haveText.color = Color.Lerp(m_lackColor, m_baseColor, f);
			}
		}
	}
}
