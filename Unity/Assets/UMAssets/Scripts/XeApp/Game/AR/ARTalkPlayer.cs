
using System;
using System.Collections;
using System.Collections.Generic;
using CriWare;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.AR
{
    public class ARTalkPlayer : MonoBehaviour
    {
        private const float WAIT_TIME = 5;
        private const float DEFAULT_TALK_TIME = 3;
        private static readonly int[] MOTION_TABLE = new int[5]
        {
            1, 2, 1, 2, 1
        }; // 0x0
        private List<string> m_cueNameList = new List<string>(); // 0xC
        private ARDivaObject m_divaObject; // 0x10
        private int m_divaId; // 0x14
        private Action m_updater; // 0x18
        private float m_elapsedTime; // 0x1C
        private bool m_isPaused; // 0x20
        private bool m_isNoVoice; // 0x21

        private ARDivaVoicePlayer voARDiva { get { return SoundManager.Instance.voARDiva; } } //0x13AD9EC

        // RVA: 0x13ADA20 Offset: 0x13ADA20 VA: 0x13ADA20
        public void Start()
        {
            //
        }

        // RVA: 0x13ADA24 Offset: 0x13ADA24 VA: 0x13ADA24
        public void Update()
        {
            if(m_isPaused)
                return;
            if(m_updater != null)
                m_updater();
        }

        // // RVA: 0x13ADA48 Offset: 0x13ADA48 VA: 0x13ADA48
        // public bool IsReady() { }

        // // RVA: 0x13ADA50 Offset: 0x13ADA50 VA: 0x13ADA50
        // public bool IsPlaying() { }

        // RVA: 0x13ADA60 Offset: 0x13ADA60 VA: 0x13ADA60
        public bool IsPaused()
        {
            return m_isPaused;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678DCC Offset: 0x678DCC VA: 0x678DCC
        // RVA: 0x13ADA68 Offset: 0x13ADA68 VA: 0x13ADA68
        public IEnumerator Co_Setup(ARDivaObject divaObject, ARMarkerMasterData.Data data)
        {
            string cueSheetName;

            //0x13AE4F4
            m_cueNameList.Clear();
            m_divaObject = divaObject;
            m_divaId = data.divaId;
            cueSheetName = data.cueSheetId;
            if(cueSheetName != "")
            {
                bool isFinish = false;
                SoundManager.Instance.voARDiva.RequestChangeCueSheet(cueSheetName, () =>
                {
                    //0x13AE4E4
                    isFinish = true;
                });
                if(!isFinish)
                    yield return null;
                CriAtomEx.CueInfo[] infos = CriAtom.GetAcb(cueSheetName).GetCueInfoList();
                for(int i = 0; i < infos.Length; i++)
                {
                    m_cueNameList.Add(infos[i].name);
                }
                if(m_cueNameList.Count != 0)
                {
                    m_isNoVoice = false;
                    yield break;
                }
            }
            //LAB_013ae834
            m_isNoVoice = true;
        }

        // RVA: 0x13ADB48 Offset: 0x13ADB48 VA: 0x13ADB48
        public void StartPlay()
        {
            Resume();
            m_elapsedTime = 0;
            m_divaObject.Idle();
            m_updater = UpdateTalk;
        }

        // RVA: 0x13ADCBC Offset: 0x13ADCBC VA: 0x13ADCBC
        public void Pause()
        {
            if(!m_isNoVoice)
            {
                voARDiva.source.Pause(true);
            }
            m_divaObject.Pause();
            m_divaObject.LockBoneSpring(0);
            m_isPaused = true;
        }

        // RVA: 0x13ADC00 Offset: 0x13ADC00 VA: 0x13ADC00
        public void Resume()
        {
            if(!m_isNoVoice)
            {
                voARDiva.source.Pause(false);
            }
            m_divaObject.Resume();
            m_divaObject.UnlockBoneSpring(true, 0);
            m_isPaused = false;
        }

        // RVA: 0x13ADD74 Offset: 0x13ADD74 VA: 0x13ADD74
        public void Stop()
        {
            if(!m_isNoVoice)
            {
                voARDiva.source.Stop();
                voARDiva.source.Pause(false);
            }
            if(m_divaObject != null)
            {
                m_divaObject.Stop();
            }
            m_updater = null;
            m_isPaused = false;
        }

        // // RVA: 0x13ADEDC Offset: 0x13ADEDC VA: 0x13ADEDC
        private void UpdateIdle()
        {
            if(!m_isNoVoice)
            {
                if(voARDiva.isPlaying)
                    return;
            }
            else
            {
                m_elapsedTime += Time.deltaTime;
                if(m_elapsedTime < 3)
                    return;
                m_elapsedTime = 0;
            }
            m_divaObject.TalkEnd();
            m_divaObject.IdleCrossFade(0.5f);
            m_updater = UpdateTalk;
        }

        // // RVA: 0x13AE01C Offset: 0x13AE01C VA: 0x13AE01C
        private void UpdateTalk()
        {
            m_elapsedTime += Time.deltaTime;
            if(m_elapsedTime >= 5)
            {
                m_elapsedTime = 0;
                if(!m_isNoVoice)
                {
                    int max = m_cueNameList.Count;
                    if(max >= MOTION_TABLE.Length)
                    {
                        max = MOTION_TABLE.Length;
                    }
                    int a = UnityEngine.Random.Range(0, max);
                    m_divaObject.Talk(MOTION_TABLE[a]);
                    voARDiva.Play(m_cueNameList[a]);
                }
                else
                {
                    m_divaObject.Talk(MOTION_TABLE[UnityEngine.Random.Range(0, MOTION_TABLE.Length)]);
                }
                m_updater = UpdateIdle;
            }
        }
    }
}
