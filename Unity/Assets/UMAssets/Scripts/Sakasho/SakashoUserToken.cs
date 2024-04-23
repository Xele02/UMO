using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoUserToken : SakashoAPIBase
{
	// // RVA: 0x2E6D2E4 Offset: 0x2E6D2E4 VA: 0x2E6D2E4
	public static SakashoAPICallContext CreatePlayer(int accountType, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["accountType"] = accountType;
		return new SakashoAPICallContext(Call(SakashoUserTokenCreatePlayer, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E6D3C8 Offset: 0x2E6D3C8 VA: 0x2E6D3C8
	// private static SakashoAPICallContext CreatePlayerSession(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6D4AC Offset: 0x2E6D4AC VA: 0x2E6D4AC
	public static SakashoAPICallContext GetPlayerStatus(OnSuccess onSuccess, OnError onError)
    {
        return new SakashoAPICallContext(Call(SakashoUserTokenGetPlayerStatus, "", onSuccess, onError));
    }

	// // RVA: 0x2E6D590 Offset: 0x2E6D590 VA: 0x2E6D590
	// public static void ClearDeviceLoginData() { }

	// // RVA: 0x2E6D62C Offset: 0x2E6D62C VA: 0x2E6D62C
	// public static void SetDeviceName(string deviceName, string gameId) { }

	// // RVA: 0x2E6D7A0 Offset: 0x2E6D7A0 VA: 0x2E6D7A0
	// public static void SetUserToken(string userToken, string gameId) { }

	// // RVA: 0x2E6D914 Offset: 0x2E6D914 VA: 0x2E6D914
	// public static SakashoAPICallContext GetDeviceName(string gameId, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6DA8C Offset: 0x2E6DA8C VA: 0x2E6DA8C
	// public static SakashoAPICallContext GetUserToken(string gameId, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6DC04 Offset: 0x2E6DC04 VA: 0x2E6DC04
	// public static SakashoAPICallContext CreatePlayerFromFacebookToken(string accessToken, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6DDD8 Offset: 0x2E6DDD8 VA: 0x2E6DDD8
	// public static SakashoAPICallContext CreatePlayerFromFacebookToken(string accessToken, bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6DFAC Offset: 0x2E6DFAC VA: 0x2E6DFAC
	// public static SakashoAPICallContext CreatePlayerFromPassphraseWithPlayerId(int originalPlayerId, string passphrase, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6E1B4 Offset: 0x2E6E1B4 VA: 0x2E6E1B4
	// public static SakashoAPICallContext CreatePlayerFromPassphraseWithPlayerId(int originalPlayerId, string passphrase, bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6E3C0 Offset: 0x2E6E3C0 VA: 0x2E6E3C0
	public static SakashoAPICallContext CreatePlayerFromTwitter(OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["keepOtherPlayerDevices"] = false;
		return new SakashoAPICallContext(Call(SakashoUserTokenCreatePlayerFromTwitter, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E6E550 Offset: 0x2E6E550 VA: 0x2E6E550
	// public static SakashoAPICallContext CreatePlayerFromTwitter(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6E6E0 Offset: 0x2E6E6E0 VA: 0x2E6E6E0
	public static SakashoAPICallContext CreatePlayerFromLine(OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["keepOtherPlayerDevices"] = false;
		return new SakashoAPICallContext(Call(SakashoUserTokenCreatePlayerFromLine, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E6E870 Offset: 0x2E6E870 VA: 0x2E6E870
	// public static SakashoAPICallContext CreatePlayerFromLine(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6EA00 Offset: 0x2E6EA00 VA: 0x2E6EA00
	public static SakashoAPICallContext CreatePlayerFromFacebook(OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["keepOtherPlayerDevices"] = false;
		return new SakashoAPICallContext(Call(SakashoUserTokenCreatePlayerFromFacebook, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E6EB90 Offset: 0x2E6EB90 VA: 0x2E6EB90
	// public static SakashoAPICallContext CreatePlayerFromFacebook(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6ED20 Offset: 0x2E6ED20 VA: 0x2E6ED20
	// public static SakashoAPICallContext ActivateDevice(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6EE04 Offset: 0x2E6EE04 VA: 0x2E6EE04
	// public static SakashoAPICallContext SwitchPlayer(int originalPlayerId, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6EF94 Offset: 0x2E6EF94 VA: 0x2E6EF94
	// public static SakashoAPICallContext CreatePlayerFromGoogle(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6F124 Offset: 0x2E6F124 VA: 0x2E6F124
	// public static SakashoAPICallContext CreatePlayerFromGameCenter(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6F2B4 Offset: 0x2E6F2B4 VA: 0x2E6F2B4
	// public static SakashoAPICallContext GetFacebookAuthenticateUrl(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6F444 Offset: 0x2E6F444 VA: 0x2E6F444
	// public static SakashoAPICallContext GetLineAuthenticateUrl(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6F5D4 Offset: 0x2E6F5D4 VA: 0x2E6F5D4
	// public static SakashoAPICallContext GetTwitterAuthenticateUrl(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6F764 Offset: 0x2E6F764 VA: 0x2E6F764
	// public static SakashoAPICallContext CreatePlayerFromApple(bool keepOtherPlayerDevices, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6F8F4 Offset: 0x2E6F8F4 VA: 0x2E6F8F4
	// public static void CancelCreatePlayerFromFacebookBeforeOauth() { }

	// // RVA: 0x2E6F990 Offset: 0x2E6F990 VA: 0x2E6F990
	// public static void CancelCreatePlayerFromLineBeforeOauth() { }

	// // RVA: 0x2E6FA2C Offset: 0x2E6FA2C VA: 0x2E6FA2C
	// public static void CancelCreatePlayerFromTwitterBeforeOauth() { }

	// // RVA: 0x2E6FAC8 Offset: 0x2E6FAC8 VA: 0x2E6FAC8
	public static SakashoAPICallContext ClearDeviceLoginDataWithLog(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoUserTokenClearDeviceLoginDataWithLog, "", onSuccess, onError));
	}

	// // RVA: 0x2E6FBB0 Offset: 0x2E6FBB0 VA: 0x2E6FBB0
	private static /*extern */int SakashoUserTokenCreatePlayer(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoUserTokenCreatePlayer(callbackId, json);
	}

	// // RVA: 0x2E6FCC0 Offset: 0x2E6FCC0 VA: 0x2E6FCC0
	// private static extern int SakashoUserTokenCreatePlayerSession(int callbackId, string json) { }

	// // RVA: 0x2E6FDD0 Offset: 0x2E6FDD0 VA: 0x2E6FDD0
	private static /*extern*/ int SakashoUserTokenGetPlayerStatus(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoUserTokenGetPlayerStatus(callbackId, json);
    }

	// // RVA: 0x2E6FEE0 Offset: 0x2E6FEE0 VA: 0x2E6FEE0
	// private static extern int SakashoUserTokenClearDeviceLoginData(int callbackId, string json) { }

	// // RVA: 0x2E6FFF8 Offset: 0x2E6FFF8 VA: 0x2E6FFF8
	// private static extern int SakashoUserTokenSetDeviceName(int callbackId, string json) { }

	// // RVA: 0x2E70108 Offset: 0x2E70108 VA: 0x2E70108
	// private static extern int SakashoUserTokenSetUserToken(int callbackId, string json) { }

	// // RVA: 0x2E70218 Offset: 0x2E70218 VA: 0x2E70218
	// private static extern int SakashoUserTokenGetDeviceName(int callbackId, string json) { }

	// // RVA: 0x2E70328 Offset: 0x2E70328 VA: 0x2E70328
	// private static extern int SakashoUserTokenGetUserToken(int callbackId, string json) { }

	// // RVA: 0x2E70438 Offset: 0x2E70438 VA: 0x2E70438
	// private static extern int SakashoUserTokenCreatePlayerFromFacebookToken(int callbackId, string json) { }

	// // RVA: 0x2E70558 Offset: 0x2E70558 VA: 0x2E70558
	// private static extern int SakashoUserTokenCreatePlayerFromPassphraseWithPlayerId(int callbackId, string json) { }

	// // RVA: 0x2E70680 Offset: 0x2E70680 VA: 0x2E70680
	private static int SakashoUserTokenCreatePlayerFromTwitter(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoUserTokenCreatePlayerFromTwitter(callbackId, json);
	}

	// // RVA: 0x2E70798 Offset: 0x2E70798 VA: 0x2E70798
	private static int SakashoUserTokenCreatePlayerFromLine(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoUserTokenCreatePlayerFromLine(callbackId, json);
	}

	// // RVA: 0x2E708B0 Offset: 0x2E708B0 VA: 0x2E708B0
	private static int SakashoUserTokenCreatePlayerFromFacebook(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoUserTokenCreatePlayerFromFacebook(callbackId, json);
	}

	// // RVA: 0x2E709C8 Offset: 0x2E709C8 VA: 0x2E709C8
	// private static extern int SakashoUserTokenActivateDevice(int callbackId, string json) { }

	// // RVA: 0x2E70AD8 Offset: 0x2E70AD8 VA: 0x2E70AD8
	// private static extern int SakashoUserTokenSwitchPlayer(int callbackId, string json) { }

	// // RVA: 0x2E70BE8 Offset: 0x2E70BE8 VA: 0x2E70BE8
	// private static extern int SakashoUserTokenCreatePlayerFromGoogle(int callbackId, string json) { }

	// // RVA: 0x2E70D00 Offset: 0x2E70D00 VA: 0x2E70D00
	// private static extern int SakashoUserTokenCreatePlayerFromGameCenter(int callbackId, string json) { }

	// // RVA: 0x2E70E18 Offset: 0x2E70E18 VA: 0x2E70E18
	// private static extern int SakashoUserTokenGetFacebookAuthenticateUrl(int callbackId, string json) { }

	// // RVA: 0x2E70F30 Offset: 0x2E70F30 VA: 0x2E70F30
	// private static extern int SakashoUserTokenGetLineAuthenticateUrl(int callbackId, string json) { }

	// // RVA: 0x2E71048 Offset: 0x2E71048 VA: 0x2E71048
	// private static extern int SakashoUserTokenGetTwitterAuthenticateUrl(int callbackId, string json) { }

	// // RVA: 0x2E71160 Offset: 0x2E71160 VA: 0x2E71160
	// private static extern int SakashoUserTokenCreatePlayerFromApple(int callbackId, string json) { }

	// // RVA: 0x2E71278 Offset: 0x2E71278 VA: 0x2E71278
	// private static extern int SakashoUserTokenCancelCreatePlayerFromFacebookBeforeOauth(int callbackId, string json) { }

	// // RVA: 0x2E713A0 Offset: 0x2E713A0 VA: 0x2E713A0
	// private static extern int SakashoUserTokenCancelCreatePlayerFromLineBeforeOauth(int callbackId, string json) { }

	// // RVA: 0x2E714C8 Offset: 0x2E714C8 VA: 0x2E714C8
	// private static extern int SakashoUserTokenCancelCreatePlayerFromTwitterBeforeOauth(int callbackId, string json) { }

	// // RVA: 0x2E715F0 Offset: 0x2E715F0 VA: 0x2E715F0
	private static int SakashoUserTokenClearDeviceLoginDataWithLog(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoUserTokenClearDeviceLoginDataWithLog(callbackId, json);
	}
}
