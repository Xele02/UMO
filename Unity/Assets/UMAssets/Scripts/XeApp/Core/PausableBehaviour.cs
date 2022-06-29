using UnityEngine;

namespace XeApp.Core
{
	public abstract class PausableBehaviour : MonoBehaviour
	{
		public static bool isPause; // 0x0

		// RVA: 0x1D74788 Offset: 0x1D74788 VA: 0x1D74788
		private void Awake()
		{
			PausableAwake();
		}

		// RVA: 0x1D74798 Offset: 0x1D74798 VA: 0x1D74798
		private void Start()
		{
			PausableStart();
		}

		// RVA: 0x1D747A8 Offset: 0x1D747A8 VA: 0x1D747A8
		private void Update()
		{
			if(!isPause)
			{
				if(IsPause())
				{
					PausableInPause();
				}
				else
				{
					PausableUpdate();
				}
			}
			else
			{
				PausableInPause();
			}
		}

		// // RVA: 0x1D74888 Offset: 0x1D74888 VA: 0x1D74888 Slot: 4
		protected virtual bool IsPause()
		{
			return false;
		}

		// // RVA: -1 Offset: -1 Slot: 5
		protected abstract void PausableAwake();

		// // RVA: -1 Offset: -1 Slot: 6
		protected abstract void PausableStart();

		// // RVA: -1 Offset: -1 Slot: 7
		protected abstract void PausableUpdate();

		// // RVA: -1 Offset: -1 Slot: 8
		protected abstract void PausableInPause();
	}
}
