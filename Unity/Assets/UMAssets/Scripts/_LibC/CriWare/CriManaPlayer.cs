
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using CriWare.CriMana;
using LibVLCSharp.Shared;
using UnityEngine;
using VGMToolbox.format;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        public class MoviePlayerData
        {
            public int playerId;
            public string filePath;
            public VLCPlayback playback;

            public Player.Status status;
            public bool loop;

            public MovieInfo movieInfo;
        }

        static Dictionary<int, MoviePlayerData> moviePlayers = new Dictionary<int, MoviePlayerData>();
        static int moviePlayerCnt = 0;

        public static void CRIWARE044D0246_criManaUnityPlayer_SetCuePointCallback(int player_id, Player.CuePointCallbackFromNativeDelegate cbfunc)
        {
            UnityEngine.Debug.LogError("CRIWARE044D0246_criManaUnityPlayer_SetCuePointCallback");
        }

        public static void CRIWARECB5086D8_criManaUnityPlayer_Prepare(int player_id)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                moviePlayers[player_id].status = Player.Status.Dechead;
                if(moviePlayers[player_id].playback == null)
                {
                    moviePlayers[player_id].playback = VLCManager.Instance.gameObject.AddComponent<VLCPlayback>();
                    CriUsmStream videoStream = new CriUsmStream(moviePlayers[player_id].filePath);
                    MpegStream.DemuxOptionsStruct demux = new MpegStream.DemuxOptionsStruct() { ExtractVideo = true, ExtractAudio = false };
                    demux.ExtractedFileList = new List<string>();
                    demux.Key1 = 0x44C5F5F5;
                    demux.Key2 = 0x0581B687;
                    demux.ExtractInMemoryStream = true;
                    demux.ExtractedMemoryStream = new List<MemoryStream>();
                    videoStream.DemultiplexStreams(demux);
                    moviePlayers[player_id].movieInfo = videoStream.movieInfo;
                    foreach(MemoryStream s in demux.ExtractedMemoryStream)
                    {
                        moviePlayers[player_id].playback.ms = s;
                        moviePlayers[player_id].playback.SetLoop(moviePlayers[player_id].loop);
                        moviePlayers[player_id].playback.StartCoroutineWatched(moviePlayers[player_id].playback.Prepare());
                        break;
                    }
                }
            }
        }

        public static void CRIWARE3D38F2C2_criManaUnityPlayer_Start(int player_id)
        {
            if(!moviePlayers.ContainsKey(player_id))
                return;
            MoviePlayerData player = moviePlayers[player_id];
            player.playback.StartPlay();
            player.status = Player.Status.Playing;
        }

        public static void CRIWARE0C381E92_criManaUnityPlayer_Stop(int player_id)
        {
            if(!moviePlayers.ContainsKey(player_id))
                return;
            MoviePlayerData player = moviePlayers[player_id];
            player.playback.Stop();
            player.status = Player.Status.Stop;
        }

        public static int CRIWAREFE53CA2C_criManaUnityPlayer_Update(int player_id, IntPtr subtitle_buffer, ref uint subtitle_size)
        {
            if(!moviePlayers.ContainsKey(player_id))
                return (int)Player.Status.Dechead;
            MoviePlayerData player = moviePlayers[player_id];
            if(player.status == Player.Status.Dechead)
            {
                if(player.playback != null && player.playback.IsReady())
                {
                    player.status = Player.Status.WaitPrep;
                }
            }
            else if(player.status == Player.Status.WaitPrep)
            {
                player.status = Player.Status.Prep;
            }
            else if(player.status == Player.Status.Prep)
            {
                // Need to see what event change prep to ready, instead of directly going on next call
                player.status = Player.Status.Ready;
                UnityEngine.Debug.Log("CriMana, player is ready");
            }
            else if(player.status == Player.Status.Playing)
            {
                if(player.playback.GetState() == VLCState.Ended)
                {
                    player.status = Player.Status.PlayEnd;
                }
                else if(player.playback.GetState() == VLCState.Error)
                {
                    player.status = Player.Status.Error;
                }
                /*else if(player.playback.GetState() == VLCState.Stopped)
                {
                    player.status = Player.Status.Stop;
                }*/
            }
            return (int)player.status;
        }

        public static void CRIWARED22E1E28_criManaUnityPlayer_Pause(int player_id, int sw)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                moviePlayers[player_id].playback.Pause(sw != 0);
            }
        }

        public static void CRIWARE851F97C9_criManaUnityPlayer_Loop(int player_id, int sw)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                moviePlayers[player_id].loop = sw != 0;
                if(moviePlayers[player_id].playback != null)
                    moviePlayers[player_id].playback.SetLoop(sw != 0);
            }
        }

        public static void CRIWARE941BB516_criManaUnityPlayer_SetFile(int player_id, IntPtr binder, string path)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                moviePlayers[player_id].filePath = path;
            }
        }
        public static bool CRIWARE7FE26661_criManaUnityPlayer_EntryFile(int player_id, IntPtr binder, string path, bool repeat)
        {
            UnityEngine.Debug.LogError("CRIWARE7FE26661_criManaUnityPlayer_EntryFile");
            return true;
        }

        public static bool CRIWARE1E2E4671(int player_id)
        {
            if(moviePlayers.ContainsKey(player_id) && moviePlayers[player_id].playback != null)
            {
                moviePlayers[player_id].playback.IsPaused();
            }
            return false;
        }

        public static void CRIWAREC92A5005(int player_id, int seek_frame_no)
        {
            // seek
        }

        public static bool CRIWARE6C94B6FB(int player_id)
        {
            UnityEngine.Debug.LogError("CRIWARE6C94B6FB");
            return true;
        }

        public static void CRIWAREC9D98FAA(int player_id)
        {
            UnityEngine.Debug.LogError("CRIWAREC9D98FAA");
        }

        public static int CRIWARE4B9FFA91_criManaUnityPlayer_Create()
        {
            return CRIWARED1C9883A_criManaUnityPlayer_Create(true, 0);
        }

        public static int CRIWARED1C9883A_criManaUnityPlayer_Create(bool useAtomExPlayer, uint maxPathLength)
        {
            MoviePlayerData player = new MoviePlayerData();
            player.playerId = ++moviePlayerCnt;
            player.status = Player.Status.Stop;
            moviePlayers.Add(player.playerId, player);
            return player.playerId;
        }

        public static IntPtr CRIWARE453735B6(int player_id)
        {
            UnityEngine.Debug.LogError("CRIWARE453735B6");
            return IntPtr.Zero;
        }

        public static sbyte CRIWARE9BAE0415(int player_id) // GetNumberOfFrameBeforeDestroy
        {
            return 0;
        }

        public static bool CRIWARED6D2B5F7(int player_id, int num_textures, IntPtr[] tex_ptrs, FrameInfo frame_info, ref bool frame_drop)
        {
            if(moviePlayers.ContainsKey(player_id) && moviePlayers[player_id].playback != null)
            {
                frame_info.time = (ulong)moviePlayers[player_id].playback.GetTime();
                frame_info.tunit = 1000000;
            }
            frame_drop = false;
            return true;
        }

        public static bool CRIWARE14DB4020(int player_id, int num_textures, [In] [Out] IntPtr[] tex_ptrs)
        {
            return true;
        }

        public static void CRIWARE6AEEBF51(int player_id) // desallocate subtitle buffer
        {
			TodoLogger.Log(TodoLogger.CriManaPlugin, "CRIWARE6AEEBF51");
        }

        public static IntPtr CRIWARE91AA6C29(int player_id, int bufferSize)
		{
			TodoLogger.Log(TodoLogger.CriManaPlugin, "CRIWARE91AA6C29");
			return IntPtr.Zero;
        }

        public static void CRIWARE6536ABE0_criManaUnityPlayer_Destroy(int player_id)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                if(moviePlayers[player_id].playback != null)
                {
                    moviePlayers[player_id].playback.CleanAndDestroy();
                }
                moviePlayers.Remove(player_id);
            }
        }

        public static void CRIWARE55BA8D00(int player_id) // Frame update ?
		{
			TodoLogger.Log(TodoLogger.CriManaPlugin, "CRIWARE55BA8D00");
		}

        public static void CRIWARE51B54144(int player_id, ulong user_count, ulong user_unit)
		{
			TodoLogger.Log(TodoLogger.CriManaPlugin, "CRIWARE51B54144");
		}

        public static void CRIWARE4A28D964_criManaUnityPlayer_GetMovieInfo(int player_id, out MovieInfo movie_info)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                movie_info = moviePlayers[player_id].movieInfo;
                return;
            }
            movie_info = null;
        }

        public static Texture2D GetVLCTexture(int player_id)
        {
            if(moviePlayers.ContainsKey(player_id))
            {
                return moviePlayers[player_id].playback.GetTexture();
            }
            return null;
        }
    }
}
