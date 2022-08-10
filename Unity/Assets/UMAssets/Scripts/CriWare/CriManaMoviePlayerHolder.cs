using CriWare.CriMana;

namespace CriWare
{

    public class CriManaMoviePlayerHolder : CriMonoBehaviour
    {
        private Player _player; // 0x1C

        public Player player { set { _player = value; } } // 0x29634BC

        // // RVA: 0x2964844 Offset: 0x2964844 VA: 0x2964844
        private void Awake()
        {
            TodoLogger.Log(0, "TODO");
        }

        // // RVA: 0x29648C8 Offset: 0x29648C8 VA: 0x29648C8 Slot: 6
        public override void CriInternalUpdate()
        {
            TodoLogger.Log(0, "TODO");
        }

        // // RVA: 0x29648CC Offset: 0x29648CC VA: 0x29648CC Slot: 7
        public override void CriInternalLateUpdate()
        {
            TodoLogger.Log(0, "TODO");
        }

        // // RVA: 0x29648D0 Offset: 0x29648D0 VA: 0x29648D0
        private void Start()
        {
            TodoLogger.Log(0, "TODO");
        }
    }
}