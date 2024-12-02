using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using XeApp.Core;
using mcrs;

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
		public PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo> m_content_diva; // 0x38
		private int m_diva_id_now; // 0x3C
		private int m_diva_id_prev; // 0x40
		private float[] m_content_diva_pos = new float[10]; // 0x44
		public PlayRecordView m_view_data; // 0x48
		private const string PATH_BUNDLE = "ct/dv/me/09/{0:D2}_{1:D2}.xab";
		private const string PATH_FILE = "{0:D2}_{1:D2}";
		private StringBuilder m_string_builder = new StringBuilder(); // 0x4C
		private PlayRecord_Animator m_anim_ctrl; // 0x50
		private Material[] m_material_diva = new Material[10]; // 0x54
		private Material m_material_total; // 0x58

		//public PlayRecord_Animator animctrl { get; private set; } 0xA4222C

		//// RVA: 0xA42238 Offset: 0xA42238 VA: 0xA42238
		public bool IsAnimation()
		{
			return m_anim_ctrl.IsPlaying() || m_content_total.animctrl.IsPlaying() || m_content_diva.front.animctrl.IsPlaying();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF4B4 Offset: 0x6FF4B4 VA: 0x6FF4B4
		//// RVA: 0xA42360 Offset: 0xA42360 VA: 0xA42360
		public IEnumerator Enter()
		{
			//0xA453DC
			m_tap_guard.raycastTarget = true;
			m_current = 0;
			SelectButton(0);
			if(IsFirstLaunch())
			{
				m_anim_ctrl.EnterFirst();
				m_content_total.animctrl.EnterFirst();
			}
			else
			{
				m_anim_ctrl.Enter();
				m_content_total.animctrl.Enter();
			}
			yield return null;
			while (IsAnimation())
				yield return null;
			m_tap_guard.raycastTarget = false;
			m_status = Status.Enter;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF52C Offset: 0x6FF52C VA: 0x6FF52C
		//// RVA: 0xA4240C Offset: 0xA4240C VA: 0xA4240C
		public IEnumerator Leave()
		{
			//0xA46484
			m_tap_guard.raycastTarget = true;
			if(m_current == 0)
			{
				m_content_total.animctrl.Leave();
			}
			else
			{
				m_content_diva.front.animctrl.Leave();
			}
			m_anim_ctrl.Leave();
			yield return null;
			while (IsAnimation())
				yield return null;
			m_tap_guard.raycastTarget = true;
			m_status = Status.Leave;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF5A4 Offset: 0x6FF5A4 VA: 0x6FF5A4
		//// RVA: 0xA424B8 Offset: 0xA424B8 VA: 0xA424B8
		public IEnumerator Initialize(Action a_cb_closed)
		{
			//0xA45640
			m_view_data = new PlayRecordView();
			m_view_data.Create(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			yield return null;
			m_anim_ctrl = new PlayRecord_Animator(m_anim);
			m_content_total.Initialize();
			m_content_total.Set(m_view_data.m_total);
			m_content_diva = new PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo>(m_list_content_diva);
			m_content_diva.front.Initalize();
			m_content_diva.back.Initalize();
			for(int i = 0; i < m_content_diva_pos.Length; i++)
			{
				m_content_diva_pos[i] = 1;
			}
			m_btn_close.AddOnClickCallback(() =>
			{
				//0xA42E94
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch = false;
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				}
				m_tap_guard.raycastTarget = true;
				if (a_cb_closed != null)
					a_cb_closed();
			});
			m_btn_total.AddOnClickCallback(() =>
			{
				//0xA430A4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
				this.StartCoroutineWatched(CO_ChangeTotal());
			});
			for(int i = 0; i < m_list_btn_diva.Count; i++)
			{
				int t_diva_id = i + 1;
				m_list_btn_diva[i].AddOnClickCallback(() =>
				{
					//0xA43150
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
					this.StartCoroutineWatched(CO_ChangeDiva(t_diva_id));
				});
			}
			m_list_canvas_group = new List<CanvasGroup>();
			m_list_canvas_group.AddRange(gameObject.GetComponentsInChildren<CanvasGroup>(true));
			Text[] ts = gameObject.GetComponentsInChildren<Text>(true);
			for (int i = 0; i < ts.Length; i++)
			{
				GameManager.Instance.GetSystemFont().Apply(ts[i]);
			}
			yield return Co.R(CO_LoadTexture_Total());
		}

		//// RVA: 0xA42580 Offset: 0xA42580 VA: 0xA42580
		private void SelectButton(int a_index)
		{
			if(a_index == 0)
			{
				m_btn_cursor.transform.position = m_btn_total.transform.position;
				m_btn_total.IsInputLock = true;
			}
			else
			{
				m_btn_total.IsInputLock = false;
			}
			for(int i = 0; i < m_list_btn_diva.Count; i++)
			{
				if(a_index - 1 == i)
				{
					m_btn_cursor.transform.position = m_list_btn_diva[i].transform.position;
					m_list_btn_diva[i].IsInputLock = true;
				}
				else
				{
					m_list_btn_diva[i].IsInputLock = false;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF61C Offset: 0x6FF61C VA: 0x6FF61C
		//// RVA: 0xA42890 Offset: 0xA42890 VA: 0xA42890
		private IEnumerator CO_ChangeDiva(int a_diva_id)
		{
			int t_diva_index; // 0x18
			string t_bundle_name; // 0x1C
			AssetBundleLoadAssetOperation t_operation; // 0x20

			//0xA43488
			m_tap_guard.raycastTarget = true;
			yield return null;
			SelectButton(a_diva_id);
			m_diva_id_prev = m_diva_id_now;
			m_diva_id_now = a_diva_id;
			t_diva_index = a_diva_id - 1;
			if(m_material_diva[t_diva_index] == null)
			{
				m_string_builder.Clear();
				m_string_builder.AppendFormat("ct/dv/me/09/{0:D2}_{1:D2}.xab", a_diva_id, 1);
				t_bundle_name = m_string_builder.ToString();
				m_string_builder.Clear();
				m_string_builder.AppendFormat("{0:D2}_{1:D2}", a_diva_id, 1);
				t_operation = AssetBundleManager.LoadAssetAsync(t_bundle_name, m_string_builder.ToString(), typeof(Material));
				yield return t_operation;
				m_material_diva[t_diva_index] = t_operation.GetAsset<Material>();
				AssetBundleManager.UnloadAssetBundle(t_bundle_name, false);
				yield return null;
				t_operation = null;
				t_bundle_name = null;
			}
			m_content_diva.back.Set(m_view_data.m_diva[t_diva_index]);
			m_content_diva.back.m_image_main.material = m_material_diva[t_diva_index];
			if(m_current == 0)
			{
				m_content_total.animctrl.Leave();
			}
			else
			{
				m_content_diva.front.animctrl.Leave();
			}
			yield return null;
			m_content_diva.Swap();
			if(m_diva_id_prev > 0)
			{
				m_content_diva_pos[m_diva_id_prev - 1] = m_content_diva.back.m_scroll.verticalNormalizedPosition;
			}
			if(m_diva_id_now > 0)
			{
				m_content_diva.front.m_scroll.verticalNormalizedPosition = m_content_diva_pos[m_diva_id_now - 1];
			}
			m_content_diva.front.animctrl.Enter();
			yield return null;
			while (m_content_diva.front.animctrl.IsPlaying())
				yield return null;
			m_tap_guard.raycastTarget = false;
			m_current = DispInfo.Diva;
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF694 Offset: 0x6FF694 VA: 0x6FF694
		//// RVA: 0xA42958 Offset: 0xA42958 VA: 0xA42958
		private IEnumerator CO_ChangeTotal()
		{
			//0xA4455C
			m_tap_guard.raycastTarget = true;
			yield return null;
			SelectButton(0);
			m_content_diva.front.animctrl.Leave();
			yield return null;
			m_content_total.animctrl.Enter();
			yield return null;
			while (m_content_diva.front.animctrl.IsPlaying())
				yield return null;
			m_tap_guard.raycastTarget = false;
			m_current = DispInfo.Total;
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF70C Offset: 0x6FF70C VA: 0x6FF70C
		//// RVA: 0xA42A04 Offset: 0xA42A04 VA: 0xA42A04
		private IEnumerator CO_LoadTexture_Total()
		{
			string t_bundle_name; // 0x18
			AssetBundleLoadAssetOperation t_operation; // 0x1C

			//0xA44C8C
			int totalinfoimage = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("playrecord_totalinfo_image", 6);
			int num = 1;
			if(totalinfoimage > 0)
			{
				num = UnityEngine.Random.Range(1, totalinfoimage + 1);
			}
			m_string_builder.Clear();
			m_string_builder.AppendFormat("ct/dv/me/09/{0:D2}_{1:D2}.xab", 11, num);
			t_bundle_name = m_string_builder.ToString();
			m_string_builder.Clear();
			m_string_builder.AppendFormat("{0:D2}_{1:D2}", 11, num);
			t_operation = AssetBundleManager.LoadAssetAsync(t_bundle_name, m_string_builder.ToString(), typeof(Material));
			yield return t_operation;
			m_material_total = t_operation.GetAsset<Material>();
			m_content_total.m_Image_Main.material = m_material_total;
			AssetBundleManager.UnloadAssetBundle(t_bundle_name, false);
			yield return null;
			t_bundle_name = null;
			t_operation = null;
			bool t_loaded_musicratio_texture = false;
			GameManager.Instance.MusicRatioTextureCache.Load(m_view_data.m_total.m_uta_grade, (IiconTexture texture) =>
			{
				//0xA43230
				(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_content_total.m_Image_UtaGrade, m_view_data.m_total.m_uta_grade);
				t_loaded_musicratio_texture = true;
			});
			while (!t_loaded_musicratio_texture)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF784 Offset: 0x6FF784 VA: 0x6FF784
		//// RVA: 0xA42AB0 Offset: 0xA42AB0 VA: 0xA42AB0
		public static IEnumerator CO_LoadLayout(Transform a_pearent, Action<UI_PlayRecord> a_cb_loadend)
		{
			XeSys.FontInfo t_font; // 0x1C
			StringBuilder t_bundle_name; // 0x20
			int t_bundle_cnt; // 0x24
			AssetBundleLoadUGUIOperationBase t_bundle_op; // 0x28

			//0xA44894
			t_font = GameManager.Instance.GetSystemFont();
			UI_PlayRecord t_ui = null;
			t_bundle_name = new StringBuilder("ly/301.xab");
			t_bundle_cnt = 0;
			t_bundle_op = AssetBundleManager.LoadUGUIAsync(t_bundle_name.ToString(), "UI_PlayRecord");
			yield return t_bundle_op;
			yield return Co.R(t_bundle_op.InitializeUGUICoroutine(t_font, (GameObject instance) =>
			{
				//0xA43364
				instance.transform.SetParent(a_pearent.transform, false);
				instance.transform.SetAsFirstSibling();
				t_ui = instance.GetComponentInChildren<UI_PlayRecord>();
			}));
			t_bundle_cnt++;
			for(int i = 0; i < t_bundle_cnt; i++)
			{
				AssetBundleManager.UnloadAssetBundle(t_bundle_name.ToString());
			}
			t_bundle_op = null;
			t_bundle_name = null;
			if(a_cb_loadend != null)
			{
				a_cb_loadend(t_ui);
			}
		}

		// RVA: 0xA42B78 Offset: 0xA42B78 VA: 0xA42B78
		public void OnDestroy()
		{
			for(int i = 0; i < m_material_diva.Length; i++)
			{
				if (m_material_diva[i] != null)
					m_material_diva[i] = null;
			}
			if (m_material_total != null)
				m_material_total = null;
		}

		// RVA: 0xA42CF0 Offset: 0xA42CF0 VA: 0xA42CF0
		public static bool IsFirstLaunch()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch;
		}
	}
}
