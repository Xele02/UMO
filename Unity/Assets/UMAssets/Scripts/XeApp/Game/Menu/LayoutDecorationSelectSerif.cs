using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSelectSerif : LayoutDecorationSelectItemBase
	{
		public static readonly string AssetName = "root_deco_item_02_layout_root"; // 0x0
		[SerializeField]
		private List<Text> m_texts = new List<Text>(); // 0xD4
		private int m_frameType; // 0xD8
		private AbsoluteLayout m_textTbl; // 0xDC

		// RVA: 0x18B7B9C Offset: 0x18B7B9C VA: 0x18B7B9C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_textTbl = layout.FindViewById("swtbl_ballon_text_01") as AbsoluteLayout;
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// RVA: 0x18B7C74 Offset: 0x18B7C74 VA: 0x18B7C74 Slot: 10
		public override void Setting(KDKFHGHGFEK item, int postNum, bool canKira, DecorationDecorator.TabType tab, LayoutDecorationWindow01.SelectItemType type, LayoutDecorationWindow01 window)
		{
			if(item.KGBAOKCMALD == 0)
			{
				SettingDisableSerif(item, postNum, window);
			}
			else
			{
				base.Setting(item, postNum, canKira, tab, type, window);
				if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					SettingSerif(item.GBJFNGCDKPM, item.DOIGLOBENMG, item.DBGAJBIBODC);
				}
				else
				{
					SettingBg(item.PPFNGGCBJKC_Id);
				}
			}
		}

		// RVA: 0x18B81A8 Offset: 0x18B81A8 VA: 0x18B81A8 Slot: 11
		public override void LoadTexture()
		{
			m_textureId = m_frameType;
			base.LoadTexture();
		}

		// // RVA: 0x18B7F70 Offset: 0x18B7F70 VA: 0x18B7F70
		private void SettingSerif(int frameType, string text, int fontSize)
		{
			m_frameType = frameType;
			int a = Mathf.Min(fontSize - 1, m_texts.Count - 1);
			m_textTbl.StartChildrenAnimGoStop(a, a);
			m_texts[a].text = text;
		}

		// // RVA: 0x18B7DD8 Offset: 0x18B7DD8 VA: 0x18B7DD8
		private void SettingDisableSerif(KDKFHGHGFEK item, int postNum, LayoutDecorationWindow01 window)
		{
			m_window = window;
			Data = item;
			m_frameType = 0;
			m_textTbl.StartChildrenAnimGoStop(0, 0);
			m_texts[0].text = "";
			SetEnabledExchangable(false);
			SetNewIcon(false);
			SetStatusIcon(-1 < postNum);
			SetNum(0, -postNum);
			SetDetailButtonHidden();
			SetData(0, 0, LayoutDecorationWindow01.SelectItemType.Serif);
			IsUpdateRestNum = false;
			m_selectItemTextureLoader = new SelectSerifTextureLoader();
		}

		// // RVA: 0x18B80C4 Offset: 0x18B80C4 VA: 0x18B80C4
		public void SettingBg(int id)
		{
			m_texts[0].text = "";
			m_textTbl.StartChildrenAnimGoStop(0, 0);
			m_frameType = id;
		}

		// RVA: 0x18B81B4 Offset: 0x18B81B4 VA: 0x18B81B4 Slot: 12
		public override void LayoutAllUpdate()
		{
			if(m_textTbl != null)
			{
				m_textTbl.UpdateAllAnimation(2 * TimeWrapper.deltaTime);
				m_textTbl.UpdateAll(new Matrix23(), Color.white);
			}
			base.LayoutAllUpdate();
		}
	}
}
