
public class SakashoBbsThreadCriteria
{
	public int Op { get; } // 0x8
	public int ThreadOwnerId { get; } // 0xC
	public string ThreadGroup { get; set; } // 0x10
	public bool ExcludeBlockedThreads { get; set; } // 0x14
}
