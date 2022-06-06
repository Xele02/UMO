
namespace XeSys
{
    public class TouchInfoRecord
    {
        // Fields
        // [CompilerGeneratedAttribute] // RVA: 0x652E9C Offset: 0x652E9C VA: 0x652E9C
        // private int <id>k__BackingField; // 0x8
        // [CompilerGeneratedAttribute] // RVA: 0x652EAC Offset: 0x652EAC VA: 0x652EAC
        // private int <recentCapacity>k__BackingField; // 0xC
        // [CompilerGeneratedAttribute] // RVA: 0x652EBC Offset: 0x652EBC VA: 0x652EBC
        // private TouchInfo <currentInfo>k__BackingField; // 0x10
        // [CompilerGeneratedAttribute] // RVA: 0x652ECC Offset: 0x652ECC VA: 0x652ECC
        // private TouchInfo <beganInfo>k__BackingField; // 0x14
        // [CompilerGeneratedAttribute] // RVA: 0x652EDC Offset: 0x652EDC VA: 0x652EDC
        // private TouchInfo <endedInfo>k__BackingField; // 0x18
        private TouchInfo[] recentInfos; // 0x1C

        // Properties
        public int id { get; set; }
        public int recentCapacity { get; set; }
        public TouchInfo currentInfo { get; set; }
        public TouchInfo beganInfo { get; set; }
        public TouchInfo endedInfo { get; set; }

        // // Methods

        // [CompilerGeneratedAttribute] // RVA: 0x69127C Offset: 0x69127C VA: 0x69127C
        // // RVA: 0x23A699C Offset: 0x23A699C VA: 0x23A699C
        // public int get_id() { }

        // [CompilerGeneratedAttribute] // RVA: 0x69128C Offset: 0x69128C VA: 0x69128C
        // // RVA: 0x23A69A4 Offset: 0x23A69A4 VA: 0x23A69A4
        // private void set_id(int value) { }

        // [CompilerGeneratedAttribute] // RVA: 0x69129C Offset: 0x69129C VA: 0x69129C
        // // RVA: 0x23A69AC Offset: 0x23A69AC VA: 0x23A69AC
        // public int get_recentCapacity() { }

        // [CompilerGeneratedAttribute] // RVA: 0x6912AC Offset: 0x6912AC VA: 0x6912AC
        // // RVA: 0x23A69B4 Offset: 0x23A69B4 VA: 0x23A69B4
        // private void set_recentCapacity(int value) { }

        // [CompilerGeneratedAttribute] // RVA: 0x6912BC Offset: 0x6912BC VA: 0x6912BC
        // // RVA: 0x2389B88 Offset: 0x2389B88 VA: 0x2389B88
        // public TouchInfo get_currentInfo() { }

        // [CompilerGeneratedAttribute] // RVA: 0x6912CC Offset: 0x6912CC VA: 0x6912CC
        // // RVA: 0x23A69BC Offset: 0x23A69BC VA: 0x23A69BC
        // private void set_currentInfo(TouchInfo value) { }

        // [CompilerGeneratedAttribute] // RVA: 0x6912DC Offset: 0x6912DC VA: 0x6912DC
        // // RVA: 0x2389A3C Offset: 0x2389A3C VA: 0x2389A3C
        // public TouchInfo get_beganInfo() { }

        // [CompilerGeneratedAttribute] // RVA: 0x6912EC Offset: 0x6912EC VA: 0x6912EC
        // // RVA: 0x23A69C4 Offset: 0x23A69C4 VA: 0x23A69C4
        // private void set_beganInfo(TouchInfo value) { }

        // [CompilerGeneratedAttribute] // RVA: 0x6912FC Offset: 0x6912FC VA: 0x6912FC
        // // RVA: 0x23A69CC Offset: 0x23A69CC VA: 0x23A69CC
        // public TouchInfo get_endedInfo() { }

        // [CompilerGeneratedAttribute] // RVA: 0x69130C Offset: 0x69130C VA: 0x69130C
        // // RVA: 0x23A69D4 Offset: 0x23A69D4 VA: 0x23A69D4
        // private void set_endedInfo(TouchInfo value) { }

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