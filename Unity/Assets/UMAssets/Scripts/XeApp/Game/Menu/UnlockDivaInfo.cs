using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.DownLoad;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockDivaInfo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private Transform m_content; // 0x18
		private Text m_info; // 0x1C
		private Text m_age; // 0x20
		private Text m_birthday; // 0x24
		private Text m_birthplace; // 0x28
		private Text m_favorite; // 0x2C
		private RawImageEx m_chara_name; // 0x30
		private RawImageEx m_diva_image; // 0x34
		private List<Rect> m_name_list = new List<Rect>(); // 0x38
		private ActionButton m_btn; // 0x3C
		private Action mUpdater; // 0x40

		// RVA: 0x125EC04 Offset: 0x125EC04 VA: 0x125EC04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_ul_chara_all_anim") as AbsoluteLayout;
			Transform t = transform.Find("sw_ul_chara_all_anim (AbsoluteLayout)/sw_ul_chara_all (AbsoluteLayout)");
			m_info = t.Find("text_00 (TextView)").GetComponent<Text>();
			m_age = t.Find("ago_00 (TextView)").GetComponent<Text>();
			m_birthday = t.Find("birthday_00 (TextView)").GetComponent<Text>();
			m_birthplace = t.Find("birthplace_00 (TextView)").GetComponent<Text>();
			m_favorite = t.Find("favorite_00 (TextView)").GetComponent<Text>();
			m_diva_image = t.Find("mask (MaskView)/MaskInverse/cmn_download (AbsoluteLayout)/swtexc_cmn_download (ImageView)").GetComponent<RawImageEx>();
			m_chara_name = t.Find("cmn_ul_chara_name (AbsoluteLayout)/cmn_ul_chara_name (ImageView)").GetComponent<RawImageEx>();
			m_btn = transform.Find("sw_ul_chara_all_anim (AbsoluteLayout)/sw_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < 10; i++)
			{
				str.Clear();
				str.AppendFormat("cmn_ul_chara_name_{0:00}", i + 1);
				m_name_list.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString())));
			}
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x125F208 Offset: 0x125F208 VA: 0x125F208
		private void Start()
		{ 
			return;
		}

		// RVA: 0x125F20C Offset: 0x125F20C VA: 0x125F20C
		private void Update()
		{
			return;
		}

		// // RVA: 0x125F210 Offset: 0x125F210 VA: 0x125F210
		private void UpdateLoad()
		{
			mUpdater = UpdateIdle;
		}

		// // RVA: 0x125F298 Offset: 0x125F298 VA: 0x125F298
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x125F29C Offset: 0x125F29C VA: 0x125F29C
		public void Init(int diva_id)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			m_info.horizontalOverflow = HorizontalWrapMode.Wrap;
			string b = string.Format("profile_diva{0:000}", diva_id);
			m_info.text = bk.GetMessageByLabel(b + "_description");
			m_age.text = bk.GetMessageByLabel(b + "_age");
			m_birthday.text = bk.GetMessageByLabel(b + "_birthday");
			m_birthplace.text = bk.GetMessageByLabel(b + "_birthplace");
			m_favorite.text = bk.GetMessageByLabel(b + "_favorite");
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				m_favorite.verticalOverflow = VerticalWrapMode.Truncate;
				m_favorite.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_favorite.resizeTextForBestFit = true;
				m_favorite.resizeTextMaxSize = m_favorite.fontSize;
				m_birthplace.verticalOverflow = VerticalWrapMode.Truncate;
				m_birthplace.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_birthplace.resizeTextForBestFit = true;
				m_birthplace.resizeTextMaxSize = m_birthplace.fontSize;
			}
			m_abs.StartChildrenAnimGoStop("st_wait", "st_wait");
			m_chara_name.uvRect = m_name_list[diva_id - 1];
			DownLoadDivaTextureCache.Create();
			this.StartCoroutineWatched(DownLoadDivaTextureCache.Instance.LoadDivaGraphicCoroutine(diva_id, (DownLoadDivaTexture texture) =>
			{
				//0x125F970
				texture.Set(m_diva_image);
			}));
		}

		// RVA: 0x125F71C Offset: 0x125F71C VA: 0x125F71C
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x125F7A8 Offset: 0x125F7A8 VA: 0x125F7A8
		// public void Leave() { }

		// // RVA: 0x125F834 Offset: 0x125F834 VA: 0x125F834
		public void Release()
		{
			DownLoadDivaTextureCache.Release();
		}

		// // RVA: 0x125F8B0 Offset: 0x125F8B0 VA: 0x125F8B0
		// public bool IsPlaying() { }

		// // RVA: 0x125F8DC Offset: 0x125F8DC VA: 0x125F8DC
		public ActionButton GetBtn()
		{
			return m_btn;
		}
	}
}
