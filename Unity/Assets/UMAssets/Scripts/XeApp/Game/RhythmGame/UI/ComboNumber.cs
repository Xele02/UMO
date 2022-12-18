using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class ComboNumber : MonoBehaviour
	{
		[SerializeField]
		private NumericMesh m_comboNumericMesh; // 0xC
		[SerializeField]
		private NumericMesh m_comboEffNumericMesh; // 0x10
		[SerializeField]
		private GameObject m_comboRootObject; // 0x14
		[SerializeField]
		private Animator m_animator; // 0x18
		[SerializeField]
		private Animator m_effAnimator; // 0x1C
		private int m_preValue; // 0x20
		private const int CountupValue1 = 10;
		private const int CountupValue2 = 50;
		private static readonly int Combo_S_Hash = Animator.StringToHash("Combo_S"); // 0x0
		private static readonly int Combo_L_Hash = Animator.StringToHash("Combo_L"); // 0x4
		private static readonly int ComboEff_Hash = Animator.StringToHash("Combo_eff"); // 0x8

		// RVA: 0x155AA58 Offset: 0x155AA58 VA: 0x155AA58
		private void Awake()
		{
			m_effAnimator.Play(ComboEff_Hash, 0, 1);
		}

		// RVA: 0x155AB20 Offset: 0x155AB20 VA: 0x155AB20
		public void SetValue(int value, int modeType)
		{
			bool b = false;
			if(m_preValue < value)
			{
				if(value >= 2 && (value - m_preValue) >=1)
				{
					for(int i = 0; i < value - m_preValue; i++)
					{
						int a = m_preValue + i + 1;
						b = false;
						if(a % 10 == 0)
							b = true;
						if(a % 50 == 0)
						{
							m_preValue = a;
							m_effAnimator.Play(ComboEff_Hash, 0, 0);
							m_comboEffNumericMesh.SetNumber(m_preValue, modeType);
							break;
						}
					}
					m_preValue += value - m_preValue;
				}
			}
			if(b)
			{
				m_animator.Play(Combo_L_Hash, 0, 0);
			}
			else
			{
				m_animator.Play(Combo_S_Hash, 0, 0);
			}
			m_comboNumericMesh.SetNumber(value, modeType);
			m_comboRootObject.SetActive(value > 1);
			m_preValue = value;
		}
	}
}
