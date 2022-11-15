
using System;
using System.Collections.Generic;
using System.IO;
using CriWare;
using DereTore.Exchange.Audio.HCA;
using UnityEngine;
using VGMToolbox.format;

namespace ExternLib
{
    public static partial class LibCriWare
    {    
        static float bytesToFloat(byte firstByte, byte secondByte)
        {
            // convert two bytes to one short (little endian)
            short s = (short)((secondByte << 8) | firstByte);
            // convert to range from -1 to (just below) 1
            return s / 32768.0F;
        }

        class PlayerData
        {
            public CriAtomExPlayer.Config config;
            public string cueName = "";
            public int cueId = -1;
            public IntPtr acbPtr;
            public CriAtomExPlayer.Status status = CriAtomExPlayer.Status.Stop;
            public Stream acbStream;
            public HcaAudioStream audioStream;
            public uint currentPlayingId = 0;
        }
        static Dictionary<IntPtr, PlayerData> playersList = new Dictionary<IntPtr, PlayerData>();
        static List<IntPtr> playersToCheckEnd = new List<IntPtr>();
        static int playerCount = 0;

        public static void criAtomExPlayer_Stop(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                if(playersList[player].acbStream != null)
                {
                    UnityEngine.Debug.Log("Stop sound "+playersList[player].cueName+" "+playersList[player].cueId);
                    playersList[player].config.source.unityAudioSource.Stop();
                    playersList[player].config.source.unityAudioSource.clip = null;
                    playersList[player].audioStream = null;
                    playersList[player].acbStream = null;
                    playersList[player].status = CriAtomExPlayer.Status.Stop;
                    if(playersList[player].currentPlayingId != 0)
                        playbacksList.Remove(playersList[player].currentPlayingId);
                    playersList[player].currentPlayingId = 0;
                    playersList[player].cueName = "";
                    playersList[player].cueId = -1;
                }
                playersToCheckEnd.Remove(player);
            }
        }
        public static void criAtomExPlayer_StopWithoutReleaseTime(IntPtr player)
        {
			criAtomExPlayer_Stop(player);
		}
        public static void CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(IntPtr pool)
        {
            TodoLogger.Log(0, "CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear");
        }
        public static void criAtomExPlayer_SetVolume(IntPtr player, float volume)
        {
            if(playersList.ContainsKey(player))
            {
                playersList[player].config.source.unityAudioSource.volume = volume;
            }
        }
        public static void CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy(IntPtr pool)
        {
            TodoLogger.Log(0, "CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy");
        }
        public static IntPtr criAtomExPlayer_Create(ref CriAtomExPlayer.Config config, IntPtr work, int work_size)
        {
            IntPtr ptr = new IntPtr(++playerCount);
            PlayerData data = new PlayerData();
            data.config = config;
            playersList[ptr] = data;
            return ptr;
        }
        public static void criAtomExPlayer_Destroy(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                playersList.Remove(player);
            }
        }
        public static CriAtomExPlayer.Status criAtomExPlayer_GetStatus(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                return playersList[player].status;
            }
            return CriAtomExPlayer.Status.Error;
        }
        public static void criAtomExPlayer_SetStartTime(IntPtr player, long start_time_ms)
        {
            if(playersList.ContainsKey(player))
            {
                playersList[player].config.source.unityAudioSource.time = start_time_ms * 1.0f / 1000.0f;
            }
        }
        public static void criAtomExPlayer_UpdateAll(IntPtr player)
        {
        }
        public static void criAtomExPlayer_Set3dSourceHn(IntPtr player, IntPtr source)
        {
            if(playersList.ContainsKey(player) && srcsList.ContainsKey(source))
            {
                if(playersList[player].config.source.unityAudioSource == srcsList[source].config.source.unityAudioSource)
                    return;
            }
            TodoLogger.Log(0, "criAtomExPlayer_Set3dSourceHn");
        }
        public static void criAtomExPlayer_Set3dListenerHn(IntPtr player, IntPtr listener)
        {
            TodoLogger.Log(0, "criAtomExPlayer_Set3dListenerHn");
        }
        public static void criAtomExPlayer_SetPitch(IntPtr player, float pitch)
        {
            if(playersList.ContainsKey(player))
            {
                // Criware : 0 default, 100 = +1 semitone, -100 = -1 semitone.
                // Unity : 1 default, 1.05946 ^n, n being semitone.
                float numSemitone = pitch / 100;
                float unityVal = Mathf.Pow(1.05946f, numSemitone);
                playersList[player].config.source.unityAudioSource.pitch = unityVal;
            }
        }
		public static void criAtomExPlayer_SetCueName(IntPtr player, IntPtr acb_hn, string cue_name)
		{
			if (playersList.ContainsKey(player))
			{
				if (playersList[player].acbPtr != null)
					criAtomExPlayer_Stop(player);

				playersList[player].acbPtr = acb_hn;
				playersList[player].cueName = cue_name;
				SetupPlayer(playersList[player]);
			}
		}

		private static void SetupPlayer(PlayerData player)
		{
			if (!acbFiles.ContainsKey(player.acbPtr))
            {
				player.status = CriAtomExPlayer.Status.Error;
                return;
            }
			player.status = CriAtomExPlayer.Status.Prep;

			bool isStreaming;
			Stream acbStream;
			player.audioStream = GetAudioStream(acbFiles[player.acbPtr].file, player.cueName, player.cueId, out isStreaming, out acbStream);
			if (player.audioStream == null)
			{
				player.status = CriAtomExPlayer.Status.Error;
				return;
			}
			player.acbStream = acbStream;

			AudioSource source = player.config.source.unityAudioSource;
			source.loop = player.audioStream.HcaInfo.LoopFlag;
			string clipName = player.cueName != "" ? "cue_" + player.cueId : player.cueName;
			AudioClip clip = null;
			if (!acbFiles[player.acbPtr].cachedAudioClips.TryGetValue(clipName, out clip))
			{
				clip = GetClip(player.audioStream, player.cueName, player.cueId, isStreaming);
			}
			source.clip = clip;
			player.status = CriAtomExPlayer.Status.Stop;
            UnityEngine.Debug.Log("Prepared sound "+ player.cueName+" "+ player.cueId);
        }

		private static HcaAudioStream GetAudioStream(CriAcbFile acbFile, string cueName, int cueId, out bool isStreaming, out Stream acbStream)
		{
			var decodeParams = DecodeParams.CreateDefault(0x44C5F5F5, 0x0581B687);
			var audioParams = AudioParams.CreateDefault();
			audioParams.InfiniteLoop = true;
			audioParams.SimulatedLoopCount = 0;
			audioParams.OutputWaveHeader = false;

			if (cueName != "")
				acbStream = acbFile.GetCueFileStream(cueName, out isStreaming);
			else
				acbStream = acbFile.GetCueFileStream(cueId, out isStreaming);
			if (acbStream == null)
				return null;

			HcaAudioStream audioStream = new HcaAudioStream(acbStream, decodeParams, audioParams);
			return audioStream;
		}

		private static AudioClip GetClip(CriAcbFile acbFile, string cueName, int cueId)
		{
			bool isStreaming;
			Stream acbStream;
			HcaAudioStream audioStream = GetAudioStream(acbFile, cueName, cueId, out isStreaming, out acbStream);
			return GetClip(audioStream, cueName, cueId, isStreaming);
		}
		private static AudioClip GetClip(HcaAudioStream audioStream, string cueName, int cueId, bool isStreaming)
		{
			int length = System.Int32.MaxValue;
			long reallength = (audioStream.Length / (2 * audioStream.HcaInfo.ChannelCount));
			if (reallength < System.Int32.MaxValue)
			{
				length = (int)reallength;
			}
			if (audioStream.HcaInfo.LoopFlag)
				isStreaming = true; // Length will be unlimited if loop is checked, so force as if streamed
									//bool debug = player.cueName == "se_valkyrie_001";
			bool debug = false;
			if (debug)
			{
				UnityEngine.Debug.Log("A " + reallength);
				UnityEngine.Debug.Log("A " + cueName);
				UnityEngine.Debug.Log("A " + cueId);
				UnityEngine.Debug.Log("A " + length);
				UnityEngine.Debug.Log("A " + audioStream.HcaInfo.ChannelCount);
				UnityEngine.Debug.Log("A " + audioStream.HcaInfo.SamplingRate);
				UnityEngine.Debug.Log("A " + isStreaming);
			}

			byte[] readData = null;
			AudioClip clip = null;
			//if(isStreaming)
			{
				clip = AudioClip.Create(cueName, length, (int)audioStream.HcaInfo.ChannelCount, (int)audioStream.HcaInfo.SamplingRate, isStreaming, (float[] data) => {
					if (debug)
						UnityEngine.Debug.Log("Asked new data (" + data.Length + "), cur pos = " +/*curPos+*/" stream pos = " + audioStream.Position);
					int numLeft = data.Length * 2;
					if (readData == null || readData.Length < data.Length * 2)
					{
						readData = new byte[data.Length * 2];
					}
					int read = 1;
					int offset = 0;
					while (read > 0 && numLeft > 0)
					{
						read = audioStream.Read(readData, 0, numLeft);
						if (debug)
							UnityEngine.Debug.Log("Read " + read);
						for (int i = 0; i < read; i += 2)
						{
							data[offset] = bytesToFloat(readData[i], readData[i + 1]);
							offset++;
						}
						numLeft -= read;
					}
					//curPos += data.Length;
				}, (int newPos) =>
				{
					audioStream.Seek(newPos * 2, SeekOrigin.Begin);
				});
			}
			/*else
            {
                clip = AudioClip.Create(cueName, length, (int)audioStream.HcaInfo.ChannelCount, (int) audioStream.HcaInfo.SamplingRate, false);
                float[] samples = new float[clip.samples * clip.channels];
                byte[] read = new byte[2];
                for(int i = 0; i < samples.Length; i++)
                {
                    audioStream.Read(read, 0, 2);
                    samples[i] = bytesToFloat(read[0], read[1]);
                }
                clip.SetData(samples, 0);
            }*/
			return clip;
		}

		public static void criAtomExPlayer_LimitLoopCount(IntPtr player, int count)
        {
            TodoLogger.Log(0, "criAtomExPlayer_LimitLoopCount");
        }
        public static IntPtr criAtomExPlayer_GetPlayerParameter(IntPtr player)
        {
            TodoLogger.Log(100, "criAtomExPlayer_GetPlayerParameter");
            return IntPtr.Zero;
        }
        public static void criAtomExPlayerParameter_RemoveParameter(IntPtr player_parameter, ushort id)
        {
            TodoLogger.Log(100, "criAtomExPlayerParameter_RemoveParameter");
        }
        public static uint criAtomExPlayer_Start(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                AudioSource source = playersList[player].config.source.unityAudioSource;
                source.Play();
                UnityEngine.Debug.Log("Play sound "+playersList[player].cueName+" "+playersList[player].cueId);
                playersList[player].status = CriAtomExPlayer.Status.Playing;
                playersList[player].currentPlayingId = (uint)++playbackCount;
                PlaybackInfo pbinfo = new PlaybackInfo();
                pbinfo.playerPtr = player;
                pbinfo.sourcePtr = playersList[player].config.source.source.nativeHandle;
                playbacksList[playersList[player].currentPlayingId] = pbinfo;
                if(!source.loop)
                    playersToCheckEnd.Add(player);
                return playersList[player].currentPlayingId;
            }
            return 0;
        }
        public static void criAtomExPlayer_SetCueId(IntPtr player, IntPtr acb_hn, int id)
        {
            if(playersList.ContainsKey(player))
            {
                playersList[player].acbPtr = acb_hn;
				playersList[player].cueName = "";
                playersList[player].cueId = id;
				SetupPlayer(playersList[player]);
            }
        }
        public static void criAtomExPlayer_Pause(IntPtr player, bool sw)
        {
            TodoLogger.Log(0, "criAtomExPlayer_Pause");
        }
        public static void criAtomExPlayer_Resume(IntPtr player, CriAtomEx.ResumeMode mode)
        {
            TodoLogger.Log(0, "criAtomExPlayer_Resume");
        }
        public static bool criAtomExPlayer_IsPaused(IntPtr player)
        {
            TodoLogger.Log(0, "criAtomExPlayer_IsPaused");
            return false;
        }
        public static void CheckSoundStatus()
        {
            List<IntPtr> playersStopped = new List<IntPtr>();
            for(int i = playersToCheckEnd.Count - 1; i >= 0; i--)
            {
                AudioSource source = playersList[playersToCheckEnd[i]].config.source.unityAudioSource;
                if(!source.isPlaying)
                {
                    playersStopped.Add(playersToCheckEnd[i]);
                }
            }
            for(int i = 0; i < playersStopped.Count; i++)
            {
                criAtomExPlayer_Stop(playersStopped[i]);
            }
        }

        public static void criAtomExPlayer_SetPanType(IntPtr player, CriAtomEx.PanType panType)
		{
			TodoLogger.Log(0, "criAtomExPlayer_SetPanType");
		}
    }
}
