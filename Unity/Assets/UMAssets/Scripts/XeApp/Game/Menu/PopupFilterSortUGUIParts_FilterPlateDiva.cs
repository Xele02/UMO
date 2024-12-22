using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateDiva : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private RawImageEx[] m_image; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18
		[SerializeField]
		private UGUIToggleButton[] m_compatibleBtn; // 0x1C
		private List<int> m_list_diva_id = new List<int>(); // 0x20
		private uint m_bit_btn; // 0x24
		private Color m_onColor = new Color(1, 1, 1, 1); // 0x28
		private Color m_offColor = new Color(0.6f, 0.6f, 0.6f, 1); // 0x38
		private byte m_selectDivaID; // 0x48
		private RectTransform m_rect; // 0x4C
		private Vector2 m_sizeDelta; // 0x50
		private Transform m_compatibleTransform; // 0x58
		private float m_compatibleHeight; // 0x5C
		public override Type MyType { get { return Type.NoControl; } } //0x1CA2F58

		// [IteratorStateMachineAttribute] // RVA: 0x708F34 Offset: 0x708F34 VA: 0x708F34
		// RVA: 0x1CA2F60 Offset: 0x1CA2F60 VA: 0x1CA2F60 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA3CB0
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA3688
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_compatibleBtn[0].SetOff();
					PushFilterButtonsWithAllButton(index, m_btn);
					if(index == 0)
					{
						for(int j = 1; j < m_btn.Length; j++)
						{
							m_image[j].color = m_offColor;
						}
					}
					else
					{
						m_image[index].color = m_btn[index].IsOn ? m_onColor : m_offColor;
					}
				});
			}
			m_compatibleBtn[0].AddOnClickCallback(() =>
			{
				//0x1CA367C
				OnPushCompatibleButton();
			});
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			m_rect = GetComponent<RectTransform>();
			m_sizeDelta = m_rect.sizeDelta;
			m_compatibleTransform = m_rect.transform.GetChild(0);
			m_compatibleHeight = m_compatibleTransform.GetComponent<RectTransform>().sizeDelta.y;
			yield break;
		}

		// // RVA: 0x1C9ACA4 Offset: 0x1C9ACA4 VA: 0x1C9ACA4
		public void Initialize(List<FFHPBEPOMAK_DivaInfo> a_view_diva, bool a_is_val, bool compatibleEnable, bool a_is_has_only = false)
		{
			m_list_diva_id.Clear();
			for(int i = 0; i < a_view_diva.Count; i++)
			{
				if(!a_is_has_only || a_view_diva[i].FJODMPGPDDD_DivaHave)
				{
					m_list_diva_id.Add(a_view_diva[i].AHHJLDLAPAN_DivaId);
				}
			}
			for(int i = 1; i < m_image.Length; i++)
			{
				int index = i;
				if(i - 1 < m_list_diva_id.Count)
				{
					GameManager.Instance.DivaIconCache.SetLoadingIcon(m_image[i]);
					int divaId = m_list_diva_id[i - 1];
					int costumeId = 1;
					int colorId = 0;
					if(a_is_has_only)
					{
						FFHPBEPOMAK_DivaInfo f = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
						{
							//0x1CA3B74
							return _.AHHJLDLAPAN_DivaId == divaId;
						});
						if(f != null)
						{
							costumeId = f.EGAFMGDFFCH_HomeDivaCostume.DAJGPBLEEOB_PrismCostumeId;
							colorId = f.JFFLFIMIMOI_HomeColorId;
						}
					}
					GameManager.Instance.DivaIconCache.Load(divaId, costumeId, colorId, (IiconTexture texture) =>
					{
						//0x1CA39B4
						if(m_image[index] != null)
						{
							texture.Set(m_image[index]);
						}
					});
					m_btn[i].Hidden = false;
				}
				else
				{
					m_btn[i].Hidden = true;
				}
				if(m_btn[i].IsOn)
				{
					m_image[i].color = m_onColor;
				}
				else
				{
					m_image[i].color = m_offColor;
				}
			}
			if(a_is_val)
			{
				m_list_diva_id.Add(a_view_diva.Count + 1);
				m_list_diva_id.Add(a_view_diva.Count + 2);
				m_btn[m_btn.Length - 2].Hidden = false;
				m_btn[m_btn.Length - 1].Hidden = false;
			}
			else
			{
				m_btn[m_btn.Length - 2].Hidden = true;
				m_btn[m_btn.Length - 1].Hidden = true;
			}
			if(compatibleEnable)
			{
				m_rect.sizeDelta = m_sizeDelta;
				m_compatibleTransform.gameObject.SetActive(true);
			}
			else
			{
				m_rect.sizeDelta = new Vector2(m_rect.sizeDelta.x, m_sizeDelta.y - m_compatibleHeight);
				m_compatibleTransform.gameObject.SetActive(false);
			}
		}

		// // RVA: 0x1C9AC94 Offset: 0x1C9AC94 VA: 0x1C9AC94
		public void SetBit(uint bitFlag)
		{
			SetFilterButtonsWithAllButton(m_btn, bitFlag);
		}

		// // RVA: 0x1C9C534 Offset: 0x1C9C534 VA: 0x1C9C534
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}

		// // RVA: 0x1C9AC9C Offset: 0x1C9AC9C VA: 0x1C9AC9C
		public void SetBitCompatible(uint bitFlag)
		{
			SetFilterButtons(m_compatibleBtn, bitFlag);
		}

		// // RVA: 0x1C9C53C Offset: 0x1C9C53C VA: 0x1C9C53C
		public uint GetBitCompatible()
		{
			return GetFilterButtonsBit(m_compatibleBtn);
		}

		// // RVA: 0x1CA301C Offset: 0x1CA301C VA: 0x1CA301C
		// private void SetCimpatibleDivaFilterButtonEvent() { }

		// // RVA: 0x1CA3184 Offset: 0x1CA3184 VA: 0x1CA3184
		private void OnPushCompatibleButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(m_compatibleBtn[0].IsOn)
			{
				m_compatibleBtn[0].SetOn();
				UpdateCompatibleButton();
			}
			else
			{
				m_compatibleBtn[0].SetOff();
				PushFilterButtonsWithAllButton(0, m_btn);
				for(int i = 1; i < m_btn.Length; i++)
				{
					m_image[i].color = m_offColor;
				}
			}
		}

		// // RVA: 0x1CA3380 Offset: 0x1CA3380 VA: 0x1CA3380
		private void UpdateCompatibleButton()
		{
			m_btn[0].SetOff();
			for(int i = 1; i < m_btn.Length; i++)
			{
				if(m_selectDivaID == i - 1)
				{
					m_btn[i].SetOn();
					m_image[i].color = m_onColor;
				}
				else
				{
					m_btn[i].SetOff();
					m_image[i].color = m_offColor;
				}
			}
		}

		// // RVA: 0x1C9B818 Offset: 0x1C9B818 VA: 0x1C9B818
		public void SetSelectedDiva(int divaid)
		{
			m_selectDivaID = (byte)m_list_diva_id.FindIndex((int x) =>
			{
				//0x1CA3C98
				return divaid == x;
			});
			if(m_compatibleBtn[0].IsOn)
			{
				m_btn[0].SetOff();
				for(int i = 1; i < m_btn.Length; i++)
				{
					if(i - 1 == m_selectDivaID)
					{
						m_btn[i].SetOn();
						m_image[i].color = m_onColor;
					}
					else
					{
						m_btn[i].SetOff();
						m_image[i].color = m_offColor;
					}
				}
			}
			
		}
    }
}
