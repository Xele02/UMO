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

		//public PlayRecord_Animator animctrl { get; private set; } 0xA42350 0xA4671C
		
		//// RVA: 0xA45DD8 Offset: 0xA45DD8 VA: 0xA45DD8
		public void Initialize()
		{
			m_anim_ctrl = new PlayRecord_Animator(m_anim);
		}

		//// RVA: 0xA45E50 Offset: 0xA45E50 VA: 0xA45E50
		public void Set(PlayRecordView_Total a_view)
		{
			TodoLogger.Log(0, "Set");
		}

		//// RVA: 0xA45304 Offset: 0xA45304 VA: 0xA45304
		//public void SetImageMain(Material a_material) { }
	}
}
