
using System;
using System.Collections.Generic;
using CriWare;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        class PlaybackInfo
        {
            public IntPtr sourcePtr;
            public IntPtr playerPtr;
        }
        static Dictionary<uint, PlaybackInfo> playbacksList = new Dictionary<uint, PlaybackInfo>();
        static int playbackCount = 0;

        public static long criAtomExPlayback_GetTimeSyncedWithAudio(uint id)
        {
#if !UNITY_ANDROID
			if(playbacksList.ContainsKey(id) && playersList.ContainsKey(playbacksList[id].playerPtr))
            {
                PlayerData player = playersList[playbacksList[id].playerPtr];
                return (long)((player.config.source.unityAudioSource.time) * 1000);
            }
#endif
            return 0;
        }

        public static CriAtomExPlayback.Status criAtomExPlayback_GetStatus(uint id)
        {
            if(playbacksList.ContainsKey(id) && playersList.ContainsKey(playbacksList[id].playerPtr))
            {
                PlayerData player = playersList[playbacksList[id].playerPtr];
                if(player.status == CriAtomExPlayer.Status.Playing)
                    return CriAtomExPlayback.Status.Playing;
                if(player.status == CriAtomExPlayer.Status.Prep)
                    return CriAtomExPlayback.Status.Prep;
            }
            return CriAtomExPlayback.Status.Removed;
        }

		public static void criAtomExPlayback_Stop(uint id)
		{
			if (playbacksList.ContainsKey(id) && playersList.ContainsKey(playbacksList[id].playerPtr))
			{
				criAtomExPlayer_Stop(playbacksList[id].playerPtr);
			}
		}
		public static void criAtomExPlayback_StopWithoutReleaseTime(uint id)
		{
			if (playbacksList.ContainsKey(id) && playersList.ContainsKey(playbacksList[id].playerPtr))
			{
				criAtomExPlayer_StopWithoutReleaseTime(playbacksList[id].playerPtr);
			}
		}

        public static void criAtomExPlayback_Pause(uint id, bool sw)
        {
			if (playbacksList.ContainsKey(id) && playersList.ContainsKey(playbacksList[id].playerPtr))
			{
				criAtomExPlayer_Pause(playbacksList[id].playerPtr, sw);
			}
        }

		public static void criAtomExPlayback_Resume(uint id, CriAtomEx.ResumeMode mode)
		{
			if (playbacksList.ContainsKey(id) && playersList.ContainsKey(playbacksList[id].playerPtr))
			{
				criAtomExPlayer_Resume(playbacksList[id].playerPtr, mode);
			}
		}
	}
#endif
}
