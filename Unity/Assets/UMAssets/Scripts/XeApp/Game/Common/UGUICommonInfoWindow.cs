using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUICommonInfoWindow : MonoBehaviour
	{
		public enum Direction
		{
			None = 0,
			Left = 1,
			Right = 2,
			Top = 3,
			Bottom = 4,
		}
		
		//[HeaderAttribute] // RVA: 0x68C23C Offset: 0x68C23C VA: 0x68C23C
		[SerializeField]
		private Direction m_direction; // 0xC
		//[HeaderAttribute] // RVA: 0x68C298 Offset: 0x68C298 VA: 0x68C298
		[SerializeField]
		private RectTransform m_root; // 0x10
		//[HeaderAttribute] // RVA: 0x68C2F4 Offset: 0x68C2F4 VA: 0x68C2F4
		[SerializeField]
		private Image m_imageTelop; // 0x14
		//[HeaderAttribute] // RVA: 0x68C348 Offset: 0x68C348 VA: 0x68C348
		[SerializeField]
		private Image m_imageArrow; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68C398 Offset: 0x68C398 VA: 0x68C398
		private Image m_imageIcon; // 0x1C
		//[HeaderAttribute] // RVA: 0x68C3F0 Offset: 0x68C3F0 VA: 0x68C3F0
		[SerializeField]
		private Text m_textMessage; // 0x20
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68C438 Offset: 0x68C438 VA: 0x68C438
		private InOutAnime m_inOutAnime; // 0x24
		private static readonly Vector3[] s_arrowAngles = new Vector3[5] {
			new Vector3(0, 0, 0),
			new Vector3(0, 0, 0),
			new Vector3(0, 0, 180),
			new Vector3(0, 0, 270),
			new Vector3(0, 0, 90),
		}; // 0x0

		// RVA: 0x1CD181C Offset: 0x1CD181C VA: 0x1CD181C
		private void Start()
		{
			SetDirection(m_direction);
		}

		// RVA: 0x1CD1B9C Offset: 0x1CD1B9C VA: 0x1CD1B9C
		private void OnValidate()
		{
			SetDirection(m_direction);
		}

		//// RVA: 0x1CD1BA4 Offset: 0x1CD1BA4 VA: 0x1CD1BA4
		public void Setup(string text, Sprite sprite)
		{
			if(sprite != null)
			{
				m_imageIcon.gameObject.SetActive(true);
				m_imageIcon.sprite = sprite;
			}
			else
			{
				m_imageIcon.gameObject.SetActive(false);
			}
			m_textMessage.text = text;
		}

		//// RVA: 0x1CD1824 Offset: 0x1CD1824 VA: 0x1CD1824
		public void SetDirection(Direction dir)
		{
			Vector2 a = new Vector2(0.5f, 0.5f);
			Vector3 pos = m_root.position;
			m_direction = dir;
			switch(dir)
			{
				case Direction.None:
					m_imageArrow.enabled = false;
					break;
				case Direction.Left:
					a = new Vector2(0, 0.5f);
					m_imageArrow.enabled = true;
					break;
				case Direction.Right:
					a = new Vector2(1, 0.5f);
					m_imageArrow.enabled = true;
					break;
				case Direction.Top:
					a = new Vector2(0.5f, 1);
					m_imageArrow.enabled = true;
					break;
				case Direction.Bottom:
					a = new Vector2(0.5f, 0);
					m_imageArrow.enabled = true;
					break;
				default:
					break;
			}
			(m_imageArrow.transform as RectTransform).eulerAngles = s_arrowAngles[(int)m_direction];
			(m_imageArrow.transform as RectTransform).anchorMin = a;
			m_root.anchorMin = a;
			(m_imageArrow.transform as RectTransform).anchorMax = a;
			m_root.anchorMax = a;
			(m_imageArrow.transform as RectTransform).pivot = a;
			m_root.pivot = a;
		}

		//// RVA: 0x1CD1CE4 Offset: 0x1CD1CE4 VA: 0x1CD1CE4
		public void SetTelopColor(Color color)
		{
			m_imageTelop.color = color;
		}

		//// RVA: 0x1CD1D44 Offset: 0x1CD1D44 VA: 0x1CD1D44
		public void Enter(bool force = false)
		{
			m_inOutAnime.Enter(force, null);
		}

		//// RVA: 0x1CD1D7C Offset: 0x1CD1D7C VA: 0x1CD1D7C
		//public void Enter(float animTime, bool force = False) { }

		//// RVA: 0x1CD1DC8 Offset: 0x1CD1DC8 VA: 0x1CD1DC8
		public void Leave(bool force = false)
		{
			m_inOutAnime.Leave(force, null);
		}

		//// RVA: 0x1CD1E00 Offset: 0x1CD1E00 VA: 0x1CD1E00
		//public void Leave(float animTime, bool force = False) { }

		//// RVA: 0x1CD1E4C Offset: 0x1CD1E4C VA: 0x1CD1E4C
		//public bool IsPlaying() { }
	}
}
