using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class NumberAnimationUtility : MonoBehaviour
	{
		//[IteratorStateMachineAttribute] // RVA: 0x73BF28 Offset: 0x73BF28 VA: 0x73BF28
		//// RVA: 0xAF37F4 Offset: 0xAF37F4 VA: 0xAF37F4
		public static IEnumerator Co_FakeCountup(int targetNumber, List<float> countTimeList, Action<int> onChangeNumberCakllback, Action onFinished, Func<bool> onSkiped)
		{
			List<int> lastDigitNumber; // 0x24
			int fixedNumber; // 0x28
			bool isSkip; // 0x2C
			int i; // 0x30
			float time; // 0x34
			float count; // 0x38

			//0xAF3A04
			if(targetNumber == 0)
			{
				onChangeNumberCakllback(0);
			}
			else
			{
				lastDigitNumber = new List<int>(countTimeList.Count);
				if(targetNumber > 0)
				{
					while (true)
					{
						lastDigitNumber.Add(targetNumber % 10);
						targetNumber /= 10;
						if (targetNumber < 10)
							break;
					}
				}
				isSkip = false;
				fixedNumber = 0;
				for(i = 0; i < lastDigitNumber.Count; i++)
				{
					time = countTimeList[i];
					count = 0.0f;
					do
					{
						int rand = UnityEngine.Random.Range(1, 10);
						float f = Mathf.Pow(10, i);
						onChangeNumberCakllback(fixedNumber + (int)(f * rand));
						count += Time.deltaTime;
						if (onSkiped == null || !onSkiped())
							yield return null;
						else
							isSkip = true;
					} while (count < time && !isSkip);
					fixedNumber = fixedNumber + (int)(Mathf.Pow(10, i) * lastDigitNumber[i]);
					onChangeNumberCakllback(fixedNumber);
				}
			}
			if (onFinished != null)
				onFinished();

		}

		// RVA: 0xAF390C Offset: 0xAF390C VA: 0xAF390C
		public static void MakeAccelerationTimeList(int digitMax, float initTime, float decreaseTime, ref List<float> timerList)
		{
			timerList.Clear();
			for(int i = 0; i < digitMax; i++)
			{
				timerList.Add(initTime - i * decreaseTime);
			}
		}
	}
}
