
using System.Collections;
using CriWare;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.AR
{
    public class ARMusicPlayer : MonoBehaviour
    {
        private const int FADE_START_TIME = 500;
        private const float FADE_TIME = 0.3f;
        private const float WAIT_TIME = 2;
        [SerializeField]
        private ARCheatSequenceController m_seqControl; // 0xC
        private ARDivaObject m_divaObject; // 0x10
        private bool isChangeSequenceRequest; // 0x15
        public int currentRawMusicMillisec; // 0x18
        public CriAtomExPlayback bgmPlayback; // 0x24
        private bool m_isReStarting; // 0x28

        public bool isPlaying { get; private set; } // 0x14
        public int musicMillisecLength { get; private set; } // 0x1C
        public int musicRequestChangeMillisec { get; private set; } // 0x20
        private BgmPlayer bgmPlayer { get { return SoundManager.Instance.bgmPlayer; } } //0x11E29AC

        // RVA: 0x11E29E0 Offset: 0x11E29E0 VA: 0x11E29E0
        public void Start()
        {
            m_seqControl.enabled = false;
        }

        // RVA: 0x11E2A10 Offset: 0x11E2A10 VA: 0x11E2A10
        public void Update()
        {
            if(isPlaying)
            {
                if(IsPlayingMusicAnimation() && !m_isReStarting)
                {
                    if(IsFinishMusicAnimation())
                    {
                        this.StartCoroutineWatched(Co_ReStart());
                        return;
                    }
                    float t = bgmPlayback.timeSyncedWithAudio;
                    if(t == 0)
                        t = musicRequestChangeMillisec;
                    currentRawMusicMillisec = (int)t;
                    m_divaObject.ChangeAnimationTime(IncludeDeviceLatency(currentRawMusicMillisec) / 1000.0f);
                }
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x677EF4 Offset: 0x677EF4 VA: 0x677EF4
        // // RVA: 0x11E2DBC Offset: 0x11E2DBC VA: 0x11E2DBC
        private IEnumerator Co_ReStart()
        {
            //0x11E37B0
            m_isReStarting = true;
            GameManager.Instance.fullscreenFader.Fade(0.3f, Color.white);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            m_divaObject.PlayMusicAnimation(0);
            yield return new WaitForSeconds(2);
            m_divaObject.LockBoneSpring(0);
            Stop();
            Play();
            m_divaObject.UnlockBoneSpring(true, 0);
            GameManager.Instance.fullscreenFader.Fade(0.3f, 0);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            m_isReStarting = false;
        }

        // // RVA: 0x11E2AF8 Offset: 0x11E2AF8 VA: 0x11E2AF8
        private bool IsPlayingMusicAnimation()
        {
            return m_divaObject.GetCurrentAnimatorStateInfo(0).IsName("music");
        }

        // // RVA: 0x11E2BC4 Offset: 0x11E2BC4 VA: 0x11E2BC4
        private bool IsFinishMusicAnimation()
        {
            if(m_divaObject != null)
            {
                if(IsPlayingMusicAnimation())
                {
                    if(m_divaObject.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                        return true;
                    if(bgmPlayback.timeSyncedWithAudio == 0)
                        return musicRequestChangeMillisec >= musicMillisecLength - 500;
                    return bgmPlayback.timeSyncedWithAudio >= musicMillisecLength - 500;
                }
            }
            return false;
        }

        // RVA: 0x11E2E70 Offset: 0x11E2E70 VA: 0x11E2E70
        public void LateUpdate()
        {
            ApplyChangeMusicSequenceTime();
        }

        // // RVA: 0x11E30E4 Offset: 0x11E30E4 VA: 0x11E30E4
        // public bool IsReady() { }

        // RVA: 0x11E30EC Offset: 0x11E30EC VA: 0x11E30EC
        public void Reset()
        {
            this.StopAllCoroutinesWatched();
            if(m_isReStarting)
            {
                GameManager.Instance.fullscreenFader.Fade(0, 0);
                m_isReStarting = false;
            }
            Stop();
        }

        // RVA: 0x11CE798 Offset: 0x11CE798 VA: 0x11CE798
        public void Setup(ARDivaObject divaObject, int wavId, UnityAction onFinished)
        {
            this.StopAllCoroutinesWatched();
            m_isReStarting = false;
            this.StartCoroutineWatched(Co_Setup(divaObject, wavId, onFinished));
        }

        // [IteratorStateMachineAttribute] // RVA: 0x677F6C Offset: 0x677F6C VA: 0x677F6C
        // // RVA: 0x11E31DC Offset: 0x11E31DC VA: 0x11E31DC
        private IEnumerator Co_Setup(ARDivaObject divaObject, int wavId, UnityAction onFinished)
        {
            //0x11E3BC4
            m_divaObject = divaObject;
            bool isFinished = false;
            bgmPlayer.RequestChangeCueSheet(wavId, () =>
            {
                //0x13AE4E4
                isFinished = true;
            });
            while(!isFinished)
                yield return null;
            bgmPlayer.ChangeMusicCue(wavId);
            musicMillisecLength = bgmPlayer.millisecLength;
            if(onFinished != null)
                onFinished();
        }

        // RVA: 0x11E32D4 Offset: 0x11E32D4 VA: 0x11E32D4
        public void StartPlayMusic()
        {
            Stop();
            Play();
        }

        // // RVA: 0x11E32F0 Offset: 0x11E32F0 VA: 0x11E32F0
        private void Play()
        {
            if(!isPlaying)
            {
                musicRequestChangeMillisec = 0;
                bgmPlayer.source.player.SetStartTime(0);
                bgmPlayback = bgmPlayer.source.Play();
                m_divaObject.PlayMusicAnimation(0);
                isPlaying = true;
                return;
            }
            if(bgmPlayer.source.IsPaused())
                Resume();
            else
                Pause();
        }

        // RVA: 0x11E3534 Offset: 0x11E3534 VA: 0x11E3534
        public void Pause()
        {
            bgmPlayer.source.Pause(true);
            m_divaObject.Pause();
            m_divaObject.LockBoneSpring(0);
        }

        // RVA: 0x11E348C Offset: 0x11E348C VA: 0x11E348C
        public void Resume()
        {
            bgmPlayer.source.Pause(false);
            m_divaObject.Resume();
            m_divaObject.UnlockBoneSpring(true, 0);
        }

        // RVA: 0x11CE4B0 Offset: 0x11CE4B0 VA: 0x11CE4B0
        public void Stop()
        {
            bgmPlayer.source.Stop();
            bgmPlayer.source.Pause(false);
            if(m_divaObject != null)
                m_divaObject.Stop();
            isPlaying = false;
        }

        // // RVA: 0x11E35D8 Offset: 0x11E35D8 VA: 0x11E35D8
        // private void RequestChangeMusicSequenceTime(int millisec) { }

        // // RVA: 0x11E2E74 Offset: 0x11E2E74 VA: 0x11E2E74
        private bool ApplyChangeMusicSequenceTime()
        {
            if(!isChangeSequenceRequest)
                return false;
            else
            {
                if(bgmPlayer.source.status == CriAtomSource.Status.Playing)
                {
                    bgmPlayer.source.player.SetStartTime(Mathf.Clamp(musicRequestChangeMillisec, 0, musicMillisecLength));
                    bgmPlayer.source.player.Stop();
                    bgmPlayback = bgmPlayer.source.player.Start();
                    isChangeSequenceRequest = false;
                    return true;
                }
            }
            return false;
        }

        // // RVA: 0x11E2DA0 Offset: 0x11E2DA0 VA: 0x11E2DA0
        // private float ToSecTime(int millisec) { }

        // // RVA: 0x11E3648 Offset: 0x11E3648 VA: 0x11E3648
        // private float ToMillisecTime(float sec) { }

        // // RVA: 0x11E3668 Offset: 0x11E3668 VA: 0x11E3668
        // private bool IsPlayingMusic() { }

        // // RVA: 0x11E36D0 Offset: 0x11E36D0 VA: 0x11E36D0
        // private bool IsStopMusic() { }

        // RVA: 0x11E3738 Offset: 0x11E3738 VA: 0x11E3738
        public bool IsPaused()
        {
            return bgmPlayer.source.IsPaused();
        }

        // // RVA: 0x11E2E68 Offset: 0x11E2E68 VA: 0x11E2E68
        // private int GetMusicMillisecLength() { }

        // // RVA: 0x11E2D3C Offset: 0x11E2D3C VA: 0x11E2D3C
        // private int GetRawMusicMillisec() { }

        // // RVA: 0x11E2D64 Offset: 0x11E2D64 VA: 0x11E2D64
        private int IncludeDeviceLatency(int rawMillisec)
        {
            return rawMillisec - SoundManager.Instance.estimatedLatencyMillisec;
        }
    }
}