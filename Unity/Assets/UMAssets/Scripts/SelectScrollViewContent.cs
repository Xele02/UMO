using UnityEngine;
using XeSys.Gfx;

public class SelectScrollViewContent : LayoutUGUIScriptBase, ISelectScrollViewContent
{
	// RVA: 0xDFEF40 Offset: 0xDFEF40 VA: 0xDFEF40 Slot: 8
	public virtual int GetIndex()
	{
		return transform.GetSiblingIndex();
	}

	// RVA: 0xDFEF74 Offset: 0xDFEF74 VA: 0xDFEF74 Slot: 9
	public virtual Vector2 GetItemSize()
	{
		return (transform as RectTransform).sizeDelta;
	}
}
