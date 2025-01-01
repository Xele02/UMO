
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public class ARHeaderMenu : MonoBehaviour
    {
        public enum ARHeaderButton
        {
            None = -1,
            Hamburger = 0,
            Close = 1,
            Camera = 2,
            Share = 3,
            Num = 4,
        }

        public enum ARHeaderButtonPos
        {
            None = 0,
            Left = 1,
            Right = 2,
            Num = 3,
        }

        private static readonly string[] HEADER_BUTTON_TABLE = new string[4]
        {
            "Hamburger", "Close", "Camera", "Share"
        }; // 0x0
        private Dictionary<ARHeaderButton, ARHeaderButtonPos> m_directions = new Dictionary<ARHeaderButton, ARHeaderButtonPos>()
        {
            { ARHeaderButton.Hamburger, ARHeaderButtonPos.Left },
            { ARHeaderButton.Close, ARHeaderButtonPos.Left },
            { ARHeaderButton.Camera, ARHeaderButtonPos.Right },
            { ARHeaderButton.Share, ARHeaderButtonPos.Right }
        }; // 0xC
        private bool m_isInitialized; // 0x10
        private List<Button> m_buttons = new List<Button>(); // 0x14
        private ARHeaderMenu.ARHeaderButton[] m_currentShowButton = new ARHeaderButton[3]; // 0x18

        // RVA: 0x11D5050 Offset: 0x11D5050 VA: 0x11D5050
        public void Start()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679CBC Offset: 0x679CBC VA: 0x679CBC
        // // RVA: 0x11D5074 Offset: 0x11D5074 VA: 0x11D5074
        private IEnumerator Co_Initialize()
        {
            //0x11D5C40
            m_isInitialized = false;
            List<Button> l = new List<Button>(GetComponentsInChildren<Button>(true));
            for(int i = 0; i < 4; i++)
            {
                m_buttons.Add(l.Find((Button _) =>
                {
                    //0x11D5B44
                    return _.name == HEADER_BUTTON_TABLE[i];
                }));
            }
            yield return null;
            for(int i = 0; i < m_buttons.Count; i++)
            {
                m_buttons[i].gameObject.SetActive(false);
            }
            for(int i = 0; i < m_currentShowButton.Length; i++)
            {
                m_currentShowButton[i] = ARHeaderButton.None;
            }
            m_isInitialized = true;
        }

        // // RVA: 0x11D5120 Offset: 0x11D5120 VA: 0x11D5120
        public bool IsReady()
        {
            return m_isInitialized;
        }

        // RVA: 0x11D5128 Offset: 0x11D5128 VA: 0x11D5128
        public void SetEnableOperate(bool isEnable)
        {
            for(int i = 0; i < m_buttons.Count; i++)
            {
                m_buttons[i].targetGraphic.raycastTarget = isEnable;
            }
        }

        // RVA: 0x11D5234 Offset: 0x11D5234 VA: 0x11D5234
        public void SetCallback(ARHeaderButton type, UnityAction callback)
        {
            m_buttons[(int)type].onClick.RemoveAllListeners();
            m_buttons[(int)type].onClick.AddListener(callback);
        }

        // // RVA: 0x11D5338 Offset: 0x11D5338 VA: 0x11D5338
        // public void ShowButtons(ARHeaderMenu.ARHeaderButton[] buttons) { }

        // RVA: 0x11D54DC Offset: 0x11D54DC VA: 0x11D54DC
        public void ShowButton(ARHeaderButton button)
        {
            if(button < ARHeaderButton.Hamburger || button > ARHeaderButton.Share)
                return;
            HideButton(m_directions[button]);
            m_buttons[(int)button].gameObject.SetActive(true);
            m_currentShowButton[(int)m_directions[button]] = button;
        }

        // RVA: 0x11D5620 Offset: 0x11D5620 VA: 0x11D5620
        public void HideButton(ARHeaderButtonPos pos)
        {
            if(pos > ARHeaderButtonPos.None && pos <= ARHeaderButtonPos.Right)
            {
                ARHeaderButton idx = m_currentShowButton[(int)pos];
                if(idx > ARHeaderButton.Share || idx < ARHeaderButton.Hamburger)
                    return;
                m_buttons[(int)idx].gameObject.SetActive(false);
            }
        }
    }
}