using XeApp.Core;
using UnityEngine;

public class LayoutCheckScene : MainSceneBase
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	[SerializeField]
	private Canvas m_canvas;
	[SerializeField]
	private bool m_disableTransitionRoot;
	[SerializeField]
	private Font m_textFontOverride;
}
