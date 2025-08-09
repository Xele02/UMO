using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMissionBonusListItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_textDate; // 0x20
		[SerializeField]
		private Text m_textDesc; // 0x24
		[SerializeField]
		private RawImageEx m_imageLogo; // 0x28
		private AbsoluteLayout m_layout; // 0x2C
		private Matrix23 m_identity; // 0x30

		// // RVA: 0x1732F4C Offset: 0x1732F4C VA: 0x1732F4C
		// public bool IsIconLoaded() { }

		// // RVA: 0x1732F94 Offset: 0x1732F94 VA: 0x1732F94
		public void SetStatus(KPJHLACKGJF_EventMission.HLMINENBCKO data)
		{
			m_textDate.text = data.HJAFPEBIBOP_DateText;
			m_textDesc.text = data.GJLFANGDGCL_Desc;
			SetIconImage(data.CIANOCNPIFF_Type, data.IIAAIPNHJFJ_Value);
		}

		// // RVA: 0x173301C Offset: 0x173301C VA: 0x173301C
		private void SetIconImage(KPJHLACKGJF_EventMission.MNIIDKPECMD type, int value)
		{
			if(type == KPJHLACKGJF_EventMission.MNIIDKPECMD.CEPMMEKKNGC_3_All)
			{
				m_layout.StartChildrenAnimGoStop("05");
			}
			else if(type == KPJHLACKGJF_EventMission.MNIIDKPECMD.OLFDHLDEPKO_2_MusicAttr)
			{
				switch(value)
				{
					case 1:
						m_layout.StartChildrenAnimGoStop("01");
						break;
					case 2:
						m_layout.StartChildrenAnimGoStop("02");
						break;
					case 3:
						m_layout.StartChildrenAnimGoStop("03");
						break;
					case 4:
						m_layout.StartChildrenAnimGoStop("04");
						break;
					default:
						break;
				}
			}
			else if(type == KPJHLACKGJF_EventMission.MNIIDKPECMD.LNAOAANJGDM_1_SerieAttr)
			{
				m_imageLogo.enabled = false;
                SeriesLogoId.Type logoId = SeriesLogoId.ConvertFromAttr((SeriesAttr.Type)value);
				MenuScene.Instance.MenuResidentTextureCache.LoadLogo((int)logoId, (IiconTexture icon) =>
				{
					//0x1733514
					if(m_imageLogo != null)
					{
                		if(logoId == SeriesLogoId.ConvertFromAttr((SeriesAttr.Type)value))
						{
							m_imageLogo.enabled = true;
							icon.Set(m_imageLogo);
						}
					}
				});
				m_layout.StartChildrenAnimGoStop("06");
            }
			m_layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2);
			m_layout.UpdateAll(m_identity, Color.white);
		}

		// RVA: 0x1733434 Offset: 0x1733434 VA: 0x1733434 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewById("swtbl_target_music") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
