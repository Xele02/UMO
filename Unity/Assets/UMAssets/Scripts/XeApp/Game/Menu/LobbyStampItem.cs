using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyStampItem : SwapScrollListContent
	{
		public enum StampWordType
		{
			SHORT = 0,
			MIDDLE = 1,
			LONG = 2,
			MAX = 3,
		}

		public const int TEXT_WORD_SHORT = 6;
		public const int TEXT_WORD_MIDDLE = 9;
		public const int TEXT_WORD_LONG = 21;
		[SerializeField]
		private RawImageEx m_charaStampIcon; // 0x20
		[SerializeField]
		private RawImageEx m_messgeBalloon; // 0x24
		[SerializeField]
		private ActionButton m_button; // 0x28
		[SerializeField]
		private Text[] m_stampMesList = new Text[3]; // 0x2C
		private AbsoluteLayout m_stampTypeChange; // 0x30
		private LobbyStampItem.StampWordType m_wordType; // 0x34
		private int m_stampId; // 0x38
		private int m_serifId; // 0x3C

		//public int StampID { get; private set; } 0xD2094C 0xD20954
		//public int SerifID { get; private set; } 0xD2095C 0xD20964
		public bool IsLoadedTexture { get; protected set; } // 0x40
		public Action OnStampClickButton { get; set; } // 0x44

		// RVA: 0xD2098C Offset: 0xD2098C VA: 0xD2098C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_stampTypeChange = layout.FindViewByExId("sw_dc_cstm_01_txt_02") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0xD21300
				if (OnStampClickButton != null)
					OnStampClickButton();
			});
			Loaded();
			return true;
		}

		// RVA: 0xD20AC0 Offset: 0xD20AC0 VA: 0xD20AC0
		private void LoadIconTexture(int stampId)
		{
			m_stampId = stampId;
			IsLoadedTexture = false;
			NCPPAHHCCAO n = NCPPAHHCCAO.FKDIMODKKJD().Find((NCPPAHHCCAO item) =>
			{
				//0xD21314
				return item.PPFNGGCBJKC == m_stampId;
			});
			MenuScene.Instance.DecorationItemTextureCache.LoadForDecoCustom(n.IDELKEKDIFD_CharaId, n.BEHMEDMNJMC_EmotionId, (IiconTexture image) =>
			{
				//0xD21358
				SetDecoCharImageIcon(image);
				IsLoadedTexture = true;
			});
		}

		//// RVA: 0xD20CB8 Offset: 0xD20CB8 VA: 0xD20CB8
		private void SetDecoCharImageIcon(IiconTexture texture)
		{
			if (texture == null)
				return;
			texture.Set(m_charaStampIcon);
		}

		// RVA: 0xD20D94 Offset: 0xD20D94 VA: 0xD20D94
		private void LoadtBallonTexture(int serifId)
		{
			m_serifId = serifId;
			IsLoadedTexture = false;
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP stamp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
			{
				//0xD21374
				return item.PPFNGGCBJKC == m_serifId;
			});
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(stamp.GBJFNGCDKPM_FrameId, (IiconTexture image) =>
			{
				//0xD213B8
				SetStampBallonImageIcon(image);
				IsLoadedTexture = true;
			});
			string str = NCPPAHHCCAO.GHHOBKGGADG(m_serifId);
			for(int i = 0; i < m_stampMesList.Length; i++)
			{
				m_stampMesList[i].text = str;
			}
			KDKFHGHGFEK data = new KDKFHGHGFEK();
			data.KHEKNNFCAOI(m_serifId, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif);
			m_stampTypeChange.StartChildrenAnimGoStop(data.DBGAJBIBODC.ToString("D2"));
		}

		//// RVA: 0xD2118C Offset: 0xD2118C VA: 0xD2118C
		public void CopyData(int stampId, int serifId)
		{
			LoadIconTexture(stampId);
			LoadtBallonTexture(serifId);
		}

		//// RVA: 0xD211B0 Offset: 0xD211B0 VA: 0xD211B0
		private void SetStampBallonImageIcon(IiconTexture texture)
		{
			if (texture == null)
				return;
			texture.Set(m_messgeBalloon);
		}
	}
}
