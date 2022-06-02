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
			public TextMeshProUGUI m_text;
			public Image m_image;
		}

		[SerializeField]
		public UI_PlayRecord_Item_Num m_Rank;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_IntimacyTouch;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_Costume;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_CostumeLV;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_MusicMax;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Present;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_DivaEvent_Soul;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_DivaEvent_Voice;
		[SerializeField]
		public UI_PlayRecord_Item_NumMax m_DivaEvent_Charm;
		[SerializeField]
		public UI_PlayRecord_Item_Num m_Sns;
		[SerializeField]
		public List<UI_PlayRecord_DivaInfo.StSnsObject> m_Sns_Object;
		[SerializeField]
		public Sprite m_Sns_SpriteRead;
		[SerializeField]
		public Sprite m_Sns_SpriteUnread;
		[SerializeField]
		public Image m_image_main;
		[SerializeField]
		public Animator m_anim;
		[SerializeField]
		public ScrollRect m_scroll;
	}
}
