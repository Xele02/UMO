using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Common
{
	public class CommonDivaBalloon : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x6892D4 Offset: 0x6892D4 VA: 0x6892D4
		[SerializeField]
		private Image m_imageFrame; // 0xC
		//[HeaderAttribute] // RVA: 0x689328 Offset: 0x689328 VA: 0x689328
		[SerializeField]
		private Text m_textName; // 0x10
		//[HeaderAttribute] // RVA: 0x689384 Offset: 0x689384 VA: 0x689384
		[SerializeField]
		private Text m_textMessage; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6893E0 Offset: 0x6893E0 VA: 0x6893E0
		private InOutAnime m_inOutAnime; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x689428 Offset: 0x689428 VA: 0x689428
		private CanvasGroup m_canvasGroup; // 0x1C
		//[HeaderAttribute] // RVA: 0x689470 Offset: 0x689470 VA: 0x689470
		[SerializeField]
		private float m_intervalCloseWindowMax = 1; // 0x20
		private float m_intervalCloseWindow; // 0x24
		//[HeaderAttribute] // RVA: 0x6894B8 Offset: 0x6894B8 VA: 0x6894B8
		[SerializeField]
		private Color[] m_colorTable = new Color[10]
			{
				GetRgbColor(0xfb5a74),
				GetRgbColor(0x973cff),
				GetRgbColor(0xe7b300),
				GetRgbColor(0xff6ec3),
				GetRgbColor(0xccd5a),
				GetRgbColor(0xccd5a),
				GetRgbColor(0x973cff),
				GetRgbColor(0xff6ec3),
				GetRgbColor(0xf43650),
				GetRgbColor(0xf6cf7),
			}; // 0x28

		//// RVA: 0xE66168 Offset: 0xE66168 VA: 0xE66168
		private static Color GetRgbColor(uint color)
		{
			if(color < 0x1000000)
			{
				return new Color(((color >> 16) & 0xff) / 255.0f
					, ((color >> 8) & 0xff) / 255.0f
					, ((color) & 0xff) / 255.0f
					, 1);
			}
			else
			{
				return new Color(((color >> 24) & 0xff) / 255.0f
					, ((color >> 16) & 0xff) / 255.0f
					, ((color >> 8) & 0xff) / 255.0f
					, ((color) & 0xff) / 255.0f);
			}
		}

		// RVA: 0xE66220 Offset: 0xE66220 VA: 0xE66220
		private void Start()
		{
			m_textMessage.text = "";
		}

		// RVA: 0xE662E4 Offset: 0xE662E4 VA: 0xE662E4
		private void Update()
		{
			if(m_inOutAnime.IsEnter)
			{
				if(!SoundManager.Instance.voDiva.isPlaying)
				{
					if(!SoundManager.Instance.voDivaCos.isPlaying)
					{
						if (!SoundManager.Instance.voSeasonEvent.isPlaying)
						{
							m_intervalCloseWindow += Time.deltaTime;
							if(m_intervalCloseWindow > m_intervalCloseWindowMax)
							{
								Leave(false);
							}
						}
					}
				}
			}
		}

		//// RVA: 0xE66488 Offset: 0xE66488 VA: 0xE66488
		public void SetDiva(int divaId)
		{
			m_imageFrame.color = m_colorTable[divaId - 1];
			m_textName.text = MessageManager.Instance.GetBank("master").GetMessageByLabel("diva_" + divaId.ToString("D2"));
		}

		//// RVA: 0xE662A8 Offset: 0xE662A8 VA: 0xE662A8
		public void SetMessage(string message)
		{
			m_textMessage.text = message;
		}

		//// RVA: 0xE6663C Offset: 0xE6663C VA: 0xE6663C
		//public void SetActive(bool active) { }

		//// RVA: 0xE66714 Offset: 0xE66714 VA: 0xE66714
		public void Enter(bool force = false)
		{
			if (m_textMessage.text == "")
				return;
			m_inOutAnime.Enter(force, null);
			m_intervalCloseWindow = 0;
		}

		//// RVA: 0xE667DC Offset: 0xE667DC VA: 0xE667DC
		//public void Enter(float animTime, bool force = False) { }

		//// RVA: 0xE66450 Offset: 0xE66450 VA: 0xE66450
		public void Leave(bool force = false)
		{
			m_inOutAnime.Leave(force, null);
		}

		//// RVA: 0xE668B4 Offset: 0xE668B4 VA: 0xE668B4
		//public void Leave(float animTime, bool force = False) { }

		//// RVA: 0xE66900 Offset: 0xE66900 VA: 0xE66900
		//public bool IsPlaying() { }
	}
}
