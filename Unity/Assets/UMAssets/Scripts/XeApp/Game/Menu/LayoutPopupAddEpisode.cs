using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeSys;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAddEpisode : LayoutUGUIScriptBase
	{
		public enum Type
		{
			AddEpisode = 0,
			AvailableEpisode = 1,
			ViewEpisode = 2,
			AddEpisodeListContent = 3,
		}
		
		[SerializeField]
		private Text m_title; // 0x14
		[SerializeField]
		private Text[] m_episodeDesc; // 0x18
		[SerializeField]
		private Text m_divaName; // 0x1C
		[SerializeField]
		private Text m_homeBgName; // 0x20
		[SerializeField]
		private Text[] m_rewardName; // 0x24
		[SerializeField]
		private Text[] m_desc; // 0x28
		[SerializeField]
		private RawImageEx[] m_image; // 0x2C
		[SerializeField]
		private RawImageEx m_episodeImage; // 0x30
		[SerializeField]
		private RawImageEx m_episodeBgImage; // 0x34
		private AbsoluteLayout m_typeTbl; // 0x38
		private AbsoluteLayout m_descTbl; // 0x3C
		private AbsoluteLayout[] m_stringAnim; // 0x40
		private int m_stringIndex; // 0x44
		private Type m_type; // 0x48
		private bool m_isLoadingIcon; // 0x4C
		private bool m_isLoadingEpisodeImage; // 0x4D
		private bool m_isLoadingEpisodeBgImage; // 0x4E
		private List<IEnumerator> m_animList = new List<IEnumerator>(4); // 0x50

		public bool IsOpen { get; private set; } // 0x4F

		//// RVA: 0x15E414C Offset: 0x15E414C VA: 0x15E414C
		public void SetStatus(int episodeId, Type type)
		{
			if (episodeId < 1)
				return;
			PIGBBNDPPJC p = new PIGBBNDPPJC();
			p.KHEKNNFCAOI(episodeId);
			LGMEPLIJLNB l = LGMEPLIJLNB.BMFKMFNPGPC(episodeId, true);
			if(l != null && l.GOOIIPFHOIG != null)
			{
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
				SetType(type, cat);
				if(type >= Type.ViewEpisode || type == Type.AddEpisode)
				{
					//LAB_015e4270
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					{
						SetRewardName(GetHomeBgName(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId));
						SetHomeBgName(GetHomeBgName(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId));
						SetImageHomeBg(GetHomeBgId(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId));
					}
					else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
					{
						SetRewardName(string.Format(MessageManager.Instance.GetMessage("menu", "valkyrie_name_text_format_001"), MessageManager.Instance.GetMessage("master", "vn_" + EKLNMHFCAOI.DEACAHNLMNI_getItemId(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId).ToString("D4")), MessageManager.Instance.GetMessage("master", "v_pn_" + EKLNMHFCAOI.DEACAHNLMNI_getItemId(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId).ToString("D4"))));
						SetImageIcon(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
					}
					else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
					{
						SetRewardName(EKLNMHFCAOI.INCKKODFJAP_GetItemName(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId));
						SetImageIcon(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
					}
					else
					{
						SetImageIcon(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
					}
				}
				else if(type == Type.AvailableEpisode)
				{
					if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					{
						SetRewardName(GetHomeBgName(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId));
						SetHomeBgName(GetHomeBgName(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId));
						SetImageHomeBg(GetHomeBgId(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId));
					}
					else if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
					{
						SetPilotName(GetPilotName(GetPilotIdForValkyrie(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId)));
						SetImageValkyrie(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId);
						SetRewardName(string.Format(MessageManager.Instance.GetMessage("menu", "valkyrie_name_text_format_001"), MessageManager.Instance.GetMessage("master", "vn_" + EKLNMHFCAOI.DEACAHNLMNI_getItemId(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId).ToString("D4")), MessageManager.Instance.GetMessage("master", "v_pn_" + EKLNMHFCAOI.DEACAHNLMNI_getItemId(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId).ToString("D4"))));
					}
					else if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
					{
						SetDivaName(GetDivaShortName(GetDivaIdForCostume(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId)));
						SetImageCostume(l.GOOIIPFHOIG.NNFNGLJOKKF_ItemId);
						SetRewardName(EKLNMHFCAOI.INCKKODFJAP_GetItemName(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId));
					}
				}
				SetDesc(cat);
			}
			//LAB_015e45c8
			SetImageEpisode(p.KELFCMEOPPM_EpId);
			SetEpisodeName(p.OPFGFINHFCE_Name);
			SetEpisodeDesc(p.KLMPFGOCBHC_Description);
		}

		//// RVA: 0x15E5144 Offset: 0x15E5144 VA: 0x15E5144
		private int GetDivaIdForCostume(int costumeId)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[costumeId - 1].AHHJLDLAPAN_PrismDivaId;
		}

		//// RVA: 0x15E55C0 Offset: 0x15E55C0 VA: 0x15E55C0
		private int GetPilotIdForValkyrie(int vfId)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[vfId - 1].PFGJJLGLPAC_PilotId;
		}

		//// RVA: 0x15E5274 Offset: 0x15E5274 VA: 0x15E5274
		private string GetDivaShortName(int divaId)
		{
			return MessageManager.Instance.GetMessage("master", string.Format("diva_s_{0:D2}", divaId));
		}

		//// RVA: 0x15E56F0 Offset: 0x15E56F0 VA: 0x15E56F0
		private string GetPilotName(int pilotId)
		{
			return MessageManager.Instance.GetMessage("master", string.Format("plt_nm_{0:D4}", pilotId));
		}

		//// RVA: 0x15E4CF0 Offset: 0x15E4CF0 VA: 0x15E4CF0
		private int GetHomeBgId(int bgid)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA[bgid - 1].OENPCNBFPDA_BgId;
		}

		//// RVA: 0x15E4B0C Offset: 0x15E4B0C VA: 0x15E4B0C
		private string GetHomeBgName(int bgid)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA[bgid - 1].OPFGFINHFCE_Name;
		}

		//// RVA: 0x15E5FEC Offset: 0x15E5FEC VA: 0x15E5FEC
		public bool IsLoading()
		{
			UnityEngine.Debug.LogError(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning+" "+!m_isLoadingIcon+" "+!m_isLoadingEpisodeBgImage+" "+!m_isLoadingEpisodeImage);
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !m_isLoadingIcon && !m_isLoadingEpisodeBgImage && !m_isLoadingEpisodeImage;
		}

		//// RVA: 0x15E4914 Offset: 0x15E4914 VA: 0x15E4914
		private void SetType(Type type, EKLNMHFCAOI.FKGCBLHOOCL_Category itemType)
		{
			if (m_typeTbl == null)
				return;
			m_type = type;
			switch(type)
			{
				case Type.AddEpisode:
				case Type.AddEpisodeListContent:
					m_stringIndex = 0;
					m_typeTbl.StartChildrenAnimGoStop(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg ? "05" : "01");
					break;
				case Type.AvailableEpisode:
					if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					{
						m_stringIndex = 3;
						m_typeTbl.StartChildrenAnimGoStop("06");
					}
					else if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
					{
						m_stringIndex = 2;
						m_typeTbl.StartChildrenAnimGoStop("03");
					}
					else if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
					{
						m_stringIndex = 1;
						m_typeTbl.StartChildrenAnimGoStop("02");
					}
					break;
				case Type.ViewEpisode:
					if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					{
						m_stringIndex = 3;
						m_typeTbl.StartChildrenAnimGoStop("05");
					}
					break;
				default:
					break;
			}
		}

		//// RVA: 0x15E5DDC Offset: 0x15E5DDC VA: 0x15E5DDC
		public void SetEpisodeName(string text)
		{
			if(m_title != null)
			{
				m_title.text = text;
			}
		}

		//// RVA: 0x15E5E9C Offset: 0x15E5E9C VA: 0x15E5E9C
		public void SetEpisodeDesc(string text)
		{
			for(int i = 0; i < m_episodeDesc.Length; i++)
			{
				if(m_episodeDesc[i] != null)
				{
					m_episodeDesc[i].text = text;
				}
			}
		}

		//// RVA: 0x15E534C Offset: 0x15E534C VA: 0x15E534C
		public void SetDivaName(string text)
		{
			if(m_divaName != null)
			{
				m_divaName.text = string.Format(MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_release_ep_diva_costume"), text);
			}
		}

		//// RVA: 0x15E57C8 Offset: 0x15E57C8 VA: 0x15E57C8
		public void SetPilotName(string text)
		{
			if(m_divaName != null)
			{
				m_divaName.text = text;
			}
		}

		//// RVA: 0x15E4C30 Offset: 0x15E4C30 VA: 0x15E4C30
		public void SetHomeBgName(string text)
		{
			if(m_homeBgName != null)
			{
				m_homeBgName.text = text;
			}
		}

		//// RVA: 0x15E4A6C Offset: 0x15E4A6C VA: 0x15E4A6C
		public void SetRewardName(string text)
		{
			for(int i = 0; i < m_rewardName.Length; i++)
			{
				m_rewardName[i].text = text;
			}
		}

		//// RVA: 0x15E59B0 Offset: 0x15E59B0 VA: 0x15E59B0
		private void SetDesc(EKLNMHFCAOI.FKGCBLHOOCL_Category itemType)
		{
			SwitchDesc(itemType);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_type == Type.AddEpisodeListContent || m_type == Type.AddEpisode)
			{
				if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
				{
					SetDesc(bk.GetMessageByLabel("popup_add_episode_04"));
				}
				else if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
				{
					SetDesc(bk.GetMessageByLabel("popup_add_episode_02"));
				}
				else if (itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
				{
					SetDesc(bk.GetMessageByLabel("popup_add_episode_03"));
				}
				else
				{
					SetDesc(bk.GetMessageByLabel("popup_add_episode_01"));
				}
			}
			else if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
			{
				SetDesc(bk.GetMessageByLabel("popup_release_episode_03"));
			}
			else if (itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				SetDesc(bk.GetMessageByLabel("popup_release_episode_02"));
			}
			else if (itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				SetDesc(bk.GetMessageByLabel("popup_release_episode_01"));
			}
		}

		//// RVA: 0x15E60B4 Offset: 0x15E60B4 VA: 0x15E60B4
		private void SwitchDesc(EKLNMHFCAOI.FKGCBLHOOCL_Category itemType)
		{
			if(m_descTbl != null)
			{
				if (itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					m_descTbl.StartChildrenAnimGoStop("05");
				else if (itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
					m_descTbl.StartChildrenAnimGoStop("02");
				else if (itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
					m_descTbl.StartChildrenAnimGoStop("01");
				else
					m_descTbl.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x15E6170 Offset: 0x15E6170 VA: 0x15E6170
		private void SetDesc(string text)
		{
			for(int i = 0; i < m_desc.Length; i++)
			{
				m_desc[i].text = text;
			}
		}

		//// RVA: 0x15E502C Offset: 0x15E502C VA: 0x15E502C
		public void SetImageIcon(int id)
		{
			m_isLoadingIcon = true;
			GameManager.Instance.ItemTextureCache.Load(id, (IiconTexture texture) =>
			{
				//0x15E6FA8
				texture.Set(m_image[0]);
				m_isLoadingIcon = false;
			});
		}

		//// RVA: 0x15E5498 Offset: 0x15E5498 VA: 0x15E5498
		public void SetImageCostume(int cos_id)
		{
			m_isLoadingIcon = true;
			GameManager.Instance.CostumeIconCache.Load(cos_id, 0, (IiconTexture texture) =>
			{
				//0x15E70B8
				texture.Set(m_image[1]);
				m_isLoadingIcon = false;
			});
		}

		//// RVA: 0x15E5888 Offset: 0x15E5888 VA: 0x15E5888
		public void SetImageValkyrie(int id)
		{
			m_isLoadingIcon = true;
			GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(id, 0, (IiconTexture texture) =>
			{
				//0x15E71C8
				texture.Set(m_image[2]);
				m_isLoadingIcon = false;
			});
		}

		//// RVA: 0x15E4E14 Offset: 0x15E4E14 VA: 0x15E4E14
		public void SetImageHomeBg(int id)
		{
			m_isLoadingIcon = true;
			GameManager.Instance.SceneIconCache.SetLoadingTexture(m_image[3]);
			GameManager.Instance.SceneIconCache.SetLoadingTexture(m_image[4]);
			GameManager.Instance.HomeBgIconTextureCache.Load(id, (IiconTexture texture) =>
			{
				//0x15E72D8
				texture.Set(m_image[3]);
				texture.Set(m_image[4]);
				m_isLoadingIcon = false;
			});
		}

		//// RVA: 0x15E5B8C Offset: 0x15E5B8C VA: 0x15E5B8C
		public void SetImageEpisode(int id)
		{
			m_isLoadingEpisodeImage = false;
			m_isLoadingEpisodeBgImage = false;
			if(m_episodeImage != null && m_episodeBgImage != null)
			{
				m_isLoadingEpisodeImage = true;
				GameManager.Instance.EpisodeIconCache.Load(id, (IiconTexture texture) =>
				{
					//0x15E7498
					texture.Set(m_episodeImage);
					m_isLoadingEpisodeImage = false;
				});
				m_isLoadingEpisodeBgImage = true;
				GameManager.Instance.EpisodeIconCache.LoadBg(id, (IiconTexture texture) =>
				{
					//0x15E7578
					texture.Set(m_episodeBgImage);
					m_isLoadingEpisodeBgImage = false;
				});
			}
		}

		// RVA: 0x15E6210 Offset: 0x15E6210 VA: 0x15E6210
		public void Update()
		{
			for (int i = 0; i < m_animList.Count; i++)
			{
				if (m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
					{
						m_animList[i] = null;
					}
				}
			}
		}

		//// RVA: 0x15E63AC Offset: 0x15E63AC VA: 0x15E63AC
		public void ResetData()
		{
			m_animList.Clear();
			m_stringAnim[m_stringIndex].StartAllAnimGoStop("st_wait");
		}

		//// RVA: 0x15E648C Offset: 0x15E648C VA: 0x15E648C
		public void Show()
		{
			if(m_stringAnim[m_stringIndex] != null)
			{
				if(!IsOpen)
				{
					IsOpen = true;
					m_animList.Clear();
				}
			}
		}

		//// RVA: 0x15E6560 Offset: 0x15E6560 VA: 0x15E6560
		public void Hide()
		{
			if (m_stringAnim[m_stringIndex] != null)
			{
				if (IsOpen)
				{
					IsOpen = false;
					m_animList.Clear();
				}
			}
		}

		//// RVA: 0x15E6630 Offset: 0x15E6630 VA: 0x15E6630
		public void StringIn()
		{
			if(((int)m_type & 0xfffffffe) == 2 || !IsOpen)
			{
				return;
			}
			if (m_stringAnim[m_stringIndex] == null)
				return;
			m_stringAnim[m_stringIndex].StartAllAnimGoStop("go_in", "st_in");
			m_animList.Add(AnimInWait());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70B6D4 Offset: 0x70B6D4 VA: 0x70B6D4
		//// RVA: 0x15E67DC Offset: 0x15E67DC VA: 0x15E67DC
		private IEnumerator AnimInWait()
		{
			//0x15E765C
			while (m_stringAnim[m_stringIndex].IsPlayingChildren())
				yield return null;
			m_stringAnim[m_stringIndex].StartAllAnimLoop("logo_up", "loen_up");
		}

		// RVA: 0x15E6888 Offset: 0x15E6888 VA: 0x15E6888 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_typeTbl = layout.FindViewByExId("root_pop_ep_sw_pop_ep_all") as AbsoluteLayout;
			m_descTbl = layout.FindViewByExId("sw_pop_ep_all_swtbl_caution_txt") as AbsoluteLayout;
			m_stringAnim = new AbsoluteLayout[4];
			m_stringAnim[0] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_03_anim") as AbsoluteLayout;
			m_stringAnim[1] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_04_anim") as AbsoluteLayout;
			m_stringAnim[2] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_05_anim") as AbsoluteLayout;
			m_stringAnim[3] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_06_anim") as AbsoluteLayout;
			SetEpisodeName("");
			SetEpisodeDesc("");
			SetRewardName("");
			SetDesc("");
			if(m_episodeImage != null)
			{
				m_episodeImage.uvRect = EpisodeTextuteCache.ImageUv;
			}
			Loaded();
			return true;
		}
	}
}
