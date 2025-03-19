using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EpisodeAchievWindow : LayoutUGUIScriptBase
	{
		private Action mUpdater; // 0x14
		private NumberBase m_point_episode; // 0x18
		private RawImageEx m_item_image; // 0x1C
		private RawImageEx m_roop_text_image; // 0x20
		private Text m_item_name; // 0x24

		// RVA: 0x1275328 Offset: 0x1275328 VA: 0x1275328 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_sel_ep_earm_all (AbsoluteLayout)/sw_sel_ep_earm (AbsoluteLayout)");
			m_point_episode = t.Find("swnum_earm_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_item_image = t.Find("cnm_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_roop_text_image = t.Find("sel_ep_reward_fnt_01 (AbsoluteLayout)/sel_ep_reward_fnt_01 (ImageView)").GetComponent<RawImageEx>();
			m_item_name = t.Find("item_name_01 (TextView)").GetComponent<Text>();
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x1275564 Offset: 0x1275564 VA: 0x1275564
		private void Start()
		{
			return;
		}

		// RVA: 0x1275568 Offset: 0x1275568 VA: 0x1275568
		private void Update()
		{
			if(mUpdater != null)
				mUpdater();
		}

		// // RVA: 0x127557C Offset: 0x127557C VA: 0x127557C
		private void UpdateLoad()
		{
			if(!m_point_episode.IsLoaded())
				return;
			mUpdater = UpdateIdle;
		}

		// // RVA: 0x127562C Offset: 0x127562C VA: 0x127562C
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x1275630 Offset: 0x1275630 VA: 0x1275630
		public void Init(MFDJIFIIPJD data)
		{
			if(data.KACECFNECON == null)
			{
				Debug.LogError("null");
			}
			else
			{
				if(!data.KACECFNECON.LKGELAPAACK)
				{
					m_point_episode.SetNumber(data.KACECFNECON.DNBFMLBNAEE, 0);
					m_roop_text_image.enabled = false;
				}
				else
				{
					m_point_episode.SetDigitLength(4, false);
					m_roop_text_image.enabled = true;
				}
				m_item_name.text = string.Format("{0}　{1}{2}", EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.JJBGOIMEIPF_ItemId), data.MBJIFDBEDAC_Cnt, EKLNMHFCAOI.NDBLEADIDLA(data.NPPNDDMPFJJ_ItemCategory, data.NNFNGLJOKKF_ItemId, data.MBJIFDBEDAC_Cnt));
				SetItemImage(data.JJBGOIMEIPF_ItemId);
			}
		}

		// // RVA: 0x1275988 Offset: 0x1275988 VA: 0x1275988
		// public void Enter() { }

		// // RVA: 0x1275878 Offset: 0x1275878 VA: 0x1275878
		private void SetItemImage(int index)
		{
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0x1275994
				icon.Set(m_item_image);
			});
		}
	}
}
