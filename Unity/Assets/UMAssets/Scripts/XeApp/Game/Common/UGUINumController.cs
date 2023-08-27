using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	//[AddComponentMenu] // RVA: 0x64F8C8 Offset: 0x64F8C8 VA: 0x64F8C8
	public class UGUINumController : MonoBehaviour
	{
		private static readonly string ObjectNameDigits = "Digits"; // 0x0
		private static readonly string ObjectNameNum = "D{0}"; // 0x4
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68C8D8 Offset: 0x68C8D8 VA: 0x68C8D8
		private bool m_enableClampValue = true; // 0xC
		[SerializeField]
		private bool m_dispAllDigits; // 0xD
		[SerializeField]
		private Sprite m_spriteNum0; // 0x10
		[SerializeField]
		private Sprite m_spriteNum1; // 0x14
		[SerializeField]
		private Sprite m_spriteNum2; // 0x18
		[SerializeField]
		private Sprite m_spriteNum3; // 0x1C
		[SerializeField]
		private Sprite m_spriteNum4; // 0x20
		[SerializeField]
		private Sprite m_spriteNum5; // 0x24
		[SerializeField]
		private Sprite m_spriteNum6; // 0x28
		[SerializeField]
		private Sprite m_spriteNum7; // 0x2C
		[SerializeField]
		private Sprite m_spriteNum8; // 0x30
		[SerializeField]
		private Sprite m_spriteNum9; // 0x34
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68C9E4 Offset: 0x68C9E4 VA: 0x68C9E4
		private Animator m_animatorDigits; // 0x38
		[SerializeField]
		private List<Image> m_imagesNum; // 0x3C
		private List<Sprite> m_spliteListNum = new List<Sprite>(10); // 0x40

		// RVA: 0x1CD897C Offset: 0x1CD897C VA: 0x1CD897C
		private void Awake()
		{
			m_spliteListNum.Add(m_spriteNum0);
			m_spliteListNum.Add(m_spriteNum1);
			m_spliteListNum.Add(m_spriteNum2);
			m_spliteListNum.Add(m_spriteNum3);
			m_spliteListNum.Add(m_spriteNum4);
			m_spliteListNum.Add(m_spriteNum5);
			m_spliteListNum.Add(m_spriteNum6);
			m_spliteListNum.Add(m_spriteNum7);
			m_spliteListNum.Add(m_spriteNum8);
			m_spliteListNum.Add(m_spriteNum9);
			SetNum(0);
		}

		// // RVA: 0x1CD8BDC Offset: 0x1CD8BDC VA: 0x1CD8BDC
		public void SetNum(int num)
		{
			if(m_enableClampValue)
			{
				float f = Mathf.Pow(10, m_imagesNum.Count);
				num = Mathf.Clamp(num, 1 - (int)(f), (int)(f) - 1);
			}
			UpdateNums(num);
			UpdateDigits(num);
		}

		// // RVA: 0x1CD8CE8 Offset: 0x1CD8CE8 VA: 0x1CD8CE8
		private void UpdateNums(int num)
		{
			int v = Mathf.Abs(num);
			int i = 0;
			for(; i < m_imagesNum.Count; i++)
			{
				m_imagesNum[i].sprite = m_spliteListNum[v % 10];
				m_imagesNum[i].enabled = true;
				if(v < 10)
				{
					i++;
					break;
				}
				v /= 10;
			}
			for(; i < m_imagesNum.Count; i++)
			{
				m_imagesNum[i].sprite = m_spliteListNum[0];
				m_imagesNum[i].enabled = m_dispAllDigits;
			}
		}

		// // RVA: 0x1CD9008 Offset: 0x1CD9008 VA: 0x1CD9008
		private void UpdateDigits(int num)
		{
			int v = Mathf.Abs(num);
			int i = 0;
			for(; i < m_imagesNum.Count; i++)
			{
				if(v < 10)
				{
					i++;
					break;
				}
				v /= 10;
			}
			if(m_animatorDigits.hasBoundPlayables)
			{
				m_animatorDigits.CrossFade(string.Format("D{0}", i), 0);
			}
		}
	}
}
