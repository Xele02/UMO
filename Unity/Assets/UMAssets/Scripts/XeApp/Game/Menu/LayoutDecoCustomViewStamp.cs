using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomViewStamp : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_rootLayout; // 0x14
		private AbsoluteLayout m_textAnim; // 0x18
		[SerializeField]
		private RawImageEx m_charactorImage; // 0x1C
		[SerializeField]
		private RawImageEx m_serifImage; // 0x20
		[SerializeField]
		private Text[] m_serifText; // 0x24
		private int m_charaId; // 0x28
		private int m_emotionId; // 0x2C

		public bool IsCharaTexLoad { get { return m_charactorImage.enabled; } } //0x19E3218
		public bool IsSerifTexLoad { get { return m_serifImage.enabled; } } //0x19E3244

		// RVA: 0x19E3270 Offset: 0x19E3270 VA: 0x19E3270 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootLayout = layout.FindViewByExId("root_cstm_deco_item_stamp_swtbl_cstm_deco_item_stamp") as AbsoluteLayout;
			m_rootLayout.StartChildrenAnimGoStop("02", "02");
			m_textAnim = layout.FindViewByExId("sw_cmn_item_balloon_anim_swtbl_ballon_text_04") as AbsoluteLayout;
			return true;
		}

		//// RVA: 0x19E33E4 Offset: 0x19E33E4 VA: 0x19E33E4
		public void SetImage(IiconTexture texture, RawImageEx target)
		{
			texture.Set(target);
		}

		//// RVA: 0x19E34C0 Offset: 0x19E34C0 VA: 0x19E34C0
		public void CharaSelect()
		{
			m_rootLayout.StartChildrenAnimGoStop("01", "01");
		}

		//// RVA: 0x19E3540 Offset: 0x19E3540 VA: 0x19E3540
		public void SerifSelect()
		{
			m_rootLayout.StartChildrenAnimGoStop("02", "02");
		}

		//// RVA: 0x19E35C0 Offset: 0x19E35C0 VA: 0x19E35C0
		public void Hide()
		{
			m_rootLayout.enabled = false;
		}

		//// RVA: 0x19E35F8 Offset: 0x19E35F8 VA: 0x19E35F8
		public void Show()
		{
			m_rootLayout.enabled = true;
		}

		//// RVA: 0x19E3630 Offset: 0x19E3630 VA: 0x19E3630
		public void SetTexCharactor(int stampId)
		{
			NCPPAHHCCAO n = NCPPAHHCCAO.FKDIMODKKJD().Find((NCPPAHHCCAO item) =>
			{
				//0x19E3DF8
				return stampId == item.PPFNGGCBJKC;
			});
			if(m_charaId == n.IDELKEKDIFD_CharaId)
			{
				if(m_emotionId == n.BEHMEDMNJMC_EmotionId)
				{
					return;
				}
			}
			m_charaId = n.IDELKEKDIFD_CharaId;
			m_emotionId = n.BEHMEDMNJMC_EmotionId;
			m_charactorImage.enabled = false;
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectedDecoCustom(m_charaId, m_emotionId, (IiconTexture image) =>
			{
				//0x19E3E3C
				SetImage(image, m_charactorImage);
				m_charactorImage.enabled = true;
			});

		}

		//// RVA: 0x19E3930 Offset: 0x19E3930 VA: 0x19E3930
		public void SetTexSerif(int serifId)
		{
			if(serifId != 0)
			{
				SerifSelect();
				SerifSetting(serifId);
			}
			else
			{
				CharaSelect();
			}
		}

		//// RVA: 0x19E396C Offset: 0x19E396C VA: 0x19E396C
		private void SerifSetting(int serifId)
		{
			m_serifImage.enabled = false;
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP n = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
			{
				//0x19E3EC0
				return item.PPFNGGCBJKC == serifId;
			});
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(n.GBJFNGCDKPM_FrameId, (IiconTexture image) =>
			{
				//0x19E3F04
				m_serifImage.enabled = true;
				SetImage(image, m_serifImage);
			});
			n = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
			{
				//0x19E3F88
				return item.PPFNGGCBJKC == serifId;
			});
			m_textAnim.StartChildrenAnimGoStop(string.Format("{0:D2}", n.LDLGLHBGOKE_FontSize));
			string s = NCPPAHHCCAO.GHHOBKGGADG(serifId);
			for(int i = 0; i < m_serifText.Length; i++)
			{
				m_serifText[i].text = s;
			}
		}
	}
}
