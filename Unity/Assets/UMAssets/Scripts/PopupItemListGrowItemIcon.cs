using XeApp.Game.Menu;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Text;
using XeSys;
using mcrs;

public class PopupItemListGrowItemIcon : FlexibleListItemLayout
{
	[SerializeField]
	private RawImageEx[] m_iconImages; // 0x18
	[SerializeField]
	private RawImageEx[] m_frameImages; // 0x1C
	[SerializeField]
	private Text[] m_countTexts; // 0x20
	[SerializeField]
	private StayButton[] m_stayButtons; // 0x24
	private TexUVListManager m_uvMan; // 0x28
	private StringBuilder m_strBuilder = new StringBuilder(64); // 0x2C

	// RVA: 0xDF9154 Offset: 0xDF9154 VA: 0xDF9154 Slot: 5
	public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
	{
		ClearLoadedCallback();
		m_uvMan = uvMan;
		for(int i = 0; i < m_countTexts.Length; i++)
		{
			m_countTexts[i].horizontalOverflow = HorizontalWrapMode.Wrap;
			m_countTexts[i].verticalOverflow = VerticalWrapMode.Truncate;
			m_countTexts[i].resizeTextForBestFit = true;
		}
		return true;
	}

	//// RVA: 0xDF92A4 Offset: 0xDF92A4 VA: 0xDF92A4
	public void UpdateContent(int id, int count, int index)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		MenuScene.Instance.ItemTextureCache.Load(id, (IiconTexture texture) =>
		{
			//0xDF99EC
			texture.Set(m_iconImages[index]);
		});
		m_countTexts[index].text = string.Format(bk.GetMessageByLabel("growth_popup_text01"), count);
		m_stayButtons[index].ClearOnClickCallback();
		m_stayButtons[index].AddOnClickCallback(() =>
		{
			//0xDF9B18
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupItemListItemIcon.ShowItemDetail(id, count);
		});
		m_stayButtons[index].ClearOnStayCallback();
		m_stayButtons[index].AddOnStayCallback(() =>
		{
			//0xDF9FD8
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupItemListItemIcon.ShowItemDetail(id, count);
		});
	}

	//// RVA: 0xDF973C Offset: 0xDF973C VA: 0xDF973C
	//private void ChangeFrameColor(int colorIndex) { }
}
