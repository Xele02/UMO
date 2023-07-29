using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class DivaGrowthStatusWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_statusTexts; // 0x14
		[SerializeField]
		private RawImageEx m_divaImage; // 0x18
		[SerializeField]
		private ActionButton m_detailButton; // 0x1C
		public Action OnClickDetailButtonListener; // 0x20
		private DivaIconDecoration m_divaIconDecoration; // 0x24

		// RVA: 0x17DFF1C Offset: 0x17DFF1C VA: 0x17DFF1C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_divaIconDecoration = new DivaIconDecoration();
			ClearLoadedCallback();
			m_detailButton.AddOnClickCallback(() =>
			{
				//0x17E06DC
				if(OnClickDetailButtonListener != null)
					OnClickDetailButtonListener();
			});
			return true;
		}

		//// RVA: 0x17DFFF4 Offset: 0x17DFFF4 VA: 0x17DFFF4
		public void InitializeDecoration()
		{
			m_divaIconDecoration.Initialize(m_divaImage.gameObject, DivaIconDecoration.Size.L, true, false, null, null);
		}

		//// RVA: 0x17E0064 Offset: 0x17E0064 VA: 0x17E0064
		public void ReleaseDecoration()
		{
			m_divaIconDecoration.Release();
		}

		//// RVA: 0x17E008C Offset: 0x17E008C VA: 0x17E008C
		public void UpdateContent(FFHPBEPOMAK_DivaInfo divaData, DFKGGBMFFGB_PlayerInfo playerData)
		{
			MenuScene.Instance.DivaIconCache.LoadPortraitIcon(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, divaData.EKFONBFDAAP_ColorId, (IiconTexture texture) =>
			{
				//0x17E06F0
				texture.Set(m_divaImage);
			});
			m_statusTexts[6].text = divaData.JLJGCBOHJID_Status.Total.ToString();
			m_statusTexts[5].text = divaData.JLJGCBOHJID_Status.soul.ToString();
			m_statusTexts[4].text = divaData.JLJGCBOHJID_Status.vocal.ToString();
			m_statusTexts[3].text = divaData.JLJGCBOHJID_Status.charm.ToString();
			m_statusTexts[2].text = divaData.JLJGCBOHJID_Status.life.ToString();
			m_statusTexts[1].text = divaData.JLJGCBOHJID_Status.support.ToString();
			m_statusTexts[0].text = divaData.JLJGCBOHJID_Status.fold.ToString();
			m_divaIconDecoration.Change(divaData, playerData, DisplayType.Level);
		}
	}
}
