
using System;

public class SakashoFCMPushNotificationPayload
{
	public string Message { get; set; } // 0x8
	public Nullable<int> TimeToLive { get; set; } // 0xC
	public string IOSCategory { get; set; } // 0x14
	public Nullable<int> IOSBadgeNumber { get; } // 0x18
	public string IOSSoundPath { get; } // 0x20
	public string IOSMediaAttachment { get; } // 0x24
	public string AndroidMessageTitle { get; set; } // 0x28
	public string AndroidCollapseKey { get; set; } // 0x2C
	public string AndroidIconName { get; set; } // 0x30
	public string AndroidChannelId { get; set; } // 0x34
	public string Extras { get; } // 0x38
}
