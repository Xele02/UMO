
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class MusicSelectArgs : TransitionArgs
    {
        public class SelectionData
        {
            public FreeCategoryId.Type categoryId { get; internal set; } // 0x8
            public int freeMusicId { get; internal set; } // 0xC
            public Difficulty.Type difficulty { get; internal set; } // 0x10
            public OHCAABOMEOF.KGOGMKMBCPP_EventType eventCategory { get; internal set; } // 0x14
            public int miniGameId { get; internal set; } // 0x18

            // // RVA: 0x1054B20 Offset: 0x1054B20 VA: 0x1054B20
            public SelectionData()
            {
                miniGameId = 0;
                categoryId = 0;
                freeMusicId = -1;
                difficulty = 0;
            }
        }

        internal SelectionData selection { get; private set; } // 0x8
        internal bool hasSelection { get { return selection != null; } } //0x1054A18
        internal bool isScoreRanking { get; private set; } // 0xC
        public bool isSimulation { get; set; } // 0xD
        public bool isLine6Mode { get; set; } // 0xE

        // // RVA: 0x1054A50 Offset: 0x1054A50 VA: 0x1054A50
        // public void SetSelection(int freeMusicid, Difficulty.Type difficulty) { }

        // // RVA: 0x1054B70 Offset: 0x1054B70 VA: 0x1054B70
        public void SetSelection(int freeMusicId)
		{
			selection = new SelectionData();
			selection.freeMusicId = freeMusicId;
		}

        // // RVA: 0x1054C20 Offset: 0x1054C20 VA: 0x1054C20
        // public void SetSelection(Difficulty.Type difficulty) { }

        // // RVA: 0x1054CD0 Offset: 0x1054CD0 VA: 0x1054CD0
        public void SetSelection(FreeCategoryId.Type categoryId)
		{
			selection = new SelectionData();
			selection.categoryId = categoryId;
		}

        // // RVA: 0x1054D88 Offset: 0x1054D88 VA: 0x1054D88
        // public void SetSelection(OHCAABOMEOF.KGOGMKMBCPP eventCategory) { }

        // // RVA: 0x1054E40 Offset: 0x1054E40 VA: 0x1054E40
        public void SetSelectionMiniGame(int miniGameId)
		{
			selection = new SelectionData();
			selection.miniGameId = miniGameId;
		}

        // // RVA: 0x1054EF8 Offset: 0x1054EF8 VA: 0x1054EF8
        // public void SetScoreRanking() { }
    }
}
