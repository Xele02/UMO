
public class SakashoBbsThreadInfo
{
	public const int NOT_SPECIFIED = -1;
	// public const int[] KEEP_ACCESSIBLE_PLAYER_IDS;
	public const int NOT_APPLY = 0;
	public const int APPLY = 1;

	public string Title { get; set; } // 0x8
	public string Detail { get; set; } // 0xC
	public string ThreadGroup { get; set; } // 0x10
	public string Extra { get; set; } // 0x14
	public int MinCommentBytes { get; set; } // 0x18
	public int MaxCommentBytes { get; set; } // 0x1C
	public int MaxComments { get; set; } // 0x20
	public int ExpireDays { get; set; } // 0x24
	public int ThreadScore { get; } // 0x28
	public int[] ReadPlayerIds { get; set; } // 0x2C
	public int[] WritePlayerIds { get; set; } // 0x30
	public int[] UpdatePlayerIds { get; set; } // 0x34
	public int ApplyOwnerBlacklist { get; set; } // 0x38

	// RVA: 0x3078C90 Offset: 0x3078C90 VA: 0x3078C90
	public SakashoBbsThreadInfo()
    {
        ReadPlayerIds = null;
        WritePlayerIds = null;
        UpdatePlayerIds = null;
        ApplyOwnerBlacklist = -1;
        MinCommentBytes = -1;
        MaxCommentBytes = -1;
        MaxComments = -1;
        ExpireDays = -1;
    }
}