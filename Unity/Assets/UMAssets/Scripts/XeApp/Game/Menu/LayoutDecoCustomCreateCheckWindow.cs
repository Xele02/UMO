using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomCreateCheckWindow : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_textAnim; // 0x14
		[SerializeField]
		private RawImageEx m_charactorImage; // 0x18
		[SerializeField]
		private RawImageEx m_serifImage; // 0x1C
		[SerializeField]
		private Text[] m_serifText; // 0x20
		private bool m_isInitialize; // 0x24

		// RVA: 0x19DBC64 Offset: 0x19DBC64 VA: 0x19DBC64
		public bool IsLoading()
		{
			return m_isInitialize && m_charactorImage.enabled && m_serifImage.enabled;
		}

		// RVA: 0x19DBCD0 Offset: 0x19DBCD0 VA: 0x19DBCD0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_textAnim = layout.FindViewByExId("sw_cstm_deco_pop_all_01_swtbl_ballon_text_01") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x19DBDA8 Offset: 0x19DBDA8 VA: 0x19DBDA8
		public void SetStampInfo(int stampId, int serifId)
		{
			NCPPAHHCCAO n = NCPPAHHCCAO.FKDIMODKKJD().Find((NCPPAHHCCAO item) =>
			{
				//0x19DC474
				return stampId == item.PPFNGGCBJKC;
			});
			m_charactorImage.enabled = false;
			MenuScene.Instance.DecorationItemTextureCache.LoadForDecoCustom(n.IDELKEKDIFD_CharaId, n.BEHMEDMNJMC_EmotionId, (IiconTexture image) =>
			{
				//0x19DC4B8
				SetImage(image, m_charactorImage);
				m_charactorImage.enabled = true;
			});
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
			{
				//0x19DC53C
				return serifId == item.PPFNGGCBJKC;
			});
			m_serifImage.enabled = false;
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(s.GBJFNGCDKPM_FrameId, (IiconTexture image) =>
			{
				//0x19DC580
				SetImage(image, m_serifImage);
				m_serifImage.enabled = true;
			});
			s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
			{
				//0x19DC604
				return serifId == item.PPFNGGCBJKC;
			});
			m_textAnim.StartChildrenAnimGoStop(string.Format("{0:D2}", s.LDLGLHBGOKE_FontSize));
			string str = NCPPAHHCCAO.GHHOBKGGADG(serifId);
			for(int i = 0; i < m_serifText.Length; i++)
			{
				m_serifText[i].text = str;
			}
			m_isInitialize = true;
		}

		// RVA: 0x19DC390 Offset: 0x19DC390 VA: 0x19DC390
		private void SetImage(IiconTexture texture, RawImageEx target)
		{
			texture.Set(target);
		}
	}
}
