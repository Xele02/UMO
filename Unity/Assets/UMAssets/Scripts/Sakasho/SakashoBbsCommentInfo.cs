
public class SakashoBbsCommentInfo
{
	public string Content { get; set; } // 0x8
	public string Nickname { get; set; } // 0xC
	public string Extra { get; set; } // 0x10
	public int ReplyTo { get; } // 0x14
	public bool Sage { get; } // 0x18
}