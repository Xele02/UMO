using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EpisodeRewardItem : LayoutUGUIScriptBase
	{
		private RawImageEx m_item_image; // 0x14
		private RawImageEx m_clear_icon; // 0x18
		private Text m_item_name; // 0x1C
		private Text m_item_num; // 0x20
		private Text m_item_achieve; // 0x24
		private StringBuilder m_work_sb = new StringBuilder(32); // 0x28

		// RVA: 0xF02228 Offset: 0xF02228 VA: 0xF02228 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t1 = transform.Find("sw_sel_ep_reward_list (AbsoluteLayout)");
			m_item_image = t1.Find("cnm_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_clear_icon = t1.Find("sel_ep_clear_icon (ImageView)").GetComponent<RawImageEx>();
			m_item_name = t1.Find("item_name_01 (TextView)").GetComponent<Text>();
			m_item_num = t1.Find("item_number_01 (TextView)").GetComponent<Text>();
			m_item_achieve = t1.Find("achieve_number_01 (TextView)").GetComponent<Text>();
			Loaded();
			return true;
		}

		// RVA: 0xF02490 Offset: 0xF02490 VA: 0xF02490
		public void SetItem(LGMEPLIJLNB data, bool is_roop_reward)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_item_name.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
			m_item_num.text = data.GOOIIPFHOIG.MBJIFDBEDAC_Cnt.ToString() + EKLNMHFCAOI.NDBLEADIDLA(data.GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory, data.GOOIIPFHOIG.NNFNGLJOKKF_ItemId);
			if(is_roop_reward)
			{
				m_work_sb.SetFormat(bk.GetMessageByLabel("episode_reward_text002"), data.DNBFMLBNAEE_TotalPoint - data.CCDPNBJMKDI_StartPoint, RichTextUtility.MakeSizeTagString(bk.GetMessageByLabel("episode_reward_text003"), 22));
				m_item_achieve.text = m_work_sb.ToString();
			}
			else
			{
				m_work_sb.SetFormat(bk.GetMessageByLabel("episode_reward_text001"), data.DNBFMLBNAEE_TotalPoint);
				m_item_achieve.text = m_work_sb.ToString();
			}
			SetItemImage(data.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
			SetClearIconActive(data.HMEOAKCLKJE_IsReceived && !is_roop_reward);
		}

		//// RVA: 0xF02988 Offset: 0xF02988 VA: 0xF02988
		private void SetClearIconActive(bool active)
		{
			m_clear_icon.enabled = active;
		}

		//// RVA: 0xF02878 Offset: 0xF02878 VA: 0xF02878
		private void SetItemImage(int index)
		{
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0xF02A3C
				icon.Set(m_item_image);
			});
		}
	}
}
