using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UI_PlayRecord_TotalInfo : MonoBehaviour
	{
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Login; // 0xC
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Mission; // 0x10
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Achievement; // 0x14
		[SerializeField]
		public UI_PlayRecord_Item_Num m_MusicTotal; // 0x18
		[SerializeField]
		public List<UI_PlayRecord_Item_Num> m_MusicSeries; // 0x1C
		[SerializeField]
		public List<UI_PlayRecord_Item_Num> m_MusicDifficulty; // 0x20
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Plate; // 0x24
		[SerializeField]
		public UI_PlayRecord_Item_Num m_PlateLV; // 0x28
		[SerializeField]
		public UI_PlayRecord_Item_Num m_PlatePremium; // 0x2C
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Costume; // 0x30
		[SerializeField]
		public UI_PlayRecord_Item_Num m_CostumeLV; // 0x34
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_CostumeColor; // 0x38
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Valkyrie; // 0x3C
		[SerializeField]
		public UI_PlayRecord_Item_Num m_ValkyrieLV; // 0x40
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco; // 0x44
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_Phrase; // 0x48
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_Interior; // 0x4C
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_BG; // 0x50
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_Mascot; // 0x54
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Rank; // 0x58
		[SerializeField]
		public RawImageEx m_Image_UtaGrade; // 0x5C
		[SerializeField]
		public Image m_Image_Main; // 0x60
		[SerializeField]
		public Animator m_anim; // 0x64
		[SerializeField]
		public ScrollRect m_scroll; // 0x68
		private PlayRecord_Animator m_anim_ctrl; // 0x6C

		public PlayRecord_Animator animctrl { get { return m_anim_ctrl; } private set { return; } } //0xA42350 0xA4671C
		
		//// RVA: 0xA45DD8 Offset: 0xA45DD8 VA: 0xA45DD8
		public void Initialize()
		{
			m_anim_ctrl = new PlayRecord_Animator(m_anim);
		}

		//// RVA: 0xA45E50 Offset: 0xA45E50 VA: 0xA45E50
		public void Set(PlayRecordView_Total a_view)
		{
			m_Login.Set(a_view.m_login);
			m_Mission.Set(a_view.m_mission);
			m_Achievement.Set(a_view.m_achievement, a_view.m_achievement_max);
			m_MusicTotal.Set(a_view.m_music_total);
			for(int i = 0; i < m_MusicSeries.Count; i++)
			{
				m_MusicSeries[i].Set(a_view.m_music_series[i]);
			}
			for(int i = 0; i < m_MusicDifficulty.Count; i++)
			{
				m_MusicDifficulty[i].Set(a_view.m_music_difficulty[i]);
			}
			m_Plate.Set(a_view.m_plate_now, a_view.m_plate_max);
			m_PlateLV.Set(a_view.m_plate_upgrade);
			m_PlatePremium.Set(a_view.m_plate_premium);
			m_Costume.Set(a_view.m_costume_now, a_view.m_costume_max);
			m_CostumeLV.Set(a_view.m_costume_upgrade_now);
			m_CostumeColor.Set(a_view.m_costume_color_now, a_view.m_costume_color_max);
			m_Valkyrie.Set(a_view.m_valkyrie_now, a_view.m_valkyrie_max);
			m_ValkyrieLV.Set(a_view.m_valkyrie_upgrade_now);
			m_Deco.Set(a_view.m_deco_now, a_view.m_deco_max);
			m_Deco_Phrase.Set(a_view.m_deco_phrase_now, a_view.m_deco_phrase_max);
			m_Deco_Interior.Set(a_view.m_deco_interia_now, a_view.m_deco_interia_max);
			m_Deco_BG.Set(a_view.m_deco_bg_now, a_view.m_deco_bg_max);
			m_Deco_Mascot.Set(a_view.m_deco_mascot_now, a_view.m_deco_mascot_max);
		}

		//// RVA: 0xA45304 Offset: 0xA45304 VA: 0xA45304
		//public void SetImageMain(Material a_material) { }
	}
}
