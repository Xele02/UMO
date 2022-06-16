
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
        // public void .ctor(int id, int recentCapacity) { }

        // // RVA: 0x23A6B80 Offset: 0x23A6B80 VA: 0x23A6B80
        // public TouchInfo FindRecentInfo(int frameFromLatest) { }

        // // RVA: 0x23A6C0C Offset: 0x23A6C0C VA: 0x23A6C0C
        // public void Update(TouchPhase phase, Vector3 pos) { }

        // // RVA: 0x23A6E88 Offset: 0x23A6E88 VA: 0x23A6E88
        // public void UpdateReleased() { }

        // // RVA: 0x23A6C7C Offset: 0x23A6C7C VA: 0x23A6C7C
        // private void UpdateBegan(Vector3 pos) { }

        // // RVA: 0x23A6DA0 Offset: 0x23A6DA0 VA: 0x23A6DA0
        // private void UpdateStationary(Vector3 pos) { }

        // // RVA: 0x23A6DFC Offset: 0x23A6DFC VA: 0x23A6DFC
        // private void UpdateEnded(Vector3 pos) { }

        // // RVA: 0x23A6EF4 Offset: 0x23A6EF4 VA: 0x23A6EF4
        // private void UpdateRecent() { }

        // // RVA: 0x23A7004 Offset: 0x23A7004 VA: 0x23A7004
        // public float GetRecentDeltaDistance(int frame) { }

        // // RVA: 0x23A7160 Offset: 0x23A7160 VA: 0x23A7160
        // public bool IsFlick(int frame, float distanceRate) { }

        // // RVA: 0x23A720C Offset: 0x23A720C VA: 0x23A720C
        // public int GetSwipeAngleType(int divCount, bool isHalfOffset = True) { }

        // // RVA: 0x23A735C Offset: 0x23A735C VA: 0x23A735C
        // public int GetFlickAngleType(int divCount, int frame, float distanceRate, bool isHalfOffset = True) { }

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