
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.DownLoad
{
    public class DownLoadDivaTexture
    {
        private Texture2D baseTexture; // 0x8
        private Texture2D maskTexture; // 0xC
        private Material material; // 0x10

        // RVA: 0x11BD5F4 Offset: 0x11BD5F4 VA: 0x11BD5F4
        public DownLoadDivaTexture(Texture2D baseTexture, Texture2D maskTexture)
        {
            this.baseTexture = baseTexture;
            this.maskTexture = maskTexture;
            material = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
            material.SetTexture("_MainTex", baseTexture);
            material.SetTexture("_MaskTex", maskTexture);
        }

        // RVA: 0x11BD704 Offset: 0x11BD704 VA: 0x11BD704
        public void Set(RawImageEx image)
        {
            if(image == null)
                return;
            image.MaterialMul = material;
            image.texture = baseTexture;
        }
    }

    public class DownLoadDivaTextureCache
    {
        private static DownLoadDivaTextureCache sm_instance; // 0x0
        private Dictionary<int, DownLoadDivaTexture> m_divaGraphicCache = new Dictionary<int, DownLoadDivaTexture>(); // 0x8
        private Dictionary<int, Action<DownLoadDivaTexture>> m_loadInfo = new Dictionary<int, Action<DownLoadDivaTexture>>(); // 0xC

        public static DownLoadDivaTextureCache Instance { get { return sm_instance; } } //0x11BD7F0

        // // RVA: 0x11BD87C Offset: 0x11BD87C VA: 0x11BD87C
        public static DownLoadDivaTextureCache Create()
        {
            if(sm_instance == null)
            {
                sm_instance = new DownLoadDivaTextureCache();
            }
            return sm_instance;
        }

        // // RVA: 0x11BDA64 Offset: 0x11BDA64 VA: 0x11BDA64
        public static void Release()
        {
            if(sm_instance != null)
                sm_instance = null;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6B5800 Offset: 0x6B5800 VA: 0x6B5800
        // // RVA: 0x11BDB30 Offset: 0x11BDB30 VA: 0x11BDB30
        public IEnumerator LoadDivaGraphicCoroutine(int divaId, Action<DownLoadDivaTexture> callback)
        {
            //0x11BDD60
            DownLoadDivaTexture tex = null;
            if(m_divaGraphicCache.TryGetValue(divaId, out tex))
            {
                callback(tex);
            }
            else
            {
                if(!m_loadInfo.ContainsKey(divaId))
                {
                    m_loadInfo.Add(divaId, callback);
                    Texture2D baseTexture = null;
                    Texture2D maskTexture = null;
                    ResourcesManager.Instance.Load(string.Format("CmnTex/DownLoad/cmn_download_{0:D2}_base", divaId), (FileResultObject fo) => {
                        //0x11BDC1C
                        baseTexture = fo.unityObject as Texture2D;
                        return true;
                    });
                    ResourcesManager.Instance.Load(string.Format("CmnTex/DownLoad/cmn_download_{0:D2}_mask", divaId), (FileResultObject fo) => {
                        //0x11BDCBC
                        maskTexture = fo.unityObject as Texture2D;
                        return true;
                    });
                    while(baseTexture == null || maskTexture == null)
                        yield return null;
                    tex = new DownLoadDivaTexture(baseTexture, maskTexture);
                    m_divaGraphicCache.Add(divaId, tex);
                    m_loadInfo[divaId].Invoke(tex);
                    m_loadInfo.Remove(divaId);
                }
                else
                {
                    m_loadInfo[divaId] += callback;
                }
            }
        }
    }
}