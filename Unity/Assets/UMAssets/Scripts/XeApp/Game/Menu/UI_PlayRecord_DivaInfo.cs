using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using XeApp.Game;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class UI_PlayRecord_DivaInfo : MonoBehaviour
	{
		[Serializable]
		public struct StSnsObject
		{
			public TextMeshProUGUI m_text; // 0x0
			public Image m_image; // 0x4
		}

		[SerializeField]
		public UI_PlayRecord_Item_Num m_Rank; // 0xC
		[SerializeField]
		public UI_PlayRecord_Item_Num m_IntimacyTouch; // 0x10
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Costume; // 0x14
		[SerializeField]
		public UI_PlayRecord_Item_Num m_CostumeLV; // 0x18
		[SerializeField]
		public UI_PlayRecord_Item_Num m_MusicMax; // 0x1C
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Present; // 0x20
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_DivaEvent_Soul; // 0x24
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_DivaEvent_Voice; // 0x28
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_DivaEvent_Charm; // 0x2C
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Sns; // 0x30
		[SerializeField]
		public List<StSnsObject> m_Sns_Object; // 0x34
		[SerializeField]
		public Sprite m_Sns_SpriteRead; // 0x38
		[SerializeField]
		public Sprite m_Sns_SpriteUnread; // 0x3C
		[SerializeField]
		public Image m_image_main; // 0x40
		[SerializeField]
		public Animator m_anim; // 0x44
		[SerializeField]
		public ScrollRect m_scroll; // 0x48
		private PlayRecord_Animator m_anim_ctrl; // 0x4C

		//public PlayRecord_Animator animctrl { get; private set; } 0xA42358 0xA46710

		//// RVA: 0xA46370 Offset: 0xA46370 VA: 0xA46370
		public void Initalize()
		{
			m_anim_ctrl = new PlayRecord_Animator(m_anim);
		}

		//// RVA: 0xA43EF4 Offset: 0xA43EF4 VA: 0xA43EF4
		//public void Set(PlayRecordView_Diva a_view) { }

		//// RVA: 0xA44484 Offset: 0xA44484 VA: 0xA44484
		//public void SetImage(Material a_material) { }
	}
}
