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
		public UI_PlayRecord_Item_Num m_Login;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Mission;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Achievement;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_MusicTotal;
		[SerializeField]
		public List<UI_PlayRecord_Item_Num> m_MusicSeries;
		[SerializeField]
		public List<UI_PlayRecord_Item_Num> m_MusicDifficulty;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Plate;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_PlateLV;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_PlatePremium;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Costume;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_CostumeLV;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_CostumeColor;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Valkyrie;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_ValkyrieLV;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_Phrase;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_Interior;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_BG;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Deco_Mascot;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Rank;
		[SerializeField]
		public RawImageEx m_Image_UtaGrade;
		[SerializeField]
		public Image m_Image_Main;
		[SerializeField]
		public Animator m_anim;
		[SerializeField]
		public ScrollRect m_scroll;
	}
}
