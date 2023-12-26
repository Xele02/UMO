
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeSys.uGUI;

namespace XeApp.Game.AR
{
    public class ARCheatSequenceController : MonoBehaviour
    {
        //[TooltipAttribute] // RVA: 0x5DA2D0 Offset: 0x5DA2D0 VA: 0x5DA2D0
        [SerializeField]
        private float fasterSpeedValue; // 0xC
        [SerializeField]
        //[TooltipAttribute] // RVA: 0x5DA318 Offset: 0x5DA318 VA: 0x5DA318
        private float skipSecond; // 0x10
        private GameObject sequenceControlObject; // 0x14
        private Slider sequenceBar; // 0x18
        private float sequenceBarWidth; // 0x1C
        private Text musicTime; // 0x20
        private Text musicLongText; // 0x24
        private GameObject favariteObject; // 0x28
        public Button playButton; // 0x2C
        public Button pauseButton; // 0x30
        public Button stopButton; // 0x34
        public Button rewindButton; // 0x38
        public Button forwardButton; // 0x3C
        public Button skipPrevButton; // 0x40
        public Button skipNextButton; // 0x44
        public Button reloadButton; // 0x48
        public Button favariteJumpButton; // 0x4C
        public Button favariteSetButton; // 0x50
        private UGUILongPress longPressRewind; // 0x54
        private UGUILongPress longPressForward; // 0x58
        private int favariteValue; // 0x5C
        private StringBuilder timeStringBuilder = new StringBuilder(); // 0x60
        private bool isInUpdateChange; // 0x64
        public Action playAction; // 0x68
        public Action pauseAction; // 0x6C
        public Action stopAction; // 0x70
        public Action reloadAction; // 0x74
        public Action<int> changeTimeAction; // 0x78
        public Func<int> getMusicTimeFunc; // 0x7C
        public Func<int> getMusicLengthFunc; // 0x80

        // // RVA: 0x1614410 Offset: 0x1614410 VA: 0x1614410
        // public void Initialize() { }

        // // RVA: 0x16153D0 Offset: 0x16153D0 VA: 0x16153D0
        // public void OnUpdate() { }

        // // RVA: 0x1615744 Offset: 0x1615744 VA: 0x1615744
        // private void KeyboardControl() { }

        // // RVA: 0x16159C8 Offset: 0x16159C8 VA: 0x16159C8
        // private void SetContollerInteractable(bool active) { }

        // // RVA: 0x1615AE4 Offset: 0x1615AE4 VA: 0x1615AE4
        // public void Open() { }

        // // RVA: 0x1615B1C Offset: 0x1615B1C VA: 0x1615B1C
        // public void Close() { }

        // // RVA: 0x161584C Offset: 0x161584C VA: 0x161584C
        // public void Play() { }

        // // RVA: 0x1615910 Offset: 0x1615910 VA: 0x1615910
        // public void Pause() { }

        // // RVA: 0x1615B54 Offset: 0x1615B54 VA: 0x1615B54
        // public void Stop() { }

        // // RVA: 0x1615244 Offset: 0x1615244 VA: 0x1615244
        // public void ApplyMusicLengthToSequenceBar() { }

        // // RVA: 0x16152EC Offset: 0x16152EC VA: 0x16152EC
        // public void ApplyMusicLengthToText() { }

        // // RVA: 0x1615594 Offset: 0x1615594 VA: 0x1615594
        // private void Rewind() { }

        // // RVA: 0x161566C Offset: 0x161566C VA: 0x161566C
        // private void Forward() { }

        // // RVA: 0x1615C18 Offset: 0x1615C18 VA: 0x1615C18
        // private void SkipPrev() { }

        // // RVA: 0x1615CDC Offset: 0x1615CDC VA: 0x1615CDC
        // private void SkipNext() { }

        // // RVA: 0x1615DA0 Offset: 0x1615DA0 VA: 0x1615DA0
        // private void Reload() { }

        // // RVA: 0x1615DD4 Offset: 0x1615DD4 VA: 0x1615DD4
        // private void FavariteJump() { }

        // // RVA: 0x1615E54 Offset: 0x1615E54 VA: 0x1615E54
        // private void FavariteSet() { }

        // // RVA: 0x1616020 Offset: 0x1616020 VA: 0x1616020
        // private void ChangedMusicSequenceBarValueDelegate(float value) { }
    }
}