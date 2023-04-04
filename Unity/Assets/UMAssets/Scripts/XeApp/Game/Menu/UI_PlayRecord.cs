using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Text;

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
		public Image m_tap_guard; // 0xC
		[SerializeField]
		public Image m_btn_cursor; // 0x10
		[SerializeField]
		public UGUIButton m_btn_total; // 0x14
		[SerializeField]
		public UGUIButton m_btn_close; // 0x18
		[SerializeField]
		public List<UGUIButton> m_list_btn_diva; // 0x1C
		[SerializeField]
		public UI_PlayRecord_TotalInfo m_content_total; // 0x20
		[SerializeField]
		public List<UI_PlayRecord_DivaInfo> m_list_content_diva; // 0x24
		[SerializeField]
		public Animator m_anim; // 0x28
		public Status m_status; // 0x2C
		public DispInfo m_current; // 0x30
		public List<CanvasGroup> m_list_canvas_group; // 0x34
		//public PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo> m_content_diva; // 0x38
		private int m_diva_id_now; // 0x3C
		private int m_diva_id_prev; // 0x40
		private float[] m_content_diva_pos = new float[10]; // 0x44
		//public PlayRecordView m_view_data; // 0x48
		private const string PATH_BUNDLE = "ct/dv/me/09/{0:D2}_{1:D2}.xab";
		private const string PATH_FILE = "{0:D2}_{1:D2}";
		private StringBuilder m_string_builder = new StringBuilder(); // 0x4C
		private PlayRecord_Animator m_anim_ctrl; // 0x50
		private Material[] m_material_diva = new Material[10]; // 0x54
		private Material m_material_total; // 0x58

		//public PlayRecord_Animator animctrl { get; private set; } 0xA4222C

		//// RVA: 0xA42238 Offset: 0xA42238 VA: 0xA42238
		//public bool IsAnimation() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF4B4 Offset: 0x6FF4B4 VA: 0x6FF4B4
		//// RVA: 0xA42360 Offset: 0xA42360 VA: 0xA42360
		//public IEnumerator Enter() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF52C Offset: 0x6FF52C VA: 0x6FF52C
		//// RVA: 0xA4240C Offset: 0xA4240C VA: 0xA4240C
		//public IEnumerator Leave() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF5A4 Offset: 0x6FF5A4 VA: 0x6FF5A4
		//// RVA: 0xA424B8 Offset: 0xA424B8 VA: 0xA424B8
		//public IEnumerator Initialize(Action a_cb_closed) { }

		//// RVA: 0xA42580 Offset: 0xA42580 VA: 0xA42580
		//private void SelectButton(int a_index) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF61C Offset: 0x6FF61C VA: 0x6FF61C
		//// RVA: 0xA42890 Offset: 0xA42890 VA: 0xA42890
		//private IEnumerator CO_ChangeDiva(int a_diva_id) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF694 Offset: 0x6FF694 VA: 0x6FF694
		//// RVA: 0xA42958 Offset: 0xA42958 VA: 0xA42958
		//private IEnumerator CO_ChangeTotal() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF70C Offset: 0x6FF70C VA: 0x6FF70C
		//// RVA: 0xA42A04 Offset: 0xA42A04 VA: 0xA42A04
		//private IEnumerator CO_LoadTexture_Total() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FF784 Offset: 0x6FF784 VA: 0x6FF784
		//// RVA: 0xA42AB0 Offset: 0xA42AB0 VA: 0xA42AB0
		//public static IEnumerator CO_LoadLayout(Transform a_pearent, Action<UI_PlayRecord> a_cb_loadend) { }

		// RVA: 0xA42B78 Offset: 0xA42B78 VA: 0xA42B78
		public void OnDestroy()
		{
			TodoLogger.Log(0, "OnDestroy");
		}

		// RVA: 0xA42CF0 Offset: 0xA42CF0 VA: 0xA42CF0
		public static bool IsFirstLaunch()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch;
		}
	}
}
