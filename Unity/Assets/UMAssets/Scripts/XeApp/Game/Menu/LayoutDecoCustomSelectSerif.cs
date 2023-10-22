using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomSelectSerif : LayoutDecoCustomSelectItemBase
	{
		public static readonly string AssetName = "root_cstm_deco_item_02_layout_root"; // 0x0
		private AbsoluteLayout m_textPatternAnim; // 0x50
		[SerializeField]
		private Text[] m_text; // 0x54
		private int m_SerifId; // 0x58

		// RVA: 0x19DD654 Offset: 0x19DD654 VA: 0x19DD654
		public void Update()
		{
			return;
		}

		// RVA: 0x19DD658 Offset: 0x19DD658 VA: 0x19DD658 Slot: 7
		public override void AnimUpdateAll()
		{
			base.AnimUpdateAll();
			m_textPatternAnim.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_textPatternAnim.UpdateAll(new Matrix23(), Color.white);
		}

		// RVA: 0x19DD708 Offset: 0x19DD708 VA: 0x19DD708 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootLayout = layout.FindViewById("sw_deco_item_02") as AbsoluteLayout;
			m_textPatternAnim = layout.FindViewByExId("sw_cstm_deco_item_02_swtbl_ballon_text") as AbsoluteLayout;
			m_textPatternAnim.StartChildrenAnimGoStop("01");
			for(int i = 0; i < m_text.Length; i++)
			{
				m_text[i].text = "";
			}
			Loaded();
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// RVA: 0x19DD928 Offset: 0x19DD928 VA: 0x19DD928 Slot: 6
		public override void LoadTexture()
		{
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP n = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
			{
				//0x19DDDE4
				return item.PPFNGGCBJKC == Id;
			});
			int id = Id;
			m_SerifId = n.GBJFNGCDKPM_FrameId;
			int attrId = m_SerifId;
			SetSerifEnable(false);
			SetTextEnable(false);
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(m_SerifId, (IiconTexture image) =>
			{
				//0x19DDE28
				if(m_SerifId == attrId)
				{
					IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP n2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
					{
						//0x19DE044
						return item.PPFNGGCBJKC == id;
					});
					m_textPatternAnim.StartChildrenAnimGoStop(string.Format("{0:D2}", n2.LDLGLHBGOKE_FontSize));
					SetText(NCPPAHHCCAO.GHHOBKGGADG(Id));
					SetImage(image);
				}
			});
		}

		//// RVA: 0x19DDCC8 Offset: 0x19DDCC8 VA: 0x19DDCC8
		public void SetText(string text)
		{
			for(int i = 0; i < m_text.Length; i++)
			{
				m_text[i].text = text;
			}
		}

		//// RVA: 0x19DDC10 Offset: 0x19DDC10 VA: 0x19DDC10
		private void SetTextEnable(bool _enable)
		{
			for(int i = 0; i < m_text.Length; i++)
			{
				m_text[i].gameObject.SetActive(_enable);
			}
		}
	}
}
