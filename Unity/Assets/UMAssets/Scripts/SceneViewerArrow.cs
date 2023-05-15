using UnityEngine;
using XeSys.Gfx;

public class SceneViewerArrow : LayoutUGUIScriptBase
{
	private AbsoluteLayout m_arrowText; // 0x14

	// RVA: 0xDFE044 Offset: 0xDFE044 VA: 0xDFE044 Slot: 5
	public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
	{
		m_arrowText = layout.FindViewByExId("sw_cmn_arr_r_01_anim_swtbl_cmn_chk_open") as AbsoluteLayout;
		if(m_arrowText == null)
			m_arrowText = layout.FindViewByExId("sw_cmn_arr_l_01_anim_swtbl_cmn_chk_open2") as AbsoluteLayout;
		return true;
	}

	// RVA: 0xDFE18C Offset: 0xDFE18C VA: 0xDFE18C
	public void ChangeArrowText(bool _isDefault)
	{
		if(m_arrowText != null)
		{
			m_arrowText.StartChildrenAnimGoStop(_isDefault ? "01" : "02");
		}
		else
		{
			Debug.Log(JpStringLiterals.StringLiteral_13238);
		}
	}
}
