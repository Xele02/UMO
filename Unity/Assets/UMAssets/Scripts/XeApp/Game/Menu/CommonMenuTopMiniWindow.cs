using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using XeApp.Game.Common;
using System.Collections.Generic;
using mcrs;

namespace XeApp.Game.Menu
{
	public class CommonMenuTopMiniWindow : MonoBehaviour
	{
		public enum Type
		{
			UtaRate = 0,
			Rank = 1,
		}

		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66AC60 Offset: 0x66AC60 VA: 0x66AC60
		private GameObject m_rootMain; // 0xC
		//[HeaderAttribute] // RVA: 0x66ACB0 Offset: 0x66ACB0 VA: 0x66ACB0
		[SerializeField]
		private GameObject m_rootText; // 0x10
		//[HeaderAttribute] // RVA: 0x66AD0C Offset: 0x66AD0C VA: 0x66AD0C
		[SerializeField]
		private Text m_textNext; // 0x14
		[SerializeField]
		private Text m_textPoint; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66AD64 Offset: 0x66AD64 VA: 0x66AD64
		private GameObject m_rootItem; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66ADC0 Offset: 0x66ADC0 VA: 0x66ADC0
		private RawImageEx m_imageItem; // 0x20
		//[HeaderAttribute] // RVA: 0x66AE14 Offset: 0x66AE14 VA: 0x66AE14
		[SerializeField]
		private ButtonBase m_button; // 0x24
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66AE5C Offset: 0x66AE5C VA: 0x66AE5C
		private InOutAnime m_inOutAnime; // 0x28
		//[HeaderAttribute] // RVA: 0x66AEA4 Offset: 0x66AEA4 VA: 0x66AEA4
		[SerializeField]
		private List<Vector2> m_position = new List<Vector2>() {
			new Vector2(-370, -74), new Vector2(-440, -60)
		}; // 0x2C
		public bool m_isEnter; // 0x30

		// RVA: 0x1B4F310 Offset: 0x1B4F310 VA: 0x1B4F310
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x1B4F514
				Leave();
			});
			m_textNext.text = JpStringLiterals.UMO_Next;
		}

		// RVA: 0x1B4DEC0 Offset: 0x1B4DEC0 VA: 0x1B4DEC0
		public void SetFont(XeSys.FontInfo fontInfo)
		{
			//m_textNext.font = font;
			fontInfo.Apply(m_textNext);
			//m_textPoint.font = font;
			fontInfo.Apply(m_textPoint);
		}

		// RVA: 0x1B4DF1C Offset: 0x1B4DF1C VA: 0x1B4DF1C
		public void Setup(Type type, string text, int itemId = 0)
		{
			m_textPoint.text = text;
			(m_rootMain.transform as RectTransform).anchoredPosition = m_position[(int)type];
			if(itemId <1)
			{
				m_rootItem.gameObject.SetActive(false);
				(m_rootText.transform as RectTransform).sizeDelta = new Vector2(130, (m_rootText.transform as RectTransform).sizeDelta.y);
			}
			else
			{
				m_rootItem.gameObject.SetActive(true);
				(m_rootText.transform as RectTransform).sizeDelta = new Vector2(80, (m_rootText.transform as RectTransform).sizeDelta.y);
				m_imageItem.enabled = false;
				GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
				{
					//0x1B4F518
					m_imageItem.enabled = true;
					texture.Set(m_imageItem);
				});
			}
		}

		// RVA: 0x1B4E2F4 Offset: 0x1B4E2F4 VA: 0x1B4E2F4
		public void Enter()
		{
			if(IsPlaying())
				return;
			m_isEnter = true;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_inOutAnime.Enter(false, null);
			transform.SetAsLastSibling();
			if(MenuScene.Instance != null)
				MenuScene.Instance.InputDisable();
			m_button.gameObject.SetActive(true);
			GameManager.Instance.AddPushBackButtonHandler(Leave);
		}

		// // RVA: 0x1B4E994 Offset: 0x1B4E994 VA: 0x1B4E994
		public void Leave()
		{
			if(IsPlaying())
				return;
			if(!m_isEnter)
				return;
			m_isEnter = false;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_inOutAnime.Leave(false, null);
			m_button.gameObject.SetActive(false);
			if(MenuScene.Instance != null)
				MenuScene.Instance.InputEnable();
			GameManager.Instance.RemovePushBackButtonHandler(Leave);
		}

		// // RVA: 0x1B4ECD4 Offset: 0x1B4ECD4 VA: 0x1B4ECD4
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
