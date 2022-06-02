using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class UI_PlayRecord : MonoBehaviour
	{
		public enum Status
		{
			None = 0,
			Initialized = 1,
			Enter = 2,
			Leave = 3,
		}

		public enum DispInfo
		{
			Total = 0,
			Diva = 1,
		}

		[SerializeField]
		public Image m_tap_guard;
		[SerializeField]
		public Image m_btn_cursor;
		[SerializeField]
		public UGUIButton m_btn_total;
		[SerializeField]
		public UGUIButton m_btn_close;
		[SerializeField]
		public List<UGUIButton> m_list_btn_diva;
		[SerializeField]
		public UI_PlayRecord_TotalInfo m_content_total;
		[SerializeField]
		public List<UI_PlayRecord_DivaInfo> m_list_content_diva;
		[SerializeField]
		public Animator m_anim;
		public Status m_status;
		public DispInfo m_current;
		public List<CanvasGroup> m_list_canvas_group;
	}
}
