using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ValkyrieStatusParam : LayoutUGUIScriptBase
	{
		private enum Flags
		{
			PilotLoaded = 1,
			ValkyrieLoaded = 2,
			SeriesLogo = 4,
			All = 7,
		}

		[SerializeField]
		private RawImageEx m_valkrieImage; // 0x14
		[SerializeField]
		private RawImageEx m_pilotImage; // 0x18
		[SerializeField]
		private RawImageEx m_logoImage; // 0x1C
		[SerializeField]
		private RawImageEx m_valAtkImage; // 0x20
		[SerializeField]
		private RawImageEx m_valHitImage; // 0x24
		[SerializeField]
		private Text m_robotName; // 0x28
		[SerializeField]
		private Text m_pilotName; // 0x2C
		[SerializeField]
		private Text m_attackText; // 0x30
		[SerializeField]
		private Text m_hitText; // 0x34
		private AbsoluteLayout m_iconAdjustAnimeLayout; // 0x38
		private byte m_flags; // 0x3C

		// RVA: 0x16667EC Offset: 0x16667EC VA: 0x16667EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_iconAdjustAnimeLayout = layout.FindViewByExId("sw_valkyrie_icon_valkyrie_icon") as AbsoluteLayout;
			ClearLoadedCallback();
			EnableImageValAtk(false);
			EnableImageValHit(false);
			return true;
		}

		// RVA: 0x1666A54 Offset: 0x1666A54 VA: 0x1666A54
		public void UpdateContent(PNGOLKLFFLH valkyrieData, NHDJHOPLMDE valkyrieAbilityData)
		{
			m_robotName.text = valkyrieData.IJBLEJOKEFH_ValkyrieName;
			m_pilotName.text = valkyrieData.OPBPKNHIPPE_Pilot.OPFGFINHFCE_Name;
			m_attackText.text = valkyrieData.KINFGHHNFCF_Atk.ToString();
			EnableImageValAtk(false);
			m_hitText.text = valkyrieData.NONBCCLGBAO_Hit.ToString();
			EnableImageValHit(false);
			if(valkyrieAbilityData != null)
			{
				if(valkyrieAbilityData.KINFGHHNFCF_Atk > 0)
				{
					m_attackText.text = RichTextUtility.MakeColorTagString((valkyrieData.KINFGHHNFCF_Atk + valkyrieAbilityData.KINFGHHNFCF_Atk).ToString(), StatusTextColor.UpColor);
					EnableImageValAtk(true);
				}
				if(valkyrieAbilityData.NONBCCLGBAO_Hit > 0)
				{
					m_hitText.text = RichTextUtility.MakeColorTagString((valkyrieData.NONBCCLGBAO_Hit + valkyrieAbilityData.NONBCCLGBAO_Hit).ToString(), StatusTextColor.UpColor);
					EnableImageValHit(true);
				}
			}
			m_flags = 0;
			GameManager.Instance.ValkyrieIconCache.Load(valkyrieData.GPPEFLKGGGJ_ValkyrieId, 0, (IiconTexture texture) =>
			{
				//0x1667074
				texture.Set(m_valkrieImage);
				m_flags |= (byte)Flags.ValkyrieLoaded;
			});
			GameManager.Instance.PilotTextureCache.Load(valkyrieData.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, (IiconTexture texture) =>
			{
				//0x1667160
				texture.Set(m_pilotImage);
				m_flags |= (byte)Flags.PilotLoaded;
			});
			int serie = valkyrieData.AIHCEGFANAM_Serie;
			if (serie == 5)
				serie = 10;
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(serie, (IiconTexture texture) =>
			{
				//0x166724C
				texture.Set(m_logoImage);
				m_flags |= (byte)Flags.SeriesLogo;
			});
			m_iconAdjustAnimeLayout.StartAnimGoStop("01");
		}

		// RVA: 0x1667058 Offset: 0x1667058 VA: 0x1667058
		public bool IsReady()
		{
			return m_flags == (byte)Flags.All;
		}

		//// RVA: 0x16668DC Offset: 0x16668DC VA: 0x16668DC
		private void EnableImageValAtk(bool a_enable)
		{
			if (m_valAtkImage != null)
				m_valAtkImage.enabled = a_enable;
		}

		//// RVA: 0x1666998 Offset: 0x1666998 VA: 0x1666998
		private void EnableImageValHit(bool a_enable)
		{
			if (m_valHitImage != null)
				m_valHitImage.enabled = a_enable;
		}
	}
}
