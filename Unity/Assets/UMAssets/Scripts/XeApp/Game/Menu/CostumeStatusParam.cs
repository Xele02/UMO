using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CostumeStatusParam : LayoutUGUIScriptBase
	{
		private enum Flags
		{
			Loaded_Diva = 1,
			Loaded_Costume = 2,
			Loaded_SeriesLogo = 4,
			All = 7,
		}

		[SerializeField]
		private RawImageEx m_image_cos; // 0x14
		[SerializeField]
		private RawImageEx m_image_diva; // 0x18
		[SerializeField]
		private RawImageEx m_image_logo; // 0x1C
		[SerializeField]
		private Text m_txt_name; // 0x20
		[SerializeField]
		private Text m_txt_effect_01; // 0x24
		[SerializeField]
		private Text m_txt_effect_02; // 0x28
		private byte m_flags; // 0x2C

		// RVA: 0x16E81F0 Offset: 0x16E81F0 VA: 0x16E81F0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x16E8208 Offset: 0x16E8208 VA: 0x16E8208
		public void UpdateContent(CKFGMNAIBNG a_data, int a_color)
		{
			if(a_data != null)
			{
				FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
				{
					//0x16E8998
					return _.AHHJLDLAPAN_DivaId == a_data.AHHJLDLAPAN_DivaId;
				});
				if(diva != null)
				{
					m_flags = 0;
					m_txt_name.text = a_data.HCPCHEPCFEA_GetCostumeName(a_color);
					string[] strs = a_data.FCEGELPJAMH_SkillDesc.Replace("\r\n", "\n").Split(new char[] { '\n' });
					if(strs.Length < 2)
					{
						if(strs.Length == 1)
						{
							m_txt_effect_01.text = strs[0];
							m_txt_effect_02.text = "";
						}
						else
						{
							m_txt_effect_01.text = "---";
							m_txt_effect_02.text = "";
						}
					}
					else
					{
						m_txt_effect_01.text = strs[0];
						m_txt_effect_02.text = strs[1];
					}
					GameManager.Instance.CostumeIconCache.Load(a_data.AHHJLDLAPAN_DivaId, a_data.DAJGPBLEEOB_PrismCostumeId, a_color, (IiconTexture texture) =>
					{
						//0x16E89F0
						texture.Set(m_image_cos);
						m_image_cos.enabled = true;
						m_flags |= (int)Flags.Loaded_Costume;
					});
					GameManager.Instance.DivaIconCache.LoadDivaUpIco(a_data.AHHJLDLAPAN_DivaId, a_data.DAJGPBLEEOB_PrismCostumeId, a_color, (IiconTexture texture) =>
					{
						//0x16E8B50
						texture.Set(m_image_diva);
						m_flags |= (int)Flags.Loaded_Diva;
					});
					GameManager.Instance.MenuResidentTextureCache.LoadLogo(diva.AIHCEGFANAM_Serie, (IiconTexture texture) =>
					{
						//0x16E8C78
						texture.Set(m_image_logo);
						m_flags |= (int)Flags.Loaded_SeriesLogo;
					});
				}
			}
		}

		// RVA: 0x16E897C Offset: 0x16E897C VA: 0x16E897C
		public bool IsReady()
		{
			return m_flags == (int)Flags.All;
		}
	}
}
