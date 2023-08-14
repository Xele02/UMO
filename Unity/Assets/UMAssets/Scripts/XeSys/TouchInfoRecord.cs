
using UnityEngine;

namespace XeSys
{
    public class TouchInfoRecord
    {
        private TouchInfo[] recentInfos; // 0x1C

        public int id { get; private set; }  // 0x8
        public int recentCapacity { get; private set; } // 0xC
        public TouchInfo currentInfo { get; private set; } // 0x10
        public TouchInfo beganInfo { get; private set; } // 0x14
        public TouchInfo endedInfo { get; private set; } // 0x18

        // // RVA: 0x23A69DC Offset: 0x23A69DC VA: 0x23A69DC
        public TouchInfoRecord(int id, int recentCapacity)
        {
            this.id = id;
            this.recentCapacity = recentCapacity;
            recentInfos = new TouchInfo[recentCapacity];
            for(int i = 0; i < recentCapacity; i++)
            {
                recentInfos[i] = new TouchInfo();
            }
            currentInfo = new TouchInfo();
            beganInfo = new TouchInfo();
            endedInfo = new TouchInfo();
        }

        // // RVA: 0x23A6B80 Offset: 0x23A6B80 VA: 0x23A6B80
        public TouchInfo FindRecentInfo(int frameFromLatest)
		{
			if (frameFromLatest >= recentInfos.Length)
				return null;
			return recentInfos[recentInfos.Length - frameFromLatest - 1];
		}

        // // RVA: 0x23A6C0C Offset: 0x23A6C0C VA: 0x23A6C0C
        public void Update(TouchPhase phase, Vector3 pos)
        {
            if(phase == TouchPhase.Stationary || phase == TouchPhase.Moved)
                UpdateStationary(pos);
            else if(phase == TouchPhase.Ended || phase == TouchPhase.Canceled)
                UpdateEnded(pos);
            else if(phase == TouchPhase.Began)
                UpdateBegan(pos);
        }

        // // RVA: 0x23A6E88 Offset: 0x23A6E88 VA: 0x23A6E88
        public void UpdateReleased()
		{
			currentInfo.Initialize();
            beganInfo.Initialize();
            endedInfo.Initialize();
            UpdateRecent();
        }

        // // RVA: 0x23A6C7C Offset: 0x23A6C7C VA: 0x23A6C7C
        private void UpdateBegan(Vector3 pos)
        {
            for(int i = 0; i < recentInfos.Length; i++)
            {
                recentInfos[i].Initialize();
            }
            currentInfo.Setup(id, TouchState.BEGAN, pos);
            beganInfo.Setup(id, TouchState.BEGAN, pos);
            endedInfo.Initialize();
            UpdateRecent();
        }

        // // RVA: 0x23A6DA0 Offset: 0x23A6DA0 VA: 0x23A6DA0
        private void UpdateStationary(Vector3 pos)
        {
            currentInfo.Setup(id, TouchState.MOVED, pos);
            UpdateRecent();
        }

        // // RVA: 0x23A6DFC Offset: 0x23A6DFC VA: 0x23A6DFC
        private void UpdateEnded(Vector3 pos)
        {
            currentInfo.Setup(id, TouchState.ENDED, pos);
            endedInfo.Setup(id, TouchState.ENDED, pos);
            UpdateRecent();
        }

        // // RVA: 0x23A6EF4 Offset: 0x23A6EF4 VA: 0x23A6EF4
        private void UpdateRecent()
        {
            for(int i = 0; i < recentInfos.Length - 1; i++)
            {
                recentInfos[i].Copy(recentInfos[i+1]);
            }
            recentInfos[recentInfos.Length - 1].Copy(currentInfo);
        }

        // // RVA: 0x23A7004 Offset: 0x23A7004 VA: 0x23A7004
        public float GetRecentDeltaDistance(int frame)
		{
			TouchInfo info = FindRecentInfo(frame);
			if(info.state != TouchState.ILLEGAL && currentInfo.state != TouchState.ILLEGAL)
			{
				return (info.position - currentInfo.position).magnitude;
			}
			return 0;
		}

        // // RVA: 0x23A7160 Offset: 0x23A7160 VA: 0x23A7160
        public bool IsFlick(int frame, float distanceRate)
		{
			return distanceRate <= GetRecentDeltaDistance(frame) / new Vector2(Screen.width, Screen.height).sqrMagnitude;
		}

        // // RVA: 0x23A720C Offset: 0x23A720C VA: 0x23A720C
        // public int GetSwipeAngleType(int divCount, bool isHalfOffset = True) { }

        // // RVA: 0x23A735C Offset: 0x23A735C VA: 0x23A735C
        public int GetFlickAngleType(int divCount, int frame, float distanceRate, bool isHalfOffset = true)
		{
			int res = -1;
			TouchInfo info = FindRecentInfo(frame);
			if (info.state != TouchState.ILLEGAL)
			{
				if (currentInfo.state != TouchState.ILLEGAL && IsFlick(frame, distanceRate))
				{
					res = Math.CalcAngleType(divCount, info.position, currentInfo.position, isHalfOffset);
				}
			}
			return res;
		}

        // // RVA: 0x23A7474 Offset: 0x23A7474 VA: 0x23A7474
        // public float GetSwipeRadian() { }

        // // RVA: 0x23A75C0 Offset: 0x23A75C0 VA: 0x23A75C0
        // public float GetFlickRadian(int frame, float distanceRate) { }

        // // RVA: 0x23A7704 Offset: 0x23A7704 VA: 0x23A7704
        // public float GetSwipeDegree() { }

        // // RVA: 0x23A7728 Offset: 0x23A7728 VA: 0x23A7728
        // public float GetFlickDegree(int frame, float distance) { }
    }
}
