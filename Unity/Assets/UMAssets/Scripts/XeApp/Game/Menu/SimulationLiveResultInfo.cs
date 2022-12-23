using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SimulationLiveResultInfo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_Anim; // 0x14
		private AbsoluteLayout m_LayoutSwitch; // 0x18
		[SerializeField]
		private ActionButton m_musicBtn; // 0x1C
		[SerializeField]
		private ActionButton m_animeStoreBtn; // 0x20
		[SerializeField]
		private Text m_musicTitle; // 0x24
		[SerializeField]
		private Text m_musicInfo; // 0x28
		[SerializeField]
		private Text m_animeTitle; // 0x2C
		[SerializeField]
		private RawImageEx m_cdJakt; // 0x30
		[SerializeField]
		private RawImageEx m_banner; // 0x34
		private bool m_isLoadingImage; // 0x38
		private Rect[] m_rectArray; // 0x3C
		private Action m_OnClickMusicCallback; // 0x40
		private Action m_OnClickAnimeStoreCallback; // 0x44

		public Action OnClickMusicButton { set { m_OnClickMusicCallback = value; } } //0xC4E700
		public Action OnClickAnimeStoreButton { set { m_OnClickAnimeStoreCallback = value; } } //0xC4E708

		// RVA: 0xC4E710 Offset: 0xC4E710 VA: 0xC4E710 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewById("sw_g_res_simu_win_anim") as AbsoluteLayout;
			m_LayoutSwitch = layout.FindViewById("swtbl_g_res_simu_win") as AbsoluteLayout;
			m_musicBtn.AddOnClickCallback(() =>
			{
				//0xC4F3A8
				if (m_OnClickMusicCallback != null)
					m_OnClickMusicCallback();
			});
			m_animeStoreBtn.AddOnClickCallback(() =>
			{
				//0xC4F3BC
				if (m_OnClickAnimeStoreCallback != null)
					m_OnClickAnimeStoreCallback();
			});
			StringBuilder str = new StringBuilder();
			m_rectArray = new Rect[4];
			for(int i = 0; i < m_rectArray.Length; i++)
			{
				str.Clear();
				str.AppendFormat("game_res_simu_a{0:D2}", (i + 1));
				m_rectArray[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString()));
			}
			Loaded();
			return true;
		}

		//// RVA: g Offset: 0xC4EB2C VA: 0xC4EB2C
		public void Setup(int bannerId, MusicTextDatabase.TextInfo musicTextInfo)
		{
			m_musicTitle.text = Database.Instance.selectedMusic.GetSelectedMusicData().NBKFBCLDGAL_OfficialName;
			m_musicTitle.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_musicTitle.verticalOverflow = VerticalWrapMode.Truncate;
			m_musicTitle.resizeTextForBestFit = true;
			m_musicInfo.text = Database.Instance.selectedMusic.GetSelectedMusicData().KLMPFGOCBHC_Description;
			m_animeTitle.text = GetAnimName(Database.Instance.selectedMusic.GetSelectedMusicData().AIHCEGFANAM_Serie - 1);
			SetDetailCD(Database.Instance.selectedMusic.GetSelectedMusicData().NNHOBFBCIIJ_Cd);
			if (bannerId == 0)
				m_LayoutSwitch.StartChildrenAnimGoStop(1, 1);
			else
			{
				m_LayoutSwitch.StartChildrenAnimGoStop(0, 0);
				m_banner.uvRect = m_rectArray[bannerId - 1];
			}
			m_musicBtn.Hidden = !musicTextInfo.isEnableBuyURL;
		}

		//// RVA: 0xC4F0C8 Offset: 0xC4F0C8 VA: 0xC4F0C8
		//public void SetCD(int coverId) { }

		//// RVA: 0xC4EFB0 Offset: 0xC4EFB0 VA: 0xC4EFB0
		public void SetDetailCD(int cdId)
		{
			m_isLoadingImage = true;
			GameManager.Instance.MusicJacketTextureCache.LoadDetail(cdId, (IiconTexture icon) =>
			{
				//0xC4F4B8
				icon.Set(m_cdJakt);
				m_isLoadingImage = false;
			});
		}

		//// RVA: 0xC4EE10 Offset: 0xC4EE10 VA: 0xC4EE10
		public static string GetAnimName(int id)
		{
			switch(id)
			{
				case 0:
					return MessageManager.Instance.GetBank("menu").GetMessageByLabel("simulation_result_anim_name_01");
				case 1:
					return MessageManager.Instance.GetBank("menu").GetMessageByLabel("simulation_result_anim_name_02");
				case 2:
					return MessageManager.Instance.GetBank("menu").GetMessageByLabel("simulation_result_anim_name_03");
				case 3:
					return MessageManager.Instance.GetBank("menu").GetMessageByLabel("simulation_result_anim_name_04");
				default:
					return "";
			}
		}

		//// RVA: 0xC4F1E0 Offset: 0xC4F1E0 VA: 0xC4F1E0
		public void Enter()
		{
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0xC4F26C Offset: 0xC4F26C VA: 0xC4F26C
		public void Leave()
		{
			m_Anim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xC4F2F8 Offset: 0xC4F2F8 VA: 0xC4F2F8
		public bool IsPlaying()
		{
			return m_Anim.IsPlayingChildren();
		}

		//// RVA: 0xC4F324 Offset: 0xC4F324 VA: 0xC4F324
		//public void Skip() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x726D8C Offset: 0x726D8C VA: 0x726D8C
		//// RVA: 0xC4F3D0 Offset: 0xC4F3D0 VA: 0xC4F3D0
		//private void <SetCD>b__19_0(IiconTexture icon) { }
	}
}
