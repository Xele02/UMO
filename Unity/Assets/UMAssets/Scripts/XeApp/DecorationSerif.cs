using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game;

namespace XeApp
{
	public class DecorationSerif : DecorationItemBase
	{
		private const int sizeOffset = 0;
		private static readonly int[] FontSizeTbl = new int[4]
		{
			-1, 16, 13, 11
		}; // 0x0
		private Text m_text; // 0x9C
		private string m_serifText; // 0xA0
		private DecorationChara m_chara; // 0xA4
		private int m_fontSize; // 0xA8
		private GameObject m_textObject; // 0xAC
		private TextMesh m_textMesh; // 0xB0
		private Renderer m_textRenderer; // 0xB4

		public override int SortingOrder { get { return base.SortingOrder; } set
		{
			m_textRenderer.sortingOrder = value;
			base.SortingOrder = value;
		} } //0xBB2CF4 0xBB2D3C

		// RVA: 0xBB2458 Offset: 0xBB2458 VA: 0xBB2458 Slot: 5
		protected override Action PreLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			DecorationSerifArgs arg = args as DecorationSerifArgs;
			m_viewDecoItemData.KHEKNNFCAOI(id, itemCategory);
			m_serifText = arg.m_text;
			m_chara = arg.m_chara;
			m_fontSize = FontSizeTbl[arg.m_fontSize];
			return LoadCallback;
		}

		// RVA: 0xBB2614 Offset: 0xBB2614 VA: 0xBB2614 Slot: 6
		protected override void PostLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			return;
		}

		// // RVA: 0xBB2618 Offset: 0xBB2618 VA: 0xBB2618
		private void LoadCallback()
		{
			SettingText();
			AttachChara();
			m_object.SetActive(true);
		}

		// // RVA: 0xBB2658 Offset: 0xBB2658 VA: 0xBB2658
		private void SettingText()
		{
			if(m_textObject == null)
			{
				m_textObject = new GameObject("Text");
				m_textObject.AddComponent<RectTransform>();
				m_textObject.layer = m_object.layer;
				m_textObject.transform.SetParent(m_object.transform, false);
				m_textMesh = m_textObject.AddComponent<TextMesh>();
				m_textRenderer = m_textObject.GetComponent<MeshRenderer>();
			}
			(m_textObject.transform as RectTransform).sizeDelta = Size;
			m_textMesh.alignment = TextAlignment.Center;
			m_textMesh.fontSize = m_fontSize;
			m_textMesh.characterSize = 12;
			m_textMesh.color = new Color(0.019f, 0.176f, 0.278f);
			m_textMesh.lineSpacing = 0.6f;
			m_textMesh.anchor = TextAnchor.MiddleCenter;
			m_textMesh.offsetZ = -0.1f;
			m_textMesh.text = m_serifText;
			GameManager.Instance.GetSystemFont().Apply(m_textMesh);
			m_textRenderer.sharedMaterial = m_textMesh.font.material;
			SortingOrder = m_chara.SortingOrder;
		}

		// // RVA: 0xBB2B9C Offset: 0xBB2B9C VA: 0xBB2B9C
		private void AttachChara()
		{
			m_chara.AttachSerif(this);
			m_chara.HideSerif();
		}

		// RVA: 0xBB2BF0 Offset: 0xBB2BF0 VA: 0xBB2BF0 Slot: 25
		public override void Show()
		{
			m_textRenderer.enabled = true;
			base.Show();
		}

		// RVA: 0xBB2C30 Offset: 0xBB2C30 VA: 0xBB2C30 Slot: 26
		public override void Hide()
		{
			if(m_textRenderer != null)
				m_textRenderer.enabled = false;
			base.Hide();
		}

		// RVA: 0xBB2D44 Offset: 0xBB2D44 VA: 0xBB2D44 Slot: 9
		protected override void PostInitController()
		{
			m_decorationContoller.SetEnable(false);
		}

		// RVA: 0xBB2D7C Offset: 0xBB2D7C VA: 0xBB2D7C Slot: 16
		protected override void PreDestroy()
		{
			return;
		}

		// RVA: 0xBB2D80 Offset: 0xBB2D80 VA: 0xBB2D80 Slot: 17
		protected override void PostDestroy()
		{
			return;
		}
	}
}
