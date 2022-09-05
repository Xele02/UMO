using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DereTore.Exchange.Audio.HCA;
using LibVLCSharp.Shared;
using UnityEngine;
using UnityEngine.Video;
using VGMToolbox.format;

class CriFileTest : MonoBehaviour
{   
    HcaAudioStream audioStream;
    Stream inputStream;
    int curPos = 0;
    static float bytesToFloat(byte firstByte, byte secondByte)
    {
        // convert two bytes to one short (little endian)
        short s = (short)((secondByte << 8) | firstByte);
        // convert to range from -1 to (just below) 1
        return s / 32768.0F;
    }
    public IEnumerator PlayVideo(MemoryStream s)
    {
        //pb.videoPath = s;
        pb.ms = s;
        yield return pb.Prepare();
        pb.PlayPause();
        yield break;
    }

    public Material mat;
    public VLCPlayback pb;
    public CriWare.CriManaMovieController criManaCtrl;

    public bool testAudio;
    public bool testDirectVLC;
    public bool testCriMovie;

    public string audioPath = "/home/xele/.config/unity3d/UtaMacross/UtaMacross/data/android/snd/bgm/cs_w_0001.acb";
    public string moviePath = "/home/xele/Projects/UtaMacrossOffline/Data/android/mov/gm/dv/game_dv_0119_mv_q2!s64ede4a6z!.usm";
    void Awake()
    {
        if(testDirectVLC && pb != null)
        {
            CriUsmStream videoStream = new CriUsmStream(moviePath);
            MpegStream.DemuxOptionsStruct demux = new MpegStream.DemuxOptionsStruct() { ExtractVideo = true, ExtractAudio = false };
            demux.OutputPath = Path.GetTempPath();
            demux.ExtractedFileList = new List<string>();
            demux.Key1 = 0x44C5F5F5;
            demux.Key2 = 0x0581B687;
            demux.ExtractInMemoryStream = true;
            demux.ExtractedMemoryStream = new List<MemoryStream>();
            videoStream.DemultiplexStreams(demux);
            foreach(MemoryStream s in demux.ExtractedMemoryStream)
            {
                //UnityEngine.Debug.Log(s);
                StartCoroutine(PlayVideo(s));
                break;
            }
        }

        if(testCriMovie)
        {
        }

        if(testAudio)
        {
            AudioSource source = GetComponent<AudioSource>();
            CriAcbFile file;
    //        using(FileStream fs = File.Open(Application.streamingAssetsPath+"/snd/bgm/cs_bgm_002.acb", FileMode.Open, FileAccess.Read, FileShare.Read))
            using(FileStream fs = File.Open(audioPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                file = new CriAcbFile(fs, 0, false);
                //file.ExtractAll();
                //bool isStreamed = false;
            }

            string str = file.GetTableAsString(0, true);
            UnityEngine.Debug.Log(str);
            //inputStream = file.GetCueFileStream("bgm_002", out isStreamed);
            //string path = Application.streamingAssetsPath+"/snd/bgm/_vgmt_acb_ext_cs_bgm_002/awb/00000_bgm_002.hca";
            //using (var inputFileStream = File.Open(path, FileMode.Open, FileAccess.Read)) {
            //inputStream = File.Open(path, FileMode.Open, FileAccess.Read);
            {
                //using (MemoryStream outputFileStream = new MemoryStream()) {
                //using (var outputFileStream = File.Open(path.Replace("hca","wav"), FileMode.Create, FileAccess.Write)) {
                    var decodeParams = DecodeParams.CreateDefault(0x44C5F5F5, 0x0581B687);

                    var audioParams = AudioParams.CreateDefault();

                    audioParams.InfiniteLoop = true;
                    audioParams.SimulatedLoopCount = 0;
                    audioParams.OutputWaveHeader = false;

                    //using (var hcaStream = new HcaAudioStream(inputFileStream, decodeParams, audioParams)) {
                    audioStream = new HcaAudioStream(inputStream, decodeParams, audioParams);
                    {
                        //var read = 1;
                        //var dataBuffer = new byte[1024];

                        UnityEngine.Debug.Log("Channel : " + audioStream.HcaInfo.ChannelCount);
                        UnityEngine.Debug.Log("SamplingRate : " + audioStream.HcaInfo.SamplingRate);
                        UnityEngine.Debug.Log("BlockCount : " + audioStream.HcaInfo.BlockCount);
                        UnityEngine.Debug.Log("BlockSize : " + audioStream.HcaInfo.BlockSize);
                        UnityEngine.Debug.Log("Length : " + audioStream.Length);
                        UnityEngine.Debug.Log("LoopFlag : " + audioStream.HcaInfo.LoopFlag);
                        UnityEngine.Debug.Log("LoopEnd : " + audioStream.HcaInfo.LoopEnd);
                        UnityEngine.Debug.Log("LoopStart : " + audioStream.HcaInfo.LoopStart);
                        UnityEngine.Debug.Log("LoopR01 : " + audioStream.HcaInfo.LoopR01);
                        UnityEngine.Debug.Log("LoopR02 : " + audioStream.HcaInfo.LoopR02);
                        int length = System.Int32.MaxValue;
                        if(audioStream.HcaInfo.LoopFlag)
                            source.loop = true;
                        long reallength = (audioStream.Length / (2 * audioStream.HcaInfo.ChannelCount));
                        if(reallength < System.Int32.MaxValue)
                        {
                            length = (int)reallength;
                        }
                        AudioClip clip = AudioClip.Create("test", length, (int)audioStream.HcaInfo.ChannelCount, (int)audioStream.HcaInfo.SamplingRate, true, (float[] data) => {
                            //UnityEngine.Debug.Log("Asked new data ("+data.Length+"), cur pos = "+curPos+" stream pos = "+audioStream.Position);
                            int numLeft = data.Length * 2;
                            byte[] readData = new byte[data.Length * 2];
                            int read = 1;
                            int offset = 0;
                            while(read > 0 && numLeft > 0)
                            {
                                read = audioStream.Read(readData, 0, numLeft);
                                //UnityEngine.Debug.Log("Read "+read);
                                for(int i = 0; i < read; i+=2)
                                {
                                    data[offset] = bytesToFloat(readData[i], readData[i + 1]);
                                    offset++;
                                }
                                numLeft -= read;
                            }
                            curPos += data.Length;
                        }, (int newPos) =>
                        {
                        });
                        source.clip = clip;
                        source.Play();
                    }
                //}
            }
        }
    }
}
