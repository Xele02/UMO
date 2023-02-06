using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Common
{
    public enum SizeType
    {
        Small = 0,
        Middle = 1,
        Large = 2,
        SSmall = 3,
        Large2 = 4,
    }

    [Serializable]
    public struct ButtonInfo
    {
        public PopupButton.ButtonLabel Label { get; set; } // 0x0
        public PopupButton.ButtonType Type { get; set; } // 0x4
    }

    [Serializable]
    public abstract class PopupSetting // TypeDefIndex: 17510
    {
        private bool mIsCaption = true; // 0x8
        private PopupButton.ButtonLabel backButtonLabel; // 0xC
        private PopupButton.ButtonLabel negativeButtonLabel; // 0x10
        public Transform m_parent; // 0x20
        protected GameObject m_content; // 0x24
        private ButtonInfo[] m_buttons = new ButtonInfo[0]; // 0x28
        private PopupTabButton.ButtonLabel[] m_tabs = new PopupTabButton.ButtonLabel[0]; // 0x2C
        private PopupTabButton.ButtonLabel m_defaultTab = PopupTabButton.ButtonLabel.None; // 0x30

        public string TitleText { get; set; } // 0x14
        public SizeType WindowSize { get; set; } // 0x18
        public bool IsOpenAnimeMoment { get; set; } // 0x1C
        public ButtonInfo[] Buttons { get { return m_buttons; } set { m_buttons = value; } } //0x1BACEDC 0x1BB218C
        public PopupTabButton.ButtonLabel[] Tabs { get { return m_tabs; } set { m_tabs = value; } } //0x1BB2194 0x1BB219C
        public PopupTabButton.ButtonLabel DefaultTab { get { return m_defaultTab; } set { m_defaultTab = value; } } //0x1BB21A4 0x1BB21AC
        public PopupButton.ButtonLabel BackButtonLabel { get { return backButtonLabel; } set { backButtonLabel = value; } }// 0x1BB21B4 0x1BB21BC
        public PopupButton.ButtonLabel NegativeButtonLabel { get { return negativeButtonLabel; } set { negativeButtonLabel = value; } } //0x1BB21C4 0x1BB21CC
        public abstract string PrefabPath { get; } // Slot: 5
        public virtual bool IsCaption { get { return mIsCaption; } set { mIsCaption = value; } } //0x1BB247C 0x1BB2484
        public virtual string BundleName { get { return ""; } } //0x1BB248C
        public virtual string AssetName { get { return ""; } }  //0x1BB24E8
        public virtual bool IsAssetBundle { get { return false; } } //0x1BB2544
        public virtual bool IsPreload { get { return false; } } //0x1BB254C
        public virtual GameObject Content { get { return m_content; } } //0x1BB2554

        // [IteratorStateMachineAttribute] // RVA: 0x73F164 Offset: 0x73F164 VA: 0x73F164
        // // RVA: 0x1BAE8B8 Offset: 0x1BAE8B8 VA: 0x1BAE8B8 Slot: 4
        public virtual IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            //0x1BB2568
            AssetBundleLoadLayoutOperationBase operation;
            if(m_content != null)
                yield break;
            operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
            yield return Co.R(operation);
            yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
                //0x1BB255C
                m_content = instance;
            }));
            AssetBundleManager.UnloadAssetBundle(BundleName, false);
            m_content.transform.SetParent(m_parent, false);
            m_content.gameObject.SetActive(false);
            operation = null;
        }

        // // RVA: 0x1BB21F4 Offset: 0x1BB21F4 VA: 0x1BB21F4
        public void SetParent(Transform parent)
        {
            m_parent = parent;
            if(m_content == null)
                return;

            m_content.transform.SetParent(parent, false);
            m_content.gameObject.SetActive(false);
        }

        // // RVA: 0x1BB2320 Offset: 0x1BB2320 VA: 0x1BB2320
        // public void Destroy() { }

        // // RVA: 0x1BB23F0 Offset: 0x1BB23F0 VA: 0x1BB23F0
        public bool ISLoaded()
        {
            return m_content != null;
        }
    }
}
